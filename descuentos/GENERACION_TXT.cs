using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.descuentos
{
    public partial class GENERACION_TXT : Form
    {

        DescuentoUtils descuentoUtils = new DescuentoUtils();
        public GENERACION_TXT()
        {
            InitializeComponent();
        }

        private void VER_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            if (rbActivos.Checked)
               dataGridView1.DataSource = descuentoUtils.DescuentosXmes((int)TIPO_ACTIVIDAD.ACTIVO);
            else
                dataGridView1.DataSource = descuentoUtils.DescuentosXmes((int)TIPO_ACTIVIDAD.PASIVO);

            GENERAR.Visible = true;
        }

        private void GENERAR_Click(object sender, EventArgs e)
        {

            TXT archivo;
            
            
            if (rbActivos.Checked)
               archivo    = new TXT((int)TIPO_ACTIVIDAD.ACTIVO);
            else
                archivo   = new TXT((int)TIPO_ACTIVIDAD.PASIVO);

            try
            {

                archivo.GenerarInfo();
                
                MessageBox.Show("TXT GRABADO C:/CSPFA_SOCIOS", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void rbActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivos.Checked)
                rbPasividad.Checked = false;
            else
                rbPasividad.Checked = true;

        }

        private void rbPasividad_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPasividad.Checked)
               rbActivos.Checked = false;
            else
                rbActivos.Checked = true;
        }
    }
}
