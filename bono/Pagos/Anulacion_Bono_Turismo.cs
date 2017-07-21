using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.bono.Pagos
{   
    public partial class Anulacion_Bono_Turismo : Form
    {
        int ID = 0;
        bo dlog = new bo();
        public Anulacion_Bono_Turismo(int pID)
        {
            InitializeComponent();
            ID = pID;
        }

        private void Anulacion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro de Anular el Bono?", "Anulacion Bono ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dlog.BajaTurismo(ID, VGlobales.vp_username, System.DateTime.Now);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    DialogResult = DialogResult.Cancel;
                    throw new Exception(ex.Message);
                    this.Close();

                }
            }
        }

        private void Reintegro_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro de Reintegrar el Bono?", "Reintegrar Bono ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Reintegro_Bono_Turismo rt = new Reintegro_Bono_Turismo(ID);
                    rt.StartPosition=  FormStartPosition.CenterScreen;
                    DialogResult = rt.ShowDialog();

                    this.Hide();
                }
                catch (Exception ex)
                {
                    DialogResult = DialogResult.Cancel;
                    MessageBox.Show("Reintegro Realizado  con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    throw new Exception(ex.Message);
                    this.Close();

                }
            }
        }

       
    }
}
