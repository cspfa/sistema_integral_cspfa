using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using FirebirdSql.Data.Firebird;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Mails;


namespace SOCIOS
{
    public partial class Socios : MicroFour.StrataFrame.UI.Windows.Forms.StandardForm
    {

        public static int vp_nro_soc;
        public static int vp_nro_dep;
        public static int vp_barra;
        public static int vp_nro_adh;
        public static int vp_tabpage = 0;
        public static DataSet dsllc;
        public static string isediting;
        public static string isadding;
        public static Image fotoZoom = null;
        //public buscar frmbuscar;
        public static int v_par;
        public static int v_acrjp1;
        public static int v_acrjp2;
        public static int v_acrjp3;
        public static int v_pcrjp1;
        public static int v_pcrjp2;
        public static int v_pcrjp3;
        public string v_semaforo_baja;
        public string v_soc_fallecido;



        // Crear Objeto de Dataset
        DatosReporte DS = new DatosReporte();


        // Crear Objeto del visor de reportes
        VerReporteTitular VER;















        public Socios()
        {
            InitializeComponent();
        }




        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isediting == "SI")
            {
                Control ctrl = (Control)sender;
                if (ctrl.Text.Length == 0)
                {
                    errorProvider1.SetError(ctrl, "DEBE INDICAR UN VALOR VALIDO PARA ESTE CAMPO.-");
                }
                else
                {
                    errorProvider1.SetError(ctrl, "");
                }
            }
        }

        private void txtEmail_TextChanged(object sender, System.EventArgs e)
        {
            if (isediting == "SI")
            {
                System.Text.RegularExpressions.Regex regex;
                regex = new System.Text.RegularExpressions.Regex(@"^\S+@\S+\.\S+$");
                Control ctrl = (Control)sender;
                if (regex.IsMatch(ctrl.Text))
                {
                    errorProvider1.SetError(ctrl, "");
                }
                else
                {
                    errorProvider1.SetError(ctrl, "EL MAIL INDICADO NO ES VALIDO.-");
                }
            }
        }


        public void limpio_botones()
        {
            /*
            bindingNavigator1.MoveFirstItem.Enabled = true;
            bindingNavigator1.MoveLastItem.Enabled = true;
            bindingNavigator1.MoveNextItem.Enabled = true;
            bindingNavigator1.MovePreviousItem.Enabled = true;
            */
            cancelar.Enabled = false;
            grabar.Enabled = false;
            ADQUIRIR.Enabled = false;

        }


        public void limpio_campos()
        {
            maskedTextBox1.Text = "0";
            maskedTextBox2.Text = "0";
            maskedTextBox3.Text = "0";
            maskedTextBox4.Text = "0";
            maskedTextBox5.Text = "0";
            maskedTextBox7.Text = "0";
            maskedTextBox6.Text = "0";
            textBox1.Text = " ";
            textBox2.Text = " ";
            maskedTextbox8.Text = " ";
            textBox3.Text = " ";
            maskedTextBox9.Text = "0";
            maskedTextBox10.Text = "0";
            maskedTextbox26.Text = " ";
            textBox14.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
            textBox8.Text = " ";
            textBox9.Text = " ";
            maskedTextBox11.Text = "0";
            textBox10.Text = " ";
            maskedTextBox12.Text = "0";
            textBox11.Text = " ";
            textBox12.Text = " ";
            maskedTextBox13.Text = "0";
            maskedTextbox17.Text = " ";
            textBox13.Text = " ";
            pictureBox1.Image = SOCIOS.Properties.Resources.fotonodisponible;
            listView1.Items.Clear();
            listBox1.Items.Clear();
            v_semaforo_baja = "N";

        }



        private bool Cargo_Datos(string vcmd)
        {

            //vp_nro_soc = (int)(System.Convert.ToInt32(maskedTextBox1.Text));
            //vp_nro_dep = (int)(System.Convert.ToInt32(maskedTextBox2.Text));
            string connectionString;
            bool rtnDatos = true;
            v_semaforo_baja = "N";

            Datos_ini ini2 = new Datos_ini();
            try
            {

                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini2.Servidor;
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
                    FbCommand cmd = new FbCommand(vcmd, connection, transaction);
                    cmd.Parameters.Add(new FbParameter("@VNRO_SOC", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@VNRO_DEP", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@VTIPO", FbDbType.Char));
                    cmd.Parameters["@VNRO_SOC"].Value = vp_nro_soc;
                    cmd.Parameters["@VNRO_DEP"].Value = vp_nro_dep;
                    FbDataReader mt = cmd.ExecuteReader();

                    if (mt.Read())
                    {
                        /*
                        maskedTextBox1.Text = (mt.GetString(mt.GetOrdinal("NRO_SOC"))).TrimEnd();
                        maskedTextBox2.Text = (mt.GetString(mt.GetOrdinal("NRO_DEP"))).TrimEnd();

                        vp_nro_soc = Convert.ToInt32(maskedTextBox1.Text);
                        vp_nro_dep = Convert.ToInt32(maskedTextBox2.Text);
                        */
                        vp_nro_soc = Convert.ToInt32(mt.GetString(mt.GetOrdinal("NRO_SOC")));
                        vp_nro_dep = Convert.ToInt32(mt.GetString(mt.GetOrdinal("NRO_DEP")));

                        if (vp_nro_soc != -1 && vp_nro_dep != -1)
                        {
                            maskedTextBox1.Text = (mt.GetString(mt.GetOrdinal("NRO_SOC"))).TrimEnd();
                            maskedTextBox2.Text = (mt.GetString(mt.GetOrdinal("NRO_DEP"))).TrimEnd();
                            textBox1.Text = (mt.GetString(mt.GetOrdinal("APE_SOC"))).TrimEnd();
                            textBox2.Text = (mt.GetString(mt.GetOrdinal("NOM_SOC"))).TrimEnd();
                            maskedTextbox8.Text = (mt.GetString(mt.GetOrdinal("F_NACIM"))).TrimEnd();
                            textBox3.Text = (mt.GetString(mt.GetOrdinal("SEX"))).TrimEnd();
                            maskedTextBox9.Text = (mt.GetString(mt.GetOrdinal("NUM_DOC"))).TrimEnd();
                            maskedTextBox10.Text = (mt.GetString(mt.GetOrdinal("NUM_CED"))).TrimEnd();
                            textBox4.Text = (mt.GetString(mt.GetOrdinal("CALL_PAR"))).TrimEnd();
                            textBox5.Text = (mt.GetString(mt.GetOrdinal("NRO_PAR"))).TrimEnd();
                            textBox6.Text = (mt.GetString(mt.GetOrdinal("PIS_PAR"))).TrimEnd();
                            textBox7.Text = (mt.GetString(mt.GetOrdinal("DPT_PAR"))).TrimEnd();
                            textBox8.Text = (mt.GetString(mt.GetOrdinal("LOC_PAR"))).TrimEnd();
                            textBox9.Text = (mt.GetString(mt.GetOrdinal("CP_PART"))).TrimEnd();
                            maskedTextBox11.Text = (mt.GetString(mt.GetOrdinal("CAR_TE1"))).TrimEnd();
                            textBox10.Text = (mt.GetString(mt.GetOrdinal("NUM_TE1"))).TrimEnd();
                            maskedTextBox12.Text = (mt.GetString(mt.GetOrdinal("CAR_TE2"))).TrimEnd();
                            textBox11.Text = (mt.GetString(mt.GetOrdinal("NUM_TE2"))).TrimEnd();
                            maskedTextBox14.Text = (mt.GetString(mt.GetOrdinal("LEG_PER"))).TrimEnd();
                            maskedTextbox15.Text = (mt.GetString(mt.GetOrdinal("F_ALTPO"))).TrimEnd();
                            maskedTextbox16.Text = (mt.GetString(mt.GetOrdinal("CAM_JER"))).TrimEnd();
                            maskedTextbox17.Text = (mt.GetString(mt.GetOrdinal("F_BAJPO"))).TrimEnd();
                            maskedTextBox18.Text = (mt.GetString(mt.GetOrdinal("ORD_DIA"))).TrimEnd();
                            maskedTextbox19.Text = (mt.GetString(mt.GetOrdinal("ORD_FEC"))).TrimEnd();
                            maskedTextbox21.Text = (mt.GetString(mt.GetOrdinal("F_ALTCI"))).TrimEnd();
                            textBox15.Text = (mt.GetString(mt.GetOrdinal("COD_DTO"))).TrimEnd();
                            maskedTextBox13.Text = (mt.GetString(mt.GetOrdinal("CAR_FAX"))).TrimEnd();
                            textBox13.Text = (mt.GetString(mt.GetOrdinal("NUM_FAX"))).TrimEnd();
                            maskedTextbox22.Text = (mt.GetString(mt.GetOrdinal("F_ALTVI"))).TrimEnd();
                            maskedTextbox23.Text = (mt.GetString(mt.GetOrdinal("F_CESDE"))).TrimEnd();
                            maskedTextbox24.Text = (mt.GetString(mt.GetOrdinal("F_CARN"))).TrimEnd();
                            maskedTextbox25.Text = (mt.GetString(mt.GetOrdinal("F_BAJCI"))).TrimEnd();
                            maskedTextBox7.Text = (mt.GetString(mt.GetOrdinal("AAR"))).TrimEnd();
                            maskedTextBox6.Text = (mt.GetString(mt.GetOrdinal("ACRJP2"))).TrimEnd();
                            maskedTextBox3.Text = (mt.GetString(mt.GetOrdinal("PCRJP1"))).TrimEnd();
                            maskedTextBox4.Text = (mt.GetString(mt.GetOrdinal("PCRJP2"))).TrimEnd();
                            maskedTextBox5.Text = (mt.GetString(mt.GetOrdinal("PCRJP3"))).TrimEnd();
                            maskedTextbox26.Text = (mt.GetString(mt.GetOrdinal("F_CACAT"))).TrimEnd();
                            textBox19.Text = (mt.GetString(mt.GetOrdinal("BEAUCHEF"))).TrimEnd();
                            textBox14.Text = (mt.GetString(mt.GetOrdinal("GIMNASIO"))).TrimEnd();
                            textBox18.Text = (mt.GetString(mt.GetOrdinal("NCOD_DTO"))).TrimEnd();
                            textBox12.Text = (mt.GetString(mt.GetOrdinal("E_MAIL"))).TrimEnd();
                            maskedTextbox27.Text = (mt.GetString(mt.GetOrdinal("A_DTO"))).TrimEnd();
                            textBox16.Text = (mt.GetString(mt.GetOrdinal("SUSCRIP"))).TrimEnd();
                            maskedTextbox20.Text = (mt.GetString(mt.GetOrdinal("F_ALTRE"))).TrimEnd();

                            v_acrjp1 = mt.GetInt32(mt.GetOrdinal("ACRJP1"));
                            v_acrjp2 = mt.GetInt32(mt.GetOrdinal("ACRJP2"));
                            v_acrjp3 = mt.GetInt32(mt.GetOrdinal("ACRJP3"));
                            v_pcrjp1 = mt.GetInt32(mt.GetOrdinal("PCRJP1"));
                            v_pcrjp2 = mt.GetInt32(mt.GetOrdinal("PCRJP2"));
                            v_pcrjp3 = mt.GetInt32(mt.GetOrdinal("PCRJP3"));
                            v_par = mt.GetInt32(mt.GetOrdinal("PAR"));

                            if (maskedTextbox25.Text == " " || maskedTextbox25.Text.Length == 0)
                                v_semaforo_baja = "S";
                            else
                                v_semaforo_baja = "N";

                            // COMBO CATEGORIAS

                            comboBox1.SelectedIndex = -1;
                            comboBox1.SelectedValue = mt.GetString(mt.GetOrdinal("CAT_SOC"));

                            // COMBO DOMICILIOS
                            comboBox2.SelectedIndex = -1;
                            comboBox2.SelectedValue = mt.GetString(mt.GetOrdinal("DAT_DOM"));


                            // COMBO 5 (solapa)
                            comboBox5.SelectedIndex = -1;
                            comboBox5.SelectedValue = mt.GetString(mt.GetOrdinal("AVAL"));


                            // COMBO Tipo Carnet
                            comboBox3.SelectedIndex = -1;
                            comboBox3.SelectedValue = mt.GetString(mt.GetOrdinal("TIP_CAR"));

                            // COMBO MOT. Baja Circulo
                            comboBox4.SelectedIndex = -1;
                            comboBox4.SelectedValue = mt.GetString(mt.GetOrdinal("M_BAJCI"));
                            
                            // COMBO MOT. Baja Policial
                            comboBox6.SelectedIndex = -1;
                            v_soc_fallecido = mt.GetString(mt.GetOrdinal("M_BAJPO"));
                            comboBox6.SelectedValue = v_soc_fallecido;

                            // COMBO TIPO DOCUMENTOS
                            comboBox8.SelectedIndex = -1;
                            comboBox8.SelectedValue = mt.GetString(mt.GetOrdinal("TIP_DOC"));

                            // COMBO PROVINCIAS
                            comboBox7.SelectedIndex = -1;
                            comboBox7.SelectedValue = mt.GetString(mt.GetOrdinal("PRO_PAR"));

                            // COMBO JERARQUIA
                            comboBox9.SelectedIndex = -1;
                            comboBox9.SelectedValue = mt.GetString(mt.GetOrdinal("JERARQ")).TrimEnd();  
 
                            // COMBO DESTINOS
                            comboBox10.SelectedIndex = -1;
                            comboBox10.SelectedValue = mt.GetString(mt.GetOrdinal("DESTINO")).TrimEnd();


                            // esto es un ejemplo de como obtener lo seleccionado y guardar en la BD el ValueMember
                            int resultIndex = -1;
                            // Call the FindStringExact method to find the first 
                            // occurrence in the list.
                            resultIndex = comboBox1.SelectedIndex;
                            //MessageBox.Show("El value menber es: " + comboBox1.SelectedValue.ToString());
                            //--------------------------------------------


                            Byte[] byteBLOBData1 = new Byte[0];
                            byteBLOBData1 = (Byte[])mt.GetValue(mt.GetOrdinal("FOTO"));
                            MemoryStream stmBLOBData1 = new MemoryStream(byteBLOBData1);
                            pictureBox1.Image = Image.FromStream(stmBLOBData1);



                            Byte[] byteBLOBData2 = new Byte[0];
                            byteBLOBData2 = (Byte[])mt.GetValue(mt.GetOrdinal("FICHA"));
                            MemoryStream stmBLOBData2 = new MemoryStream(byteBLOBData2);
                            pictureBox2.Image = Image.FromStream(stmBLOBData2);


                            //-----------------------------------------
                            // Recuperamos el rtf de las observaciones
                            Byte[] rtf = new Byte[Convert.ToInt32((mt.GetBytes(mt.GetOrdinal("OBSERVACIONES"), 0, null, 0, Int32.MaxValue)))];
                            long bytesReceived = mt.GetBytes(mt.GetOrdinal("OBSERVACIONES"), 0, rtf, 0, rtf.Length);
                            ASCIIEncoding encoding = new ASCIIEncoding();
                            richTextbox1.Rtf = encoding.GetString(rtf, 0, Convert.ToInt32(bytesReceived));



                            //--- prueba imagen del reporte
                            ((Bitmap)pictureBox1.Image).Save("C:\\tmp.bmp");

                            


                        }
                        else
                        {
                            rtnDatos = false;
                        }
                    }
                    connection.Dispose();

                }




                string cs2;
                Datos_ini ini22 = new Datos_ini();
                try
                {
                    VGlobales.vp_ntp = false;
                    FbConnectionStringBuilder css = new FbConnectionStringBuilder();
                    css.DataSource = ini22.Servidor;
                    css.Database = ini22.Ubicacion;
                    css.UserID = VGlobales.vp_username;
                    css.Password = VGlobales.vp_password;
                    css.Role = VGlobales.vp_role;
                    css.Dialect = 3;
                    cs2 = css.ToString();
                    using (FbConnection conn2 = new FbConnection(cs2))
                    {
                        conn2.Open();
                        FbTransaction tran = conn2.BeginTransaction();
                        string cmd_familiares;
                        string cmd_adherentes;
                        string cmd_observac;
                        cmd_familiares = "SELECT * FROM FAMILIAR WHERE NRO_SOC=" + maskedTextBox1.Text + " AND NRO_DEP=" + maskedTextBox2.Text;
                        cmd_familiares = cmd_familiares + " ORDER BY BARRA ASC";
                        cmd_adherentes = "SELECT * FROM ADHERENT WHERE NRO_SOCIO=" + maskedTextBox1.Text + " AND NRO_DEP=" + maskedTextBox2.Text;
                        cmd_adherentes = cmd_adherentes + " ORDER BY ID_ADHERENTE ASC";
                        cmd_observac = "SELECT SUBSTR(OBS,1,60) AS O1,SUBSTR(OBS,61,120) AS O2,SUBSTR(OBS,121,180) AS O3  FROM OBSERVAC WHERE NRO_SOC=" + maskedTextBox1.Text + " AND NRO_DEP=" + maskedTextBox2.Text;
  
                        FbCommand cmdt = new FbCommand(cmd_familiares, conn2, tran);
                        FbCommand cmdt2 = new FbCommand(cmd_adherentes, conn2, tran);
                        FbCommand cmdt3 = new FbCommand(cmd_observac, conn2, tran);
                        cmdt.CommandText = cmd_familiares;
                        cmdt.Connection = conn2;
                        cmdt.CommandType = CommandType.Text;
                        FbDataReader reader3 = cmdt.ExecuteReader();
                        cmdt2.CommandText = cmd_adherentes;
                        cmdt2.Connection = conn2;
                        cmdt2.CommandType = CommandType.Text;
                        FbDataReader reader4 = cmdt2.ExecuteReader();

                        cmdt3.CommandText = cmd_observac;
                        cmdt3.Connection = conn2;
                        cmdt3.CommandType = CommandType.Text;
                        FbDataReader reader5 = cmdt3.ExecuteReader();

                        listBox1.Items.Clear();



                        Cargar_Familires(reader3);

                        Cargar_Adherentes(reader4);

                        Cargar_observac(reader5);

                        conn2.Dispose();


                    }
                }

                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }

                //mt = null;
            }
            catch (FbException ex)
            {


                VGlobales.vp_ntp = true;
                switch (ex.ErrorCode.ToString())
                {

                    case "335544352":
                        {
                            MessageBox.Show("NO TIENE PERMISOS PARA REALIZAR ESTA TAREA. \n \n UTILICE LA OPCION DE CAMBIO DE USUARIO",
                                       "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        break;
                    case "335544374":
                        {
                            MessageBox.Show("EOF - NO HAY MAS REGISTROS",
                                   "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        break;
                    case "335544644":
                        {
                            MessageBox.Show("BOF - NO HAY MAS REGISTROS",
                                   "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        break;
                    default:
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        break;

                }


                //this.Dispose();
                this.Close();
            }

            return rtnDatos;
        }

        private void Cargar_Solapa_Fam()
        {
            string cs2;
                Datos_ini ini22 = new Datos_ini();
                try
                {
                    VGlobales.vp_ntp = false;
                    FbConnectionStringBuilder css = new FbConnectionStringBuilder();
                    css.DataSource = ini22.Servidor;
                    css.Database = ini22.Ubicacion;
                    css.UserID = VGlobales.vp_username;
                    css.Password = VGlobales.vp_password;
                    css.Role = VGlobales.vp_role;
                    css.Dialect = 3;
                    cs2 = css.ToString();
                    using (FbConnection conn2 = new FbConnection(cs2))
                    {
                        conn2.Open();
                        FbTransaction tran = conn2.BeginTransaction();
                        string cmd_familiares;
       
                        cmd_familiares = "SELECT * FROM FAMILIAR WHERE NRO_SOC=" + maskedTextBox1.Text + " AND NRO_DEP=" + maskedTextBox2.Text;
                        cmd_familiares = cmd_familiares + " ORDER BY BARRA ASC";
                        
                        FbCommand cmdt = new FbCommand(cmd_familiares, conn2, tran);
                        cmdt.CommandText = cmd_familiares;
                        cmdt.Connection = conn2;
                        cmdt.CommandType = CommandType.Text;
                        FbDataReader reader3 = cmdt.ExecuteReader();

                        listBox1.Items.Clear();

                        Cargar_Familires(reader3);

                        conn2.Dispose();

                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }

                
         }

        private void Cargar_Solapa_Adh()
        {
            string cs2;
            Datos_ini ini22 = new Datos_ini();
            try
            {
                VGlobales.vp_ntp = false;
                FbConnectionStringBuilder css = new FbConnectionStringBuilder();
                css.DataSource = ini22.Servidor;
                css.Database = ini22.Ubicacion;
                css.UserID = VGlobales.vp_username;
                css.Password = VGlobales.vp_password;
                css.Role = VGlobales.vp_role;
                css.Dialect = 3;
                cs2 = css.ToString();
                using (FbConnection conn2 = new FbConnection(cs2))
                {
                    conn2.Open();
                    FbTransaction tran = conn2.BeginTransaction();
                    string cmd_adherentes;
                    cmd_adherentes = "SELECT * FROM ADHERENT WHERE NRO_SOCIO=" + maskedTextBox1.Text + " AND NRO_DEP=" + maskedTextBox2.Text;
                    cmd_adherentes = cmd_adherentes + " ORDER BY ID_ADHERENTE ASC";

                    FbCommand cmdt2 = new FbCommand(cmd_adherentes, conn2, tran);
                
                    cmdt2.CommandText = cmd_adherentes;
                    cmdt2.Connection = conn2;
                    cmdt2.CommandType = CommandType.Text;
                    FbDataReader reader4 = cmdt2.ExecuteReader();

                    listBox1.Items.Clear();

                    Cargar_Adherentes(reader4);

                    conn2.Dispose();

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

        }
        

        private void Cargar_Adherentes(FbDataReader reader4)
        {
            listView2.Items.Clear();
            //listView2.BeginUpdate();
            if (reader4.Read())
            {
                do
                {
                    ListViewItem item11 = new ListViewItem(reader4.GetString(reader4.GetOrdinal("NRO_ADH")));
                    if (reader4.GetString(reader4.GetOrdinal("F_BAJADH")) == null)
                    {
                        item11.ImageIndex = 14;
                        //item11.StateImageIndex = 14;
                    }
                    else
                    {
                        //item11.StateImageIndex = 10;
                        item11.ImageIndex = 10;
                    }
                    item11.SubItems.Add(reader4.GetString(reader4.GetOrdinal("BARRA")));
                    item11.SubItems.Add(reader4.GetString(reader4.GetOrdinal("APE_ADH")));
                    item11.SubItems.Add(reader4.GetString(reader4.GetOrdinal("NOM_ADH")));
                    item11.SubItems.Add(reader4.GetString(reader4.GetOrdinal("COD_DTO")));
                    item11.SubItems.Add(reader4.GetString(reader4.GetOrdinal("F_BAJADH")));
                    listView2.Items.Add(item11);

                }
                while (reader4.Read());
                //listView2.EndUpdate();




            }
        }

        private void Cargar_Familires(FbDataReader reader3)
        {
            listView1.Items.Clear();
            //listView1.BeginUpdate();

            if (reader3.Read())
            {
                do
                {
                    ListViewItem item1 = new ListViewItem(reader3.GetString(reader3.GetOrdinal("BARRA")));
                    if (reader3.GetString(reader3.GetOrdinal("F_BAJA")) == null)
                    {
                        //item1.StateImageIndex = 14;
                        item1.ImageIndex = 14;
                        //    listView1.Items[0].ImageIndex = 14;
                    }
                    else
                    {
                        //    item1.StateImageIndex = 10;
                        item1.ImageIndex = 10;
                    }
                    item1.SubItems.Add(reader3.GetString(reader3.GetOrdinal("APE_FAM")));
                    item1.SubItems.Add(reader3.GetString(reader3.GetOrdinal("NOM_FAM")));
                    item1.SubItems.Add(reader3.GetString(reader3.GetOrdinal("F_BAJA")));
                    item1.SubItems.Add(reader3.GetString(reader3.GetOrdinal("F_CARFAM")));
                    item1.SubItems.Add(reader3.GetString(reader3.GetOrdinal("F_NACFAM")));
                    item1.SubItems.Add(reader3.GetString(reader3.GetOrdinal("SEXO")));
                    listView1.Items.Add(item1);

                    DS.DataTableFamiliiar.Rows.Add(reader3.GetString(reader3.GetOrdinal("APE_FAM")),
                       reader3.GetString(reader3.GetOrdinal("NOM_FAM")), reader3.GetString(reader3.GetOrdinal("F_NACFAM")),
                       reader3.GetString(reader3.GetOrdinal("BARRA")));


                }
                while (reader3.Read());
                //listView1.EndUpdate();


            }
        }





        private void Cargar_observac(FbDataReader reader5)
        {
            listBox1.Items.Clear();

            if (reader5.Read())
            {
                do
                {
                    //ListBox item1 = new ListBox();
                    listBox1.Items.Add(reader5.GetString(reader5.GetOrdinal("O1")));
                    listBox1.Items.Add(reader5.GetString(reader5.GetOrdinal("O2")));
                    listBox1.Items.Add(reader5.GetString(reader5.GetOrdinal("O3")));
                    //item1.Items.Add(item1);
                }
                while (reader5.Read());
            }
        }






        private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "0";
            maskedTextBox2.Text = "0";
            //vp_nro_dep = 0;
            //vp_nro_soc = 0;
            richTextbox1.ReadOnly = true;
            dsllc = lleno_combos();

            Ver_Privilegios("TITULAR");

            Habilitar_Botones();

            if (vp_nro_soc == -1 && vp_nro_dep == -1)
            {
                nuevo_Click(nuevo, new EventArgs());
            }
            else
            {
                Busco_Primero();
            }

            if (VGlobales.vp_role.Trim() != "SISTEMAS")
            {
                //tabPage2.Hide();
                //tabPage2.IsAccessible = false;
                tabPage2.Dispose();
                vp_tabpage = -1;
            }

           // frmbuscar = new buscar();
           // frmbuscar.Hide();
        }

        private void Habilitar_Botones()
        {
            bindingNavigator1.MoveFirstItem.Enabled = false;
            bindingNavigator1.MovePreviousItem.Enabled = false;
            bindingNavigator1.MoveNextItem.Enabled = false;
            bindingNavigator1.MoveLastItem.Enabled = false;

            if (VGlobales.vp_boton_modi == "U")
                editar.Enabled = true;
            else
                editar.Enabled = false;

            if (VGlobales.vp_boton_alta == "I")
                nuevo.Enabled = true;
            else
                nuevo.Enabled = false;
        }

        public static void Ver_Privilegios(string tabla)
        {
            VGlobales.vp_boton_modi = "S";
            VGlobales.vp_boton_alta = "S";

            string connectionString3;
            string comando3;
            comando3 = "select RDB$USER,RDB$RELATION_NAME,RDB$PRIVILEGE ";
            comando3 = comando3 + " from RDB$USER_PRIVILEGES ";
            comando3 = comando3 + " where RDB$USER='" + VGlobales.vp_role.Trim() + "'";
            comando3 = comando3 + " and RDB$RELATION_NAME='" + tabla.Trim() + "' ";
            comando3 = comando3 + " and  (rdb$privilege='I' or rdb$privilege='U')";

            Datos_ini ini3 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs3 = new FbConnectionStringBuilder();
                cs3.DataSource = ini3.Servidor;
                cs3.Database = ini3.Ubicacion;
                cs3.UserID = VGlobales.vp_username;
                cs3.Password = VGlobales.vp_password;
                cs3.Role = VGlobales.vp_role;
                cs3.Dialect = 3;
                connectionString3 = cs3.ToString();

                using (FbConnection connection3 = new FbConnection(connectionString3))
                {

                    connection3.Open();
                    FbTransaction transaction3 = connection3.BeginTransaction();
                    FbCommand cmd3 = new FbCommand(comando3, connection3, transaction3);
                    FbDataReader reader4 = cmd3.ExecuteReader();



                    string v_auxi;

                    if (reader4.Read())
                    {
                        do
                        {
                            v_auxi = reader4.GetString(reader4.GetOrdinal("RDB$PRIVILEGE"));
                            if (v_auxi.Trim() == "I")
                                VGlobales.vp_boton_alta = "I";
                            if (v_auxi.Trim() == "U")
                                VGlobales.vp_boton_modi = "U";
                        }
                        while (reader4.Read());
                    }
                    connection3.Close();
                }
            }
            catch (FbException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }


        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            Busco_Primero();

        }

        private void Busco_Primero()
        {
            string busco;
            if (vp_nro_soc != 0)
            {
                {
                    maskedTextBox1.Text = Convert.ToString(vp_nro_soc);
                    maskedTextBox2.Text = Convert.ToString(vp_nro_dep);

                    limpio_botones();

                    busco = "SELECT * FROM P_OBTENER_TITULAR(@VNRO_SOC,@VNRO_DEP,'E')";
                    Cargo_Datos(busco);
                }

                //tabControl1.SelectedIndex = vp_tabpage;

                //if (tabControl1.SelectedTab == tabPage3 ) // FAMILIARES

                //if (tabControl1.SelectedTab.Text == "FAMILIARES")

                if (((vp_tabpage == 2) && (VGlobales.vp_role.Trim() == "SISTEMAS"))  || 
                    ((vp_tabpage == 1) && (VGlobales.vp_role.Trim() != "SISTEMAS"))) // FAM
                {
                    tabControl1.SelectedTab = tabPage3;

                    if (this.listView1.Items.Count == 1)
                    {
                        this.listView1.Items[0].Focused = true;
                        this.listView1_Click(listView1, new EventArgs());
                    }
                    else
                    {
                        if (VGlobales.vp_cod_bar == "F")
                        {
                            using (Familiares frmFAM = new Familiares())
                            {
                                frmFAM.ShowDialog(this);
                            }

                            Cargar_Solapa_Fam();
                        }
                    }
                }
                else
                {
                  //if (tabControl1.SelectedTab == tabPage5) //ADHERENTES
                  // if (tabControl1.SelectedTab.Text == "ADHERENTES")
                  
                    if (((vp_tabpage == 3) && (VGlobales.vp_role.Trim() == "SISTEMAS")) ||
                        ((vp_tabpage == 2) && (VGlobales.vp_role.Trim() != "SISTEMAS"))) // ADHERENTES
                    {
                        tabControl1.SelectedTab = tabPage5;

                        if (this.listView2.Items.Count == 1)
                        {
                            this.listView2.Items[0].Focused = true;
                            this.listView2_Click(listView2, new EventArgs());
                        }
                        else
                        {
                            if (VGlobales.vp_cod_bar == "A")
                            {
                                using (Adherentes frmADH = new Adherentes())
                                {
                                    frmADH.ShowDialog(this);
                                }

                                Cargar_Solapa_Adh();
                            }
                        }
                    }
                }
            }
            else
            {

                limpio_botones();
                bindingNavigator1.MoveFirstItem.Enabled = false;
                bindingNavigator1.MovePreviousItem.Enabled = false;

                busco = "SELECT * FROM P_OBTENER_TITULAR(0,0,'P')";
            }

            Cargo_Datos(busco);

        }



        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            limpio_botones();
            string busco;
            busco = "SELECT * FROM P_OBTENER_TITULAR(@VNRO_SOC,@VNRO_DEP,'A') ";
            if (!Cargo_Datos(busco)) //se pasó del primero al ir con anterior
            {
                Busco_Primero();
            }

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            limpio_botones();
            string busco;
            busco = "SELECT * FROM P_OBTENER_TITULAR(@VNRO_SOC,@VNRO_DEP,'S')";
            if (!Cargo_Datos(busco)) //se pasó del ultimo al ir hacia adelante
            {
                Busco_Ultimo();
            }

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            Busco_Ultimo();

        }

        private void Busco_Ultimo()
        {
            limpio_botones();
            bindingNavigator1.MoveLastItem.Enabled = false;
            bindingNavigator1.MoveNextItem.Enabled = false;
            string busco;
            busco = "SELECT * FROM P_OBTENER_TITULAR(99999,999,'U')";
            Cargo_Datos(busco);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            /*
            buscar frmbuscar = new buscar();
            frmbuscar.ShowDialog(this);
            
            if (vp_nro_soc != 0)
            {
                maskedTextBox1.Text = Convert.ToString(vp_nro_soc);
                maskedTextBox2.Text = Convert.ToString(vp_nro_dep);

                limpio_botones();
                string busco;
                busco = "SELECT * FROM P_OBTENER_TITULAR(@VNRO_SOC,@VNRO_DEP,'E')";
                Cargo_Datos(busco);
            }

            tabControl1.SelectedIndex = vp_tabpage;

            if (vp_tabpage == 2) // FAM
            {
                if (this.listView1.Items.Count == 1)
                {
                    this.listView1.Items[0].Focused = true;
                    this.listView1_Click(listView1, new EventArgs());
                }
            }
            else
            {
                if (vp_tabpage == 3) // ADH
                {
                    if (this.listView2.Items.Count == 1)
                    {
                        this.listView2.Items[0].Focused = true;
                        this.listView2_Click(listView2, new EventArgs());
                    }
                }
            }

            //browseDialog1.ShowDialog();
             */
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            limpio_campos();
        }

        private void TXT_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).Focus();
            ((TextBox)sender).SelectAll();
        }

        private void MSK_Enter(object sender, EventArgs e)
        {
            ((MaskedTextBox)sender).Focus();
            ((MaskedTextBox)sender).SelectAll();
        }


        private void CMB_Enter(object sender, EventArgs e)
        {
            ((ComboBox)sender).Focus();
            ((ComboBox)sender).SelectAll();
        }




        private void TXT_paso(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            isediting = "SI";
            isadding = "NO";
            bindingNavigator1.MoveFirstItem.Enabled = false;
            bindingNavigator1.MoveLastItem.Enabled = false;
            bindingNavigator1.MoveNextItem.Enabled = false;
            bindingNavigator1.MovePreviousItem.Enabled = false;
            cancelar.Enabled = true;
            grabar.Enabled = true;
            buscar.Enabled = false;
            //v_semaforo_baja = "N";

              
            editar.Enabled = false;
            
            nuevo.Enabled = false;
            
            
            tabPage1.Select();  // si edita o es nuevo se queda siempre en titular           

            maskedTextBox1.ReadOnly = true;
            maskedTextBox2.ReadOnly = true;
            maskedTextBox3.ReadOnly = false;
            maskedTextBox4.ReadOnly = false;
            maskedTextBox5.ReadOnly = false;
            maskedTextBox7.ReadOnly = false;
            maskedTextBox6.ReadOnly = false;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            maskedTextbox8.ReadOnly = false;
            textBox3.ReadOnly = false;
            maskedTextBox9.ReadOnly = false;
            maskedTextBox10.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            maskedTextBox11.ReadOnly = false;
            textBox10.ReadOnly = false;
            maskedTextBox12.ReadOnly = false;
            textBox11.ReadOnly = false;
            textBox12.ReadOnly = false;
            maskedTextBox13.ReadOnly = false;
            textBox13.ReadOnly = false;
            textBox14.ReadOnly = false;
            textBox18.ReadOnly = false;
            richTextbox1.ReadOnly = false;
            textBox16.ReadOnly = false;


            comboBox1.PreventDropDown = false;
            comboBox1.BackColor = Color.FromName("white");
            comboBox1.ForeColor = Color.FromName("Black");

            comboBox2.PreventDropDown = false;
            comboBox2.BackColor = Color.FromName("white");
            comboBox2.ForeColor = Color.FromName("Black");

            comboBox3.PreventDropDown = false;
            comboBox3.BackColor = Color.FromName("white");
            comboBox3.ForeColor = Color.FromName("Black");

            comboBox4.PreventDropDown = false;
            comboBox4.BackColor = Color.FromName("white");
            comboBox4.ForeColor = Color.FromName("Black");

            comboBox6.PreventDropDown = false;
            comboBox6.BackColor = Color.FromName("white");
            comboBox6.ForeColor = Color.FromName("Black");

            comboBox7.PreventDropDown = false;
            comboBox7.BackColor = Color.FromName("white");
            comboBox7.ForeColor = Color.FromName("Black");

            comboBox8.PreventDropDown = false;
            comboBox8.BackColor = Color.FromName("white");
            comboBox8.ForeColor = Color.FromName("Black");

            comboBox9.PreventDropDown = false;
            comboBox9.BackColor = Color.FromName("white");
            comboBox9.ForeColor = Color.FromName("Black");

            comboBox10.PreventDropDown = false;
            comboBox10.BackColor = Color.FromName("white");
            comboBox10.ForeColor = Color.FromName("Black");
            
            maskedTextbox26.ReadOnly = false;

            if (VGlobales.vp_role == "SISTEMAS")
            {
                textBox19.ReadOnly = false;
                comboBox5.PreventDropDown = false;
                comboBox5.BackColor = Color.FromName("white");
                comboBox5.ForeColor = Color.FromName("Black");
            }

            maskedTextBox14.ReadOnly = false;
            maskedTextbox16.ReadOnly = false;
            maskedTextbox15.ReadOnly = false;
            maskedTextbox17.ReadOnly = false;
            maskedTextBox18.ReadOnly = false;
            maskedTextbox19.ReadOnly = false;
            maskedTextbox20.ReadOnly = false;

            maskedTextbox21.ReadOnly = false;
            maskedTextbox22.ReadOnly = false;
            textBox15.ReadOnly = false;
            maskedTextbox23.ReadOnly = false;
            maskedTextbox24.ReadOnly = false;
            maskedTextbox24.ReadOnly = false;
            maskedTextbox25.ReadOnly = false;
            maskedTextbox27.ReadOnly = false;


            tabControl1.SelectedIndex = 0;
            ADQUIRIR.Enabled = true;
            //pictureBox1.Image = SOCIOS.Properties.Resources.fotonodisponible;
            maskedTextBox3.Focus();

        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("CONFIRMA CANCELAR LA EDICION?", "ATENCION",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                              MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {

                //errorProvider1.SetError((Control)sender, "");
                errorProvider1.Clear();
                
                /* --
                bindingNavigator1.MoveFirstItem.Enabled = true;
                bindingNavigator1.MoveLastItem.Enabled = true;
                bindingNavigator1.MoveNextItem.Enabled = true;
                bindingNavigator1.MovePreviousItem.Enabled = true;
                 */

                cancelar.Enabled = false;
                grabar.Enabled = false;
                buscar.Enabled = true;
                //editar.Enabled = true;
                //nuevo.Enabled = true;
                Habilitar_Botones();
                maskedTextBox1.ReadOnly = true;
                maskedTextBox2.ReadOnly = true;
                maskedTextBox3.ReadOnly = true;
                maskedTextBox4.ReadOnly = true;
                maskedTextBox5.ReadOnly = true;
                maskedTextBox7.ReadOnly = true;
                maskedTextBox6.ReadOnly = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                maskedTextbox8.ReadOnly = true;
                textBox3.ReadOnly = true;
                maskedTextBox9.ReadOnly = true;
                maskedTextBox10.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;
                maskedTextBox11.ReadOnly = true;
                textBox10.ReadOnly = true;
                maskedTextBox12.ReadOnly = true;
                textBox11.ReadOnly = true;
                textBox12.ReadOnly = true;
                maskedTextBox13.ReadOnly = true;
                textBox13.ReadOnly = true;
                maskedTextBox1.ReadOnly = true;
                maskedTextBox2.ReadOnly = true;
                maskedTextBox3.ReadOnly = true;
                maskedTextBox4.ReadOnly = true;
                maskedTextBox5.ReadOnly = true;
                maskedTextBox7.ReadOnly = true;
                maskedTextBox6.ReadOnly = true;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                maskedTextbox8.ReadOnly = true;
                textBox3.ReadOnly = true;
                maskedTextBox9.ReadOnly = true;
                maskedTextBox10.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;
                maskedTextBox11.ReadOnly = true;
                textBox10.ReadOnly = true;
                maskedTextBox12.ReadOnly = true;
                textBox11.ReadOnly = true;
                textBox12.ReadOnly = true;
                maskedTextBox13.ReadOnly = true;
                textBox13.ReadOnly = true;
                textBox18.ReadOnly = true;
                textBox14.ReadOnly = true;
                richTextbox1.ReadOnly = true;
                maskedTextbox25.ReadOnly = true;
                textBox16.ReadOnly = true;

                comboBox1.PreventDropDown = true;
                comboBox1.BackColor = Color.FromName("Control");
                comboBox1.ForeColor = Color.FromName("Black");

                comboBox2.PreventDropDown = true;
                comboBox2.BackColor = Color.FromName("Control");
                comboBox2.ForeColor = Color.FromName("Black");

                comboBox3.PreventDropDown = true;
                comboBox3.BackColor = Color.FromName("Control");
                comboBox3.ForeColor = Color.FromName("Black");

                comboBox4.PreventDropDown = true;
                comboBox4.BackColor = Color.FromName("Control");
                comboBox4.ForeColor = Color.FromName("Black");

                comboBox6.PreventDropDown = true;
                comboBox6.BackColor = Color.FromName("Control");
                comboBox6.ForeColor = Color.FromName("Black");

                comboBox7.PreventDropDown = true;
                comboBox7.BackColor = Color.FromName("Control");
                comboBox7.ForeColor = Color.FromName("Black");

                comboBox8.PreventDropDown = true;
                comboBox8.BackColor = Color.FromName("Control");
                comboBox8.ForeColor = Color.FromName("Black");

                comboBox9.PreventDropDown = true;
                comboBox9.BackColor = Color.FromName("Control");
                comboBox9.ForeColor = Color.FromName("Black");

                comboBox10.PreventDropDown = true;
                comboBox10.BackColor = Color.FromName("Control");
                comboBox10.ForeColor = Color.FromName("Black");


                maskedTextbox26.ReadOnly = true;

                if (VGlobales.vp_role == "SISTEMAS")
                {
                    textBox19.ReadOnly = true;
                    comboBox5.PreventDropDown = true;
                    comboBox5.BackColor = Color.FromName("Control");
                    comboBox5.ForeColor = Color.FromName("Black");
                }

                //textBox18.ReadOnly = true;

                maskedTextBox14.ReadOnly = true;
                maskedTextbox16.ReadOnly = true;
                maskedTextbox15.ReadOnly = true;
                maskedTextbox17.ReadOnly = true;
                maskedTextBox18.ReadOnly = true;
                maskedTextbox19.ReadOnly = true;
                maskedTextbox20.ReadOnly = true;

                maskedTextbox21.ReadOnly = true;
                maskedTextbox22.ReadOnly = true;
                textBox15.ReadOnly = true;
                maskedTextbox23.ReadOnly = true;
                maskedTextbox24.ReadOnly = true;
                maskedTextbox25.ReadOnly = true;

                maskedTextBox2.ReadOnly = true;
                maskedTextbox27.ReadOnly = true;



                ADQUIRIR.Enabled = false;

                isediting = "NO";
                isadding = "NO";


                string busco;
                busco = "SELECT * FROM P_OBTENER_TITULAR(@VNRO_SOC,@VNRO_DEP,'E')";
                Cargo_Datos(busco);
                //pictureBox1.Image = SOCIOS.Properties.Resources.fotonodisponible;
            }

        }

        private void ADQUIRIR_Click(object sender, EventArgs e)
        {
            string nombreFoto = maskedTextBox1.Text.Trim().PadLeft(5, '0');
            string sfilename = "";
            string spath = "";
            OpenFileDialog opn = new OpenFileDialog();
            //opn.FileName = nombreFoto + "-0";    OJO que hay que utilizar los botones
            opn.Filter = "JPEG|*.jpg|GIF|*.gif";
            opn.ShowDialog();

            if (opn.FileName.Length > 0)
            {
                sfilename = System.IO.Path.GetFileName(opn.FileName);
                spath = System.IO.Path.GetDirectoryName(opn.FileName);

                //MessageBox.Show(sfilename + "  " + spath);

            
                if (sfilename.Substring(0, 5) == nombreFoto && sfilename.Substring(5, 2) == "-0")
                {
                    Bitmap IMG = new Bitmap(opn.FileName);
                    pictureBox1.Image = resizeImage(IMG, 83, 72);
                }
                else
                {
                    MessageBox.Show("LA FOTO SELECCIONADA NO CORRESPENDE AL TITULAR", "ATENCION" , MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    ADQUIRIR_Click(ADQUIRIR, new EventArgs());
                }

            }
        }



        private void nuevo_Click(object sender, EventArgs e)
        {
            isediting = "NO";
            isadding = "SI";

            bindingNavigator1.MoveFirstItem.Enabled = false;
            bindingNavigator1.MoveLastItem.Enabled = false;
            bindingNavigator1.MoveNextItem.Enabled = false;
            bindingNavigator1.MovePreviousItem.Enabled = false;
            cancelar.Enabled = true;
            grabar.Enabled = true;
            buscar.Enabled = false;
            editar.Enabled = false;
            nuevo.Enabled = false;
            tabPage1.Select();  // si edita o es nuevo se queda siempre en titular
            
            maskedTextBox1.ReadOnly = true;
            maskedTextBox2.ReadOnly = false;
          
            maskedTextBox3.ReadOnly = false;
            maskedTextBox4.ReadOnly = false;
            maskedTextBox5.ReadOnly = false;
            maskedTextBox7.ReadOnly = false;
            maskedTextBox6.ReadOnly = false;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            maskedTextbox8.ReadOnly = false;
            textBox3.ReadOnly = false;
            maskedTextBox9.ReadOnly = false;
            maskedTextBox10.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            maskedTextBox11.ReadOnly = false;
            textBox10.ReadOnly = false;
            maskedTextBox12.ReadOnly = false;
            textBox11.ReadOnly = false;
            textBox12.ReadOnly = false;
            maskedTextBox13.ReadOnly = false;
            textBox13.ReadOnly = false;
            textBox14.ReadOnly = false;
            textBox18.ReadOnly = false;
            richTextbox1.ReadOnly = false;
            maskedTextbox25.ReadOnly = false;
            maskedTextBox2.ReadOnly = false;
            maskedTextbox27.ReadOnly = false;
            textBox16.ReadOnly = false;

            comboBox1.PreventDropDown = false;
            comboBox1.BackColor = Color.FromName("white");
            comboBox1.ForeColor = Color.FromName("Black");

            comboBox2.PreventDropDown = false;
            comboBox2.BackColor = Color.FromName("white");
            comboBox2.ForeColor = Color.FromName("Black");

            comboBox3.PreventDropDown = false;
            comboBox3.BackColor = Color.FromName("white");
            comboBox3.ForeColor = Color.FromName("Black");

            comboBox4.PreventDropDown = false;
            comboBox4.BackColor = Color.FromName("white");
            comboBox4.ForeColor = Color.FromName("Black");

            comboBox6.PreventDropDown = false;
            comboBox6.BackColor = Color.FromName("white");
            comboBox6.ForeColor = Color.FromName("Black");

            comboBox7.PreventDropDown = false;
            comboBox7.BackColor = Color.FromName("white");
            comboBox7.ForeColor = Color.FromName("Black");

            comboBox8.PreventDropDown = false;
            comboBox8.BackColor = Color.FromName("white");
            comboBox8.ForeColor = Color.FromName("Black");

            comboBox9.PreventDropDown = false;
            comboBox9.BackColor = Color.FromName("white");
            comboBox9.ForeColor = Color.FromName("Black");

            comboBox10.PreventDropDown = false;
            comboBox10.BackColor = Color.FromName("white");
            comboBox10.ForeColor = Color.FromName("Black");
           
            maskedTextbox26.ReadOnly = false;

            if (VGlobales.vp_role == "SISTEMAS")
            {
                textBox19.ReadOnly = false;
                comboBox5.PreventDropDown = false;
                comboBox5.BackColor = Color.FromName("white");
                comboBox5.ForeColor = Color.FromName("Black");
            }

            //textBox18.ReadOnly = false;

            maskedTextBox14.ReadOnly = false;
            maskedTextbox16.ReadOnly = false;
            maskedTextbox15.ReadOnly = false;
            maskedTextbox17.ReadOnly = false;
            maskedTextBox18.ReadOnly = false;
            maskedTextbox19.ReadOnly = false;
            maskedTextbox20.ReadOnly = false;

            maskedTextbox21.ReadOnly = false;
            maskedTextbox22.ReadOnly = false;
            textBox15.ReadOnly = false;
            maskedTextbox23.ReadOnly = false;
            maskedTextbox24.ReadOnly = false;
            maskedTextbox24.ReadOnly = false;
            maskedTextbox25.ReadOnly = false;

            maskedTextBox1.Text = "0";
            maskedTextBox2.Text = "994";
            maskedTextBox3.Text = "0";
            maskedTextBox4.Text = "0";
            maskedTextBox5.Text = "0";
            maskedTextBox7.Text = "0";
            maskedTextBox6.Text = "0";
            textBox1.Text = " ";
            textBox2.Text = " ";
            maskedTextbox8.Text = " ";
            textBox3.Text = " ";
            maskedTextBox9.Text = "0";
            maskedTextBox10.Text = "0";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
            textBox8.Text = " ";
            textBox9.Text = " ";
            maskedTextBox11.Text = "0";
            textBox10.Text = " ";
            maskedTextBox12.Text = "0";
            textBox11.Text = " ";
            textBox12.Text = " ";
            maskedTextBox13.Text = "0";
            maskedTextBox14.Text = "0";

            textBox13.Text = " ";
            textBox19.Text = "0";
            textBox15.Clear();
            //textBox18.Clear();
            pictureBox1.Image = SOCIOS.Properties.Resources.fotonodisponible;
            pictureBox2.Image = SOCIOS.Properties.Resources.fotonodisponible;

            maskedTextbox21.Text = " ";
            maskedTextbox26.Text = " ";
            maskedTextbox25.Text = " ";
            maskedTextbox15.Text = " ";
            maskedTextbox16.Text = " ";
            maskedTextbox17.Text = " ";
            maskedTextBox18.Text = "0";
            maskedTextbox19.Text = " ";
            maskedTextbox22.Text = " ";
            maskedTextbox23.Text = " ";
            maskedTextbox24.Text = " ";


            textBox18.Text = " ";
            textBox14.Text = " ";
            richTextbox1.Text = "";

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox7.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;
            comboBox9.SelectedIndex = -1;
            comboBox10.SelectedIndex = -1;
           
 


            tabControl1.SelectedIndex = 0;
            ADQUIRIR.Enabled = true;

            // se pone fecha del día en los siguientes campos
            // Fecha de Alta Circulo    
            maskedTextbox21.Text = DateTime.Today.Date.Day.ToString().PadLeft(2, '0') +
                                   DateTime.Today.Date.Month.ToString().PadLeft(2, '0') +
                                   DateTime.Today.Date.Year.ToString();
            //maskedTextbox24.Text = DateTime.Today.Date.Day.ToString().PadLeft(2, '0') +
            //                      DateTime.Today.Date.Month.ToString().PadLeft(2, '0') +
            //                      DateTime.Today.Date.Year.ToString();
            //Gimnasio
            textBox14.Text = "N"; 

            listView1.Items.Clear();
            maskedTextBox1.Focus();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (VGlobales.vp_ntp == false)
            {
                DialogResult dr = MessageBox.Show("CONFIRMA CERRAR ESTA PANTALLA?", "ATENCION",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1);


                if (dr == DialogResult.Yes)
                {
                    if (cancelar.Enabled == true)
                    {
                        MessageBox.Show("DEBE CONFIRMAR O CANCELAR LOS CAMBIOS, RECUERDE QUE ESTA EDITANDO",
                               "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        e.Cancel = true;
                    }
                    else
                    {
                        //File.Delete("C:\\TEMP.RTF");
                        e.Cancel = false;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }

        }


        private DataSet lleno_combos()
        {
            string connectionString;
            string string_combo;
            DataSet ds1 = new DataSet();
            Datos_ini ini2 = new Datos_ini();
            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini2.Servidor;
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



                    //Carga COMBOBOX1

                    DataTable dt1 = new DataTable("CATEGORIAS");
                    dt1.Columns.Add("codigo", typeof(string));
                    dt1.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt1);



                    // llenamos las categorias del socio.-
                    string_combo = "SELECT SUBSTR(CODIGO,2,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('CA')";
                    FbCommand cmd = new FbCommand(string_combo, connection, transaction);
                    FbDataReader reader3 = cmd.ExecuteReader();


                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();

                    comboBox1.DisplayMember = "descrip";
                    comboBox1.ValueMember = "codigo";
                    comboBox1.DataSource = dt1;



                    //Carga COMBOBOX2

                    DataTable dt2 = new DataTable("DD");
                    dt2.Columns.Add("codigo", typeof(string));
                    dt2.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt2);

                    // llenamos datos de domicilio
                    cmd.CommandText = "SELECT SUBSTR(CODIGO,4,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('DD')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt2.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();


                    comboBox2.DisplayMember = "descrip";
                    comboBox2.ValueMember = "codigo";
                    comboBox2.DataSource = dt2;


                    //Carga COMBOBOX5


                    DataTable dt5 = new DataTable("AO");
                    dt5.Columns.Add("codigo", typeof(string));
                    dt5.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt5);

                    // llenamos datos confidenciales
                    cmd.CommandText = "SELECT '0'||SUBSTR(CODIGO,1,6) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('A0')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();


                    while (reader3.Read())
                    {
                        dt5.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();


                    comboBox5.DisplayMember = "descrip";
                    comboBox5.ValueMember = "codigo";
                    comboBox5.DataSource = dt5;


                    //Carga COMBOBOX3

                    DataTable dt3 = new DataTable("TC");
                    dt3.Columns.Add("codigo", typeof(string));
                    dt3.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt3);


                    // llenamos los Tipos de Carnet.-
                    cmd.CommandText = "SELECT SUBSTR(CODIGO,4,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('TC')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();


                    while (reader3.Read())
                    {
                        dt3.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();

                    comboBox3.DisplayMember = "descrip";
                    comboBox3.ValueMember = "codigo";
                    comboBox3.DataSource = dt3;


                    //Carga COMBOBOX4

                    DataTable dt4 = new DataTable("BC");
                    dt4.Columns.Add("codigo", typeof(string));
                    dt4.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt4);


                    // llenamos los mot. Baja Circulo.-
                    cmd.CommandText = "SELECT SUBSTR(CODIGO,4,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('BC')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();


                    while (reader3.Read())
                    {
                        dt4.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();

                    comboBox4.DisplayMember = "descrip";
                    comboBox4.ValueMember = "codigo";
                    comboBox4.DataSource = dt4;


                    //Carga COMBOBOX6

                    DataTable dt6 = new DataTable("BP");
                    dt6.Columns.Add("codigo", typeof(string));
                    dt6.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt6);


                    // llenamos los Motivos Baja Policial.-
                    cmd.CommandText = "SELECT SUBSTR(CODIGO,4,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('BP')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();


                    while (reader3.Read())
                    {
                        dt6.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();

                    comboBox6.DisplayMember = "descrip";
                    comboBox6.ValueMember = "codigo";
                    comboBox6.DataSource = dt6;



                    //Carga COMBOBOX8

                    DataTable dt8 = new DataTable("TD");
                    dt8.Columns.Add("codigo", typeof(string));
                    dt8.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt8);


                    // llenamos los Tipos de documentos.-
                    cmd.CommandText = "SELECT SUBSTR(CODIGO,4,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('TD')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();


                    while (reader3.Read())
                    {
                        dt8.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();

                    comboBox8.DisplayMember = "descrip";
                    comboBox8.ValueMember = "codigo";
                    comboBox8.DataSource = dt8;


                    //Carga COMBOBOX7

                    DataTable dt7 = new DataTable("PR");
                    dt7.Columns.Add("codigo", typeof(string));
                    dt7.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt7);


                    // llenamos las provincias.-
                    cmd.CommandText = "SELECT SUBSTR(CODIGO,3,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('PR')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();


                    while (reader3.Read())
                    {
                        dt7.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();

                    comboBox7.DisplayMember = "descrip";
                    comboBox7.ValueMember = "codigo";
                    comboBox7.DataSource = dt7;


                    //Carga COMBO JERARQUIA
                    DataTable dt14 = new DataTable("JE");
                    dt14.Columns.Add("codigo", typeof(string));
                    dt14.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt14);

                    // llenamos los mot. Jerarquia.-
                    cmd.CommandText = "SELECT SUBSTR(CODIGO,1,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('JE')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();


                    while (reader3.Read())
                    {
                        dt14.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();

                    comboBox9.DisplayMember = "descrip";
                    comboBox9.ValueMember = "codigo";
                    comboBox9.DataSource = dt14;


                    //Carga COMBO DESTINO 
                    DataTable dt15 = new DataTable("DE");
                    dt15.Columns.Add("codigo", typeof(string));
                    dt15.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt15);

                    // llenamos los mot. Destinos.-
                    cmd.CommandText = "SELECT SUBSTR(CODIGO,1,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('DE')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt15.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();

                    comboBox10.DisplayMember = "descrip";
                    comboBox10.ValueMember = "codigo";
                    comboBox10.DataSource = dt15;

                    //=====================================================
                    // Esto es para las otras pantallas por eso no pone el DisplayMember y el ValueMember (se ponen despues)
                    //=====================================================

                    //Carga Descripcion BARRA Familiar

                    DataTable dt9 = new DataTable("BA");
                    dt9.Columns.Add("codigo", typeof(string));
                    dt9.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt9);


                    // llenamos los Tipos de documentos.-
                    cmd.CommandText = "SELECT SUBSTR(CODIGO,4,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('BA')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();


                    while (reader3.Read())
                    {
                        dt9.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();


                    //Carga COMBO Tipo Carnet para Fam y Adh

                    DataTable dt10 = new DataTable("TF");
                    dt10.Columns.Add("codigo", typeof(string));
                    dt10.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt10);


                    // llenamos los Tipos de Carnet.-
                    cmd.CommandText = "SELECT SUBSTR(CODIGO,4,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('TF')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();


                    while (reader3.Read())
                    {
                        dt10.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();


                    //Carga COMBOBO mot. baja Fam 

                    DataTable dt11 = new DataTable("BF");
                    dt11.Columns.Add("codigo", typeof(string));
                    dt11.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt11);


                    // llenamos los mot. Baja Circulo.-
                    cmd.CommandText = "SELECT SUBSTR(CODIGO,4,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('BF')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();


                    while (reader3.Read())
                    {
                        dt11.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();


                    //Carga COMBOBO mot. baja ADH 

                    DataTable dt12 = new DataTable("BH");
                    dt12.Columns.Add("codigo", typeof(string));
                    dt12.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt12);


                    // llenamos los mot. Baja Circulo.-
                    cmd.CommandText = "SELECT SUBSTR(CODIGO,4,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('BH')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();


                    while (reader3.Read())
                    {
                        dt12.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();

                    //Carga Descripcion BARRA Adherente

                    DataTable dt13 = new DataTable("BADH");
                    dt13.Columns.Add("codigo", typeof(string));
                    dt13.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt13);

                    // lo lleno a mano pues no hay tabla

                    dt13.Rows.Add("0000", "ADHERENTE TITULAR");
                    dt13.Rows.Add("0001", "ESPOSO/A");
                    dt13.Rows.Add("0002", "HIJO/S");
 
                    // devuelvo el Data Set con todas las tablas 
                    return ds1;
                }

            }
            catch
            {
                //System.Windows.Forms.MessageBox.Show(e.ToString());
                return ds1;
            }

        }


        private void grabar_Click(object sender, EventArgs e)
        {

            
            string connectionString;
            string vcomando;
            string vcomando99;
            string cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(1)"; // obtiene numerador de Titulares
            int vnro_socio = 0;
            int vp07 = 0;
            int vp08 = 0;
            Datos_ini ini2 = new Datos_ini();

            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini2.Servidor;
            cs.Database = ini2.Ubicacion;
            cs.UserID = VGlobales.vp_username;
            cs.Password = VGlobales.vp_password;
            cs.Role = VGlobales.vp_role;
            cs.Dialect = 3;
            connectionString = cs.ToString();
            FbConnection connection = new FbConnection(connectionString);
            connection.Open();
            FbTransaction transaction = connection.BeginTransaction();

            if (isediting == "SI" && isadding == "NO")
                vcomando = "P_MODIFICA_TITULAR ";
            else
            {
                vcomando = "P_ALTA_TITULAR ";
                FbCommand tNum = new FbCommand(cmd_numerador, connection, transaction);

                vnro_socio = (int)tNum.ExecuteScalar();
                maskedTextBox1.Text = vnro_socio.ToString();

                vp_nro_soc = vnro_socio;
                vp_nro_dep = System.Convert.ToInt32(maskedTextBox2.Text);


                //MessageBox.Show(vnro_socio.ToString());
            }

            
            FbCommand cmd = new FbCommand(vcomando, connection, transaction);

            try
            {
                using (connection)
                {

                    cmd.CommandText = vcomando;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new FbParameter("@P01", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P03", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P05", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P06", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P07", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P08", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P09", FbDbType.Char, 40));
                    cmd.Parameters.Add(new FbParameter("@P10", FbDbType.Char, 60));
                    cmd.Parameters.Add(new FbParameter("@P75", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P14", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P16", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P17", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P18", FbDbType.Char, 1));
                    cmd.Parameters.Add(new FbParameter("@P19", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P20", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P21", FbDbType.Char, 40));
                    cmd.Parameters.Add(new FbParameter("@P22", FbDbType.Char, 5));
                    cmd.Parameters.Add(new FbParameter("@P23", FbDbType.Char, 2));
                    cmd.Parameters.Add(new FbParameter("@P24", FbDbType.Char, 3));
                    cmd.Parameters.Add(new FbParameter("@P25", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P26", FbDbType.Char, 60));
                    cmd.Parameters.Add(new FbParameter("@P27", FbDbType.Char, 2));
                    cmd.Parameters.Add(new FbParameter("@P28", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P29", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P30", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P31", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P32", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P33", FbDbType.Char, 1));
                    cmd.Parameters.Add(new FbParameter("@P34", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P35", FbDbType.Char, 1));
                    cmd.Parameters.Add(new FbParameter("@P36", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P37", FbDbType.Char, 3));
                    cmd.Parameters.Add(new FbParameter("@P38", FbDbType.Char, 3));
                    cmd.Parameters.Add(new FbParameter("@P39", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P40", FbDbType.Char, 1));
                    cmd.Parameters.Add(new FbParameter("@P41", FbDbType.Char, 5));
                    cmd.Parameters.Add(new FbParameter("@P43", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P44", FbDbType.Char, 1));
                    cmd.Parameters.Add(new FbParameter("@P47", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P48", FbDbType.Char, 1));
                    cmd.Parameters.Add(new FbParameter("@P49", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P50", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P51", FbDbType.Char, 1));
                    cmd.Parameters.Add(new FbParameter("@P52", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P53", FbDbType.Char, 1));
                    cmd.Parameters.Add(new FbParameter("@P54", FbDbType.Char, 4));
                    cmd.Parameters.Add(new FbParameter("@P55", FbDbType.Char, 4));
                    cmd.Parameters.Add(new FbParameter("@P65", FbDbType.Numeric, 8));
                    cmd.Parameters.Add(new FbParameter("@P67", FbDbType.Binary));
                    cmd.Parameters.Add(new FbParameter("@P71", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P72", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P73", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P74", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@P90", FbDbType.Binary));
                    cmd.Parameters.Add(new FbParameter("@P91", FbDbType.Binary));
                    cmd.Parameters.Add(new FbParameter("@P92", FbDbType.Char, 3));
                    cmd.Parameters.Add(new FbParameter("@P93", FbDbType.Char, 150));
                    cmd.Parameters.Add(new FbParameter("@P94", FbDbType.Char, 8));
                    cmd.Parameters.Add(new FbParameter("@P95", FbDbType.Char, 3));
                    cmd.Parameters.Add(new FbParameter("@P96", FbDbType.Char, 8));

                   
                    
                    cmd.Parameters["@P01"].Value = (maskedTextBox7.Text == "" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox7.Text)) );
                    cmd.Parameters["@P03"].Value = (maskedTextBox6.Text == "__" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox6.Text)) );
                    
                    
                    
                    //cmd.Parameters["@P05"].Value = (maskedTextBox6.Text == "" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox6.Text)) );


                    vp07 = (maskedTextBox4.Text == "______" ? 0 : (int)(System.Convert.ToInt32(maskedTextBox4.Text)));
                    vp08 = (maskedTextBox5.Text == "__" ? 0 : (int)(System.Convert.ToInt32(maskedTextBox5.Text)));

                    cmd.Parameters["@P07"].Value = (maskedTextBox4.Text == "______" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox4.Text)));
                    cmd.Parameters["@P08"].Value = (maskedTextBox5.Text == "__" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox5.Text)));



                    if ((vp07 == 0) && (vp08 == 0))
                        cmd.Parameters["@P05"].Value = 0;
                    else
                        cmd.Parameters["@P05"].Value = 2;
                    
                    cmd.Parameters["@P06"].Value = (maskedTextBox3.Text == "__" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox3.Text)) );
                    cmd.Parameters["@P09"].Value = textBox1.Text;
                    cmd.Parameters["@P10"].Value = textBox2.Text;
                    cmd.Parameters["@P75"].Value = (maskedTextBox10.Text == "" ? 0 :(int?)(System.Convert.ToInt32(maskedTextBox10.Text)) );
                    cmd.Parameters["@P14"].Value = (maskedTextBox14.Text == "_____" ? 0 : (System.Convert.ToInt32(maskedTextBox14.Text)) );

                    if (maskedTextbox15.Text == " " || maskedTextbox15.Text.Length == 0)
                        cmd.Parameters["@P16"].Value = null;
                    else
                        cmd.Parameters["@P16"].Value = maskedTextbox15.Text;

                    if (maskedTextbox21.Text == " " || maskedTextbox21.Text.Length == 0)
                        cmd.Parameters["@P17"].Value = null;
                    else
                        cmd.Parameters["@P17"].Value = maskedTextbox21.Text;

                    cmd.Parameters["@P18"].Value = (comboBox8.SelectedValue == null ? "" : comboBox8.SelectedValue.ToString());
                   
                    
                    
                    cmd.Parameters["@P19"].Value = (maskedTextBox9.Text == "_________" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox9.Text)));

                    if (maskedTextbox8.Text == " " || maskedTextbox8.Text.Length == 0)
                        cmd.Parameters["@P20"].Value = null;
                    else
                        cmd.Parameters["@P20"].Value = maskedTextbox8.Text;

                    cmd.Parameters["@P21"].Value = textBox4.Text;
                    cmd.Parameters["@P22"].Value = textBox5.Text;
                    cmd.Parameters["@P23"].Value = textBox6.Text;
                    cmd.Parameters["@P24"].Value = textBox7.Text;
                    cmd.Parameters["@P25"].Value = textBox9.Text;
                    cmd.Parameters["@P26"].Value = textBox8.Text;

                    cmd.Parameters["@P92"].Value = textBox18.Text;
                   
                    cmd.Parameters["@P27"].Value = (comboBox7.SelectedValue == null ? "" : comboBox7.SelectedValue.ToString());
                    cmd.Parameters["@P28"].Value = (maskedTextBox11.Text == "____" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox11.Text)) );
                    cmd.Parameters["@P29"].Value = textBox10.Text;
                    cmd.Parameters["@P30"].Value = (maskedTextBox12.Text == "____" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox12.Text)) );
                    cmd.Parameters["@P31"].Value = textBox11.Text;
                    cmd.Parameters["@P44"].Value = textBox14.Text;

                    if (maskedTextbox17.Text == " " || maskedTextbox17.Text.Length == 0)
                        cmd.Parameters["@P32"].Value = null;
                    else
                        cmd.Parameters["@P32"].Value = maskedTextbox17.Text;

                    cmd.Parameters["@P33"].Value = (comboBox6.SelectedValue == null ? "" : comboBox6.SelectedValue.ToString());
                    
                    //if (maskedTextbox25.Text == " " || maskedTextbox25.Text.Length == 0)
                    //    cmd.Parameters["@P33"].Value = null;
                    //else
                    //    cmd.Parameters["@P33"].Value = maskedTextbox25.Text;


                    if (maskedTextbox25.Text == " " || maskedTextbox25.Text.Length == 0)
                        cmd.Parameters["@P34"].Value = null;
                    else
                        cmd.Parameters["@P34"].Value = maskedTextbox25.Text;

                    cmd.Parameters["@P35"].Value = (comboBox4.SelectedValue == null ? "" : comboBox4.SelectedValue.ToString());

                    if (maskedTextbox23.Text == " " || maskedTextbox23.Text.Length == 0)
                        cmd.Parameters["@P36"].Value = null;
                    else
                        cmd.Parameters["@P36"].Value = maskedTextbox23.Text;

                    cmd.Parameters["@P37"].Value = textBox15.Text;
                   
                    cmd.Parameters["@P38"].Value = (comboBox1.SelectedValue == null ? "" : comboBox1.SelectedValue.ToString());

                    if (maskedTextbox26.Text == " " || maskedTextbox26.Text.Length == 0)
                        cmd.Parameters["@P39"].Value = null;
                    else
                        cmd.Parameters["@P39"].Value = maskedTextbox26.Text;

                    cmd.Parameters["@P40"].Value = textBox19.Text;
                    cmd.Parameters["@P41"].Value = (comboBox5.SelectedValue == null ? "" : comboBox5.SelectedValue.ToString());

                    if (maskedTextbox22.Text == " " || maskedTextbox22.Text.Length == 0)
                        cmd.Parameters["@P43"].Value = null;
                    else
                        cmd.Parameters["@P43"].Value = maskedTextbox22.Text;

                    if (maskedTextbox24.Text == " " || maskedTextbox24.Text.Length == 0)
                        cmd.Parameters["@P47"].Value = null;
                    else
                        cmd.Parameters["@P47"].Value = maskedTextbox24.Text;


                    cmd.Parameters["@P48"].Value = (comboBox3.SelectedValue == null ? "" : comboBox3.SelectedValue.ToString());
                    cmd.Parameters["@P49"].Value = (maskedTextBox18.Text == "_____" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox18.Text)) );

                    cmd.Parameters["@P33"].Value = (comboBox6.SelectedValue == null ? "" : comboBox6.SelectedValue.ToString());


                    cmd.Parameters["@P93"].Value = textBox12.Text ;


                    if (maskedTextbox19.Text == " " || maskedTextbox19.Text.Length == 0)
                        cmd.Parameters["@P50"].Value = null;
                    else
                        cmd.Parameters["@P50"].Value = maskedTextbox19.Text;

                    cmd.Parameters["@P51"].Value = (comboBox2.SelectedValue == null ? "" : comboBox2.SelectedValue.ToString());

                    if (maskedTextbox16.Text == " " || maskedTextbox16.Text.Length == 0)
                        cmd.Parameters["@P52"].Value = null;
                    else
                        cmd.Parameters["@P52"].Value = maskedTextbox16.Text;

                    cmd.Parameters["@P53"].Value = textBox3.Text;


                    cmd.Parameters["@P54"].Value = (comboBox9.SelectedValue == null ? "000Z" : comboBox9.SelectedValue.ToString());
                    cmd.Parameters["@P55"].Value = (comboBox10.SelectedValue == null ? "" : comboBox10.SelectedValue.ToString());
                    //maskedTextBox13.Text = "0";
                    cmd.Parameters["@P65"].Value = 0;
                    cmd.Parameters["@P67"].Value = imageToByteArray(pictureBox1.Image);
                    cmd.Parameters["@P71"].Value = (maskedTextBox13.Text == "" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox13.Text)));
                    cmd.Parameters["@P72"].Value = textBox13.Text;
                    cmd.Parameters["@P73"].Value = vp_nro_soc;
                    cmd.Parameters["@P74"].Value = vp_nro_dep;
                    cmd.Parameters["@P90"].Value = imageToByteArray(pictureBox2.Image);
                    //cmd.Parameters["@P70"].Value = imageToByteArray(richTextbox1.);
                    //cmd.Parameters["@P91"].Value = richTextbox1.Rtf;


                    if (maskedTextbox27.Text == " " || maskedTextbox27.Text.Length == 0)
                        cmd.Parameters["@P94"].Value = null;
                    else
                        cmd.Parameters["@P94"].Value = maskedTextbox27.Text;

                    cmd.Parameters["@P95"].Value = textBox16.Text;
                    
                    if (maskedTextbox20.Text == " " || maskedTextbox20.Text.Length == 0)
                        cmd.Parameters["@P96"].Value = null;
                    else
                        cmd.Parameters["@P96"].Value = maskedTextbox20.Text;
                    richTextbox1.SaveFile(@"TEMP.RTF",RichTextBoxStreamType.RichText);
                    FileStream stream = new FileStream(@"TEMP.RTF", FileMode.Open, FileAccess.Read);
                    int size = Convert.ToInt32(stream.Length);
                    Byte[] rtf = new Byte[size];
                    stream.Read(rtf, 0, size);
                    cmd.Parameters["@P91"].Value = rtf;
                    stream.Dispose();

                    cmd.ExecuteNonQuery();



                    if ((maskedTextbox25.Text != " " || maskedTextbox25.Text.Length > 0) && (v_semaforo_baja == "S"))
                    {
                        DialogResult dr = MessageBox.Show("CONFIRMA LA BAJA A FAMILIARES Y ADHERENTES?", "ATENCION",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                          MessageBoxDefaultButton.Button1);
                        if (dr == DialogResult.Yes)
                        {
                            vcomando99 = "P_BAJA_TIT_FAM_ADH";
                            FbCommand cmd2 = new FbCommand(vcomando99, connection, transaction);
                            cmd2.CommandText = vcomando99;
                            cmd2.Connection = connection;
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Add(new FbParameter("@V_ID_TITULAR", FbDbType.Integer));
                            cmd2.Parameters.Add(new FbParameter("@VF_BAJCI", FbDbType.Char, 8));
                            int id_titular99 = (Socios.vp_nro_soc * 1000) + Socios.vp_nro_dep;
                            cmd2.Parameters["@V_ID_TITULAR"].Value = id_titular99;
                            cmd2.Parameters["@VF_BAJCI"].Value = maskedTextbox25.Text;
                            cmd2.ExecuteNonQuery();
                        }
                    }

                    v_semaforo_baja = "N";

                    transaction.Commit();

                    connection.Dispose();

                    MessageBox.Show("OPERACION EFECTUADA EXISTOSAMENTE",
                                        vcomando.Substring(2, 6), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fin_alta();
                
                }
            }
            catch (FbException ex)
            {
                transaction.Rollback();
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                Mails1 mensaje = new Mails1();
                mensaje.Enviar_Mail_Error(ex.ToString());
            }


        }

        private void fin_alta()
        {
            errorProvider1.Clear();
            /*
            bindingNavigator1.MoveFirstItem.Enabled = true;
            bindingNavigator1.MoveLastItem.Enabled = true;
            bindingNavigator1.MoveNextItem.Enabled = true;
            bindingNavigator1.MovePreviousItem.Enabled = true;
             */
            cancelar.Enabled = false;
            grabar.Enabled = false;
            buscar.Enabled = true;
            //editar.Enabled = true;
            //nuevo.Enabled = true;
            Habilitar_Botones();
            maskedTextBox1.ReadOnly = true;
            maskedTextBox2.ReadOnly = true;
            maskedTextBox3.ReadOnly = true;
            maskedTextBox4.ReadOnly = true;
            maskedTextBox5.ReadOnly = true;
            maskedTextBox7.ReadOnly = true;
            maskedTextBox6.ReadOnly = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            maskedTextbox8.ReadOnly = true;
            textBox3.ReadOnly = true;
            maskedTextBox9.ReadOnly = true;
            maskedTextBox10.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            maskedTextBox11.ReadOnly = true;
            textBox10.ReadOnly = true;
            maskedTextBox12.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;
            maskedTextBox13.ReadOnly = true;
            textBox13.ReadOnly = true;
            maskedTextBox1.ReadOnly = true;
            maskedTextBox2.ReadOnly = true;
            maskedTextBox3.ReadOnly = true;
            maskedTextBox4.ReadOnly = true;
            maskedTextBox5.ReadOnly = true;
            maskedTextBox7.ReadOnly = true;
            maskedTextBox6.ReadOnly = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            maskedTextbox8.ReadOnly = true;
            textBox3.ReadOnly = true;
            maskedTextBox9.ReadOnly = true;
            maskedTextBox10.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            maskedTextBox11.ReadOnly = true;
            textBox10.ReadOnly = true;
            maskedTextBox12.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;
            maskedTextBox13.ReadOnly = true;
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;
            textBox18.ReadOnly = true;
            richTextbox1.ReadOnly = true;
            maskedTextbox27.ReadOnly = true;
            maskedTextbox25.ReadOnly = true;
            textBox16.ReadOnly = true;

            comboBox1.PreventDropDown = true;
            comboBox1.BackColor = Color.FromName("Control");
            comboBox1.ForeColor = Color.FromName("Black");

            comboBox2.PreventDropDown = true;
            comboBox2.BackColor = Color.FromName("Control");
            comboBox2.ForeColor = Color.FromName("Black");

            comboBox3.PreventDropDown = true;
            comboBox3.BackColor = Color.FromName("Control");
            comboBox3.ForeColor = Color.FromName("Black");

            comboBox4.PreventDropDown = true;
            comboBox4.BackColor = Color.FromName("Control");
            comboBox4.ForeColor = Color.FromName("Black");

            comboBox6.PreventDropDown = true;
            comboBox6.BackColor = Color.FromName("Control");
            comboBox6.ForeColor = Color.FromName("Black");

            comboBox7.PreventDropDown = true;
            comboBox7.BackColor = Color.FromName("Control");
            comboBox7.ForeColor = Color.FromName("Black");

            comboBox8.PreventDropDown = true;
            comboBox8.BackColor = Color.FromName("Control");
            comboBox8.ForeColor = Color.FromName("Black");

            comboBox9.PreventDropDown = true;
            comboBox9.BackColor = Color.FromName("Control");
            comboBox9.ForeColor = Color.FromName("Black");

            comboBox10.PreventDropDown = true;
            comboBox10.BackColor = Color.FromName("Control");
            comboBox10.ForeColor = Color.FromName("Black");


            maskedTextbox26.ReadOnly = true;

            if (VGlobales.vp_role == "SISTEMAS")
            {
                textBox19.ReadOnly = true;
                comboBox5.PreventDropDown = true;
                comboBox5.BackColor = Color.FromName("Control");
                comboBox5.ForeColor = Color.FromName("Black");
            }

            //textBox18.ReadOnly = true;

            maskedTextBox14.ReadOnly = true;
            maskedTextbox16.ReadOnly = true;
            maskedTextbox15.ReadOnly = true;
            maskedTextbox17.ReadOnly = true;
            maskedTextBox18.ReadOnly = true;
            maskedTextbox19.ReadOnly = true;
            maskedTextbox20.ReadOnly = true;

            maskedTextbox21.ReadOnly = true;
            maskedTextbox22.ReadOnly = true;
            textBox15.ReadOnly = true;
            maskedTextbox23.ReadOnly = true;
            maskedTextbox24.ReadOnly = true;
            maskedTextbox25.ReadOnly = true;
            ADQUIRIR.Enabled = false;

            isediting = "NO";
            isadding = "NO";
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            vp_barra = (int)(System.Convert.ToInt32(listView1.FocusedItem.Index));
            VGlobales.vp_cod_bar = string.Empty;

            using (Familiares frmFAM = new Familiares())
            {
                frmFAM.ShowDialog(this);
            }

            Cargar_Solapa_Fam();
        }


        private void listView2_Click(object sender, EventArgs e)
        {
            vp_nro_adh = (int)(System.Convert.ToInt32(listView2.FocusedItem.Index));
            VGlobales.vp_cod_bar = string.Empty;

            using (Adherentes frmADH = new Adherentes())
            {
                frmADH.ShowDialog(this);
            }

            Cargar_Solapa_Adh();
        }

        private void buttonADH_Click(object sender, EventArgs e)
        {
            vp_nro_adh = -1;
            using (Adherentes frmADH = new Adherentes())
            {
                frmADH.ShowDialog(this);
            }
            
            if (VGlobales.vp_boton_modi != "U" && VGlobales.vp_boton_alta != "I")
            {
                MessageBox.Show("NO TIENE PERMISOS PARA AGREGAR ADHERENTES",
                                                "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             
            Cargar_Solapa_Adh();
        }




        //De image a byte []:
        public byte[] imageToByteArray(Image imageIn)
        {
           MemoryStream ms = new MemoryStream();
           imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
           return ms.ToArray();
        }


        //De byte [] a image:
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
           MemoryStream ms = new MemoryStream(byteArrayIn);
           Image returnImage = Image.FromStream(ms);
           return returnImage;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Familiares.fotoZoom = resizeImage(pictureBox1.Image, 249, 216);

            using (FotoZoom frmFOTO = new FotoZoom())
            {
                frmFOTO.ShowDialog(this);
            }
        }
        
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Familiares.fotoZoom = resizeImage(pictureBox1.Image, 249, 216);
            using (FotoZoom frmFOTO = new FotoZoom())
            {
                frmFOTO.ShowDialog(this);
            }

        }


        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (isadding == "SI" || isediting == "SI")
            {
                if (tabControl1.SelectedTab == tabPage3 || tabControl1.SelectedTab == tabPage5)
                {
                    tabControl1.SelectedTab = tabPage1;
                    MessageBox.Show("SI EDITA O AGREGA TITULARES NO PUEDE PASAR A \n SOLAPA DE FAMILIARES O ADHERENTES",
                                    "ATENCION",
                                    MessageBoxButtons.OK, MessageBoxIcon.Hand);

                }
            }
            else
            {
                if (tabControl1.SelectedTab == tabPage5)
                {
                    if ((v_soc_fallecido == "5") || (v_soc_fallecido == "8"))
                    {
                        toolStripLabel1.Enabled = false;
                        NuevoAdherenete.Enabled = false;
                    }
                }
                else
                    if (tabControl1.SelectedTab == tabPage3)
                    {
                        if ((v_soc_fallecido == "5") || (v_soc_fallecido == "8"))
                        {
                            NuevoFamiliar.Enabled = false;
                        }
                    }
            }
        }


        private void msk_Fecha(object sender, EventArgs e)
        {
          string input = "1900-01-01";

          if (isadding == "SI" || isediting == "SI")
            {
                Control ctrl = (Control)sender;
                

                if (ctrl.Text.Length != 0 )
                {
                    if (IsValidDate(ctrl.Text))
                    {
                        DateTime dateTime;
                         input =  ctrl.Text.Substring(4, 4) + "-" +  // paso la fecha a formato yyyy-mm-dd 
                                  ctrl.Text.Substring(2, 2) + "-" +  // para validar 
                                  ctrl.Text.Substring(0, 2) ;
                   
                    
                        if (DateTime.TryParse(input, out dateTime))
                        {
                            errorProvider1.SetError(ctrl, "");
                            
                        }
                        else
                        {
                            errorProvider1.SetError(ctrl, "FECHA INVALIDA - CORRIJA");
                            ctrl.Focus();
                         
                        }
                    }
                    else
                        {
                        errorProvider1.SetError(ctrl, "FECHA INVALIDA - CORRIJA");
                        ctrl.Focus();
                                 
                        }
                 }
                else
                 {
                     errorProvider1.SetError(ctrl, "");
                     this.msk_textChanged(ctrl, new EventArgs());
                 }
             }

             return;
         }

        //Checks for format of date (dd/mm/yyyyy)
        //separators = /-.
        //format = xx/xx/xxxx or xx/xx/xx
        //Month and day must be within correct calendar range
        //Year can be anything either 2 or 4 digits
        private static bool IsValidDate(string dt)
        {
            // estas expresiones controlan la barra o guion 
            //^([1-9]|0[1-9]|1[012])[- /.]([1-9]|0[1-9]|[12][0-9]|3[01])[- /.][0-9]{4}$
            //^(0[1-9]|1[0-2])[./-](0[1-9]|1[0-9]|2[0-9]|3[0-1])[./-](\\d{2}|\\d{4})$;

            return (Regex.IsMatch(dt, "^(0[1-9]|1[0-9]|2[0-9]|3[0-1])" +
                                      "(0[1-9]|1[0-2])" +
                                      "((19|20)\\d{2})$"));
                                     // "(\\d{4})$"));
        }


        private void msk_textChanged(object sender, EventArgs e)
        {
            // Blanquea el error apenas se selecciona algo 
            Control ctrl = (Control)sender;
            errorProvider1.SetError(ctrl, "");
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            // CHEQUEAMOS  QUE SI TIENE FECHA DE BAJA POL O BAJA CIRC NO DEBE IMPRIMIRLO
            if (maskedTextbox21.Text == "")
            {
                MessageBox.Show("NO SE PUEDE EMITIR UN CARNET SIN FECHA DE ALTA AL CIRCULO");
                return;
            }
            else
            {


                if (textBox15.Text == "640" || textBox15.Text == "740" || textBox15.Text == "642" || textBox15.Text == "A/S")
                {


                    string v_coneccion_acces;
                    string v_provider;
                    string vcadena;
                    string vp1 = "";
                    string vp2 = "";
                    string vp3 = "";
                    string vcodigobarra = "";

                    Datos_ini ini_carnet = new Datos_ini();

                    // si es titular activo o vitalicio.-
                    if (comboBox1.SelectedValue.ToString() == "001")
                        v_coneccion_acces = ini_carnet.Vcarnet_titular;
                    else
                        v_coneccion_acces = ini_carnet.Vcarnet_vitalicio;


                    v_provider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + v_coneccion_acces;

                    OleDbConnection aConnection = new OleDbConnection(v_provider);

                    //if (maskedTextBox4.Text == "")
                    //{
                    //    vp1 = maskedTextBox7.Text;
                    //    vp2 = maskedTextBox6.Text;
                    //}
                    //else
                    //{
                    //    vp1 = maskedTextBox3.Text;
                    //    vp2 = maskedTextBox4.Text;
                    //}


                    // NUEVA REGLA DE NEGOCIO AL 16-12-2009
                    if (v_par == 2)
                    {
                        vp1 = v_pcrjp1.ToString();
                        vp2 = v_pcrjp2.ToString();
                        vp3 = v_pcrjp3.ToString(); ;
                    }
                    else
                    {
                        vp1 = v_acrjp1.ToString();
                        vp2 = v_acrjp2.ToString();
                        vp3 = v_acrjp3.ToString();
                    }


                    vcodigobarra = maskedTextBox1.Text.Trim();
                    vcodigobarra = vcodigobarra.PadLeft(6, '0');
                    vcodigobarra = vcodigobarra + maskedTextBox2.Text.Trim();


                    vcadena = "INSERT INTO IDProjectData (IDCf_altci,IDCBarCodeField1,";
                    vcadena = vcadena + "IDCnro_soc,IDCape_soc,IDCNOM_SOC,IDCnro_doc,IDCTIP_DOC,IDCCRJP1,";
                    vcadena = vcadena + "IDCCRJP2,IDCcrjp3,IDCfoto) values ( '" + maskedTextbox21.Text.Substring(2, 2) + "/" + maskedTextbox21.Text.Substring(4, 4) + "', ";
                    vcadena = vcadena + "'" + "T" + vcodigobarra;
                    vcadena = vcadena + "','" + maskedTextBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text;
                    vcadena = vcadena + "','" + maskedTextBox9.Text + "'," + "'DNI'" + "," + "'" + vp1 + "'" + "," + "'" + vp2 + "'" + ",'" + vp3;
                    vcadena = vcadena + "'," + "?)";

                    OleDbParameter parImagen = new OleDbParameter("@imagen", OleDbType.LongVarBinary, imageToByteArray(pictureBox1.Image).Length);

                    //parImagen.Value = (byte[])adherentesDT.Rows[rowpos]["FOTO"];
                    parImagen.Value = imageToByteArray(pictureBox1.Image);
                    OleDbCommand aCommand = new OleDbCommand(vcadena, aConnection);

                    aCommand.Parameters.Add(parImagen);

                    aConnection.Open();

                    aCommand.ExecuteNonQuery();

                    aConnection.Close();

                    // actualizamos para saber si es original, duplicado etc.-
                    // ATENCION FALTA PONER SI ES ORIGINAL Y VIENE OTRA IMPRESION -> DUPLICADO.-
                    maskedTextbox24.Text = DateTime.Today.Date.Day.ToString().PadLeft(2, '0') +
                           DateTime.Today.Date.Month.ToString().PadLeft(2, '0') +
                           DateTime.Today.Date.Year.ToString();



                    // GRABAMOS EN LA BASE.-

                    string connectionString;

                    Datos_ini ini2 = new Datos_ini();

                    FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                    cs.DataSource = ini2.Servidor;
                    cs.Database = ini2.Ubicacion;
                    cs.UserID = VGlobales.vp_username;
                    cs.Password = VGlobales.vp_password;
                    cs.Role = VGlobales.vp_role;
                    cs.Dialect = 3;
                    connectionString = cs.ToString();
                    using (FbConnection connection = new FbConnection(connectionString))
                    {
                        string vcomando;

                        vcomando = "UPDATE TITULAR SET  F_CARN=CURRENT_DATE WHERE NRO_SOC=" + maskedTextBox1.Text + " AND NRO_DEP=" + maskedTextBox2.Text;

                        connection.Open();
                        FbTransaction transaction = connection.BeginTransaction();
                        FbCommand cmd = new FbCommand(vcomando, connection, transaction);
                        cmd.CommandText = vcomando;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        connection.Dispose();
                    }



                    MessageBox.Show("CARNET LISTO PARA IMPRIMIR.");
                }

                else
                    MessageBox.Show("NO SE PUEDE IMPRIMIR EL CARNET DE ESTE SOCIO, VERIFIQUE");
            }
        }

        private void NuevoAdherenete_Click(object sender, EventArgs e)
        {
            vp_nro_adh = -1;
            using (Adherentes frmADH = new Adherentes())
            {
                frmADH.ShowDialog(this);
            }

            if (VGlobales.vp_boton_modi != "U" && VGlobales.vp_boton_alta != "I")
            {
                MessageBox.Show("NO TIENE PERMISOS PARA AGREGAR ADHERENTES",
                                                "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cargar_Solapa_Adh();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            vp_barra = -1;
            using (Familiares frmFAM = new Familiares())
            {
                frmFAM.ShowDialog(this);
            }

            if (VGlobales.vp_boton_modi != "U" && VGlobales.vp_boton_alta != "I")
            {
                MessageBox.Show("NO TIENE PERMISOS PARA AGREGAR FAMILIARES",
                                                "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cargar_Solapa_Fam();
        }

        private void fbConnection1_InfoMessage(object sender, FbInfoMessageEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
           
            using (Mover_Adherentes frmMOVADH = new Mover_Adherentes())
            {
                frmMOVADH.ShowDialog(this);
            }

            if (VGlobales.vp_boton_modi != "U" && VGlobales.vp_boton_alta != "I")
            {
                MessageBox.Show("NO TIENE PERMISOS PARA MOVER ADHERENTES",
                                                "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cargar_Solapa_Adh();
            
        }

        private void toolStripButton2_Click_2(object sender, EventArgs e)
        {

            //Agregar Datos a la(s) tabla(s) que nos interesa(n) del dataset



            //Cargar_Datos_Titular(DS);

            DS.DataTableTitular.Rows.Add(textBox1.Text, textBox2.Text, maskedTextBox1.Text,
                maskedTextBox2.Text, imageToByteArray(pictureBox1.Image));






            //DS.DataTableTitular.Rows.Add("Modarelli", "Marcelo", "1234", "997");
            //DS.DataTableFamiliiar.Rows.Add("Pepe", "Alberto", "01/12/1998", "0");
            //DS.DataTableFamiliiar.Rows.Add("Epa", "Luis", "01/10/1999", "1");
            //DS.DataTableFamiliiar.Rows.Add("Selamastic", "Lira", "01/11/2000", "1");

            // Inicializar el visor de reportes y mandarle la tabla con los datos
            VER = new VerReporteTitular(DS);
            VER.ShowDialog();

        }



        /*private void Cargar_Datos_Titular(DataSet DS)
        {

           DS.DataTableTitular.Rows.Add(textBox1.Text, textBox2.Text, maskedTextBox1.Text,
               maskedTextBox2.Text);

        
        }
        */




    }

    
}


 
