using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS
{
    public class sectAct
    {
        bo dlog = new bo();

        public string sectact(int SECTACT)
        {
            string sectact = string.Empty;

            try
            {
                string query = "SELECT DETALLE FROM SECTACT WHERE ID = " + SECTACT;
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();

                if (foundRows.Length > 0)
                    sectact = foundRows[0][0].ToString().Trim();
                else
                    sectact = "NO SE ENCONTRARON DATOS - " + SECTACT;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return sectact;
        }

        public DataRow[] getIdsFromSectAct(string SECTACT)
        {
            DataRow[] foundRows = null;

            try
            {
                string query = "SELECT ID FROM SECTACT WHERE ROL = '" + SECTACT + "' ORDER BY ID ASC;"; 
                foundRows = dlog.BO_EjecutoDataTable(query).Select();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return foundRows;
        }
    }
}
