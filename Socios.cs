using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using FirebirdSql.Data.FirebirdClient;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Mails;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Configuration;
using SOCIOS;

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
        public static System.Drawing.Image fotoZoom = null;
        public static int v_par;
        public static int v_aar;
        public static int v_acrjp1;
        public static int v_acrjp2;
        public static int v_acrjp3;
        public static int v_pcrjp1;
        public static int v_pcrjp2;
        public static int v_pcrjp3;
        public string v_semaforo_baja;
        public static Byte[] byteFotoRepo = new Byte[0];
        public string vdatabase;
        public string vdatasource;
        public string v_cmb10SelValue;
        private string v_Fec_BajaCI = string.Empty;
        private string v_Cod_Dto = string.Empty;
        private string v_NCod_Dto = string.Empty;
        private string v_Cmb4_MBajCI = string.Empty;
        private bool v_load = true;
        private string v_CmbOrAlta = string.Empty;
        public bool v_vit_nuevo;
        public bool v_vit_edito;
        public bool v_vit_semaforo;
        private DateTime dateVal;
        private bool iseditingCBU = false;
        private bool isaddingCBU = false;
        private Carnet.Utils utilCarnet = new Carnet.Utils();
        
        public Socios()
        {
            InitializeComponent();
            button1.Visible = false;
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
            cancelar.Enabled = false;
            grabar.Enabled = false;
            btnAdquirir.Enabled = false;
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
            mskCmpte.Text = " ";
            mskImporte.Text = " ";
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
            textBox17.Text = "0";
            textBox13.Text = " ";
            pictureBox1.Image = SOCIOS.Properties.Resources.fotonodisponible;
            listView1.Items.Clear();
            listBox1.Items.Clear();
            mskCodDestino.Text = "0";
            mskOrDia2.Text = "0";
            mskFecOrDia2.Text = "  ";
            mskImporte.Text = "0";
            mskCmpte.Text = " ";
            v_semaforo_baja = "N";
            v_aar = 0;
            v_acrjp1 = 0;
            v_acrjp2 = 0;
            v_acrjp3 = 0;
            v_pcrjp1 = 0;
            v_pcrjp2 = 0;
            v_pcrjp3 = 0;
        }

        private bool Cargo_Datos(string vcmd)
        {
            bool rtnDatos = true;
            v_semaforo_baja = "N";
            
            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

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
                        vp_nro_soc = Convert.ToInt32(mt.GetString(mt.GetOrdinal("NRO_SOC")));
                        vp_nro_dep = Convert.ToInt32(mt.GetString(mt.GetOrdinal("NRO_DEP")));

                        if (vp_nro_soc != -1 && vp_nro_dep != -1)
                        {
                            //datosContacto(maskedTextBox1.Text, maskedTextBox2.Text);
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
                            mskCmpte.Text = (mt.GetString(mt.GetOrdinal("CC"))).TrimEnd();
                            mskImporte.Text = (mt.GetString(mt.GetOrdinal("IMPORTE"))).TrimEnd();
                            mskOrDia2.Text = (mt.GetString(mt.GetOrdinal("ORD_DIA2"))).TrimEnd();
                            mskFecOrDia2.Text = (mt.GetString(mt.GetOrdinal("ORD_FEC2"))).TrimEnd();
                            maskedTextbox21.Text = (mt.GetString(mt.GetOrdinal("F_ALTCI"))).TrimEnd();
                            textBox15.Text = (mt.GetString(mt.GetOrdinal("COD_DTO"))).TrimEnd();
                            textBox17.Text = (mt.GetString(mt.GetOrdinal("OBRA_SOCIAL"))).TrimEnd();
                            maskedTextBox13.Text = (mt.GetString(mt.GetOrdinal("CAR_FAX"))).TrimEnd();
                            textBox13.Text = (mt.GetString(mt.GetOrdinal("NUM_FAX"))).TrimEnd();
                            maskedTextbox22.Text = (mt.GetString(mt.GetOrdinal("F_ALTVI"))).TrimEnd();
                            maskedTextbox23.Text = (mt.GetString(mt.GetOrdinal("F_CESDE"))).TrimEnd();
                            maskedTextbox24.Text = (mt.GetString(mt.GetOrdinal("F_CARN"))).TrimEnd();
                            maskedTextbox25.Text = (mt.GetString(mt.GetOrdinal("F_BAJCI"))).TrimEnd();
                            v_Fec_BajaCI = maskedTextbox25.Text;
                            maskedTextBox7.Text = (mt.GetString(mt.GetOrdinal("AAR"))).TrimEnd();
                            maskedTextBox6.Text = (mt.GetString(mt.GetOrdinal("ACRJP2"))).TrimEnd();
                            maskedTextBox3.Text = (mt.GetString(mt.GetOrdinal("PCRJP1"))).TrimEnd();
                            maskedTextBox4.Text = (mt.GetString(mt.GetOrdinal("PCRJP2"))).TrimEnd();
                            maskedTextBox5.Text = (mt.GetString(mt.GetOrdinal("PCRJP3"))).TrimEnd();
                            maskedTextbox26.Text = (mt.GetString(mt.GetOrdinal("F_CACAT"))).TrimEnd();
                            textBox19.Text = (mt.GetString(mt.GetOrdinal("BEAUCHEF"))).TrimEnd();
                            textBox14.Text = (mt.GetString(mt.GetOrdinal("GIMNASIO"))).TrimEnd();
                            textBox18.Text = (mt.GetString(mt.GetOrdinal("NCOD_DTO"))).TrimEnd();
                            v_NCod_Dto = textBox18.Text;
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
                            v_aar = mt.GetInt32(mt.GetOrdinal("AAR"));
                            tbCUIL.Text = mt.GetString(mt.GetOrdinal("CUIL")).Trim();

                            if (maskedTextbox25.Text == null || maskedTextbox25.Text == string.Empty || maskedTextbox25.Text.Length == 0)
                            {
                                v_semaforo_baja = "S";
                            }
                            else
                            {
                                v_semaforo_baja = "N";
                            }

                            //TRASPASADO
                            tbTraspasado.Text = (mt.GetString(mt.GetOrdinal("TRASPASADO"))).TrimEnd();

                            //COD_CIUDAD
                            tbCiudad.Text = (mt.GetString(mt.GetOrdinal("COD_CIUDAD"))).TrimEnd();

                            //ID EMPLEADO
                            tbIdEmp.Text = (mt.GetString(mt.GetOrdinal("ID_EMPLEADO"))).TrimEnd();

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
                            v_Cmb4_MBajCI = mt.GetString(mt.GetOrdinal("M_BAJCI"));

                            //comboBox4.SelectedValue = v_Cmb4_MBajCI;
                            if (v_Cmb4_MBajCI == null || v_Cmb4_MBajCI == string.Empty)
                                comboBox4.SelectedValue = -1;
                            else
                                comboBox4.SelectedValue = v_Cmb4_MBajCI;

                            // COMBO MOT. Baja Policial
                            comboBox6.SelectedIndex = -1;
                            VGlobales.v_soc_fallecido = mt.GetString(mt.GetOrdinal("M_BAJPO"));
                            comboBox6.SelectedValue = VGlobales.v_soc_fallecido;

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
                            v_cmb10SelValue = mt.GetString(mt.GetOrdinal("DESTINO")).TrimEnd();
                            
                            if (v_cmb10SelValue == null || v_cmb10SelValue == string.Empty)
                            {
                                mskCodDestino.Text = "000Z";
                                comboBox10.SelectedValue = mskCodDestino.Text;
                            }
                            else
                            {
                                comboBox10.SelectedValue = v_cmb10SelValue;
                                mskCodDestino.Text = comboBox10.SelectedValue.ToString();
                            }

                            // COMBO Origen Alta
                            cmbOrAlta.SelectedIndex = -1;
                            v_CmbOrAlta = mt.GetString(mt.GetOrdinal("ORIGEN_ALTA"));

                            if (v_CmbOrAlta == null || v_CmbOrAlta == string.Empty)
                            {
                                cmbOrAlta.SelectedValue = -1;
                            }
                            else
                            {
                                cmbOrAlta.SelectedValue = v_CmbOrAlta;
                            }

                            int resultIndex = -1;
                            resultIndex = comboBox1.SelectedIndex;
                           
                            Byte[] byteBLOBData1 = new Byte[0];
                            byteBLOBData1 = (Byte[])mt.GetValue(mt.GetOrdinal("FOTO"));
                            MemoryStream stmBLOBData1 = new MemoryStream(byteBLOBData1);
                            pictureBox1.Image = System.Drawing.Image.FromStream(stmBLOBData1);
                            byteFotoRepo = (Byte[])imageToByteArray(pictureBox1.Image);

                            //-----------------------------------------
                            // Recuperamos el rtf de las observaciones

                            Byte[] rtf = new Byte[Convert.ToInt32((mt.GetBytes(mt.GetOrdinal("OBSERVACIONES"), 0, null, 0, Int32.MaxValue)))];
                            long bytesReceived = mt.GetBytes(mt.GetOrdinal("OBSERVACIONES"), 0, rtf, 0, rtf.Length);
                            ASCIIEncoding encoding = new ASCIIEncoding();
                            richTextbox1.Rtf = encoding.GetString(rtf, 0, Convert.ToInt32(bytesReceived));
                        }
                        else
                        {
                            rtnDatos = false;
                        }
                    }

                    connection.Dispose();
                    VGlobales.ID_EMPLEADO = tbIdEmp.Text;
                }
            }
            catch (FbException ex)
            {
                VGlobales.vp_ntp = true;

                switch (ex.ErrorCode.ToString())
                {
                    case "335544352":
                        MessageBox.Show("NO TIENE PERMISOS PARA REALIZAR ESTA TAREA. \n \n UTILICE LA OPCION DE CAMBIO DE USUARIO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        break;

                    case "335544374":
                        MessageBox.Show("EOF - NO HAY MAS REGISTROS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        break;
                    
                    case "335544644":
                        MessageBox.Show("BOF - NO HAY MAS REGISTROS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        break;

                    default:
                        MessageBox.Show(ex.ToString());
                        break;
                }

                this.Close();
            }

            return rtnDatos;
        }

        private void Cargar_Solapa_Fam()
        {
            try
            {
                VGlobales.vp_ntp = false;
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction tran = connection.BeginTransaction();
                    string cmd_familiares;
                    cmd_familiares = "SELECT * FROM FAMILIAR WHERE NRO_SOC=" + maskedTextBox1.Text + " AND NRO_DEP=" + maskedTextBox2.Text;
                    cmd_familiares = cmd_familiares + " ORDER BY BARRA ASC";
                    FbCommand cmdt = new FbCommand(cmd_familiares, connection, tran);
                    cmdt.CommandText = cmd_familiares;
                    cmdt.Connection = connection;
                    cmdt.CommandType = CommandType.Text;
                    FbDataReader reader3 = cmdt.ExecuteReader();
                    listBox1.Items.Clear();
                    Cargar_Familires(reader3);
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());  //falta mail
            }
        }

        private void Cargar_Solapa_Adh()
        {
            try
            {
                VGlobales.vp_ntp = false;
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction tran = connection.BeginTransaction();
                    string cmd_adherentes;
                    cmd_adherentes = "SELECT * FROM ADHERENT WHERE NRO_SOCIO=" + maskedTextBox1.Text + " AND NRO_DEP=" + maskedTextBox2.Text;
                    cmd_adherentes = cmd_adherentes + " AND NRO_DEPADH <> 11 ORDER BY ID_ADHERENTE ASC";
                    FbCommand cmdt2 = new FbCommand(cmd_adherentes, connection, tran);
                    cmdt2.CommandText = cmd_adherentes;
                    cmdt2.Connection = connection;
                    cmdt2.CommandType = CommandType.Text;
                    FbDataReader reader4 = cmdt2.ExecuteReader();
                    listBox1.Items.Clear();
                    Cargar_Adherentes(reader4);
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void Cargar_Solapa_Inp()
        {
            try
            {
                VGlobales.vp_ntp = false;
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction tran = connection.BeginTransaction();
                    string cmd_invparti;
                    cmd_invparti = "SELECT * FROM ADHERENT WHERE NRO_SOCIO=" + maskedTextBox1.Text + " AND NRO_DEP=" + maskedTextBox2.Text;
                    cmd_invparti = cmd_invparti + " AND NRO_DEPADH = 11  ORDER BY ID_ADHERENTE ASC";
                    FbCommand cmdt2 = new FbCommand(cmd_invparti, connection, tran);
                    cmdt2.CommandText = cmd_invparti;
                    cmdt2.Connection = connection;
                    cmdt2.CommandType = CommandType.Text;
                    FbDataReader reader6 = cmdt2.ExecuteReader();
                    listBox1.Items.Clear();
                    Cargar_InvParti(reader6);
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());  // falta mail
            }
        }

        private void Cargar_Servicios(string NRO_SOC, string NRO_DEP)
        {
            try
            {
                conString conString = new conString();
                string connectionString = conString.get();
                
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    string query = "SELECT * FROM P_OBTENER_FAMADH(" + NRO_SOC + "," + NRO_DEP + ")";
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataTable dt1 = new DataTable("RESULTADOS");
                    dt1.Columns.Add("ID_TITULAR", typeof(string));
                    dt1.Columns.Add("NRO_SOC", typeof(string));
                    dt1.Columns.Add("NRO_DEP", typeof(string));
                    dt1.Columns.Add("BARRA", typeof(string));
                    dt1.Columns.Add("APELLIDO", typeof(string));
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("TIPO", typeof(string));
                    dt1.Columns.Add("NUM_DOC", typeof(string));
                    dt1.Columns.Add("ACRJP2", typeof(string));
                    dt1.Columns.Add("SOCIO", typeof(string));
                    dt1.Columns.Add("EDAD", typeof(string));
                    //dt1.Columns.Add("BAJA", typeof(string));
                    DataSet ds1 = new DataSet();
                    ds1.Tables.Add(dt1);
                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID_TITULAR")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NRO_SOC")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("BARRA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("APELLIDO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TIPO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NUM_DOC")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("ACRJP2")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("SOCIO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("EDAD")).Trim());
                                     //reader3.GetString(reader3.GetOrdinal("BAJA")).Trim());
                    }

                    reader3.Close();
                    dgvGrupo.DataSource = dt1;
                    dgvGrupo.Columns[0].Visible = false;
                    dgvGrupo.Columns[8].Visible = false;
                    //dgvGrupo.Columns[11].Visible = false;
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Cargar_Adherentes(FbDataReader reader)
        {
            listView2.Items.Clear();

            if (reader.Read())
            {
                do
                {
                    ListViewItem item11 = new ListViewItem(reader.GetString(reader.GetOrdinal("NRO_ADH")));

                    if (reader.GetString(reader.GetOrdinal("F_BAJADH")) == null)
                    {
                        item11.ImageIndex = 14;
                    }
                    else
                    {
                        item11.ImageIndex = 10;
                    }

                    item11.SubItems.Add(reader.GetString(reader.GetOrdinal("BARRA")));
                    item11.SubItems.Add(reader.GetString(reader.GetOrdinal("APE_ADH")));
                    item11.SubItems.Add(reader.GetString(reader.GetOrdinal("NOM_ADH")));
                    item11.SubItems.Add(reader.GetString(reader.GetOrdinal("COD_DTO")));
                    item11.SubItems.Add(reader.GetString(reader.GetOrdinal("F_BAJADH")));
                    listView2.Items.Add(item11);
                }

                while (reader.Read());
            }
        }

        private void Cargar_InvParti(FbDataReader reader)
        {
            listView3.Items.Clear();

            if (reader.Read())
            {
                do
                {
                    ListViewItem item13 = new ListViewItem(reader.GetString(reader.GetOrdinal("NRO_ADH")));

                    if (reader.GetString(reader.GetOrdinal("F_BAJADH")) == null)
                    {
                        item13.ImageIndex = 14;
                    }
                    else
                    {
                        item13.ImageIndex = 10;
                    }

                    item13.SubItems.Add(reader.GetString(reader.GetOrdinal("BARRA")));
                    item13.SubItems.Add(reader.GetString(reader.GetOrdinal("APE_ADH")));
                    item13.SubItems.Add(reader.GetString(reader.GetOrdinal("NOM_ADH")));
                    item13.SubItems.Add(reader.GetString(reader.GetOrdinal("COD_DTO")));
                    item13.SubItems.Add(reader.GetString(reader.GetOrdinal("F_BAJADH")));
                    listView3.Items.Add(item13);
                }

                while (reader.Read());
            }
        }

        private void Cargar_Familires(FbDataReader reader)
        {
            listView1.Items.Clear();

            if (reader.Read())
            {
                do
                {
                    ListViewItem item1 = new ListViewItem(reader.GetString(reader.GetOrdinal("BARRA")));

                    if (reader.GetString(reader.GetOrdinal("F_BAJA")) == null)
                    {
                        item1.ImageIndex = 14;
                    }
                    else
                    {
                        item1.ImageIndex = 10;
                    }

                    item1.SubItems.Add(reader.GetString(reader.GetOrdinal("APE_FAM")));
                    item1.SubItems.Add(reader.GetString(reader.GetOrdinal("NOM_FAM")));
                    item1.SubItems.Add(reader.GetString(reader.GetOrdinal("F_BAJA")));
                    item1.SubItems.Add(reader.GetString(reader.GetOrdinal("F_CARFAM")));
                    item1.SubItems.Add(reader.GetString(reader.GetOrdinal("F_NACFAM")));
                    item1.SubItems.Add(reader.GetString(reader.GetOrdinal("SEXO")));
                    listView1.Items.Add(item1);
                }

                while (reader.Read());
            }
        }

        private void Cargar_Observaciones()
        {
            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string busco = "SELECT SUBSTR(OBS,1,60) AS O1,SUBSTR(OBS,61,120) AS O2,SUBSTR(OBS,121,180) AS O3  FROM OBSERVAC WHERE NRO_SOC=" + maskedTextBox1.Text + " AND NRO_DEP=" + maskedTextBox2.Text;
                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            do
                            {
                                listBox1.Items.Add(reader.GetString(reader.GetOrdinal("O1")));
                                listBox1.Items.Add(reader.GetString(reader.GetOrdinal("O2")));
                                listBox1.Items.Add(reader.GetString(reader.GetOrdinal("O3")));
                            }

                            while (reader.Read());
                        }

                        reader.Close();
                        transaction.Commit();
                        connection.Close();
                        cmd = null;
                        transaction = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Cargar_observac()
        {
            listBox1.Items.Clear();
            
            try
            {
                VGlobales.vp_ntp = false;
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction tran = connection.BeginTransaction();
                    string cmd_observac = "SELECT SUBSTR(OBS,1,60) AS O1,SUBSTR(OBS,61,120) AS O2,SUBSTR(OBS,121,180) AS O3  FROM OBSERVAC WHERE NRO_SOC=" + maskedTextBox1.Text + " AND NRO_DEP=" + maskedTextBox2.Text;
                    FbCommand cmdt3 = new FbCommand(cmd_observac, connection, tran);
                    cmdt3.CommandText = cmd_observac;
                    cmdt3.Connection = connection;
                    cmdt3.CommandType = CommandType.Text;
                    FbDataReader reader = cmdt3.ExecuteReader();
                    connection.Dispose();

                    if (reader.Read())
                    {
                        do
                        {
                            listBox1.Items.Add(reader.GetString(reader.GetOrdinal("O1")));
                            listBox1.Items.Add(reader.GetString(reader.GetOrdinal("O2")));
                            listBox1.Items.Add(reader.GetString(reader.GetOrdinal("O3")));
                        }

                        while (reader.Read());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString()); //falta mail
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            v_acrjp1 = 0;
            v_acrjp2 = 0;
            v_acrjp3 = 0;
            v_pcrjp1 = 0;
            v_pcrjp2 = 0;
            v_pcrjp3 = 0;

            string path = Directory.GetCurrentDirectory();
            string vfoto = Directory.GetCurrentDirectory();
            path = path + "\\PARAMETERS.BIN";
            vfoto = vfoto + "\\TMP.TIF";

            try
            {
                File.Delete(path);
                File.Delete(vfoto);
            }
            catch (FbException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            try
            {
                int I = 0;
                conString conString = new conString();
                string connectionString = conString.get();
               
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    string QUERY_PERMISO = "SELECT CONTROL, PERMISO, INDEX_CONTROL FROM CONTROL_MENU_SOCIOS WHERE ROL = '" + VGlobales.vp_role.Trim() + "' ORDER BY ID_ROL";
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand cmd3 = new FbCommand(QUERY_PERMISO, connection, transaction);
		            DataTable Tabla = new DataTable();
                    FbDataAdapter FBDA = new FbDataAdapter(cmd3);
                    FBDA.Fill(Tabla);

                    foreach (DataRow row in Tabla.Rows)
                    {
                        VGlobales.vp_arraySolapas[I, 0] = row[2].ToString().TrimEnd();
                        VGlobales.vp_arraySolapas[I, 1] = row[1].ToString().TrimEnd();
                        I = I + 1;
                    }

                    connection.Close();
                }
            }
            catch (FbException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString()); 
            }

            v_load = true;
            maskedTextBox1.Text = "0";
            maskedTextBox2.Text = "0";
            richTextbox1.ReadOnly = true;
            dsllc = lleno_combos();
            Ver_Privilegios("TITULAR");

            if (vp_nro_soc == -1 && vp_nro_dep == -1)
            {
                nuevo_Click(nuevo, new EventArgs());
            }
            else
            {
                Busco_Primero();
            }

            if (VGlobales.vp_role.Trim() != "SISTEMAS") //PESTAÑA CONFIDENCIALES
            {
                TabConfidenciales.Dispose();
                vp_tabpage = -1;
            }

            // NUEVO VITALICIOS
            if ((VGlobales.vp_role.Trim() != "VITALICIOS") && (VGlobales.vp_role.Trim() != "VITALMODI") && (VGlobales.vp_role.Trim() != "SISTEMAS") && (VGlobales.vp_role.Trim() != "VITALMODI2"))
            {
                TabVitalicios.Dispose();
                vp_tabpage = -1;
            }
            
            // TURISMO 09-05-2013
            if ((!VGlobales.vp_role.Trim().StartsWith("TURISMO") && (VGlobales.vp_role.Trim() != "SISTEMAS") && (VGlobales.vp_role.Trim() != "SERVICIOS MEDICOS") && (VGlobales.vp_role.Trim() != "DEPORTES") && (VGlobales.vp_role.Trim() != "INTERIOR") &&  ! (VGlobales.vp_role.Trim().StartsWith("CPO"))))
            {
                TabServicios.Dispose();
                vp_tabpage = -1;
            }
           
            // NUEVO, AUTOMATIZAR CONFIGURACION DEL SISTEMA.
            string vmacro;

            if (1==2)
            {
                for (int i=0; i<VGlobales.vp_arraySolapas.Length; i++)
                {

                    if (string.IsNullOrEmpty(VGlobales.vp_arraySolapas[i, 0]))
                    {
                        vmacro = "";
                    }
                    else if (VGlobales.vp_arraySolapas[i, 1] == "N")
                    {
                        vmacro = VGlobales.vp_arraySolapas[i, 0];

                        if (vmacro != "0")
                            TabsSocios.TabPages.RemoveAt(Convert.ToInt32(vmacro));
                    }
                }
            }

            Habilitar_Botones();

            if (VGlobales.vp_viene_de_barras == "S")
            {
                TabsSocios.SelectedTab = TabAdherentes;
                TabAdherentes.Focus();
                string iSearch = VGlobales.vp_id_adhbarra.ToString();
                iSearch = iSearch.Substring(0,5);
                string iSearch2 = VGlobales.vp_idadh_barra;

                foreach (ListViewItem item in listView2.Items)
                {
                    if ((item.SubItems[0].Text.Contains(iSearch)) && (item.SubItems[1].Text.Contains(iSearch2)))
                    {
                        item.Selected = true;
                    }
                }           
            }

            if (VGlobales.vp_servyact == "S")
            {
                TabsSocios.SelectedTab = TabServicios;
                TabServicios.Focus();
            }
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

            if ((VGlobales.vp_role.Trim() == "VITALICIOS") && (VGlobales.vp_role.Trim() == "VITALMODI") && (VGlobales.vp_role.Trim() == "VITALMODI2"))
            {
                editar.Enabled = false;
                nuevo.Enabled = false;
            }

            if ((VGlobales.vp_role.Trim() == "SERVICIOS MEDICOS") || (VGlobales.vp_role.Trim() == "INFORMES") || (VGlobales.vp_role.Trim() == "DEPORTES")
                || (VGlobales.vp_role.StartsWith("TURISMO")) || (VGlobales.vp_role.Trim() == "INTERIOR") || (VGlobales.vp_role.Trim() == "CAJA") || (VGlobales.vp_role.Trim() == "CONFITERIA") 
                || (VGlobales.vp_role.Trim() == "SSADPADUA") || (VGlobales.vp_role.Trim() == "CONTADURIA"))
            {
                nuevo.Enabled = true;

                if (maskedTextBox2.Text == "012" || maskedTextBox2.Text == "12")
                {
                    editar.Enabled = true;
                }
                else
                {
                    editar.Enabled = false;
                }
            }
        }

        public static void Ver_Privilegios(string tabla)
        {
            VGlobales.vp_boton_modi = "S";
            VGlobales.vp_boton_alta = "S";

            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    string QUERY_PRIV = "SELECT RDB$USER,RDB$RELATION_NAME,RDB$PRIVILEGE FROM RDB$USER_PRIVILEGES WHERE RDB$USER='" + VGlobales.vp_role.Trim() + "' AND RDB$RELATION_NAME='" + tabla.Trim() + "' AND (rdb$privilege='I' or rdb$privilege='U')";
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand cmd3 = new FbCommand(QUERY_PRIV, connection, transaction);
                    FbDataReader reader = cmd3.ExecuteReader();
                    string v_auxi;

                    if (reader.Read())
                    {
                        do
                        {
                            v_auxi = reader.GetString(reader.GetOrdinal("RDB$PRIVILEGE"));

                            if (v_auxi.Trim() == "I")
                            {
                                VGlobales.vp_boton_alta = "I";
                            }
                            if (v_auxi.Trim() == "U")
                            {
                                VGlobales.vp_boton_modi = "U";
                            }
                        }
                        
                        while (reader.Read());
                    }

                    connection.Close();
                }
            }
            catch (FbException ex)
            {
                MessageBox.Show(ex.ToString());
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
                    busco = "SELECT * FROM P_OBTENER_TITULAR_WB2(@VNRO_SOC,@VNRO_DEP,'E')";
                    Cargo_Datos(busco);
                }

                if (((vp_tabpage == 2) && (VGlobales.vp_role.Trim() == "SISTEMAS")) || ((vp_tabpage == 1) && (VGlobales.vp_role.Trim() != "SISTEMAS"))) // FAM
                {
                    TabsSocios.SelectedTab = TabFamiliares;

                    if (this.listView1.Items.Count == 1)
                    {
                        this.listView1.Items[0].Focused = true;
                        this.listView1_Click_1(listView1, new EventArgs());
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
                    if (((vp_tabpage == 3) && (VGlobales.vp_role.Trim() == "SISTEMAS")) || ((vp_tabpage == 2) && (VGlobales.vp_role.Trim() != "SISTEMAS"))) // ADHERENTES
                    {
                        TabsSocios.SelectedTab = TabAdherentes;

                        if (this.listView2.Items.Count == 1)
                        {
                            VGlobales.vp_adh_inp = "A";
                            this.listView2.Items[0].Focused = true;
                            this.listView2_Click_1(listView2, new EventArgs());
                        }
                        else
                        {
                            if (VGlobales.vp_cod_bar == "A")
                            {
                                VGlobales.vp_adh_inp = "A";

                                using (Adherentes frmADH = new Adherentes())
                                {
                                    frmADH.Text = "ADHERENTES - ALTAS/BAJAS/MODIFICACIONES";
                                    frmADH.ShowDialog(this);
                                }

                                Cargar_Solapa_Adh();
                            }
                        }
                    }
                    else
                    {
                        if (((vp_tabpage == 6) && (VGlobales.vp_role.Trim() != "SISTEMAS"))) // INV.PARTICIPATIVOS
                        {
                            TabsSocios.SelectedTab = TabInvitados;

                            if (this.listView3.Items.Count == 1)
                            {
                                VGlobales.vp_adh_inp = "I";
                                this.listView3.Items[0].Focused = true;
                                this.listView3_Click_1(listView3, new EventArgs());
                            }
                            else
                            {
                                if (VGlobales.vp_cod_bar == "A")
                                {
                                    VGlobales.vp_adh_inp = "I";
                                    using (Adherentes frmADH = new Adherentes())
                                    {
                                        frmADH.Text = "INV.PARTICIPATIVOS - ALTAS/BAJAS/MODIFICACIONES";
                                        frmADH.ShowDialog(this);
                                    }

                                    Cargar_Solapa_Inp();
                                }
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
                busco = "SELECT * FROM P_OBTENER_TITULAR_WB2(0,0,'P')";
            }

            Cargo_Datos(busco);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            limpio_botones();
            string busco;
            busco = "SELECT * FROM P_OBTENER_TITULAR_WB2(@VNRO_SOC,@VNRO_DEP,'A') ";
            
            if (!Cargo_Datos(busco))
            {
                Busco_Primero();
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            limpio_botones();
            string busco;
            busco = "SELECT * FROM P_OBTENER_TITULAR_WB2(@VNRO_SOC,@VNRO_DEP,'S')";

            if (!Cargo_Datos(busco))
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
            busco = "SELECT * FROM P_OBTENER_TITULAR_WB2(99999,999,'U')";
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
                busco = "SELECT * FROM P_OBTENER_TITULAR_WB2(@VNRO_SOC,@VNRO_DEP,'E')";
                Cargo_Datos(busco);
            }

            TabsSocios.SelectedIndex = vp_tabpage;

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

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            v_load = false;
            isediting = "SI";
            isadding = "NO";
            bindingNavigator1.MoveFirstItem.Enabled = false;
            bindingNavigator1.MoveLastItem.Enabled = false;
            bindingNavigator1.MoveNextItem.Enabled = false;
            bindingNavigator1.MovePreviousItem.Enabled = false;
            //tbCUIL.ReadOnly = false;
            cancelar.Enabled = true;
            grabar.Enabled = true;
            buscar.Enabled = false;
            editar.Enabled = false;
            nuevo.Enabled = false;
            TabTitular.Select();
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
            mskCmpte.ReadOnly = false;
            mskImporte.ReadOnly = false;
            textBox18.ReadOnly = false;
            richTextbox1.ReadOnly = false;
            textBox16.ReadOnly = false;
            textBox17.ReadOnly = false;
            tbIdEmp.ReadOnly = false;
            tbTraspasado.ReadOnly = false;
            tbCiudad.ReadOnly = false;

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

            cmbOrAlta.PreventDropDown = false;
            cmbOrAlta.BackColor = Color.FromName("white");
            cmbOrAlta.ForeColor = Color.FromName("Black");

            maskedTextbox26.ReadOnly = false;

            if (VGlobales.vp_role == "SISTEMAS")
            {
                textBox19.ReadOnly = false;
                comboBox5.PreventDropDown = false;
                comboBox5.BackColor = Color.FromName("white");
                comboBox5.ForeColor = Color.FromName("Black");
            }

            maskedTextBox14.ReadOnly = false;
            mskCmpte.ReadOnly = false;
            mskImporte.ReadOnly = false;
            maskedTextbox16.ReadOnly = false;
            maskedTextbox15.ReadOnly = false;
            maskedTextbox17.ReadOnly = false;
            maskedTextBox18.ReadOnly = false;
            maskedTextbox19.ReadOnly = false;
            mskCodDestino.ReadOnly = false;
            mskOrDia2.ReadOnly = false;
            mskFecOrDia2.ReadOnly = false;
            maskedTextbox20.ReadOnly = false;
            maskedTextbox21.ReadOnly = false;
            maskedTextbox22.ReadOnly = false;
            textBox15.ReadOnly = false;
            maskedTextbox23.ReadOnly = false;
            maskedTextbox24.ReadOnly = false;
            maskedTextbox24.ReadOnly = false;
            maskedTextbox25.ReadOnly = false;
            maskedTextbox27.ReadOnly = false;
            TabsSocios.SelectedIndex = 0;
            btnAdquirir.Enabled = true;
            maskedTextBox3.Focus();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            VGlobales.vp_nuevo_socio = "NO";

            DialogResult dr = MessageBox.Show("CONFIRMA CANCELAR LA EDICION?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                errorProvider1.Clear();
                cancelar.Enabled = false;
                grabar.Enabled = false;
                buscar.Enabled = true;
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
                mskCmpte.ReadOnly = true;
                mskImporte.ReadOnly = true;
                richTextbox1.ReadOnly = true;
                maskedTextbox25.ReadOnly = true;
                textBox16.ReadOnly = true;
                textBox17.ReadOnly = true;
                tbIdEmp.ReadOnly = true;
                tbTraspasado.ReadOnly = true;
                tbCiudad.ReadOnly = true;
                //tbCUIL.ReadOnly = true;

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

                cmbOrAlta.PreventDropDown = true;
                cmbOrAlta.BackColor = Color.FromName("Control");
                cmbOrAlta.ForeColor = Color.FromName("Black");

                maskedTextbox26.ReadOnly = true;

                if (VGlobales.vp_role == "SISTEMAS")
                {
                    textBox19.ReadOnly = true;
                    comboBox5.PreventDropDown = true;
                    comboBox5.BackColor = Color.FromName("Control");
                    comboBox5.ForeColor = Color.FromName("Black");
                }

                maskedTextBox14.ReadOnly = true;
                mskCmpte.ReadOnly = true;
                mskImporte.ReadOnly = true;
                maskedTextbox16.ReadOnly = true;
                maskedTextbox15.ReadOnly = true;
                maskedTextbox17.ReadOnly = true;
                maskedTextBox18.ReadOnly = true;
                maskedTextbox19.ReadOnly = true;
                mskCodDestino.ReadOnly = true;
                mskOrDia2.ReadOnly = true;
                mskFecOrDia2.ReadOnly = true;
                maskedTextbox20.ReadOnly = true;
                maskedTextbox21.ReadOnly = true;
                maskedTextbox22.ReadOnly = true;
                textBox15.ReadOnly = true;
                maskedTextbox23.ReadOnly = true;
                maskedTextbox24.ReadOnly = true;
                maskedTextbox25.ReadOnly = true;
                maskedTextBox2.ReadOnly = true;
                maskedTextbox27.ReadOnly = true;
                btnAdquirir.Enabled = false;
                isediting = "NO";
                isadding = "NO";
                string busco;
                busco = "SELECT * FROM P_OBTENER_TITULAR_WB2(@VNRO_SOC,@VNRO_DEP,'E')";
                Cargo_Datos(busco);
            }
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            if ((VGlobales.vp_role.Trim() == "SERVICIOS MEDICOS") || (VGlobales.vp_role.Trim() == "INFORMES") || (VGlobales.vp_role.Trim() == "DEPORTES")
                || (VGlobales.vp_role.Trim() == "INTERIOR") || (VGlobales.vp_role.Trim() == "CAJA") 
                || (VGlobales.vp_role.Trim() == "CONFITERIA")
                || (VGlobales.vp_role.Trim() == "CONTADURIA")
                || (VGlobales.vp_role.Trim().StartsWith("TURISMO")))
            {
                maskedTextBox2.Text = "012";
                maskedTextBox2.ReadOnly = true;
            }
            else if (VGlobales.vp_role == "CPOCABA")
            {
                maskedTextBox2.Text = "018";
                textBox15.Text = "000";
                textBox18.Text = "000";
                maskedTextBox2.Enabled = false;
                mskCodDestino.Text = "000Z";
            }
            else if (VGlobales.vp_role == "CPOPOLVORINES")
            {
                maskedTextBox2.Text = "019";
                textBox15.Text = "000";
                textBox18.Text = "000";
                maskedTextBox2.Enabled = false;
                mskCodDestino.Text = "000Z";
            }
            else
            {
                maskedTextBox2.Text = "994";
            }

            v_load = false;

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
            TabTitular.Select();
            maskedTextBox1.ReadOnly = true;

            if ((VGlobales.vp_role.Trim() == "SERVICIOS MEDICOS") || (VGlobales.vp_role.Trim() == "INFORMES") || (VGlobales.vp_role.Trim() == "DEPORTES")
                || (VGlobales.vp_role.Trim() == "INTERIOR") || (VGlobales.vp_role.Trim() == "CAJA") || (VGlobales.vp_role.Trim() == "CONFITERIA"
                || (VGlobales.vp_role.Trim() == "SSADPADUA") || (VGlobales.vp_role.Trim() == "TURISMO") || (VGlobales.vp_role.Trim() == "CONTADURIA")))
            {
                maskedTextBox2.ReadOnly = true;
                maskedTextBox2.Text = "012";
            }
            else
            {
                maskedTextBox2.ReadOnly = false;
            }

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

            cmbOrAlta.PreventDropDown = false;
            cmbOrAlta.BackColor = Color.FromName("white");
            cmbOrAlta.ForeColor = Color.FromName("Black");

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
            mskCodDestino.ReadOnly = false;
            mskOrDia2.ReadOnly = false;
            mskFecOrDia2.ReadOnly = false;
            maskedTextbox20.ReadOnly = false;
            maskedTextbox21.ReadOnly = false;
            maskedTextbox22.ReadOnly = false;
            textBox15.ReadOnly = false;
            maskedTextbox23.ReadOnly = false;
            maskedTextbox24.ReadOnly = false;
            maskedTextbox24.ReadOnly = false;
            maskedTextbox25.ReadOnly = false;
            textBox17.ReadOnly = false;
            maskedTextBox1.Text = "0";
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
            textBox17.Text = "0";
            textBox13.Text = " ";
            textBox19.Text = "0";
            //textBox15.Clear();
            pictureBox1.Image = SOCIOS.Properties.Resources.fotonodisponible;
            maskedTextbox21.Text = " ";
            maskedTextbox26.Text = " ";
            maskedTextbox25.Text = " ";
            maskedTextbox15.Text = " ";
            maskedTextbox16.Text = " ";
            maskedTextbox17.Text = " ";
            maskedTextBox18.Text = "0";
            maskedTextbox19.Text = " ";
            //mskCodDestino.Text = "0";
            mskOrDia2.Text = "0";
            mskFecOrDia2.Text = " ";
            mskCmpte.Text = " ";
            mskImporte.Text = " ";
            maskedTextbox22.Text = " ";
            maskedTextbox23.Text = " ";
            maskedTextbox24.Text = " ";
            textBox18.Text = " ";
            textBox14.Text = " ";
            mskCmpte.Text = " ";
            mskImporte.Text = " ";
            richTextbox1.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = -1; 
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox7.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;
            comboBox9.SelectedIndex = -1;
            comboBox10.SelectedIndex = -1;
            cmbOrAlta.SelectedIndex = -1;
            TabsSocios.SelectedIndex = 0;
            btnAdquirir.Enabled = true;
            maskedTextbox21.Text = DateTime.Today.Date.Day.ToString().PadLeft(2, '0') + DateTime.Today.Date.Month.ToString().PadLeft(2, '0') + DateTime.Today.Date.Year.ToString();
            textBox14.Text = "N";
            listView1.Items.Clear();
            maskedTextBox1.Focus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (VGlobales.vp_ntp == false)
            {
                DialogResult dr = MessageBox.Show("CONFIRMA CERRAR ESTA PANTALLA?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (dr == DialogResult.Yes)
                {
                    if (cancelar.Enabled == true)
                    {
                        MessageBox.Show("DEBE CONFIRMAR O CANCELAR LOS CAMBIOS, RECUERDE QUE ESTA EDITANDO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void comboJerarquias()
        {
            bo dlog = new bo();
            string query = "SELECT SUBSTR(CODIGO,1,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('JE');";

            if (maskedTextBox2.Text == "017" || maskedTextBox2.Text == "17")
            {
                query = "SELECT SUBSTR(CODIGO,1,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('JM')";
            }

            comboBox9.DataSource = null;
            comboBox9.Items.Clear();
            comboBox9.DataSource = dlog.BO_EjecutoDataTable(query);
            comboBox9.DisplayMember = "DESCRIP";
            comboBox9.ValueMember = "CODIGO";
            comboBox9.SelectedItem = -1;

            /*string string_combo;
            DataSet ds1 = new DataSet();
            DataTable dt14 = new DataTable("JE");
            dt14.Columns.Add("codigo", typeof(string));
            dt14.Columns.Add("descrip", typeof(string));
            ds1.Tables.Add(dt14);

            cmd.CommandText = "SELECT SUBSTR(CODIGO,1,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('JE')";

            if (maskedTextBox2.Text == "017" || maskedTextBox2.Text == "17")
            {
                cmd.CommandText = "SELECT SUBSTR(CODIGO,1,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('JM')";
            }

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
            comboBox9.DataSource = dt14;*/
        }
            

        private DataSet lleno_combos()
        {
            string string_combo;
            DataSet ds1 = new DataSet();

            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

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

                    if (VGlobales.vp_nuevo_socio == "SI")
                    {
                        string_combo = "SELECT SUBSTR(CODIGO,2,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('CA')";

                        if ((VGlobales.vp_role.Trim() == "SERVICIOS MEDICOS") || (VGlobales.vp_role.Trim() == "INFORMES") || (VGlobales.vp_role.Trim() == "DEPORTES")
                            || (VGlobales.vp_role.Trim() == "INTERIOR") || (VGlobales.vp_role.Trim() == "CAJA")
                            || (VGlobales.vp_role.Trim() == "CONFITERIA") || (VGlobales.vp_role.Trim() == "SSADPADUA") || (VGlobales.vp_role.Trim() == "CONTADURIA"))
                        {
                            string_combo = "SELECT SUBSTR(CODIGO,2,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('CA') WHERE CODIGO = '0005';";
                        }
                        
                        if ((VGlobales.vp_role.Trim() == "CPOCABA")) 
                        {
                            string_combo = "SELECT SUBSTR(CODIGO,2,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('CA') WHERE CODIGO = '0013';";
                        }

                        if ((VGlobales.vp_role.Trim() == "CPOPOLVORINES"))
                        {
                            string_combo = "SELECT SUBSTR(CODIGO,2,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('CA') WHERE CODIGO = '0014';";
                        }

                        if ((VGlobales.vp_role.StartsWith("TURISMO")))
                        {
                            string_combo = "SELECT SUBSTR(CODIGO,2,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('CA') WHERE CODIGO IN ('0005', '0008');";
                        }
                    }
                    else
                    {
                        string_combo = "SELECT SUBSTR(CODIGO,2,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('CA')";
                    }

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
                    comboBox1.SelectedIndex = 0;


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
                    //comboBox4.DisplayMember = "codigo";
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
                    //comboBox6.DisplayMember = "codigo";
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

                    comboJerarquias();

                    //Carga COMBO DESTINO 
                    DataTable dt15 = new DataTable("DE");
                    dt15.Columns.Add("codigo", typeof(string));
                    dt15.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt15);

                    // llenamos los mot. Destinos.-
                    //cmd.CommandText = "SELECT SUBSTR(CODIGO,1,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('DE')";
                    cmd.CommandText = "SELECT SUBSTR(CODIGO,1,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('DE') ORDER BY DESCRIP"; //23-11-11
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


                    //Carga ORIGEN ALTA 
                    DataTable dt22 = new DataTable("OA");
                    dt22.Columns.Add("codigo", typeof(string));
                    dt22.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt22);

                    // llenamos los mot. Origen Alta.-
                    cmd.CommandText = "SELECT SUBSTR(CODIGO,2,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('OA') ORDER BY DESCRIP"; //23-11-11
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt22.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();

                    cmbOrAlta.DisplayMember = "descrip";
                    cmbOrAlta.ValueMember = "codigo";
                    cmbOrAlta.DataSource = dt22;


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




                    //Carga COMBO cbServicio 

                    DataTable dt101 = new DataTable("SERV");
                    dt101.Columns.Add("DETALLE", typeof(string));
                    dt101.Columns.Add("FORMULARIO", typeof(string));
                    ds1.Tables.Add(dt101);

                    // llenamos combo de servicios para link.-

                    if (VGlobales.vp_role != "SISTEMAS")
                        cmd.CommandText = "SELECT DETALLE, FORMULARIO FROM CONTROL_ROL_FORM WHERE ROL = '" + VGlobales.vp_role + "'";
                    else
                        cmd.CommandText = "SELECT DETALLE, FORMULARIO FROM CONTROL_ROL_FORM ORDER BY ROL ASC;";
                   
                    if (VGlobales.vp_role.StartsWith("CPO"))
                        cmd.CommandText = "SELECT DETALLE, FORMULARIO FROM CONTROL_ROL_FORM WHERE ROL = 'DEPORTES'";


                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt101.Rows.Add(reader3.GetString(reader3.GetOrdinal("DETALLE")), reader3.GetString(reader3.GetOrdinal("FORMULARIO")));
                    }
                    reader3.Close();

                    cbServicio.DisplayMember = "DETALLE";
                    cbServicio.ValueMember = "FORMULARIO";
                    cbServicio.DataSource = dt101;

                    //Carga Descripcion BARRA Adherente

                    DataTable dt13 = new DataTable("BADH");
                    dt13.Columns.Add("codigo", typeof(string));
                    dt13.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt13);

                    // lo lleno a mano pues no hay tabla

                    if (VGlobales.vp_adh_inp == "A")
                        dt13.Rows.Add("0000", "ADHERENTE TITULAR");
                    else
                    {
                        dt13.Rows.Add("0000", "INV.PARTICIPATIVO TITULAR");
                    }
                    dt13.Rows.Add("0001", "ESPOSO/A");
                    dt13.Rows.Add("0002", "HIJO/S");

                    //
                    //==> VITALICIOS
                    //

                    //Datos 25 Años
                    DataTable dt20 = new DataTable("LUGAR1");
                    dt20.Columns.Add("codigo", typeof(string));
                    dt20.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt20);

                    cmd.CommandText = "SELECT SUBSTR(CODIGO,1,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('VI')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt20.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }
                    reader3.Close();

                    //Datos 50 Años
                    DataTable dt21 = new DataTable("LUGAR2");
                    dt21.Columns.Add("codigo", typeof(string));
                    dt21.Columns.Add("descrip", typeof(string));
                    ds1.Tables.Add(dt21);

                    cmd.CommandText = "SELECT SUBSTR(CODIGO,1,4) AS CODIGO, DESCRIP FROM P_OBTENER_TABLA ('VI')";
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt21.Rows.Add(reader3.GetString(reader3.GetOrdinal("CODIGO")), reader3.GetString(reader3.GetOrdinal("DESCRIP")));
                    }


                    // devuelvo el Data Set con todas las tablas 
                    return ds1;
                }

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                return ds1;
            }
        }

        private void Consistir_BajaPOCI()
        {
            this.msk_textChanged(comboBox6, new EventArgs());
        }

        private void grabar_Click(object sender, EventArgs e)
        {   
            VGlobales.vp_nuevo_socio = "NO";
            
            string vsemaforo = "S";

            if ((((VGlobales.vp_role.Trim() == "SERVICIOS MEDICOS"))) && (isediting == "SI" && isadding == "NO"))
            {
                int id_titular = (Socios.vp_nro_soc * 1000) + Socios.vp_nro_dep;
                string vcomando1;
                vcomando1 = "UPDATE TITULAR SET OBRA_SOCIAL = '" + textBox17.Text.Trim() + "'";
                vcomando1 = vcomando1 + " WHERE ID_TITULAR = " + id_titular.ToString();
                conString conString = new conString();
                string connectionString = conString.get();
                FbConnection connection = new FbConnection(connectionString);
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                FbCommand cmd = new FbCommand(vcomando1, connection, transaction);

                try
                {
                    using (connection)
                    {
                        cmd.CommandText = vcomando1;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        connection.Dispose();
                        fin_alta();
                    }
                }
                catch (FbException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    fin_alta();
                }
            }
            else
            {
                string vBajaCascada = "N";

                if ((maskedTextbox25.Text != string.Empty || maskedTextbox25.Text.Length > 0) && (v_semaforo_baja == "S"))
                {
                    DialogResult dr = MessageBox.Show("CONFIRMA LA BAJA A FAMILIARES Y ADHERENTES?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (dr == DialogResult.Yes)
                    {
                        vBajaCascada = "S";
                        textBox15.Text = "000";
                        textBox18.Text = "000";
                        tbCiudad.Text = "0";
                    }
                    else
                    { 
                        textBox15.Text = v_Cod_Dto;
                        textBox18.Text = v_NCod_Dto;
                        maskedTextbox25.Text = v_Fec_BajaCI;

                        if (v_Cmb4_MBajCI == null || v_Cmb4_MBajCI == string.Empty)
                        {
                            comboBox4.SelectedIndex = -1;
                        }
                        else
                        {
                            comboBox4.SelectedValue = v_Cmb4_MBajCI;
                        }
                    }
                }

                string vcomando;
                string vcomando2;
                string vcomando3;
                string vcomando4;
                string vcomando99;
                string cmd_numerador = "";
                int vnro_socio = 0;
                int vp07 = 0;
                int vp08 = 0;
                
                switch (maskedTextBox2.Text)
                {
                    case "019":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(13)";
                        break;

                    case "19":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(13)";
                        break;

                    case "018":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(12)";
                        break;

                    case "18":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(12)";
                        break;

                    case "020":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(11)";
                        break;

                    case "20":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(11)";
                        break;

                    case "017":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(10)";
                        break;

                    case "17":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(10)";
                        break;

                    case "016":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(10)";
                        break;

                    case "16":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(9)";
                        break;

                    case "015":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(8)";
                        break;

                    case "012":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(4)";
                        break;

                    case "12":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(4)";
                        break;

                    case "013":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(5)";
                        break;

                    case "13":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(5)";
                        break;

                    case "057":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(6)";
                        break;

                    case "57":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(6)";
                        break;

                    case "994":
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(1)";
                        break;

                    default:
                        cmd_numerador = "SELECT * FROM P_OBTENER_NUMERADOR(1)";
                        break;
                }

                conString conString = new conString();
                string connectionString = conString.get();
                FbConnection connection = new FbConnection(connectionString);
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();

                if (isediting == "SI" && isadding == "NO")
                {
                    vcomando = "P_MODIFICA_TITULAR_WB2";
                }
                else
                {
                    vcomando = "SELECT ID_TITULAR FROM TITULAR WHERE ACRJP2 = " + maskedTextBox6.Text + " AND ACRJP2 != 0 AND COD_DTO != '000'";

                    FbCommand tNum1 = new FbCommand(vcomando, connection, transaction);
                    tNum1.CommandText = vcomando;
                    tNum1.Connection = connection;
                    tNum1.CommandType = CommandType.Text;
                    FbDataReader reader = tNum1.ExecuteReader();

                    vcomando2 = "SELECT NUM_DOC FROM TITULAR WHERE NUM_DOC = " + maskedTextBox9.Text;

                    FbCommand tNum2 = new FbCommand(vcomando2, connection, transaction);
                    tNum2.CommandText = vcomando2;
                    tNum2.Connection = connection;
                    tNum2.CommandType = CommandType.Text;
                    FbDataReader reader2 = tNum2.ExecuteReader();

                    vcomando3 = "SELECT NUM_DOCADH FROM ADHERENT WHERE NUM_DOCADH = " + maskedTextBox9.Text;

                    FbCommand tNum3 = new FbCommand(vcomando3, connection, transaction);
                    tNum3.CommandText = vcomando3;
                    tNum3.Connection = connection;
                    tNum3.CommandType = CommandType.Text;
                    FbDataReader reader3 = tNum3.ExecuteReader();

                    vcomando4 = "SELECT NUM_DOCF FROM FAMILIAR WHERE NUM_DOCF = " + maskedTextBox9.Text;

                    FbCommand tNum4 = new FbCommand(vcomando4, connection, transaction);
                    tNum4.CommandText = vcomando4;
                    tNum4.Connection = connection;
                    tNum4.CommandType = CommandType.Text;
                    FbDataReader reader4 = tNum4.ExecuteReader();

                    if (maskedTextBox9.Text == "0" && maskedTextBox2.Text == "12")
                    {
                        MessageBox.Show("EL DNI ES NECESARIO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        vsemaforo = "N";
                    }
                    else if (reader.Read() && maskedTextBox2.Text == "12")
                    {
                        MessageBox.Show("EL N° DE AFILIADO YA EXISTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        vsemaforo = "N";
                        reader.Close();
                        transaction.Commit();
                        vcomando = "";
                    }
                    else if (reader2.Read() && maskedTextBox2.Text == "12")
                    {
                        MessageBox.Show("EL N° DE DNI EXISTE EN TITULARES", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        vsemaforo = "N";
                        reader2.Close();
                        transaction.Commit();
                        vcomando2 = "";
                    }
                    else if (reader3.Read() && maskedTextBox2.Text == "12")
                    {
                        MessageBox.Show("EL N° DE DNI EXISTE EN ADHERENTES", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        vsemaforo = "N";
                        reader3.Close();
                        transaction.Commit();
                        vcomando3 = "";
                    }
                    else if (reader4.Read() && maskedTextBox2.Text == "12")
                    {
                        MessageBox.Show("EL N° DE DNI EXISTE EN FAMILIARES", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        vsemaforo = "N";
                        reader4.Close();
                        transaction.Commit();
                        vcomando4 = "";
                    }
                    else
                    {
                        vcomando = "";
                        vcomando = "P_ALTA_TITULAR_WB2 ";
                        FbCommand tNum = new FbCommand(cmd_numerador, connection, transaction);
                        vnro_socio = (int)tNum.ExecuteScalar();
                        maskedTextBox1.Text = vnro_socio.ToString();
                        vp_nro_soc = vnro_socio;
                        vp_nro_dep = System.Convert.ToInt32(maskedTextBox2.Text);
                    }
                }

                if (vsemaforo == "S")
                {
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
                            cmd.Parameters.Add(new FbParameter("@PORDDIA2", FbDbType.Integer));
                            cmd.Parameters.Add(new FbParameter("@PORDFEC2", FbDbType.Char, 8));
                            cmd.Parameters.Add(new FbParameter("@PORIGENALTA", FbDbType.Char, 3));
                            cmd.Parameters.Add(new FbParameter("@OBRASOCIAL", FbDbType.Char, 10));
                            cmd.Parameters.Add(new FbParameter("@ID_EMPLEADO", FbDbType.Integer));
                            cmd.Parameters.Add(new FbParameter("@COD_CIUDAD", FbDbType.Integer));
                            cmd.Parameters.Add(new FbParameter("@TRASPASADO", FbDbType.Char, 1));
                            cmd.Parameters.Add(new FbParameter("@CUIL", FbDbType.Char, 11));

                            cmd.Parameters["@P01"].Value = (maskedTextBox7.Text == "" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox7.Text)));
                            cmd.Parameters["@P03"].Value = (maskedTextBox6.Text == "__" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox6.Text)));

                            vp07 = (maskedTextBox4.Text == "______" ? 0 : (int)(System.Convert.ToInt32(maskedTextBox4.Text)));
                            vp08 = (maskedTextBox5.Text == "__" ? 0 : (int)(System.Convert.ToInt32(maskedTextBox5.Text)));

                            cmd.Parameters["@P07"].Value = (maskedTextBox4.Text == "______" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox4.Text)));
                            cmd.Parameters["@P08"].Value = (maskedTextBox5.Text == "__" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox5.Text)));

                            if ((vp07 == 0) && (vp08 == 0))
                                cmd.Parameters["@P05"].Value = 0;
                            else
                                cmd.Parameters["@P05"].Value = 2;

                            cmd.Parameters["@P06"].Value = (maskedTextBox3.Text == "__" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox3.Text)));
                            cmd.Parameters["@P09"].Value = textBox1.Text.Trim();
                            cmd.Parameters["@P10"].Value = textBox2.Text.Trim();
                            cmd.Parameters["@P75"].Value = (maskedTextBox10.Text == "" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox10.Text)));
                            cmd.Parameters["@P14"].Value = (maskedTextBox14.Text == "_____" ? 0 : (System.Convert.ToInt32(maskedTextBox14.Text)));

                            if (maskedTextbox15.Text == " " || maskedTextbox15.Text.Length == 0)
                                cmd.Parameters["@P16"].Value = null;
                            else
                                cmd.Parameters["@P16"].Value = maskedTextbox15.Text.Trim();

                            if (maskedTextbox21.Text == " " || maskedTextbox21.Text.Length == 0)
                                cmd.Parameters["@P17"].Value = null;
                            else
                                cmd.Parameters["@P17"].Value = maskedTextbox21.Text.Trim();

                            cmd.Parameters["@P18"].Value = (comboBox8.SelectedValue == null ? "" : comboBox8.SelectedValue.ToString());

                            cmd.Parameters["@P19"].Value = (maskedTextBox9.Text == "_________" ? 0 : (int?)(System.Convert.ToInt64(maskedTextBox9.Text)));

                            if (maskedTextbox8.Text == " " || maskedTextbox8.Text.Length == 0)
                                cmd.Parameters["@P20"].Value = null;
                            else
                                cmd.Parameters["@P20"].Value = maskedTextbox8.Text.Trim();

                            cmd.Parameters["@P21"].Value = textBox4.Text.Trim();
                            cmd.Parameters["@P22"].Value = textBox5.Text.Trim();
                            cmd.Parameters["@P23"].Value = textBox6.Text.Trim();
                            cmd.Parameters["@P24"].Value = textBox7.Text.Trim();
                            cmd.Parameters["@P25"].Value = textBox9.Text.Trim();
                            cmd.Parameters["@P26"].Value = textBox8.Text.Trim();
                            cmd.Parameters["@P92"].Value = textBox18.Text.Trim();
                            cmd.Parameters["@P27"].Value = (comboBox7.SelectedValue == null ? "" : comboBox7.SelectedValue.ToString());

                            if (maskedTextBox11.Text != "")
                                cmd.Parameters["@P28"].Value = Convert.ToInt32(maskedTextBox11.Text.Trim());
                            else
                                cmd.Parameters["@P28"].Value = null;

                            cmd.Parameters["@P29"].Value = textBox10.Text;

                            if (maskedTextBox12.Text != "")
                                cmd.Parameters["@P30"].Value = Convert.ToInt32(maskedTextBox12.Text.Trim());
                            else
                                cmd.Parameters["@P30"].Value = null;

                            cmd.Parameters["@P31"].Value = textBox11.Text.Trim();
                            cmd.Parameters["@P44"].Value = textBox14.Text.Trim();

                            if (maskedTextbox17.Text == " " || maskedTextbox17.Text.Length == 0)
                                cmd.Parameters["@P32"].Value = null;
                            else
                                cmd.Parameters["@P32"].Value = maskedTextbox17.Text.Trim();

                            cmd.Parameters["@P33"].Value = (comboBox6.SelectedValue == null ? "" : comboBox6.SelectedValue.ToString());

                            if (maskedTextbox25.Text == " " || maskedTextbox25.Text.Length == 0)
                                cmd.Parameters["@P34"].Value = null;
                            else
                                cmd.Parameters["@P34"].Value = maskedTextbox25.Text.Trim();

                            cmd.Parameters["@P35"].Value = (comboBox4.SelectedValue == null ? "" : comboBox4.SelectedValue.ToString());

                            if (maskedTextbox23.Text == " " || maskedTextbox23.Text.Length == 0)
                                cmd.Parameters["@P36"].Value = null;
                            else
                                cmd.Parameters["@P36"].Value = maskedTextbox23.Text.Trim();

                            cmd.Parameters["@P37"].Value = textBox15.Text;

                            cmd.Parameters["@P38"].Value = (comboBox1.SelectedValue == null ? "" : comboBox1.SelectedValue.ToString());

                            if (maskedTextbox26.Text == " " || maskedTextbox26.Text.Length == 0)
                                cmd.Parameters["@P39"].Value = null;
                            else
                                cmd.Parameters["@P39"].Value = maskedTextbox26.Text.Trim();

                            cmd.Parameters["@P40"].Value = textBox19.Text;

                            cmd.Parameters["@P41"].Value = (comboBox5.SelectedValue == null ? "" : comboBox5.SelectedValue.ToString());

                            if (maskedTextbox22.Text == " " || maskedTextbox22.Text.Length == 0)
                                cmd.Parameters["@P43"].Value = null;
                            else
                                cmd.Parameters["@P43"].Value = maskedTextbox22.Text.Trim();

                            if (maskedTextbox24.Text == " " || maskedTextbox24.Text.Length == 0)
                                cmd.Parameters["@P47"].Value = null;
                            else
                                cmd.Parameters["@P47"].Value = maskedTextbox24.Text.Trim();

                            cmd.Parameters["@P48"].Value = (comboBox3.SelectedValue == null ? "" : comboBox3.SelectedValue.ToString());
                            cmd.Parameters["@P49"].Value = (maskedTextBox18.Text == "" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox18.Text)));

                            cmd.Parameters["@P33"].Value = (comboBox6.SelectedValue == null ? "" : comboBox6.SelectedValue.ToString());

                            cmd.Parameters["@P93"].Value = textBox12.Text.Trim();

                            if (maskedTextbox19.Text == " " || maskedTextbox19.Text.Length == 0)
                                cmd.Parameters["@P50"].Value = null;
                            else
                                cmd.Parameters["@P50"].Value = maskedTextbox19.Text.Trim();

                            cmd.Parameters["@P51"].Value = (comboBox2.SelectedValue == null ? "" : comboBox2.SelectedValue.ToString());

                            if (maskedTextbox16.Text == " " || maskedTextbox16.Text.Length == 0)
                                cmd.Parameters["@P52"].Value = null;
                            else
                                cmd.Parameters["@P52"].Value = maskedTextbox16.Text.Trim();

                            cmd.Parameters["@P53"].Value = textBox3.Text.Trim();

                            cmd.Parameters["@P54"].Value = (comboBox9.SelectedValue == null ? "000Z" : comboBox9.SelectedValue.ToString());
                            cmd.Parameters["@P55"].Value = (comboBox10.SelectedValue == null ? "" : comboBox10.SelectedValue.ToString());
                            cmd.Parameters["@P65"].Value = 0;
                            cmd.Parameters["@P67"].Value = imageToByteArray(pictureBox1.Image);
                            cmd.Parameters["@P71"].Value = (maskedTextBox13.Text == "" ? 0 : (int?)(System.Convert.ToInt32(maskedTextBox13.Text)));
                            cmd.Parameters["@P72"].Value = textBox13.Text.Trim();
                            cmd.Parameters["@P73"].Value = vp_nro_soc;
                            cmd.Parameters["@P74"].Value = vp_nro_dep;
                            cmd.Parameters["@P90"].Value = "";

                            if (maskedTextbox27.Text == " " || maskedTextbox27.Text.Length == 0)
                                cmd.Parameters["@P94"].Value = null;
                            else
                                cmd.Parameters["@P94"].Value = maskedTextbox27.Text;

                            cmd.Parameters["@P95"].Value = textBox16.Text.Trim();

                            if (maskedTextbox20.Text == " " || maskedTextbox20.Text.Length == 0)
                                cmd.Parameters["@P96"].Value = null;
                            else
                                cmd.Parameters["@P96"].Value = maskedTextbox20.Text.Trim();

                            cmd.Parameters["@PORDDIA2"].Value = (mskOrDia2.Text == "" ? 0 : (int?)(System.Convert.ToInt32(mskOrDia2.Text)));

                            if (mskFecOrDia2.Text == " " || mskFecOrDia2.Text.Length == 0)
                                cmd.Parameters["@PORDFEC2"].Value = null;
                            else
                                cmd.Parameters["@PORDFEC2"].Value = mskFecOrDia2.Text.Trim();

                            cmd.Parameters["@PORIGENALTA"].Value = (cmbOrAlta.SelectedValue == null ? "" : cmbOrAlta.SelectedValue.ToString());
                            cmd.Parameters["@OBRASOCIAL"].Value = textBox17.Text.Trim();

                            cmd.Parameters["@ID_EMPLEADO"].Value = tbIdEmp.Text.Trim();
                            cmd.Parameters["@TRASPASADO"].Value = tbTraspasado.Text.Trim();

                            if (tbCiudad.Text.Trim() != "")
                                cmd.Parameters["@COD_CIUDAD"].Value = Convert.ToInt32(tbCiudad.Text.Trim());
                            else
                                cmd.Parameters["@COD_CIUDAD"].Value = 0;

                            if (tbCUIL.Text.Trim() != "")
                                cmd.Parameters["@CUIL"].Value = tbCUIL.Text.Trim();
                            else
                                cmd.Parameters["@CUIL"].Value = "";

                            richTextbox1.SaveFile(@"TEMP.RTF", RichTextBoxStreamType.RichText);
                            FileStream stream = new FileStream(@"TEMP.RTF", FileMode.Open, FileAccess.Read);
                            int size = Convert.ToInt32(stream.Length);
                            Byte[] rtf = new Byte[size];
                            stream.Read(rtf, 0, size);
                            cmd.Parameters["@P91"].Value = rtf;
                            stream.Dispose();

                            cmd.ExecuteNonQuery();

                            if (vBajaCascada == "S")
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
                                cmd2.Parameters["@VF_BAJCI"].Value = maskedTextbox25.Text.Trim();
                                cmd2.ExecuteNonQuery();
                            }

                            v_semaforo_baja = "N";
                            transaction.Commit();
                            connection.Dispose();
                            MessageBox.Show("OPERACION EFECTUADA EXISTOSAMENTE", vcomando.Substring(2, 6), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fin_alta();
                        }
                    }
                    catch (FbException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void fin_alta()
        {
            errorProvider1.Clear();
            cancelar.Enabled = false;
            grabar.Enabled = false;
            buscar.Enabled = true;
            editar.Enabled = false;
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
            mskCmpte.ReadOnly = true;
            mskImporte.ReadOnly = true;
            richTextbox1.ReadOnly = true;
            maskedTextbox27.ReadOnly = true;
            maskedTextbox25.ReadOnly = true;
            textBox16.ReadOnly = true;
            textBox17.ReadOnly = true;
            tbIdEmp.ReadOnly = true;
            tbTraspasado.ReadOnly = true;
            tbCiudad.ReadOnly = true;
            //tbCUIL.ReadOnly = true;

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

            cmbOrAlta.PreventDropDown = true;
            cmbOrAlta.BackColor = Color.FromName("Control");
            cmbOrAlta.ForeColor = Color.FromName("Black");

            maskedTextbox26.ReadOnly = true;

            if (VGlobales.vp_role == "SISTEMAS")
            {
                textBox19.ReadOnly = true;
                comboBox5.PreventDropDown = true;
                comboBox5.BackColor = Color.FromName("Control");
                comboBox5.ForeColor = Color.FromName("Black");
            }

            maskedTextBox14.ReadOnly = true;
            maskedTextbox16.ReadOnly = true;
            maskedTextbox15.ReadOnly = true;
            maskedTextbox17.ReadOnly = true;
            maskedTextBox18.ReadOnly = true;
            maskedTextbox19.ReadOnly = true;
            mskCodDestino.ReadOnly = true;
            mskOrDia2.ReadOnly = true;
            mskFecOrDia2.ReadOnly = true;
            maskedTextbox20.ReadOnly = true;
            maskedTextbox21.ReadOnly = true;
            maskedTextbox22.ReadOnly = true;
            textBox15.ReadOnly = true;
            maskedTextbox23.ReadOnly = true;
            maskedTextbox24.ReadOnly = true;
            maskedTextbox25.ReadOnly = true;
            btnAdquirir.Enabled = false;
            isediting = "NO";
            isadding = "NO";
            v_Cod_Dto = textBox15.Text;
            v_NCod_Dto = textBox18.Text;
            v_Fec_BajaCI = maskedTextbox25.Text;

            if (comboBox4.SelectedValue == null || comboBox4.SelectedIndex == -1)
                v_Cmb4_MBajCI = string.Empty;
            else
                v_Cmb4_MBajCI = comboBox4.SelectedValue.ToString();
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode =
            System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, width, height);
            g.Dispose();

            return (System.Drawing.Image)b;
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

        private void TabsSocios_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (isadding == "SI" || isediting == "SI")
            {
                if (TabsSocios.SelectedTab == TabFamiliares || TabsSocios.SelectedTab == TabAdherentes || TabsSocios.SelectedTab == TabInvitados)
                {
                    TabsSocios.SelectedTab = TabTitular;
                    MessageBox.Show("SI EDITA O AGREGA TITULARES NO PUEDE PASAR A \n SOLAPA DE FAMILIARES O ADHERENTES O INV.PARTICIPATIVOS", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                if (TabsSocios.SelectedTab == TabAdherentes)
                {
                    if ((VGlobales.v_soc_fallecido == "5") || (VGlobales.v_soc_fallecido == "8"))
                    {
                        btnImportarAdherentes.Enabled = false;
                        btnNuevoAdherente.Enabled = false;
                    }
                }
                else
                {
                    if (TabsSocios.SelectedTab == TabFamiliares)
                    {
                        if ((VGlobales.v_soc_fallecido == "5") || (VGlobales.v_soc_fallecido == "8"))
                        {
                            btnNuevoFamiliar.Enabled = false;
                        }
                    }
                    else
                    {
                        if (TabsSocios.SelectedTab == TabInvitados)
                        {
                            if ((VGlobales.v_soc_fallecido == "5") || (VGlobales.v_soc_fallecido == "8"))
                            {
                                btnNuevoParticipativo.Enabled = true;
                            }
                        }
                        else
                        {
                            if (TabsSocios.SelectedTab == TabVitalicios)
                            {
                                if (comboBox1.Text.Contains("VITALICIO"))
                                {
                                    CancelarVit.Enabled = false;
                                    GrabarVit.Enabled = false;
                                    ListarVit.Enabled = true;
                                }
                                else
                                {
                                    NuevoVit.Enabled = false;
                                    EditarVit.Enabled = false;
                                    CancelarVit.Enabled = false;
                                    GrabarVit.Enabled = false;
                                    ListarVit.Enabled = false;
                                }
                            }
                        }
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

                if (ctrl.Text.Length != 0)
                {
                    if (IsValidDate(ctrl.Text))
                    {
                        DateTime dateTime;
                        input = ctrl.Text.Substring(4, 4) + "-" +  // paso la fecha a formato yyyy-mm-dd 
                                ctrl.Text.Substring(2, 2) + "-" +  // para validar 
                                ctrl.Text.Substring(0, 2);

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

        private static bool IsValidDate(string dt)
        {
            return (Regex.IsMatch(dt, "^(0[1-9]|1[0-9]|2[0-9]|3[0-1])" + "(0[1-9]|1[0-2])" + "((19|20)\\d{2})$"));
        }
        
        private void msk_textChanged(object sender, EventArgs e)
        {
            if (!v_load)
            {
                Control ctrl = (Control)sender;
                errorProvider1.SetError(ctrl, "");

                switch (ctrl.Name)
                {
                    case "maskedTextbox17":   // F. Baja Policial
                    {
                        errorProvider1.SetError(comboBox6, "");

                        if (ctrl.Text.Length == 0 || ctrl.Text == string.Empty || ctrl.Text == "      ")
                        {
                            comboBox6.SelectedIndex = -1;
                            comboBox6.Enabled = false;
                        }
                        else
                        {
                            comboBox6.Enabled = true;

                            if (comboBox6.SelectedIndex != -1)
                            {
                                if (((comboBox6.SelectedValue.ToString()) != "1" && (comboBox6.SelectedValue.ToString()) != "9" && (comboBox6.SelectedValue.ToString()) != "0"))
                                {
                                    if (v_semaforo_baja == "S") // Si NO estaba informado lo cambia
                                    {
                                        maskedTextbox25.Text = maskedTextbox17.Text;
                                        comboBox4.Enabled = true;
                                    }
                                }
                            }
                        }
                    }
                    break;

                    case "comboBox6":   // Combo MOtivo Baja Policial
                    {
                        errorProvider1.SetError(comboBox6, "");

                        if (comboBox6.SelectedIndex != -1)
                        {
                            if (((comboBox6.SelectedValue.ToString()) != "1" && (comboBox6.SelectedValue.ToString()) != "9" && (comboBox6.SelectedValue.ToString()) != "0"))
                            {
                                if (v_semaforo_baja == "S")
                                {
                                    Setear_BajaCir(comboBox6.SelectedValue.ToString());
                                }
                            }
                            else
                            {
                                if ((comboBox6.SelectedValue.ToString() == "0"))
                                {
                                    textBox15.Text = "A/S";
                                }
                            }
                        }
                    }
                    break;

                    case "maskedTextbox25":
                    {
                        errorProvider1.SetError(comboBox4, "");

                        if (ctrl.Text.Length == 0 || ctrl.Text == string.Empty || ctrl.Text == "      ")
                        {
                            comboBox4.SelectedIndex = -1;
                            comboBox4.Enabled = false;
                        }
                        else
                        {
                            textBox15.Text = "000";
                            textBox18.Text = "000";
                            comboBox4.Enabled = true;
                        }
                    }
                    break;

                    default:
                    break;
                }
            }
        }

        private void Setear_BajaCir(string valor)
        {
            maskedTextbox25.Text = maskedTextbox17.Text;
            comboBox4.Enabled = true;

            if (v_par == 2) //Pasividad
            {
                switch (valor)
                {
                    case "2":   // BAJA TOTAL
                        comboBox4.SelectedValue = 8;
                        break;
  
                    case "3":   //  CESANTIA
                        comboBox4.SelectedValue = 8;
                        break;
                    
                    case "4":   // EXONERACION
                        comboBox4.SelectedValue = 8;
                        break;
                    
                    case "5":   // FALLECIDO
                        comboBox4.SelectedValue = 5;
                        break;
                    
                    case "7":   // RENUNCIA
                        comboBox4.SelectedValue = 7;
                        break;
                    
                    case "8":   // POSIBLE FALLECIMIENTO
                        comboBox4.SelectedValue = 8;
                        break;
                    
                    case "A":   // MOTIVO DESCONOCIDO
                        comboBox4.SelectedValue = 8;
                        break;

                    default:
                        break;
                }
            }
            else  //Actividad
            {
                switch (valor)
                {
                    case "2":   // BAJA TOTAL
                        comboBox4.SelectedValue = 1;
                        break;

                    case "3":   //  CESANTIA
                        comboBox4.SelectedValue = 1;
                        break;
                    
                    case "4":   // EXONERACION
                        comboBox4.SelectedValue = 1;
                        break;

                    case "5":   // FALLECIDO
                        comboBox4.SelectedValue = 5;
                        break;
                    
                    case "7":   // RENUNCIA
                        comboBox4.SelectedValue = 7;
                        break;

                    case "8":   // POSIBLE FALLECIMIENTO
                        comboBox4.SelectedValue = 1;
                        break;

                    case "A":   // MOTIVO DESCONOCIDO
                        comboBox4.SelectedValue = 1;
                        break;

                    default:
                        break;
                }
            }
        }

        // Modificado por Sebastian 17-02-2016 hasta la 4093
        private void GenerarCarnetLocal()
        {
            if (maskedTextbox21.Text == "")
            {
                MessageBox.Show("NO SE PUEDE EMITIR UN CARNET SIN FECHA DE ALTA AL CIRCULO");
                return;
            }
            else
            {




                if (textBox15.Text == "640" || textBox15.Text == "740" || textBox15.Text == "642" || textBox15.Text == "A/S" || textBox15.Text.Trim() == "13" || textBox15.Text == "EEE" || textBox15.Text == "MET")
                {
                    string v_coneccion_acces = "";
                    string v_provider;
                    string vcadena;
                    string vp1 = "";
                    string vp2 = "";
                    string vp3 = "";
                    string vcodigobarra = "";
                    string Fecha = "";
                    string Afiliado_Beneficio = "";
                    string Legajo = "";
                    Fecha = maskedTextbox21.Text.Substring(2, 2) + "/" + maskedTextbox21.Text.Substring(4, 4);
                    string NroSocio = maskedTextBox1.Text;
                    string Nombre = textBox2.Text;
                    string Apellido = textBox1.Text;
                    string Documento = maskedTextBox9.Text;
                    Datos_ini ini_carnet = new Datos_ini();
                    int TipoCarnet;
                    SOCIOS.Carnet.GeneradorCarnet genCarnet;


                    if (comboBox1.SelectedValue.ToString() == "001" || comboBox1.SelectedValue.ToString() == "003")
                    {
                        TipoCarnet = (int)SOCIOS.Carnet.Tipo_Carnet.TITULAR;
                    }
                    else if (comboBox1.SelectedValue.ToString() == "006")
                    {
                        TipoCarnet = (int)SOCIOS.Carnet.Tipo_Carnet.SOCIO_INVITADO;
                    }
                    else if (comboBox1.SelectedValue.ToString() == "012")
                    {
                        TipoCarnet = (int)SOCIOS.Carnet.Tipo_Carnet.METROPOLITANA;
                    }
                    else if (comboBox1.SelectedValue.ToString() == "002")
                    {
                        TipoCarnet = (int)SOCIOS.Carnet.Tipo_Carnet.VITALCIO;
                    }
                    else if (comboBox1.SelectedValue.ToString() == "007")
                    {
                        TipoCarnet = (int)SOCIOS.Carnet.Tipo_Carnet.EMPLEADO;
                        Legajo = maskedTextBox6.Text;
                    }
                    else
                    {
                        TipoCarnet = (int)SOCIOS.Carnet.Tipo_Carnet.TITULAR;
                    }




                    if (v_par == 2)
                    {
                        vp1 = v_pcrjp1.ToString();
                        vp2 = v_pcrjp2.ToString();
                        vp3 = v_pcrjp3.ToString();
                    }
                    else
                    {
                        vp3 = v_acrjp3.ToString();
                        vp1 = maskedTextBox7.Text;
                        vp2 = maskedTextBox6.Text;
                    }

                    vcodigobarra = maskedTextBox1.Text.Trim();
                    vcodigobarra = vcodigobarra.PadLeft(6, '0');
                    vcodigobarra = "T" + vcodigobarra + maskedTextBox2.Text.Trim().PadLeft(3, '0');

                    if (TipoCarnet != (int)SOCIOS.Carnet.Tipo_Carnet.EMPLEADO)
                    {
                        Afiliado_Beneficio = vp1 + "  /  " + vp2 + "  /  " + vp3;
                    }


                    System.Drawing.Image Imagen;

                    if (VGlobales.Imagen_Editada)
                        Imagen = VGlobales.Imagen_Carnet;
                    else
                        Imagen = pictureBox1.Image;

                    genCarnet = new SOCIOS.Carnet.GeneradorCarnet(TipoCarnet, SOCIOS.Utils.ImagenCarnet(Imagen));

                    if (genCarnet.GenerarCarnet(Fecha, NroSocio, Apellido, Nombre, Documento, Afiliado_Beneficio, vcodigobarra, Legajo, "", ""))
                    {
                        this.GrabarFechaCarnet();
                    }
                    else
                    {

                    }
                }
            }
        }


        private void GrabarFechaCarnet()
        {
            conString conString = new conString();
            string connectionString = conString.get();

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
        
       private void toolStripButton1_Click_1(object sender, EventArgs e) //IMPRIMIR CARNET
       {
           Generar_Carnet_ODBC();
       }

       private void Generar_Carnet_ODBC()
       {
           if (maskedTextbox21.Text == "")
           {
               MessageBox.Show("NO SE PUEDE EMITIR UN CARNET SIN FECHA DE ALTA AL CIRCULO");
               return;
           }
           else
           {
               if (textBox15.Text == "640" || textBox15.Text == "740" || textBox15.Text == "642" || textBox15.Text == "A/S" || textBox15.Text.Trim() == "13"
                   || textBox15.Text == "EEE" || textBox15.Text == "MET" || textBox15.Text == "781" || textBox15.Text == "187")
               {
                   string v_coneccion_acces = "";
                   string v_provider;
                   string vcadena;
                   string vp1 = "";
                   string vp2 = "";
                   string vp3 = "";
                   string aar = "";
                   string vcodigobarra = "";
                   string alt_ci = maskedTextbox21.Text.Substring(2, 2) + "/" + maskedTextbox21.Text.Substring(4, 4);

                   Datos_ini ini_carnet = new Datos_ini();

                   if (comboBox1.SelectedValue.ToString() == "001" || comboBox1.SelectedValue.ToString() == "003")
                   {
                       v_coneccion_acces = ini_carnet.Vcarnet_titular;
                   }
                   else if (comboBox1.SelectedValue.ToString() == "006")
                   {
                       v_coneccion_acces = ini_carnet.Vcarnet_socio_invitado;
                   }
                   else if (comboBox1.SelectedValue.ToString() == "002")
                   {
                       v_coneccion_acces = ini_carnet.Vcarnet_vitalicio;
                   }
                   else if (comboBox1.SelectedValue.ToString() == "007")
                   {
                       v_coneccion_acces = ini_carnet.Vcarnet_socio_empleado;
                   }
                   else if (comboBox1.SelectedValue.ToString() == "012")
                   {
                       v_coneccion_acces = ini_carnet.Vcarnet_metro;
                   }
                   else if (comboBox1.SelectedValue.ToString() == "015")
                   {
                       v_coneccion_acces = ini_carnet.Vcarnet_adh_interfuerza;
                   }
                   else
                   {
                       v_coneccion_acces = ini_carnet.Vcarnet_titular;
                   }

                   v_provider = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + v_coneccion_acces;

                   OleDbConnection aConnection = new OleDbConnection(v_provider);

                   if (v_par == 2)
                   {
                       vp1 = v_pcrjp1.ToString();
                       vp2 = v_pcrjp2.ToString();
                       vp3 = v_pcrjp3.ToString();
                   }
                   else
                   {
                       vp3 = v_acrjp3.ToString();
                       vp1 = maskedTextBox7.Text;
                       vp2 = maskedTextBox6.Text;
                   }
                   
                   vcodigobarra = maskedTextBox1.Text.Trim();
                   vcodigobarra = vcodigobarra.PadLeft(6, '0');
                   vcodigobarra = vcodigobarra + maskedTextBox2.Text.Trim().PadLeft(3, '0');

                   vcadena = "INSERT INTO IDProjectData (IDCf_altci, IDCBarCodeField1, IDCnro_soc, IDCape_soc, IDCNOM_SOC, IDCnro_doc, IDCTIP_DOC, IDCCRJP1, IDCCRJP2, IDCcrjp3, IDCfoto) ";
                   vcadena = vcadena + " VALUES ('" + alt_ci + "', '" + "T" + vcodigobarra + "', '" + maskedTextBox1.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "','" + maskedTextBox9.Text + "'," + "'DNI'" + "," + "'" + vp1 + "'" + "," + "'" + vp2 + "'" + ", '" + vp3 + "', ?)";

                   if (maskedTextBox2.Text == "17" || maskedTextBox2.Text == "017")
                   {
                       vcadena = "INSERT INTO IDProjectData (IDCf_altci, IDCBarCodeField1, IDCnro_soc, IDCape_soc, IDCNOM_SOC, IDCnro_doc, IDCTIP_DOC, IDCCRJP1, IDCCRJP2, IDCcrjp3, IDCfoto, IDCNRO_DEP) ";
                       vcadena = vcadena + " VALUES ('" + alt_ci + "', '" + "T" + vcodigobarra + "', '" + maskedTextBox1.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "','" + maskedTextBox9.Text + "'," + "'DNI'" + "," + "'" + vp1 + "'" + "," + "'" + vp2 + "'" + ", '" + vp3 + "', ?, '" + maskedTextBox2.Text + "')";
                   }

                   if (maskedTextBox2.Text == "20" || maskedTextBox2.Text == "020")
                   {
                       vcadena = "INSERT INTO IDProjectData (IDCf_altci, IDCBarCodeField1, IDCnro_soc, IDCape_soc, IDCNOM_SOC, IDCnro_doc, IDCTIP_DOC, IDCCRJP1, IDCCRJP2, IDCcrjp3, IDCfoto) ";
                       vcadena = vcadena + " VALUES ('" + alt_ci + "', '" + "T" + vcodigobarra + "', '" + maskedTextBox1.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "','" + maskedTextBox9.Text + "'," + "'DNI'" + "," + "'" + tbIdEmp.Text + "'" + "," + "'" + vp2 + "'" + ", '" + vp3 + "', ?)";
                   }
                   
                   OleDbParameter parImagen = new OleDbParameter("@imagen", OleDbType.LongVarBinary, imageToByteArray(pictureBox1.Image).Length);
                   parImagen.Value = imageToByteArray(pictureBox1.Image);
                   OleDbCommand aCommand = new OleDbCommand(vcadena, aConnection);
                   aCommand.Parameters.Add(parImagen);
                   aConnection.Open();
                   aCommand.ExecuteNonQuery();
                   aConnection.Close();

                   maskedTextbox24.Text = DateTime.Today.Date.Day.ToString().PadLeft(2, '0') + DateTime.Today.Date.Month.ToString().PadLeft(2, '0') + DateTime.Today.Date.Year.ToString();

                   conString conString = new conString();
                   string connectionString = conString.get();

                   using (FbConnection connection = new FbConnection(connectionString))
                   {
                       string vcomando;
                       vcomando = "UPDATE TITULAR SET F_CARN=CURRENT_DATE WHERE NRO_SOC=" + maskedTextBox1.Text + " AND NRO_DEP=" + maskedTextBox2.Text;
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
               {
                   MessageBox.Show("NO SE PUEDE IMPRIMIR EL CARNET DE ESTE SOCIO, VERIFIQUE");
               }
           }
       }

       private void toolStripButton2_Click_2(object sender, EventArgs e) //IMPRIMIR FICHA
       {
           genHTML gen = new genHTML();
           gen.fichaTitular(int.Parse(maskedTextBox1.Text), int.Parse(maskedTextBox2.Text));
       } 

       private void HabilitarCamposVit()
       {
           GrabarVit.Enabled = true;
           CancelarVit.Enabled = true;
           EditarVit.Enabled = false;
           NuevoVit.Enabled = false;
           medalla_plata.ReadOnly = false;
           fecha_vit.ReadOnly = false;
           lugar_vit.PreventDropDown = false;
           lugar_vit.Enabled = true;
           diploma.Enabled = true;
           suscriptor.Enabled = true;
           medalla_plata.Focus();
           medalla_oro.Enabled = true;
           fecha_oro.ReadOnly = false;
           lugar_oro.PreventDropDown = false;
           lugar_oro.Enabled = true;
           diploma_oro.Enabled = true;
           suscriptor_oro.Enabled = true;
           carnet.Enabled = true;
           observac_vit.ReadOnly = false;
           lugar_vit.BackColor = Color.FromName("white");
           lugar_vit.ForeColor = Color.FromName("Black");
           lugar_oro.BackColor = Color.FromName("white");
           lugar_oro.ForeColor = Color.FromName("Black");
       }

       private void Cargo_Vit()
       {
           string vcmd_v;
           string string_combo;
           lugar_vit.DisplayMember = "descrip";
           lugar_vit.ValueMember = "codigo";
           lugar_vit.DataSource = Socios.dsllc.Tables["LUGAR1"];
           lugar_oro.DisplayMember = "descrip";
           lugar_oro.ValueMember = "codigo";
           lugar_oro.DataSource = Socios.dsllc.Tables["LUGAR2"];

           

           try
           {
               conString conString = new conString();
               string connectionString = conString.get();

               using (FbConnection connection = new FbConnection(connectionString))
               {
                   connection.Open();
                   FbTransaction transaction = connection.BeginTransaction();
                   vcmd_v = "SELECT * FROM TITULAR_VITALICIO WHERE NRO_SOC=" + vp_nro_soc + " AND NRO_DEP=" + vp_nro_dep;
                   FbCommand cmd = new FbCommand(vcmd_v, connection, transaction);
                   FbDataReader mt = cmd.ExecuteReader();
                   lugar_vit.SelectedIndex = -1;
                   lugar_oro.SelectedIndex = -1;

                   if (mt.Read())
                   {
                       EditarVit.Enabled = true;
                       NuevoVit.Enabled = false;
                       v_vit_edito = true;
                       v_vit_nuevo = false;

                       if (mt.GetString(mt.GetOrdinal("NRO_MEDALLA_ORO")).TrimEnd() == "S")
                           medalla_oro.Checked = true;
                       else
                           medalla_oro.Checked = false;

                       medalla_plata.Text = (mt.GetString(mt.GetOrdinal("NRO_MEDALLA_PLATA"))).TrimEnd();
                       fecha_vit.Text = (mt.GetString(mt.GetOrdinal("FECHA"))).TrimEnd();
                       fecha_oro.Text = (mt.GetString(mt.GetOrdinal("FECHA_ORO"))).TrimEnd();
                       lugar_vit.SelectedValue = mt.GetString(mt.GetOrdinal("LUGAR")).TrimEnd();
                       lugar_oro.SelectedValue = mt.GetString(mt.GetOrdinal("LUGAR_ORO")).TrimEnd();

                       if (mt.GetString(mt.GetOrdinal("SUSCRIPTOR_ORO")).TrimEnd() == "S")
                           suscriptor_oro.Checked = true;
                       else
                           suscriptor_oro.Checked = false;

                       if (mt.GetString(mt.GetOrdinal("SUSCRIPTOR")).TrimEnd() == "S")
                           suscriptor.Checked = true;
                       else
                           suscriptor.Checked = false;

                       if (mt.GetString(mt.GetOrdinal("DIPLOMA_ORO")).TrimEnd() == "S")
                           diploma_oro.Checked = true;
                       else
                           diploma_oro.Checked = false;

                       if (mt.GetString(mt.GetOrdinal("DIPLOMA")).TrimEnd() == "S")
                           diploma.Checked = true;
                       else
                           diploma.Checked = false;

                       if (mt.GetString(mt.GetOrdinal("CARNET")).TrimEnd() == "S")
                           carnet.Checked = true;
                       else
                           carnet.Checked = false;

                       observac_vit.Text = mt.GetString(mt.GetOrdinal("OBSERVAC")).TrimEnd();
                   }
                   else
                   {
                       EditarVit.Enabled = false;
                       NuevoVit.Enabled = true;
                       v_vit_edito = false;
                       v_vit_nuevo = true;
                   }
                   connection.Dispose();
               }
           }
           catch (FbException ex)
           {
               System.Windows.Forms.MessageBox.Show(ex.ToString());
               Mails1 mensaje = new Mails1();
               mensaje.Enviar_Mail_Error(ex.ToString());
           }
       }

       private bool ConsistirDatosVit()
       {
           bool datos25 = false;
           bool datos50 = false;

           if ((medalla_plata.Text != string.Empty && fecha_vit.Text.Substring(0, 1) != "_" && lugar_vit.SelectedIndex != -1))
           {
               datos25 = true;
           }
           
           if ((medalla_oro.Checked == true && fecha_oro.Text.Substring(0, 1) != "_" && lugar_oro.SelectedIndex != -1) || (medalla_oro.Checked == false && fecha_oro.Text.Substring(0, 1) == "_" && lugar_oro.SelectedIndex == -1))
           {
               datos50 = true;
           }

           if (1 == 2)
           {
               if (datos25 && datos50)
               {
                   return true;
               }
               else
               {
                   if ((!datos25 && !datos50) || (!datos25 && datos50))
                   {
                       MessageBox.Show("DATOS NO INFORMADOS O INCOMPLETOS", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                       return false;
                   }
                   else
                   {
                       MessageBox.Show("NO PUEDE INFORMAR DATOS 50 AÑOS SIN COMPLETAR DATOS 25 AÑOS", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                       return false;
                   }
               }
           }
           else
           {
               return true;
           }
       }

       private void ProtegerCamposVit()
       {
           GrabarVit.Enabled = false;
           CancelarVit.Enabled = false;
           EditarVit.Enabled = v_vit_edito;
           NuevoVit.Enabled = v_vit_nuevo;
           medalla_plata.ReadOnly = true;
           fecha_vit.ReadOnly = true;
           lugar_vit.Enabled = true;
           lugar_vit.PreventDropDown = true;
           diploma.Enabled = false;
           suscriptor.Enabled = false;
           medalla_oro.Enabled = false;
           fecha_oro.ReadOnly = true;
           lugar_oro.Enabled = true;
           lugar_oro.PreventDropDown = true;
           diploma_oro.Enabled = false;
           suscriptor_oro.Enabled = false;
           carnet.Enabled = false;
           observac_vit.ReadOnly = true;
           lugar_vit.BackColor = Color.FromName("Control");
           lugar_vit.ForeColor = Color.FromName("Black");
           lugar_oro.BackColor = Color.FromName("Control");
           lugar_oro.ForeColor = Color.FromName("Black");
       }
        
       private void fecha_TypeValidationCompleted(object sender, System.Windows.Forms.TypeValidationEventArgs e)
       {
           Control ctrl = (Control)sender;

           if (e.IsValidInput)
           {
               dateVal = (DateTime)e.ReturnValue;
               errorProvider1.SetError(ctrl, "");
                
               if (ctrl.Name != "mskFecAlta" && ctrl.Name != "mskFecBaja")
               {
                   if (!VerificarAños(ctrl.Name))
                   {
                       errorProvider1.SetError(ctrl, "FECHA INVALIDA - NO SUPERA AÑOS MINIMOS");
                   }
               }
           }
           else
           {
               if (ctrl.Text != string.Empty)
               {
                   dateVal = DateTime.MinValue;
                   errorProvider1.SetError(ctrl, "FECHA INVALIDA - CORRIJA");
                   ctrl.Focus();
               }
           }
       }

       private bool VerificarAños(string name)
       {
           DateTime fecVitOro;
           DateTime fecAltaCi = new DateTime(Convert.ToInt32(maskedTextbox21.Text.Substring(4, 4)), Convert.ToInt32(maskedTextbox21.Text.Substring(2, 2)), Convert.ToInt32(maskedTextbox21.Text.Substring(0, 2)));

           if (name == "fecha_vit")
           {
               fecVitOro = fecAltaCi.AddYears(25);
           }
           else
           {
               fecVitOro = fecAltaCi.AddYears(50);
           }

           if (DateTime.Compare(dateVal, fecVitOro) < 0)
           {
               return false;
           }
           else
           {
               return true;
           }
       }

       private void toolStripButton3_Click(object sender, EventArgs e)
       {
           int id_titular = (Socios.vp_nro_soc * 1000) + Socios.vp_nro_dep;
           genHTML gh = new genHTML();
           gh.authIndividualTitular(id_titular);
       }

       private void ControlEdad()
       {
           foreach (DataGridViewRow dr in dgvGrupo.SelectedRows)
           {
               int Barra = Int32.Parse(dr.Cells[3].Value.ToString());
               string Tipo = dr.Cells[5].Value.ToString();

               if (dr.Cells[10].Value != null)
               {
                   if (dr.Cells[10].Value.ToString().Length == 0)
                   {
                       if ((Tipo == "FAM" && Barra > 3) || (Tipo == "ADH" && Barra > 2))
                       {
                           throw new Exception("Falta Cargar Edad en Personas Seleccionadas");
                       }
                   }
               }
           }
       }

       private void TabObservaciones_Enter(object sender, EventArgs e)
       {
           Cargar_Observaciones();
       }
       private void TabAdherentes_Enter(object sender, EventArgs e)
       {
           Cargar_Solapa_Adh();
       }

       private void TabFamiliares_Enter(object sender, EventArgs e)
       {
           Cargar_Solapa_Fam();
       }

       private void TabInvitados_Enter(object sender, EventArgs e)
       {
           Cargar_Solapa_Inp();
       }

       private void TabVitalicios_Enter(object sender, EventArgs e)
       {
           Cargo_Vit();
       }

       private void TabServicios_Enter(object sender, EventArgs e)
       {
           Cargar_Servicios(maskedTextBox1.Text, maskedTextBox2.Text);
       }

       private void comboBox1_SelectionChangeCommitted_1(object sender, EventArgs e)
       {
           bo dlog = new bo();
           string vresult = "";
           string nro_dep = "";
           vresult = comboBox1.SelectedValue.ToString();
           string query = "SELECT NRO_DEP FROM DEPURACIONES WHERE CAT_SOC = '" + vresult + "'";
           DataRow[] foundRows;
           foundRows = dlog.BO_EjecutoDataTable(query).Select();

           if (foundRows.Length > 0)
           {
               nro_dep = foundRows[0][0].ToString();
           }

           this.maskedTextBox2.Text = nro_dep;
           comboJerarquias();
       }

       private void comboBox10_SelectedValueChanged_1(object sender, EventArgs e)
       {
           if (!v_load)
           {
               if (comboBox10.SelectedIndex == -1)
               {
                   mskCodDestino.Text = v_cmb10SelValue;
               }
               else
               {
                   mskCodDestino.Text = comboBox10.SelectedValue.ToString();
               }
           }
       }

       private void maskedTextBox2_Leave_1(object sender, EventArgs e)
       {
           if (this.maskedTextBox2.Text == "16")
           {
               int vindex = comboBox1.FindString("CIUDAD");
               comboBox1.SelectedIndex = vindex;
           }
           if (this.maskedTextBox2.Text == "016")
           {
               int vindex = comboBox1.FindString("CIUDAD");
               comboBox1.SelectedIndex = vindex;
           }
           if (this.maskedTextBox2.Text == "13")
           {
               int vindex = comboBox1.FindString("SOCIO INVITADO");
               comboBox1.SelectedIndex = vindex;
           }
           if (this.maskedTextBox2.Text == "12")
           {
               int vindex = comboBox1.FindString("NO SOCIO");
               comboBox1.SelectedIndex = vindex;
           }
           if (this.maskedTextBox2.Text == "57")
           {
               int vindex = comboBox1.FindString("SOCIO EMPLEADO");
               comboBox1.SelectedIndex = vindex;
           }
           if (this.maskedTextBox2.Text == "013")
           {
               int vindex = comboBox1.FindString("SOCIO INVITADO");
               comboBox1.SelectedIndex = vindex;
           }
           if (this.maskedTextBox2.Text == "012")
           {
               int vindex = comboBox1.FindString("NO SOCIO");
               comboBox1.SelectedIndex = vindex;
           }
           if (this.maskedTextBox2.Text == "057")
           {
               int vindex = comboBox1.FindString("SOCIO EMPLEADO");
               comboBox1.SelectedIndex = vindex;
           }
           if (this.maskedTextBox2.Text == "994")
           {
               int vindex = comboBox1.FindString("TITULAR");
               comboBox1.SelectedIndex = vindex;
           }
           if (this.maskedTextBox2.Text == "012")
           {
               int vindex = comboBox1.FindString("INVITADO DEPORTES");
               comboBox1.SelectedIndex = vindex;
           }
           comboBox1.Refresh();
       }

       private void button1_Click_1(object sender, EventArgs e)
       {
           if (dgvGrupo.SelectedRows.Count == 1)
           {
               string Nombre = dgvGrupo.SelectedRows[0].Cells[5].Value.ToString();
               string Apellido = dgvGrupo.SelectedRows[0].Cells[4].Value.ToString();
               string Tipo = dgvGrupo.SelectedRows[0].Cells[6].Value.ToString();
               string ID = dgvGrupo.SelectedRows[0].Cells[0].Value.ToString();
               string NRO = dgvGrupo.SelectedRows[0].Cells[1].Value.ToString();
               string DEP = dgvGrupo.SelectedRows[0].Cells[2].Value.ToString();
               string BARRA = dgvGrupo.SelectedRows[0].Cells[3].Value.ToString();

               CargaEdad ce = new CargaEdad(Nombre, Apellido, Tipo, ID, NRO, DEP, BARRA);
               DialogResult res = ce.ShowDialog();

               if (res == DialogResult.OK)
               {
                   dgvGrupo.DataSource = null;
                   Cargar_Servicios(maskedTextBox1.Text, maskedTextBox2.Text);
               }
           }
           else if (dgvGrupo.SelectedRows.Count > 1)
           {
               MessageBox.Show("Debe Seleccionar una Sola Persona");
           }
           else if (dgvGrupo.SelectedRows.Count == 0)
           {
               MessageBox.Show("Debe Seleccionar una  Persona");
           }
       }

       private void dgvGrupo_CellClick_1(object sender, DataGridViewCellEventArgs e)
       {
           if (dgvGrupo.SelectedRows[0].Cells[10].Value.ToString().Length == 0)
           {
               button1.Visible = true;

           }
           else
           {
               button1.Visible = false;
           }
       }

       private void dgvGrupo_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
       {
           try
           {
               DataGridViewRow row = dgvGrupo.Rows[e.RowIndex];// get you required index
               int Barra = Int32.Parse(row.Cells[3].Value.ToString());
               string Tipo = row.Cells[5].Value.ToString();
               string Edad = row.Cells[10].Value.ToString();

               if (Edad.Length == 0)
               {
                   if ((Tipo == "FAM" && Barra > 3) || (Tipo == "ADH" && Barra > 2))
                   {
                       row.DefaultCellStyle.BackColor = Color.Yellow;
                   }
               }
           }
           catch (Exception ex)
           {

           }
       }

       private void dgvGrupo_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
       {
           if (dgvGrupo.SelectedRows[0].Cells[10].Value.ToString().Length == 0)
           {
               button1.Visible = true;

           }
           else
           {
               button1.Visible = false;
           }
       }

       private void btnVerFormulario_Click_1(object sender, EventArgs e)
       {

          SOCIOS.deportes.DeportesService ds = new deportes.DeportesService();
 
           VGlobales.vp_IdSocio2 = Convert.ToInt32(dgvGrupo[0, dgvGrupo.CurrentCell.RowIndex].Value.ToString());
           VGlobales.vp_Numero = dgvGrupo[1, dgvGrupo.CurrentCell.RowIndex].Value.ToString();
           VGlobales.vp_Depuracion = dgvGrupo[2, dgvGrupo.CurrentCell.RowIndex].Value.ToString();
           VGlobales.vp_Barra = dgvGrupo[3, dgvGrupo.CurrentCell.RowIndex].Value.ToString();
           VGlobales.vp_Nombre = dgvGrupo[5, dgvGrupo.CurrentCell.RowIndex].Value.ToString();
           VGlobales.vp_Apellido = dgvGrupo[4, dgvGrupo.CurrentCell.RowIndex].Value.ToString();
           string Tipo = dgvGrupo[6, dgvGrupo.CurrentCell.RowIndex].Value.ToString();

           System.Drawing.Image foto;

           string num_doc = dgvGrupo[7, dgvGrupo.CurrentCell.RowIndex].Value.ToString();

           if (dgvGrupo[6, dgvGrupo.CurrentCell.RowIndex].Value.ToString() == "TIT")
           {
               VGlobales.vp_NombreTabla = "TITULAR";
           }
           else if (dgvGrupo[6, dgvGrupo.CurrentCell.RowIndex].Value.ToString() == "FAM")
           {
               VGlobales.vp_NombreTabla = "FAMILIAR";
           }
           else if (dgvGrupo[6, dgvGrupo.CurrentCell.RowIndex].Value.ToString() == "ADH")
           {
               VGlobales.vp_NombreTabla = "ADHERENT";
           }

           switch (cbServicio.SelectedValue.ToString().Trim())
           {
               case "turnos":
                   turnos frmTurnos = new turnos(VGlobales.vp_NombreTabla, VGlobales.vp_Numero, VGlobales.vp_Depuracion, VGlobales.vp_Barra, num_doc);
                   frmTurnos.ShowDialog(this);
                   break;

               case "admDeportes":
                   
                   if (VGlobales.vp_NombreTabla == "TITULAR")
                   {
                       foto = pictureBox1.Image;
                   }
                   else
                   {
                       try
                       {
                           foto = utilCarnet.Imagen_Nativa(Int32.Parse(VGlobales.vp_Numero), Int32.Parse(VGlobales.vp_Depuracion), VGlobales.vp_NombreTabla);
                       }
                       catch (Exception ex)
                       {
                           foto = SOCIOS.Properties.Resources.fotonodisponible;
                       }

                   }


                   if (ds.ExistenRoles(VGlobales.vp_Numero, VGlobales.vp_Depuracion, VGlobales.vp_Barra))
                   {
                       SOCIOS.deportes.Selector_Deportes sd = new deportes.Selector_Deportes(VGlobales.vp_NombreTabla, VGlobales.vp_Numero, VGlobales.vp_Depuracion, VGlobales.vp_Barra, vp_nro_soc.ToString(), vp_nro_dep.ToString(), VGlobales.vp_IdScocio, num_doc, VGlobales.vp_Nombre, VGlobales.vp_Apellido, foto);
                       sd.ShowDialog();
                       sd.Focus();

                   }
                   else
                   {
                       admDeportes admdepo = new admDeportes(VGlobales.vp_NombreTabla, VGlobales.vp_Numero, VGlobales.vp_Depuracion, VGlobales.vp_Barra, vp_nro_soc.ToString(), vp_nro_dep.ToString(), VGlobales.vp_IdScocio, num_doc, VGlobales.vp_Nombre, VGlobales.vp_Apellido, foto, VGlobales.vp_role, 0, false, System.DateTime.Now);
                       admdepo.ShowDialog();
                       admdepo.Focus();
                   }
                   break;

               case "BonoOdontologico":
                    SOCIOS.bono.Odontologia.Selector_Bono_Odontologia sbo = new bono.Odontologia.Selector_Bono_Odontologia(VGlobales.vp_Numero, VGlobales.vp_Depuracion, VGlobales.vp_Barra, vp_nro_soc.ToString(), vp_nro_dep.ToString());
                    sbo.ShowDialog();
                    sbo.Focus();
                    break;

                case "BonoPasaje":
                   {
                       try
                       {
                           this.ControlEdad();
                           bono.BonoPasaje admBonoPasaje = new bono.BonoPasaje(dgvGrupo.SelectedRows, vp_nro_soc.ToString(), vp_nro_dep.ToString(), true);
                           admBonoPasaje.ShowDialog();
                           admBonoPasaje.Focus();
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show(ex.Message, "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       }
                       break;
                   }

               case "BonoSalida":
                   {
                       try
                       {
                           this.ControlEdad();
                           bono.BonoPaquete admBonoPaquete = new bono.BonoPaquete(dgvGrupo.SelectedRows, VGlobales.vp_Titular_Soc, VGlobales.vp_Titular_Dep, true);
                           admBonoPaquete.ShowDialog();
                           admBonoPaquete.Focus();
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show(ex.Message, "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       }
                       break;
                   }

               case "BonoHotel":
                   {
                       try
                       {
                           this.ControlEdad();
                           bono.BonoHotel admBonoHotel = new bono.BonoHotel(dgvGrupo.SelectedRows, VGlobales.vp_Titular_Soc, VGlobales.vp_Titular_Dep, true);
                           admBonoHotel.ShowDialog();
                           admBonoHotel.Focus();
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show(ex.Message, "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       }
                       break;
                   }

               case "SolicitudHotel":
                   SOCIOS.Turismo.Solicitudes.Solicitud solicitud = new SOCIOS.Turismo.Solicitudes.Solicitud(dgvGrupo.SelectedRows, VGlobales.vp_Titular_Soc, VGlobales.vp_Titular_Dep, true);
                   solicitud.ShowDialog();
                   solicitud.Focus();
                   break;
               case "BonoHotelCompletar":
                   {
                       try
                       {
                           this.ControlEdad();
                           bono.Bonos.Carga_Bono_Blanco_Socio bhS = new bono.Bonos.Carga_Bono_Blanco_Socio("HOT", dgvGrupo.SelectedRows, VGlobales.vp_Titular_Soc, VGlobales.vp_Titular_Dep);
                           bhS.ShowDialog();
                           bhS.Focus();
                       }

                       catch (Exception ex)
                       {
                           MessageBox.Show(ex.Message, "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       }
                       break;
                   }

               case "BonoSalidaCompletar":
                   {
                       try
                       {
                           this.ControlEdad();
                           bono.Bonos.Carga_Bono_Blanco_Socio bhS = new bono.Bonos.Carga_Bono_Blanco_Socio("PAQ", dgvGrupo.SelectedRows, VGlobales.vp_Titular_Soc, VGlobales.vp_Titular_Dep);
                           bhS.ShowDialog();
                           bhS.Focus();
                       }

                       catch (Exception ex)
                       {
                           MessageBox.Show(ex.Message, "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       }
                       break;
                   }

               case "BonoPasajeCompletar":
                   {
                       try
                       {
                           this.ControlEdad();
                           bono.Bonos.Carga_Bono_Blanco_Socio bhS = new bono.Bonos.Carga_Bono_Blanco_Socio("PAS", dgvGrupo.SelectedRows, VGlobales.vp_Titular_Soc, VGlobales.vp_Titular_Dep);
                           bhS.ShowDialog();
                           bhS.Focus();
                       }

                       catch (Exception ex)
                       {
                           MessageBox.Show(ex.Message, "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       }
                       break;
                   }



               default:
                   MessageBox.Show("default");
                   break;
           }
       }

       private void mskCodDestino_Validated_1(object sender, EventArgs e)
       {
           if (!v_load)
           {
               try
               {
                   comboBox10.SelectedValue = mskCodDestino.Text.Trim().PadLeft(4, '0');

                   if (comboBox10.SelectedIndex == -1)
                   {
                       MessageBox.Show("CODIGO DE DESTINO INEXISTENTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                   }

               }
               catch
               {
                   MessageBox.Show("CODIGO DE DESTINO INEXISTENTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
               }
           }
       }

       private void GrabarVit_Click_1(object sender, EventArgs e)
       {
           if (ConsistirDatosVit())
           {
               string vcomando1 = "";

               if (v_vit_edito == true || v_vit_nuevo == true)
               {
                   if (v_vit_edito == true && v_vit_nuevo == false)
                   {
                       vcomando1 = "P_MODIFICA_VITALICIO";
                   }
                   else
                   {
                       vcomando1 = "P_INSERTVIT";
                       v_vit_edito = true;
                       v_vit_nuevo = false;
                   }

                   conString conString = new conString();
                   string connectionString = conString.get();
                   FbConnection connection = new FbConnection(connectionString);
                   connection.Open();
                   FbTransaction transaction = connection.BeginTransaction();
                   FbCommand cmd = new FbCommand(vcomando1, connection, transaction);

                   try
                   {
                       using (connection)
                       {
                           cmd.CommandText = vcomando1;
                           cmd.Connection = connection;
                           cmd.CommandType = CommandType.StoredProcedure;
                           cmd.Parameters.Add(new FbParameter("@NRO_SOC", FbDbType.Integer));
                           cmd.Parameters.Add(new FbParameter("@NRO_DEP", FbDbType.Integer));
                           cmd.Parameters.Add(new FbParameter("@NRO_MEDALLA_ORO", FbDbType.Char, 5));
                           cmd.Parameters.Add(new FbParameter("@NRO_MEDALLA_PLATA", FbDbType.Char, 5));
                           cmd.Parameters.Add(new FbParameter("@DIPLOMA", FbDbType.Char, 1));
                           cmd.Parameters.Add(new FbParameter("@FECHA", FbDbType.Date));
                           cmd.Parameters.Add(new FbParameter("@LUGAR", FbDbType.Char, 4));
                           cmd.Parameters.Add(new FbParameter("@OBSERVAC", FbDbType.VarChar, 2000));
                           cmd.Parameters.Add(new FbParameter("@SUSCRIPTOR", FbDbType.Char, 1));
                           cmd.Parameters.Add(new FbParameter("@LUGAR_ORO", FbDbType.Char, 4));
                           cmd.Parameters.Add(new FbParameter("@FECHA_ORO", FbDbType.Date));
                           cmd.Parameters.Add(new FbParameter("@DIPLOMA_ORO", FbDbType.Char, 1));
                           cmd.Parameters.Add(new FbParameter("@SUSCRIPTOR_ORO", FbDbType.Char, 1));
                           cmd.Parameters.Add(new FbParameter("@CARNET", FbDbType.Char, 1));
                           cmd.Parameters.Add(new FbParameter("@MED_ORO", FbDbType.Char, 1));
                           cmd.Parameters["@NRO_SOC"].Value = vp_nro_soc;
                           cmd.Parameters["@NRO_DEP"].Value = vp_nro_dep;
                           cmd.Parameters["@MED_ORO"].Value = " ";
                           
                           if (medalla_oro.Checked == true)
                               cmd.Parameters["@NRO_MEDALLA_ORO"].Value = "S    ";
                           else
                               cmd.Parameters["@NRO_MEDALLA_ORO"].Value = "N    ";

                           if (medalla_plata.Text.Replace(' ', '0') == "00000")
                               cmd.Parameters["@NRO_MEDALLA_PLATA"].Value = "";
                           else
                               cmd.Parameters["@NRO_MEDALLA_PLATA"].Value = medalla_plata.Text.Replace(' ', '0');

                           if (diploma.Checked == true)
                               cmd.Parameters["@DIPLOMA"].Value = "S";
                           else
                               cmd.Parameters["@DIPLOMA"].Value = "N";

                           if (diploma_oro.Checked == true)
                               cmd.Parameters["@DIPLOMA_ORO"].Value = "S";
                           else
                               cmd.Parameters["@DIPLOMA_ORO"].Value = "N";

                           if (suscriptor_oro.Checked == true)
                               cmd.Parameters["@SUSCRIPTOR_ORO"].Value = "S";
                           else
                               cmd.Parameters["@SUSCRIPTOR_ORO"].Value = "N";

                           if (suscriptor.Checked == true)
                               cmd.Parameters["@SUSCRIPTOR"].Value = "S";
                           else
                               cmd.Parameters["@SUSCRIPTOR"].Value = "N";

                           if (carnet.Checked == true)
                               cmd.Parameters["@CARNET"].Value = "S";
                           else
                               cmd.Parameters["@CARNET"].Value = "N";

                           if (this.fecha_vit.Text.Substring(0, 1) == "_")
                               cmd.Parameters["@FECHA"].Value = null;
                           else
                               cmd.Parameters["@FECHA"].Value = Convert.ToDateTime(fecha_vit.Text);

                           if (this.fecha_oro.Text.Substring(0, 1) == "_")
                               cmd.Parameters["@FECHA_ORO"].Value = null;
                           else
                               cmd.Parameters["@FECHA_ORO"].Value = Convert.ToDateTime(fecha_oro.Text);

                           cmd.Parameters["@OBSERVAC"].Value = observac_vit.Text;
                           cmd.Parameters["@LUGAR"].Value = (lugar_vit.SelectedValue == null ? "" : lugar_vit.SelectedValue.ToString());
                           cmd.Parameters["@LUGAR_ORO"].Value = (lugar_oro.SelectedValue == null ? "" : lugar_oro.SelectedValue.ToString());
                           cmd.ExecuteNonQuery();
                           transaction.Commit();
                           connection.Dispose();
                           MessageBox.Show("OPERACION EFECTUADA EXISTOSAMENTE", vcomando1.Substring(2, 6), MessageBoxButtons.OK, MessageBoxIcon.Information);
                           ProtegerCamposVit();
                       }
                   }
                   catch (FbException ex)
                   {
                       System.Windows.Forms.MessageBox.Show(ex.ToString());
                       Mails1 mensaje = new Mails1();
                       mensaje.Enviar_Mail_Error(ex.ToString());
                   }
               }
           }
       }

       private void CancelarVit_Click_1(object sender, EventArgs e)
       {
           DialogResult dr = MessageBox.Show("CONFIRMA CANCELAR LA EDICION?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
           
           if (dr == DialogResult.Yes)
           {
               errorProvider1.Clear();
               ProtegerCamposVit();
           
               if (v_vit_nuevo)
               {
                   medalla_plata.Text = string.Empty;
                   fecha_vit.Text = string.Empty;
                   lugar_vit.SelectedIndex = -1;
                   diploma.Checked = false;
                   suscriptor.Checked = false;
                   medalla_oro.Checked = false;
                   fecha_oro.Text = string.Empty;
                   lugar_oro.SelectedIndex = -1;
                   diploma_oro.Checked = false;
                   suscriptor_oro.Checked = false;
                   carnet.Checked = false;
                   observac_vit.Text = string.Empty;
               }

               Cargo_Vit();
           }
       }

       private void listView3_Click_1(object sender, EventArgs e)
       {
           vp_nro_adh = (int)(System.Convert.ToInt32(listView3.FocusedItem.Index));
           VGlobales.vp_cod_bar = string.Empty;
           VGlobales.vp_adh_inp = "I";

           using (Adherentes frmADH = new Adherentes())
           {
               frmADH.Text = "INV.PARTICIPATIVOS - ALTAS/BAJAS/MODIFICACIONES";
               frmADH.ShowDialog(this);
           }

           Cargar_Solapa_Inp();
       }

       private void NuevoVit_Click_1(object sender, EventArgs e)
       {
           HabilitarCamposVit();
       }

       private void btnNuevoParticipativo_Click(object sender, EventArgs e)
       {
           vp_nro_adh = -1;
           VGlobales.vp_adh_inp = "I";

           using (Adherentes frmADH = new Adherentes())
           {
               frmADH.Text = "INV.PARTICIPATIVOS - ALTAS/BAJAS/MODIFICACIONES";
               frmADH.ShowDialog(this);
           }

           if (VGlobales.vp_boton_modi != "U" && VGlobales.vp_boton_alta != "I")
           {
               MessageBox.Show("NO TIENE PERMISOS PARA AGREGAR INV.PARTICIPATIVOS",
                                               "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }

           Cargar_Solapa_Inp();

       }

       private void btnNuevoAdherente_Click(object sender, EventArgs e)
       {
           vp_nro_adh = -1;
           VGlobales.vp_adh_inp = "A";

           using (Adherentes frmADH = new Adherentes())
           {
               frmADH.Text = "ADHERENTES - ALTAS/BAJAS/MODIFICACIONES";
               frmADH.ShowDialog(this);
           }

           if (VGlobales.vp_boton_modi != "U" && VGlobales.vp_boton_alta != "I")
           {
               MessageBox.Show("NO TIENE PERMISOS PARA AGREGAR ADHERENTES",
                                               "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }

           Cargar_Solapa_Adh();
       }

       private void btnImportarAdherentes_Click(object sender, EventArgs e)
       {
           using (Mover_Adherentes frmMOVADH = new Mover_Adherentes("ADHERENTES"))
           {
               frmMOVADH.ShowDialog(this);
           }

           if (VGlobales.vp_boton_modi != "U" && VGlobales.vp_boton_alta != "I")
           {
               MessageBox.Show("NO TIENE PERMISOS PARA MOVER ADHERENTES", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }

           Cargar_Solapa_Adh();
       }

       private void btnNuevoFamiliar_Click(object sender, EventArgs e)
       {
           vp_barra = -1;
           using (Familiares frmFAM = new Familiares())
           {
               frmFAM.ShowDialog(this);
           }

           if (VGlobales.vp_boton_modi != "U" && VGlobales.vp_boton_alta != "I")
           {
               MessageBox.Show("NO TIENE PERMISOS PARA AGREGAR FAMILIARES", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }

           Cargar_Solapa_Fam();
       }

       private void listView2_Click_1(object sender, EventArgs e)
       {
           Cursor = Cursors.WaitCursor;
           vp_nro_adh = int.Parse(listView2.FocusedItem.Index.ToString());
           VGlobales.vp_cod_bar = string.Empty;
           VGlobales.vp_adh_inp = "A";

           using (Adherentes frmADH = new Adherentes())
           {
               frmADH.Text = "ADHERENTES - ALTAS / BAJAS / MODIFICACIONES";
               frmADH.ShowDialog(this);
           }

           Cargar_Solapa_Adh();
           Cursor = Cursors.Default;
       }

       private void listView1_Click_1(object sender, EventArgs e)
       {
           Cursor = Cursors.WaitCursor;
           vp_barra = (int)(System.Convert.ToInt32(listView1.FocusedItem.Index));
           VGlobales.vp_cod_bar = string.Empty;

           using (Familiares frmFAM = new Familiares())
           {
               frmFAM.ShowDialog(this);
           }

           Cargar_Solapa_Fam();
           Cursor = Cursors.Default;
       }

       private void btnAdquirir_Click(object sender, EventArgs e)
       {
           string nombreFoto = maskedTextBox1.Text.Trim().PadLeft(5, '0');
           string nombreFotoAfil = maskedTextBox7.Text.Trim() + "" + maskedTextBox6.Text.Trim();
           string nombreFotoBenef = maskedTextBox3.Text.Trim() + "" + maskedTextBox4.Text.Trim() + "" + maskedTextBox5.Text.Trim();
           string sfilename = "";
           string spath = "";
           OpenFileDialog opn = new OpenFileDialog();
           opn.Filter = "JPEG|*.jpg|GIF|*.gif";
           opn.ShowDialog();

           if (opn.FileName.Length > 0)
           {
               sfilename = System.IO.Path.GetFileName(opn.FileName);
               spath = System.IO.Path.GetDirectoryName(opn.FileName);
               string[] split = sfilename.Split(new Char[] { '.' }); //LE SACO LA EXTENSION
               Bitmap IMG = new Bitmap(opn.FileName);
               //pictureBox1.Image = resizeImage(IMG, 83, 72);
               pictureBox1.Image = IMG;
           }
       }

       private void EditarVit_Click_1(object sender, EventArgs e)
       {
           HabilitarCamposVit();
       }

       private void zeroSwitch(MaskedTextBox TEXTBOX)
       {
           /*if (TEXTBOX.Text == "0")
           {
               TEXTBOX.Text = "";
           }
           else if (TEXTBOX.Text == "")
           {
               TEXTBOX.Text = "0";
           }*/
       }

       private void maskedTextBox3_Enter(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox3);
       }

       private void maskedTextBox3_Leave(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox3);
       }

       private void maskedTextBox4_Enter(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox4);
       }

       private void maskedTextBox4_Leave(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox4);
       }

       private void maskedTextBox5_Enter(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox5);
       }

       private void maskedTextBox5_Leave(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox5);
       }

       private void maskedTextBox7_Enter(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox7);
       }

       private void maskedTextBox7_Leave(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox7);
       }

       private void maskedTextBox6_Enter(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox6);
       }

       private void maskedTextBox6_Leave(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox6);
       }

       private void maskedTextBox9_Enter(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox9);
       }

       private void maskedTextBox9_Leave(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox9);
       }

       private void maskedTextBox10_Enter(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox10);
       }

       private void maskedTextBox10_Leave(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox10);
       }

       private void maskedTextBox11_Enter(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox11);
       }

       private void maskedTextBox11_Leave(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox11);
       }

       private void maskedTextBox12_Enter(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox12);
       }

       private void maskedTextBox12_Leave(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox12);
       }

       private void maskedTextBox13_Enter(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox13);
       }

       private void maskedTextBox13_Leave(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox13);
       }

       private void maskedTextBox14_Enter(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox14);
       }

       private void maskedTextBox14_Leave(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox14);
       }

       private void maskedTextBox18_Enter(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox18);
       }

       private void maskedTextBox18_Leave(object sender, EventArgs e)
       {
           zeroSwitch(maskedTextBox18);
       }

       private void mskOrDia2_Enter(object sender, EventArgs e)
       {
           zeroSwitch(mskOrDia2);
       }

       private void mskOrDia2_Leave(object sender, EventArgs e)
       {
           zeroSwitch(mskOrDia2);
       }

       private void maskedTextbox17_KeyUp(object sender, KeyEventArgs e)
       {
           if (maskedTextbox17.Text == "")
           {
               comboBox6.SelectedIndex = -1;
           }
       }

       private void maskedTextbox25_KeyUp(object sender, KeyEventArgs e)
       {
           if (maskedTextbox25.Text == "")
           {
               comboBox4.SelectedIndex = -1;
           }
       }

       private void btnBeneficio_Click(object sender, EventArgs e)
       {
           Bienestar.DatosSocioBienestar ds = new Bienestar.DatosSocioBienestar(maskedTextBox9.Text);
           ds.ShowDialog();

       }

       private void btnImpInvPart_Click(object sender, EventArgs e)
       {
           using (Mover_Adherentes frmMOVADH = new Mover_Adherentes("INVITADOS PARTICIPATIVOS"))
           {
               frmMOVADH.ShowDialog(this);
           }

           if (VGlobales.vp_boton_modi != "U" && VGlobales.vp_boton_alta != "I")
           {
               MessageBox.Show("NO TIENE PERMISOS PARA MOVER INVITADOS PARTICIPATIVOS", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }

           Cargar_Solapa_Inp();
       }
    }
}

