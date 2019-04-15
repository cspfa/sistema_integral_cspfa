using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class profesionales_abm : Form
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

        private int FILTRO;
        public int _FILTRO
        {
            get
            {
                return FILTRO;
            }
            set
            {
                FILTRO = value;
            }
        }

        public profesionales_abm(int F)
        {
            InitializeComponent();
            FILTRO = F;
            comboEspecialidades();
            comboProfesionalesBaja();
            tbNombre.CharacterCasing = CharacterCasing.Upper;
            tbMatricula.CharacterCasing = CharacterCasing.Upper;
            btnBaja.Enabled = false;
            btnCancelar.Enabled = false;
            btnEditar.Visible = false;
            comboContratos();
            comboComprobantes();
            comboAgregarProfesionales();
        }

        public void cambiarValores(int ID)
        {
            string query = "SELECT P.ID, P.NOMBRE, P.MATRICULA, P.DNI, PE.ESPECIALIDAD, P.CORREO, P.TELEFONO, P.CELULAR, P.BAJA, P.TIPO_CONTRATO, P.BONO_RECIBO, P.CUENTA FROM PROFESIONALES P, PROF_ESP PE WHERE P.ID = "+ ID +" AND P.ID = PE.PROFESIONAL;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();
            tbNombre.Text = foundRows[0][1].ToString();
            tbMatricula.Text = foundRows[0][2].ToString();
            tbDNI.Text = foundRows[0][3].ToString();
            cbEspecialidades.SelectedValue = foundRows[0][4].ToString();
            tbCorreo.Text = foundRows[0][5].ToString();
            tbTelefono.Text = foundRows[0][6].ToString();
            tbCelular.Text = foundRows[0][7].ToString();
            cbContratos.SelectedValue = foundRows[0][9].ToString();
            cbComprobante.SelectedValue = foundRows[0][10].ToString();
            tbCuenta.Text = foundRows[0][11].ToString();

        }

        public void comboEspecialidades()
        {
            cbEspecialidades.DataSource = null;
            string query = "";

            if (FILTRO == 1)
                query = "SELECT ID, DETALLE FROM SECTACT WHERE ROL = 'SERVICIOS MEDICOS' AND ESTADO = 1 ORDER BY DETALLE;";
            else
                query = "SELECT ID, TRIM(ROL)||' - '||TRIM(DETALLE) AS DETALLE FROM SECTACT WHERE ESTADO = 1 ORDER BY ROL, DETALLE;";

            cbEspecialidades.Items.Clear();
            cbEspecialidades.SelectedItem = 0;
            cbEspecialidades.DataSource = dlog.BO_EjecutoDataTable(query);
            cbEspecialidades.DisplayMember = "DETALLE";
            cbEspecialidades.ValueMember = "ID";

            cbEspecialidadMod.Items.Clear();
            cbEspecialidadMod.SelectedItem = 0;
            cbEspecialidadMod.DataSource = dlog.BO_EjecutoDataTable(query);
            cbEspecialidadMod.DisplayMember = "DETALLE";
            cbEspecialidadMod.ValueMember = "ID";

            cbEspecialidadAgregar.Items.Clear();
            cbEspecialidadAgregar.SelectedItem = 0;
            cbEspecialidadAgregar.DataSource = dlog.BO_EjecutoDataTable(query);
            cbEspecialidadAgregar.DisplayMember = "DETALLE";
            cbEspecialidadAgregar.ValueMember = "ID";
        }

        public void comboContratos()
        {
            cbContratos.DataSource = null;
            string queryTipos = "SELECT ID, DETALLE FROM TIPO_CONTRATO_PROFESIONAL ORDER BY ID;";
            cbContratos.Items.Clear();
            cbContratos.SelectedItem = 0;
            cbContratos.DataSource = dlog.BO_EjecutoDataTable(queryTipos);
            cbContratos.DisplayMember = "DETALLE";
            cbContratos.ValueMember = "ID";
        }

        public void comboProfesionales(string ESPECIALIDAD)
        {
            cbProfesionales.DataSource = null;
            string query = "SELECT P.ID, P.NOMBRE FROM PROFESIONALES P, PROF_ESP E WHERE E.ESPECIALIDAD = " + ESPECIALIDAD + " AND E.PROFESIONAL = P.ID AND P.BAJA IS NULL ORDER BY P.NOMBRE;";
            cbProfesionales.Items.Clear();
            cbProfesionales.SelectedItem = 0;
            cbProfesionales.DataSource = dlog.BO_EjecutoDataTable(query);
            cbProfesionales.DisplayMember = "NOMBRE";
            cbProfesionales.ValueMember = "ID";
        }

        public void comboAgregarProfesionales()
        {
            cbProfesionalAgregar.DataSource = null;
            string query = "SELECT ID, NOMBRE FROM PROFESIONALES WHERE BAJA IS NULL AND NOMBRE != 'EMPLEADOS CSPFA' ORDER BY NOMBRE;";
            cbProfesionalAgregar.Items.Clear();
            cbProfesionalAgregar.SelectedItem = 0;
            cbProfesionalAgregar.DataSource = dlog.BO_EjecutoDataTable(query);
            cbProfesionalAgregar.DisplayMember = "NOMBRE";
            cbProfesionalAgregar.ValueMember = "ID";
        }

        public void comboComprobantes()
        {
            cbComprobante.DataSource = null;
            string query = "SELECT ID, COMPROBANTE FROM COMPROBANTES;";
            cbComprobante.Items.Clear();
            cbComprobante.SelectedItem = 0;
            cbComprobante.DataSource = dlog.BO_EjecutoDataTable(query);
            cbComprobante.DisplayMember = "COMPROBANTE";
            cbComprobante.ValueMember = "ID";
        }

        public void comboProfesionalesBaja()
        {
            cbProfesionalesBaja.DataSource = null;
            string query = "SELECT ID, NOMBRE FROM PROFESIONALES WHERE BAJA IS NOT NULL AND NOMBRE != 'EMPLEADOS CSPFA' AND ROL = '"+VGlobales.vp_role+"' ORDER BY NOMBRE;";

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                cbProfesionalesBaja.Enabled = true;
                btnRestaurar.Enabled = true;
                cbProfesionalesBaja.Items.Clear();
                cbProfesionalesBaja.SelectedItem = 0;
                cbProfesionalesBaja.DataSource = dlog.BO_EjecutoDataTable(query);
                cbProfesionalesBaja.DisplayMember = "NOMBRE";
                cbProfesionalesBaja.ValueMember = "ID";
            }
            else
            {
                cbProfesionalesBaja.Enabled = false;
                btnRestaurar.Enabled = false;
            }
        }

        public void cleanForm()
        {
            tbNombre.Text = "";
            tbMatricula.Text = "0";
            tbDNI.Text = "0";
            cbEspecialidades.SelectedIndex = 0;
            tbCorreo.Text = "@";
            tbTelefono.Text = "0";
            tbCelular.Text = "0";
            cbContratos.SelectedIndex = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            /*existe ex = new existe();

            if (tbNombre.Text == "")
            {
                tbNombre.Focus();
                MessageBox.Show("El campo Nombre no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbDNI.Text == "")
            {
                tbDNI.Focus();
                MessageBox.Show("El campo DNI no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbCuenta.Text == "0")
            {
                tbCuenta.Focus();
                MessageBox.Show("El campo Cuenta no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    dlog.nuevoProfesional(
                        tbNombre.Text, 
                        tbMatricula.Text, 
                        int.Parse(string.Format("{0}", tbDNI.Text)), 
                        tbCorreo.Text, 
                        int.Parse(string.Format("{0}", tbTelefono.Text)), 
                        int.Parse(string.Format("{0}", tbCelular.Text)),
                        int.Parse(cbContratos.SelectedValue.ToString()),
                        VGlobales.vp_role,
                        cbComprobante.SelectedValue.ToString(),
                        int.Parse(tbCuenta.Text.ToString()));
                        
                    maxid mid = new maxid();
                    int ID = int.Parse(string.Format("{0}", mid.m("ID", "PROFESIONALES")));
                    dlog.nuevoProfEsp(ID, int.Parse(string.Format("{0}", cbEspecialidades.SelectedValue)));
                    //comboProfesionales();
                    MessageBox.Show("Registro creado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleanForm();
                }
                catch (Exception error)
                {
                    MessageBox.Show("No se pudo crear el registro\n" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }*/
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnLimpiar.Enabled = false;
            btnBaja.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Visible = false;
            btnEditar.Visible = true;
            ID = int.Parse(string.Format("{0}", cbProfesionales.SelectedValue));
            cambiarValores(ID);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cancelar la edición del registro?", "Cancelar Edición", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cleanForm();
                btnLimpiar.Enabled = true;
                btnBaja.Enabled = false;
                btnCancelar.Enabled = false;
                btnEditar.Visible = false;
                btnNuevo.Visible = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Confirma la modificación del registro?", "Confirmar Modificación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tbNombre.Text == "")
                {
                    tbNombre.Focus();
                    MessageBox.Show("El campo Nombre no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbMatricula.Text == "")
                {
                    tbMatricula.Focus();
                    MessageBox.Show("El campo Matricula no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbDNI.Text == "")
                {
                    tbDNI.Focus();
                    MessageBox.Show("El campo DNI no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbTelefono.Text == "")
                {
                    tbTelefono.Focus();
                    MessageBox.Show("El campo Telefono no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbCelular.Text == "")
                {
                    tbCelular.Focus();
                    MessageBox.Show("El campo Celular no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbCorreo.Text == "")
                {
                    tbCorreo.Focus();
                    MessageBox.Show("El campo Correo no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                { 
                    try
                    {
                        //dlog.modificarProfesional(ID, tbNombre.Text, tbMatricula.Text, int.Parse(string.Format("{0}", tbDNI.Text)), tbCorreo.Text, int.Parse(string.Format("{0}", tbTelefono.Text)), int.Parse(string.Format("{0}", tbCelular.Text)), int.Parse(cbContratos.SelectedValue.ToString()), cbComprobante.SelectedValue.ToString());
                        //dlog.modificarProfEsp(ID, int.Parse(string.Format("{0}", cbEspecialidades.SelectedValue)));
                        MessageBox.Show("Registro modificado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cleanForm();
                        btnEditar.Visible = false;
                        btnBaja.Enabled = false;
                        btnCancelar.Enabled = false;
                        btnNuevo.Visible = true;
                        btnLimpiar.Enabled = true;
                        //comboProfesionales();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("No se pudo modificar el registro\n" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Confirma la baja del registro?", "Baja", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dlog.bajaProfesional(ID, DateTime.Now.ToString());
                    MessageBox.Show("Baja realizada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //comboProfesionales();
                    comboProfesionalesBaja();
                    cleanForm();
                    btnBaja.Enabled = false;
                    btnCancelar.Enabled = false;
                }
                catch (Exception error)
                {
                    MessageBox.Show("No se pudo dar de baja el registro\n" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            int IDBAJA = int.Parse(string.Format("{0}", cbProfesionalesBaja.SelectedValue));

            if (MessageBox.Show("¿Confirma la restauración del registro?", "Restaurar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dlog.nuevaAltaProfesional(IDBAJA, null, DateTime.Now.ToString());
                    MessageBox.Show("Registro restaurado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //comboProfesionales();
                    comboProfesionalesBaja();
                }
                catch (Exception error)
                {
                    MessageBox.Show("No se pudo restaurar el registro\n" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Vaciar los campos?", "Limpiar Campos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cleanForm();
            }
        }

        private void cbEspecialidadMod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string ESPECIALIDAD = cbEspecialidadMod.SelectedValue.ToString();
            comboProfesionales(ESPECIALIDAD);
        }

        private void btAgregarProfesional_Click(object sender, EventArgs e)
        {
            //RENOMBRAR TABLA PROFE_ESPE > PROF_ESP
        }
    }
}
