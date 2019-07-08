using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using Excel = Microsoft.Office.Interop.Excel;
using SOCIOS;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Confiteria
{
    public partial class listadoComandas : Form
    {
        bo dlog = new bo();

        private DataSet ITEMS { get; set; }
        private DataSet COMANDA { get; set; }
        private DataSet SOLICITUD { get; set; }
        private DataSet LISTADO { get; set; }

        public listadoComandas()
        {
            InitializeComponent();
        }

        private void listadoComandas_Load(object sender, EventArgs e)
        {
            comboFormasDePago();
            comboComprobantes();
            subitemsFormasDePago();
            subitemsTipoDeComanda();
            comboTipoDeComanda();
            llenarGrillaComandas();
            modificarItemsToolStripMenuItem.Visible = true;
        }

        public void comboComprobantes()
        {
            cbTipoComprobante.Items.Add("COMANDA");
            cbTipoComprobante.Items.Add("SOLICITUD DE DESCUENTO");
            cbTipoComprobante.SelectedIndex = 0;
        }

        public void comboTipoDeComanda()
        {
            cbTipoDeComanda.DataSource = null;
            string query = "SELECT * FROM CONFITERIA_TIPO_COMANDA ORDER BY ID ASC;";
            cbTipoDeComanda.Items.Clear();
            cbTipoDeComanda.DataSource = dlog.BO_EjecutoDataTable(query);
            cbTipoDeComanda.DisplayMember = "TIPO";
            cbTipoDeComanda.ValueMember = "ID";
            cbTipoDeComanda.SelectedIndex = 0;
        }

        public void comboFormasDePago()
        {
            cbFormaDePago.DataSource = null;
            string query = "SELECT * FROM FORMAS_DE_PAGO ORDER BY ID ASC;";
            cbFormaDePago.Items.Clear();
            cbFormaDePago.DataSource = dlog.BO_EjecutoDataTable(query);
            cbFormaDePago.DisplayMember = "DETALLE";
            cbFormaDePago.ValueMember = "ID";
            cbFormaDePago.SelectedIndex = 0;
        }

        private void llenarGrillaComandas()
        {
            char[] sep = {'/'};
            string[] DE = dpDesde.Text.Split(sep);
            string[] HA = dpHasta.Text.Split(sep);
            string DESDE = DE[1] + "/" + DE[0] + "/" + DE[2];
            string HASTA = HA[1] + "/" + HA[0] + "/" + HA[2];
            string FORMA_DE_PAGO = cbFormaDePago.SelectedValue.ToString();
            int TIPO_DE_COMANDA = int.Parse(cbTipoDeComanda.SelectedValue.ToString());
            string HORA_DESDE = tbHoraDesde.Text;
            string HORA_HASTA = tbHoraHasta.Text;
            buscarComandas(DESDE, HASTA, 0, FORMA_DE_PAGO, 0, TIPO_DE_COMANDA, HORA_DESDE, HORA_HASTA);
        }

        private void buscarComandas(string DESDE, string HASTA, int ID_COMANDA, string FORMA_DE_PAGO, int ID_SOLICITUD, int TIPO_DE_COMANDA, string HORA_DESDE, string HORA_HASTA)
        {
            conString conString = new conString();
            string connectionString = conString.get();

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    LISTADO = ds;
                    
                    string QUERY = "";
                    string COMPROBANTE = cbTipoComprobante.SelectedItem.ToString();
                    lbComprobante.Text = COMPROBANTE;

                    if (COMPROBANTE == "COMANDA")
                    {
                        if (ID_COMANDA == 0)
                        {
                            if (cbSoloAnuladas.Checked == false)
                            {
                                if (FORMA_DE_PAGO == "10")
                                {
                                    QUERY = "SELECT C.ID, C.FECHA, C.IMPORTE, C.NOMBRE_SOCIO, C.NRO_SOC, C.NRO_DEP, C.BARRA, C.AFILIADO, C.BENEFICIO, C.DESCUENTO, C.CONTRALOR, F.DETALLE, C.ANULADA, C.COM_BORRADOR, C.CONSUME, C.PERSONAS, C.NRO_COMANDA, C.MESA ";
                                    QUERY += "FROM CONFITERIA_COMANDAS C, FORMAS_DE_PAGO F WHERE CAST(C.FECHA AS DATE) >= '" + DESDE + "' AND CAST(C.FECHA AS DATE) <= '" + HASTA + "' AND EXTRACT(HOUR FROM FECHA) >= " + HORA_DESDE;
                                    QUERY += " AND EXTRACT(HOUR FROM FECHA) <= " + HORA_HASTA + " AND C.FORMA_DE_PAGO = F.ID AND C.TIPO_COMANDA = " + TIPO_DE_COMANDA + " AND C.ROL = '" + VGlobales.vp_role + "' ORDER BY FECHA DESC";
                                }
                                else
                                {
                                    QUERY = "SELECT C.ID, C.FECHA, C.IMPORTE, C.NOMBRE_SOCIO, C.NRO_SOC, C.NRO_DEP, C.BARRA, C.AFILIADO, C.BENEFICIO, C.DESCUENTO, C.CONTRALOR, F.DETALLE, C.ANULADA, C.COM_BORRADOR, C.CONSUME, C.PERSONAS, C.NRO_COMANDA, C.MESA ";
                                    QUERY += "FROM CONFITERIA_COMANDAS C, FORMAS_DE_PAGO F WHERE CAST(C.FECHA AS DATE) >= '" + DESDE + "' AND CAST(C.FECHA AS DATE) <= '" + HASTA + "' AND EXTRACT(HOUR FROM FECHA) >= " + HORA_DESDE;
                                    QUERY += " AND EXTRACT(HOUR FROM FECHA) <= " + HORA_HASTA + " AND C.FORMA_DE_PAGO = " + FORMA_DE_PAGO + " AND C.FORMA_DE_PAGO = F.ID AND C.TIPO_COMANDA = " + TIPO_DE_COMANDA + " AND C.ROL = '" + VGlobales.vp_role + "' ORDER BY FECHA DESC";
                                }

                            }
                            else
                            {
                                if (FORMA_DE_PAGO == "10")
                                {
                                    QUERY = "SELECT C.ID, C.FECHA, C.IMPORTE, C.NOMBRE_SOCIO, C.NRO_SOC, C.NRO_DEP, C.BARRA, C.AFILIADO, C.BENEFICIO, C.DESCUENTO, C.CONTRALOR, F.DETALLE, C.ANULADA, C.COM_BORRADOR, C.CONSUME, C.PERSONAS, C.NRO_COMANDA, C.MESA ";
                                    QUERY += "FROM CONFITERIA_COMANDAS C, FORMAS_DE_PAGO F WHERE CAST(C.FECHA AS DATE) >= '" + DESDE + "' AND CAST(C.FECHA AS DATE) <= '" + HASTA + "' AND EXTRACT(HOUR FROM FECHA) >= " + HORA_DESDE;
                                    QUERY += " AND EXTRACT(HOUR FROM FECHA) <= " + HORA_HASTA + " AND C.FORMA_DE_PAGO = " + FORMA_DE_PAGO + " AND C.FORMA_DE_PAGO = F.ID AND C.ANULADA IS NOT NULL AND C.TIPO_COMANDA = " + TIPO_DE_COMANDA + " AND C.ROL = '" + VGlobales.vp_role + "' ORDER BY FECHA DESC";
                                }
                                else
                                {
                                    QUERY = "SELECT C.ID, C.FECHA, C.IMPORTE, C.NOMBRE_SOCIO, C.NRO_SOC, C.NRO_DEP, C.BARRA, C.AFILIADO, C.BENEFICIO, C.DESCUENTO, C.CONTRALOR, F.DETALLE, C.ANULADA, C.COM_BORRADOR, C.CONSUME, C.PERSONAS, C.NRO_COMANDA, C.MESA ";
                                    QUERY += "FROM CONFITERIA_COMANDAS C, FORMAS_DE_PAGO F WHERE CAST(C.FECHA AS DATE) >= '" + DESDE + "' AND CAST(C.FECHA AS DATE) <= '" + HASTA + "' AND EXTRACT(HOUR FROM FECHA) >= " + HORA_DESDE;
                                    QUERY += " AND EXTRACT(HOUR FROM FECHA) <= " + HORA_HASTA + " AND C.ANULADA IS NOT NULL AND C.FORMA_DE_PAGO = F.ID AND C.TIPO_COMANDA = " + TIPO_DE_COMANDA + " AND C.ROL = '" + VGlobales.vp_role + "' ORDER BY FECHA DESC";
                                }
                            }
                        }
                        else
                        {
                            QUERY = "SELECT C.ID, C.FECHA, C.MESA, M.NOMBRE, C.IMPORTE, C.NRO_SOC, C.NRO_DEP, C.BARRA, C.PERSONAS, C.NOMBRE_SOCIO, C.AFILIADO, C.BENEFICIO, C.USUARIO, C.DESCUENTO, F.DETALLE, C.CONTRALOR, C.COM_BORRADOR, C.DESCUENTO_APLICADO, C.IMPORTE_DESCONTADO, C.NRO_COMANDA ";
                            QUERY += "FROM CONFITERIA_COMANDAS C, CONFITERIA_MOZOS M, FORMAS_DE_PAGO F ";
                            QUERY += "WHERE C.ID = " + ID_COMANDA + " AND C.MOZO = M.ID AND C.FORMA_DE_PAGO = F.ID;";
                        }
                    }
                    else if (COMPROBANTE == "SOLICITUD DE DESCUENTO")
                    {
                        if (ID_SOLICITUD == 0)
                        {
                            QUERY = "SELECT D.ID, D.FECHA, D.IMPORTE, D.NOM_SOC, C.NRO_SOC, C.NRO_DEP, C.BARRA, C.AFILIADO, C.BENEFICIO, C.ID, C.CONTRALOR, F.DETALLE, D.ANULADA, C.COM_BORRADOR, C.CONSUME, C.PERSONAS, C.NRO_COMANDA, C.MESA ";
                            QUERY += "FROM CONFITERIA_COMANDAS C, CONFITERIA_SOL_DESC D, FORMAS_DE_PAGO F WHERE F.ID = C.FORMA_DE_PAGO AND D.COMANDA = C.ID AND CAST(C.FECHA AS DATE) >= '" + DESDE + "' AND CAST(C.FECHA AS DATE) <= '" + HASTA + "' AND C.ROL = '" + VGlobales.vp_role + "' ORDER BY D.ID DESC;";
                        }
                        else
                        {
                            //QUERY = "SELECT * FROM CONFITERIA_SOL_DESC WHERE ID = " + ID_SOLICITUD;
                            QUERY = "SELECT D.ID, D.FECHA, D.IMPORTE, D.NOM_SOC, C.NRO_SOC, C.NRO_DEP, C.BARRA, C.AFILIADO, C.BENEFICIO, C.ID, C.CONTRALOR, F.DETALLE, D.ANULADA, C.COM_BORRADOR, C.CONSUME, C.PERSONAS, C.NRO_COMANDA, C.MESA ";
                            QUERY += "FROM CONFITERIA_COMANDAS C, CONFITERIA_SOL_DESC D, FORMAS_DE_PAGO F WHERE F.ID = C.FORMA_DE_PAGO AND D.COMANDA = C.ID AND C.ROL = '" + VGlobales.vp_role + "' AND D.ID = " + ID_SOLICITUD + " ORDER BY D.ID DESC;";
                        }
                    }

                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (ID_COMANDA == 0)
                                mostrarComandas(ds);
                            else
                                COMANDA = ds;
                        }
                        else
                        {
                            MessageBox.Show("NO SE ENCONTRARON RESULTADOS");
                        }
                        
                    }

                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void mostrarComandas(DataSet COMANDAS)
        {
            try
            {
                dgComandas.Rows.Clear();

                foreach (DataRow row in COMANDAS.Tables[0].Rows)
                {
                    string ID = row[0].ToString().Trim();
                    string FECHA = row[1].ToString().Trim().Replace("12:00:00 a.m.", "");
                    decimal IMPORTE = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(row[2].ToString()))));
                    string NOM_SOC = row[3].ToString().Trim();
                    string NRO_SOC = row[4].ToString().Trim();
                    string NRO_DEP = row[5].ToString().Trim();
                    string BARRA = row[6].ToString().Trim();
                    string AFILIADO = row[7].ToString().Trim();
                    string BENEFICIO = row[8].ToString().Trim();
                    string DESCUENTO = row[9].ToString().Trim();
                    string CONTRALOR = row[10].ToString().Trim();
                    string FORMA_DE_PAGO = row[11].ToString().Trim();
                    string ANULADA = row[12].ToString().Trim();
                    string BORRADOR = row[13].ToString().Trim();
                    string CONSUME = row[14].ToString().Trim();
                    string PERSONAS = "";
                    string NRO_COMANDA = row[16].ToString().Trim();
                    string MESA = row[17].ToString().Trim();

                    if (cbTipoComprobante.SelectedItem.ToString() != "SOLICITUD DE DESCUENTO")
                    {
                        PERSONAS = row[15].ToString().Trim();
                    }

                    if (cbTipoComprobante.SelectedItem.ToString() == "COMANDA")
                    {
                        dgComandas.Rows.Add(NRO_COMANDA, ANULADA, FECHA, IMPORTE, NOM_SOC, NRO_SOC, NRO_DEP, BARRA, AFILIADO, BENEFICIO, DESCUENTO, CONTRALOR, FORMA_DE_PAGO, BORRADOR, CONSUME, PERSONAS, ID, MESA);
                    }

                    if (cbTipoComprobante.SelectedItem.ToString() == "SOLICITUD DE DESCUENTO")
                    {
                        dgComandas.Rows.Add(ID, ANULADA, FECHA, IMPORTE, NOM_SOC, NRO_SOC, NRO_DEP, BARRA, AFILIADO, BENEFICIO, DESCUENTO, CONTRALOR, FORMA_DE_PAGO, BORRADOR, CONSUME, PERSONAS, ID, MESA);
                    }
                }

                dgComandas.ClearSelection();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());      
            }
        }

        private void mostrarItems(DataSet ITEMS)
        {
            try
            {
                dgItems.Rows.Clear();

                foreach (DataRow row in ITEMS.Tables[0].Rows)
                {
                    string ID = row[7].ToString();
                    string COMANDA = row[9].ToString();
                    string ITEM = row[0].ToString();
                    string CANTIDAD = row[1].ToString();
                    string TIPO = row[2].ToString();
                    string VALOR = string.Format("{0:n}", Convert.ToDecimal(row[3].ToString()));
                    string SUBTOTAL = string.Format("{0:n}", Convert.ToDecimal(row[4].ToString()));
                    string ITEM_DETALLE = row[5].ToString();
                    string TIPO_DETALLE = row[6].ToString();
                    string IMPRESO = row[8].ToString();
                    dgItems.Rows.Add(ID, COMANDA, ITEM, CANTIDAD, TIPO, VALOR, SUBTOTAL, TIPO_DETALLE, ITEM_DETALLE, IMPRESO);
                }

                dgItems.ClearSelection();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void calcularComensales()
        {
            string ULTIMA_COMANDA = dgComandas.Rows[0].Cells[0].Value.ToString();
            string PRIMER_COMANDA = dgComandas.Rows[dgComandas.Rows.Count - 1].Cells[0].Value.ToString();
            string QUERY = "SELECT COUNT(A.COMANDA) FROM CONFITERIA_COMANDA_ITEM A, CONFITERIA_COMANDAS B WHERE A.COMANDA >= " + PRIMER_COMANDA + " AND A.COMANDA <= " + ULTIMA_COMANDA + " AND A.COMANDA = B.ID AND (A.TIPO = 269 OR A.TIPO = 276 OR A.TIPO = 278 OR A.TIPO = 248 OR A.TIPO = 271 OR A.TIPO = 274 OR A.TIPO = 275 OR A.TIPO = 272 OR A.TIPO = 277);";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            lbComensalesListados.Text = "COMENSALES ESTIMADOS: " + foundRows[0][0].ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            llenarGrillaComandas();
            string TOTAL = sumar().ToString();

            if (sumar() != 0)
            {
                lbImporteTotalListado.Text = "IMPORTE TOTAL: $ " + string.Format("{0:n}", TOTAL);
                int COMANDAS = dgComandas.Rows.Count;
                decimal PROMEDIO = Convert.ToDecimal(TOTAL) / COMANDAS;
                lbPromedioComandaListado.Text = "PROMEDIO COMANDA: $ " + string.Format("{0:n}", PROMEDIO);
                lbTotalComandasListadas.Text = "TOTAL COMANDAS: " + COMANDAS.ToString();
                calcularComensales();
            }
        }

        private void buscarItems(int ID_COMANDA, string MOSTRAR)
        {
            conString conString = new conString();
            string connectionString = conString.get();

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    string QUERY = "SELECT C.ITEM, C.CANTIDAD, C.TIPO, C.VALOR, C.SUBTOTAL, C.ITEM_DETALLE, C.TIPO_DETALLE, C.ID, C.IMPRESO, C.COMANDA FROM CONFITERIA_COMANDA_ITEM C WHERE IMPRESO = 'NO' AND C.COMANDA = " + ID_COMANDA + " ORDER BY C.ID ASC;";
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);
                    ITEMS = null;

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (MOSTRAR == "SI")
                        {
                            mostrarItems(ds);
                        }

                        ITEMS = ds;
                    }

                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataSet buscarSolicitud(int ID_SOLICITUD, string TABLA)
        {
            conString conString = new conString();
            string connectionString = conString.get();
            DataSet DATOS = null;

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string QUERY = "SELECT S.ID, S.FECHA, S.NOM_SOC, S.IMPORTE, S.DESTINO, S.LEG_PER, S.AFILIADO, S.BENEFICIO, S.A_DTO, S.COMANDA, S.ANULADA, S.USR_ANULADA, C.COM_BORRADOR, C.CONSUME, C.IMPORTE_DESCONTADO FROM " + TABLA + " S, CONFITERIA_COMANDAS C WHERE S.ID = " + ID_SOLICITUD + " AND C.ID = S.COMANDA;";
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SOLICITUD = ds;
                            DATOS = ds;
                        }
                    }

                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return DATOS;
        }

        private bool checkDescuento()
        {
            int DESC = 0;

            foreach (DataGridViewRow row in dgComandas.SelectedRows)
            {
                if (row.Cells[10].Value.ToString() != "")
                {
                    DESC++;
                }
            }

            if (DESC > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private decimal sumar()
        { 
            decimal TOTAL = 0;
            decimal IMPORTE = 0;

            foreach (DataGridViewRow row in dgComandas.Rows)
            {
                IMPORTE = Convert.ToDecimal(row.Cells[3].Value.ToString());

                if (row.Cells[1].Value.ToString() == "")
                    TOTAL = TOTAL + IMPORTE;
            }

            return TOTAL;
        }

        private bool checkSocio()
        {
            int NRO_SOC = int.Parse(dgComandas[6, dgComandas.CurrentCell.RowIndex].Value.ToString());
            int NRO_DEP = int.Parse(dgComandas[7, dgComandas.CurrentCell.RowIndex].Value.ToString());
            int SOCIO_UNO = NRO_SOC + NRO_DEP;
            int SOCIO = 0;
            bool RETURN = false;

            foreach (DataGridViewRow row in dgComandas.SelectedRows)
            {
                NRO_SOC = int.Parse(row.Cells[6].Value.ToString());
                NRO_DEP = int.Parse(row.Cells[7].Value.ToString());
                SOCIO = NRO_SOC + NRO_DEP;

                if (SOCIO_UNO != SOCIO)
                {
                    RETURN = true;
                }
            }

            return RETURN;
        }

        private bool checkFormaDePago()
        {
            bool RETURN = false;
            string FORMA_DE_PAGO = "";

            foreach (DataGridViewRow row in dgComandas.SelectedRows)
            {
                FORMA_DE_PAGO = row.Cells[12].Value.ToString();

                if (FORMA_DE_PAGO != "DESCUENTO")
                {
                    RETURN = true;
                }
            }

            return RETURN;
        }

        private void dgComandas_Click(object sender, EventArgs e)
        {
            if (dgComandas.SelectedRows.Count == 1)
            {
                int ID_COMANDA = int.Parse(dgComandas[16, dgComandas.CurrentCell.RowIndex].Value.ToString());
                buscarItems(ID_COMANDA, "SI");
            }
        }

        private void dgComandas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int FP = 0;
                FP = int.Parse(cbFormaDePago.SelectedValue.ToString());

                if (lbComprobante.Text == "COMANDA")
                {
                    if (FP == 8)
                    {
                        imprimirSolicitudDeDescuentoToolStripMenuItem.Visible = true;
                    }

                    cmComandas.Show(Cursor.Position);
                }
                else if (lbComprobante.Text == "SOLICITUD DE DESCUENTO")
                {
                    cmSolicitudes.Show(Cursor.Position);
                }
            }
        }

        private void imprimirComandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgComandas.SelectedRows.Count > 1)
            {
                MessageBox.Show("SELECCIONAR SOLO UNA COMANDA PARA IMPRIMIR", "ERROR");
            }
            else
            {
                int ID_COMANDA = int.Parse(dgComandas[16, dgComandas.CurrentCell.RowIndex].Value.ToString());
                buscarComandas("X", "X", ID_COMANDA, "X", 0, 1, "X", "X");
                buscarItems(ID_COMANDA, "NO");
                imprimir i = new imprimir();
                i.imprimirComanda(ITEMS, COMANDA, "SOCIO");
            }
        }

        private void imprimirSolicitudDeDescuentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgComandas.SelectedRows.Count == 0)
            {
                MessageBox.Show("SELECCIONAR LAS COMANDAS PARA GENERAR LA SOLICITUD", "ERROR");
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                int D_ADTO = 1;
                int M_ADTO = DateTime.Today.Month;

                if (M_ADTO < 12)
                {
                    M_ADTO = M_ADTO + 1;
                }
                else if (M_ADTO == 12)
                {
                    M_ADTO = 1;
                }
                
                int Y_ADTO = DateTime.Today.Year;

                if (M_ADTO < 12)
                {
                    Y_ADTO = Y_ADTO;
                }
                else if (M_ADTO == 12)
                {
                    Y_ADTO = Y_ADTO + 1;
                }

                string A_DTO = D_ADTO.ToString() + "/" + M_ADTO.ToString() + "/" + Y_ADTO.ToString();
                string FECHA = DateTime.Today.ToShortDateString();

                if (dgComandas.SelectedRows.Count == 1)
                {
                    if (checkDescuento() == true)
                    {
                        MessageBox.Show("ESTA COMANDA YA TIENE SOLICITUD DE DESCUENTO", "ERROR");
                    }
                    else if (dgComandas[12, dgComandas.CurrentCell.RowIndex].Value.ToString() != "DESCUENTO")
                    {
                        MessageBox.Show("LA FORMA DE PAGO DEBE SER DESCUENTO", "ERROR");
                    }
                    else
                    {
                        try
                        {
                            int NRO_SOC = int.Parse(dgComandas[5, dgComandas.CurrentCell.RowIndex].Value.ToString());
                            int NRO_DEP = int.Parse(dgComandas[6, dgComandas.CurrentCell.RowIndex].Value.ToString());
                            string AFILIADO = dgComandas[8, dgComandas.CurrentCell.RowIndex].Value.ToString();
                            string NOM_SOC = dgComandas[4, dgComandas.CurrentCell.RowIndex].Value.ToString();
                            string BENEFICIO = dgComandas[9, dgComandas.CurrentCell.RowIndex].Value.ToString();
                            string BORRADOR = dgComandas[13, dgComandas.CurrentCell.RowIndex].Value.ToString();
                            string CONSUME = dgComandas[14, dgComandas.CurrentCell.RowIndex].Value.ToString();
                            decimal IMPORTE = Convert.ToDecimal(dgComandas[3, dgComandas.CurrentCell.RowIndex].Value.ToString());
                            obtenerDestino od = new obtenerDestino();
                            string DESTINO = od.get(NRO_SOC, NRO_DEP);
                            obtenerLegPer olp = new obtenerLegPer();
                            int LEG_PER = olp.get(NRO_SOC, NRO_DEP);
                            int ID_COMANDA = int.Parse(dgComandas[0, dgComandas.CurrentCell.RowIndex].Value.ToString());
                            dlog.nuevaSolicitudDescuentoConfiteria(FECHA, NOM_SOC, IMPORTE, DESTINO, LEG_PER, AFILIADO, BENEFICIO, A_DTO, ID_COMANDA);
                            maxid mid = new maxid();
                            int ID_SOLICITUD = int.Parse(mid.m("ID", "CONFITERIA_SOL_DESC"));
                            buscarSolicitud(ID_SOLICITUD, "CONFITERIA_SOL_DESC");
                            dlog.descuentoEnComanda(ID_COMANDA, ID_SOLICITUD);
                            imprimir i = new imprimir();
                            i.imprimirSolicitud(SOLICITUD);
                            llenarGrillaComandas();
                            dgItems.Rows.Clear();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("NO SE PUDO GUARDAR LA SOLICITUD DE DESCUENTO\n" + error, "ERROR");
                        }
                    }
                }
                else
                {
                    if (checkDescuento() == true)
                    {
                        MessageBox.Show("ALGUNAS DE LAS COMANDAS SELECCIONADAS YA POSEEN SOLICITUD DE DESCUENTO", "ERROR");
                    }
                    else if (checkSocio() == true)
                    {
                        MessageBox.Show("LAS COMANDAS SELECCIONADAS NO PERTENECEN TODAS AL MISMO SOCIO", "ERROR");
                    }
                    else if (checkFormaDePago() == true)
                    {
                        MessageBox.Show("ALGUNAS COMANDAS NO TIENEN COMO FORMA DE PAGO DESCUENTO", "ERROR");
                    }
                    else
                    {
                        int NRO_SOC = int.Parse(dgComandas[5, dgComandas.CurrentCell.RowIndex].Value.ToString());
                        int NRO_DEP = int.Parse(dgComandas[6, dgComandas.CurrentCell.RowIndex].Value.ToString());
                        string AFILIADO = dgComandas[8, dgComandas.CurrentCell.RowIndex].Value.ToString();
                        string NOM_SOC = dgComandas[4, dgComandas.CurrentCell.RowIndex].Value.ToString();
                        string BENEFICIO = dgComandas[9, dgComandas.CurrentCell.RowIndex].Value.ToString();
                        decimal IMPORTE = Convert.ToDecimal(dgComandas[3, dgComandas.CurrentCell.RowIndex].Value.ToString());
                        obtenerDestino od = new obtenerDestino();
                        string DESTINO = od.get(NRO_SOC, NRO_DEP);
                        obtenerLegPer olp = new obtenerLegPer();
                        int LEG_PER = olp.get(NRO_SOC, NRO_DEP);
                        int ID_COMANDA = int.Parse(dgComandas[0, dgComandas.CurrentCell.RowIndex].Value.ToString());
                        dlog.nuevaSolicitudDescuentoConfiteria(FECHA, NOM_SOC, IMPORTE, DESTINO, LEG_PER, AFILIADO, BENEFICIO, A_DTO, ID_COMANDA);
                        maxid mid = new maxid();
                        int ID_SOLICITUD = int.Parse(mid.m("ID", "CONFITERIA_SOL_DESC"));
                        buscarSolicitud(ID_SOLICITUD, "CONFITERIA_SOL_DESC");

                        foreach (DataGridViewRow row in dgComandas.SelectedRows)
                        {
                            int COMANDA = int.Parse(row.Cells[0].Value.ToString());
                            dlog.descuentoEnComanda(COMANDA, ID_SOLICITUD);
                        }

                        imprimir i = new imprimir();
                        i.imprimirSolicitud(SOLICITUD);
                        llenarGrillaComandas();
                        dgItems.Rows.Clear();
                    }
                }

                Cursor = Cursors.Default;
            }
        }

        private void anularComandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA LA ANULACIÓN DE LA COMANDA SELECCIONADA?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int ID_COMANDA = int.Parse(dgComandas[16, dgComandas.CurrentCell.RowIndex].Value.ToString());
                    string ANULADA = DateTime.Now.ToString();
                    string USR_ANULADA = VGlobales.vp_username;
                    dlog.anularComandaComedor(ID_COMANDA, ANULADA, USR_ANULADA);
                    MessageBox.Show("COMANDA ANULADA CORRECTAMENTE", "LISTO!");
                    llenarGrillaComandas();
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO ELIMINAR LA COMANDA\n" + error, "ERROR");
                }
            }
        }

        private void cbTipoComprobante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbTipoComprobante.SelectedItem.ToString() == "SOLICITUD DE DESCUENTO")
            {
                cbFormaDePago.Enabled = false;
            }
            else
            {
                cbFormaDePago.Enabled = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int ID_SOLICITUD = int.Parse(dgComandas[0, dgComandas.CurrentCell.RowIndex].Value.ToString());
            buscarSolicitud(ID_SOLICITUD, "CONFITERIA_SOL_DESC");
            imprimir i = new imprimir();
            i.imprimirSolicitud(SOLICITUD);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA LA ANULACIÓN DE LA SOLICITUD SELECCIONADA?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int ID_SOLICITUD = int.Parse(dgComandas[0, dgComandas.CurrentCell.RowIndex].Value.ToString());
                    string ANULADA = DateTime.Now.ToString();
                    string USR_ANULADA = VGlobales.vp_username;
                    dlog.anularSolicitud(ID_SOLICITUD, ANULADA, USR_ANULADA);
                    MessageBox.Show("SOLICITUD ANULADA CORRECTAMENTE", "LISTO!");
                    llenarGrillaComandas();
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO ANULAR LA COMANDA\n" + error, "ERROR");
                }
            }
        }

        private void modificarItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int MESA = int.Parse(dgComandas[17, dgComandas.CurrentCell.RowIndex].Value.ToString());
            string NRO_MESA =dgComandas[17, dgComandas.CurrentCell.RowIndex].Value.ToString();
            int SECUENCIA = 0;
            int GROUP = 4;
            int PERSONAS = int.Parse(dgComandas[15, dgComandas.CurrentCell.RowIndex].Value.ToString());
            int PAGO = int.Parse(cbFormaDePago.SelectedValue.ToString());
            int ID_COMANDA = int.Parse(dgComandas[16, dgComandas.CurrentCell.RowIndex].Value.ToString());
            int NRO_COMANDA = int.Parse(dgComandas[0, dgComandas.CurrentCell.RowIndex].Value.ToString());
            string SOCIO = dgComandas[4, dgComandas.CurrentCell.RowIndex].Value.ToString();
            string NRO_SOC = dgComandas[5, dgComandas.CurrentCell.RowIndex].Value.ToString();
            string NRO_DEP = dgComandas[6, dgComandas.CurrentCell.RowIndex].Value.ToString();
            string BARRA = dgComandas[7, dgComandas.CurrentCell.RowIndex].Value.ToString();
            comanda co = new comanda(NRO_SOC, NRO_DEP, BARRA, SOCIO, SECUENCIA, GROUP, MESA, ID_COMANDA, PERSONAS, PAGO, "N", NRO_MESA, NRO_COMANDA);
            co.ShowDialog();
            llenarGrillaComandas();
            Cursor = Cursors.Default;
        }

        private void desanularComandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA LA DESANULACIÓN DE LA COMANDA SELECCIONADA?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dgComandas[1, dgComandas.CurrentCell.RowIndex].Value.ToString() == "")
                {
                    MessageBox.Show("LA COMANDA NO FUE ANULADA, NO SE PUEDE DESANULAR", "ERROR");
                }
                else
                {
                    try
                    {
                        int ID_COMANDA = int.Parse(dgComandas[16, dgComandas.CurrentCell.RowIndex].Value.ToString());
                        string ANULADA = null;
                        string USR_ANULADA = null;
                        dlog.anularComandaComedor(ID_COMANDA, ANULADA, USR_ANULADA);
                        MessageBox.Show("COMANDA DESANULADA CORRECTAMENTE", "LISTO!");
                        llenarGrillaComandas();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO DESANULAR LA COMANDA\n" + error, "ERROR");
                    }
                }
            }
        }

        private void subItemClick(object sender, EventArgs e)
        {
            try
            {
                int s = sender.ToString().IndexOf("·");
                int index = s - 1;
                string FORMA_DE_PAGO = sender.ToString().Substring(0, index);
                int ID_COMANDA = int.Parse(dgComandas[16, dgComandas.CurrentCell.RowIndex].Value.ToString());
                dlog.confiteriaModificarPago(ID_COMANDA, int.Parse(FORMA_DE_PAGO));
                llenarGrillaComandas();
                MessageBox.Show("FORMA DE PAGO MODIFICADA", "LISTO!");
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO MODIFICAR LA FORMA DE PAGO\n" + error, "ERROR");
            }
        }

        private void subItemClickTipo(object sender, EventArgs e)
        {
            try
            {
                int s = sender.ToString().IndexOf("·");
                int index = s - 1;
                string TIPO_DE_COMANDA = sender.ToString().Substring(0, index);
                int ID_COMANDA = int.Parse(dgComandas[16, dgComandas.CurrentCell.RowIndex].Value.ToString());
                dlog.modificarTipoDeComanda(ID_COMANDA, int.Parse(TIPO_DE_COMANDA));
                llenarGrillaComandas();
                MessageBox.Show("TIPO DE COMANDA MODIFICADA", "LISTO!");
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO MODIFICAR LA FORMA DE PAGO\n" + error, "ERROR");
            }
        }

        private void subitemsFormasDePago()
        {
            string query = "SELECT * FROM FORMAS_DE_PAGO ORDER BY ID ASC;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                for (int i = 0; i < foundRows.Length; i++)
                {
                    this.cambiarFormaDePagoToolStripMenuItem.DropDownItems.Add(foundRows[i][0].ToString() + " · " + foundRows[i][1].ToString(), null, subItemClick);
                }
            }
        }

        private void subitemsTipoDeComanda()
        {
            string query = "SELECT * FROM CONFITERIA_TIPO_COMANDA ORDER BY ID ASC;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                for (int i = 0; i < foundRows.Length; i++)
                {
                    this.cambiarTipoDeComandaToolStripMenuItem.DropDownItems.Add(foundRows[i][0].ToString() + " · " + foundRows[i][1].ToString(), null, subItemClickTipo);
                }
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivo XLS|*.xls";
            saveFileDialog1.Title = "Guardar Listado";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                excel(LISTADO, saveFileDialog1.FileName);
            }
        }

        public void excel(DataSet ds, string path)
        {
            Cursor = Cursors.WaitCursor;
            string data = null;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add();
            xlWorkSheet = xlWorkBook.Worksheets[1];

            xlWorkSheet.Range["A1:Z1"].Font.Bold = true;

            xlWorkSheet.Cells[1, 1] = "#";
            xlWorkSheet.Cells[1, 2] = "FECHA";
            xlWorkSheet.Cells[1, 3] = "IMPORTE";
            xlWorkSheet.Cells[1, 4] = "NOMBRE Y APELLIDO";
            xlWorkSheet.Cells[1, 5] = "NRO_SOC";
            xlWorkSheet.Cells[1, 6] = "NRO_DEP";
            xlWorkSheet.Cells[1, 7] = "BARRA";
            xlWorkSheet.Cells[1, 8] = "AFILIADO";
            xlWorkSheet.Cells[1, 9] = "BENEFICIO";
            xlWorkSheet.Cells[1, 10] = "DESC";
            xlWorkSheet.Cells[1, 11] = "CONTRALOR";
            xlWorkSheet.Cells[1, 12] = "FORMA DE PAGO";
            xlWorkSheet.Cells[1, 13] = "ANULADA";

            xlWorkSheet.Cells[ds.Tables[0].Rows.Count + 2, 1] = lbImporteTotalListado.Text;
            xlWorkSheet.Cells[ds.Tables[0].Rows.Count + 2, 2] = lbComensalesListados.Text;
            xlWorkSheet.Cells[ds.Tables[0].Rows.Count + 2, 3] = lbPromedioComandaListado.Text;
            xlWorkSheet.Cells[ds.Tables[0].Rows.Count + 2, 4] = lbTotalComandasListadas.Text;

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                    xlWorkSheet.Columns[j + 1].AutoFit();
                    xlWorkSheet.Columns[2].EntireColumn.NumberFormat = "DD/MM/AAAA";
                }
            }

            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            Cursor = Cursors.Default;
            MessageBox.Show("EXPORTACION COMPLETADA");
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

        private void cbTipoDeComanda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbTipoDeComanda.SelectedValue.ToString() == "2")
            {
                cbTipoComprobante.SelectedIndex = 0;
                cbFormaDePago.SelectedIndex = 0;
                cbTipoComprobante.Enabled = false;
                cbFormaDePago.Enabled = false;
            }
            else
            {
                cbTipoComprobante.SelectedIndex = 0;
                cbFormaDePago.SelectedIndex = 0;
                cbTipoComprobante.Enabled = true;
                cbFormaDePago.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivo PDF|*.pdf";
            saveFileDialog1.Title = "Guardar Informe";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //grillaPreComanda gpc = new grillaPreComanda();
                //gpc.listadoPDF();
            }
        }
    }
}
