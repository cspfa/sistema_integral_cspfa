using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS
{
   public class getGrupo
    {
        /*public string getCatSoc(string NRO_SOC, string NRO_DEP)
        {

        }*/

        public int get(string COD_DTO, string CAT_SOC)
        {
            int GRUPO = 0;

            if (CAT_SOC == "008")
            {
                GRUPO = 2; //INTERCIRCULO
            }
            else
            {
                switch (COD_DTO)
                {
                    case "640": //SOCIO
                        GRUPO = 1;
                        break;

                    case "781": //SOCIO
                        GRUPO = 1;
                        break;

                    case "187": //SOCIO
                        GRUPO = 1;
                        break;

                    case "642": //SOCIO
                        GRUPO = 1;
                        break;

                    case "740": //SOCIO
                        GRUPO = 1;
                        break;

                    case "641": //SOCIO
                        GRUPO = 1;
                        break;

                    case "643": //SOCIO
                        GRUPO = 1;
                        break;

                    case "EEE": //SOCIO
                        GRUPO = 1;
                        break;

                    case "A/S": //SOCIO
                        GRUPO = 1;
                        break;

                    case "S/C": //SOCIO
                        GRUPO = 1;
                        break;

                    case "MET": //SOCIO
                        GRUPO = 1;
                        break;

                    case "   ": //NO SOCIO
                        GRUPO = 3;
                        break;

                    case "000": //NO SOCIO
                        GRUPO = 3;
                        break;
                }
            }

            if (CAT_SOC == "INP" && COD_DTO == "A/S")
            {
                GRUPO = 5; //INVITADOS PARTICIPATIVOS
            }

            if (CAT_SOC == "013" && COD_DTO == "014")
            {
                GRUPO = 7; //CONCURRENTES CAMPOS
            }

            return GRUPO;
        }
    }
}
