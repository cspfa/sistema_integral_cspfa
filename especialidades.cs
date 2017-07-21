using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            comboEspecialidadesBaja();
            tbEspecialidad.CharacterCasing = CharacterCasing.Upper;
            btnBaja.Enabled = false;
            btnCancelar.Enabled = false;
            btnModificar.Visible = false;
        }

        public void comboEspecialidades()
        {
            cbEspecialidades.DataSource = null;
            string query = "SELECT ID, ESPECIALIDAD FROM ESPECIALIDADES WHERE BAJA IS NULL ORDER BY ESPECIALIDAD;";
            cbEspecialidades.Items.Clear();
            cbEspecialidades.SelectedItem = 0;
            cbEspecialidades.DataSource = dlog.BO_EjecutoDataTable(query);
            cbEspecialidades.DisplayMember = "ESPECIALIDAD";
            cbEspecialidades.ValueMember = "ID";
        }

        public void comboEspecialidadesBaja()
        {
            cbEspecialidadesBaja.DataSource = null;
            string query = "SELECT ID, ESPECIALIDAD FROM ESPECIALIDADES WHERE BAJA IS NOT NULL ORDER BY ESPECIALIDAD;";

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                cbEspecialidadesBaja.Enabled = true;
                btnRestaurar.Enabled = true;
                cbEspecialidadesBaja.Items.Clear();
                cbEspecialidadesBaja.SelectedItem = 0;
                cbEspecialidadesBaja.DataSource = dlog.BO_EjecutoDataTable(query);
                cbEspecialidadesBaja.DisplayMember = "ESPECIALIDAD";
                cbEspecialidadesBaja.ValueMember = "ID";
            }
            else
            {
                cbEspecialidadesBaja.Enabled = false;
                btnRestaurar.Enabled = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tbEspecialidad.Text == "")
            {
                tbEspecialidad.Focus();
                MessageBox.Show("El campo Especialidad no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbArancelSocio.Text == "")
            {
                tbArancelSocio.Focus();
                MessageBox.Show("El campo Arancel Socio no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbArancelNoSocio.Text == "")
            {
                tbArancelNoSocio.Focus();
                MessageBox.Show("El campo Arancel No Socio no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ID != 0)
                {
                    try
                    {
                        dlog.modificarEspecialidad(ID, tbEspecialidad.Text, int.Parse(string.Format("{0}", tbArancelSocio.Text)), int.Parse(string.Format("{0}", tbArancelNoSocio.Text)));
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
                    bool existe = ex.check("ESPECIALIDADES", "ESPECIALIDAD", tbEspecialidad.Text);

                    if (existe == true)
                    {
                        MessageBox.Show("Ya existe una especialidad con el nombre " + tbEspecialidad.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            dlog.nuevaEspecialidad(tbEspecialidad.Text, int.Parse(string.Format("{0}", tbArancelSocio.Text)), int.Parse(string.Format("{0}", tbArancelNoSocio.Text)));
                            MessageBox.Show("Registro creado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("No se pudo crear el registro\n" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        public void cambiarValores(int ID)
        {
            string query = "SELECT ID, ESPECIALIDAD, ARANCEL_SOC, ARANCEL_NOSOC, BAJA FROM ESPECIALIDADES WHERE ID = " + ID + ";";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();
            tbEspecialidad.Text = foundRows[0][1].ToString();
            tbArancelSocio.Text = foundRows[0][2].ToString();
            tbArancelNoSocio.Text = foundRows[0][3].ToString();

            if (foundRows[0][4].ToString() != "")
            {
                btnRestaurar.Visible = true;
                btnAceptar.Visible = false;
            }
            else
            {
                btnBaja.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ID = int.Parse(string.Format("{0}", cbEspecialidades.SelectedValue));
            cambiarValores(ID);
            btnBaja.Enabled = true;
            btnCancelar.Enabled = true;
            btnAceptar.Visible = false;
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
                    btnBaja.Enabled = false;
                    btnCancelar.Enabled = false;
                    cleanForm();
                    comboEspecialidades();
                    comboEspecialidadesBaja();
                }
                catch (Exception error)
                {
                    MessageBox.Show("No se pudo dar de baja el registro\n" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void cleanForm()
        {
            tbArancelNoSocio.Text = "";
            tbArancelSocio.Text = "";
            tbEspecialidad.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cancelar la edición del registro?", "Cancelar Edición", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cleanForm();
                btnBaja.Enabled = false;
                btnCancelar.Enabled = false;
                btnModificar.Visible = false;
                btnAceptar.Visible = true;
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            int IDBAJA = int.Parse(string.Format("{0}", cbEspecialidadesBaja.SelectedValue));

            if (MessageBox.Show("¿Confirma la restauración del registro?", "Restaurar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dlog.nuevaAltaEspecialidad(IDBAJA, null, DateTime.Now.ToString());
                    MessageBox.Show("Registro restaurado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboEspecialidades();
                    comboEspecialidadesBaja();
                }
                catch (Exception error)
                {
                    MessageBox.Show("No se pudo restaurar el registro\n" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Confirma la modificación del registro?", "Confirmar Modificación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dlog.modificarEspecialidad(ID, tbEspecialidad.Text, int.Parse(string.Format("{0}", tbArancelSocio.Text)), int.Parse(string.Format("{0}", tbArancelNoSocio.Text)));
                    MessageBox.Show("Registro modificado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboEspecialidades();
                }
                catch (Exception error)
                {
                    MessageBox.Show("No se pudo modificar el registro\n" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
