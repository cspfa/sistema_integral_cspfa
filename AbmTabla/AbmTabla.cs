using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Tabla
{
    public partial class AbmTabla : Form
    {
        SOCIOS.AbmTabla.TableInterface inter;
        public AbmTabla()
        {
            InitializeComponent();
        }

        public AbmTabla(string Titulo)

        {
            InitializeComponent();
            if (Titulo == "REGIMEN")
                inter = new SOCIOS.AbmTabla.Regimen();
            else if (Titulo == "TRASLADO")
                inter = new SOCIOS.AbmTabla.Traslado();
            else if (Titulo == "TIPOSALIDA")
                inter = new SOCIOS.AbmTabla.TipoSalida();

            this.Text = Titulo;
            Refresh();
        }

        private void Refresh()
        {
            dgvDatos.DataSource = inter.getData();
            dgvDatos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDatos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        
        
        }

        private void CancelarBank_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
               
                if (MessageBox.Show("¿Borro el Registro?", "BORRAR ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int ID = Int32.Parse(dgvDatos.SelectedRows[0].Cells[0].Value.ToString());
                    try
                    {
                        inter.Borrar(ID);
                        this.valores(false);
                        this.Refresh();
                        MessageBox.Show("REGISTRO BORRADO CON EXITO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)

                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void  valores(bool vista)
        {
            gpValores.Visible = vista;

            tbNombre.Text = "";
          
        
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbNombre.Text.Length > 1)
                {
                    inter.Insertar(tbNombre.Text);
                    this.valores(false);
                    this.Refresh();
                    MessageBox.Show("REGISTRO INSERTADO CON EXITO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NuevoBank_Click(object sender, EventArgs e)
        {
            this.valores(true);
        }
    }
}
