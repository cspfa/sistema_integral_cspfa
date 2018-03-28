using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.deportes
{
    public partial class Responsables : Form
    {
      public   List<Registro_Responsables> Lista = new List<Registro_Responsables>();

        public Responsables(List<Registro_Responsables> pLista)
        {
            InitializeComponent();
            Lista = pLista;
            dataGridView1.DataSource = pLista;
        }

        public Responsables()
        {
            InitializeComponent();
        }

        private void btnGranar_Click(object sender, EventArgs e)
        {
            Registro_Responsables Respon = new Registro_Responsables();
            Respon.DNI    = tbDni.Text;
            Respon.NOMBRE = tbNombre.Text;
            Respon.APELLIDO = tbApellido.Text;
            Respon.EMAIL = tbMail.Text;
            Respon.FECHA = System.DateTime.Now.ToShortDateString();
            Respon.USUARIO = VGlobales.vp_username.TrimEnd().TrimStart();
            Respon.VINCULO = tbVinculo.Text;
            Respon.ROL = VGlobales.vp_role.TrimEnd().TrimStart();
            Respon.BORRAR = false;
            Respon.NUEVO = true;
            Respon.TELEFONO = tbTelefono.Text.TrimEnd().TrimStart();
            Lista.Add(Respon);
            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Lista;
            dataGridView1.Refresh();
            
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;

            gpNuevo.Visible = false;
            btnGrabar.Visible = true;


        }

        private void NuevoBank_Click(object sender, EventArgs e)
        {
            gpNuevo.Visible = true;
            btnGrabar.Visible = false;
        }

        private void CancelarBank_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar Borrado de Vinculo", "Confirmar Borrado", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string DNI = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().TrimEnd().TrimStart();
                var item = Lista.Where(x => x.DNI == DNI).FirstOrDefault();
               
                if (item != null)
                {
                    Lista.Where(x => x.DNI == DNI).FirstOrDefault().BORRAR = true;
                }
            }

        }
    }
}
