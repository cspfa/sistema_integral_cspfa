using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class IngresoAsamblea : MicroFour.StrataFrame.UI.Windows.Forms.StandardForm
    {
        public IngresoAsamblea()
        {
            InitializeComponent();
        }

        public static Image fotoZoom = null;
        private static DateTime FecTope;

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

                if (((textBox1.Text == "0") || (textBox1.Text == "")) &&
                   ((textBox5.Text == "0") || (textBox5.Text == "")) &&
                   ((textBox12.Text == "0") || (textBox12.Text == "")) &&
                   ((textBox8.Text == "0") || (textBox8.Text == "")) &&
                   ((textBox9.Text == "0") || (textBox9.Text == "")) &&
                   ((textBox10.Text == "0") || (textBox10.Text == "")) &&
                   ((textBox11.Text == "0") || (textBox11.Text == "")) &&
                   ((textBox7.Text == "0") || (textBox7.Text == "")) &&
                   (textBox6.Text == "") && (textBox13.Text == "") &&
                   ((textBox14.Text == "0") || (textBox14.Text == "")))
                {
                    MessageBox.Show("DEBE INGRESAR UNA CONDICION DE BUSQUEDA",
                                           "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Limpiar_Campos();
                }
                else
                    BuscarTitular();
            
        }


        private void BuscarTitular()
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
                    string busco;
                    busco = "SELECT * FROM P_BUSCO_UN_TITULAR (@P_APE_SOC,@P_NOM_SOC,";
                    busco = busco + "@P_NRO_SOC,@P_NRO_DEP,@P_AAR,";
                    busco = busco + "@P_ACRJP2,@P_LEG_PER,@P_PCRJP3,@P_PCRJP2,";
                    busco = busco + "@P_PCRJP1,@P_NRODOC)";
                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;

                    // DEFINICION DE LOS PARAMETROS PARA EJECUTAR STORE DE BUSQUEDA.-
                    cmd.Parameters.Add(new FbParameter("@P_APE_SOC", FbDbType.Char));
                    cmd.Parameters.Add(new FbParameter("@P_NOM_SOC", FbDbType.Char));
                    cmd.Parameters.Add(new FbParameter("@P_NRO_SOC", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_NRO_DEP", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_AAR", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_ACRJP2", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_LEG_PER", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_PCRJP3", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_PCRJP2", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_PCRJP1", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_NRODOC", FbDbType.Integer));


                    // SE CARGAN LOS PARAMETROS CON LOS VALORES DEL WINFORM.-
                    cmd.Parameters["@P_APE_SOC"].Value = textBox6.Text;
                    cmd.Parameters["@P_NOM_SOC"].Value = textBox13.Text;
                    //cmd.Parameters["@P_NRO_SOC"].Value = (int)(System.Convert.ToInt32(textBox1.Text));
                    cmd.Parameters["@P_NRO_SOC"].Value = (textBox1.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox1.Text)));
                    cmd.Parameters["@P_NRO_DEP"].Value = (textBox5.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox5.Text)));
                    cmd.Parameters["@P_AAR"].Value = (textBox7.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox7.Text)));
                    cmd.Parameters["@P_ACRJP2"].Value = (textBox11.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox11.Text)));
                    cmd.Parameters["@P_LEG_PER"].Value = (textBox12.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox12.Text)));
                    cmd.Parameters["@P_PCRJP3"].Value = (textBox10.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox10.Text)));
                    cmd.Parameters["@P_PCRJP2"].Value = (textBox9.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox9.Text)));
                    cmd.Parameters["@P_PCRJP1"].Value = (textBox8.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox8.Text)));
                    cmd.Parameters["@P_NRODOC"].Value = (textBox14.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox14.Text)));

                    // SE EJECUTA EL COMANDO DE LECTURA CON TODOS LOS PARAMETROS.-
                    // cmd.ExecuteNonQuery();

                    FbDataReader reader = cmd.ExecuteReader();

                    string ape;
                    string nom;
                    string soc;
                    string dep;
                    string dto;


                    try
                    {
                        while (reader.Read())
                        {
                            
                            ape = reader.GetString(reader.GetOrdinal("APE_SOC"));
                            nom = reader.GetString(reader.GetOrdinal("NOM_SOC"));
                            soc = reader.GetString(reader.GetOrdinal("NRO_SOC"));
                            soc = soc.PadLeft(5, '0');
                            dep = reader.GetString(reader.GetOrdinal("NRO_DEP"));
                            dep = dep.PadLeft(3, '0');
                            dto = reader.GetString(reader.GetOrdinal("COD_DTO"));
                            dto = dto.PadLeft(3, '0');
                            if ( dep == "994")
                                this.listBox1.Items.Add(soc + " " + dep + " " + ape + " " + nom + " " + dto);
                        }

                        themedGroupBox3.Title = "RESULTADO DE LA BUSQUEDA - " + listBox1.Items.Count.ToString() + " REGISTROS";

                        if (listBox1.Items.Count == 1)
                        {
                            listBox1.SelectedIndex = 0;
                            CargarDatos(listBox1.SelectedItem);
                        }

                        if (listBox1.Items.Count == 0)
                        {
                            MessageBox.Show("NO SE ENCONTRARON DATOS",
                                  "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }



                    }
                    finally
                    {
                        reader.Close();
                    }



                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                }
            }

            catch (FbException ex)
            {
                //  System.Windows.Forms.MessageBox.Show(ex.ToString());
                DisplayFbErrors(ex);
                textBox24.Focus();
            }
            finally
            {

            }
        }

 

        private void button2_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("CONFIRMA CERRAR LA VENTANA?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    return;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // SE LIMPIAN LOS TEXTBOX DEL WINFORM.-
            Limpiar_Campos();
 
        }

        private void Limpiar_Campos()
        {
            textBox1.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
            textBox12.Text = "0";
            textBox13.Text = "";
            textBox14.Text = "0";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "0";
            textBox6.Text = "";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox16.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox15.Text = "";
            textBox17.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            comboBox1.SelectedIndex = -1;
            listBox1.Items.Clear();
            pictureBox1.Image = SOCIOS.Properties.Resources.fotonodisponible;
            button4.Enabled = false;
            label15.Text = "";
            label16.Text = "";
            themedGroupBox3.Title = "RESULTADO DE LA BUSQUEDA";
            textBox24.Text = "";  // Codigo de Barras
            textBox24.Focus();
        }

 
        private void Form5_Load(object sender, EventArgs e)
        {
            Limpiar_Campos();
            ObtenerAsamblea();
        }

        private void ObtenerAsamblea()
        {
            string connString;
            Datos_ini ini2 = new Datos_ini();
            string fectope;

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini2.Servidor;  cs.Port = int.Parse(ini2.Puerto);
                cs.Database = ini2.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connString = cs.ToString();

                using (FbConnection connection1 = new FbConnection(connString))
                {
                    connection1.Open();
                    FbTransaction transaction1 = connection1.BeginTransaction();
                    string fcmd;
                    fcmd = "SELECT FECHA_TOPE FROM ";
                    fcmd = fcmd + "CONTROL_ASISTENCIA ";
                    fcmd = fcmd + " WHERE ELECCION=extract(year from current_date) AND CERRADO='N'";
                    FbCommand cmd1 = new FbCommand(fcmd, connection1, transaction1);
                    cmd1.CommandText = fcmd;
                    cmd1.Connection = connection1;
                    FbDataReader reader1 = cmd1.ExecuteReader();

                    //Asi no tiene sentido pues siempre devuelve algo el COUNT
                    if (reader1.Read())
                    {
                        fectope = reader1.GetString(reader1.GetOrdinal("FECHA_TOPE"));
              //          VGlobales.vp_FecTope = Convert.ToDateTime(fectope);
                        transaction1.Commit();
                        connection1.Close();
                    }
                    else
                    {
                        MessageBox.Show("NO HAY ASAMBLEAS ABIERTAS",
                                     "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }


        }




        private void Form5_Shown(object sender, EventArgs e)
        {
            textBox24.Focus();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void MSK_Enter(object sender, EventArgs e)
        {
            ((MaskedTextBox)sender).Focus();
            ((MaskedTextBox)sender).SelectAll();
        }

        private void TXT_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).Focus();
            ((TextBox)sender).SelectAll();
        }
        
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.SelectAll();
        }


        private void listBox1_Click(object sender, EventArgs e)
        {
            CargarDatos(sender);
        }
        
        private void CargarDatos(object sender)
        {
            string connectionString;
            int vnro_lega;
            int vnro_depu;

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
                    string busco;
                    busco = "SELECT * FROM P_BUSCO_TITULAR (@P_APE_SOC,@P_NOM_SOC,";
                    busco = busco + "@P_NRO_LEGAJO,@P_NRO_DEPURACION,@P_AAR,";
                    busco = busco + "@P_ACRJP2,@P_LEG_PER,@P_PCRJP3,@P_PCRJP2,@P_PCRJP1,@P_NRODOC)";
                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;


                    // DEFINICION DE LOS PARAMETROS PARA EJECUTAR STORE DE BUSQUEDA.-
                    cmd.Parameters.Add(new FbParameter("@P_APE_SOC", FbDbType.Char));
                    cmd.Parameters.Add(new FbParameter("@P_NOM_SOC", FbDbType.Char));
                    cmd.Parameters.Add(new FbParameter("@P_NRO_LEGAJO", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_NRO_DEPURACION", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_AAR", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_ACRJP2", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_LEG_PER", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_PCRJP3", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_PCRJP2", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_PCRJP1", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P_NRODOC", FbDbType.Integer));

                    // SE CARGAN LOS PARAMETROS CON LOS VALORES DEL WINFORM.-
                    cmd.Parameters["@P_APE_SOC"].Value = textBox6.Text;
                    cmd.Parameters["@P_NOM_SOC"].Value = textBox13.Text;
                    vnro_lega = (int)(System.Convert.ToInt32(listBox1.GetItemText(listBox1.SelectedItem).Substring(0, 5)));
                    vnro_depu = (int)(System.Convert.ToInt32(listBox1.GetItemText(listBox1.SelectedItem).Substring(6, 3)));
                    cmd.Parameters["@P_NRO_LEGAJO"].Value = (int)(System.Convert.ToInt32(listBox1.GetItemText(listBox1.SelectedItem).Substring(0, 5)));
                    cmd.Parameters["@P_NRO_DEPURACION"].Value = (int)(System.Convert.ToInt32(listBox1.GetItemText(listBox1.SelectedItem).Substring(6, 3)));
                    cmd.Parameters["@P_AAR"].Value = 0;
                    cmd.Parameters["@P_ACRJP2"].Value = 0;
                    cmd.Parameters["@P_LEG_PER"].Value = 0;
                    cmd.Parameters["@P_PCRJP3"].Value = 0;
                    cmd.Parameters["@P_PCRJP2"].Value = 0;
                    cmd.Parameters["@P_PCRJP1"].Value = 0;
                    cmd.Parameters["@P_NRODOC"].Value = 0;

                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) 
                    {
                        textBox2.Text = reader.GetString(reader.GetOrdinal("APE_SOC"));
                        textBox6.Text = reader.GetString(reader.GetOrdinal("APE_SOC"));
                        textBox3.Text = reader.GetString(reader.GetOrdinal("NOM_SOC"));
                        textBox13.Text = reader.GetString(reader.GetOrdinal("NOM_SOC"));
                        textBox4.Text = reader.GetString(reader.GetOrdinal("DESCRIP"));
                        textBox1.Text = reader.GetString(reader.GetOrdinal("NRO_SOC"));
                        textBox5.Text = reader.GetString(reader.GetOrdinal("NRO_DEP"));
                        textBox15.Text = reader.GetString(reader.GetOrdinal("F_BAJCI"));
                        textBox16.Text = reader.GetString(reader.GetOrdinal("F_BAJPO"));
                        textBox18.Text = reader.GetString(reader.GetOrdinal("MBPOL"));
                        textBox19.Text = reader.GetString(reader.GetOrdinal("F_ALTCI"));
                        textBox20.Text = reader.GetString(reader.GetOrdinal("COD_DTO"));
                        textBox7.Text = reader.GetString(reader.GetOrdinal("AAR"));
                        textBox11.Text = reader.GetString(reader.GetOrdinal("ACRJP2"));
                        textBox17.Text = reader.GetString(reader.GetOrdinal("MBCIR"));
                        textBox12.Text = reader.GetString(reader.GetOrdinal("LEG_PER"));


                        textBox8.Text = reader.GetString(reader.GetOrdinal("PCRJP1"));
                        textBox9.Text = reader.GetString(reader.GetOrdinal("PCRJP2"));
                        textBox10.Text = reader.GetString(reader.GetOrdinal("PCRJP3"));



                        Byte[] byteBLOBData = new Byte[0];
                        byteBLOBData = (Byte[])reader.GetValue(reader.GetOrdinal("FOTO"));
                        MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                        pictureBox1.Image = Image.FromStream(stmBLOBData);
                    }
                    transaction.Commit();
                    reader.Close();
                    connection.Close();
                    cmd = null;
                }


                // VERIFICAMOS SI PUEDE ENTRAR O NO.-

                button4.Enabled = true;

                label15.Text = "PUEDE INGRESAR";
                this.label15.ForeColor = System.Drawing.Color.Green;
                label16.Text = "";


                FbConnectionStringBuilder cs3 = new FbConnectionStringBuilder();
                cs3.DataSource = ini2.Servidor;
                cs3.Port = int.Parse(ini2.Puerto);
                cs3.Database = ini2.Ubicacion;
                cs3.UserID = VGlobales.vp_username;
                cs3.Password = VGlobales.vp_password;
                cs3.Role = VGlobales.vp_role;
                cs3.Dialect = 3;
                connectionString = cs.ToString();

                using (FbConnection connection2 = new FbConnection(connectionString))
                {
                    connection2.Open();
                    FbTransaction transaction2 = connection2.BeginTransaction();
                    string busco2;
                    busco2 = "SELECT * FROM P_VERIFICAR_INGRESO(@P_NRO_LEG,@P_NRO_DEP,@P_FEC_TOPE)";
                    FbCommand cmd2 = new FbCommand(busco2, connection2, transaction2);
                    cmd2.CommandText = busco2;
                    cmd2.Connection = connection2;
                    cmd2.CommandType = CommandType.Text;

                    cmd2.Parameters.Add(new FbParameter("@P_NRO_LEG", FbDbType.Integer));
                    cmd2.Parameters.Add(new FbParameter("@P_NRO_DEP", FbDbType.Integer));
                    cmd2.Parameters.Add(new FbParameter("@P_FEC_TOPE", FbDbType.Date));

                    cmd2.Parameters["@P_NRO_LEG"].Value = vnro_lega;
                    cmd2.Parameters["@P_NRO_DEP"].Value = vnro_depu;
                    cmd2.Parameters["@P_FEC_TOPE"].Value = VGlobales.v_fechatope;


                    string verifico;
                    string vcausa;

                    FbDataReader reader2 = cmd2.ExecuteReader();

                    if (reader2.Read())
                    {
                        //verifico = reader.GetString(0);
                        //vcausa = reader.GetString(1);

                        textBox21.Text = reader2.GetString(reader2.GetOrdinal("MOROSO"));
                        textBox22.Text = reader2.GetString(reader2.GetOrdinal("IMPORTE"));
                        textBox23.Text = reader2.GetString(reader2.GetOrdinal("V_CONCEPTO"));

                        verifico = reader2.GetString(reader2.GetOrdinal("VERIFICACION"));
                        vcausa = reader2.GetString(reader2.GetOrdinal("CAUSA"));



                        if (verifico == "N")
                        {
                            label15.Text = "NO INGRESA";
                            this.label15.ForeColor = System.Drawing.Color.Red;
                            label16.Text = vcausa;
                        }
                        else
                        {
                            label15.Text = "PUEDE INGRESAR";
                            this.label15.ForeColor = System.Drawing.Color.Green;
                            label16.Text = "";
                        }


                        //transaction.Commit();
                        //connection.Close();
                        //cmd = null;

                        button4.Enabled = true;
                    }

                    
                    
                }

            }

            catch (FbException ex)
            {
               //System.Windows.Forms.MessageBox.Show(ex.ErrorCode.ToString());
               
            }

        }


        public void DisplayFbErrors(FbException myException)
        {

            switch (myException.ErrorCode.ToString())
            {
                case "335544665":
                    { 
                        MessageBox.Show("REGISTRO YA INGRESADO CON ANTERIORIDAD",
                                      "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "2":  //E_ASAMBLEA_CERRADA en TRIGGER
                    MessageBox.Show("LA ASAMBLEA ESTA CERRADA, NO SE PUEDEN INGRESAR MAS VOTANTES",
                                      "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
               
                default:
                    for (int i = 0; i < myException.Errors.Count; i++)
                    {
                      //MessageBox.Show("Index #" + i + "\n" +
                      //   "Error: " + myException.Errors[i].ToString() + "\n");
                    };
                    break;
                   
            }

           
        }

        

        private void button4_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("CONFIRMA EL INGRESO DEL SOCIO?", "ATENCION",
               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button1) == DialogResult.Yes)
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


                        // verificar que en la tabla control de asistencia este habilitado.-
                        // EL CONTROL SE HACE POR TRIGGER (04-10-2009)

                        //string agrego = "INSERT INTO ASAMBLEA (ELECCION,TIPO,NRO_SOC,NRO_DEP,NOMINAL,INGRESO) " +
                        //                " VALUES (extract(year from current_date), 'A', @P1, @P2, 'NO','S')";

                        string agrego = "INSERT INTO ASAMBLEA (ELECCION,TIPO,NRO_SOC,NRO_DEP,NOMINAL,INGRESO) " +
                                        " VALUES (extract(year from current_date), 'A', ";
                        agrego = agrego + textBox1.Text + ", "+ textBox5.Text + ", 'NO','S')";
                        


                        FbCommand cmd = new FbCommand(agrego, connection, transaction);

                        cmd.CommandText = agrego;
                        cmd.Connection = connection;
                        //cmd.CommandType = CommandType.Text;
                        //cmd.Parameters.Add(new FbParameter("@P1", FbDbType.Integer));
                        //cmd.Parameters.Add(new FbParameter("@P2", FbDbType.Char, 30));
                        //cmd.Parameters.Add(new FbParameter("@P3", FbDbType.Char, 60));
                        //cmd.Parameters["@P1"].Value = (int)(System.Convert.ToInt32(textBox1.Text));
                        //cmd.Parameters["@P2"].Value = (int)(System.Convert.ToInt32(textBox5.Text));
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        connection.Close();
                        cmd = null;

                        MessageBox.Show("EL INGRESO FUE GUARDADO CON EXITO",
                                       "ALTA", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                catch (FbException ex)
                {
                    //System.Windows.Forms.MessageBox.Show(ex.ErrorCode.ToString());
                    DisplayFbErrors(ex);
                    textBox24.Focus();
                }
            }
            else
            {
                            
                MessageBox.Show("EL INGRESO FUE CANCELADO POR EL OPERADOR",
                                       "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand); 

            }
            
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (MessageBox.Show("CONFIRMA CERRAR LA VENTANA?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes);

        }


        private static Image resizeImage(Image imgToResize, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode =
            System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, width, height);
            g.Dispose();

            return (Image)b;
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            fotoZoom = resizeImage(pictureBox1.Image, 249, 216);

            using (FotoZoomAsamblea frmFOTO = new FotoZoomAsamblea())
            {
                frmFOTO.ShowDialog(this);
            }
        }

        private void validar_barra(object sender, EventArgs e)
        {
            if (textBox24.Text.Trim().Length > 0)
            {

                // OJO, FALTA TOMAR EL PRIMER CERO DE NRO_SOCIO, EN TODOS
                if (textBox24.Text.Substring(0, 1) == "T")
                {
                    textBox1.Text = textBox24.Text.Substring(2, 5);
                    textBox5.Text = textBox24.Text.Substring(7, 3);
                    textBox24.Text = "";
                    BuscarTitular();
                }
                else
                {
                    MessageBox.Show("EL CODIGO LEIDO NO CORRESPONDE A UN TITULAR",
                                       "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Limpiar_Campos();
                }

            }
        }




    }

}