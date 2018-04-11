using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace SOCIOS
{
    public class existe
    {
        bo dlog = new bo();

        public bool check(string TABLA, string CAMPO, string VALOR)
        {
            string query = "SELECT " + CAMPO + " FROM " + TABLA + " WHERE " + CAMPO + " = '" + VALOR + "';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
