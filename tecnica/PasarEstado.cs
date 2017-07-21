using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Tecnica
{
    public partial class PasarEstado : Form
    {
        int MODO = 0; //1 : Activo, 2: Cumplimentado, 3: Cancelado
        bo_Tecnica dlog = new bo_Tecnica();
        int ID;
        string ROL;
        TecnicaServices ts = new TecnicaServices();

        public PasarEstado(int pID, string pEstado, int pMOdo, string pROL,string Tecnico)
        {
            InitializeComponent();
            tbObs.Focus();
            MODO = pMOdo;
            ROL =pROL;
            ts.CargoTEcnicos(cbTecnico);
            
            if (Tecnico.Length > 0)
            {
                cbTecnico.SelectedValue = cbTecnico;
                
            }



            lbDato.Text = "TICKET NRO: " + pID.ToString() + " - " + pEstado;
            ID = pID;

            if (MODO == 3)
            {
                lbTecnico.Visible = false;
                cbTecnico.Visible = false;
                btnGrabar.Text = "PASAR A CANCELADO";
            }
            else if (MODO ==1 )
            {
                lbTecnico.Visible = true;
                cbTecnico.Visible = true;
                btnGrabar.Text = "PASAR A EN PROCESO";
            
            }
            else  if  (MODO == 2 )
            {
                lbTecnico.Visible = true;
                cbTecnico.Visible = true;
                btnGrabar.Text = "PASAR A CUMPLIMENTADO";
            }
        }

        private void btnGrabar_Click_1(object sender, EventArgs e)
        {
            if (cbTecnico.Text.Length == 0 && cbTecnico.Visible ==true )
            {
                MessageBox.Show("Debe Seleccionar Tecnico", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Esta Seguro de Pasar de Estado?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dlog.AsistenciaTecnica_Cambio_Estado(ID, tbObs.Text, MODO, cbTecnico.Text,ROL);
            }
        }
    }
}
