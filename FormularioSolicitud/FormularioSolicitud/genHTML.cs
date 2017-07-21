using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SOCIOS
{
    class genHTML
    {
        BO_Datos dlog = new BO_Datos();

        public void gHTML(string ADTO, string ORIGEN_ALTA, int PAR, int ORDEN, string IND, int AFI_BEN, int O, int A)
        {
            DateTime Hoy = DateTime.Today;
            string fecha_actual = Hoy.ToString("dd-MM-yyyy");
            string origen = ORIGEN_ALTA.Substring(3, 3);
            string mes = ADTO.Substring(3, 2);
            string anio = ADTO.Substring(6, 4);

            string query = "SELECT APE_SOC, NOM_SOC, NUM_DOC, AAR, ACRJP2, NRO_SOC, LEG_PER FROM TITULAR WHERE 1=1";

            if (A == 1)
                query += " AND A_DTO = '" + anio + "/" + mes + "/01'";

            if (O == 1)
                query += " AND ORIGEN_ALTA = '" + origen + "'";

            if (AFI_BEN == 1 && IND != "")
                query += " AND AAR = " + IND.Substring(0, 1) + " AND ACRJP2 = " + IND.Substring(1, 6) + "";

            if (AFI_BEN == 2 && IND != "")
                query += " AND PCRJP1 = " + IND.Substring(0, 2) + " AND PCRJP2 = " + IND.Substring(2, 6) + " AND PCRJP3 = " + IND.Substring(8, 1) + "";

            query += " AND PAR = " + PAR + "";

            query += " AND F_BAJCI IS NULL";

            if (ORDEN == 1)
                query += " ORDER BY APE_SOC, NOM_SOC;";
            else
                query += " ORDER BY AAR, ACRJP2;";

            int CODIGO = 0;

            if (AFI_BEN == 1)
                CODIGO = 633;
            
            if (AFI_BEN == 2)
                CODIGO = 640;

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            //MessageBox.Show(query);
            //Clipboard.SetDataObject(query);

            if (foundRows.Length > 0)
            {
                string html = "<html><body style='font-family:arial;'>";

                int x = 1;

                for (int i = 0; i <= foundRows.Length - 1; i++)
                {
                    html += "<table width='900' border='0' cellspacing='4'>";

                    html += "<tr><td colspan='3' align='center'>Circulo de Suboficiales de la Policia Federal Argentina <div>Asociaci&oacute;n Civil Fundada el 7 de Marzo de 1957 con Personer&iacute;a Jur&iacute;dica Otorgada el 26 de Mayo de 1958 <br/> CUIT: 30-51658821-3 </div> </td></tr>";
                    
                    html += "<tr><td colspan='3'><div align='center' style='font-size:26px;font-weight:bold;'>AUTORIZACI&Oacute;N</div></td></tr>";
                    
                    html += "<tr><td><div style='font-size:18px;font-weight:bold;text-decoration:underline;'>ALTA DESCUENTO</div></td><td>&nbsp;</td><td>FECHA: <strong>" + fecha_actual + "</strong></td></tr>";
                    
                    html += "<tr><td>APELLIDO: <strong>" + foundRows[i][0] + "</strong></td><td>&nbsp;</td><td>NOMBRES: <strong>" + foundRows[i][1] + "</strong></td></tr>";
                    
                    html += "<tr><td>DNI: <strong>" + foundRows[i][2] + "</strong></td><td>&nbsp;</td><td>AFILIADO. C.R.J Y P.F.A: <strong>" + foundRows[i][3] + "/" + foundRows[i][4] + "</strong></td></tr>";

                    html += "<tr><td>LP: <strong>" + foundRows[i][6] + "</strong></td><td>&nbsp;</td><td>NRO SOCIO: <strong>" + foundRows[i][5] + "</strong></td></tr>";
                    
                    html += "<tr><td colspan='3' style='border:1px solid #333;padding:6px;'>Autorizo en este acto al CSPFA a efectuar el descuento mensual de la Cuota Societaria de mis Haberes seg&uacute;n detalle, firmando al pie de la presente en conformidad.-</td></tr>";
                    
                    html += "<tr><td align='center' style='border:1px solid #CCC;'>CONCEPTO</td><td align='center' style='border:1px solid #CCC;'>COD.DTO.</td><td align='center' style='border:1px solid #CCC;'>HABERES</td></tr>";
                    
                    html += "<tr><td align='center' style='border:1px solid #CCC;font-weight:bold;'>ALTA</td><td align='center' style='border:1px solid #CCC;font-weight:bold;'>" + CODIGO + "</td><td align='center' style='border:1px solid #CCC;font-weight:bold;'><strong>" + mes + "/" + anio + "</strong></td></tr>";
                    
                    html += "<tr><td height='120'></td><td>&nbsp;</td><td></td></tr>";
                    
                    html += "<tr><td valign='bottom' align='center' style='border-top:1px dashed #333;'>FIRMA DEL SOCIO TITULAR</td><td>&nbsp;</td><td valign='bottom' align='center' style='border-top:1px dashed #333;'>ACLARACI&Oacute;N</td></tr>";
                    
                    html += "</table>";
                    
                    html += "<br/><br/>";
                    
                    html += "<div style='width:900px;height:1px;border-top:1px dashed #000;'></div>";
                    
                    html += "<br/><br/>";

                    if (x != 3)
                    {
                        x++;
                    }
                    else
                    {
                        html += "<br style='page-break-after: always;' />";
                        x=1;
                    }
                }

                html += "</body></html>";

                string fileName = "temp.html";
                StreamWriter writer = File.CreateText(fileName);
                writer.WriteLine(html);
                writer.Close();

                previewHTML ph = new previewHTML(html);
                ph.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se encontraron datos");
            }
        }
    }
}
