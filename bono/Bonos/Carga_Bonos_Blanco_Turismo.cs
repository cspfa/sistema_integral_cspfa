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
    public partial class Carga_Bonos_Blanco_Turismo : Form
    {
        BonoUtils bu = new BonoUtils();
        bo_Turismo dlog = new bo_Turismo();
        SOCIOS.Turismo.TurismoUtils utilsTurismo = new SOCIOS.Turismo.TurismoUtils();
        public Carga_Bonos_Blanco_Turismo()
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
                string TIPO = "";
                SOCIOS.bono.handlerDatosSocios srvDatosSocio = new handlerDatosSocios("", "");
                for (int I = 0; I < Veces; I++)
                {

                    if (cbCODIGOS.Text.Contains("PASAJE"))
                        TIPO = "PAS";
                    else if (cbCODIGOS.Text.Contains("PAQ"))
                        TIPO = "PAQ";
                    else
                        TIPO = "HOT";

                    dlog.InsertBonoTurismo(0, 0, 0, 0, 0, System.DateTime.Now, 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, "", "", 0, "", "", VGlobales.vp_username, TIPO, 0, 0, "", 0, VGlobales.vp_role.TrimEnd().TrimStart(), CODINT, 0, "SI");

                    int ID = utilsTurismo.GetMaxID("0", TIPO);

                    //Obtener Proximo ID_ROL
                    int ID_ROL = utilsTurismo.GetMax_ID_ROL(VGlobales.vp_role.TrimEnd().TrimStart(), CODINT) + 1;

                    dlog.Seteo_Id_ROL(ID, ID_ROL);


                    if (TIPO == "HOT")
                    {
                        ReporteBonoHotel_Blanco bb = new ReporteBonoHotel_Blanco(ID_ROL, ID, System.DateTime.Now, srvDatosSocio.CAB, VGlobales.vp_role.TrimEnd().TrimStart());
                        bb.ShowDialog();


                    }
                    else if (TIPO == "PAQ")
                    {
                        ReporteBonoPaquete_Blanco bp = new ReporteBonoPaquete_Blanco(ID_ROL, ID, System.DateTime.Now, srvDatosSocio.CAB, VGlobales.vp_role.TrimEnd().TrimStart());
                        bp.ShowDialog();
                    }
                    else if (TIPO == "PAS")
                    {
                        ReporteBonoPasaje_Blanco bp = new ReporteBonoPasaje_Blanco(ID_ROL, ID, System.DateTime.Now, srvDatosSocio.CAB, VGlobales.vp_role.TrimEnd().TrimStart());
                        bp.ShowDialog();
                    }


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
