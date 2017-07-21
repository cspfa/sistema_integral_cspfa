using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Text.RegularExpressions;

namespace SOCIOS
{
    public partial class Mover_Adherentes : MicroFour.StrataFrame.UI.Windows.Forms.StandardForm
    {
        string CAT { get; set; }

        public Mover_Adherentes(string CATEGORIA)
        {
            InitializeComponent();
            CAT = CATEGORIA;
        }

        private void Mover_Adherentes_Load(object sender, EventArgs e)
        {
            this.textBox4.Text = Convert.ToString(Socios.vp_nro_soc);
            this.textBox3.Text = Convert.ToString(Socios.vp_nro_dep);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int vid_socio_origen;
            int vid_socio_destino = (Socios.vp_nro_soc * 1000) + Socios.vp_nro_dep;

            if (textBox1.Text == "")
            {
                MessageBox.Show("DEBE INFORMAR UN NUMERO DE SOCIO");
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("DEBE INFORMAR UN NUMERO DE DEPURACION");
                return;
            }

            vid_socio_origen = (System.Convert.ToInt32(textBox1.Text) * 1000) + (System.Convert.ToInt32(textBox2.Text));

            DialogResult dr2 = MessageBox.Show("CONFIRMA MOVER LOS " + CAT + "?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question,  MessageBoxDefaultButton.Button1);

            if (dr2 == DialogResult.Yes)
            {
                string connectionString;
                string vcomando = "";

                if (this.textBox1.Text == "")
                {
                    MessageBox.Show("NO SE INDICO EL NUMERO DE SOCIO DESDE EL CUAL TRANSFERIR");
                    return;
                }
                else
                {
                    if (CAT == "ADHERENTES")
                        vcomando = "P_MOVER_ADHERENTES";

                    if (CAT == "INVITADOS PARTICIPATIVOS")
                        vcomando = "P_MOVER_INVPART";

                    Datos_ini ini2 = new Datos_ini();
                    FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                    cs.DataSource = ini2.Servidor;  
                    cs.Port = int.Parse(ini2.Puerto);
                    cs.Database = ini2.Ubicacion;
                    cs.UserID = VGlobales.vp_username;
                    cs.Password = VGlobales.vp_password;
                    cs.Role = VGlobales.vp_role;
                    cs.Dialect = 3;
                    connectionString = cs.ToString();
                    FbConnection connection = new FbConnection(connectionString);
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand cmd = new FbCommand(vcomando, connection, transaction);

                    try
                    {
                        using (connection)
                        {
                            try
                            {
                                cmd.CommandText = vcomando;
                                cmd.Connection = connection;
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.Add(new FbParameter("@VID_ORIGEN", FbDbType.Integer));
                                cmd.Parameters.Add(new FbParameter("@VID_DESTINO", FbDbType.Integer));
                                cmd.Parameters.Add(new FbParameter("@VNRO_SOC", FbDbType.Integer));
                                cmd.Parameters.Add(new FbParameter("@VNRO_DEP", FbDbType.Integer));

                                cmd.Parameters["@VID_ORIGEN"].Value = vid_socio_origen;
                                cmd.Parameters["@VID_DESTINO"].Value = vid_socio_destino;
                                cmd.Parameters["@VNRO_SOC"].Value = Socios.vp_nro_soc;
                                cmd.Parameters["@VNRO_DEP"].Value = Socios.vp_nro_dep;

                                cmd.ExecuteNonQuery();
                                transaction.Commit();
                                connection.Dispose();
                                MessageBox.Show("OPERACION EFECTUADA EXITOSAMENTE", vcomando.Substring(2, 6), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.button2_Click(button2, new EventArgs());
                            }
                            catch (FbException ex)
                            {
                                transaction.Rollback();
                                System.Windows.Forms.MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }       
    }
}