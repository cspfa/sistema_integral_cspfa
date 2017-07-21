using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;
using System.Data;

namespace SOCIOS.descuentos
{
    public class TXT_Utils
    {
        bo dlog= new bo();



        private void Proceso_Registro(Registro_Actividad REG)
        {
            DateTime Fecha = System.DateTime.Now.AddMonths(-1);
            string QUERY = " select ID,MES,ANIO,ACRPJ2,COD_INT,TIPO,MONTO,USR_A,FECHA_A from TXT_ACTIVOS WHERE MES= " +  Fecha.Month.ToString() + "AND ANIO =" + Fecha.Year.ToString();
 
            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


            if (foundRows.Length > 0)
            {
                REG.Tipo = "B";
            }
            else
                REG.Tipo = "A";








        }

        public List<Registro_Actividad> TXT_ACT_MES(int Mes, int Anio)

        {

           
            string QUERY = " select ID,MES,ANIO,ACRPJ2,COD_INT,TIPO,MONTO,ROL from TXT_ACTIVOS WHERE MES= " + Mes.ToString() + " AND ANIO =" + Anio.ToString();

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            List<Registro_Actividad> lista = new List<Registro_Actividad>();

            foreach (DataRow dr in foundRows)
            {

                Registro_Actividad ra = new Registro_Actividad();
                ra.Mes  =  Int32.Parse(dr[1].ToString());
                ra.Anio = Int32.Parse(dr[2].ToString());
                ra.CRJP1 = Int32.Parse(dr[3].ToString());
                ra.CRJP2 = 0;
                ra.CRJP3 = 0;
                ra.Codint =Int32.Parse(dr[4].ToString());
                ra.Tipo = dr[5].ToString();
                ra.Monto = Decimal.Parse(dr[6].ToString());
                ra.ROL = dr[7].ToString();
                lista.Add(ra);


            }

            return lista;
        
        }

        public List<Registro_Actividad> TXT_PAS_MES(int Mes, int Anio)
        {


            string QUERY = " select ID,MES,ANIO,PCRJP1,PCRJP2,PCRJP3,CODINT,TIPO,MONTO,ROL from TXT_PASIVOS WHERE MES= " + Mes.ToString() + " AND ANIO =" + Anio.ToString();

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            List<Registro_Actividad> lista = new List<Registro_Actividad>();

            foreach (DataRow dr in foundRows)
            {

                Registro_Actividad ra = new Registro_Actividad();
                ra.Mes = Int32.Parse(dr[1].ToString());
                ra.Anio = Int32.Parse(dr[2].ToString());
                ra.CRJP1 = Int32.Parse(dr[3].ToString());
                ra.CRJP2 = Int32.Parse(dr[4].ToString());
                ra.CRJP3 = Int32.Parse(dr[5].ToString());
                ra.Codint = Int32.Parse(dr[6].ToString());
                ra.Tipo = dr[7].ToString();
                ra.Monto = Decimal.Parse(dr[8].ToString());
                ra.ROL = dr[9].ToString();
                lista.Add(ra);


            }

            return lista;

        }





        public string ConvertirFormatoImporte(decimal monto)
        {
            string monto_cuota = monto.ToString("0000000000.00");
            string e_monto_cuota = monto_cuota.Substring(0, monto_cuota.Length - 3);
            string d_monto_cuota = monto_cuota.Substring(monto_cuota.Length - 2);
            monto_cuota = e_monto_cuota + d_monto_cuota;

            return monto_cuota;
        }

        public string ConvertirFormatoImporte9(decimal monto)
        {
            string monto_cuota = monto.ToString("0000000.00");
            string e_monto_cuota = monto_cuota.Substring(0, monto_cuota.Length - 3);
            string d_monto_cuota = monto_cuota.Substring(monto_cuota.Length - 2);
            monto_cuota = e_monto_cuota + d_monto_cuota;

            return monto_cuota;
        }



        public  string CompletarBlancos(string texto, bool aDerecha, int tamanioTotal)
        {
            StringBuilder sb = new StringBuilder();
            if (texto == null)
                texto = "";

            sb.Append(this.StringBlanco(tamanioTotal - texto.Length));
            if (aDerecha)
                sb.Insert(0, texto);
            else
                sb.Append(texto);

            return sb.ToString(); ;
        }

        public  string CompletarCeros(string texto, bool aDerecha, int tamanioTotal)
        {
            StringBuilder sb = new StringBuilder();

            if (texto == null)
                texto = "";

            sb.Append(this.StringCero(tamanioTotal - texto.Length));
            if (aDerecha)
                sb.Insert(0, texto);
            else
                sb.Append(texto);

            return sb.ToString(); ;
        }

        public  string StringBlanco(int longitud)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < longitud; i++)
            {
                sb.Append(" ");
            }
            return sb.ToString();
        }

        public  string StringCero(int longitud)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < longitud; i++)
            {
                sb.Append("0");
            }
            return sb.ToString();
        }
    }
}
