using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SOCIOS
{
    class bonoVacio
    {
        public bool bono(int ID_BONO)
        {
            bo dlog = new bo();
            string query = "SELECT ID FROM BONOS_CAJA WHERE ID = " + ID_BONO + " AND CUENTA_DEBE IS NULL;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length == 1)
                return true;
            else
                return false;
        }
    }
}
