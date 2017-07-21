using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SOCIOS
{
    class reciboVacio
    {
        public bool recibo(int ID_RECIBO)
        {
            bo dlog = new bo();
            string query = "SELECT ID FROM RECIBOS_CAJA WHERE ID = " + ID_RECIBO + " AND CUENTA_HABER IS NULL;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
                return true;
            else
                return false;
        }

        public bool bono(int ID_BONO)
        {
            bo dlog = new bo();
            string query = "SELECT ID FROM BONOS_CAJA WHERE ID = " + ID_BONO + " AND CUENTA_HABER IS NULL;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
                return true;
            else
                return false;
        }
    }
}
