﻿using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

namespace SOCIOS
{
    public partial class compras : Form
    {
        existe existe = new existe();
        private decimal IMPORTE_TOTAL { get; set; }
        private DataSet OP { get; set; }
        private DataSet CHEQUES { get; set; }
        private DataSet FACTURAS { get; set; }
        private int ID_ARTICULO { get; set; }
        private string BUSCO_QUERY { get; set; }
        private string ACCION { get; set; }
        private decimal SUMA_ART { get; set; }
        private string S_AJUSTE { get; set; }
        
        List<ART_SOL> LISTA_ART_SOL;
        List<ART_SOL_FILTRO> LISTA_ART_SOL_FILTRO;

        bo dlog = new bo();
        BO.bo_Compras BO_COMPRAS = new BO.bo_Compras();
        maxid mid = new maxid();

        public compras()
        {
            InitializeComponent();
            comboAjuste(cbAjuste);
            comboDescuento(cbDescuento);
            comboDescuento(cbDescGlobal);
            comboTipoProveedor();
            comboTipoComprobante(cbTipoBusqueda);
            comboTipoComprobante(cbTipoComprobante);
            comboSectores(cbSectorBusqueda, 0);
            comboSectores(cbSectores, 0);            
            lvFacturas.MultiSelect = true;
            comboTipoCheques();
            ACCION = "NUEVA";

            if (VGlobales.vp_role != "TESORERIA" && VGlobales.vp_role != "CONTADURIA")
            {
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabAdjuntos);
                tabControl1.TabPages.Remove(tpProveedores);
                tabControl1.TabPages.Remove(tabAdjuntos);
                tabControl1.TabPages.Remove(tabOrdenesDePago);
                tabControl1.TabPages.Remove(tpBancosCuentasCheques); 
                tabControl1.TabPages.Remove(tabLibroBanco);
            }
            else
            {
                comboBeneficiarios();
            }


            string TIPO_COMPROBANTE = cbTipoComprobante.SelectedValue.ToString();

            if (TIPO_COMPROBANTE == "2" || TIPO_COMPROBANTE == "9" || TIPO_COMPROBANTE == "12")
            {
                tbNumFactura.Enabled = true;
                tbNumSolicitud.Enabled = false;
            }

            string TIPO_DE_BUSQUEDA = cbTipoBusqueda.SelectedValue.ToString();

            if (TIPO_DE_BUSQUEDA == "2" || TIPO_DE_BUSQUEDA == "9" || TIPO_DE_BUSQUEDA == "12")
            {
                tbBuscarNumeroFactura.Visible = true;
                tbBuscarNumeroSolicitud.Visible = false;
            }

            if (VGlobales.vp_username == "JBUESDORFF" || VGlobales.vp_username == "CHERNANDEZ" || VGlobales.vp_username == "AHERNANDEZ" || VGlobales.vp_username == "SBARBEITO")
            {
                cONFIRMARANULACIÓNToolStripMenuItem.Visible = true;
            }
        }

        private bool recibeCompras()
        {
            bool RECIBE = false;
            string QUERY = "SELECT PARAM FROM CONFIG WHERE ROL = '" + VGlobales.vp_role + "' AND PARAM = 'RECIBE_COMPRAS';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
                RECIBE = true;

            return RECIBE;
        }

        public class ART_SOL
        {
            public string ID { get; set; }
            public string DETALLE { get; set; }
            public string TIPO { get; set; }
            public string ID_TIPO { get; set; }

            public ART_SOL(string id, string detalle, string tipo, string id_tipo)
            {
                this.ID = id;
                this.DETALLE = detalle;
                this.TIPO = tipo;
                this.ID_TIPO = id_tipo;
            }
        }

        public class ART_SOL_FILTRO
        {
            public string ID { get; set; }
            public string DETALLE { get; set; }
            public string TIPO { get; set; }
            public string ID_TIPO { get; set; }

            public ART_SOL_FILTRO(string id, string detalle, string tipo, string id_tipo)
            {
                this.ID = id;
                this.DETALLE = detalle;
                this.TIPO = tipo;
                this.ID_TIPO = id_tipo;
            }
        }

        private void generarListaArtSol()
        {
            try
            {
                LISTA_ART_SOL = new List<ART_SOL>();
                string QUERY = "SELECT A.ID, A.DETALLE, T.DETALLE AS TIPO, A.TIPO AS ID_TIPO FROM ARTICULOS A, TIPOS_ARTICULOS T WHERE A.TIPO = T.ID;";
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
                        string DETALLE = reader.GetString(reader.GetOrdinal("DETALLE")).Trim();
                        string TIPO = reader.GetString(reader.GetOrdinal("TIPO")).Trim();
                        string ID_TIPO = reader.GetString(reader.GetOrdinal("ID_TIPO")).Trim();
                        LISTA_ART_SOL.Add(new ART_SOL(ID, DETALLE, TIPO, ID_TIPO));
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR AL CARGAR LOS RESULTADOS " + e);
            }
        }

        private void comboAjuste(ComboBox COMBO)
        {
            COMBO.Items.Add("+");
            COMBO.Items.Add("-");
            COMBO.SelectedIndex = 1;
        }

        private void comboDescuento(ComboBox COMBO)
        {
            COMBO.Items.Add("%");
            COMBO.Items.Add("$");
            COMBO.SelectedIndex = 1;
        }

        private void mostrarResultados(FbDataReader reader)
        {
            lvProveedores.Items.Clear();
            lvProveedores.Columns.Clear();
            lvProveedores.BeginUpdate();

            if (lvProveedores.Columns.Count == 0)
            {
                lvProveedores.Columns.Add("RAZÓN SOCIAL");
                lvProveedores.Columns.Add("EMAIL");
                lvProveedores.Columns.Add("DOMICILIO");
                lvProveedores.Columns.Add("TELEFONO");
                lvProveedores.Columns.Add("WEB");
                lvProveedores.Columns.Add("CONTACTO");
                lvProveedores.Columns.Add("CUIT");
                lvProveedores.Columns.Add("CUENTA");
                lvProveedores.Columns.Add("CBU");
                lvProveedores.Columns.Add("ID");
                lvProveedores.Columns.Add("TIPO");
                lvProveedores.Columns.Add("TIPO CUENTA");
                lvProveedores.Columns.Add("TIPO PROVE");
            }
            do
            {
                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("RAZON_SOCIAL")).Trim().ToUpper());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("EMAIL")).Trim().ToLower());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("DOMICILIO")).Trim().ToUpper());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TELEFONO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("WEB")).Trim().ToLower());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("CONTACTO")).Trim().ToUpper());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("CUIT")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("CUENTA")));
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("CBU")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ID")));
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TIPO")));
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TIPO_DE_CUENTA")));
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TIPO_PROVE")));
                lvProveedores.Items.Add(listItem);
            }

            while (reader.Read());
            lvProveedores.EndUpdate();
            lvProveedores.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvProveedores.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvProveedores.Columns[9].Width = 0;
            lvProveedores.Columns[10].Width = 0;
            lvProveedores.Columns[11].Width = 0;
        }

        static void OpenMicrosoftExcel(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }

        private void buscarProveedores(string CONDICION, string ACCION)
        {
            conString cs = new conString();
            string connectionString = cs.get();

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string busco = "SELECT * FROM PROVEEDORES_S('" + CONDICION + "')";
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
                            switch (ACCION)
                            {
                                case "MOSTRAR":
                                    mostrarResultados(reader);
                                    break;

                                case "EXCEL":
                                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                                    saveFileDialog1.Filter = "Archivo XLS|*.xls";
                                    saveFileDialog1.Title = "Guardar Listado";

                                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        listadoExcelProveedores(ds, saveFileDialog1.FileName);
                                        Cursor = Cursors.Default;
                                        DialogResult result = MessageBox.Show("LISTADO GENERADO CORRECTAMENTE \n\n ¿ABRIR EL ARCHIVO?", "LISTO!", MessageBoxButtons.YesNo);

                                        if (result == DialogResult.Yes)
                                        {
                                            OpenMicrosoftExcel(saveFileDialog1.FileName);
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
        
        private void limpiarFormulario()
        {
            tbRazonSocial.Text = "";
            tbEmail.Text = "";
            tbDomicilio.Text = "";
            tbTelefono.Text = "";
            tbWeb.Text = "";
            tbContacto.Text = "";
            tbCuit.Text = "";
            tbCuenta.Text = "";
            tbCBU.Text = "";
            cbTipoDeCuenta.SelectedIndex = 0;
            cbTipoProveedor.SelectedIndex = 0;
        }

        private void limpiarFactura()
        {
            cbProveedores.Text = "";
            tbNumFactura.Text = "";
            dpFechaFactura.Text = DateTime.Today.ToShortDateString();
            tbImporte.Text = "";
            tbSerie.Text = "";
            tbObservaciones.Text = "";
            tbCantidad.Text = "";
            tbDetalle.Text = "";
            tbValor.Text = "";
            lbArchivoAdjunto.Text = "ARCHIVO PDF NO CARGADO";
            cbSectores.SelectedIndex = 0;
            cbTipoComprobante.SelectedIndex = 0;
            tbNumSolicitud.Text = "";
            tbNumSecGral.Text = "";
            tbAcreedor.Text = "";
        }

        private void limpiarBusquedaFactura()
        {
            tbBuscarFactura.Text = "";
            tbBuscarNumeroFactura.Text = "";
            tbBuscarNumeroSolicitud.Text = "";
            cbTipoBusqueda.SelectedIndex = 0;
            tbBuscarNumeroSolicitud.Visible = false;
            tbBuscarNumeroFactura.Visible = true;
            lvFacturas.Items.Clear();
        }

        private void limpiarArticulo()
        {
            tbCantidad.Text = "";
            tbDetalle.Text = "";
            tbValor.Text = "";
            tbSerie.Text = "";
            cbDescuento.SelectedIndex = 0;
            tbDescuento.Text = "";
            cbTipoArticulo.SelectedIndex = 0;
            ID_ARTICULO = 0;
            btAgregarArticulo.Enabled = true;
            btnModArt.Enabled = true;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(lvProveedores.SelectedItems[0].SubItems[9].Text);
            string USR_BAJA = VGlobales.vp_username;
            DateTime Hoy = DateTime.Today;
            string FE_BAJA = Hoy.ToString("dd/MM/yyyy");

            try
            {
                BO_COMPRAS.eliminaUnProveedor(ID, USR_BAJA, FE_BAJA);
                MessageBox.Show("PROVEEDOR ELIMINADO CORRECTAMENTE");
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO ELIMINAR EL PROVEEDOR\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void tpBancosCuentasCheques_Enter(object sender, EventArgs e)
        {
            comboBancosChequeras();
            comboProveedores(cbProveedorCtaBancaria);
            comboProveedores(cbProveedoresFiltro);
            comboTipoCuentasBancarias();
            buscarCuentasBancarias(0);
            toggleBotones("OCULTAR");
        }

        private void tabAdjuntos_Enter(object sender, EventArgs e)
        {
            toggleBotones("OCULTAR");
            comboImpuestosRetenciones(cbImpuestoRetencion);
            comboRegimenesRetenciones(cbRegimenRetencion);

            if (LBIDDATO.Text != "")
            {
                grupoReciboOficial.Enabled = true;
                grupoRetencion.Enabled = true;
                grupoRemito.Enabled = true;
                grupoOrdenDePago.Enabled = true;
                grupoNotaDeCredito.Enabled = true;
            }
        }

        private void desbloquearFormsOP()
        {
            if (lvOP.Items.Count > 0)
            {
                gbChequesSeleccionados.Enabled = true;
                gbDatosDelCheque.Enabled = true;
                gbObservacionesOP.Enabled = true;
                btnGuardarOP.Enabled = true;
                btnCancelarOP.Enabled = true;
                gbDatosTransferencia.Enabled = true;
                gbTransSeleccionadas.Enabled = true;
                cbCuentaDestinoTrans.Enabled = true;
            }
            else
            {
                gbChequesSeleccionados.Enabled = false;
                gbDatosDelCheque.Enabled = false;
                gbObservacionesOP.Enabled = false;
                btnGuardarOP.Enabled = false;
                btnCancelarOP.Enabled = false;
                gbDatosTransferencia.Enabled = false;
                gbTransSeleccionadas.Enabled = false;
            }
        }

        private void tabOrdenesDePago_Enter(object sender, EventArgs e)
        {
            if (VGlobales.vp_role == "TESORERIA")
            {
                totalImporteFacturasOP();
                tbImporteOP.Text = lbTotalFacturasOP.Text;
                tbImporteTrans.Text = lbTotalFacturasOP.Text;
                desbloquearFormsOP();
                comboBancos(cbBancos);
                comboBancos(cbBancoOrigenTrans);
                int BANCO = int.Parse(cbBancos.SelectedValue.ToString());
                comboCuentasBancariasCargadas(BANCO, cbCtaOrigenTrans);
                comboCheques(BANCO, cbCheques);
                int CHEQUE = 0;

                if (cbCheques.Items.Count > 0)
                {
                    CHEQUE = int.Parse(cbCheques.Text);
                    tipoCheque(BANCO, CHEQUE);
                }

                comboBeneficiarios();
                traeCuentaBancariaProveedor();
                toggleBotones("OCULTAR");
                comboCheques(int.Parse(cbBancoOrigenTrans.SelectedValue.ToString()), cbChequeAcompTrans);
            }
        }

        private void tpProveedores_Enter(object sender, EventArgs e)
        {
            comboTipoProveedor();
            comboTipoDeCuenta();
            comboTiposExistentes();
            toggleBotones("OCULTAR");
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            tbBuscarFactura.Focus();
            comboProveedores(cbProveedores);
            comboTipoArticulo(cbTipoArticulo);
            toggleBotones("MOSTRAR");
        }

        private void comboAnticipos()
        {
            string query = "SELECT ID, TRIM(RAZON_SOCIAL) AS RS FROM PROVEEDORES WHERE FE_BAJA IS NULL AND TIPO_DE_CUENTA = 'A' ORDER BY RAZON_SOCIAL ASC;";
            cbProveedores.DataSource = null;
            cbProveedores.Items.Clear();
            cbProveedores.DataSource = dlog.BO_EjecutoDataTable(query);
            cbProveedores.DisplayMember = "RS";
            cbProveedores.ValueMember = "ID";
            cbProveedores.SelectedItem = 0;
        }

        private void comboProveedores(ComboBox COMBO)
        {
            string query = "SELECT ID, TRIM(RAZON_SOCIAL) AS RS FROM PROVEEDORES WHERE FE_BAJA IS NULL AND TIPO_DE_CUENTA <> 'A' ORDER BY RAZON_SOCIAL ASC;";
            COMBO.DataSource = null;
            COMBO.Items.Clear();
            COMBO.DataSource = dlog.BO_EjecutoDataTable(query);
            COMBO.DisplayMember = "RS";
            COMBO.ValueMember = "ID";
            COMBO.SelectedItem = 0;
        }

        private void comboTiposExistentes()
        {
            string query = "SELECT ID, TRIM(DETALLE) AS DETALLE FROM TIPOS_ARTICULOS ORDER BY DETALLE ASC;";
            cbTiposExistentes.DataSource = null;
            cbTiposExistentes.Items.Clear();
            cbTiposExistentes.DataSource = dlog.BO_EjecutoDataTable(query);
            cbTiposExistentes.DisplayMember = "DETALLE";
            cbTiposExistentes.ValueMember = "ID";
            cbTiposExistentes.SelectedIndex = -1;
        }

        private void comboTipoArticulo(ComboBox COMBO)
        {
            string query = "SELECT ID, TRIM(DETALLE) AS DETALLE FROM TIPOS_ARTICULOS ORDER BY DETALLE ASC;";
            COMBO.DataSource = null;
            COMBO.Items.Clear();
            COMBO.DataSource = dlog.BO_EjecutoDataTable(query);
            COMBO.DisplayMember = "DETALLE";
            COMBO.ValueMember = "ID";
            COMBO.SelectedItem = 0;
        }

        private void comboTipoProveedor()
        {
            string query = "SELECT ID, TRIM(DETALLE) AS DETALLE FROM TIPOS_ARTICULOS ORDER BY DETALLE ASC;";
            cbTipoProveedor.DataSource = null;
            cbTipoProveedor.Items.Clear();
            cbTipoProveedor.DataSource = dlog.BO_EjecutoDataTable(query);
            cbTipoProveedor.DisplayMember = "DETALLE";
            cbTipoProveedor.ValueMember = "ID";
            cbTipoProveedor.SelectedItem = 0;
        }

        private void comboImpuestosRetenciones(ComboBox COMBO)
        {
            string query = "SELECT * FROM RETENCIONES_IMPUESTOS ORDER BY ID ASC;";
            COMBO.DataSource = null;
            COMBO.Items.Clear();
            COMBO.DataSource = dlog.BO_EjecutoDataTable(query);
            COMBO.DisplayMember = "NOMBRE";
            COMBO.ValueMember = "ID";
            COMBO.SelectedItem = 0;
        }

        private void comboRegimenesRetenciones(ComboBox COMBO)
        {
            string query = "SELECT * FROM RETENCIONES_REGIMENES ORDER BY ID ASC;";
            COMBO.DataSource = null;
            COMBO.Items.Clear();
            COMBO.DataSource = dlog.BO_EjecutoDataTable(query);
            COMBO.DisplayMember = "NOMBRE";
            COMBO.ValueMember = "ID";
            COMBO.SelectedItem = 0;
        }

        private void comboTipoDeCuenta()
        {
            string query = "SELECT ID, TIPO FROM TIPOS_DE_CUENTA;";
            cbTipoDeCuenta.DataSource = null;
            cbTipoDeCuenta.Items.Clear();
            cbTipoDeCuenta.DataSource = dlog.BO_EjecutoDataTable(query);
            cbTipoDeCuenta.DisplayMember = "TIPO";
            cbTipoDeCuenta.ValueMember = "ID";
            cbTipoDeCuenta.SelectedIndex = 0;
        }

        private void comboTipoComprobante(ComboBox COMBO)
        {
            string query = "SELECT ID, TIPO FROM TIPOS_CARGA_COMPROBANTE ORDER BY ORDEN";

            if (COMBO == cbTipoFactura)
                query = "SELECT ID, TIPO FROM TIPOS_CARGA_COMPROBANTE WHERE ID IN(1, 4, 5, 6, 7, 8) ORDER BY ORDEN";

            if (COMBO == cbTipoComprobante)
                query = "SELECT ID, TIPO FROM TIPOS_CARGA_COMPROBANTE WHERE TIPO <> 'TODOS' ORDER BY ORDEN";

            COMBO.DataSource = null;
            COMBO.Items.Clear();
            COMBO.DataSource = dlog.BO_EjecutoDataTable(query);
            COMBO.DisplayMember = "TIPO";
            COMBO.ValueMember = "ID";
            COMBO.SelectedIndex = 0;
        }

        private void comboPrioridadesSolicitudes(ComboBox COMBO, string SELECTED)
        {
            if(COMBO == cbPrioridadFiltro)
                COMBO.Items.Add("TODAS");

            COMBO.Items.Add("MEDIA");
            COMBO.Items.Add("ALTA");
            COMBO.Items.Add("BAJA");

            if (SELECTED != "X")
                COMBO.SelectedItem = SELECTED;
        }

        private void comboPendienteRespuesta(ComboBox COMBO, string SELECTED)
        {
            if(COMBO == cbPteRtaFiltro)
                COMBO.Items.Add("TODAS");

            COMBO.Items.Add("SI");
            COMBO.Items.Add("NO");

            if(SELECTED != "X")
                COMBO.SelectedItem = SELECTED;
        }

        private void comboTipoSolicitud(ComboBox COMBO, int SELECTED)
        {
            string query = "SELECT VALOR, VALOR1 FROM CONFIG WHERE PARAM = 'TIPO_SOLICITUD';";
            COMBO.DataSource = null;
            COMBO.Items.Clear();
            COMBO.DataSource = dlog.BO_EjecutoDataTable(query);
            COMBO.DisplayMember = "VALOR1";
            COMBO.ValueMember = "VALOR";
            COMBO.SelectedIndex = SELECTED;
        }

        private void comboSectores(ComboBox SECTORES, int SELECTED)
        {
            string query = "SELECT DISTINCT TRIM(ROL) AS ROL FROM SECTACT WHERE ESTADO = 1 ORDER BY ROL;";

            if (SECTORES == cbSectDestSolicitudes)
                query = "SELECT DISTINCT TRIM(ROL) AS ROL FROM SECTACT WHERE ESTADO = 1 AND COMPRA = 1 ORDER BY ROL;";

            SECTORES.DataSource = null;
            SECTORES.Items.Clear();
            SECTORES.DataSource = dlog.BO_EjecutoDataTable(query);
            SECTORES.DisplayMember = "ROL";
            SECTORES.ValueMember = "ROL";
            SECTORES.SelectedIndex = SELECTED;
        }

        private bool sumaFacturaHija(object SENDER, int ID_FACTURA)
        {
            bool RES = false;
            decimal TOTAL_FACTURA = Convert.ToDecimal(tbImporte.Text);
            decimal TOTAL_ROWS = 0;
            decimal IMPORTE_ROW = 0;
            int ID_ROW = 0;
            int FACTURAS_HIJAS = dgFacturasHijas.Rows.Count;
            decimal VALOR_AGREGAR = Convert.ToDecimal(tbImporteFactura.Text);

            if (SENDER == btAgregarArticulo)
            {
                if (FACTURAS_HIJAS > 0)
                {
                    foreach (DataGridViewRow row in dgFacturasHijas.Rows)
                    {
                        IMPORTE_ROW = Convert.ToDecimal(row.Cells["IMPORTE"].Value);
                        TOTAL_ROWS = TOTAL_ROWS + IMPORTE_ROW;
                    }

                    if (TOTAL_ROWS == TOTAL_FACTURA)
                    {
                        RES = true;
                    }
                    else
                    {
                        RES = false;
                    }
                }
                else
                {
                    if (VALOR_AGREGAR <= TOTAL_FACTURA)
                    {
                        RES = true;
                    }
                }
            }

            return RES;
        }

        private bool suma(object SENDER, int ID_ARTICULO)
        {
            decimal TOTAL_FACTURA = Convert.ToDecimal(tbImporte.Text);
            decimal TOTAL_ROWS = 0;
            decimal VALOR_AGREGAR = Convert.ToDecimal(tbValor.Text);
            decimal CANTIDAD_AGREGAR = Convert.ToDecimal(tbCantidad.Text);
            string descuento;
            decimal importe = 0;

            if (tbDescuento.Text != "" && cbDescuento.Text == "%")
            {
                descuento = tbDescuento.Text + cbDescuento.Text;
                decimal aDescontar = Convert.ToDecimal(tbValor.Text) * Convert.ToDecimal(tbDescuento.Text) / 100;
                decimal valorConDescuento = Convert.ToDecimal(tbValor.Text) - aDescontar;
                importe = valorConDescuento * Convert.ToDecimal(tbCantidad.Text.Trim());
                importe = decimal.Round(importe, 2);
            }

            if (tbDescuento.Text != "" && cbDescuento.Text == "$")
            {
                descuento = cbDescuento.Text + tbDescuento.Text;
                decimal aDescontar = Convert.ToDecimal(tbDescuento.Text);
                decimal valorConDescuento = Convert.ToDecimal(tbValor.Text) - aDescontar;
                importe = valorConDescuento * Convert.ToDecimal(tbCantidad.Text.Trim());
                importe = decimal.Round(importe, 2);
            }

            decimal IMPORTE_ROW = 0;
            int ID_ROW = 0;
            bool RES = false;
            int ARTICULOS = dgArticulos.Rows.Count;

            if (SENDER == btAgregarArticulo)
            {
                if (ARTICULOS > 0)
                {
                    foreach (DataGridViewRow row in dgArticulos.Rows)
                    {
                        IMPORTE_ROW = Convert.ToDecimal(row.Cells["IMPORTE"].Value);
                        TOTAL_ROWS = TOTAL_ROWS + IMPORTE_ROW;
                    }

                    if (TOTAL_ROWS + (importe * CANTIDAD_AGREGAR) <= TOTAL_FACTURA)
                    {
                        RES = true;
                    }
                }
                else
                {
                    if ((importe * CANTIDAD_AGREGAR) <= TOTAL_FACTURA)
                    {
                        RES = true;
                    }
                }
            }

            if (SENDER == btnModArt)
            {
                if (ARTICULOS > 0)
                {
                    foreach (DataGridViewRow row in dgArticulos.Rows)
                    {
                        IMPORTE_ROW = Convert.ToDecimal(row.Cells["IMPORTE"].Value);

                        if (lbID.Text != "ID_FACTURA")
                        {
                            ID_ROW = int.Parse(row.Cells["AID"].Value.ToString());

                            if (ID_ROW != ID_ARTICULO)
                            {
                                TOTAL_ROWS = TOTAL_ROWS + IMPORTE_ROW;
                            }
                        }
                        else
                        {
                            ID_ROW = int.Parse(row.Index.ToString());

                            if (ID_ROW != ID_ARTICULO)
                            {
                                TOTAL_ROWS = TOTAL_ROWS + IMPORTE_ROW;
                            }
                        }
                    }

                    if (TOTAL_ROWS + (importe * CANTIDAD_AGREGAR) <= TOTAL_FACTURA)
                    {
                        RES = true;
                    }
                }
                else
                {
                    if (importe <= TOTAL_FACTURA)
                    {
                        RES = true;
                    }
                }
            }

            return RES;
        }

        private bool checkProveedorFactura()
        { 
            bool RES = false;
            int PROVEEDOR = int.Parse(cbProveedores.SelectedValue.ToString());
            string TIPO_DE_COMPROBANTE = cbTipoComprobante.SelectedValue.ToString();

            if (TIPO_DE_COMPROBANTE != "2" && TIPO_DE_COMPROBANTE != "9" && TIPO_DE_COMPROBANTE != "12")
            {
                string NUM_FACTURA = tbNumFactura.Text.Trim();
                string QUERY = "SELECT ID FROM FACTURAS WHERE PROVEEDOR = " + PROVEEDOR + " AND NUM_FACTURA = '" + NUM_FACTURA + "' AND TIPO = " + TIPO_DE_COMPROBANTE + " AND ANULADO IS NULL;";
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

                if (foundRows.Length > 0)
                {
                    RES = true;
                }

                if (RES == true && (PROVEEDOR == 814 || PROVEEDOR == 1089 || PROVEEDOR == 1073))
                {
                    if (MessageBox.Show("¿CONFIRMA CARGAR DOS FACTURAS CON EL NRO " + NUM_FACTURA + "?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        RES = false;
                    }
                    else
                    {
                        RES = true;
                    }
                }
            }

            return RES;
        }

        private void buscarFactura(string ACCION)
        {
            string PROVEEDOR = tbBuscarFactura.Text.Trim();
            string NUMERO = "";
            string TIPO_DE_BUSQUEDA = cbTipoBusqueda.SelectedValue.ToString();
            string FECHA = dpFechaListado.Text;
            string[] FECHA_SPLIT = FECHA.Split('/');
            FECHA = FECHA_SPLIT[1] + "/" + FECHA_SPLIT[0] + "/" + FECHA_SPLIT[2];
            string FECHA_HASTA = dpFechaListadoHasta.Text;
            string[] FECHA_SPLIT_HASTA = FECHA_HASTA.Split('/');
            FECHA_HASTA = FECHA_SPLIT_HASTA[1] + "/" + FECHA_SPLIT_HASTA[0] + "/" + FECHA_SPLIT_HASTA[2];
            string SECTOR = cbSectorBusqueda.SelectedValue.ToString();
            string CUIT = tbCuitBusqueda.Text.Trim();
            string OP = tbOpBusqueda.Text.Trim();
            lbTipoBusqueda.Text = TIPO_DE_BUSQUEDA;

            if (TIPO_DE_BUSQUEDA == "2" || TIPO_DE_BUSQUEDA == "9" || TIPO_DE_BUSQUEDA == "12")
                NUMERO = tbBuscarNumeroSolicitud.Text.Trim();
            else
                NUMERO = tbBuscarNumeroFactura.Text.Trim();

            if (NUMERO == "-")
                NUMERO = "";
            
            buscar(PROVEEDOR, NUMERO, TIPO_DE_BUSQUEDA, FECHA, SECTOR, CUIT, OP, ACCION, FECHA_HASTA);
        }

        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            buscarFactura("BUSCAR");
        }

        private void llenarDatosSeleccionados()
        {
            LBIDDATO.Text = lvFacturas.SelectedItems[0].SubItems[0].Text;
            LBTIPODATO.Text = cbTipoBusqueda.Text;
            LBPROVEEDORDATO.Text = lvFacturas.SelectedItems[0].SubItems[1].Text;
            LBNUMERODATO.Text = lvFacturas.SelectedItems[0].SubItems[2].Text;
            LBFECHADATO.Text = lvFacturas.SelectedItems[0].SubItems[3].Text;
            LBIMPORTEDATO.Text = lvFacturas.SelectedItems[0].SubItems[4].Text;
            LBOBSERVACDATO.Text = lvFacturas.SelectedItems[0].SubItems[5].Text;
            LBSECTORDATO.Text = lvFacturas.SelectedItems[0].SubItems[6].Text;
        }
        
        private void mostrarResultadosFactura(FbDataReader reader)
        {
            lvFacturas.Items.Clear();
            lvFacturas.Columns.Clear();
            lvFacturas.BeginUpdate();

            if (lvFacturas.Columns.Count == 0)
            {
                lvFacturas.Columns.Add("#");
                lvFacturas.Columns.Add("PROVEEDOR");
                lvFacturas.Columns.Add("NUMERO");
                lvFacturas.Columns.Add("FECHA");
                lvFacturas.Columns.Add("IMPORTE");
                lvFacturas.Columns.Add("OBSERVACIONES");
                lvFacturas.Columns.Add("SECTOR");
                lvFacturas.Columns.Add("OP");
                lvFacturas.Columns.Add("TIPO");
                lvFacturas.Columns.Add("CUIT");
                lvFacturas.Columns.Add("TC");
                lvFacturas.Columns.Add("DES%");
                lvFacturas.Columns.Add("ANULADA");
                lvFacturas.Columns.Add("OP_ANULADA");
            }
            do
            {
                decimal IMPORTE = reader.GetDecimal(reader.GetOrdinal("IMPORTE"));
                string VALOR = string.Format("{0:n}", IMPORTE);
                DateTime FECHA = reader.GetDateTime(reader.GetOrdinal("FECHA"));
                DateTime OP_ANULADA;
                string RAZON_SOCIAL = "";

                if(reader.GetString(reader.GetOrdinal("ACREEDOR_DIVERSO")).Trim() != "")
                {
                    RAZON_SOCIAL = reader.GetString(reader.GetOrdinal("RAZON_SOCIAL")).Trim() + " (" + reader.GetString(reader.GetOrdinal("ACREEDOR_DIVERSO")).Trim() + ")";
                }
                else
                {
                    RAZON_SOCIAL = reader.GetString(reader.GetOrdinal("RAZON_SOCIAL")).Trim();
                }

                if (reader.GetString(reader.GetOrdinal("OP_ANULADA")) != "")
                { 
                   // OP_ANULADA = reader.GetString(reader.GetOrdinal("ANULADO")).
                }

                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("ID")).Trim());
                listItem.SubItems.Add(RAZON_SOCIAL);
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NUM_FACTURA")).Trim());
                listItem.SubItems.Add(FECHA.ToShortDateString());
                listItem.SubItems.Add(VALOR);
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("OBSERVACIONES")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("SECTOR")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ORDEN_DE_PAGO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TIPO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("CUIT")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TC")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("DESCUENTO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ANULADO")).Trim());
                lvFacturas.Items.Add(listItem);
            }

            while (reader.Read());
            lvFacturas.EndUpdate();
            lvFacturas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvFacturas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        static void OpenAdobeAcrobat(string f)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "ACROBAT.EXE";
                startInfo.Arguments = f;
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnVerAdjunto_Click(object sender, EventArgs e)
        {
            string ID = lvFacturas.SelectedItems[0].SubItems[0].Text;
            string ARCHIVO = "\\\\192.168.1.6\\ComprasPDF\\" + ID + ".PDF";

            if (File.Exists(ARCHIVO))
            {
                OpenAdobeAcrobat(ARCHIVO);
            }
            else
            {
                MessageBox.Show("NO SE ENCONTRO EL ARCHIVO ADJUNTO");
            }
        }

        private void guardarTemporalAdjunto(FbDataReader reader, string ABRIR)
        {
            Byte[] ADJUNTO = new Byte[0];
            ADJUNTO = (Byte[])reader.GetValue(reader.GetOrdinal("ADJUNTO"));
            File.WriteAllBytes(@"C:\CSPFA_SOCIOS\TEMP_FACTURA.PDF", ADJUNTO);

            if (ABRIR == "SI")
            {
                OpenAdobeAcrobat(@"C:\CSPFA_SOCIOS\TEMP_FACTURA.PDF");
            }
        }

        private void buscar(string PROVEEDOR, string NUMERO, string TIPO_DE_BUSQUEDA, string FECHA, string SECTOR, string CUIT, string OP, string ACCION, string FECHA_HASTA)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                conString cs = new conString();
                string connectionString = cs.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string QUERY = "";

                    switch (ACCION)
                    {
                        case "BUSCAR":
                        QUERY += "SELECT F.ID, F.PROVEEDOR, F.NUM_FACTURA, F.FECHA, F.IMPORTE, F.OBSERVACIONES, F.FE_ALTA, F.US_ALTA, F.FE_MOD, ";
                        QUERY += "F.US_MOD, P.RAZON_SOCIAL, F.SECTOR, F.ORDEN_DE_PAGO, F.NRO_REMITO, F.RETENCION, T.TIPO, P.CUIT, F.TIPO AS TC, F.DESCUENTO, F.ANULADO, F.OP_ANULADA, F.ACREEDOR_DIVERSO ";
                        break;

                        case "EXCEL":
                        QUERY += "SELECT F.FE_ALTA, P.RAZON_SOCIAL, F.NUM_FACTURA, F.FECHA, F.IMPORTE, F.OBSERVACIONES, F.SECTOR, F.ORDEN_DE_PAGO, F.NRO_REMITO, ";
                        QUERY += "F.RETENCION, T.TIPO, P.CUIT, F.DESCUENTO, F.ANULADO, F.OP_ANULADA, F.ACREEDOR_DIVERSO ";
                        break;
                    }

                    QUERY += "FROM FACTURAS F, PROVEEDORES P, TIPOS_CARGA_COMPROBANTE T ";
                    QUERY += "WHERE 1 = 1 ";
                            
                    if (PROVEEDOR != "")
                        QUERY += "AND (P.RAZON_SOCIAL LIKE '%' || RTRIM (LTRIM ('" + PROVEEDOR + "')) || '%') ";

                    if (NUMERO != "")
                        QUERY += "AND F.NUM_FACTURA = TRIM('" + NUMERO + "') ";

                    if (TIPO_DE_BUSQUEDA != "13")
                        QUERY += "AND F.TIPO = '" + TIPO_DE_BUSQUEDA + "' ";

                    if (cbFecha.Checked == true && cbFechaHasta.Checked == false)
                        QUERY += "AND F.FE_ALTA = '" + FECHA + "' ";

                    if (cbFecha.Checked == true && cbFechaHasta.Checked == true)
                        QUERY += "AND F.FE_ALTA BETWEEN '" + FECHA + "' AND '" + FECHA_HASTA + "' ";

                    if (chSectores.Checked == true)
                        QUERY += "AND F.SECTOR = '" + SECTOR + "' ";

                    if (CUIT != "")
                        QUERY += "AND P.CUIT = '" + CUIT + "' ";

                    if (OP != "")
                        QUERY += "AND F.ORDEN_DE_PAGO = '" + OP + "' ";

                    QUERY += "AND P.ID = F.PROVEEDOR AND F.TIPO = T.ID ORDER BY F.FE_ALTA DESC";

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
                            switch (ACCION)
                            {
                                case "BUSCAR":
                                    mostrarResultadosFactura(reader);
                                    break;

                                case "EXCEL":
                                    generarExcel(ds);
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        reader.Close();
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

            Cursor = Cursors.Default;
        }

        private void buscarParaListado(string FECHA)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();

            try
            {
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
                    string busco = "SELECT * FROM FACTURAS WHERE FECHA_ALTA ;";
                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        mostrarResultadosFactura(reader);
                    }
                    else
                    {
                        MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                MessageBox.Show(ex.ToString());
            }
        }

        private void btAgregarArticulo_Click(object sender, EventArgs e)
        {
            if (gbFacturas.Visible == true)
            {
                agregarModificarFactura("AGREGAR", 0, sender);
            }
            else
            {
                agregarModificarArticulo("AGREGAR", 0, sender);
            }
        }

        private void agregarModificarFactura(string ACCION, int FACTURA_DEUDA, object sender)
        {
            if (mbNumeroFactura.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO NÚMERO DE FACTURA", "ERROR");
                mbNumeroFactura.Focus();
            }
            else if (tbImporteFactura.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO IMPORTE", "ERROR");
                tbImporteFactura.Focus();
            }
            else
            {
                btAgregarArticulo.Enabled = false;
                btnModArt.Enabled = false;
                decimal IMPORTE_FACTURA_HIJA = decimal.Parse(tbImporteFactura.Text);
                int ID_PROVEEDOR_FACTURA_HIJA = int.Parse(cbProveedorFactura.SelectedValue.ToString());
                string PROVEEDOR_FACTURA_HIJA = cbProveedorFactura.Text;
                string NRO_FACTURA_HIJA = mbNumeroFactura.Text;
                int ID_TIPO_FACTURA_HIJA = int.Parse(cbTipoFactura.SelectedValue.ToString());
                string TIPO_FACTURA_HIJA = cbTipoFactura.Text;
                string FECHA_FACTURA_HIJA = dpDiaFactura.Text;
                string NUM_FACTURA_HIJA = mbNumeroFactura.Text.Trim();
                string OBS_FACTURA_HIJA = "";
                DateTime Hoy = DateTime.Today;
                string FE_ALTA_FACTURA_HIJA = Hoy.ToString("dd/MM/yyyy");
                string US_ALTA_FACTURA_HIJA = VGlobales.vp_username;
                string SECTOR_FACTURA_HIJA = cbSectores.SelectedValue.ToString();
                int ORDEN_DE_PAGO_FACTURA_HIJA = 0;
                string SEC_GRAL_FACTURA_HIJA = tbNumSecGral.Text.Trim();

                if (lbID.Text == "ID_FACTURA")
                {
                    MessageBox.Show("GUARDAR LA RENDICION ANTES DE AGREGAR UNA FACTURA", "ERROR");
                    btAgregarArticulo.Enabled = true;
                    btnModArt.Enabled = true;
                }
                else
                {
                    int ID_FACTURA_MADRE = int.Parse(lbID.Text);
                    int DESCUENTO_FACTURA_HIJA = 0;
                    string TIPO_DESC_FACTURA_HIJA = "";
                    string ACREEDOR_DIVERSO = tbAcreedorFactura.Text.Trim();

                    try
                    {
                        if (lbID.Text != "ID_FACTURA") //GRABA EN BASE DE DATOS
                        {
                            if (ACCION == "AGREGAR")
                            {
                                if (sumaFacturaHija(sender, ID_ARTICULO) == false)
                                {
                                    MessageBox.Show("LA SUMA DE LAS FACTURAS NO COINCIDE CON EL TOTAL DE LA RENDICION", "ERROR");
                                    btAgregarArticulo.Enabled = true;
                                    btnModArt.Enabled = true;
                                }
                                else if (check_ad_factura(NRO_FACTURA_HIJA, ACREEDOR_DIVERSO))
                                {
                                    MessageBox.Show("EL NRO DE FACTURA INGRESADO YA EXISTE PARA ESTE PROVEEDOR", "ERROR");
                                    btAgregarArticulo.Enabled = true;
                                    btnModArt.Enabled = true;
                                }
                                else
                                {
                                    Cursor = Cursors.WaitCursor;
                                    BO_COMPRAS.nuevaFactura(ID_PROVEEDOR_FACTURA_HIJA, NUM_FACTURA_HIJA, FECHA_FACTURA_HIJA, IMPORTE_FACTURA_HIJA,
                                    OBS_FACTURA_HIJA, FE_ALTA_FACTURA_HIJA, US_ALTA_FACTURA_HIJA, SECTOR_FACTURA_HIJA, SEC_GRAL_FACTURA_HIJA,
                                    ID_TIPO_FACTURA_HIJA, ORDEN_DE_PAGO_FACTURA_HIJA, 0, 0, ID_FACTURA_MADRE, DESCUENTO_FACTURA_HIJA, TIPO_DESC_FACTURA_HIJA, "0", 
                                    S_AJUSTE, ACREEDOR_DIVERSO);
                                    Cursor = Cursors.Default;

                                    BuscarFacturasHijas(ID_FACTURA_MADRE);
                                }
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO " + ACCION + " LA FACTURA HIJA\n" + error, "ERROR");
                        btAgregarArticulo.Enabled = true;
                        btnModArt.Enabled = true;
                    }
                }
            }
        }

        private void agregarArticuloSolicitud()
        { 
        
        }

        private void agregarModificarArticulo(string ACCION, int ID_ARTICULO, object sender)
        {
            /*if (tbImporte.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO IMPORTE", "ERROR");
                tbImporte.Focus();
            }
            else*/ if (tbCantidad.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO CANTIDAD", "ERROR");
                tbCantidad.Focus();
            }
            else if (tbDetalle.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO DETALLE", "ERROR");
                tbDetalle.Focus();
            }
            else if (tbValor.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO VALOR", "ERROR");
                tbValor.Focus();
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                btAgregarArticulo.Enabled = false;
                btnModArt.Enabled = false;
                decimal importe = Convert.ToDecimal(tbCantidad.Text) * Convert.ToDecimal(tbValor.Text);
                decimal valor = Convert.ToDecimal(tbValor.Text);
                string descuento = "";
                decimal CANTIDAD = Convert.ToDecimal(tbCantidad.Text.Trim());
                string DETALLE = tbDetalle.Text.Trim();
                string NSERIE = tbSerie.Text.Trim();
                int TIPO = int.Parse(cbTipoArticulo.SelectedValue.ToString());
                
                if (tbDescuento.Text != "" && cbDescuento.Text == "%")
                {
                    descuento = tbDescuento.Text + cbDescuento.Text;
                    decimal aDescontar = Convert.ToDecimal(tbValor.Text) * Convert.ToDecimal(tbDescuento.Text) / 100;
                    decimal valorConDescuento = Convert.ToDecimal(tbValor.Text) - aDescontar;
                    importe = valorConDescuento * Convert.ToDecimal(tbCantidad.Text.Trim());
                    importe = decimal.Round(importe, 2);
                }

                if (tbDescuento.Text != "" && cbDescuento.Text == "$")
                {
                    descuento = cbDescuento.Text + tbDescuento.Text;
                    decimal aDescontar = Convert.ToDecimal(tbDescuento.Text);
                    decimal valorConDescuento = Convert.ToDecimal(tbValor.Text) - aDescontar;
                    importe = valorConDescuento * Convert.ToDecimal(tbCantidad.Text.Trim());
                    importe = decimal.Round(importe, 2);
                }

                string VALOR_S = string.Format("{0:n}", valor);
                string IMPORTE_S = string.Format("{0:n}", importe);

                try
                {
                    if (lbID.Text != "ID_FACTURA") //GRABA EN BASE DE DATOS
                    {
                        if (ACCION == "AGREGAR")
                        {
                            if (suma(sender, ID_ARTICULO) == false)
                            {
                                MessageBox.Show("LA SUMA DE LOS ARTICULOS NO COINCIDE CON EL TOTAL DE LA FACTURA", "ERROR");
                                btAgregarArticulo.Enabled = true;
                                btnModArt.Enabled = true;
                            }
                            else
                            {
                                BO_COMPRAS.nuevoArticulo(int.Parse(lbID.Text), DETALLE, valor, CANTIDAD, NSERIE, TIPO, descuento);
                                limpiarArticulo();
                            }
                        }

                        if (ACCION == "MODIFICAR")
                        {
                            if (suma(sender, ID_ARTICULO) == false)
                            {
                                MessageBox.Show("LA SUMA DE LOS ARTICULOS NO COINCIDE CON EL TOTAL DE LA FACTURA", "ERROR");
                                btAgregarArticulo.Enabled = true;
                                btnModArt.Enabled = true;
                            }
                            else
                            {
                                BO_COMPRAS.modificarArticulos(ID_ARTICULO, DETALLE, valor, CANTIDAD, NSERIE, TIPO, descuento);
                                limpiarArticulo();
                            }
                        }
                    }
                    else //GRABA EN DATAGRID
                    {
                        if (ACCION == "AGREGAR")
                        {
                            if (suma(sender, ID_ARTICULO) == false)
                            {
                                MessageBox.Show("LA SUMA DE LOS ARTICULOS NO COINCIDE CON EL TOTAL DE LA FACTURA", "ERROR");
                                btAgregarArticulo.Enabled = true;
                                btnModArt.Enabled = true;
                            }
                            else
                            {
                                dgArticulos.Rows.Add(CANTIDAD, DETALLE, VALOR_S, descuento, IMPORTE_S, "", cbTipoArticulo.Text.ToString(), cbTipoArticulo.SelectedValue);
                                limpiarArticulo();
                            }
                        }

                        if (ACCION == "MODIFICAR")
                        {
                            if (suma(sender, ID_ARTICULO) == false)
                            {
                                MessageBox.Show("LA SUMA DE LOS ARTICULOS NO COINCIDE CON EL TOTAL DE LA FACTURA", "ERROR");
                                btAgregarArticulo.Enabled = true;
                                btnModArt.Enabled = true;
                            }
                            else
                            {
                                dgArticulos.Rows[int.Parse(lbIndex.Text)].SetValues(CANTIDAD, DETALLE, VALOR_S, descuento, IMPORTE_S, "", cbTipoArticulo.Text.ToString(), cbTipoArticulo.SelectedValue);
                                limpiarArticulo();
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO " + ACCION + " EL ARTICULO\n" + error, "ERROR");
                    btAgregarArticulo.Enabled = true;
                    btnModArt.Enabled = true;
                }

                if (lbID.Text != "ID_FACTURA")
                {
                    buscarArticulos(int.Parse(lbID.Text));
                }

                btAgregarArticulo.Enabled = true;
                btnModArt.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnCancelarFactura_Click(object sender, EventArgs e)
        {
            btnModFactura.Visible = false;
            btnGuardarFactura.Enabled = true;
            limpiarFactura();
            limpiarNotaCreditoDebito();
        }

        private void limpiarNotaCreditoDebito()
        {
            tbNumNota.Text = "";
            tbImporteNota.Text = "";
            tbObsNota.Text = "";
            dpFechaNota.Text = DateTime.Today.ToShortDateString();
            rbNinguna.Checked = true;
            lbNotaAdjunto.Text = "ARCHIVO PDF NO CARGADO";
        }

        private void limpiarRemito()
        {
            tbNumRemito.Text = "";
            tbImporteRemito.Text = "";
            tbObsRemito.Text = "";
            dpFechaRemito.Text = DateTime.Today.ToShortDateString();
            lbPdfRemito.Text = "ARCHIVO PDF NO CARGADO";
        }

        private void limpiarReciboOficial()
        {
            tbNumRecibo.Text = "";
            tbImporteRecibo.Text = "";
            tbObsRecibo.Text = "";
            dpFechaRecibo.Text = DateTime.Today.ToShortDateString();
            lbAdjuntoRecibo.Text = "ARCHIVO PDF NO CARGADO";
        }

        private void llenarDatosFactura(int ID)
        {
            if (lvFacturas.SelectedItems[0].SubItems[7].Text != "0")
            {
                //bloquearGrupos();
            }
            else
            {
                //desbloquearGrupos();
            }

            if (lvFacturas.SelectedItems.Count == 1)
            {
                Cursor = Cursors.WaitCursor;
                lbID.Text = ID.ToString();
                buscarAdjuntos(ID);
                //limpiarFactura();
                buscarFactura(ID);
                buscarArticulos(ID);
                llenarDatosSeleccionados();
                Cursor = Cursors.Default;
            }
        }

        private void mostrarArticulos(DataSet ds)
        {
            dgArticulos.Rows.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string ART_ID = row[0].ToString().Trim();
                string DETALLE = row[1].ToString().Trim();
                decimal IMPORTE_ART = Convert.ToDecimal(row[2]) * Convert.ToInt16(row[3]);
                string VALOR_ART = string.Format("{0:n}", IMPORTE_ART);
                decimal IMPORTE_UNI = Convert.ToDecimal(row[2]);
                string VALOR_UNI = string.Format("{0:n}", IMPORTE_UNI);
                string CANTIDAD = row[3].ToString().Trim();
                string NSERIE = row[4].ToString().Trim();
                string TIPO_ID = row[5].ToString().Trim();
                string DESCUENTO = row[6].ToString().Trim();
                string TIPO_DETALLE = row[7].ToString().Trim();
                
                dgArticulos.Rows.Add(CANTIDAD, DETALLE, VALOR_UNI, DESCUENTO, VALOR_ART, NSERIE, TIPO_DETALLE, TIPO_ID, ART_ID);
            }
        }

        private void mostrarFacturasHijas(DataSet ds)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string ID_FACTURA = row[0].ToString().Trim();
                string ID_PROVEEDOR = row[1].ToString().Trim();
                string NUM_FACTURA = row[2].ToString().Trim();
                string FECHA = row[3].ToString().Trim().Substring(0, 10);
                string IMPORTE = string.Format("{0:n}", Convert.ToDecimal(row[4].ToString().Trim()));
                string ID_TIPO = row[5].ToString().Trim();
                string TIPO = row[6].ToString().Trim();
                string RAZON_SOCIAL = row[7].ToString().Trim();

                dgFacturasHijas.Rows.Add(RAZON_SOCIAL, NUM_FACTURA, TIPO, IMPORTE, FECHA, ID_TIPO, ID_PROVEEDOR, ID_FACTURA);
            }
        }

        private void BuscarFacturasHijas(int FACTURA)
        {
            try
            {
                conString cs = new conString();
                string connectionString = cs.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string QUERY = "SELECT F.ID, F.PROVEEDOR AS ID_PROVEEDOR, F.NUM_FACTURA, F.FECHA, F.IMPORTE, F.TIPO AS ID_TIPO, T.TIPO, P.RAZON_SOCIAL ";
                    QUERY += "FROM FACTURAS F, PROVEEDORES P, TIPOS_CARGA_COMPROBANTE T ";
                    QUERY += "WHERE F.DEUDA = " + FACTURA + " AND F.PROVEEDOR = P.ID AND F.TIPO = T.ID ORDER BY F.ID";
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);
                    dgFacturasHijas.Rows.Clear();

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mostrarFacturasHijas(ds);
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

        private void buscarArticulos(int FACTURA)
        {
            try
            {
                conString cs = new conString();
                string connectionString = cs.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string query = "SELECT A.ID, A.DETALLE, A.VALOR, A.CANTIDAD, A.NSERIE, A.TIPO, A.DESCUENTO, ";
                    query += "COALESCE(T.DETALLE, 'SIN ESPECIFICAR') AS TIPO FROM ARTICULOS A LEFT JOIN TIPOS_ARTICULOS T "; 
                    query += "ON T.ID = A.TIPO  WHERE A.ID_FACTURA = " + FACTURA + " AND A.FE_BAJA IS NULL ORDER BY A.ID ASC;";
                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mostrarArticulos(ds);
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

        private void buscarFactura(int CONDICION)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();

            try
            {
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
                    string query = "SELECT * FROM FACTURAS WHERE ID = " + CONDICION;
                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mostrarFactura(ds);
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

        private void buscarAdjuntos(int ID)
        {
            lvAdjuntos.Clear();
            string RUTA = @"\\192.168.1.6\compraspdf\";

            if (Directory.Exists(RUTA))
            {
                DirectoryInfo directory = new DirectoryInfo(RUTA);
                FileInfo[] files = directory.GetFiles("*.PDF");

                string[] TIPO = { "X", "X" };
                string FECHA = "";
                string ARCHIVO = "";
                string NUMERO = "";
                string[] FILE = { "X", "X" };
                char SEP = '_';
                string ID_ARCHIVO = "";

                if (lvAdjuntos.Columns.Count == 0)
                {
                    lvAdjuntos.Columns.Add("ARCHIVO");
                    lvAdjuntos.Columns.Add("TIPO");
                }

                for (int i = 0; i < files.Length; i++)
                {
                    ARCHIVO = files[i].Name.ToString();
                    FILE = ARCHIVO.Split(SEP);
                    ID_ARCHIVO = FILE[1].Replace(".PDF", "");

                    if (ID_ARCHIVO == ID.ToString())
                    {
                        TIPO = ARCHIVO.Split(SEP);
                        string TIPO_FINAL = TIPO[0];

                        if (TIPO_FINAL == "CREDITO")
                            TIPO_FINAL = "NOTA DE CRÉDITO";

                        if (TIPO_FINAL == "DEBITO")
                            TIPO_FINAL = "NOTA DE DÉBITO";

                        FECHA = File.GetLastWriteTime(ARCHIVO).ToString();
                        ListViewItem items = new ListViewItem(ARCHIVO);
                        items.SubItems.Add(TIPO_FINAL);
                        lvAdjuntos.Items.Add(items);
                    }
                }

                lvAdjuntos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvAdjuntos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            else
            {
                if (lvAdjuntos.Columns.Count == 0)
                {
                    lvAdjuntos.Columns.Add("ERROR");
                }

                lvAdjuntos.Items.Add("NO SE ENCONTRO LA UBICACION DE RED");
                lvAdjuntos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvAdjuntos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void mostrarFactura(DataSet ds)
        {
            dgArticulos.Rows.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string TIPO_DE_COMPROBANTE = row[14].ToString();

                if (TIPO_DE_COMPROBANTE != "2" && TIPO_DE_COMPROBANTE != "9" && TIPO_DE_COMPROBANTE != "12")
                    comboProveedores(cbProveedores);
                else
                    comboAnticipos();

                cbProveedores.SelectedValue = row[1];
                dpFechaFactura.Text = row[3].ToString();
                decimal IMPORTE = Convert.ToDecimal(row[4].ToString().Trim());
                string VALOR = string.Format("{0:n}", IMPORTE);
                IMPORTE_TOTAL = IMPORTE;
                tbImporte.Text = VALOR;
                tbObservaciones.Text = row[5].ToString().Trim();
                cbSectores.SelectedValue = row[10].ToString().Trim();
                tbNumSecGral.Text = row[13].ToString().Trim();
                cbTipoComprobante.SelectedValue = row[14];
                tbAcreedor.Text = row[25].ToString().Trim();

                if (row[18].ToString() == "")
                    tbDescuentoTotal.Text = "0";
                else
                    tbDescuentoTotal.Text = row[18].ToString();
                

                if (TIPO_DE_COMPROBANTE != "2" && TIPO_DE_COMPROBANTE != "9" && TIPO_DE_COMPROBANTE != "12")
                {
                    tbNumFactura.Enabled = true;
                    lbNumFactura.Enabled = true;
                    lbNumSolicitud.Enabled = false;
                    tbNumSolicitud.Text = "";
                    tbNumFactura.Text = row[2].ToString().Trim();
                }
                else
                {
                    tbNumFactura.Enabled = false;
                    lbNumFactura.Enabled = false;
                    lbNumSolicitud.Enabled = true;
                    tbNumSolicitud.Text = row[2].ToString();
                    tbNumFactura.Text = "";
                }

                /*if (lbTipoBusqueda.Text == "1")
                {
                    decimal IMPORTE_ART = Convert.ToDecimal(row[12]) * Convert.ToInt16(row[10]);
                    string VALOR_ART = string.Format("{0:n}", IMPORTE_ART);
                    decimal IMPORTE_UNI = Convert.ToDecimal(row[12]);
                    string VALOR_UNI = string.Format("{0:n}", IMPORTE_UNI);
                    string CANTIDAD = row[10].ToString().Trim();
                    string DETALLE = row[11].ToString().Trim();
                    string DESCUENTO = row[17].ToString().Trim();
                    string NSERIE = row[13].ToString().Trim();
                    string TIPO_ID = row[14].ToString().Trim();
                    string TIPO_DETALLE = row[15].ToString().Trim();
                    string ART_ID = row[16].ToString().Trim();
                    dgArticulos.Rows.Add(CANTIDAD, DETALLE, VALOR_UNI, DESCUENTO, VALOR_ART, NSERIE, TIPO_DETALLE, TIPO_ID, ART_ID);
                }*/
            }
        }

        private void btnModArt_Click(object sender, EventArgs e)
        {
            if (gbFacturas.Visible == true)
            {
                agregarModificarFactura("MODIFICAR", 0, sender);
            }
            else
            {
                agregarModificarArticulo("MODIFICAR", ID_ARTICULO, sender);
            }
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF (*.PDF)|*.PDF|" + "All files (*.*)|*.*";
            ofd.Title = "Seleccionar Archivo";
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                lbArchivoAdjunto.Text = ofd.FileName;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llenarLvOp()
        {
            lvOP.BeginUpdate();

            if (lvOP.Columns.Count == 0)
            {
                lvOP.Columns.Add("#");
                lvOP.Columns.Add("PROVEEDOR");
                lvOP.Columns.Add("FACTURA");
                lvOP.Columns.Add("FECHA");
                lvOP.Columns.Add("IMPORTE");
            }

            foreach (ListViewItem itemRow in lvFacturas.SelectedItems)
            {
                ListViewItem listItem = new ListViewItem(itemRow.SubItems[0].Text);            
                listItem.SubItems.Add(itemRow.SubItems[1].Text);
                listItem.SubItems.Add(itemRow.SubItems[2].Text);
                listItem.SubItems.Add(itemRow.SubItems[3].Text);
                listItem.SubItems.Add(itemRow.SubItems[4].Text);
                lvOP.Items.Add(listItem);
                itemRow.Remove();
            }
            
            lvOP.EndUpdate();
            lvOP.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvOP.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private decimal sumarFacturasOP()
        {
            decimal TOTAL = 0;
            
            foreach (ListViewItem itemRow in lvOP.Items)
            {
                TOTAL = TOTAL + Convert.ToDecimal(itemRow.SubItems[4].Text);
            }

            return TOTAL;
        }

        private bool checkOrdenDePago()
        {
            int COUNT = 0;

            foreach (ListViewItem itemRows in lvFacturas.SelectedItems)
            {
                if (itemRows.SubItems[7].Text != "0")
                {
                    COUNT++;
                }
            }

            if (COUNT > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void totalImporteFacturasOP()
        {
            decimal total = 0;

            foreach (ListViewItem itemRow in lvOP.Items)
            {
                total += Convert.ToDecimal(itemRow.SubItems[4].Text);
            }

            lbTotalFacturasOP.Text = total.ToString();
        }

        private void sumaCheques()
        {
            decimal total = 0;

            foreach (ListViewItem itemRow in lvChequesSeleccionados.Items)
            {
                total += Convert.ToDecimal(itemRow.SubItems[4].Text);
            }

            lbTotalCheques.Text = total.ToString();
        }

        private void sumaTransferencias()
        {
            decimal total = 0;

            foreach (ListViewItem itemRow in lvTransSeleccionadas.Items)
            {
                total += Convert.ToDecimal(itemRow.SubItems[9].Text);
            }

            lbTotalTransferencias.Text = total.ToString();
        }

        private void btnGuardarOP_Click(object sender, EventArgs e)
        {
            if (lvOP.Items.Count == 0)
            {
                MessageBox.Show("NO SE SELECCIONO NINGUNA FACTURA", "ERROR");
            }
            else if (lvChequesSeleccionados.Items.Count == 0 && lvTransSeleccionadas.Items.Count == 0)
            {
                MessageBox.Show("NO SE CARGO NINGUN CHEQUE NI TRANSFERENCIA", "ERROR");
            }
            else if (sumarTotales() == false)
            {
                MessageBox.Show("EL IMPORTE DE LAS FACTURAS SELECCIONADAS NO HA SIDO CUBIERTO", "ERROR");
            }
            else if (cbBenefOpe.Text == "")
            {
                MessageBox.Show("SELECCIONAR UN BENEFICIARIO PARA LA ORDEN DE PAGO", "ERROR");
            }
            else
            {
                if (MessageBox.Show("¿CONFIRMA GUARDAR LA ORDEN DE PAGO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    btnGuardarOP.Enabled = false;

                    try
                    {
                        maxid mid = new maxid();
                        string FECHA = DateTime.Now.ToShortDateString();
                        string OBSERVACIONES = tbObservacionesOP.Text.Trim();
                        string BENEFICIARIO_OP = cbBenefOpe.Text.Trim().ToUpper();
                        decimal TOTAL = Convert.ToDecimal(lbTotalCheques.Text) + Convert.ToDecimal(lbTotalTransferencias.Text) ;
                        string US_ALTA = VGlobales.vp_username;
                        string FECHA_OP = fechaOP.Text;
                        BO_COMPRAS.nuevaOrdenDePago(FECHA, OBSERVACIONES, TOTAL, BENEFICIARIO_OP, 0, US_ALTA, FECHA_OP);
                        int ID_OP = int.Parse(mid.m("ID", "ORDENES_DE_PAGO"));

                        foreach (ListViewItem itemRow in lvOP.Items)
                        {
                            int ID_FACTURA = int.Parse(itemRow.SubItems[0].Text);
                            BO_COMPRAS.opEnFactura(ID_FACTURA, ID_OP);
                            BO_COMPRAS.facturaXop(ID_OP, ID_FACTURA);
                        }

                        if (lvChequesSeleccionados.Items.Count > 0)
                        {
                            foreach (ListViewItem itemRow in lvChequesSeleccionados.Items)
                            {
                                int CHEQUE = int.Parse(itemRow.SubItems[1].Text);
                                decimal IMPORTE = Convert.ToDecimal(itemRow.SubItems[4].Text);
                                string FECHA_CHEQUE = itemRow.SubItems[5].Text;
                                string ESTADO = "EN CARTERA";
                                string VENCIMIENTO = itemRow.SubItems[3].Text;
                                string BENEFICIARIO_CHEQUE = itemRow.SubItems[6].Text.ToUpper();
                                BO_COMPRAS.modificaCheque(CHEQUE, ID_OP, IMPORTE, FECHA_CHEQUE, ESTADO, VENCIMIENTO, BENEFICIARIO_CHEQUE);
                            }
                        }

                        if (lvTransSeleccionadas.Items.Count > 0)
                        {
                            foreach (ListViewItem itemRow in lvTransSeleccionadas.Items)
                            {
                                int BANCO_ORIGEN = int.Parse(itemRow.SubItems[0].Text);
                                int CUENTA_ORIGEN = int.Parse(itemRow.SubItems[3].Text);
                                int CHEQUE;
                                if (itemRow.SubItems[8].Text != "")
                                    CHEQUE = int.Parse(itemRow.SubItems[8].Text);
                                else
                                    CHEQUE = 0;
                                int PROVEEDOR_TRANS = int.Parse(itemRow.SubItems[11].Text);
                                int CUENTA_DESTINO = int.Parse(itemRow.SubItems[7].Text);
                                decimal IMPORTE = decimal.Parse(itemRow.SubItems[9].Text);
                                string US_ALTA_TRANS = VGlobales.vp_username;
                                string FE_ALTA = DateTime.Today.ToShortDateString();
                                string FECHA_TRANS = dpFechaTransferencia.Text;
                                BO_COMPRAS.altaTransferencia(BANCO_ORIGEN, CUENTA_ORIGEN, CHEQUE, PROVEEDOR_TRANS, CUENTA_DESTINO, IMPORTE, US_ALTA_TRANS, FE_ALTA, FECHA_TRANS, ID_OP);
                            }

                            if (lbPdfTrans.Text != "ARCHIVO PDF NO CARGADO")
                            {
                                int ID_TRANS = int.Parse(mid.m("ID", "TRANSFERENCIAS"));
                                string ARCHIVO_ORIGEN = lbPdfTrans.Text;
                                string ARCHIVO_DESTINO = "\\\\192.168.1.6\\ComprasPDF\\TRANSFERENCIA_" + ID_OP + "_" + ID_TRANS + ".PDF";
                                File.Copy(ARCHIVO_ORIGEN, ARCHIVO_DESTINO);
                                lbPdfTrans.Text = "ARCHIVO PDF NO CARGADO";
                            }
                        }

                        
                        imprimirOrdenDePago(ID_OP);
                        DialogResult result = MessageBox.Show("ORDEN DE PAGO CREADA CORRECTAMENTE \n\n ¿ABRIR EL ARCHIVO?", "LISTO!", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            Process.Start(@"\\192.168.1.6\Tesoreria\ORDENES_DE_PAGO\OP - " + ID_OP.ToString() + ".PDF");
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO GENERAR LA ORDEN DE PAGO\n" + error, "ERROR");
                        Cursor = Cursors.Default;
                    }

                    limpiarOrdenDePago();
                    desbloquearTabPages();
                    bloquearGrupos();
                    eliminarCheques("TODOS");
                    buscarFactura("BUSCAR");
                    tabControl1.SelectedTab = tabPage1;
                    Cursor = Cursors.Default;
                }
            }
        }

        private void bloquearTabPages()
        {
            tabPage1.Enabled = false;
            tpProveedores.Enabled = false;
            tpBancosCuentasCheques.Enabled = false;
        }

        private void desbloquearTabPages()
        {
            tabPage1.Enabled = true;
            tpProveedores.Enabled = true;
            tpBancosCuentasCheques.Enabled = true;
        }

        private void obtenerOrdenDePago(int ID_OP)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();

            try
            {
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
                    string QUERY = "SELECT OBSERVACIONES, TOTAL, BENEFICIARIO FROM ORDENES_DE_PAGO WHERE ID = " + ID_OP;
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        OP = ds;
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

        private void obtenerCheques(int ID_OP)
        {
            string connectionString;
            string QUERY = string.Empty;
            Datos_ini ini2 = new Datos_ini();

            try
            {
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

                    if (ID_OP != 0)
                        QUERY = "SELECT C.NRO_CHEQUE, B.NOMBRE, C.IMPORTE FROM CHEQUES C, CHEQUES_ORDENES O, BANCOS B WHERE O.ORDEN = " + ID_OP + " AND O.CHEQUE = C.ID AND B.ID = C.ID_BANCO;";
                    else
                        QUERY = "SELECT C.NRO_CHEQUE, B.NOMBRE, C.IMPORTE, O.ID FROM CHEQUES C, CHEQUES_ORDENES O, BANCOS B WHERE E = C.ID AND B.ID = C.ID_BANCO;";

                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        CHEQUES = ds;
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

        private PdfPCell celda(PdfPCell CELL, BaseColor BACK_COLOR, BaseColor BORDER_COLOR, int H_ALIGN, float FIX_HEIGHT, PdfPTable TABLA)
        {
            CELL.BackgroundColor = BACK_COLOR;
            CELL.BorderColor = BORDER_COLOR;
            CELL.HorizontalAlignment = H_ALIGN;
            CELL.FixedHeight = FIX_HEIGHT;
            TABLA.AddCell(CELL);
            return CELL;
        }

        /*private void imprimirBusqueda(DataSet BUSQUEDA, string PATH)
        {
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _standardFontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _standardFontWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            iTextSharp.text.Font _standardFontBoldWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            iTextSharp.text.Font _mediumFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _mediumFontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _mediumFontWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            iTextSharp.text.Font _mediumFontBoldWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            BaseColor negro = new BaseColor(0, 0, 0);
            BaseColor gris = new BaseColor(230, 230, 230);
            BaseColor topo = new BaseColor(100, 100, 100);
            BaseColor blanco = new BaseColor(255, 255, 255);
            BaseColor colorFondo = new BaseColor(255, 255, 255);

            Document doc = new Document(PageSize.A4);
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(PATH, FileMode.Create));
            doc.AddTitle("LISTADO DE CHEQUES");
            doc.AddCreator("TESORERIA CSPFA");
            doc.Open();

            header(doc, _standardFontBold, writer, "LISTADO DE CHEQUES " + cbEstadosCheques.SelectedItem.ToString());
            doc.Add(Chunk.NEWLINE);

            
            PdfPTable TABLA_OPS = new PdfPTable(7);
            TABLA_OPS.WidthPercentage = 100;
            TABLA_OPS.SpacingAfter = 5;
            TABLA_OPS.SpacingBefore = 5;
            TABLA_OPS.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 1f });

            iTextSharp.text.Font font = _mediumFontWhite;

            PdfPCell FECHA = new PdfPCell(new Phrase("FECHA", font));
            doc.Add(celda(FECHA, topo, blanco, 1, 16f, TABLA_OPS));

            PdfPCell NRO_OP = new PdfPCell(new Phrase("NRO_OP", font));
            doc.Add(celda(NRO_OP, topo, blanco, 1, 16f, TABLA_OPS));

            PdfPCell ESTADO = new PdfPCell(new Phrase("ESTADO", font));
            doc.Add(celda(ESTADO, topo, blanco, 1, 16f, TABLA_OPS));

            PdfPCell NRO_CHEQUE = new PdfPCell(new Phrase("NRO_CHEQUE", font));
            doc.Add(celda(NRO_CHEQUE, topo, blanco, 1, 16f, TABLA_OPS));

            PdfPCell BANCO = new PdfPCell(new Phrase("BANCO", font));
            doc.Add(celda(BANCO, topo, blanco, 1, 16f, TABLA_OPS));

            PdfPCell OBSERVACIONES = new PdfPCell(new Phrase("OBSERVACIONES", font));
            doc.Add(celda(OBSERVACIONES, topo, blanco, 1, 16f, TABLA_OPS));

            PdfPCell TOTAL = new PdfPCell(new Phrase("TOTAL", font));
            doc.Add(celda(TOTAL, topo, blanco, 1, 16f, TABLA_OPS));

            foreach (DataRow row in BUSQUEDA.Tables[0].Rows)
            {
                string D_NRO_OP = row[0].ToString();
                string D_FECHA = row[1].ToString();
                string D_TOTAL = row[2].ToString();
                string D_NRO_CHEQUE = row[6].ToString();
                string D_BANCO = row[7].ToString();
                string D_ESTADO = row[8].ToString();
                string D_OBSERVACIONES = row[10].ToString();

                PdfPCell FECHA_D = new PdfPCell(new Phrase(D_FECHA, _mediumFont));
                doc.Add(celda(FECHA_D, blanco, blanco, 1, 16f, TABLA_OPS));

                PdfPCell NRO_OP_D = new PdfPCell(new Phrase(D_NRO_OP, _mediumFont));
                doc.Add(celda(NRO_OP_D, blanco, blanco, 1, 16f, TABLA_OPS));

                PdfPCell ESTADO_D = new PdfPCell(new Phrase(D_ESTADO, _mediumFont));
                doc.Add(celda(ESTADO_D, blanco, blanco, 1, 16f, TABLA_OPS));

                PdfPCell NRO_CHEQUE_D = new PdfPCell(new Phrase(D_NRO_CHEQUE, _mediumFont));
                doc.Add(celda(NRO_CHEQUE_D, blanco, blanco, 1, 16f, TABLA_OPS));

                PdfPCell BANCO_D = new PdfPCell(new Phrase(D_BANCO, _mediumFont));
                doc.Add(celda(BANCO_D, blanco, blanco, 1, 16f, TABLA_OPS));

                PdfPCell OBSERVACIONES_D = new PdfPCell(new Phrase(D_OBSERVACIONES, _mediumFont));
                doc.Add(celda(OBSERVACIONES_D, blanco, blanco, 1, 16f, TABLA_OPS));

                PdfPCell TOTAL_D = new PdfPCell(new Phrase(D_TOTAL, _mediumFont));
                doc.Add(celda(TOTAL_D, blanco, blanco, 1, 16f, TABLA_OPS));
            }

            doc.Add(TABLA_OPS);

            #endregion

            doc.Close();
            writer.Close();
        }*/

        private void header(Document doc, iTextSharp.text.Font FONT, PdfWriter writer, string PARAGRAPH)
        {
            Paragraph header = new Paragraph(PARAGRAPH, FONT);
            header.Alignment = Element.ALIGN_CENTER;
            header.SpacingAfter = 5;
            doc.Add(header);
        }

        private void imprimirOrdenDePago(int ID_OP)
        {
            string QUERY_OP = "SELECT * FROM ORDENES_DE_PAGO WHERE ID = " + ID_OP + ";";
            DataRow[] OP = dlog.BO_EjecutoDataTable(QUERY_OP).Select();
            string QUERY_FACTURAS = "SELECT F.NUM_FACTURA, P.RAZON_SOCIAL, F.FECHA, F.IMPORTE, F.OBSERVACIONES, F.SECTOR FROM FACTURAS F, PROVEEDORES P, FACTURAS_OP O WHERE P.ID = F.PROVEEDOR AND O.ID_OP = " + ID_OP + " AND F.ID = O.ID_FACTURA";
            DataRow[] FACTURAS = dlog.BO_EjecutoDataTable(QUERY_FACTURAS).Select();
            string QUERY_CHEQUES = "SELECT B.NOMBRE, C.SERIE, C.NRO_CHEQUE, C.IMPORTE, C.FECHA, C.TIPO, C.VENCIMIENTO, C.BENEFICIARIO FROM CHEQUERAS C, BANCOS B WHERE OP_ASIGNADA = " + ID_OP + " AND B.ID = C.BANCO;";
            DataRow[] CHEQUES = dlog.BO_EjecutoDataTable(QUERY_CHEQUES).Select();
            string QUERY_TRANSFERENCIAS = "SELECT C.CBU, P.RAZON_SOCIAL, T.IMPORTE FROM TRANSFERENCIAS T, PROVEEDORES P, CUENTAS_BANCARIAS C WHERE T.PROVEEDOR = P.ID AND C.ID = T.CUENTA_DESTINO AND T.OP = " + ID_OP;
            DataRow[] TRANSFERENCIAS = dlog.BO_EjecutoDataTable(QUERY_TRANSFERENCIAS).Select();

            string OBSERVACIONES = OP[0][2].ToString().Trim();
            decimal TOTAL = Convert.ToDecimal(OP[0][3]);
            string BENEFICIARIO = OP[0][4].ToString();
            DateTime FECHA = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            string FECHA_LARGA = FECHA.ToString("D", CultureInfo.CreateSpecificCulture("es-MX"));
            string TOTAL_OP = "$ " + string.Format("{0:n}", TOTAL);

            #region HEADER
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

            Document doc = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"\\192.168.1.6\Tesoreria\ORDENES_DE_PAGO\OP - " + ID_OP.ToString() + ".PDF", FileMode.Create));
            doc.AddTitle("ORDEN DE PAGO Nº " + ID_OP.ToString());
            doc.AddCreator("CSPFA");
            doc.Open();

            PdfPTable TABLA_HEADER = new PdfPTable(2);
            TABLA_HEADER.WidthPercentage = 100;
            TABLA_HEADER.SpacingAfter = 5;
            TABLA_HEADER.SetWidths(new float[] { 1f, 1f });

            PdfPCell CELDA_CSPFA = new PdfPCell(new Phrase("CÍRCULO DE SUBOFICIALES DE LA PFA", _standardFont));
            PdfPCell CELDA_OP = new PdfPCell(new Phrase("ORDEN DE PAGO Nº " + ID_OP.ToString(), _standardFont));

            CELDA_CSPFA.BackgroundColor = blanco;
            CELDA_CSPFA.BorderColor = blanco;
            CELDA_CSPFA.HorizontalAlignment = 0;
            CELDA_CSPFA.FixedHeight = 16f;

            CELDA_OP.BackgroundColor = blanco;
            CELDA_OP.BorderColor = blanco;
            CELDA_OP.HorizontalAlignment = 2;
            CELDA_OP.FixedHeight = 16f;

            TABLA_HEADER.AddCell(CELDA_CSPFA);
            TABLA_HEADER.AddCell(CELDA_OP);

            doc.Add(TABLA_HEADER);

            Paragraph P_FECHA = new Paragraph("Buenos Aires " + FECHA_LARGA, _mediumFont);
            P_FECHA.Alignment = Element.ALIGN_LEFT;
            P_FECHA.SpacingAfter = 5;
            doc.Add(P_FECHA);

            Paragraph P_PAGUESE = new Paragraph("Páguese por Tesorería los importes correspondientes a los comprobantes que se adjuntan", _mediumFont);
            P_PAGUESE.Alignment = Element.ALIGN_LEFT;
            P_PAGUESE.SpacingBefore = 5;
            doc.Add(P_PAGUESE);

            Paragraph P_BENEFICIARIO = new Paragraph("BENEFICIARIO: " + BENEFICIARIO, _mediumFont);
            P_BENEFICIARIO.Alignment = Element.ALIGN_LEFT;
            P_BENEFICIARIO.SpacingAfter = 5;
            doc.Add(P_BENEFICIARIO);
            #endregion

            #region TABLA FACTURAS
            PdfPTable TABLA_FACTURAS = new PdfPTable(5);
            TABLA_FACTURAS.WidthPercentage = 100;
            TABLA_FACTURAS.SpacingAfter = 5;
            TABLA_FACTURAS.SpacingBefore = 5;
            TABLA_FACTURAS.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f });

            PdfPCell CELDA_NRO_FACTURA = new PdfPCell(new Phrase("FACTURA Nº", _mediumFontBoldWhite));
            CELDA_NRO_FACTURA.BackgroundColor = topo;
            CELDA_NRO_FACTURA.BorderColor = blanco;
            CELDA_NRO_FACTURA.HorizontalAlignment = 1;
            CELDA_NRO_FACTURA.FixedHeight = 16f;
            TABLA_FACTURAS.AddCell(CELDA_NRO_FACTURA);

            PdfPCell CELDA_PROVEEDOR = new PdfPCell(new Phrase("PROVEEDOR", _mediumFontBoldWhite));
            CELDA_PROVEEDOR.BackgroundColor = topo;
            CELDA_PROVEEDOR.BorderColor = blanco;
            CELDA_PROVEEDOR.HorizontalAlignment = 1;
            CELDA_PROVEEDOR.FixedHeight = 16f;
            TABLA_FACTURAS.AddCell(CELDA_PROVEEDOR);

            PdfPCell CELDA_FECHA = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
            CELDA_FECHA.BackgroundColor = topo;
            CELDA_FECHA.BorderColor = blanco;
            CELDA_FECHA.HorizontalAlignment = 1;
            CELDA_FECHA.FixedHeight = 16f;
            TABLA_FACTURAS.AddCell(CELDA_FECHA);

            PdfPCell CELDA_SECTOR = new PdfPCell(new Phrase("SECTOR", _mediumFontBoldWhite));
            CELDA_SECTOR.BackgroundColor = topo;
            CELDA_SECTOR.BorderColor = blanco;
            CELDA_SECTOR.HorizontalAlignment = 1;
            CELDA_SECTOR.FixedHeight = 16f;
            TABLA_FACTURAS.AddCell(CELDA_SECTOR);

            PdfPCell CELDA_IMPORTE = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
            CELDA_IMPORTE.BackgroundColor = topo;
            CELDA_IMPORTE.BorderColor = blanco;
            CELDA_IMPORTE.HorizontalAlignment = 1;
            CELDA_IMPORTE.FixedHeight = 16f;
            TABLA_FACTURAS.AddCell(CELDA_IMPORTE);

            for (int i = 0; i <= FACTURAS.Length - 1; i ++)
            {
                string NRO_FACTURA = FACTURAS[i][0].ToString().Trim();
                string PROVEEDOR = FACTURAS[i][1].ToString().Trim();
                string FECHA_FACTURA = Convert.ToDateTime(FACTURAS[i][2]).ToShortDateString();
                string IMPORTE = "$ " + string.Format("{0:n}", FACTURAS[i][3]).ToString();
                string OBS_FACTURA = FACTURAS[i][4].ToString().Trim();
                string SECTOR = FACTURAS[i][5].ToString().Trim();

                PdfPCell DATO_NRO_FACTURA = new PdfPCell(new Phrase(NRO_FACTURA, _mediumFont));
                DATO_NRO_FACTURA.BackgroundColor = blanco;
                DATO_NRO_FACTURA.BorderColor = blanco;
                DATO_NRO_FACTURA.HorizontalAlignment = 1;
                TABLA_FACTURAS.AddCell(DATO_NRO_FACTURA);

                PdfPCell DATO_PROVEEDOR = new PdfPCell(new Phrase(PROVEEDOR, _mediumFont));
                DATO_PROVEEDOR.BackgroundColor = blanco;
                DATO_PROVEEDOR.BorderColor = blanco;
                DATO_PROVEEDOR.HorizontalAlignment = 1;
                TABLA_FACTURAS.AddCell(DATO_PROVEEDOR);

                PdfPCell DATO_FECHA = new PdfPCell(new Phrase(FECHA_FACTURA, _mediumFont));
                DATO_FECHA.BackgroundColor = blanco;
                DATO_FECHA.BorderColor = blanco;
                DATO_FECHA.HorizontalAlignment = 1;
                TABLA_FACTURAS.AddCell(DATO_FECHA);

                PdfPCell DATO_SECTOR = new PdfPCell(new Phrase(SECTOR, _mediumFont));
                DATO_SECTOR.BackgroundColor = blanco;
                DATO_SECTOR.BorderColor = blanco;
                DATO_SECTOR.HorizontalAlignment = 1;
                TABLA_FACTURAS.AddCell(DATO_SECTOR);

                PdfPCell DATO_IMPORTE = new PdfPCell(new Phrase(IMPORTE, _mediumFont));
                DATO_IMPORTE.BackgroundColor = blanco;
                DATO_IMPORTE.BorderColor = blanco;
                DATO_IMPORTE.HorizontalAlignment = 1;
                TABLA_FACTURAS.AddCell(DATO_IMPORTE);
            }

            doc.Add(TABLA_FACTURAS);

            #endregion

            #region TABLA CHEQUES
            if (CHEQUES.Length > 0)
            {
                PdfPTable TABLA_CHEQUES = new PdfPTable(7);
                TABLA_CHEQUES.WidthPercentage = 100;
                TABLA_CHEQUES.SpacingAfter = 5;
                TABLA_CHEQUES.SpacingBefore = 5;
                TABLA_CHEQUES.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 1f });

                PdfPCell CELDA_BANCO = new PdfPCell(new Phrase("BANCO", _mediumFontBoldWhite));
                CELDA_BANCO.BackgroundColor = topo;
                CELDA_BANCO.BorderColor = blanco;
                CELDA_BANCO.HorizontalAlignment = 1;
                CELDA_BANCO.FixedHeight = 16f;
                TABLA_CHEQUES.AddCell(CELDA_BANCO);

                PdfPCell CELDA_SERIE = new PdfPCell(new Phrase("SERIE", _mediumFontBoldWhite));
                CELDA_SERIE.BackgroundColor = topo;
                CELDA_SERIE.BorderColor = blanco;
                CELDA_SERIE.HorizontalAlignment = 1;
                CELDA_SERIE.FixedHeight = 16f;
                TABLA_CHEQUES.AddCell(CELDA_SERIE);

                PdfPCell CELDA_NRO_CHEQUE = new PdfPCell(new Phrase("CHEQUE", _mediumFontBoldWhite));
                CELDA_NRO_CHEQUE.BackgroundColor = topo;
                CELDA_NRO_CHEQUE.BorderColor = blanco;
                CELDA_NRO_CHEQUE.HorizontalAlignment = 1;
                CELDA_NRO_CHEQUE.FixedHeight = 16f;
                TABLA_CHEQUES.AddCell(CELDA_NRO_CHEQUE);

                PdfPCell CELDA_IMPORTE_CHEQUE = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                CELDA_IMPORTE_CHEQUE.BackgroundColor = topo;
                CELDA_IMPORTE_CHEQUE.BorderColor = blanco;
                CELDA_IMPORTE_CHEQUE.HorizontalAlignment = 1;
                CELDA_IMPORTE_CHEQUE.FixedHeight = 16f;
                TABLA_CHEQUES.AddCell(CELDA_IMPORTE_CHEQUE);

                PdfPCell CELDA_FECHA_CHEQUE = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
                CELDA_FECHA_CHEQUE.BackgroundColor = topo;
                CELDA_FECHA_CHEQUE.BorderColor = blanco;
                CELDA_FECHA_CHEQUE.HorizontalAlignment = 1;
                CELDA_FECHA_CHEQUE.FixedHeight = 16f;
                TABLA_CHEQUES.AddCell(CELDA_FECHA_CHEQUE);

                PdfPCell CELDA_FECHA_TIPO = new PdfPCell(new Phrase("TIPO", _mediumFontBoldWhite));
                CELDA_FECHA_TIPO.BackgroundColor = topo;
                CELDA_FECHA_TIPO.BorderColor = blanco;
                CELDA_FECHA_TIPO.HorizontalAlignment = 1;
                CELDA_FECHA_TIPO.FixedHeight = 16f;
                TABLA_CHEQUES.AddCell(CELDA_FECHA_TIPO);

                PdfPCell CELDA_VENCIMIENTO = new PdfPCell(new Phrase("VENCIMIENTO", _mediumFontBoldWhite));
                CELDA_VENCIMIENTO.BackgroundColor = topo;
                CELDA_VENCIMIENTO.BorderColor = blanco;
                CELDA_VENCIMIENTO.HorizontalAlignment = 1;
                CELDA_VENCIMIENTO.FixedHeight = 16f;
                TABLA_CHEQUES.AddCell(CELDA_VENCIMIENTO);

                for (int i = 0; i <= CHEQUES.Length - 1; i++)
                {
                    string BANCO = CHEQUES[i][0].ToString();
                    string SERIE = CHEQUES[i][1].ToString();
                    string NRO_CHEQUE = CHEQUES[i][2].ToString();
                    string IMPORTE = "$ " + string.Format("{0:n}", CHEQUES[i][3]).ToString();
                    string FECHA_CHEQUE = Convert.ToDateTime(CHEQUES[i][4]).ToShortDateString();
                    string TIPO = CHEQUES[i][5].ToString();
                    string VENCIMIENTO = CHEQUES[i][6].ToString();
                    string BENEF_CHEQUE = CHEQUES[i][7].ToString();

                    PdfPCell DATO_BANCO = new PdfPCell(new Phrase(BANCO, _mediumFont));
                    DATO_BANCO.BackgroundColor = blanco;
                    DATO_BANCO.BorderColor = blanco;
                    DATO_BANCO.HorizontalAlignment = 1;
                    TABLA_CHEQUES.AddCell(DATO_BANCO);

                    PdfPCell DATO_SERIE = new PdfPCell(new Phrase(SERIE, _mediumFont));
                    DATO_SERIE.BackgroundColor = blanco;
                    DATO_SERIE.BorderColor = blanco;
                    DATO_SERIE.HorizontalAlignment = 1;
                    TABLA_CHEQUES.AddCell(DATO_SERIE);

                    PdfPCell DATO_NRO_CHEQUE = new PdfPCell(new Phrase(NRO_CHEQUE, _mediumFont));
                    DATO_NRO_CHEQUE.BackgroundColor = blanco;
                    DATO_NRO_CHEQUE.BorderColor = blanco;
                    DATO_NRO_CHEQUE.HorizontalAlignment = 1;
                    TABLA_CHEQUES.AddCell(DATO_NRO_CHEQUE);

                    PdfPCell DATO_IMPORTE = new PdfPCell(new Phrase(IMPORTE, _mediumFont));
                    DATO_IMPORTE.BackgroundColor = blanco;
                    DATO_IMPORTE.BorderColor = blanco;
                    DATO_IMPORTE.HorizontalAlignment = 1;
                    TABLA_CHEQUES.AddCell(DATO_IMPORTE);

                    PdfPCell DATO_FECHA_CHEQUE = new PdfPCell(new Phrase(FECHA_CHEQUE, _mediumFont));
                    DATO_FECHA_CHEQUE.BackgroundColor = blanco;
                    DATO_FECHA_CHEQUE.BorderColor = blanco;
                    DATO_FECHA_CHEQUE.HorizontalAlignment = 1;
                    TABLA_CHEQUES.AddCell(DATO_FECHA_CHEQUE);

                    PdfPCell DATO_TIPO = new PdfPCell(new Phrase(TIPO, _mediumFont));
                    DATO_TIPO.BackgroundColor = blanco;
                    DATO_TIPO.BorderColor = blanco;
                    DATO_TIPO.HorizontalAlignment = 1;
                    TABLA_CHEQUES.AddCell(DATO_TIPO);

                    PdfPCell DATO_VENCIMIENTO = new PdfPCell(new Phrase(VENCIMIENTO, _mediumFont));
                    DATO_VENCIMIENTO.BackgroundColor = blanco;
                    DATO_VENCIMIENTO.BorderColor = blanco;
                    DATO_VENCIMIENTO.HorizontalAlignment = 1;
                    TABLA_CHEQUES.AddCell(DATO_VENCIMIENTO);
                }

                doc.Add(TABLA_CHEQUES);
            }
            #endregion

            #region TABLA TRANSFERENCIAS
            if (TRANSFERENCIAS.Length > 0)
            {
                PdfPTable TABLA_TRANSFERENCIAS = new PdfPTable(3);
                TABLA_TRANSFERENCIAS.WidthPercentage = 100;
                TABLA_TRANSFERENCIAS.SpacingAfter = 5;
                TABLA_TRANSFERENCIAS.SpacingBefore = 5;
                TABLA_TRANSFERENCIAS.SetWidths(new float[] { 1f, 1f, 1f });

                PdfPCell CELDA_CBU = new PdfPCell(new Phrase("CBU", _mediumFontBoldWhite));
                CELDA_CBU.BackgroundColor = topo;
                CELDA_CBU.BorderColor = blanco;
                CELDA_CBU.HorizontalAlignment = 1;
                CELDA_CBU.FixedHeight = 16f;
                TABLA_TRANSFERENCIAS.AddCell(CELDA_CBU);

                PdfPCell CELDA_PROVEEDOR_T = new PdfPCell(new Phrase("PROVEEDOR", _mediumFontBoldWhite));
                CELDA_PROVEEDOR_T.BackgroundColor = topo;
                CELDA_PROVEEDOR_T.BorderColor = blanco;
                CELDA_PROVEEDOR_T.HorizontalAlignment = 1;
                CELDA_PROVEEDOR_T.FixedHeight = 16f;
                TABLA_TRANSFERENCIAS.AddCell(CELDA_PROVEEDOR_T);

                PdfPCell CELDA_IMPORTE_T = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                CELDA_IMPORTE_T.BackgroundColor = topo;
                CELDA_IMPORTE_T.BorderColor = blanco;
                CELDA_IMPORTE_T.HorizontalAlignment = 1;
                CELDA_IMPORTE_T.FixedHeight = 16f;
                TABLA_TRANSFERENCIAS.AddCell(CELDA_IMPORTE_T);

                for (int i = 0; i <= TRANSFERENCIAS.Length - 1; i++)
                {
                    string CBU = TRANSFERENCIAS[i][0].ToString();
                    string PROVEEDOR = TRANSFERENCIAS[i][1].ToString();
                    string IMPORTE = "$ " + string.Format("{0:n}", TRANSFERENCIAS[i][2]).ToString();

                    PdfPCell DATO_CBU = new PdfPCell(new Phrase(CBU, _mediumFont));
                    DATO_CBU.BackgroundColor = blanco;
                    DATO_CBU.BorderColor = blanco;
                    DATO_CBU.HorizontalAlignment = 1;
                    TABLA_TRANSFERENCIAS.AddCell(DATO_CBU);

                    PdfPCell DATO_PROVEEDOR = new PdfPCell(new Phrase(PROVEEDOR, _mediumFont));
                    DATO_PROVEEDOR.BackgroundColor = blanco;
                    DATO_PROVEEDOR.BorderColor = blanco;
                    DATO_PROVEEDOR.HorizontalAlignment = 1;
                    TABLA_TRANSFERENCIAS.AddCell(DATO_PROVEEDOR);

                    PdfPCell DATO_IMPORTE = new PdfPCell(new Phrase(IMPORTE, _mediumFont));
                    DATO_IMPORTE.BackgroundColor = blanco;
                    DATO_IMPORTE.BorderColor = blanco;
                    DATO_IMPORTE.HorizontalAlignment = 1;
                    TABLA_TRANSFERENCIAS.AddCell(DATO_IMPORTE);

                }

                doc.Add(TABLA_TRANSFERENCIAS);
            }
            #endregion

            #region TABLA TOTAL OP
            PdfPTable TABLA_TOTAL_OP = new PdfPTable(1);
            TABLA_TOTAL_OP.WidthPercentage = 100;
            TABLA_TOTAL_OP.SpacingAfter = 5;
            TABLA_TOTAL_OP.SetWidths(new float[] { 1f });

            PdfPCell CELDA_IMPORTE_TOTAL_OP = new PdfPCell(new Phrase("TOTAL: " + TOTAL_OP, _mediumFontBoldWhite));
            CELDA_IMPORTE_TOTAL_OP.BackgroundColor = topo;
            CELDA_IMPORTE_TOTAL_OP.BorderColor = blanco;
            CELDA_IMPORTE_TOTAL_OP.HorizontalAlignment = 2;
            CELDA_IMPORTE_TOTAL_OP.FixedHeight = 16f;
            TABLA_TOTAL_OP.AddCell(CELDA_IMPORTE_TOTAL_OP);

            doc.Add(TABLA_TOTAL_OP);
            #endregion

            #region TABLA FIRMAS

            PdfPTable TABLA_FIRMA_BENEFICIARIO = new PdfPTable(2);
            TABLA_FIRMA_BENEFICIARIO.WidthPercentage = 100;
            TABLA_FIRMA_BENEFICIARIO.SpacingBefore = 65;
            TABLA_FIRMA_BENEFICIARIO.SetWidths(new float[] { 3f, 1f });

            PdfPCell CELDA_RECIBI = new PdfPCell(new Phrase("Recibí de conformidad el pago con los valores detallados precedentemente", _mediumFont));
            CELDA_RECIBI.BackgroundColor = blanco;
            CELDA_RECIBI.BorderColor = blanco;
            CELDA_RECIBI.HorizontalAlignment = 0;
            TABLA_FIRMA_BENEFICIARIO.AddCell(CELDA_RECIBI);

            PdfPCell CELDA_LINEA_FIRMA_RECIBI = new PdfPCell(new Phrase("__________________________", _mediumFont));
            CELDA_LINEA_FIRMA_RECIBI.BackgroundColor = blanco;
            CELDA_LINEA_FIRMA_RECIBI.BorderColor = blanco;
            CELDA_LINEA_FIRMA_RECIBI.HorizontalAlignment = 2;
            TABLA_FIRMA_BENEFICIARIO.AddCell(CELDA_LINEA_FIRMA_RECIBI);

            PdfPCell CELDA_VACIA = new PdfPCell(new Phrase(" ", _mediumFont));
            CELDA_VACIA.BackgroundColor = blanco;
            CELDA_VACIA.BorderColor = blanco;
            CELDA_VACIA.HorizontalAlignment = 1;
            TABLA_FIRMA_BENEFICIARIO.AddCell(CELDA_VACIA);

            PdfPCell CELDA_FIRMA = new PdfPCell(new Phrase("Firma del Beneficiario  ", _mediumFont));
            CELDA_FIRMA.BackgroundColor = blanco;
            CELDA_FIRMA.BorderColor = blanco;
            CELDA_FIRMA.HorizontalAlignment = 2;
            TABLA_FIRMA_BENEFICIARIO.AddCell(CELDA_FIRMA);

            doc.Add(TABLA_FIRMA_BENEFICIARIO);

            PdfPTable TABLA_FIRMAS = new PdfPTable(3);
            TABLA_FIRMAS.WidthPercentage = 100;
            TABLA_FIRMAS.SpacingBefore = 65;
            TABLA_FIRMAS.SetWidths(new float[] { 1f, 1f, 1f });

            PdfPCell CELDA_LINEA_TAVARES = new PdfPCell(new Phrase("_______________________________", _mediumFont));
            CELDA_LINEA_TAVARES.BackgroundColor = blanco;
            CELDA_LINEA_TAVARES.BorderColor = blanco;
            CELDA_LINEA_TAVARES.HorizontalAlignment = 1;
            CELDA_LINEA_TAVARES.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_LINEA_TAVARES);

            PdfPCell CELDA_LINEA_HERNANDEZ = new PdfPCell(new Phrase("_______________________________", _mediumFont));
            CELDA_LINEA_HERNANDEZ.BackgroundColor = blanco;
            CELDA_LINEA_HERNANDEZ.BorderColor = blanco;
            CELDA_LINEA_HERNANDEZ.HorizontalAlignment = 1;
            CELDA_LINEA_HERNANDEZ.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_LINEA_HERNANDEZ);

            PdfPCell CELDA_LINEA_VISCONTI = new PdfPCell(new Phrase("_______________________________", _mediumFont));
            CELDA_LINEA_VISCONTI.BackgroundColor = blanco;
            CELDA_LINEA_VISCONTI.BorderColor = blanco;
            CELDA_LINEA_VISCONTI.HorizontalAlignment = 1;
            CELDA_LINEA_VISCONTI.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_LINEA_VISCONTI);

            PdfPCell CELDA_TAVARES = new PdfPCell(new Phrase("Miguel Ángel TAVARES", _mediumFont));
            CELDA_TAVARES.BackgroundColor = blanco;
            CELDA_TAVARES.BorderColor = blanco;
            CELDA_TAVARES.HorizontalAlignment = 1;
            CELDA_TAVARES.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_TAVARES);

            PdfPCell CELDA_HERNANDEZ = new PdfPCell(new Phrase("Carlos Aníbal HERNANDEZ", _mediumFont));
            CELDA_HERNANDEZ.BackgroundColor = blanco;
            CELDA_HERNANDEZ.BorderColor = blanco;
            CELDA_HERNANDEZ.HorizontalAlignment = 1;
            CELDA_HERNANDEZ.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_HERNANDEZ);

            PdfPCell CELDA_VISCONTI = new PdfPCell(new Phrase("Eliseo Aníbal VISCONTI", _mediumFont));
            CELDA_VISCONTI.BackgroundColor = blanco;
            CELDA_VISCONTI.BorderColor = blanco;
            CELDA_VISCONTI.HorizontalAlignment = 1;
            CELDA_VISCONTI.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_VISCONTI);


            PdfPCell CELDA_SECRETARIO = new PdfPCell(new Phrase("SECRETARIO GENERAL", _mediumFont));
            CELDA_SECRETARIO.BackgroundColor = blanco;
            CELDA_SECRETARIO.BorderColor = blanco;
            CELDA_SECRETARIO.HorizontalAlignment = 1;
            CELDA_SECRETARIO.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_SECRETARIO);

            PdfPCell CELDA_TESORERO = new PdfPCell(new Phrase("TESORERO", _mediumFont));
            CELDA_TESORERO.BackgroundColor = blanco;
            CELDA_TESORERO.BorderColor = blanco;
            CELDA_TESORERO.HorizontalAlignment = 1;
            CELDA_TESORERO.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_TESORERO);

            PdfPCell CELDA_PRESIDENTE = new PdfPCell(new Phrase("PRESIDENTE", _mediumFont));
            CELDA_PRESIDENTE.BackgroundColor = blanco;
            CELDA_PRESIDENTE.BorderColor = blanco;
            CELDA_PRESIDENTE.HorizontalAlignment = 1;
            CELDA_PRESIDENTE.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_PRESIDENTE);


            doc.Add(TABLA_FIRMAS);

            #endregion

            Paragraph P_PROCEDIO = new Paragraph("Se procedió al pago ordenado precedentemente", _mediumFont);
            P_PROCEDIO.Alignment = Element.ALIGN_LEFT;
            P_PROCEDIO.SpacingBefore = 25;
            doc.Add(P_PROCEDIO);

            Paragraph P_CREV = new Paragraph("VERIFICACIÓN COMISIÓN REVISORA DE CUENTAS", _mediumFont);
            P_CREV.Alignment = Element.ALIGN_LEFT;
            P_CREV.SpacingBefore = 15;
            doc.Add(P_CREV);

            Paragraph P_LINEA_CREV = new Paragraph("____________________________________________________________________________________________________________", _mediumFont);
            P_LINEA_CREV.Alignment = Element.ALIGN_LEFT;
            P_LINEA_CREV.SpacingBefore = 15;
            doc.Add(P_LINEA_CREV);

            Paragraph P_OBSERVACIONES = new Paragraph("OBSERVACIONES: " + OBSERVACIONES, _mediumFont);
            P_OBSERVACIONES.Alignment = Element.ALIGN_LEFT;
            P_OBSERVACIONES.SpacingBefore = 15;
            doc.Add(P_OBSERVACIONES);

            doc.Close();
            writer.Close();
        }

        private void limpiarOrdenDePago()
        {
            lvOP.Clear();
            lvTransSeleccionadas.Clear();
            tbImporteOP.Text = "";
            lbTotalFacturasOP.Text = "0";
            lbTotalCheques.Text = "0";
            lbTotalTransferencias.Text = "0";
            tbObservacionesOP.Text = "";
            cbBeneficiarioOP.SelectedItem = 0;
            cbBenefOpe.SelectedItem = 0;
            cbBancos.SelectedItem = 0;
        }

        private void limpiarTransferencia()
        { 
            comboBancos(cbBancoOrigenTrans);
            cbCtaOrigenTrans.DataSource = null;
            cbCtaOrigenTrans.Items.Clear();
            cbCtaOrigenTrans.Enabled = false;
            cbChequeAcompTrans.DataSource = null;
            cbChequeAcompTrans.Items.Clear();
            cbChequeAcompTrans.Enabled = false;
            cbCuentaDestinoTrans.DataSource = null;
            cbCuentaDestinoTrans.Items.Clear();
            cbCuentaDestinoTrans.Enabled = false;
            tbProvTrans.Text = "";
            tbImporteTrans.Text = "";
            dpFechaTransferencia.Text = DateTime.Today.ToShortDateString();
        }

        private void eliminarCheques(string CUALES)
        {
            string CHEQUE = "";
            string BANCO_ID = "";

            if (CUALES == "SELECCIONADOS")
            {
                foreach (ListViewItem itemRow in lvChequesSeleccionados.SelectedItems)
                {
                    CHEQUE = itemRow.SubItems[1].Text;
                    BANCO_ID = itemRow.SubItems[7].Text;
                    BO_COMPRAS.chequeOpTemp(0, int.Parse(CHEQUE), int.Parse(BANCO_ID));
                    itemRow.Remove();
                }
            }

            if (CUALES == "TODOS")
            {
                foreach (ListViewItem itemRow in lvChequesSeleccionados.Items)
                {
                    CHEQUE = itemRow.SubItems[1].Text;
                    BANCO_ID = itemRow.SubItems[7].Text;
                    BO_COMPRAS.chequeOpTemp(0, int.Parse(CHEQUE), int.Parse(BANCO_ID));
                    itemRow.Remove();
                }
            }
            
            sumaCheques();
            int BANCO = int.Parse(cbBancos.SelectedValue.ToString());
            comboCheques(BANCO, cbCheques);
        }

        private void btnCancelarOP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA CANCELAR LA ORDEN DE PAGO?\nTODOS LOS DATOS INGRESADOS SE PERDERÁN", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                limpiarOrdenDePago();
                desbloquearTabPages();
                bloquearGrupos();
                eliminarCheques("TODOS");
                buscarFactura("BUSCAR");
                tabControl1.SelectedTab = tabPage1;
            }
        }

        private void comboBancos(ComboBox COMBO)
        {
            string query = "SELECT ID, NOMBRE FROM BANCOS WHERE FE_BAJA IS NULL ORDER BY NOMBRE";
            COMBO.DataSource = null;
            COMBO.Items.Clear();
            COMBO.DataSource = dlog.BO_EjecutoDataTable(query);
            COMBO.DisplayMember = "NOMBRE";
            COMBO.ValueMember = "ID";
            COMBO.SelectedItem = 0;
        }

        private void comboBeneficiarios()
        {
            string query = "SELECT DISTINCT(TRIM(BENEFICIARIO)) AS NOMBRE FROM ORDENES_DE_PAGO ORDER BY NOMBRE ASC;";
            cbBeneficiarioOP.DataSource = null;
            cbBeneficiarioOP.Items.Clear();
            cbBeneficiarioOP.DataSource = dlog.BO_EjecutoDataTable(query);
            cbBeneficiarioOP.DisplayMember = "NOMBRE";
            cbBeneficiarioOP.ValueMember = "NOMBRE";
            cbBeneficiarioOP.SelectedItem = 0;

            cbBenefCargaOp.DataSource = null;
            cbBenefCargaOp.Items.Clear();
            cbBenefCargaOp.DataSource = dlog.BO_EjecutoDataTable(query);
            cbBenefCargaOp.DisplayMember = "NOMBRE";
            cbBenefCargaOp.ValueMember = "NOMBRE";
            cbBenefCargaOp.SelectedItem = 0;

            cbBenefOpe.DataSource = null;
            cbBenefOpe.Items.Clear();
            cbBenefOpe.DataSource = dlog.BO_EjecutoDataTable(query);
            cbBenefOpe.DisplayMember = "NOMBRE";
            cbBenefOpe.ValueMember = "NOMBRE";
            cbBenefOpe.SelectedItem = 0;
        }

        private void comboTipoCuentasBancarias()
        {
            string query = "SELECT ID, TIPO FROM TIPO_CUENTA_BANCARIA ORDER BY ID ASC;";
            cbTipoCuenta.DataSource = null;
            cbTipoCuenta.Items.Clear();
            cbTipoCuenta.DataSource = dlog.BO_EjecutoDataTable(query);
            cbTipoCuenta.DisplayMember = "TIPO";
            cbTipoCuenta.ValueMember = "ID";
            cbTipoCuenta.SelectedIndex = -1;
        }

        private void comboCuentasBancariasCargadas(int BANCO, ComboBox COMBO)
        {
            string query = "SELECT ID, NRO_CUENTA FROM CUENTAS_BANCARIAS WHERE FE_BAJA IS NULL AND BANCO = " + BANCO + " ORDER BY NRO_CUENTA";//"  AND PROVEEDOR = 99999999 ORDER BY NRO_CUENTA;";
            COMBO.DataSource = null;
            COMBO.Items.Clear();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                COMBO.DataSource = dlog.BO_EjecutoDataTable(query);
                COMBO.DisplayMember = "NRO_CUENTA";
                COMBO.ValueMember = "ID";
                COMBO.SelectedIndex = 0;
                COMBO.Enabled = true;
            }
            else
            {
                COMBO.Enabled = false;
            }
        }

        private void comboBancosChequeras()
        {
            string query = "SELECT ID, NOMBRE FROM BANCOS WHERE FE_BAJA IS NULL ORDER BY NOMBRE;";
            cbBancosChequeras.DataSource = null;
            cbBancosChequeras.Items.Clear();
            cbBancosChequeras.DataSource = dlog.BO_EjecutoDataTable(query);
            cbBancosChequeras.DisplayMember = "NOMBRE";
            cbBancosChequeras.ValueMember = "ID";
            cbBancosChequeras.SelectedItem = 0;

            cbModicarBanco.DataSource = null;
            cbModicarBanco.Items.Clear();
            cbModicarBanco.DataSource = dlog.BO_EjecutoDataTable(query);
            cbModicarBanco.DisplayMember = "NOMBRE";
            cbModicarBanco.ValueMember = "ID";
            cbModicarBanco.SelectedIndex = -1;

            cbBancosEnCuentas.DataSource = null;
            cbBancosEnCuentas.Items.Clear();
            cbBancosEnCuentas.DataSource = dlog.BO_EjecutoDataTable(query);
            cbBancosEnCuentas.DisplayMember = "NOMBRE";
            cbBancosEnCuentas.ValueMember = "ID";
            cbBancosEnCuentas.SelectedItem = -1;
        }

        private void comboCheques(int BANCO, ComboBox COMBO)
        {
            string QUERY = "SELECT NRO_CHEQUE FROM CHEQUERAS WHERE BANCO = " + BANCO + " AND OP_ASIGNADA IS NULL AND OP_TEMP = 0 ORDER BY NRO_CHEQUE ASC;";
            COMBO.Items.Clear();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                COMBO.Enabled = true;

                for (int i = 0; i <= foundRows.Length - 1; i++)
                {
                    COMBO.Items.Add(foundRows[i][0].ToString());
                }

                COMBO.SelectedIndex = 0;
            }
            else
            {
                COMBO.Enabled = false;
            }
        }

        private bool checkChequeras(int DESDE, int HASTA, int BANCO, string SERIE)
        {
            string QUERY = "SELECT COUNT(ID) FROM CHEQUERAS WHERE BANCO = " + BANCO + " AND SERIE = '" + SERIE + "' AND NRO_CHEQUE >= " + DESDE + " AND NRO_CHEQUE <= " + HASTA;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (int.Parse(foundRows[0][0].ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void bloquearGrupos()
        {
            /*grupoAltaFactura.Enabled = false;
            grupoArticulos.Enabled = false;
            grupoNotaDeCredito.Enabled = false;*/
        }

        private void desbloquearGrupos()
        {
           /*grupoAltaFactura.Enabled = true;
            grupoArticulos.Enabled = true;
            grupoNotaDeCredito.Enabled = true;*/
        }

        private bool checkFacturaEnOp(string ID_FACTURA)
        {
            int COUNT = 0;

            foreach (ListViewItem itemRows in lvOP.Items)
            {
                if (itemRows.SubItems[0].Text == ID_FACTURA)
                {
                    COUNT++;
                }
            }

            if (COUNT > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void btnAgregarAop_Click(object sender, EventArgs e)
        {
            string ID_FACTURA = lvFacturas.SelectedItems[0].SubItems[0].Text;
            bool OP = checkOrdenDePago();
            bool FACTURA_EN_OP = checkFacturaEnOp(ID_FACTURA);

            if (OP == true)
            {
                MessageBox.Show("ALGUNA DE LAS FACTURAS SELECCIONADAS YA POSEE UNA ORDEN DE PAGO", "ERROR");
            }
            else if (FACTURA_EN_OP == true)
            {
                MessageBox.Show("ALGUNA DE LAS FACTURAS SELECCIONADAS YA EXISTE EN LA ORDEN DE PAGO ABIERTA", "ERROR");
            }
            else
            {
                llenarLvOp();
                lvFacturas.SelectedItems[0].Remove();
            }
        }

        private void buscarOrdenDePago(int NRO_OP)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                conString cs = new conString();
                string connectionString = cs.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string QUERY = "SELECT ID, FECHA_OP, BENEFICIARIO, TOTAL, OBSERVACIONES, ANULA_FECHA, CANULA_FECHA, CANCELA_FECHA FROM ORDENES_DE_PAGO WHERE ID = " + NRO_OP;
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
                            mostrarOrdenesDePago(reader);
                        }
                        else
                        {
                            MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

            Cursor = Cursors.Default;
        }

        /*private void buscarOrdenDePago(string NRO_OP, string ESTADO, string BANCO)
        {
            string connectionString;
            string busco = "";
            string FACTURA = "N";
            Datos_ini ini2 = new Datos_ini();

            try
            {
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

                    busco += "SELECT O.ID AS NRO_OP, O.FECHA, O.TOTAL, C.BENEFICIARIO AS BENEF_OP, P.RAZON_SOCIAL, C.NRO_CHEQUE, B.NOMBRE AS BANCO, C.ESTADO, ";
                    busco += "O.BENEFICIARIO AS BENEF_CHEQUE, O.OBSERVACIONES, O.US_ALTA, B.ID, O.ANULA_FECHA, O.CANULA_FECHA, O.CANCELA_FECHA ";
                    busco += "FROM ORDENES_DE_PAGO O, PROVEEDORES P, BANCOS B ";
                    busco += "WHERE C.BANCO = B.ID ";

                    /*if (NRO_FACTURA != "")
                    {
                        busco = "SELECT O.ID AS NRO_OP, O.FECHA, O.TOTAL, C.BENEFICIARIO AS BENEF_OP, F.NUM_FACTURA, P.RAZON_SOCIAL, C.NRO_CHEQUE, B.NOMBRE AS BANCO, C.ESTADO, ";
                        busco += "O.BENEFICIARIO AS BENEF_CHEQUE, O.OBSERVACIONES, O.US_ALTA, B.ID, O.ANULA_FECHA, O.CANULA_FECHA, O.CANCELA_FECHA ";
                        busco += "FROM ORDENES_DE_PAGO O, CHEQUERAS C, FACTURAS F, PROVEEDORES P, FACTURAS_OP A, BANCOS B ";
                        busco += "WHERE P.ID = F.PROVEEDOR AND A.ID_FACTURA = F.ID AND A.ID_OP = O.ID AND C.BANCO = B.ID AND C.OP_ASIGNADA = O.ID ";
                        FACTURA = "S"; 
                    }
                    
                    if(chBancoOP.Checked == true)
                    {
                        busco += " AND C.BANCO = " + BANCO;
                    }
                    
                    if (NRO_OP != "")
                    {
                        busco += " AND O.ID = '" + NRO_OP + "' AND C.OP_ASIGNADA = '" + NRO_OP + "' ";
                    }

                    /*if (NRO_CHEQUE != "")
                    {
                        busco += "AND C.NRO_CHEQUE = '" + NRO_CHEQUE + "' ";
                    }

                    if (NRO_FACTURA != "")
                    {
                        busco += "AND F.NUM_FACTURA = '" + NRO_FACTURA + "' ";
                    }

                    if (PROVEEDOR != "")
                    {
                        busco += "AND (P.RAZON_SOCIAL LIKE '%' || '" + PROVEEDOR + "' || '%') ";
                    }

                    if (ESTADO != "TODOS")
                    {
                        busco += "AND C.ESTADO = '" + ESTADO + "'";
                    }

                    busco += " ORDER BY O.ID DESC;";

                    BUSCO_QUERY = busco;
                    //Clipboard.SetData(DataFormats.Text, (Object)BUSCO_QUERY);

                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        mostrarOrdenesDePago(reader, FACTURA);
                    }
                    else
                    {
                        MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                MessageBox.Show(ex.ToString());
            }
        }*/

        private void mostrarOrdenesDePago(FbDataReader OPS)
        {
            lvBuscarOP.Items.Clear();
            lvBuscarOP.Columns.Clear();
            lvBuscarOP.BeginUpdate();

            if (lvBuscarOP.Columns.Count == 0)
            {
                lvBuscarOP.Columns.Add("# OP");
                lvBuscarOP.Columns.Add("FECHA");
                lvBuscarOP.Columns.Add("BENEFICIARIO");
                lvBuscarOP.Columns.Add("IMPORTE");
                lvBuscarOP.Columns.Add("OBSERVACIONES");
                lvBuscarOP.Columns.Add("ANULADA");
                lvBuscarOP.Columns.Add("CONFIRMADA");
                lvBuscarOP.Columns.Add("CANCELADA");
            }
            do
            {
                string ID = OPS.GetString(OPS.GetOrdinal("ID")).Trim();
                string FECHA = OPS.GetString(OPS.GetOrdinal("FECHA_OP")).Trim().Substring(0, 10);
                string IMPORTE = string.Format("{0:n}", OPS.GetDecimal(OPS.GetOrdinal("TOTAL")));
                string BENEFICIARIO = OPS.GetString(OPS.GetOrdinal("BENEFICIARIO")).Trim();
                string OBSERVACIONES = OPS.GetString(OPS.GetOrdinal("OBSERVACIONES")).Trim();
                string ANULA_FECHA = "";
                string CANULA_FECHA = "";
                string CANCELA_FECHA = "";

                if (OPS.GetString(OPS.GetOrdinal("ANULA_FECHA")) != "")
                {
                    ANULA_FECHA = OPS.GetString(OPS.GetOrdinal("ANULA_FECHA")).Trim().Substring(0, 10);
                }

                if (OPS.GetString(OPS.GetOrdinal("CANULA_FECHA")) != "")
                {
                    CANULA_FECHA = OPS.GetString(OPS.GetOrdinal("CANULA_FECHA")).Trim().Substring(0, 10);
                }

                if (OPS.GetString(OPS.GetOrdinal("CANCELA_FECHA")) != "")
                {
                    CANCELA_FECHA = OPS.GetString(OPS.GetOrdinal("CANCELA_FECHA")).Trim().Substring(0, 10);
                }

                ListViewItem listItem = new ListViewItem(ID);
                listItem.SubItems.Add(FECHA);
                listItem.SubItems.Add(BENEFICIARIO);
                listItem.SubItems.Add(IMPORTE);
                listItem.SubItems.Add(OBSERVACIONES);
                listItem.SubItems.Add(ANULA_FECHA);
                listItem.SubItems.Add(CANULA_FECHA);
                listItem.SubItems.Add(CANCELA_FECHA);
                lvBuscarOP.Items.Add(listItem);
            }

            while (OPS.Read());
            lvBuscarOP.EndUpdate();
            lvBuscarOP.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvBuscarOP.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private decimal sumarBusqueda()
        {
            decimal TOTAL = 0;

            foreach (ListViewItem itemRow in lvBuscarOP.Items)
            {
                decimal IMPORTE = Convert.ToDecimal(itemRow.SubItems[3].Text);
                TOTAL = IMPORTE + TOTAL;
            }

            return TOTAL;
        }

        private void pintarOpAnulada() 
        {
            if (lvBuscarOP.Items.Count > 0)
            {
                foreach (ListViewItem row in lvBuscarOP.Items)
                {
                    if (row.SubItems[5].Text != "")
                    {
                        row.BackColor = Color.Orange;
                        row.ForeColor = Color.Black;
                    }
                    if (row.SubItems[6].Text != "")
                    {
                        row.BackColor = Color.Red;
                        row.ForeColor = Color.White;
                    }
                }
            }
        }

        private void ejecBuscarOP() 
        {
            if (tbBuscarOPxNum.Text != "")
            {
                int NRO_OP = int.Parse(tbBuscarOPxNum.Text);
                buscarOrdenDePago(NRO_OP);
                pintarOpAnulada();
                tbTotalBusqueda.Text = "TOTAL $ " + string.Format("{0:n}", sumarBusqueda());
            }
            else
            {
                MessageBox.Show("INGRESAR UN NUMERO DE OP", "ERROR!");
            }
        }

        private void btnBuscarOP_Click(object sender, EventArgs e)
        {
            ejecBuscarOP();
        }

        private void lvBuscarOP_MouseDown(object sender, MouseEventArgs e)
        {
            if(lvBuscarOP.SelectedItems.Count == 1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (lvBuscarOP.FocusedItem.Bounds.Contains(e.Location) == true)
                    {
                        cmEstadoOP.Show(Cursor.Position);
                    }
                }
            }
        }

        private void cambiarEstadoCheque(int CHEQUE, int BANCO, string ESTADO)
        {
            /*string NRO_OP = tbBuscarOPxNum.Text.Trim();
            
            try
            {
                BO_COMPRAS.cambiarEstadoDeCheque(CHEQUE, BANCO, ESTADO);
                ESTADO = cbEstadosCheques.Text;
                buscarOrdenDePago(NRO_OP, ESTADO, BANCO.ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }*/
        }

        private void enCalle_Click(object sender, EventArgs e)
        {
            int CHEQUE = int.Parse(lvBuscarOP.SelectedItems[0].SubItems[6].Text);
            int BANCO = int.Parse(lvBuscarOP.SelectedItems[0].SubItems[12].Text);
            string ESTADO = "EN CALLE";
            cambiarEstadoCheque(CHEQUE, BANCO, ESTADO);
        }

        private void btnLimpiarLvOP_Click(object sender, EventArgs e)
        {
            limpiarOp();            
        }

        private void limpiarOp()
        {
            lvBuscarOP.Clear();
            tbBuscarOPxNum.Text = "";
        }

        private void enCartera_Click(object sender, EventArgs e)
        {
            int CHEQUE = int.Parse(lvBuscarOP.SelectedItems[0].SubItems[6].Text);
            int BANCO = int.Parse(lvBuscarOP.SelectedItems[0].SubItems[12].Text);
            string ESTADO = "EN CARTERA";
            cambiarEstadoCheque(CHEQUE, BANCO, ESTADO);
        }

        private void cobrado_Click(object sender, EventArgs e)
        {
            int CHEQUE = int.Parse(lvBuscarOP.SelectedItems[0].SubItems[6].Text);
            int BANCO = int.Parse(lvBuscarOP.SelectedItems[0].SubItems[12].Text);
            string ESTADO = "COBRADO";
            cambiarEstadoCheque(CHEQUE, BANCO, ESTADO);
        }

        private void vERPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string OP = @"\\192.168.1.6\Tesoreria\ORDENES_DE_PAGO\OP - " + lvBuscarOP.SelectedItems[0].SubItems[0].Text + ".PDF";
                System.Diagnostics.Process.Start(OP);
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO ABRIR EL ARCHIVO PDF\n" + error.ToString() + "\n" + OP, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /*private void comboEstadosCheques()
        {
            cbEstadosCheques.Items.Add("TODOS");
            cbEstadosCheques.Items.Add("EN CARTERA");
            cbEstadosCheques.Items.Add("EN CALLE");
            cbEstadosCheques.Items.Add("COBRADO");
            cbEstadosCheques.SelectedIndex = 0;
        }*/

        private void comboTipoCheques()
        {
            cbTipoCheque.Items.Add("COMUN");
            cbTipoCheque.Items.Add("DIFERIDO");
            cbTipoCheque.SelectedIndex = 0;
        }

        private void imprimirCheque()
        {
            numerosAletras nal = new numerosAletras();
            DateTimeFormatInfo FORMATO_FECHA = CultureInfo.CurrentCulture.DateTimeFormat;
            string FECHA = lvBuscarOP.SelectedItems[0].SubItems[1].Text;
            string IMPORTE = lvBuscarOP.SelectedItems[0].SubItems[2].Text;
            string BENEFICIARIO = lvBuscarOP.SelectedItems[0].SubItems[9].Text;
            string NRO_CHEQUE = lvBuscarOP.SelectedItems[0].SubItems[6].Text;
            string BANCO = lvBuscarOP.SelectedItems[0].SubItems[7].Text;
            string IMPORTE_LETRAS = nal.convertir(IMPORTE);
            char[] SEP = { '/' };
            string[] FE = FECHA.Split(SEP);
            string DIA = FE[0];
            string MES = FE[1];
            string ANIO = FE[2];
            string NOMBRE_MES = FORMATO_FECHA.GetMonthName(int.Parse(MES)).ToUpper();

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
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

            Document doc = new Document(PageSize.A4);
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"\\192.168.1.6\Tesoreria\CHEQUES\CHEQUE - " + NRO_CHEQUE + ".PDF", FileMode.Create));
            doc.AddTitle("CHEQUE Nº " + NRO_CHEQUE);
            doc.AddCreator("CSPFA");
            doc.Open();

            Paragraph P = new Paragraph("-", _standardFontWhite);
            P.Alignment = Element.ALIGN_LEFT;
            doc.Add(P);

            Paragraph P_IMPORTE = new Paragraph(IMPORTE + "              ", _standardFont);
            P_IMPORTE.Alignment = Element.ALIGN_RIGHT;
            P_IMPORTE.SpacingBefore = 125;
            doc.Add(P_IMPORTE);

            Paragraph P_FECHA = new Paragraph("                                                                 " + DIA + "       " + NOMBRE_MES + "                  " + ANIO, _mediumFont);
            P_FECHA.Alignment = Element.ALIGN_LEFT;
            P_FECHA.SpacingBefore = 27;
            doc.Add(P_FECHA);

            Paragraph P_BENEFICIARIO = new Paragraph("                                                                  " + BENEFICIARIO, _mediumFont);
            P_BENEFICIARIO.Alignment = Element.ALIGN_LEFT;
            P_BENEFICIARIO.SpacingBefore = 15;
            doc.Add(P_BENEFICIARIO);

            Paragraph P_IMPORTE_LETRAS = new Paragraph("                                                                           " + IMPORTE_LETRAS, _mediumFont);
            P_IMPORTE_LETRAS.Alignment = Element.ALIGN_LEFT;
            P_IMPORTE_LETRAS.SpacingBefore = 16;
            doc.Add(P_IMPORTE_LETRAS);

            doc.Close();
            writer.Close();
        }

        

        private void tsmAgregarOp_Click(object sender, EventArgs e)
        {
            string ID_FACTURA = lvFacturas.SelectedItems[0].SubItems[0].Text;
            bool OP = checkOrdenDePago();
            bool FACTURA_EN_OP = checkFacturaEnOp(ID_FACTURA);

            if (OP == true)
            {
                MessageBox.Show("ALGUNA DE LAS FACTURAS SELECCIONADAS YA POSEE UNA ORDEN DE PAGO", "ERROR");
            }
            else if (FACTURA_EN_OP == true)
            {
                MessageBox.Show("ALGUNA DE LAS FACTURAS SELECCIONADAS YA EXISTE EN LA ORDEN DE PAGO ABIERTA", "ERROR");
            }
            else
            {
                //bloquearGrupos();
                llenarLvOp();
            }
        }

        private void tsmAbrirRemito_Click(object sender, EventArgs e)
        {
            string NRO_REMITO = lvFacturas.SelectedItems[0].SubItems[8].Text;
            string ARCHIVO = "\\\\192.168.1.6\\ComprasPDF\\REMITO - " + NRO_REMITO + ".PDF";

            if (File.Exists(ARCHIVO))
            {
                OpenAdobeAcrobat(ARCHIVO);
            }
            else
            {
                MessageBox.Show("NO SE ENCONTRO EL ARCHIVO ADJUNTO");
            }
        }

        private void lvAdjuntos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvAdjuntos.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    cmAdjuntos.Show(Cursor.Position);
                }
            }
        }

        private void cbTipoComprobante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string TIPO_COMPROBANTE = cbTipoComprobante.SelectedValue.ToString();

            if (TIPO_COMPROBANTE == "2" || TIPO_COMPROBANTE == "9" || TIPO_COMPROBANTE == "12")
            {
                comboAnticipos();
                tbNumFactura.Enabled = false;
                lbNumFactura.Enabled = false;
                lbNumSolicitud.Enabled = true;
                maxid mid = new maxid();
                tbNumSolicitud.Text = mid.m("ID", "FACTURAS");
                gbFacturas.Visible = true;
                grupoArticulos.Visible = false;
            }
            else
            {
                comboProveedores(cbProveedores);
                tbNumFactura.Enabled = true;
                lbNumFactura.Enabled = true;
                lbNumSolicitud.Enabled = false;
                tbNumSolicitud.Text = "";
                gbFacturas.Visible = false;
                grupoArticulos.Visible = true;
            }

            grupoFacturas(sender);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string ARCHIVO = @"\\192.168.1.6\compraspdf\" + lvAdjuntos.SelectedItems[0].SubItems[0].Text;
            OpenAdobeAcrobat(ARCHIVO);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA ELIMINAR EL ARCHIVO SELECCIONADO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string ARCHIVO = @"\\192.168.1.6\compraspdf\" + lvAdjuntos.SelectedItems[0].SubItems[0].Text;
                string DESTINO = @"\\192.168.1.6\compraspdf\Papelera\" + lvAdjuntos.SelectedItems[0].SubItems[0].Text;

                try
                {
                    File.Delete(ARCHIVO);

                    foreach (ListViewItem itemRow in lvAdjuntos.SelectedItems)
                    {
                        itemRow.Remove();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
            }
        }

        private void cargarNotaCreditoDebito(string NUM_FACTURA, string ID_FACTURA)
        {
            if (rbNinguna.Checked == false)
            {
                if (tbNumNota.Text == "")
                {
                    MessageBox.Show("COMPLETAR EL CAMPO Nº NOTA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tbNumNota.Focus();
                }
                else if (tbImporteNota.Text == "")
                {
                    MessageBox.Show("COMPLETAR EL CAMPO IMPORTE NOTA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tbImporteNota.Focus();
                }
                else if (lbNotaAdjunto.Text == "ARCHIVO PDF NO CARGADO")
                {
                    MessageBox.Show("SELECCIONAR UN ARCHIVO PDF", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    try
                    {
                        string TIPO_NOTA = "";
                        if (rbCredito.Checked) { TIPO_NOTA = "CREDITO"; }
                        if (rbDebito.Checked) { TIPO_NOTA = "DEBITO"; }
                        string NRO_NOTA = tbNumNota.Text.Trim();
                        string FE_NOTA = dpFechaNota.Text;
                        decimal IMPORTE_NOTA = Convert.ToDecimal(tbImporteNota.Text);
                        string OBS_NOTA = tbObsNota.Text.Trim();
                        string ALTA_NOTA = DateTime.Today.ToShortDateString();
                        string US_ALTA_NOTA = VGlobales.vp_username;
                        BO_COMPRAS.nuevaNotaCreditoDebito(NRO_NOTA, FE_NOTA, IMPORTE_NOTA, TIPO_NOTA, OBS_NOTA, ALTA_NOTA, US_ALTA_NOTA, NUM_FACTURA);
                        string ARCHIVO_ORIGEN = lbNotaAdjunto.Text;
                        string ARCHIVO_DESTINO = "\\\\192.168.1.6\\ComprasPDF\\" + TIPO_NOTA + "_" + ID_FACTURA + ".PDF";
                        File.Copy(ARCHIVO_ORIGEN, ARCHIVO_DESTINO);
                        MessageBox.Show("SE CARGO LA NOTA CORRECTAMENTE", "LISTO!");
                        limpiarNotaCreditoDebito();
                        buscarAdjuntos(int.Parse(ID_FACTURA));
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("OCURRIO UN ERROR AL CARGAR LA NOTA", "ERROR");
                    }
                }
            }
            else
            {
                MessageBox.Show("SELECCIONAR UN TIPO DE NOTA", "ERROR");
            }
        }

        private void cargarRemito(string NUM_FACTURA, string ID_FACTURA)
        {
            if (tbNumRemito.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO Nº REMITO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbNumRemito.Focus();
            }
            else if (tbImporteRemito.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO IMPORTE REMITO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbImporteRemito.Focus();
            }
            else if (lbPdfRemito.Text == "ARCHIVO PDF NO CARGADO")
            {
                MessageBox.Show("SELECCIONAR UN ARCHIVO PDF", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try
                {
                    string NRO_REMITO = tbNumRemito.Text.Trim();
                    string FE_REMITO = dpFechaRemito.Text;
                    decimal IMPORTE_REMITO = Convert.ToDecimal(tbImporteRemito.Text);
                    string OBS_REMITO = tbObsRemito.Text.Trim();
                    string ALTA_REMITO = DateTime.Today.ToShortDateString();
                    string US_ALTA_REMITO = VGlobales.vp_username;
                    BO_COMPRAS.nuevoRemito(NRO_REMITO, FE_REMITO, IMPORTE_REMITO, OBS_REMITO, ALTA_REMITO, US_ALTA_REMITO, NUM_FACTURA);
                    string ARCHIVO_ORIGEN = lbPdfRemito.Text;
                    string ARCHIVO_DESTINO = "\\\\192.168.1.6\\ComprasPDF\\REMITO_" + ID_FACTURA + ".PDF";
                    File.Copy(ARCHIVO_ORIGEN, ARCHIVO_DESTINO);
                    MessageBox.Show("SE CARGO EL REMITO CORRECTAMENTE", "LISTO!");
                    limpiarRemito();
                    buscarAdjuntos(int.Parse(ID_FACTURA));
                }
                catch (Exception error)
                {
                    MessageBox.Show("OCURRIO UN ERROR AL CARGAR LA NOTA\n" + error, "ERROR");
                }
            }
        }

        private void cargarReciboOficial(string NUM_FACTURA, string ID_FACTURA)
        {
            if (tbNumRecibo.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO Nº RECIBO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbNumRecibo.Focus();
            }
            else if (tbImporteRecibo.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO IMPORTE RECIBO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbImporteRecibo.Focus();
            }
            else if (lbAdjuntoRecibo.Text == "ARCHIVO PDF NO CARGADO")
            {
                MessageBox.Show("SELECCIONAR UN ARCHIVO PDF", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try
                {
                    string NRO_RECIBO = tbNumRecibo.Text.Trim();
                    string FE_RECIBO = dpFechaRecibo.Text;
                    decimal IMPORTE_RECIBO = Convert.ToDecimal(tbImporteRecibo.Text);
                    string OBS_RECIBO = tbObsRecibo.Text.Trim();
                    string ALTA_RECIBO = DateTime.Today.ToShortDateString();
                    string US_ALTA_RECIBO = VGlobales.vp_username;
                    BO_COMPRAS.nuevoReciboOficial(NRO_RECIBO, FE_RECIBO, IMPORTE_RECIBO, OBS_RECIBO, ALTA_RECIBO, US_ALTA_RECIBO, NUM_FACTURA);
                    string ARCHIVO_ORIGEN = lbAdjuntoRecibo.Text;
                    string ARCHIVO_DESTINO = "\\\\192.168.1.6\\ComprasPDF\\RECIBO_" + ID_FACTURA + ".PDF";
                    File.Copy(ARCHIVO_ORIGEN, ARCHIVO_DESTINO);
                    MessageBox.Show("SE CARGO EL RECIBO CORRECTAMENTE", "LISTO!");
                    limpiarReciboOficial();
                    buscarAdjuntos(int.Parse(ID_FACTURA));
                }
                catch (Exception error)
                {
                    MessageBox.Show("OCURRIO UN ERROR AL CARGAR LA NOTA\n" + error, "ERROR");
                }
            }
        }

        private void limpiarCargaOP()
        {
            TBNROOP.Text = "";
            TBIMPOP.Text = "";
            TBOBSOP.Text = "";
            DPFECHAOP.Text = DateTime.Today.ToShortDateString();
            LBPDFOP.Text = "ARCHIVO PDF NO CARGADO";
        }

        private void cargarOP(string NUM_FACTURA, string ID_FACTURA)
        {
            if (TBNROOP.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO Nº OP", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                TBNROOP.Focus();
            }
            else if (TBIMPOP.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO IMPORTE OP", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                TBIMPOP.Focus();
            }
            else if (LBPDFOP.Text == "ARCHIVO PDF NO CARGADO")
            {
                MessageBox.Show("SELECCIONAR UN ARCHIVO PDF", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try
                {
                    string NRO_OP = TBNROOP.Text.Trim();
                    string FE_OP = DPFECHAOP.Text;
                    decimal IMPORTE_OP = Convert.ToDecimal(TBIMPOP.Text);
                    string OBS_OP = TBOBSOP.Text.Trim();
                    string ALTA_OP = DateTime.Today.ToShortDateString();
                    string US_ALTA_OP = VGlobales.vp_username;
                    string ARCHIVO_ORIGEN = LBPDFOP.Text;
                    string ARCHIVO_DESTINO = "\\\\192.168.1.6\\ComprasPDF\\ORDENDEPAGO_" + ID_FACTURA + ".PDF";
                    File.Copy(ARCHIVO_ORIGEN, ARCHIVO_DESTINO);
                    MessageBox.Show("SE CARGO LA ORDEN DE PAGO CORRECTAMENTE", "LISTO!");
                    limpiarCargaOP();
                }
                catch (Exception error)
                {
                    MessageBox.Show("OCURRIO UN ERROR AL CARGAR LA NOTA\n" + error, "ERROR");
                }
            }
        }

        private void cbTipoBusqueda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string TIPO_DE_BUSQUEDA = cbTipoBusqueda.SelectedValue.ToString();

            if (TIPO_DE_BUSQUEDA == "2" || TIPO_DE_BUSQUEDA == "9" || TIPO_DE_BUSQUEDA == "12")
            {
                tbBuscarNumeroFactura.Visible = false;
                tbBuscarNumeroFactura.Text = "";
                tbBuscarNumeroSolicitud.Visible = true;
            }
            else
            {
                tbBuscarNumeroFactura.Visible = true;
                tbBuscarNumeroSolicitud.Visible = false;
                tbBuscarNumeroSolicitud.Text = "";
            }
        }

        private void btnAdjuntarRemito_Click_1(object sender, EventArgs e)
        {
            string NUM_FACTURA = lvFacturas.SelectedItems[0].SubItems[2].Text;
            string ID_FACTURA = lvFacturas.SelectedItems[0].SubItems[0].Text;
            cargarRemito(NUM_FACTURA, ID_FACTURA);
        }

        private void btnGuardarRecibo_Click_1(object sender, EventArgs e)
        {
            string NUM_FACTURA = lvFacturas.SelectedItems[0].SubItems[2].Text;
            string ID_FACTURA = lvFacturas.SelectedItems[0].SubItems[0].Text;
            cargarReciboOficial(NUM_FACTURA, ID_FACTURA);
        }

        private void btnGuardarNota_Click_1(object sender, EventArgs e)
        {
            string NUM_FACTURA = lvFacturas.SelectedItems[0].SubItems[2].Text;
            string ID_FACTURA = lvFacturas.SelectedItems[0].SubItems[0].Text;
            cargarNotaCreditoDebito(NUM_FACTURA, ID_FACTURA);
        }

        private void toggleBotones(string ACCION)
        {
            if (ACCION == "OCULTAR")
            {
                btnGuardarFactura.Visible = false;
                btnModFactura.Visible = false;
                button4.Visible = false;
            }

            if (ACCION == "MOSTRAR")
            {
                btnGuardarFactura.Visible = true;
                btnModFactura.Visible = true;
                button4.Visible = true;
            }
        }

        private void btnSectores_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            sect_act_abm sa = new sect_act_abm();
            sa.ShowDialog();
            comboSectores(cbSectores, 0);
            Cursor = Cursors.Default;
        }

        private bool check_ad_factura(string FACTURA, string AD)
        {
            bool RES = false;
            string QUERY = "SELECT COUNT(ID) FROM FACTURAS WHERE NUM_FACTURA = '" + FACTURA + "' AND ACREEDOR_DIVERSO = '" + AD + "';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


            if (Convert.ToInt32(foundRows[0][0]) > 0)
            {
                RES = true;
            }

            return RES;

        }

        private void btnGuardarFactura_Click_1(object sender, EventArgs e)
        {
            btnGuardarFactura.Enabled = false;
            int ARTICULOS = dgArticulos.Rows.Count;
            int FACTURAS_HIJAS = dgFacturasHijas.Rows.Count;
            string TIPO_COMPROBANTE = cbTipoComprobante.SelectedValue.ToString();
            bool CHECK_P_F = checkProveedorFactura();
            decimal IMPORTE_FACTURA = decimal.Parse(tbImporte.Text.Trim());
            string IF = string.Format("{0:n}", IMPORTE_FACTURA);

            foreach (DataGridViewRow row in dgArticulos.Rows)
            {
                SUMA_ART = SUMA_ART + decimal.Parse(row.Cells["IMPORTE"].Value.ToString());
            }

            if (tbAjuste.Text != "0")
            {
                decimal AJUSTE = decimal.Parse(tbAjuste.Text);
                string OPERACION = cbAjuste.Text;
                S_AJUSTE = OPERACION + AJUSTE.ToString();

                if (OPERACION == "-")
                {
                    SUMA_ART = SUMA_ART - AJUSTE;
                }

                if (OPERACION == "+")
                {
                    SUMA_ART = SUMA_ART + AJUSTE;
                }
            }

            string SA = string.Format("{0:n}", SUMA_ART);

            if (cbProveedores.SelectedValue == "")
            {
                MessageBox.Show("SELECCIONAR UN PROVEEDOR", "ERROR");
                SUMA_ART = 0;
                cbProveedores.Focus();
                btnGuardarFactura.Enabled = true;
            }
            else if (TIPO_COMPROBANTE != "2" && TIPO_COMPROBANTE != "9" && TIPO_COMPROBANTE != "12" && tbNumFactura.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO Nº FACTURA", "ERROR");
                SUMA_ART = 0;
                tbNumFactura.Focus();
                btnGuardarFactura.Enabled = true;
            }
            else if (tbImporte.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO IMPORTE", "ERROR");
                SUMA_ART = 0;
                tbImporte.Focus();
                btnGuardarFactura.Enabled = true;
            }
            else if (dgArticulos.Rows.Count > 0 && IF != SA)
            {
                MessageBox.Show("EL IMPORTE DE LA FACTURA Y LA SUMA DE LOS ARTICULOS NO COINCIDEN", "ERROR");
                SUMA_ART = 0;
                btnGuardarFactura.Enabled = true;
            }
            else if (CHECK_P_F == true)
            {
                MessageBox.Show("LA FACTURA " + tbNumFactura.Text.Trim() + " YA EXISTE PARA ESTE PROVEEDOR", "ERROR");
                SUMA_ART = 0;
                btnGuardarFactura.Enabled = true;
            }
            else if(check_ad_factura(tbAcreedor.Text.Trim(), tbNumFactura.Text))
            {
                MessageBox.Show("LA FACTURA " + tbNumFactura.Text.Trim() + " YA EXISTE PARA ESTE ACREEDOR DIVERSO", "ERROR");
                SUMA_ART = 0;
                btnGuardarFactura.Enabled = true;
            }
            else
            {
                try
                {
                    int PROVEEDOR = int.Parse(cbProveedores.SelectedValue.ToString());
                    string NUM_FACTURA = "";

                    if (TIPO_COMPROBANTE != "2" && TIPO_COMPROBANTE != "9" && TIPO_COMPROBANTE != "12")
                    {
                        NUM_FACTURA = tbNumFactura.Text.Trim();
                    }
                    else
                    {
                        NUM_FACTURA = tbNumSolicitud.Text.Trim();
                    }

                    string FECHA = dpFechaFactura.Text.Trim();
                    decimal IMPORTE = Convert.ToDecimal(tbImporte.Text.Trim());
                    string OBSERVACIONES = tbObservaciones.Text.Trim();
                    string US_ALTA = VGlobales.vp_username;
                    DateTime Hoy = DateTime.Today;
                    string FE_ALTA = Hoy.ToString("dd/MM/yyyy");
                    string SECTOR = cbSectores.SelectedValue.ToString();
                    int ORDEN_DE_PAGO = 0;
                    string SEC_GRAL = tbNumSecGral.Text.Trim();
                    int TIPO = int.Parse(cbTipoComprobante.SelectedValue.ToString());
                    string TIPO_ARCHIVO = "";
                    string FE_ALTA_NOTA = "";
                    int REGIMEN = 0;
                    decimal RETENCION = 0;
                    int DESCUENTO_TOTAL = int.Parse(tbDescuentoTotal.Text);
                    string TIPO_DESCUENTO = cbDescGlobal.SelectedItem.ToString();
                    string SOL_COMP = tbSolComp.Text.Trim();
                    string ACREEDOR_DIVERSO = tbAcreedor.Text.Trim();

                    Cursor = Cursors.WaitCursor;

                    BO_COMPRAS.nuevaFactura(PROVEEDOR, NUM_FACTURA, FECHA, IMPORTE, OBSERVACIONES, FE_ALTA, US_ALTA, SECTOR, SEC_GRAL,
                        TIPO, ORDEN_DE_PAGO, REGIMEN, RETENCION, 0, DESCUENTO_TOTAL, TIPO_DESCUENTO, SOL_COMP, S_AJUSTE, ACREEDOR_DIVERSO);

                    int ID_FACTURA = int.Parse(mid.m("ID", "FACTURAS"));

                    switch (TIPO)
                    {
                        case 2:
                            TIPO_ARCHIVO = "SOLICITUD";
                            break;

                        default:
                            TIPO_ARCHIVO = "FACTURA";
                            break;
                    }

                    if (lbArchivoAdjunto.Text != "ARCHIVO PDF NO CARGADO")
                    {
                        string ARCHIVO_ORIGEN = lbArchivoAdjunto.Text;
                        string ARCHIVO_DESTINO = "\\\\192.168.1.6\\ComprasPDF\\" + TIPO_ARCHIVO + "_" + ID_FACTURA + ".PDF";

                        try
                        {
                            File.Copy(ARCHIVO_ORIGEN, ARCHIVO_DESTINO);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("NO SE PUDO COPIAR EL ARCHIVO");
                        }
                    }

                    if (FACTURAS_HIJAS > 0)
                    {
                        foreach (DataGridView row in dgFacturasHijas.Rows)
                        {

                        }
                    }

                    if (ARTICULOS > 0)
                    {
                        foreach (DataGridViewRow row in dgArticulos.Rows)
                        {
                            //string ID_ART = row.Cells["AID"].Value.ToString();
                            //bool EXISTE = existe.check("ARTICULOS", "ID", ID_ART);
                            Int32 CANTIDAD;
                            string DETALLE = string.Empty;
                            decimal PRECIO;
                            string NSERIE = string.Empty;
                            int TIPO_ART;
                            string DESCUENTO;
                            CANTIDAD = Convert.ToInt32(row.Cells["CANTIDAD"].Value);
                            DETALLE = Convert.ToString(row.Cells["DETALLE"].Value).Trim();
                            PRECIO = Convert.ToDecimal(row.Cells["PRECIO"].Value.ToString().Trim());
                            NSERIE = Convert.ToString(row.Cells["NSERIE"].Value).Trim();
                            TIPO_ART = Convert.ToInt16(row.Cells["TID"].Value);
                            DESCUENTO = row.Cells["DESC"].Value.ToString();
                            BO_COMPRAS.nuevoArticulo(ID_FACTURA, DETALLE, PRECIO, CANTIDAD, NSERIE, TIPO_ART, DESCUENTO);

                            /*if (EXISTE == false)
                            {
                                BO_COMPRAS.nuevoArticulo(ID_FACTURA, DETALLE, PRECIO, CANTIDAD, NSERIE, TIPO_ART, DESCUENTO);
                            }
                            else
                            {
                                BO_COMPRAS.modificarArticulos(int.Parse(ID_ART), DETALLE, PRECIO, CANTIDAD, NSERIE, TIPO_ART, DESCUENTO);
                            }*/
                        }
                    }

                    if (TIPO_COMPROBANTE != "2" && TIPO_COMPROBANTE != "9" && TIPO_COMPROBANTE != "12")
                    {
                        limpiarFactura();
                        comboProveedores(cbProveedores);
                    }
                    else
                    {
                        lbID.Text = ID_FACTURA.ToString();
                    }

                    
                    SUMA_ART = 0;
                    dgArticulos.Rows.Clear();
                    btnGuardarFactura.Enabled = true;
                    Cursor = Cursors.Default;
                    MessageBox.Show("DEUDA GUARDADA", "LISTO!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO GUARDAR LA DEUDA\n" + error, "ERROR");
                    Cursor = Cursors.Default;
                    btnGuardarFactura.Enabled = true;
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            lbID.Text = "ID_FACTURA";
            lbIdArticulo.Text = "ID_ARTICULO";
            limpiarBusquedaFactura();
            limpiarArticulo();
            limpiarFactura();
            lvAdjuntos.Clear();
            dgArticulos.Rows.Clear();
            btnGuardarFactura.Enabled = true;
            btnModFactura.Enabled = false;
            comboProveedores(cbProveedores);
        }

        private void btnModFactura_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                int ID = Convert.ToInt16(lbID.Text);
                int PROVEEDOR = Convert.ToInt16(cbProveedores.SelectedValue);
                string NUM_FACTURA = tbNumFactura.Text.Trim();
                string FECHA = dpFechaFactura.Text;
                decimal IMPORTE = Convert.ToDecimal(tbImporte.Text);
                string OBSERVACIONES = tbObservaciones.Text.Trim();
                string US_MOD = VGlobales.vp_username;
                DateTime Hoy = DateTime.Today;
                string FE_MOD = Hoy.ToString("dd/MM/yyyy");
                string SECTOR = cbSectores.SelectedValue.ToString();
                string SEC_GRAL = tbNumSecGral.Text.Trim();
                int TIPO = int.Parse(cbTipoComprobante.SelectedValue.ToString());
                string TIPO_ARCHIVO = "";
                int REGIMEN = 0;
                int DESCUENTO = int.Parse(tbDescuentoTotal.Text);
                string SOL_COMP = tbSolComp.Text.Trim();

                BO_COMPRAS.modificarFactura(ID, PROVEEDOR, NUM_FACTURA, FECHA, IMPORTE, OBSERVACIONES, FE_MOD, US_MOD, SECTOR, SEC_GRAL, TIPO, DESCUENTO, SOL_COMP);

                switch (TIPO)
                {
                    case 1:
                        TIPO_ARCHIVO = "FACTURA";
                        break;

                    case 2:
                        TIPO_ARCHIVO = "SOLICITUD";
                        break;
                }

                if (lbArchivoAdjunto.Text != "ARCHIVO PDF NO CARGADO")
                {
                    string ARCHIVO_ORIGEN = lbArchivoAdjunto.Text;
                    string ARCHIVO_DESTINO = "\\\\192.168.1.6\\ComprasPDF\\" + TIPO_ARCHIVO + "_" + ID + ".PDF";

                    try
                    {
                        File.Copy(ARCHIVO_ORIGEN, ARCHIVO_DESTINO, true);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO COPIAR EL ARCHIVO\n" + error);
                    }
                }

                MessageBox.Show("MODIFICACIÓN COMPLETADA CORRECTAMENTE");
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO MODIFICAR LA FACTURA\n" + error.ToString());
            }

            llenarDatosFactura(Convert.ToInt16(lbID.Text));
            Cursor = Cursors.Default;
        }

        private void BTNPDFOP_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF (*.PDF)|*.PDF|" + "All files (*.*)|*.*";
            ofd.Title = "Seleccionar Archivo";
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                LBPDFOP.Text = ofd.FileName;
            }
        }

        private void btnPdfRemito_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF (*.PDF)|*.PDF|" + "All files (*.*)|*.*";
            ofd.Title = "Seleccionar Archivo";
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                lbPdfRemito.Text = ofd.FileName;
            }
        }

        private void btnPdfRecibo_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF (*.PDF)|*.PDF|" + "All files (*.*)|*.*";
            ofd.Title = "Seleccionar Archivo";
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                lbAdjuntoRecibo.Text = ofd.FileName;
            }
        }

        private void btnAdjuntarNota_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF (*.PDF)|*.PDF|" + "All files (*.*)|*.*";
            ofd.Title = "Seleccionar Archivo";
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                lbNotaAdjunto.Text = ofd.FileName;
            }
        }

        private void BTNGUAROP_Click(object sender, EventArgs e)
        {
            if (TBNROOP.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO NRO OP");
            }
            else if (TBIMPOP.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO IMPORTE");
            }
            else
            {
                try
                {
                    string FECHA = DPFECHAOP.Text;
                    string TOTAL = string.Format("{0:n}", Convert.ToDecimal(TBIMPOP.Text));
                    string OBSERVACIONES = TBOBSOP.Text.Trim();
                    string BENEFICIARIO = cbBenefCargaOp.Text.Trim();
                    int IDE = int.Parse(TBNROOP.Text.Trim());
                    string US_ALTA = VGlobales.vp_username;
                    string FECHA_OP = fechaOP.Text;
                    BO_COMPRAS.nuevaOrdenDePago(FECHA, OBSERVACIONES, Convert.ToDecimal(TOTAL), BENEFICIARIO, IDE, US_ALTA, FECHA_OP);
                    BO_COMPRAS.facturaXop(IDE, int.Parse(LBIDDATO.Text));
                    BO_COMPRAS.opEnFactura(int.Parse(LBIDDATO.Text), IDE);
                    string ARCHIVO_ORIGEN = LBPDFOP.Text;
                    string ARCHIVO_DESTINO = "\\\\192.168.1.6\\ComprasPDF\\OP_" + LBIDDATO.Text + ".PDF";
                    File.Copy(ARCHIVO_ORIGEN, ARCHIVO_DESTINO);
                    MessageBox.Show("ORDEN DE PAGO CARGADA");
                    limpiarCargaOP();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
            }

        }

        private bool sumarTotales()
        { 
            decimal CHEQUES = Convert.ToDecimal(lbTotalCheques.Text);
            decimal TRANSFE = Convert.ToDecimal(lbTotalTransferencias.Text);
            decimal TOTALFA = Convert.ToDecimal(lbTotalFacturasOP.Text);
            decimal TOTALLL = CHEQUES + TRANSFE;

            if (TOTALLL == TOTALFA)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnAgregarCheque_Click(object sender, EventArgs e)
        {
            if (tbImporteOP.Text == "")
            {
                MessageBox.Show("EL IMPORTE DEL CHEQUE ES NECESARIO", "ERROR");
            }
            else if (Convert.ToDecimal(tbImporteOP.Text) > Convert.ToDecimal(lbTotalFacturasOP.Text))
            {
                MessageBox.Show("EL IMPORTE DEL CHEQUE SUPERA EL TOTAL DE LAS FACTURAS SELECCIONADAS", "ERROR");
            }
            else
            {
                string BANCO_ID = cbBancos.SelectedValue.ToString().Trim();
                string BANCO_DE = cbBancos.Text.Trim();
                string CHEQUE = cbCheques.Text.Trim();
                string TIPO = LBTIPOCHEQUE.Text.Trim();
                string FECHA = DPFECHACHEQUE.Text;
                string VENCIMIENTO = "";

                if (TIPO == "DIFERIDO")
                    VENCIMIENTO = DPVENCECHEQUE.Text;

                string IMPORTE = string.Format("{0:n}", Convert.ToDecimal(tbImporteOP.Text.Trim()));
                string BENEF = cbBeneficiarioOP.Text.Trim().ToUpper();

                if (lvChequesSeleccionados.Columns.Count == 0)
                {
                    lvChequesSeleccionados.Columns.Add("BDETALLE");
                    lvChequesSeleccionados.Columns.Add("CHEQUE");
                    lvChequesSeleccionados.Columns.Add("TIPO");
                    lvChequesSeleccionados.Columns.Add("VENCE");
                    lvChequesSeleccionados.Columns.Add("IMPORTE");
                    lvChequesSeleccionados.Columns.Add("FECHA");
                    lvChequesSeleccionados.Columns.Add("BENEFICIARIO");
                    lvChequesSeleccionados.Columns.Add("ID");
                }

                ListViewItem items = new ListViewItem(BANCO_DE);
                items.SubItems.Add(CHEQUE);
                items.SubItems.Add(TIPO);
                items.SubItems.Add(VENCIMIENTO);
                items.SubItems.Add(IMPORTE);
                items.SubItems.Add(FECHA);
                items.SubItems.Add(BENEF);
                items.SubItems.Add(BANCO_ID);
                lvChequesSeleccionados.Items.Add(items);
                lvChequesSeleccionados.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvChequesSeleccionados.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvChequesSeleccionados.Columns[7].Width = 0;
                sumaCheques();
                int VALOR = 1;
                BO_COMPRAS.chequeOpTemp(VALOR, int.Parse(CHEQUE), int.Parse(BANCO_ID));
                comboCheques(int.Parse(BANCO_ID), cbCheques);
                comboCheques(int.Parse(cbBancoOrigenTrans.SelectedValue.ToString()), cbChequeAcompTrans);
            }
        }

        private void tipoCheque(int BANCO, int CHEQUE)
        {
            try
            {
                string QUERY = "SELECT TIPO FROM CHEQUERAS WHERE BANCO = " + BANCO + " AND NRO_CHEQUE = " + CHEQUE + " AND OP_ASIGNADA IS NULL;";
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
                LBTIPOCHEQUE.Text = foundRows[0][0].ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void cbBancos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int BANCO = int.Parse(cbBancos.SelectedValue.ToString());
            comboCheques(BANCO, cbCheques);

            if (cbCheques.Items.Count > 0)
            {
                int CHEQUE = int.Parse(cbCheques.Text);
                tipoCheque(BANCO, CHEQUE);
            }
            else
            {
                LBTIPOCHEQUE.Text = "";
            }

            if (LBTIPOCHEQUE.Text == "DIFERIDO")
            {
                DPVENCECHEQUE.Enabled = true;
            }
            else
            {
                DPVENCECHEQUE.Enabled = false;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            eliminarCheques("SELECCIONADOS");
        }

        private void lvChequesSeleccionados_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvChequesSeleccionados.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    cmCheques.Show(Cursor.Position);
                }
            }
        }

        private bool checkNombreBanco(string NOMBRE_BANCO)
        {
            string QUERY = "SELECT NOMBRE FROM BANCOS WHERE NOMBRE = '" + NOMBRE_BANCO + "';";
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

        private void llenarDatosBanco(int ID)
        { 
            string QUERY = "SELECT NOMBRE FROM BANCOS WHERE ID = " + ID;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                tbBancoNuevo.Text = foundRows[0][0].ToString().Trim();
                idBancoModificar.Text = ID.ToString();
            }
        }

        private void tbCargarPdfTrans_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF (*.PDF)|*.PDF|" + "All files (*.*)|*.*";
            ofd.Title = "Seleccionar Archivo";
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                lbPdfTrans.Text = ofd.FileName;
            }
        }

        private string[] obtenerBancoDeCuenta(string ID_CUENTA)
        {
            string QUERY = "SELECT C.BANCO, B.NOMBRE FROM CUENTAS_BANCARIAS C, BANCOS B WHERE C.ID = " + int.Parse(ID_CUENTA) + " AND C.BANCO = B.ID;";
            string[] RETURN;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                RETURN = new string[] { foundRows[0][0].ToString(), foundRows[0][1].ToString() };
            }
            else
            {
                RETURN = new string[] { "X", "X" };
            }

            return RETURN;
        }

        private void btnAddTrans_Click(object sender, EventArgs e)
        {
            if (tbImporteTrans.Text.Trim() == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO IMPORTE", "ERROR");
            }
            else if (Convert.ToDecimal(lbTotalFacturasOP.Text) < Convert.ToDecimal(tbImporteTrans.Text))
            {
                MessageBox.Show("EL IMPORTE DE LA TRANSFERENCIA SUPERA EL TOTAL DE LAS FACTURAS SELECCIONADAS", "ERROR");
            }
            else if (lvTransSeleccionadas.Columns.Count > 0 && VerificarTotalTransferido())
            {
                MessageBox.Show("EL IMPORTE DE LAS TRANSFERENCIAS SUPERA EL TOTAL DE LAS FACTURAS SELECCIONADAS", "ERROR");
            }
            else if (tbProvTrans.Text.Trim() == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO PROVEEDOR", "ERROR");
            }
            else if (cbCuentaDestinoTrans.Items.Count == 0)
            {
                MessageBox.Show("NO SE ENCONTRÓ NINGUNA CUENTA BANCARIA ASIGNADA AL PROVEEDOR SELECCIONADO", "ERROR");
            }
            else if (!checkProveedor(tbProvTrans.Text.Trim()))
            {
                MessageBox.Show("EL PROVEEDOR INGRESADO NO EXISTE");
            }
            /*else if (checkCuentaDestino( cbProvTrans.Text.Trim(), cbCuentaDestinoTrans.Text.Trim()))
            {
                MessageBox.Show("EL PROVEEDOR NO COINCIDE CON EL NRO DE CUENTA DESTINO");
            }*/
            /*else if (lbPdfTrans.Text == "ARCHIVO PDF NO CARGADO")
            {
                MessageBox.Show("NO SE CARGO NINGUN COMPROBANTE DE TRANSFERENCIA", "ERROR");
            }*/
            else
            {
                string BANCO_ORIGEN_ID = cbBancoOrigenTrans.SelectedValue.ToString();
                string BANCO_ORIGEN = cbBancoOrigenTrans.Text.Trim();
                string CUENTA_ORIGEN = cbCtaOrigenTrans.Text.Trim();
                string CUENTA_ORIGEN_ID = cbCtaOrigenTrans.SelectedValue.ToString();
                string CHEQUE = cbChequeAcompTrans.Text.Trim();
                string CUENTA_DESTINO = cbCuentaDestinoTrans.Text.Trim();
                string CUENTA_DESTINO_ID = cbCuentaDestinoTrans.SelectedValue.ToString();
                string IMPORTE = string.Format("{0:n}", Convert.ToDecimal(tbImporteTrans.Text.Trim()));
                string PROVEEDOR = tbProvTrans.Text.Trim().ToUpper().Trim();
                string PROVEEDOR_ID = idProveedor(PROVEEDOR);
                string PDF_RUTA = lbPdfTrans.Text.Trim();
                string[] BANCO_DESTINO = obtenerBancoDeCuenta(CUENTA_DESTINO_ID);
                string FECHA = dpFechaTransferencia.Text;

                if (lvTransSeleccionadas.Columns.Count == 0)
                {
                    lvTransSeleccionadas.Columns.Add("B_ORIGEN_ID");
                    lvTransSeleccionadas.Columns.Add("B_ORIGEN");
                    lvTransSeleccionadas.Columns.Add("CUENTA_ORIGEN");
                    lvTransSeleccionadas.Columns.Add("CUENTA_ORIGEN_ID");
                    lvTransSeleccionadas.Columns.Add("B_DESTINO");
                    lvTransSeleccionadas.Columns.Add("B_DESTINO_ID");
                    lvTransSeleccionadas.Columns.Add("CUENTA_DESTINO");
                    lvTransSeleccionadas.Columns.Add("CUENTA_DESTINO_ID");
                    lvTransSeleccionadas.Columns.Add("CHEQUE");
                    lvTransSeleccionadas.Columns.Add("IMPORTE");
                    lvTransSeleccionadas.Columns.Add("PROVEEDOR");
                    lvTransSeleccionadas.Columns.Add("PROVEEDOR_ID");
                    lvTransSeleccionadas.Columns.Add("FECHA");
                    lvTransSeleccionadas.Columns.Add("PDF");
                }

                ListViewItem items = new ListViewItem(BANCO_ORIGEN_ID);
                items.SubItems.Add(BANCO_ORIGEN);
                items.SubItems.Add(CUENTA_ORIGEN);
                items.SubItems.Add(CUENTA_ORIGEN_ID);
                items.SubItems.Add(BANCO_DESTINO[1].Trim());
                items.SubItems.Add(BANCO_DESTINO[0]);
                items.SubItems.Add(CUENTA_DESTINO);
                items.SubItems.Add(CUENTA_DESTINO_ID);
                items.SubItems.Add(CHEQUE);
                items.SubItems.Add(IMPORTE);
                items.SubItems.Add(PROVEEDOR);
                items.SubItems.Add(PROVEEDOR_ID);
                items.SubItems.Add(FECHA);
                items.SubItems.Add(PDF_RUTA);
                lvTransSeleccionadas.Items.Add(items);

                lvTransSeleccionadas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvTransSeleccionadas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                lvTransSeleccionadas.Columns[0].Width = 0;
                lvTransSeleccionadas.Columns[3].Width = 0;
                lvTransSeleccionadas.Columns[5].Width = 0;
                lvTransSeleccionadas.Columns[7].Width = 0;
                lvTransSeleccionadas.Columns[11].Width = 0;
                lvTransSeleccionadas.Columns[13].Width = 0;


                if (BANCO_ORIGEN_ID == "2")
                {
                    int CB_CHEQUES_INDEX = cbChequeAcompTrans.SelectedIndex;
                    cbChequeAcompTrans.Items.RemoveAt(CB_CHEQUES_INDEX);
                    cbChequeAcompTrans.SelectedIndex = 0;
                }
            }

            sumaTransferencias();
        }

        private string idProveedor(string PROVEEDOR)
        {
            string QUERY = "SELECT ID FROM PROVEEDORES WHERE RAZON_SOCIAL = '" + PROVEEDOR + "' AND FE_BAJA IS NULL";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            return foundRows[0][0].ToString().Trim();
        }

        private bool checkCuentaDestino(string PROVEEDOR, string CUENTA)
        {
            string QUERY = "SELECT ID FROM CUENTAS_BANCARIAS WHERE PROVEEDOR = " + PROVEEDOR + " AND NRO_CUENTA = '" + CUENTA + "'";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            return foundRows.Length < 0;
        }

        private bool VerificarTotalTransferido()
        {
            decimal total = 0;

            foreach (ListViewItem itemRow in lvTransSeleccionadas.Items)
            {
                total += Convert.ToDecimal(itemRow.SubItems[9].Text);
            }

            total += Convert.ToDecimal(tbImporteTrans.Text);

            return total > Convert.ToDecimal(lbTotalFacturasOP.Text);
        }

        private void cbBancoOrigenTrans_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int BANCO = int.Parse(cbBancoOrigenTrans.SelectedValue.ToString());

            if (BANCO == 2)
            {
                comboCheques(BANCO, cbChequeAcompTrans);
            }
            else
            {
                cbChequeAcompTrans.Enabled = false;
                cbChequeAcompTrans.Items.Clear();
            }
            
            comboCuentasBancariasCargadas(BANCO, cbCtaOrigenTrans);
        }

        private void limpiarCuentasBancarias()
        {
            cbBancosEnCuentas.SelectedIndex = 0;
            tbAgregarCuenta.Text = "";
            cbTipoCuenta.SelectedIndex = 0;
            lbIdCuenta.Text = "";
            btnAgregarCuenta.Enabled = true;
            btnModificarCuenta.Enabled = false;
            btnEliminarCuenta.Enabled = false;
            tbCBUCuentaBancaria.Text = "";
            tbSucursalCuentaBancaria.Text = "";
        }

        private void cargarDatosCuentaBancaria(int ID_CUENTA)
        { 
            string QUERY = "SELECT BANCO, TIPO_CUENTA, NRO_CUENTA FROM CUENTAS_BANCARIAS WHERE ID = " + ID_CUENTA;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                cbBancosEnCuentas.SelectedItem = foundRows[0][0];
                tbAgregarCuenta.Text = foundRows[0][2].ToString().Trim();
                cbTipoCuenta.SelectedValue = foundRows[0][1];
                lbIdCuenta.Text = ID_CUENTA.ToString();
            }
        }

        private void traeCuentaBancariaProveedor( /*int ID_PROVEEDOR  */)
        {
            string QUERY = "SELECT ID, NRO_CUENTA FROM CUENTAS_BANCARIAS";// WHERE PROVEEDOR = " + ID_PROVEEDOR + ";";
            cbCuentaDestinoTrans.DataSource = null;
            cbCuentaDestinoTrans.Items.Clear();
            cbCuentaDestinoTrans.DataSource = dlog.BO_EjecutoDataTable(QUERY);
            cbCuentaDestinoTrans.DisplayMember = "NRO_CUENTA";
            cbCuentaDestinoTrans.ValueMember = "ID";
            cbCuentaDestinoTrans.SelectedItem = 0;
        }

        private void cbProvTrans_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void buscarCuentasBancarias(int PROVEEDOR)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();

            try
            {
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
                    string BUSCO = string.Empty;

                    if (PROVEEDOR == 0)
                    {
                        BUSCO = "SELECT C.ID, B.NOMBRE, T.TIPO, C.NRO_CUENTA, C.BANCO, C.TIPO_CUENTA, C.CBU, C.SUCURSAL, P.RAZON_SOCIAL, C.PROVEEDOR ";
                        BUSCO += "FROM CUENTAS_BANCARIAS C, BANCOS B, TIPO_CUENTA_BANCARIA T, PROVEEDORES P WHERE C.BANCO = B.ID AND C.TIPO_CUENTA = T.ID AND C.FE_BAJA IS NULL AND C.PROVEEDOR = P.ID;";
                    }
                    else
                    {
                        BUSCO = "SELECT C.ID, B.NOMBRE, T.TIPO, C.NRO_CUENTA, C.BANCO, C.TIPO_CUENTA, C.CBU, C.SUCURSAL, P.RAZON_SOCIAL, C.PROVEEDOR ";
                        BUSCO += "FROM CUENTAS_BANCARIAS C, BANCOS B, TIPO_CUENTA_BANCARIA T, PROVEEDORES P WHERE C.BANCO = B.ID AND C.TIPO_CUENTA = T.ID AND C.FE_BAJA IS NULL AND C.PROVEEDOR = P.ID ";
                        BUSCO += "AND C.PROVEEDOR = " + PROVEEDOR + ";";
                    }

                    FbCommand cmd = new FbCommand(BUSCO, connection, transaction);
                    cmd.CommandText = BUSCO;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        mostrarCuentasBancarias(reader);
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
                MessageBox.Show(ex.ToString());
            }
        }

        private void mostrarCuentasBancarias(FbDataReader reader)
        {
            lvCuentasBancarias.Items.Clear();
            lvCuentasBancarias.Columns.Clear();
            lvCuentasBancarias.BeginUpdate();

            if (lvProveedores.Columns.Count == 0)
            {
                lvCuentasBancarias.Columns.Add("ID");
                lvCuentasBancarias.Columns.Add("BANCO");
                lvCuentasBancarias.Columns.Add("TIPO");
                lvCuentasBancarias.Columns.Add("CUENTA");
                lvCuentasBancarias.Columns.Add("ID_BANCO");
                lvCuentasBancarias.Columns.Add("ID_TIPO");
                lvCuentasBancarias.Columns.Add("CBU");
                lvCuentasBancarias.Columns.Add("SUCURSAL");
                lvCuentasBancarias.Columns.Add("PROVEEDOR");
                lvCuentasBancarias.Columns.Add("PROVEEDOR_ID");
            }
            do
            {
                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("ID")));
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NOMBRE")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TIPO")).Trim().ToUpper());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NRO_CUENTA")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("BANCO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TIPO_CUENTA")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("CBU")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("SUCURSAL")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("RAZON_SOCIAL")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("PROVEEDOR")).Trim());
                lvCuentasBancarias.Items.Add(listItem);
            }

            while (reader.Read());
            lvCuentasBancarias.EndUpdate();
            lvCuentasBancarias.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvCuentasBancarias.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvCuentasBancarias.Columns[4].Width = 0;
            lvCuentasBancarias.Columns[5].Width = 0;
            lvCuentasBancarias.Columns[0].Width = 0;
            lvCuentasBancarias.Columns[9].Width = 0;
        }

        private void cargarDatosModificarCuenta()
        {
            tbAgregarCuenta.Text = lvCuentasBancarias.SelectedItems[0].SubItems[3].Text;
            cbBancosEnCuentas.SelectedValue = lvCuentasBancarias.SelectedItems[0].SubItems[4].Text;
            cbTipoCuenta.SelectedValue = lvCuentasBancarias.SelectedItems[0].SubItems[5].Text;
            lbIdCuenta.Text = lvCuentasBancarias.SelectedItems[0].SubItems[0].Text;
            tbCBUCuentaBancaria.Text = lvCuentasBancarias.SelectedItems[0].SubItems[6].Text;
            tbSucursalCuentaBancaria.Text = lvCuentasBancarias.SelectedItems[0].SubItems[7].Text;
            cbProveedorCtaBancaria.SelectedValue = lvCuentasBancarias.SelectedItems[0].SubItems[9].Text;
        }

        private void lvCuentasBancarias_Click(object sender, EventArgs e)
        {
            btnAgregarCuenta.Enabled = false;
            btnModificarCuenta.Enabled = true;
            btnEliminarCuenta.Enabled = true;
            cargarDatosModificarCuenta();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (tbBuscar.Text == "")
            {
                MessageBox.Show("INGRESAR UNA CONDICION DE BUSQUEDA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                buscarProveedores(tbBuscar.Text.Trim(), "MOSTRAR");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;

            if (tbRazonSocial.Text == "")
            {
                MessageBox.Show("INGRESAR UNA RAZON SOCIAL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                int ID = int.Parse(lvProveedores.SelectedItems[0].SubItems[9].Text);

                string RAZON_SOCIAL = null;
                string EMAIL = null;
                string DOMICILIO = null;
                string TELEFONO = null;
                string WEB = null;
                string CONTACTO = null;
                string CUIT = null;
                string CUENTA = null;
                string USR_MOD = VGlobales.vp_username;
                DateTime Hoy = DateTime.Today;
                string FE_MOD = Hoy.ToString("dd/MM/yyyy");
                string CBU = tbCBU.Text.Trim();
                string TIPO = cbTipoProveedor.SelectedValue.ToString();
                string TIPO_DE_CUENTA = cbTipoDeCuenta.SelectedValue.ToString();

                if (TIPO_DE_CUENTA == "4")
                    TIPO_DE_CUENTA = "A";

                RAZON_SOCIAL = (tbRazonSocial.Text.Trim() != "") ? tbRazonSocial.Text.Trim() : null;
                EMAIL = (tbEmail.Text.Trim() != "") ? tbEmail.Text.Trim() : null;
                DOMICILIO = (tbDomicilio.Text.Trim() != "") ? tbDomicilio.Text.Trim() : null;
                TELEFONO = (tbTelefono.Text.Trim() != "") ? tbTelefono.Text.Trim() : null;
                WEB = (tbWeb.Text.Trim() != "") ? tbWeb.Text.Trim() : null;
                CONTACTO = (tbContacto.Text.Trim() != "") ? tbContacto.Text.Trim() : null;
                CUIT = (tbCuit.Text.Trim() != "") ? tbCuit.Text.Trim() : null;
                CBU = (tbEmail.Text.Trim() != "") ? tbEmail.Text.Trim() : null;
                CUENTA = (tbCuenta.Text.Trim() != "") ? tbCuenta.Text.Trim() : null;

                try
                {
                    BO_COMPRAS.modificaUnProveedor(ID, RAZON_SOCIAL, EMAIL, DOMICILIO, TELEFONO, WEB, CONTACTO, CUIT, CUENTA, USR_MOD, FE_MOD, CBU, TIPO, TIPO_DE_CUENTA);
                    MessageBox.Show("PROVEEDOR MODIFICADO CORRECTAMENTE");
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    limpiarFormulario();
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO MODIFICAR EL PROVEEDOR\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            limpiarFormulario();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void lvProveedores_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            btnEliminarProveedor.Enabled = true;
            tbRazonSocial.Text = lvProveedores.SelectedItems[0].SubItems[0].Text;
            tbEmail.Text = lvProveedores.SelectedItems[0].SubItems[1].Text;
            tbDomicilio.Text = lvProveedores.SelectedItems[0].SubItems[2].Text;
            tbTelefono.Text = lvProveedores.SelectedItems[0].SubItems[3].Text;
            tbWeb.Text = lvProveedores.SelectedItems[0].SubItems[4].Text;
            tbContacto.Text = lvProveedores.SelectedItems[0].SubItems[5].Text;
            tbCuit.Text = lvProveedores.SelectedItems[0].SubItems[6].Text;
            tbCuenta.Text = lvProveedores.SelectedItems[0].SubItems[7].Text;
            tbCBU.Text = lvProveedores.SelectedItems[0].SubItems[8].Text;
            cbTipoDeCuenta.SelectedValue = int.Parse(lvProveedores.SelectedItems[0].SubItems[11].Text);
        }

        private bool checkProveedor(string RAZON_SOCIAL)
        {
            string QUERY = "SELECT RAZON_SOCIAL FROM PROVEEDORES WHERE RAZON_SOCIAL = '" + RAZON_SOCIAL + "' AND FE_BAJA IS NULL;";
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

        private bool checkCuenta(string CUENTA)
        {
            string QUERY = "SELECT CUENTA FROM PROVEEDORES WHERE CUENTA = '" + CUENTA + "' AND FE_BAJA IS NULL;";
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (tbRazonSocial.Text == "")
            {
                MessageBox.Show("INGRESAR UNA RAZON SOCIAL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (checkProveedor(tbRazonSocial.Text.Trim()) == true)
            {
                MessageBox.Show("YA EXISTE UN PROVEEDOR CON LA RAZON SOCIAL INGRESADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                string RAZON_SOCIAL = null;
                string EMAIL = null;
                string DOMICILIO = null;
                string TELEFONO = null;
                string WEB = null;
                string CONTACTO = null;
                string CUIT = null;
                string CUENTA = tbCuenta.Text.Trim();
                string USR_ALTA = VGlobales.vp_username;
                DateTime Hoy = DateTime.Today;
                string FE_ALTA = Hoy.ToString("dd/MM/yyyy");
                string CBU = tbCBU.Text.Trim();
                string TIPO = null;
                string TIPO_DE_CUENTA = cbTipoDeCuenta.SelectedValue.ToString();

                if (TIPO_DE_CUENTA == "4")
                    TIPO_DE_CUENTA = "A";

                RAZON_SOCIAL = (tbRazonSocial.Text.Trim() != "") ? tbRazonSocial.Text.Trim() : null;
                EMAIL = (tbEmail.Text.Trim() != "") ? tbEmail.Text.Trim() : null;
                DOMICILIO = (tbDomicilio.Text.Trim() != "") ? tbDomicilio.Text.Trim() : null;
                TELEFONO = (tbTelefono.Text.Trim() != "") ? tbTelefono.Text.Trim() : null;
                WEB = (tbWeb.Text.Trim() != "") ? tbWeb.Text.Trim() : null;
                CONTACTO = (tbContacto.Text.Trim() != "") ? tbContacto.Text.Trim() : null;
                CUIT = (tbCuit.Text.Trim() != "") ? tbCuit.Text.Trim() : null;
                CBU = (tbEmail.Text.Trim() != "") ? tbEmail.Text.Trim() : null;

                if (cbTipoProveedor.Text != "")
                {
                    TIPO = cbTipoProveedor.SelectedValue.ToString();
                }

                try
                {
                    BO_COMPRAS.guardarUnProveedor(RAZON_SOCIAL, EMAIL, DOMICILIO, TELEFONO, WEB, CONTACTO, CUIT, CUENTA, USR_ALTA, FE_ALTA, CBU, TIPO, TIPO_DE_CUENTA);
                    MessageBox.Show("PROVEEDOR CARGADO CORRECTAMENTE");
                    limpiarFormulario();
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO GUARDAR EL PROVEEDOR\n" + error, "ERROR");
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

        private void listadoExcelProveedores(DataSet ds, string path)
        {
            string data = null;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add();
            xlWorkSheet = xlWorkBook.Worksheets[1];

            xlWorkSheet.Range["A1:Z1"].Font.Bold = true;
            //ID, RAZON_SOCIAL, EMAIL, DOMICILIO, TELEFONO, WEB, CONTACTO, CUIT, CUENTA, USR_ALTA, FE_ALTA, USR_BAJA, FE_BAJA, USR_MOD, FE_MOD, CBU, TIPO, TIPO_DE_CUENTA
            xlWorkSheet.Cells[1, 1] = "ID";
            xlWorkSheet.Cells[1, 2] = "RAZON SOCIAL";
            xlWorkSheet.Cells[1, 3] = "EMAIL";
            xlWorkSheet.Cells[1, 4] = "DOMICILIO";
            xlWorkSheet.Cells[1, 5] = "TELEFONO";
            xlWorkSheet.Cells[1, 6] = "SITIO WEB";
            xlWorkSheet.Cells[1, 7] = "CONTACTO";
            xlWorkSheet.Cells[1, 8] = "CUIT";
            xlWorkSheet.Cells[1, 9] = "CUENTA";
            xlWorkSheet.Cells[1, 10] = "USR_ALTA";
            xlWorkSheet.Cells[1, 11] = "FE_ALTA";
            xlWorkSheet.Cells[1, 12] = "USR_BAJA";
            xlWorkSheet.Cells[1, 13] = "FE_BAJA";
            xlWorkSheet.Cells[1, 14] = "USR_MOD";
            xlWorkSheet.Cells[1, 15] = "FE_MOD";
            xlWorkSheet.Cells[1, 16] = "CBU";
            xlWorkSheet.Cells[1, 17] = "TIPO PROVEEDOR";
            xlWorkSheet.Cells[1, 18] = "TIPO CUENTA";

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                    xlWorkSheet.Columns[j + 1].AutoFit();
                }
            }

            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private void btnListadoProvXLS_Click(object sender, EventArgs e)
        {
            buscarProveedores("TODOS", "EXCEL");
        }

        private void btnModificarTipo_Click(object sender, EventArgs e)
        {
            if (tbTipo.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO TIPO");
            }
            else
            {
                try
                {
                    BO_COMPRAS.modificarTipoArticulo(Convert.ToInt16(cbTiposExistentes.SelectedValue), tbTipo.Text.Trim());
                    MessageBox.Show("SE MODIFICO EL TIPO");
                    comboTiposExistentes();
                    tbTipo.Text = "";
                    btnModificarTipo.Enabled = false;
                    comboTipoProveedor();
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO MODIFICAR EL TIPO\n" + error);
                }
            }
        }

        private void btnNuevoTipo_Click(object sender, EventArgs e)
        {
            if (tbTipo.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO TIPO");
            }
            else if (existe.check("TIPOS_ARTICULOS", "DETALLE", tbTipo.Text.Trim()))
            {
                MessageBox.Show("EL TIPO INGRESADO YA EXISTE");
            }
            else
            {
                try
                {
                    BO_COMPRAS.nuevoTipoArticulo(tbTipo.Text);
                    MessageBox.Show("SE GUARDO EL NUEVO TIPO");
                    comboTiposExistentes();
                    tbTipo.Text = "";
                    btnModificarTipo.Enabled = false;
                    comboTipoProveedor();
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO GUARDAR EL TIPO\n" + error);
                }
            }
        }

        private void cbTiposExistentes_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            tbTipo.Text = cbTiposExistentes.Text;
            btnModificarTipo.Enabled = true;
        }

        private void btnAgregarPdfRetencion_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF (*.PDF)|*.PDF|" + "All files (*.*)|*.*";
            ofd.Title = "Seleccionar Archivo";
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                lbPdfRetencion.Text = ofd.FileName;
            }
        }

        private void cargarRetencion(string NUM_FACTURA, string ID_FACTURA)
        {
            if (tbCertRetencion.Text == "")
            {
                MessageBox.Show("INGRESAR UN NUMERO DE CERTIFICADO", "ERROR");
            }
            else if (tbImporteRetencion.Text == "")
            {
                MessageBox.Show("INGRESAR UN IMPORTE", "ERROR");
            }
            else if (tbRetencionAplicada.Text == "")
            {
                MessageBox.Show("INGRESAR UN IMPORTE DE RETENCION", "ERROR");
            }
            else if (lbPdfRetencion.Text == "ARCHIVO PDF NO CARGADO")
            {
                MessageBox.Show("SELECCIONAR UN ARCHIVO PDF", "ERROR");
            }
            else
            {
                try
                {
                    string NUM_CERT = tbCertRetencion.Text;
                    string FECHA = dpFechaRetencion.Text;
                    decimal IMPORTE = Convert.ToDecimal(tbImporteRetencion.Text.Trim());
                    decimal RETENCION = Convert.ToDecimal(tbRetencionAplicada.Text.Trim());
                    int IMPUESTO = int.Parse(cbImpuestoRetencion.SelectedValue.ToString());
                    int REGIMEN = int.Parse(cbRegimenRetencion.SelectedValue.ToString());
                    int OP = 0;
                    string US_ALTA = VGlobales.vp_username;
                    string FE_ALTA = DateTime.Today.ToShortDateString();
                    BO_COMPRAS.altaRetencion(NUM_CERT, FECHA, IMPORTE, RETENCION, IMPUESTO, REGIMEN, OP, US_ALTA, FE_ALTA);
                    string ARCHIVO_ORIGEN = lbPdfRetencion.Text;
                    string ARCHIVO_DESTINO = "\\\\192.168.1.6\\ComprasPDF\\RETENCION_" + ID_FACTURA + ".PDF";
                    File.Copy(ARCHIVO_ORIGEN, ARCHIVO_DESTINO);
                    MessageBox.Show("SE CARGO LA RETENCION CORRECTAMENTE", "LISTO!");

                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO CARGAR LA RETENCION\n" + error, "ERROR");
                }
            }
        }

        private void btnGuardarRetencion_Click(object sender, EventArgs e)
        {
            string NUM_FACTURA = lvFacturas.SelectedItems[0].SubItems[2].Text;
            string ID_FACTURA = lvFacturas.SelectedItems[0].SubItems[0].Text;
            cargarRetencion(NUM_FACTURA, ID_FACTURA);
        }

        private void calcularRetencion(decimal IMPORTE, int REGIMEN)
        {
            /*string QUERY = "SELECT * FROM RETENCIONES_CONFIG WHERE REGIMEN = " + REGIMEN;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            
            decimal MINIMO = Convert.ToDecimal(foundRows[0][2].ToString());
            
            int GANANCIAS = int.Parse(foundRows[0][3].ToString());

            string IVA = "1," + cbIVA.SelectedItem.ToString().Replace("IVA ", "");
            
            decimal IVA_FINAL = decimal.Parse(IVA);

            decimal IVA_IMPORTE = Math.Round(IMPORTE / IVA_FINAL, 2);

            decimal NETO = IMPORTE - IVA_IMPORTE;

            decimal MONTO = IVA_IMPORTE - MINIMO;
            
            decimal RET_GAN = Math.Round(MONTO * GANANCIAS / 100, 2);

            tbRetencionCalculada.Text = RET_GAN.ToString();*/
        }

        private void tbImporte_Leave(object sender, EventArgs e)
        {
            if (tbImporte.Text!="")
                IMPORTE_TOTAL = decimal.Parse(tbImporte.Text);

            /*if (cbTipoComprobante.SelectedValue.ToString() == "4" && tbImporte.Text != "")
            {
                decimal IMPORTE = Convert.ToDecimal(tbImporte.Text);
                int REGIMEN = int.Parse(cbRegimenFactura.SelectedValue.ToString());
                calcularRetencion(IMPORTE, REGIMEN);
            }
            else if (cbTipoComprobante.SelectedValue.ToString() != "4")
            {
                tbRetencionCalculada.Text = "";
            }*/
        }

        private void cbRegimenFactura_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /*if (cbTipoComprobante.SelectedValue.ToString() == "4" && tbImporte.Text != "")
            {
                decimal IMPORTE = Convert.ToDecimal(tbImporte.Text);
                int REGIMEN = int.Parse(cbRegimenFactura.SelectedValue.ToString());
                calcularRetencion(IMPORTE, REGIMEN);
            }
            else if (cbTipoComprobante.SelectedValue.ToString() != "4")
            {
                tbRetencionCalculada.Text = "";
            }*/
        }

        private void cbIVA_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /*if (cbTipoComprobante.SelectedValue.ToString() == "4" && tbImporte.Text != "")
            {
                decimal IMPORTE = Convert.ToDecimal(tbImporte.Text);
                int REGIMEN = int.Parse(cbRegimenFactura.SelectedValue.ToString());
                calcularRetencion(IMPORTE, REGIMEN);
            }
            else if (cbTipoComprobante.SelectedValue.ToString() != "4")
            {
                tbRetencionCalculada.Text = "";
            }*/
        }

        private void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA ELIMINAR EL PROVEEDOR SELECCIONADO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int ID_PROVEEDOR = int.Parse(lvProveedores.SelectedItems[0].SubItems[9].Text);
                    string USR_BAJA = VGlobales.vp_username;
                    string FE_BAJA = DateTime.Today.ToShortDateString();
                    BO_COMPRAS.eliminaUnProveedor(ID_PROVEEDOR, USR_BAJA, FE_BAJA);
                    lvProveedores.Clear();
                    limpiarFormulario();
                    button1.Enabled = true;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    btnEliminarProveedor.Enabled = false;
                    MessageBox.Show("SE ELIMINÓ EL PROVEEDOR", "LISTO!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO ELIMINAR EL PROVEEDOR\n" + error, "ERROR");
                }
            }
        }

        private void btnAceptarCheques_Click_1(object sender, EventArgs e)
        {
            if (tbSerieCheque.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO SERIE", "ERROR");
                tbSerie.Focus();
            }
            if (tbSerieCheque.Text.Length > 1)
            {
                MessageBox.Show("EL CAMPO SERIE DEBE TENER SOLO UNA LETRA", "ERROR");
                tbSerie.Focus();
            }
            else if (tbDesdeCheque.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO Nº CHEQUE DESDE", "ERROR");
                tbDesdeCheque.Focus();
            }
            else if (tbHastaCheque.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO Nº CHEQUE HASTA", "ERROR");
                tbHastaCheque.Focus();
            }
            else if (checkChequeras(int.Parse(tbDesdeCheque.Text), int.Parse(tbHastaCheque.Text), int.Parse(cbBancosChequeras.SelectedValue.ToString()), tbSerieCheque.Text.Trim()) == true)
            {
                MessageBox.Show("ALGUNOS DE LOS CHEQUES INGRESADOS YA SE ENCUENTRAN CARGADOS", "ERROR");
            }
            else
            {
                try
                {
                    int BANCO = int.Parse(cbBancosChequeras.SelectedValue.ToString());
                    string SERIE = tbSerieCheque.Text.Trim();
                    int DESDE = int.Parse(tbDesdeCheque.Text.Trim());
                    int HASTA = int.Parse(tbHastaCheque.Text.Trim());
                    int TOTAL = HASTA - DESDE;
                    string TIPO = cbTipoCheque.Text;

                    if (DESDE > HASTA)
                    {
                        MessageBox.Show("EL CAMPO HASTA NO PUEDE SER MENOR QUE EL CAMPO DESDE", "ERROR");
                    }
                    else
                    {
                        pbChequeras.Visible = true;
                        pbChequeras.Minimum = 0;
                        pbChequeras.Maximum = TOTAL;
                        pbChequeras.Value = 1;
                        pbChequeras.Step = 1;

                        for (int i = DESDE; i <= HASTA; i++)
                        {
                            BO_COMPRAS.guardarChequeras(BANCO, SERIE, i, "SIN CONFECCIONAR", TIPO);
                            pbChequeras.PerformStep();
                        }

                        MessageBox.Show("SE CARGÓ LA CHEQUERA CORRECTAMENTE", "LISTO!");
                        pbChequeras.Visible = false;
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO GUARDAR EL CHEQUE\n" + error, "ERROR");
                }
            }
        }

        private void btnEliminarBanco_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA ELIMINAR EL BANCO SELECCIONADO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int ID = int.Parse(idBancoModificar.Text);
                    string US_BAJA = VGlobales.vp_username;
                    string FE_BAJA = DateTime.Today.ToShortDateString();
                    BO_COMPRAS.bajaBanco(ID, US_BAJA, FE_BAJA);
                    MessageBox.Show("SE DIO DE BAJA EL BANCO SELECCIONADO", "LISTO!");
                    comboBancosChequeras();
                    tbBancoNuevo.Text = "";
                    idBancoModificar.Text = "";
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO DAR DE BAJA AL BANCO SELECCIONADO\n" + error, "ERROR");
                }
            }
        }

        private void btnNuevoBanco_Click_1(object sender, EventArgs e)
        {
            if (tbBancoNuevo.Text.Trim() == "")
            {
                MessageBox.Show("EL CAMPO BANCO ES NECESARIO", "ERROR");
            }
            else if (checkNombreBanco(tbBancoNuevo.Text.Trim()) == true)
            {
                MessageBox.Show("YA EXISTE UN BANCO CON EL MISMO NOMBRE", "ERROR");
            }
            else
            {
                try
                {
                    string BANCO = tbBancoNuevo.Text.Trim();
                    string US_ALTA = VGlobales.vp_username;
                    string FE_ALTA = DateTime.Today.ToShortDateString();
                    BO_COMPRAS.nuevoBanco(BANCO, US_ALTA, FE_ALTA);
                    MessageBox.Show("SE CREO EL REGISTRO CORRECTAMENTE", "LISTO");
                    tbBancoNuevo.Text = "";
                    comboBancosChequeras();
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO GUARDAR EL REGISTRO\n" + error, "ERROR");
                }
            }
        }

        private void btnModificarBanco_Click_1(object sender, EventArgs e)
        {
            if (tbBancoNuevo.Text == "")
            {
                MessageBox.Show("EL CAMPO BANCO ES NECESARIO", "ERROR");
            }
            else
            {
                try
                {
                    string BANCO = tbBancoNuevo.Text.Trim();
                    int ID = int.Parse(idBancoModificar.Text);
                    BO_COMPRAS.modificarBanco(ID, BANCO);
                    MessageBox.Show("SE MODIFICÓ EL REGISTRO CORRECTAMENTE", "LISTO");
                    tbBancoNuevo.Text = "";
                    comboBancosChequeras();
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO MODIFICAR EL REGISTRO\n" + error, "ERROR");
                }
            }
        }

        private void cbModicarBanco_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            int ID = int.Parse(cbModicarBanco.SelectedValue.ToString());
            llenarDatosBanco(ID);
        }

        private void btnAgregarCuenta_Click_1(object sender, EventArgs e)
        {
            if (tbAgregarCuenta.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO NUMERO CUENTA", "ERROR");
            }
            else
            {
                try
                {
                    int BANCO = int.Parse(cbBancosEnCuentas.SelectedValue.ToString());
                    string CUENTA = tbAgregarCuenta.Text.Trim();
                    int TIPO = int.Parse(cbTipoCuenta.SelectedValue.ToString());
                    string US_ALTA = VGlobales.vp_username;
                    string FE_ALTA = DateTime.Today.ToShortDateString();
                    string CBU = tbCBUCuentaBancaria.Text.Trim();
                    string SUCURSAL = tbSucursalCuentaBancaria.Text.Trim();
                    int PROVEEDOR = int.Parse(cbProveedorCtaBancaria.SelectedValue.ToString());
                    BO_COMPRAS.altaCuentaBancaria(BANCO, CUENTA, TIPO, US_ALTA, FE_ALTA, CBU, SUCURSAL, PROVEEDOR);
                    MessageBox.Show("SE GUARDO LA CUENTA CORRECTAMENTE", "LISTO!");
                    limpiarCuentasBancarias();
                    buscarCuentasBancarias(0);
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO GUARDAR LA CUENTA\n" + error, "ERROR");
                }
            }
        }

        private void btnModificarCuenta_Click_1(object sender, EventArgs e)
        {
            if (tbAgregarCuenta.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO NUMERO CUENTA", "ERROR");
            }
            else
            {
                try
                {
                    int BANCO = int.Parse(cbBancosEnCuentas.SelectedValue.ToString());
                    string CUENTA = tbAgregarCuenta.Text.Trim();
                    int TIPO = int.Parse(cbTipoCuenta.SelectedValue.ToString());
                    int ID = int.Parse(lbIdCuenta.Text);
                    string CBU = tbCBUCuentaBancaria.Text.Trim();
                    string SUCURSAL = tbSucursalCuentaBancaria.Text.Trim();
                    int PROVEEDOR = int.Parse(cbProveedorCtaBancaria.SelectedValue.ToString());
                    BO_COMPRAS.modificarCuentaBancaria(ID, BANCO, CUENTA, TIPO, CBU, SUCURSAL, PROVEEDOR);
                    MessageBox.Show("SE MODIFICO LA CUENTA CORRECTAMENTE", "LISTO!");
                    limpiarCuentasBancarias();
                    buscarCuentasBancarias(0);
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO MODIFICAR LA CUENTA\n" + error, "ERROR");
                }
            }
        }

        private void btnEliminarCuenta_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA GUARDAR LA ORDEN DE PAGO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int ID = int.Parse(lbIdCuenta.Text);
                    string US_BAJA = VGlobales.vp_username;
                    string FE_BAJA = DateTime.Today.ToShortDateString();
                    BO_COMPRAS.bajaCuentaBancaria(ID, US_BAJA, FE_BAJA);
                    limpiarCuentasBancarias();
                    buscarCuentasBancarias(0);
                    MessageBox.Show("NO ELIMINO LA CUENTA", "LISTO");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO ELIMINAR LA CUENTA\n" + error, "ERROR");
                }
            }
        }

        private void btnCancelarEdicionCuenta_Click_1(object sender, EventArgs e)
        {
            limpiarCuentasBancarias();
            buscarCuentasBancarias(0);
        }

        private void btnFiltrarCuentasBancarias_Click_1(object sender, EventArgs e)
        {
            int PROVEEDOR = int.Parse(cbProveedoresFiltro.SelectedValue.ToString());
            buscarCuentasBancarias(PROVEEDOR);
        }

        private void iMPRIMIRCHEQUEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvBuscarOP.SelectedItems.Count == 0)
            {
                MessageBox.Show("NO SE SELECCINO NINGUN CHEQUE", "ERROR");
            }
            else if (lvBuscarOP.SelectedItems.Count > 1)
            {
                MessageBox.Show("SELECCIONAR SOLO UN CHEQUE PARA IMPRIMIR", "ERROR");
            }
            else
            {
                string NRO_CHEQUE = lvBuscarOP.SelectedItems[0].SubItems[6].Text;
                imprimirCheque();
                System.Diagnostics.Process.Start(@"\\192.168.1.6\Tesoreria\CHEQUES\CHEQUE - " + NRO_CHEQUE + ".PDF");
            }
        }

        private void generarExcel(DataSet ds)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivo XLS|*.xls";
            saveFileDialog1.Title = "Guardar Listado";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                excel(ds, saveFileDialog1.FileName);
                DialogResult result = MessageBox.Show("LISTADO GENERADO CORRECTAMENTE \n\n ¿ABRIR EL ARCHIVO?", "LISTO!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    OpenMicrosoftExcel(saveFileDialog1.FileName);
                }
            }
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            buscarFactura("EXCEL");
        }

        public void excel(DataSet ds, string path)
        {
            string data = null;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add();
            xlWorkSheet = xlWorkBook.Worksheets[1];
            xlWorkSheet.Range["A1:Z1"].Font.Bold = true;
            xlWorkSheet.Cells[1, 1] = "FECHA CARGA";
            xlWorkSheet.Cells[1, 2] = "CUENTA CONTABLE";
            xlWorkSheet.Cells[1, 3] = "NUMERO";
            xlWorkSheet.Cells[1, 4] = "FECHA FACTURA";
            xlWorkSheet.Cells[1, 5] = "IMPORTE";
            xlWorkSheet.Cells[1, 6] = "OBSERVACIONES";
            xlWorkSheet.Cells[1, 7] = "SECTOR";
            xlWorkSheet.Cells[1, 8] = "OP";
            xlWorkSheet.Cells[1, 9] = "REMITO";
            xlWorkSheet.Cells[1, 10] = "RETENCION";
            xlWorkSheet.Cells[1, 11] = "TIPO";
            xlWorkSheet.Cells[1, 12] = "CUIT";
            xlWorkSheet.Cells[1, 13] = "DES%";

            Cursor = Cursors.WaitCursor;

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                    xlWorkSheet.Columns[j + 1].AutoFit();
                    xlWorkSheet.Columns[1].EntireColumn.NumberFormat = "DD/MM/AAAA";
                    xlWorkSheet.Columns[4].EntireColumn.NumberFormat = "DD/MM/AAAA";
                    //xlWorkSheet.Columns[5].EntireColumn.NumberFormat = "#,##0,00";
                }
            }

            Cursor = Cursors.Default;

            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        /*private void btnListadoBusqueda_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivo PDF|*.pdf";
            saveFileDialog1.Title = "Guardar Listado";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                conString cs = new conString();
                string connectionString = cs.get();
                DataSet BUSQUEDA = new DataSet();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        FbTransaction transaction = connection.BeginTransaction();
                        FbCommand cmd = new FbCommand(BUSCO_QUERY, connection, transaction);
                        cmd.CommandText = BUSCO_QUERY;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
                        FbDataAdapter da = new FbDataAdapter(cmd);
                        da.Fill(BUSQUEDA);
                        imprimirBusqueda(BUSQUEDA, saveFileDialog1.FileName);
                        DialogResult result = MessageBox.Show("LISTADO GENERADO CORRECTAMENTE \n\n ¿ABRIR EL ARCHIVO?", "LISTO!", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            OpenAdobeAcrobat(saveFileDialog1.FileName);
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO IMPRIMIR EL LISTADO\n" + error);
                    }
                }
            }
        }*/

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            int SELECTED_ROWS = dgArticulos.SelectedRows.Count;
            string CONFIRM = "";
            string EXITO = "";
            string FALLA = "";

            if (SELECTED_ROWS == 1)
            {
                CONFIRM = "¿CONFIRMA ELIMINAR EL ARTICULO SELECCIONADO?";
                EXITO = "EL ARTICULO SELECCIONADO FUE ELIMINADO";
                FALLA = "NO SE PUDO ELIMINAR EL ARTICULO SELECCIONADO";
            }

            if (SELECTED_ROWS > 1)
            {
                CONFIRM = "¿CONFIRMA ELIMINAR LOS ARTICULOS SELECCIONADOS?";
                EXITO = "LOS ARTICULOS SELECCIONADOS FUERON ELIMINADOS";
                FALLA = "NO SE PUDIERON ELIMINAR LOS ARTICULOS SELECCIONADOS";
            }

            if (MessageBox.Show(CONFIRM, "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    btnEliminarArticulo.Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    string ID = "";
                    string FE_BAJA = DateTime.Today.ToShortDateString();

                    foreach (DataGridViewRow row in dgArticulos.SelectedRows)
                    {
                        if (lbID.Text == "ID_FACTURA")
                        {
                            ID = row.Index.ToString();
                            dgArticulos.Rows.RemoveAt(int.Parse(ID));
                        }
                        else
                        {
                            ID = row.Index.ToString();
                            dgArticulos.Rows.RemoveAt(int.Parse(ID));
                            BO_COMPRAS.bajaArticulo(ID_ARTICULO.ToString(), FE_BAJA);
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(FALLA, "ERROR");
                }

                btnEliminarArticulo.Enabled = true;

                if (lbID.Text != "ID_FACTURA")
                {
                    buscarArticulos(int.Parse(lbID.Text));                        
                }
                
                Cursor = Cursors.Default;
            }
        }

        private void dgArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int INDEX = dgArticulos.CurrentCell.RowIndex;
            lbIndex.Text = INDEX.ToString();
            tbCantidad.Text = dgArticulos.SelectedCells[0].Value.ToString();
            tbDetalle.Text = dgArticulos.SelectedCells[1].Value.ToString();
            tbValor.Text = dgArticulos.SelectedCells[2].Value.ToString();
            tbSerie.Text = dgArticulos.SelectedCells[5].Value.ToString();

            if (lbID.Text != "ID_FACTURA")
                ID_ARTICULO = int.Parse(dgArticulos.SelectedCells[8].Value.ToString());
            else
                ID_ARTICULO = int.Parse(dgArticulos.CurrentCell.RowIndex.ToString());

            if (dgArticulos.SelectedCells[3].Value.ToString().Contains("%"))
            {
                tbDescuento.Text = dgArticulos.SelectedCells[3].Value.ToString().Replace("%", "");
                cbDescuento.SelectedIndex = 0;
            }

            if (dgArticulos.SelectedCells[3].Value.ToString().Contains("$"))
            {
                tbDescuento.Text = dgArticulos.SelectedCells[3].Value.ToString().Replace("$", "");
                cbDescuento.SelectedIndex = 1;
            }

            cbTipoArticulo.SelectedValue = dgArticulos.SelectedCells[7].Value;
        }

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            limpiarArticulo();
        }

        private void btnContabilizar_Click(object sender, EventArgs e)
        {

        }

        private void grupoFacturas(object sender)
        {
            string VALOR = "";

            if (sender == lvFacturas)
            {
                VALOR = lvFacturas.SelectedItems[0].SubItems[8].Text;

                if (VALOR == "RENDICION" || VALOR == "2" || VALOR == "9" || VALOR == "12")
                    BuscarFacturasHijas(int.Parse(VALOR));
            }

            if (sender == cbTipoComprobante)
            {
                VALOR = cbTipoComprobante.SelectedValue.ToString();

                if (VALOR == "RENDICION" || VALOR == "2" || VALOR == "9" || VALOR == "12")
                {
                    comboProveedores(cbProveedorFactura);
                    comboTipoComprobante(cbTipoFactura);
                    gbFacturas.Visible = true;
                    grupoArticulos.Visible = false;                        
                }
                else
                {
                    gbFacturas.Visible = false;
                    grupoArticulos.Visible = true;
                }
            }

            if (sender == cbProveedores)
            {
                VALOR = cbProveedores.SelectedValue.ToString();
            } 
        }
        
        private void lvFacturas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (lvFacturas.SelectedItems.Count != 0)
                {
                    btnGuardarFactura.Enabled = false;
                    btnModFactura.Enabled = true;
                    int ID = Convert.ToInt16(lvFacturas.SelectedItems[0].SubItems[0].Text);
                    llenarDatosFactura(ID);
                    grupoFacturas(sender);
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                if (lvFacturas.SelectedItems.Count != 0)
                {
                    if (lvFacturas.FocusedItem.Bounds.Contains(e.Location) == true)
                    {
                        if (lvFacturas.SelectedItems[0].SubItems[12].Text != "")
                        {
                            aCTIVRToolStripMenuItem.Visible = true;
                            aNULARToolStripMenuItem.Visible = false;

                        }
                        else
                        {
                            aCTIVRToolStripMenuItem.Visible = false;
                            aNULARToolStripMenuItem.Visible = true;
                        }

                        cmFactura.Show(Cursor.Position);
                    }
                }
            }
        }

        private void pressF1(KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                buscarFactura("BUSCAR");
            }
        }

        private void tbBuscarFactura_KeyUp(object sender, KeyEventArgs e)
        {
            pressF1(e);
        }

        private void cbTipoBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            pressF1(e);
        }

        private void tbBuscarNumeroSolicitud_KeyUp(object sender, KeyEventArgs e)
        {
            pressF1(e);
        }

        private void tbBuscarNumeroFactura_KeyUp(object sender, KeyEventArgs e)
        {
            pressF1(e);
        }

        private void cbProveedores_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //grupoFacturas(sender);
        } 

        private void buscarPlanDeCuentas(string CUENTA)
        {
            try
            {
                conString cs = new conString();
                string connectionString = cs.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string busco = "SELECT ID, NUMEROCTA, NOMBRECTA FROM CUENTAS WHERE NUMEROCTA = " + CUENTA + " ORDER BY NUMEROCTA ASC;";
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
                            mostrarResultadosPlanCuentas(reader);
                        }
                        else
                        {
                            MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void mostrarResultadosPlanCuentas(FbDataReader READER)
        {
            lvPlanDeCuentas.Items.Clear();
            lvPlanDeCuentas.Columns.Clear();
            lvPlanDeCuentas.BeginUpdate();

            if (lvPlanDeCuentas.Columns.Count == 0)
            {
                lvPlanDeCuentas.Columns.Add("ID");
                lvPlanDeCuentas.Columns.Add("CUENTA");
                lvPlanDeCuentas.Columns.Add("DETALLE");
            }
            do
            {
                ListViewItem listItem = new ListViewItem(READER.GetString(READER.GetOrdinal("ID")));
                listItem.SubItems.Add(READER.GetString(READER.GetOrdinal("NUMEROCTA")));
                listItem.SubItems.Add(READER.GetString(READER.GetOrdinal("NOMBRECTA")).ToUpper());
                lvPlanDeCuentas.Items.Add(listItem);
            }

            while (READER.Read());
            lvPlanDeCuentas.EndUpdate();
            lvPlanDeCuentas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvPlanDeCuentas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            if (tbBuscarCuenta.Text == "")
            {
                MessageBox.Show("INGRESAR UNA CONDICION DE BUSQUEDA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                buscarPlanDeCuentas(tbBuscarCuenta.Text.Trim());
            }
        }

        private void lvPlanDeCuentas_Click(object sender, EventArgs e)
        {
            tbCuentaPlan.Text = lvPlanDeCuentas.SelectedItems[0].SubItems[1].Text;
            tbDetallePlan.Text = lvPlanDeCuentas.SelectedItems[0].SubItems[2].Text;
            btnAddModCuenta.Text = "MODIFICAR";
            ACCION = "MODIFICA";
        }

        private void resetForm()
        {
            tbCuentaPlan.Text = "";
            tbDetallePlan.Text = "";
            btnAddModCuenta.Text = "NUEVA CUENTA";
            ACCION = "NUEVA";
            tbBuscarCuenta.Text = "";
            lvPlanDeCuentas.Items.Clear();
            lvPlanDeCuentas.Columns.Clear();
        }

        private void btnAddModCuenta_Click(object sender, EventArgs e)
        {
            string NUMEROCTA = tbCuentaPlan.Text;
            string NOMBRECTA = tbDetallePlan.Text.Trim();
            bool EXISTE = existe.check("CUENTAS", "NUMEROCTA", NUMEROCTA.ToString());
            Int64 ID = 0;

            if (ACCION == "NUEVA")
            {
                try
                {
                    if (EXISTE == true)
                    {
                        MessageBox.Show("YA EXISTE LA CUENTA", "ERROR!");
                    }
                    else
                    {
                        ID = Int64.Parse(mid.m("ID", "CUENTAS")) + 1;
                        BO_COMPRAS.nuevaCuentaPlan(ID.ToString(), NUMEROCTA, NOMBRECTA);
                        MessageBox.Show("CUENTA CREADA", "LISTO!");
                        resetForm();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO CREAR LA CUENTA\n " + error, "ERROR!");
                    resetForm();
                }
            }


            if (ACCION == "MODIFICA")
            {
                try
                {
                    ID = Int64.Parse(lvPlanDeCuentas.SelectedItems[0].SubItems[0].Text);
                    BO_COMPRAS.modificarCuentaPlan(ID.ToString(), NUMEROCTA, NOMBRECTA);
                    MessageBox.Show("CUENTA MODIFICADA", "LISTO!");
                    resetForm();
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO MODIFICAR LA CUENTA\n" + error, "ERROR!");
                    resetForm();
                }
            }
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFecha.Checked == true)
            {
                dpFechaListado.Enabled = true;
                cbFechaHasta.Enabled = true;
            }
            else
            {
                dpFechaListado.Enabled = false;
                cbFechaHasta.Enabled = false;
            }
        }

        private void chSectores_CheckedChanged(object sender, EventArgs e)
        {
            if (chSectores.Checked == true)
                cbSectorBusqueda.Enabled = true;
            else
                cbSectorBusqueda.Enabled = false;
        }

        private void tbDescuentoTotal_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbImporte.Text != "" && tbDescuentoTotal.Text != "")
            {
                if (cbDescGlobal.SelectedItem == "%")
                {
                    decimal DESCUENTO = decimal.Parse(tbDescuentoTotal.Text);
                    decimal RESTAR = (IMPORTE_TOTAL * DESCUENTO) / 100;
                    decimal TOTAL = IMPORTE_TOTAL - RESTAR;
                    tbImporte.Text = TOTAL.ToString();
                }

                if (cbDescGlobal.SelectedItem == "$")
                {
                    decimal DESCUENTO = decimal.Parse(tbDescuentoTotal.Text);
                    decimal TOTAL = IMPORTE_TOTAL - DESCUENTO;
                    tbImporte.Text = TOTAL.ToString();
                }
            }
        }      

        private void dgFacturasHijas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgFacturasHijas.Rows)
            {
                string ID_FACTURA_FH = row.Cells["ID_FACTURA"].Value.ToString();
                string ID_PROVEEDOR_FH = row.Cells["ID_PROVEEDOR"].Value.ToString();
                string NUM_FACTURA_FH = row.Cells["NUMERO"].Value.ToString();
                string FECHA_FH = row.Cells["FECHA_FACTURA"].Value.ToString();
                string IMPORTE_FH = row.Cells["IMPORTE_FACTURA"].Value.ToString();
                string ID_TIPO_FH = row.Cells["ID_TIPO"].Value.ToString();
                string TIPO_FH = row.Cells["TIPO_FACTURA"].Value.ToString();
                string RAZON_SOCIAL_FH = row.Cells["PROVEEDOR"].Value.ToString();
                
                cbProveedorFactura.SelectedValue = ID_PROVEEDOR_FH;
                mbNumeroFactura.Text = NUM_FACTURA_FH;
                cbTipoFactura.SelectedValue = ID_TIPO_FH;
                tbImporteFactura.Text = IMPORTE_FH;
                dpDiaFactura.Text = FECHA_FH;
            }
        }

        private void aNULARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA ANULAR LA DEUDA?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string ID = lvFacturas.SelectedItems[0].SubItems[0].Text;
                    string ANULADO = DateTime.Today.ToShortDateString();
                    string USR_ANULADO = VGlobales.vp_username;
                    BO_COMPRAS.anularFactura(ID, ANULADO, USR_ANULADO);
                    MessageBox.Show("DEUDA ANULADA", "LISTO!");
                    buscarFactura("BUSCAR");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO ANULAR LA DEUDA\n" + error, "ERROR!");
                }
            }
        }

        private void aCTIVRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA ACTIVAR LA DEUDA SELECCIONADA?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string ID = lvFacturas.SelectedItems[0].SubItems[0].Text;
                    string ANULADO = null;
                    string USR_ANULADO = null;
                    BO_COMPRAS.anularFactura(ID, ANULADO, USR_ANULADO);
                    MessageBox.Show("DEUDA ACTIVADA", "LISTO!");
                    buscarFactura("BUSCAR");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO ACTIVAR LA DEUDA\n" + error, "ERROR!");
                }
            }
        }

        private void limpiarArtSol()
        {
            tbCantArtSol.Text = "";
            tbDetArtSol.Text = "";
            cbTipoArtSol.SelectedIndex = 0;
            lbIdArtSol.Text = "ID_ART";
        }

        private void carga_inicial_solicitudes()
        {
            generarListaArtSol();
            comboSectores(cbSectOrigenSolicitud, 0);
            comboSectores(cbSectorFiltro, -1);
            comboSectores(cbSectDestSolicitudes, 0);
            comboPrioridadesSolicitudes(cbPrioridadSolicitud, "MEDIA");
            comboPrioridadesSolicitudes(cbPrioridadFiltro, "TODAS");
            comboTipoSolicitud(cbTipoSolicitud, 0);
            comboTipoSolicitud(cbTipoSolicitudFiltro, -1);
            comboTipoArticulo(cbTipoArtSol);
            comboPendienteRespuesta(cbPteRta, "X");
            comboPendienteRespuesta(cbPteRtaFiltro, "TODAS");
            cbSectOrigenSolicitud.SelectedValue = VGlobales.vp_role;

            if (recibeCompras() == true)
            {
                gbSolicitudesCompras.Text = "SOLICITUDES RECIBIDAS";
                buscarSolicitudes("RECIBIDAS", "X");
            }
            else
            {
                gbSolicitudesCompras.Text = "SOLICITUDES ENVIADAS";
                cbSectorFiltro.SelectedValue = VGlobales.vp_role;
                cbSectorFiltro.Enabled = false;
                cbSectOrigenSolicitud.Enabled = false;
                buscarSolicitudes("ENVIADAS", "X");
            }
        }

        public void buscarArticulos(string CONDICION)
        {
            var FILTRO = LISTA_ART_SOL.Where(x => x.DETALLE.Contains(CONDICION)).ToList();

            if (FILTRO.Count > 0)
            {
                dgResArtSol.Visible = true;
                btnAddArtSol.Enabled = false;
                dgResArtSol.DataSource = null;
                dgResArtSol.DataSource = FILTRO;
                dgResArtSol.Columns[0].Visible = false;
                dgResArtSol.Columns[1].Width = 400;
                dgResArtSol.Columns[2].Width = 150;
                dgResArtSol.Columns[3].Visible = false;
            }
            else
            {
                dgResArtSol.Visible = false;
                lbIdArtSol.Text = "ID_ART";
                btnAddArtSol.Enabled = true;
            }
        }

     

        private void buscarSolicitudesEnviadas()
        {
            conString cs = new conString();
            string connectionString = cs.get();

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string busco = "SELECT * FROM SOLICITUDES_COMPRAS WHERE SECTOR_ORIGEN = '" + VGlobales.vp_role + "' ORDER BY ID DESC;";             
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
                            mostrarSolicitudes(reader, lvSolicitudesDeCompra);
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

        private void buscarSolicitudes(string RE, string TIPO)
        {
            conString cs = new conString();
            string connectionString = cs.get();

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string busco = "";

                    busco = "SELECT S.ID, S.FECHA_ALTA, S.SECTOR_ORIGEN, S.SECTOR_DESTINO, ";
                    busco += "S.ESTADO, S.PRIORIDAD, S.NRO_RECIBO, C.VALOR1, S.PROVEEDOR ";
                    busco += "FROM SOLICITUDES_COMPRAS S, CONFIG C ";

                    if (RE == "ENVIADAS")
                    {
                        busco += "WHERE SECTOR_ORIGEN = '" + VGlobales.vp_role + "' ";
                    }

                    if (RE == "RECIBIDAS")
                    {
                        busco += "WHERE SECTOR_DESTINO = '" + VGlobales.vp_role + "' ";
                    }

                    if(cbFiltroFecha.Checked == true)
                    {
                        string[] FECHA_SPLIT = dpFechaFiltro.Text.Split('/');
                        busco += "AND S.FECHA_ALTA = '" + FECHA_SPLIT[1] + "/" + FECHA_SPLIT[0] + "/" + FECHA_SPLIT[2] + "' ";
                    }

                    if(cbPrioridadFiltro.Text != "TODAS")
                    {
                        busco += "AND S.PRIORIDAD = '" + cbPrioridadFiltro.Text + "' ";
                    }

                    if (cbPteRtaFiltro.Text != "TODAS")
                    {
                        busco += "AND S.PTE_RTA = '" + cbPteRtaFiltro.Text + "' ";
                    }

                    if (cBoxSectorFiltro.Checked == true)
                    {
                        busco += "AND S.SECTOR_ORIGEN = '" + cbSectorFiltro.Text + "' ";
                    }

                    if (cBoxTipoFiltro.Checked == true)
                    {
                        busco += "AND S.TIPO_SOLICITUD = " + cbTipoSolicitudFiltro.SelectedValue + " ";
                    }

                    busco += "AND S.TIPO_SOLICITUD = C.VALOR ";
                    busco += "AND C.PARAM = 'TIPO_SOLICITUD' ";
                    busco += "ORDER BY ID DESC;";

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
                            lvSolicitudesDeCompra.Clear();
                            mostrarSolicitudes(reader, lvSolicitudesDeCompra);
                        }
                        else
                        {
                            lvSolicitudesDeCompra.Clear();
                            MessageBox.Show("NO SE ENCONTRARON RESULTADOS");
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

        private void mostrarSolicitudes(FbDataReader reader, ListView LV)
        {
            LV.Items.Clear();
            LV.Columns.Clear();
            LV.BeginUpdate();

            //busco = "SELECT S.ID, S.FECHA_ALTA, S.SECTOR_ORIGEN, S.SECTOR_DESTINO, ";
            //busco += "S.ESTADO, S.PRIORIDAD, S.NRO_RECIBO, C.VALOR1, S.PROVEEDOR ";

            if (LV.Columns.Count == 0)
            {
                LV.Columns.Add("ID");
                LV.Columns.Add("TIPO");
                LV.Columns.Add("ALTA");
                LV.Columns.Add("SECTOR ORIGEN");
                LV.Columns.Add("SECTOR DESTINO");
                LV.Columns.Add("PRIORIDAD");
                LV.Columns.Add("RECIBO");
                LV.Columns.Add("ESTADO");
                LV.Columns.Add("PROVEEDOR");
            }
            do
            {
                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("ID")).Trim().ToUpper());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("VALOR1")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("FECHA_ALTA")).Trim().ToLower().Replace(" 00:00:00", ""));
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("SECTOR_ORIGEN")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("SECTOR_DESTINO")).Trim().ToUpper());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("PRIORIDAD")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NRO_RECIBO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ESTADO")).Trim().ToUpper());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("PROVEEDOR")));
                LV.Items.Add(listItem);
            }

            while (reader.Read());
            LV.EndUpdate();
            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            LV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void cbDescGlobal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbDescuentoTotal.Text = "0";
            tbImporte.Text = IMPORTE_TOTAL.ToString();
        }

        private void lvSolicitudesDeCompra_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvSolicitudesDeCompra.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    cmEstadoCompra.Show(Cursor.Position);
                }
            }
        }

        private void pENDIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(lvSolicitudesDeCompra.SelectedItems[0].SubItems[0].Text);
            string ESTADO = "PENDIENTE";
            BO_COMPRAS.modificarEstadoSolicitud(ID, ESTADO);
            buscarSolicitudes("RECIBIDAS", "X");
        }

        private void aCTIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(lvSolicitudesDeCompra.SelectedItems[0].SubItems[0].Text);
            string ESTADO = "ACTIVA";
            BO_COMPRAS.modificarEstadoSolicitud(ID, ESTADO);
            buscarSolicitudes("RECIBIDAS", "X");
        }

        private void rECHAZADAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(lvSolicitudesDeCompra.SelectedItems[0].SubItems[0].Text);
            string ESTADO = "RECHAZADA";
            BO_COMPRAS.modificarEstadoSolicitud(ID, ESTADO);
            buscarSolicitudes("RECIBIDAS", "X");
        }

        private void aNULADAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(lvSolicitudesDeCompra.SelectedItems[0].SubItems[0].Text);
            string ESTADO = "ANULADA";
            BO_COMPRAS.modificarEstadoSolicitud(ID, ESTADO);
            buscarSolicitudes("RECIBIDAS", "X");
        }

        private void cOMPLETADAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(lvSolicitudesDeCompra.SelectedItems[0].SubItems[0].Text);
            string ESTADO = "COMPLETA";
            BO_COMPRAS.modificarEstadoSolicitud(ID, ESTADO);
            buscarSolicitudes("RECIBIDAS", "X");
        }

        private void eNTREGADAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(lvSolicitudesDeCompra.SelectedItems[0].SubItems[0].Text);
            string ESTADO = "ENTREGADA";
            BO_COMPRAS.modificarEstadoSolicitud(ID, ESTADO);
            buscarSolicitudes("RECIBIDAS", "X");
        }

        private void aNULARORDENDEPAGOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string OP = "0";
            string ANULADA = "";
            string CONFIRMADA = "";

            if (lvBuscarOP.SelectedItems.Count != 1)
            {
                MessageBox.Show("SELECCIONAR SOLAMENTE UNA ORDEN DE PAGO", "ERROR");
            }
            else
            {
                foreach (ListViewItem itemRow in lvBuscarOP.SelectedItems)
                {
                    OP = itemRow.SubItems[0].Text;
                    ANULADA = itemRow.SubItems[5].Text;

                    if (ANULADA != "")
                    {
                        MessageBox.Show("LA ORDEN DE PAGO SELECCIONADA YA SE ENCUENTRA ANULADA", "ERROR");
                    }
                    else if (CONFIRMADA !="")
                    {
                        MessageBox.Show("LA ORDEN DE PAGO SELECCIONADA YA TIENE SU ANULACIÓN CONFIRMADA", "ERROR");
                    }
                    else
                    {
                        anular_op aop = new anular_op(OP, "ANULA");
                        aop.ShowDialog();
                        ejecBuscarOP();
                    }
                }
            }
        }

        private void cONFIRMARANULACIÓNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string OP = "0";
            string ANULADA = "";
            string CONFIRMADA = "";

            if (lvBuscarOP.SelectedItems.Count != 1)
            {
                MessageBox.Show("SELECCIONAR SOLAMENTE UNA ORDEN DE PAGO", "ERROR");
            }
            else
            {
                foreach (ListViewItem itemRow in lvBuscarOP.SelectedItems)
                {
                    OP = itemRow.SubItems[0].Text;
                    ANULADA = itemRow.SubItems[5].Text;
                    CONFIRMADA = itemRow.SubItems[6].Text;

                    if (ANULADA == "")
                    {
                        MessageBox.Show("LA ORDEN DE PAGO SELECCIONADA NO SE ENCUENTRA ANULADA", "ERROR");
                    }
                    else if (CONFIRMADA != "")
                    {
                        MessageBox.Show("LA ORDEN DE PAGO SELECCIONADA YA TIENE SU ANULACIÓN CONFIRMADA", "ERROR");
                    }
                    else
                    {
                        anular_op aop = new anular_op(OP, "CONFIRMA");
                        aop.ShowDialog();
                        ejecBuscarOP();
                    }
                }
            }
        }

        private void cANCELARANULACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vERDETALLEOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvBuscarOP.SelectedItems.Count == 1)
            {
                foreach (ListViewItem itemRow in lvBuscarOP.Items)
                {
                    int OP = int.Parse(itemRow.SubItems[0].Text);
                    orden_de_pago op = new orden_de_pago(OP);
                    op.ShowDialog();
                }
            }
        }

        private void TabLibroBanco_Enter(object sender, EventArgs e)
        {
            comboBancos(cbBancosEnLibro);
        }

        private void BtnAceptarLibroBanco_Click(object sender, EventArgs e)
        {

        }

        private void buscarRecibos()
        {
            /*try
            {
                DataSet ds1 = new DataSet();
                string query = "";
                query = "SELECT B.NRO_COMP, TRIM(B.NOMBRE_SOCIO) AS DETALLE, (TRIM(S.DETALLE)||' - '||TRIM(P.NOMBRE)) AS CONCEPTO, B.CUENTA_HABER AS IMPUTACION, ";
                query += "CASE WHEN B.ANULADO IS NULL THEN B.VALOR ELSE '0' END AS IMPORTE, ";
                query += "B.OBSERVACIONES, 'R' AS TIPO, B.CAJA_DIARIA, B.FECHA_RECIBO, F.DETALLE AS F_PAGO, B.ANULADO, B.DESTINO, B.ID AS ID_COMP, B.PTO_VTA ";
                query += ", B.NUMERO_E, B.DNI ";
                query += "FROM RECIBOS_CAJA B, SECTACT S, PROFESIONALES P, FORMAS_DE_PAGO F ";
                query += "WHERE B.SECTACT = S.ID ";
                query += "AND B.ID_PROFESIONAL = P.ID ";
                query += "AND B.FORMA_PAGO = '1' ";
                query += "AND B.DEPOSITADO = 0 ";
                query += "AND B.FORMA_PAGO = F.ID ";
                query += "AND B.REINTEGRO_DE = 0 ";
                query += "AND(B.DESTINO IS NULL OR B.DESTINO NOT IN(10, 4, 1, 3, 16, 2)) ";
                query += "ORDER BY B.NRO_COMP ASC";

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
            }*/
        }

        private void DgArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CbProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TabOrdenesDePago_Click(object sender, EventArgs e)
        {

        }

        private void CbFechaHasta_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFechaHasta.Checked == true)
            {
                dpFechaListadoHasta.Enabled = true;
            }
            else
            {
                dpFechaListadoHasta.Enabled = false;
            }
        }

        private void VerDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSolicitudesDeCompra.SelectedItems.Count == 1)
            {
                foreach (ListViewItem itemRow in lvSolicitudesDeCompra.SelectedItems)
                {
                    int ID_SOLICITUD = int.Parse(itemRow.SubItems[0].Text);
                    detalle_solicitud ds = new detalle_solicitud(ID_SOLICITUD);
                    ds.ShowDialog();
                }
            }
        }

        private void VerDetalleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lvSolicitudesDeCompra.SelectedItems.Count == 1)
            {
                foreach (ListViewItem itemRow in lvSolicitudesDeCompra.SelectedItems)
                {
                    int ID_SOLICITUD = int.Parse(itemRow.SubItems[0].Text);
                    detalle_solicitud ds = new detalle_solicitud(ID_SOLICITUD);
                    ds.ShowDialog();
                }
            }
        }

        private void TpSolicitud_Enter_1(object sender, EventArgs e)
        {
            carga_inicial_solicitudes();
        }

        private void TbDetArtSol_KeyUp_1(object sender, KeyEventArgs e)
        {
            string CONDICION = tbDetArtSol.Text.Trim();
            buscarArticulos(CONDICION);
        }

        private void BtnAddArtSol_Click_1(object sender, EventArgs e)
        {
            if (tbCantArtSol.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO CANTIDAD", "ERROR");
                tbCantArtSol.Focus();
            }
            else if (tbDetArtSol.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO DETALLE", "ERROR");
                tbDetArtSol.Focus();
            }
            else
            {
                dgResArtSol.Visible = false;
                string CANTIDAD_SOL = tbCantArtSol.Text.Trim();
                string DETALLE_SOL = tbDetArtSol.Text.Trim();
                string TIPO_SOL = cbTipoArtSol.Text;
                string ID_TIPO_SOL = cbTipoArtSol.SelectedValue.ToString();
                string ID_ART = lbIdArtSol.Text;
                dgvArtSol.Rows.Add(CANTIDAD_SOL, DETALLE_SOL, TIPO_SOL, ID_TIPO_SOL, ID_ART);
                limpiarArtSol();
            }
        }

        private void BtnDelArtSol_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvArtSol.SelectedRows)
            {
                int ID = int.Parse(row.Index.ToString());
                dgvArtSol.Rows.RemoveAt(ID);
            }

            btnDelArtSol.Enabled = false;
        }

        private void BtnAltaSolicitud_Click(object sender, EventArgs e)
        {
            if (dgvArtSol.Rows.Count == 0)
            {
                MessageBox.Show("AGREGAR POR LO MENOS UN ARTÍCULO", "ERROR!");
            }
            else
            {
                string FECHA_SOL = dpFechaSolicitud.Text;
                string PRIORIDAD_SOL = cbPrioridadSolicitud.Text;
                string SECTOR_ORIGEN = cbSectOrigenSolicitud.SelectedValue.ToString();
                string SECTOR_DESTINO = cbSectDestSolicitudes.SelectedValue.ToString();
                int TIPO_SOLICITUD = Convert.ToInt32(cbTipoSolicitud.SelectedValue);
                string OBSERVACIONES = tbObsSolicitud.Text.Trim();
                string PROVEEDOR = tbProveedorSolicitud.Text.Trim();
                string EMAIL = tbEmailSolicitud.Text.Trim();
                string TELEFONO = tbTelefonoContacto.Text.Trim();
                string NOMBRE = tbNombreContacto.Text.Trim();
                string PTE_RTA = cbPteRta.Text;
                int REF_NRO_SOL = 0;

                if (tbRefSolCompra.Text != "")
                    REF_NRO_SOL = Convert.ToInt32(tbRefSolCompra.Text);

                string DETALLE_ART_SOL = "";
                int ID_TIPO_ART_SOL = 1;
                int ID_NUEVO_ART_SOL = 0;
                int CANTIDAD_ART_SOL = 0;
                string NRO_RECIBO = tbNroRecibo.Text;

                try
                {
                    BO_COMPRAS.nuevaSolicitudCompra(FECHA_SOL, PRIORIDAD_SOL, SECTOR_ORIGEN, SECTOR_DESTINO, NRO_RECIBO, TIPO_SOLICITUD, OBSERVACIONES, PROVEEDOR, EMAIL, TELEFONO, NOMBRE, PTE_RTA, REF_NRO_SOL);
                    string ID_SOL = mid.m("ID", "SOLICITUDES_COMPRAS");

                    foreach (DataGridViewRow row in dgvArtSol.Rows)
                    {
                        if (row.Cells[4].Value.ToString() == "ID_ART")
                        {
                            DETALLE_ART_SOL = row.Cells[1].Value.ToString();
                            ID_TIPO_ART_SOL = int.Parse(row.Cells[3].Value.ToString());
                            BO_COMPRAS.nuevoArticulo(0, DETALLE_ART_SOL, 0, 0, "0", ID_TIPO_ART_SOL, "0");
                            ID_NUEVO_ART_SOL = int.Parse(mid.m("ID", "ARTICULOS"));
                            row.Cells[4].Value = ID_NUEVO_ART_SOL.ToString();
                        }
                    }

                    foreach (DataGridViewRow row in dgvArtSol.Rows)
                    {
                        ID_NUEVO_ART_SOL = int.Parse(row.Cells[4].Value.ToString());
                        CANTIDAD_ART_SOL = int.Parse(row.Cells[0].Value.ToString());
                        BO_COMPRAS.altaSolicitudArticulos(int.Parse(ID_SOL), ID_NUEVO_ART_SOL, CANTIDAD_ART_SOL);
                    }

                    MessageBox.Show("SOLICITUD DE COMPRA ENVIADA", "LISTO!");
                    carga_inicial_solicitudes();
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO ENVIAR LA SOLICITUD\n" + error, "ERROR!");
                }
            }
        }

        private void DgResArtSol_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgResArtSol.SelectedRows)
            {
                string ID_ART_SOL = row.Cells["ID"].Value.ToString();
                string DETALLE = row.Cells["DETALLE"].Value.ToString();
                string TIPO = row.Cells["TIPO"].Value.ToString();
                string ID_TIPO = row.Cells["ID_TIPO"].Value.ToString();
                tbDetArtSol.Text = DETALLE;
                cbTipoArtSol.SelectedValue = ID_TIPO;
                lbIdArtSol.Text = ID_ART_SOL;
                dgResArtSol.Visible = false;
                btnAddArtSol.Enabled = true;
            }
        }

        private void DgvArtSol_Click_1(object sender, EventArgs e)
        {
            if (dgvArtSol.SelectedRows.Count > 0)
            {
                btnDelArtSol.Enabled = true;
            }
            else
            {
                btnDelArtSol.Enabled = false;
            }
        }

        private void LvSolicitudesDeCompra_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvSolicitudesDeCompra.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    if(recibeCompras() == true)
                        cmEstadoCompra.Show(Cursor.Position);
                    else
                        cmEnviadas.Show(Cursor.Position);
                }
            }
        }

        private void CbTipoSolicitud_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(Convert.ToInt32(cbTipoSolicitud.SelectedValue) == 1)
            {
                tbProveedorSolicitud.Enabled = false;
                tbEmailSolicitud.Enabled = false;
                tbTelefonoContacto.Enabled = false;
                tbNombreContacto.Enabled = false;
                cbPteRta.SelectedIndex = -1;
                cbPteRta.Enabled = false;
                tbRefSolCompra.Enabled = false;
            }

            if (Convert.ToInt32(cbTipoSolicitud.SelectedValue) == 2)
            {
                tbProveedorSolicitud.Enabled = true;
                tbEmailSolicitud.Enabled = true;
                tbTelefonoContacto.Enabled = true;
                tbNombreContacto.Enabled = true;
                cbPteRta.SelectedIndex = 0;
                cbPteRta.Enabled = true;
                tbRefSolCompra.Enabled = true;
            }
        }

        private void BtnAceptarFiltro_Click(object sender, EventArgs e)
        {
            if (recibeCompras() == true)
            {
                buscarSolicitudes("RECIBIDAS", "X");
            }
            else
            {
                buscarSolicitudes("ENVIADAS", "X");
            }
        }

        private void LvTransSeleccionadas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvTransSeleccionadas.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    cmTransferencias.Show(Cursor.Position);
                }
            }

        }

        private void eliminarTransferencias(string CUALES) // revisar codigo comentado
        {
            string CHEQUE = "";
            string BANCO_ID = "";

            if (CUALES == "SELECCIONADOS")
            {
                foreach (ListViewItem itemRow in lvTransSeleccionadas.SelectedItems)
                {
                    //CHEQUE = itemRow.SubItems[1].Text;
                    //BANCO_ID = itemRow.SubItems[7].Text;
                    //BO_COMPRAS.chequeOpTemp(0, int.Parse(CHEQUE), int.Parse(BANCO_ID));
                    itemRow.Remove();
                }
            }

            if (CUALES == "TODOS")
            {
                foreach (ListViewItem itemRow in lvTransSeleccionadas.Items)
                {
                    //CHEQUE = itemRow.SubItems[1].Text;
                    //BANCO_ID = itemRow.SubItems[7].Text;
                    //BO_COMPRAS.chequeOpTemp(0, int.Parse(CHEQUE), int.Parse(BANCO_ID));
                    itemRow.Remove();
                }
            }
            sumaTransferencias();
            //int BANCO = int.Parse(cbBancos.SelectedValue.ToString());
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            eliminarTransferencias("SELECCIONADOS");
        }

        private void BtnVistaPreviaTrans_Click(object sender, EventArgs e)
        {
            if (lvOP.Items.Count == 0)
            {
                MessageBox.Show("NO SE SELECCIONO NINGUNA FACTURA", "ERROR");
            }
            else if (lvChequesSeleccionados.Items.Count == 0 && lvTransSeleccionadas.Items.Count == 0)
            {
                MessageBox.Show("NO SE CARGO NINGUN CHEQUE NI TRANSFERENCIA", "ERROR");
            }
            else if (sumarTotales() == false)
            {
                MessageBox.Show("EL IMPORTE DE LAS FACTURAS SELECCIONADAS YA HA SIDO CUBIERTO", "ERROR");
            }
            else if (cbBenefOpe.Text == "")
            {
                MessageBox.Show("SELECCIONAR UN BENEFICIARIO PARA LA ORDEN DE PAGO", "ERROR");
            }
            else
            {
                if (MessageBox.Show("¿DESEA CREAR VISTA PREVIA?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int ID_OP = int.Parse(mid.m("ID", "ORDENES_DE_PAGO")) + 1;

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.FileName = "VISTAPREVIAOP - " + ID_OP.ToString(); 
                    saveFileDialog1.Filter = "Pdf Files|*.pdf";
                    saveFileDialog1.Title = "Guardar PDF vista previa";
                    saveFileDialog1.ShowDialog();

                    if (saveFileDialog1.FileName != "" && saveFileDialog1.FileName != "VISTAPREVIAOP - " + ID_OP.ToString())
                    {
                        string PATH = saveFileDialog1.FileName;
                        Cursor = Cursors.WaitCursor;
                        string[][] TRANSFERENCIAS = new string[lvTransSeleccionadas.Items.Count][];
                        string[][] CHEQUES = new string[lvChequesSeleccionados.Items.Count][];
                        try
                        {
                            string ID_FACTURA = "";
                            decimal TOTAL = Convert.ToDecimal(lbTotalCheques.Text) + Convert.ToDecimal(lbTotalTransferencias.Text);

                            foreach (ListViewItem itemRow in lvOP.Items)
                            {
                                ID_FACTURA = itemRow.SubItems[0].Text;
                            }

                            string[] OP = new string[4];
                            OP[0] = tbObservacionesOP.Text.Trim();
                            OP[1] = cbBenefOpe.Text.Trim().ToUpper();
                            OP[2] = Convert.ToString(TOTAL);
                            OP[3] = ID_FACTURA;


                            if (lvChequesSeleccionados.Items.Count > 0)
                            {
                                int i = 0;
                                foreach (ListViewItem itemRow in lvChequesSeleccionados.Items)
                                {
                                    CHEQUES[i] = new string[8];
                                    CHEQUES[i][0] = itemRow.SubItems[0].Text; // Banco
                                    CHEQUES[i][1] = "A"; // SERIE
                                    CHEQUES[i][2] = itemRow.SubItems[1].Text; // Cheque
                                    CHEQUES[i][3] = itemRow.SubItems[4].Text; // Importe
                                    CHEQUES[i][4] = itemRow.SubItems[5].Text; // Fecha
                                    CHEQUES[i][5] = itemRow.SubItems[2].Text; // Tipo
                                    CHEQUES[i][6] = itemRow.SubItems[3].Text; // Vencimiento
                                    CHEQUES[i][7] = itemRow.SubItems[6].Text.ToUpper(); // Beneficiario
                                    i++;
                                }
                            }

                            if (lvTransSeleccionadas.Items.Count > 0)
                            {
                                int i = 0;
                                foreach (ListViewItem itemRow in lvTransSeleccionadas.Items)
                                {
                                    string QUERY_CBU = "SELECT CBU FROM CUENTAS_BANCARIAS WHERE ID = " + itemRow.SubItems[7].Text;
                                    DataRow[] CBU = dlog.BO_EjecutoDataTable(QUERY_CBU).Select();

                                    TRANSFERENCIAS[i] = new string[3];
                                    TRANSFERENCIAS[i][0] = CBU[0][0].ToString(); // CBU
                                    TRANSFERENCIAS[i][1] = itemRow.SubItems[10].Text; // Proveedor
                                    TRANSFERENCIAS[i][2] = itemRow.SubItems[9].Text; // Importe
                                    i++;
                                }

                                if (lbPdfTrans.Text != "ARCHIVO PDF NO CARGADO")
                                {
                                    int ID_TRANS = int.Parse(mid.m("ID", "TRANSFERENCIAS"));
                                    string ARCHIVO_ORIGEN = lbPdfTrans.Text;
                                    string ARCHIVO_DESTINO = "\\\\192.168.1.6\\ComprasPDF\\TRANSFERENCIA_" + ID_OP + "_" + ID_TRANS + ".PDF";
                                    File.Copy(ARCHIVO_ORIGEN, ARCHIVO_DESTINO);
                                    lbPdfTrans.Text = "ARCHIVO PDF NO CARGADO";
                                }
                            }

                            imprimirVistaPrevia(TRANSFERENCIAS, CHEQUES, OP, PATH);
                            DialogResult result = MessageBox.Show("VISTA PREVIA CREADA CORRECTAMENTE \n\n ¿ABRIR EL ARCHIVO?", "LISTO!", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                Process.Start(PATH);
                            }
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("NO SE PUDO GENERAR VISTA PREVIA\n" + error, "ERROR");
                            Cursor = Cursors.Default;
                        }
                    }
                    Cursor = Cursors.Default;
                } 
            }
        
        }

        private void imprimirVistaPrevia(string[][] TRANSFERENCIAS, string[][] CHEQUES, string[] OP, string PATH)
        {
            maxid mid = new maxid();
            int ID_OP = int.Parse(mid.m("ID", "ORDENES_DE_PAGO")) + 1;
            string QUERY_FACTURAS = "SELECT F.NUM_FACTURA, P.RAZON_SOCIAL, F.FECHA, F.IMPORTE, F.OBSERVACIONES, F.SECTOR FROM FACTURAS F, PROVEEDORES P WHERE P.ID = F.PROVEEDOR AND F.ID = " + OP[3];
            DataRow[] FACTURAS = dlog.BO_EjecutoDataTable(QUERY_FACTURAS).Select();

            string OBSERVACIONES = OP[0];
            decimal TOTAL = Decimal.Parse(OP[2]);
            string BENEFICIARIO = OP[1];
            DateTime FECHA = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            string FECHA_LARGA = FECHA.ToString("D", CultureInfo.CreateSpecificCulture("es-MX"));
            string TOTAL_OP = "$ " + string.Format("{0:n}", TOTAL);

            #region HEADER
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

            Document doc = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(PATH, FileMode.Create));
            doc.AddTitle("ORDEN DE PAGO Nº " + ID_OP.ToString());
            doc.AddCreator("CSPFA");
            doc.Open();

            PdfPTable TABLA_HEADER = new PdfPTable(2);
            TABLA_HEADER.WidthPercentage = 100;
            TABLA_HEADER.SpacingAfter = 5;
            TABLA_HEADER.SetWidths(new float[] { 1f, 1f });

            PdfPCell CELDA_CSPFA = new PdfPCell(new Phrase("CÍRCULO DE SUBOFICIALES DE LA PFA", _standardFont));
            PdfPCell CELDA_OP = new PdfPCell(new Phrase("ORDEN DE PAGO Nº " + ID_OP.ToString(), _standardFont));

            CELDA_CSPFA.BackgroundColor = blanco;
            CELDA_CSPFA.BorderColor = blanco;
            CELDA_CSPFA.HorizontalAlignment = 0;
            CELDA_CSPFA.FixedHeight = 16f;

            CELDA_OP.BackgroundColor = blanco;
            CELDA_OP.BorderColor = blanco;
            CELDA_OP.HorizontalAlignment = 2;
            CELDA_OP.FixedHeight = 16f;

            TABLA_HEADER.AddCell(CELDA_CSPFA);
            TABLA_HEADER.AddCell(CELDA_OP);

            doc.Add(TABLA_HEADER);

            Paragraph P_FECHA = new Paragraph("Buenos Aires " + FECHA_LARGA, _mediumFont);
            P_FECHA.Alignment = Element.ALIGN_LEFT;
            P_FECHA.SpacingAfter = 5;
            doc.Add(P_FECHA);

            Paragraph P_PAGUESE = new Paragraph("Páguese por Tesorería los importes correspondientes a los comprobantes que se adjuntan", _mediumFont);
            P_PAGUESE.Alignment = Element.ALIGN_LEFT;
            P_PAGUESE.SpacingBefore = 5;
            doc.Add(P_PAGUESE);

            Paragraph P_BENEFICIARIO = new Paragraph("BENEFICIARIO: " + BENEFICIARIO, _mediumFont);
            P_BENEFICIARIO.Alignment = Element.ALIGN_LEFT;
            P_BENEFICIARIO.SpacingAfter = 5;
            doc.Add(P_BENEFICIARIO);
            #endregion

            #region TABLA FACTURAS
            PdfPTable TABLA_FACTURAS = new PdfPTable(5);
            TABLA_FACTURAS.WidthPercentage = 100;
            TABLA_FACTURAS.SpacingAfter = 5;
            TABLA_FACTURAS.SpacingBefore = 5;
            TABLA_FACTURAS.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f });

            PdfPCell CELDA_NRO_FACTURA = new PdfPCell(new Phrase("FACTURA Nº", _mediumFontBoldWhite));
            CELDA_NRO_FACTURA.BackgroundColor = topo;
            CELDA_NRO_FACTURA.BorderColor = blanco;
            CELDA_NRO_FACTURA.HorizontalAlignment = 1;
            CELDA_NRO_FACTURA.FixedHeight = 16f;
            TABLA_FACTURAS.AddCell(CELDA_NRO_FACTURA);

            PdfPCell CELDA_PROVEEDOR = new PdfPCell(new Phrase("PROVEEDOR", _mediumFontBoldWhite));
            CELDA_PROVEEDOR.BackgroundColor = topo;
            CELDA_PROVEEDOR.BorderColor = blanco;
            CELDA_PROVEEDOR.HorizontalAlignment = 1;
            CELDA_PROVEEDOR.FixedHeight = 16f;
            TABLA_FACTURAS.AddCell(CELDA_PROVEEDOR);

            PdfPCell CELDA_FECHA = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
            CELDA_FECHA.BackgroundColor = topo;
            CELDA_FECHA.BorderColor = blanco;
            CELDA_FECHA.HorizontalAlignment = 1;
            CELDA_FECHA.FixedHeight = 16f;
            TABLA_FACTURAS.AddCell(CELDA_FECHA);

            PdfPCell CELDA_SECTOR = new PdfPCell(new Phrase("SECTOR", _mediumFontBoldWhite));
            CELDA_SECTOR.BackgroundColor = topo;
            CELDA_SECTOR.BorderColor = blanco;
            CELDA_SECTOR.HorizontalAlignment = 1;
            CELDA_SECTOR.FixedHeight = 16f;
            TABLA_FACTURAS.AddCell(CELDA_SECTOR);

            PdfPCell CELDA_IMPORTE = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
            CELDA_IMPORTE.BackgroundColor = topo;
            CELDA_IMPORTE.BorderColor = blanco;
            CELDA_IMPORTE.HorizontalAlignment = 1;
            CELDA_IMPORTE.FixedHeight = 16f;
            TABLA_FACTURAS.AddCell(CELDA_IMPORTE);

            for (int i = 0; i <= FACTURAS.Length - 1; i++)
            {
                string NRO_FACTURA = FACTURAS[i][0].ToString().Trim();
                string PROVEEDOR = FACTURAS[i][1].ToString().Trim();
                string FECHA_FACTURA = Convert.ToDateTime(FACTURAS[i][2]).ToShortDateString();
                string IMPORTE = "$ " + string.Format("{0:n}", FACTURAS[i][3]).ToString();
                string OBS_FACTURA = FACTURAS[i][4].ToString().Trim();
                string SECTOR = FACTURAS[i][5].ToString().Trim();

                PdfPCell DATO_NRO_FACTURA = new PdfPCell(new Phrase(NRO_FACTURA, _mediumFont));
                DATO_NRO_FACTURA.BackgroundColor = blanco;
                DATO_NRO_FACTURA.BorderColor = blanco;
                DATO_NRO_FACTURA.HorizontalAlignment = 1;
                TABLA_FACTURAS.AddCell(DATO_NRO_FACTURA);

                PdfPCell DATO_PROVEEDOR = new PdfPCell(new Phrase(PROVEEDOR, _mediumFont));
                DATO_PROVEEDOR.BackgroundColor = blanco;
                DATO_PROVEEDOR.BorderColor = blanco;
                DATO_PROVEEDOR.HorizontalAlignment = 1;
                TABLA_FACTURAS.AddCell(DATO_PROVEEDOR);

                PdfPCell DATO_FECHA = new PdfPCell(new Phrase(FECHA_FACTURA, _mediumFont));
                DATO_FECHA.BackgroundColor = blanco;
                DATO_FECHA.BorderColor = blanco;
                DATO_FECHA.HorizontalAlignment = 1;
                TABLA_FACTURAS.AddCell(DATO_FECHA);

                PdfPCell DATO_SECTOR = new PdfPCell(new Phrase(SECTOR, _mediumFont));
                DATO_SECTOR.BackgroundColor = blanco;
                DATO_SECTOR.BorderColor = blanco;
                DATO_SECTOR.HorizontalAlignment = 1;
                TABLA_FACTURAS.AddCell(DATO_SECTOR);

                PdfPCell DATO_IMPORTE = new PdfPCell(new Phrase(IMPORTE, _mediumFont));
                DATO_IMPORTE.BackgroundColor = blanco;
                DATO_IMPORTE.BorderColor = blanco;
                DATO_IMPORTE.HorizontalAlignment = 1;
                TABLA_FACTURAS.AddCell(DATO_IMPORTE);
            }

            doc.Add(TABLA_FACTURAS);
            #endregion

            #region TABLA CHEQUES
            if (CHEQUES.Length > 0)
            {
                PdfPTable TABLA_CHEQUES = new PdfPTable(7);
                TABLA_CHEQUES.WidthPercentage = 100;
                TABLA_CHEQUES.SpacingAfter = 5;
                TABLA_CHEQUES.SpacingBefore = 5;
                TABLA_CHEQUES.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 1f });

                PdfPCell CELDA_BANCO = new PdfPCell(new Phrase("BANCO", _mediumFontBoldWhite));
                CELDA_BANCO.BackgroundColor = topo;
                CELDA_BANCO.BorderColor = blanco;
                CELDA_BANCO.HorizontalAlignment = 1;
                CELDA_BANCO.FixedHeight = 16f;
                TABLA_CHEQUES.AddCell(CELDA_BANCO);

                PdfPCell CELDA_SERIE = new PdfPCell(new Phrase("SERIE", _mediumFontBoldWhite));
                CELDA_SERIE.BackgroundColor = topo;
                CELDA_SERIE.BorderColor = blanco;
                CELDA_SERIE.HorizontalAlignment = 1;
                CELDA_SERIE.FixedHeight = 16f;
                TABLA_CHEQUES.AddCell(CELDA_SERIE);

                PdfPCell CELDA_NRO_CHEQUE = new PdfPCell(new Phrase("CHEQUE", _mediumFontBoldWhite));
                CELDA_NRO_CHEQUE.BackgroundColor = topo;
                CELDA_NRO_CHEQUE.BorderColor = blanco;
                CELDA_NRO_CHEQUE.HorizontalAlignment = 1;
                CELDA_NRO_CHEQUE.FixedHeight = 16f;
                TABLA_CHEQUES.AddCell(CELDA_NRO_CHEQUE);

                PdfPCell CELDA_IMPORTE_CHEQUE = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                CELDA_IMPORTE_CHEQUE.BackgroundColor = topo;
                CELDA_IMPORTE_CHEQUE.BorderColor = blanco;
                CELDA_IMPORTE_CHEQUE.HorizontalAlignment = 1;
                CELDA_IMPORTE_CHEQUE.FixedHeight = 16f;
                TABLA_CHEQUES.AddCell(CELDA_IMPORTE_CHEQUE);

                PdfPCell CELDA_FECHA_CHEQUE = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
                CELDA_FECHA_CHEQUE.BackgroundColor = topo;
                CELDA_FECHA_CHEQUE.BorderColor = blanco;
                CELDA_FECHA_CHEQUE.HorizontalAlignment = 1;
                CELDA_FECHA_CHEQUE.FixedHeight = 16f;
                TABLA_CHEQUES.AddCell(CELDA_FECHA_CHEQUE);

                PdfPCell CELDA_FECHA_TIPO = new PdfPCell(new Phrase("TIPO", _mediumFontBoldWhite));
                CELDA_FECHA_TIPO.BackgroundColor = topo;
                CELDA_FECHA_TIPO.BorderColor = blanco;
                CELDA_FECHA_TIPO.HorizontalAlignment = 1;
                CELDA_FECHA_TIPO.FixedHeight = 16f;
                TABLA_CHEQUES.AddCell(CELDA_FECHA_TIPO);

                PdfPCell CELDA_VENCIMIENTO = new PdfPCell(new Phrase("VENCIMIENTO", _mediumFontBoldWhite));
                CELDA_VENCIMIENTO.BackgroundColor = topo;
                CELDA_VENCIMIENTO.BorderColor = blanco;
                CELDA_VENCIMIENTO.HorizontalAlignment = 1;
                CELDA_VENCIMIENTO.FixedHeight = 16f;
                TABLA_CHEQUES.AddCell(CELDA_VENCIMIENTO);

                for (int i = 0; i <= CHEQUES.Length - 1; i++)
                {
                    string BANCO = CHEQUES[i][0];
                    string SERIE = CHEQUES[i][1].ToString();
                    string NRO_CHEQUE = CHEQUES[i][2].ToString();
                    string IMPORTE = "$ " + string.Format("{0:n}", CHEQUES[i][3]).ToString();
                    string FECHA_CHEQUE = Convert.ToDateTime(CHEQUES[i][4]).ToShortDateString();
                    string TIPO = CHEQUES[i][5].ToString();
                    string VENCIMIENTO = CHEQUES[i][6].ToString();
                    string BENEF_CHEQUE = CHEQUES[i][7].ToString();

                    PdfPCell DATO_BANCO = new PdfPCell(new Phrase(BANCO, _mediumFont));
                    DATO_BANCO.BackgroundColor = blanco;
                    DATO_BANCO.BorderColor = blanco;
                    DATO_BANCO.HorizontalAlignment = 1;
                    TABLA_CHEQUES.AddCell(DATO_BANCO);

                    PdfPCell DATO_SERIE = new PdfPCell(new Phrase(SERIE, _mediumFont));
                    DATO_SERIE.BackgroundColor = blanco;
                    DATO_SERIE.BorderColor = blanco;
                    DATO_SERIE.HorizontalAlignment = 1;
                    TABLA_CHEQUES.AddCell(DATO_SERIE);

                    PdfPCell DATO_NRO_CHEQUE = new PdfPCell(new Phrase(NRO_CHEQUE, _mediumFont));
                    DATO_NRO_CHEQUE.BackgroundColor = blanco;
                    DATO_NRO_CHEQUE.BorderColor = blanco;
                    DATO_NRO_CHEQUE.HorizontalAlignment = 1;
                    TABLA_CHEQUES.AddCell(DATO_NRO_CHEQUE);

                    PdfPCell DATO_IMPORTE = new PdfPCell(new Phrase(IMPORTE, _mediumFont));
                    DATO_IMPORTE.BackgroundColor = blanco;
                    DATO_IMPORTE.BorderColor = blanco;
                    DATO_IMPORTE.HorizontalAlignment = 1;
                    TABLA_CHEQUES.AddCell(DATO_IMPORTE);

                    PdfPCell DATO_FECHA_CHEQUE = new PdfPCell(new Phrase(FECHA_CHEQUE, _mediumFont));
                    DATO_FECHA_CHEQUE.BackgroundColor = blanco;
                    DATO_FECHA_CHEQUE.BorderColor = blanco;
                    DATO_FECHA_CHEQUE.HorizontalAlignment = 1;
                    TABLA_CHEQUES.AddCell(DATO_FECHA_CHEQUE);

                    PdfPCell DATO_TIPO = new PdfPCell(new Phrase(TIPO, _mediumFont));
                    DATO_TIPO.BackgroundColor = blanco;
                    DATO_TIPO.BorderColor = blanco;
                    DATO_TIPO.HorizontalAlignment = 1;
                    TABLA_CHEQUES.AddCell(DATO_TIPO);

                    PdfPCell DATO_VENCIMIENTO = new PdfPCell(new Phrase(VENCIMIENTO, _mediumFont));
                    DATO_VENCIMIENTO.BackgroundColor = blanco;
                    DATO_VENCIMIENTO.BorderColor = blanco;
                    DATO_VENCIMIENTO.HorizontalAlignment = 1;
                    TABLA_CHEQUES.AddCell(DATO_VENCIMIENTO);
                }

                doc.Add(TABLA_CHEQUES);
            }
            #endregion

            #region TABLA TRANSFERENCIAS
            if (TRANSFERENCIAS.Length > 0)
            {
                PdfPTable TABLA_TRANSFERENCIAS = new PdfPTable(3);
                TABLA_TRANSFERENCIAS.WidthPercentage = 100;
                TABLA_TRANSFERENCIAS.SpacingAfter = 5;
                TABLA_TRANSFERENCIAS.SpacingBefore = 5;
                TABLA_TRANSFERENCIAS.SetWidths(new float[] { 1f, 1f, 1f });

                PdfPCell CELDA_CBU = new PdfPCell(new Phrase("CBU", _mediumFontBoldWhite));
                CELDA_CBU.BackgroundColor = topo;
                CELDA_CBU.BorderColor = blanco;
                CELDA_CBU.HorizontalAlignment = 1;
                CELDA_CBU.FixedHeight = 16f;
                TABLA_TRANSFERENCIAS.AddCell(CELDA_CBU);

                PdfPCell CELDA_PROVEEDOR_T = new PdfPCell(new Phrase("PROVEEDOR", _mediumFontBoldWhite));
                CELDA_PROVEEDOR_T.BackgroundColor = topo;
                CELDA_PROVEEDOR_T.BorderColor = blanco;
                CELDA_PROVEEDOR_T.HorizontalAlignment = 1;
                CELDA_PROVEEDOR_T.FixedHeight = 16f;
                TABLA_TRANSFERENCIAS.AddCell(CELDA_PROVEEDOR_T);

                PdfPCell CELDA_IMPORTE_T = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                CELDA_IMPORTE_T.BackgroundColor = topo;
                CELDA_IMPORTE_T.BorderColor = blanco;
                CELDA_IMPORTE_T.HorizontalAlignment = 1;
                CELDA_IMPORTE_T.FixedHeight = 16f;
                TABLA_TRANSFERENCIAS.AddCell(CELDA_IMPORTE_T);

                for (int i = 0; i < TRANSFERENCIAS.Length; i++)
                {
                    string CBU = Convert.ToString(TRANSFERENCIAS[i][0]);
                    string PROVEEDOR = Convert.ToString(TRANSFERENCIAS[i][1]);
                    string IMPORTE = "$ " + string.Format("{0:n}", TRANSFERENCIAS[i][2]);

                    PdfPCell DATO_CBU = new PdfPCell(new Phrase(CBU, _mediumFont));
                    DATO_CBU.BackgroundColor = blanco;
                    DATO_CBU.BorderColor = blanco;
                    DATO_CBU.HorizontalAlignment = 1;
                    TABLA_TRANSFERENCIAS.AddCell(DATO_CBU);

                    PdfPCell DATO_PROVEEDOR = new PdfPCell(new Phrase(PROVEEDOR, _mediumFont));
                    DATO_PROVEEDOR.BackgroundColor = blanco;
                    DATO_PROVEEDOR.BorderColor = blanco;
                    DATO_PROVEEDOR.HorizontalAlignment = 1;
                    TABLA_TRANSFERENCIAS.AddCell(DATO_PROVEEDOR);

                    PdfPCell DATO_IMPORTE = new PdfPCell(new Phrase(IMPORTE, _mediumFont));
                    DATO_IMPORTE.BackgroundColor = blanco;
                    DATO_IMPORTE.BorderColor = blanco;
                    DATO_IMPORTE.HorizontalAlignment = 1;
                    TABLA_TRANSFERENCIAS.AddCell(DATO_IMPORTE);

                }

                doc.Add(TABLA_TRANSFERENCIAS);
            }
            #endregion

            #region TABLA TOTAL OP
            PdfPTable TABLA_TOTAL_OP = new PdfPTable(1);
            TABLA_TOTAL_OP.WidthPercentage = 100;
            TABLA_TOTAL_OP.SpacingAfter = 5;
            TABLA_TOTAL_OP.SetWidths(new float[] { 1f });

            PdfPCell CELDA_IMPORTE_TOTAL_OP = new PdfPCell(new Phrase("TOTAL: " + TOTAL_OP, _mediumFontBoldWhite));
            CELDA_IMPORTE_TOTAL_OP.BackgroundColor = topo;
            CELDA_IMPORTE_TOTAL_OP.BorderColor = blanco;
            CELDA_IMPORTE_TOTAL_OP.HorizontalAlignment = 2;
            CELDA_IMPORTE_TOTAL_OP.FixedHeight = 16f;
            TABLA_TOTAL_OP.AddCell(CELDA_IMPORTE_TOTAL_OP);

            doc.Add(TABLA_TOTAL_OP);
            #endregion

            #region TABLA FIRMAS

            PdfPTable TABLA_FIRMA_BENEFICIARIO = new PdfPTable(2);
            TABLA_FIRMA_BENEFICIARIO.WidthPercentage = 100;
            TABLA_FIRMA_BENEFICIARIO.SpacingBefore = 65;
            TABLA_FIRMA_BENEFICIARIO.SetWidths(new float[] { 3f, 1f });

            PdfPCell CELDA_RECIBI = new PdfPCell(new Phrase("Recibí de conformidad el pago con los valores detallados precedentemente", _mediumFont));
            CELDA_RECIBI.BackgroundColor = blanco;
            CELDA_RECIBI.BorderColor = blanco;
            CELDA_RECIBI.HorizontalAlignment = 0;
            TABLA_FIRMA_BENEFICIARIO.AddCell(CELDA_RECIBI);

            PdfPCell CELDA_LINEA_FIRMA_RECIBI = new PdfPCell(new Phrase("__________________________", _mediumFont));
            CELDA_LINEA_FIRMA_RECIBI.BackgroundColor = blanco;
            CELDA_LINEA_FIRMA_RECIBI.BorderColor = blanco;
            CELDA_LINEA_FIRMA_RECIBI.HorizontalAlignment = 2;
            TABLA_FIRMA_BENEFICIARIO.AddCell(CELDA_LINEA_FIRMA_RECIBI);

            PdfPCell CELDA_VACIA = new PdfPCell(new Phrase(" ", _mediumFont));
            CELDA_VACIA.BackgroundColor = blanco;
            CELDA_VACIA.BorderColor = blanco;
            CELDA_VACIA.HorizontalAlignment = 1;
            TABLA_FIRMA_BENEFICIARIO.AddCell(CELDA_VACIA);

            PdfPCell CELDA_FIRMA = new PdfPCell(new Phrase("Firma del Beneficiario  ", _mediumFont));
            CELDA_FIRMA.BackgroundColor = blanco;
            CELDA_FIRMA.BorderColor = blanco;
            CELDA_FIRMA.HorizontalAlignment = 2;
            TABLA_FIRMA_BENEFICIARIO.AddCell(CELDA_FIRMA);

            doc.Add(TABLA_FIRMA_BENEFICIARIO);

            PdfPTable TABLA_FIRMAS = new PdfPTable(3);
            TABLA_FIRMAS.WidthPercentage = 100;
            TABLA_FIRMAS.SpacingBefore = 65;
            TABLA_FIRMAS.SetWidths(new float[] { 1f, 1f, 1f });

            PdfPCell CELDA_LINEA_TAVARES = new PdfPCell(new Phrase("_______________________________", _mediumFont));
            CELDA_LINEA_TAVARES.BackgroundColor = blanco;
            CELDA_LINEA_TAVARES.BorderColor = blanco;
            CELDA_LINEA_TAVARES.HorizontalAlignment = 1;
            CELDA_LINEA_TAVARES.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_LINEA_TAVARES);

            PdfPCell CELDA_LINEA_HERNANDEZ = new PdfPCell(new Phrase("_______________________________", _mediumFont));
            CELDA_LINEA_HERNANDEZ.BackgroundColor = blanco;
            CELDA_LINEA_HERNANDEZ.BorderColor = blanco;
            CELDA_LINEA_HERNANDEZ.HorizontalAlignment = 1;
            CELDA_LINEA_HERNANDEZ.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_LINEA_HERNANDEZ);

            PdfPCell CELDA_LINEA_VISCONTI = new PdfPCell(new Phrase("_______________________________", _mediumFont));
            CELDA_LINEA_VISCONTI.BackgroundColor = blanco;
            CELDA_LINEA_VISCONTI.BorderColor = blanco;
            CELDA_LINEA_VISCONTI.HorizontalAlignment = 1;
            CELDA_LINEA_VISCONTI.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_LINEA_VISCONTI);

            PdfPCell CELDA_TAVARES = new PdfPCell(new Phrase("Miguel Ángel TAVARES", _mediumFont));
            CELDA_TAVARES.BackgroundColor = blanco;
            CELDA_TAVARES.BorderColor = blanco;
            CELDA_TAVARES.HorizontalAlignment = 1;
            CELDA_TAVARES.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_TAVARES);

            PdfPCell CELDA_HERNANDEZ = new PdfPCell(new Phrase("Carlos Aníbal HERNANDEZ", _mediumFont));
            CELDA_HERNANDEZ.BackgroundColor = blanco;
            CELDA_HERNANDEZ.BorderColor = blanco;
            CELDA_HERNANDEZ.HorizontalAlignment = 1;
            CELDA_HERNANDEZ.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_HERNANDEZ);

            PdfPCell CELDA_VISCONTI = new PdfPCell(new Phrase("Eliseo Aníbal VISCONTI", _mediumFont));
            CELDA_VISCONTI.BackgroundColor = blanco;
            CELDA_VISCONTI.BorderColor = blanco;
            CELDA_VISCONTI.HorizontalAlignment = 1;
            CELDA_VISCONTI.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_VISCONTI);


            PdfPCell CELDA_SECRETARIO = new PdfPCell(new Phrase("SECRETARIO GENERAL", _mediumFont));
            CELDA_SECRETARIO.BackgroundColor = blanco;
            CELDA_SECRETARIO.BorderColor = blanco;
            CELDA_SECRETARIO.HorizontalAlignment = 1;
            CELDA_SECRETARIO.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_SECRETARIO);

            PdfPCell CELDA_TESORERO = new PdfPCell(new Phrase("TESORERO", _mediumFont));
            CELDA_TESORERO.BackgroundColor = blanco;
            CELDA_TESORERO.BorderColor = blanco;
            CELDA_TESORERO.HorizontalAlignment = 1;
            CELDA_TESORERO.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_TESORERO);

            PdfPCell CELDA_PRESIDENTE = new PdfPCell(new Phrase("PRESIDENTE", _mediumFont));
            CELDA_PRESIDENTE.BackgroundColor = blanco;
            CELDA_PRESIDENTE.BorderColor = blanco;
            CELDA_PRESIDENTE.HorizontalAlignment = 1;
            CELDA_PRESIDENTE.FixedHeight = 16f;
            TABLA_FIRMAS.AddCell(CELDA_PRESIDENTE);


            doc.Add(TABLA_FIRMAS);

            #endregion

            Paragraph P_PROCEDIO = new Paragraph("Se procedió al pago ordenado precedentemente", _mediumFont);
            P_PROCEDIO.Alignment = Element.ALIGN_LEFT;
            P_PROCEDIO.SpacingBefore = 25;
            doc.Add(P_PROCEDIO);

            Paragraph P_CREV = new Paragraph("VERIFICACIÓN COMISIÓN REVISORA DE CUENTAS", _mediumFont);
            P_CREV.Alignment = Element.ALIGN_LEFT;
            P_CREV.SpacingBefore = 15;
            doc.Add(P_CREV);

            Paragraph P_LINEA_CREV = new Paragraph("____________________________________________________________________________________________________________", _mediumFont);
            P_LINEA_CREV.Alignment = Element.ALIGN_LEFT;
            P_LINEA_CREV.SpacingBefore = 15;
            doc.Add(P_LINEA_CREV);

            Paragraph P_OBSERVACIONES = new Paragraph("OBSERVACIONES: " + OBSERVACIONES, _mediumFont);
            P_OBSERVACIONES.Alignment = Element.ALIGN_LEFT;
            P_OBSERVACIONES.SpacingBefore = 15;
            doc.Add(P_OBSERVACIONES);

            doc.Close();
            writer.Close();
        }

        private void Compras_Load(object sender, EventArgs e)
        {

        }
    }
}