﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.RegularExpressions;
using System.Net;
using System.Configuration;

using System.Text;
using Microsoft.Reporting.WinForms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Drawing;

namespace SOCIOS.Factura_Electronica
{
    public class DataBarra
    {
     public byte [] Barra  {get; set;}
    }
     
    public class Impresor_Factura
    {
        string DIRECTORIO = "";
        string leyenda_TC = "";
        string Leyenda_Direccion = "";
        string Leyenda_Forma_Pago = "";
        string Leyenda_Domicilio = "";
        string Leyenda_Profesional = "";
        string DIRECTORIO_TEMP = @"C:\CSPFA_SOCIOS\TMP\";
        bo dlog = new bo();
        QrHelper QR = new QrHelper();

        public Impresor_Factura(string pDIR)
        {
            DIRECTORIO = pDIR;
        }

        public void Genero_PDF(int pTipo_Comprobante,int pPunto_De_Venta,int pNumero,DateTime pFecha,string pCuit,string pIva,string pNombre,decimal pMonto,string pCAE,string pVENC,string pOrden, string pConcepto,int ID_BONO )

        {
            ReportDataSource rds = new ReportDataSource();
            ReportParameter[] para = new ReportParameter[18];
            ReportViewer viewer = new ReportViewer();
            FacturaCSPFA facturaService = new FacturaCSPFA(pPunto_De_Venta);
            int TipoDoc=0;
            if (pCuit.Length > 8)
                  {
                                TipoDoc = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.CUIT;
                                
                  } else
                    { TipoDoc = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.DNI;
            
                    }

           System.Drawing.Image Image_Qr = QR.QR_TS(pFecha, pPunto_De_Venta, pTipo_Comprobante, pNumero, pMonto, TipoDoc, pCuit, pCAE);

          
          

            if (pTipo_Comprobante == (int)SOCIOS.Factura_Electronica.Tipo_Comprobante_Enum.RECIBO_C)
                leyenda_TC = "RECIBO C";
            else
                leyenda_TC = "NOTA DE CREDITO C ";

         //   Leyenda_Direccion = this.Direccion_Pto_Vta(pPunto_De_Venta);
            this.Get_Datos_Bono(ID_BONO);
            this.get_Leyenda_Profesional(ID_BONO);
            string fileName =leyenda_TC+"-PV " + pPunto_De_Venta.ToString() + "- NRO " + pNumero.ToString() + ".pdf";
          //  fileName = "testing.pdf";

            string Codigo_Barra = facturaService.Codigo_Barra(pTipo_Comprobante.ToString(),pPunto_De_Venta,pCAE,pVENC);
            ReportParameter Tipo_Comp       = new ReportParameter("TIPO_COMPROBANTE",leyenda_TC.ToString());
            ReportParameter PtoVenta        = new ReportParameter("PUNTO_DE_VENTA", pPunto_De_Venta.ToString("00000"));
            ReportParameter Numero          = new ReportParameter("NUMERO",pNumero.ToString("00000000") );
            ReportParameter Fecha           = new ReportParameter("FECHA", pFecha.ToShortDateString());
            ReportParameter Cuit            = new ReportParameter("CUIT_SOCIO",pCuit.ToString() );
            ReportParameter Iva             = new ReportParameter("IVA_SOCIO", pIva.ToString());
            ReportParameter Nombre          = new ReportParameter("NOMBRE_SOCIO", pNombre.ToString());
            ReportParameter Domicilio       = new ReportParameter("DOMICILIO_SOCIO", Leyenda_Domicilio);
            ReportParameter Monto           = new ReportParameter("MONTO", pMonto.ToString());
            ReportParameter CAE             = new ReportParameter("CAE", pCAE);
            ReportParameter VENC            = new ReportParameter("VENC", pVENC);
            ReportParameter Barra           = new ReportParameter("BARCODE",Codigo_Barra);
            ReportParameter Orden           = new ReportParameter("ORDEN", pOrden);
            ReportParameter Condicion_Venta = new ReportParameter("CONDICION_VENTA", Leyenda_Forma_Pago);
            ReportParameter Concepto        = new ReportParameter("CONCEPTO", pConcepto);
            ReportParameter Direccion                  =  new ReportParameter("DIRECCION",Leyenda_Direccion);
            ReportParameter Leyenda_profesional         = new ReportParameter("LEYENDA", Leyenda_Profesional);
            ReportParameter QR_P               = new ReportParameter("QR", ImageToBase64(Image_Qr));
            para[0] = Tipo_Comp;
            para[1] = PtoVenta;
            para[2] = Numero;
            para[3] = Fecha;
            para[4] = Cuit;
            para[5] = Iva;
            para[6] = Nombre;
            para[7] = Domicilio;
           
            para[8] = CAE;
            para[9] = VENC;
            para[10] = Barra;
            para[11] = Monto;
            para[12] = Orden;
            para[13] = Condicion_Venta;
            para[14] = Concepto;
            para[15] = Direccion;
            para[16] = Leyenda_profesional;
            para[17] = QR_P;
            string Excepcion = "";

            try
            {
                viewer.ProcessingMode = ProcessingMode.Local;


                viewer.LocalReport.ReportPath = "Factura.rdlc";

                string RUTA = DIRECTORIO + fileName;
                string RUTA_TEMP = DIRECTORIO_TEMP + fileName;
               

                viewer.LocalReport.DataSources.Add(new ReportDataSource("DataBarra", this.getCodigoBarra(Codigo_Barra)));
                viewer.LocalReport.EnableExternalImages = true;
                viewer.LocalReport.SetParameters(para);
                viewer.LocalReport.Refresh();

                byte[] Bytes = viewer.LocalReport.Render(format: "PDF", deviceInfo: "");
                //RUTA=RUTA.Replace("//", "/");
                //RUTA_TEMP = RUTA_TEMP.Replace("//", "/");
             using    (FileStream stream = new FileStream(RUTA_TEMP, FileMode.Create))
                {
                    stream.Write(Bytes, 0, Bytes.Length);
                }

             this.BorrarUltimaPagina(RUTA_TEMP, RUTA);


            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message);  
                
            }

        
        }

        public string ImageToBase64(System.Drawing.Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            { //Convert Image to byte[]
                image.Save(ms,image.RawFormat); byte[] imageBytes = ms.ToArray();
                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String; 
            }
        }

        private List<DataBarra> getCodigoBarra(string Codigo)
        {
            List<DataBarra> lista = new List<DataBarra>();
            DataBarra item = new DataBarra();
            Barcode128 code128 = new Barcode128();


            code128.CodeType = Barcode.CODE128;
            code128.ChecksumText = true;
            code128.GenerateChecksum = true;
            code128.Code = Codigo;
            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(code128.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
            System.Drawing.Image i = (System.Drawing.Image)bm;

          
            item.Barra = Utils.imageToByteArray(i);
            
            
            lista.Add(item);
            return lista;

        
        }


        private void BorrarUltimaPagina(string archivoBorrarPagina, string archivoBorradoPagina)
        {
            // get input document
            PdfReader inputPdf = new PdfReader(archivoBorrarPagina);

            // retrieve the total number of pages
            int pageCount = inputPdf.NumberOfPages;

            //if (paginaFin < paginaInicio || paginaFin > pageCount)
            //{
            //    paginaFin = pageCount;
            //}

            // load the input document
            Document inputDoc =
                new Document(inputPdf.GetPageSizeWithRotation(1));

            // create the filestream
            using (FileStream fs = new FileStream(archivoBorradoPagina, FileMode.Create))
            {
                // create the output writer
                PdfWriter outputWriter = PdfWriter.GetInstance(inputDoc, fs);
                inputDoc.Open();
                PdfContentByte cb1 = outputWriter.DirectContent;

                // copy pages from input to output document
                for (int i = 1; i <= pageCount - 1; i++)
                {
                    inputDoc.SetPageSize(inputPdf.GetPageSizeWithRotation(i));
                    inputDoc.NewPage();

                    PdfImportedPage page =
                        outputWriter.GetImportedPage(inputPdf, i);
                    int rotation = inputPdf.GetPageRotation(i);

                    if (rotation == 90 || rotation == 270)
                    {
                        cb1.AddTemplate(page, 0, -1f, 1f, 0, 0,
                            inputPdf.GetPageSizeWithRotation(i).Height);
                    }
                    else
                    {
                        cb1.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                    }
                }

                inputDoc.Close();
            }
        }


        public string Direccion_Pto_Vta(int PuntoVenta)
        {
            string Punto_Venta = ToString().PadLeft(4, '0');
            string QUERY = @"Select Domicilio from puntos_de_Venta where pto_Venta='" + Punto_Venta+"'";     


            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return foundRows[0][0].ToString().Trim();
            }
            else
                return "";
        }

        public void Get_Datos_Bono(int ID)

        {
            int Forma_Pago;
            

            string QUERY = @"select B.Forma_pago, trim(T.CALL_PAR) || ' '|| trim(T.NRO_PAR) || ' '|| trim(T.PIS_PAR) || ' '|| trim (T.DPT_PAR),P.LEYENDA, P.NOMBRE   from recibos_caja B, Titular T,Profesionales P  where  B.dni=T.num_doc and B.ID_PROFESIONAL=P.ID  and B.ID=" + ID.ToString();
            



            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                Forma_Pago = Int32.Parse(foundRows[0][0].ToString());
                Leyenda_Domicilio = foundRows[0][1].ToString();
                this.Get_Forma_Pago(Forma_Pago);

                //if (foundRows[0][2].ToString().Length > 0)
                //    Leyenda_Profesional = foundRows[0][2].ToString() + " " + foundRows[0][3].ToString();
                //else
                //    Leyenda_Profesional = "";

            }
            else
            {
                this.Get_Forma_Pago_X_Recibo(ID);
            }
            
        
        }



        public void Get_Forma_Pago(int ID)
        {



            string QUERY = @"select detalle from formas_De_pago where ID=" + ID.ToString();




            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                Leyenda_Forma_Pago = foundRows[0][0].ToString();
            

            }


        }
        public void Get_Forma_Pago_X_Recibo(int ID)
        {



            string QUERY = @"select F.detalle From recibos_caja R, Formas_De_Pago F where  R.ID=" + ID.ToString() + " and R.Forma_Pago=F.ID";




            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                Leyenda_Forma_Pago = foundRows[0][0].ToString();


            }


        }
        public void get_Leyenda_Profesional(int ID)

        {
            string QUERY = @"select P.LEYENDA, P.NOMBRE   from recibos_caja B,Profesionales P  where   B.ID_PROFESIONAL=P.ID  and B.ID=" + ID.ToString();




            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                  if (foundRows[0][0].ToString().Length > 0)
                      Leyenda_Profesional = foundRows[0][0].ToString() + " " + foundRows[0][1].ToString();
                else
                    Leyenda_Profesional = "";


            }
        
        
        }
    }

    }




