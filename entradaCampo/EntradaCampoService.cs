using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace SOCIOS
{
    public class RegistroEntradaCampo

    {
        public int     ID         { get; set; }
        public int     TipoValor  { get; set; }
        public string     Tipo       { get; set; }
        public decimal Monto      { get; set; }

    
    }



    public class  EntradaCampo
    {
        public int      ID                            { get; set; }
        public string ROL                             { get; set; }
        public DateTime FECHA                         { get; set; }

        public string   Tipo                          { get; set; }
        public string   DNI                           { get; set; }
        public string   NOMBRE                        { get; set; }
        public string   APELLIDO                      { get; set; }
   
        public int      NRO_SOCIO                     { get; set; }
        public int      NRO_DEP                       { get; set; }
        public int      INVITADO                      { get; set; }
        public decimal  MONTO_INVITADO                { get; set; }

        public int      INVITADO_PILETA               { get; set; }
        public decimal  MONTO_INVITADO_PILETA         { get; set; }
        public int      INVITADO_ESTACIONAMIENTO      { get; set; }
        public decimal  MONTO_INVITADO_EST            { get; set; }

        public int      SOCIO                         { get; set; }
        public decimal  MONTO_SOCIO                   { get; set; }
        public int      SOCIO_PILETA                  { get; set; }
        public decimal  MONTO_SOCIO_PILETA            { get; set; }
        public int      SOCIO_ESTACIONAMIENTO         { get; set; }
        public decimal  MONTO_SOCIO_EST               { get; set; }

        public int     INTERCIRCULO                   { get; set; }
        public decimal MONTO_INTER                    { get; set; }

        public int     INTERCIRCULO_PILETA            { get; set; }
        public decimal MONTO_INTERCIRCULO_PILETA      { get; set; }

        public int      INTERCIRCULO_ESTACIONAMIENTO  { get; set; }
        public decimal  MONTO_INTERCIRCULO_EST        { get; set; }

        public int      TOTAL                         { get; set; }
        public decimal  MONTO_TOTAL                   { get; set; }
  
        public string   USER                          { get; set; }
      
        public DateTime BAJA                          { get; set; }
        public string   USR_BAJA                      { get; set; }
        public bool     PROCESADO                     { get; set; }
     
        public int      MENOR                         { get; set; }
        public int      DISCAPACITADO                 { get; set; }
        public int      DISCAPACITADO_ACOM            { get; set; }
        public int      ID_INTERNO                    { get; set; }
        public int      LEGAJO                        { get; set; }
        public string   OBS_CUMPLE                    { get; set; }
        public int      ID_REAL                       { get; set; }
        public int      EVENTO                        { get; set; }
        public decimal  MONTO_EVENTO                  { get; set; }
        public string   HORA                          { get; set; }

    }


    public class EntradaCampoReporte : EntradaCampo

    { 
    
    


    
    }


    
    public  class EntradaCampoService
    {
       private int SectAct_Entrada = 0;
       private int SectAct_Pileta = 0;
       private int Secact_Estacionamiento = 0;
       private int Secact_Evento = 0;

        private int Prof_Entrada = 0;
       private int Prof_Pileta = 0;
       
       private int Prof_Estacionamiento = 0;

       private int Prof_Evento = 0;
       

       public decimal EntradaSocio                 = 0;
       public decimal EntradaSocioPileta           = 0;
       public decimal EntradaSocioEstacionamiento  = 0;   
       
       public decimal EntradaInvi                  = 0;
       public decimal EntradaInviPileta            = 0;
       public decimal EntradaInviEstacionamiento   = 0;

       public decimal  EntradaInter                = 0;
       public decimal  EntradaInterPileta          = 0;
       public decimal  EntradaInterEstacionamiento = 0;
       
       public decimal EntradaEvento = 0;
        
           
       public decimal TotalSocio  =0;
       public decimal TotalSocioPileta = 0;
       public decimal TotalSocioEstacionamiento = 0;

       public decimal TotalInvi = 0;
       public decimal TotalInviPileta = 0;
       public decimal TotalInviEstacionamiento = 0;

       public decimal TotalInter = 0;
       public decimal TotalInterPileta = 0;
       public decimal TotalInterEstacionamiento = 0;

       public decimal TotalEvento = 0;

       public string Titulo = "";
       public int ID = 0;
       string Dato1 = "";
       string Dato2 = "";
       decimal Total = 0;
       int Socio = 0;
       int SocioPileta = 0;
       int SocioEstacionamiento = 0;
       
        int Invitado = 0;
       int InvitadoPileta = 0;
       int InvitadoEstacionamiento = 0;
      
        int Intercirculo = 0;
       int IntercirculoPileta = 0;
       int IntercirculoEstacionamiento = 0;

       int Menor = 0;
       int Disca = 0;
       int Oro = 0;

       int Evento = 0;

       string Hora = "";

       public string ORIGINAL_DUPLICADO = "";
       
       SOCIOS.descuentos.TXT_Utils txtUtils = new descuentos.TXT_Utils();


       bo_Entrada_Campo dlog = new bo_Entrada_Campo();
        
        public EntradaCampoService()

        {

            arancel Aran = new arancel();
            SectAct_Entrada  = Int32.Parse(Config.getValor(VGlobales.vp_role, "CAMPO_ENTRADA", 0));
            Prof_Entrada     = Int32.Parse(Config.getValor(VGlobales.vp_role, "CAMPO_ENTRADA", 1));
            SectAct_Pileta   =  Int32.Parse(Config.getValor(VGlobales.vp_role, "CAMPO_PILETA", 0));
            Prof_Pileta      = Int32.Parse(Config.getValor(VGlobales.vp_role, "CAMPO_PILETA", 1));
            Secact_Estacionamiento = Int32.Parse(Config.getValor(VGlobales.vp_role, "CAMPO_EST", 0));
            Prof_Estacionamiento = Int32.Parse(Config.getValor(VGlobales.vp_role, "CAMPO_EST", 1));

            Secact_Evento = Int32.Parse(Config.getValor(VGlobales.vp_role, "CAMPO_ESTDEPO", 0));
            Prof_Evento   = Int32.Parse(Config.getValor(VGlobales.vp_role, "CAMPO_ESTDEPO", 1));
            
            EntradaSocio       = Aran.valorGrupo(SectAct_Entrada, 1, Prof_Entrada);
            EntradaInter       = Aran.valorGrupo(SectAct_Entrada, 2, Prof_Entrada);
            EntradaInvi        = Aran.valorGrupo(SectAct_Entrada, 3, Prof_Entrada);
            

            EntradaSocioPileta = Aran.valorGrupo(SectAct_Pileta, 1, Prof_Pileta);
            EntradaInterPileta = Aran.valorGrupo(SectAct_Pileta, 2, Prof_Pileta);
            EntradaInviPileta  = Aran.valorGrupo(SectAct_Pileta, 3, Prof_Pileta);

            EntradaSocioEstacionamiento = Aran.valorGrupo(Secact_Estacionamiento, 1, Prof_Estacionamiento);
            EntradaInterEstacionamiento = Aran.valorGrupo(Secact_Estacionamiento, 2, Prof_Estacionamiento);
            EntradaInviEstacionamiento  = Aran.valorGrupo(Secact_Estacionamiento, 3, Prof_Estacionamiento);


            EntradaEvento = Decimal.Parse(Config.getValor("CPOCABA", "CAMPO_ESTDEPO", 0));
            

            Titulo = Config.getValor(VGlobales.vp_role, "TICKET", 0);


        }


        public void Imprimir(int pSocio, int pSocioPileta,int pSocioEst, int pinvitado, int pinvitadoPileta,int pinvitadoEst, int pInter, int pInterPileta,int pInterEst,int pMenor, int pDisca, int pOro, int pID,string pDato1,string pDato2,bool Reintegro,bool Totales_reintegro,bool Original,string User,int pEvento,bool Totales,bool ImpresionDirecta,string pHora)

        {

            Socio = pSocio;
            SocioPileta = pSocioPileta;
            SocioEstacionamiento = pSocioEst;

            Invitado = pinvitado;
            InvitadoPileta = pinvitadoPileta;
            InvitadoEstacionamiento = pinvitadoEst;

            Intercirculo = pInter;
            IntercirculoPileta = pInterPileta;
            IntercirculoEstacionamiento = pInterEst;

            Evento = pEvento;

             TotalSocio                =   Decimal.Round( EntradaSocio * Socio,2);
             TotalSocioPileta          =   Decimal.Round(EntradaSocioPileta * SocioPileta, 2);
             TotalSocioEstacionamiento =   Decimal.Round( EntradaSocioEstacionamiento * SocioEstacionamiento, 2);
             
             TotalInvi                 =   Decimal.Round(EntradaInvi * Invitado, 2);
             TotalInviPileta           =   Decimal.Round(EntradaInviPileta * InvitadoPileta, 2);
             TotalInviEstacionamiento  =    Decimal.Round(EntradaInviEstacionamiento * InvitadoEstacionamiento, 2);
             
             TotalInter = Decimal.Round(EntradaInter * Intercirculo, 2);
             TotalInterPileta = Decimal.Round(EntradaInterPileta * IntercirculoPileta, 2);
             TotalInterEstacionamiento = Decimal.Round(EntradaInterEstacionamiento * IntercirculoEstacionamiento, 2);
             TotalEvento = Decimal.Round(EntradaEvento * Evento, 2);

             Menor = pMenor;
             Disca = pDisca;
             Oro = pOro;
             Hora = pHora;

             if (Evento > 0 && !Totales)
                 Titulo = "EST. EVENTO " + VGlobales.vp_role.TrimEnd().TrimStart();
            //Tipo 1 , Ticket normal 2: Reintegro , 3 : Total
            
             if (Reintegro || Totales_reintegro)
                 Titulo = Titulo + "-Reintegro";


             ID = pID;

             if (Original)
                 ORIGINAL_DUPLICADO = User + "-"+ ID.ToString() + "-ORIGINAL"  ;
             else
                 ORIGINAL_DUPLICADO =  User + "-"+ ID.ToString() + "-DUPLICADO";
            


             Total = Decimal.Round(TotalSocio + TotalSocioPileta + TotalSocioEstacionamiento+ TotalInvi + TotalInviPileta + TotalInviEstacionamiento + TotalInter + TotalInterPileta + TotalInterEstacionamiento + TotalEvento, 2);
         
             Dato1 = pDato1;
             Dato2 = pDato2;
             PrintDialog pd = new PrintDialog(); 
             PrintDocument pdoc = new PrintDocument();

             if (ImpresionDirecta)
                pdoc.PrintController = new System.Drawing.Printing.StandardPrintController();
             
            PaperSize psize = new PaperSize();
             
             pd.Document = pdoc;
             pd.Document.DefaultPageSettings.PaperSize = psize;

          

            if (!Totales_reintegro)
                pdoc.PrintPage += new PrintPageEventHandler(pdoc_Print);
             else
                 pdoc.PrintPage += new PrintPageEventHandler(pdoc_Print_Reintegro);
            
            //DialogResult result = pd.ShowDialog();


            //if (result == DialogResult.OK)
            //{
                pdoc.Print();
                Titulo = Config.getValor(VGlobales.vp_role, "TICKET", 0);
            //}

         
        
        }

        public void Imprimir(int ID,bool Directo)

        {
            EntradaCampo ec = this.getRegistroEntradaCampo(ID);

            
            this.Imprimir(ec.SOCIO, ec.SOCIO_PILETA, ec.SOCIO_ESTACIONAMIENTO, ec.INVITADO, ec.INVITADO_PILETA, ec.INVITADO_ESTACIONAMIENTO, ec.INTERCIRCULO, ec.INTERCIRCULO_PILETA, ec.INTERCIRCULO_ESTACIONAMIENTO, ec.MENOR, ec.DISCAPACITADO, ec.DISCAPACITADO_ACOM, ec.ID, ec.DNI + "-" + ec.APELLIDO + "," + ec.NOMBRE, ec.Tipo, false, false, false,"",ec.EVENTO,false,Directo,ec.HORA);

        }




        public void Imprimir_Pileta(string pDatosSocio,string pLeyenda,bool ImpresionDirecta)
        {

            



        
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            
            if (ImpresionDirecta)
               pdoc.PrintController = new System.Drawing.Printing.StandardPrintController();

            PaperSize psize = new PaperSize();
            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;

      
            Dato1 = pDatosSocio;
            Dato2 = pLeyenda;


            pdoc.PrintPage += new PrintPageEventHandler(pPileta_Print);
           

            //DialogResult result = pd.ShowDialog();


            //if (result == DialogResult.OK)
            //{
                pdoc.Print();
            //}



        }



        public void Impresion_Totales(List<SOCIOS.EntradaCampo> lista,string User)

        {

            int Socio = lista.Sum(x => x.SOCIO);
            int Socio_Pileta = lista.Sum(x => x.SOCIO_PILETA);
            int Socio_Estacionamiento = lista.Sum(x => x.SOCIO_ESTACIONAMIENTO);
            int Invitado = lista.Sum(x => x.INVITADO);
            int Invitado_Pileta = lista.Sum(x => x.INVITADO_PILETA);
            int Invitado_Estacionamiento = lista.Sum(x => x.INVITADO_ESTACIONAMIENTO);
            int Inter = lista.Sum(x => x.INTERCIRCULO);
            int Inter_Pileta = lista.Sum(x => x.INTERCIRCULO_PILETA);
            int Inter_Estacionamiento = lista.Sum(x => x.INTERCIRCULO_ESTACIONAMIENTO);
            int Menor = lista.Sum(x => x.MENOR);
            int Disca = lista.Sum(x => x.DISCAPACITADO);
            int Disca_Acom = lista.Sum(x => x.DISCAPACITADO_ACOM);
            int Evento = lista.Sum(x => x.EVENTO);

            string LeyendaTotales = "";

            LeyendaTotales = "TOTALES DE " + lista.OrderBy(x => x.ID).FirstOrDefault().ID.ToString() + " A " + lista.OrderByDescending(x => x.ID).FirstOrDefault().ID.ToString(); 


            this.Imprimir(Socio, Socio_Pileta, Socio_Estacionamiento, Invitado, Invitado_Pileta, Invitado_Estacionamiento, Inter, Inter_Pileta, Inter_Estacionamiento, Menor, Disca, Disca_Acom,0, LeyendaTotales , System.DateTime.Now.ToString(), false,false,true,User,Evento,true,false,"");

        
        }


        public void Impresion_Totales_Reintegro(List<SOCIOS.EntradaCampo> lista)
        {

            lista = lista.Where(x => x.MONTO_TOTAL < 0).ToList();

            int Socio = lista.Sum(x => x.SOCIO) ;
            int Socio_Pileta = lista.Sum(x => x.SOCIO_PILETA);
            int Socio_Estacionamiento = lista.Sum(x => x.SOCIO_ESTACIONAMIENTO);
            int Invitado = lista.Sum(x => x.INVITADO) ;
            int Invitado_Pileta = lista.Sum(x => x.INVITADO_PILETA) ;
            int Invitado_Estacionamiento = lista.Sum(x => x.INVITADO_ESTACIONAMIENTO);
            int Inter = lista.Sum(x => x.INTERCIRCULO);
            int Inter_Pileta = lista.Sum(x => x.INTERCIRCULO_PILETA);
            int Inter_Estacionamiento = lista.Sum(x => x.INTERCIRCULO_ESTACIONAMIENTO);
            int Menor = lista.Sum(x => x.MENOR);
            int Disca = lista.Sum(x => x.DISCAPACITADO);
            int Disca_Acom = lista.Sum(x => x.DISCAPACITADO_ACOM);
            string LeyendaTotales = "";

           




            if (lista.Count > 0)
            {
                LeyendaTotales = "TOTALES REINT " + lista.OrderBy(x => x.ID).FirstOrDefault().ID.ToString() + " A " + lista.OrderByDescending(x => x.ID).FirstOrDefault().ID.ToString(); 

                this.Imprimir(Socio, Socio_Pileta, Socio_Estacionamiento, Invitado, Invitado_Pileta, Invitado_Estacionamiento, Inter, Inter_Pileta, Inter_Estacionamiento, Menor, Disca, Disca_Acom, 0, LeyendaTotales, System.DateTime.Now.ToString(), false, true, true,"",Evento,false,false,"");
            }


        }



        public void pdoc_Print(object sender, PrintPageEventArgs e)
        {
            Barcode39 code39 = new Barcode39();
            code39.CodeType = Barcode.CODE128;
            code39.ChecksumText = false;
            code39.GenerateChecksum = false;
            code39.X = 40;
            Graphics graphics = e.Graphics;
            Font courier_big = new Font("FontA1x1", 10);
            Font courier_med = new Font("FontA1x1", 7);
            SolidBrush black = new SolidBrush(Color.Black);
            int startX = 0;
            int startY = 0;
            int Offset = 0;
            string TOTAL = "";

            DateTime hoy = System.DateTime.Now;
            string Horalocal =  hoy.Hour.ToString() + ":" + hoy.Minute.ToString();

            if (Hora != null)
            {  if (Hora.Length ==0)
                  Hora = Horalocal;

            }
            graphics.DrawString(hoy.Day.ToString() + "-" + hoy.Month.ToString() + "-" + hoy.Year.ToString() + "-" + Hora + ORIGINAL_DUPLICADO, courier_big, black, startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString(Titulo, courier_big, black, startX, startY + Offset);
            Offset = Offset + 20;
          
            
        
            graphics.DrawString(Dato1, courier_big, black, startX, startY + Offset);
                Offset = Offset + 20;
            
            graphics.DrawString(Dato2, courier_big, black, startX, startY + Offset);
            Offset = Offset + 20;



            if (TotalEvento > 0)
            {
                graphics.DrawString(Evento.ToString("00") + txtUtils.CompletarBlancos("-EST.", true, 17), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$" +  TotalEvento.ToString(), courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;
            }
            else if (Evento >0)
            {
                graphics.DrawString(Evento.ToString("00") + txtUtils.CompletarBlancos("-EST.", true, 17), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$0", courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;

            }

            if (TotalSocio > 0)
            {
                graphics.DrawString(Socio.ToString("00") + txtUtils.CompletarBlancos("-SOCIOS        ", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$" + TotalSocio.ToString(), courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;
            }
            else if (Socio >0 )
            {
                graphics.DrawString(Socio.ToString("00") + txtUtils.CompletarBlancos("-SOCIOS        ", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$0", courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;
            
            }
             if (TotalSocioPileta >0)
             {
                 graphics.DrawString(SocioPileta.ToString("00") + txtUtils.CompletarBlancos("-Pil SOCIO     ", true, 15), courier_big, black, startX, startY + Offset);
                 graphics.DrawString(":$" + TotalSocioPileta.ToString(), courier_big, black, startX + 150, startY + Offset);
                 Offset = Offset + 20;
            }

             if (TotalSocioEstacionamiento > 0)
             {
                 graphics.DrawString(SocioEstacionamiento.ToString("00") + txtUtils.CompletarBlancos("-Est SOCIO     ", true, 15), courier_big, black, startX, startY + Offset);
                 graphics.DrawString(":$" +TotalSocioEstacionamiento.ToString(), courier_big, black, startX + 150, startY + Offset);
                 Offset = Offset + 20;
             
             }

             if (TotalInvi >0)
             {
                 graphics.DrawString(Invitado.ToString("00") + txtUtils.CompletarBlancos("-INVI          ", true, 15), courier_big, black, startX, startY + Offset);
            graphics.DrawString(":$" + TotalInvi.ToString(), courier_big, black, startX + 150, startY + Offset);
                 Offset = Offset + 20;
            }
             if (TotalInviPileta >0)
             {
                 graphics.DrawString(InvitadoPileta.ToString("00") + txtUtils.CompletarBlancos("-Pil INVI      ", true, 15), courier_big, black, startX, startY + Offset);
                 graphics.DrawString(":$" + TotalInviPileta.ToString(), courier_big, black, startX + 150, startY + Offset);
                 Offset = Offset + 20;
            }

             if (TotalInviEstacionamiento > 0)
             {
                 graphics.DrawString(InvitadoEstacionamiento.ToString("00") + txtUtils.CompletarBlancos("-Est INVI      ", true, 15), courier_big, black, startX, startY + Offset);
                 graphics.DrawString(":$" + TotalInviEstacionamiento.ToString(), courier_big, black, startX + 150, startY + Offset);
                 Offset = Offset + 20;
             
             }

             if (TotalInter > 0)

             {
                 graphics.DrawString(Intercirculo.ToString("00") + txtUtils.CompletarBlancos("-INTER         ", true, 15), courier_big, black, startX, startY + Offset);
                 graphics.DrawString(":$" + TotalInter.ToString(), courier_big, black, startX + 150, startY + Offset);
                 Offset = Offset + 20;
             
             }

             if (TotalInterPileta > 0)

             {
                 graphics.DrawString(IntercirculoPileta.ToString("00") + txtUtils.CompletarBlancos("-Pil INTER     ", true, 15), courier_big, black, startX, startY + Offset);
                 graphics.DrawString(":$" + TotalInterPileta.ToString(), courier_big, black, startX + 150, startY + Offset);
                 Offset = Offset + 20;
             
             }

             if (TotalInterEstacionamiento > 0)
             {

                 graphics.DrawString(IntercirculoEstacionamiento.ToString("00") + txtUtils.CompletarBlancos("-Est INTER     ", true, 15), courier_big, black, startX, startY + Offset);
                 graphics.DrawString(":$" + TotalInterEstacionamiento.ToString(), courier_big, black, startX + 150, startY + Offset);
                 Offset = Offset + 20;
             
             }

             if (Menor > 0)
             {
                 graphics.DrawString(Menor.ToString("00") + txtUtils.CompletarBlancos("-Pil MENOR     ", true, 15), courier_big, black, startX, startY + Offset);
                 graphics.DrawString(":$0", courier_big, black, startX + 150, startY + Offset);
                 Offset = Offset + 20;
             }

             if (Disca > 0)
             {
                 graphics.DrawString(Disca.ToString("00") + txtUtils.CompletarBlancos("-Pil DISC      ", true, 15), courier_big, black, startX, startY + Offset);
                 graphics.DrawString(":$0", courier_big, black, startX + 150, startY + Offset);
                 Offset = Offset + 20;
             }

             if (Oro > 0)
             {
                 graphics.DrawString(Oro.ToString("00") + txtUtils.CompletarBlancos("-Pil Vit.Oro", true, 15), courier_big, black, startX, startY + Offset);
                 graphics.DrawString(":$0", courier_big, black, startX + 150, startY + Offset);
                 Offset = Offset + 20;
             }


             graphics.DrawString(" TOTAL ", courier_big, black, startX, startY + Offset);
             graphics.DrawString(":$" + Total.ToString(), courier_big, black, startX + 150, startY + Offset); 
             Offset = Offset + 20;

            


            code39.Code = "CR - " + ID.ToString();
            Bitmap bm = new Bitmap(code39.CreateDrawingImage(Color.Black, Color.White));
            graphics.DrawImage(bm, startX, startY + Offset);
            Offset = Offset + 40;
            
            graphics.DrawString(".", courier_med, black, startX, startY + Offset);
            Offset = Offset + 10;
            graphics.DrawString("LOS REINTEGROS SE EFECTUAN", courier_big, black, startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("DENTRO DE LAS  2 HS", courier_big, black, startX, startY + Offset);


        }


        public void pPileta_Print(object sender, PrintPageEventArgs e)
        {
            Barcode39 code39 = new Barcode39();
            code39.CodeType = Barcode.CODE128;
            code39.ChecksumText = false;
            code39.GenerateChecksum = false;
            code39.X = 40;
            Graphics graphics = e.Graphics;
            Font courier_big = new Font("FontA1x1", 10);
            Font courier_med = new Font("FontA1x1", 7);
            SolidBrush black = new SolidBrush(Color.Black);
            int startX = 0;
            int startY = 0;
            int Offset = 0;
            string TOTAL = "";

            DateTime hoy = System.DateTime.Now;
            string Hora = hoy.Hour.ToString() + ":" + hoy.Minute.ToString();
            graphics.DrawString(hoy.Day.ToString() + "-" + hoy.Month.ToString() + "-" + hoy.Year.ToString() + "-" + Hora, courier_big, black, startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString(Titulo, courier_big, black, startX, startY + Offset);
            Offset = Offset + 20;



            graphics.DrawString(Dato1, courier_big, black, startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString(Dato2, courier_big, black, startX, startY + Offset);
          
            Offset = Offset + 20;
            graphics.DrawString("LOS REINTEGROS SE EFECTUAN", courier_big, black, startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("DENTRO DE LAS 2 HS", courier_big, black, startX, startY + Offset);





        }





        public void pdoc_Print_Reintegro(object sender, PrintPageEventArgs e)
        {
            Barcode39 code39 = new Barcode39();
            code39.CodeType = Barcode.CODE128;
            code39.ChecksumText = false;
            code39.GenerateChecksum = false;
            code39.X = 40;
            Graphics graphics = e.Graphics;
            Font courier_big = new Font("FontA1x1", 10);
            Font courier_med = new Font("FontA1x1", 7);
            SolidBrush black = new SolidBrush(Color.Black);
            int startX = 0;
            int startY = 0;
            int Offset = 0;
            string TOTAL = "";

            DateTime hoy = System.DateTime.Now;
            graphics.DrawString(hoy.Day.ToString() + "-" + hoy.Month.ToString() + "-" + hoy.Year.ToString(), courier_big, black, startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString(Titulo, courier_big, black, startX, startY + Offset);
            Offset = Offset + 20;



            graphics.DrawString(Dato1, courier_big, black, startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString(Dato2, courier_big, black, startX, startY + Offset);
            Offset = Offset + 20;




            if (TotalEvento > 0)
            {
                graphics.DrawString(Evento.ToString("00") + txtUtils.CompletarBlancos("-ESTACIONAMIENTO", true, 17), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$" + TotalEvento.ToString(), courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;
            }
            else if (Evento > 0)
            {
                graphics.DrawString(Evento.ToString("00") + txtUtils.CompletarBlancos("-ESTACIONAMIENTO", true, 17), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$0", courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;

            }


            if (TotalSocio != 0)
            {
                graphics.DrawString(Socio.ToString("00") + txtUtils.CompletarBlancos("-R.SOCIOS        ", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$" + TotalSocio.ToString(), courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;
            }
            else if (Socio != 0)
            {
                graphics.DrawString(Socio.ToString("00") + txtUtils.CompletarBlancos("-R.SOCIOS        ", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$0", courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;

            }
            if (TotalSocioPileta != 0)
            {
                graphics.DrawString(SocioPileta.ToString("00") + txtUtils.CompletarBlancos("-R.Pil SOCIO     ", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$" + TotalSocioPileta.ToString(), courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;
            }

            if (TotalSocioEstacionamiento != 0)
            {
                graphics.DrawString(SocioEstacionamiento.ToString("00") + txtUtils.CompletarBlancos("-R.Est SOCIO     ", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$" + TotalSocioEstacionamiento.ToString(), courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;

            }

            if (TotalInvi != 0)
            {
                graphics.DrawString(Invitado.ToString("00") + txtUtils.CompletarBlancos("-R.INVI          ", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$" + TotalInvi.ToString(), courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;
            }
            if (TotalInviPileta != 0)
            {
                graphics.DrawString(InvitadoPileta.ToString("00") + txtUtils.CompletarBlancos("-R.Pil INVI      ", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$" + TotalInviPileta.ToString(), courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;
            }

            if (TotalInviEstacionamiento != 0)
            {
                graphics.DrawString(InvitadoEstacionamiento.ToString("00") + txtUtils.CompletarBlancos("-R.Est INVI      ", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$" + TotalInviEstacionamiento.ToString(), courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;

            }

            if (TotalInter != 0)
            {
                graphics.DrawString(Intercirculo.ToString("00") + txtUtils.CompletarBlancos("-R.INTER         ", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$" + TotalInter.ToString(), courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;

            }

            if (TotalInterPileta != 0)
            {
                graphics.DrawString(IntercirculoPileta.ToString("00") + txtUtils.CompletarBlancos("-R.Pil INTER     ", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$" + TotalInterPileta.ToString(), courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;

            }

            if (TotalInterEstacionamiento != 0)
            {

                graphics.DrawString(IntercirculoEstacionamiento.ToString("00") + txtUtils.CompletarBlancos("-R.Est INTER     ", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$" + TotalInterEstacionamiento.ToString(), courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;

            }

            if (Menor != 0)
            {
                graphics.DrawString(Menor.ToString("00") + txtUtils.CompletarBlancos("-R.Pil MENOR     ", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$0", courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;
            }

            if (Disca != 0)
            {
                graphics.DrawString(Menor.ToString("00") + txtUtils.CompletarBlancos("-R.Pil DISC      ", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$0", courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;
            }

            if (Oro != 0)
            {
                graphics.DrawString(Menor.ToString("00") + txtUtils.CompletarBlancos("-R.Vitalicio ORO.", true, 15), courier_big, black, startX, startY + Offset);
                graphics.DrawString(":$0", courier_big, black, startX + 150, startY + Offset);
                Offset = Offset + 20;
            }


            graphics.DrawString(" TOTAL REINTEGROS ", courier_big, black, startX, startY + Offset);
            graphics.DrawString(":$" + Total.ToString(), courier_big, black, startX + 150, startY + Offset);
            Offset = Offset + 20;




            code39.Code = "CR - " + ID.ToString();
            Bitmap bm = new Bitmap(code39.CreateDrawingImage(Color.Black, Color.White));
            graphics.DrawImage(bm, startX, startY + Offset);
            Offset = Offset + 40;

            graphics.DrawString(".", courier_med, black, startX, startY + Offset);
            Offset = Offset + 20;


        }




        public int GetMaxID_ROL(string DNI,string ROL)
        {
            string QUERY = "SELECT coalesce (MAX(ID_ROL),0) from entrada_campo WHERE DNI='" + DNI + "'" + " and ROL='" + ROL + "'"; ;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return Int32.Parse(foundRows[0][0].ToString().Trim());
            }
            else
                return 0;


        }

        public int GetMaxID(string DNI)
        {
            string QUERY = "SELECT coalesce (MAX(ID),0) from entrada_campo WHERE DNI='" + DNI;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return Int32.Parse(foundRows[0][0].ToString().Trim());
            }
            else
                return 0;


        }



        public void  Reintegrar(int ID,string ROL)
        {

            List<EntradaCampo> Lista = new List<EntradaCampo>();
            EntradaCampo item = new EntradaCampo();

            string QUERY = @"SELECT   ID_ROL,DNI,NOMBRE,APELLIDO, NRO_SOC, NRO_DEP,TIPO,INVITADO, MONTO_INVITADO, INVITADO_PILETA,
                                      MONTO_INVITADO_PIL,INVITADO_EST, MONTO_INVITADO_EST, SOCIO, MONTO_SOCIO, SOCIO_PILETA, MONTO_SOCIO_PIL,
                                      SOCIO_EST, MONTO_SOCIO_EST, INTER, MONTO_INTER, INTER_PILETA, MONTO_INTER_PILETA, INTER_EST, MONTO_INTER_EST,
                                      CANTIDAD_TOTAL,MONTO_TOTAL,FECHA, ROL, USUARIO, EXPORTADO,  FECHA_ANUL, USUARIO_IMPORTACION, FECHA_IMPORTACION,
                                      ROL_IMPORTACION, USUARIO_ANUL, MENOR, DISCA, DISCA_ACOM,LEGAJO,CUMPLE_OBS,EVENTO,MONTO_EVENTO FROM  ENTRADA_CAMPO WHERE ID_ROL=  " + ID.ToString() + " and ROL ='"+ROL+"'" ;

            



            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {


                int I = 0;

               

                    item = new EntradaCampo();
                    item.ID = Int32.Parse(foundRows[I][0].ToString().Trim()); ;
                    item.DNI = foundRows[I][1].ToString().Trim();
                    item.NOMBRE = foundRows[I][2].ToString().Trim();
                    item.APELLIDO = foundRows[I][3].ToString().Trim();
                    item.NRO_SOCIO = Int32.Parse(foundRows[I][4].ToString().Trim());
                    item.NRO_DEP = Int32.Parse(foundRows[I][5].ToString().Trim());
                    item.Tipo = foundRows[I][6].ToString().Trim();
                    item.INVITADO = Int32.Parse(foundRows[I][7].ToString().Trim());
                    item.MONTO_INVITADO = Decimal.Parse((foundRows[I][8].ToString().Trim()));
                    item.INVITADO_PILETA = Int32.Parse(foundRows[I][9].ToString().Trim());
                    item.MONTO_INVITADO_PILETA = Decimal.Parse(foundRows[I][10].ToString().Trim());
                    item.INVITADO_ESTACIONAMIENTO = Int32.Parse(foundRows[I][11].ToString().Trim());
                    item.MONTO_INVITADO_EST = Decimal.Parse(foundRows[I][12].ToString().Trim());
                    item.SOCIO = Int32.Parse(foundRows[I][13].ToString().Trim());
                    item.MONTO_SOCIO = Decimal.Parse(foundRows[I][14].ToString().Trim());
                    item.SOCIO_PILETA = Int32.Parse(foundRows[I][15].ToString().Trim());
                    item.MONTO_SOCIO_PILETA = Decimal.Parse(foundRows[I][16].ToString().Trim());
                    item.SOCIO_ESTACIONAMIENTO = Int32.Parse(foundRows[I][17].ToString().Trim());
                    item.MONTO_SOCIO_EST = Decimal.Parse(foundRows[I][18].ToString().Trim());
                    item.INTERCIRCULO = Int32.Parse(foundRows[I][19].ToString().Trim());
                    item.MONTO_INTER = Decimal.Parse(foundRows[I][20].ToString().Trim());
                    item.INTERCIRCULO_PILETA = Int32.Parse(foundRows[I][21].ToString().Trim());
                    item.MONTO_INTERCIRCULO_PILETA = Decimal.Parse(foundRows[I][22].ToString().Trim());
                    item.INTERCIRCULO_ESTACIONAMIENTO = Int32.Parse(foundRows[I][23].ToString().Trim());
                    item.MONTO_INTERCIRCULO_EST = Decimal.Parse(foundRows[I][24].ToString().Trim());
                    item.TOTAL = Int32.Parse(foundRows[I][25].ToString().Trim());
                    item.MONTO_TOTAL = Decimal.Parse(foundRows[I][26].ToString().Trim());
                    item.FECHA = DateTime.Parse(foundRows[I][27].ToString().Trim());
                    item.ROL = foundRows[I][28].ToString().Trim();
                    item.USER = foundRows[I][29].ToString().Trim();
                    item.MENOR = Int32.Parse(foundRows[I][36].ToString().Trim());
                    item.DISCAPACITADO = Int32.Parse(foundRows[I][37].ToString().Trim());
                    item.DISCAPACITADO_ACOM = Int32.Parse(foundRows[I][38].ToString().Trim());
                    item.LEGAJO = Int32.Parse(foundRows[I][39].ToString().Trim());
                    item.OBS_CUMPLE = foundRows[I][40].ToString().Trim();
                   
                    if (foundRows[I][32].ToString().Trim().Length > 1) ;
                    {
                        try
                        {
                            item.BAJA = DateTime.Parse(foundRows[I][32].ToString().Trim());
                            item.USR_BAJA = foundRows[I][35].ToString().Trim();
                        }
                        catch (Exception ex)
                        {

                        }

                    }

                    if (foundRows[I][41].ToString().Trim().Length >0)
                    {
                        item.EVENTO = Int32.Parse(foundRows[I][41].ToString().Trim());
                        item.MONTO_EVENTO = decimal.Parse(foundRows[I][42].ToString().Trim());
                     
                    }

                    
                      int ID_INT = this.Ultimo_ID(VGlobales.vp_role);
                      string Hora = System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString(); 

                      dlog.Entrada_Campo_Ins(item.DNI, item.NOMBRE, item.APELLIDO, item.NRO_SOCIO, item.NRO_DEP, item.Tipo, item.INVITADO * (-1), item.MONTO_INVITADO * (-1), item.INVITADO_PILETA * (-1), item.MONTO_INVITADO_PILETA * (-1), item.INVITADO_ESTACIONAMIENTO * (-1), item.MONTO_INVITADO_EST * (-1), item.SOCIO * (-1), item.MONTO_SOCIO * (-1), item.SOCIO_PILETA * (-1), item.MONTO_SOCIO_PILETA * (-1), item.SOCIO_ESTACIONAMIENTO * (-1), item.MONTO_SOCIO_EST * (-1), item.INTERCIRCULO * (-1), item.MONTO_INTER * (-1), item.INTERCIRCULO_PILETA * (-1), item.MONTO_INTERCIRCULO_PILETA * (-1), item.INTERCIRCULO_ESTACIONAMIENTO * (-1), item.MONTO_INTERCIRCULO_PILETA * (-1), item.TOTAL * (-1), item.MONTO_TOTAL * (-1), System.DateTime.Now, VGlobales.vp_role, VGlobales.vp_username, item.MENOR, item.DISCAPACITADO, item.DISCAPACITADO_ACOM, item.EVENTO, item.MONTO_EVENTO * (-1), ID_INT, "BAJA", item.LEGAJO, item.OBS_CUMPLE, 0, "", "",Hora);
                  

                    Lista.Add(item);
                }
            }



        public EntradaCampo getRegistroEntradaCampo(int ID)
        
        {

            EntradaCampo item = new EntradaCampo();

            string QUERY = @"SELECT   ID_ROL,DNI,NOMBRE,APELLIDO, NRO_SOC, NRO_DEP,TIPO,INVITADO, MONTO_INVITADO, INVITADO_PILETA, MONTO_INVITADO_PIL,INVITADO_EST, MONTO_INVITADO_EST,
           SOCIO, MONTO_SOCIO, SOCIO_PILETA, MONTO_SOCIO_PIL, SOCIO_EST, MONTO_SOCIO_EST, INTER, MONTO_INTER, INTER_PILETA, MONTO_INTER_PILETA, INTER_EST, MONTO_INTER_EST, CANTIDAD_TOTAL,
            MONTO_TOTAL,FECHA, ROL, USUARIO, EXPORTADO,  FECHA_ANUL, USUARIO_IMPORTACION, FECHA_IMPORTACION, ROL_IMPORTACION, USUARIO_ANUL, MENOR, DISCA, DISCA_ACOM,LEGAJO,CUMPLE_OBS,EVENTO,MONTO_EVENTO,HORA FROM  ENTRADA_CAMPO WHERE ID_ROL =" +ID.ToString() + " AND ROL ='" + VGlobales.vp_role + "'";

            //AND ROL = '" + VGlobales.vp_role + "'";

          



            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {


                int I = 0;

               

                    item = new EntradaCampo();
                    item.ID = Int32.Parse(foundRows[0][0].ToString().Trim()); ;
                    item.DNI = foundRows[0][1].ToString().Trim();
                    item.NOMBRE = foundRows[0][2].ToString().Trim();
                    item.APELLIDO = foundRows[0][3].ToString().Trim();
                    item.NRO_SOCIO = Int32.Parse(foundRows[0][4].ToString().Trim());
                    item.NRO_DEP = Int32.Parse(foundRows[0][5].ToString().Trim());
                    item.Tipo = foundRows[0][6].ToString().Trim();
                    item.INVITADO = Int32.Parse(foundRows[0][7].ToString().Trim());
                    item.MONTO_INVITADO = Decimal.Parse((foundRows[0][8].ToString().Trim()));
                    item.INVITADO_PILETA = Int32.Parse(foundRows[0][9].ToString().Trim());
                    item.MONTO_INVITADO_PILETA = Decimal.Parse(foundRows[0][10].ToString().Trim());
                    item.INVITADO_ESTACIONAMIENTO = Int32.Parse(foundRows[0][11].ToString().Trim());
                    item.MONTO_INVITADO_EST = Decimal.Parse(foundRows[0][12].ToString().Trim());
                    item.SOCIO = Int32.Parse(foundRows[0][13].ToString().Trim());
                    item.MONTO_SOCIO = Decimal.Parse(foundRows[0][14].ToString().Trim());
                    item.SOCIO_PILETA = Int32.Parse(foundRows[0][15].ToString().Trim());
                    item.MONTO_SOCIO_PILETA = Decimal.Parse(foundRows[0][16].ToString().Trim());
                    item.SOCIO_ESTACIONAMIENTO = Int32.Parse(foundRows[0][17].ToString().Trim());
                    item.MONTO_SOCIO_EST = Decimal.Parse(foundRows[0][18].ToString().Trim());
                    item.INTERCIRCULO = Int32.Parse(foundRows[0][19].ToString().Trim());
                    item.MONTO_INTER = Decimal.Parse(foundRows[0][20].ToString().Trim());
                    item.INTERCIRCULO_PILETA = Int32.Parse(foundRows[0][21].ToString().Trim());
                    item.MONTO_INTERCIRCULO_PILETA = Decimal.Parse(foundRows[0][22].ToString().Trim());
                    item.INTERCIRCULO_ESTACIONAMIENTO = Int32.Parse(foundRows[0][23].ToString().Trim());
                    item.MONTO_INTERCIRCULO_EST = Decimal.Parse(foundRows[0][24].ToString().Trim());
                    item.TOTAL = Int32.Parse(foundRows[0][25].ToString().Trim());
                    item.MONTO_TOTAL = Decimal.Parse(foundRows[0][26].ToString().Trim());
                    item.FECHA = DateTime.Parse(foundRows[0][27].ToString().Trim());
                    item.ROL = foundRows[0][28].ToString().Trim();
                    item.USER = foundRows[0][29].ToString().Trim();
                    item.MENOR = Int32.Parse(foundRows[0][36].ToString().Trim());
                    item.DISCAPACITADO = Int32.Parse(foundRows[0][37].ToString().Trim());
                    item.DISCAPACITADO_ACOM = Int32.Parse(foundRows[0][38].ToString().Trim());
                    item.LEGAJO = Int32.Parse(foundRows[0][39].ToString().Trim());
                    item.OBS_CUMPLE = foundRows[0][40].ToString().Trim();
                    if (foundRows[0][43].ToString().Length > 0)
                        item.HORA = foundRows[0][43].ToString();
                    else
                        item.HORA = "";
                    if (foundRows[0][32].ToString().Trim().Length > 1) ;
                    {
                        try
                        {
                            item.BAJA = DateTime.Parse(foundRows[0][32].ToString().Trim());
                            item.USR_BAJA = foundRows[0][35].ToString().Trim();
                        }
                        catch (Exception ex)
                        {

                        }

                    }


                    

                   
                }
            




            return item;
        
        
        }


            



        



        public List<EntradaCampo> getIngresos(bool SoloSinProcesar,bool sinBajas,int ID_DESDE, int ID_HASTA,bool Remoto,string RolRemoto)

        {

            List<EntradaCampo> Lista = new List<EntradaCampo>();
            EntradaCampo item = new EntradaCampo();

            string QUERY = @"SELECT   ID_ROL,DNI,NOMBRE,APELLIDO, NRO_SOC, NRO_DEP,TIPO,INVITADO, MONTO_INVITADO, INVITADO_PILETA, MONTO_INVITADO_PIL,INVITADO_EST, MONTO_INVITADO_EST,
  SOCIO, MONTO_SOCIO, SOCIO_PILETA, MONTO_SOCIO_PIL, SOCIO_EST, MONTO_SOCIO_EST, INTER, MONTO_INTER, INTER_PILETA, MONTO_INTER_PILETA, INTER_EST, MONTO_INTER_EST, CANTIDAD_TOTAL,
  MONTO_TOTAL,FECHA, ROL, USUARIO, EXPORTADO,  FECHA_ANUL, USUARIO_IMPORTACION, FECHA_IMPORTACION, ROL_IMPORTACION, USUARIO_ANUL, MENOR, DISCA, DISCA_ACOM,LEGAJO,CUMPLE_OBS,ID,EVENTO,MONTO_EVENTO,HORA FROM  ENTRADA_CAMPO WHERE 1=1";
  
   //AND ROL = '" + VGlobales.vp_role + "'";

            if (SoloSinProcesar)
                QUERY= QUERY + " AND EXPORTADO=0";

            if (sinBajas == true)
            {
                QUERY = QUERY + "AND  coalesce(FECHA_ANUL  ,'1') ='1'   ";
            }

            if (ID_DESDE != 0)
                QUERY = QUERY + " AND ID_ROL >=  " + ID_DESDE.ToString();
            if (ID_HASTA != 0)
                QUERY = QUERY + " AND ID_ROL <=  " + ID_HASTA.ToString();

            QUERY = QUERY + " ORDER BY ID_ROL";



            DataRow[] foundRows;

            if (!Remoto)
               foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            else
                foundRows = dlog.BO_EjecutoDataTable_Remota(QUERY,RolRemoto).Select();
            if (foundRows.Length > 0)
            {


                int I=0;

                while(I <= (foundRows.Length -1))

                {

                item = new EntradaCampo();
                item.ID                             =Int32.Parse(foundRows[I][0].ToString().Trim());;
                item.ID_INTERNO = item.ID;
                item.DNI                            =foundRows[I][1].ToString().Trim();
                item.NOMBRE                         =foundRows[I][2].ToString().Trim();
                item.APELLIDO                       =foundRows[I][3].ToString().Trim();
                item.NRO_SOCIO                      =Int32.Parse(foundRows[I][4].ToString().Trim());
                item.NRO_DEP                        =Int32.Parse(foundRows[I][5].ToString().Trim());
                item.Tipo                           =foundRows[I][6].ToString().Trim();
                item.INVITADO                       =Int32.Parse(foundRows[I][7].ToString().Trim());
                item.MONTO_INVITADO                 =Decimal.Parse((foundRows[I][8].ToString().Trim()));
                item.INVITADO_PILETA                =Int32.Parse(foundRows[I][9].ToString().Trim());
                item.MONTO_INVITADO_PILETA          =Decimal.Parse(foundRows[I][10].ToString().Trim());
                item.INVITADO_ESTACIONAMIENTO       =Int32.Parse(foundRows[I][11].ToString().Trim());
                item.MONTO_INVITADO_EST             =Decimal.Parse(foundRows[I][12].ToString().Trim());
                item.SOCIO                          =Int32.Parse(foundRows[I][13].ToString().Trim());
                item.MONTO_SOCIO                    =Decimal.Parse(foundRows[I][14].ToString().Trim());
                item.SOCIO_PILETA                   =Int32.Parse(foundRows[I][15].ToString().Trim());
                item.MONTO_SOCIO_PILETA             =Decimal.Parse(foundRows[I][16].ToString().Trim());
                item.SOCIO_ESTACIONAMIENTO          =Int32.Parse(foundRows[I][17].ToString().Trim());
                item.MONTO_SOCIO_EST                =Decimal.Parse(foundRows[I][18].ToString().Trim());
                item.INTERCIRCULO                   = Int32.Parse(foundRows[I][19].ToString().Trim());
                item.MONTO_INTER = Decimal.Parse(foundRows[I][20].ToString().Trim());
                item.INTERCIRCULO_PILETA = Int32.Parse(foundRows[I][21].ToString().Trim());
                item.MONTO_INTERCIRCULO_PILETA = Decimal.Parse(foundRows[I][22].ToString().Trim());
                item.INTERCIRCULO_ESTACIONAMIENTO = Int32.Parse(foundRows[I][23].ToString().Trim());
                item.MONTO_INTERCIRCULO_EST        = Decimal.Parse(foundRows[I][24].ToString().Trim());
                item.TOTAL                          = Int32.Parse(foundRows[I][25].ToString().Trim());
                item.MONTO_TOTAL                    = Decimal.Parse(foundRows[I][26].ToString().Trim());
                item.FECHA                          = DateTime.Parse(foundRows[I][27].ToString().Trim());
                item.ROL                            = foundRows[I][28].ToString().Trim();
                item.USER                           = foundRows[I][29].ToString().Trim();
                item.MENOR                          =Int32.Parse(foundRows[I][36].ToString().Trim());
                item.DISCAPACITADO                  =Int32.Parse(foundRows[I][37].ToString().Trim());
                item.DISCAPACITADO_ACOM             = Int32.Parse(foundRows[I][38].ToString().Trim());
                item.LEGAJO                         = Int32.Parse(foundRows[I][39].ToString().Trim());
                item.OBS_CUMPLE                     = foundRows[I][40].ToString().Trim();
               //ojo que tipo es el ID real, parche 
                // item.Tipo                          = foundRows[I][41].ToString().Trim();
                item.EVENTO = Int32.Parse(foundRows[I][42].ToString().Trim());
                item.MONTO_EVENTO = Decimal.Parse(foundRows[I][43].ToString().Trim());
                if (foundRows[I][43].ToString().Length > 0)
                    item.HORA = foundRows[I][43].ToString().TrimEnd().TrimStart();
                else
                    item.HORA = "";

                    
                    if (foundRows[I][32].ToString().Trim().Length >1 );
                {
                    try
                    {
                        item.BAJA = DateTime.Parse(foundRows[I][32].ToString().Trim());
                        item.USR_BAJA = foundRows[I][35].ToString().Trim();
                    }
                    catch (Exception ex)

                    { 
                    
                    }
                
                }




                I = I + 1;

                Lista.Add(item);
                }
            }

            
            
            
            return Lista;
        
        
        
        }


        public List<EntradaCampo> getIngresos(bool SoloSinProcesar, bool sinBajas,bool filtroFecha,bool filtroID, DateTime Desde, DateTime Hasta,int IDD,int IDH)
        {

            List<EntradaCampo> Lista = new List<EntradaCampo>();
            EntradaCampo item = new EntradaCampo();


            


            string QUERY = @"SELECT   ID_ROL,DNI,NOMBRE,APELLIDO, NRO_SOC, NRO_DEP,TIPO,INVITADO, MONTO_INVITADO, INVITADO_PILETA, MONTO_INVITADO_PIL,INVITADO_EST, MONTO_INVITADO_EST,
  SOCIO, MONTO_SOCIO, SOCIO_PILETA, MONTO_SOCIO_PIL, SOCIO_EST, MONTO_SOCIO_EST, INTER, MONTO_INTER, INTER_PILETA, MONTO_INTER_PILETA, INTER_EST, MONTO_INTER_EST, CANTIDAD_TOTAL,
  MONTO_TOTAL,FECHA, ROL, USUARIO, EXPORTADO,  FECHA_ANUL, USUARIO_IMPORTACION, FECHA_IMPORTACION, ROL_IMPORTACION, USUARIO_ANUL, MENOR, DISCA, DISCA_ACOM,LEGAJO,CUMPLE_OBS,ID,EVENTO,MONTO_EVENTO FROM  ENTRADA_CAMPO WHERE 1=1";

            //AND ROL = '" + VGlobales.vp_role + "'";

            if (SoloSinProcesar)
                QUERY = QUERY + " AND EXPORTADO=0";

            if (sinBajas == true)
            {
                QUERY = QUERY + "AND  coalesce(FECHA_ANUL  ,'1') ='1'   ";
            }
            if (filtroFecha )
                QUERY = QUERY + "  AND FECHA > '" + Desde.AddDays(-1).ToString("MM/dd/yyyy") + "' AND FECHA <'" + Hasta.AddDays(1).ToString("MM/dd/yyyy") + " '";
            if (filtroID)
                QUERY = QUERY + " AND ID_ROL >= " + IDD.ToString() + " AND ID_ROL <= " + IDH.ToString();
            QUERY = QUERY + "  ORDER BY ID_ROL";

            



            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {


                int I = 0;

                while (I <= (foundRows.Length - 1))
                {

                    item = new EntradaCampo();
                    item.ID = Int32.Parse(foundRows[I][0].ToString().Trim()); ;

                    item.DNI = foundRows[I][1].ToString().Trim();
                    item.NOMBRE = foundRows[I][2].ToString().Trim();
                    item.APELLIDO = foundRows[I][3].ToString().Trim();
                    item.NRO_SOCIO = Int32.Parse(foundRows[I][4].ToString().Trim());
                    item.NRO_DEP = Int32.Parse(foundRows[I][5].ToString().Trim());
                    item.Tipo = foundRows[I][6].ToString().Trim();
                    item.INVITADO = Int32.Parse(foundRows[I][7].ToString().Trim());
                    item.MONTO_INVITADO = Decimal.Parse((foundRows[I][8].ToString().Trim()));
                    item.INVITADO_PILETA = Int32.Parse(foundRows[I][9].ToString().Trim());
                    item.MONTO_INVITADO_PILETA = Decimal.Parse(foundRows[I][10].ToString().Trim());
                    item.INVITADO_ESTACIONAMIENTO = Int32.Parse(foundRows[I][11].ToString().Trim());
                    item.MONTO_INVITADO_EST = Decimal.Parse(foundRows[I][12].ToString().Trim());
                    item.SOCIO = Int32.Parse(foundRows[I][13].ToString().Trim());
                    item.MONTO_SOCIO = Decimal.Parse(foundRows[I][14].ToString().Trim());
                    item.SOCIO_PILETA = Int32.Parse(foundRows[I][15].ToString().Trim());
                    item.MONTO_SOCIO_PILETA = Decimal.Parse(foundRows[I][16].ToString().Trim());
                    item.SOCIO_ESTACIONAMIENTO = Int32.Parse(foundRows[I][17].ToString().Trim());
                    item.MONTO_SOCIO_EST = Decimal.Parse(foundRows[I][18].ToString().Trim());
                    item.INTERCIRCULO = Int32.Parse(foundRows[I][19].ToString().Trim());
                    item.MONTO_INTER = Decimal.Parse(foundRows[I][20].ToString().Trim());
                    item.INTERCIRCULO_PILETA = Int32.Parse(foundRows[I][21].ToString().Trim());
                    item.MONTO_INTERCIRCULO_PILETA = Decimal.Parse(foundRows[I][22].ToString().Trim());
                    item.INTERCIRCULO_ESTACIONAMIENTO = Int32.Parse(foundRows[I][23].ToString().Trim());
                    item.MONTO_INTERCIRCULO_EST = Decimal.Parse(foundRows[I][24].ToString().Trim());
                    item.TOTAL = Int32.Parse(foundRows[I][25].ToString().Trim());
                    item.MONTO_TOTAL = Decimal.Parse(foundRows[I][26].ToString().Trim());
                    item.FECHA = DateTime.Parse(foundRows[I][27].ToString().Trim());
                    item.ROL = foundRows[I][28].ToString().Trim();
                    item.USER = foundRows[I][29].ToString().Trim();
                    item.MENOR = Int32.Parse(foundRows[I][36].ToString().Trim());
                    item.DISCAPACITADO = Int32.Parse(foundRows[I][37].ToString().Trim());
                    item.DISCAPACITADO_ACOM = Int32.Parse(foundRows[I][38].ToString().Trim());
                    item.LEGAJO = Int32.Parse(foundRows[I][39].ToString().Trim());
                    item.OBS_CUMPLE = foundRows[I][40].ToString().Trim();
                    //ojo que tipo es el ID real, parche 
                    item.Tipo = foundRows[I][41].ToString().Trim();


                    if (foundRows[I][32].ToString().Trim().Length > 1) ;
                    {
                        try
                        {
                            item.BAJA = DateTime.Parse(foundRows[I][32].ToString().Trim());
                            item.USR_BAJA = foundRows[I][35].ToString().Trim();
                        }
                        catch (Exception ex)
                        {

                        }

                    }

                    if (foundRows[I][42].ToString().Trim().Length > 0) ;
                    {
                        item.EVENTO = Int32.Parse(foundRows[I][42].ToString());
                        item.MONTO_EVENTO = decimal.Parse(foundRows[I][43].ToString());
                    
                    }



                    I = I + 1;

                    Lista.Add(item);
                }
            }




            return Lista;



        }



        public List<EntradaCampo> getIngresos(bool filtroFecha,bool filtroID, DateTime Desde, DateTime Hasta, int idDesde, int idHasta, string DNI, string NOMBRE, string APELLIDO, string ROL,string USER)

        {
               List<EntradaCampo> listaOriginal =new List<EntradaCampo>();
               List<EntradaCampo> lista = new List<EntradaCampo>();
               
            
               listaOriginal = this.getIngresos(false, true,filtroFecha,filtroID,Desde,Hasta,idDesde,idHasta).ToList();



               if (filtroFecha)
                   lista = listaOriginal.Where(x => (x.FECHA > Desde.AddDays(-1) && x.FECHA < Hasta.AddDays(1))).ToList();
               else
               {
                   lista = listaOriginal;
               }

               
              if (idDesde !=0)
               {
                   lista = lista.Where(x => (x.ID >= idDesde)).ToList();
               }

               if (idHasta != 0)
               {
                   lista = lista.Where(x => (x.ID <= idHasta)).ToList();
               }

              
              
               if (DNI.Length > 0)
                   lista = lista.Where(x => x.DNI.Contains(DNI)).ToList();
            
               if (NOMBRE.Length > 0)
              
               {
                   lista = lista.Where(x => x.NOMBRE.Contains(NOMBRE)).ToList();
                                  
               }

               if (APELLIDO.Length > 0)
               
               {
                   lista = lista.Where(x => (x.APELLIDO.Contains(APELLIDO))).ToList();

               }

               if (ROL.Length>0)
               {
                   lista = lista.Where(x => x.ROL == ROL).ToList();
               
               }

              if (USER.Length >0)

              {
                 lista = lista.Where(x=>x.USER ==USER).ToList();
              }



            return lista;
                
        
        
        }

        public List<EntradaCampo> getIngresosXRol(string ROL,int Desde,int Hasta)


        {
            List<EntradaCampo> listaOriginal = new List<EntradaCampo>();
          
            listaOriginal = this.getIngresos(false, true,Desde,Hasta,false,"").ToList().Where(x=>x.ROL ==ROL).ToList();


            return listaOriginal;
        }


        public void Procesar_Registros(List<EntradaCampo> lista)

        {

            try
            {
                foreach (EntradaCampo e in lista)
                {

                    dlog.Entrada_Campo_Marca(e.ID,e.ROL);


                }
            }
            catch (Exception ex)

            { 
               throw new Exception(ex.Message);
            
            }
        
        }

       public bool Persona_Ya_Ingresada(string DNI, DateTime fecha)

        {

            string QUERY = "SELECT ID from entrada_campo WHERE DNI='" + DNI + "' AND ROL = '" + VGlobales.vp_role + "' and extract (day from fecha) = " + fecha.Day.ToString() + " and extract(month from fecha) = " + fecha.Month.ToString() + " and extract(year from fecha )= " + fecha.Year.ToString() ;

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return true;
            }
            else
                return false;
        
        
        }


       public int Ultimo_ID(string ROL)
       {

           string QUERY = "SELECT  first 1  ID_ROL   from entrada_campo WHERE ROL='" + ROL + "' order by ID_ROL desc";


           DataRow[] foundRows;
           foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

           try
           {
               if (foundRows.Length > 0)
               {
                   if (foundRows[0][0] != null)
                       return Int32.Parse(foundRows[0][0].ToString()) + 1;
                   else return 1;

               }
               else
                   return 1;
           }
           catch (Exception ex)

           {

               return 1;
           }


       }


       public void Actualizo_Ingreso(string DNI,DateTime? Fecha_Anul, int pID_ROL )
       {

           int ID = this.GetMaxID(DNI);
           // metodo medio casero, pero Ultimo_ID rol, por lo general es para 
           int ID_ROL = pID_ROL - 1;

           string QUERY = "UPDATE ENTRADA_CAMPO SET ID_ROL = " + ID_ROL.ToString() + " , USUARIO_IMPORTACION = '" + VGlobales.vp_username + "' , ROL_IMPORTACION ='" + VGlobales.vp_role + "', FECHA_IMPORTACION= (select cast('Now' as date) from rdb$database)  ";

           if (Fecha_Anul != null && Fecha_Anul.Value > new DateTime(2015,1,1))
               QUERY = QUERY + " , FECHA_ANUL='" + Fecha_Anul.Value.ToShortDateString() + "'";

           QUERY = QUERY + " WHERE ID = " + ID.ToString();



           string connectionString;


           Datos_ini ini2 = new Datos_ini();

           FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
           cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
           cs.Database = ini2.Ubicacion;
           cs.UserID = VGlobales.vp_username;
           cs.Password = VGlobales.vp_password;
           cs.Role = VGlobales.vp_role;
           cs.Dialect = 3;
           connectionString = cs.ToString();

           using (FbConnection connection = new FbConnection(connectionString))
           {
               string vcomando;

               

               connection.Open();
               FbTransaction transaction = connection.BeginTransaction();
               FbCommand cmd = new FbCommand(QUERY, connection, transaction);
               cmd.CommandText = QUERY;
               cmd.Connection = connection;
               cmd.CommandType = CommandType.Text;

               cmd.ExecuteNonQuery();
               transaction.Commit();
               connection.Dispose();

           }

           


       }


       public decimal Monto_Maximo_Reintegrar(string DNI,DateTime FECHA)
       {

           string Dia = FECHA.Day.ToString();
           string Mes = FECHA.Month.ToString();
           string Anio = FECHA.Year.ToString();



           string QUERY = "select sum(monto_invitado_pil) + sum(MONTO_INTER_PILETA) + sum(monto_socio_pil) + sum(monto_invitado_est) + sum(monto_socio_est) + sum(monto_inter_est) + sum(monto_invitado) + sum(monto_inter) + sum(monto_evento) from entrada_campo    where extract (day from FECHA)=" +Dia +" and extract(month from Fecha)="+Mes+ " and extract(year from fecha)="+Anio+ " and dni='" + DNI+"' and monto_total>0";

           DataRow[] foundRows;
           foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

           try
           {
               if (foundRows.Length > 0)
               {
                   if (foundRows[0][0] != null)
                      return Decimal.Parse(foundRows[0][0].ToString());   
               }
               else
                   return 0;
           }
           catch (Exception ex)
           {

               return 0;
           }

           return 0;


       }

       public bool Existe_Entrada_Tipo(string DNI,int Tipo)
       {

           string Dia = System.DateTime.Now.Day.ToString();
           string Mes = System.DateTime.Now.Month.ToString();
           string Anio = System.DateTime.Now.Year.ToString();

           //Tipo 1 ,Socio pileta 
           //Tipo 2 , Invitado Pileta
           //Tipo 3 , Invitado Intercirculo


           string QUERY = "select  ID  from entrada_campo    where extract (day from FECHA)=" + Dia + " and extract(month from Fecha)=" + Mes + " and extract(year from fecha)=" + Anio + " and dni='" + DNI + "' and monto_total>0 ";
           if (Tipo == 1)
           {
               QUERY = QUERY + " and SOCIO_PILETA>0   ";
           }
           else if (Tipo == 2)
           {

               QUERY = QUERY + " and INVITADO_PILETA >0   ";

           }
           else if (Tipo == 3)
           {
               QUERY = QUERY + " and INTER_PILETA >0   ";

           }
           else
           {
               QUERY = QUERY + "and EVENTO > 0";
           }

           DataRow[] foundRows;
           foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

           try
           {
               if (foundRows.Length > 0)
               {
                   return true;
               }
               else
                   return false;
           }
           catch (Exception ex)
           {

               return false;
           }

           return false;


       }

       public bool Existe_Entrada_Tipo(string DNI, int Tipo,DateTime FECHA)
       {

           

           //Tipo 1 ,Socio pileta 
           //Tipo 2 , Invitado Pileta
           //Tipo 3 , Invitado Intercirculo


           string QUERY = "select  ID  from entrada_campo    where extract (day from FECHA)=" + FECHA.Day.ToString() + " and extract(month from Fecha)=" + FECHA.Month.ToString() + " and extract(year from fecha)=" + FECHA.Year.ToString() + " and dni='" + DNI + "' and monto_total>0 ";
           if (Tipo == 1)
           {
               QUERY = QUERY + " and SOCIO_PILETA>0   ";
           }
           else if (Tipo == 2)
           {

               QUERY = QUERY + " and INVITADO_PILETA >0   ";

           }
           else if (Tipo == 3)
           {
               QUERY = QUERY + " and INTER_PILETA >0   ";

           }
           else
           {
               QUERY = QUERY + "and EVENTO > 0";
           }

           DataRow[] foundRows;
           foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

           try
           {
               if (foundRows.Length > 0)
               {
                   return true;
               }
               else
                   return false;
           }
           catch (Exception ex)
           {

               return false;
           }

           return false;


       }


       public List<SOCIOS.EntradaCampo> InfoExportar(bool FiltroSinProcesar, bool FiltroID, string tbDESDE, string tbHASTA, string ROL)

       {
           List<SOCIOS.EntradaCampo> registros = new List<SOCIOS.EntradaCampo>();

           int ID_DESDE = 0;
           int ID_HASTA = 0;

           if (tbDESDE.Length > 0)
               ID_DESDE = Int32.Parse(tbDESDE);

           if (tbHASTA.Length > 0)
               ID_HASTA = Int32.Parse(tbHASTA);

           registros = new List<SOCIOS.EntradaCampo>();

           registros = this.getIngresos(FiltroSinProcesar, false, ID_DESDE, ID_HASTA,true,ROL).Where(x => x.ROL == ROL).ToList();

           if (ID_DESDE > 0 && FiltroID)
           {
               if (ID_HASTA > 0)
                   registros = registros.Where(x => x.ID >= ID_DESDE).Where(x => x.ID <= ID_HASTA).ToList();
               else
                   registros = registros.Where(x => x.ID >= ID_DESDE).ToList();

           }

           return registros;
       }


       public void Importar_Entrada_Campo(List<SOCIOS.EntradaCampo> LISTA)
        {
                string ROL = LISTA.FirstOrDefault().ROL;
                int ID_DESDE = LISTA.OrderBy(x => x.ID_INTERNO).FirstOrDefault().ID_INTERNO;
                int ID_HASTA = LISTA.OrderByDescending(x => x.ID_INTERNO).FirstOrDefault().ID_INTERNO;

                List<SOCIOS.EntradaCampo> YaProcesados = this.getIngresosXRol(ROL,ID_DESDE,ID_HASTA).ToList();

              
                    int i = 0;
                    foreach (SOCIOS.EntradaCampo item in LISTA)
                    {

                        if (YaProcesados.Where(x => x.ID == item.ID_INTERNO).Count() == 0)
                        {

                            dlog.Entrada_Campo_Ins(item.DNI, item.NOMBRE, item.APELLIDO, item.NRO_SOCIO, item.NRO_DEP, item.Tipo, item.INVITADO, item.MONTO_INVITADO, item.INVITADO_PILETA, item.MONTO_INVITADO_PILETA, item.INVITADO_ESTACIONAMIENTO, item.MONTO_INVITADO_EST, item.SOCIO, item.MONTO_SOCIO, item.SOCIO_PILETA, item.MONTO_SOCIO_PILETA, item.SOCIO_ESTACIONAMIENTO, item.MONTO_SOCIO_EST, item.INTERCIRCULO, item.MONTO_INTER, item.INTERCIRCULO_PILETA, item.MONTO_INTERCIRCULO_PILETA, item.INTERCIRCULO_ESTACIONAMIENTO, item.MONTO_INTERCIRCULO_EST, item.TOTAL, item.MONTO_TOTAL, item.FECHA, item.ROL, item.USER, item.MENOR, item.DISCAPACITADO, item.DISCAPACITADO_ACOM,item.EVENTO,item.MONTO_EVENTO, item.ID_INTERNO, "ALTA", item.LEGAJO, item.OBS_CUMPLE, 1,VGlobales.vp_username,VGlobales.vp_role,item.HORA);
                          
                        }
                   }
                    

        
        }









       
    }
}
