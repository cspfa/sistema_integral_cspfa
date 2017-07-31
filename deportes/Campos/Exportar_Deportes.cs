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

        public Exportar_Deportes()
        {
            InitializeComponent();
            this.InicializarCombos();

        }

        private void InicializarCombos()
        {
            cbROLES.Items.Add("CPOCABA");
            fechaDesde.Value = System.DateTime.Now.AddDays(-1);
            fechaHasta.Value = System.DateTime.Now.AddDays(1);

        }

        private void regRed_Click(object sender, EventArgs e)
        {
            lista = ds.Importar_Exportar_Deporte(FECHAS.fechaUSA(fechaDesde.Value), FECHAS.fechaUSA(fechaHasta.Value), cbROLES.Text.TrimEnd().TrimStart());
            dgDeportes.Visible = true;
            dgDeportes.DataSource = lista;
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                ds.Proceso_Importar_Exportar(lista,fechaDesde.Value,fechaHasta.Value,cbROLES.Text);
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
