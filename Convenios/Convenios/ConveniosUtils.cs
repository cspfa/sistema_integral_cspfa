using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
