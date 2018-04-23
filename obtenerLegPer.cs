using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SOCIOS
{
    public class obtenerLegPer
    {
        public int get(int NRO_SOC, int NRO_DEP)
        {
            int LEG_PER = 0;
            string LP = "";
            bo dlog = new bo();
            string QUERY = "SELECT LEG_PER FROM TITULAR WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                LP = foundRows[0][0].ToString();

                if (LP != "")
                    LEG_PER = int.Parse(foundRows[0][0].ToString());
            }

            return LEG_PER;
        }
    }
}
