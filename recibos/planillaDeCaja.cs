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

        private void habilitarEdicion()
        {
            tbNuevoImporteEfectivo.Text = "";
            tbNuevoImporteOtros.Text = "";

            if (VGlobales.vp_username == "SVALLEJOS" || VGlobales.vp_username == "PDEREYES" || VGlobales.vp_username == "AHERNANDEZ" || VGlobales.vp_username == "SBARBEITO")
            {
                label1.Enabled = true;
                label7.Enabled = true;
                label8.Enabled = true;
                label9.Enabled = true;
                cbNuevoPagoEfectivo.Enabled = true;
                cbNuevoPagoOtros.Enabled = true;
                btnNuevoPagoEfectivo.Enabled = true;
                btnNuevoPagoOtros.Enabled = true;
                tbNuevoImporteEfectivo.Enabled = true;
                tbNuevoImporteOtros.Enabled = true;
                btnNuevoImporteEfectivo.Enabled = true;
                btnNuevoImporteOtros.Enabled = true;
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
            comboBancos(cbBancos);
            comboBancos(cbBancosCheques);
            comboFormasDePago(cbNuevoPagoEfectivo);
            comboFormasDePago(cbNuevoPagoOtros);

            buscar("1", dgEfectivo, CAJA);
            buscarCajas(0, dgCajasAnteriores);
            buscarCajas(1, dgCajasDepositadas);
            pintarCajas();
            tbTotal.Text = INGRESOS_EFECTIVO.ToString();
            tbCambio.Text = obtenerCambio().ToString();
            agregarCambio();

            buscar("0", dgOtros, CAJA);
            buscar("E", dgEgresos, CAJA);
            buscar("2", dgCheques, CAJA);

            totalEgresos();
            dgTotalesDelDia.Rows.Add("SUBTOTAL INGRESOS DEL DIA", string.Format("{0:n}", INGRESOS_EFECTIVO + INGRESOS_OTROS));
            chequesEnTotal();
            CAJAS_ANTERIORES = cajasAnteriores();
            SALDO_ANTERIOR = CAJAS_ANTERIORES;
            
            dgTotalesDelDia.Rows.Add("TOTAL DEL DÍA", string.Format("{0:n}", (INGRESOS_EFECTIVO + INGRESOS_OTROS)));
            dgTotalesDelDia.Rows.Add("SALDO DEL DÍA ANTERIOR", string.Format("{0:n}", (SALDO_ANTERIOR)));

            if (dgCajasAnteriores.Rows.Count == 1)
                dgTotalesDelDia.Rows.Add("SALDO DEL LA FECHA", string.Format("{0:n}", "0,00"));
            else
                dgTotalesDelDia.Rows.Add("SALDO DEL LA FECHA", string.Format("{0:n}", (SALDO_ANTERIOR + INGRESOS_EFECTIVO + INGRESOS_OTROS - EGRESOS)));
            
            cajaDeHoyEnComposicion();

            if (CAJA > 0)
                cajasEnComposicion(CAJA);

            if (CAJA == 0)
                agregarCajas();

            dgCajasAnteriores.ClearSelection();
            dgComposicion.ClearSelection();
            dgTotalesDelDia.ClearSelection();
            dgTotalesDelDia.Enabled = false;

            if (VGlobales.vp_role != "CAJA")
            {
                tabPage3.Dispose();
                btnExcelCaja.Enabled = false;
                btnMostrarCaja.Enabled = false;
                gbDepositoCajas.Enabled = false;
            }

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
            }
            
            dgTotalesDelDia.Rows.Add("EGRESOS", string.Format("{0:n}", EGRESOS));
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

        private void buscar(string PAGO, DataGridView GRID, int CAJA)
        {
            try
            {
                DataSet ds1 = new DataSet();
                string query = "SELECT * FROM PLANILLA_CAJA ('" + PAGO + "', " + CAJA + ", '" + VGlobales.vp_role + "') WHERE DESTINO IS NULL OR (DESTINO <> 10 AND DESTINO <> 2);";
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
                        dt1.Rows.Add(NRO_COMP, DETALLE, CONCEPTO, IMPUTACION, VALOR, OBSERVACIONES, FECHA, ANULADO, F_PAGO, ID_COMP, PTO_VTA);

                        if (PAGO == "2")
                        {
                            dgComposicion.Rows.Add(NRO_COMP.Replace("R", ""), "CHEQUE " + CONCEPTO + " " + FECHA, string.Format("{0:n}", (IMPORTE)));
                        }
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
                    GRID.Columns[6].Visible = true;
                    GRID.Columns[6].Width = 70;
                    GRID.Columns[7].Width = 70;
                    GRID.Columns[8].Width = 110;
                    GRID.Columns[9].Width = 50;
                    GRID.Columns[10].Width = 40;
                    transaction.Commit();

                    if (PAGO == "1") //EFECTIVO
                    {
                        dgTotalesDelDia.Rows.Add("INGRESOS EFECTIVO", string.Format("{0:n}", TOTAL));
                        INGRESOS_EFECTIVO = TOTAL;
                    }
                    else if (PAGO != "1" && GRID.Name.ToString() == "dgOtros")
                    {
                        dgTotalesDelDia.Rows.Add("INGRESOS CHEQUES Y OTROS", string.Format("{0:n}", TOTAL));
                        INGRESOS_OTROS = TOTAL;
                    }
                    else if (PAGO != "1" && PAGO != "2")
                    {
                        CAJAS_DEPOSITADAS = totalCajasDepositadas();
                        EGRESOS = TOTAL + CAJAS_DEPOSITADAS;
                        //EGRESOS = TOTAL;
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
            decimal CAJA = 0;

            foreach (DataGridViewRow row in dgCajasDepositadas.Rows)
            {
                CAJA = decimal.Parse(row.Cells[4].Value.ToString());
                TOTAL = TOTAL + CAJA;
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
            string FECHA = Hoy.ToString("dd/MM/yyyy");
            decimal INGRESOS_EFECTIVO = Convert.ToDecimal(dgTotalesDelDia.Rows[0].Cells[1].Value.ToString());
            decimal INGRESOS_OTROS = Convert.ToDecimal(dgTotalesDelDia.Rows[1].Cells[1].Value.ToString());
            decimal EGRESOS = Convert.ToDecimal(dgTotalesDelDia.Rows[2].Cells[1].Value.ToString());
            decimal SUBTOTAL_INGRESOS = Convert.ToDecimal(dgTotalesDelDia.Rows[3].Cells[1].Value.ToString());
            decimal SALDO_CAJA = Convert.ToDecimal(dgTotalesDelDia.Rows[4].Cells[1].Value.ToString());
            decimal TOTAL = Convert.ToDecimal(tbTotal.Text);
            string ROL = VGlobales.vp_role;
            pbProcesando.Visible = true;
            pbProcesando.Minimum = 0;
            pbProcesando.Step = 1;
            pbProcesando.Maximum = dgComposicion.Rows.Count;
            pbProcesando.Value = 0;

            try
            {
                BO_CAJA.cerrarCajaDiaria(FECHA, INGRESOS_EFECTIVO, INGRESOS_OTROS, SUBTOTAL_INGRESOS, EGRESOS, SALDO_CAJA, ROL, TOTAL);
            }
            catch (Exception error)
            { 
                Cursor = Cursors.Default;
                MessageBox.Show("NO SE PUDO GUARDAR LA CAJA DIARIA\n " + error);
            }

            maxid mid = new maxid();
            int CAJA_DIARIA = int.Parse(mid.m("ID", "CAJA_DIARIA"));
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
                    query = "SELECT * FROM CAJA_DIARIA_S('" + VGlobales.vp_role + "') WHERE DEPOSITADA IN (0,1,2);";

                if (DEPO == 1)
                    query = "SELECT * FROM CAJA_DIARIA_S('" + VGlobales.vp_role + "') WHERE DEPOSITADA = 1;";

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
                        dt1.Rows.Add(ID, FECHA, US_ALTA, FE_ALTA, INGRESOS_EFECTIVO, INGRESOS_OTROS, SUBTOTAL_INGRESOS, EGRESOS, SALDO_CAJA, TOTAL, DEPOSITADA);
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
                    GRILLA.Columns[10].Visible = false;
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

            if (CAJA > 0)
                modificarCaja(CAJA);
        }

        private void modificarCaja(int CAJA)
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
        }

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
                string PATH = @"\\192.168.1.6\planillascaja\" + VGlobales.vp_role + "_CAJA_DEL_" + DIA + "_" + MES + "_" + ANIO + ".pdf";
                string DIR = @"\\192.168.1.6\planillascaja\";

                if (VGlobales.vp_role == "CPOCABA" || VGlobales.vp_role == "CPOPOLVORINES")
                {
                    //PATH = @"C:\PlanillasCaja\" + VGlobales.vp_role + "_CAJA_DEL_" + DIA + "_" + MES + "_" + ANIO + ".pdf";
                    //DIR = @"C:\PlanillasCaja";
                    PATH = "SAVEAS";
                }

                if (!Directory.Exists(DIR))
                {
                    PATH = "SAVEAS";
                }

                imprimirPlanilla(CAJA, PATH);
                Cursor = Cursors.Default;
            }
        }
        
        private DataSet buscarComposicionInforme(int CAJA)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();
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
                DataSet ds = new DataSet();
                string query = "";

                if (VGlobales.vp_role == "CAJA" || VGlobales.vp_role == "INFORMES" || VGlobales.vp_role == "CAJA2")
                    query = "SELECT * FROM PLANILLA_CAJA_INFORME ('" + PAGO + "', " + CAJA + ") WHERE DESTINO IS NULL OR (DESTINO <> 4);";

                if (VGlobales.vp_role != "CAJA" && VGlobales.vp_role != "INFORMES" && VGlobales.vp_role != "CAJA2")
                    query = "SELECT * FROM PLANILLA_CAJA_INFORME ('" + PAGO + "', " + CAJA + ");";

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

                string NUM = "";
                string RECIBO = "";
                string BONO = "";
                string NOMBRE = "";
                string CONCEPTO = "";
                string DEBE = "";
                decimal IMPORTE = 0;
                string OBSERVACIONES = "";
                decimal TOTAL = 0;
                decimal TOTAL_INGRESOS_EFECTIVO = Convert.ToDecimal(dgCajasAnteriores[4, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString());
                decimal TOTAL_INGRESOS_OTROS = Convert.ToDecimal(dgCajasAnteriores[5, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString());
                decimal TOTAL_EGRESOS = Convert.ToDecimal(dgCajasAnteriores[7, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString());
                string FECHA = dgCajasAnteriores[1, dgCajasAnteriores.CurrentCell.RowIndex].Value.ToString();
                int X = 0;
                string TIPO = "";
                string ANULADO = "";
                string PTO_VTA = "";

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

                PdfPTable TABLA_INGRESOS = new PdfPTable(7);
                TABLA_INGRESOS.WidthPercentage = 100;
                TABLA_INGRESOS.SpacingAfter = 10;
                TABLA_INGRESOS.SpacingBefore = 10;
                TABLA_INGRESOS.SetWidths(new float[] { 1.4f, 4f, 6f, 1f, 2f, 5f, 2f });
                PdfPCell CELDA_NUM = new PdfPCell(new Phrase("#", _mediumFontBoldWhite));
                PdfPCell CELDA_APENOM = new PdfPCell(new Phrase("APELLIDO Y NOMBRES", _mediumFontBoldWhite));
                PdfPCell CELDA_CONCEPTO = new PdfPCell(new Phrase("CONCEPTO", _mediumFontBoldWhite));
                PdfPCell CELDA_IMPUTACION = new PdfPCell(new Phrase("HABER", _mediumFontBoldWhite));
                PdfPCell CELDA_IMPORTE = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                PdfPCell CELDA_OBS = new PdfPCell(new Phrase("OBSERVACIONES", _mediumFontBoldWhite));
                PdfPCell CELDA_ANULADO = new PdfPCell(new Phrase("ANULADO", _mediumFontBoldWhite));
                CELDA_NUM.BackgroundColor = topo;
                CELDA_NUM.BorderColor = blanco;
                CELDA_NUM.HorizontalAlignment = 1;
                CELDA_NUM.FixedHeight = 16f;
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
                CELDA_OBS.BackgroundColor = topo;
                CELDA_OBS.BorderColor = blanco;
                CELDA_OBS.HorizontalAlignment = 1;
                CELDA_OBS.FixedHeight = 16f;
                CELDA_ANULADO.BackgroundColor = topo;
                CELDA_ANULADO.BorderColor = blanco;
                CELDA_ANULADO.HorizontalAlignment = 1;
                CELDA_ANULADO.FixedHeight = 16f;
                TABLA_INGRESOS.AddCell(CELDA_NUM);
                TABLA_INGRESOS.AddCell(CELDA_APENOM);
                TABLA_INGRESOS.AddCell(CELDA_CONCEPTO);
                TABLA_INGRESOS.AddCell(CELDA_IMPUTACION);
                TABLA_INGRESOS.AddCell(CELDA_IMPORTE);
                TABLA_INGRESOS.AddCell(CELDA_OBS);
                TABLA_INGRESOS.AddCell(CELDA_ANULADO);
                #endregion

                #region CABECERA INGRESOS EN OTROS

                PdfPTable TABLA_INGRESOS_OTROS = new PdfPTable(7);
                TABLA_INGRESOS_OTROS.WidthPercentage = 100;
                TABLA_INGRESOS_OTROS.SpacingAfter = 10;
                TABLA_INGRESOS_OTROS.SpacingBefore = 10;
                TABLA_INGRESOS_OTROS.SetWidths(new float[] { 1.4f, 4f, 6f, 1f, 2f, 5f, 2f });
                PdfPCell CELDA_NUM_OTROS = new PdfPCell(new Phrase("#", _mediumFontBoldWhite));
                PdfPCell CELDA_APENOM_OTROS = new PdfPCell(new Phrase("APELLIDO Y NOMBRES", _mediumFontBoldWhite));
                PdfPCell CELDA_CONCEPTO_OTROS = new PdfPCell(new Phrase("CONCEPTO", _mediumFontBoldWhite));
                PdfPCell CELDA_IMPUTACION_OTROS = new PdfPCell(new Phrase("HABER", _mediumFontBoldWhite));
                PdfPCell CELDA_IMPORTE_OTROS = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                PdfPCell CELDA_OBS_OTROS = new PdfPCell(new Phrase("OBSERVACIONES", _mediumFontBoldWhite));
                PdfPCell CELDA_ANULADO_OTROS = new PdfPCell(new Phrase("ANULADO", _mediumFontBoldWhite));
                CELDA_NUM_OTROS.BackgroundColor = topo;
                CELDA_NUM_OTROS.BorderColor = blanco;
                CELDA_NUM_OTROS.HorizontalAlignment = 1;
                CELDA_NUM_OTROS.FixedHeight = 16f;
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
                CELDA_OBS_OTROS.BackgroundColor = topo;
                CELDA_OBS_OTROS.BorderColor = blanco;
                CELDA_OBS_OTROS.HorizontalAlignment = 1;
                CELDA_OBS_OTROS.FixedHeight = 16f;
                CELDA_ANULADO_OTROS.BackgroundColor = topo;
                CELDA_ANULADO_OTROS.BorderColor = blanco;
                CELDA_ANULADO_OTROS.HorizontalAlignment = 1;
                CELDA_ANULADO_OTROS.FixedHeight = 16f;
                TABLA_INGRESOS_OTROS.AddCell(CELDA_NUM_OTROS);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_APENOM_OTROS);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_CONCEPTO_OTROS);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_IMPUTACION_OTROS);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_IMPORTE_OTROS);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_OBS_OTROS);
                TABLA_INGRESOS_OTROS.AddCell(CELDA_ANULADO_OTROS);
                #endregion

                #region CABECERA EGRESOS
                PdfPTable TABLA_EGRESOS = new PdfPTable(7);
                TABLA_EGRESOS.WidthPercentage = 100;
                TABLA_EGRESOS.SpacingAfter = 10;
                TABLA_EGRESOS.SpacingBefore = 10;
                TABLA_EGRESOS.SetWidths(new float[] { 1.4f, 4f, 6f, 1f, 2f, 5f, 2f });
                PdfPCell CELDA_NUM_EGRESOS = new PdfPCell(new Phrase("#", _mediumFontBoldWhite));
                PdfPCell CELDA_APENOM_EGRESOS = new PdfPCell(new Phrase("APELLIDO Y NOMBRES", _mediumFontBoldWhite));
                PdfPCell CELDA_CONCEPTO_EGRESOS = new PdfPCell(new Phrase("CONCEPTO", _mediumFontBoldWhite));
                PdfPCell CELDA_IMPUTACION_EGRESOS = new PdfPCell(new Phrase("DEBE", _mediumFontBoldWhite));
                PdfPCell CELDA_IMPORTE_EGRESOS = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                PdfPCell CELDA_OBS_EGRESOS = new PdfPCell(new Phrase("OBSERVACIONES", _mediumFontBoldWhite));
                PdfPCell CELDA_ANULADO_EGRESOS = new PdfPCell(new Phrase("ANULADO", _mediumFontBoldWhite));
                CELDA_NUM_EGRESOS.BackgroundColor = topo;
                CELDA_NUM_EGRESOS.BorderColor = blanco;
                CELDA_NUM_EGRESOS.HorizontalAlignment = 1;
                CELDA_NUM_EGRESOS.FixedHeight = 16f;
                CELDA_APENOM_EGRESOS.BackgroundColor = topo;
                CELDA_APENOM_EGRESOS.BorderColor = blanco;
                CELDA_APENOM_EGRESOS.HorizontalAlignment = 1;
                CELDA_APENOM_EGRESOS.FixedHeight = 16f;
                CELDA_CONCEPTO_EGRESOS.BackgroundColor = topo;
                CELDA_CONCEPTO_EGRESOS.BorderColor = blanco;
                CELDA_CONCEPTO_EGRESOS.HorizontalAlignment = 1;
                CELDA_CONCEPTO_EGRESOS.FixedHeight = 16f;
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
                TABLA_EGRESOS.AddCell(CELDA_NUM_EGRESOS);
                TABLA_EGRESOS.AddCell(CELDA_APENOM_EGRESOS);
                TABLA_EGRESOS.AddCell(CELDA_CONCEPTO_EGRESOS);
                TABLA_EGRESOS.AddCell(CELDA_IMPUTACION_EGRESOS);
                TABLA_EGRESOS.AddCell(CELDA_IMPORTE_EGRESOS);
                TABLA_EGRESOS.AddCell(CELDA_OBS_EGRESOS);
                TABLA_EGRESOS.AddCell(CELDA_ANULADO_EGRESOS);
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
                PdfPTable TABLA_TOTAL_INGRESOS = new PdfPTable(2);
                TABLA_TOTAL_INGRESOS.WidthPercentage = 100;
                TABLA_TOTAL_INGRESOS.SpacingAfter = 0;
                TABLA_TOTAL_INGRESOS.SpacingBefore = 0;
                TABLA_TOTAL_INGRESOS.SetWidths(new float[] { 4f, 4f });
                PdfPCell CELDA_TITULO = new PdfPCell(new Phrase("3.01.1.01 INGRESOS DEL DIA (DEBE)", _mediumFontBoldWhite));
                PdfPCell CELDA_TOTAL = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", TOTAL_INGRESOS_EFECTIVO), _mediumFontBoldWhite));
                CELDA_TITULO.BackgroundColor = topo;
                CELDA_TITULO.BorderColor = blanco;
                CELDA_TITULO.HorizontalAlignment = 1;
                CELDA_TITULO.FixedHeight = 16f;
                CELDA_TOTAL.BackgroundColor = topo;
                CELDA_TOTAL.BorderColor = blanco;
                CELDA_TOTAL.HorizontalAlignment = 1;
                CELDA_TOTAL.FixedHeight = 16f;
                TABLA_TOTAL_INGRESOS.AddCell(CELDA_TITULO);
                TABLA_TOTAL_INGRESOS.AddCell(CELDA_TOTAL);
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

                    PdfPCell CELL_IMPORTE_OTROS = new PdfPCell(new Phrase("$ " +string.Format("{0:n}", IMPORTE), _mediumFont));
                    CELL_IMPORTE_OTROS.HorizontalAlignment = 2;
                    CELL_IMPORTE_OTROS.BorderWidth = 0;
                    CELL_IMPORTE_OTROS.BackgroundColor = colorFondo;
                    CELL_IMPORTE_OTROS.FixedHeight = 14f;
                    TABLA_INGRESOS_OTROS.AddCell(CELL_IMPORTE_OTROS);

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
                }

                Paragraph sub2 = new Paragraph("INGRESOS DEL DIA CHEQUES, DEPOSITOS Y TARJETAS", _standardFontBold);
                sub2.Alignment = Element.ALIGN_CENTER;
                sub2.SpacingAfter = 5;
                doc.Add(sub2);
                doc.Add(TABLA_INGRESOS_OTROS);
                #endregion

                #region TOTAL INGRESOS EN OTROS
                PdfPTable TABLA_TOTAL_OTROS = new PdfPTable(2);
                TABLA_TOTAL_OTROS.WidthPercentage = 100;
                TABLA_TOTAL_OTROS.SpacingAfter = 0;
                TABLA_TOTAL_OTROS.SpacingBefore = 0;
                TABLA_TOTAL_OTROS.SetWidths(new float[] { 4f, 4f });
                PdfPCell CELDA_TITULO_OTROS = new PdfPCell(new Phrase("3.01.1.01 INGRESOS DEL DIA (DEBE)", _mediumFontBoldWhite));
                PdfPCell CELDA_TOTAL_OTROS = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", TOTAL_INGRESOS_OTROS), _mediumFontBoldWhite));
                CELDA_TITULO_OTROS.BackgroundColor = topo;
                CELDA_TITULO_OTROS.BorderColor = blanco;
                CELDA_TITULO_OTROS.HorizontalAlignment = 1;
                CELDA_TITULO_OTROS.FixedHeight = 16f;
                CELDA_TOTAL_OTROS.BackgroundColor = topo;
                CELDA_TOTAL_OTROS.BorderColor = blanco;
                CELDA_TOTAL_OTROS.HorizontalAlignment = 1;
                CELDA_TOTAL_OTROS.FixedHeight = 16f;
                TABLA_TOTAL_OTROS.AddCell(CELDA_TITULO_OTROS);
                TABLA_TOTAL_OTROS.AddCell(CELDA_TOTAL_OTROS);
                doc.Add(TABLA_TOTAL_OTROS);
                #endregion

                #region DATOS EGRESOS
                X = 0;
                foreach (DataRow row in EGRESOS.Tables[0].Rows)
                {
                    NUM = row[0].ToString();
                    NOMBRE = row[1].ToString();
                    CONCEPTO = row[2].ToString();
                    DEBE = "301207";
                    IMPORTE = Convert.ToDecimal(row[4]);
                    OBSERVACIONES = row[5].ToString();
                    TIPO = row[6].ToString();
                    ANULADO = row[10].ToString();
                    PTO_VTA = row[12].ToString();

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

                    PdfPCell CELL_NOMBRE_EGRESOS = new PdfPCell(new Phrase(NOMBRE, _mediumFont));
                    CELL_NOMBRE_EGRESOS.BorderWidth = 0;
                    CELL_NOMBRE_EGRESOS.BackgroundColor = colorFondo;
                    CELL_NOMBRE_EGRESOS.FixedHeight = 14f;
                    TABLA_EGRESOS.AddCell(CELL_NOMBRE_EGRESOS);

                    PdfPCell CELL_CONCEPTO_EGRESOS = new PdfPCell(new Phrase(CONCEPTO, _mediumFont));
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
                }

                Paragraph sub3 = new Paragraph("EGRESOS", _standardFontBold);
                sub3.Alignment = Element.ALIGN_CENTER;
                sub3.SpacingAfter = 5;
                doc.Add(sub3);
                doc.Add(TABLA_EGRESOS);
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
                #endregion

                #region DATOS COMPOSICION DE SALDO
                decimal TOTAL_COMPOSICION = 0;

                X = 0;
                string CAMBIO_CAJA = "";
                decimal TOTAL_CHEQUES = 0;
                string DETALLE_CHEQUE = "";
                string IMPORTE_CHEQUE = "";
                string FECHA_CHEQUE = "";

                foreach (DataRow cambio in CAMBIO_DS.Tables[0].Rows)
                {
                    CAMBIO_CAJA = string.Format("{0:n}", Convert.ToDecimal(cambio[0].ToString()));
                }

                foreach (DataRow cheques in CHEQUES.Tables[0].Rows)
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
                CELDA_TITULO_INGRESOS_EFECTIVO.BorderColor = new BaseColor(240, 240, 240);
                CELDA_TITULO_INGRESOS_EFECTIVO.HorizontalAlignment = 0;
                CELDA_TITULO_INGRESOS_EFECTIVO.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_INGRESOS_EFECTIVO);

                PdfPCell CELDA_TOTAL_INGRESOS_EFECTIVO = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", INGRESOS_EFECTIVO), _mediumFont));
                CELDA_TOTAL_INGRESOS_EFECTIVO.BackgroundColor = new BaseColor(240, 240, 240);
                CELDA_TOTAL_INGRESOS_EFECTIVO.BorderColor = new BaseColor(240, 240, 240);
                CELDA_TOTAL_INGRESOS_EFECTIVO.HorizontalAlignment = 2;
                CELDA_TOTAL_INGRESOS_EFECTIVO.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TOTAL_INGRESOS_EFECTIVO);

                PdfPCell CELDA_TITULO_INGRESOS_OTROS = new PdfPCell(new Phrase("TOTAL INGRESOS CHEQUES Y OTROS", _mediumFont));
                CELDA_TITULO_INGRESOS_OTROS.BackgroundColor = blanco;
                CELDA_TITULO_INGRESOS_OTROS.BorderColor = blanco;
                CELDA_TITULO_INGRESOS_OTROS.HorizontalAlignment = 0;
                CELDA_TITULO_INGRESOS_OTROS.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_INGRESOS_OTROS);

                PdfPCell CELDA_TOTAL_INGRESOS_OTROS = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", INGRESOS_OTROS), _mediumFont));
                CELDA_TOTAL_INGRESOS_OTROS.BackgroundColor = blanco;
                CELDA_TOTAL_INGRESOS_OTROS.BorderColor = blanco;
                CELDA_TOTAL_INGRESOS_OTROS.HorizontalAlignment = 2;
                CELDA_TOTAL_INGRESOS_OTROS.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TOTAL_INGRESOS_OTROS);

                PdfPCell CELDA_TITULO_SUBTOTAL_INGRESOS = new PdfPCell(new Phrase("SUBTOTAL INGRESOS DEL DÍA", _mediumFont));
                CELDA_TITULO_SUBTOTAL_INGRESOS.BackgroundColor = new BaseColor(240, 240, 240);
                CELDA_TITULO_SUBTOTAL_INGRESOS.BorderColor = new BaseColor(240, 240, 240);
                CELDA_TITULO_SUBTOTAL_INGRESOS.HorizontalAlignment = 0;
                CELDA_TITULO_SUBTOTAL_INGRESOS.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_SUBTOTAL_INGRESOS);

                PdfPCell CELDA_TOTAL_SUBTOTAL_INGRESOS = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", SUBTOTAL_INGRESOS), _mediumFont));
                CELDA_TOTAL_SUBTOTAL_INGRESOS.BackgroundColor = new BaseColor(240, 240, 240);
                CELDA_TOTAL_SUBTOTAL_INGRESOS.BorderColor = new BaseColor(240, 240, 240);
                CELDA_TOTAL_SUBTOTAL_INGRESOS.HorizontalAlignment = 2;
                CELDA_TOTAL_SUBTOTAL_INGRESOS.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TOTAL_SUBTOTAL_INGRESOS);

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

                PdfPCell CELDA_TITULO_CAJA_DEL_DIA = new PdfPCell(new Phrase("TOTAL DEL DIA", _mediumFont));
                CELDA_TITULO_CAJA_DEL_DIA.BackgroundColor = new BaseColor(240, 240, 240);
                CELDA_TITULO_CAJA_DEL_DIA.BorderColor = new BaseColor(240, 240, 240);
                CELDA_TITULO_CAJA_DEL_DIA.HorizontalAlignment = 0;
                CELDA_TITULO_CAJA_DEL_DIA.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_CAJA_DEL_DIA);

                PdfPCell CELDA_CAJA_DEL_DIA = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", CAJA_DIA), _mediumFont));
                CELDA_CAJA_DEL_DIA.BackgroundColor = new BaseColor(240, 240, 240); 
                CELDA_CAJA_DEL_DIA.BorderColor = new BaseColor(240, 240, 240); 
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
                CELDA_TITULO_SALDO_CAJA_DIA.BorderColor = new BaseColor(240, 240, 240); 
                CELDA_TITULO_SALDO_CAJA_DIA.HorizontalAlignment = 0;
                CELDA_TITULO_SALDO_CAJA_DIA.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TITULO_SALDO_CAJA_DIA);
                
                PdfPCell CELDA_TOTAL_SALDO_CAJA_DIA = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", SALDO_CAJA_DIA), _mediumFont));
                CELDA_TOTAL_SALDO_CAJA_DIA.BackgroundColor = new BaseColor(240, 240, 240);
                CELDA_TOTAL_SALDO_CAJA_DIA.BorderColor = new BaseColor(240, 240, 240); 
                CELDA_TOTAL_SALDO_CAJA_DIA.HorizontalAlignment = 2;
                CELDA_TOTAL_SALDO_CAJA_DIA.FixedHeight = 16f;
                TABLA_TOTALES_DIA.AddCell(CELDA_TOTAL_SALDO_CAJA_DIA);

                doc.Add(TABLA_TOTALES_DIA);
                #endregion

                doc.Close();
                writer.Close();
                AddPageNumber(PATH);
                Cursor = Cursors.Default;

                DialogResult result = MessageBox.Show("PLANILLA DE CAJA CREADA CORRECTAMENTE \n\n ¿ABRIR EL ARCHIVO? \n\n " + PATH, "LISTO!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(PATH);
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
                    dgComposicion.Rows.Add("", "CAMBIO",  string.Format("{0:n}", (Convert.ToDecimal(tbCambio.Text.Trim()))));
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
                    MessageBox.Show("NO SE PUDIERON DEPOSITAR LAS CAJAS", "ERROR");
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

        private void nuevaFormaDePago(object SENDER, int FORMA_DE_PAGO)
        {
            string COMPROBANTE = "X";
            int ID_COMP = 0;

            //EFECTIVO
            if (SENDER == btnNuevoPagoEfectivo)
            {
                foreach (DataGridViewRow ROW in dgEfectivo.SelectedRows)
                {
                    COMPROBANTE = ROW.Cells[0].Value.ToString().Substring(0, 1);
                    
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
            }

            //OTROS
            if (SENDER == btnNuevoPagoOtros)
            {
                foreach (DataGridViewRow ROW in dgOtros.SelectedRows)
                {
                    COMPROBANTE = ROW.Cells[0].Value.ToString().Substring(0, 1);

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
            }
        }

        private bool nuevoImporte(object SENDER)
        { 
            string COMPROBANTE = "X";
            int ID = 0;
            int SELECCION = 0;
            decimal NUEVO_IMPORTE = 0;

            //EFECTIVO
            if (SENDER == btnNuevoImporteEfectivo)
            {
                SELECCION = dgEfectivo.SelectedRows.Count;

                if (SELECCION == 1)
                {
                    if (tbNuevoImporteEfectivo.Text != "")
                    {
                        NUEVO_IMPORTE = decimal.Parse(tbNuevoImporteEfectivo.Text);

                        foreach (DataGridViewRow ROW in dgEfectivo.SelectedRows)
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
            }

            //OTROS
            if (SENDER == btnNuevoImporteOtros)
            {
                SELECCION = dgOtros.SelectedRows.Count;

                if (SELECCION == 1)
                {
                    if (tbNuevoImporteOtros.Text != "")
                    {
                        NUEVO_IMPORTE = decimal.Parse(tbNuevoImporteOtros.Text);

                        foreach (DataGridViewRow ROW in dgOtros.SelectedRows)
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
            }

            return false;
        }

        private void btnNuevoPagoEfectivo_Click(object sender, EventArgs e)
        {
            int FORMA_DE_PAGO = int.Parse(cbNuevoPagoEfectivo.SelectedValue.ToString());
            nuevaFormaDePago(sender, FORMA_DE_PAGO);
            cargaInicial(CAJA);
        }

        private void btnNuevoPagoOtros_Click(object sender, EventArgs e)
        {
            int FORMA_DE_PAGO = int.Parse(cbNuevoPagoOtros.SelectedValue.ToString());
            nuevaFormaDePago(sender, FORMA_DE_PAGO);
            cargaInicial(CAJA);
        }

        private void btnNuevoImporteEfectivo_Click(object sender, EventArgs e)
        {
            if (nuevoImporte(sender) == true)
                cargaInicial(CAJA);
        }

        private void btnNuevoImporteOtros_Click(object sender, EventArgs e)
        {
            if (nuevoImporte(sender) == true)
                cargaInicial(CAJA);
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
    }
}