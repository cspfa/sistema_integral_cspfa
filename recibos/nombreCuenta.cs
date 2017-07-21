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
    class nombreCuenta
    {
        public string nombre(string NUMEROCTA)
        {
            bo dlog = new bo();
            string nombre = "";

            try
            {
                string query = "SELECT NOMBRECTA FROM CUENTAS WHERE NUMEROCTA = " + NUMEROCTA;
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();

                if (foundRows.Length > 0)
                    nombre = foundRows[0][0].ToString().Trim();
                else
                    nombre = "NO SE ENCONTRARON DATOS";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return nombre;
        }
    }
}
