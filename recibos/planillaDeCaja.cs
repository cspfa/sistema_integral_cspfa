using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Drawing.Imaging;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Excel = Microsoft.Office.Interop.Excel;

namespace SOCIOS
{
    public partial class planillaDeCaja : Form
    {
        bo dlog = new bo();
        BO.bo_Caja BO_CAJA = new BO.bo_Caja();
        numeroRecibo nr = new numeroRecibo();
        string Modo_Facturacion_Produccion = VGlobales.MODO_FACTURACION;
        private decimal INGRESOS_EFECTIVO { get; set; }
        private decimal INGRESOS_OTROS { get; set; }
        private decimal EGRESOS { get; set; }
        private decimal CAJAS_ANTERIORES { get; set; }
        private int CAJA { get; set; }
        private int INDEX { get; set; }
        private string FECHA { get; set; }

        public planillaDeCaja()
        {
            InitializeComponent();
        }

        private void planillaDeCaja_Load(object sender, EventArgs e)
        {
            groupBoxAl.Text = "AL " + DateTime.Today.ToShortDateString();
            cargaInicial(0);
        }

        private void comboRoles(ComboBox CB)
        {
            string query = "SELECT DISTINCT TRIM(ROL) AS ROL FROM SECTACT ORDER BY ROL;";
            CB.DataSource = null;
            CB.Items.Clear();
            CB.DataSource = dlog.BO_EjecutoDataTable(query);
            CB.DisplayMember = "ROL";
            CB.ValueMember = "ROL";
            CB.SelectedItem = 0;
        }

        private void comboProfesionales(ComboBox COMBO, int SECTACT, ComboBox CB_DESTINOS)
        {
            if (CB_DESTINOS.SelectedValue != null)
            {
                string query = "SELECT P.ID, P.NOMBRE, P.BONO_RECIBO, P.CUENTA FROM PROFESIONALES P, PROF_ESP E, SECTACT S WHERE P.ID=E.PROFESIONAL AND E.ESPECIALIDAD=S.ID AND S.ID=" + SECTACT + ";";
                //Clipboard.SetData(DataFormats.Text, (Object)query);
                string connectionString;
                DataSet ds2 = new DataSet();
                Datos_ini ini4 = new Datos_ini();

                try
                {
                    FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                    cs.DataSource = ini4.Servidor;
                    cs.Port = int.Parse(ini4.Puerto);
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
                        DataTable dt2 = new DataTable("PROFESIONALES");
                        dt2.Columns.Add("ID", typeof(string));
                        dt2.Columns.Add("NOMBRE", typeof(string));
                        dt2.Columns.Add("BONO_RECIBO", typeof(string));
                        dt2.Columns.Add("CUENTA", typeof(string));
                        ds2.Tables.Add(dt2);
                        FbCommand cmd2 = new FbCommand(query, connection, transaction);
                        FbDataReader reader4 = cmd2.ExecuteReader();
                        DataRow fila;

                        while (reader4.Read())
                        {
                            fila = dt2.NewRow();
                            fila["ID"] = reader4.GetString(reader4.GetOrdinal("ID")).Trim();
                            fila["NOMBRE"] = reader4.GetString(reader4.GetOrdinal("NOMBRE")).Trim() + "-" + reader4.GetString(reader4.GetOrdinal("BONO_RECIBO")).Trim() + "-" + reader4.GetString(reader4.GetOrdinal("CUENTA")).Trim();
                            dt2.Rows.Add(fila);
                        }

                        reader4.Close();
                        COMBO.DataSource = dt2;
                        COMBO.DisplayMember = "NOMBRE";
                        COMBO.ValueMember = "ID";
                        COMBO.SelectedIndex = 0;
                        transaction.Commit();
                    }
                }
                catch (Exception e)
                {
                    //MessageBox.Show("ERROR AL CARGAR EL COMBO DETALLE\n"+e);
                }
            }
        }

        private void cambioComboRoles(ComboBox COMBO, ComboBox CB_ROLES)
        {
            if (CB_ROLES.SelectedValue != null)
            {
                string paso = CB_ROLES.SelectedValue.ToString().Trim();
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
                        COMBO.DataSource = dt2;
                        COMBO.DisplayMember = "DESTINO";
                        COMBO.ValueMember = "ID";
                        COMBO.SelectedIndex = 0;
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

        private void habilitarEdicion()
        {
            tbNuevoImporteEfectivo.Text = "";
            tbNuevoImporteOtros.Text = "";

            if (VGlobales.vp_username == "SVALLEJOS" || VGlobales.vp_username == "PDEREYES" || VGlobales.vp_username == "AHERNANDEZ" || VGlobales.vp_username == "SBARBEITO" || VGlobales.vp_username == "KMARTIN" || VGlobales.vp_username == "MORELLANO")
            {
                cbNuevoPagoEfectivo.Enabled = true;
                cbNuevoPagoOtros.Enabled = true;
                cbFormaPagoBuscador.Enabled = true;
                btnFormaPagoBuscador.Enabled = true;
                btnNuevoPagoEfectivo.Enabled = true;
                btnNuevoPagoOtros.Enabled = true;
                tbNuevoImporteEfectivo.Enabled = true;
                tbNuevoImporteOtros.Enabled = true;
                tbImporteBuscador.Enabled = true;
                btnNuevoImporteEfectivo.Enabled = true;
                btnNuevoImporteOtros.Enabled = true;
                btnFormaPagoBuscador.Enabled = true;
                btnImporteBuscador.Enabled = true;
                cbRolesEfectivo.Enabled = true;
                cbDestinosEfectivo.Enabled = true;
                btnModRoleDestEfectivo.Enabled = true;
                cbProfEfectivo.Enabled = true;
                cbRolesOtros.Enabled = true;
                cbProfOtros.Enabled = true;
                cbDestinosOtros.Enabled = true;
                btnModRoleDestOtros.Enabled = true;
                cbProfBuscador.Enabled = true;
                cbRoleBuscador.Enabled = true;
                cbDestinoBuscador.Enabled = true;
                btnModRoleDestBuscador.Enabled = true;
                cbProfBuscador.Enabled = true;
            }
        }

        private void comboComprobantes()
        {
            cbTipos.Items.Add("BONOS");
            cbTipos.Items.Add("RECIBOS");
            cbTipos.Items.Add("REINTEGROS");
            cbTipos.SelectedIndex = 0;
        }

        private void pintarSinFacturar(DataGridView GRID)
        {
            int X = 0;
            string NE = "";

            foreach (DataGridViewRow row in GRID.Rows)
            {
                NE = row.Cells[11].Value.ToString();

                if (NE == "")
                {
                    GRID.Rows[X].DefaultCellStyle.BackColor = Color.Orange;
                }
                X++;
            }
        }

        private void cargaInicial(int CAJA)
        {
            Cursor = Cursors.WaitCursor;
            INGRESOS_EFECTIVO = 0;
            INGRESOS_OTROS = 0;
            EGRESOS = 0;
            decimal CAJAS_ANTERIORES = 0;
            decimal SALDO_ANTERIOR = 0;

            dgTotalesDelDia.Rows.Clear();
            dgTotalesDelDia.ColumnCount = 2;
            dgTotalesDelDia.Columns[0].Name = "DETALLE";
            dgTotalesDelDia.Columns[1].Name = "TOTALES";
            dgTotalesDelDia.Columns[0].Width = 500;
            dgTotalesDelDia.Columns[1].Width = 110;
            dgTotalesDelDia.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgComposicion.Rows.Clear();
            dgComposicion.ColumnCount = 3;
            dgComposicion.Columns[0].Name = "ID";
            dgComposicion.Columns[1].Name = "DETALLE";
            dgComposicion.Columns[2].Name = "TOTALES";
            dgComposicion.Columns[0].Width = 50;
            dgComposicion.Columns[0].Width = 0;
            dgComposicion.Columns[1].Width = 500;
            dgComposicion.Columns[2].Width = 110;
            dgComposicion.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            habilitarEdicion();
            comboRoles(cbRolesEfectivo);
            comboRoles(cbRolesOtros);
            comboRoles(cbRoleBuscador); //MODIFICAR ROLE
            comboRoles(cbRolesBuscador); //BUSCAR POR ROLE
            comboBancos(cbBancos);
            comboBancos(cbBancosCheques);
            comboFormasDePago(cbNuevoPagoEfectivo);
            comboFormasDePago(cbNuevoPagoOtros);
            comboFormasDePago(cbFormaPagoBuscador);
            comboFormasDePago(cbPagoFiltro);

            buscarCajas(1, dgCajasDepositadas);
            buscar("E", dgEgresos, CAJA);
            buscar("1", dgEfectivo, CAJA);
            pintarSinFacturar(dgEfectivo);
            buscarCajas(0, dgCajasAnteriores);
            pintarCajas();
            tbTotal.Text = INGRESOS_EFECTIVO.ToString();
            tbCambio.Text = obtenerCambio().ToString();
            agregarCambio();

            buscar("0", dgOtros, CAJA);
            pintarSinFacturar(dgOtros);
            buscar("2", dgCheques, CAJA);

            totalEgresos();

            if(VGlobales.vp_role == "CAJA")
                dgTotalesDelDia.Rows.Add("SUBTOTAL INGRESOS DEL DIA", string.Format("{0:n}", INGRESOS_EFECTIVO + INGRESOS_OTROS));

            if (VGlobales.vp_role == "CPOCABA")
                dgTotalesDelDia.Rows.Add("SUBTOTAL INGRESOS DEL DIA", string.Format("{0:n}", INGRESOS_EFECTIVO));

            chequesEnTotal();
            CAJAS_ANTERIORES = cajasAnteriores();
            SALDO_ANTERIOR = CAJAS_ANTERIORES;

            if (VGlobales.vp_role == "CAJA")
                dgTotalesDelDia.Rows.Add("TOTAL DEL DÍA", string.Format("{0:n}", (INGRESOS_EFECTIVO + INGRESOS_OTROS)));

            if (VGlobales.vp_role == "CPOCABA")
                dgTotalesDelDia.Rows.Add("TOTAL DEL DÍA", string.Format("{0:n}", (INGRESOS_EFECTIVO)));

            dgTotalesDelDia.Rows.Add("SALDO DEL DÍA ANTERIOR", string.Format("{0:n}", (SALDO_ANTERIOR)));

            if (VGlobales.vp_role == "CAJA")
            {
                if (dgCajasAnteriores.Rows.Count == 1)
                    dgTotalesDelDia.Rows.Add("SALDO DE LA FECHA", string.Format("{0:n}", "0,00"));
                else
                    dgTotalesDelDia.Rows.Add("SALDO DE LA FECHA", string.Format("{0:n}", (SALDO_ANTERIOR + INGRESOS_EFECTIVO + INGRESOS_OTROS - EGRESOS)));
            }

            cajaDeHoyEnComposicion();

            if (CAJA > 0)
            {
                cajasEnComposicion(CAJA);
                DataSet CAJAS_DEPOSITADAS = buscarCajasDepositadas(CAJA);
                dgCajasDepositadas.DataSource = CAJAS_DEPOSITADAS.Tables[0];
            }

            if (CAJA == 0)
                agregarCajas();

            dgCajasAnteriores.ClearSelection();
            dgComposicion.ClearSelection();
            dgTotalesDelDia.ClearSelection();
            dgTotalesDelDia.Enabled = false;

            if (VGlobales.vp_role != "CAJA")
            {
                //tabPage3.Dispose();
                //btnExcelCaja.Enabled = false;
                //btnMostrarCaja.Enabled = false;
                gbDepositoCajas.Enabled = false;
            }

            if (VGlobales.vp_role == "CPOCABA" || VGlobales.vp_role == "CPOPOLVORINES")
            {
                btnDepoCajaCampo.Enabled = true;
            }

            comboComprobantes();
            Cursor = Cursors.Default;
        }

        private void cajasEnComposicion(int CAJA)
        {
            string QUERY = "SELECT C.ID, C.FECHA, C.INGRESOS_EFECTIVO FROM CAJA_DIARIA C, CAJAS_ANTERIORES A WHERE A.CAJA_DIARIA = " + CAJA + " AND C.ID = A.CAJA_ANTERIOR ORDER BY C.ID DESC";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            int ID = 0;
            string FECHA = string.Empty;
            decimal IMPORTE = 0;
            string IMPORTE_S = string.Empty;

            if (foundRows.Length > 0)
            {
                foreach (DataRow ROW in foundRows)
                {
                    ID = int.Parse(ROW[0].ToString());
                    FECHA = ROW[1].ToString();
                    IMPORTE = decimal.Parse(ROW[2].ToString());
                    IMPORTE_S = string.Format("{0:n}", IMPORTE);
                    dgComposicion.Rows.Add(ID, "CAJA DEL DIA " + FECHA, IMPORTE_S);
                }
            }
        }

        private void comboBancos(ComboBox CB)
        {
            string query = "SELECT ID, TRIM('BANCO '||NOMBRE) AS NOMBRE FROM BANCOS WHERE FE_BAJA IS NULL ORDER BY NOMBRE;";
            CB.DataSource = null;
            CB.Items.Clear();
            CB.DataSource = dlog.BO_EjecutoDataTable(query);
            CB.DisplayMember = "NOMBRE";
            CB.ValueMember = "ID";
            CB.SelectedItem = 0;
        }

        private void comboFormasDePago(ComboBox CB)
        {
            string query = "SELECT ID, DETALLE FROM FORMAS_DE_PAGO WHERE ID <> 10 ORDER BY ID;";

            if(CB == cbPagoFiltro)
                query = "SELECT ID, DETALLE FROM FORMAS_DE_PAGO ORDER BY ID;";

            CB.DataSource = null;
            CB.Items.Clear();
            CB.DataSource = dlog.BO_EjecutoDataTable(query);
            CB.DisplayMember = "DETALLE";
            CB.ValueMember = "ID";
            CB.SelectedItem = 0;
        }

        private decimal saldoAnterior()
        {
            decimal TOTAL = 0;
            int ID = 0;
            int X = 0;

            foreach (DataGridViewRow row in dgCajasAnteriores.Rows)
            {
                if (X == 1)
                {
                    ID = int.Parse(row.Cells[0].Value.ToString());
                }

                X++;
            }

            string query = "SELECT TOTAL FROM CAJA_DIARIA WHERE ID = " + ID + ";";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();
            TOTAL = Convert.ToDecimal(foundRows[0][0].ToString());
            return TOTAL;
        }

        private decimal cajasAnteriores()
        {
            decimal TOTAL = 0;
            decimal CAJA = 0;
            string DEPOSITADA = "";

            foreach (DataGridViewRow row in dgCajasAnteriores.Rows)
            {
                DEPOSITADA = row.Cells[10].Value.ToString();

                if (DEPOSITADA == "0")
                {
                    CAJA = decimal.Parse(row.Cells[9].Value.ToString());
                    TOTAL = TOTAL + CAJA;
                }
            }

            return TOTAL;
        }

        private void cajaDeHoyEnComposicion()
        {
            decimal EFECTIVO = decimal.Parse(INGRESOS_EFECTIVO.ToString());
            decimal CHEQUES = 0;
            decimal IMPORTE = 0;
            decimal TOTAL = 0;
            string HOY = DateTime.Today.ToShortDateString();
            string TITULO = "CAJA DEL DIA DE HOY";

            foreach (DataGridViewRow row in dgOtros.Rows)
            {
                if (row.Cells[8].Value.ToString() == "2")
                {
                    IMPORTE = decimal.Parse(row.Cells[4].Value.ToString());
                    CHEQUES = CHEQUES + IMPORTE;
                }
            }

            TOTAL = EFECTIVO + CHEQUES;
            string TOTAL_S = string.Format("{0:n}", TOTAL);
            dgComposicion.Rows.Add(0, TITULO, TOTAL_S);
        }

        private decimal obtenerCambio()
        {
            decimal CAMBIO = 0;
            string query = "SELECT VALOR FROM CONFIG WHERE PARAM = 'CAMBIO' AND ROL = '" + VGlobales.vp_role + "';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();
            CAMBIO = Convert.ToDecimal(foundRows[0][0].ToString());
            return CAMBIO;
        }

        static void OpenAdobeAcrobat(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\Program Files (x86)\Adobe\Acrobat Reader DC\Reader\AcroRd32.exe";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }

        private void totalEgresos()
        {
            decimal CAJA = 0;
            decimal TOTAL = 0;

            foreach (DataGridViewRow row in dgEgresos.Rows)
            {
                CAJA = decimal.Parse(row.Cells[4].Value.ToString());
                TOTAL = TOTAL + CAJA;
            }

            if(VGlobales.vp_role == "CAJA")
                dgTotalesDelDia.Rows.Add("EGRESOS", string.Format("{0:n}", EGRESOS));   

            if(VGlobales.vp_role == "CPOCABA")
                dgTotalesDelDia.Rows.Add("EGRESOS", string.Format("{0:n}", TOTAL));
        }

        private void updateEgresos()
        {
            dgTotalesDelDia.Rows[3].SetValues("EGRESOS", string.Format("{0:n}", EGRESOS));
        }

        private void chequesEnTotal()
        {
            foreach (DataGridViewRow row in dgComposicion.Rows)
            {
                if (row.Cells[1].Value.ToString().Contains("CHEQUE"))
                {
                    tbTotal.Text = (decimal.Parse(tbTotal.Text) + decimal.Parse(row.Cells[2].Value.ToString())).ToString();
                }
            }
        }

        private decimal sumarReintegros()
        {
            decimal TOTAL = 0;

            foreach (DataGridViewRow row in dgEgresos.Rows)
            {
                if (row.Cells[5].Value.ToString().Contains("REINTEGRO"))
                {
                    TOTAL = TOTAL + decimal.Parse(row.Cells[4].Value.ToString());
                }
            }

            return TOTAL;
        }

        private void buscar(string PAGO, DataGridView GRID, int CAJA)
        {
            try
            {
                DataSet ds1 = new DataSet();
                string query = "";

                if (VGlobales.vp_role == "CAJA")
                    query = "SELECT * FROM PLANILLA_CAJA ('" + PAGO + "', " + CAJA + ", '" + VGlobales.vp_role + "') WHERE DESTINO IS NULL OR (DESTINO <> 10 AND DESTINO <> 4 AND DESTINO <> 1  AND DESTINO <> 2  AND DESTINO <> 3 AND DESTINO <> 16);";
                else
                    query = "SELECT * FROM PLANILLA_CAJA ('" + PAGO + "', " + CAJA + ", '" + VGlobales.vp_role + "');";

                conString cs = new conString();
                string connectionString = cs.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataTable dt1 = new DataTable("RESULTADOS");
                    dt1.Columns.Add("#", typeof(string));
                    dt1.Columns.Add("DETALLE", typeof(string));
                    dt1.Columns.Add("CONCEPTO", typeof(string));
                    dt1.Columns.Add("IMP", typeof(int));
                    dt1.Columns.Add("IMPORTE", typeof(string));
                    dt1.Columns.Add("OBSERVACIONES", typeof(string));
                    dt1.Columns.Add("FECHA", typeof(string));
                    dt1.Columns.Add("ANULADO", typeof(string));
                    dt1.Columns.Add("F_PAGO", typeof(string));
                    dt1.Columns.Add("ID", typeof(string));
                    dt1.Columns.Add("PV", typeof(string));
                    dt1.Columns.Add("NE", typeof(string));
                    dt1.Columns.Add("DNI", typeof(string));
                    ds1.Tables.Add(dt1);
                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    FbDataReader reader = cmd.ExecuteReader();
                    string NRO_COMP = string.Empty;
                    string DETALLE = string.Empty;
                    string CONCEPTO = string.Empty;
                    string IMPUTACION = string.Empty;
                    decimal IMPORTE;
                    string OBSERVACIONES = string.Empty;
                    string FECHA = string.Empty;
                    string VALOR;
                    decimal TOTAL = 0;
                    string TIPO = string.Empty;
                    string ANULADO = string.Empty;
                    string F_PAGO = string.Empty;
                    decimal CAJAS_DEPOSITADAS = 0;
                    string ID_COMP = string.Empty;
                    string PTO_VTA = string.Empty;
                    string NUMERO_E = string.Empty;
                    string DNI = string.Empty;

                    while (reader.Read())
                    {
                        TIPO = reader.GetString(reader.GetOrdinal("TIPO"));
                        NRO_COMP = reader.GetString(reader.GetOrdinal("NRO_COMP")).Trim();

                        if (TIPO == "B")
                            NRO_COMP = "B" + NRO_COMP;
                        else
                            NRO_COMP = "R" + NRO_COMP;

                        DETALLE = reader.GetString(reader.GetOrdinal("DETALLE")).Trim();
                        CONCEPTO = reader.GetString(reader.GetOrdinal("CONCEPTO")).Trim();
                        IMPUTACION = reader.GetString(reader.GetOrdinal("IMPUTACION"));
                        IMPORTE = reader.GetDecimal(reader.GetOrdinal("IMPORTE"));
                        VALOR = string.Format("{0:n}", IMPORTE);
                        OBSERVACIONES = reader.GetString(reader.GetOrdinal("OBSERVACIONES")).Trim();
                        FECHA = reader.GetString(reader.GetOrdinal("FECHA_RECIBO")).Trim().Replace(" 0:00:00", "");
                        TOTAL = TOTAL + IMPORTE;
                        ANULADO = reader.GetString(reader.GetOrdinal("ANULADO")).Trim().Replace(" 0:00:00", "");
                        F_PAGO = reader.GetString(reader.GetOrdinal("F_PAGO")).Trim();
                        ID_COMP = reader.GetString(reader.GetOrdinal("ID_COMP"));
                        PTO_VTA = reader.GetString(reader.GetOrdinal("PTO_VTA"));
                        NUMERO_E = reader.GetString(reader.GetOrdinal("NUMERO_E"));
                        DNI = reader.GetString(reader.GetOrdinal("DNI")).Trim();
                        dt1.Rows.Add(NRO_COMP, DETALLE, CONCEPTO, IMPUTACION, VALOR, OBSERVACIONES, FECHA, ANULADO, F_PAGO, ID_COMP, PTO_VTA, NUMERO_E, DNI);

                        if (PAGO == "2")
                        {
                            dgComposicion.Rows.Add(NRO_COMP.Replace("R", ""), "CHEQUE " + CONCEPTO + " " + FECHA, string.Format("{0:n}", (IMPORTE)));
                        }
                    }

                    reader.Close();
                    GRID.DataSource = dt1;
                    GRID.Columns[0].Width = 60;
                    GRID.Columns[1].Width = 170;
                    GRID.Columns[2].Width = 170;
                    GRID.Columns[3].Width = 50;
                    GRID.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GRID.Columns[4].Width = 80;
                    GRID.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GRID.Columns[5].Width = 195;
                    GRID.Columns[6].Visible = true;
                    GRID.Columns[6].Width = 70;
                    GRID.Columns[7].Width = 70;
                    GRID.Columns[8].Width = 110;
                    GRID.Columns[9].Width = 50;
                    GRID.Columns[10].Width = 40;
                    GRID.Columns[11].Width = 40;
                    transaction.Commit();

                    if (PAGO == "1") //EFECTIVO
                    {
                        decimal REINTEGROS = sumarReintegros();
                        dgTotalesDelDia.Rows.Add("INGRESOS EFECTIVO", string.Format("{0:n}", TOTAL - REINTEGROS));
                        INGRESOS_EFECTIVO = TOTAL;
                    }
                    else if (PAGO != "1" && GRID.Name.ToString() == "dgOtros")
                    {
                        dgTotalesDelDia.Rows.Add("INGRESOS CHEQUES Y OTROS", string.Format("{0:n}", TOTAL));
                        INGRESOS_OTROS = TOTAL;
                    }
                    else if (PAGO != "1" && PAGO != "2" && GRID.Name.ToString() == "dgEgresos")
                    {
                        CAJAS_DEPOSITADAS = totalCajasDepositadas();
                        EGRESOS = TOTAL + CAJAS_DEPOSITADAS;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private decimal totalCajasDepositadas()
        {
            decimal TOTAL = 0;
            decimal EFECTIVO = 0;

            foreach (DataGridViewRow row in dgCajasDepositadas.Rows)
            {
                EFECTIVO = decimal.Parse(row.Cells[4].Value.ToString());
                TOTAL = TOTAL + EFECTIVO;
            }

            return TOTAL;
        }

        private bool validarCajaCerrada()
        {
            bool CAJA = false;
            string DIA = DateTime.Today.Day.ToString();
            string MES = DateTime.Today.Month.ToString();
            string ANO = DateTime.Today.Year.ToString();
            string FECHA = MES + "/" + DIA + "/" + ANO;

            string query = "SELECT FECHA FROM CAJA_DIARIA WHERE FECHA = '" + FECHA + "' AND ROL = '" + VGlobales.vp_role + "';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                CAJA = true;
            }

            return CAJA;
        }

        private void cerrar()
        {
            Cursor = Cursors.WaitCursor;
            DateTime Hoy = DateTime.Today;
            maxid MAX_ID = new maxid();
            string FECHA = Hoy.ToString("dd/MM/yyyy");
            decimal INGRESOS_EFECTIVO = Convert.ToDecimal(dgTotalesDelDia.Rows[0].Cells[1].Value.ToString());
            decimal INGRESOS_OTROS = Convert.ToDecimal(dgTotalesDelDia.Rows[1].Cells[1].Value.ToString());
            decimal EGRESOS = Convert.ToDecimal(dgTotalesDelDia.Rows[2].Cells[1].Value.ToString());
            decimal SUBTOTAL_INGRESOS = Convert.ToDecimal(dgTotalesDelDia.Rows[3].Cells[1].Value.ToString());
            decimal SALDO_CAJA = Convert.ToDecimal(dgTotalesDelDia.Rows[4].Cells[1].Value.ToString());
            decimal TOTAL = Convert.ToDecimal(tbTotal.Text);
            string ROL = VGlobales.vp_role;
            int ID_ROL = int.Parse(MAX_ID.role("ID_ROL", "CAJA_DIARIA", "ROL", VGlobales.vp_role)) + 1;
            pbProcesando.Visible = true;
            pbProcesando.Minimum = 0;
            pbProcesando.Step = 1;
            pbProcesando.Maximum = dgComposicion.Rows.Count;
            pbProcesando.Value = 0;

            try
            {
                BO_CAJA.cerrarCajaDiaria(FECHA, INGRESOS_EFECTIVO, INGRESOS_OTROS, SUBTOTAL_INGRESOS, EGRESOS, SALDO_CAJA, ROL, TOTAL, ID_ROL.ToString());
            }
            catch (Exception error)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("NO SE PUDO GUARDAR LA CAJA DIARIA\n " + error);
            }

            maxid mid = new maxid();
            int CAJA_DIARIA = int.Parse(mid.role("ID", "CAJA_DIARIA", "ROL", VGlobales.vp_role));
            agregarCambio();

            foreach (DataGridViewRow row in dgComposicion.Rows)
            {
                if (row.Cells[1].Value.ToString().Contains("CAMBIO"))
                {
                    decimal CAMBIO = Convert.ToDecimal(row.Cells[2].Value.ToString());

                    try
                    {
                        BO_CAJA.guardarCambio(CAJA_DIARIA, CAMBIO);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO GUARDAR EL CAMBIO\n" + error);
                    }
                }
                else if (row.Cells[1].Value.ToString().Contains("CH"))
                {
                    int CHEQUE = int.Parse(row.Cells[0].Value.ToString());

                    try
                    {
                        BO_CAJA.guardarChequeCajaDiaria(CAJA_DIARIA, CHEQUE);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO GUARDAR LA CAJA DIARIA EN CHEQUES - " + CHEQUE + "\n" + error);
                    }
                }
                else
                {
                    int CAJA_ANTERIOR = int.Parse(row.Cells[0].Value.ToString());

                    if (CAJA_ANTERIOR != 0)
                    {
                        try
                        {
                            BO_CAJA.guardarCajasAnteriores(CAJA_ANTERIOR, CAJA_DIARIA);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("NO SE PUDO GUARDAR LA CAJA ANTERIOR\n" + error);
                        }
                    }
                }

                pbProcesando.PerformStep();
            }

            pbProcesando.Maximum = dgEfectivo.Rows.Count;
            pbProcesando.Value = 0;

            foreach (DataGridViewRow row in dgEfectivo.Rows)
            {
                string NRO = row.Cells[0].Value.ToString();
                int ID = int.Parse(row.Cells[9].Value.ToString());

                if (NRO.Contains("R"))
                {
                    try
                    {
                        BO_CAJA.cajaEnRecibos(ID, CAJA_DIARIA);
                    }
                    catch (Exception error)
                    {
                        BO_CAJA.borrarCajaDeComprobante("RECIBOS_CAJA", CAJA_DIARIA);
                        BO_CAJA.borrarCajaDeComprobante("CAJA_DIARIA", CAJA_DIARIA);
                        MessageBox.Show("NO SE PUDO GUARDAR LA CAJA EN EL RECIBO " + NRO + "\n" + error);
                    }
                }
                else if (NRO.Contains("B"))
                {
                    try
                    {
                        BO_CAJA.cajaEnBonos(ID, CAJA_DIARIA);
                    }
                    catch (Exception error)
                    {
                        BO_CAJA.borrarCajaDeComprobante("BONOS_CAJA", CAJA_DIARIA);
                        BO_CAJA.borrarCajaDeComprobante("CAJA_DIARIA", CAJA_DIARIA);
                        MessageBox.Show("NO SE PUDO GUARDAR LA CAJA EN EL BONO " + NRO + "\n" + error);
                    }
                }

                pbProcesando.PerformStep();
            }

            pbProcesando.Maximum = dgOtros.Rows.Count;
            pbProcesando.Value = 0;

            foreach (DataGridViewRow row in dgOtros.Rows)
            {
                string NRO = row.Cells[0].Value.ToString();
                int ID = int.Parse(row.Cells[9].Value.ToString());

                if (NRO.Contains("R"))
                {
                    try
                    {
                        BO_CAJA.cajaEnRecibos(ID, CAJA_DIARIA);
                    }
                    catch (Exception error)
                    {
                        BO_CAJA.borrarCajaDeComprobante("RECIBOS_CAJA", CAJA_DIARIA);
                        BO_CAJA.borrarCajaDeComprobante("CAJA_DIARIA", CAJA_DIARIA);
                        MessageBox.Show("NO SE PUDO GUARDAR LA CAJA EN EL RECIBO " + NRO + "\n" + error);
                    }
                }
                else if (NRO.Contains("B"))
                {
                    try
                    {
                        BO_CAJA.cajaEnBonos(ID, CAJA_DIARIA);
                    }
                    catch (Exception error)
                    {
                        BO_CAJA.borrarCajaDeComprobante("BONOS_CAJA", CAJA_DIARIA);
                        BO_CAJA.borrarCajaDeComprobante("CAJA_DIARIA", CAJA_DIARIA);
                        MessageBox.Show("NO SE PUDO GUARDAR LA CAJA EN EL BONO " + NRO + "\n" + error);
                    }
                }

                pbProcesando.PerformStep();
            }

            pbProcesando.Maximum = dgOtros.Rows.Count;
            pbProcesando.Value = 0;

            foreach (DataGridViewRow row in dgEgresos.Rows)
            {
                int ID = int.Parse(row.Cells[9].Value.ToString());
                string F_PAGO = row.Cells[8].Value.ToString();
                string NRO = row.Cells[0].Value.ToString();

                if (NRO.Contains("R"))
                {
                    try
                    {
                        BO_CAJA.cajaEnRecibos(ID, CAJA_DIARIA);
                    }
                    catch (Exception error)
                    {
                        BO_CAJA.borrarCajaDeComprobante("RECIBOS_CAJA", CAJA_DIARIA);
                        BO_CAJA.borrarCajaDeComprobante("CAJA_DIARIA", CAJA_DIARIA);
                        MessageBox.Show("NO SE PUDO GUARDAR LA CAJA EN EL RECIBO " + NRO + "\n" + error);
                    }
                }
                else if (NRO.Contains("B"))
                {
                    try
                    {
                        BO_CAJA.cajaEnBonos(ID, CAJA_DIARIA);
                    }
                    catch (Exception error)
                    {
                        BO_CAJA.borrarCajaDeComprobante("BONOS_CAJA", CAJA_DIARIA);
                        BO_CAJA.borrarCajaDeComprobante("CAJA_DIARIA", CAJA_DIARIA);
                        MessageBox.Show("NO SE PUDO GUARDAR LA CAJA EN EL BONO " + NRO + "\n" + error);
                    }
                }

                if (F_PAGO == "CHEQUE")
                {
                    BO_CAJA.depositarChequeAlCierre(ID, 2, CAJA_DIARIA);
                }

                pbProcesando.PerformStep();
            }

            pbProcesando.Maximum = dgOtros.Rows.Count;
            pbProcesando.Value = 0;

            foreach (DataGridViewRow row in dgCajasDepositadas.Rows)
            {
                int ID = int.Parse(row.Cells[0].Value.ToString());
                BO_CAJA.depositarCajaAlCierre(ID, 2, CAJA_DIARIA);
                pbProcesando.PerformStep();
            }

            cargaInicial(0);
            Cursor = Cursors.Default;
            pbProcesando.Visible = false;
            MessageBox.Show("CAJA DIARIA CERRADA CORRECTAMENTE");
        }

        private void cerrarCaja()
        {
            if (MessageBox.Show("SE DISPONE A CERRAR LA CAJA DIARIA\n¿CONTINUAR?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (validarCajaCerrada() == true)
                {
                    MessageBox.Show("LA CAJA DEL DIA YA SE ENCUENTRA CERRADA", "ERROR");
                }
                else
                {
                    if (dgComposicion.Rows.Count == 0)
                    {
                        if (MessageBox.Show("NO HAY CAJAS ANTERIORES EN COMPOSICION DE SALDO\n¿CONTINUAR?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            cerrar();
                        }
                    }
                    else
                    {
                        cerrar();
                    }
                }
            }
        }

        private void pintarCajas()
        {
            string DEPOSITADA = "0";
            int X = 0;

            foreach (DataGridViewRow row in dgCajasAnteriores.Rows)
            {
                DEPOSITADA = row.Cells[10].Value.ToString();

                if (DEPOSITADA == "0")
                {
                    dgCajasAnteriores.Rows[X].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    dgCajasAnteriores.Rows[X].DefaultCellStyle.BackColor = Color.LightSalmon;
                }

                X++;
            }
        }

        private void buscarCajas(int DEPO, DataGridView GRILLA)
        {
            try
            {
                string connectionString;
                DataSet ds1 = new DataSet();
                Datos_ini ini3 = new Datos_ini();
                string query = "";

                if (DEPO == 0)
                    query = "SELECT ID, FECHA, US_ALTA, FE_ALTA, INGRESOS_EFECTIVO, INGRESOS_OTROS, SUBTOTAL_INGRESOS, EGRESOS, SALDO_CAJA, TOTAL, DEPOSITADA, EXPORTADA, ID_ROL FROM CAJA_DIARIA WHERE DEPOSITADA IN (0,1,2) AND ROL = '" + VGlobales.vp_role + "' ORDER BY ID_ROL DESC;";

                if (DEPO == 1)
                    query = "SELECT ID, FECHA, US_ALTA, FE_ALTA, INGRESOS_EFECTIVO, INGRESOS_OTROS, SUBTOTAL_INGRESOS, EGRESOS, SALDO_CAJA, TOTAL, DEPOSITADA, EXPORTADA, ID_ROL FROM CAJA_DIARIA WHERE DEPOSITADA = 1 AND ROL = '" + VGlobales.vp_role + "' ORDER BY ID_ROL DESC;";

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
                    dt1.Columns.Add("ID", typeof(int));
                    dt1.Columns.Add("FECHA", typeof(string));
                    dt1.Columns.Add("USUARIO", typeof(string));
                    dt1.Columns.Add("ALTA", typeof(string));
                    dt1.Columns.Add("EFECTIVO", typeof(string));
                    dt1.Columns.Add("OTROS", typeof(string));
                    dt1.Columns.Add("SUBTOTAL", typeof(string));
                    dt1.Columns.Add("EGRESOS", typeof(string));
                    dt1.Columns.Add("SALDO", typeof(string));
                    dt1.Columns.Add("TOTAL", typeof(string));
                    dt1.Columns.Add("DEPOSITADA", typeof(int));
                    dt1.Columns.Add("ID_ROL", typeof(int));
                    ds1.Tables.Add(dt1);
                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    FbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader.GetString(reader.GetOrdinal("ID")));
                        string FECHA = reader.GetString(reader.GetOrdinal("FECHA")).Substring(0, 10);
                        string US_ALTA = reader.GetString(reader.GetOrdinal("US_ALTA")).Trim();
                        string FE_ALTA = reader.GetString(reader.GetOrdinal("FE_ALTA")).Substring(0, 10);
                        string INGRESOS_EFECTIVO = string.Format("{0:n}", reader.GetDecimal(reader.GetOrdinal("INGRESOS_EFECTIVO")));
                        string INGRESOS_OTROS = string.Format("{0:n}", reader.GetDecimal(reader.GetOrdinal("INGRESOS_OTROS")));
                        string SUBTOTAL_INGRESOS = string.Format("{0:n}", reader.GetDecimal(reader.GetOrdinal("SUBTOTAL_INGRESOS")));
                        string EGRESOS = string.Format("{0:n}", reader.GetDecimal(reader.GetOrdinal("EGRESOS")));
                        string SALDO_CAJA = string.Format("{0:n}", reader.GetDecimal(reader.GetOrdinal("SALDO_CAJA")));
                        string TOTAL = string.Format("{0:n}", reader.GetDecimal(reader.GetOrdinal("TOTAL")));
                        string DEPOSITADA = (reader.GetDecimal(reader.GetOrdinal("DEPOSITADA"))).ToString();
                        string ID_ROL = (reader.GetDecimal(reader.GetOrdinal("ID_ROL"))).ToString();
                        dt1.Rows.Add(ID, FECHA, US_ALTA, FE_ALTA, INGRESOS_EFECTIVO, INGRESOS_OTROS, SUBTOTAL_INGRESOS, EGRESOS, SALDO_CAJA, TOTAL, DEPOSITADA, ID_ROL);
                    }


                    reader.Close();
                    GRILLA.DataSource = dt1;
                    GRILLA.Columns[0].Width = 0;
                    GRILLA.Columns[0].Visible = true;
                    GRILLA.Columns[1].Width = 80;
                    GRILLA.Columns[2].Width = 100;
                    GRILLA.Columns[2].Visible = false;
                    GRILLA.Columns[3].Width = 80;
                    GRILLA.Columns[3].Visible = false;
                    GRILLA.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GRILLA.Columns[4].Width = 89;
                    GRILLA.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GRILLA.Columns[5].Width = 89;
                    GRILLA.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GRILLA.Columns[6].Width = 89;
                    GRILLA.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GRILLA.Columns[7].Width = 89;
                    GRILLA.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GRILLA.Columns[8].Width = 89;
                    GRILLA.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GRILLA.Columns[8].Width = 89;
                    GRILLA.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GRILLA.Columns[9].Width = 89;
                    GRILLA.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GRILLA.Columns[10].Visible = false; //DEPOSITADA
                    GRILLA.Columns[11].Width = 0; //ID_ROL
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCerrarCaja_Click_1(object sender, EventArgs e)
        {
            if (CAJA == 0)
                cerrarCaja();

            //if (CAJA > 0)
            //  modificarCaja(CAJA);
        }

        /*private void modificarCaja(int CAJA)
        {
            decimal INGRESOS_EFECTIVO = Convert.ToDecimal(dgTotalesDelDia.Rows[0].Cells[1].Value.ToString());
            decimal INGRESOS_OTROS = Convert.ToDecimal(dgTotalesDelDia.Rows[1].Cells[1].Value.ToString());
            decimal EGRESOS = Convert.ToDecimal(dgTotalesDelDia.Rows[2].Cells[1].Value.ToString());
            decimal SUBTOTAL_INGRESOS = Convert.ToDecimal(dgTotalesDelDia.Rows[3].Cells[1].Value.ToString());
            decimal SALDO_CAJA = Convert.ToDecimal(dgTotalesDelDia.Rows[4].Cells[1].Value.ToString());
            decimal TOTAL = Convert.ToDecimal(tbTotal.Text);
            string ROL = VGlobales.vp_role;

            try
            {
                BO_CAJA.modificarCajaDiaria(INGRESOS_EFECTIVO, INGRESOS_OTROS, SUBTOTAL_INGRESOS, EGRESOS, SALDO_CAJA, ROL, TOTAL);
                cargaInicial(CAJA);
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO MODIFICAR LA CAJA DIARIA\n " + error);
            }
        }*/

        private void agregarCajas()
        {
            decimal TOTAL = 0;
            string DEPOSITADA = "";

            foreach (DataGridViewRow row in dgCajasAnteriores.Rows)
            {
                DEPOSITADA = row.Cells[10].Value.ToString();

                if (DEPOSITADA == "0")
                {
                    string ID = row.Cells[0].Value.ToString();
                    string FECHA_CAJA = row.Cells[1].Value.ToString();
                    decimal IMPORTE = Convert.ToDecimal(row.Cells[4].Value);
                    string IMPORTE_S = string.Format("{0:n}", IMPORTE);
                    dgComposicion.Rows.Add(ID, "CAJA DEL DIA " + FECHA_CAJA, IMPORTE_S);
                    TOTAL = TOTAL + IMPORTE;
                }
            }

            tbTotal.Text = (decimal.Parse(tbTotal.Text) + TOTAL).ToString();
        }

        private void agregarChequesAComposicion()
        {
            decimal TOTAL = 0;

            foreach (DataGridViewRow row in dgCheques.SelectedRows)
            {
                string ID = row.Cells[4].Value.ToString();
                string FECHA = row.Cells[3].Value.ToString();
                string DETALLE = "CHEQUE " + row.Cells[0].Value.ToString();
                decimal IMPORTE = Convert.ToDecimal(row.Cells[2].Value);
                dgComposicion.Rows.Add(ID, DETALLE + " " + FECHA, IMPORTE);
                TOTAL = TOTAL + IMPORTE;
            }

            tbTotal.Text = (decimal.Parse(tbTotal.Text) + TOTAL).ToString();
        }

        private void btAgregarCajas_Click(object sender, EventArgs e)
        {
            agregarCajas();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dgCajasAnteriores.SelectedRows.Count == 0)
            {
                MessageBox.Show("SELECCIONAR UNA CAJA PARA IMPRIMIR");
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                int CAJA = int.Parse(dgCajasAnteriores[0, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString());
                string DIA = dgCajasAnteriores[1, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString().Substring(0, 2);
                string MES = dgCajasAnteriores[1, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString().Substring(3, 2);
                string ANIO = dgCajasAnteriores[1, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString().Substring(6, 4);
                string PATH = "SAVEAS";
                imprimirPlanilla(CAJA, PATH);
                Cursor = Cursors.Default;
            }
        }

        private DataSet buscarComposicionInforme(int CAJA)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
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
                DataSet ds = new DataSet();
                string query = "SELECT * FROM COMPOSICION_SALDO_S ('" + CAJA + "');";
                FbCommand cmd = new FbCommand(query, connection, transaction);
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(cmd);
                da.Fill(ds);

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    return ds;
                }

                transaction.Commit();
                connection.Close();
                cmd = null;
                transaction = null;
            }
        }

        private DataSet buscarChequesComposicion(int CAJA)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
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
                DataSet ds = new DataSet();
                string query = @"SELECT 'R'||B.PTO_VTA||'-'||B.NRO_COMP, 
                TRIM(B.NOMBRE_SOCIO), (TRIM(S.DETALLE)||' - '||TRIM(P.NOMBRE)), B.CUENTA_HABER, B.VALOR, 
                B.OBSERVACIONES, B.FECHA_RECIBO
                FROM RECIBOS_CAJA B, SECTACT S, PROFESIONALES P, FORMAS_DE_PAGO F 
                WHERE B.SECTACT = S.ID
                AND B.ID_PROFESIONAL = P.ID         
                AND B.FORMA_PAGO = '2'    
                AND B.DEPOSITADO = 0
                AND B.FORMA_PAGO = F.ID
                AND B.ROL = 'CAJA'  
                AND B.DESTINO = 9
                AND B.REINTEGRO_DE = 0  
                ORDER BY B.NRO_COMP ASC;";
                FbCommand cmd = new FbCommand(query, connection, transaction);
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(cmd);
                da.Fill(ds);

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    return ds;
                }

                transaction.Commit();
                connection.Close();
                cmd = null;
                transaction = null;
            }
        }

        private DataSet buscarCajasDepositadas(int CAJA)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
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
                DataSet ds = new DataSet();
                string query = "SELECT C.FECHA, C.INGRESOS_EFECTIVO, C.IMPUTACION, B.NOMBRE FROM CAJA_DIARIA C, BANCOS B WHERE C.CAJA_DEPOSITADA = " + CAJA + " AND C.BANCO = B.ID;";
                FbCommand cmd = new FbCommand(query, connection, transaction);
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(cmd);
                da.Fill(ds);

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    return ds;
                }

                transaction.Commit();
                connection.Close();
                cmd = null;
                transaction = null;
            }
        }

        private DataSet buscarChequesInforme(int CAJA)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
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
                DataSet ds = new DataSet();
                string query = "SELECT R.NRO_COMP, R.OBSERVACIONES, R.FECHA_RECIBO, R.VALOR, R.CUENTA_DEBE  FROM CAJA_DIARIA_CHEQUES C, RECIBOS_CAJA R WHERE R.ID = C.CHEQUE AND C.CAJA_DIARIA = " + CAJA + " AND PTO_VTA = '" + VGlobales.PTO_VTA_N + "';";
                FbCommand cmd = new FbCommand(query, connection, transaction);
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(cmd);
                da.Fill(ds);

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    return ds;
                }

                transaction.Commit();
                connection.Close();
                cmd = null;
                transaction = null;
            }
        }

        private DataSet buscarCambioInforme(int CAJA)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
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
                DataSet ds = new DataSet();
                string query = "SELECT CAMBIO FROM CAJA_CAMBIO WHERE CAJA_DIARIA = " + CAJA;
                FbCommand cmd = new FbCommand(query, connection, transaction);
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(cmd);
                da.Fill(ds);

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    return ds;
                }

                transaction.Commit();
                connection.Close();
                cmd = null;
                transaction = null;
            }
        }

        private DataSet buscarIngresosInforme(int CAJA, string PAGO)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
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
                DataSet ds = new DataSet();
                string query = "SELECT * FROM PLANILLA_CAJA_INFORME ('" + PAGO + "', " + CAJA + ", '" + VGlobales.vp_role + "');";
                FbCommand cmd = new FbCommand(query, connection, transaction);
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(cmd);
                da.Fill(ds);

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    return ds;
                }

                transaction.Commit();
                connection.Close();
                cmd = null;
                transaction = null;
            }
        }

        private DataSet buscarTotalesInforme(int CAJA)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
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
                DataSet ds = new DataSet();
                string query = "SELECT INGRESOS_EFECTIVO, INGRESOS_OTROS, SUBTOTAL_INGRESOS, EGRESOS, SALDO_CAJA, TOTAL FROM CAJA_DIARIA WHERE ID = " + CAJA;
                FbCommand cmd = new FbCommand(query, connection, transaction);
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(cmd);
                da.Fill(ds);

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    return ds;
                }

                transaction.Commit();
                connection.Close();
                cmd = null;
                transaction = null;
            }
        }

        private DataSet buscarEgresosInforme(int CAJA)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
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
                DataSet ds = new DataSet();
                string query = "SELECT * FROM EGRESOS_INFORME (" + CAJA + ");";
                FbCommand cmd = new FbCommand(query, connection, transaction);
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(cmd);
                da.Fill(ds);

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    return ds;
                }

                transaction.Commit();
                connection.Close();
                cmd = null;
                transaction = null;
            }
        }

        private void AddPageNumber(string ARCHIVO)
        {
            byte[] bytes = File.ReadAllBytes(ARCHIVO);
            iTextSharp.text.Font _mediumFontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            using (MemoryStream stream = new MemoryStream())
            {
                PdfReader reader = new PdfReader(bytes);

                using (PdfStamper stamper = new PdfStamper(reader, stream))
                {
                    int pages = reader.NumberOfPages;

                    for (int i = 1; i <= pages; i++)
                    {
                        ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase("Página " + i.ToString() + " de " + pages.ToString(), _mediumFontBold), 100f, 15f, 0);
                    }
                }

                bytes = stream.ToArray();
            }

            File.WriteAllBytes(ARCHIVO, bytes);
        }

        private void imprimirPlanilla(int CAJA, string PATH)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                #region CONFIG
                Document doc = new Document(PageSize.LEGAL);
                doc.SetPageSize(iTextSharp.text.PageSize.LEGAL.Rotate());

                if (PATH == "SAVEAS")
                {
                    SaveFileDialog SFD = new SaveFileDialog();
                    SFD.Filter = "Archivo PDF|*.pdf";
                    SFD.Title = "Guardar Listado";

                    if (SFD.ShowDialog() == DialogResult.OK)
                    {
                        PATH = SFD.FileName;
                    }
                }

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(PATH, FileMode.Create));
                doc.AddTitle("PLANILLA DE CAJA");
                doc.AddCreator("CSPFA");
                doc.Open();

                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font _standardFontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font _standardFontWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
                iTextSharp.text.Font _standardFontBoldWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                iTextSharp.text.Font _mediumFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font _mediumFontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font _mediumFontWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
                iTextSharp.text.Font _mediumFontBoldWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, BaseColor.WHITE);

                BaseColor negro = new BaseColor(0, 0, 0);
                BaseColor gris = new BaseColor(230, 230, 230);
                BaseColor topo = new BaseColor(100, 100, 100);
                BaseColor blanco = new BaseColor(255, 255, 255);
                BaseColor colorFondo = new BaseColor(255, 255, 255);

                DataSet EFECTIVO_DS = buscarIngresosInforme(CAJA, "1");
                DataSet CAMBIO_DS = buscarCambioInforme(CAJA);
                DataSet TOTALES_DIA = buscarTotalesInforme(CAJA);
                DataSet OTROS_DS = buscarIngresosInforme(CAJA, "0");
                DataSet EGRESOS = buscarIngresosInforme(CAJA, "E");
                DataSet CHEQUES = buscarChequesInforme(CAJA);
                DataSet COMPOSICION_DS = buscarComposicionInforme(CAJA);
                DataSet CAJAS_DEPOSITADAS = buscarCajasDepositadas(CAJA);
                DataSet CHEQUES_COMPOSICION = buscarChequesComposicion(CAJA);

                string NUM = "";
                string NUM_E = "";
                string RECIBO = "";
                string BONO = "";
                string NOMBRE = "";
                string CONCEPTO = "";
                string DEBE = "";
                decimal IMPORTE = 0;
                decimal IMPORTE_E = 0;
                string OBSERVACIONES = "";
                string PTO_VTA_AFIP = "";
                decimal TOTAL_EFECTIVO_AFIP = 0;
                decimal TOTAL_OTROS_AFIP = 0;
                decimal TOTAL = 0;
                decimal TOTAL_INGRESOS_EFECTIVO = Convert.ToDecimal(dgCajasAnteriores[4, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString());
                decimal TOTAL_INGRESOS_OTROS = Convert.ToDecimal(dgCajasAnteriores[5, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString());
                decimal TOTAL_EGRESOS = Convert.ToDecimal(dgCajasAnteriores[7, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString());
                string FECHA = dgCajasAnteriores[1, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString();
                int X = 0;
                string TIPO = "";
                string ANULADO = "";
                string PTO_VTA = "";
                string F_PAGO = "";
                string TEXTO_NUM_E = "";

                Paragraph header = new Paragraph("// " + VGlobales.vp_role + " // PLANILLA DE CAJA " + FECHA, _standardFontBold);
                header.Alignment = Element.ALIGN_CENTER;
                header.SpacingAfter = 5;
                doc.Add(header);
                #endregion

                #region CABECERA INGRESOS EN EFECTIVO
                Paragraph sub = new Paragraph("INGRESOS DEL DIA EN EFECTIVO", _standardFontBold);
                sub.Alignment = Element.ALIGN_CENTER;
                sub.SpacingAfter = 5;
                doc.Add(sub);

                PdfPTable TABLA_INGRESOS = new PdfPTable(9);
                TABLA_INGRESOS.WidthPercentage = 100;
                TABLA_INGRESOS.SpacingAfter = 10;
                TABLA_INGRESOS.SpacingBefore = 10;
                TABLA_INGRESOS.SetWidths(new float[] { 1.6f, 1.6f, 4f, 6f, 1.5f, 2f, 2f, 5f, 2f });
                PdfPCell CELDA_NUM = new PdfPCell(new Phrase("#", _mediumFontBoldWhite));
                PdfPCell CELDA_NUM_E = new PdfPCell(new Phrase("#E", _mediumFontBoldWhite));
                PdfPCell CELDA_APENOM = new PdfPCell(new Phrase("APELLIDO Y NOMBRES", _mediumFontBoldWhite));
                PdfPCell CELDA_CONCEPTO = new PdfPCell(new Phrase("CONCEPTO", _mediumFontBoldWhite));
                PdfPCell CELDA_IMPUTACION = new PdfPCell(new Phrase("HABER", _mediumFontBoldWhite));
                PdfPCell CELDA_IMPORTE = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                PdfPCell CELDA_IMPORTE_E = new PdfPCell(new Phrase("IMPORTE E", _mediumFontBoldWhite));
                PdfPCell CELDA_OBS = new PdfPCell(new Phrase("OBSERVACIONES", _mediumFontBoldWhite));
                PdfPCell CELDA_ANULADO = new PdfPCell(new Phrase("ANULADO", _mediumFontBoldWhite));
                CELDA_NUM.BackgroundColor = topo;
                CELDA_NUM.BorderColor = blanco;
                CELDA_NUM.HorizontalAlignment = 1;
                CELDA_NUM.FixedHeight = 16f;
                CELDA_NUM_E.BackgroundColor = topo;
                CELDA_NUM_E.BorderColor = blanco;
                CELDA_NUM_E.HorizontalAlignment = 1;
                CELDA_NUM_E.FixedHeight = 16f;
                CELDA_APENOM.BackgroundColor = topo;
                CELDA_APENOM.BorderColor = blanco;
                CELDA_APENOM.HorizontalAlignment = 1;
                CELDA_APENOM.FixedHeight = 16f;
                CELDA_CONCEPTO.BackgroundColor = topo;
                CELDA_CONCEPTO.BorderColor = blanco;
                CELDA_CONCEPTO.HorizontalAlignment = 1;
                CELDA_CONCEPTO.FixedHeight = 16f;
                CELDA_IMPUTACION.BackgroundColor = topo;
                CELDA_IMPUTACION.BorderColor = blanco;
                CELDA_IMPUTACION.HorizontalAlignment = 1;
                CELDA_IMPUTACION.FixedHeight = 16f;
                CELDA_IMPORTE.BackgroundColor = topo;
                CELDA_IMPORTE.BorderColor = blanco;
                CELDA_IMPORTE.HorizontalAlignment = 1;
                CELDA_IMPORTE.FixedHeight = 16f;
                CELDA_IMPORTE_E.BackgroundColor = topo;
                CELDA_IMPORTE_E.BorderColor = blanco;
                CELDA_IMPORTE_E.HorizontalAlignment = 1;
                CELDA_IMPORTE_E.FixedHeight = 16f;
                CELDA_OBS.BackgroundColor = topo;
                CELDA_OBS.BorderColor = blanco;
                CELDA_OBS.HorizontalAlignment = 1;
                CELDA_OBS.FixedHeight = 16f;
                CELDA_ANULADO.BackgroundColor = topo;
                CELDA_ANULADO.BorderColor = blanco;
                CELDA_ANULADO.HorizontalAlignment = 1;
                CELDA_ANULADO.FixedHeight = 16f;
                TABLA_INGRESOS.AddCell(CELDA_NUM);
                TABLA_INGRESOS.AddCell(CELDA_NUM_E);
                TABLA_INGRESOS.AddCell(CELDA_APENOM);
                TABLA_INGRESOS.AddCell(CELDA_CONCEPTO);
                TABLA_INGRESOS.AddCell(CELDA_IMPUTACION);
                TABLA_INGRESOS.AddCell(CELDA_IMPORTE);
                TABLA_INGRESOS.AddCell(CELDA_IMPORTE_E);
                TABLA_INGRESOS.AddCell(CELDA_OBS);
                TABLA_INGRESOS.AddCell(CELDA_ANULADO);
                #endregion

                #region CABECERA INGRESOS EN OTROS
                PdfPTable TABLA_INGRESOS_OTROS = new PdfPTable(10);

                TABLA_INGRESOS_OTROS.WidthPercentage = 100;
                TABLA_INGRESOS_OTROS.SpacingAfter = 10;
                TABLA_INGRESOS_OTROS.SpacingBefore = 10;
                TABLA_INGRESOS_OTROS.SetWidths(new float[] { 1.8f, 1.8f, 4f, 6f, 1.5f, 2.5f, 2.5f, 5f, 2f, 2f });
                PdfPCell CELDA_NUM_OTROS = new PdfPCell(new Phrase("#", _mediumFontBoldWhite));
                PdfPCell CELDA_NUM_OTROS_E = new PdfPCell(new Phrase("#E", _mediumFontBoldWhite));
                PdfPCell CELDA_APENOM_OTROS = new PdfPCell(new Phrase("APELLIDO Y NOMBRES", _mediumFontBoldWhite));
                PdfPCell CELDA_CONCEPTO_OTROS = new PdfPCell(new Phrase("CONCEPTO", _mediumFontBoldWhite));
                PdfPCell CELDA_IMPUTACION_OTROS = new PdfPCell(new Phrase("HABER", _mediumFontBoldWhite));
                PdfPCell CELDA_IMPORTE_OTROS = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                PdfPCell CELDA_IMPORTE_OTROS_E = new PdfPCell(new Phrase("IMPORTE_E", _mediumFontBoldWhite));
                PdfPCell CELDA_OBS_OTROS = new PdfPCell(new Phrase("OBSERVACIONES", _mediumFontBoldWhite));
                PdfPCell CELDA_ANULADO_OTROS = new PdfPCell(new Phrase("ANULADO", _mediumFontBoldWhite));
                PdfPCell CELDA_PAGO_OTROS = new PdfPCell(new Phrase("PAGO", _mediumFontBoldWhite));
                CELDA_NUM_OTROS.BackgroundColor = topo;
                CELDA_NUM_OTROS.BorderColor = blanco;
                CELDA_NUM_OTROS.HorizontalAlignment = 1;
                CELDA_NUM_OTROS.FixedHeight = 16f;
                CELDA_NUM_OTROS_E.BackgroundColor = topo;
                CELDA_NUM_OTROS_E.BorderColor = blanco;
                CELDA_NUM_OTROS_E.HorizontalAlignment = 1;
                CELDA_NUM_OTROS_E.FixedHeight = 16f;
                CELDA_APENOM_OTROS.BackgroundColor = topo;
                CELDA_APENOM_OTROS.BorderColor = blanco;
                CELDA_APENOM_OTROS.HorizontalAlignment = 1;
                CELDA_APENOM_OTROS.FixedHeight = 16f;
                CELDA_CONCEPTO_OTROS.BackgroundColor = topo;
                CELDA_CONCEPTO_OTROS.BorderColor = blanco;
                CELDA_CONCEPTO_OTROS.HorizontalAlignment = 1;
                CELDA_CONCEPTO_OTROS.FixedHeight = 16f;
                CELDA_IMPUTACION_OTROS.BackgroundColor = topo;
                CELDA_IMPUTACION_OTROS.BorderColor = blanco;
                CELDA_IMPUTACION_OTROS.HorizontalAlignment = 1;
                CELDA_IMPUTACION_OTROS.FixedHeight = 16f;
                CELDA_IMPORTE_OTROS.BackgroundColor = topo;
                CELDA_IMPORTE_OTROS.BorderColor = blanco;
                CELDA_IMPORTE_OTROS.HorizontalAlignment = 1;
                CELDA_IMPORTE_OTROS.FixedHeight = 16f;
                CELDA_IMPORTE_OTROS_E.BackgroundColor = topo;
                CELDA_IMPORTE_OTROS_E.BorderColor = blanco;
                CELDA_IMPORTE_OTROS_E.HorizontalAlignment = 1;
                CELDA_IMPORTE_OTROS_E.FixedHeight = 16f;
                CELDA_OBS_OTROS.BackgroundColor = topo;
                CELDA_OBS_OTROS.BorderColor = blanco;
                CELDA_OBS_OTROS.HorizontalAlignment = 1;
                CELDA_OBS_OTROS.FixedHeight = 16f;
                CELDA_ANULADO_OTROS.BackgroundColor = topo;
                CELDA_ANULADO_OTROS.BorderColor = blanco;
                CELDA_ANULADO_OTROS.HorizontalAlignment = 1;
                CELDA_ANULADO_OTROS.FixedHeight = 16f;
                CELDA_PAGO_OTROS.BackgroundColor = topo;
                CELDA_PAGO_OTROS.BorderColor = blanco;
                CELDA_PAGO_OTROS.HorizontalAlignment = 1;
                CELDA_PAGO_OTROS.FixedHeight = 16f;
                TABLA_INGRESOS_OTROS.AddCell(CELDA_NUM_OTROS);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_NUM_OTROS_E);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_APENOM_OTROS);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_CONCEPTO_OTROS);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_IMPUTACION_OTROS);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_IMPORTE_OTROS);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_IMPORTE_OTROS_E);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_OBS_OTROS);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_ANULADO_OTROS);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_PAGO_OTROS);

                #endregion

                #region CABECERA EGRESOS
                PdfPTable TABLA_EGRESOS = new PdfPTable(7);
                if (VGlobales.vp_role == "CAJA")
                {
                    TABLA_EGRESOS.WidthPercentage = 100;
                    TABLA_EGRESOS.SpacingAfter = 10;
                    TABLA_EGRESOS.SpacingBefore = 10;
                    TABLA_EGRESOS.SetWidths(new float[] { 1.4f, 4f, 1f, 2f, 5f, 2f, 2f });
                    PdfPCell CELDA_NUM_EGRESOS = new PdfPCell(new Phrase("#", _mediumFontBoldWhite));
                    PdfPCell CELDA_APENOM_EGRESOS = new PdfPCell(new Phrase("BANCO", _mediumFontBoldWhite));
                    PdfPCell CELDA_IMPUTACION_EGRESOS = new PdfPCell(new Phrase("DEBE", _mediumFontBoldWhite));
                    PdfPCell CELDA_IMPORTE_EGRESOS = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                    PdfPCell CELDA_OBS_EGRESOS = new PdfPCell(new Phrase("OBSERVACIONES", _mediumFontBoldWhite));
                    PdfPCell CELDA_ANULADO_EGRESOS = new PdfPCell(new Phrase("ANULADO", _mediumFontBoldWhite));
                    PdfPCell CELDA_PAGO_EGRESOS = new PdfPCell(new Phrase("PAGO", _mediumFontBoldWhite));
                    CELDA_NUM_EGRESOS.BackgroundColor = topo;
                    CELDA_NUM_EGRESOS.BorderColor = blanco;
                    CELDA_NUM_EGRESOS.HorizontalAlignment = 1;
                    CELDA_NUM_EGRESOS.FixedHeight = 16f;
                    CELDA_APENOM_EGRESOS.BackgroundColor = topo;
                    CELDA_APENOM_EGRESOS.BorderColor = blanco;
                    CELDA_APENOM_EGRESOS.HorizontalAlignment = 1;
                    CELDA_APENOM_EGRESOS.FixedHeight = 16f;
                    CELDA_IMPUTACION_EGRESOS.BackgroundColor = topo;
                    CELDA_IMPUTACION_EGRESOS.BorderColor = blanco;
                    CELDA_IMPUTACION_EGRESOS.HorizontalAlignment = 1;
                    CELDA_IMPUTACION_EGRESOS.FixedHeight = 16f;
                    CELDA_IMPORTE_EGRESOS.BackgroundColor = topo;
                    CELDA_IMPORTE_EGRESOS.BorderColor = blanco;
                    CELDA_IMPORTE_EGRESOS.HorizontalAlignment = 1;
                    CELDA_IMPORTE_EGRESOS.FixedHeight = 16f;
                    CELDA_OBS_EGRESOS.BackgroundColor = topo;
                    CELDA_OBS_EGRESOS.BorderColor = blanco;
                    CELDA_OBS_EGRESOS.HorizontalAlignment = 1;
                    CELDA_OBS_EGRESOS.FixedHeight = 16f;
                    CELDA_ANULADO_EGRESOS.BackgroundColor = topo;
                    CELDA_ANULADO_EGRESOS.BorderColor = blanco;
                    CELDA_ANULADO_EGRESOS.HorizontalAlignment = 1;
                    CELDA_ANULADO_EGRESOS.FixedHeight = 16f;
                    CELDA_PAGO_EGRESOS.BackgroundColor = topo;
                    CELDA_PAGO_EGRESOS.BorderColor = blanco;
                    CELDA_PAGO_EGRESOS.HorizontalAlignment = 2;
                    CELDA_PAGO_EGRESOS.FixedHeight = 16f;
                    TABLA_EGRESOS.AddCell(CELDA_NUM_EGRESOS);
                    TABLA_EGRESOS.AddCell(CELDA_APENOM_EGRESOS);
                    TABLA_EGRESOS.AddCell(CELDA_IMPUTACION_EGRESOS);
                    TABLA_EGRESOS.AddCell(CELDA_IMPORTE_EGRESOS);
                    TABLA_EGRESOS.AddCell(CELDA_OBS_EGRESOS);
                    TABLA_EGRESOS.AddCell(CELDA_ANULADO_EGRESOS);
                    TABLA_EGRESOS.AddCell(CELDA_PAGO_EGRESOS);
                }
                #endregion

                #region CABECERA CAJAS DEPOSITADAS
                PdfPTable TABLA_CAJAS_DEPOSITADAS = new PdfPTable(4);
                PdfPCell CELDA_FECHA_CAJA = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
                PdfPCell CELDA_TOTAL_CAJA = new PdfPCell(new Phrase("TOTAL", _mediumFontBoldWhite));
                PdfPCell CELDA_IMPUTACION_CAJA = new PdfPCell(new Phrase("IMPUTACION", _mediumFontBoldWhite));
                PdfPCell CELDA_BANCO_CAJA = new PdfPCell(new Phrase("BANCO", _mediumFontBoldWhite));

                if (CAJAS_DEPOSITADAS.Tables[0].Rows.Count > 0)
                {
                    TABLA_CAJAS_DEPOSITADAS.WidthPercentage = 100;
                    TABLA_CAJAS_DEPOSITADAS.SpacingAfter = 10;
                    TABLA_CAJAS_DEPOSITADAS.SpacingBefore = 10;
                    TABLA_CAJAS_DEPOSITADAS.SetWidths(new float[] { 1f, 1f, 1f, 1f });

                    CELDA_FECHA_CAJA.BackgroundColor = topo;
                    CELDA_FECHA_CAJA.BorderColor = blanco;
                    CELDA_FECHA_CAJA.HorizontalAlignment = 1;
                    CELDA_FECHA_CAJA.FixedHeight = 16f;

                    CELDA_TOTAL_CAJA.BackgroundColor = topo;
                    CELDA_TOTAL_CAJA.BorderColor = blanco;
                    CELDA_TOTAL_CAJA.HorizontalAlignment = 1;
                    CELDA_TOTAL_CAJA.FixedHeight = 16f;

                    CELDA_IMPUTACION_CAJA.BackgroundColor = topo;
                    CELDA_IMPUTACION_CAJA.BorderColor = blanco;
                    CELDA_IMPUTACION_CAJA.HorizontalAlignment = 1;
                    CELDA_IMPUTACION_CAJA.FixedHeight = 16f;

                    CELDA_BANCO_CAJA.BackgroundColor = topo;
                    CELDA_BANCO_CAJA.BorderColor = blanco;
                    CELDA_BANCO_CAJA.HorizontalAlignment = 1;
                    CELDA_BANCO_CAJA.FixedHeight = 16f;

                    TABLA_CAJAS_DEPOSITADAS.AddCell(CELDA_FECHA_CAJA);
                    TABLA_CAJAS_DEPOSITADAS.AddCell(CELDA_IMPUTACION_CAJA);
                    TABLA_CAJAS_DEPOSITADAS.AddCell(CELDA_BANCO_CAJA);
                    TABLA_CAJAS_DEPOSITADAS.AddCell(CELDA_TOTAL_CAJA);
                }

                #endregion

                #region CABECERA COMPOSICION DE SALDO
                PdfPTable TABLA_COMPOSICION = new PdfPTable(2);
                TABLA_COMPOSICION.WidthPercentage = 100;
                TABLA_COMPOSICION.SpacingAfter = 10;
                TABLA_COMPOSICION.SpacingBefore = 10;
                TABLA_COMPOSICION.SetWidths(new float[] { 4f, 4f });
                TABLA_COMPOSICION.HorizontalAlignment = Element.ALIGN_LEFT;
                PdfPCell CELDA_CAJA_COMPOSICION = new PdfPCell(new Phrase("CAJA", _mediumFontBoldWhite));
                PdfPCell CELDA_IMPORTE_COMPOSICION = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));

                CELDA_CAJA_COMPOSICION.BackgroundColor = topo;
                CELDA_CAJA_COMPOSICION.BorderColor = blanco;
                CELDA_CAJA_COMPOSICION.HorizontalAlignment = 0;
                CELDA_CAJA_COMPOSICION.FixedHeight = 16f;

                CELDA_IMPORTE_COMPOSICION.BackgroundColor = topo;
                CELDA_IMPORTE_COMPOSICION.BorderColor = blanco;
                CELDA_IMPORTE_COMPOSICION.HorizontalAlignment = 2;
                CELDA_IMPORTE_COMPOSICION.FixedHeight = 16f;

                TABLA_COMPOSICION.AddCell(CELDA_CAJA_COMPOSICION);
                TABLA_COMPOSICION.AddCell(CELDA_IMPORTE_COMPOSICION);
                #endregion

                #region CABECERA CHEQUES COMPO

                PdfPTable TABLA_CHEQUES_COMPO = new PdfPTable(6);

                if (VGlobales.vp_role == "CAJA")
                {
                    TABLA_CHEQUES_COMPO.WidthPercentage = 100;
                    TABLA_CHEQUES_COMPO.SpacingAfter = 10;
                    TABLA_CHEQUES_COMPO.SpacingBefore = 10;
                    TABLA_CHEQUES_COMPO.SetWidths(new float[] { 1.6f, 4f, 6f, 1f, 2f, 5f });
                    PdfPCell CELDA_NUM_CP = new PdfPCell(new Phrase("#", _mediumFontBoldWhite));
                    PdfPCell CELDA_APENOM_CP = new PdfPCell(new Phrase("APELLIDO Y NOMBRES", _mediumFontBoldWhite));
                    PdfPCell CELDA_CONCEPTO_CP = new PdfPCell(new Phrase("CONCEPTO", _mediumFontBoldWhite));
                    PdfPCell CELDA_IMPUTACION_CP = new PdfPCell(new Phrase("HABER", _mediumFontBoldWhite));
                    PdfPCell CELDA_IMPORTE_CP = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                    PdfPCell CELDA_OBS_CP = new PdfPCell(new Phrase("OBSERVACIONES", _mediumFontBoldWhite));
                    CELDA_NUM_CP.BackgroundColor = topo;
                    CELDA_NUM_CP.BorderColor = blanco;
                    CELDA_NUM_CP.HorizontalAlignment = 1;
                    CELDA_NUM_CP.FixedHeight = 16f;
                    CELDA_APENOM_CP.BackgroundColor = topo;
                    CELDA_APENOM_CP.BorderColor = blanco;
                    CELDA_APENOM_CP.HorizontalAlignment = 1;
                    CELDA_APENOM_CP.FixedHeight = 16f;
                    CELDA_CONCEPTO_CP.BackgroundColor = topo;
                    CELDA_CONCEPTO_CP.BorderColor = blanco;
                    CELDA_CONCEPTO_CP.HorizontalAlignment = 1;
                    CELDA_CONCEPTO_CP.FixedHeight = 16f;
                    CELDA_IMPUTACION_CP.BackgroundColor = topo;
                    CELDA_IMPUTACION_CP.BorderColor = blanco;
                    CELDA_IMPUTACION_CP.HorizontalAlignment = 1;
                    CELDA_IMPUTACION_CP.FixedHeight = 16f;
                    CELDA_IMPORTE_CP.BackgroundColor = topo;
                    CELDA_IMPORTE_CP.BorderColor = blanco;
                    CELDA_IMPORTE_CP.HorizontalAlignment = 1;
                    CELDA_IMPORTE_CP.FixedHeight = 16f;
                    CELDA_OBS_CP.BackgroundColor = topo;
                    CELDA_OBS_CP.BorderColor = blanco;
                    CELDA_OBS_CP.HorizontalAlignment = 1;
                    CELDA_OBS_CP.FixedHeight = 16f;

                    TABLA_CHEQUES_COMPO.AddCell(CELDA_NUM_CP);
                    TABLA_CHEQUES_COMPO.AddCell(CELDA_APENOM_CP);
                    TABLA_CHEQUES_COMPO.AddCell(CELDA_CONCEPTO_CP);
                    TABLA_CHEQUES_COMPO.AddCell(CELDA_IMPUTACION_CP);
                    TABLA_CHEQUES_COMPO.AddCell(CELDA_IMPORTE_CP);
                    TABLA_CHEQUES_COMPO.AddCell(CELDA_OBS_CP);
                }

                #endregion

                #region CABECERA TOTALES AL DIA
                PdfPTable TABLA_TOTALES_DIA = new PdfPTable(2);
                TABLA_TOTALES_DIA.WidthPercentage = 100;
                TABLA_TOTALES_DIA.SpacingAfter = 10;
                TABLA_TOTALES_DIA.SpacingBefore = 10;
                TABLA_TOTALES_DIA.SetWidths(new float[] { 4f, 4f });
                TABLA_TOTALES_DIA.HorizontalAlignment = Element.ALIGN_RIGHT;
                PdfPCell CELDA_TITULO_TOTAL_DIA = new PdfPCell(new Phrase("AL " + FECHA, _mediumFontBoldWhite));
                PdfPCell CELDA_IMPORTE_TOTAL_DIA = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));

                CELDA_TITULO_TOTAL_DIA.BackgroundColor = topo;
                CELDA_TITULO_TOTAL_DIA.BorderColor = blanco;
                CELDA_TITULO_TOTAL_DIA.HorizontalAlignment = 0;
                CELDA_TITULO_TOTAL_DIA.FixedHeight = 16f;

                CELDA_IMPORTE_TOTAL_DIA.BackgroundColor = topo;
                CELDA_IMPORTE_TOTAL_DIA.BorderColor = blanco;
                CELDA_IMPORTE_TOTAL_DIA.HorizontalAlignment = 2;
                CELDA_IMPORTE_TOTAL_DIA.FixedHeight = 16f;

                TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_TOTAL_DIA);
                TABLA_TOTALES_DIA.AddCell(CELDA_IMPORTE_TOTAL_DIA);
                #endregion

                #region DATOS INGRESOS EN EFECTIVO
                X = 0;
                foreach (DataRow row in EFECTIVO_DS.Tables[0].Rows)
                {
                    NUM = row[0].ToString();
                    NOMBRE = row[1].ToString();
                    CONCEPTO = row[2].ToString();
                    DEBE = row[3].ToString();
                    IMPORTE = Convert.ToDecimal(row[4]);
                    OBSERVACIONES = row[5].ToString();
                    TIPO = row[6].ToString();
                    ANULADO = row[10].ToString().Replace("12:00:00 a.m.", "");
                    PTO_VTA = row[12].ToString();
                    PTO_VTA_AFIP = row[14].ToString();
                    NUM_E = row[15].ToString();

                    if (NUM_E != "")
                    {
                        TOTAL_EFECTIVO_AFIP = TOTAL_EFECTIVO_AFIP + IMPORTE;
                        IMPORTE_E = IMPORTE;
                        TEXTO_NUM_E = TIPO + "" + PTO_VTA_AFIP + "-" + NUM_E;
                    }
                    else
                    {
                        IMPORTE_E = 0;
                        TEXTO_NUM_E = "";
                    }

                    if (X == 0)
                    {
                        colorFondo = new BaseColor(255, 255, 255);
                        X++;
                    }
                    else
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                        X--;
                    }

                    PdfPCell CELL_NUM = new PdfPCell(new Phrase(TIPO + "" + PTO_VTA + "-" + NUM, _mediumFont));
                    CELL_NUM.HorizontalAlignment = 1;
                    CELL_NUM.BorderWidth = 0;
                    CELL_NUM.BackgroundColor = colorFondo;
                    CELL_NUM.FixedHeight = 14f;
                    TABLA_INGRESOS.AddCell(CELL_NUM);

                    PdfPCell CELL_NUM_E = new PdfPCell(new Phrase(TEXTO_NUM_E, _mediumFont));
                    CELL_NUM_E.HorizontalAlignment = 1;
                    CELL_NUM_E.BorderWidth = 0;
                    CELL_NUM_E.BackgroundColor = colorFondo;
                    CELL_NUM_E.FixedHeight = 14f;
                    TABLA_INGRESOS.AddCell(CELL_NUM_E);

                    PdfPCell CELL_NOMBRE = new PdfPCell(new Phrase(NOMBRE, _mediumFont));
                    //CELL_NOMBRE.HorizontalAlignment = 1;
                    CELL_NOMBRE.BorderWidth = 0;
                    CELL_NOMBRE.BackgroundColor = colorFondo;
                    CELL_NOMBRE.FixedHeight = 14f;
                    TABLA_INGRESOS.AddCell(CELL_NOMBRE);

                    PdfPCell CELL_CONCEPTO = new PdfPCell(new Phrase(CONCEPTO, _mediumFont));
                    //CELL_CONCEPTO.HorizontalAlignment = 1;
                    CELL_CONCEPTO.BorderWidth = 0;
                    CELL_CONCEPTO.BackgroundColor = colorFondo;
                    CELL_CONCEPTO.FixedHeight = 14f;
                    TABLA_INGRESOS.AddCell(CELL_CONCEPTO);

                    PdfPCell CELL_DEBE = new PdfPCell(new Phrase(DEBE, _mediumFont));
                    CELL_DEBE.HorizontalAlignment = 1;
                    CELL_DEBE.BorderWidth = 0;
                    CELL_DEBE.BackgroundColor = colorFondo;
                    CELL_DEBE.FixedHeight = 14f;
                    TABLA_INGRESOS.AddCell(CELL_DEBE);

                    PdfPCell CELL_IMPORTE = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", IMPORTE), _mediumFont));
                    CELL_IMPORTE.HorizontalAlignment = 2;
                    CELL_IMPORTE.BorderWidth = 0;
                    CELL_IMPORTE.BackgroundColor = colorFondo;
                    CELL_IMPORTE.FixedHeight = 14f;
                    TABLA_INGRESOS.AddCell(CELL_IMPORTE);

                    PdfPCell CELL_IMPORTE_E = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", IMPORTE_E), _mediumFont));
                    CELL_IMPORTE_E.HorizontalAlignment = 2;
                    CELL_IMPORTE_E.BorderWidth = 0;
                    CELL_IMPORTE_E.BackgroundColor = colorFondo;
                    CELL_IMPORTE_E.FixedHeight = 14f;
                    TABLA_INGRESOS.AddCell(CELL_IMPORTE_E);

                    PdfPCell CELL_OBS = new PdfPCell(new Phrase(OBSERVACIONES, _mediumFont));
                    //CELL_OBS.HorizontalAlignment = 1;
                    CELL_OBS.BorderWidth = 0;
                    CELL_OBS.BackgroundColor = colorFondo;
                    CELL_OBS.FixedHeight = 14f;
                    TABLA_INGRESOS.AddCell(CELL_OBS);

                    PdfPCell CELL_ANULADO = new PdfPCell(new Phrase(ANULADO, _mediumFont));
                    CELL_ANULADO.BorderWidth = 0;
                    CELL_ANULADO.BackgroundColor = colorFondo;
                    CELL_ANULADO.FixedHeight = 14f;
                    TABLA_INGRESOS.AddCell(CELL_ANULADO);
                }

                doc.Add(TABLA_INGRESOS);
                #endregion

                #region TOTAL INGRESOS EN EFECTIVO
                PdfPTable TABLA_TOTAL_INGRESOS = new PdfPTable(4);
                TABLA_TOTAL_INGRESOS.WidthPercentage = 100;
                TABLA_TOTAL_INGRESOS.SpacingAfter = 0;
                TABLA_TOTAL_INGRESOS.SpacingBefore = 0;
                TABLA_TOTAL_INGRESOS.SetWidths(new float[] { 4f, 4f, 4f, 4f });
                PdfPCell CELDA_TITULO = new PdfPCell(new Phrase("3.01.1.01 INGRESOS DEL DIA (DEBE)", _mediumFontBoldWhite));
                PdfPCell CELDA_TOTAL = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", TOTAL_INGRESOS_EFECTIVO), _mediumFontBoldWhite));
                PdfPCell CELDA_TITULO_E = new PdfPCell(new Phrase("TOTAL FACTURADO", _mediumFontBoldWhite));
                PdfPCell CELDA_TOTAL_E = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", TOTAL_EFECTIVO_AFIP), _mediumFontBoldWhite));
                CELDA_TITULO.BackgroundColor = topo;
                CELDA_TITULO.BorderColor = blanco;
                CELDA_TITULO.HorizontalAlignment = 1;
                CELDA_TITULO.FixedHeight = 16f;
                CELDA_TOTAL.BackgroundColor = topo;
                CELDA_TOTAL.BorderColor = blanco;
                CELDA_TOTAL.HorizontalAlignment = 1;
                CELDA_TOTAL.FixedHeight = 16f;
                CELDA_TITULO_E.BackgroundColor = topo;
                CELDA_TITULO_E.BorderColor = blanco;
                CELDA_TITULO_E.HorizontalAlignment = 1;
                CELDA_TITULO_E.FixedHeight = 16f;
                CELDA_TOTAL_E.BackgroundColor = topo;
                CELDA_TOTAL_E.BorderColor = blanco;
                CELDA_TOTAL_E.HorizontalAlignment = 1;
                CELDA_TOTAL_E.FixedHeight = 16f;
                TABLA_TOTAL_INGRESOS.AddCell(CELDA_TITULO);
                TABLA_TOTAL_INGRESOS.AddCell(CELDA_TOTAL);
                TABLA_TOTAL_INGRESOS.AddCell(CELDA_TITULO_E);
                TABLA_TOTAL_INGRESOS.AddCell(CELDA_TOTAL_E);
                doc.Add(TABLA_TOTAL_INGRESOS);
                #endregion

                #region DATOS INGRESOS EN OTROS
                X = 0;
                foreach (DataRow row in OTROS_DS.Tables[0].Rows)
                {
                    NUM = row[0].ToString();
                    NOMBRE = row[1].ToString();
                    CONCEPTO = row[2].ToString();
                    DEBE = row[3].ToString();
                    IMPORTE = Convert.ToDecimal(row[4]);
                    OBSERVACIONES = row[5].ToString();
                    TIPO = row[6].ToString();
                    ANULADO = row[10].ToString();
                    PTO_VTA = row[12].ToString();
                    PTO_VTA_AFIP = row[14].ToString();
                    NUM_E = row[15].ToString();
                    F_PAGO = row[11].ToString();

                    if (NUM_E != "")
                    {
                        TOTAL_OTROS_AFIP = TOTAL_OTROS_AFIP + IMPORTE;
                        IMPORTE_E = IMPORTE;
                        TEXTO_NUM_E = TIPO + "" + PTO_VTA_AFIP + "-" + NUM_E;
                    }
                    else
                    {
                        IMPORTE_E = 0;
                        TEXTO_NUM_E = "";
                    }

                    if (X == 0)
                    {
                        colorFondo = new BaseColor(255, 255, 255);
                        X++;
                    }
                    else
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                        X--;
                    }

                    PdfPCell CELL_NUM_OTROS = new PdfPCell(new Phrase(TIPO + "" + PTO_VTA + "-" + NUM, _mediumFont));
                    CELL_NUM_OTROS.HorizontalAlignment = 1;
                    CELL_NUM_OTROS.BorderWidth = 0;
                    CELL_NUM_OTROS.BackgroundColor = colorFondo;
                    CELL_NUM_OTROS.FixedHeight = 14f;
                    TABLA_INGRESOS_OTROS.AddCell(CELL_NUM_OTROS);

                    PdfPCell CELL_NUM_OTROS_E = new PdfPCell(new Phrase(TEXTO_NUM_E, _mediumFont));
                    CELL_NUM_OTROS_E.HorizontalAlignment = 1;
                    CELL_NUM_OTROS_E.BorderWidth = 0;
                    CELL_NUM_OTROS_E.BackgroundColor = colorFondo;
                    CELL_NUM_OTROS_E.FixedHeight = 14f;
                    TABLA_INGRESOS_OTROS.AddCell(CELL_NUM_OTROS_E);

                    PdfPCell CELL_NOMBRE_OTROS = new PdfPCell(new Phrase(NOMBRE, _mediumFont));
                    //CELL_NOMBRE.HorizontalAlignment = 1;
                    CELL_NOMBRE_OTROS.BorderWidth = 0;
                    CELL_NOMBRE_OTROS.BackgroundColor = colorFondo;
                    CELL_NOMBRE_OTROS.FixedHeight = 14f;
                    TABLA_INGRESOS_OTROS.AddCell(CELL_NOMBRE_OTROS);

                    PdfPCell CELL_CONCEPTO_OTROS = new PdfPCell(new Phrase(CONCEPTO, _mediumFont));
                    //CELL_CONCEPTO.HorizontalAlignment = 1;
                    CELL_CONCEPTO_OTROS.BorderWidth = 0;
                    CELL_CONCEPTO_OTROS.BackgroundColor = colorFondo;
                    CELL_CONCEPTO_OTROS.FixedHeight = 14f;
                    TABLA_INGRESOS_OTROS.AddCell(CELL_CONCEPTO_OTROS);

                    PdfPCell CELL_DEBE_OTROS = new PdfPCell(new Phrase(DEBE, _mediumFont));
                    CELL_DEBE_OTROS.HorizontalAlignment = 1;
                    CELL_DEBE_OTROS.BorderWidth = 0;
                    CELL_DEBE_OTROS.BackgroundColor = colorFondo;
                    CELL_DEBE_OTROS.FixedHeight = 14f;
                    TABLA_INGRESOS_OTROS.AddCell(CELL_DEBE_OTROS);

                    PdfPCell CELL_IMPORTE_OTROS = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", IMPORTE), _mediumFont));
                    CELL_IMPORTE_OTROS.HorizontalAlignment = 2;
                    CELL_IMPORTE_OTROS.BorderWidth = 0;
                    CELL_IMPORTE_OTROS.BackgroundColor = colorFondo;
                    CELL_IMPORTE_OTROS.FixedHeight = 14f;
                    TABLA_INGRESOS_OTROS.AddCell(CELL_IMPORTE_OTROS);

                    PdfPCell CELL_IMPORTE_OTROS_E = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", IMPORTE), _mediumFont));
                    CELL_IMPORTE_OTROS_E.HorizontalAlignment = 2;
                    CELL_IMPORTE_OTROS_E.BorderWidth = 0;
                    CELL_IMPORTE_OTROS_E.BackgroundColor = colorFondo;
                    CELL_IMPORTE_OTROS_E.FixedHeight = 14f;
                    TABLA_INGRESOS_OTROS.AddCell(CELL_IMPORTE_OTROS_E);

                    PdfPCell CELL_OBS_OTROS = new PdfPCell(new Phrase(OBSERVACIONES, _mediumFont));
                    //CELL_OBS.HorizontalAlignment = 1;
                    CELL_OBS_OTROS.BorderWidth = 0;
                    CELL_OBS_OTROS.BackgroundColor = colorFondo;
                    CELL_OBS_OTROS.FixedHeight = 14f;
                    TABLA_INGRESOS_OTROS.AddCell(CELL_OBS_OTROS);

                    PdfPCell CELL_ANULADO_OTROS = new PdfPCell(new Phrase(ANULADO, _mediumFont));
                    //CELL_OBS.HorizontalAlignment = 1;
                    CELL_ANULADO_OTROS.BorderWidth = 0;
                    CELL_ANULADO_OTROS.BackgroundColor = colorFondo;
                    CELL_ANULADO_OTROS.FixedHeight = 14f;
                    TABLA_INGRESOS_OTROS.AddCell(CELL_ANULADO_OTROS);

                    PdfPCell CELL_PAGO_OTROS = new PdfPCell(new Phrase(F_PAGO, _mediumFont));
                    CELL_PAGO_OTROS.HorizontalAlignment = 2;
                    CELL_PAGO_OTROS.BorderWidth = 0;
                    CELL_PAGO_OTROS.BackgroundColor = colorFondo;
                    CELL_PAGO_OTROS.FixedHeight = 14f;
                    TABLA_INGRESOS_OTROS.AddCell(CELL_PAGO_OTROS);

                }
                Paragraph sub2 = new Paragraph("INGRESOS DEL DIA CHEQUES, DEPOSITOS Y TARJETAS", _standardFontBold);
                sub2.Alignment = Element.ALIGN_CENTER;
                sub2.SpacingAfter = 5;
                doc.Add(sub2);
                doc.Add(TABLA_INGRESOS_OTROS);

                #endregion

                #region TOTAL INGRESOS EN OTROS
                PdfPTable TABLA_TOTAL_OTROS = new PdfPTable(4);

                TABLA_TOTAL_OTROS.WidthPercentage = 100;
                TABLA_TOTAL_OTROS.SpacingAfter = 0;
                TABLA_TOTAL_OTROS.SpacingBefore = 0;
                TABLA_TOTAL_OTROS.SetWidths(new float[] { 4f, 4f, 4f, 4f });
                PdfPCell CELDA_TITULO_OTROS = new PdfPCell(new Phrase("3.01.1.01 INGRESOS DEL DIA (DEBE)", _mediumFontBoldWhite));
                PdfPCell CELDA_TOTAL_OTROS = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", TOTAL_INGRESOS_OTROS), _mediumFontBoldWhite));
                PdfPCell CELDA_TITULO_OTROS_E = new PdfPCell(new Phrase("TOTAL FACTURADO", _mediumFontBoldWhite));
                PdfPCell CELDA_TOTAL_OTROS_E = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", TOTAL_OTROS_AFIP), _mediumFontBoldWhite));
                CELDA_TITULO_OTROS.BackgroundColor = topo;
                CELDA_TITULO_OTROS.BorderColor = blanco;
                CELDA_TITULO_OTROS.HorizontalAlignment = 1;
                CELDA_TITULO_OTROS.FixedHeight = 16f;
                CELDA_TOTAL_OTROS.BackgroundColor = topo;
                CELDA_TOTAL_OTROS.BorderColor = blanco;
                CELDA_TOTAL_OTROS.HorizontalAlignment = 1;
                CELDA_TOTAL_OTROS.FixedHeight = 16f;
                CELDA_TITULO_OTROS_E.BackgroundColor = topo;
                CELDA_TITULO_OTROS_E.BorderColor = blanco;
                CELDA_TITULO_OTROS_E.HorizontalAlignment = 1;
                CELDA_TITULO_OTROS_E.FixedHeight = 16f;
                CELDA_TOTAL_OTROS_E.BackgroundColor = topo;
                CELDA_TOTAL_OTROS_E.BorderColor = blanco;
                CELDA_TOTAL_OTROS_E.HorizontalAlignment = 1;
                CELDA_TOTAL_OTROS_E.FixedHeight = 16f;
                TABLA_TOTAL_OTROS.AddCell(CELDA_TITULO_OTROS);
                TABLA_TOTAL_OTROS.AddCell(CELDA_TOTAL_OTROS);
                TABLA_TOTAL_OTROS.AddCell(CELDA_TITULO_OTROS_E);
                TABLA_TOTAL_OTROS.AddCell(CELDA_TOTAL_OTROS_E);
                doc.Add(TABLA_TOTAL_OTROS);

                #endregion

                #region DATOS EGRESOS
                if (VGlobales.vp_role == "CAJA")
                {
                    X = 0;
                    foreach (DataRow row in EGRESOS.Tables[0].Rows)
                    {
                        NUM = row[0].ToString();
                        NOMBRE = row[1].ToString();
                        CONCEPTO = row[2].ToString();
                        DEBE = row[3].ToString();
                        IMPORTE = Convert.ToDecimal(row[4]);
                        OBSERVACIONES = row[5].ToString();
                        TIPO = row[6].ToString();
                        ANULADO = row[10].ToString();
                        PTO_VTA = row[12].ToString();
                        string BANCO_DEPO = row[13].ToString();
                        F_PAGO = row[11].ToString();

                        if (BANCO_DEPO.Trim() == "PATAGONIA")
                        {
                            DEBE = "301207";
                        }

                        if (BANCO_DEPO.Trim() == "NACIÓN")
                        {
                            DEBE = "301205";
                        }

                        if (X == 0)
                        {
                            colorFondo = new BaseColor(255, 255, 255);
                            X++;
                        }
                        else
                        {
                            colorFondo = new BaseColor(240, 240, 240);
                            X--;
                        }

                        PdfPCell CELL_NUM_EGRESOS = new PdfPCell(new Phrase(TIPO + "" + PTO_VTA + "-" + NUM, _mediumFont));
                        CELL_NUM_EGRESOS.HorizontalAlignment = 1;
                        CELL_NUM_EGRESOS.BorderWidth = 0;
                        CELL_NUM_EGRESOS.BackgroundColor = colorFondo;
                        CELL_NUM_EGRESOS.FixedHeight = 14f;
                        TABLA_EGRESOS.AddCell(CELL_NUM_EGRESOS);

                        PdfPCell CELL_CONCEPTO_EGRESOS = new PdfPCell(new Phrase(BANCO_DEPO, _mediumFont));
                        CELL_CONCEPTO_EGRESOS.BorderWidth = 0;
                        CELL_CONCEPTO_EGRESOS.BackgroundColor = colorFondo;
                        CELL_CONCEPTO_EGRESOS.FixedHeight = 14f;
                        TABLA_EGRESOS.AddCell(CELL_CONCEPTO_EGRESOS);

                        PdfPCell CELL_DEBE_EGRESOS = new PdfPCell(new Phrase(DEBE, _mediumFont));
                        CELL_DEBE_EGRESOS.HorizontalAlignment = 1;
                        CELL_DEBE_EGRESOS.BorderWidth = 0;
                        CELL_DEBE_EGRESOS.BackgroundColor = colorFondo;
                        CELL_DEBE_EGRESOS.FixedHeight = 14f;
                        TABLA_EGRESOS.AddCell(CELL_DEBE_EGRESOS);

                        PdfPCell CELL_IMPORTE_EGRESOS = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", IMPORTE), _mediumFont));
                        CELL_IMPORTE_EGRESOS.HorizontalAlignment = 2;
                        CELL_IMPORTE_EGRESOS.BorderWidth = 0;
                        CELL_IMPORTE_EGRESOS.BackgroundColor = colorFondo;
                        CELL_IMPORTE_EGRESOS.FixedHeight = 14f;
                        TABLA_EGRESOS.AddCell(CELL_IMPORTE_EGRESOS);

                        PdfPCell CELL_OBS_EGRESOS = new PdfPCell(new Phrase(OBSERVACIONES, _mediumFont));
                        CELL_OBS_EGRESOS.BorderWidth = 0;
                        CELL_OBS_EGRESOS.BackgroundColor = colorFondo;
                        CELL_OBS_EGRESOS.FixedHeight = 14f;
                        TABLA_EGRESOS.AddCell(CELL_OBS_EGRESOS);

                        PdfPCell CELL_ANULADO_EGRESOS = new PdfPCell(new Phrase(ANULADO, _mediumFont));
                        CELL_ANULADO_EGRESOS.BorderWidth = 0;
                        CELL_ANULADO_EGRESOS.BackgroundColor = colorFondo;
                        CELL_ANULADO_EGRESOS.FixedHeight = 14f;
                        TABLA_EGRESOS.AddCell(CELL_ANULADO_EGRESOS);

                        PdfPCell CELL_PAGO_EGRESOS = new PdfPCell(new Phrase(F_PAGO, _mediumFont));
                        CELL_PAGO_EGRESOS.HorizontalAlignment = 2;
                        CELL_PAGO_EGRESOS.BorderWidth = 0;
                        CELL_PAGO_EGRESOS.BackgroundColor = colorFondo;
                        CELL_PAGO_EGRESOS.FixedHeight = 14f;
                        TABLA_EGRESOS.AddCell(CELL_PAGO_EGRESOS);
                    }

                    Paragraph sub3 = new Paragraph("EGRESOS", _standardFontBold);
                    sub3.Alignment = Element.ALIGN_CENTER;
                    sub3.SpacingAfter = 5;
                    doc.Add(sub3);
                    doc.Add(TABLA_EGRESOS);
                }
                #endregion

                #region CAJAS DEPOSITADAS

                if (CAJAS_DEPOSITADAS.Tables[0].Rows.Count > 0)
                {
                    X = 0;
                    foreach (DataRow row in CAJAS_DEPOSITADAS.Tables[0].Rows)
                    {
                        string FECHA_CAJA = row[0].ToString().Substring(0, 10);
                        decimal TOTAL_CAJA = decimal.Parse(row[1].ToString());
                        string IMPUTACION = row[2].ToString();
                        string BANCO = row[3].ToString();

                        if (X == 0)
                        {
                            colorFondo = new BaseColor(255, 255, 255);
                            X++;
                        }
                        else
                        {
                            colorFondo = new BaseColor(240, 240, 240);
                            X--;
                        }

                        PdfPCell CELL_FECHA_CAJA = new PdfPCell(new Phrase("CAJA DEL DIA " + FECHA_CAJA, _mediumFont));
                        CELL_FECHA_CAJA.HorizontalAlignment = 0;
                        CELL_FECHA_CAJA.BorderWidth = 0;
                        CELL_FECHA_CAJA.BackgroundColor = colorFondo;
                        CELL_FECHA_CAJA.FixedHeight = 14f;
                        TABLA_CAJAS_DEPOSITADAS.AddCell(CELL_FECHA_CAJA);

                        PdfPCell CELL_IMPUTACION_CAJA = new PdfPCell(new Phrase(IMPUTACION, _mediumFont));
                        CELL_IMPUTACION_CAJA.HorizontalAlignment = 1;
                        CELL_IMPUTACION_CAJA.BorderWidth = 0;
                        CELL_IMPUTACION_CAJA.BackgroundColor = colorFondo;
                        CELL_IMPUTACION_CAJA.FixedHeight = 14f;
                        TABLA_CAJAS_DEPOSITADAS.AddCell(CELL_IMPUTACION_CAJA);

                        PdfPCell CELL_BANCO_CAJA = new PdfPCell(new Phrase(BANCO, _mediumFont));
                        CELL_BANCO_CAJA.HorizontalAlignment = 1;
                        CELL_BANCO_CAJA.BorderWidth = 0;
                        CELL_BANCO_CAJA.BackgroundColor = colorFondo;
                        CELL_BANCO_CAJA.FixedHeight = 14f;
                        TABLA_CAJAS_DEPOSITADAS.AddCell(CELL_BANCO_CAJA);

                        PdfPCell CELL_TOTAL_CAJA = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", TOTAL_CAJA), _mediumFont));
                        CELL_TOTAL_CAJA.HorizontalAlignment = 2;
                        CELL_TOTAL_CAJA.BorderWidth = 0;
                        CELL_TOTAL_CAJA.BackgroundColor = colorFondo;
                        CELL_TOTAL_CAJA.FixedHeight = 14f;
                        TABLA_CAJAS_DEPOSITADAS.AddCell(CELL_TOTAL_CAJA);
                    }

                    Paragraph sub4 = new Paragraph("CAJAS DEPOSITADAS", _standardFontBold);
                    sub4.Alignment = Element.ALIGN_CENTER;
                    sub4.SpacingAfter = 5;
                    doc.Add(sub4);
                    doc.Add(TABLA_CAJAS_DEPOSITADAS);
                }
                #endregion

                #region TOTAL EGRESOS
                PdfPTable TABLA_TOTAL_EGRESOS = new PdfPTable(2);
                if (VGlobales.vp_role == "CAJA")
                {
                    TABLA_TOTAL_EGRESOS.WidthPercentage = 100;
                    TABLA_TOTAL_EGRESOS.SpacingAfter = 0;
                    TABLA_TOTAL_EGRESOS.SpacingBefore = 0;
                    TABLA_TOTAL_EGRESOS.SetWidths(new float[] { 4f, 4f });
                    PdfPCell CELDA_TITULO_EGRESOS = new PdfPCell(new Phrase("3.01.1.01 EGRESOS DEL DIA TOTAL (HABER)", _mediumFontBoldWhite));
                    PdfPCell CELDA_TOTAL_EGRESOS = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", TOTAL_EGRESOS), _mediumFontBoldWhite));
                    CELDA_TITULO_EGRESOS.BackgroundColor = topo;
                    CELDA_TITULO_EGRESOS.BorderColor = blanco;
                    CELDA_TITULO_EGRESOS.HorizontalAlignment = 1;
                    CELDA_TITULO_EGRESOS.FixedHeight = 16f;
                    CELDA_TOTAL_EGRESOS.BackgroundColor = topo;
                    CELDA_TOTAL_EGRESOS.BorderColor = blanco;
                    CELDA_TOTAL_EGRESOS.HorizontalAlignment = 1;
                    CELDA_TOTAL_EGRESOS.FixedHeight = 16f;
                    TABLA_TOTAL_EGRESOS.AddCell(CELDA_TITULO_EGRESOS);
                    TABLA_TOTAL_EGRESOS.AddCell(CELDA_TOTAL_EGRESOS);
                    doc.Add(TABLA_TOTAL_EGRESOS);
                }
                #endregion

                #region DATOS COMPOSICION DE SALDO
                decimal TOTAL_COMPOSICION = 0;

                X = 0;
                string CAMBIO_CAJA = "0";
                decimal TOTAL_CHEQUES = 0;
                string DETALLE_CHEQUE = "";
                string IMPORTE_CHEQUE = "";
                string FECHA_CHEQUE = "";

                foreach (DataRow cambio in CAMBIO_DS.Tables[0].Rows)
                {
                    CAMBIO_CAJA = string.Format("{0:n}", Convert.ToDecimal(cambio[0].ToString()));
                }

                if (VGlobales.vp_role == "CAJA")
                {
                    foreach (DataRow cheques in CHEQUES.Tables[0].Rows)
                    {
                        if (cheques[3].ToString() != "")
                        {
                            IMPORTE_CHEQUE = string.Format("{0:n}", Convert.ToDecimal(cheques[3].ToString()));
                            DETALLE_CHEQUE = cheques[1].ToString();
                            FECHA_CHEQUE = cheques[2].ToString().Substring(0, 9);

                            if (X == 0)
                            {
                                colorFondo = new BaseColor(255, 255, 255);
                                X++;
                            }
                            else
                            {
                                colorFondo = new BaseColor(240, 240, 240);
                                X--;
                            }

                            PdfPCell CELL_CHEQUE = new PdfPCell(new Phrase(DETALLE_CHEQUE + " " + FECHA_CHEQUE, _mediumFont));
                            CELL_CHEQUE.HorizontalAlignment = 0;
                            CELL_CHEQUE.BorderWidth = 0;
                            CELL_CHEQUE.BackgroundColor = colorFondo;
                            CELL_CHEQUE.FixedHeight = 14f;
                            TABLA_COMPOSICION.AddCell(CELL_CHEQUE);

                            PdfPCell CELL_IMPORTE_CHEQUE = new PdfPCell(new Phrase("$ " + IMPORTE_CHEQUE, _mediumFont));
                            CELL_IMPORTE_CHEQUE.HorizontalAlignment = 2;
                            CELL_IMPORTE_CHEQUE.BorderWidth = 0;
                            CELL_IMPORTE_CHEQUE.BackgroundColor = colorFondo;
                            CELL_IMPORTE_CHEQUE.FixedHeight = 14f;
                            TABLA_COMPOSICION.AddCell(CELL_IMPORTE_CHEQUE);

                            //SUMA
                            TOTAL_CHEQUES = TOTAL_CHEQUES + Convert.ToDecimal(IMPORTE_CHEQUE);
                        }
                    }
                }

                foreach (DataRow row in COMPOSICION_DS.Tables[0].Rows)
                {
                    string FECHA_CAJA = row[0].ToString().Substring(0, 10);
                    string TOTAL_EFECTIVO = string.Format("{0:n}", Convert.ToDecimal(row[1].ToString()));

                    if (X == 0)
                    {
                        colorFondo = new BaseColor(255, 255, 255);
                        X++;
                    }
                    else
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                        X--;
                    }

                    PdfPCell CELL_FECHA_COMPOSICION = new PdfPCell(new Phrase("CAJA DEL DÍA " + FECHA_CAJA, _mediumFont));
                    CELL_FECHA_COMPOSICION.HorizontalAlignment = 0;
                    CELL_FECHA_COMPOSICION.BorderWidth = 0;
                    CELL_FECHA_COMPOSICION.BackgroundColor = colorFondo;
                    CELL_FECHA_COMPOSICION.FixedHeight = 14f;
                    TABLA_COMPOSICION.AddCell(CELL_FECHA_COMPOSICION);

                    PdfPCell CELL_SALDO_COMPOSICION = new PdfPCell(new Phrase("$ " + TOTAL_EFECTIVO, _mediumFont));
                    CELL_SALDO_COMPOSICION.HorizontalAlignment = 2;
                    CELL_SALDO_COMPOSICION.BorderWidth = 0;
                    CELL_SALDO_COMPOSICION.BackgroundColor = colorFondo;
                    CELL_SALDO_COMPOSICION.FixedHeight = 14f;
                    TABLA_COMPOSICION.AddCell(CELL_SALDO_COMPOSICION);

                    //SUMA
                    TOTAL_COMPOSICION = TOTAL_COMPOSICION + Convert.ToDecimal(TOTAL_EFECTIVO);
                }

                if (X == 0)
                {
                    colorFondo = new BaseColor(255, 255, 255);
                    X++;
                }
                else
                {
                    colorFondo = new BaseColor(240, 240, 240);
                    X--;
                }

                string EFECTIVO_DEL_DIA = dgCajasAnteriores[4, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString();
                TOTAL_COMPOSICION = TOTAL_COMPOSICION + TOTAL_CHEQUES + Convert.ToDecimal(CAMBIO_CAJA) + Convert.ToDecimal(EFECTIVO_DEL_DIA);
                string FECHA_CAJA_SELECCIONADA = dgCajasAnteriores[1, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString();

                PdfPCell CELL_CAJA_DEL_DIA = new PdfPCell(new Phrase("CAJA DEL DÍA " + FECHA_CAJA_SELECCIONADA, _mediumFont));
                CELL_CAJA_DEL_DIA.HorizontalAlignment = 0;
                CELL_CAJA_DEL_DIA.BorderWidth = 0;
                CELL_CAJA_DEL_DIA.BackgroundColor = colorFondo;
                CELL_CAJA_DEL_DIA.FixedHeight = 14f;
                TABLA_COMPOSICION.AddCell(CELL_CAJA_DEL_DIA);

                PdfPCell CELL_EFECTIVO_DEL_DIA = new PdfPCell(new Phrase("$ " + EFECTIVO_DEL_DIA, _mediumFont));
                CELL_EFECTIVO_DEL_DIA.HorizontalAlignment = 2;
                CELL_EFECTIVO_DEL_DIA.BorderWidth = 0;
                CELL_EFECTIVO_DEL_DIA.BackgroundColor = colorFondo;
                CELL_EFECTIVO_DEL_DIA.FixedHeight = 14f;
                TABLA_COMPOSICION.AddCell(CELL_EFECTIVO_DEL_DIA);

                PdfPCell CELL_TITULO_CAMBIO_COMPOSICION = new PdfPCell(new Phrase("CAMBIO", _mediumFont));
                CELL_TITULO_CAMBIO_COMPOSICION.HorizontalAlignment = 0;
                CELL_TITULO_CAMBIO_COMPOSICION.BorderWidth = 0;
                CELL_TITULO_CAMBIO_COMPOSICION.BackgroundColor = colorFondo;
                CELL_TITULO_CAMBIO_COMPOSICION.FixedHeight = 14f;
                TABLA_COMPOSICION.AddCell(CELL_TITULO_CAMBIO_COMPOSICION);

                PdfPCell CELL_CAMBIO_COMPOSICION = new PdfPCell(new Phrase("$ " + CAMBIO_CAJA, _mediumFont));
                CELL_CAMBIO_COMPOSICION.HorizontalAlignment = 2;
                CELL_CAMBIO_COMPOSICION.BorderWidth = 0;
                CELL_CAMBIO_COMPOSICION.BackgroundColor = colorFondo;
                CELL_CAMBIO_COMPOSICION.FixedHeight = 14f;
                TABLA_COMPOSICION.AddCell(CELL_CAMBIO_COMPOSICION);

                PdfPCell CELDA_TITULO_COMPOSICION = new PdfPCell(new Phrase("TOTAL", _mediumFontBoldWhite));
                CELDA_TITULO_COMPOSICION.BackgroundColor = topo;
                CELDA_TITULO_COMPOSICION.BorderColor = blanco;
                CELDA_TITULO_COMPOSICION.HorizontalAlignment = 0;
                CELDA_TITULO_COMPOSICION.FixedHeight = 16f;
                TABLA_COMPOSICION.AddCell(CELDA_TITULO_COMPOSICION);

                PdfPCell CELDA_TOTAL_COMPOSICION = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", TOTAL_COMPOSICION), _mediumFontBoldWhite));
                CELDA_TOTAL_COMPOSICION.BackgroundColor = topo;
                CELDA_TOTAL_COMPOSICION.BorderColor = blanco;
                CELDA_TOTAL_COMPOSICION.HorizontalAlignment = 2;
                CELDA_TOTAL_COMPOSICION.FixedHeight = 16f;
                TABLA_COMPOSICION.AddCell(CELDA_TOTAL_COMPOSICION);

                Paragraph subx = new Paragraph("COMPOSICION DE SALDO AL " + FECHA, _standardFontBold);
                subx.Alignment = Element.ALIGN_CENTER;
                subx.SpacingAfter = 5;
                doc.Add(subx);
                doc.Add(TABLA_COMPOSICION);
                #endregion

                #region DATOS CHEQUES EN COMPO
                if (VGlobales.vp_role == "CAJA")
                {
                    X = 0;
                    foreach (DataRow row in CHEQUES_COMPOSICION.Tables[0].Rows)
                    {
                        NUM = row[0].ToString();
                        NOMBRE = row[1].ToString();
                        CONCEPTO = row[2].ToString();
                        DEBE = row[3].ToString();
                        IMPORTE = Convert.ToDecimal(row[4]);
                        OBSERVACIONES = row[5].ToString();

                        if (X == 0)
                        {
                            colorFondo = new BaseColor(255, 255, 255);
                            X++;
                        }
                        else
                        {
                            colorFondo = new BaseColor(240, 240, 240);
                            X--;
                        }

                        PdfPCell CELL_NUM_CP = new PdfPCell(new Phrase(NUM, _mediumFont));
                        CELL_NUM_CP.HorizontalAlignment = 1;
                        CELL_NUM_CP.BorderWidth = 0;
                        CELL_NUM_CP.BackgroundColor = colorFondo;
                        CELL_NUM_CP.FixedHeight = 14f;
                        TABLA_CHEQUES_COMPO.AddCell(CELL_NUM_CP);

                        PdfPCell CELL_NOMBRE_CP = new PdfPCell(new Phrase(NOMBRE, _mediumFont));
                        //CELL_NOMBRE.HorizontalAlignment = 1;
                        CELL_NOMBRE_CP.BorderWidth = 0;
                        CELL_NOMBRE_CP.BackgroundColor = colorFondo;
                        CELL_NOMBRE_CP.FixedHeight = 14f;
                        TABLA_CHEQUES_COMPO.AddCell(CELL_NOMBRE_CP);

                        PdfPCell CELL_CONCEPTO_CP = new PdfPCell(new Phrase(CONCEPTO, _mediumFont));
                        //CELL_CONCEPTO.HorizontalAlignment = 1;
                        CELL_CONCEPTO_CP.BorderWidth = 0;
                        CELL_CONCEPTO_CP.BackgroundColor = colorFondo;
                        CELL_CONCEPTO_CP.FixedHeight = 14f;
                        TABLA_CHEQUES_COMPO.AddCell(CELL_CONCEPTO_CP);

                        PdfPCell CELL_DEBE_CP = new PdfPCell(new Phrase(DEBE, _mediumFont));
                        CELL_DEBE_CP.HorizontalAlignment = 1;
                        CELL_DEBE_CP.BorderWidth = 0;
                        CELL_DEBE_CP.BackgroundColor = colorFondo;
                        CELL_DEBE_CP.FixedHeight = 14f;
                        TABLA_CHEQUES_COMPO.AddCell(CELL_DEBE_CP);

                        PdfPCell CELL_IMPORTE_CP = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", IMPORTE), _mediumFont));
                        CELL_IMPORTE_CP.HorizontalAlignment = 2;
                        CELL_IMPORTE_CP.BorderWidth = 0;
                        CELL_IMPORTE_CP.BackgroundColor = colorFondo;
                        CELL_IMPORTE_CP.FixedHeight = 14f;
                        TABLA_CHEQUES_COMPO.AddCell(CELL_IMPORTE_CP);

                        PdfPCell CELL_OBS_CP = new PdfPCell(new Phrase(OBSERVACIONES, _mediumFont));
                        //CELL_OBS.HorizontalAlignment = 1;
                        CELL_OBS_CP.BorderWidth = 0;
                        CELL_OBS_CP.BackgroundColor = colorFondo;
                        CELL_OBS_CP.FixedHeight = 14f;
                        TABLA_CHEQUES_COMPO.AddCell(CELL_OBS_CP);
                    }

                    Paragraph subc = new Paragraph("CHEQUES EN COMPOSICION AL " + FECHA, _standardFontBold);
                    subc.Alignment = Element.ALIGN_CENTER;
                    subc.SpacingAfter = 5;
                    doc.Add(subc);
                    doc.Add(TABLA_CHEQUES_COMPO);
                }

                #endregion

                #region TOTALES AL DIA

                decimal INGRESOS_EFECTIVO = 0;
                decimal INGRESOS_OTROS = 0;
                decimal SUBTOTAL_INGRESOS = 0;
                decimal EGRESOS_DIA = 0;
                decimal SALDO_CAJA_DIA = decimal.Parse(dgCajasAnteriores[9, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString());
                decimal TOTAL_CAJA_DIA = 0;
                decimal CAJA_DIA = decimal.Parse(dgCajasAnteriores[6, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString());
                int INDEX = 1;

                if (dgCajasAnteriores.Rows.Count == 1)
                {
                    INDEX = 0;
                }

                decimal SALDO_ANTERIOR = decimal.Parse(dgCajasAnteriores[9, dgCajasAnteriores.CurrentCell.RowIndex + INDEX].Value.ToString());

                foreach (DataRow row in TOTALES_DIA.Tables[0].Rows)
                {
                    INGRESOS_EFECTIVO = Convert.ToDecimal(row[0]);
                    INGRESOS_OTROS = Convert.ToDecimal(row[1]);
                    SUBTOTAL_INGRESOS = Convert.ToDecimal(row[2]);
                    EGRESOS_DIA = Convert.ToDecimal(row[3]);
                    TOTAL_CAJA_DIA = Convert.ToDecimal(row[5]);
                }

                PdfPCell CELDA_TITULO_INGRESOS_EFECTIVO = new PdfPCell(new Phrase("TOTAL INGRESOS EN EFECTIVO", _mediumFont));
                CELDA_TITULO_INGRESOS_EFECTIVO.BackgroundColor = new BaseColor(240, 240, 240);
                CELDA_TITULO_INGRESOS_EFECTIVO.BorderColor = blanco;
                CELDA_TITULO_INGRESOS_EFECTIVO.HorizontalAlignment = 0;
                CELDA_TITULO_INGRESOS_EFECTIVO.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_INGRESOS_EFECTIVO);

                PdfPCell CELDA_TOTAL_INGRESOS_EFECTIVO = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", INGRESOS_EFECTIVO), _mediumFont));
                CELDA_TOTAL_INGRESOS_EFECTIVO.BackgroundColor = new BaseColor(240, 240, 240);
                CELDA_TOTAL_INGRESOS_EFECTIVO.BorderColor = blanco;
                CELDA_TOTAL_INGRESOS_EFECTIVO.HorizontalAlignment = 2;
                CELDA_TOTAL_INGRESOS_EFECTIVO.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TOTAL_INGRESOS_EFECTIVO);

                if (VGlobales.vp_role == "CAJA")
                {
                    PdfPCell CELDA_TITULO_FACTURADO_EFECTIVO = new PdfPCell(new Phrase("TOTAL FACTURADO EN EFECTIVO", _mediumFont));
                    CELDA_TITULO_FACTURADO_EFECTIVO.BackgroundColor = blanco;
                    CELDA_TITULO_FACTURADO_EFECTIVO.BorderColor = blanco;
                    CELDA_TITULO_FACTURADO_EFECTIVO.HorizontalAlignment = 0;
                    CELDA_TITULO_FACTURADO_EFECTIVO.FixedHeight = 16f;
                    TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_FACTURADO_EFECTIVO);

                    PdfPCell CELDA_TOTAL_FACTURADO_EFECTIVO = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", TOTAL_EFECTIVO_AFIP), _mediumFont));
                    CELDA_TOTAL_FACTURADO_EFECTIVO.BackgroundColor = blanco;
                    CELDA_TOTAL_FACTURADO_EFECTIVO.BorderColor = blanco;
                    CELDA_TOTAL_FACTURADO_EFECTIVO.HorizontalAlignment = 2;
                    CELDA_TOTAL_FACTURADO_EFECTIVO.FixedHeight = 16f;
                    TABLA_TOTALES_DIA.AddCell(CELDA_TOTAL_FACTURADO_EFECTIVO);

                    PdfPCell CELDA_TITULO_INGRESOS_OTROS = new PdfPCell(new Phrase("TOTAL INGRESOS CHEQUES Y OTROS", _mediumFont));
                    CELDA_TITULO_INGRESOS_OTROS.BackgroundColor = new BaseColor(240, 240, 240);
                    CELDA_TITULO_INGRESOS_OTROS.BorderColor = blanco;
                    CELDA_TITULO_INGRESOS_OTROS.HorizontalAlignment = 0;
                    CELDA_TITULO_INGRESOS_OTROS.FixedHeight = 16f;
                    TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_INGRESOS_OTROS);

                    PdfPCell CELDA_TOTAL_INGRESOS_OTROS = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", INGRESOS_OTROS), _mediumFont));
                    CELDA_TOTAL_INGRESOS_OTROS.BackgroundColor = new BaseColor(240, 240, 240);
                    CELDA_TOTAL_INGRESOS_OTROS.BorderColor = blanco;
                    CELDA_TOTAL_INGRESOS_OTROS.HorizontalAlignment = 2;
                    CELDA_TOTAL_INGRESOS_OTROS.FixedHeight = 16f;
                    TABLA_TOTALES_DIA.AddCell(CELDA_TOTAL_INGRESOS_OTROS);

                    PdfPCell CELDA_TITULO_FACTURADO_OTROS = new PdfPCell(new Phrase("TOTAL FACTURADO CHEQUES Y OTROS", _mediumFont));
                    CELDA_TITULO_FACTURADO_OTROS.BackgroundColor = blanco;
                    CELDA_TITULO_FACTURADO_OTROS.BorderColor = blanco;
                    CELDA_TITULO_FACTURADO_OTROS.HorizontalAlignment = 0;
                    CELDA_TITULO_FACTURADO_OTROS.FixedHeight = 16f;
                    TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_FACTURADO_OTROS);

                    PdfPCell CELDA_TOTAL_FACTURADO_OTROS = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", TOTAL_OTROS_AFIP), _mediumFont));
                    CELDA_TOTAL_FACTURADO_OTROS.BackgroundColor = blanco;
                    CELDA_TOTAL_FACTURADO_OTROS.BorderColor = blanco;
                    CELDA_TOTAL_FACTURADO_OTROS.HorizontalAlignment = 2;
                    CELDA_TOTAL_FACTURADO_OTROS.FixedHeight = 16f;
                    TABLA_TOTALES_DIA.AddCell(CELDA_TOTAL_FACTURADO_OTROS);
                }

                PdfPCell CELDA_TITULO_SUBTOTAL_INGRESOS = new PdfPCell(new Phrase("SUBTOTAL INGRESOS DEL DÍA", _mediumFont));
                CELDA_TITULO_SUBTOTAL_INGRESOS.BackgroundColor = new BaseColor(240, 240, 240);
                CELDA_TITULO_SUBTOTAL_INGRESOS.BorderColor = blanco;
                CELDA_TITULO_SUBTOTAL_INGRESOS.HorizontalAlignment = 0;
                CELDA_TITULO_SUBTOTAL_INGRESOS.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_SUBTOTAL_INGRESOS);

                PdfPCell CELDA_TOTAL_SUBTOTAL_INGRESOS = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", SUBTOTAL_INGRESOS), _mediumFont));
                CELDA_TOTAL_SUBTOTAL_INGRESOS.BackgroundColor = new BaseColor(240, 240, 240);
                CELDA_TOTAL_SUBTOTAL_INGRESOS.BorderColor = blanco;
                CELDA_TOTAL_SUBTOTAL_INGRESOS.HorizontalAlignment = 2;
                CELDA_TOTAL_SUBTOTAL_INGRESOS.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TOTAL_SUBTOTAL_INGRESOS);

                if (VGlobales.vp_role == "CAJA")
                {
                    PdfPCell CELDA_TITULO_EGRESOS_DEL_DIA = new PdfPCell(new Phrase("EGRESOS DEL DIA", _mediumFont));
                    CELDA_TITULO_EGRESOS_DEL_DIA.BackgroundColor = blanco;
                    CELDA_TITULO_EGRESOS_DEL_DIA.BorderColor = blanco;
                    CELDA_TITULO_EGRESOS_DEL_DIA.HorizontalAlignment = 0;
                    CELDA_TITULO_EGRESOS_DEL_DIA.FixedHeight = 16f;
                    TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_EGRESOS_DEL_DIA);

                    PdfPCell CELDA_TOTAL_EGRESOS_DEL_DIA = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", EGRESOS_DIA), _mediumFont));
                    CELDA_TOTAL_EGRESOS_DEL_DIA.BackgroundColor = blanco;
                    CELDA_TOTAL_EGRESOS_DEL_DIA.BorderColor = blanco;
                    CELDA_TOTAL_EGRESOS_DEL_DIA.HorizontalAlignment = 2;
                    CELDA_TOTAL_EGRESOS_DEL_DIA.FixedHeight = 16f;
                    TABLA_TOTALES_DIA.AddCell(CELDA_TOTAL_EGRESOS_DEL_DIA);
                }

                PdfPCell CELDA_TITULO_CAJA_DEL_DIA = new PdfPCell(new Phrase("TOTAL DEL DIA", _mediumFont));
                CELDA_TITULO_CAJA_DEL_DIA.BackgroundColor = new BaseColor(240, 240, 240);
                CELDA_TITULO_CAJA_DEL_DIA.BorderColor = blanco;
                CELDA_TITULO_CAJA_DEL_DIA.HorizontalAlignment = 0;
                CELDA_TITULO_CAJA_DEL_DIA.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_CAJA_DEL_DIA);

                PdfPCell CELDA_CAJA_DEL_DIA = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", CAJA_DIA), _mediumFont));
                CELDA_CAJA_DEL_DIA.BackgroundColor = new BaseColor(240, 240, 240);
                CELDA_CAJA_DEL_DIA.BorderColor = blanco;
                CELDA_CAJA_DEL_DIA.HorizontalAlignment = 2;
                CELDA_CAJA_DEL_DIA.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_CAJA_DEL_DIA);

                PdfPCell CELDA_TITULO_SALDO_ANTERIOR = new PdfPCell(new Phrase("SALDO DEL DIA ANTERIOR", _mediumFont));
                CELDA_TITULO_SALDO_ANTERIOR.BackgroundColor = blanco;
                CELDA_TITULO_SALDO_ANTERIOR.BorderColor = blanco;
                CELDA_TITULO_SALDO_ANTERIOR.HorizontalAlignment = 0;
                CELDA_TITULO_SALDO_ANTERIOR.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_SALDO_ANTERIOR);

                PdfPCell CELDA_SALDO_ANTERIOR = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", SALDO_ANTERIOR), _mediumFont));
                CELDA_SALDO_ANTERIOR.BackgroundColor = blanco;
                CELDA_SALDO_ANTERIOR.BorderColor = blanco;
                CELDA_SALDO_ANTERIOR.HorizontalAlignment = 2;
                CELDA_SALDO_ANTERIOR.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_SALDO_ANTERIOR);

                PdfPCell CELDA_TITULO_SALDO_CAJA_DIA = new PdfPCell(new Phrase("SALDO DE LA FECHA", _mediumFont));
                CELDA_TITULO_SALDO_CAJA_DIA.BackgroundColor = new BaseColor(240, 240, 240);
                CELDA_TITULO_SALDO_CAJA_DIA.BorderColor = blanco;
                CELDA_TITULO_SALDO_CAJA_DIA.HorizontalAlignment = 0;
                CELDA_TITULO_SALDO_CAJA_DIA.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_SALDO_CAJA_DIA);

                PdfPCell CELDA_TOTAL_SALDO_CAJA_DIA = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", SALDO_CAJA_DIA), _mediumFont));
                CELDA_TOTAL_SALDO_CAJA_DIA.BackgroundColor = new BaseColor(240, 240, 240);
                CELDA_TOTAL_SALDO_CAJA_DIA.BorderColor = blanco;
                CELDA_TOTAL_SALDO_CAJA_DIA.HorizontalAlignment = 2;
                CELDA_TOTAL_SALDO_CAJA_DIA.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TOTAL_SALDO_CAJA_DIA);

                doc.Add(TABLA_TOTALES_DIA);
                #endregion

                #region FIRMAS
                PdfPTable TABLA_FIRMAS = new PdfPTable(2);
                TABLA_FIRMAS.WidthPercentage = 100;
                TABLA_FIRMAS.SpacingAfter = 0;
                TABLA_FIRMAS.SpacingBefore = 60;
                TABLA_FIRMAS.SetWidths(new float[] { 2f, 2f });
                PdfPCell CELDA_CAJERO = new PdfPCell(new Phrase("FIRMA CAJERO", _mediumFontBold));
                PdfPCell CELDA_TESORERO = new PdfPCell(new Phrase("FIRMA TESORERO", _mediumFontBold));
                CELDA_CAJERO.BackgroundColor = blanco;
                CELDA_CAJERO.BorderColor = blanco;
                CELDA_CAJERO.HorizontalAlignment = 1;
                CELDA_CAJERO.FixedHeight = 16f;
                CELDA_TESORERO.BackgroundColor = blanco;
                CELDA_TESORERO.BorderColor = blanco;
                CELDA_TESORERO.HorizontalAlignment = 1;
                CELDA_TESORERO.FixedHeight = 16f;
                TABLA_FIRMAS.AddCell(CELDA_CAJERO);
                TABLA_FIRMAS.AddCell(CELDA_TESORERO);
                doc.Add(TABLA_FIRMAS);
                #endregion

                doc.Close();
                writer.Close();
                AddPageNumber(PATH);
                Cursor = Cursors.Default;

                DialogResult result = MessageBox.Show("PLANILLA DE CAJA CREADA CORRECTAMENTE \n\n ¿ABRIR EL ARCHIVO? \n\n " + PATH, "LISTO!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Process.Start(PATH);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void btnEliminarCaja_Click(object sender, EventArgs e)
        {
            decimal TOTAL = decimal.Parse(tbTotal.Text);
            decimal CAJA = decimal.Parse(dgComposicion.CurrentRow.Cells[2].Value.ToString());

            if (MessageBox.Show("¿ELIMIAR LA CAJA SELECCIONADA\nDE COMPOSICION DE SALDO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dgComposicion.Rows.RemoveAt(dgComposicion.CurrentRow.Index);
                tbTotal.Text = (TOTAL - CAJA).ToString();
            }
        }

        private void agregarCambio()
        {
            try
            {
                string INSERT = "SI";

                foreach (DataGridViewRow row in dgComposicion.Rows)
                {
                    if (row.Cells[1].Value.ToString().Contains("CAMBIO"))
                    {
                        INSERT = "NO";
                    }
                }

                if (INSERT == "SI")
                {
                    dgComposicion.Rows.Add("", "CAMBIO", string.Format("{0:n}", (Convert.ToDecimal(tbCambio.Text.Trim()))));
                    tbTotal.Text = (decimal.Parse(tbTotal.Text) + decimal.Parse(tbCambio.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO SE PUDO AGREGAR EL CAMBIO A LA COMPOSICION\n" + ex, "ERROR!");
            }
        }

        private void btnAgregarCheque_Click(object sender, EventArgs e)
        {
            int ID = 0;
            string COMP = "0";
            int BANCO = int.Parse(cbBancos.SelectedValue.ToString());

            if (tbCompCheque.Text == "")
            {
                MessageBox.Show("INGRESAR UN NRO DE COMPROBANTE");
            }
            else
            {
                COMP = tbCompCheque.Text;

                try
                {
                    foreach (DataGridViewRow row in dgCheques.SelectedRows)
                    {
                        ID = int.Parse(row.Cells[9].Value.ToString());
                        BO_CAJA.depositarCheque(ID, 1, BANCO, COMP);
                    }

                    cargaInicial(0);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cargaInicial(0);
        }

        private void btnAgregarChequeAComposicion_Click(object sender, EventArgs e)
        {
            agregarChequesAComposicion();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            excelCaja(0);
        }

        private void excelCaja(int CAJA)
        {
            decimal INGRESOS_EFECTIVO_DS = 0;
            decimal INGRESOS_OTROS_DS = 0;
            decimal SUBTOTAL_INGRESOS_DS = 0;
            decimal EGRESOS_DIA_DS = 0;
            decimal SALDO_CAJA_DIA_DS = 0;
            decimal TOTAL_CAJA_DIA_DS = 0;

            DataSet EFECTIVO_DS = null;
            DataSet CAMBIO_DS = null;
            DataSet TOTALES_DS = null;
            DataSet OTROS_DS = null;
            DataSet EGRESOS_DS = null;
            DataSet CHEQUES_DS = null;
            DataSet COMPOSICION_DS = null;

            if (CAJA > 0)
            {
                EFECTIVO_DS = buscarIngresosInforme(CAJA, "1");
                CAMBIO_DS = buscarCambioInforme(CAJA);
                TOTALES_DS = buscarTotalesInforme(CAJA);
                OTROS_DS = buscarIngresosInforme(CAJA, "2");
                EGRESOS_DS = buscarIngresosInforme(CAJA, "T");
                CHEQUES_DS = buscarChequesInforme(CAJA);
                COMPOSICION_DS = buscarComposicionInforme(CAJA);

                foreach (DataRow row in TOTALES_DS.Tables[0].Rows)
                {
                    INGRESOS_EFECTIVO_DS = Convert.ToDecimal(row[0]);
                    INGRESOS_OTROS_DS = Convert.ToDecimal(row[1]);
                    SUBTOTAL_INGRESOS_DS = Convert.ToDecimal(row[2]);
                    EGRESOS_DIA_DS = Convert.ToDecimal(row[3]);
                    SALDO_CAJA_DIA_DS = Convert.ToDecimal(row[4]);
                    TOTAL_CAJA_DIA_DS = Convert.ToDecimal(row[5]);
                }
            }

            decimal INGRESOS_EFECTIVO = Convert.ToDecimal(dgTotalesDelDia.Rows[0].Cells[1].Value.ToString());
            decimal INGRESOS_OTROS = Convert.ToDecimal(dgTotalesDelDia.Rows[1].Cells[1].Value.ToString());
            decimal EGRESOS_TOTAL = Convert.ToDecimal(dgTotalesDelDia.Rows[2].Cells[1].Value.ToString());
            decimal SUBTOTAL_INGRESOS = Convert.ToDecimal(dgTotalesDelDia.Rows[3].Cells[1].Value.ToString());
            decimal SALDO_CAJA = Convert.ToDecimal(dgTotalesDelDia.Rows[4].Cells[1].Value.ToString());
            decimal TOTAL = Convert.ToDecimal(tbTotal.Text);

            string ARCHIVO = "";
            string NRO = "";
            string DETALLE = "";
            string CONCEPTO = "";
            string IMPUTACION = "";
            string IMPORTE = "";
            string OBSERVACIONES = "";
            string FECHA = "";
            string ANULADO = "";
            string DEBE = "";
            string BONO = "";
            string RECIBO = "";

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet EFECTIVO;
            Excel.Worksheet OTROS;
            Excel.Worksheet EGRESOS;
            Excel.Worksheet CHEQUES;
            Excel.Worksheet TOTALES;

            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add();
            

            Excel.Worksheet CHEQUES_WS;
            CHEQUES_WS = (Excel.Worksheet)xlWorkBook.Worksheets.Add();

            Excel.Worksheet TOTALES_WS;
            TOTALES_WS = (Excel.Worksheet)xlWorkBook.Worksheets.Add();

            EFECTIVO = xlWorkBook.Worksheets[1];
            EFECTIVO.Name = "EFECTIVO";

            OTROS = xlWorkBook.Worksheets[2];
            OTROS.Name = "CHEQUES, DEPOSITOS Y TARJETAS";

            EGRESOS = xlWorkBook.Worksheets[3];
            EGRESOS.Name = "EGRESOS";

            CHEQUES = xlWorkBook.Worksheets[4];
            CHEQUES.Name = "CHEQUES";

            TOTALES = xlWorkBook.Worksheets[5];
            TOTALES.Name = "TOTALES";

            EFECTIVO.Cells[1, 1] = "TOTAL";

            if (CAJA > 0)
                EFECTIVO.Cells[1, 2] = INGRESOS_EFECTIVO_DS.ToString();
            else
                EFECTIVO.Cells[1, 2] = INGRESOS_EFECTIVO.ToString();

            EFECTIVO.Cells[2, 1] = "#";
            EFECTIVO.Cells[2, 2] = "DETALLE";
            EFECTIVO.Cells[2, 3] = "CONCEPTO";
            EFECTIVO.Cells[2, 4] = "IMPUTACION";
            EFECTIVO.Cells[2, 5] = "IMPORTE";
            EFECTIVO.Cells[2, 6] = "OBSERVACIONES";
            EFECTIVO.Cells[2, 7] = "FECHA";
            EFECTIVO.Cells[2, 8] = "ANULADO";

            int X = 3;

            if (CAJA > 0)
            {
                foreach (DataRow row in EFECTIVO_DS.Tables[0].Rows)
                {
                    NRO = row[0].ToString();
                    DETALLE = row[1].ToString();
                    CONCEPTO = row[2].ToString();
                    IMPUTACION = row[3].ToString();
                    IMPORTE = row[4].ToString();
                    OBSERVACIONES = row[5].ToString();
                    FECHA = row[6].ToString();
                    ANULADO = row[7].ToString();

                    EFECTIVO.Cells[X, 1] = NRO;
                    EFECTIVO.Columns[1].AutoFit();
                    EFECTIVO.Cells[X, 2] = DETALLE;
                    EFECTIVO.Columns[2].AutoFit();
                    EFECTIVO.Cells[X, 3] = CONCEPTO;
                    EFECTIVO.Columns[3].AutoFit();
                    EFECTIVO.Cells[X, 4] = IMPUTACION;
                    EFECTIVO.Columns[4].AutoFit();
                    EFECTIVO.Cells[X, 5] = IMPORTE;
                    EFECTIVO.Columns[5].AutoFit();
                    EFECTIVO.Cells[X, 6] = OBSERVACIONES;
                    EFECTIVO.Columns[6].AutoFit();
                    EFECTIVO.Cells[X, 7] = FECHA;
                    EFECTIVO.Columns[7].AutoFit();
                    EFECTIVO.Cells[X, 8] = ANULADO;
                    EFECTIVO.Columns[8].AutoFit();
                    X++;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgEfectivo.Rows)
                {
                    NRO = row.Cells[0].Value.ToString();
                    DETALLE = row.Cells[1].Value.ToString();
                    CONCEPTO = row.Cells[2].Value.ToString();
                    IMPUTACION = row.Cells[3].Value.ToString();
                    IMPORTE = row.Cells[4].Value.ToString();
                    OBSERVACIONES = row.Cells[5].Value.ToString();
                    FECHA = row.Cells[6].Value.ToString();
                    ANULADO = row.Cells[7].Value.ToString();

                    EFECTIVO.Cells[X, 1] = NRO;
                    EFECTIVO.Columns[1].AutoFit();
                    EFECTIVO.Cells[X, 2] = DETALLE;
                    EFECTIVO.Columns[2].AutoFit();
                    EFECTIVO.Cells[X, 3] = CONCEPTO;
                    EFECTIVO.Columns[3].AutoFit();
                    EFECTIVO.Cells[X, 4] = IMPUTACION;
                    EFECTIVO.Columns[4].AutoFit();
                    EFECTIVO.Cells[X, 5] = IMPORTE;
                    EFECTIVO.Columns[5].AutoFit();
                    EFECTIVO.Cells[X, 6] = OBSERVACIONES;
                    EFECTIVO.Columns[6].AutoFit();
                    EFECTIVO.Cells[X, 7] = FECHA;
                    EFECTIVO.Columns[7].AutoFit();
                    EFECTIVO.Cells[X, 8] = ANULADO;
                    EFECTIVO.Columns[8].AutoFit();
                    X++;
                }
            }

            OTROS.Cells[1, 1] = "TOTAL";

            if (CAJA > 0)
                OTROS.Cells[1, 2] = INGRESOS_OTROS_DS.ToString();
            else
                OTROS.Cells[1, 2] = INGRESOS_OTROS.ToString();

            OTROS.Cells[2, 1] = "#";
            OTROS.Cells[2, 2] = "DETALLE";
            OTROS.Cells[2, 3] = "CONCEPTO";
            OTROS.Cells[2, 4] = "IMPUTACION";
            OTROS.Cells[2, 5] = "IMPORTE";
            OTROS.Cells[2, 6] = "OBSERVACIONES";
            OTROS.Cells[2, 7] = "FECHA";
            OTROS.Cells[2, 8] = "ANULADO";

            X = 3;

            if (CAJA > 0)
            {
                foreach (DataRow row in OTROS_DS.Tables[0].Rows)
                {
                    NRO = row[0].ToString();
                    DETALLE = row[1].ToString();
                    CONCEPTO = row[2].ToString();
                    IMPUTACION = row[3].ToString();
                    IMPORTE = row[4].ToString();
                    OBSERVACIONES = row[5].ToString();
                    FECHA = row[6].ToString();
                    ANULADO = row[7].ToString();

                    OTROS.Cells[X, 1] = NRO;
                    OTROS.Columns[1].AutoFit();
                    OTROS.Cells[X, 2] = DETALLE;
                    OTROS.Columns[2].AutoFit();
                    OTROS.Cells[X, 3] = CONCEPTO;
                    OTROS.Columns[3].AutoFit();
                    OTROS.Cells[X, 4] = IMPUTACION;
                    OTROS.Columns[4].AutoFit();
                    OTROS.Cells[X, 5] = IMPORTE;
                    OTROS.Columns[5].AutoFit();
                    OTROS.Cells[X, 6] = OBSERVACIONES;
                    OTROS.Columns[6].AutoFit();
                    OTROS.Cells[X, 7] = FECHA;
                    OTROS.Columns[7].AutoFit();
                    OTROS.Cells[X, 8] = ANULADO;
                    OTROS.Columns[8].AutoFit();
                    X++;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgOtros.Rows)
                {
                    NRO = row.Cells[0].Value.ToString();
                    DETALLE = row.Cells[1].Value.ToString();
                    CONCEPTO = row.Cells[2].Value.ToString();
                    IMPUTACION = row.Cells[3].Value.ToString();
                    IMPORTE = row.Cells[4].Value.ToString();
                    OBSERVACIONES = row.Cells[5].Value.ToString();
                    FECHA = row.Cells[6].Value.ToString();
                    ANULADO = row.Cells[7].Value.ToString();

                    OTROS.Cells[X, 1] = NRO;
                    OTROS.Columns[1].AutoFit();
                    OTROS.Cells[X, 2] = DETALLE;
                    OTROS.Columns[2].AutoFit();
                    OTROS.Cells[X, 3] = CONCEPTO;
                    OTROS.Columns[3].AutoFit();
                    OTROS.Cells[X, 4] = IMPUTACION;
                    OTROS.Columns[4].AutoFit();
                    OTROS.Cells[X, 5] = IMPORTE;
                    OTROS.Columns[5].AutoFit();
                    OTROS.Cells[X, 6] = OBSERVACIONES;
                    OTROS.Columns[6].AutoFit();
                    OTROS.Cells[X, 7] = FECHA;
                    OTROS.Columns[7].AutoFit();
                    OTROS.Cells[X, 8] = ANULADO;
                    OTROS.Columns[8].AutoFit();
                    X++;
                }
            }

            EGRESOS.Cells[1, 1] = "TOTAL";

            if (CAJA > 0)
                EGRESOS.Cells[1, 2] = EGRESOS_DIA_DS.ToString();
            else
                EGRESOS.Cells[1, 2] = EGRESOS_TOTAL.ToString();

            EGRESOS.Cells[2, 1] = "#";
            EGRESOS.Cells[2, 2] = "DETALLE";
            EGRESOS.Cells[2, 3] = "CONCEPTO";
            EGRESOS.Cells[2, 4] = "IMPUTACION";
            EGRESOS.Cells[2, 5] = "IMPORTE";
            EGRESOS.Cells[2, 6] = "OBSERVACIONES";

            X = 3;

            if (CAJA > 0)
            {
                foreach (DataRow row in EGRESOS_DS.Tables[0].Rows)
                {
                    NRO = row[0].ToString();
                    DETALLE = row[1].ToString();
                    CONCEPTO = row[2].ToString();
                    IMPUTACION = row[3].ToString();
                    IMPORTE = row[4].ToString();
                    OBSERVACIONES = row[5].ToString();
                    FECHA = row[6].ToString();
                    ANULADO = row[7].ToString();

                    EGRESOS.Cells[X, 1] = NRO;
                    EGRESOS.Columns[1].AutoFit();
                    EGRESOS.Cells[X, 2] = DETALLE;
                    EGRESOS.Columns[2].AutoFit();
                    EGRESOS.Cells[X, 3] = CONCEPTO;
                    EGRESOS.Columns[3].AutoFit();
                    EGRESOS.Cells[X, 4] = IMPUTACION;
                    EGRESOS.Columns[4].AutoFit();
                    EGRESOS.Cells[X, 5] = IMPORTE;
                    EGRESOS.Columns[5].AutoFit();
                    EGRESOS.Cells[X, 6] = OBSERVACIONES;
                    EGRESOS.Columns[6].AutoFit();
                    EGRESOS.Cells[X, 7] = FECHA;
                    EGRESOS.Columns[7].AutoFit();
                    EGRESOS.Cells[X, 8] = ANULADO;
                    EGRESOS.Columns[8].AutoFit();
                    X++;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgEgresos.Rows)
                {
                    DETALLE = row.Cells[0].Value.ToString();
                    IMPUTACION = row.Cells[1].Value.ToString();
                    DEBE = row.Cells[2].Value.ToString();
                    FECHA = row.Cells[3].Value.ToString();
                    BONO = row.Cells[4].Value.ToString();
                    RECIBO = row.Cells[5].Value.ToString();

                    EGRESOS.Cells[X, 1] = DETALLE;
                    EGRESOS.Columns[1].AutoFit();
                    EGRESOS.Cells[X, 2] = IMPUTACION;
                    EGRESOS.Columns[2].AutoFit();
                    EGRESOS.Cells[X, 3] = DEBE;
                    EGRESOS.Columns[3].AutoFit();
                    EGRESOS.Cells[X, 4] = FECHA;
                    EGRESOS.Columns[4].AutoFit();
                    EGRESOS.Cells[X, 5] = BONO;
                    EGRESOS.Columns[5].AutoFit();
                    EGRESOS.Cells[X, 6] = RECIBO;
                    EGRESOS.Columns[6].AutoFit();
                    X++;
                }
            }

            if (CAJA > 0)
            {
                CHEQUES.Cells[1, 1] = "#";
                CHEQUES.Cells[1, 2] = "DETALLE";
                CHEQUES.Cells[1, 3] = "FECHA";
                CHEQUES.Cells[1, 4] = "IMPORTE";
                CHEQUES.Cells[1, 5] = "IMPUTACION";
            }
            else
            {
                CHEQUES.Cells[1, 1] = "#";
                CHEQUES.Cells[1, 2] = "DETALLE";
                CHEQUES.Cells[1, 3] = "CONCEPTO";
                CHEQUES.Cells[1, 4] = "IMPUTACION";
                CHEQUES.Cells[1, 5] = "IMPORTE";
                CHEQUES.Cells[1, 6] = "OBSERVACIONES";
                CHEQUES.Cells[1, 7] = "FECHA";
                CHEQUES.Cells[1, 8] = "ANULADO";
            }

            X = 2;

            if (CAJA > 0)
            {
                foreach (DataRow row in CHEQUES_DS.Tables[0].Rows)
                {
                    NRO = row[0].ToString();
                    DETALLE = row[1].ToString();
                    FECHA = row[2].ToString();
                    IMPORTE = row[3].ToString();
                    IMPUTACION = row[4].ToString();

                    CHEQUES.Cells[X, 1] = NRO;
                    CHEQUES.Columns[1].AutoFit();
                    CHEQUES.Cells[X, 2] = DETALLE;
                    CHEQUES.Columns[2].AutoFit();
                    CHEQUES.Cells[X, 3] = FECHA;
                    CHEQUES.Columns[3].AutoFit();
                    CHEQUES.Cells[X, 4] = IMPORTE;
                    CHEQUES.Columns[4].AutoFit();
                    CHEQUES.Cells[X, 5] = IMPUTACION;
                    CHEQUES.Columns[5].AutoFit();
                    X++;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgCheques.Rows)
                {
                    NRO = row.Cells[0].Value.ToString();
                    DETALLE = row.Cells[1].Value.ToString();
                    CONCEPTO = row.Cells[2].Value.ToString();
                    IMPUTACION = row.Cells[3].Value.ToString();
                    IMPORTE = row.Cells[4].Value.ToString();
                    OBSERVACIONES = row.Cells[5].Value.ToString();
                    FECHA = row.Cells[6].Value.ToString();
                    ANULADO = row.Cells[7].Value.ToString();

                    CHEQUES.Cells[X, 1] = NRO;
                    CHEQUES.Columns[1].AutoFit();
                    CHEQUES.Cells[X, 2] = DETALLE;
                    CHEQUES.Columns[2].AutoFit();
                    CHEQUES.Cells[X, 3] = CONCEPTO;
                    CHEQUES.Columns[3].AutoFit();
                    CHEQUES.Cells[X, 4] = IMPUTACION;
                    CHEQUES.Columns[4].AutoFit();
                    CHEQUES.Cells[X, 5] = IMPORTE;
                    CHEQUES.Columns[5].AutoFit();
                    CHEQUES.Cells[X, 6] = OBSERVACIONES;
                    CHEQUES.Columns[6].AutoFit();
                    CHEQUES.Cells[X, 7] = FECHA;
                    CHEQUES.Columns[7].AutoFit();
                    CHEQUES.Cells[X, 8] = ANULADO;
                    CHEQUES.Columns[8].AutoFit();
                    X++;
                }
            }

            if (CAJA > 0)
            {
                TOTALES.Cells[1, 1] = "INGRESOS EFECTIVO";
                TOTALES.Cells[1, 2] = INGRESOS_EFECTIVO_DS.ToString();
                TOTALES.Cells[2, 1] = "INGRESOS CHEQUES Y OTROS";
                TOTALES.Cells[2, 2] = INGRESOS_OTROS_DS.ToString();
                TOTALES.Cells[3, 1] = "EGRESOS";
                TOTALES.Cells[3, 2] = EGRESOS_DIA_DS.ToString();
                TOTALES.Cells[4, 1] = "SUBTOTAL INGRESOS";
                TOTALES.Cells[4, 2] = SUBTOTAL_INGRESOS_DS.ToString();
                TOTALES.Cells[5, 1] = "SALDO CAJA";
                TOTALES.Cells[5, 2] = SALDO_CAJA_DIA_DS.ToString();
                TOTALES.Columns[1].AutoFit();
                TOTALES.Columns[2].AutoFit();
            }
            else
            {
                TOTALES.Cells[1, 1] = "INGRESOS EFECTIVO";
                TOTALES.Cells[1, 2] = INGRESOS_EFECTIVO.ToString();
                TOTALES.Cells[2, 1] = "INGRESOS CHEQUES Y OTROS";
                TOTALES.Cells[2, 2] = INGRESOS_OTROS.ToString();
                TOTALES.Cells[3, 1] = "EGRESOS";
                TOTALES.Cells[3, 2] = EGRESOS_TOTAL.ToString();
                TOTALES.Cells[4, 1] = "SUBTOTAL INGRESOS";
                TOTALES.Cells[4, 2] = SUBTOTAL_INGRESOS.ToString();
                TOTALES.Cells[5, 1] = "SALDO CAJA";
                TOTALES.Cells[5, 2] = SALDO_CAJA.ToString();
                TOTALES.Columns[1].AutoFit();
                TOTALES.Columns[2].AutoFit();
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivo XLS|*.xls";
            saveFileDialog1.Title = "Guardar Listado";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ARCHIVO = saveFileDialog1.FileName;
            }

            xlWorkBook.SaveAs(ARCHIVO, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(EFECTIVO);
            releaseObject(OTROS);
            releaseObject(EGRESOS);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            MessageBox.Show("EXCEL GENERADO CORRECTAMENTE", "LISTO!");
        }

        private void btnExcelCaja_Click(object sender, EventArgs e)
        {
            if (dgCajasAnteriores.SelectedRows.Count == 0)
            {
                MessageBox.Show("SELECCIONAR UNA CAJA");
            }
            else
            {
                int CAJA = int.Parse(dgCajasAnteriores[0, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString());
                excelCaja(CAJA);
            }
        }

        private void btnQuitarCheque_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgEgresos.SelectedRows)
                {
                    int ID = int.Parse(row.Cells[9].Value.ToString());
                    string F_PAGO = row.Cells[8].Value.ToString().Trim();

                    if (F_PAGO == "CHEQUE")
                    {
                        BO_CAJA.depositarCheque(ID, 0, 0, "0");
                    }
                    else
                        MessageBox.Show("NO SE SELECCIONO NINGUN CHEQUE");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            cargaInicial(0);
        }

        private int cuentaBanco(int BANCO)
        {
            string query = "SELECT CUENTA FROM BANCOS WHERE ID = " + BANCO + ";";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();
            int CUENTA = int.Parse(foundRows[0][0].ToString());
            return CUENTA;
        }

        private void btnDepoCaja_Click_1(object sender, EventArgs e)
        {
            int SELECCION = dgCajasAnteriores.SelectedRows.Count;
            int CAJA = 0;
            string DEPOSITADA = "";
            int BANCO = int.Parse(cbBancos.SelectedValue.ToString());
            string CODIGO = "0";
            int IMPUTACION = cuentaBanco(BANCO);
            decimal EFECTIVO = 0;
            //MessageBox.Show(SELECCION.ToString());

            if (SELECCION == 0)
            {
                MessageBox.Show("SELECCIONAR AL MENOS UNA CAJA PARA DEPOSITAR", "ERROR");
            }
            else if (tbCodDep.Text == "")
            {
                MessageBox.Show("INGRESAR UN CODIGO DE DEPOSITO", "ERROR");
            }
            else if (SELECCION > 0)
            {
                Cursor = Cursors.WaitCursor;
                CODIGO = tbCodDep.Text.Trim();

                try
                {
                    foreach (DataGridViewRow ROW in dgCajasAnteriores.SelectedRows)
                    {
                        DEPOSITADA = ROW.Cells[10].Value.ToString();
                        CAJA = int.Parse(ROW.Cells[0].Value.ToString());
                        EFECTIVO = decimal.Parse(ROW.Cells[4].Value.ToString());

                        if (DEPOSITADA == "0")
                        {
                            BO_CAJA.depositarCaja(CAJA, 1, BANCO, IMPUTACION, CODIGO);
                        }
                    }

                    MessageBox.Show("CAJAS DEPOSITADAS", "LISTO!");
                    cargaInicial(0);
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDIERON DEPOSITAR LAS CAJAS\n" + error, "ERROR");
                }

                Cursor = Cursors.Default;
            }
        }

        private void btnNoDepositar_Click_1(object sender, EventArgs e)
        {
            int SELECCION = dgCajasAnteriores.SelectedRows.Count;
            int CAJA = 0;
            string DEPOSITADA = "";
            int BANCO = int.Parse(cbBancos.SelectedValue.ToString());
            int CODIGO = 0;
            int IMPUTACION = cuentaBanco(BANCO);

            if (SELECCION == 0)
            {
                MessageBox.Show("SELECCIONAR AL MENOS UNA CAJA PARA CANCELAR EL DEPOSITO", "ERROR");
            }
            else if (SELECCION > 0)
            {
                Cursor = Cursors.WaitCursor;

                try
                {
                    foreach (DataGridViewRow ROW in dgCajasAnteriores.SelectedRows)
                    {
                        DEPOSITADA = ROW.Cells[10].Value.ToString();
                        CAJA = int.Parse(ROW.Cells[0].Value.ToString());

                        if (DEPOSITADA == "1")
                        {
                            BO_CAJA.depositarCaja(CAJA, 0, 0, 0, "0");
                        }
                    }

                    MessageBox.Show("DEPOSITOS CANCELADOS", "LISTO!");
                    cargaInicial(0);
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDIERON CANCELAR LOS DEPOSITOS", "ERROR");
                }

                Cursor = Cursors.Default;
            }
        }

        private void nuevaFormaDePago(DataGridView GRID, int FORMA_DE_PAGO)
        {
            string COMPROBANTE = "X";
            int ID_COMP = 0;
            int X = 0;

            foreach (DataGridViewRow ROW in GRID.SelectedRows)
            {
                COMPROBANTE = ROW.Cells[0].Value.ToString().Substring(0, 1);

                if (X == 0)
                {
                    if (COMPROBANTE == "R")
                    {
                        ID_COMP = int.Parse(ROW.Cells[9].Value.ToString());
                        BO_CAJA.modificarFormaPagoRecibos(ID_COMP, FORMA_DE_PAGO);
                    }
                    if (COMPROBANTE == "B")
                    {
                        ID_COMP = int.Parse(ROW.Cells[9].Value.ToString());

                        if (FORMA_DE_PAGO != 2 && FORMA_DE_PAGO != 7 && FORMA_DE_PAGO != 8 && FORMA_DE_PAGO != 9)
                            BO_CAJA.modificarFormaPagoBonos(ID_COMP, FORMA_DE_PAGO);
                    }
                }
                X++;
            }
        }

        private bool nuevoImporte(DataGridView GRID, TextBox IMPORTE)
        {
            string COMPROBANTE = "X";
            int ID = 0;
            int SELECCION = 0;
            decimal NUEVO_IMPORTE = 0;
            SELECCION = GRID.SelectedRows.Count;

            if (SELECCION == 1)
            {
                if (IMPORTE.Text != "")
                {
                    NUEVO_IMPORTE = decimal.Parse(IMPORTE.Text);

                    foreach (DataGridViewRow ROW in GRID.SelectedRows)
                    {
                        COMPROBANTE = ROW.Cells[0].Value.ToString().Substring(0, 1);

                        if (COMPROBANTE == "R")
                        {
                            ID = int.Parse(ROW.Cells[9].Value.ToString());
                            BO_CAJA.modificarImporteComprobante(ID, NUEVO_IMPORTE, "MOD_IMPORTE_RECIBO");
                        }

                        if (COMPROBANTE == "B")
                        {
                            ID = int.Parse(ROW.Cells[9].Value.ToString());
                            BO_CAJA.modificarImporteComprobante(ID, NUEVO_IMPORTE, "MOD_IMPORTE_BONO");
                        }
                    }

                    return true;
                }
                else
                {
                    MessageBox.Show("INGRESAR UN NUEVO IMPORTE", "ERROR");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("SELECCIONAR SOLO UN COMPROBATE PARA MODIFICAR EL IMPORTE", "ERROR");
                return false;
            }

            return false;
        }

        private bool nuevoRoleDest(DataGridView GRID, string SECTACT, string ID_PROF, string RECIBO_BONO, string CUENTA)
        {
            string COMPROBANTE = "X";
            int ID = 0;
            int ID_COMP = 0;
            bool RES = false;

            foreach (DataGridViewRow ROW in GRID.SelectedRows)
            {
                COMPROBANTE = ROW.Cells[0].Value.ToString().Substring(0, 1);

                if (COMPROBANTE != RECIBO_BONO)
                {
                    MessageBox.Show("NO SE PUEDE ASIGNAR UN PROFESIONAL CON UN TIPO DE COMPROBANTE DIFERENTE AL CREADO");
                    RES = false;
                }
                else
                {
                    ID_COMP = int.Parse(ROW.Cells[9].Value.ToString());

                    if (COMPROBANTE == "R")
                    {
                        try
                        {
                            BO_CAJA.modificarRoleDestRecibos(ID_COMP, int.Parse(SECTACT), int.Parse(ID_PROF), int.Parse(CUENTA));
                            RES = true;
                        }
                        catch
                        {
                            RES = false;
                        }

                    }
                    if (COMPROBANTE == "B")
                    {
                        try
                        {
                            BO_CAJA.modificarRoleDestBonos(ID_COMP, int.Parse(SECTACT), int.Parse(ID_PROF), int.Parse(CUENTA));
                            RES = true;
                        }
                        catch
                        {
                            RES = false;
                        }
                    }
                }
            }
            return RES;
        }

        //MODIFICAR COMPROBANTES EFECTIVO
        private void btnNuevoPagoEfectivo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA MODIFICAR LA FORMA DE PAGO DEL COMPROBANTE SELECCIONADO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int FORMA_DE_PAGO = int.Parse(cbNuevoPagoEfectivo.SelectedValue.ToString());
                nuevaFormaDePago(dgEfectivo, FORMA_DE_PAGO);
                cargaInicial(CAJA);
            }
        }

        private void btnNuevoImporteEfectivo_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA MODIFICAR EL IMPORTE DEL COMPROBANTE SELECCIONADO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (nuevoImporte(dgEfectivo, tbNuevoImporteEfectivo) == true)
                    cargaInicial(CAJA);
            }
        }

        private void btnModRoleDestEfectivo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA MODIFICAR ROLE Y DESTINO DEL COMPROBANTE SELECCIONADO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string[] destino = cbDestinosEfectivo.Text.Split('-');
                string[] profesional = cbProfEfectivo.Text.Split('-');
                string SECTACT = "";
                foreach (string d in destino)
                {
                    SECTACT = d;
                }
                string ID_PROF = cbProfEfectivo.SelectedValue.ToString();
                string RECIBO_BONO = profesional[1];
                string CUENTA = profesional[2];
                if (nuevoRoleDest(dgEfectivo, SECTACT, ID_PROF, RECIBO_BONO, CUENTA) == true)
                {
                    MessageBox.Show("COMPROBANTE MODIFICADO CORRECTAMENTE", "LISTO!");
                    cargaInicial(0);
                }
                else
                {
                    MessageBox.Show("NO SE PUDO MODIFICAR EL COMPROBANTE", "ERROR!");
                }
            }
        }

        //MODIFICAR COMPROBANTES OTROS
        private void btnNuevoPagoOtros_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA MODIFICAR LA FORMA DE PAGO DEL COMPROBANTE SELECCIONADO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int FORMA_DE_PAGO = int.Parse(cbNuevoPagoOtros.SelectedValue.ToString());
                nuevaFormaDePago(dgOtros, FORMA_DE_PAGO);
                cargaInicial(CAJA);
            }
        }

        private void btnNuevoImporteOtros_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA MODIFICAR EL IMPORTE DEL COMPROBANTE SELECCIONADO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (nuevoImporte(dgOtros, tbNuevoImporteOtros) == true)
                    cargaInicial(CAJA);
            }
        }

        private void btnModRoleDestOtros_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA MODIFICAR ROLE Y DESTINO DEL COMPROBANTE SELECCIONADO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string[] destino = cbDestinosOtros.Text.Split('-');
                string[] profesional = cbProfOtros.Text.Split('-');
                string SECTACT = "";
                foreach (string d in destino)
                {
                    SECTACT = d;
                }
                string ID_PROF = cbProfOtros.SelectedValue.ToString();
                string RECIBO_BONO = profesional[1];
                string CUENTA = profesional[2];
                if (nuevoRoleDest(dgOtros, SECTACT, ID_PROF, RECIBO_BONO, CUENTA) == true)
                {
                    MessageBox.Show("COMPROBANTE MODIFICADO CORRECTAMENTE", "LISTO!");
                    cargaInicial(0);
                }
                else
                {
                    MessageBox.Show("NO SE PUDO MODIFICAR EL COMPROBANTE", "ERROR!");
                }
            }
        }

        //MODIFICAR COMPROBANTES BUSCADOR
        private void btnFormaPagoBuscador_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA MODIFICAR LA FORMA DE PAGO DEL COMPROBANTE SELECCIONADO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int FORMA_DE_PAGO = int.Parse(cbFormaPagoBuscador.SelectedValue.ToString());
                nuevaFormaDePago(dgBuscador, FORMA_DE_PAGO);
                cargaInicial(CAJA);
                buscarComprobantes();
            }
        }

        private void btnImporteBuscador_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA MODIFICAR EL IMPORTE DEL COMPROBANTE SELECCIONADO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (nuevoImporte(dgBuscador, tbImporteBuscador) == true)
                {
                    cargaInicial(CAJA);
                    buscarComprobantes();
                }
            }
        }

        private void btnModRoleDestBuscador_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA MODIFICAR ROLE Y DESTINO DEL COMPROBANTE SELECCIONADO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string[] destino = cbDestinoBuscador.Text.Split('-');
                string[] profesional = cbProfBuscador.Text.Split('-');
                string SECTACT = "";

                foreach (string d in destino)
                {
                    SECTACT = d;
                }

                string ID_PROF = cbProfBuscador.SelectedValue.ToString();
                string RECIBO_BONO = profesional[1];
                string CUENTA = profesional[2];

                if (nuevoRoleDest(dgBuscador, SECTACT, ID_PROF, RECIBO_BONO, CUENTA) == true)
                {
                    MessageBox.Show("COMPROBANTE MODIFICADO CORRECTAMENTE", "LISTO!");
                    cargaInicial(CAJA);
                    buscarComprobantes();
                }
                else
                {
                    MessageBox.Show("NO SE PUDO MODIFICAR EL COMPROBANTE", "ERROR!");
                }
            }
        }

        private void btnMostrarCaja_Click(object sender, EventArgs e)
        {
            CAJA = int.Parse(dgCajasAnteriores[0, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString());
            FECHA = dgCajasAnteriores[1, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString();
            INDEX = dgCajasAnteriores.CurrentCell.RowIndex;
            cargaInicial(CAJA);
            toggleActions("DESHABILITAR");
        }

        private void toggleActions(string ACTION)
        {
            if (ACTION == "HABILITAR")
            {
                gbDepositoCajas.Enabled = true;
                btnCerrarCaja.Text = "CARGAR CAJA SELECCIONADA";
                btnQuitarCheque.Enabled = true;
                label6.Enabled = true;
                cbBancosCheques.Enabled = true;
                label5.Enabled = true;
                tbCompCheque.Enabled = true;
                btnAgregarCheque.Enabled = true;
                groupBoxAl.Text = "AL " + FECHA;
                dgCajasAnteriores.ClearSelection();
                dgCajasAnteriores.Rows[INDEX].Selected = true;
                gbCajasAnteriores.Enabled = true;
                btnExcel.Enabled = true;
            }

            if (ACTION == "DESHABILITAR")
            {
                gbDepositoCajas.Enabled = false;
                btnCerrarCaja.Text = "MODIFICAR CAJA SELECCIONADA";
                btnQuitarCheque.Enabled = false;
                label6.Enabled = false;
                cbBancosCheques.Enabled = false;
                label5.Enabled = false;
                tbCompCheque.Enabled = false;
                btnAgregarCheque.Enabled = false;
                groupBoxAl.Text = "AL " + FECHA;
                dgCajasAnteriores.ClearSelection();
                dgCajasAnteriores.Rows[INDEX].Selected = true;
                gbCajasAnteriores.Enabled = false;
                btnExcel.Enabled = false;
            }
        }

        private void btnDepoCajaCampo_Click(object sender, EventArgs e)
        {
            int SELECCION = dgCajasAnteriores.SelectedRows.Count;
            int CAJA = 0;
            string DEPOSITADA = "";
            int BANCO = 0;
            string CODIGO = "SEDE CENTRAL";
            int IMPUTACION = 111111;

            if (SELECCION == 0)
            {
                MessageBox.Show("SELECCIONAR AL MENOS UNA CAJA PARA DEPOSITAR", "ERROR");
            }
            else if (SELECCION > 0)
            {
                Cursor = Cursors.WaitCursor;

                try
                {
                    foreach (DataGridViewRow ROW in dgCajasAnteriores.SelectedRows)
                    {
                        DEPOSITADA = ROW.Cells[10].Value.ToString();
                        CAJA = int.Parse(ROW.Cells[0].Value.ToString());

                        if (DEPOSITADA == "0")
                        {
                            BO_CAJA.depositarCaja(CAJA, 1, BANCO, IMPUTACION, CODIGO);
                        }
                    }

                    MessageBox.Show("CAJAS DEPOSITADAS", "LISTO!");
                    cargaInicial(0);
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDIERON DEPOSITAR LAS CAJAS\n" + error, "ERROR");
                }

                Cursor = Cursors.Default;
            }
        }

        private void buscarComprobantes()
        {
            int DESDE = 0;
            int HASTA = 0;
            string F_DESDE = "";
            string F_HASTA = "";
            string PTO_VTA = "";
            string COMPROBANTE = "";
            string COMP_MIN = "";
            string FORMA_PAGO = "1";
            DataGridView GRID = dgBuscador;

            if (cbBuscarNumeros.Checked == false && cbBuscarFechas.Checked == false)
            {
                MessageBox.Show("SELECCIONAR AL MENOS UNA CONDICION DE BÚSQUEDA");
            }
            else if (tbNroDesde.Text.Trim() == "" && cbBuscarNumeros.Checked == true)
            {
                MessageBox.Show("INGRESAR UN NRO DESDE", "ERROR!");
            }
            else if (tbPtoVta.Text.Trim() == "" && cbTipos.SelectedItem.ToString() != "REINTEGROS")
            {
                MessageBox.Show("INGRESAR UN PUNTO DE VENTA", "ERROR!");
            }
            else if (cbTipos.SelectedItem.ToString() == "")
            {
                MessageBox.Show("SELECCIONAR UN TIPO DE COMPROBANTE", "ERROR!");
            }
            else
            {
                if (cbBuscarNumeros.Checked == true && cbBuscarFechas.Checked == false)
                {
                    DESDE = int.Parse(tbNroDesde.Text.Trim());
                    HASTA = int.Parse(tbNroHasta.Text.Trim());
                }
                else if (cbBuscarNumeros.Checked == true && cbBuscarFechas.Checked == true)
                {
                    DESDE = int.Parse(tbNroDesde.Text.Trim());
                    HASTA = int.Parse(tbNroHasta.Text.Trim());
                    F_DESDE = dpFechaDesde.Text.Substring(3, 2) + "/" + dpFechaDesde.Text.Substring(0, 2) + "/" + dpFechaDesde.Text.Substring(6, 4);
                    F_HASTA = dpFechaHasta.Text.Substring(3, 2) + "/" + dpFechaHasta.Text.Substring(0, 2) + "/" + dpFechaHasta.Text.Substring(6, 4);
                }
                else if (cbBuscarNumeros.Checked == false && cbBuscarFechas.Checked == true)
                {
                    F_DESDE = dpFechaDesde.Text.Substring(3, 2) + "/" + dpFechaDesde.Text.Substring(0, 2) + "/" + dpFechaDesde.Text.Substring(6, 4);
                    F_HASTA = dpFechaHasta.Text.Substring(3, 2) + "/" + dpFechaHasta.Text.Substring(0, 2) + "/" + dpFechaHasta.Text.Substring(6, 4);
                }

                COMPROBANTE = cbTipos.SelectedItem.ToString();
                COMP_MIN = COMPROBANTE.Substring(0, 1);
                PTO_VTA = tbPtoVta.Text.Trim();
                FORMA_PAGO = cbPagoFiltro.SelectedValue.ToString();
                buscador(DESDE, HASTA, COMPROBANTE, GRID, PTO_VTA, F_DESDE, F_HASTA, FORMA_PAGO);
            }
        }

        private string queryBuscador(int DESDE, int HASTA, string COMPROBANTE, string PTO, string F_DESDE, string F_HASTA, string FORMA_PAGO)
        {
            string query = "";

            if (COMPROBANTE == "REINTEGROS")
            {
                //BONOS
                query += @"SELECT B.NRO_COMP, TRIM(B.NOMBRE_SOCIO) AS DETALLE, (TRIM(S.DETALLE) || ' - ' || TRIM(P.NOMBRE)) AS CONCEPTO, B.CUENTA_HABER AS IMPUTACION, ";
                query += "CASE WHEN B.ANULADO IS NULL THEN B.VALOR ELSE '0' END AS VALOR, B.OBSERVACIONES, 'RR' AS TIPO, B.CAJA_DIARIA, B.FECHA_RECIBO, F.DETALLE ";
                query += "AS F_PAGO, B.ANULADO, B.DESTINO, B.ID, B.PTO_VTA, 0 AS PTO_E, B.DNI FROM BONOS_CAJA B, SECTACT S, PROFESIONALES P, FORMAS_DE_PAGO F ";
                query += "WHERE B.SECTACT = S.ID AND B.ID_PROFESIONAL = P.ID AND B.FORMA_PAGO = F.ID AND B.REINTEGRO_DE IS NOT NULL AND B.PTO_VTA = '0005' ";

                if (HASTA == 0 && cbBuscarNumeros.Checked == true)
                    query += "AND B.NRO_COMP = " + DESDE;

                if (HASTA > 0 && cbBuscarNumeros.Checked == true)
                    query += " AND B.NRO_COMP BETWEEN " + DESDE + " AND " + HASTA;

                if (F_DESDE != "" && F_HASTA != "")
                {
                    if (HASTA == 0 && cbBuscarNumeros.Checked == true)
                        query += " AND B.NRO_COMP = " + DESDE;

                    query += " AND B.FECHA_RECIBO >= '" + F_DESDE + "' AND B.FECHA_RECIBO <= '" + F_HASTA + "' ";
                }

                if (F_DESDE != "" && F_HASTA != "")
                {
                    if (HASTA > 0 && cbBuscarNumeros.Checked == true)
                        query += " AND B.NRO_COMP BETWEEN " + DESDE + " AND " + HASTA;

                    query += " AND B.FECHA_RECIBO >= '" + F_DESDE + "' AND B.FECHA_RECIBO <= '" + F_HASTA + "' ";
                }

                query += "UNION ALL ";

                //RECIBOS
                query += @"SELECT B.NRO_COMP, TRIM(B.NOMBRE_SOCIO) AS DETALLE, (TRIM(S.DETALLE) || ' - ' || TRIM(P.NOMBRE)) AS CONCEPTO, B.CUENTA_HABER AS IMPUTACION, ";
                query += "CASE WHEN B.ANULADO IS NULL THEN B.VALOR ELSE '0' END AS VALOR, B.OBSERVACIONES, 'RB' AS TIPO, B.CAJA_DIARIA, B.FECHA_RECIBO, F.DETALLE ";
                query += "AS F_PAGO, B.ANULADO, B.DESTINO, B.ID, B.PTO_VTA, 0 AS PTO_E, B.DNI FROM RECIBOS_CAJA B, SECTACT S, PROFESIONALES P, FORMAS_DE_PAGO F ";
                query += "WHERE B.SECTACT = S.ID AND B.ID_PROFESIONAL = P.ID AND B.FORMA_PAGO = F.ID AND B.REINTEGRO_DE IS NOT NULL AND B.PTO_VTA = '0005' ";

                if (HASTA == 0 && cbBuscarNumeros.Checked == true)
                    query += "AND B.NRO_COMP = " + DESDE;

                if (HASTA > 0 && cbBuscarNumeros.Checked == true)
                    query += " AND B.NRO_COMP BETWEEN " + DESDE + " AND " + HASTA;

                if (F_DESDE != "" && F_HASTA != "")
                {
                    if (HASTA == 0 && cbBuscarNumeros.Checked == true)
                        query += " AND B.NRO_COMP = " + DESDE;

                    query += " AND B.FECHA_RECIBO >= '" + F_DESDE + "' AND B.FECHA_RECIBO <= '" + F_HASTA + "' ";
                }

                if (F_DESDE != "" && F_HASTA != "")
                {
                    if (HASTA > 0 && cbBuscarNumeros.Checked == true)
                        query += " AND B.NRO_COMP BETWEEN " + DESDE + " AND " + HASTA;

                    query += " AND B.FECHA_RECIBO >= '" + F_DESDE + "' AND B.FECHA_RECIBO <= '" + F_HASTA + "' ";
                }

            }
            else
            {
                if (COMPROBANTE == "BONOS")
                {
                    query += @"SELECT B.NRO_COMP, TRIM(B.NOMBRE_SOCIO) AS DETALLE, (TRIM(S.DETALLE)||' - '||TRIM(P.NOMBRE)) AS CONCEPTO, B.CUENTA_HABER AS IMPUTACION, CASE WHEN B.ANULADO IS NULL THEN B.VALOR ELSE '0' END AS VALOR, ";
                    query += "B.OBSERVACIONES, 'B' AS TIPO, B.CAJA_DIARIA, B.FECHA_RECIBO, F.DETALLE AS F_PAGO, B.ANULADO, B.DESTINO, B.ID, B.PTO_VTA, 0 AS NRO_E, B.DNI FROM ";
                    query += "BONOS_CAJA B, SECTACT S, PROFESIONALES P, FORMAS_DE_PAGO F WHERE B.SECTACT = S.ID AND B.ID_PROFESIONAL = P.ID AND B.FORMA_PAGO = F.ID";
                 }

                if (COMPROBANTE == "RECIBOS")
                {
                    query += @"SELECT B.NRO_COMP, TRIM(B.NOMBRE_SOCIO) AS DETALLE, (TRIM(S.DETALLE)||' - '||TRIM(P.NOMBRE)) AS CONCEPTO, B.CUENTA_HABER AS IMPUTACION, CASE WHEN B.ANULADO IS NULL THEN B.VALOR ELSE '0' END AS VALOR, ";
                    query += "B.OBSERVACIONES, 'R' AS TIPO, B.CAJA_DIARIA, B.FECHA_RECIBO, F.DETALLE AS F_PAGO, B.ANULADO, B.DESTINO, B.ID, B.PTO_VTA, B.NUMERO_E AS NRO_E, B.DNI FROM ";
                    query += "RECIBOS_CAJA B, SECTACT S, PROFESIONALES P, FORMAS_DE_PAGO F WHERE B.SECTACT = S.ID AND B.ID_PROFESIONAL = P.ID AND B.FORMA_PAGO = F.ID";
                }

                if (HASTA == 0 && cbBuscarNumeros.Checked == true)
                    query += "AND NRO_COMP = " + DESDE;

                if (HASTA > 0 && cbBuscarNumeros.Checked == true)
                    query += " AND NRO_COMP BETWEEN " + DESDE + " AND " + HASTA;

                if (F_DESDE != "" && F_HASTA != "")
                {
                    if (HASTA == 0 && cbBuscarNumeros.Checked == true)
                        query += " AND NRO_COMP = " + DESDE;

                    query += " AND FECHA_RECIBO >= '" + F_DESDE + "' AND FECHA_RECIBO <= '" + F_HASTA + "' ";
                }

                if (F_DESDE != "" && F_HASTA != "")
                {
                    if (HASTA > 0 && cbBuscarNumeros.Checked == true)
                        query += " AND NRO_COMP BETWEEN " + DESDE + " AND " + HASTA;

                    query += " AND FECHA_RECIBO >= '" + F_DESDE + "' AND FECHA_RECIBO <= '" + F_HASTA + "' ";
                }

                if (cbBuscarPorRole.Checked == true)
                {
                    sectAct sa = new sectAct();
                    DataRow[] ids = sa.getIdsFromSectAct(cbRolesBuscador.SelectedValue.ToString());
                    int TOTAL = ids.Length;
                    int X = 1;

                    query += " AND SECTACT IN (";

                    foreach (DataRow row in ids)
                    {
                        if (X < TOTAL)
                        {
                            query += row[0].ToString() + ", ";
                            X++;
                        }
                        else
                        {
                            query += row[0].ToString() + ")";
                        }
                    }
                }

                if (FORMA_PAGO != "10")
                    query += " AND B.FORMA_PAGO = '" + FORMA_PAGO + "'";

                query += " AND B.PTO_VTA = '" + PTO + "' ORDER BY B.NRO_COMP ASC;";
            }

            return query;
        }

        private void buscador(int DESDE, int HASTA, string COMPROBANTE, DataGridView GRID, string PTO, string F_DESDE, string F_HASTA, string FORMA_PAGO)
        {
            try
            {
                DataSet ds1 = new DataSet();
                string query = queryBuscador(DESDE, HASTA, COMPROBANTE, PTO, F_DESDE, F_HASTA, FORMA_PAGO);
                conString cs = new conString();
                string connectionString = cs.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataTable dt1 = new DataTable("RESULTADOS");
                    dt1.Columns.Add("#", typeof(string));
                    dt1.Columns.Add("DETALLE", typeof(string));
                    dt1.Columns.Add("CONCEPTO", typeof(string));
                    dt1.Columns.Add("IMP", typeof(int));
                    dt1.Columns.Add("IMPORTE", typeof(string));
                    dt1.Columns.Add("OBSERVACIONES", typeof(string));
                    dt1.Columns.Add("FECHA", typeof(string));
                    dt1.Columns.Add("ANULADO", typeof(string));
                    dt1.Columns.Add("F_PAGO", typeof(string));
                    dt1.Columns.Add("ID", typeof(string));
                    dt1.Columns.Add("PV", typeof(string));
                    dt1.Columns.Add("NE", typeof(string));
                    dt1.Columns.Add("DNI", typeof(string));
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    FbDataReader reader = cmd.ExecuteReader();

                    string NRO_COMP = string.Empty;
                    string DETALLE = string.Empty;
                    string CONCEPTO = string.Empty;
                    string IMPUTACION = string.Empty;
                    decimal IMPORTE;
                    string OBSERVACIONES = string.Empty;
                    string FECHA = string.Empty;
                    string VALOR;
                    decimal TOTAL = 0;
                    string TIPO = string.Empty;
                    string ANULADO = string.Empty;
                    string F_PAGO = string.Empty;
                    decimal CAJAS_DEPOSITADAS = 0;
                    string ID_COMP = string.Empty;
                    string PTO_VTA = string.Empty;
                    string NRO_E = string.Empty;
                    string DNI = string.Empty;

                    while (reader.Read())
                    {
                        TIPO = reader.GetString(reader.GetOrdinal("TIPO"));
                        NRO_COMP = TIPO + "" + reader.GetString(reader.GetOrdinal("NRO_COMP")).Trim();
                        DETALLE = reader.GetString(reader.GetOrdinal("DETALLE")).Trim();
                        CONCEPTO = reader.GetString(reader.GetOrdinal("CONCEPTO")).Trim();
                        IMPUTACION = reader.GetString(reader.GetOrdinal("IMPUTACION"));
                        IMPORTE = reader.GetDecimal(reader.GetOrdinal("VALOR"));
                        VALOR = string.Format("{0:n}", IMPORTE);
                        OBSERVACIONES = reader.GetString(reader.GetOrdinal("OBSERVACIONES")).Trim();
                        FECHA = reader.GetString(reader.GetOrdinal("FECHA_RECIBO")).Trim().Replace(" 0:00:00", "");
                        TOTAL = TOTAL + IMPORTE;
                        ANULADO = reader.GetString(reader.GetOrdinal("ANULADO")).Trim().Replace(" 0:00:00", "");
                        F_PAGO = reader.GetString(reader.GetOrdinal("F_PAGO")).Trim();
                        ID_COMP = reader.GetString(reader.GetOrdinal("ID"));
                        PTO_VTA = reader.GetString(reader.GetOrdinal("PTO_VTA"));
                        NRO_E = reader.GetString(reader.GetOrdinal("NRO_E"));
                        DNI = reader.GetString(reader.GetOrdinal("DNI"));
                        dt1.Rows.Add(NRO_COMP, DETALLE, CONCEPTO, IMPUTACION, VALOR, OBSERVACIONES, FECHA, ANULADO, F_PAGO, ID_COMP, PTO_VTA, NRO_E, DNI);
                    }

                    reader.Close();
                    GRID.DataSource = dt1;
                    GRID.Columns[0].Width = 60;
                    GRID.Columns[1].Width = 190;
                    GRID.Columns[2].Width = 190;
                    GRID.Columns[3].Width = 50;
                    GRID.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GRID.Columns[4].Width = 80;
                    GRID.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    GRID.Columns[5].Width = 195;
                    GRID.Columns[6].Width = 85;
                    GRID.Columns[7].Width = 70;
                    GRID.Columns[8].Width = 110;
                    GRID.Columns[10].Width = 40;
                    GRID.Columns[11].Width = 40;
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarComprobantes();
        }

        private void dgCajasAnteriores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ID = "";
            string FECHA = "";
            string EFECTIVO = "";
            string OTROS = "";
            string SUBTOTAL = "";
            string EGRESOS = "";
            string SALDO = "";
            string TOTAL = "";

            foreach (DataGridViewRow row in dgCajasAnteriores.SelectedRows)
            {
                ID = row.Cells[0].Value.ToString();
                FECHA = row.Cells[3].Value.ToString();
                EFECTIVO = row.Cells[4].Value.ToString();
                OTROS = row.Cells[5].Value.ToString();
                SUBTOTAL = row.Cells[6].Value.ToString();
                EGRESOS = row.Cells[7].Value.ToString();
                SALDO = row.Cells[8].Value.ToString();
                TOTAL = row.Cells[9].Value.ToString();
            }

            modificarCajaDiaria mcd = new modificarCajaDiaria(ID, FECHA, EFECTIVO, OTROS, SUBTOTAL, EGRESOS, SALDO, TOTAL);
            mcd.ShowDialog();
            cargaInicial(0);
        }

        private void btnFormaPagoBuscador_Click(object sender, EventArgs e)
        {
            int FORMA_DE_PAGO = int.Parse(cbFormaPagoBuscador.SelectedValue.ToString());
            nuevaFormaDePago(dgBuscador, FORMA_DE_PAGO);
            buscarComprobantes();
            cargaInicial(CAJA);
        }

        private void btnImporteBuscador_Click(object sender, EventArgs e)
        {
            if (nuevoImporte(dgBuscador, tbImporteBuscador) == true)
            {
                buscarComprobantes();
                cargaInicial(CAJA);
            }
        }

        private void cbRolesEfectivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambioComboRoles(cbDestinosEfectivo, cbRolesEfectivo);
        }

        private void cbDestinosEfectivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDestinosEfectivo.SelectedValue.ToString() != "")
            {
                string vIdDestino = "";
                string[] words = cbDestinosEfectivo.Text.Split('-');

                foreach (string word in words)
                {
                    vIdDestino = word;
                }

                int SECTACT = int.Parse(vIdDestino.TrimEnd());
                comboProfesionales(cbProfEfectivo, SECTACT, cbDestinosEfectivo);
            }
        }

        private void cbRolesOtros_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambioComboRoles(cbDestinosOtros, cbRolesOtros);
        }

        private void cbDestinosOtros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDestinosOtros.SelectedValue.ToString() != "")
            {
                string vIdDestino = "";
                string[] words = cbDestinosOtros.Text.Split('-');

                foreach (string word in words)
                {
                    vIdDestino = word;
                }

                int SECTACT = int.Parse(vIdDestino.TrimEnd());
                comboProfesionales(cbProfOtros, SECTACT, cbDestinosOtros);
            }
        }

        private void cbRoleBuscador_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambioComboRoles(cbDestinoBuscador, cbRoleBuscador);
        }

        private void cbDestinoBuscador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDestinoBuscador.SelectedValue.ToString() != "")
            {
                string vIdDestino = "";
                string[] words = cbDestinoBuscador.Text.Split('-');

                foreach (string word in words)
                {
                    vIdDestino = word;
                }

                int SECTACT = int.Parse(vIdDestino.TrimEnd());
                comboProfesionales(cbProfBuscador, SECTACT, cbDestinoBuscador);
            }
        }



        private void cbBuscarNumeros_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBuscarNumeros.Checked == true)
            {
                label10.Enabled = true;
                label12.Enabled = true;
                tbNroDesde.Enabled = true;
                tbNroHasta.Enabled = true;
            }
            else
            {
                label10.Enabled = false;
                label12.Enabled = false;
                tbNroDesde.Enabled = false;
                tbNroHasta.Enabled = false;
                tbNroDesde.Text = "";
                tbNroHasta.Text = "";
            }
        }

        private void cbBuscarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBuscarFechas.Checked == true)
            {
                label14.Enabled = true;
                label15.Enabled = true;
                dpFechaDesde.Enabled = true;
                dpFechaHasta.Enabled = true;
            }
            else
            {
                label14.Enabled = false;
                label15.Enabled = false;
                dpFechaDesde.Enabled = false;
                dpFechaHasta.Enabled = false;
            }
        }

        private string right(string value, int length)
        {
            return value.Substring(value.Length - length);
        }

        private void btImpBuscador_Click(object sender, EventArgs e)
        {
            string COMPROBANTE = "X";
            string NRO_COMPROBANTE = "X";
            int ID = 0;
            int SELECCION = 0;
            string TABLA = "";
            SELECCION = dgBuscador.SelectedRows.Count;
            getGrupo gg = new getGrupo();

            if (SELECCION == 1)
            {
                foreach (DataGridViewRow ROW in dgBuscador.SelectedRows)
                {
                    COMPROBANTE = ROW.Cells[0].Value.ToString().Substring(0, 1);

                    if (COMPROBANTE == "R")
                    {
                        TABLA = "RECIBOS_CAJA";
                        NRO_COMPROBANTE = ROW.Cells[0].Value.ToString().Replace("R", "");
                    }

                    if (COMPROBANTE == "B")
                    {
                        TABLA = "BONOS_CAJA";
                        NRO_COMPROBANTE = ROW.Cells[0].Value.ToString().Replace("B", "");
                    }

                    ID = int.Parse(ROW.Cells[9].Value.ToString());
                    string QUERY = "SELECT R.ID_SOCIO, R.SECTACT, R.ID_PROFESIONAL, R.NOMBRE_SOCIO_TITULAR, R.TIPO_SOCIO_TITULAR, R.BARRA, R.NRO_COMP, R.CUENTA_DEBE, R.DNI, R.VALOR, ";
                    QUERY += "R.REINTEGRO_DE FROM " + TABLA + " R WHERE R.NRO_COMP = " + int.Parse(NRO_COMPROBANTE) + " AND PTO_VTA = " + VGlobales.PTO_VTA_N + ";";
                    DataRow[] foundRows;
                    foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

                    string ID_SOCIO = foundRows[0][0].ToString();
                    string NRO_DEP = right(ID_SOCIO, 3);
                    string NRO_SOC = ID_SOCIO.Replace(NRO_DEP, "");
                    string NRO_DEPADH = right(foundRows[0][0].ToString(), 3);
                    string NRO_ADH = foundRows[0][0].ToString().Replace(NRO_DEPADH, "");
                    string BARRA = foundRows[0][5].ToString();
                    string TIT_SOC = ID_SOCIO.Replace(NRO_DEP, "");
                    string TIT_DEP = right(ID_SOCIO, 3);
                    string DNI = foundRows[0][8].ToString();
                    string COD_DTO = "";
                    string CAT_SOC = foundRows[0][4].ToString();
                    decimal IMPORTE = decimal.Parse(foundRows[0][9].ToString());
                    string RB = "R";
                    string REINTEGRO_DE = foundRows[0][10].ToString();
                    int CUENTA = int.Parse(foundRows[0][7].ToString());
                    int ID_PROFESIONAL = int.Parse(foundRows[0][2].ToString());
                    int SECTACT = int.Parse(foundRows[0][1].ToString());
                    int SECUENCIA = 0;
                    string[] NOM_APE = ROW.Cells[1].Value.ToString().Trim().Split(',');
                    string APELLIDO = NOM_APE[0];
                    string NOMBRE = NOM_APE[1];
                    int GRUPO = 0;
                    string REINTEGRO = "NO";

                    if (REINTEGRO_DE != "0")
                    {
                        REINTEGRO = "SI";
                    }

                    recibos r = new recibos(int.Parse(ID_SOCIO), SECTACT, ID_PROFESIONAL, SECUENCIA, APELLIDO, NOMBRE, CAT_SOC, BARRA, COD_DTO,
                    NRO_COMPROBANTE, NRO_SOC, NRO_DEP, TIT_SOC, TIT_DEP, CUENTA, DNI, GRUPO, IMPORTE, RB, REINTEGRO, null);
                    r.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("SELECCIONAR SOLO UN COMPROBANTE PARA IMPRIMIR", "ERROR");
            }
        }

        private void cbBuscarPorRole_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBuscarPorRole.Checked == true)
            {
                cbRolesBuscador.Enabled = true;
            }
            else
            {
                cbRolesBuscador.Enabled = false;
            }
        }

        private void facturar(DataGridView GRID, ProgressBar PB)
        {
            string EXCEPTION = "";
            string DENI = "";
            int TC = (int)SOCIOS.Factura_Electronica.Tipo_Comprobante_Enum.RECIBO_C;
            int TD = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.CONSUMIDOR_FINAL;
            int TF = (int)SOCIOS.Factura_Electronica.Tipo_FACTURACION_ENUM.UNITARIA;
            int recibo_id = 0;
            string IMPORTE = "";
            string FECHA_RECIBO = "";
            string NOMBRE_SOCIO = "";
            string CONCEPTO = "SERVICIOS PRESTADOS";
            string PTO_VTA = "";
            string ROLE = "";
            string PTO_VTA_O = "";
            string DIR = "";
            string COND_IVA = "CONSUMIDOR FINAL";

            if (GRID.SelectedRows.Count == 0)
                MessageBox.Show("SELECCIONAR AL MENOS UN COMPROBANTE PARA FACTURAR");
            else
            {
                PB.Visible = true;
                PB.Minimum = 0;
                PB.Maximum = GRID.SelectedRows.Count;
                PB.Value = 1;
                PB.Step = 1;
                Cursor = Cursors.WaitCursor;

                foreach (DataGridViewRow row in GRID.SelectedRows)
                {
                    DENI = row.Cells[12].Value.ToString();
                    recibo_id = int.Parse(row.Cells[9].Value.ToString());
                    IMPORTE = row.Cells[4].Value.ToString();
                    FECHA_RECIBO = row.Cells[6].Value.ToString();
                    NOMBRE_SOCIO = row.Cells[1].Value.ToString();
                    PTO_VTA = row.Cells[10].Value.ToString();
                    ROLE = nr.obtenerRole(PTO_VTA);
                    PTO_VTA_O = nr.obtenerPtoVtaOficial(ROLE);

                    if (DENI != "0" && DENI != "")
                    {
                        TD = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.DNI;

                        if (DENI.Length > 8)
                        {
                            TD = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.CUIT;
                            CONCEPTO = nr.obtenerObservacion(recibo_id);
                            COND_IVA = nr.obnenerCondicionPorCuit(DENI);
                        }
                    }

                    if (PTO_VTA_O != "") //VALIDO QUE EXISTA PUNTO DE VENTA CARGADO
                    {
                        if (Modo_Facturacion_Produccion == "TEST") //DEFINO EL DIRECTORIO PARA GUARDAR LOS ARCHIVOS
                            DIR = "\\\\192.168.1.6\\factura_electronica\\TEST\\" + PTO_VTA_O + "\\FACTURAS\\";
                        else
                            DIR = "\\\\192.168.1.6\\factura_electronica\\" + PTO_VTA_O + "\\FACTURAS\\";

                        Factura_Electronica.Recibo_Request result = new Factura_Electronica.Recibo_Request();
                        Factura_Electronica.FacturaCSPFA fe = new Factura_Electronica.FacturaCSPFA(int.Parse(PTO_VTA_O));
                        Factura_Electronica.Impresor_Factura imp_fact = new Factura_Electronica.Impresor_Factura(DIR);

                        if (row.Cells[0].Value.ToString().Substring(0, 1) == "R") //VALIDO TIPO DE COMPROBANTE
                        {
                            if (row.Cells[11].Value.ToString() == "" || row.Cells[11].Value.ToString() == "0") //VALIDO NUMERO ELECTRONICO
                            {
                                if (row.Cells[4].Value.ToString() != "0,00") //VALIDO IMPORTE DIFERENTE A 0
                                {
                                    if (decimal.Parse(row.Cells[4].Value.ToString()) < 5000) //VALIDO QUE SEA MENOR A 5 MIL
                                    {
                                        result = fe.Facturo_Recibo(recibo_id, int.Parse(PTO_VTA_O), TC, TD, DENI, decimal.Parse(IMPORTE), DateTime.Now, TF);
                                        if (result.Result == true)
                                            imp_fact.Genero_PDF(TC, int.Parse(PTO_VTA_O), result.Numero, DateTime.Now, DENI, COND_IVA, NOMBRE_SOCIO, decimal.Parse(IMPORTE), result.Cae, FECHA_RECIBO, "ORIGINAL", CONCEPTO, recibo_id);
                                        else
                                            MessageBox.Show(result.Excepcion.ToString());
                                        PB.PerformStep();
                                    }
                                    else //SI ES MAYOR O IGUAL A 5 MIL
                                    {
                                        if (TD == 99) // SI ES CONSUMIDOR FINAL DIVIDO Y HAGO VARIOS RECIBOS C
                                        {
                                            decimal CANTIDAD_FACTURAS = decimal.Parse(IMPORTE) / 4999;
                                            decimal CANTIDAD_FACTURAS_FLOOR = Math.Floor(CANTIDAD_FACTURAS);
                                            decimal IMPORTE_FACTURADO = CANTIDAD_FACTURAS_FLOOR * 4999;
                                            decimal IMPORTE_RESTANTE = decimal.Parse(IMPORTE) - IMPORTE_FACTURADO;
                                            TF = (int)Factura_Electronica.Tipo_FACTURACION_ENUM.DUAL;

                                            for (int i = 1; i <= CANTIDAD_FACTURAS_FLOOR; i++)
                                            {
                                                result = fe.Facturo_Recibo(recibo_id, int.Parse(PTO_VTA_O), TC, TD, DENI, 4999, DateTime.Now, TF);

                                                if (result.Result == true)
                                                    imp_fact.Genero_PDF(TC, int.Parse(PTO_VTA_O), result.Numero, DateTime.Now, DENI, "Consumidor Final", NOMBRE_SOCIO, 4999, result.Cae, FECHA_RECIBO, "ORIGINAL", CONCEPTO, recibo_id);
                                            }

                                            result = fe.Facturo_Recibo(recibo_id, int.Parse(PTO_VTA_O), TC, TD, DENI, IMPORTE_RESTANTE, DateTime.Now, TF);
                                            if (result.Result == true)
                                                imp_fact.Genero_PDF(TC, int.Parse(PTO_VTA_O), result.Numero, DateTime.Now, DENI, "Consumidor Final", NOMBRE_SOCIO, IMPORTE_RESTANTE, result.Cae, FECHA_RECIBO, "ORIGINAL", CONCEPTO, recibo_id);
                                        }
                                        else // SI NO ES CONSUMIDOR FINAL HAGO UN SOLO RECIBO C
                                        {
                                            result = fe.Facturo_Recibo(recibo_id, int.Parse(PTO_VTA_O), TC, TD, DENI, decimal.Parse(IMPORTE), DateTime.Now, TF);
                                            if (result.Result == true)
                                                imp_fact.Genero_PDF(TC, int.Parse(PTO_VTA_O), result.Numero, DateTime.Now, DENI, "Consumidor Final", NOMBRE_SOCIO, decimal.Parse(IMPORTE), result.Cae, FECHA_RECIBO, "ORIGINAL", CONCEPTO, recibo_id);
                                            PB.PerformStep();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Cursor = Cursors.Default;
                PB.Visible = false;
            }
        }

        private void btnFacturarEfectivo_Click(object sender, EventArgs e)
        {
            facturar(dgEfectivo, pbFactrarEfectivo);
            MessageBox.Show("FACTURACIÓN COMPLETADA", "LISTO");
            buscar("1", dgEfectivo, CAJA);
        }

        private void btnFacturarOtros_Click(object sender, EventArgs e)
        {
            facturar(dgOtros, pbFacturarOtros);
            MessageBox.Show("FACTURACIÓN COMPLETADA", "LISTO");
            buscar("0", dgOtros, CAJA);
        }

        private void anular(string NRO, string COMPROBANTE, string TABLA, string FECHA, string PTO_VTA)
        {
            string ACCION = "";
            TextBox CAMPO = null;

            if (FECHA == null)
                ACCION = "RESTABLECIDO";
            else
                ACCION = "ANULADO";

            if (COMPROBANTE == "RECIBO")
                BO_CAJA.anularRecibo(int.Parse(NRO), FECHA, PTO_VTA);

            if (COMPROBANTE == "BONO")
                BO_CAJA.anularBono(int.Parse(NRO), FECHA, PTO_VTA);
        }

        private void anularComprobante(DataGridView GRID)
        {
            if (GRID.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("¿CONFIRMA ANULAR EL COMPROBANTE SELECCIONADO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in GRID.SelectedRows)
                    {
                        if (row.Cells[7].Value.ToString() == "")
                        {
                            if (row.Cells[0].Value.ToString().Substring(0, 1) == "R")
                            {
                                try
                                {
                                    Cursor = Cursors.WaitCursor;
                                    string NRO = row.Cells[0].Value.ToString().Replace("R", "");
                                    string COMPROBANTE = "RECIBO";
                                    string TABLA = "RECIBOS_CAJA";
                                    string FECHA = DateTime.Now.ToString();
                                    string PTO_VTA = row.Cells[10].Value.ToString();
                                    string DENI = row.Cells[11].Value.ToString();
                                    decimal IMPORTE = decimal.Parse(row.Cells[4].Value.ToString());
                                    string NOMBRE_SOCIO = row.Cells[1].Value.ToString();
                                    string CONCEPTO = "SERVICIOS PRESTADOS";
                                    int ID_COMP = nr.obtenerIdComprobante("RECIBO", PTO_VTA, int.Parse(NRO));
                                    anular(NRO, COMPROBANTE, TABLA, FECHA, PTO_VTA);

                                    if (VGlobales.vp_role == "CAJA")
                                    {
                                        string DIR = "";
                                        int TC = (int)SOCIOS.Factura_Electronica.Tipo_Comprobante_Enum.NOTA_VENTA_C;
                                        int TD = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.CONSUMIDOR_FINAL;

                                        if (Modo_Facturacion_Produccion == "TEST")
                                            DIR = "\\\\192.168.1.6\\factura_electronica\\TEST\\" + PTO_VTA + "\\NOTAS_DE_CREDITO\\";
                                        else
                                            DIR = "\\\\192.168.1.6\\factura_electronica\\" + PTO_VTA + "\\NOTAS_DE_CREDITO\\";

                                        Factura_Electronica.Recibo_Request result = new Factura_Electronica.Recibo_Request();
                                        Factura_Electronica.Impresor_Factura imp_fact = new Factura_Electronica.Impresor_Factura(DIR);
                                        Factura_Electronica.FacturaCSPFA fe = new Factura_Electronica.FacturaCSPFA(Int32.Parse(VGlobales.PTO_VTA_O));
                                        result = fe.Facturo_Recibo(int.Parse(NRO), int.Parse(VGlobales.PTO_VTA_O), TC, TD, DENI, IMPORTE, DateTime.Now, 1);
                                        
                                        if (result.Result == true)
                                            imp_fact.Genero_PDF(TC, int.Parse(VGlobales.PTO_VTA_O), result.Numero, DateTime.Now, DENI, "Consumidor Final", NOMBRE_SOCIO, IMPORTE,
                                                result.Cae, FECHA, "ORIGINAL", CONCEPTO, ID_COMP);
                                        else
                                            MessageBox.Show("LA NOTA DE CREDITO NO SE PUDO REALIZAR\nINTENTAR NUEVAMENTE DESDE EL LISTADO DE INGRESOS\n" + result.Excepcion);
                                    }
                                    MessageBox.Show("COMPROBANTE ANULADO CORRECTAMENTE", "LISTO");
                                }
                                catch (Exception error)
                                {
                                    MessageBox.Show("NO SE PUDO ANULAR EL COMPROBANTE\n" + error, "ERROR");
                                }
                                Cursor = Cursors.Default;
                            }
                            if (row.Cells[0].Value.ToString().Substring(0, 1) == "B")
                            {
                                string NRO = row.Cells[0].Value.ToString().Replace("B", "");
                                string COMPROBANTE = "BONO";
                                string TABLA = "BONOS_CAJA";
                                string FECHA = DateTime.Now.ToString();
                                string PTO_VTA = row.Cells[10].Value.ToString();
                                anular(NRO, COMPROBANTE, TABLA, FECHA, PTO_VTA);
                            }
                        }
                        else
                        {
                            MessageBox.Show("EL COMPROBANTE SELECCIONADO YA SE ECUENTRA ANULADO", "ERROR");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("SELECCIONAR SOLAMENTE UN COMPROBANTE PARA ANULAR", "ERROR");
            }
        }

        private void btnAnularOtros_Click(object sender, EventArgs e)
        {
            anularComprobante(dgOtros);
            buscar("0", dgOtros, CAJA);
        }

        private void btnAnularEfectivo_Click(object sender, EventArgs e)
        {
            anularComprobante(dgEfectivo);
            buscar("1", dgEfectivo, CAJA);
        }

        //private void GenerarNotaCredito(DataGridView GRID)
        //{

        //    if (GRID.SelectedRows.Count == 1)
        //    {
        //        foreach (DataGridViewRow row in GRID.SelectedRows)
        //        {
        //            if (row.Cells[0].Value.ToString().Substring(0, 1) == "R")
        //            {
        //                 Cursor = Cursors.WaitCursor;
        //                            string NRO = row.Cells[0].Value.ToString().Replace("R", "");
                                    
        //                            string FECHA = DateTime.Now.ToString();
        //                            string PTO_VTA = row.Cells[10].Value.ToString();
        //                            string DENI = row.Cells[11].Value.ToString();
        //                            decimal IMPORTE = decimal.Parse(row.Cells[4].Value.ToString());
        //                            string NOMBRE_SOCIO = row.Cells[1].Value.ToString();
        //                            string CONCEPTO = "SERVICIOS PRESTADOS";
                                  

        //                            if (VGlobales.vp_role == "CAJA")
        //                            {
        //                                string DIR = "";
        //                                int TC = (int)SOCIOS.Factura_Electronica.Tipo_Comprobante_Enum.NOTA_VENTA_C;
        //                                int TD = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.CONSUMIDOR_FINAL;

        //                                if (Modo_Facturacion_Produccion == "TEST")
        //                                    DIR = "\\\\192.168.1.6\\factura_electronica\\TEST\\" + PTO_VTA + "\\NOTAS_DE_CREDITO\\";
        //                                else
        //                                    DIR = "\\\\192.168.1.6\\factura_electronica\\" + PTO_VTA + "\\NOTAS_DE_CREDITO\\";

        //                                Factura_Electronica.Recibo_Request result = new Factura_Electronica.Recibo_Request();
        //                                Factura_Electronica.Impresor_Factura imp_fact = new Factura_Electronica.Impresor_Factura(DIR);
        //                                Factura_Electronica.FacturaCSPFA fe = new Factura_Electronica.FacturaCSPFA(Int32.Parse(VGlobales.PTO_VTA_O));
        //                                result = fe.Facturo_Recibo(int.Parse(NRO), int.Parse(VGlobales.PTO_VTA_O), TC, TD, DENI, IMPORTE, DateTime.Now, 1);
                                        
        //                                if (result.Result == true)
        //                                    imp_fact.Genero_PDF(TC, int.Parse(VGlobales.PTO_VTA_O), result.Numero, DateTime.Now, DENI, "Consumidor Final", NOMBRE_SOCIO, IMPORTE,
        //                                        result.Cae, FECHA, "ORIGINAL", CONCEPTO, ID_COMP);
        //                                else
        //                                    MessageBox.Show("LA NOTA DE CREDITO NO SE PUDO REALIZAR\nINTENTAR NUEVAMENTE DESDE EL LISTADO DE INGRESOS\n" + result.Excepcion);
        //                            }
        //                            MessageBox.Show("COMPROBANTE ANULADO CORRECTAMENTE", "LISTO");
        //                        }
        //                        catch (Exception error)
        //                        {
        //                            MessageBox.Show("NO SE PUDO ANULAR EL COMPROBANTE\n" + error, "ERROR");
        //                        }
        //                        Cursor = Cursors.Default;
        //                    }

        //            }
        //        }

        //    }
        //}


        private void verReciboC(DataGridView GRID)
        {
            if (GRID.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow row in GRID.SelectedRows)
                {
                    if (row.Cells[0].Value.ToString().Substring(0, 1) == "R")
                    {
                        try
                        {
                            string PTO_VTA = row.Cells[10].Value.ToString();
                            string ROLE = nr.obtenerRole(PTO_VTA);
                            string PTO_VTA_O = nr.obtenerPtoVtaOficial(ROLE);
                            string PTO_VTA_F = PTO_VTA_O.Replace("0", "");
                            string NRO_E = row.Cells[11].Value.ToString();
                            string FILE = "";

                            if (Modo_Facturacion_Produccion=="TEST")
                                FILE = "\\\\192.168.1.6\\factura_electronica\\TEST\\" + PTO_VTA_O + "\\FACTURAS\\RECIBO C-PV " + PTO_VTA_F + "- NRO " + NRO_E + ".pdf";
                            else
                                FILE = "\\\\192.168.1.6\\factura_electronica\\" + PTO_VTA_O + "\\FACTURAS\\RECIBO C-PV " + PTO_VTA_F + "- NRO " + NRO_E + ".pdf";

                            if (File.Exists(FILE))
                            {
                                Process.Start(FILE);
                            }
                            else
                            {
                                MessageBox.Show("EL ARCHIVO NO EXISTE", "ERROR");
                            }
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("OCURRIO UN ERROR AL ABRIR EL ARCHIVO PDF\n"+error, "ERROR");
                        }
                    }
                    else
                    {
                        MessageBox.Show("SELECCIONAR UN RECIBO PARA VER EL ARCHIVO PDF", "ERROR");
                    }
                }
            }
            else
            {
                MessageBox.Show("SELECCIONAR SOLO UN COMPROBANTE", "ERROR");
            }
        }

        private void btnVerReciboEfectivo_Click(object sender, EventArgs e)
        {
            verReciboC(dgEfectivo);
        }

        private void btnVerReciboOtros_Click(object sender, EventArgs e)
        {
            verReciboC(dgOtros);
        }

        private void genPdfReciboC(DataGridView GRID)
        {
            if (GRID.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in GRID.SelectedRows)
                {
                    if (row.Cells[0].Value.ToString().Substring(0, 1) == "R")
                    {
                        if (row.Cells[11].Value.ToString() != "")
                        {
                            try
                            {
                                string PTO_VTA = row.Cells[10].Value.ToString();
                                string ROLE = nr.obtenerRole(PTO_VTA);
                                string PTO_VTA_O = nr.obtenerPtoVtaOficial(ROLE);
                                string PTO_VTA_F = PTO_VTA_O.Replace("0", "");
                                string NRO_E = row.Cells[11].Value.ToString();
                                string FILE = "";
                                if (Modo_Facturacion_Produccion == "TEST")
                                    FILE = "\\\\192.168.1.6\\factura_electronica\\TEST\\" + PTO_VTA_O + "\\FACTURAS\\RECIBO C-PV " + PTO_VTA_F + "- NRO " + NRO_E + ".pdf";
                                else
                                    FILE = "\\\\192.168.1.6\\factura_electronica\\" + PTO_VTA_O + "\\FACTURAS\\RECIBO C-PV " + PTO_VTA_F + "- NRO " + NRO_E + ".pdf";

                                //if (!File.Exists(FILE))
                                //{
                                    string DIR = "";

                                    if (Modo_Facturacion_Produccion == "TEST")
                                        DIR = "\\\\192.168.1.6\\factura_electronica\\TEST\\" + PTO_VTA_O + "\\FACTURAS\\";
                                    else
                                        DIR = "\\\\192.168.1.6\\factura_electronica\\" + PTO_VTA_O + "\\FACTURAS\\";

                                    int TC = (int)SOCIOS.Factura_Electronica.Tipo_Comprobante_Enum.RECIBO_C;
                                    int TD = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.CONSUMIDOR_FINAL;

                                    string DENI = row.Cells[12].Value.ToString();
                                    int recibo_id = int.Parse(row.Cells[9].Value.ToString());
                                    string IMPORTE = row.Cells[4].Value.ToString();
                                    string FECHA_RECIBO = row.Cells[6].Value.ToString().Substring(0, 10);
                                    string NOMBRE_SOCIO = row.Cells[1].Value.ToString();
                                    string CONCEPTO = "SERVICIOS PRESTADOS";
                                    string CAE = nr.obtenerCaePorRecibo(PTO_VTA_F, int.Parse(NRO_E));
                                    string COND_IVA = "CONSUMIDOR FINAL";

                                    if (DENI != "0" && DENI != "")
                                    {
                                        TD = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.DNI;

                                        if (DENI.Length > 8)
                                        {
                                            TD = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.CUIT;
                                            CONCEPTO = nr.obtenerObservacion(recibo_id);
                                            COND_IVA = nr.obnenerCondicionPorCuit(DENI);
                                        }
                                    }

                                    Factura_Electronica.Impresor_Factura imp_fact = new Factura_Electronica.Impresor_Factura(DIR);
                                    imp_fact.Genero_PDF(TC, int.Parse(PTO_VTA_O), int.Parse(NRO_E), DateTime.Parse(FECHA_RECIBO), DENI, COND_IVA, NOMBRE_SOCIO, decimal.Parse(IMPORTE),
                                        CAE, FECHA_RECIBO, "ORIGINAL", CONCEPTO, recibo_id);

                                    MessageBox.Show("ARCHIVO PDF GENERADO CORRECTAMENTE", "LISTO!");
                                //}
                                /*else
                                {
                                    MessageBox.Show("EL ARCHIVO YA EXISTE", "ERROR");
                                }*/
                                //MessageBox.Show("ARCHIVOS PDF GENERADOS CORRECTAMENTE", "LISTO!");
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show("OCURRIO UN ERROR AL GENERAR EL ARCHIVO PDF\n" + error, "ERROR");
                            }
                        }
                        else
                        {
                            MessageBox.Show("EL CAMPO NE NO PUEDE ESTAR VACÍO", "ERROR");
                        }
                    }
                    else
                    {
                        MessageBox.Show("SELECCIONAR UN RECIBO PARA GENERAR LOS PDFS", "ERROR");
                    }
                }                
            }
            else
            {
                MessageBox.Show("SELECCIONAR AL MENOS UN RECIBO", "ERROR");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            genPdfReciboC(dgEfectivo);
        }

        private void btnGenPdfOtros_Click(object sender, EventArgs e)
        {
            genPdfReciboC(dgOtros);
        }

        private void btnFacturarBuscador_Click(object sender, EventArgs e)
        {
            facturar(dgBuscador, pbFacturarBuscador);
            MessageBox.Show("FACTURACIÓN COMPLETADA", "LISTO");
            buscarComprobantes();
        }

        private void btnVerReciboBuscador_Click(object sender, EventArgs e)
        {
            verReciboC(dgBuscador);
        }

        private void btnGenPdfBuscador_Click(object sender, EventArgs e)
        {
            genPdfReciboC(dgBuscador);
        }

        private void asignarReciboC(DataGridView GRID)
        {
            string NE = "";
            string PTO_VTA_I = "";
            string ID = "";
            string NRO = "";
            string ROLE = "";

            if (GRID.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow row in GRID.SelectedRows)
                {
                    NRO = row.Cells[0].Value.ToString();

                    if (NRO.Contains("R"))
                    {
                        NE = row.Cells[11].Value.ToString();

                        if (NE == "")
                        {
                            PTO_VTA_I = row.Cells[10].Value.ToString();
                            ID = row.Cells[9].Value.ToString();
                            ROLE = nr.obtenerRole(PTO_VTA_I);
                            asignarReciboC arc = new asignarReciboC(ID, ROLE);
                            arc.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("SELECCIONAR UN RECIBO QUE NO POSEA RECIBO C", "ERROR!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("SELECCIONAR UN RECIBO", "ERROR!");
                    }
                }
            }
            else
            {
                MessageBox.Show("SELECCIONAR SOLAMENTE UN RECIBO", "ERROR!");
            }
        }

        private void btnAsignarBuscador_Click(object sender, EventArgs e)
        {
            asignarReciboC(dgBuscador);
        }

        private void btnAsignarOtros_Click(object sender, EventArgs e)
        {
            asignarReciboC(dgOtros);
        }

        private void btnAsignarEfectivo_Click(object sender, EventArgs e)
        {
            asignarReciboC(dgEfectivo);
        }

        private void btnControlAfip_Click(object sender, EventArgs e)
        {
            Factura_Electronica.Consulta_Factura cf = new Factura_Electronica.Consulta_Factura();
            cf.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Factura_Electronica.Consulta_Factura cf = new Factura_Electronica.Consulta_Factura();
            cf.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Factura_Electronica.Consulta_Factura cf = new Factura_Electronica.Consulta_Factura();
            cf.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Factura_Electronica.Consulta_Factura cf = new Factura_Electronica.Consulta_Factura();
            cf.ShowDialog();
        }
    }
}