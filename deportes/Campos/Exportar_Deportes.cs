using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.deportes.Campos
{
    public partial class Exportar_Deportes : Form
    {
        SOCIOS.deportes.DeportesService ds = new DeportesService();
        List<Deporte_Importacion> lista = new List<Deporte_Importacion>();
        string ROL = "";

        public Exportar_Deportes(string pROL)
        {
            InitializeComponent();
            this.InicializarCombos(pROL);

        }

        private void InicializarCombos(string pROL)
        {
            if (pROL.Length == 0)
            {
                cbROLES.Visible = true;

                cbROLES.Items.Add("CPOCABA");
            }
            else
            {
                cbROLES.Visible = false;
                ROL = pROL;
                lbRol.Text = ROL;
            }

            fechaDesde.Value = System.DateTime.Now.AddDays(-1);
            fechaHasta.Value = System.DateTime.Now.AddDays(1);

        }

        private void regRed_Click(object sender, EventArgs e)
        {

            string ROL_IMPORTACION = "";

            if (ROL.Length == 0)
                ROL_IMPORTACION = cbROLES.Text.TrimEnd().TrimStart();
            else
                ROL_IMPORTACION = ROL;

            lista = ds.Importar_Exportar_Deporte(FECHAS.fechaUSA(fechaDesde.Value), FECHAS.fechaUSA(fechaHasta.Value),ROL_IMPORTACION ,cb_Deportes.Checked);
            dgDeportes.Visible = true;
            dgDeportes.DataSource = lista;
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                ds.Proceso_Importar_Exportar(lista, fechaDesde.Value, fechaHasta.Value, cbROLES.Text, cb_Deportes.Checked, cbAsistencia.Checked);
                dgDeportes.Visible = false;
                MessageBox.Show("Proceso de Importacion Con Exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbROLES_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
