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
            cbCODIGOS.ValueMember = "CODIGO";
            cbCODIGOS.DisplayMember = "DES";
            cbCODIGOS.DataSource = bu.getCodigos(VGlobales.vp_role.TrimEnd().TrimStart());
        }

        private void label2_Click(object sender, EventArgs e)
        {

           

        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                int Veces = Int32.Parse(tbCantidad.Text);
                int CODINT = Int32.Parse(cbCODIGOS.SelectedValue.ToString());
                int PROFESIONAL = 0;
                int SECTACT=0;
                string TIPO = "";
                SOCIOS.bono.handlerDatosSocios srvDatosSocio = new handlerDatosSocios("", "");
                for (int I = 0; I < Veces; I++)
                {





                    dlog.InsertOdontologico(0,0,0,0,0,0,System.DateTime.Now, PROFESIONAL,SECTACT, 0,0,0,0, "","","","","","","","","","","","","","","","","",0, VGlobales.vp_username, 0, VGlobales.vp_role,CODINT,0);

               
                    //Obtener Proximo ID_ROL
                    int   ID_ROL = odontoService.GetMax_ID_ROL(VGlobales.vp_role.TrimEnd().TrimStart(), CODINT);
                    int   idBono =   odontoService.GetMaxID("","","");
                    dlog.Seteo_Id_ROL(idBono, ID_ROL);

                    ReporteBonoOdontologico_Blanco rb = new ReporteBonoOdontologico_Blanco(ID_ROL, CODINT);
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
    }
}
