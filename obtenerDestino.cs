using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SOCIOS
{
    class obtenerDestino
    {
        public string get(int NRO_SOC, int NRO_DEP)
        {
            string DESTINO = "X";
            bo dlog = new bo();
            string QUERY = "SELECT CODIGOS.SIGN FROM TITULAR, CODIGOS WHERE TITULAR.NRO_SOC = " + NRO_SOC + " AND TITULAR.NRO_DEP = " + NRO_DEP + " AND 'DE'||TITULAR.DESTINO = CODIGOS.CODIGO;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                DESTINO = foundRows[0][0].ToString().Trim();
            }

            return DESTINO;
        }
    }
}
