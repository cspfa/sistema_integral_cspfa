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
    class nroSocio
    {
        public int numero(int ENTIDAD)
        {
            bo dlog = new bo();
            
            int numero;
            
            string query = "SELECT MAX(VALOR)+1 FROM NUMERADORES WHERE ID_ENTIDAD = " + ENTIDAD;

            DataRow[] foundRows;
            
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            numero = int.Parse(foundRows[0][0].ToString());

            return numero;
        }
    }
}
