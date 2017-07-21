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
    class nombreProf
    {
        public string nombre(int IDPROF)
        {
            bo dlog = new bo();
            string nombre = string.Empty;

            try
            {
                string query = "SELECT NOMBRE FROM PROFESIONALES WHERE ID = " + IDPROF + ";";
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();

                if (foundRows.Length > 0)
                    nombre = foundRows[0][0].ToString();
                else
                    nombre = "-";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            
            return nombre;
        }
    }
}
