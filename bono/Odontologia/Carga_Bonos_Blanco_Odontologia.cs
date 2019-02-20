using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.bono.Bonos
{
    public partial class Carga_Bonos_Blanco_Odontologia : Form
    {
        BonoUtils bu = new BonoUtils();

        BO.bo_ServiciosMedicos dlog = new BO.bo_ServiciosMedicos();
        SOCIOS.bono.Odontologia.ServicioOdonto odontoService = new Odontologia.ServicioOdonto();

        public Carga_Bonos_Blanco_Odontologia()
        {
            InitializeComponent();
            this.ComboOdontologia();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

           

        }

        public void ComboOdontologia()
        {
            cbOdontologia.DataSource = null;
            string query = "SELECT ID, DETALLE FROM SECTACT WHERE ROL = '" + VGlobales.vp_role + "' AND DETALLE LIKE '%ODONTO%'  ORDER BY DETALLE;";
            cbOdontologia.Items.Clear();
            cbOdontologia.DataSource = dlog.BO_EjecutoDataTable(query);
            cbOdontologia.DisplayMember = "DETALLE";
            cbOdontologia.ValueMember = "ID";
            cbOdontologia.SelectedIndex = -1;

        }


        private void Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
            
                int Veces = Int32.Parse(tbCantidad.Text);
               
                int PROFESIONAL = 0;
                int SECTACT=0;
                string TIPO = "";

                PROFESIONAL = Int32.Parse(cbProfesionales.SelectedValue.ToString());
                SECTACT = Int32.Parse(cbOdontologia.SelectedValue.ToString());

                int CODINT = odontoService.Tratamiento_Odontologico_CodInt(PROFESIONAL, SECTACT);
                SOCIOS.bono.handlerDatosSocios srvDatosSocio = new handlerDatosSocios("", "");

                for (int I = 0; I < Veces; I++)
                {
                    

                    dlog.InsertOdontologico(0,0,0," ",0,0,System.DateTime.Now, PROFESIONAL,SECTACT, 0,0,0,0," "," "," "," "," "," ",0,0,0,0,0,0,0,0," "," "," ",0, VGlobales.vp_username, 0, VGlobales.vp_role,CODINT,0,"SI",0,0,0,0,0,0);

               
                    //Obtener Proximo ID_ROL
                    int   ID_ROL = odontoService.GetMax_ID_ROL(VGlobales.vp_role.TrimEnd().TrimStart(), CODINT);
                    int   idBono =   odontoService.GetMaxID("0","0","0");
                    dlog.Seteo_Id_ROL(idBono, ID_ROL);
                    
                    ReporteBonoOdontologico_Blanco rb = new ReporteBonoOdontologico_Blanco(ID_ROL, CODINT,cbProfesionales.Text);
                    rb.ShowDialog();
                                                     
                    System.Threading.Thread.Sleep(60);

                }

                MessageBox.Show("Bonos Generados con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbOdontologia_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            if (cbOdontologia.SelectedValue != null)
                comboProfesional(cbOdontologia.SelectedValue.ToString(),cbProfesionales);
        
        }

        public bool comboProfesional(string ESPECIALIDAD, ComboBox cbProfesionales)
        {
            try
            {
                cbProfesionales.DataSource = null;

                string query = "SELECT P.ID, P.NOMBRE FROM PROFESIONALES P, PROF_ESP PE WHERE PE.ESPECIALIDAD = " + ESPECIALIDAD + " AND PE.PROFESIONAL = P.ID AND P.BAJA IS NULL ORDER BY P.NOMBRE ASC;";

                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();

                if (foundRows.Length > 0)
                {
                    cbProfesionales.Items.Clear();
                    cbProfesionales.SelectedItem = 0;
                    cbProfesionales.DataSource = dlog.BO_EjecutoDataTable(query);
                    cbProfesionales.DisplayMember = "NOMBRE";
                    cbProfesionales.ValueMember = "ID";
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
