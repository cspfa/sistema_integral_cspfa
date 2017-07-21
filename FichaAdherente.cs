using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class FichaAdherente : MicroFour.StrataFrame.UI.Windows.Forms.StandardForm
    {
        public FichaAdherente()
        {
            InitializeComponent();
        }

        private void Cargo_Ficha(object sender, EventArgs e)
        {
            string connectionString;
            string vcmd;
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
                vcmd = "SELECT FICHA FROM ADHERENT_IMAGEN WHERE ID_ADHERENTE =" + Adherentes.vp_id_adherente.ToString();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand cmd = new FbCommand(vcmd, connection, transaction);
                    FbDataReader mt = cmd.ExecuteReader();

                    try
                    {
                        if (mt.Read())
                        {
                            string FICHA = "";
                            FICHA = mt.GetValue(mt.GetOrdinal("FICHA")).ToString();

                            if (FICHA != "")
                            {
                                Byte[] byteBLOBData2 = new Byte[0];
                                byteBLOBData2 = (Byte[])mt.GetValue(mt.GetOrdinal("FICHA"));
                                MemoryStream stmBLOBData2 = new MemoryStream(byteBLOBData2);
                                pictureBox1.Image = Image.FromStream(stmBLOBData2);
                            }
                            else
                            {
                                MessageBox.Show("NO SE ENCONTRO NINGUNA FICHA");
                                this.Close();
                            }
                        }
                    }
                    catch (FbException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (FbException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
    }
}