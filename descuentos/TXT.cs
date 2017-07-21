using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOCIOS.descuentos
{
    public class FILE_ACTIVIDAD_REG

    {
       public string MMAA   { get; set; }
       public string ACRPJ2  { get; set; }
       public string SEPAR  { get; set; }
       public string CODINT { get; set; }
       public string MONTO  { get; set; }
       public string SEPAR2 { get; set; }
       
    
    }

    public class Registro_Actividad
    {
        public int Mes       { get; set; }
        public int Anio      { get; set; }
        public int CRJP1     { get; set; }
        public int CRJP2     { get; set; }
        public int CRJP3     { get; set; }
        public int Codint    { get; set; }
        public int Cod_CC { get; set; }
        public decimal Monto { get; set; }
        public string Tipo   { get; set; }
        public string ROL    { get; set; }
        
    
    }
    
    public class TXT
    {

        
        string Fecha;
        TXT_Utils tu = new TXT_Utils();
        DescuentoUtils du = new DescuentoUtils();
        List<Registro_Actividad> Descuentos = new List<Registro_Actividad>();
        bo_Descuentos dlog = new bo_Descuentos();
        bool Actividad=false;
        int TIPO;
        public TXT(int pTIPO)

        {
            DateTime hoy = System.DateTime.Now;
            TIPO = pTIPO;
            if (TIPO == (int)TIPO_ACTIVIDAD.ACTIVO)
                Actividad = true;

            

            Fecha = hoy.Month.ToString("00") + hoy.Year.ToString().Substring(2, 2);
          
            Descuentos = du.DescuentosXmes(TIPO);
           
        
            
          


        
        }


        public void GenerarInfo()
        {
            this.PROCESAR_GRABAR(TIPO);
            this.GENERO_TXT();

        }

        #region TXT




        private void GENERO_TXT()
        {
            string filename = "";

            if (Actividad)
                filename = "subofact.txt";
            else
                filename = "subofpas.txt";




            System.IO.StreamWriter file = new System.IO.StreamWriter("C://CSPFA_SOCIOS//"+ filename);

            foreach (Registro_Actividad R in Descuentos)
            {
               if (Actividad) 
                 file.WriteLine(this.GenerarRegistroAct(R.CRJP2.ToString(),R.Monto,R.Cod_CC.ToString(),R.Tipo));
               else
                file.WriteLine(this.GenerarRegistroPas(R.CRJP1.ToString(),R.CRJP2.ToString(),R.CRJP3.ToString(),R.Cod_CC, R.Monto, R.Tipo));


            }





        }

        private string GenerarRegistroAct(string ACRJP2,decimal Monto,string Codigo,string Tipo)

        {

            StringBuilder sb = new StringBuilder();
            sb.Append(Fecha);//Fecha : 4 
            sb.Append(tu.CompletarCeros(ACRJP2,false,7));//ACRJP2: 7
            sb.Append("0");// cero  fijo 1 
            sb.Append(tu.CompletarCeros(Codigo,false,5));// Codigo 5
            sb.Append(Tipo);// Tipo   1 
            sb.Append(tu.ConvertirFormatoImporte(Monto));//12 Monto
            sb.Append("0000000000000000000000000000000000");//Relleno 34
            return sb.ToString();



        }
        private string GenerarRegistroPas(string PCRJP1, string PCRJP2, string PCRJP3,int CODCC, decimal Monto, string Tipo)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("CR");
            sb.Append(Fecha);//Fecha : 4 
            sb.Append(tu.CompletarCeros(PCRJP1, false, 2));//PCRJP1: 2
            sb.Append(tu.CompletarCeros(PCRJP2, false, 6));//PCRJP2: 2
            sb.Append(tu.CompletarCeros(PCRJP3, false, 1));//PCRJP3: 2
            sb.Append(Tipo);// TIPO 2 
            sb.Append(CODCC.ToString());// CODCC 3 
            sb.Append(tu.ConvertirFormatoImporte(Monto));//12 Monto
            sb.Append("00000000000000");//Relleno 14
            return sb.ToString();



        }


        private string GenerarRegistroFederal(string ID_SOCIEDAD, string ID_EMPLEADO,decimal Monto, string Periodo)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(ID_SOCIEDAD);//ID SOCIEDAD : 3 
            sb.Append(tu.CompletarCeros(ID_EMPLEADO, false, 12));//ID_EMPLEADO: 12
            sb.Append("633");// Cod_DTO 3 
            sb.Append(tu.ConvertirFormatoImporte9(Monto));// Monto  7 enteros , 2 decimales
            sb.Append(Periodo);// Periodo   1 
           
            return sb.ToString();



        }



        #endregion

        #region DATOS


        private void  PROCESAR_GRABAR(int Tipo)

        {


            foreach (Registro_Actividad R in Descuentos)
            {

                if (Tipo == (int)TIPO_ACTIVIDAD.ACTIVO)
                    dlog.Txt_Activo_I(R.Mes, R.Anio, R.CRJP2.ToString(), R.Codint,R.Cod_CC, R.Tipo, R.Monto);
                else
                    dlog.Txt_Pasivo_I(R.Mes, R.Anio, R.CRJP1, R.CRJP2.ToString(), R.CRJP3, R.Codint,R.Cod_CC, R.Tipo, R.Monto);
            }
            
        
        }

       

 

        #endregion




    }
}
