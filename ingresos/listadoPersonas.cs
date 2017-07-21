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
    class listadoPersonas
    {
        bo dlog = new bo();

        public DataRow[] listado(int escalafon)
        {
            string query = "SELECT PERSONAS.NOMBRE, TEMP_PA.PA FROM PERSONAS, TEMP_PA WHERE PERSONAS.ESCALAFON = " + escalafon + " AND PERSONAS.ID = TEMP_PA.PERSONA AND PERSONAS.ESTADO = 1 ORDER BY PERSONAS.NOMBRE;";
            DataRow[] fRows;
            fRows = dlog.BO_EjecutoDataTable(query).Select();
            return fRows;   
        }
    }
}
