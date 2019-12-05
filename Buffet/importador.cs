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

namespace Buffet
{
    public partial class importador : Form
    {
        string G_ROL { get; set; }
        bo dlog = new bo();
        db db = new db();
        Utils cu = new Utils();
        maxid mid = new maxid();
        private int CAJA_SELECCIONADA { get; set; }

        public importador(string P_ROL)
        {
            InitializeComponent();
            G_ROL = P_ROL;
            cargaInicial();
        }

        private void cargaInicial()
        {
            cajasDiarias(G_ROL);

        }

        private void cajasDiarias(string ROL)
        {
            string QUERY = "SELECT * FROM CONFITERIA_CAJA_DIARIA WHERE EXPORTADA = 0 AND ROL = '" + ROL + "';";
            DataSet CAJAS = cu.getDataFromQuery(QUERY, ROL);
            dgCajasAnteriores.Rows.Clear();

            if (CAJAS.Tables.Count > 0)
            {
                foreach (DataRow ROW_CAJA in CAJAS.Tables[0].Rows)
                {
                    int ID = int.Parse(ROW_CAJA[0].ToString());
                    string FECHA = ROW_CAJA[1].ToString().Replace(" 00:00:00", "");
                    string USUARIO = ROW_CAJA[2].ToString().Trim();
                    decimal EFECTIVO = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(ROW_CAJA[3].ToString()))));
                    decimal TARJETAS = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(ROW_CAJA[4].ToString()))));
                    decimal DESCUENTOS = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(ROW_CAJA[5].ToString()))));
                    decimal ESPECIALES = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(ROW_CAJA[6].ToString()))));
                    dgCajasAnteriores.Rows.Add(ID, FECHA, USUARIO, EFECTIVO, TARJETAS, DESCUENTOS, ESPECIALES);
                }
            }
        }

        private void comandas(string ROL, int CAJA_DIARIA)
        {
            string QUERY = "SELECT NRO_COMANDA, FECHA, IMPORTE, NOMBRE_SOCIO, NRO_SOC, NRO_DEP, ID FROM CONFITERIA_COMANDAS WHERE EXPORTADA = 0 AND RENDIDA = " + CAJA_DIARIA + " AND ROL = '" + ROL + "';";
            DataSet COMANDAS = cu.getDataFromQuery(QUERY, ROL);
            dgComandas.Rows.Clear();

            if (COMANDAS.Tables.Count > 0)
            {
                foreach (DataRow ROW_COMANDA in COMANDAS.Tables[0].Rows)
                {
                    string NRO_COMANDA = ROW_COMANDA[0].ToString().Trim();
                    decimal IMPORTE = Convert.ToDecimal(string.Format("{0:n}", (Convert.ToDecimal(ROW_COMANDA[2].ToString()))));
                    string FECHA = ROW_COMANDA[1].ToString().Trim().Substring(0, 10);
                    string NOMBRE = ROW_COMANDA[3].ToString().Trim();
                    string NRO_SOC = ROW_COMANDA[4].ToString().Trim();
                    string NRO_DEP = ROW_COMANDA[5].ToString().Trim();
                    string ID = ROW_COMANDA[6].ToString().Trim();
                    dgComandas.Rows.Add(NRO_COMANDA, IMPORTE, FECHA, NOMBRE, NRO_SOC, NRO_DEP, ID);
                }
            }
        }

        private void importarItems(int ID_COMANDA, int N_ID_COMANDA)
        {
            string QUERY = "SELECT * FROM CONFITERIA_COMANDA_ITEM WHERE COMANDA = " + ID_COMANDA + " AND ROL = '" + G_ROL + "';";
            DataSet ITEMS = cu.getDataFromQuery(QUERY, G_ROL);

            if (ITEMS.Tables.Count > 0)
            {
                int ID; int COMANDA; int ITEM; int CANTIDAD; int TIPO; decimal VALOR; decimal SUBTOTAL; string ITEM_DETALLE; string TIPO_DETALLE; string IMPRESO; string OBSERVACIONES; string ROL;

                foreach (DataRow ROW_ITEM in ITEMS.Tables[0].Rows)
                {
                    ID = int.Parse(ROW_ITEM[0].ToString()); COMANDA = N_ID_COMANDA; ITEM = int.Parse(ROW_ITEM[2].ToString()); CANTIDAD = int.Parse(ROW_ITEM[3].ToString()); TIPO = int.Parse(ROW_ITEM[4].ToString());
                    VALOR = decimal.Parse(ROW_ITEM[5].ToString()); SUBTOTAL = decimal.Parse(ROW_ITEM[6].ToString()); ITEM_DETALLE = ROW_ITEM[7].ToString(); TIPO_DETALLE = ROW_ITEM[8].ToString(); IMPRESO = ROW_ITEM[9].ToString();
                    OBSERVACIONES = ROW_ITEM[10].ToString(); ROL = ROW_ITEM[11].ToString();

                    try
                    {
                        int N_ID_ITEM = cu.getGeneratorValue("CONFITERIA_COMANDA_ITEM_GEN");
                        string IMP_ITEM_QUERY = "INSERT INTO CONFITERIA_COMANDA_ITEM (ID, COMANDA, ITEM, CANTIDAD, TIPO, VALOR, SUBTOTAL, ITEM_DETALLE, TIPO_DETALLE, IMPRESO, OBSERVACIONES, ROL) " +
                            "VALUES (" + N_ID_ITEM + ", " + N_ID_COMANDA + ", " + ITEM + ", " + CANTIDAD + ", " + TIPO + ", " + VALOR + ", " + SUBTOTAL + ", '" + ITEM_DETALLE + "', '" + TIPO_DETALLE + "', '" + IMPRESO + "', '" + OBSERVACIONES + 
                            "', '" + ROL + "')";

                        db.Ejecuto_Consulta(IMP_ITEM_QUERY);

                        cu.setGeneratorValue("CONFITERIA_COMANDA_ITEM_GEN", N_ID_ITEM + 1);

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO INSERTAR EL ITEM " + ID + "\n\r" + error);
                    }
                }
            }
        }

        private void importarComandas(DataSet COMANDAS, int ID_CAJA)
        {
            if (COMANDAS.Tables.Count > 0)
            {
                int MAX = COMANDAS.Tables[0].Rows.Count;
                pbImportar.Visible = true;
                pbImportar.Maximum = MAX;
                pbImportar.Step = 1;

                int ID; DateTime FECHA; int MESA; int MOZO; decimal IMPORTE; int NRO_SOC; int NRO_DEP; int BARRA; int PERSONAS; string NOMBRE_SOCIO;
                string AFILIADO; string BENEFICIO; string USUARIO; int DESCUENTO = 0; int FORMA_DE_PAGO; int RENDIDA; int CONTRALOR = 0;
                Nullable<DateTime> ANULADA; string ANULADA_STR = "NULL"; string USR_ANULA; int COM_BORRADOR = 0; string CONSUME; int TIPO_COMANDA = 0; int DESCUENTO_APLICADO = 0;
                decimal IMPORTE_DESCONTADO = 0; int NRO_COMANDA; string ROL; int EXPORTADA; int ID_ANTERIOR;

                foreach (DataRow ROW_COMANDA in COMANDAS.Tables[0].Rows)
                {
                    ID = int.Parse(ROW_COMANDA[0].ToString()); FECHA = Convert.ToDateTime(ROW_COMANDA[1]);
                    MESA = int.Parse(ROW_COMANDA[2].ToString()); MOZO = int.Parse(ROW_COMANDA[3].ToString());
                    IMPORTE = decimal.Parse(ROW_COMANDA[4].ToString()); NRO_SOC = int.Parse(ROW_COMANDA[5].ToString());
                    NRO_DEP = int.Parse(ROW_COMANDA[6].ToString()); BARRA = int.Parse(ROW_COMANDA[7].ToString());
                    PERSONAS = int.Parse(ROW_COMANDA[8].ToString()); NOMBRE_SOCIO = ROW_COMANDA[9].ToString();
                    AFILIADO = ROW_COMANDA[10].ToString(); BENEFICIO = ROW_COMANDA[11].ToString(); USUARIO = ROW_COMANDA[12].ToString();

                    if (ROW_COMANDA[13].ToString() != "")
                        DESCUENTO = int.Parse(ROW_COMANDA[13].ToString());

                    FORMA_DE_PAGO = int.Parse(ROW_COMANDA[14].ToString());
                    RENDIDA = ID_CAJA;

                    if (ROW_COMANDA[16].ToString() != "")
                        CONTRALOR = int.Parse(ROW_COMANDA[16].ToString());

                    if (ROW_COMANDA[17].ToString() == "")
                        ANULADA = null;
                    else
                        ANULADA = Convert.ToDateTime(ROW_COMANDA[17]);

                    USR_ANULA = ROW_COMANDA[18].ToString();

                    if (ROW_COMANDA[19].ToString() != "")
                        COM_BORRADOR = int.Parse(ROW_COMANDA[19].ToString());

                    CONSUME = ROW_COMANDA[20].ToString();

                    if (ROW_COMANDA[21].ToString() != "")
                        TIPO_COMANDA = int.Parse(ROW_COMANDA[21].ToString());

                    if (ROW_COMANDA[22].ToString() != "")
                        DESCUENTO_APLICADO = int.Parse(ROW_COMANDA[22].ToString());

                    if (ROW_COMANDA[23].ToString() != "")
                        IMPORTE_DESCONTADO = decimal.Parse(ROW_COMANDA[23].ToString());

                    NRO_COMANDA = int.Parse(ROW_COMANDA[24].ToString()); ROL = ROW_COMANDA[25].ToString();
                    EXPORTADA = 1; ID_ANTERIOR = int.Parse(ROW_COMANDA[27].ToString());

                    try
                    {
                        int N_ID_COM = cu.getGeneratorValue("CONFITERIA_COMANDAS_GEN");

                        string IMP_COM_QUERY = "INSERT INTO CONFITERIA_COMANDAS (ID, MESA, FECHA, MOZO, IMPORTE, NRO_SOC, NRO_DEP, BARRA, PERSONAS, " +
                            "AFILIADO, BENEFICIO, NOMBRE_SOCIO, USUARIO, DESCUENTO, FORMA_DE_PAGO, RENDIDA, CONTRALOR, ANULADA, USR_ANULA, COM_BORRADOR, " +
                            "CONSUME, TIPO_COMANDA, DESCUENTO_APLICADO, IMPORTE_DESCONTADO, ROL, NRO_COMANDA, EXPORTADA, ID_ANTERIOR) VALUES " +
                            "(" + N_ID_COM + "," + MESA + ",'" + FECHA + "'," + MOZO + "," + IMPORTE + "," + NRO_SOC + "," + NRO_DEP + "," + BARRA + "," +
                            PERSONAS + ",'" + AFILIADO.Trim() + "','" + BENEFICIO.Trim() + "','" + NOMBRE_SOCIO.Trim() + "','" + USUARIO.Trim() + "'," +
                            DESCUENTO + "," + FORMA_DE_PAGO + "," + RENDIDA + "," + CONTRALOR + ",";

                        if (ANULADA == null)
                        {
                            IMP_COM_QUERY += ANULADA_STR + ",";
                        }
                        else
                        {
                            IMP_COM_QUERY += "'" + ANULADA + "'";
                        }

                        IMP_COM_QUERY += "'" + USR_ANULA.Trim() + "'," + COM_BORRADOR + ",'" + CONSUME.Trim() + "'," + TIPO_COMANDA + "," + DESCUENTO_APLICADO + "," + IMPORTE_DESCONTADO + ",'" + 
                        ROL.Trim() + "'," + NRO_COMANDA + "," + EXPORTADA + "," + ID_ANTERIOR + ");";

                        db.Ejecuto_Consulta(IMP_COM_QUERY);

                        bool SET_EXPORTADO = cu.setExportado("CONFITERIA_COMANDAS", "EXPORTADA", ID, G_ROL, 1);

                        if (SET_EXPORTADO == false)
                        {
                            MessageBox.Show("NO SE PUDO MARCAR LA COMANDA " + NRO_COMANDA + " COMO EXPORTADA\nES POSIBLE QUE SIGA APARECIENDO EN LOS LISTADOS", "ERROR!");
                        }
                        else
                        {
                            importarItems(ID, N_ID_COM);
                        }

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO IMPORTAR LA COMANDA " + NRO_COMANDA + "\nSE INTENTARÁ IMPORTAR LAS SIGUIENTES COMANDAS\n" + error, "ERROR!");
                    }

                    pbImportar.PerformStep();
                }
            }
        }

        private void importar()
        {
            if (MessageBox.Show("¿IMPORTAR COMANDAS Y CAJAS DIARIAS?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string GRABA_CAJA = cu.getGrabaCaja();
                string GRABA_COMANDA = cu.getGrabaComanda();

                if (GRABA_CAJA == "S" && GRABA_COMANDA == "S")
                {
                    bool SET_GRABA_CAJA = cu.setGrabaCaja("N");
                    bool SET_GRABA_COMANDA = cu.setGrabaComanda("N");

                    if (SET_GRABA_CAJA == true && SET_GRABA_COMANDA == true)
                    {
                        bool SET_ID_ANTERIOR_CAJA = cu.setIdAnteriorCaja(G_ROL);
                        bool SET_ID_ANTERIO_COMANDA = cu.setIdAnteriorComanda(G_ROL);

                        string QUERY = "SELECT * FROM CONFITERIA_CAJA_DIARIA WHERE EXPORTADA = 0 AND ROL = '" + G_ROL + "';";
                        DataSet CAJAS = cu.getDataFromQuery(QUERY, G_ROL);
                        QUERY = "SELECT * FROM CONFITERIA_COMANDAS WHERE EXPORTADA = 0 AND ROL = '" + G_ROL + "';";
                        DataSet COMANDAS = cu.getDataFromQuery(QUERY, G_ROL);

                        if (CAJAS.Tables.Count > 0)
                        {
                            if (SET_ID_ANTERIOR_CAJA == true)
                            {
                                int MAX = CAJAS.Tables[0].Rows.Count;
                                pbImportar.Visible = true;
                                pbImportar.Maximum = MAX;
                                pbImportar.Step = 1;

                                int ID; string FECHA; string USUARIO; decimal EFECTIVO; decimal TARJETAS; decimal DESCUENTOS; decimal ESPECIALES;
                                string ROL; int EXPORTADA; int ID_ANTERIOR;

                                foreach (DataRow ROW_CAJA in CAJAS.Tables[0].Rows)
                                {
                                    ID = int.Parse(ROW_CAJA[0].ToString());
                                    FECHA = ROW_CAJA[1].ToString().Replace(" 00:00:00", "");
                                    USUARIO = ROW_CAJA[2].ToString().Trim();
                                    EFECTIVO = decimal.Parse(ROW_CAJA[3].ToString());
                                    TARJETAS = decimal.Parse(ROW_CAJA[4].ToString());
                                    DESCUENTOS = decimal.Parse(ROW_CAJA[5].ToString());
                                    ESPECIALES = decimal.Parse(ROW_CAJA[6].ToString());
                                    ROL = ROW_CAJA[7].ToString().Trim();
                                    EXPORTADA = 1;
                                    ID_ANTERIOR = int.Parse(ROW_CAJA[9].ToString());

                                    bool IMPORTAR = dlog.impCajaDiariaConfiteria(FECHA, USUARIO, EFECTIVO, TARJETAS, DESCUENTOS, ESPECIALES, ROL, EXPORTADA, ID_ANTERIOR);
                                    int ID_CAJA = int.Parse(mid.m("ID", "CONFITERIA_CAJA_DIARIA"));

                                    if (IMPORTAR == true)
                                    {
                                        bool SET_EXPORTADO = cu.setExportado("CONFITERIA_CAJA_DIARIA", "EXPORTADA", ID, ROL, 1);

                                        if (SET_EXPORTADO == false)
                                        {
                                            MessageBox.Show("NO SE PUDO MARCAR LA CAJA DEL DIA " + FECHA + " COMO EXPORTADA\nES POSIBLE QUE SIGA APARECIENDO EN LOS LISTADOS", "ERROR!");
                                        }
                                        else
                                        {
                                            importarComandas(COMANDAS, ID_CAJA);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("NO SE PUDO IMPORTAR LA CAJA DEL DIA " + FECHA + "\nSE INTENTARÁ IMPORTAR LAS SIGUIENTES CAJAS", "ERROR!");
                                    }

                                    pbImportar.PerformStep();
                                }
                            }

                            pbImportar.Visible = false;
                        }

                        pbImportar.Visible = false;

                        SET_GRABA_CAJA = cu.setGrabaCaja("S");
                        SET_GRABA_COMANDA = cu.setGrabaComanda("S");

                        if (SET_GRABA_CAJA == true && SET_GRABA_COMANDA == true)
                        {
                            MessageBox.Show("EL PROCESO DE IMPORTACIÓN FINALIZÓ CORRECTAMENTE", "LISTO!");
                            cargaInicial();
                        }
                        else
                        {
                            MessageBox.Show("NO SE PUDIERON DESBLOQUEAR LAS TABLAS\nES POSIBLE QUE NO SE PUEDAN REALIZAR COMANDAS", "ERROR!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("NO SE PUDO REALIZAR LA IMPORTACION\nFALLÓ EL BLOQUEO DE LAS TABLAS", "ERROR!");
                    }
                }
                else
                {
                    MessageBox.Show("NO SE PUDO REALIZAR LA IMPORTACION\nLAS TABLAS SE ENCUENTRAN BLOQUEADAS POR OTRO USUARIO", "ERROR!");
                }
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            importar();
        }

        private void dgCajasAnteriores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int CAJA_DIARIA = 0;

            foreach (DataGridViewRow row in dgCajasAnteriores.SelectedRows)
            {
                if (row.Cells[0].Value.ToString() != "")
                    CAJA_DIARIA = int.Parse(row.Cells[0].Value.ToString());
            }

            if (CAJA_DIARIA > 0)
                comandas(G_ROL, CAJA_DIARIA);
        }

        private void BtnImportarArticulos_Click(object sender, EventArgs e)
        {

        }
    }
}
