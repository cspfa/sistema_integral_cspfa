using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using Reportes;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;


namespace SOCIOS
{
    public partial class frmMemo : Form
    {
        public frmMemo()
        {
            InitializeComponent();

           // MessageBox.Show(VGlobales.vp_idBusco);
           // MessageBox.Show(VGlobales.vp_idTipo);
            BuscoMemo();
        }


        private void BuscoMemo()
        {

            string connectionString;
            string dato2 = "";
            DataSet ds2 = new DataSet();
            Datos_ini ini4 = new Datos_ini();


            if (VGlobales.vp_idTipo == "TIT")
            {
                dato2 = "SELECT MEMO FROM TITULAR_IMAGEN WHERE ID_TITULAR=" + VGlobales.vp_idBusco;
            }

            if (VGlobales.vp_idTipo == "FAM")
            {
                dato2 = "SELECT MEMO FROM FAMILIAR_IMAGEN WHERE ID_TITULAR=" + VGlobales.vp_idBusco;
            }

            if (VGlobales.vp_idTipo == "ADH")
            {
                dato2 = "SELECT MEMO FROM ADHERENT_IMAGEN WHERE ID_ADHERENTE=" + VGlobales.vp_idBusco;
            }

            if (VGlobales.vp_idTipo == "VIS")
            {
                dato2 = "SELECT MEMO FROM INVITADO WHERE NUM_DOC=" + VGlobales.vp_idBusco;
            }

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini4.Servidor;  cs.Port = int.Parse(ini4.Puerto);
                cs.Database = ini4.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    FbTransaction transaction = connection.BeginTransaction();

                    FbCommand cmd2 = new FbCommand(dato2, connection, transaction);

                    FbDataReader reader3 = cmd2.ExecuteReader();

                    reader3.Read();

                    textBox1.Text = (reader3.GetString(reader3.GetOrdinal("MEMO")));

                    reader3.Close();

                    transaction.Commit();

                }

            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR EL MEMO");
            }
        }

        private void grabar_Click(object sender, EventArgs e)
        {

            string dato2 = "";
            DialogResult dr = MessageBox.Show("CONFIRMA GRABAR LOS DATOS?", "ATENCION",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                           MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {


                if (VGlobales.vp_idTipo == "TIT")
                {
                    dato2 = "UPDATE TITULAR_IMAGEN SET MEMO='" + textBox1.Text + "' WHERE ID_TITULAR=" + VGlobales.vp_idBusco;
                }

                if (VGlobales.vp_idTipo == "FAM")
                {
                    dato2 = "UPDATE FAMILIAR_IMAGEN SET MEMO='" + textBox1.Text + "' WHERE ID_TITULAR=" + VGlobales.vp_idBusco;
                }

                if (VGlobales.vp_idTipo == "ADH")
                {
                    dato2 = "UPDATE ADHERENT_IMAGEN SET MEMO='" + textBox1.Text + "' WHERE ID_ADHERENTE=" + VGlobales.vp_idBusco;
                }

                if (VGlobales.vp_idTipo == "VIS")
                {
                    dato2 = "UPDATE INVITADO SET MEMO='" + textBox1.Text + "' WHERE NUM_DOC=" + VGlobales.vp_idBusco;
                }


                string connectionString;

                Datos_ini ini3 = new Datos_ini();
                try
                {
                    FbConnectionStringBuilder cs = new FbConnectionStringBuilder();

                    cs.DataSource = ini3.Servidor;  cs.Port = int.Parse(ini3.Puerto);
                    cs.Database = ini3.Ubicacion;
                    cs.UserID = VGlobales.vp_username;
                    cs.Password = VGlobales.vp_password;
                    cs.Role = VGlobales.vp_role;
                    cs.Dialect = 3;
                    connectionString = cs.ToString();

                    using (FbConnection connection = new FbConnection(connectionString))
                    {
                        connection.Open();

                        FbTransaction transaction = connection.BeginTransaction();
                        FbCommand cmd = new FbCommand(dato2, connection, transaction);

                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                        connection.Dispose();

                        MessageBox.Show("OPERACION EFECTUADA EXISTOSAMENTE");

                    }

                }
                catch
                {
                    MessageBox.Show("ERROR AL GRABAR EL MEMO");
                }


            }


        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
