using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SOCIOS
{
    class afiliadoBeneficio
    {
        public string[] get(int NRO_SOC, int NRO_DEP)
        {
            string[] RES;
            string AFILIADO = "";
            string BENEFICIO = "";
            bo dlog = new bo();
            string QUERY = "SELECT AAR, ACRJP2, PCRJP1, PCRJP2, PCRJP3 FROM TITULAR WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                AFILIADO = foundRows[0][0].ToString().Trim() + "/" + foundRows[0][1].ToString().Trim();
                BENEFICIO = foundRows[0][2].ToString().Trim() + "/" + foundRows[0][3].ToString().Trim() + "/" + foundRows[0][4].ToString().Trim();
                RES = new string[] { AFILIADO, BENEFICIO };
            }
            else
            {
                RES = new string[] { "X", "X" };
            }

            return RES;
        }
    }
}
