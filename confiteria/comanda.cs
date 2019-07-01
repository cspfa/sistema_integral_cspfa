using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using SOCIOS;
using System.Text.RegularExpressions;

namespace Confiteria
{
    public partial class comanda : Form
    {
        bo dlog = new bo();
        Utils utils = new Utils();
        private string _MOROSO { get; set; }
        private DataSet COMANDA { get; set; }
        private DataSet SOLICITUD { get; set; }
        private DataSet ITEMS { get; set; }
        private int GRUPO { get; set; }
        private int CANTIDAD_ITEMS { get; set; }
        private int ID_MESA { get; set; }
        private int NU_MESA { get; set; }
        private int ID_COM { get; set; }
        List<ITEMS_CONFITERIA> LISTA_ITEMS;
      
        public comanda(string NRO_SOC, string NRO_DEP, string BARRA, string SOCIO, int SECUENCIA, int GROUP, int MESA, int ID_COMANDA, int PERSONAS, int PAGO, string MOROSO, string NRO_MESA, int NRO_COMANDA)
        {
            InitializeComponent();
            _MOROSO = MOROSO;
            this.ControlBox = false;
            llenarGrillaSocio(NRO_SOC, NRO_DEP, BARRA, SOCIO, SECUENCIA);
            comboSectAct("MENU " + VGlobales.vp_role);
            comboProfesionales(cbSectAct.SelectedValue.ToString());
            tbMesa.Text = NRO_MESA;
            GRUPO = GROUP;
            comboMozos();
            comboFormasDePago();
            mostrarArancel();
            generarListaItems();
            comboTipoDeComanda();
            ID_MESA = MESA;
            NU_MESA = int.Parse(NRO_MESA);
            ID_COM = ID_COMANDA;
            dpEntrega.Format = DateTimePickerFormat.Time;
            dpEntrega.ShowUpDown = true;

            if(VGlobales.vp_role == "CPOCABA")
            {
                dpEntrega.Visible = true;
                label20.Visible = true;
            }

            if (ID_COMANDA != 0)
            {
                tbNroComanda.Text = NRO_COMANDA.ToString();
                tbIdComanda.Text = ID_COM.ToString();
                tbPersonas.Text = PERSONAS.ToString();
                cbFormaDePago.SelectedValue = PAGO;
                buscarItems(ID_COMANDA, "SI", "X");
                CANTIDAD_ITEMS = dgItems.Rows.Count;
                string[] DATOS_COMANDA = obtenerDatosComanda(ID_COMANDA);
                decimal TOTAL = decimal.Parse(DATOS_COMANDA[4].ToString());
                dpEntrega.Text = DATOS_COMANDA[5];
                tbTotal.Text = TOTAL.ToString().Trim();
                tbContralor.Text = DATOS_COMANDA[0].Trim();
                cbMozo.SelectedValue = DATOS_COMANDA[1];
                tbComandaBorrador.Text = DATOS_COMANDA[2].Trim();
                cbTipoDeComanda.SelectedValue = DATOS_COMANDA[3];
                int TIPO_COMANDA = int.Parse(cbTipoDeComanda.SelectedValue.ToString());
                cambiarDescuento(TIPO_COMANDA);

                if (DATOS_COMANDA[3] == "2")
                {
                    cambiarDescuento(int.Parse(DATOS_COMANDA[3]));
                    cbFormaDePago.SelectedValue = 1;
                    cbFormaDePago.Enabled = false;
                    resetNroContralor();
                }
            }
        }
     
        private string[] obtenerDatosComanda(int ID_COMANDA)
        {
            string QUERY = "SELECT CONTRALOR, MOZO, COM_BORRADOR, TIPO_COMANDA, IMPORTE, ENTREGA FROM CONFITERIA_COMANDAS WHERE ID = " + ID_COMANDA;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            string[] RETURN;

            if (foundRows.Length > 0)
            {
                RETURN = new string[] { foundRows[0][0].ToString(), foundRows[0][1].ToString(), foundRows[0][2].ToString(), foundRows[0][3].ToString(), foundRows[0][4].ToString() };
            }
            else
            {
                RETURN = new string[] { "X", "X", "X", "X", "X" };
            }

            return RETURN;
        }

        private void buscarItems(int ID_COMANDA, string MOSTRAR, string IMPRESO)
        {
            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    string QUERY = "";
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();

                    if (IMPRESO == "NO")
                        QUERY = "SELECT C.ITEM, C.CANTIDAD, C.TIPO, C.VALOR, C.SUBTOTAL, C.ITEM_DETALLE, C.TIPO_DETALLE, C.ID, C.IMPRESO, C.OBSERVACIONES FROM CONFITERIA_COMANDA_ITEM C WHERE IMPRESO = 'NO' AND C.COMANDA = " + ID_COMANDA + " ORDER BY C.ID ASC;";
                    else
                        QUERY = "SELECT C.ITEM, C.CANTIDAD, C.TIPO, C.VALOR, C.SUBTOTAL, C.ITEM_DETALLE, C.TIPO_DETALLE, C.ID, C.IMPRESO, C.OBSERVACIONES FROM CONFITERIA_COMANDA_ITEM C WHERE C.COMANDA = " + ID_COMANDA + " ORDER BY C.ID ASC;";
                    
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

        private void buscarComanda(int ID_COMANDA)
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
                    string QUERY = "SELECT C.ID, C.FECHA, C.MESA, M.NOMBRE, C.IMPORTE, C.NRO_SOC, C.NRO_DEP, C.BARRA, C.PERSONAS, C.NOMBRE_SOCIO, C.AFILIADO, C.BENEFICIO, C.USUARIO, C.DESCUENTO, F.DETALLE, C.CONTRALOR, C.COM_BORRADOR, C.DESCUENTO_APLICADO, C.IMPORTE_DESCONTADO, C.NRO_COMANDA, C.ENTREGA ";
                    QUERY += "FROM CONFITERIA_COMANDAS C, CONFITERIA_MOZOS M, FORMAS_DE_PAGO F ";
                    QUERY += "WHERE C.ID = " + ID_COMANDA + " AND C.MOZO = M.ID AND C.FORMA_DE_PAGO = F.ID; ";
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
                            COMANDA = ds;
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
        }

        private void mostrarItems(DataSet DS)
        {
            dgItems.Rows.Clear();

            foreach (DataRow row in DS.Tables[0].Rows)
            {
                string ITEM = row[0].ToString();
                string CANTIDAD = row[1].ToString();
                string TIPO = row[2].ToString();
                string VALOR = row[3].ToString().Trim();
                string SUBTOTAL = row[4].ToString().Trim();
                string ITEM_DETALLE = row[5].ToString().Trim();
                string TIPO_DETALLE = row[6].ToString().Trim();
                string ID = row[7].ToString().Trim();
                string IMPRESO = row[8].ToString().Trim();
                string OBSERVACION = row[9].ToString().Trim();
                dgItems.Rows.Add(CANTIDAD, TIPO_DETALLE, ITEM_DETALLE, VALOR, SUBTOTAL, ITEM, TIPO, ID, "NO", IMPRESO, OBSERVACION);
            }

            dgItems.ClearSelection();
        }

        private void llenarGrillaSocio(string NRO_SOC, string NRO_DEP, string BARRA, string SOCIO, int SECUENCIA)
        {
            afiliadoBeneficio ab = new afiliadoBeneficio();
            string[] AFIL_BENEF = ab.get(int.Parse(NRO_SOC), int.Parse(NRO_DEP));
            dgSocio.Rows.Add(NRO_SOC, NRO_DEP, BARRA, SOCIO, SECUENCIA, AFIL_BENEF[0], AFIL_BENEF[1]);

            if (_MOROSO == "S")
            {
                int X = 0;

                foreach (DataGridViewRow row in dgSocio.Rows)
                {
                    dgSocio.Rows[X].DefaultCellStyle.SelectionBackColor = Color.Red;
                    X++;
                }
            }
        }

        public void comboTipoDeComanda()
        {
            cbTipoDeComanda.DataSource = null;
            string query = "SELECT ID, TIPO FROM CONFITERIA_TIPO_COMANDA ORDER BY ID ASC;";
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

        public void comboSectAct(string ROL)
        {
            cbSectAct.DataSource = null;
            string query = "SELECT ID, TRIM(LEADING FROM DETALLE) AS DETALLE FROM SECTACT WHERE ROL = '" + ROL + "' AND ESTADO = 1 ORDER BY DETALLE;";
            cbSectAct.Items.Clear();
            cbSectAct.DataSource = dlog.BO_EjecutoDataTable(query);
            cbSectAct.DisplayMember = "DETALLE";
            cbSectAct.ValueMember = "ID";
            cbSectAct.SelectedIndex = 0;
        }

        public void comboMozos()
        {
            cbMozo.DataSource = null;
            string query = "SELECT ID, NOMBRE FROM CONFITERIA_MOZOS WHERE ROL = '" + VGlobales.vp_role + "' ORDER BY NOMBRE ASC;";
            cbMozo.Items.Clear();
            cbMozo.DataSource = dlog.BO_EjecutoDataTable(query);
            cbMozo.DisplayMember = "NOMBRE";
            cbMozo.ValueMember = "ID";
            cbMozo.SelectedIndex = 0;
        }

        public void comboProfesionales(string SECTACT)
        {
            cbProf.DataSource = null;
            string query = "SELECT P.ID, P.NOMBRE FROM PROFESIONALES P, PROF_ESP PE WHERE P.ID = PE.PROFESIONAL AND PE.ESPECIALIDAD = " + SECTACT + " AND P.BAJA IS NULL ORDER BY P.NOMBRE ASC;";
            cbProf.Items.Clear();
            cbProf.DataSource = dlog.BO_EjecutoDataTable(query);
            cbProf.DisplayMember = "NOMBRE";
            cbProf.ValueMember = "ID";
        }

        private void cbSectAct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboProfesionales(cbSectAct.SelectedValue.ToString());
            string SECTACT = cbSectAct.SelectedValue.ToString();
            mostrarArancel();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tbCantidad.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO CANTIDAD", "ERROR");
                tbCantidad.Focus();
            }
            else if (utils.isStockeable(Convert.ToInt32(dgResultados[0, dgResultados.CurrentCell.RowIndex].Value.ToString())) == true 
                && Convert.ToInt32(tbCantidad.Text) > Convert.ToInt32(tbStock.Text))
            {
                MessageBox.Show("LA CANTIDAD INGRESADA ES MAYOR QUE EL STOCK DISPONIBLE", "ERROR");
            }
            else if (cbSectAct.SelectedValue.ToString() == "")
            {
                MessageBox.Show("SELECCIONAR UN TIPO", "ERROR");
                cbSectAct.Focus();
            }
            else if (cbProf.SelectedValue.ToString() == "")
            {
                MessageBox.Show("SELECCIONAR UN ITEM", "ERROR");
                cbProf.Focus();
            }
            else
            {
                int CANTIDAD = int.Parse(tbCantidad.Text.Trim());
                string TIPO = cbSectAct.Text.Trim();
                int SEC_ACT = int.Parse(cbSectAct.SelectedValue.ToString());
                int PROF = int.Parse(cbProf.SelectedValue.ToString());
                string ITEM = cbProf.Text.Trim();
                decimal VALOR = decimal.Parse(tbImporteItem.Text.Trim());
                decimal SUBTOTAL = VALOR * CANTIDAD;
                string OBSERVACION = tbItemObservacion.Text.Trim();
                dgItems.Rows.Add(CANTIDAD, TIPO, ITEM, VALOR, SUBTOTAL, PROF, SEC_ACT, "X", "NO", "NO", OBSERVACION);
                decimal TOTAL = sumarTotal();
                tbTotal.Text = TOTAL.ToString();
                tbImporteItem.ReadOnly = true;
            }
        }

        private void btnQuitarItem_Click(object sender, EventArgs e)
        {
            if (dgItems[7, dgItems.CurrentRow.Index].Value.ToString() == "X")
            {
                dgItems.Rows.RemoveAt(dgItems.CurrentRow.Index);
            }
            else
            {
                dgItems[8, dgItems.CurrentRow.Index].Value = "SI";
                dgItems[2, dgItems.CurrentRow.Index].Value = "ELIMINADO";
                dgItems[1, dgItems.CurrentRow.Index].Value = "ELIMINADO";
            }
            
            decimal TOTAL = sumarTotal();
            tbTotal.Text = TOTAL.ToString();
        }

        private decimal sumarTotal()
        { 
            decimal TOTAL = 0;
            decimal IMPORTE = 0;
            
            foreach(DataGridViewRow row in dgItems.Rows)
            {
                if (row.Cells[8].Value.ToString() == "NO")
                {
                    IMPORTE = Convert.ToDecimal(row.Cells[4].Value);
                    TOTAL = TOTAL + IMPORTE;
                }
            }

            if (tbDescuento.Text != "")
            {
                if (int.Parse(tbDescuento.Text) >= 0 && int.Parse(tbDescuento.Text) <= 100)
                {
                    int DESC = int.Parse(tbDescuento.Text);
                    TOTAL = TOTAL - (TOTAL * DESC / 100);
                }
            }

            return TOTAL;
        }

        private void guardarItems(int ID_COM)
        {
            int COMANDA = int.Parse(tbNroComanda.Text);

            foreach (DataGridViewRow row in dgItems.Rows)
            {
                if (row.Cells[8].Value.ToString() == "NO")
                {
                    int CANTIDAD = int.Parse(row.Cells[0].Value.ToString());
                    string TIPO_DETALLE = row.Cells[1].Value.ToString();
                    string ITEM_DETALLE = row.Cells[2].Value.ToString();
                    decimal VALOR = Convert.ToDecimal(row.Cells[3].Value.ToString());
                    decimal SUBTOTAL = Convert.ToDecimal(row.Cells[4].Value.ToString());
                    int ITEM = int.Parse(row.Cells[5].Value.ToString());
                    int TIPO = int.Parse(row.Cells[6].Value.ToString());
                    string OBSERVACION = row.Cells[10].Value.ToString();
                    int ITEM_STOCK = utils.getItemStock(ITEM);
                    int STOCK_FINAL = utils.getStockFinal(ITEM_STOCK, CANTIDAD, "-");
                    bool SET_STOCK = utils.setItemStock(ITEM, STOCK_FINAL);
                    dlog.guardaItems(ID_COM, ITEM, CANTIDAD, TIPO, TIPO_DETALLE, ITEM_DETALLE, VALOR, SUBTOTAL, "NO", OBSERVACION);

                }
                else if (row.Cells[8].Value.ToString() == "SI")
                {
                    int ID = int.Parse(row.Cells[7].Value.ToString());
                    dlog.eliminaItems(ID);
                }
            }
        }

        private void agregarItems()
        {
            int COMANDA = int.Parse(tbIdComanda.Text);

            foreach (DataGridViewRow row in dgItems.Rows)
            {
                int CANTIDAD = int.Parse(row.Cells[0].Value.ToString());
                int ITEM = int.Parse(row.Cells[5].Value.ToString());

                if (row.Cells[7].Value.ToString() == "X")
                {
                    string TIPO_DETALLE = row.Cells[1].Value.ToString();
                    string ITEM_DETALLE = row.Cells[2].Value.ToString();
                    decimal VALOR = Convert.ToDecimal(row.Cells[3].Value.ToString());
                    decimal SUBTOTAL = Convert.ToDecimal(row.Cells[4].Value.ToString());
                    int TIPO = int.Parse(row.Cells[6].Value.ToString());
                    string OBSERVACION = row.Cells[10].Value.ToString();

                    if (utils.isStockeable(ITEM) == true)
                    {
                        int ITEM_STOCK = utils.getItemStock(ITEM);
                        int STOCK_FINAL = utils.getStockFinal(ITEM_STOCK, CANTIDAD, "-");
                        bool SET_STOCK = utils.setItemStock(ITEM, STOCK_FINAL);
                    }
                    
                    dlog.guardaItems(COMANDA, ITEM, CANTIDAD, TIPO, TIPO_DETALLE, ITEM_DETALLE, VALOR, SUBTOTAL, "NO", OBSERVACION);
                }
                else if (row.Cells[8].Value.ToString() == "SI")
                {
                    int ITEM_STOCK = utils.getItemStock(ITEM);
                    int STOCK_FINAL = utils.getStockFinal(ITEM_STOCK, CANTIDAD, "+");
                    bool SET_STOCK = utils.setItemStock(ITEM, STOCK_FINAL);
                    int ID = int.Parse(row.Cells[7].Value.ToString());
                    dlog.eliminaItems(ID);
                }
            }
        }

        private bool checkNumContralor(int CONTRALOR)
        {
            string QUERY = "SELECT CONTRALOR FROM CONFITERIA_COMANDAS WHERE CONTRALOR = " + CONTRALOR;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void guardarMesa(int ID_COMANDA, string MSG)
        {
            try
            {
                int HORA = DateTime.Now.Hour;
                int MINUTO = DateTime.Now.Minute;
                int SEGUNDO = DateTime.Now.Second;
                string TIEMPO = HORA.ToString() + ":" + MINUTO.ToString() + ":" + SEGUNDO.ToString();
                string FECHA = dpFechaComanda.Text + " " + TIEMPO;
                int NRO_MESA = int.Parse(tbMesa.Text);
                decimal IMPORTE = decimal.Parse(tbTotal.Text);
                int NRO_SOC = int.Parse(dgSocio[0, dgSocio.CurrentCell.RowIndex].Value.ToString());
                int NRO_DEP = int.Parse(dgSocio[1, dgSocio.CurrentCell.RowIndex].Value.ToString());
                afiliadoBeneficio ab = new afiliadoBeneficio();
                string[] AFIL_BENEF = ab.get(NRO_SOC, NRO_DEP);
                string AFILIADO = AFIL_BENEF[0];
                string BENEFICIO = AFIL_BENEF[1];
                int BARRA = int.Parse(dgSocio[2, dgSocio.CurrentCell.RowIndex].Value.ToString());
                string NOMBRE_SOCIO = dgSocio[3, dgSocio.CurrentCell.RowIndex].Value.ToString();
                string USUARIO = VGlobales.vp_username;
                int PERSONAS = int.Parse(tbPersonas.Text.Trim());
                int MOZO = int.Parse(cbMozo.SelectedValue.ToString());
                int FORMA_DE_PAGO = int.Parse(cbFormaDePago.SelectedValue.ToString());
                int CONTRALOR = 0;
                string COM_BORRADOR = tbComandaBorrador.Text.Trim();
                string CONSUME = tbConsume.Text.Trim();
                int TIPO_COMANDA = int.Parse(cbTipoDeComanda.SelectedValue.ToString());
                decimal DESCUENTO_APLICADO = 0;
                decimal IMPORTE_DESCONTADO = 0;
                int NRO_COMANDA = 0;
                string NCOM = "";
                bool TIENE_DESCUENTO = utils.getTieneDescuento(TIPO_COMANDA);
                string ENTREGA = dpEntrega.Text;
                
                if (TIENE_DESCUENTO == true)
                {
                    DESCUENTO_APLICADO = decimal.Parse(tbDescuento.Text);
                    IMPORTE_DESCONTADO = decimal.Parse(tbTotal.Text);
                    //IMPORTE_DESCONTADO = IMPORTE - ((IMPORTE * DESCUENTO_APLICADO) / 100);
                }

                if (cbFormaDePago.SelectedValue.ToString() == "8")
                {
                    CONTRALOR = int.Parse(tbContralor.Text);
                }

                if (ID_COMANDA == 0)
                {
                    maxid mid = new maxid();
                    NCOM = mid.role("NRO_COMANDA", "CONFITERIA_COMANDAS", "ROL", VGlobales.vp_role);

                    if (NCOM != "")
                    {
                        NRO_COMANDA = int.Parse(NCOM);
                    }
                    
                    NRO_COMANDA = NRO_COMANDA + 1;
                    dlog.guardaMesa(FECHA, NU_MESA, MOZO, IMPORTE, NRO_SOC, NRO_DEP, BARRA, PERSONAS, AFILIADO, BENEFICIO, NOMBRE_SOCIO, USUARIO, FORMA_DE_PAGO, CONTRALOR, COM_BORRADOR, CONSUME, TIPO_COMANDA, DESCUENTO_APLICADO, IMPORTE_DESCONTADO, NRO_COMANDA, ENTREGA);                    
                    tbNroComanda.Text = NRO_COMANDA.ToString();
                    int ID_COM = int.Parse(mid.role("ID", "CONFITERIA_COMANDAS", "ROL", VGlobales.vp_role));
                    guardarItems(ID_COM);
                    dlog.guardaComandaEnMesa(ID_MESA, NRO_COMANDA, ID_COM);
                }
                else
                {
                    dlog.modificarMesa(ID_COMANDA, MOZO, IMPORTE, PERSONAS, FORMA_DE_PAGO, CONTRALOR, COM_BORRADOR, CONSUME, TIPO_COMANDA, DESCUENTO_APLICADO, IMPORTE_DESCONTADO, ENTREGA);   
                }

                if (MSG == "SI")
                    MessageBox.Show("MESA GUARDADA", "LISTO");
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO GUARDAR LA MESA\n" + error, "ERROR");
            }
        }

        private void modificarImporteComanda(int ID_COMANDA)
        {
            try
            {
                decimal IMPORTE = sumarTotal();
                dlog.modificarImporteComanda(ID_COMANDA, IMPORTE);
                MessageBox.Show("SE GUARDO LA MESA", "LISTO");
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO ACTUALIZAR EL IMPORTE DE LA COMANDA\n" + error, "ERROR");
            }
        }

        private bool checkItems()
        {
            int ITEMS = dgItems.Rows.Count;

            if (ITEMS == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void modificarPersoPago(int MESA, int PERSO, int PAGO)
        {
            try
            {
                dlog.modPersoPagoTemp(MESA, PERSO, PAGO);
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR AL INTENTAR MODIFICAR PERSONAS Y FORMA DE PAGO\n"+error, "ERROR");
            }
        }
        
        private void guardarComanda(string MSG)
        {
            try
            {
                if (tbNroComanda.Text == "") // NUEVA COMANDA
                {
                    int SECUENCIA = int.Parse(dgSocio[4, dgSocio.CurrentCell.RowIndex].Value.ToString());
                    guardarMesa(0, MSG);
                    maxid mid = new maxid();
                    string ID_COMANDA = mid.m("ID", "CONFITERIA_COMANDAS");
                    string NRO_COMANDA = mid.m("NRO_COMANDA", "CONFITERIA_COMANDAS");
                    tbNroComanda.Text = NRO_COMANDA;
                    tbIdComanda.Text = ID_COMANDA;
                    ID_COM = int.Parse(ID_COMANDA);
                    buscarItems(int.Parse(ID_COMANDA), "SI", "X");
                }
                else // MODIFICA COMANDA
                {
                    guardarMesa(ID_COM, MSG);
                    agregarItems();
                    buscarItems(ID_COM, "SI", "X");
                    int PERSO = int.Parse(tbPersonas.Text);
                    int PAGO = int.Parse(cbFormaDePago.SelectedValue.ToString());
                    int MESA = int.Parse(tbMesa.Text);
                    modificarPersoPago(MESA, PERSO, PAGO);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO GUARDAR LA MESA\n" + error, "ERROR");
                btnGuardar.Enabled = true;
            }
            
        }

        private void botonGuardarMesa(string MSG)
        {
            btnGuardar.Enabled = false;
            Cursor = Cursors.WaitCursor;

            if (checkItems() == false)
            {
                MessageBox.Show("NO SE ENCONTRO NINGUN ITEM EN LA LISTA", "ERROR");
                btnGuardar.Enabled = true;
            }
            /*else if (cbMozo.SelectedValue.ToString() == "1")
            {
                MessageBox.Show("NO SE SELECCIONO NINGÚN MOZO", "ERROR");
                btnGuardar.Enabled = true;
            }*/
            else if (cbFormaDePago.SelectedValue.ToString() == "8" && tbContralor.Text == "")
            {
                MessageBox.Show("INGRESAR EL NUMERO DE CONTRALOR", "ERROR");
                btnGuardar.Enabled = true;
            }
            else if (cbFormaDePago.SelectedValue.ToString() == "8" && checkNumContralor(int.Parse(tbContralor.Text)) == true)
            {
                MessageBox.Show("EL NUMERO DE CONTRALOR INGRESADO YA FUE ASIGNADO", "ERROR");
                btnGuardar.Enabled = true;
            }
            /*else if (tbPersonas.Text == "0")
            {
                MessageBox.Show("NUMERO DE PERSONAS NO ESPECIFICADO", "ERROR");
                btnGuardar.Enabled = true;
            }*/
            else if (VGlobales.vp_role != "CONFITERIA" && cbFormaDePago.SelectedValue.ToString() == "8")
            {
                MessageBox.Show("FORMA DE PAGO NO ACEPTADA", "ERROR");
                btnGuardar.Enabled = true;
            }
            else
            {
                guardarComanda(MSG);
            }

            Cursor = Cursors.Default;
            btnGuardar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            botonGuardarMesa("SI");
        }

        private void btnImprimirComanda_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int NRO_SOC = int.Parse(dgSocio[0, dgSocio.CurrentCell.RowIndex].Value.ToString());
            int NRO_DEP = int.Parse(dgSocio[1, dgSocio.CurrentCell.RowIndex].Value.ToString());
            SOCIOS.afiliadoBeneficio ab = new afiliadoBeneficio();
            string[] AFIL_BENEF = ab.get(NRO_SOC, NRO_DEP);
            string AFILIADO = AFIL_BENEF[0];
            string BENEFICIO = AFIL_BENEF[1];
            string NOM_SOC = dgSocio[3, dgSocio.CurrentCell.RowIndex].Value.ToString();
            decimal IMPORTE = Convert.ToDecimal(tbTotal.Text);
            string FECHA = DateTime.Today.ToString();
            SOCIOS.obtenerDestino od = new obtenerDestino();
            string DESTINO = od.get(NRO_SOC, NRO_DEP);
            SOCIOS.obtenerLegPer olp = new obtenerLegPer();
            int LEG_PER = olp.get(NRO_SOC, NRO_DEP);
            string FORMA_DE_PAGO = cbFormaDePago.SelectedValue.ToString();
            int MESA = int.Parse(tbMesa.Text);
            int SECUENCIA = int.Parse(dgSocio[4, dgSocio.CurrentCell.RowIndex].Value.ToString());
            int D_ADTO = 1;
            int M_ADTO = DateTime.Today.Month;

            if (M_ADTO < 12)
                M_ADTO = M_ADTO + 1;

            int Y_ADTO = DateTime.Today.Year;
            string A_DTO = D_ADTO.ToString() + "/" + M_ADTO.ToString() + "/" + Y_ADTO.ToString();
            int TIPO_COMANDA = int.Parse(cbTipoDeComanda.SelectedValue.ToString());

            if (MessageBox.Show("SE VA A CERRAR LA MESA " + tbMesa.Text + "\n¿CONTINUAR?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                botonGuardarMesa("NO");
                maxid mid = new maxid();

                if (tbNroComanda.Text != "")
                {
                    try
                    {
                        if (MESA == 27)
                            dlog.cerrarMesa(ID_MESA, "DELIVERY");
                        else
                            dlog.cerrarMesa(ID_MESA, "CERRADA");

                        try
                        {
                            int ID_COM = int.Parse(tbIdComanda.Text);
                            buscarComanda(ID_COM);
                            buscarItems(ID_COM, "NO", "X");
                            imprimir i = new imprimir();
                            i.imprimirComanda(ITEMS, COMANDA, "SOCIO");

                            /*if (VGlobales.vp_role == "CPOCABA")
                            {
                                i.imprimirComanda(ITEMS, COMANDA, "COCINA");
                            }*/

                            if (FORMA_DE_PAGO == "8")
                            {
                                int HORA = DateTime.Now.Hour;
                                int MINUTO = DateTime.Now.Minute;
                                int SEGUNDO = DateTime.Now.Second;
                                string TIEMPO = HORA.ToString() + ":" + MINUTO.ToString() + ":" + SEGUNDO.ToString();
                                FECHA = dpFechaComanda.Text + " " + TIEMPO;
                                dlog.nuevaSolicitudDescuentoConfiteria(FECHA, NOM_SOC, IMPORTE, DESTINO, LEG_PER, AFILIADO, BENEFICIO, A_DTO, ID_COM);
                                int ID_SOLICITUD = int.Parse(mid.m("ID", "CONFITERIA_SOL_DESC"));
                                listadoComandas lc = new listadoComandas();
                                SOLICITUD = lc.buscarSolicitud(ID_SOLICITUD, "CONFITERIA_SOL_DESC");
                                dlog.descuentoEnComanda(ID_COM, ID_SOLICITUD);
                                i.imprimirSolicitud(SOLICITUD);
                            }

                            if (TIPO_COMANDA == 2)
                            {
                                dlog.nuevaSolicitudEspecial(FECHA, NOM_SOC, IMPORTE, DESTINO, LEG_PER, AFILIADO, BENEFICIO, A_DTO, ID_COM);
                                int ID_SOLICITUD = int.Parse(mid.m("ID", "CONFITERIA_SOL_ESP"));
                                listadoComandas lc = new listadoComandas();
                                SOLICITUD = lc.buscarSolicitud(ID_SOLICITUD, "CONFITERIA_SOL_ESP");
                                dlog.descuentoEnComanda(ID_COM, ID_SOLICITUD);
                                i.imprimirSolicitudEspecial(SOLICITUD);
                            }

                            this.Close();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("NO SE PUDO IMPRIMIR LA COMANDA\n" + error, "ERROR");
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO CERRAR LA MESA\n" + error, "ERROR");
                    }
                }
            }

            Cursor = Cursors.Default;
        }

        private void marcarItemImpreso()
        {
            foreach (DataGridViewRow row in dgItems.Rows)
            {
                if (row.Cells[9].Value.ToString() != "SI")
                {
                    dlog.marcarItemImpreso(int.Parse(row.Cells[7].Value.ToString()));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                botonGuardarMesa("NO");
                int ID_COMANDA = int.Parse(tbNroComanda.Text);
                int MESA = int.Parse(tbMesa.Text);
                imprimir i = new imprimir();
                buscarComanda(ID_COMANDA);
                buscarItems(ID_COMANDA, "NO", "NO");
                    
                if (ITEMS.Tables[0].Rows.Count > 0)
                {
                    i.imprimirComanda(ITEMS, COMANDA, "COCINA");
                    marcarItemImpreso();
                }
                else
                {
                    MessageBox.Show("NO SE ENCONTRARON ITEMS NUEVOS PARA IMPRIMIR", "ERROR");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO IMPRIMIR LA COMANDA\n" + error, "ERROR");
            }

            Cursor = Cursors.Default;
        }

        private void btnCerrarComanda_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (MessageBox.Show("¿GUARDAR LA COMANDA?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (checkItems() == false)
                {
                    MessageBox.Show("NO SE ENCONTRO NINGUN ITEM EN LA LISTA", "ERROR");
                }
                else
                {
                    guardarComanda("NO");
                    this.Close();
                }
            }
            else
            {
                if (tbNroComanda.Text == "")
                {
                    int MESA = int.Parse(tbMesa.Text);
                    dlog.cerrarMesa(MESA, "CERRADA");
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            
            Cursor = Cursors.Default;
        }

        private void mostrarArancel()
        { 
            string TIPO = cbSectAct.Text.Trim();
            int SEC_ACT = int.Parse(cbSectAct.SelectedValue.ToString());
            int PROF = int.Parse(cbProf.SelectedValue.ToString());
            arancel aa = new arancel();
            decimal VALOR = aa.valorGrupo(SEC_ACT, GRUPO, PROF);

            if (VALOR > 0)
                tbImporteItem.Text = VALOR.ToString();
            else
            {
                tbImporteItem.Text = "";
                tbImporteItem.ReadOnly = false;
            }
        }
        
        private void cbProf_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int SEL_ITEM = int.Parse(cbProf.SelectedValue.ToString());
            int STOCK = utils.getItemStock(Convert.ToInt32(SEL_ITEM));
            tbStock.Text = STOCK.ToString();

            if (STOCK < 10 && STOCK > 0)
                lbStockMenor10.Visible = true;
            else
                lbStockMenor10.Visible = false;
            mostrarArancel();
        }

        private void resetNroContralor()
        {
            if (cbFormaDePago.SelectedValue.ToString() == "8")
            {
                tbContralor.Text = "";
                tbContralor.ReadOnly = false;
            }
            else
            {
                tbContralor.Text = "";
                tbContralor.ReadOnly = true;
            }
        }

        private void cbFormaDePago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgSocio.Rows)
            {
                string BENEFICIO = row.Cells[6].Value.ToString();
                string FORMA_DE_PAGO = cbFormaDePago.SelectedValue.ToString();
                
                if ((BENEFICIO == "X" || BENEFICIO == "0/0/0") && FORMA_DE_PAGO == "8")
                {
                    MessageBox.Show("LOS DESCUENTOS SOLO ESTAN DISPONIBLES PARA RETIRADOS", "ERROR");
                    cbFormaDePago.SelectedIndex = 0;
                }
            }
            
            resetNroContralor();
        }

        private void cargarItemEnCombos(string SEL_TIPO, string SEL_ITEM)
        {
            cbSectAct.SelectedValue = int.Parse(SEL_TIPO);
            comboProfesionales(cbSectAct.SelectedValue.ToString());
            cbProf.SelectedValue = int.Parse(SEL_ITEM);
        }

        public void buscarItems(string CONDICION)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(CONDICION);
            string CONDICION_LIMPIA = System.Text.Encoding.UTF8.GetString(bytes);
            var FILTRO = LISTA_ITEMS.Where(x => x.NOMBRE.Contains(CONDICION_LIMPIA)).ToList();
            dgResultados.DataSource = null;
            dgResultados.DataSource = FILTRO;
            dgResultados.Columns[0].Visible = false;
            dgResultados.Columns[1].Visible = false;
            dgResultados.Columns[2].Width = 600;
        }
        
        public class ITEMS_CONFITERIA
        {
            public string ID { get; set; }
            public string ESPECIALIDAD { get; set; }
            public string NOMBRE { get; set; }

            public ITEMS_CONFITERIA(string id, string especialidad, string nombre)
            {
                this.ID = id;
                this.ESPECIALIDAD = especialidad;
                this.NOMBRE = nombre;
            }
        }

        public class ITEMS_CONFITERIA_FILTRO
        {
            public string ID { get; set; }
            public string ESPECIALIDAD { get; set; }
            public string NOMBRE { get; set; }

            public ITEMS_CONFITERIA_FILTRO(string id, string especialidad, string nombre)
            {
                this.ID = id;
                this.ESPECIALIDAD = especialidad;
                this.NOMBRE = nombre;
            }
        }

        private void generarListaItems()
        {
            try
            {
                LISTA_ITEMS = new List<ITEMS_CONFITERIA>();
                string QUERY = "SELECT P.ID, PE.ESPECIALIDAD, P.NOMBRE FROM PROFESIONALES P, PROF_ESP PE WHERE P.ID = PE.PROFESIONAL AND P.ROL = 'MENU " + VGlobales.vp_role + "' AND P.BAJA IS NULL ORDER BY P.NOMBRE ASC;";
                DataSet ds1 = new DataSet();
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    FbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string ID = reader.GetString(reader.GetOrdinal("ID")).Trim();
                        string ESPECIALIDAD = reader.GetString(reader.GetOrdinal("ESPECIALIDAD")).Trim();
                        string NOMBRE = reader.GetString(reader.GetOrdinal("NOMBRE")).Trim();
                        byte[] bytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(NOMBRE);
                        string NOMBRE_LIMPIO = System.Text.Encoding.UTF8.GetString(bytes);
                        LISTA_ITEMS.Add(new ITEMS_CONFITERIA(ID, ESPECIALIDAD, NOMBRE_LIMPIO));
                    }
                }
            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR LOS RESULTADOS");
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string CONDICION = textBox1.Text.Trim();
            buscarItems(CONDICION);
        }

        private void dgResultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string SEL_TIPO = dgResultados[1, dgResultados.CurrentCell.RowIndex].Value.ToString();
            string SEL_ITEM = dgResultados[0, dgResultados.CurrentCell.RowIndex].Value.ToString();
            int STOCK = utils.getItemStock(Convert.ToInt32(SEL_ITEM));
            tbStock.Text = STOCK.ToString();

            if (STOCK < 10 && STOCK > 0)
                lbStockMenor10.Visible = true;
            else
                lbStockMenor10.Visible = false;

            cargarItemEnCombos(SEL_TIPO, SEL_ITEM);
            mostrarArancel();
        }

        private void cambiarDescuento(int TIPO_COMANDA)
        {
            string QUERY = "SELECT DESCUENTO FROM CONFITERIA_TIPO_COMANDA WHERE ID = " + TIPO_COMANDA + ";";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            tbDescuento.Text = foundRows[0][0].ToString();
        }

        private void cbTipoDeComanda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int TIPO_COMANDA = int.Parse(cbTipoDeComanda.SelectedValue.ToString());
            cambiarDescuento(TIPO_COMANDA);

            if (TIPO_COMANDA == 2)
            {
                cbFormaDePago.SelectedValue = 1;
                cbFormaDePago.Enabled = false;
            }
            else
            {
                cbFormaDePago.Enabled = true;
            }

            resetNroContralor();
            decimal TOTAL = sumarTotal();
            tbTotal.Text = TOTAL.ToString();
        }        
    }
}
