using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    class checkHour 
    {
        bo dlog = new bo();

        public bool checkH(string fecha_hora, int persona)
        {
            string query = "SELECT FIRST 1 FECHA_HORA FROM MOVIMIENTOS WHERE PERSONA = " + persona + " ORDER BY FECHA_HORA DESC;";
            DataRow[] fRows;
            fRows = dlog.BO_EjecutoDataTable(query).Select();

            if (fRows.Length > 0)
            {
                DateTime dt = Convert.ToDateTime(fRows[0][0].ToString());
                DateTime dtFechaHora = Convert.ToDateTime(fecha_hora);

                if (dt > dtFechaHora)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}
