using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace SOCIOS.utils
{
    public class servicioEdad
    {

        public void FaltantesEdad(DataGridView dg)
        {

            if (dg.Rows.Count == 0)
                return;
            foreach (DataGridViewRow row in dg.Rows)
            {
                if (row.Cells[10].Value != null)
                {
                    string Edad = row.Cells[10].Value.ToString();

                    if (Edad.Length == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;

                    }
                }
                
            }

        }
    }
}