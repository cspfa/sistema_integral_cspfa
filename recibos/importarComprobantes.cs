using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS
{
    public partial class importarComprobantes : Form
    {
        bo dlog = new bo();
        db db = new db();
        BO.bo_Caja CAJA = new BO.bo_Caja();

        string ROLE { get; set; }
        string PTO_VTA { get; set; }
        int CONECTADA { get; set; }

        public importarComprobantes(string TITULO, string ROL)
        {
            InitializeComponent();
            this.Text = TITULO;
            ROLE = ROL;
        }

        private string testConnection()
        {
            string CONN = "";
            string QUERY = "SELECT FIRST(1) ID_TITULAR FROM TITULAR;";
            DataRow[] foundRows;

            try
            {
                foundRows = dlog.BO_EjecutoDataTable_Remota(QUERY, ROLE).Select();
                CONN = "BASE DE DATOS: Conectada";
                CONECTADA = 1;
            }
            catch (Exception error)
            {
                CONN = "BASE DE DATOS: Desconectada";
                CONECTADA = 0;
            }
            
            return CONN;
        }

        private void importarComprobantes_Load(object sender, EventArgs e)
        {
            cargaInicial();
        }

        private void cargaInicial()
        {
            lbConexion.Text = testConnection();

            if (CONECTADA == 1)
            {
                buscarCajas(dgCajasAnteriores);
                dgCajasAnteriores.ClearSelection();
                dgCajasAnteriores.Enabled = false;
                buscarComprobantes(dgEfectivo);
                dgEfectivo.ClearSelection();
                //dgEfectivo.Enabled = false;
            }
        }

        private void buscarCajas(DataGridView GRILLA)
        {
            try
            {
                conString cs = new conString();
                string connectionString = cs.getRemota(ROLE);
                DataSet ds1 = new DataSet();
                Datos_ini ini3 = new Datos_ini();
                string query = "SELECT * FROM CAJA_DIARIA_S('" + ROLE + "') WHERE DEPOSITADA IN (0,1,2) AND EXPORTADA = 0;";

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

        private void buscarComprobantes(DataGridView GRID)
        {
            try
            {
                DataSet ds1 = new DataSet();
                string query = "SELECT * FROM PLANILLA_CAJA_IMPORTAR ('" + ROLE + "');";
                conString cs = new conString();
                string connectionString = cs.getRemota(ROLE);

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private DataRow[] cajas()
        {
            DataRow[] CAJAS = null;
            string QUERY_CAJAS = "SELECT * FROM CAJA_DIARIA WHERE ROL = '" + ROLE + "' AND EXPORTADA = 0 ORDER BY ID DESC;";
            CAJAS = dlog.BO_EjecutoDataTable_Remota(QUERY_CAJAS, ROLE).Select();
            return CAJAS;
        }

        private DataRow[] recibos()
        {
            DataRow[] RECIBOS = null;
            string QUERY_RECIBOS = "SELECT * FROM RECIBOS_CAJA WHERE ROL = '" + ROLE + "' AND EXPORTADO = 0";
            RECIBOS = dlog.BO_EjecutoDataTable_Remota(QUERY_RECIBOS, ROLE).Select();
            return RECIBOS;
        }

        private DataRow[] bonos()
        {
            DataRow[] BONOS = null;
            string QUERY_BONOS = "SELECT * FROM BONOS_CAJA WHERE ROL = '" + ROLE + "' AND EXPORTADO = 0";
            BONOS = dlog.BO_EjecutoDataTable_Remota(QUERY_BONOS, ROLE).Select();
            return BONOS;
        }

        private void marcarExportado(string TABLA, string CAMPO, int ID)
        {
            try
            {
                string QUERY = "UPDATE " + TABLA + " SET " + CAMPO + " = 1 WHERE ID = " + ID + ";";
                db.Ejecuto_Consulta_Remota(QUERY, ROLE);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿IMPORTAR COMPROBANTES Y CAJAS DIARIAS?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRow[] CAJAS = cajas();
                DataRow[] RECIBOS = recibos();
                //DataRow[] BONOS = bonos();
                int MAX = CAJAS.Length + RECIBOS.Length;
                pbImportar.Visible = true;
                pbImportar.Maximum = MAX;
                pbImportar.Step = 1;

                if (CAJAS.Length > 0)
                {
                    int ID; string FECHA; string US_ALTA; string FE_ALTA; decimal INGRESOS_EFECTIVO; decimal INGRESOS_OTROS; decimal SUBTOTAL_INGRESOS; decimal EGRESOS;
                    decimal SALDO_CAJA; string ROL; decimal TOTAL; int DEPOSITADA; int BANCO; int IMPUTACION; int CAJA_DEPOSITADA; string CODIGO_DEPOSITO; int EXPORTADA; int ID_ROL;

                    foreach (DataRow ROW_CAJA in CAJAS)
                    {
                        ID = int.Parse(ROW_CAJA[0].ToString()); FECHA = ROW_CAJA[1].ToString().Replace(" 0:00:00", ""); US_ALTA = ROW_CAJA[2].ToString().Trim(); 
                        FE_ALTA = ROW_CAJA[3].ToString(); INGRESOS_EFECTIVO = decimal.Parse(ROW_CAJA[4].ToString()); INGRESOS_OTROS = decimal.Parse(ROW_CAJA[5].ToString()); 
                        SUBTOTAL_INGRESOS = decimal.Parse(ROW_CAJA[6].ToString()); EGRESOS = decimal.Parse(ROW_CAJA[7].ToString()); SALDO_CAJA = decimal.Parse(ROW_CAJA[8].ToString()); 
                        ROL = ROW_CAJA[9].ToString().Trim(); TOTAL = decimal.Parse(ROW_CAJA[10].ToString()); DEPOSITADA = int.Parse(ROW_CAJA[11].ToString()); BANCO = int.Parse(ROW_CAJA[12].ToString()); 
                        IMPUTACION = int.Parse(ROW_CAJA[13].ToString()); CAJA_DEPOSITADA = int.Parse(ROW_CAJA[14].ToString()); CODIGO_DEPOSITO = ROW_CAJA[15].ToString().Trim();
                        EXPORTADA = int.Parse(ROW_CAJA[16].ToString()); ID_ROL = int.Parse(ROW_CAJA[17].ToString());

                        CAJA.importarCajaDiaria(FECHA, US_ALTA, INGRESOS_EFECTIVO, INGRESOS_OTROS, SUBTOTAL_INGRESOS, EGRESOS, SALDO_CAJA, ROL, TOTAL, DEPOSITADA, BANCO, IMPUTACION, 
                        CAJA_DEPOSITADA, CODIGO_DEPOSITO, ID_ROL);

                        marcarExportado("CAJA_DIARIA", "EXPORTADA", ID);

                        pbImportar.PerformStep();
                    }
                }

                if (RECIBOS.Length > 0)
                {
                    int ID; int CUENTA_DEBE; int CUENTA_HABER; int SECTACT; int ID_SOCIO; decimal VALOR; string FECHA_ALTA; string FORMA_PAGO; string USUARIO; int DESTINO;
                    string USUARIO_MOD; string FECHA_RECIBO; int ID_PROFESIONAL; string ANULADO; string NOMBRE_SOCIO_TITULAR; string TIPO_SOCIO_TITULAR; string OBSERVACIONES;
                    string FECHA_CAJA; int BARRA; string NOMBRE_SOCIO; string TIPO_SOCIO; Int64 DNI; string TIPO_SOCIO_NO_TITULAR; int CAJA_DIARIA; int DEPOSITADO; string ROL;
                    int NRO_COMP; int EGRESO; string PTO_VTA; int EXPORTADO; string CAE; string CAE_VENC; int PTO_VTA_E = 0; int NUMERO_E = 0; string USR_FACT;

                    foreach (DataRow ROW_RECIBO in RECIBOS)
                    {
                        ID = int.Parse(ROW_RECIBO[0].ToString()); CUENTA_DEBE = int.Parse(ROW_RECIBO[1].ToString()); CUENTA_HABER = int.Parse(ROW_RECIBO[2].ToString());
                        SECTACT = int.Parse(ROW_RECIBO[3].ToString()); ID_SOCIO = int.Parse(ROW_RECIBO[4].ToString()); VALOR = decimal.Parse(ROW_RECIBO[5].ToString());
                        FECHA_ALTA = ROW_RECIBO[6].ToString(); FORMA_PAGO = ROW_RECIBO[7].ToString(); USUARIO = ROW_RECIBO[8].ToString(); DESTINO = int.Parse(ROW_RECIBO[9].ToString());
                        USUARIO_MOD = ROW_RECIBO[10].ToString(); FECHA_RECIBO = ROW_RECIBO[11].ToString(); ID_PROFESIONAL = int.Parse(ROW_RECIBO[12].ToString()); ANULADO = ROW_RECIBO[13].ToString();
                        NOMBRE_SOCIO_TITULAR = ROW_RECIBO[14].ToString(); TIPO_SOCIO_TITULAR = ROW_RECIBO[15].ToString(); OBSERVACIONES = ROW_RECIBO[16].ToString(); FECHA_CAJA = ROW_RECIBO[17].ToString();
                        BARRA = int.Parse(ROW_RECIBO[18].ToString()); NOMBRE_SOCIO = ROW_RECIBO[19].ToString(); TIPO_SOCIO = ROW_RECIBO[20].ToString(); DNI = Int64.Parse(ROW_RECIBO[21].ToString());
                        TIPO_SOCIO_NO_TITULAR = ROW_RECIBO[22].ToString(); CAJA_DIARIA = int.Parse(ROW_RECIBO[23].ToString()); DEPOSITADO = int.Parse(ROW_RECIBO[24].ToString());
                        ROL = ROW_RECIBO[25].ToString(); NRO_COMP = int.Parse(ROW_RECIBO[26].ToString()); EGRESO = int.Parse(ROW_RECIBO[27].ToString());
                        PTO_VTA = ROW_RECIBO[31].ToString();
                        EXPORTADO = int.Parse(ROW_RECIBO[32].ToString());
                        CAE = ROW_RECIBO[35].ToString();
                        CAE_VENC = ROW_RECIBO[36].ToString();

                        if(ROW_RECIBO[37].ToString()!="")
                            PTO_VTA_E = int.Parse(ROW_RECIBO[37].ToString());

                        if(ROW_RECIBO[38].ToString()!="")
                            NUMERO_E = int.Parse(ROW_RECIBO[38].ToString());

                        USR_FACT = ROW_RECIBO[39].ToString();

                        try
                        {
                            CAJA.importarRecibos(NRO_COMP, CUENTA_DEBE, CUENTA_HABER, VALOR, FORMA_PAGO, SECTACT, USUARIO_MOD, FECHA_RECIBO, ID_SOCIO, ID_PROFESIONAL,
                            NOMBRE_SOCIO_TITULAR, TIPO_SOCIO_TITULAR, OBSERVACIONES, BARRA, NOMBRE_SOCIO, TIPO_SOCIO, DNI, PTO_VTA, CAJA_DIARIA, ROLE, DEPOSITADO, CAE, 
                            CAE_VENC, PTO_VTA_E, NUMERO_E, USR_FACT);
                        }
                        catch(Exception error)
                        {
                            MessageBox.Show(error.ToString());
                            //MessageBox.Show(NRO_COMP+"-"+CUENTA_DEBE+"-"+CUENTA_HABER+"-"+VALOR+"-"+FORMA_PAGO+"-"+SECTACT+"-"+USUARIO_MOD+"-"+FECHA_RECIBO+"-"+ID_SOCIO+"-"+ID_PROFESIONAL,
                            //NOMBRE_SOCIO_TITULAR+"-"+TIPO_SOCIO_TITULAR+"-"+OBSERVACIONES+"-"+BARRA+"-"+NOMBRE_SOCIO+"-"+TIPO_SOCIO+"-"+DNI+"-"+PTO_VTA+"-"+CAJA_DIARIA+"-"+ROLE);
                        }

                        marcarExportado("RECIBOS_CAJA", "EXPORTADO", ID);

                        pbImportar.PerformStep();
                    }
                }

                /*if (BONOS.Length > 0)
                {
                    int ID; int CUENTA_DEBE; int CUENTA_HABER; int SECTACT; int ID_SOCIO; decimal VALOR; string FECHA_ALTA; string FORMA_PAGO; string USUARIO; int DESTINO;
                    string USUARIO_MOD; string FECHA_RECIBO; int ID_PROFESIONAL; string ANULADO; string NOMBRE_SOCIO_TITULAR; string TIPO_SOCIO_TITULAR; string OBSERVACIONES;
                    string FECHA_CAJA; int BARRA; string NOMBRE_SOCIO; string TIPO_SOCIO; int DNI; string TIPO_SOCIO_NO_TITULAR; int CAJA_DIARIA; string ROL; int NRO_COMP;
                    string PTO_VTA; int EXPORTADO;

                    foreach (DataRow ROW_BONO in BONOS)
                    {
                        ID = int.Parse(ROW_BONO[0].ToString()); CUENTA_DEBE = int.Parse(ROW_BONO[1].ToString()); CUENTA_HABER = int.Parse(ROW_BONO[2].ToString());
                        SECTACT = int.Parse(ROW_BONO[3].ToString()); ID_SOCIO = int.Parse(ROW_BONO[4].ToString()); VALOR = decimal.Parse(ROW_BONO[5].ToString());
                        FECHA_ALTA = ROW_BONO[6].ToString(); FORMA_PAGO = ROW_BONO[7].ToString(); USUARIO = ROW_BONO[8].ToString(); DESTINO = int.Parse(ROW_BONO[9].ToString());
                        USUARIO_MOD = ROW_BONO[10].ToString(); FECHA_RECIBO = ROW_BONO[11].ToString(); ID_PROFESIONAL = int.Parse(ROW_BONO[12].ToString()); ANULADO = ROW_BONO[13].ToString();
                        NOMBRE_SOCIO_TITULAR = ROW_BONO[14].ToString(); TIPO_SOCIO_TITULAR = ROW_BONO[15].ToString(); OBSERVACIONES = ROW_BONO[16].ToString();
                        FECHA_CAJA = ROW_BONO[17].ToString(); BARRA = int.Parse(ROW_BONO[18].ToString()); NOMBRE_SOCIO = ROW_BONO[19].ToString(); TIPO_SOCIO = ROW_BONO[20].ToString();
                        DNI = int.Parse(ROW_BONO[21].ToString()); TIPO_SOCIO_NO_TITULAR = ROW_BONO[22].ToString(); CAJA_DIARIA = int.Parse(ROW_BONO[23].ToString());
                        ROL = ROW_BONO[24].ToString(); NRO_COMP = int.Parse(ROW_BONO[25].ToString()); PTO_VTA = ROW_BONO[26].ToString(); EXPORTADO = int.Parse(ROW_BONO[27].ToString());

                        CAJA.importarBonos(NRO_COMP, CUENTA_DEBE, CUENTA_HABER, VALOR, FORMA_PAGO, SECTACT, USUARIO_MOD, FECHA_RECIBO, ID_SOCIO, ID_PROFESIONAL, NOMBRE_SOCIO_TITULAR,
                        TIPO_SOCIO_TITULAR, OBSERVACIONES, BARRA, NOMBRE_SOCIO, TIPO_SOCIO, DNI, PTO_VTA, CAJA_DIARIA, ROLE);

                        marcarExportado("BONOS_CAJA", "EXPORTADO", ID);

                        pbImportar.PerformStep();
                    }
                }*/

                MessageBox.Show("CAJAS Y COMPROBANTES IMPORTADOS CORRECTAMENTE", "LISTO");
                pbImportar.Visible = false;
                cargaInicial();
            }
        }
    }
}
