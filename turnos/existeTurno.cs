using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Firebird;

namespace SOCIOS
{
    class existeTurno
    {
        bo dlog = new bo();

        public bool existe(int DIAHORA)
        {
            string query = "SELECT DIAYHORA FROM TURNOS_MEDICOS WHERE DIAYHORA = " + DIAHORA + " AND BAJA IS NULL;";

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
