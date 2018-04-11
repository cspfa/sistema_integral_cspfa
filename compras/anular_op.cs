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
        BO.bo_Compras BO_COMPRAS = new BO.bo_Compras();
        private string OR_PA { get; set; }
        private string ACTION { get; set; }
        private string MSG_CONF { get; set; }
        private string MSG_ERR { get; set; }
        private string MSG_SUC { get; set; }
        private string TXT_BOT { get; set; }

        public anular_op(string OP, string ACCION)
        {
            InitializeComponent();
            OR_PA = OP;
            ACTION = ACCION;

            if (ACTION == "ANULA")
            {
                this.Text = "ANULAR ORDEN DE PAGO Nº " + OP;
                MSG_CONF  = "¿CONFIRMA ANULAR LA ORDEN DE PAGO Nº " + OR_PA + "?";
                MSG_ERR   = "NO SE PUDO ANULAR LA ORDEN DE PAGO Nº " + OR_PA;
                MSG_SUC   = "ORDEN DE PAGO Nº " + OR_PA + " ANULADA PENDIENTE DE CONFIRMACIÓN";
                TXT_BOT   = "ANULAR ORDEN DE PAGO";
            }

            if (ACTION == "CONFIRMA")
            {
                this.Text = "CONFIRMAR ANULACIÓN DE ORDEN DE PAGO Nº " + OP;
                MSG_CONF  = "¿CONFIRMA LA ANULACIÓN DE LA ORDEN DE PAGO Nº " + OR_PA + "?";
                MSG_ERR   = "NO SE PUDO CONFIRMAR LA ANULACIÓN DE LA ORDEN DE PAGO Nº " + OR_PA;
                MSG_SUC   = "ORDEN DE PAGO Nº " + OR_PA + " ANULADA CORRECTAMENTE";
                TXT_BOT   = "CONFIRMA ANULACIÓN";
            }

            if (ACTION == "CANCELA")
            {
                this.Text = "CANCELAR ANULACIÓN DE ORDEN DE PAGO Nº " + OP;
                MSG_CONF = "¿CONFIRMA CANCELAR ANULACIÓN DE LA ORDEN DE PAGO Nº " + OR_PA + "?";
                MSG_ERR = "NO SE PUDO CANCELAR LA ANULACIÓN DE LA ORDEN DE PAGO Nº " + OR_PA;
                MSG_SUC = "SE CANCELÓ LA ANULACIÓN DE LA ORDEN DE PAGO Nº " + OR_PA + " CORRECTAMENTE";
                TXT_BOT = "CANCELAR ANULACIÓN";
            }

            btnAnularOp.Text = TXT_BOT;
        }

        private void btnAnularOp_Click_1(object sender, EventArgs e)
        {
            int ID_OP = int.Parse(OR_PA);
            string USR = VGlobales.vp_username;
            string OBS = "";
            string FEC = DateTime.Now.ToShortDateString();

            if (MessageBox.Show(MSG_CONF, "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tbObsAnulaOp.Text == "")
                {
                    tbObsAnulaOp.Focus();
                    MessageBox.Show("INGRESAR UNA OBSERVACIÓN", "ERROR");
                }
                else
                {
                    try
                    {
                        OBS = tbObsAnulaOp.Text.Trim();

                        if (ACTION == "ANULA")
                        {
                            BO_COMPRAS.anularOrdenDePago(ID_OP, USR, OBS, FEC);
                        }

                        if (ACTION == "CONFIRMA")
                        {
                            BO_COMPRAS.confirmaAnulacionOrdenDePago(ID_OP, USR, OBS, FEC);
                        }

                        if (ACTION == "CANCELA")
                        {
                            BO_COMPRAS.cancelaAnulacionOrdenDePago(ID_OP, USR, OBS, FEC);
                        }
                        
                        MessageBox.Show(MSG_SUC, "LISTO!");
                        this.Close();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(MSG_ERR + "\n" + error, "ERROR!");
                        this.Close();
                    }
                }
            }
        }
    }
}
