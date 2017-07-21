using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;
using System.IO;
using System.Drawing.Imaging;
using System.Data.OleDb;


namespace SOCIOS
{
    public partial class Cambio_clave : Form
    {
        public Cambio_clave()
        {
            InitializeComponent();
        }

        private void Cambio_clave_Load(object sender, EventArgs e)
        {
            label2.Text = VGlobales.vp_username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FbSecurity FBSecurity = new FbSecurity();
            FbUserData usuario_modifica = new FbUserData();
            //FBSecurity.ConnectionString = "User=SYSDBA; Password=masterkey; Server=192.168.1.7:D:\\DATA\\CSPFA_DATOS.FDB";
            conString conString = new conString();
            string connectionString = conString.get();
            using (FbConnection connection = new FbConnection(connectionString))
            connection.Open();
            FBSecurity.ConnectionString = connectionString;
            VGlobales.vp_password = textbox1.Text;
            usuario_modifica.UserName = VGlobales.vp_username;
            usuario_modifica.UserPassword = VGlobales.vp_password;
            FBSecurity.ModifyUser(usuario_modifica);
            //FBSecurity.UsersDbPath = "192.168.1.7:C:\Program Files\Firebird\Firebird_2_0\security2.fdb";
            //FBSecurity.UsersDbPath = "C:\\Archivos de programa\\Firebird\\Firebird_2_0\\security2.fdb";
        }
    }
}