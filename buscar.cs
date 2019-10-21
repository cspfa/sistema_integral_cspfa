using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.Linq;

namespace SOCIOS
{
    public partial class buscar : MicroFour.StrataFrame.UI.Windows.Forms.StandardForm
    {
        public string vdatabase;

        public string vdatasource;

        bo dlog = new bo();
        getGrupo gg = new getGrupo();
        db bd = new db();
        arancel o_arancel = new arancel();

        string[,] areas_orden = new string[6, 3]
        {
            { "81", "REGISTRO DE SOCIOS", "RS"},
            { "66", "BONO PELUQUERÍA", "PE"},
            { "136", "TURISMO", "TU"},
            { "123", "INGRESO COMEDOR", "CO"},
            { "7", "INGRESO COMEDOR", "CO"},
            { "36", "DEPORTES", "DE"}
        };

        EntradaCampoService entradaCampoService = new EntradaCampoService();

        private string CUIL { get; set; }

        public buscar()
        {
            InitializeComponent();
            lleno_combos_Buscar();

            if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "PROSECRETARIA" || VGlobales.vp_role == "CREDITOS")
            {
                lbDatosBancarios.Enabled = true;
            }

            if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "INFORMES")
            {
                btnRestarCounter.Visible = true;
                btnBlankTurnero.Visible = true;
            }

            if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "INTERIOR")
            {
                lbObsInterior.Enabled = true;
            }

            if (VGlobales.vp_role == "CONFITERIA" || VGlobales.vp_role == "SISTEMAS")
            {
                dpFechaIngreso.Enabled = true;
            }

            if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "CPOCABA" || VGlobales.vp_role == "CPOPOLVORINES" || VGlobales.vp_role == "CPORANELAGH")
            {
                lbIngresoCampo.Enabled = true;
                label20.Enabled = true;
            }

            if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "INFORMES" || VGlobales.vp_role == "CAJA" || VGlobales.vp_role == "SSADPADUA")
            {
                lbIngresosRecibos.Enabled = true;
            }
        }

        private bool ObtenerAsamblea()
        {
            bo dlog = new bo();
            string query = "SELECT FECHA_TOPE FROM CONTROL_ASISTENCIA WHERE ELECCION = EXTRACT(YEAR FROM CURRENT_DATE) AND CERRADO = 'N';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string ObtenerFechaTope()
        {
            bo dlog = new bo();
            string query = "SELECT FECHA_TOPE FROM CONTROL_ASISTENCIA WHERE ELECCION = EXTRACT(YEAR FROM CURRENT_DATE) AND CERRADO = 'N';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                return foundRows[0][0].ToString();
            }
            else
            {
                return "ERROR";
            }
        }

        private string[] verificarIngresoAsamblea(int NRO_SOC, int NRO_DEP, string FECHA_TOPE)
        {
            conString conString = new conString();
            string connectionString = conString.get();

            string[] DEVUELVE = { "N", "N" };

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                string busco;
                busco = "SELECT * FROM P_VERIFICAR_INGRESO(" + NRO_SOC + ", " + NRO_DEP + ", '" + FECHA_TOPE + "')";
                FbCommand cmd = new FbCommand(busco, connection, transaction);
                cmd.CommandText = busco;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string VERIFICACION = reader.GetString(reader.GetOrdinal("VERIFICACION"));
                    string CAUSA = reader.GetString(reader.GetOrdinal("CAUSA"));
                    string V_SUS = reader.GetString(reader.GetOrdinal("V_SUS"));
                    string V_CONCEPTO = reader.GetString(reader.GetOrdinal("V_CONCEPTO"));
                    decimal IMPORTE = reader.GetDecimal(reader.GetOrdinal("IMPORTE"));
                    string MOROSO = reader.GetString(reader.GetOrdinal("MOROSO"));
                    int PAR = reader.GetInt32(reader.GetOrdinal("PAR"));
                    int PCRJP1 = reader.GetInt32(reader.GetOrdinal("PCRJP1"));
                    int PCRJP2 = reader.GetInt32(reader.GetOrdinal("PCRJP2"));
                    int NRODOC = reader.GetInt32(reader.GetOrdinal("NRODOC"));
                    DEVUELVE = new string[] { VERIFICACION, CAUSA, V_SUS, V_CONCEPTO, IMPORTE.ToString(), MOROSO, PAR.ToString(), PCRJP1.ToString(), PCRJP2.ToString(), NRODOC.ToString() };
                }
                else
                {
                    MessageBox.Show("NO SE ENCONTRARON DATOS PARA VERIFICAR");
                }

                return DEVUELVE;
            }
        }

        private void darIngresoAsamblea(int ELECCION, string TIPO, int NRO_SOC, int NRO_DEP, string NOMINAL, string INGRESO)
        {
            string agrego = string.Empty;

            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    agrego = "INSERT INTO ASAMBLEA (ELECCION, TIPO, NRO_SOC, NRO_DEP, NOMINAL, INGRESO) VALUES (" + ELECCION + ", '" + TIPO + "', " + NRO_SOC + ", " + NRO_DEP + ", '" + NOMINAL + "', '" + INGRESO + "')";
                    FbCommand cmd = new FbCommand(agrego, connection, transaction);
                    cmd.CommandText = agrego;
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();
                    cmd = null;

                    if (INGRESO == "S")
                    {
                        MessageBox.Show("EL INGRESO FUE GUARDADO CON EXITO", "ALTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (FbException ex)
            {
                MessageBox.Show("NO SE PUDO GUARDAR EL INGRESO\n" + ex);
            }
        }

        private bool checkIngresoAsamblea(int NRO_SOC, int NRO_DEP, int ANO)
        {
            bool INGRESO = true;
            string QUERY = "SELECT ELECCION FROM ASAMBLEA WHERE NRO_SOC = '" + NRO_SOC + "' AND NRO_DEP = '" + NRO_DEP + "' AND ELECCION = " + ANO + ";";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                INGRESO = false;
            }

            return INGRESO;
        }

        private void btnIngresoAsamblea_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("CONFIRMA EL INGRESO DEL SOCIO?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                bool ASAMBLEA = ObtenerAsamblea();

                if (ASAMBLEA == true)
                {
                    int ELECCION = DateTime.Today.Year;
                    string TIPO = "A";
                    int NRO_SOC = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                    int NRO_DEP = Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text);
                    string NOMINAL = "NO";
                    string FECHA_TOPE = ObtenerFechaTope().Replace(" 12:00:00 a.m.", "");
                    string DIA = FECHA_TOPE.Substring(0, 2);
                    string MES = FECHA_TOPE.Substring(3, 2);
                    string ANO = FECHA_TOPE.Substring(6, 4);
                    string FECHA_TOPE_FINAL = MES + "/" + DIA + "/" + ANO;

                    if (checkIngresoAsamblea(NRO_SOC, NRO_DEP, ELECCION) == true)
                    {
                        string[] VERIFICA_INGRESO;
                        VERIFICA_INGRESO = verificarIngresoAsamblea(NRO_SOC, NRO_DEP, FECHA_TOPE_FINAL);

                        if (VERIFICA_INGRESO[0] == "S")
                        {
                            darIngresoAsamblea(ELECCION, TIPO, NRO_SOC, NRO_DEP, NOMINAL, "S");
                        }
                        else
                        {
                            MessageBox.Show("EL SOCIO NO PUEDE INGRESAR A LA ASAMBLEA\n" + VERIFICA_INGRESO[1]);
                            darIngresoAsamblea(ELECCION, TIPO, NRO_SOC, NRO_DEP, NOMINAL, "N");
                        }
                    }
                    else
                    {
                        MessageBox.Show("EL SOCIO YA INGRESO A LA ASAMBLEA");
                    }
                }
                else
                {
                    MessageBox.Show("NO SE ENCONTRARON ASAMBLEAS ABIERTAS");
                }
            }
            else
            {
                MessageBox.Show("EL INGRESO FUE CANCELADO POR EL OPERADOR", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void pintarTurnoDelDia()
        {
            string FECHA = DateTime.Today.ToShortDateString();
            int X = 0;

            foreach (DataGridViewRow row in dgvTurnos.Rows)
            {
                if (row.Cells[2].Value.ToString() == FECHA)
                {
                    dgvTurnos.Rows[X].DefaultCellStyle.BackColor = Color.Green;
                    dgvTurnos.Rows[X].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    dgvTurnos.Rows[X].DefaultCellStyle.BackColor = Color.White;
                    dgvTurnos.Rows[X].DefaultCellStyle.ForeColor = Color.Black;
                }

                X++;
            }
        }

        public void mostrarTurnos(string NRO_SOC, string NRO_DEP, string BARRA)
        {
            string FECHA = DateTime.Today.ToShortDateString();
            string DAY = FECHA.Substring(0, 2);
            string MONTH = FECHA.Substring(3, 2);
            string YEAR = FECHA.Substring(6, 4);
            string FECHA_FINAL = MONTH + "/" + DAY + "/" + YEAR;
            string query = "SELECT * FROM P_TIENE_TURNO (" + NRO_SOC + ", '" + FECHA_FINAL + "', " + NRO_DEP + ", " + BARRA + ");";
            string connectionString;
            DataSet ds1 = new DataSet();
            Datos_ini ini3 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini3.Servidor; cs.Port = int.Parse(ini3.Puerto);
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
                    DataTable dt1 = new DataTable("RESULTADOS");
                    dt1.Columns.Add("ESPECIALIDAD", typeof(string));
                    dt1.Columns.Add("PROFESIONAL", typeof(string));
                    dt1.Columns.Add("DIA", typeof(string));
                    dt1.Columns.Add("DESDE", typeof(string));
                    dt1.Columns.Add("HASTA", typeof(string));
                    dt1.Columns.Add("ROL", typeof(string));
                    dt1.Columns.Add("DESTINO", typeof(string));
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ESPECIALIDAD")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("PROFESIONAL")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("DIA")).Substring(0, 10),
                                     reader3.GetString(reader3.GetOrdinal("DESDE")).Trim().Substring(0, 5),
                                     reader3.GetString(reader3.GetOrdinal("HASTA")).Trim().Substring(0, 5),
                                     reader3.GetString(reader3.GetOrdinal("ROL")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("DESTINO")).Trim());
                    }

                    reader3.Close();

                    dgvTurnos.DataSource = dt1;
                    dgvTurnos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvTurnos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvTurnos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvTurnos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvTurnos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvTurnos.Columns[5].Visible = false;
                    dgvTurnos.Columns[6].Visible = false;
                    transaction.Commit();
                    dgvTurnos.ClearSelection();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR: " + error);
            }
        }

        public void mostrarObservaciones(string DNI)
        {
            string query = "SELECT * FROM OBSERVACIONES_MEDICAS WHERE DNI = '" + DNI + "' ORDER BY FECHA DESC;";
            string connectionString;
            DataSet ds1 = new DataSet();
            Datos_ini ini3 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini3.Servidor; cs.Port = int.Parse(ini3.Puerto);
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
                    DataTable dt1 = new DataTable("RESULTADOS");
                    dt1.Columns.Add("FECHA", typeof(string));
                    dt1.Columns.Add("OBSERVACIONES", typeof(string));
                    ds1.Tables.Add(dt1);
                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("FECHA")).Substring(0, 10), reader3.GetString(reader3.GetOrdinal("OBSERVACIONES")).Trim());
                    }

                    reader3.Close();
                    dgvObservaciones.DataSource = dt1;
                    dgvObservaciones.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvObservaciones.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    transaction.Commit();
                    dgvObservaciones.ClearSelection();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR: " + error);
            }
        }

        string titulo;
        string lastSearch;
        private int lastItm = 0;
        int currentIndex = 0;
        int columna;
        public static string vcampo;
        private List<ListViewItem> matchingList = new List<ListViewItem>(); // the list of matching ListViewItems

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

        private void TXT_paso(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void buscar_Load(object sender, EventArgs e)
        {
            limpio();
            this.KeyPreview = true;
        }

        private void limpio()
        {
            lbDatosBancarios.ForeColor = Color.Gray;
            lbObsInterior.ForeColor = Color.Gray;
            btnIngresoAsamblea.Enabled = false;
            dgvObservaciones.DataSource = null;
            btnPagos.Enabled = false;
            lbMoraInp.ForeColor = Color.Silver;
            lbMoraCuota.ForeColor = Color.Silver;
            lbMoraDepo.ForeColor = Color.Silver;
            listView1.Items.Clear();
            dgvTurnos.DataSource = null;
            comboBox3.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            btnVerDatos.Enabled = false;
            btnIngreso.Enabled = false;
            btnEgreso.Enabled = false;
            dtpEgreso.Text = DateTime.Today.ToShortDateString();
            button2.Enabled = false;
            textBox1.Text = "0";
            textBox5.Text = "0";
            textBox7.Text = "0";
            textBox11.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox12.Text = "0";
            textBox6.Text = "";
            textBox13.Text = "";
            textBox14.Text = "0";
            textBox4.Text = "";
            textBox4.Focus();
            maskedTextbox1.Text = "0";
            maskedTextbox2.Text = "0";
            maskedTextbox3.Text = "0";
            textBox2.Text = "";
            textBox3.Text = "";
            textbox15.Text = "";
            textbox15.Enabled = false;
            BuscarListView.Enabled = false;
            LimpiarListView.Enabled = false;
            comboBox3.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            tbEmail.Text = "";
            tbIntereses.Text = "";
            tbTelefono.Text = "";
            lbSocioDepo.ForeColor = Color.Gray;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            limpio();
            btnVerDatos.Enabled = false;
            btnIngreso.Enabled = false;
            button3.Enabled = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Boton_buscar();
            lbObsInterior.Visible = false;
        }

        private void Boton_buscar()
        {
            Cursor = Cursors.WaitCursor;
            lbMoraInp.ForeColor = Color.DimGray;
            lbMoraCuota.ForeColor = Color.DimGray;
            lbMoraDepo.ForeColor = Color.DimGray;
            lbMorosoNoAlcanza.ForeColor = Color.DimGray;
            lbMorosoNoDesc.ForeColor = Color.DimGray;
            listView1.Columns.Clear();
            listView1.Items.Clear();

            if (((textBox1.Text == "0") && (textBox5.Text == "0") &&
                (textBox8.Text == "0") && (textBox9.Text == "0") && (textBox10.Text == "0") &&
                (textBox7.Text == "0") && (textBox11.Text == "0") &&
                (textBox6.Text == "") && (textBox13.Text == "") &&
                (textBox12.Text == "0") && (textBox14.Text == "0")) &&
                ((maskedTextbox1.Text == "0") && (textBox2.Text == "") && (textBox3.Text == "") &&
                (maskedTextbox3.Text == "0") && (maskedTextbox2.Text == "0") && (mtbIdEmpleado.Text == "")))
            {
                MessageBox.Show("DEBE INGRESAR UNA CONDICION DE BUSQUEDA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (themedContainer1.IsBodyVisible)
                    BuscarTitular();
                else
                    BuscarFamAdhe();
            }
            Cursor = Cursors.Default;
        }

        private void BuscarTitular()
        {
            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    string busco;

                    busco = "SELECT * FROM P_BUSCO_UN_TITULAR2 (@P_APE_SOC,@P_NOM_SOC,";
                    busco = busco + "@P_NRO_LEGAJO,@P_NRO_DEPURACION,@P_AAR,";
                    busco = busco + "@P_ACRJP2,@P_LEG_PER,@VPCRJP3,@VPCRJP2,@VPCRJP1,@VNRODOC,@VID_EMPLEADO)";
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
                    cmd.Parameters.Add(new FbParameter("@VPCRJP3", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@VPCRJP2", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@VPCRJP1", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@VNRODOC", FbDbType.BigInt));
                    cmd.Parameters.Add(new FbParameter("@VID_EMPLEADO", FbDbType.Integer));

                    // SE CARGAN LOS PARAMETROS CON LOS VALORES DEL WINFORM.-
                    cmd.Parameters["@P_NRO_LEGAJO"].Value = ((textBox1.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox1.Text))));
                    cmd.Parameters["@P_NRO_DEPURACION"].Value = ((textBox5.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox5.Text))));
                    cmd.Parameters["@P_AAR"].Value = ((textBox7.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox7.Text))));
                    cmd.Parameters["@P_ACRJP2"].Value = ((textBox11.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox11.Text))));
                    cmd.Parameters["@P_LEG_PER"].Value = ((textBox12.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox12.Text))));
                    cmd.Parameters["@P_APE_SOC"].Value = textBox6.Text.Trim();
                    cmd.Parameters["@P_NOM_SOC"].Value = textBox13.Text.Trim();
                    cmd.Parameters["@VPCRJP3"].Value = ((textBox10.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox10.Text))));
                    cmd.Parameters["@VPCRJP2"].Value = ((textBox9.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox9.Text))));
                    cmd.Parameters["@VPCRJP1"].Value = ((textBox8.Text == "" ? 0 : (int?)(System.Convert.ToInt32(textBox8.Text))));
                    cmd.Parameters["@VNRODOC"].Value = ((textBox14.Text == "" ? 0 : (int)(System.Convert.ToInt64(textBox14.Text))));
                    cmd.Parameters["@VID_EMPLEADO"].Value = ((mtbIdEmpleado.Text == "" ? 0 : (int?)(System.Convert.ToInt32(mtbIdEmpleado.Text))));

                    // SE EJECUTA EL COMANDO DE LECTURA CON TODOS LOS PARAMETROS.-
                    FbDataReader reader = cmd.ExecuteReader();

                    listView1.Columns.Clear();
                    listView1.Items.Clear();
                    titulo = "RESULTADO DE LA BUSQUEDA";

                    try
                    {
                        if (reader.Read())
                        {
                            textbox15.Enabled = true;
                            limpio_tbx15();
                            Cargar_Resultado_Titular(reader);
                        }
                        else
                        {
                            MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        titulo = "RESULTADO DE LA BUSQUEDA - " + listView1.Items.Count + " REGISTROS";
                        themedGroupBox1.Title = titulo;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        textBox7.Focus();
                    }

                    reader.Close();
                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                textBox7.Focus();
            }
        }

        private void limpio_tbx15()
        {
            textbox15.Focus();
            textbox15.SelectAll();
        }

        // MUESTRA DATOS EN EL LIST VIEW DE TITULARES
        private void Cargar_Resultado_Titular(FbDataReader reader)
        {
            string dto = string.Empty;
            listView1.BeginUpdate();

            int GRUPO = 0;

            if (listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("# SOCIO");
                listView1.Columns.Add("# DEP");
                listView1.Columns.Add("COD DTO");
                listView1.Columns.Add("CATEGORIA");
                listView1.Columns.Add("APELLIDO");
                listView1.Columns.Add("NOMBRE");
                listView1.Columns.Add("JERARQUIA");
                listView1.Columns.Add("DESTINO");
                listView1.Columns.Add("ID");
                listView1.Columns.Add("MC");
                listView1.Columns.Add("MD");
                listView1.Columns.Add("DNI/CUIT");
                listView1.Columns.Add("CAT_SOC");
                listView1.Columns.Add("BAJA");
                listView1.Columns.Add("MND");
                listView1.Columns.Add("SD");
                listView1.Columns.Add("ID_ANT");
                listView1.Columns.Add("F_CARN");
                listView1.Columns.Add("NA");
            }

            foreach (ColumnHeader ch in this.listView1.Columns)
            {
                ch.ImageIndex = -1;
            }
            {
                do
                {
                    string BAJA = reader.GetString(reader.GetOrdinal("BAJA"));
                    string F_CARN = reader.GetString(reader.GetOrdinal("F_CARN"));

                    if (F_CARN != "")
                        F_CARN = F_CARN.Substring(0, 10);

                    if (BAJA != "")
                        BAJA = BAJA.Substring(0, 10);

                    string NUM_DOC = reader.GetString(reader.GetOrdinal("NUM_DOC"));

                    ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("NRO_SOC")).PadLeft(5, '0'));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NRO_DEP")).PadLeft(3, '0'));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("COD_DTO")).PadLeft(3, '0'));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("CAT_SOC")));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("APE_SOC")).Trim());
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NOM_SOC")).Trim());
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("JERARQ")));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("DESTINO")));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ID")));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("MOROSO")));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("MOROSO_DEPORTES")));
                    listItem.SubItems.Add(NUM_DOC);
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("COD_CAT_SOC")));
                    listItem.SubItems.Add(BAJA);
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("MOROSO_NO_DESC")));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("SOCIO_DEPORTES")));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ID_TITULAR_ANT")));
                    listItem.SubItems.Add(F_CARN);
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("MOROSO_NO_ALCANZA")));
                    listView1.Items.Add(listItem);

                    GRUPO = gg.get(reader.GetString(reader.GetOrdinal("COD_DTO")), reader.GetString(reader.GetOrdinal("COD_CAT_SOC")));

                    if (GRUPO == 1)
                    {
                        listItem.BackColor = Color.LightGreen;
                    }

                    if (reader.GetString(reader.GetOrdinal("MOROSO")) == "S"
                        || reader.GetString(reader.GetOrdinal("MOROSO_DEPORTES")) == "S"
                        || reader.GetString(reader.GetOrdinal("MOROSO_NO_DESC")) == "S"
                        || reader.GetString(reader.GetOrdinal("MOROSO_NO_ALCANZA")) == "S")
                    {
                        listItem.BackColor = Color.Red;
                        listItem.ForeColor = Color.White;
                    }

                    if (BAJA != "")
                    {
                        listItem.BackColor = Color.Red;
                        listItem.ForeColor = Color.White;
                    }

                    CUIL = reader.GetString(reader.GetOrdinal("CUIL"));
                }

                while (reader.Read());
                listView1.EndUpdate();
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void BuscarFamAdhe()
        {
            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    string busco;

                    busco = "SELECT * FROM P_BUSCO_FAMADHE (@P_APE_FAM,@P_NOM_FAM,@VNRODOC,@VNROADH,@VNRODEP)";
                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;

                    // DEFINICION DE LOS PARAMETROS PARA EJECUTAR STORE DE BUSQUEDA.-
                    cmd.Parameters.Add(new FbParameter("@P_APE_FAM", FbDbType.Char));
                    cmd.Parameters.Add(new FbParameter("@P_NOM_FAM", FbDbType.Char));
                    cmd.Parameters.Add(new FbParameter("@VNRODOC", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@VNROADH", FbDbType.Integer));
                    cmd.Parameters.Add(new FbParameter("@VNRODEP", FbDbType.Integer));

                    // SE CARGAN LOS PARAMETROS CON LOS VALORES DEL WINFORM.-
                    cmd.Parameters["@P_APE_FAM"].Value = textBox3.Text;
                    cmd.Parameters["@P_NOM_FAM"].Value = textBox2.Text;
                    cmd.Parameters["@VNRODOC"].Value = ((maskedTextbox1.Text == "" ? 0 : (int?)(System.Convert.ToInt32(maskedTextbox1.Text))));
                    cmd.Parameters["@VNROADH"].Value = ((maskedTextbox3.Text == "" ? 0 : (int?)(System.Convert.ToInt32(maskedTextbox3.Text))));
                    cmd.Parameters["@VNRODEP"].Value = ((maskedTextbox2.Text == "" ? 0 : (int?)(System.Convert.ToInt32(maskedTextbox2.Text))));

                    // SE EJECUTA EL COMANDO DE LECTURA CON TODOS LOS PARAMETROS.-
                    FbDataReader reader = cmd.ExecuteReader();

                    listView1.Columns.Clear();
                    listView1.Items.Clear();
                    titulo = "RESULTADO DE LA BUSQUEDA";

                    try
                    {
                        if (reader.Read())
                        {
                            textbox15.Enabled = true;
                            limpio_tbx15();
                            Cargar_Resultado_FamAdhe(reader);
                        }
                        else
                        {
                            MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        titulo = "RESULTADO DE LA BUSQUEDA - " + listView1.Items.Count + " REGISTROS";
                        themedGroupBox1.Title = titulo;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        textBox7.Focus();
                    }

                    reader.Close();
                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                textBox7.Focus();
            }
        }

        //MUESTRA DATOS EN EL LIST VIEW DE FAMILIAR Y ADHERENTE
        private void Cargar_Resultado_FamAdhe(FbDataReader reader) //CARGAR_FAMADHE
        {
            listView1.BeginUpdate();

            if (listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("NRO_SOC");
                listView1.Columns.Add("DEP");
                listView1.Columns.Add("TIPO");
                listView1.Columns.Add("TAB");
                listView1.Columns.Add("BARRA");
                listView1.Columns.Add("APELLIDO");
                listView1.Columns.Add("NOMBRE");
                listView1.Columns.Add("DTO");
                listView1.Columns.Add("APELLIDO TITULAR");
                listView1.Columns.Add("NOMBRE TITULAR");
                listView1.Columns.Add("ID");
                listView1.Columns.Add("MD");
                listView1.Columns.Add("MI");
                listView1.Columns.Add("DNI");
                listView1.Columns.Add("BAJA");
                listView1.Columns.Add("SD");
                listView1.Columns.Add("FNACIM");
                listView1.Columns.Add("NA");
            }
            foreach (ColumnHeader ch in this.listView1.Columns)
            {
                ch.ImageIndex = -1;
            }
            {
                do
                {
                    string BAJA = reader.GetString(reader.GetOrdinal("BAJA"));

                    if (BAJA != "")
                    {
                        BAJA = BAJA.Substring(0, 10);
                    }

                    string NACIM = reader.GetString(reader.GetOrdinal("FNACIM"));

                    if (NACIM != "")
                    {
                        NACIM = NACIM.Substring(0, 10);
                    }

                    ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("NRO_SOC")).PadLeft(5, '0'));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NRO_DEP")).PadLeft(3, '0'));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TIPO")));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NRO_TAB")).PadLeft(9, '0'));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("BARRA")));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("APE_SOC")).Trim());
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NOM_SOC")).Trim());
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("COD_DTO")).PadLeft(3, '0'));
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("APE_TIT")).Trim());
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NOM_TIT")).Trim());
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ID_TIT")).Trim());
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("MOROSO_DEPORTES")).Trim());
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("MOROSO_INVITADO")).Trim());
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NUM_DOC")).Trim());
                    listItem.SubItems.Add(BAJA);
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("SOCIO_DEPORTES")));
                    listItem.SubItems.Add(NACIM);
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("MOROSO_NO_ALCANZA")));
                    listView1.Items.Add(listItem);

                    if (BAJA == "")
                    {
                        listItem.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        listItem.BackColor = Color.Red;
                        listItem.ForeColor = Color.White;
                    }

                    if (reader.GetString(reader.GetOrdinal("MOROSO_INVITADO")) == "S" || reader.GetString(reader.GetOrdinal("MOROSO_NO_ALCANZA")) == "S")
                    {
                        listItem.BackColor = Color.Red;
                        listItem.ForeColor = Color.White;
                    }

                    //AGREGAR CONTROL DE EDAD PARA NO MARCAR EN VERDE FAMILIAR > 18 AÑOS
                    string TIPO = reader.GetString(reader.GetOrdinal("TIPO"));
                    int BARRA = int.Parse(reader.GetString(reader.GetOrdinal("BARRA")));
                    int EDAD_FAMILIAR = 0;

                    if (TIPO == "FAM" && NACIM != "" && BARRA >= 4)
                    {
                        edad EDAD = new edad();
                        EDAD_FAMILIAR = EDAD.CALCULAR(NACIM);

                        if (EDAD_FAMILIAR >= 18)
                        {
                            listItem.BackColor = Color.Red;
                            listItem.ForeColor = Color.White;
                        }
                    }
                }

                while (reader.Read());
                listView1.EndUpdate();
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            columna = (System.Convert.ToInt32(e.Column));
            string cName = listView1.Columns[columna].Text;
            string tit = string.Empty;

            foreach (ColumnHeader ch in this.listView1.Columns)
            {
                ch.ImageIndex = -1;

            }

            ListViewItemComparer sorter = listView1.ListViewItemSorter as ListViewItemComparer;

            if (sorter == null)
            {
                sorter = new ListViewItemComparer(e.Column);
                this.listView1.ListViewItemSorter = sorter;
                tit = Ver_Orden(e, columna, cName, tit, sorter);
            }
            else
            {
                tit = Ver_Orden(e, columna, cName, tit, sorter);
            }

            themedGroupBox1.Title = titulo + tit;
            listView1.Sort();
        }

        private string Ver_Orden(ColumnClickEventArgs e, int columna, string cName, string tit, ListViewItemComparer sorter)
        {
            if (sorter.Column == e.Column && !sorter.Descending)
            {
                sorter.Descending = true;
                listView1.Sorting = SortOrder.Descending;
                listView1.Columns[columna].ImageIndex = 1;
            }
            else
            {
                listView1.Sorting = SortOrder.Ascending;
                listView1.Columns[columna].ImageIndex = 0;
                sorter.Descending = false;
                sorter.Column = e.Column;
            }

            return tit;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string searchText = textbox15.Text.Trim();

            if (searchText != lastSearch)
            {
                lastSearch = searchText;
                currentIndex = 0;
                FillMatchingList(searchText);
            }

            HighlightNextMatch();
        }

        private void FillMatchingList(string txt)
        {
            matchingList.Clear();
            ListViewItem lViewItem;
            int lastIndex = -1;
            lViewItem = null;

            while (!(lastIndex >= listView1.Items.Count - 1))
            {
                lViewItem = FindTextEverywhere(txt, true, lastIndex + 1);

                if ((lViewItem != null))
                {
                    matchingList.Add(lViewItem);
                    lastIndex = lViewItem.Index;
                }
                else
                {
                    return;
                }
            }
        }

        private void HighlightNextMatch()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].Selected = false;
            }


            if (matchingList.Count > 0)
            {
                matchingList[currentIndex].Selected = true;
                listView1.TopItem = matchingList[currentIndex];
                currentIndex = (currentIndex + 1) % matchingList.Count;
                listView1.Focus();
            }
            else
            {
                MessageBox.Show("NO SE ENCONTRO EL VALOR BUSCADO", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private ListViewItem FindTextEverywhere(string txt, bool bv, int lastIndex)
        {
            int colCount = listView1.Columns.Count;
            int col = 0;
            bool find = false;
            ListViewItem lv = null;

            for (int colAll = col; colAll < colCount; colAll++)
            {
                for (int lst12 = lastItm; lst12 < listView1.Items.Count; lst12++)
                {
                    if (listView1.Items[lst12].SubItems[colAll].Text.IndexOf(txt) > -1)
                    {
                        listView1.TopItem = listView1.Items[lst12];
                        lastItm = lst12 + 1;
                        find = true;
                        lv = listView1.Items[lst12];
                        break;
                    }
                }

                if (find)
                {
                    break;
                }
            }

            return lv;
        }

        private void textbox15_Click(object sender, EventArgs e)
        {
            limpio_tbx15();
        }

        private void textbox15_TextChanged(object sender, EventArgs e)
        {
            BuscarListView.Enabled = true;
            LimpiarListView.Enabled = true;
            if (lastItm > 0) listView1.Items[lastItm - 1].BackColor = Color.Empty;
            lastItm = 0;
        }

        private void BuscarListView_Click(object sender, EventArgs e)
        {
            string searchText = textbox15.Text.Trim();

            if (searchText != lastSearch)
            {
                lastSearch = searchText;
                currentIndex = 0;
                FillMatchingList(searchText);
            }

            HighlightNextMatch();
        }

        private void LimpiarListView_Click(object sender, EventArgs e)
        {
            textbox15.Text = string.Empty;
            limpio_tbx15();

            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].Selected = false;
            }
        }

        private void themedContainer2_BodyHidden()
        {
            this.SuspendLayout();
            themedContainer1.ShowBody();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void themedContainer2_BodyRestored()
        {
            this.SuspendLayout();
            themedContainer1.HideBody();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void themedContainer1_BodyHidden()
        {
            themedContainer2.ShowBody();
        }

        private void themedContainer1_BodyRestored()
        {
            themedContainer2.HideBody();
        }

        private void valido_barras(object sender, EventArgs e)
        {
            vcampo = "";
            string vparam1 = "";
            string vparam2 = "";
            string vparam3 = "";
            int id = 0;
            VGlobales.vp_cod_bar = string.Empty;
            string CODIGO = textBox4.Text.Trim();
            int LENGHT = CODIGO.Length;

            if (LENGHT >= 10)
            {
                vcampo = CODIGO;

                switch (vcampo.Substring(0, 1))
                {
                    case "T":
                        themedContainer1.ShowBody();
                        themedContainer2.HideBody();
                        textBox1.Text = vcampo.Substring(2, 5);
                        textBox5.Text = vcampo.Substring(7, 3);
                        listView1.Columns.Clear();
                        listView1.Items.Clear();
                        textBox4.Text = "";
                        VGlobales.vp_cod_bar = "T";
                        BuscarTitular();
                        Socios.vp_tabpage = 0;
                        break;

                    case "F":
                        themedContainer1.HideBody();
                        themedContainer2.ShowBody();
                        vparam1 = vcampo.Substring(2, 5);
                        vparam2 = vcampo.Substring(7, 3);
                        vparam3 = vcampo.Substring(10, 2);
                        id = int.Parse(vparam1 + "" + vparam2);
                        listView1.Columns.Clear();
                        listView1.Items.Clear();
                        textBox4.Text = "";
                        Socios.vp_tabpage += 2; // FAM
                        VGlobales.vp_cod_bar = "F";
                        Socios.vp_barra = (int)(System.Convert.ToInt32(vcampo.Substring(10, 2)));
                        BuscarFamAdhe_barras(vparam1, vparam2, vparam3, "F", id);
                        break;

                    case "A":
                        themedContainer1.HideBody();
                        themedContainer2.ShowBody();
                        vparam1 = vcampo.Substring(2, 5);
                        vparam2 = vcampo.Substring(7, 3);
                        vparam3 = vcampo.Substring(10, 2);
                        id = int.Parse(vparam1 + "" + vparam2 + "" + vparam3);
                        BuscarAdh_ID(vcampo);
                        listView1.Columns.Clear();
                        listView1.Items.Clear();
                        textBox4.Text = "";

                        if (vcampo.Substring(7, 3) != "011") //verifica si es Inv.Particip
                        {
                            Socios.vp_tabpage += 3; // ADH
                            VGlobales.vp_adh_inp = "A";
                        }
                        else
                        {
                            Socios.vp_tabpage += 7; // INP
                            VGlobales.vp_adh_inp = "I";
                        }

                        VGlobales.vp_cod_bar = "A";
                        Socios.vp_nro_adh = (int)(System.Convert.ToInt32(vcampo.Substring(10, 2))); // le deja el valor de la barra
                        BuscarFamAdhe_barras(vparam1, vparam2, vparam3, "A", id);
                        break;

                    default:
                        Socios.vp_nro_soc = 0;
                        Socios.vp_nro_dep = 0;
                        break;
                }

                Socios.vp_nro_soc = (int)(System.Convert.ToInt32(textBox1.Text));
                Socios.vp_nro_dep = (int)(System.Convert.ToInt32(textBox5.Text));
            }
            else if (LENGHT < 10 && LENGHT > 0)
            {
                MessageBox.Show("EL CODIGO INGRESADO ES CORTO", "ERROR");
            }
        }


        private void BuscarFamAdhe_barras(string vp1, string vp2, string vp3, string vtip_bus, int ID)
        {
            string Fcomando = "";

            if (vtip_bus == "F")
            {
                Fcomando = "SELECT A.NRO_SOC, A.NRO_DEP, 0 AS NRO_TAB, A.BARRA, A.APE_FAM, A.NOM_FAM, B.APE_SOC, B.NOM_SOC,";
                Fcomando = Fcomando + " 'FAM' AS TIPO, B.COD_DTO AS COD_DTO, ";
                Fcomando = Fcomando + " (SELECT (CASE WHEN COUNT(*)>0 THEN 'S' ELSE 'N' END) FROM MOROSOS_DEPORTES WHERE DNI = A.NUM_DOCF) AS MOROSO_DEPORTES, ";
                Fcomando = Fcomando + " (SELECT (CASE WHEN COUNT(*)>0 THEN 'S' ELSE 'N' END) FROM MOROSOS_INVITADOS WHERE DNI = A.NUM_DOCF) AS MOROSO_INVITADO, B.ID_TITULAR, A.NUM_DOCF, A.F_BAJA AS BAJA,";
                Fcomando = Fcomando + " (SELECT (CASE WHEN COUNT(*)>0 THEN 'S' ELSE 'N' END) FROM DEPORTES_ADM WHERE DNI = A.NUM_DOCF  AND DEPORTES_ADM.FE_BAJA IS NULL) AS SOCIO_DEPORTES, A.F_NACFAM AS NACIM";
                Fcomando = Fcomando + " FROM FAMILIAR A, TITULAR B ";
                Fcomando = Fcomando + " WHERE (A.ID_TITULAR = " + ID + " OR A.ID_TITULAR_ANT = " + ID + ") AND A.BARRA = " + vp3 + " AND A.ID_TITULAR = B.ID_TITULAR;";
                //Fcomando = Fcomando + " WHERE (A.NRO_SOC = " + vp1 + " AND  A.NRO_DEP=" + vp2 + " AND A.BARRA=" + vp3 + ") AND (A.ID_TITULAR = B.ID_TITULAR OR A.ID_TITULAR_ANT = B.ID_TITULAR_ANT);";
            }
            else
            {
                Fcomando = "SELECT A.NRO_SOCIO, A.NRO_DEP, ((A.NRO_ADH * 1000) + A.NRO_DEPADH) AS NRO_TAB, A.BARRA, A.APE_ADH, A.NOM_ADH, B.APE_SOC, B.NOM_SOC,";
                Fcomando = Fcomando + "  CASE WHEN A.NRO_DEPADH <> 11 then 'ADH' ELSE 'INP' END AS TIPO, A.COD_DTO, ";
                Fcomando = Fcomando + " (SELECT (CASE WHEN COUNT(*)>0 THEN 'S' ELSE 'N' END) FROM MOROSOS_DEPORTES WHERE DNI = A.NUM_DOCADH) AS MOROSO_DEPORTES,";
                Fcomando = Fcomando + " (SELECT (CASE WHEN COUNT(*)>0 THEN 'S' ELSE 'N' END) FROM MOROSOS_INVITADOS WHERE DNI = A.NUM_DOCADH) AS MOROSO_INVITADO, B.ID_TITULAR, A.NUM_DOCADH, A.F_BAJADH AS BAJA,";
                Fcomando = Fcomando + " A.F_BAJADH, (SELECT (CASE WHEN COUNT(*)>0 THEN 'S' ELSE 'N' END) FROM DEPORTES_ADM WHERE DNI = A.NUM_DOCADH  AND DEPORTES_ADM.FE_BAJA IS NULL) AS SOCIO_DEPORTES, A.F_NACIMADH AS NACIM";
                Fcomando = Fcomando + " FROM ADHERENT A, TITULAR B ";
                Fcomando = Fcomando + " WHERE A.ID_ADHERENTE = " + ID + " AND A.BARRA = " + vp3 + " AND A.ID_TITULAR = B.ID_TITULAR;";
                //Fcomando = Fcomando + " WHERE (A.NRO_ADH = " + vp1 + " AND A.NRO_DEPADH = " + vp2 + " AND A.BARRA = " + vp3 + ") AND (A.ID_TITULAR = B.ID_TITULAR OR A.ID_TITULAR_ANT = B.ID_TITULAR_ANT);";
            }

            try
            {
                conString conString = new conString();
                string connectionString = conString.get();
                FbConnection connection = new FbConnection(connectionString);
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                FbCommand cmd = new FbCommand(Fcomando, connection, transaction);
                cmd.CommandText = Fcomando;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataReader reader2 = cmd.ExecuteReader();
                listView1.Columns.Clear();
                listView1.Items.Clear();
                titulo = "RESULTADO DE LA BUSQUEDA";

                if (vtip_bus == "F")
                    Cargar_Resultado_FamAdhe2(reader2); //FAMILIAR
                else
                    Cargar_Resultado_Adhe2(reader2); //ADHERENTE

                transaction.Commit();
                reader2.Close();
                connection.Close();
                cmd = null;
                transaction = null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                textBox7.Focus();
            }
        }

        private void Cargar_Resultado_FamAdhe2(FbDataReader reader) //FAMADHE2
        {
            reader.Read();
            listView1.BeginUpdate();

            if (listView1.Columns.Count == 0)  //si no tiene columnas las creo
            {
                listView1.Columns.Add("NRO_SOC");
                listView1.Columns.Add("DEP");
                listView1.Columns.Add("TIPO");
                listView1.Columns.Add("TAB");
                listView1.Columns.Add("BARRA");
                listView1.Columns.Add("APELLIDO");
                listView1.Columns.Add("NOMBRE");
                listView1.Columns.Add("DTO");
                listView1.Columns.Add("APELLIDO TITULAR");
                listView1.Columns.Add("NOMBRE TITULAR");
                listView1.Columns.Add("ID");
                listView1.Columns.Add("MD");
                listView1.Columns.Add("MI");
                listView1.Columns.Add("DNI");
                listView1.Columns.Add("BAJA");
                listView1.Columns.Add("SD");
                listView1.Columns.Add("NACIM");
            }

            string BAJA = reader.GetString(reader.GetOrdinal("BAJA"));

            if (BAJA != "")
            {
                BAJA = BAJA.Substring(0, 10);
            }

            string NACIM = reader.GetString(reader.GetOrdinal("NACIM"));

            if (NACIM != "")
            {
                NACIM = NACIM.Substring(0, 10);
            }

            ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("NRO_SOC")).PadLeft(5, '0'));
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NRO_DEP")).PadLeft(3, '0'));
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TIPO")));
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NRO_TAB")).PadLeft(9, '0'));
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("BARRA")));
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("APE_FAM")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NOM_FAM")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("COD_DTO")).PadLeft(3, '0'));
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("APE_SOC")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NOM_SOC")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ID_TITULAR")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("MOROSO_DEPORTES")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("MOROSO_INVITADO")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NUM_DOCF")).Trim());
            listItem.SubItems.Add(BAJA);
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("SOCIO_DEPORTES")).Trim());
            listItem.SubItems.Add(NACIM);

            if (BAJA == "")
            {
                listItem.BackColor = Color.LightGreen;
            }
            else
            {
                listItem.BackColor = Color.Red;
                listItem.ForeColor = Color.White;
            }

            if (reader.GetString(reader.GetOrdinal("MOROSO_INVITADO")) == "S")
            {
                listItem.BackColor = Color.Red;
                listItem.ForeColor = Color.White;
            }

            //AGREGAR CONTROL DE EDAD PARA NO MARCAR EN VERDE FAMILIAR > 18 AÑOS
            string TIPO = reader.GetString(reader.GetOrdinal("TIPO"));
            int BARRA = int.Parse(reader.GetString(reader.GetOrdinal("BARRA")));
            int EDAD_FAMILIAR = 0;

            if (TIPO == "FAM" && NACIM != "" && BARRA >= 4)
            {
                edad EDAD = new edad();
                EDAD_FAMILIAR = EDAD.CALCULAR(NACIM);

                if (EDAD_FAMILIAR >= 18)
                {
                    listItem.BackColor = Color.Red;
                    listItem.ForeColor = Color.White;
                }
            }

            listView1.Items.Add(listItem);
            listView1.EndUpdate();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        ////MUESTRA DATOS EN EL LIST VIEW DE ADHERENTE el que se esta usando

        private void Cargar_Resultado_Adhe2(FbDataReader reader) //ADHE2
        {
            reader.Read();

            listView1.BeginUpdate();

            if (listView1.Columns.Count == 0)  //si no tiene columnas las creo
            {
                listView1.Columns.Add("NRO_SOC");
                listView1.Columns.Add("DEP");
                listView1.Columns.Add("TIPO");
                listView1.Columns.Add("TAB");
                listView1.Columns.Add("BARRA");
                listView1.Columns.Add("APELLIDO");
                listView1.Columns.Add("NOMBRE");
                listView1.Columns.Add("COD_DTO");
                listView1.Columns.Add("APELLIDO TITULAR");
                listView1.Columns.Add("NOMBRE TITULAR");
                listView1.Columns.Add("ID");
                listView1.Columns.Add("MD");
                listView1.Columns.Add("MI");
                listView1.Columns.Add("DNI");
                listView1.Columns.Add("BAJA");
                listView1.Columns.Add("SD");
                listView1.Columns.Add("NACIM");
            }

            string BAJA = reader.GetString(reader.GetOrdinal("BAJA"));

            if (BAJA != "")
            {
                BAJA = BAJA.Substring(0, 10);
            }

            string NACIM = reader.GetString(reader.GetOrdinal("NACIM"));

            if (NACIM != "")
            {
                NACIM = NACIM.Substring(0, 10);
            }


            ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("NRO_SOCIO")).PadLeft(5, '0'));
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NRO_DEP")).PadLeft(3, '0'));
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TIPO")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NRO_TAB")).PadLeft(9, '0'));
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("BARRA")));
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("APE_ADH")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NOM_ADH")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("COD_DTO")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("APE_SOC")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NOM_SOC")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ID_TITULAR")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("MOROSO_DEPORTES")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("MOROSO_INVITADO")).Trim());
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NUM_DOCADH")).Trim());
            listItem.SubItems.Add(BAJA);
            listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("SOCIO_DEPORTES")).Trim());
            listItem.SubItems.Add(NACIM);

            if (BAJA == "")
            {
                listItem.BackColor = Color.LightGreen;
            }
            else
            {
                listItem.BackColor = Color.Red;
                listItem.ForeColor = Color.White;
            }

            listView1.Items.Add(listItem);
            listView1.EndUpdate();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void BuscarAdh_ID(string campo)
        {
            string vcmd = "SELECT NRO_SOCIO, NRO_DEP, NRO_ADH, NRO_DEPADH, BARRA FROM ADHERENT WHERE ID_ADHERENTE = " + campo.Substring(2, 10).ToString();

            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand cmd = new FbCommand(vcmd, connection, transaction);
                    FbDataReader mt = cmd.ExecuteReader();

                    if (mt.Read())
                    {
                        textBox1.Text = (mt.GetString(mt.GetOrdinal("NRO_SOCIO")));
                        textBox5.Text = (mt.GetString(mt.GetOrdinal("NRO_DEP")));
                    }
                }
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                Boton_buscar();
            }

            if (e.KeyCode.ToString() == "F2")
            {
                limpio();
                btnVerDatos.Enabled = false;
                btnIngreso.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            VGlobales.vp_nuevo_socio = "SI";
            Socios frmABM = new Socios();
            Socios.vp_nro_soc = -1;
            Socios.vp_nro_dep = -1;
            frmABM.ShowDialog(this);
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            VGlobales.vp_cod_bar = string.Empty;

            Socios frmABM = new Socios();

            if (VGlobales.vp_role != "SISTEMAS")
            {
                Socios.vp_tabpage = -1;
            }
            else
            {
                Socios.vp_tabpage = 1;
            }

            Socios.vp_nro_soc = (int)(System.Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
            Socios.vp_nro_dep = (int)(System.Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text));

            if (listView1.SelectedItems[0].SubItems[2].Text == "ADH")
            {
                Socios.vp_tabpage += 3;
                VGlobales.vp_cod_bar = "A";
                VGlobales.vp_adh_inp = "A";
                vcampo = "A" + listView1.SelectedItems[0].SubItems[3].Text + listView1.SelectedItems[0].SubItems[4].Text.PadLeft(2, '0');
                int vp_nro_adh;
                Socios.vp_nro_adh = (int)(System.Convert.ToInt32(listView1.SelectedItems[0].SubItems[4].Text.PadLeft(2, '0'))); //le deja el valor de barra
                vp_nro_adh = (int)(System.Convert.ToInt32(listView1.FocusedItem.Index));
                VGlobales.vp_cod_bar = string.Empty;
                VGlobales.vp_adh_inp = "A";
                Socios.vp_nro_soc = (int)(System.Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                Socios.vp_nro_dep = (int)(System.Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text));
                Socios frm_soc_aux = new Socios();

                if (VGlobales.vp_role != "SISTEMAS")
                {
                    Socios.vp_tabpage = -1;
                }
                else
                {
                    Socios.vp_tabpage = 1;
                }

                VGlobales.vp_viene_de_barras = "S";
                VGlobales.vp_id_adhbarra = (int)(System.Convert.ToInt32(listView1.SelectedItems[0].SubItems[3].Text));
                VGlobales.vp_idadh_barra = listView1.SelectedItems[0].SubItems[4].Text;
                frm_soc_aux.ShowDialog(this);
            }
            else
            {
                if (listView1.SelectedItems[0].SubItems[2].Text == "INP") //Inv. Participativos
                {
                    Socios.vp_tabpage += 7;
                    VGlobales.vp_cod_bar = "A";
                    VGlobales.vp_adh_inp = "I";
                    vcampo = "A" + listView1.SelectedItems[0].SubItems[3].Text + listView1.SelectedItems[0].SubItems[4].Text.PadLeft(2, '0');
                    Socios.vp_nro_adh = (int)(System.Convert.ToInt32(listView1.SelectedItems[0].SubItems[4].Text.PadLeft(2, '0'))); //le deja el valor de barra
                }
                else
                {
                    if (listView1.SelectedItems[0].SubItems[2].Text == "FAM")
                    {
                        Socios.vp_tabpage += 2;
                        VGlobales.vp_cod_bar = "F";
                        Socios.vp_barra = (int)(System.Convert.ToInt32(listView1.SelectedItems[0].SubItems[4].Text.PadLeft(2, '0')));
                    }
                    else
                    {
                        Socios.vp_tabpage = 0;
                    }
                }
            }

            if (listView1.SelectedItems[0].SubItems[2].Text != "ADH")
                frmABM.ShowDialog(this);

            Cursor = Cursors.Default;
        }

        private void lleno_combos_Buscar()
        {
            string dato1 = "";

            if (VGlobales.vp_role == "CONFITERIA" || VGlobales.vp_role == "SSADPADUA" || VGlobales.vp_role == "JARDIN MATERNAL" || VGlobales.vp_role == "CPOCABA" || VGlobales.vp_role == "CPOPOLVORINES")
            {
                dato1 = "SELECT DISTINCT ROL FROM SECTACT WHERE ROL = '" + VGlobales.vp_role + "';";
            }
            else
            {
                dato1 = "SELECT DISTINCT ROL FROM SECTACT ORDER BY ROL";
            }

            string connectionString;
            DataSet ds1 = new DataSet();
            Datos_ini ini3 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini3.Servidor;
                cs.Port = int.Parse(ini3.Puerto);
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
                    DataTable dt1 = new DataTable("ROLES");
                    dt1.Columns.Add("ROL", typeof(string));
                    ds1.Tables.Add(dt1);
                    FbCommand cmd = new FbCommand(dato1, connection, transaction);
                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ROL")).Trim());
                    }

                    reader3.Close();
                    comboBox3.DisplayMember = "ROL";
                    comboBox3.ValueMember = "ROL";
                    comboBox3.DataSource = dt1;
                    comboBox3.SelectedIndex = -1;
                    transaction.Commit();
                }
            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR EL COMBO ROL");
            }
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //cambio_combo_rol();
        }

        private void cambio_combo_rol()
        {
            if (comboBox3.SelectedValue != null)
            {
                if (comboBox3.SelectedValue.ToString() == "ALOJAMIENTO")
                {
                    btnEgreso.Enabled = true;
                    btnIngreso.Enabled = false;
                }

                string paso = comboBox3.SelectedValue.ToString().Trim();
                string dato2 = "SELECT DESTINO, ID, ID_DESTINO FROM P_TMP_CURSOR('" + paso + "')";
                string connectionString;
                DataSet ds2 = new DataSet();
                Datos_ini ini4 = new Datos_ini();

                try
                {
                    FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                    cs.DataSource = ini4.Servidor; cs.Port = int.Parse(ini4.Puerto);
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

                        //Carga COMBOBOX2

                        DataTable dt2 = new DataTable("DESTINOS");

                        dt2.Columns.Add("DESTINO", typeof(string));
                        dt2.Columns.Add("ID", typeof(string));
                        dt2.Columns.Add("ID_DESTINO", typeof(string));
                        ds2.Tables.Add(dt2);

                        FbCommand cmd2 = new FbCommand(dato2, connection, transaction);
                        FbDataReader reader4 = cmd2.ExecuteReader();

                        DataRow fila;

                        while (reader4.Read())
                        {

                            fila = dt2.NewRow();
                            fila["ID"] = reader4.GetString(reader4.GetOrdinal("ID")).Trim();
                            fila["DESTINO"] = reader4.GetString(reader4.GetOrdinal("DESTINO")).Trim() + "-" + reader4.GetString(reader4.GetOrdinal("ID_DESTINO")).Trim();
                            fila["ID_DESTINO"] = reader4.GetString(reader4.GetOrdinal("ID_DESTINO")).Trim();
                            dt2.Rows.Add(fila);

                            //dt2.Rows.Add(reader4.GetString(reader4.GetOrdinal("DESTINO")).Trim(), reader4.GetString(reader4.GetOrdinal("ID")).Trim());
                            //dt2.Rows.Add(reader4.GetString(reader4.GetOrdinal("ID")).Trim());
                            //dt2.Columns.Add(reader4.GetString(reader4.GetOrdinal("ID")).Trim());
                        }
                        reader4.Close();

                        comboBox2.DataSource = dt2;

                        //comboBox2.DisplayMember = dt2.Columns[1].ToString();
                        comboBox2.DisplayMember = "DESTINO";

                        comboBox2.ValueMember = "ID";

                        comboBox2.SelectedIndex = -1;

                        transaction.Commit();
                    }
                }
                catch
                {
                    //MessageBox.Show("ERROR AL CARGAR EL COMBO DETALLE");
                    //return ds1;
                }
            }
        }

        


        private bool AREA_CAJA { get; set; }

        public void imprimirTicket(int GRUPO, string ID_DESTINO, string ID_PROFESIONAL)
        {
            if (VGlobales.vp_role == "INFORMES" || VGlobales.vp_role == "CONFITERIA")
            {
                bool IMPRIME = false;

                foreach (string areas in areas_orden)
                {
                    if (ID_DESTINO == Convert.ToString(areas))
                    {
                        IMPRIME = true;
                        AREA_CAJA = false;
                    }
                }

                if(o_arancel.haveArancel(int.Parse(ID_PROFESIONAL)))
                {
                    IMPRIME = true;
                    AREA_CAJA = true;
                }

                if (IMPRIME)
                {
                    PrintDialog pd = new PrintDialog();
                    PrintDocument pdoc = new PrintDocument();
                    PaperSize psize = new PaperSize();
                    pd.Document = pdoc;
                    pd.Document.DefaultPageSettings.PaperSize = psize;
                    pd.PrinterSettings.PrinterName = "Aclas Printer";
                    pdoc.PrintPage += new PrintPageEventHandler(pdoc_Print);
                    DialogResult result = pd.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        pdoc.Print();
                    }
                }
            }
        }

        private string getOrdenDeLlegada()
        {
            maxid mid = new maxid();
            string SECUENCIA = mid.m("SECUENCIA", "INGRESOS_A_PROCESAR");
            string QUERY = "SELECT ORDEN_LLEGADA FROM INGRESOS_A_PROCESAR WHERE SECUENCIA = " + SECUENCIA;
            conString conString = new conString();
            string connectionString = conString.get();
            DataSet GET = new DataSet();
            string ORDEN = String.Empty;

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                cmd.CommandText = QUERY;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(cmd);
                da.Fill(GET);
            }

            if (GET.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow ROW in GET.Tables[0].Rows)
                {
                    ORDEN = Convert.ToString(ROW[0]);
                }
            }

            return ORDEN;
        }

        private string getSelectedArea()
        {
            string RETURN = comboBox3.SelectedValue.ToString();

            if (RETURN == "PROSECRETARIA")
                RETURN = "REGISTRO DE SOCIOS";

            return RETURN;
        }

        public void pdoc_Print(object sender, PrintPageEventArgs e)
        {
            string ORDEN = getOrdenDeLlegada();
            Barcode39 code39 = new Barcode39();
            code39.CodeType = Barcode.CODE128;
            code39.ChecksumText = false;
            code39.GenerateChecksum = false;
            code39.X = 20;
            Graphics graphics = e.Graphics;
            Font courier_big = new Font("FontA1x1", 12);
            Font courier_med = new Font("FontA1x1", 10);
            Font courier_xxl = new Font("FontA1x1", 40);
            SolidBrush black = new SolidBrush(Color.Black);
            int startX = 0;
            int startY = 0;
            int Offset = 0;
            string FECHA = dpFechaIngreso.Text + " " + DateTime.Now.ToString("hh:mm:ss");
            string ID_DESTINO = comboBox2.SelectedValue.ToString();
            string AREA = "CAJA";

            if(AREA_CAJA == false)
                AREA = getSelectedArea();
            
            foreach (string areas in areas_orden)
            {
                if (ID_DESTINO == Convert.ToString(areas[0]))
                {
                    graphics.DrawString(Convert.ToString(areas[1]), courier_med, black, startX, startY + Offset);
                    Offset = Offset + 20;
                }
            }
            
            graphics.DrawString(FECHA, courier_med, black, startX, startY + Offset);
            Offset = Offset + 30;

            if (themedContainer1.IsBodyVisible)
            {
                string APE_SOC = listView1.SelectedItems[0].SubItems[4].Text;
                string NOM_SOC = listView1.SelectedItems[0].SubItems[5].Text;
                string NRO_SOC = listView1.SelectedItems[0].SubItems[0].Text;
                string NRO_DEP = listView1.SelectedItems[0].SubItems[1].Text;

                graphics.DrawString(ORDEN, courier_xxl, black, startX, startY + Offset);
                Offset = Offset + 70;

                graphics.DrawString(AREA, courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(APE_SOC + ", " + NOM_SOC, courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(NRO_SOC + " / " + NRO_DEP, courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(".", courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;
            }
            else if (themedContainer2.IsBodyVisible)
            {
                string APE_SOC = listView1.SelectedItems[0].SubItems[5].Text;
                string NOM_SOC = listView1.SelectedItems[0].SubItems[6].Text;
                string NRO_SOC = listView1.SelectedItems[0].SubItems[0].Text;
                string NRO_DEP = listView1.SelectedItems[0].SubItems[1].Text;
                string NRO_ADH = listView1.SelectedItems[0].SubItems[3].Text.Substring(0, 6);
                string NRO_DEPADH = listView1.SelectedItems[0].SubItems[3].Text.Substring(6, 3);
                string BARRA = listView1.SelectedItems[0].SubItems[4].Text;

                graphics.DrawString("1", courier_xxl, black, startX, startY + Offset);
                Offset = Offset + 70;

                graphics.DrawString(APE_SOC + ", " + NOM_SOC, courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(NRO_SOC + " / " + NRO_DEP, courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(NRO_ADH + " / " + NRO_DEPADH, courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(".", courier_med, black, startX, startY + Offset);
                Offset = Offset + 20;
            }
        }

        public void getPrefijoArea(int DESTINO)
        {
           
        }

        public void darIngresoEgreso(string ACCION)
        {
            if (comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("SELECCIONAR ROL Y DESTINO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string vId = comboBox2.SelectedValue.ToString();
                string vRol = comboBox3.SelectedValue.ToString();
                string vDestino = comboBox2.Text;
                string vIdDestino = "";
                string[] words = comboBox2.Text.Split('-');
                string email = tbEmail.Text;
                string telefono = tbTelefono.Text;
                string intereses = tbIntereses.Text;

                foreach (string word in words)
                {
                    vIdDestino = word;
                }

                //TITULARES Y NO SOCIOS
                if (themedContainer1.IsBodyVisible)
                {
                    string  TIPO_SOCIO = listView1.SelectedItems[0].SubItems[3].Text.Trim();
                    string  APELLIDO = listView1.SelectedItems[0].SubItems[4].Text;
                    string  NOMBRE = listView1.SelectedItems[0].SubItems[5].Text;
                    string  ROL = vRol.TrimEnd();
                    string  DESTINO = vDestino.TrimEnd();
                    string  ID_DESTINO = vIdDestino.TrimEnd();
                    string  NRO_SOC = listView1.SelectedItems[0].SubItems[0].Text;
                    string  NRO_DEP = listView1.SelectedItems[0].SubItems[1].Text;
                    string  DNI = listView1.SelectedItems[0].SubItems[11].Text.Trim();
                    string  COD_DTO = listView1.SelectedItems[0].SubItems[2].Text;
                    string  ID_PROF = vId;
                    string  USUARIO = VGlobales.vp_username;
                    string  EGRESO = dtpEgreso.Text;
                    string  CAT_SOC = listView1.SelectedItems[0].SubItems[12].Text;
                    int     GRUPO = gg.get(COD_DTO, CAT_SOC);
                    string  BAJA = listView1.SelectedItems[0].SubItems[13].Text;
                    string  MC = listView1.SelectedItems[0].SubItems[9].Text;
                    string  MD = listView1.SelectedItems[0].SubItems[10].Text;
                    decimal IMPORTE = 0;
                    int     NRO_PAGO = 0;
                    bool    CONTINUA = true;
                    string  FECHA_INGRESO = dpFechaIngreso.Text + " " + DateTime.Now.ToString("hh:mm:ss");

                    if (MC == "S" || MD == "S")
                    {
                        CONTINUA = false;

                        if (MessageBox.Show("SE ESTA POR DAR INGRESO A UN MOROSO\n¿ESTA SEGURO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CONTINUA = true;
                        }
                        else
                        {
                            MessageBox.Show("INGRESO CANCELADO POR EL USUARIO");
                        }
                    }

                    if (BAJA != "")
                    {
                        CONTINUA = false;

                        if (MessageBox.Show("SE ESTA POR DAR INGRESO A UN REGISTRO CON FECHA DE BAJA\n¿ESTA SEGURO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CONTINUA = true;
                        }
                        else
                        {
                            MessageBox.Show("INGRESO CANCELADO POR EL USUARIO");
                        }
                    }

                    if (CONTINUA == true)
                    {
                        try
                        {
                            switch (ACCION)
                            {
                                case "INGRESO":

                                    if (ID_PROF == "38") //REALIZA DOBLE INGRESO PARA PODER IMPRIMIR AMBOS RECIBOS EN CAJA
                                    {
                                        dlog.Inserto_Ingreso(APELLIDO, NOMBRE, TIPO_SOCIO, ROL, DESTINO, ID_DESTINO, NRO_SOC, NRO_DEP, "0", "0", "0", DNI, COD_DTO, "163", null, USUARIO, GRUPO, IMPORTE, NRO_PAGO, FECHA_INGRESO, MC, CUIL);
                                        dlog.Inserto_Ingreso(APELLIDO, NOMBRE, TIPO_SOCIO, ROL, DESTINO, ID_DESTINO, NRO_SOC, NRO_DEP, "0", "0", "0", DNI, COD_DTO, "164", null, USUARIO, GRUPO, IMPORTE, NRO_PAGO, FECHA_INGRESO, MC, CUIL);
                                    }
                                    else
                                    {
                                        dlog.Inserto_Ingreso(APELLIDO, NOMBRE, TIPO_SOCIO, ROL, DESTINO, ID_DESTINO, NRO_SOC, NRO_DEP, "0", "0", "0", DNI, COD_DTO, ID_PROF, null, USUARIO, GRUPO, IMPORTE, NRO_PAGO, FECHA_INGRESO, MC, CUIL);
                                    }

                                    imprimirTicket(GRUPO, ID_DESTINO, ID_PROF);

                                    MessageBox.Show("INGRESO GUARDADO", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;

                                case "EGRESO":
                                    dlog.Inserto_Ingreso(APELLIDO, NOMBRE, TIPO_SOCIO, ROL, DESTINO, ID_DESTINO, NRO_SOC, NRO_DEP, "0", "0", "0", DNI, COD_DTO, ID_PROF, EGRESO, USUARIO, GRUPO, IMPORTE, NRO_PAGO, FECHA_INGRESO, MC, CUIL);
                                    MessageBox.Show("INGRESO Y EGRESO GUARDADO", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                            }
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("NO SE PUDO GUARDAR EL " + ACCION + "\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (themedContainer2.IsBodyVisible)
                {
                    //ADHERENTES FAMILIARES E INVITADOS
                    string TIPO_SOCIO = listView1.SelectedItems[0].SubItems[2].Text.Trim();
                    string APELLIDO = listView1.SelectedItems[0].SubItems[5].Text;
                    string NOMBRE = listView1.SelectedItems[0].SubItems[6].Text;
                    string ROL = vRol.TrimEnd();
                    string DESTINO = vDestino.TrimEnd();
                    string ID_DESTINO = vIdDestino.TrimEnd();
                    string NRO_SOC = listView1.SelectedItems[0].SubItems[0].Text;
                    string NRO_DEP = listView1.SelectedItems[0].SubItems[1].Text;
                    string DNI = listView1.SelectedItems[0].SubItems[13].Text.Trim();
                    string COD_DTO = listView1.SelectedItems[0].SubItems[7].Text;
                    string ID_PROF = vId;
                    string USUARIO = VGlobales.vp_username;
                    string EGRESO = dtpEgreso.Text;
                    string CAT_SOC = listView1.SelectedItems[0].SubItems[2].Text;
                    string BARRA = listView1.SelectedItems[0].SubItems[4].Text;
                    string FECHA = listView1.SelectedItems[0].SubItems[16].Text;
                    int EDAD_FAMILIAR = 0;
                    string FECHA_INGRESO = dpFechaIngreso.Text + " " + DateTime.Now.ToString("hh:mm:ss");

                    if (TIPO_SOCIO == "FAM" && FECHA != "" && int.Parse(BARRA) >= 4)
                    {
                        edad EDAD = new edad();
                        EDAD_FAMILIAR = EDAD.CALCULAR(FECHA);

                        if (EDAD_FAMILIAR >= 18)
                        {
                            COD_DTO = "000";
                        }
                    }

                    int GRUPO = gg.get(COD_DTO, CAT_SOC);
                    string NRO_ADH = listView1.SelectedItems[0].SubItems[3].Text.Substring(0, 6);
                    string NRO_DEPADH = listView1.SelectedItems[0].SubItems[3].Text.Substring(6, 3);
                    string MD = listView1.SelectedItems[0].SubItems[11].Text;
                    string MI = listView1.SelectedItems[0].SubItems[12].Text;
                    string BAJA = listView1.SelectedItems[0].SubItems[14].Text;
                    bool CONTINUA = true;
                    decimal IMPORTE = 0;
                    int NRO_PAGO = 0;
                    int NRO_BONO = 0;

                    if (MI == "S" || MD == "S")
                    {
                        CONTINUA = false;

                        if (MessageBox.Show("SE ESTA POR DAR INGRESO A UN MOROSO\n¿ESTA SEGURO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CONTINUA = true;
                        }
                        else
                        {
                            MessageBox.Show("INGRESO CANCELADO POR EL USUARIO");
                        }
                    }

                    if (BAJA != "")
                    {
                        CONTINUA = false;

                        if (MessageBox.Show("SE ESTA POR DAR INGRESO A UN REGISTRO CON FECHA DE BAJA\n¿ESTA SEGURO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CONTINUA = true;
                        }
                        else
                        {
                            MessageBox.Show("INGRESO CANCELADO POR EL USUARIO");
                        }
                    }

                    if (CONTINUA == true)
                    {
                        try
                        {
                            switch (ACCION)
                            {
                                case "INGRESO":

                                    if (ID_PROF == "38")
                                    {
                                        dlog.Inserto_Ingreso(APELLIDO, NOMBRE, TIPO_SOCIO, ROL, DESTINO, ID_DESTINO, NRO_SOC, NRO_DEP, NRO_ADH, NRO_DEPADH, BARRA, DNI, COD_DTO, "163", null, USUARIO, GRUPO, IMPORTE, NRO_PAGO, FECHA_INGRESO, "X", CUIL);
                                        dlog.Inserto_Ingreso(APELLIDO, NOMBRE, TIPO_SOCIO, ROL, DESTINO, ID_DESTINO, NRO_SOC, NRO_DEP, NRO_ADH, NRO_DEPADH, BARRA, DNI, COD_DTO, "164", null, USUARIO, GRUPO, IMPORTE, NRO_PAGO, FECHA_INGRESO, "X", CUIL);
                                    }
                                    else
                                    {
                                        dlog.Inserto_Ingreso(APELLIDO, NOMBRE, TIPO_SOCIO, ROL, DESTINO, ID_DESTINO, NRO_SOC, NRO_DEP, NRO_ADH, NRO_DEPADH, BARRA, DNI, COD_DTO, ID_PROF, null, USUARIO, GRUPO, IMPORTE, NRO_PAGO, FECHA_INGRESO, "X", CUIL);
                                    }

                                    imprimirTicket(GRUPO, ID_DESTINO, ID_PROF);

                                    MessageBox.Show("INGRESO GUARDADO", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;

                                case "EGRESO":
                                    dlog.Inserto_Ingreso(APELLIDO, NOMBRE, TIPO_SOCIO, ROL, DESTINO, ID_DESTINO, NRO_SOC, NRO_DEP, NRO_ADH, NRO_DEPADH, BARRA, DNI, COD_DTO, ID_PROF, EGRESO, USUARIO, GRUPO, IMPORTE, NRO_PAGO, FECHA_INGRESO, "X", CUIL);
                                    MessageBox.Show("INGRESO Y EGRESO GUARDADO", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                            }
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("NO SE PUDO GUARDAR EL " + ACCION + "\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            darIngresoEgreso("INGRESO");
            Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consulta frm_Consultar = new Consulta();
            frm_Consultar.ShowDialog(this);
        }

        public void guardarInfoContacto(int VALIDAR)
        {
            int BARRA = 0;
            int NRO_ADH = 0;
            int DEP_ADH = 0;

            if (themedContainer2.IsBodyVisible)
            {
                BARRA = int.Parse(listView1.SelectedItems[0].SubItems[4].Text);
                NRO_ADH = int.Parse(listView1.SelectedItems[0].SubItems[3].Text.Substring(0, 6));
                DEP_ADH = int.Parse(listView1.SelectedItems[0].SubItems[3].Text.Substring(6, 3));
            }

            int NRO_SOC = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            int NRO_DEP = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
            string EMAIL = tbEmail.Text;
            string TELEFONO = tbTelefono.Text;
            string INTERESES = tbIntereses.Text;

            if (VALIDAR == 1)
            {
                if (EMAIL == "" && TELEFONO == "" && INTERESES == "")
                {
                    MessageBox.Show("COMPLETAR EL CAMPO EMAIL, TELEFONO O INTERESES", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        dlog.insertoContacto(NRO_SOC, NRO_DEP, BARRA, EMAIL, TELEFONO, INTERESES, "0", NRO_ADH, DEP_ADH);
                        MessageBox.Show("INFORMACION DE CONTACTO GUARDADA", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO GUARDAR\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (EMAIL != "" || TELEFONO != "" || INTERESES != "")
                {
                    try
                    {
                        dlog.insertoContacto(NRO_SOC, NRO_DEP, BARRA, EMAIL, TELEFONO, INTERESES, "0", NRO_ADH, DEP_ADH);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO GUARDAR LA INFORMACION DE CONTACTO\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            guardarInfoContacto(1);
        }

        private void btnEgreso_Click(object sender, EventArgs e)
        {
            darIngresoEgreso("EGRESO");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambio_combo_rol();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            //Socios frmABM = new Socios();

            //VGlobales.vp_servyact = "S";
           
            //frmABM.ShowDialog(this);
            
            VGlobales.vp_cod_bar = string.Empty;

            Socios frmABM = new Socios();

            Socios.vp_nro_soc = (int)(System.Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
            Socios.vp_nro_dep = (int)(System.Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text));

            //Agregadas por Sebastian 17-04-2015
            VGlobales.vp_Titular_Soc = listView1.SelectedItems[0].SubItems[0].Text;
            VGlobales.vp_Titular_Dep = listView1.SelectedItems[0].SubItems[1].Text;
            VGlobales.vp_IdScocio = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text + "" + listView1.SelectedItems[0].SubItems[1].Text);

            //Agregado por Sebastian 20-01-2016
            VGlobales.vp_CodDto = listView1.SelectedItems[0].SubItems[2].Text;
            VGlobales.vp_CatSoc = listView1.SelectedItems[0].SubItems[12].Text;
            VGlobales.vp_Grupo = gg.get(VGlobales.vp_CodDto, VGlobales.vp_CatSoc);


            //VGlobales.vp_viene_de_barras = "S";
            VGlobales.vp_servyact = "S";

            frmABM.ShowDialog(this);

            Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nro_soc = listView1.SelectedItems[0].SubItems[0].Text;

            string nro_dep = listView1.SelectedItems[0].SubItems[1].Text;

            string nro_bar = listView1.SelectedItems[0].SubItems[4].Text;

            string tipo_soc = listView1.SelectedItems[0].SubItems[2].Text;

            tieneTurno tt = new tieneTurno(nro_soc, nro_dep, nro_bar, tipo_soc);

            tt.ShowDialog();
        }

        private void dgvTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox3.SelectedValue = dgvTurnos[5, dgvTurnos.CurrentCell.RowIndex].Value.ToString();
            comboBox2.SelectedValue = dgvTurnos[6, dgvTurnos.CurrentCell.RowIndex].Value.ToString();
            obtenerCuenta();
        }

        private void tieneObservacionInterior(string DNI)
        {
            bo dlog = new bo();
            string QUERY = "SELECT ID FROM OBS_INTERIOR WHERE DNI = '" + DNI + "';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                lbObsInterior.ForeColor = Color.Red;
            }
            else
            {
                lbObsInterior.ForeColor = Color.Gray;
            }
        }

        private void tieneDatosBancarios(string ID, string TIPO)
        {
            bo dlog = new bo();
            string QUERY = "";

            if (TIPO == "FAM")
            {
                QUERY = "SELECT ID_FAMILIAR FROM TITULAR_CBU WHERE ID_FAMILIAR = '" + ID + "' AND FE_BAJA IS NULL;";
            }
            else if (TIPO == "ADH")
            {
                QUERY = "SELECT ID_ADHERENTE FROM TITULAR_CBU WHERE ID_ADHERENTE = '" + ID + "' AND FE_BAJA IS NULL;";
            }
            else if (TIPO == "INP")
            {
                QUERY = "SELECT ID_ADHERENTE FROM TITULAR_CBU WHERE ID_ADHERENTE = '" + ID + "' AND FE_BAJA IS NULL;";
            }
            else
            {
                QUERY = "SELECT ID_TITULAR FROM TITULAR_CBU WHERE ID_TITULAR = '" + ID + "' AND ID_FAMILIAR = 0 AND ID_ADHERENTE = 0 AND FE_BAJA IS NULL;";
            }

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                lbDatosBancarios.ForeColor = Color.Green;
            }
            else
            {
                lbDatosBancarios.ForeColor = Color.Gray;
            }
        }

        private void mostrarContacto(int NRO_SOC, int NRO_DEP, int NRO_ADH, int DEP_ADH, int BARRA)
        { 
            bo dlog = new bo();
            string QUERY = "";

            if (NRO_SOC > 0)
            {
                QUERY = "SELECT FIRST 1 EMAIL, TELEFONO, INTERESES FROM CONTACTO WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = " + BARRA + " ORDER BY ID DESC;";
            }

            if (NRO_ADH > 0)
            {
                QUERY = "SELECT FIRST 1 EMAIL, TELEFONO, INTERESES FROM CONTACTO WHERE NRO_ADH = " + NRO_ADH + " AND DEP_ADH = " + DEP_ADH + " AND BARRA = " + BARRA + " ORDER BY ID DESC;";
            }

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                tbEmail.Text = foundRows[0][0].ToString();
                tbTelefono.Text = foundRows[0][1].ToString();
                tbIntereses.Text = foundRows[0][2].ToString();
            }
            else
            {
                tbEmail.Text = "";
                tbTelefono.Text = "";
                tbIntereses.Text = "";
            }
        }

        public void habilitarBotonAsamblea()
        {
            if (listView1.SelectedItems[0].SubItems[1].Text != "994" 
                && listView1.SelectedItems[0].SubItems[1].Text != "995" 
                /*&& listView1.SelectedItems[0].SubItems[1].Text != "020"*/)
            {
                btnIngresoAsamblea.Enabled = false;
            }
            else if (listView1.SelectedItems[0].SubItems[13].Text != "")
            {
                btnIngresoAsamblea.Enabled = false;
            }
            else
            {
                btnIngresoAsamblea.Enabled = true;
            }
        }

        public void morososTitulares()
        {
            if (listView1.SelectedItems[0].SubItems[9].Text == "S") //MOROSO
            {
                lbMoraCuota.ForeColor = Color.Red;
            }
            else
            {
                lbMoraCuota.ForeColor = Color.DimGray;
            }

            if (listView1.SelectedItems[0].SubItems[10].Text == "S") //MOROSO_INVITADO
            {
                lbMoraDepo.ForeColor = Color.Red;
            }
            else
            {
                lbMoraDepo.ForeColor = Color.DimGray;
            }

            if (listView1.SelectedItems[0].SubItems[14].Text == "S") //MOROSO_NO_DESC
            {
                lbMorosoNoDesc.ForeColor = Color.Red;
            }
            else
            {
                lbMorosoNoDesc.ForeColor = Color.DimGray;
            }

            if (listView1.SelectedItems[0].SubItems[15].Text == "S") //SOCIO_DEPORTES
            {
                lbSocioDepo.ForeColor = Color.Red;
            }
            else
            {
                lbSocioDepo.ForeColor = Color.DimGray;
            }

            if (listView1.SelectedItems[0].SubItems[18].Text == "S") //MOROSO NO ALCANZA
            {
                lbMorosoNoAlcanza.ForeColor = Color.Red;
            }
            else
            {
                lbMorosoNoAlcanza.ForeColor = Color.DimGray;
            }
        }

        public void morososNoTitulares()
        {
            if (listView1.SelectedItems[0].SubItems[11].Text == "S") //MOROSO_INVITADO
            {
                lbMoraDepo.ForeColor = Color.Red;
            }
            else
            {
                lbMoraDepo.ForeColor = Color.DimGray;
            }

            if (listView1.SelectedItems[0].SubItems[12].Text == "S") //MOROSO_DEPORTES
            {
                lbMoraInp.ForeColor = Color.Red;
            }
            else
            {
                lbMoraInp.ForeColor = Color.DimGray;
            }

            if (listView1.SelectedItems[0].SubItems[15].Text == "S") //SOCIO_DEPORTES
            {
                lbSocioDepo.ForeColor = Color.Red;
            }
            else
            {
                lbSocioDepo.ForeColor = Color.DimGray;
            }
        }

        private string tipoCaja(int ID_TITULAR)
        {
            string TIPO = "NO SE PUDO OBTENER";
            string QUERY = "SELECT AAR, PAR, PCRJP1 FROM TITULAR WHERE ID_TITULAR = " + ID_TITULAR;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            int AAR = int.Parse(foundRows[0][0].ToString());
            int PAR = int.Parse(foundRows[0][1].ToString());
            int PCRJP1 = int.Parse(foundRows[0][2].ToString());

            if (AAR == 1 && PAR == 0)
            {
                TIPO = "ACTIVIDAD";
            }

            if (PAR == 2 && PCRJP1 < 52)
            {
                TIPO = "PASIVIDAD";
            }

            if (PAR == 2 && PCRJP1 > 26)
            {
                TIPO = "PENSIONADO/A";
            }

            if ((AAR == 4 || AAR == 5 || AAR == 6 || AAR == 7 || AAR == 8) && PCRJP1 > 26)
            {
                TIPO = "FONDOS PROPIOS";
            }

            return TIPO;
        }

        private string rangoLetras(int ID_TITULAR)
        {
            string RANGO = "NO SE PUDO OBTENER";
            string MESA_VOTO = obtenerMesaVoto(ID_TITULAR);
            string TIPO_CAJA = tipoCaja(ID_TITULAR);

            if (TIPO_CAJA == "ACTIVIDAD")
            {
                switch (MESA_VOTO)
                {
                    case "1":
                        RANGO = "A - Ñ";
                        break;

                    case "2":
                        RANGO = "B";
                        break;

                    case "3":
                        RANGO = "C - CH";
                        break;

                    case "4":
                        RANGO = "D - E";
                        break;

                    case "5":
                        RANGO = "F";
                        break;

                    case "6":
                        RANGO = "G";
                        break;

                    case "7":
                        RANGO = "H -I -J - K";
                        break;

                    case "8":
                        RANGO = "L - LL";
                        break;

                    case "9":
                        RANGO = "M";
                        break;

                    case "10":
                        RANGO = "N - O";
                        break;

                    case "11":
                        RANGO = "P";
                        break;

                    case "12":
                        RANGO = "Q - R";
                        break;

                    case "13":
                        RANGO = "S";
                        break;

                    case "14":
                        RANGO = "T - U";
                        break;

                    case "15":
                        RANGO = "V - W - X - Y - Z";
                        break;

                }
            }

            if (TIPO_CAJA == "PASIVIDAD")
            {
                switch (MESA_VOTO)
                {
                    case "1":
                        RANGO = "A - B";
                        break;

                    case "2":
                        RANGO = "C - CH";
                        break;

                    case "3":
                        RANGO = "D - E - F";
                        break;

                    case "4":
                        RANGO = "G - H";
                        break;

                    case "5":
                        RANGO = "I - J - K - L";
                        break;

                    case "6":
                        RANGO = "M - N - Ñ";
                        break;

                    case "7":
                        RANGO = "O - P - Q";
                        break;

                    case "8":
                        RANGO = "R - S";
                        break;

                    case "9":
                        RANGO = "T - U - V - W - X - Y - Z";
                        break;
                }
            }

            if (TIPO_CAJA == "PENSIONADO/A")
            {
                RANGO = "de la A a la Z";
            }

            if (TIPO_CAJA == "FONDOS PROPIOS")
            {
                RANGO = "de la A a la Z";
            }

            return RANGO;
        }

        private string puedeVotar(int ID_TITULAR)
        {
            
            string PUEDE = "NO";
            DateTime F_ALTCI = Convert.ToDateTime(obtenerFechaAlta(ID_TITULAR).Replace(" 00:00:00", ""));
            DateTime FECHA_TOPE = Convert.ToDateTime(Config.getValor("PROSECRETARIA", "ELECCIONES", 2).Replace(" 00:00:00", ""));
            TimeSpan diff = FECHA_TOPE.Subtract(F_ALTCI);
            // Validar los dias para ver si puede votar
            return PUEDE;
        }

        private string obtenerFechaAlta(int ID_TITULAR)
        {
            string QUERY = "SELECT F_ALTCI FROM TITULAR WHERE ID_TITULAR = " + ID_TITULAR;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            return foundRows[0][0].ToString().Trim();
        }

        private string obtenerNombreSocio(int ID_TITULAR)
        {
            string QUERY = "SELECT NOM_SOC, APE_SOC FROM TITULAR WHERE ID_TITULAR = " + ID_TITULAR;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            return foundRows[0][0].ToString().Trim() + " " + foundRows[0][1].ToString().Trim();
        }

        private string obtenerMesaVoto(int ID_TITULAR)
        {
            string QUERY = "SELECT COD_9 FROM TITULAR WHERE ID_TITULAR = " + ID_TITULAR;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            return foundRows[0][0].ToString().Trim();
        }

        private void mostrarMesaVoto(int ID_TITULAR)
        {
            string ACTIVA = Config.getValor("PROSECRETARIA", "ELECCIONES", 1);

            if (ACTIVA == "1")
            {
                string PUEDE_VOTAR = puedeVotar(ID_TITULAR);
                V_NOMBRE_SOCIO = obtenerNombreSocio(ID_TITULAR);
                V_MESA_VOTO = obtenerMesaVoto(ID_TITULAR);
                V_TIPO_CAJA = tipoCaja(ID_TITULAR);
                V_RANGO_LETRAS = rangoLetras(ID_TITULAR);
                MessageBox.Show(V_NOMBRE_SOCIO + "\n\rMESA DE VOTO " + V_TIPO_CAJA + " N°: " + V_MESA_VOTO + "\n\rLETRAS: " + V_RANGO_LETRAS);
                imprimirMesaVoto();
            }
        }

        string V_TIPO_CAJA { get; set; }
        string V_MESA_VOTO { get; set; }
        string V_RANGO_LETRAS { get; set; }
        string V_NOMBRE_SOCIO { get; set; }

        private void imprimirMesaVoto()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument edoc = new PrintDocument();
            PaperSize psize = new PaperSize();
            pd.Document = edoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            //pd.PrinterSettings.PrinterName = "Aclas Printer";
            edoc.PrintPage += new PrintPageEventHandler(edoc_Print);
            DialogResult result = pd.ShowDialog();

            if (result == DialogResult.OK)
            {
                edoc.Print();
            }
        }

        public void edoc_Print(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font courier_big = new Font("FontA1x1", 12);
            Font courier_med = new Font("FontA1x1", 10);
            Font courier_xxl = new Font("FontA1x1", 40);
            SolidBrush black = new SolidBrush(Color.Black);
            int startX = 0;
            int startY = 0;
            int Offset = 0;

            graphics.DrawString(V_NOMBRE_SOCIO, courier_med, black, startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString(V_TIPO_CAJA, courier_med, black, startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString(V_RANGO_LETRAS, courier_med, black, startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString("MESA N°", courier_med, black, startX, startY + Offset);
            Offset = Offset + 20;

            graphics.DrawString(V_MESA_VOTO, courier_xxl, black, startX, startY + Offset);
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            dgvTurnos.DataSource = null;
            btnVerDatos.Enabled = true;
            btnIngreso.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            btnPagos.Enabled = true;
            string NRO_SOC = string.Empty;
            string NRO_DEP = string.Empty;
            string BARRA = "0";
            string DNI = string.Empty;
            int NRO_ADH = 0;
            int DEP_ADH = 0;
            int ID_TITULAR = 0;
            string TIPO = "TIT";
            string ID_TITULAR_ANT = "";
            string F_CARN = "";

            if (themedContainer1.IsBodyVisible) //TITULARES
            {
                NRO_SOC = listView1.SelectedItems[0].SubItems[0].Text;
                NRO_DEP = listView1.SelectedItems[0].SubItems[1].Text;
                DNI = listView1.SelectedItems[0].SubItems[11].Text;
                ID_TITULAR = (int.Parse(NRO_SOC) * 1000) + int.Parse(NRO_DEP);
                ID_TITULAR_ANT = listView1.SelectedItems[0].SubItems[16].Text;
                F_CARN = listView1.SelectedItems[0].SubItems[17].Text;

                mostrarMesaVoto(ID_TITULAR);

                if (VGlobales.vp_role == "SERVICIOS MEDICOS" || VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "INFORMES" || VGlobales.vp_role == "CAJA")
                {
                    mostrarObservaciones(DNI);
                    mostrarTurnos(NRO_SOC, NRO_DEP, BARRA);
                }

                if (VGlobales.vp_role == "INTERIOR" || VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "INFORMES")
                {
                    tieneObservacionInterior(DNI);
                }

                if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "PROSECRETARIA" || VGlobales.vp_role == "DESCUENTOS")
                {
                    tieneDatosBancarios(ID_TITULAR.ToString(), TIPO);
                }

                if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "PROSECRETARIA")
                {
                    habilitarBotonAsamblea();
                }
                
                mostrarContacto(int.Parse(NRO_SOC), int.Parse(NRO_DEP), 0, 0, 0);
                morososTitulares();

                if (VGlobales.vp_role == "INFORMES")
                {
                    if (ID_TITULAR_ANT != "")
                    {
                        if (F_CARN != "")
                        {
                            DateTime FECHA = Convert.ToDateTime("21/03/2017");
                            DateTime FECHA_CARNET = Convert.ToDateTime(F_CARN);

                            if (FECHA > FECHA_CARNET)
                            {
                                MessageBox.Show("SOLICITAR ACERCARSE A REGISTRO DE SOCIOS PARA REALIZAR LA RENOVACION DE CARNET", "MENSAJE");
                            }
                        }
                    }
                }
            }
            else
            {
                btnIngresoAsamblea.Enabled = false;
            }

            if (themedContainer2.IsBodyVisible) //ADH FAM Y INP
            {
                NRO_SOC = listView1.SelectedItems[0].SubItems[0].Text;
                NRO_DEP = listView1.SelectedItems[0].SubItems[1].Text;
                BARRA = listView1.SelectedItems[0].SubItems[4].Text;
                DNI = listView1.SelectedItems[0].SubItems[13].Text;

                if (listView1.SelectedItems[0].SubItems[2].Text == "ADH" || listView1.SelectedItems[0].SubItems[2].Text == "INP")
                {
                    NRO_ADH = int.Parse(listView1.SelectedItems[0].SubItems[3].Text.Substring(0, 6));
                    DEP_ADH = int.Parse(listView1.SelectedItems[0].SubItems[3].Text.Substring(6, 3));

                    if (VGlobales.vp_role == "SERVICIOS MEDICOS" || VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "INFORMES" || VGlobales.vp_role == "CAJA")
                    {
                        mostrarObservaciones(DNI);
                        mostrarTurnos(NRO_ADH.ToString(), DEP_ADH.ToString(), BARRA);
                    }
                }
                else
                {
                    if (VGlobales.vp_role == "SERVICIOS MEDICOS" || VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "INFORMES" || VGlobales.vp_role == "CAJA")
                    {
                        mostrarObservaciones(DNI);
                        mostrarTurnos(NRO_SOC.ToString(), NRO_DEP.ToString(), BARRA);
                    }
                }

                if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "PROSECRETARIA" || VGlobales.vp_role == "DESCUENTOS")
                {
                    TIPO = listView1.SelectedItems[0].SubItems[2].Text;

                    if (TIPO == "ADH")
                    {
                        string ID_ADHERENTE = listView1.SelectedItems[0].SubItems[3].Text + "" + listView1.SelectedItems[0].SubItems[4].Text.PadLeft(2, '0');
                        tieneDatosBancarios(ID_ADHERENTE, TIPO);
                    }
                    else if (TIPO == "INP")
                    {
                        string ID_ADHERENTE = int.Parse(listView1.SelectedItems[0].SubItems[3].Text).ToString() + "" + listView1.SelectedItems[0].SubItems[4].Text.PadLeft(2, '0');
                        tieneDatosBancarios(ID_ADHERENTE, TIPO);
                    }
                    else if (TIPO == "FAM")
                    {
                        string ID_FAMILIAR = ((int.Parse(NRO_SOC) * 1000) + int.Parse(NRO_DEP)).ToString() + "" + listView1.SelectedItems[0].SubItems[4].Text.PadLeft(2, '0');
                        tieneDatosBancarios(ID_FAMILIAR, TIPO);
                    }
                }

                if (VGlobales.vp_role == "INTERIOR" || VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "INFORMES")
                {
                    tieneObservacionInterior(DNI);
                }
                
                mostrarContacto(int.Parse(NRO_SOC), int.Parse(NRO_DEP), NRO_ADH, DEP_ADH, int.Parse(BARRA));
                morososNoTitulares();
            }

            if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "CAJA" || VGlobales.vp_role == "INFORMES" || VGlobales.vp_role == "CONTADURIA"
                || VGlobales.vp_role == "JARDIN MATERNAL" || VGlobales.vp_role == "CPOCABA" || VGlobales.vp_role == "CPOPOLVORINES" || VGlobales.vp_role == "INTERIOR")
            {
                btnCargarRecibo.Enabled = true;
            }

            pintarTurnoDelDia();
            Cursor = Cursors.Default;
        }

        private void btnCargarRecibo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("SELECCIONAR ROL Y DESTINO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (themedContainer1.IsBodyVisible) //SOCIOS TITULARES
                {
                    string NRO_SOC = listView1.SelectedItems[0].SubItems[0].Text;
                    string NRO_DEP = listView1.SelectedItems[0].SubItems[1].Text;
                    string TITULAR_SOC = listView1.SelectedItems[0].SubItems[0].Text;
                    string TITULAR_DEP = listView1.SelectedItems[0].SubItems[1].Text;
                    string COD_DTO = listView1.SelectedItems[0].SubItems[2].Text;
                    string APELLIDO = listView1.SelectedItems[0].SubItems[4].Text.TrimEnd();
                    string NOMBRE = listView1.SelectedItems[0].SubItems[5].Text.TrimEnd();
                    string CAT_SOC = listView1.SelectedItems[0].SubItems[12].Text;
                    int ID_PROFESIONAL = int.Parse(comboBox2.SelectedValue.ToString());
                    string ROL = comboBox3.SelectedValue.ToString();
                    VGlobales.ROL_NAME = comboBox3.Text;
                    string DESTINO = comboBox2.Text;
                    string ID_DESTINO = "";
                    string[] SPLIT = comboBox2.Text.Split('-');
                    int ID_SOCIO = int.Parse(listView1.SelectedItems[0].SubItems[8].Text);
                    string BARRA = "0";
                    string DNI = listView1.SelectedItems[0].SubItems[11].Text;
                    string TIPO = listView1.SelectedItems[0].SubItems[3].Text;
                    int GRUPO = gg.get(COD_DTO, CAT_SOC);
                    decimal IMPORTE = 0;
                    int CUENTA = int.Parse(lbCuenta.Text);
                    string RB = lbRB.Text;
                    string NRO_RECIBO = "0";

                    foreach (string word in SPLIT)
                    {
                        ID_DESTINO = word;
                    }

                    recibos r = new recibos(ID_SOCIO, int.Parse(ID_DESTINO), ID_PROFESIONAL, 0, APELLIDO, NOMBRE, TIPO, BARRA, COD_DTO,
                    NRO_RECIBO, NRO_SOC, NRO_DEP, NRO_SOC, NRO_DEP, CUENTA, DNI, GRUPO, IMPORTE, RB, "NO", CUIL);
                    r.ShowDialog();
                }
                
                if (themedContainer2.IsBodyVisible) 
                {
                    string NRO_SOC = listView1.SelectedItems[0].SubItems[3].Text.Substring(0, 6);
                    string NRO_DEP = listView1.SelectedItems[0].SubItems[3].Text.Substring(7, 2);
                    string CAT_SOC = listView1.SelectedItems[0].SubItems[2].Text;
                    string TAB = listView1.SelectedItems[0].SubItems[3].Text;
                    string TITULAR_SOC = listView1.SelectedItems[0].SubItems[0].Text;
                    string TITULAR_DEP = listView1.SelectedItems[0].SubItems[1].Text;
                    string BARRA = listView1.SelectedItems[0].SubItems[4].Text;
                    string COD_DTO = listView1.SelectedItems[0].SubItems[7].Text;
                    int    ID_SOCIO = int.Parse(TITULAR_SOC + TITULAR_DEP);
                    string ID_PROFESIONAL = comboBox2.SelectedValue.ToString();
                    string ROL = comboBox3.SelectedValue.ToString();
                    string DESTINO = comboBox2.Text;
                    string APELLIDO = listView1.SelectedItems[0].SubItems[5].Text;
                    string NOMBRE = listView1.SelectedItems[0].SubItems[6].Text;
                    string NOMBRE_SOCIO = listView1.SelectedItems[0].SubItems[6].Text + ", " + listView1.SelectedItems[0].SubItems[5].Text;
                    string ID_DESTINO = "";
                    string[] SPLIT = comboBox2.Text.Split('-');
                    string DNI = listView1.SelectedItems[0].SubItems[13].Text;
                    string TIPO = listView1.SelectedItems[0].SubItems[3].Text;
                    int GRUPO = gg.get(COD_DTO, CAT_SOC);
                    decimal IMPORTE = 0;
                    int CUENTA = int.Parse(lbCuenta.Text);
                    string RB = lbRB.Text;
                    string NRO_RECIBO = "0";

                    foreach (string word in SPLIT)
                    {
                        ID_DESTINO = word;
                    }

                    recibos r = new recibos(ID_SOCIO, int.Parse(ID_DESTINO), int.Parse(ID_PROFESIONAL), 0, APELLIDO, NOMBRE, TIPO, BARRA, COD_DTO,
                    NRO_RECIBO, NRO_SOC, NRO_DEP, TITULAR_SOC, TITULAR_DEP, CUENTA, DNI, GRUPO, IMPORTE, RB, "NO", CUIL);
                    r.ShowDialog();
                }
            }

            Cursor = Cursors.Default;
        }

        private void obtenerCuenta()
        {
            string query = "SELECT CUENTA, BONO_RECIBO FROM PROFESIONALES WHERE ID = " + comboBox2.SelectedValue.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();
            int cuenta = int.Parse(foundRows[0][0].ToString());
            string rb = foundRows[0][1].ToString();
            lbCuenta.Text = cuenta.ToString();
            lbRB.Text = rb;
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            obtenerCuenta();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            int ID = 0;

            if (themedContainer1.IsBodyVisible) //TITULARES
            {
                ID = int.Parse(listView1.SelectedItems[0].SubItems[8].Text);
            }
            else
            {
                if (listView1.SelectedItems[0].SubItems[2].Text == "FAM")
                {
                    ID = int.Parse(listView1.SelectedItems[0].SubItems[10].Text);
                }
                else
                {
                    ID = int.Parse(listView1.SelectedItems[0].SubItems[3].Text);
                }
                
            }

            informePagos ip = new informePagos(ID, VGlobales.vp_role);
            ip.ShowDialog();
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "ORIENTACION SOCIAL")
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                    {
                        cmOSocial.Show(Cursor.Position);
                    }
                }
            }

            if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "INFORMES" || VGlobales.vp_role == "SERVICIOS MEDICOS")
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                    {
                        cmEncuesta.Show(Cursor.Position);
                    }
                }
            }

            if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "INTERIOR")
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                    {
                        cmObservacionesInterior.Show(Cursor.Position);
                    }
                }
            }

            if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "DEPORTES")
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                    {
                        cmDeportes.Show(Cursor.Position);
                    }
                }
            }

            if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role == "PROSECRETARIA")
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                    {
                        cmProsecretaria.Show(Cursor.Position);
                    }
                }
            }
        }

        private void tsEncuesta_Click(object sender, EventArgs e)
        {
            if (themedContainer1.IsBodyVisible)
            { 
                string NOMBRE = listView1.SelectedItems[0].SubItems[4].Text + ", " +listView1.SelectedItems[0].SubItems[5].Text;
                int DNI = int.Parse(listView1.SelectedItems[0].SubItems[11].Text); 
                int NRO_SOC = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);  
                int NRO_DEP = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);   
                int NRO_SOC_ADH = 0; 
                int NRO_DEP_ADH = 0;
                int BARRA = 0;

                cargaEncuesta ce = new cargaEncuesta(NOMBRE, DNI, NRO_SOC, NRO_DEP, NRO_SOC_ADH, NRO_DEP_ADH, BARRA);
                ce.ShowDialog();
            }

            if (themedContainer2.IsBodyVisible)
            {
                string NOMBRE = listView1.SelectedItems[0].SubItems[5].Text + ", " + listView1.SelectedItems[0].SubItems[6].Text;
                int DNI = int.Parse(listView1.SelectedItems[0].SubItems[13].Text);
                int NRO_SOC = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                int NRO_DEP = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                int NRO_SOC_ADH = int.Parse(listView1.SelectedItems[0].SubItems[3].Text.Substring(0, 5));
                int NRO_DEP_ADH = int.Parse(listView1.SelectedItems[0].SubItems[3].Text.Substring(5, 3));
                int BARRA = int.Parse(listView1.SelectedItems[0].SubItems[4].Text);

                cargaEncuesta ce = new cargaEncuesta(NOMBRE, DNI, NRO_SOC, NRO_DEP, NRO_SOC_ADH, NRO_DEP_ADH, BARRA);
                ce.ShowDialog();
            }
        }

        private void btnIngresos_Click(object sender, EventArgs e)
        {
            mainIngresos mf = new mainIngresos();
            mf.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            listadoPresentes lp = new listadoPresentes();
            lp.ShowDialog();
        }

        private void btnCalcularCuotas_Click(object sender, EventArgs e)
        {
            tarjetas tc = new tarjetas();
            tc.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cargarObservaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            observacionesInterior();
        }

        private void observacionesInterior()
        {
            if (themedContainer1.IsBodyVisible)
            {
                string NOMBRE = listView1.SelectedItems[0].SubItems[4].Text + ", " + listView1.SelectedItems[0].SubItems[5].Text;
                string DNI = listView1.SelectedItems[0].SubItems[11].Text;
                cargarObservacion co = new cargarObservacion(DNI, NOMBRE);
                co.ShowDialog();
            }

            if (themedContainer2.IsBodyVisible)
            {
                string NOMBRE = listView1.SelectedItems[0].SubItems[5].Text + ", " + listView1.SelectedItems[0].SubItems[6].Text;
                string DNI = listView1.SelectedItems[0].SubItems[13].Text;
                cargarObservacion co = new cargarObservacion(DNI, NOMBRE);
                co.ShowDialog();
            }
        }

        private void lbObsInterior_Click(object sender, EventArgs e)
        {
            observacionesInterior();
        }

        private void lbDatosBancarios_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int ID_TITULAR = 0;
                int ID_ADHERENTE = 0;
                string ID_FAMILIAR = "0";
                int NRO_SOC = 0;
                int NRO_DEP = 0;
                NRO_SOC = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                NRO_DEP = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                ID_TITULAR = (NRO_SOC * 1000) + NRO_DEP;
                string TIPO = listView1.SelectedItems[0].SubItems[2].Text;

                if (themedContainer2.IsBodyVisible)
                {
                    if (TIPO == "ADH")
                    {
                        ID_ADHERENTE = int.Parse(listView1.SelectedItems[0].SubItems[3].Text + "" + listView1.SelectedItems[0].SubItems[4].Text.PadLeft(2, '0'));
                    }
                    else if (TIPO == "INP")
                    {
                        ID_ADHERENTE = int.Parse(listView1.SelectedItems[0].SubItems[3].Text + "" + listView1.SelectedItems[0].SubItems[4].Text.PadLeft(2, '0'));
                    }
                    else if (TIPO == "FAM")
                    {
                        NRO_SOC = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                        NRO_DEP = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                        ID_FAMILIAR = ((NRO_SOC * 1000) + NRO_DEP).ToString() + "" + listView1.SelectedItems[0].SubItems[4].Text;
                    }
                }

                datosBancarios db = new datosBancarios(ID_TITULAR, ID_ADHERENTE.ToString(), ID_FAMILIAR, TIPO);
                db.ShowDialog();
            }
            else
            {
                MessageBox.Show("NO SE SELECCIONO NINGUN SOCIO", "ERROR");
            }
        }

        private void lbIngresoCampo_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                int NRO_SOC = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                int NRO_DEP = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                string DNI = listView1.SelectedItems[0].SubItems[11].Text;
                string NOMBRE = listView1.SelectedItems[0].SubItems[5].Text;
                string APELLIDO = listView1.SelectedItems[0].SubItems[4].Text;
                string BAJA = listView1.SelectedItems[0].SubItems[13].Text;
                string TIPO = listView1.SelectedItems[0].SubItems[3].Text;
                // esto es para que tome el formato de la grilla de familiares 
               if  (!themedContainer1.IsBodyVisible)
               {  TIPO = listView1.SelectedItems[0].SubItems[2].Text;
                  DNI = listView1.SelectedItems[0].SubItems[13].Text;
                  BAJA = listView1.SelectedItems[0].SubItems[14].Text;
                  NOMBRE = listView1.SelectedItems[0].SubItems[6].Text;
                  APELLIDO = listView1.SelectedItems[0].SubItems[5].Text;
               }

             
                bool Invitado = false;
                bool Inter = false;

                if (TIPO.Trim().ToUpper().Contains("FAM") || TIPO.ToUpper().Contains("ADH") || TIPO.ToUpper().Contains("TITUL") || TIPO.ToUpper().Contains("VITAL") || TIPO.ToUpper().Contains("INT") || TIPO.ToUpper().Contains("ACTIVO") || TIPO.ToUpper().Contains("METRO") || TIPO.ToUpper().Contains("INP") || TIPO.ToUpper().Contains("EMP") || TIPO.ToUpper().Contains("PART") || TIPO.ToUpper().Contains("SOCIO INVITADO"))
                    Invitado = false;
                else
                    Invitado = true;

                if (TIPO.Contains("INT") && !TIPO.Contains("ADH"))
                    Inter = true;

                if (BAJA.Length > 0)
                    Invitado = true;

                Entrada_Campo.EntradaCampoIngresoTotales ec = new Entrada_Campo.EntradaCampoIngresoTotales(DNI, NOMBRE, APELLIDO, NRO_SOC, NRO_DEP, TIPO, Invitado, Inter, false, 0,false);
                ec.ShowDialog();
            }
            else
            {

                Entrada_Campo.EntradaCampoIngresoTotales ec = new Entrada_Campo.EntradaCampoIngresoTotales("9999", VGlobales.vp_role.TrimEnd().TrimStart(), VGlobales.vp_role.TrimEnd().TrimStart(), 0, 0,"", true, false, false, 0,true);
                ec.ShowDialog();
                
                //  SOCIOS.Entrada_Campo.IngresoDatos ingreso_entrada_Campo = new Entrada_Campo.IngresoDatos(false);
              //  ingreso_entrada_Campo.ShowDialog();
            }
        }

        private void lbIngresosRecibos_Click(object sender, EventArgs e)
        {
            GrillaPreRecibo gpr = new GrillaPreRecibo();
            gpr.ShowDialog();
        }

        private void label20_Click(object sender, EventArgs e)
        {



            decimal Monto_Reintegro = 0;

             if (listView1.SelectedItems.Count == 1)
            {
                int NRO_SOC = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                int NRO_DEP = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                string DNI = listView1.SelectedItems[0].SubItems[11].Text;
                string NOMBRE = listView1.SelectedItems[0].SubItems[5].Text;
                string APELLIDO = listView1.SelectedItems[0].SubItems[4].Text;
                string BAJA = listView1.SelectedItems[0].SubItems[13].Text;
                string TIPO = listView1.SelectedItems[0].SubItems[3].Text;
                  bool Invitado = false;
                bool Inter = false;
                // esto es para que tome el formato de la grilla de familiares 
               if  (!themedContainer1.IsBodyVisible)
              
               {  TIPO = listView1.SelectedItems[0].SubItems[2].Text;
                  DNI = listView1.SelectedItems[0].SubItems[13].Text;
                  BAJA = listView1.SelectedItems[0].SubItems[14].Text;
                  NOMBRE = listView1.SelectedItems[0].SubItems[6].Text;
                  APELLIDO = listView1.SelectedItems[0].SubItems[5].Text;

                 
               }


                 


               if (TIPO.ToUpper().Contains("FAM") || TIPO.ToUpper().Contains("ADH") || TIPO.ToUpper().Contains("INP") || TIPO.ToUpper().Contains("TIT") || TIPO.ToUpper().Contains("VITAL") || TIPO.ToUpper().Contains("INT") || TIPO.ToUpper().Contains("ACTIVO") || TIPO.ToUpper().Contains("CIUDAD"))
                    Invitado = false;
                else
                    Invitado = true;





                if (TIPO.ToUpper().Contains("INT"))
                    Inter = true;

                if (BAJA.Length > 0)
                    Invitado = true;

                if (entradaCampoService.Monto_Maximo_Reintegrar(DNI, System.DateTime.Now) == 0)
                {
                    MessageBox.Show("No existen movimientos a Reintegrar en el dia de la fecha  ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Entrada_Campo.EntradaCampoIngresoTotales ec = new Entrada_Campo.EntradaCampoIngresoTotales(DNI, NOMBRE, APELLIDO, NRO_SOC, NRO_DEP, TIPO, Invitado, Inter, true, 0,false);
                    ec.ShowDialog();
                }

            }
            else
             {
                 Monto_Reintegro = entradaCampoService.Monto_Maximo_Reintegrar("9999", System.DateTime.Now);

                 if ((Monto_Reintegro == 0))
                 {
                     throw new Exception("No existen movimientos a Reintegrar en el dia de la fecha  ");

                 }




                 Entrada_Campo.EntradaCampoIngresoTotales ec = new Entrada_Campo.EntradaCampoIngresoTotales("9999", VGlobales.vp_role.TrimEnd().TrimStart(), VGlobales.vp_role.TrimEnd().TrimStart(), 0, 0, "", true, false,true,0 , true);
                 ec.ShowDialog();
                 
            }
        }

        private void lbIngresoEvento_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                int NRO_SOC = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                int NRO_DEP = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                string DNI = listView1.SelectedItems[0].SubItems[11].Text;
                string NOMBRE = listView1.SelectedItems[0].SubItems[5].Text;
                string APELLIDO = listView1.SelectedItems[0].SubItems[4].Text;
                string BAJA = listView1.SelectedItems[0].SubItems[13].Text;
                string TIPO = listView1.SelectedItems[0].SubItems[3].Text;
                // esto es para que tome el formato de la grilla de familiares 
                if (!themedContainer1.IsBodyVisible)
                {
                    TIPO = listView1.SelectedItems[0].SubItems[2].Text;
                    DNI = listView1.SelectedItems[0].SubItems[13].Text;
                    BAJA = listView1.SelectedItems[0].SubItems[14].Text;
                    NOMBRE = listView1.SelectedItems[0].SubItems[6].Text;
                    APELLIDO = listView1.SelectedItems[0].SubItems[5].Text;
                }


         
                SOCIOS.entradaCampo.Campo.EntradaEvento ee = new entradaCampo.Campo.EntradaEvento(DNI, NOMBRE, APELLIDO, NRO_SOC, NRO_DEP, TIPO, "", false, 0,false);

              
                ee.ShowDialog();
            }
            else
            {
                SOCIOS.entradaCampo.Campo.EntradaEvento ec = new entradaCampo.Campo.EntradaEvento("9999", VGlobales.vp_role.TrimEnd().TrimStart(), VGlobales.vp_role.TrimEnd().TrimStart(),0,0,"MANUAL", "", false, 0,true);


                ec.ShowDialog();
            }


        }

        private void lbReintegroEvento_Click(object sender, EventArgs e)
        {
            try
            {   decimal Monto_Reintegro=0;

                if (listView1.SelectedItems.Count == 1)
                {
                    int NRO_SOC = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                    int NRO_DEP = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                    string DNI = listView1.SelectedItems[0].SubItems[11].Text;
                    string NOMBRE = listView1.SelectedItems[0].SubItems[5].Text;
                    string APELLIDO = listView1.SelectedItems[0].SubItems[4].Text;
                    string BAJA = listView1.SelectedItems[0].SubItems[13].Text;
                    string TIPO = listView1.SelectedItems[0].SubItems[3].Text;
                    // esto es para que tome el formato de la grilla de familiares 
                    if (!themedContainer1.IsBodyVisible)
                    {
                        TIPO = listView1.SelectedItems[0].SubItems[2].Text;
                        DNI = listView1.SelectedItems[0].SubItems[13].Text;
                        BAJA = listView1.SelectedItems[0].SubItems[14].Text;
                        NOMBRE = listView1.SelectedItems[0].SubItems[6].Text;
                        APELLIDO = listView1.SelectedItems[0].SubItems[5].Text;
                    }
                     Monto_Reintegro = entradaCampoService.Monto_Maximo_Reintegrar(DNI, System.DateTime.Now);

                    if (( Monto_Reintegro == 0) )
                    {
                        throw new Exception("No existen movimientos a Reintegrar en el dia de la fecha  ");

                    }

                    SOCIOS.entradaCampo.Campo.EntradaEvento ee = new entradaCampo.Campo.EntradaEvento(DNI, NOMBRE, APELLIDO, NRO_SOC, NRO_DEP, TIPO, "", true, Monto_Reintegro,false);


                    ee.ShowDialog();
                }
                else
                {
                    Monto_Reintegro = entradaCampoService.Monto_Maximo_Reintegrar("9999", System.DateTime.Now);
                    
                    if ((Monto_Reintegro == 0))
                    {
                        throw new Exception("No existen movimientos a Reintegrar en el dia de la fecha  ");

                    }

                    SOCIOS.entradaCampo.Campo.EntradaEvento ec = new entradaCampo.Campo.EntradaEvento("9999", VGlobales.vp_role.TrimEnd().TrimStart(), VGlobales.vp_role.TrimEnd().TrimStart(), 0, 0, "MANUAL", "", true, Monto_Reintegro,true);


                    ec.ShowDialog();
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void dEPFAACABAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (themedContainer1.IsBodyVisible)
            {
                if (listView1.SelectedItems.Count == 1)
                {
                    string NRO_DEP = listView1.SelectedItems[0].SubItems[1].Text;
                    int NRO_SOC = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                    int ID_TITULAR = int.Parse(listView1.SelectedItems[0].SubItems[8].Text);

                    if (NRO_DEP == "994")
                    {
                        restablecer994 r = new restablecer994(ID_TITULAR, int.Parse(NRO_DEP), NRO_SOC);
                        r.ShowDialog();
                        BuscarTitular();
                    }
                    else
                    {
                        MessageBox.Show("LA DEPURACIÓN DEBE SER 994", "ERROR!");
                    }
                }
                else
                {
                    MessageBox.Show("NO SE SELECCIONO NINGUN REGISTRO", "ERROR!");
                }
            }
            else
            {
                MessageBox.Show("BUSCAR UN SOCIO TITULAR", "ERROR!");
            }
        }

        private void dECABAAPFAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (themedContainer1.IsBodyVisible)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    string NRO_DEP = listView1.SelectedItems[0].SubItems[1].Text;
                    int NRO_SOC = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                    int ID_TITULAR = int.Parse(listView1.SelectedItems[0].SubItems[8].Text);

                    if (NRO_DEP == "020")
                    {
                        restablecer994 r = new restablecer994(ID_TITULAR, int.Parse(NRO_DEP), NRO_SOC);
                        r.ShowDialog();
                        BuscarTitular();
                    }
                    else
                    {
                        MessageBox.Show("LA DEPURACIÓN DEBE SER 20", "ERROR!");
                    }
                }
                else
                {
                    MessageBox.Show("NO SE SELECCIONO NINGUN REGISTRO", "ERROR!");
                }
            }
            else
            {
                MessageBox.Show("BUSCAR UN SOCIO TITULAR", "ERROR!");
            }
        }

        private string tipoSocio()
        {
            string TIPO_SOCIO = "";

            if (themedContainer1.IsBodyVisible)
            {
                TIPO_SOCIO = "TITULAR";
            }

            if (themedContainer2.IsBodyVisible)
            {
                TIPO_SOCIO = "ADHERENTE";
            }

            return TIPO_SOCIO;
        }

        private string idSocio()
        {
            string TIPO_SOCIO = tipoSocio();
            int ID_SOCIO = 0;
            string ID_SOCIO_S = "";
            int BARRA = 0;
            string BARRA_S = "";

            if (TIPO_SOCIO == "TITULAR")
            {
                ID_SOCIO_S = listView1.SelectedItems[0].SubItems[8].Text;
            }

            if (TIPO_SOCIO == "ADHERENTE")
            {
                BARRA = int.Parse(listView1.SelectedItems[0].SubItems[4].Text);
                ID_SOCIO = int.Parse(listView1.SelectedItems[0].SubItems[3].Text);

                if (BARRA < 10)
                {
                    BARRA_S = "0" + BARRA.ToString();
                }
                else
                {
                    BARRA_S = BARRA.ToString();
                }

                ID_SOCIO_S = ID_SOCIO.ToString() + BARRA_S;
            }

            return ID_SOCIO_S;
        }

        private void noAlcanzaCSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string TIPO_SOCIO = tipoSocio();
            string ID_SOCIO = idSocio();
            int DNI = 0;

            if (themedContainer1.IsBodyVisible)
                DNI = int.Parse(listView1.SelectedItems[0].SubItems[11].Text);
            else
                DNI = int.Parse(listView1.SelectedItems[0].SubItems[13].Text);
            
            registroSocios.noAlcanza na = new registroSocios.noAlcanza(TIPO_SOCIO, ID_SOCIO, DNI);
            na.ShowDialog();
            Boton_buscar();
        }

        private void tsAsignarElemento_Click(object sender, EventArgs e)
        {
            string TIPO_SOCIO = tipoSocio();
            string ID_SOCIO = idSocio();
            OrientacionSocial.asignarElemento ae = new OrientacionSocial.asignarElemento(TIPO_SOCIO, ID_SOCIO);
            ae.ShowDialog();
        }

        private void tsDevolverElemento_Click(object sender, EventArgs e)
        {

        }

        private void tsListarElementos_Click(object sender, EventArgs e)
        {

        }

        private void BtnRestarCounter_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿REINICIAR EL CONTADOR DE INGRESOS?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                db db = new db();
                string QUERY = "ALTER SEQUENCE NUMERADOR_INGRESO RESTART WITH 0";
                db.Ejecuto_Consulta(QUERY);
            }
        }

        private void btnBlankTurnero_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿REINICIAR EL TURNERO?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                db db = new db();
                string QUERY = "update  ingresos_a_procesar set TILDE=null where tilde='L' ";
                db.Ejecuto_Consulta(QUERY);
            }
        }
    }
}