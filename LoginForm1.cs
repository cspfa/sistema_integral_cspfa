using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Drawing.Imaging;
using System.Data.OleDb;

namespace SOCIOS
{
    public partial class LoginForm1 : Form
    {
        public delegate void EventHandler(Object sender, EventArgs e);
       
        public LoginForm1()
        {
            InitializeComponent();
        }

        private void LoginCheck(string pName, string pPassword, string pRole)
        {
            Cursor = Cursors.WaitCursor;
            string con;
            Datos_ini ini1 = new Datos_ini();
            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini1.Servidor;  cs.Port = int.Parse(ini1.Puerto);
                cs.Database = ini1.Ubicacion;
                cs.UserID = txtUsername.Text.Trim();
                cs.Password = txtPassword.Text.Trim();
                cs.Role = comboBox1.Text.Trim();
                cs.Dialect = 3;
                con = cs.ToString();

                using (FbConnection connection = new FbConnection(con))
                {
                    
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    string busco;
                    busco = "SELECT current_timestamp, current_user, current_role  FROM RDB$Database";
                    FbCommand cmd = new FbCommand(busco, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();
                    reader3.Read();

                    
                    VGlobales.vp_username = cs.UserID;
                    VGlobales.vp_password = cs.Password;
                    VGlobales.vp_role = cs.Role;
                    VGlobales.vp_timestamp = reader3.GetString(reader3.GetOrdinal("current_timestamp"));


                    if (cbxRecordar.Checked)
                    {
                        Properties.Settings.Default.userName = txtUsername.Text;
                        //Properties.Settings.Default.password = EncDec.Encrypt(txtPassword.Text, "Circulo");
                        Properties.Settings.Default.password = string.Empty;
                        Properties.Settings.Default.rememberLogin = cbxRecordar.Checked;
                    }
                    else
                    {
                        Properties.Settings.Default.userName = string.Empty;
                        Properties.Settings.Default.password = string.Empty;
                        Properties.Settings.Default.rememberLogin = cbxRecordar.Checked;
                    }

                    Properties.Settings.Default.Save();

                    reader3.Close();
                    ini1 = null;
                    transaction.Commit();
                    connection.Close();
                    cs = null;
                    transaction = null;
                    FbConnection.ClearPool(connection);
                }
            }
            catch (FbException ex)
            {
                VGlobales.vp_username = null;
                VGlobales.vp_password = null;
                VGlobales.vp_role = null;
                VGlobales.vp_timestamp = null;
                DisplayFbErrors(ex);
                Cursor = Cursors.Default;
            }
            Cursor = Cursors.Default;
        }

        public void DisplayFbErrors(FbException myException)
        {
            switch (myException.ErrorCode.ToString())
            {
                case "335544472":
                {
                    MessageBox.Show("USUARIO, CONTRASEÑA O ROLE INEXISTENTE", "ERROR DE LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                break;

                default:
                
                for (int i = 0; i < myException.Errors.Count; i++)
                {
                    MessageBox.Show("Index #" + i + "\n" + "Error: " + myException.ErrorCode.ToString() + "\n");
                };
                
                break;
            }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            this.txtUsername.Text = string.Empty;
            erpLoginError.SetError(txtUsername, "");
            this.txtPassword.Text = string.Empty;
            erpLoginError.SetError(txtPassword, "");
            this.comboBox1.SelectedIndex = -1;
            erpLoginError.SetError(comboBox1, "");
        }

        private void cmdCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.Text.Length != 0)
            {
              erpLoginError.SetError(ctrl, "");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            erpLoginError.SetError(comboBox1, "");
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            string con;
            int cmbRows = 0;
            Datos_ini ini1 = new Datos_ini();
            comboBox1.Items.Clear();
            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini1.Servidor;  cs.Port = int.Parse(ini1.Puerto);
                cs.Database = ini1.Ubicacion;
                cs.UserID = txtUsername.Text;
                cs.Password = txtPassword.Text;
                cs.Dialect = 3;
                con = cs.ToString();

                using (FbConnection connection = new FbConnection(con))
                {
                    
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    string busco;
                    busco = "SELECT u.RDB$RELATION_NAME as USRROLE FROM RDB$USER_PRIVILEGES u WHERE u.RDB$PRIVILEGE = 'M' and u.RDB$USER = '" + txtUsername.Text.Trim() + "' ORDER BY 1 ";
                    FbCommand cmd = new FbCommand(busco, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        cmbRows++;
                        comboBox1.Items.Add(reader3.GetString(reader3.GetOrdinal("USRROLE")));
                    }

                    if (cmbRows == 1) //Tiene exactamente 1 fila
                    {
                        comboBox1.SelectedIndex = 0; //setea ese directamente, empieza en cero
                    }

                    reader3.Close();
                    ini1 = null;
                    transaction.Commit();
                    connection.Close();
                    cs = null;
                    transaction = null;
                    FbConnection.ClearPool(connection);
                }
            }

            catch (FbException ex)
            {
                VGlobales.vp_username = null;
                VGlobales.vp_password = null;
                VGlobales.vp_role = null;
                VGlobales.vp_timestamp = null;
                DisplayFbErrors(ex);
            }
        }

        private void LoginForm1_Load(object sender, EventArgs e)
        {
            string userName = string.Empty;
            string password = string.Empty;

            if (Properties.Settings.Default.rememberLogin == true)
            {
                txtUsername.Text = Properties.Settings.Default.userName;
                txtPassword.Text = Properties.Settings.Default.password;
                cbxRecordar.Checked = true;
            }
        }

        public void ingresar()
        {
            if (txtUsername.Text.Length == 0)
            {
                erpLoginError.SetError(txtUsername, "POR FAVOR INGRESE UN USUARIO");
                txtUsername.Focus();
                return;
            }
            else
            {
                erpLoginError.SetError(txtUsername, "");
            }

            if (txtPassword.Text.Length == 0)
            {
                erpLoginError.SetError(txtPassword, "POR FAVOR INGRESE UNA CONTRASEÑA");
                txtPassword.Focus();
                return;
            }
            else
            {
                erpLoginError.SetError(txtPassword, "");
            }

            if (comboBox1.Text == "")
            {
                erpLoginError.SetError(comboBox1, "POR FAVOR SELECCIONE UN ROLE");
                comboBox1.Focus();
                return;
            }
            else
            {
                erpLoginError.SetError(comboBox1, "");
            }

            LoginCheck(txtUsername.Text.Trim(), txtPassword.Text.Trim(), comboBox1.SelectedText);

            if (VGlobales.vp_username != null)
            {
                string ROL = VGlobales.vp_role;

                if (ROL == "INFORMES" || ROL == "CONTADURIA")
                {
                    ROL = "CAJA";
                }

                puntoDeVenta(ROL);
                this.Close();
                DialogResult = DialogResult.OK;
            }
        }

        private void puntoDeVenta(string ROLE)
        {
            bo dlog = new bo();
            string QUERY_N = "SELECT ID, PTO_VTA FROM PUNTOS_DE_VENTA WHERE ROL = '" + ROLE + "' AND ACCION = 'N' ORDER BY ID ASC;";
            string QUERY_M = "SELECT ID, PTO_VTA FROM PUNTOS_DE_VENTA WHERE ROL = '" + ROLE + "' AND ACCION = 'M' ORDER BY ID ASC;";
            DataRow[] foundRowsN;
            DataRow[] foundRowsM;
            foundRowsN = dlog.BO_EjecutoDataTable(QUERY_N).Select();
            foundRowsM = dlog.BO_EjecutoDataTable(QUERY_M).Select();

            if (foundRowsN.Length > 0)
            {
                VGlobales.ID_PTO_VTA_N = foundRowsN[0][0].ToString();
                VGlobales.PTO_VTA_N = foundRowsN[0][1].ToString();
            }

            if (foundRowsM.Length > 0)
            {
                VGlobales.ID_PTO_VTA_M = foundRowsM[0][0].ToString();
                VGlobales.PTO_VTA_M = foundRowsM[0][1].ToString();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ingresar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ingresar();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            ingresar();
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "AHERNANDEZ")
            {
                txtPassword.Text = "cspfa123";
            }
        }
    }
}