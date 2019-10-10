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
using SOCIOS.bono;



namespace SOCIOS
{
    public partial class Consulta : MicroFour.StrataFrame.UI.Windows.Forms.StandardForm
    {
        //private DataTable dtingresos;
        string NRO_SOC_TIT;
        string NRO_DEP_TIT;

        string ROL ;
        string TIPO;
        int NRO_SOC ;
        int NRO_DEP ;
        int BARRA ;
        int NRO_ADH ;
        int NRO_DEPADH;

        int SECACT ;
        int INGRESO ;
        int PROFESIONAL ;
        string DESTINO ;

        Decimal Importe;
        string bono;
        UtilsBono ub = new UtilsBono();

        public Consulta()
        {
            InitializeComponent();
        }

        BO_Datos dlog = new BO_Datos();
        bo BO_dlog = new bo();

        private void Consultar_Load(object sender, EventArgs e)
        {
            if (VGlobales.vp_role.Trim() != "SISTEMAS")
            {
                btnImprimir.Visible = false;
            }
            lleno_combos_Buscar();
            Consultar_Visitas(dlog);
            llenoComboRoles();
        }

        private void llenoComboRoles()
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
                    comboRoles.DisplayMember = "ROL";
                    comboRoles.ValueMember = "ROL";
                    comboRoles.DataSource = dt1;
                    comboRoles.SelectedIndex = -1;
                    transaction.Commit();
                }
            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR EL COMBO ROL");
            }
        }

        private void lleno_combos_Buscar()
        {

            string QUERY = "SELECT DISTINCT ROL FROM SECTACT WHERE ROL = '"+VGlobales.vp_role+ "' ORDER BY ROL;";

            if (VGlobales.vp_role == "INFORMES")
                QUERY = "SELECT DISTINCT ROL FROM SECTACT ORDER BY ROL;";

            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            comboBox1.DataSource = dlog.BO_EjecutoDataTable(QUERY);
            comboBox1.DisplayMember = "ROL";
            comboBox1.ValueMember = "ROL";
            comboBox1.SelectedItem = 0;
        }

        private void Consultar_Visitas(BO_Datos datos)
        {

            string sectores = "SELECT TILDE, TRIM(APELLIDO) AS APELLIDO, TRIM(NOMBRE) AS NOMBRE, TRIM(TIP_SOCIO) AS TIPO, TRIM(COD_DTO) AS COD_DTO, TRIM(ROL) AS ROL, TRIM(DESTINO) AS DESTINO, FECHA, SECUENCIA, NRO_RECIBO, IMPORTE, NRO_SOC, NRO_DEP,BARRA, ";
            
            sectores = sectores + "NRO_ADH, NRO_DEPADH, DNI,BONO_ROL,ID_DESTINO,ID_PROFESIONAL, CUIL ";
            
            sectores = sectores + " FROM INGRESOS_A_PROCESAR WHERE CAST(FECHA AS DATE) BETWEEN '" + dtpFdesde.Text + "' AND '" + dtpFhasta.Text + "'";

            if (comboBox1.SelectedIndex != -1)
            {
                sectores = sectores + " and ROL='" + comboBox1.SelectedValue.ToString().Trim() + "' ";
            }

            if (comboBox3.SelectedIndex != -1)
            {
                sectores = sectores + " and DESTINO='" + comboBox3.SelectedValue.ToString().Trim() + "' ";
            }

            sectores = sectores + " ORDER BY SECUENCIA DESC";

            dataGridView1.DataSource = datos.BO_EjecutoDataTable(sectores);

        }

        private void btnFiltros_Click(object sender, EventArgs e)
        {
            Consultar_Visitas(dlog);
            this.Consulta_Shown(dataGridView1, new EventArgs());
        }



        private void Consulta_Shown(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("NO HAY DATOS PARA LAS FECHAS SELECCIONADAS",
                               "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            //using (Rpt frmRpt = new Rpt(dtpFdesde.Text, dtpFhasta.Text))
            //{
            //     frmRpt.ShowDialog(this);
            // }
        }
        private void dtpFdesde_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFhasta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gradientFormHeader1_Load(object sender, EventArgs e)
        {

        }


        /*private void lleno_combos2()
        {

            string dato1 = "SELECT DISTINCT ROL FROM SECTACT ORDER BY ROL";

            string connectionString;
            DataSet ds1 = new DataSet();
            Datos_ini ini3 = new Datos_ini();
            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();



                cs.DataSource = ini3.Servidor; //cs.Port = int.Parse(ini3.Puerto);
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

                    //Carga COMBOBOX1

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

                    comboBox1.DisplayMember = "ROL";
                    comboBox1.ValueMember = "ROL";
                    comboBox1.DataSource = dt1;

                    comboBox1.SelectedIndex = -1;



                    transaction.Commit();


                }

            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR EL COMBO ROL");
            }

        }*/





        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string paso = comboBox1.SelectedValue.ToString().Trim();
            string dato2 = "SELECT DESTINO,ID,ID_DESTINO FROM P_TMP_CURSOR('" + paso + "')";

            string connectionString;
            DataSet ds2 = new DataSet();
            Datos_ini ini4 = new Datos_ini();
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
                    }

                    reader4.Close();


                    comboBox3.DataSource = dt2;
                    comboBox3.DisplayMember = "DESTINO";
                    comboBox3.ValueMember = "destino";
                    comboBox3.SelectedIndex = -1;

                    transaction.Commit();
                }
            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR EL COMBO DETALLE");
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            dtpFdesde.Value = DateTime.Today;
            dtpFhasta.Value = DateTime.Today;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            VGlobales.vp_idTipo = Convert.ToString(this.dataGridView1.CurrentRow.Cells[3].Value);


            if (VGlobales.vp_idTipo == "TIT")
            {
                VGlobales.vp_idBusco = Convert.ToString(this.dataGridView1.CurrentRow.Cells[11].Value) +
                    Convert.ToString(this.dataGridView1.CurrentRow.Cells[12].Value);
            }

            if (VGlobales.vp_idTipo == "FAM")
            {
                VGlobales.vp_idBusco = Convert.ToString(this.dataGridView1.CurrentRow.Cells[11].Value) +
                    Convert.ToString(this.dataGridView1.CurrentRow.Cells[12].Value);
            }

            if (VGlobales.vp_idTipo == "ADH")
            {
                VGlobales.vp_idBusco = Convert.ToString(this.dataGridView1.CurrentRow.Cells[13].Value) +
                    Convert.ToString(this.dataGridView1.CurrentRow.Cells[14].Value);
            }

            if (VGlobales.vp_idTipo == "VIS")
            {
                VGlobales.vp_idBusco = Convert.ToString(this.dataGridView1.CurrentRow.Cells[15].Value);
            }


            frmMemo pant1 = new frmMemo();
            pant1.ShowDialog();

        }


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            string dato2;

            if (dataGridView1.CurrentRow.Cells[0].Value == "S")
            {
                dataGridView1.CurrentRow.Cells[0].Value = "N";
                dato2 = "UPDATE INGRESOS_A_PROCESAR SET TILDE='N' WHERE SECUENCIA=";
            }
            else
            {
                dataGridView1.CurrentRow.Cells[0].Value = "S";
                dato2 = "UPDATE INGRESOS_A_PROCESAR SET TILDE='S' WHERE SECUENCIA=";
            }


            dato2 = dato2 + dataGridView1.CurrentRow.Cells[8].Value;


            string connectionString;
            DataSet ds2 = new DataSet();
            Datos_ini ini4 = new Datos_ini();
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

                    cmd2.ExecuteReader();

                    transaction.Commit();

                }

            }
            catch
            {
                MessageBox.Show("ERROR AL MODIFICAR EL ESTADO");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consultar_Visitas(dlog);
            this.Consulta_Shown(dataGridView1, new EventArgs());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


       

            ROL = dataGridView1.SelectedRows[0].Cells[5].Value.ToString().Trim();
            TIPO = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
            NRO_SOC    = Int32.Parse(dataGridView1.SelectedRows[0].Cells[11].Value.ToString());
            NRO_DEP = Int32.Parse(dataGridView1.SelectedRows[0].Cells[12].Value.ToString());
            BARRA = Int32.Parse(dataGridView1.SelectedRows[0].Cells[13].Value.ToString());
            NRO_ADH = Int32.Parse(dataGridView1.SelectedRows[0].Cells[14].Value.ToString());
            NRO_DEPADH = Int32.Parse(dataGridView1.SelectedRows[0].Cells[15].Value.ToString());

            SECACT = Int32.Parse(dataGridView1.SelectedRows[0].Cells[18].Value.ToString());
            INGRESO = Int32.Parse(dataGridView1.SelectedRows[0].Cells[8].Value.ToString());
            PROFESIONAL = Int32.Parse(dataGridView1.SelectedRows[0].Cells[19].Value.ToString());
            DESTINO     = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            bono        = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();


            if (TIPO.Contains("ADH") || TIPO.Contains("INP"))
            {
                NRO_SOC_TIT = NRO_ADH.ToString();
                NRO_DEP_TIT = NRO_DEPADH.ToString();

            }
            else
            {
                NRO_SOC_TIT = NRO_SOC.ToString();
                NRO_DEP_TIT = NRO_DEP.ToString();

            }

            if (ROL.Contains("MEDICOS") && ub.Actividad_Odontologica(SECACT))
            {
                btnBono.Visible = true;

            }
            else
                btnBono.Visible = false;


            
        }

        private void btnBono_Click(object sender, EventArgs e)
        {



            if (bono.Trim().Length == 0)
            {
                bono.BonoOdontologico admBonoOdonto = new bono.BonoOdontologico(NRO_SOC_TIT.ToString(), NRO_DEP_TIT.ToString(), BARRA.ToString(), NRO_SOC.ToString(), NRO_DEP.ToString(), SECACT, INGRESO, false,"INGRESO");

                admBonoOdonto.idProfesional = PROFESIONAL;
                admBonoOdonto.nombreProfesional = DESTINO;
                admBonoOdonto.ShowDialog();
                admBonoOdonto.Focus();
            }
            else

            {


                SOCIOS.bono.Odontologico odonto = new bono.Odontologico(Int32.Parse(bono), false);
            
            }
        }

        public bool cambiarEstado(string ESTADO, int SECUENCIA, string PUESTO_ATENCION)
        {
            try
            {
                db db = new db();
                string QUERY = "UPDATE INGRESOS_A_PROCESAR SET TILDE = '" + ESTADO + "', PUESTO_ATENCION = '" + PUESTO_ATENCION + "' WHERE SECUENCIA = " + SECUENCIA + ";";  
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        private void btnLlamar_Click(object sender, EventArgs e)
        {
            int SECUENCIA = 0;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SECUENCIA = Convert.ToInt32(row.Cells[8].Value);
            }

            bool ce = cambiarEstado("L", SECUENCIA, VGlobales.PUESTO_ATENCION);

            if (ce == true)
            {
                Consultar_Visitas(dlog);
                this.Consulta_Shown(dataGridView1, new EventArgs());
            }
        }

        private void btnEnEspera_Click(object sender, EventArgs e)
        {
            int SECUENCIA = 0;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SECUENCIA = Convert.ToInt32(row.Cells[8].Value);
            }

            bool ce = cambiarEstado("E", SECUENCIA, VGlobales.PUESTO_ATENCION);

            if (ce == true)
            {
                Consultar_Visitas(dlog);
                this.Consulta_Shown(dataGridView1, new EventArgs());
            }
        }

        private void btnAtendido_Click(object sender, EventArgs e)
        {
            int SECUENCIA = 0;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SECUENCIA = Convert.ToInt32(row.Cells[8].Value);
            }

            bool ce = cambiarEstado("A", SECUENCIA, VGlobales.PUESTO_ATENCION);

            if (ce == true)
            {
                Consultar_Visitas(dlog);
                this.Consulta_Shown(dataGridView1, new EventArgs());
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void ComboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambio_combo_rol();
        }

        private void cambio_combo_rol()
        {
            if (comboRoles.SelectedValue != null)
            {
                string paso = comboRoles.SelectedValue.ToString().Trim();
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
                        }

                        reader4.Close();
                        comboDestinos.DataSource = dt2;
                        comboDestinos.DisplayMember = "DESTINO";
                        comboDestinos.ValueMember = "ID";
                        comboDestinos.SelectedIndex = -1;
                        transaction.Commit();
                    }
                }
                catch (Exception){}
            }
        }

        private void BtnIngreso_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            darIngreso();
            Cursor = Cursors.Default;
        }

        public void darIngreso()
        {
            if (comboRoles.SelectedIndex == -1 || comboDestinos.SelectedIndex == -1)
            {
                MessageBox.Show("SELECCIONAR ROL Y DESTINO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("SELECCIONAR UN RESULTADO DE LA GRILLA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("SELECCIONAR SOLAMENTE UN RESULTADO DE LA GRILLA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                getGrupo gg = new getGrupo();
                string vId = comboDestinos.SelectedValue.ToString();
                string vRol = comboRoles.SelectedValue.ToString();
                string vDestino = comboDestinos.Text;
                string vIdDestino = "";
                string[] words = comboDestinos.Text.Split('-');

                foreach (string word in words)
                {
                    vIdDestino = word;
                }

                foreach (DataGridViewRow ROW in dataGridView1.SelectedRows)
                {
                    string TIPO_SOCIO = ROW.Cells[3].Value.ToString();
                    string APELLIDO = ROW.Cells[1].Value.ToString();
                    string NOMBRE = ROW.Cells[2].Value.ToString();
                    string ROL = vRol.TrimEnd();
                    string DESTINO = vDestino.TrimEnd();
                    string ID_DESTINO = vIdDestino.TrimEnd();
                    string NRO_SOC = ROW.Cells[11].Value.ToString();
                    string NRO_DEP = ROW.Cells[12].Value.ToString();
                    string BARRA = ROW.Cells[13].Value.ToString();
                    string NRO_ADH = ROW.Cells[14].Value.ToString();
                    string NRO_DEPADH = ROW.Cells[15].Value.ToString();
                    string DNI = ROW.Cells[16].Value.ToString();
                    string CUIL = ROW.Cells[20].Value.ToString();
                    string ID_PROF = vId;
                    string USUARIO = VGlobales.vp_username;
                    string COD_DTO = ROW.Cells[4].Value.ToString();
                    int GRUPO = gg.get(COD_DTO, TIPO_SOCIO);
                    string FECHA_INGRESO = DateTime.Now.ToString();
                    string BAJA = String.Empty;
                    string MC = String.Empty;
                    string MD = String.Empty;
                    decimal IMPORTE = 0;
                    int NRO_PAGO = 0;

                    if(NRO_ADH != "0")
                    {
                        NRO_SOC = NRO_ADH;
                    }

                    if (NRO_DEPADH != "0")
                    {
                        NRO_DEP = NRO_DEPADH;
                    }

                    try
                    {
                        BO_dlog.Inserto_Ingreso(APELLIDO, NOMBRE, TIPO_SOCIO, ROL, DESTINO, ID_DESTINO, NRO_SOC, NRO_DEP, "0", "0", "0", DNI, COD_DTO, ID_PROF, null, USUARIO, GRUPO, IMPORTE, NRO_PAGO, FECHA_INGRESO, MC, CUIL);
                        MessageBox.Show("INGRESO GUARDADO", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Consultar_Visitas(dlog);
                        this.Consulta_Shown(dataGridView1, new EventArgs());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("NO SE PUDO GUARDAR EL INGRESO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
 