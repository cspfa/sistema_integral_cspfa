using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;

namespace SOCIOS
{
    public partial class CbioPassForm : Form
    {
        public CbioPassForm()
        {
            InitializeComponent();
        }

        private void CambioPassword_Load(object sender, EventArgs e)
        {
            txtUsername.Text = VGlobales.vp_username;
            txtPassword.Focus();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            // VALIDAR PASS ACTUAL
            if (txtPassword.Text.Length == 0)
            {
                erpLoginError.SetError(txtPassword, "POR FAVOR INGRESE LA CONTRASEÑA ACTUAL");
                txtPassword.Focus();
                txtPassword.SelectAll();
                return;
            }
            else
            {
                if (txtPassword.Text != VGlobales.vp_password)
                {
                    erpLoginError.SetError(txtPassword, "LA CONTRASEÑA ACTUAL ES INCORRECTA");
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                    return;
                }
                else
                {
                    erpLoginError.SetError(txtPassword, "");
                }
            }

            // COMPARA CONTRASEÑAS
            if (txtPassword.Text == txtPasswordNew.Text)
            {
                erpLoginError.SetError(txtPassword, "LA CONTRASEÑA NUEVA NO PUEDE SER IGUAL A LA ACTUAL");
                txtPasswordNew.Focus();
                txtPasswordNew.SelectAll();
                return;
            }

            // Control Password Nueva contra el nombre de usuario
            if (txtPasswordNew.Text.ToUpper() == VGlobales.vp_username.ToUpper())
            {
                erpLoginError.SetError(txtPasswordNew, "LA CONTRASEÑA NUEVA NO PUEDE SER IGUAL AL USUARIO");
                txtPasswordNew.Focus();
                txtPasswordNew.SelectAll();
                return;
            }

            // Password Nueva debe ser igual a Confirmacion
            if (txtPasswordNew.Text != txtPasswordCon.Text)
            {
                erpLoginError.SetError(txtPasswordNew, "LA CONTRASEÑA NUEVA NO COINCIDE CON LA CONFIRMACION");
                txtPasswordCon.Focus();
                txtPasswordCon.SelectAll();
                return;
            }

            // Password Nueva debe tener al menos 8 caracteres
            if (txtPasswordNew.Text.Length < 4)
            {
                erpLoginError.SetError(txtPasswordNew, "LA CONTRASEÑA NUEVA DEBE TENER AL MENOS 8 CARACTERES");
                txtPasswordNew.Focus();
                return;
            }

            /*if (!IsValidPassword(txtPasswordNew.Text))
            {
                erpLoginError.SetError(txtPasswordNew, "LA CONTRASEÑA NUEVA NO RESPETA REGLAS DE FORMACION DE PWD, REINGRESE");
                txtPasswordNew.Focus();
                return;
            }*/

            // Check Password
            if (ChgPass(txtUsername.Text, txtPassword.Text, txtPasswordNew.Text))
            {
                this.Close();
            }
        }

        private static bool IsValidPassword(string pw)
        {

           //This regex can be used to restrict passwords to a length of 8 to 20
           //aplhanumeric characters and select special characters. The password
           //also can not start with a digit, underscore or special character and
           //must contain at least one digit.

           bool ret = (Regex.IsMatch(pw, "^(?=[^\\d_].*?\\d)\\w(\\w|[!@#$&]){4,15}$"));
          
            // bool ret = (Regex.IsMatch(pw, "^(?=.*[d$!%^&*()]).{8,15}$"));
           return ret;
            
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar_Campos();
            erpLoginError.SetError(txtPassword, "");
            erpLoginError.SetError(txtPasswordNew, "");
            erpLoginError.SetError(txtPasswordCon, "");
            this.txtPassword.Focus();
        }

        private void Limpiar_Campos()
        {
            this.txtPassword.Text = string.Empty;
            this.txtPasswordNew.Text = string.Empty;
            this.txtPasswordCon.Text = string.Empty;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ChgPass(string txtUser, string txtPass, string txtPassN)
        {
            try
            {
                FbConnectionStringBuilder csb = new FbConnectionStringBuilder();
                csb.UserID = VGlobales.vp_username;
                csb.Password = VGlobales.vp_password;
                csb.DataSource = "192.168.1.6";
                FbSecurity fbSecurity = new FbSecurity();
                fbSecurity.ConnectionString = csb.ToString();
                FbUserData modi_usuario = new FbUserData();
                modi_usuario.UserName = VGlobales.vp_username;
                modi_usuario.UserPassword = txtPassN.Trim();
                fbSecurity.ModifyUser(modi_usuario);
                VGlobales.vp_password = txtPassN.Trim();
                MessageBox.Show("CAMBIO DE CONTRASEÑA EFECTUADO", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
           }
           catch (Exception ex)
           {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return false;
           }
        }

        // Blanquea el error apenas se ingresa algo en el textbox
        private void txt_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.Text.Length != 0)
            {
              erpLoginError.SetError(ctrl, "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LA CONTRASEÑA DEBE CONTENER:\n\n" +
                            "  - MINIMO  4 CARACTERES\n " +
                            " - MAXIMO 15 CARACTERES\n\n " +
                            "LOS CARACTERES VALIDOS SON: \n " + 
                            " - LETRAS \n " +
                            " - NUMEROS\n " + 
                            " - CARACTERES ESPECIALES: ! @ # $ &  \n\n " +
                            "NO PUEDE COMENZAR CON UN DIGITO NI CARACTER ESPECIAL \n " +
                            "PERO DEBE CONTENER AL MENOS UN DIGITO ",
                            "REGLAS DE FORMACION DE CONTRASEÑA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}