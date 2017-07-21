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
    public partial class nuevoAbmAranceles : Form
    {
        bo dlog = new bo();
        BO.bo_Caja BO_CAJA = new BO.bo_Caja();

        public nuevoAbmAranceles()
        {
            InitializeComponent();
            comboGrupos();
            comboRolesSectAct();
            comboHabitacion();
            comboRegimen();
        }

        private void comboGrupos()
        {
            string query = "SELECT * FROM GRUPOS_S;";
            cbCategoriaSocial.DataSource = null;
            cbCategoriaSocial.Items.Clear();
            cbCategoriaSocial.DataSource = dlog.BO_EjecutoDataTable(query);
            cbCategoriaSocial.DisplayMember = "NOMBRE";
            cbCategoriaSocial.ValueMember = "ID";
            cbCategoriaSocial.SelectedItem = 0;
        }

        public void comboRolesSectAct()
        {
            cbRoles.DataSource = null;
            string query = "";

            if (VGlobales.vp_role == "CAJA" || VGlobales.vp_role == "CONTADURIA" || VGlobales.vp_role == "SISTEMAS")
                query = "SELECT TRIM(ROL) AS ROL FROM SECTACT WHERE ESTADO = 1 GROUP BY ROL ORDER BY ROL;";
            else if (VGlobales.vp_role == "TURISMO")
                query = "SELECT TRIM(ROL) AS ROL FROM SECTACT WHERE ESTADO = 1 AND ROL = 'HOTELES'  GROUP BY ROL ORDER BY ROL;";
            else
                query = "SELECT TRIM(ROL) AS ROL FROM SECTACT WHERE ESTADO = 1 AND ROL = '" + VGlobales.vp_role + "' GROUP BY ROL ORDER BY ROL;";

            cbRoles.Items.Clear();
            cbRoles.DataSource = dlog.BO_EjecutoDataTable(query);
            cbRoles.DisplayMember = "ROL";
            cbRoles.ValueMember = "ROL";
            cbRoles.SelectedIndex = -1;
        }

        public void comboHabitacion()
        {
            cbHabitacion.DataSource = null;
            string query = "SELECT ID, TRIM(TIPO) AS TIPO FROM HOTEL_HABITACION_TIPO TIPO ORDER BY TIPO ASC;";
            cbHabitacion.Items.Clear();
            cbHabitacion.DataSource = dlog.BO_EjecutoDataTable(query);
            cbHabitacion.DisplayMember = "TIPO";
            cbHabitacion.ValueMember = "ID";
            cbHabitacion.SelectedIndex = 0;
        }

        public void comboRegimen()
        {
            cbRegimen.DataSource = null;
            string query = "SELECT ID, TRIM(NOMBRE) AS NOMBRE FROM TURISMO_REGIMEN WHERE F_BAJA IS NULL ORDER BY NOMBRE ASC;";
            cbRegimen.Items.Clear();
            cbRegimen.DataSource = dlog.BO_EjecutoDataTable(query);
            cbRegimen.DisplayMember = "NOMBRE";
            cbRegimen.ValueMember = "ID";
            cbRegimen.SelectedIndex = 0;
        }

        public void comboSectAct(string ROL)
        {
            cbSectAct.DataSource = null;
            string query = "SELECT ID, TRIM(LEADING FROM DETALLE) AS DETALLE FROM SECTACT WHERE ROL = '" + ROL + "' AND ESTADO = 1 ORDER BY DETALLE;";
            cbSectAct.Items.Clear();
            cbSectAct.DataSource = dlog.BO_EjecutoDataTable(query);
            cbSectAct.DisplayMember = "DETALLE";
            cbSectAct.ValueMember = "ID";
            cbSectAct.SelectedIndex = -1;
        }

        public void comboProfesionales(string SECTACT)
        {
            cbProf.DataSource = null;
            string query = "SELECT P.ID, P.NOMBRE FROM PROFESIONALES P, PROF_ESP PE WHERE P.ID = PE.PROFESIONAL AND PE.ESPECIALIDAD = " + SECTACT + " AND P.BAJA IS NULL ORDER BY P.NOMBRE ASC;";
            cbProf.Items.Clear();
            cbProf.DataSource = dlog.BO_EjecutoDataTable(query);
            cbProf.DisplayMember = "NOMBRE";
            cbProf.ValueMember = "ID";
            cbProf.SelectedIndex = -1;
        }

        private void cbRoles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboSectAct(cbRoles.SelectedValue.ToString());
            cbProf.DataSource = null;
        }

        private void cbSectAct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboProfesionales(cbSectAct.SelectedValue.ToString());
            string SECTACT = cbSectAct.SelectedValue.ToString();

            switch (SECTACT)
            {
                case "395":
                    tbSocioEmpleado.Visible = true;
                    lbSocioEmpleado.Visible = true;
                    break;
                
                case "160":
                    tbSocioEmpleado.Visible = true;
                    lbSocioEmpleado.Visible = true;
                    break;

                case "165":
                    tbSocioInvitado.Visible = true;
                    lbSocioInvitado.Visible = true;
                    break;

                case "166":
                    tbSocioInvitado.Visible = true;
                    lbSocioInvitado.Visible = true;
                    break;

                default:
                    tbSocioEmpleado.Visible = false;
                    lbSocioEmpleado.Visible = false;
                    tbSocioInvitado.Visible = false;
                    lbSocioInvitado.Visible = false;
                    break;
            }

            if (cbRoles.Text == "HOTELES")
            {
                lbHabitacion.Enabled = true;
                cbHabitacion.Enabled = true;
                lbRegimen.Enabled = true;
                cbRegimen.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbRoles.Text == "")
            {
                MessageBox.Show("SELECCIONAR UN ROL");
            }
            else if (cbSectAct.Text == "")
            {
                MessageBox.Show("SELECCIONAR UN SECTOR / ACTIVIDAD");
            }
            else if (cbProf.Text == "")
            {
                MessageBox.Show("SELECCIONAR UN PROFESIONAL");
            }
            else if (tbArancel.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO ARANCEL");
            }
            else if (cbSectAct.SelectedValue.ToString() == "160" && tbSocioEmpleado.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO SOCIO EMPLEADO");
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                int GRUPO = Convert.ToInt16(cbCategoriaSocial.SelectedValue);
                int SECTACT = Convert.ToInt16(cbSectAct.SelectedValue);
                int PROFESIONAL = Convert.ToInt16(cbProf.SelectedValue);
                decimal ARANCEL = Convert.ToDecimal(tbArancel.Text.Trim());
                string US_ALTA = VGlobales.vp_username;
                DateTime Hoy = DateTime.Today;
                string FE_ALTA = Hoy.ToString("dd/MM/yyyy");
                string connectionString;
                Datos_ini ini2 = new Datos_ini();
                int REGIMEN = 0;
                int HABITACION = 0;

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
                        connection.Open();
                        FbTransaction transaction = connection.BeginTransaction();
                        DataSet ds = new DataSet();
                        string query = "SELECT CAT_SOC FROM GRUPOS_CATEGORIAS WHERE GRUPO = " + GRUPO + " ORDER BY CAT_SOC ASC";
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
                                foreach (DataRow row in ds.Tables[0].Rows)
                                {
                                    string CATSOC = row[0].ToString();

                                    if (cbRoles.SelectedValue.ToString() == "SSADPADUA" && cbSectAct.SelectedValue.ToString() == "395" && CATSOC == "002")
                                    {
                                        BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL / 2, US_ALTA, FE_ALTA, 0, 0);
                                    }
                                    else if (cbRoles.SelectedValue.ToString() == "SSADPADUA" && cbSectAct.SelectedValue.ToString() == "395" && CATSOC == "003")
                                    {
                                        BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL / 2, US_ALTA, FE_ALTA, 0, 0);
                                    }
                                    else if (cbRoles.SelectedValue.ToString() == "SSADPADUA" && cbSectAct.SelectedValue.ToString() == "395" && CATSOC == "004")
                                    {
                                        BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL / 4, US_ALTA, FE_ALTA, 0, 0);
                                    }
                                    else if (cbRoles.SelectedValue.ToString() == "SSADPADUA" && cbSectAct.SelectedValue.ToString() == "395" && CATSOC == "007")
                                    {
                                        decimal ARANCEL_EMPLEADO = Convert.ToDecimal(tbSocioEmpleado.Text);
                                        BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL_EMPLEADO, US_ALTA, FE_ALTA, 0, 0);
                                    }
                                    else if (cbRoles.SelectedValue.ToString() == "PROSECRETARIA" && cbSectAct.SelectedValue.ToString() == "160" && CATSOC == "002")
                                    {
                                        BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL / 2, US_ALTA, FE_ALTA, 0, 0);
                                    }
                                    else if (cbRoles.SelectedValue.ToString() == "PROSECRETARIA" && cbSectAct.SelectedValue.ToString() == "160" && CATSOC == "003")
                                    {
                                        BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL / 2, US_ALTA, FE_ALTA, 0, 0);
                                    }
                                    else if (cbRoles.SelectedValue.ToString() == "PROSECRETARIA" && cbSectAct.SelectedValue.ToString() == "160" && CATSOC == "004")
                                    {
                                        BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL / 4, US_ALTA, FE_ALTA, 0, 0);
                                    }
                                    else if (cbRoles.SelectedValue.ToString() == "PROSECRETARIA" && cbSectAct.SelectedValue.ToString() == "160" && CATSOC == "007")
                                    {
                                        decimal ARANCEL_EMPLEADO = Convert.ToDecimal(tbSocioEmpleado.Text);
                                        BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL_EMPLEADO, US_ALTA, FE_ALTA, 0, 0);
                                    }
                                    else if (cbRoles.SelectedValue.ToString() == "DEPORTES" && cbSectAct.SelectedValue.ToString() == "165" && CATSOC == "006")
                                    {
                                        decimal ARANCEL_INVITADO = Convert.ToDecimal(tbSocioInvitado.Text);
                                        BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL_INVITADO, US_ALTA, FE_ALTA, 0, 0);
                                    }
                                    else if (cbRoles.SelectedValue.ToString() == "DEPORTES" && cbSectAct.SelectedValue.ToString() == "166" && CATSOC == "006")
                                    {
                                        decimal ARANCEL_INVITADO = Convert.ToDecimal(tbSocioInvitado.Text);
                                        BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL_INVITADO, US_ALTA, FE_ALTA, 0, 0);
                                    }
                                    else
                                    {
                                        REGIMEN = int.Parse(cbRegimen.SelectedValue.ToString());
                                        HABITACION = int.Parse(cbHabitacion.SelectedValue.ToString());
                                        BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL, US_ALTA, FE_ALTA, REGIMEN, HABITACION);
                                    }
                                }
                            }
                        }

                        transaction.Commit();
                        connection.Close();
                        cmd = null;
                        transaction = null;
                    }

                    MessageBox.Show("SE GUARDO EL ARANCEL");
                    button1.Enabled = false;
                    Cursor = Cursors.Default;
                    
                    string ROLLING = cbRoles.Text;

                    if (ROLLING == "HOTELES")
                        buscarAranceles(SECTACT, PROFESIONAL, GRUPO, "NO", REGIMEN, HABITACION);
                    else
                        buscarAranceles(SECTACT, PROFESIONAL, GRUPO, "NO", 0, 0);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO SE PUDO GUARDAR EL ARANCEL\n" + ex);
                }
            }
        }

        private void buscarAranceles(int SECTACT, int PROFESIONAL, int GRUPO, string BAJA, int REGIMEN, int HABITACION)
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
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string query;
                    string ROLLING = cbRoles.Text;

                    if (BAJA == "NO")
                        query = "SELECT * FROM ARANCELES_S (" + GRUPO + ", " + SECTACT + ", " + PROFESIONAL + ", '" + ROLLING + "', " + REGIMEN + ", " + HABITACION + ") WHERE FE_BAJA IS NULL;";
                    else
                        query = "SELECT * FROM ARANCELES_S (" + GRUPO + ", " + SECTACT + ", " + PROFESIONAL + ", '" + ROLLING + "', " + REGIMEN + ", " + HABITACION + ") WHERE FE_BAJA IS NOT NULL;";

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
                            if (BAJA == "NO")
                                mostrarAranceles(ds, "NO");
                            else
                                mostrarAranceles(ds, "SI");

                            bloquear();
                            btnModificar.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("NO SE ENCONTRARON REGISTROS CON LA CONDICION INDICADA");
                            button1.Enabled = true;
                            desbloquear();
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

        private void mostrarAranceles(DataSet ds, string BAJA)
        {
            dgAranceles.Rows.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string GRUPO_ID = row[0].ToString();
                string SECTACT_ID = row[1].ToString();
                string PROFESIONAL_ID = row[2].ToString();
                string NOMBRE_GRUPO = row[3].ToString().Trim();
                string CATSOC = row[4].ToString().Trim();
                string NOMBRE_ROL = row[5].ToString().Trim();
                string NOMBRE_SECTACT = row[6].ToString().Trim();
                string NOMBRE_PROF = row[7].ToString().Trim();
                decimal ARANCEL = Convert.ToDecimal(row[8].ToString());
                string ARANCEL_NUM = String.Format("{0:n}", ARANCEL);
                string ARANCEL_ID = row[9].ToString();
                string FE_BAJA = row[10].ToString().Replace("0:00:00", "");
                string REGIMEN = row[11].ToString().Trim();
                string HABITACION = row[12].ToString().Trim();
                dgAranceles.Rows.Add(GRUPO_ID, SECTACT_ID, PROFESIONAL_ID, NOMBRE_GRUPO, CATSOC, NOMBRE_ROL, NOMBRE_SECTACT, NOMBRE_PROF, ARANCEL_NUM, ARANCEL_ID, FE_BAJA, REGIMEN, HABITACION);
            }

            dgAranceles.ClearSelection();
        }

        private void bloquear()
        {
            cbCategoriaSocial.Enabled = false;
            cbRoles.Enabled = false;
            cbSectAct.Enabled = false;
            cbProf.Enabled = false;
            cbRegimen.Enabled = false;
            cbHabitacion.Enabled = false;
        }

        private void desbloquear()
        {
            cbCategoriaSocial.Enabled = true;
            cbRoles.Enabled = true;
            cbSectAct.Enabled = true;
            cbProf.Enabled = true;
            tbArancel.Enabled = true;
            //cbRegimen.Enabled = false;
            //cbHabitacion.Enabled = false;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            int GRUPO = Convert.ToInt16(cbCategoriaSocial.SelectedValue);
            int SECTACT = Convert.ToInt16(cbSectAct.SelectedValue);
            int PROFESIONAL = Convert.ToInt16(cbProf.SelectedValue);
            int REGIMEN = int.Parse(cbRegimen.SelectedValue.ToString());
            int HABITACION = int.Parse(cbHabitacion.SelectedValue.ToString());
            string ROLLING = cbRoles.Text;
            
            if (ROLLING == "HOTELES")
                buscarAranceles(SECTACT, PROFESIONAL, GRUPO, "NO", REGIMEN, HABITACION);
            else
                buscarAranceles(SECTACT, PROFESIONAL, GRUPO, "NO", 0, 0);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            desbloquear();
            limpiarForm();
            limpiarDgv();
            btnModificar.Enabled = false;
        }

        private void limpiarForm()
        {
            cbCategoriaSocial.SelectedIndex = 0;
            cbRoles.SelectedIndex = -1;
            cbProf.DataSource = null;
            cbProf.Items.Clear();
            cbSectAct.DataSource = null;
            cbSectAct.Items.Clear();
            tbArancel.Text = "0";
            tbSocioEmpleado.Visible = false;
            lbSocioEmpleado.Visible = false;
            tbSocioEmpleado.Text = "0";
            tbSocioInvitado.Text = "0";
            tbSocioInvitado.Visible = false;
            lbSocioInvitado.Visible = false;
        }

        private void limpiarDgv()
        {
            dgAranceles.Rows.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿MODIFICAR LOS ARANCELES SELECCIONADOS?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tbArancel.Text == "")
                {
                    MessageBox.Show("COMPLETAR EL CAMPO ARANCEL");
                }
                else if (cbSectAct.SelectedValue.ToString() == "160" && tbSocioEmpleado.Text == "")
                {
                    MessageBox.Show("COMPLETAR EL CAMPO SOCIO EMPLEADO");
                }
                else if ((cbSectAct.SelectedValue.ToString() == "165" || cbSectAct.SelectedValue.ToString() == "166") && tbSocioInvitado.Text == "")
                {
                    MessageBox.Show("COMPLETAR EL CAMPO SOCIO INVITADO");
                }
                else
                {
                    Cursor = Cursors.WaitCursor;
                    int GRUPO = Convert.ToInt16(cbCategoriaSocial.SelectedValue);
                    int SECTACT = Convert.ToInt16(cbSectAct.SelectedValue);
                    int PROFESIONAL = Convert.ToInt16(cbProf.SelectedValue);
                    decimal ARANCEL = Convert.ToDecimal(tbArancel.Text.Trim());
                    string US_MOD = VGlobales.vp_username;
                    DateTime Hoy = DateTime.Today;
                    string FE_MOD = Hoy.ToString("dd/MM/yyyy");
                    string FE_BAJA = Hoy.ToString("dd/MM/yyyy");
                    string connectionString;
                    Datos_ini ini2 = new Datos_ini();
                    int REGIMEN = 0;
                    int HABITACION = 0;

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
                            connection.Open();
                            FbTransaction transaction = connection.BeginTransaction();
                            DataSet ds = new DataSet();
                            string query = "SELECT CAT_SOC FROM GRUPOS_CATEGORIAS WHERE GRUPO = " + GRUPO + " ORDER BY CAT_SOC ASC";
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
                                    foreach (DataRow row in ds.Tables[0].Rows)
                                    {
                                        string CATSOC = row[0].ToString();

                                        BO_CAJA.bajaArancelesNuevos(SECTACT, CATSOC, PROFESIONAL, FE_BAJA);

                                        if (cbRoles.SelectedValue.ToString() == "SSADPADUA" && cbSectAct.SelectedValue.ToString() == "395" && CATSOC == "002")
                                        {
                                            BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL / 2, US_MOD, FE_MOD, 0, 0);
                                        }
                                        else if (cbRoles.SelectedValue.ToString() == "SSADPADUA" && cbSectAct.SelectedValue.ToString() == "395" && CATSOC == "003")
                                        {
                                            BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL / 2, US_MOD, FE_MOD, 0, 0);
                                        }
                                        else if (cbRoles.SelectedValue.ToString() == "SSADPADUA" && cbSectAct.SelectedValue.ToString() == "395" && CATSOC == "004")
                                        {
                                            BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL / 4, US_MOD, FE_MOD, 0, 0);
                                        }
                                        else if (cbRoles.SelectedValue.ToString() == "SSADPADUA" && cbSectAct.SelectedValue.ToString() == "395" && CATSOC == "007")
                                        {
                                            decimal ARANCEL_EMPLEADO = Convert.ToDecimal(tbSocioEmpleado.Text);
                                            BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL_EMPLEADO, US_MOD, FE_MOD, 0, 0);
                                        }
                                        else if (cbRoles.SelectedValue.ToString() == "PROSECRETARIA" && cbSectAct.SelectedValue.ToString() == "160" && CATSOC == "002")
                                        {
                                            BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL / 2, US_MOD, FE_MOD, 0, 0);
                                        }
                                        else if (cbRoles.SelectedValue.ToString() == "PROSECRETARIA" && cbSectAct.SelectedValue.ToString() == "160" && CATSOC == "003")
                                        {
                                            BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL / 2, US_MOD, FE_MOD, 0, 0);
                                        }
                                        else if (cbRoles.SelectedValue.ToString() == "PROSECRETARIA" && cbSectAct.SelectedValue.ToString() == "160" && CATSOC == "004")
                                        {
                                            BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL / 4, US_MOD, FE_MOD, 0, 0);
                                        }
                                        else if (cbRoles.SelectedValue.ToString() == "PROSECRETARIA" && cbSectAct.SelectedValue.ToString() == "160" && CATSOC == "007")
                                        {
                                            decimal ARANCEL_EMPLEADO = Convert.ToDecimal(tbSocioEmpleado.Text);
                                            BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL_EMPLEADO, US_MOD, FE_MOD, 0, 0);
                                        }
                                        else if (cbRoles.SelectedValue.ToString() == "DEPORTES" && cbSectAct.SelectedValue.ToString() == "165" && CATSOC == "006")
                                        {
                                            decimal ARANCEL_INVITADO = Convert.ToDecimal(tbSocioInvitado.Text);
                                            BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL_INVITADO, US_MOD, FE_MOD, 0, 0);
                                        }
                                        else if (cbRoles.SelectedValue.ToString() == "DEPORTES" && cbSectAct.SelectedValue.ToString() == "166" && CATSOC == "006")
                                        {
                                            decimal ARANCEL_INVITADO = Convert.ToDecimal(tbSocioInvitado.Text);
                                            BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL_INVITADO, US_MOD, FE_MOD, 0, 0);
                                        }
                                        else
                                        {
                                            REGIMEN = int.Parse(cbRegimen.SelectedValue.ToString());
                                            HABITACION = int.Parse(cbHabitacion.SelectedValue.ToString());
                                            BO_CAJA.agregarArancel(SECTACT, CATSOC, PROFESIONAL, ARANCEL, US_MOD, FE_MOD, REGIMEN, HABITACION);
                                        }
                                    }
                                }
                            }

                            transaction.Commit();
                            connection.Close();
                            cmd = null;
                            transaction = null;
                        }

                        MessageBox.Show("SE MODIFICARON LOS ARANCELES");
                        Cursor = Cursors.Default;

                        string ROLLING = cbRoles.Text;

                        if (ROLLING == "HOTELES")
                            buscarAranceles(SECTACT, PROFESIONAL, GRUPO, "NO", REGIMEN, HABITACION);
                        else
                            buscarAranceles(SECTACT, PROFESIONAL, GRUPO, "NO", 0, 0);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("NO SE PUDIERON MODIFICAR LOS ARANCELES\n" + ex);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int GRUPO = Convert.ToInt16(cbCategoriaSocial.SelectedValue);
            int SECTACT = Convert.ToInt16(cbSectAct.SelectedValue);
            int PROFESIONAL = Convert.ToInt16(cbProf.SelectedValue);
            int REGIMEN = int.Parse(cbRegimen.SelectedValue.ToString());
            int HABITACION = int.Parse(cbHabitacion.SelectedValue.ToString());
            string ROLLING = cbRoles.Text;

            if (ROLLING == "HOTELES")
                buscarAranceles(SECTACT, PROFESIONAL, GRUPO, "NO", REGIMEN, HABITACION);
            else
                buscarAranceles(SECTACT, PROFESIONAL, GRUPO, "NO", 0, 0);
        }
    }
}
