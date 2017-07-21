using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class especialidades : Form
    {
        bo dlog = new bo();

        private int ID;
        public int _ID
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        public especialidades(int ID)
        {
            InitializeComponent();
            comboEspecialidades();
            tbEspecialidad.CharacterCasing = CharacterCasing.Upper;
        }

        public void comboEspecialidades()
        {
            cbEspecialidades.DataSource = null;
            string query = "SELECT ID, DETALLE, ARANCEL_SO, ARANCEL_NSO, PISO, NRO_CTA, CODINT FROM SECTACT WHERE ROL = 'SERVICIOS MEDICOS' AND ESTADO = 1 ORDER BY DETALLE;";
            cbEspecialidades.Items.Clear();
            cbEspecialidades.SelectedItem = 0;
            cbEspecialidades.DataSource = dlog.BO_EjecutoDataTable(query);
            cbEspecialidades.DisplayMember = "DETALLE";
            cbEspecialidades.ValueMember = "ID";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }

        public void cambiarValores(int ID)
        {
            string query = "SELECT ID, DETALLE FROM SECTACT WHERE ID = " + ID + ";";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();
            tbEspecialidad.Text = foundRows[0][1].ToString().TrimEnd();

            if (foundRows[0][0].ToString() != "")
            {
                btnModificar.Visible = false;
            }
            else
            {
                //btnBaja.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ID = int.Parse(string.Format("{0}", cbEspecialidades.SelectedValue));
            cambiarValores(ID);
            btnModificar.Visible = true;
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Confirma la baja del registro?", "Baja", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dlog.bajaEspecialidad(ID, DateTime.Now.ToString());
                    MessageBox.Show("Baja realizada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleanForm();
                    comboEspecialidades();
                }
                catch (Exception error)
                {
                    MessageBox.Show("No se pudo dar de baja el registro\n" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void cleanForm()
        {
            tbEspecialidad.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cancelar la edición del registro?", "Cancelar Edición", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cleanForm();
                btnModificar.Visible = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (tbEspecialidad.Text == "")
            {
                tbEspecialidad.Focus();

                MessageBox.Show("El campo Especialidad no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ID != 0)
                {
                    try
                    {
                        dlog.modificarEspecialidad(ID, tbEspecialidad.Text);

                        MessageBox.Show("Registro modificado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("No se pudo modificar el registro\n" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    existe ex = new existe();

                    bool existe = ex.check("SECTACT", "DETALLE", tbEspecialidad.Text);

                    if (existe == true)
                    {
                        MessageBox.Show("Ya existe una especialidad con el nombre " + tbEspecialidad.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            string ROLE = "SERVICIOS MEDICOS";
                            string SECTACT = tbEspecialidad.Text;
                            int CODINT = Convert.ToInt32(tbCodint.Text);
                            int CODCP = Convert.ToInt32(tbCodcp.Text);
                            dlog.nuevaEspecialidad(ROLE, SECTACT, CODINT, CODCP);
                            MessageBox.Show("DATOS GUARDADOS");
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("No se pudo crear el registro\n" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ID = int.Parse(string.Format("{0}", cbEspecialidades.SelectedValue));

            if (MessageBox.Show("¿Confirma la baja de la especialidad?", "Confirmar Baja", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dlog.modificarEstadoSectAct(ID, 0);

                    MessageBox.Show("Registro eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    comboEspecialidades();
                }
                catch (Exception error)
                {
                    MessageBox.Show("No se pudo eliminar el registro\n" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
