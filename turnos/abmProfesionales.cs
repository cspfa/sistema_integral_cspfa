using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS
{
    public partial class abmProfesionales :  Form
    {
        bo dlog = new bo();

        private DataTable RESULTADOS { get; set; }

        public abmProfesionales(int ID_ITEM)
        {
            InitializeComponent();
        }

        private void cargaInicial()
        {
            comboFiltroRoles();
            comboContratos();
            comboComprobantes();
            comboEspecialidades();
            comboRoles();
            comboRolesNuevo();
            string ROL = cbFiltroRoles.SelectedValue.ToString().Trim();
            comboDetalle(ROL);
            buscarProfesionales("XXX", 0);
        }

        public void comboProfesionales()
        {
            cbProfesionales.DataSource = null;
            string query = "SELECT ID, NOMBRE FROM PROFESIONALES WHERE BAJA IS NULL ORDER BY NOMBRE;";
            cbProfesionales.Items.Clear();
            cbProfesionales.SelectedItem = 0;
            cbProfesionales.DataSource = dlog.BO_EjecutoDataTable(query);
            cbProfesionales.DisplayMember = "NOMBRE";
            cbProfesionales.ValueMember = "ID";
        }

        public void comboDetalle(string ROL)
        {
            cbDetalle.DataSource = null;
            string query = "SELECT ID, DETALLE AS DETALLE FROM SECTACT WHERE ESTADO = 1 AND ROL = '" + ROL + "' ORDER BY ROL, DETALLE;";
            cbDetalle.Items.Clear();
            cbDetalle.SelectedItem = 0;
            cbDetalle.DataSource = dlog.BO_EjecutoDataTable(query);
            cbDetalle.DisplayMember = "DETALLE";
            cbDetalle.ValueMember = "DETALLE";
        }

        public void comboEspecialidades()
        {
            cbEspecialidades.DataSource = null;
            string query = "SELECT ID, TRIM(ROL)||' - '||TRIM(DETALLE) AS DETALLE FROM SECTACT WHERE ESTADO = 1 ORDER BY ROL, DETALLE;";
            cbEspecialidades.Items.Clear();
            cbEspecialidades.SelectedItem = 0;
            cbEspecialidades.DataSource = dlog.BO_EjecutoDataTable(query);
            cbEspecialidades.DisplayMember = "DETALLE";
            cbEspecialidades.ValueMember = "ID";
        }

        public void comboEspecNuevo(string ROL)
        {
            cbEspec.DataSource = null;
            string query = "SELECT ID, TRIM(DETALLE) AS DETALLE FROM SECTACT WHERE ESTADO = 1 AND ROL = '" + ROL + "' ORDER BY DETALLE;";
            cbEspec.Items.Clear();
            cbEspec.SelectedItem = 0;
            cbEspec.DataSource = dlog.BO_EjecutoDataTable(query);
            cbEspec.DisplayMember = "DETALLE";
            cbEspec.ValueMember = "ID";
        }

        public void comboProfesionales(string ROL)
        {
            cbProfesionales.DataSource = null;
            string query = "SELECT P.ID, TRIM(P.NOMBRE) AS NOMBRE FROM PROFESIONALES P, PROF_ESP S, SECTACT E WHERE P.BAJA IS NULL AND P.ID = S.PROFESIONAL AND E.ROL = '" + ROL + "' AND E.ID = S.ESPECIALIDAD ORDER BY P.NOMBRE";
            cbProfesionales.Items.Clear();
            cbProfesionales.SelectedItem = 0;
            cbProfesionales.DataSource = dlog.BO_EjecutoDataTable(query);
            cbProfesionales.DisplayMember = "NOMBRE";
            cbProfesionales.ValueMember = "ID";
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

        private void comboFiltroRoles()
        {
            cbFiltroRoles.DataSource = null;
            string queryTipos = "SELECT DISTINCT ROL FROM SECTACT;";
            cbFiltroRoles.Items.Clear();
            cbFiltroRoles.SelectedItem = 0;
            cbFiltroRoles.DataSource = dlog.BO_EjecutoDataTable(queryTipos);
            cbFiltroRoles.DisplayMember = "ROL";
            cbFiltroRoles.ValueMember = "ROL";
        }

        private void comboRolesNuevo()
        {
            cbRolesNuevo.DataSource = null;
            string queryTipos = "SELECT DISTINCT ROL FROM SECTACT;";
            cbRolesNuevo.Items.Clear();
            cbRolesNuevo.SelectedItem = 0;
            cbRolesNuevo.DataSource = dlog.BO_EjecutoDataTable(queryTipos);
            cbRolesNuevo.DisplayMember = "ROL";
            cbRolesNuevo.ValueMember = "ROL";
        }

        private void comboRoles()
        {
            cbRoles.DataSource = null;
            string queryTipos = "SELECT DISTINCT ROL FROM SECTACT;";
            cbRoles.Items.Clear();
            cbRoles.SelectedItem = 0;
            cbRoles.DataSource = dlog.BO_EjecutoDataTable(queryTipos);
            cbRoles.DisplayMember = "ROL";
            cbRoles.ValueMember = "ROL";
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
        
        private void mostrarProfesionales(DataSet ds)
        {
            dgProfesionales.Rows.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string ID = row[0].ToString();
                string NOMBRE = row[1].ToString().Trim();
                string MATRICULA = row[2].ToString();
                string DNI = row[3].ToString();
                string ALTA = row[4].ToString();
                string BAJA = row[5].ToString();
                string CORREO = row[6].ToString();
                string CELULAR = row[7].ToString();
                string TELEFONO = row[8].ToString();
                string NUEVA_ALTA = row[9].ToString();
                string TIPO_CONTRATO = row[16].ToString().Trim();
                string ROL = row[11].ToString();
                string BONO_RECIBO = row[12].ToString();
                string CUENTA = row[13].ToString();
                string DETALLE = row[14].ToString().Trim();
                string ROOOL = row[15].ToString().Trim();
                string ESPECIALIDAD = row[17].ToString().Trim();
                dgProfesionales.Rows.Add(ROOOL, DETALLE, NOMBRE, TIPO_CONTRATO, BONO_RECIBO, CUENTA, ID, ESPECIALIDAD);
            }

            dgProfesionales.ClearSelection();
        }

        private void limpiarFormulario()
        {
            tbNombre.Text = "";
            tbMatricula.Text = "0";
            tbDNI.Text = "0";
            cbEspecialidades.SelectedIndex = 0;
            tbCorreo.Text = "@";
            tbTelefono.Text = "0";
            tbCelular.Text = "0";
            cbContratos.SelectedIndex = 0;
            tbCuenta.Text = "0";
            lbIdProf.Text = "0";
        }

        private void cargarProfesional(DataSet ds)
        {
            limpiarFormulario();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lbIdProf.Text = row[0].ToString().Trim();
                tbNombre.Text = row[1].ToString().Trim();
                tbMatricula.Text = row[2].ToString();
                tbDNI.Text = row[3].ToString();
                cbEspecialidades.SelectedValue = Convert.ToInt16(row[17]);
                tbCorreo.Text = row[6].ToString();
                tbTelefono.Text = row[8].ToString();
                tbCelular.Text = row[7].ToString();
                cbContratos.SelectedValue = Convert.ToInt16(row[10]);
                cbComprobante.SelectedValue = row[12].ToString();
                string STOCKEABLE = row[18].ToString();

                if (STOCKEABLE.Trim() == "true")
                    cbStockeable.Checked = true;
                else
                    cbStockeable.Checked = false;
            }
        }

        private void buscarProfesionales(string ROL, int ID)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini2.Servidor;  cs.Port = int.Parse(ini2.Puerto);
                cs.Database = ini2.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    string DETALLE = cbDetalle.SelectedValue.ToString().Trim();
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string query = "SELECT * FROM PROFESIONALES_S;";

                    if (ROL != "XXX")
                    {
                        query = "SELECT * FROM PROFESIONALES_S WHERE ROOOL = '" + ROL.Trim() + "' AND DETALLE = '" + DETALLE + "';";
                    }

                    if (ID != 0)
                    {
                        query = "SELECT * FROM PROFESIONALES_S WHERE ID = " + ID + ";";
                    }

                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (ID != 0)
                            {
                                cargarProfesional(ds);
                            }
                            else
                            {
                                mostrarProfesionales(ds);
                            }
                        }
                        else
                        {
                            MessageBox.Show("NO SE ENCONTRARON REGISTROS CON LA CONDICION INDICADA");
                        }
                    }

                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ROL = cbFiltroRoles.SelectedValue.ToString();
            buscarProfesionales(ROL, 0);
        }

        private void dgProfesionales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btModificar.Enabled = true;
            button2.Enabled = true;
            int ID = Convert.ToInt16(dgProfesionales.SelectedCells[6].Value);
            buscarProfesionales("XXX", ID);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void button2_Click(object sender, EventArgs e) //ELIMINAR
        {
            if (MessageBox.Show("¿CONFIRMA ELIMINAR EL PROFESIONAL?", "CONFIRMAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int ID = int.Parse(lbIdProf.Text);
                    DateTime Hoy = DateTime.Today;
                    string BAJA = Hoy.ToString("dd/MM/yyyy");
                    dlog.bajaProfesional(ID, BAJA);
                    MessageBox.Show("PROFESIONAL ELIMINADO CORRECTAMENTE", "LISTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buscarProfesionales("XXX", 0);
                    limpiarFormulario();
                    btModificar.Enabled = false;
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO ELIMINAR EL PROFESIONAL\n" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buscarProfesionales("XXX", 0);
                    limpiarFormulario();
                    btModificar.Enabled = false;
                    button2.Enabled = false;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e) //NUEVO
        {
            if (tbNombre.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO NOMBRE Y APELLIDO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string NOMBRE = tbNombre.Text.Trim();
                    string MATRICULA = tbMatricula.Text.Trim();
                    int DNI = int.Parse(tbDNI.Text.Trim());
                    string CORREO = tbCorreo.Text.Trim();
                    int TELEFONO = int.Parse(tbTelefono.Text.Trim());
                    int CELULAR = int.Parse(tbCelular.Text.Trim());
                    int TIPO_CONTRATO = int.Parse(cbContratos.SelectedValue.ToString());
                    string COMPROBANTE = cbComprobante.SelectedValue.ToString();
                    int CUENTA = int.Parse(tbCuenta.Text.Trim());
                    int ESPECIALIDAD = int.Parse(cbEspecialidades.SelectedValue.ToString());
                    string ROL = cbEspecialidades.Text;
                    string[] ROL_SPLITED = ROL.Split('-');
                    string ROL_FINAL = ROL_SPLITED[0].Trim();
                    string STOCKEABLE = "false";

                    if (cbStockeable.Checked)
                        STOCKEABLE = "true";
                    else
                        STOCKEABLE = "false";

                    dlog.nuevoProfesional(NOMBRE, MATRICULA, DNI, CORREO, TELEFONO, CELULAR, TIPO_CONTRATO, ROL_FINAL, COMPROBANTE, CUENTA, STOCKEABLE);
                    maxid maxid = new maxid();
                    int ID = int.Parse(maxid.m("ID", "PROFESIONALES"));
                    dlog.nuevoProfEsp(ID, ESPECIALIDAD);
                    MessageBox.Show("NUEVO PROFESIONAL AGREGADO CORRECTAMENTE", "LISTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //buscarProfesionales("XXX", 0);
                    //limpiarFormulario();
                    btModificar.Enabled = false;
                    button2.Enabled = false;
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO AGREGAR EL NUEVO PROFESIONAL\n" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //buscarProfesionales("XXX", 0);
                    //limpiarFormulario();
                    btModificar.Enabled = false;
                    button2.Enabled = false;
                }
            }
        }

        private void btModificar_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA LA MODIFICACIÓN DEL PROFESIONAL?", "CONFIRMAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int ID = int.Parse(lbIdProf.Text);
                    string NOMBRE = tbNombre.Text.Trim();
                    string MATRICULA = tbMatricula.Text.Trim();
                    int DNI = int.Parse(tbDNI.Text.Trim());
                    string CORREO = tbCorreo.Text.Trim();
                    int TELEFONO = int.Parse(tbTelefono.Text.Trim());
                    int CELULAR = int.Parse(tbCelular.Text.Trim());
                    int TIPO_CONTRATO = int.Parse(cbContratos.SelectedValue.ToString());
                    string COMPROBANTE = cbComprobante.SelectedValue.ToString();
                    string CUENTA = tbCuenta.Text.Trim();
                    int ESPECIALIDAD = int.Parse(cbEspecialidades.SelectedValue.ToString());
                    string STOCKEABLE = "false";

                    if (cbStockeable.Checked)
                        STOCKEABLE = "true";
                    else
                        STOCKEABLE = "false";

                    dlog.modificarProfesional(ID, NOMBRE, MATRICULA, DNI, CORREO, TELEFONO, CELULAR, TIPO_CONTRATO, COMPROBANTE, CUENTA, STOCKEABLE);
                    dlog.modificarProfEsp(ID, ESPECIALIDAD);
                    MessageBox.Show("PROFESIONAL MODIFICADO CORRECTAMENTE", "LISTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string ROL = cbFiltroRoles.SelectedValue.ToString();
                    buscarProfesionales(ROL, 0);
                    limpiarFormulario();
                    btModificar.Enabled = false;
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO MODIFICAR EL PROFESIONAL\n" + error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buscarProfesionales("XXX", 0);
                    limpiarFormulario();
                    btModificar.Enabled = false;
                }
            }
        }

        private void cbRoles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string ROL = cbRoles.Text.Trim();
            comboProfesionales(ROL);
        }

        private void cbRolesNuevo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string ROL = cbRolesNuevo.Text.Trim();
            comboEspecNuevo(ROL);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                bo dlog = new bo();
                int PROF = int.Parse(cbProfesionales.SelectedValue.ToString());
                int ESP = int.Parse(cbEspec.SelectedValue.ToString());
                dlog.nuevoProfEsp(PROF, ESP);
                MessageBox.Show("PROFESIONAL ASIGNADO", "LISTO!");            
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO ASIGNAR EL PROFESIONAL\n" + error, "ERROR");            
            }
        }

        private void cbFiltroRoles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string ROL = cbFiltroRoles.SelectedValue.ToString().Trim();
            comboDetalle(ROL);
        }

        private void abmProfesionales_Load(object sender, EventArgs e)
        {
            cargaInicial();
        }
    }
}
