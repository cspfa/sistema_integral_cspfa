using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOCIOS;

namespace Confiteria
{
    public partial class importador : Form
    {
        string ROL { get; set; }
        bo dlog = new bo();
        db db = new db();

        public importador(string P_ROL)
        {
            InitializeComponent();
            ROL = P_ROL;
            cajasDiarias();
            comandas();
        }

        private DataRow[] getCajas()
        {
            DataRow[] CAJAS = null;
            string QUERY_CAJAS = "SELECT * FROM CONFITERIA_CAJA_DIARIA WHERE ROL = '" + ROL + "' AND EXPORTADA = 0 ORDER BY ID DESC;";
            CAJAS = dlog.BO_EjecutoDataTable_Remota(QUERY_CAJAS, ROL).Select();
            return CAJAS;
        }

        private DataRow[] getComandas()
        {
            DataRow[] COMANDAS = null;
            string QUERY_COMANDAS = "SELECT * FROM CONFITERIA_COMANDAS WHERE ROL = '" + ROL + "' AND EXPORTADA = 0";
            COMANDAS = dlog.BO_EjecutoDataTable_Remota(QUERY_COMANDAS, ROL).Select();
            return COMANDAS;
        }

        private void cajasDiarias()
        {
            conString conString = new conString();
            string connectionString = conString.getRemota(ROL);

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string QUERY = "SELECT * FROM CONFITERIA_CAJA_DIARIA_S WHERE EXPORTADA = 0 AND ROL = '" + ROL + "';";
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    dgCajasAnteriores.Rows.Clear();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string ID = row[0].ToString().Trim();
                        string FECHA = row[1].ToString().Trim().Substring(0, 10);
                        string USUARIO = row[2].ToString().Trim();
                        decimal EFECTIVO = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(row[3].ToString()))));
                        decimal TARJETAS = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(row[4].ToString()))));
                        decimal DESCUENTOS = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(row[5].ToString()))));
                        decimal ESPECIALES = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(row[6].ToString()))));
                        dgCajasAnteriores.Rows.Add(ID, FECHA, USUARIO, EFECTIVO, TARJETAS, DESCUENTOS, ESPECIALES);
                    }

                    dgCajasAnteriores.ClearSelection();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void comandas()
        {
            conString conString = new conString();
            string connectionString = conString.getRemota(ROL);

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string QUERY = "SELECT NRO_COMANDA, FECHA, IMPORTE, NOMBRE_SOCIO, NRO_SOC, NRO_DEP, ID FROM CONFITERIA_COMANDAS WHERE EXPORTADA = 0 AND ROL = '" + ROL + "';";
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    dgComandas.Rows.Clear();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string NRO_COMANDA = row[0].ToString().Trim();
                        decimal IMPORTE = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(row[2].ToString()))));
                        string FECHA = row[1].ToString().Trim().Substring(0, 10);
                        string NOMBRE = row[3].ToString().Trim();
                        string NRO_SOC = row[4].ToString().Trim();
                        string NRO_DEP = row[5].ToString().Trim();
                        string ID = row[6].ToString().Trim();
                        dgComandas.Rows.Add(NRO_COMANDA, IMPORTE, FECHA, NOMBRE, NRO_SOC, NRO_DEP, ID);
                    }

                    dgComandas.ClearSelection();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void importar()
        {
            if (MessageBox.Show("¿IMPORTAR COMANDAS Y CAJAS DIARIAS?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataRow[] CAJAS = getCajas();
                DataRow[] COMANDAS = getComandas();
                
                if (CAJAS.Length > 0)
                {
                    int MAX = CAJAS.Length;
                    pbImportar.Visible = true;
                    pbImportar.Maximum = MAX;
                    pbImportar.Step = 1;

                    int ID; string FECHA; string USUARIO; decimal EFECTIVO; decimal TARJETAS; decimal DESCUENTOS; decimal ESPECIALES;
                    string ROL;

                    foreach (DataRow ROW_CAJA in CAJAS)
                    {
                        ID = int.Parse(ROW_CAJA[0].ToString());
                        FECHA = ROW_CAJA[1].ToString().Replace(" 00:00:00", "");
                        USUARIO = ROW_CAJA[2].ToString().Trim();
                        EFECTIVO = decimal.Parse(ROW_CAJA[3].ToString());
                        TARJETAS = decimal.Parse(ROW_CAJA[4].ToString());
                        DESCUENTOS = decimal.Parse(ROW_CAJA[5].ToString());
                        ESPECIALES = decimal.Parse(ROW_CAJA[6].ToString());
                        ROL = ROW_CAJA[7].ToString().Trim();
                        dlog.impCajaDiariaConfiteria(FECHA, USUARIO, EFECTIVO, TARJETAS, DESCUENTOS, ESPECIALES, ROL);
                        marcarExportado("CONFITERIA_CAJA_DIARIA", "EXPORTADA", ID);
                        pbImportar.PerformStep();
                    }
                    pbImportar.Visible = false;
                }

                if (COMANDAS.Length > 0)
                {
                    int MAX = COMANDAS.Length;
                    pbImportar.Visible = true;
                    pbImportar.Maximum = MAX;
                    pbImportar.Step = 1;

                    int ID; string FECHA; int MESA; int MOZO; decimal IMPORTE; int NRO_SOC; int NRO_DEP; int BARRA; int PERSONAS; string NOMBRE_SOCIO;
                    string AFILIADO; string BENEFICIO; string USUARIO; int DESCUENTO; int FORMA_DE_PAGO; int RENDIDA; int CONTRALOR; string ANULADA;
                    string USR_ANULA; string COM_BORRADOR; string CONSUME; int TIPO_COMANDA; int DESCUENTO_APLICADO; decimal IMPORTE_DESCONTADO;
                    int NRO_COMANDA; string ROL;

                    foreach (DataRow ROW_COMANDA in COMANDAS)
                    {
                        ID = int.Parse(ROW_COMANDA[0].ToString()); FECHA = ROW_COMANDA[1].ToString().Replace(" 00:00:00", "");
                        MESA = int.Parse(ROW_COMANDA[2].ToString()); MOZO = int.Parse(ROW_COMANDA[3].ToString());
                        IMPORTE = decimal.Parse(ROW_COMANDA[4].ToString()); NRO_SOC = int.Parse(ROW_COMANDA[5].ToString());
                        NRO_DEP = int.Parse(ROW_COMANDA[6].ToString()); BARRA = int.Parse(ROW_COMANDA[7].ToString());
                        PERSONAS = int.Parse(ROW_COMANDA[8].ToString()); NOMBRE_SOCIO = ROW_COMANDA[9].ToString();
                        AFILIADO = ROW_COMANDA[10].ToString(); BENEFICIO = ROW_COMANDA[11].ToString(); USUARIO = ROW_COMANDA[12].ToString();
                        DESCUENTO = int.Parse(ROW_COMANDA[13].ToString()); FORMA_DE_PAGO = int.Parse(ROW_COMANDA[14].ToString());
                        RENDIDA = int.Parse(ROW_COMANDA[15].ToString()); CONTRALOR = int.Parse(ROW_COMANDA[16].ToString());
                        ANULADA = ROW_COMANDA[17].ToString(); USR_ANULA = ROW_COMANDA[18].ToString(); COM_BORRADOR = ROW_COMANDA[19].ToString();
                        CONSUME = ROW_COMANDA[20].ToString(); TIPO_COMANDA = int.Parse(ROW_COMANDA[21].ToString());
                        DESCUENTO_APLICADO = int.Parse(ROW_COMANDA[22].ToString()); IMPORTE_DESCONTADO = decimal.Parse(ROW_COMANDA[23].ToString());
                        NRO_COMANDA = int.Parse(ROW_COMANDA[24].ToString()); ROL = ROW_COMANDA[25].ToString();

                        dlog.impComandaConfiteria(FECHA, MESA, MOZO, IMPORTE, NRO_SOC, NRO_DEP, BARRA, PERSONAS, NOMBRE_SOCIO, AFILIADO, BENEFICIO, USUARIO,
                            DESCUENTO, FORMA_DE_PAGO, RENDIDA, CONTRALOR, ANULADA, USR_ANULA, COM_BORRADOR, CONSUME, TIPO_COMANDA, DESCUENTO_APLICADO,
                            IMPORTE_DESCONTADO, NRO_COMANDA, ROL);
                        marcarExportado("CONFITERIA_COMANDAS", "EXPORTADA", ID);
                        pbImportar.PerformStep();
                    }
                    pbImportar.Visible = false;
                }
            }
        }

        private void marcarExportado(string TABLA, string CAMPO, int ID)
        {
            try
            {
                string QUERY = "UPDATE " + TABLA + " SET " + CAMPO + " = 1 WHERE ID = " + ID + ";";
                db.Ejecuto_Consulta_Remota(QUERY, ROL);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            importar();
        }
    }
}
