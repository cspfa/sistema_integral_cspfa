using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SOCIOS
{
    public partial class anular_op : Form
    {
        private string OR_PA { get; set; }

        public anular_op(string OP)
        {
            InitializeComponent();
            OR_PA = OP;
        }

        private void btnAnularOp_Click_1(object sender, EventArgs e)
        {
            int ID_OP = int.Parse(OR_PA);
            string USR_ANULA = VGlobales.vp_username;
            //string OBS_ANULA
            if (MessageBox.Show("¿CONFIRMA ANULAR LA ORDEN DE PAGO Nº " + OR_PA + "?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tbObsAnulaOp.Text == "")
                {
                    tbObsAnulaOp.Focus();
                    MessageBox.Show("INGRESAR UNA OBSERVACIÓN SOBRE LA ANULACIÓN DE LA ORDEN DE PAGO", "ERROR");
                }
                else
                {

                }
            }
        }
    }
}
