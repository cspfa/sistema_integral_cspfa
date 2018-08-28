using System;

namespace Convenios
{
    public class ConveniosUtils
    {
        public string convertirFecha(string FECHA, string SEPARADOR)
        {
            string DIA = FECHA.Substring(0, 2);
            string MES = FECHA.Substring(3, 2);
            string ANO = FECHA.Substring(6, 4);
            string FECHA_FINAL = MES + SEPARADOR + DIA + SEPARADOR + ANO;
            return FECHA_FINAL;
        }

        public int diasDeDiferencia(DateTime HASTA)
        {
            int DIFF = 0;
            DateTime TODAY = DateTime.Now;
            TimeSpan TS = HASTA - TODAY;
            DIFF = TS.Days;
            return DIFF;
        }
    }
}
