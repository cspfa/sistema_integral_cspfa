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
    public partial class UpdateTicket: Form
    {
        int MODO = 0; //1 : Activo, 2: Cumplimentado, 3: Cancelado
        bo_Tecnica dlog = new bo_Tecnica();
        int ID;
        string ROL;
        TecnicaServices ts = new TecnicaServices();
        Ticket objTicket = new Ticket();

        public UpdateTicket(int pID)
        {
            InitializeComponent();
            ID = pID;
            objTicket = ts.getTicket(pID);
            tbObs.Focus();
            this.comboPrioridad();
            
       
       
            ts.CargoTEcnicos(cbTecnico);

            if (objTicket.TECNICO.Length > 0)
            {
                cbTecnico.Text = objTicket.TECNICO;

            }

          

            lbDato.Text = "TICKET NRO: " + pID.ToString() + " - " + objTicket.ESTADO ;
            ID = pID;




            if (objTicket.ESTADO == "ACTIVO")
            {
                tbObs.Text = objTicket.OBS_ACTIVO;
                MODO = 1;
            }

            else if (objTicket.ESTADO == "CANCELADO")
            {
                tbObs.Text = objTicket.OBS_CANCELADO;
                MODO = 3;
            }

            else if (objTicket.ESTADO == "CUMPLIMENTADO")
            {
                tbObs.Text = objTicket.OBS_CUMPLIMENTADO;
                MODO = 2;
            }
            else if (objTicket.ESTADO == "PENDIENTE")
               { tbObs.Text = objTicket.PROBLEMA;
                 MODO = 4;
                }


            if (objTicket.PRIORIDAD.Length > 0)
                cbPrioridad.Text = objTicket.PRIORIDAD;


        }

        private void comboPrioridad()
        {
            cbPrioridad.Items.Add("NORMAL");
            cbPrioridad.Items.Add("ALTA");
            cbPrioridad.Items.Add("BAJA");
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string ObsActivo = "";
            string ObsCancel = "";
            string ObsCumpli = "";
            string OBS       = "";

            if (MODO == 1)
            {
                ObsActivo = tbObs.Text;
            }
            else if (MODO == 2)
            {
                ObsCumpli = tbObs.Text;
            }
            else if (MODO == 3)
            {
                ObsCancel = tbObs.Text;
            }
            else if (MODO == 4)
                objTicket.PROBLEMA = tbObs.Text;



            try
            {
                dlog.Asistencia_Tecnica_Update(ID, ObsActivo, ObsCancel, ObsCumpli, cbTecnico.Text, cbPrioridad.Text,objTicket.PROBLEMA);
               
                MessageBox.Show("Registo Modificado Con Exito");
                this.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

            }

        }

        private void tbObs_KeyUp(object sender, KeyEventArgs e)
        {
            int DISP = 300 - tbObs.Text.Length;
            lbDisponibles.Text = "CARACTERES DISPONIBLES: " + DISP.ToString();

            if (DISP < 50)
            {
                lbDisponibles.ForeColor = Color.Red;
            }
            else
            {
                lbDisponibles.ForeColor = Color.Black;
            }
        }
    }
}
