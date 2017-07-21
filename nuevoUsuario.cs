using System;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class nuevoUsuario : Form
    {
        public nuevoUsuario()
        {
            InitializeComponent();
        }

        private bool checkPass()
        {
            if (tbPassOne.Text != tbPassTwo.Text)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text == "")
            {
                MessageBox.Show("INGRESAR UN NOMBRE DE USUARIO");
                tbUserName.Focus();
            }
            else if (tbPassOne.Text == "")
            {
                MessageBox.Show("INGRESAR UNA CONTRASEÑA");
                tbPassOne.Focus();
            }
            else if (tbPassTwo.Text == "")
            {
                MessageBox.Show("REPETIR LA CONTRASEÑA");
                tbPassTwo.Focus();
            }
            else if (checkPass() == false)
            {
                MessageBox.Show("LAS CONTRASEÑAS INGRESADAS NO COINCIDEN");
            }
            else
            {
                try
                {
                    FbConnectionStringBuilder csb = new FbConnectionStringBuilder();
                    csb.UserID = "SYSDBA";
                    csb.Password = "C0m1s10n4d0";
                    csb.DataSource = "192.168.1.6";
                    FbSecurity fbSecurity = new FbSecurity();
                    fbSecurity.ConnectionString = csb.ToString();
                    FbUserData nuevo_usuario = new FbUserData();
                    nuevo_usuario.UserName = tbUserName.Text.Trim();
                    nuevo_usuario.UserPassword = tbPassTwo.Text.Trim();
                    nuevo_usuario.FirstName = tbFirstName.Text.Trim();
                    nuevo_usuario.MiddleName = tbMiddleName.Text.Trim();
                    nuevo_usuario.LastName = tbLastName.Text.Trim();
                    fbSecurity.AddUser(nuevo_usuario);
                    MessageBox.Show("USUARIO CREADO CORRECTAMENTE", "LISTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
