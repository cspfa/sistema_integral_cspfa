using System;
using System.Collections.Generic;
using System.Text;

namespace SOCIOS
{
    class fechaAletras
    {
        public string convertir(string FECHA)
        {
            string D = FECHA.Substring(0, 2);
            string M = FECHA.Substring(3, 2);
            string A = FECHA.Substring(6, 4);
            string MES = "";

            switch (M)
            { 
                case "01":
                    MES = "enero";
                    break;

                case "02":
                    MES = "febrero";
                    break;

                case "03":
                    MES = "marzo";
                    break;

                case "04":
                    MES = "abril";
                    break;

                case "05":
                    MES = "mayo";
                    break;

                case "06":
                    MES = "junio";
                    break;

                case "07":
                    MES = "julio";
                    break;

                case "08":
                    MES = "agosto";
                    break;

                case "09":
                    MES = "septiembre";
                    break;

                case "10":
                    MES = "octubre";
                    break;

                case "11":
                    MES = "noviembre";
                    break;

                case "12":
                    MES = "diciembre";
                    break;
            }

            return D + " de " + MES + " de " + A;
        }
    }
}
