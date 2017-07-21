using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.deportes
{
    public partial class CadetesMayores : Form
    {
        SOCIOS.deportes.VencimientoEdad ve = new VencimientoEdad();
        public CadetesMayores()
        {
            InitializeComponent();
          

            GrillaDatos.DataSource = ve.getDataReporteVencimientoEdad();



        }

        private void Procesar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Procesar y dar de Baja Seleccionados?", "Confirmacion ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    ve.ProcesoBaja();
                    GrillaDatos.DataSource = ve.getDataReporteVencimientoEdad();
                    MessageBox.Show("Proceso Realizado con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }
            }
        }
    }
}
