using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SOCIOS
{
    class COD_DTO
    {
        bo dlog = new bo();
        public string getCodigoDTO(string NRO_SOC, string NRO_DEP, string TABLA)
        {
            string query;

            if (TABLA == "TITULAR" ||TABLA == "FAMILIAR")
            {
                query = "Select COD_DTO from TITULAR where NRO_SOC =" + NRO_SOC.ToString() +
                        "AND NRO_DEP = " + NRO_DEP;
            }
            else
            {
                query = "Select COD_DTO from ADHERENT where NRO_ADH =" + NRO_SOC.ToString() +
                          "AND NRO_DEPADH = " + NRO_DEP;
            
            }

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                return foundRows[0][0].ToString();



            }
            else
                return "";
        }
    
    
    }
}
