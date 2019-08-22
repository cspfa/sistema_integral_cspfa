using System;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SOCIOS;

namespace Confiteria
{
    public partial class grillaPreComanda : Form
    {
        bo dlog = new bo();
        Utils utils = new Utils();

        public grillaPreComanda()
        {
            InitializeComponent();
            string FECHA = DateTime.Today.ToShortDateString();
            buscarIngresos(FECHA, "NO");
            llenarGrillaIngresos(INGRESOS, dataGridView1);
            llenarGrillaMesas();
            comboOrdenListado();
        }

        private DataSet INGRESOS { get; set; }
        private DataSet INGRESOS_IMPRESOS { get; set; }
        List<ITEMS_CONFITERIA> LISTA_ITEMS;

        public class ITEMS_CONFITERIA
        {
            public string NRO { get; set; }
            public string DEP { get; set; }
            public string APELLIDO { get; set; }
            public string NOMBRE { get; set; }
            public string TIP_SOCIO { get; set; }
            public string ROL { get; set; }
            public string ID_DESTINO { get; set; }
            public string ID_PROFESIONAL { get; set; }
            public string SECUENCIA { get; set; }
            public string BARRA { get; set; }
            public string DTO { get; set; }
            public string DESTINO { get; set; }
            public string PROFESIONAL { get; set; }
            public string RECIBO { get; set; }
            public string NRO_SOC { get; set; }
            public string NRO_DEP { get; set; }
            public string BONO { get; set; }
            public string BR { get; set; }
            public string CUENTA { get; set; }
            public string DNI { get; set; }
            public string GRUPO { get; set; }
            public string MC { get; set; }

            public ITEMS_CONFITERIA(string nro, string dep, string apellido, string nombre, string tip_socio, string rol, string id_destino, string id_profesional, string secuencia,
                string barra, string dto, string destino, string profesional, string recibo, string nro_soc, string nro_dep, string bono, string br, string cuenta, string dni, string grupo, 
                string mc)
            {
                NRO = nro;
                DEP = dep;
                APELLIDO = apellido; 
                NOMBRE = nombre;
                TIP_SOCIO = tip_socio;
                ROL = rol;
                ID_DESTINO = id_destino;
                ID_PROFESIONAL = id_profesional;
                SECUENCIA = secuencia;
                BARRA = barra;
                DTO = dto;
                DESTINO = destino;
                PROFESIONAL = profesional;
                RECIBO = recibo; 
                NRO_SOC = nro_soc;
                NRO_DEP = nro_dep;
                BONO = bono;
                BR = br;
                CUENTA = cuenta; 
                DNI = dni;
                GRUPO = grupo;
                MC = mc;
            }
        }

        private void comboOrdenListado()
        {
            cbOrdenListado.Items.Add("COMANDA");
            cbOrdenListado.Items.Add("BORRADOR");
            cbOrdenListado.SelectedIndex = 0;
        }

        #region BUSCAR INGRESOS
        private void buscarIngresos(string FECHA, string IMPRESA)
        {
            string  QUERY = "SELECT CASE TIP_SOCIO WHEN 'ADH' THEN A.NRO_ADH WHEN 'INP' THEN A.NRO_ADH WHEN 'VIS' THEN A.NRO_SOC ELSE A.NRO_SOC END AS NRO_SOC,";
            QUERY = QUERY + " CASE TIP_SOCIO WHEN 'ADH' THEN A.NRO_DEPADH WHEN 'INP' THEN A.NRO_DEPADH WHEN 'VIS' THEN A.NRO_DEP ELSE A.NRO_DEP END AS NRO_DEP,";
            QUERY = QUERY + " A.APELLIDO, A.NOMBRE, A.TIP_SOCIO, A.ROL, A.ID_DESTINO, A.ID_PROFESIONAL, A.SECUENCIA, A.BARRA, A.COD_DTO, SA.DETALLE, P.NOMBRE AS NOMBREPROF,";
            QUERY = QUERY + " A.NRO_RECIBO, A.NRO_SOC AS NUMERO_SOCIO, A.NRO_DEP AS NUMERO_DEPURACION, A.NRO_BONO, P.BONO_RECIBO, P.CUENTA, A.DNI, A.GRUPO, A.MOROSO";
            QUERY = QUERY + " FROM INGRESOS_A_PROCESAR A, SECTACT SA, PROFESIONALES P";
            QUERY = QUERY + " WHERE A.NRO_SOC != 300 AND A.NRO_SOC != 200";

            if (FECHA == "XXX")
            {
                QUERY = QUERY + " AND EXTRACT(DAY FROM A.FECHA)=EXTRACT(DAY FROM CURRENT_TIMESTAMP)";
                QUERY = QUERY + " AND EXTRACT(MONTH FROM A.FECHA)=EXTRACT(MONTH FROM CURRENT_TIMESTAMP)";
                QUERY = QUERY + " AND EXTRACT(YEAR FROM A.FECHA)=EXTRACT(YEAR FROM CURRENT_TIMESTAMP)";
            }
            else
            {
                string DAY = FECHA.Substring(0, 2);
                string MONTH = FECHA.Substring(3, 2);
                string YEAR = FECHA.Substring(6, 4);
                QUERY = QUERY + " AND EXTRACT(DAY FROM A.FECHA)=" + DAY;
                QUERY = QUERY + " AND EXTRACT(MONTH FROM A.FECHA)=" + MONTH;
                QUERY = QUERY + " AND EXTRACT(YEAR FROM A.FECHA)=" + YEAR;
            }

            if (IMPRESA == "NO")
            {
                QUERY = QUERY + " AND A.COMANDA IS NULL";
            }
            else if (IMPRESA == "SI")
            {
                QUERY = QUERY + " AND A.COMANDA IS NOT NULL";
            }

            if(VGlobales.vp_role != "CONFITERIA")

                QUERY = QUERY + " AND A.ROL = '" + VGlobales.vp_role + "'";


            QUERY = QUERY + " AND A.ID_DESTINO = SA.ID";
            QUERY = QUERY + " AND A.ID_PROFESIONAL = P.ID";
            QUERY = QUERY + " ORDER BY A.SECUENCIA DESC";

            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);
                    LISTA_ITEMS = new List<ITEMS_CONFITERIA>();

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (IMPRESA == "NO")
                        {
                            INGRESOS = ds;
                        }
                        else if (IMPRESA == "SI")
                        {
                            INGRESOS_IMPRESOS = ds;
                        }

                        while (reader.Read())
                        {
                            string NRO = reader.GetString(reader.GetOrdinal("NRO_SOC")).Trim();
                            string DEP = reader.GetString(reader.GetOrdinal("NRO_DEP")).Trim();
                            string APELLIDO = reader.GetString(reader.GetOrdinal("APELLIDO")).Trim();
                            string NOMBRE = reader.GetString(reader.GetOrdinal("NOMBRE")).Trim();
                            string TIP_SOCIO = reader.GetString(reader.GetOrdinal("TIP_SOCIO")).Trim();
                            string ROL = reader.GetString(reader.GetOrdinal("ROL")).Trim();
                            string ID_DESTINO = reader.GetString(reader.GetOrdinal("ID_DESTINO")).Trim();
                            string ID_PROFESIONAL = reader.GetString(reader.GetOrdinal("ID_PROFESIONAL")).Trim();
                            string SECUENCIA = reader.GetString(reader.GetOrdinal("SECUENCIA")).Trim();
                            string BARRA = reader.GetString(reader.GetOrdinal("BARRA")).Trim();
                            string DTO = reader.GetString(reader.GetOrdinal("COD_DTO")).Trim();
                            string DESTINO = reader.GetString(reader.GetOrdinal("DETALLE")).Trim();
                            string PROFESIONAL = reader.GetString(reader.GetOrdinal("NOMBREPROF")).Trim();
                            string RECIBO = reader.GetString(reader.GetOrdinal("NRO_RECIBO")).Trim();
                            string NRO_SOC = reader.GetString(reader.GetOrdinal("NUMERO_SOCIO")).Trim();
                            string NRO_DEP = reader.GetString(reader.GetOrdinal("NUMERO_DEPURACION")).Trim();
                            string BONO = reader.GetString(reader.GetOrdinal("NRO_BONO")).Trim();
                            string BR = reader.GetString(reader.GetOrdinal("BONO_RECIBO")).Trim();
                            string CUENTA = reader.GetString(reader.GetOrdinal("CUENTA")).Trim();
                            string DNI = reader.GetString(reader.GetOrdinal("DNI")).Trim();
                            string GRUPO = reader.GetString(reader.GetOrdinal("GRUPO")).Trim();
                            string MC = reader.GetString(reader.GetOrdinal("MOROSO")).Trim();
                          
                            LISTA_ITEMS.Add(new ITEMS_CONFITERIA(NRO, DEP, APELLIDO, NOMBRE, TIP_SOCIO, ROL, ID_DESTINO, ID_PROFESIONAL, SECUENCIA, BARRA, DTO, DESTINO, PROFESIONAL, 
                                RECIBO, NRO_SOC, NRO_DEP, BONO, BR, CUENTA, DNI, GRUPO, MC));
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
        #endregion

        #region LLENAR GRILLA INGRESOS
        private void llenarGrillaIngresos(DataSet INGRESOS, DataGridView GRILLA)
        {
            if (INGRESOS.Tables.Count > 0)
            {
                DataTable dt1 = new DataTable("RESULTADOS");
                dt1.Columns.Add("NRO", typeof(string));
                dt1.Columns.Add("DEP", typeof(string));
                dt1.Columns.Add("APELLIDO", typeof(string));
                dt1.Columns.Add("NOMBRE", typeof(string));
                dt1.Columns.Add("TIP_SOCIO", typeof(string));
                dt1.Columns.Add("ROL", typeof(string));
                dt1.Columns.Add("DESTINO", typeof(string));
                dt1.Columns.Add("PROFESIONAL", typeof(string));
                dt1.Columns.Add("SECUENCIA", typeof(string));
                dt1.Columns.Add("/", typeof(string));
                dt1.Columns.Add("DTO", typeof(string));
                dt1.Columns.Add("RECIBO", typeof(string));
                dt1.Columns.Add("ID_PROFESIONAL", typeof(string));
                dt1.Columns.Add("ID_DESTINO", typeof(string));
                dt1.Columns.Add("NRO_SOC", typeof(string));
                dt1.Columns.Add("NRO_DEP", typeof(string));
                dt1.Columns.Add("BONO", typeof(string));
                dt1.Columns.Add("BR", typeof(string));
                dt1.Columns.Add("CUENTA", typeof(string));
                dt1.Columns.Add("DNI", typeof(string));
                dt1.Columns.Add("GRUPO", typeof(string));
                dt1.Columns.Add("MC", typeof(string));

                foreach (DataRow row in INGRESOS.Tables[0].Rows)
                {
                    dt1.Rows.Add(row[0].ToString().Trim(),
                                    row[1].ToString().Trim(),
                                    row[2].ToString().Trim(),
                                    row[3].ToString().Trim(),
                                    row[4].ToString().Trim(),
                                    row[5].ToString().Trim(),
                                    row[6].ToString().Trim(),
                                    row[7].ToString().Trim(),
                                    row[8].ToString().Trim(),
                                    row[9].ToString().Trim(),
                                    row[10].ToString().Trim(),
                                    row[11].ToString().Trim(),
                                    row[12].ToString().Trim(),
                                    row[13].ToString().Trim(),
                                    row[14].ToString().Trim(),
                                    row[15].ToString().Trim(),
                                    row[16].ToString().Trim(),
                                    row[17].ToString().Trim(),
                                    row[18].ToString().Trim(),
                                    row[19].ToString().Trim(),
                                    row[20].ToString().Trim(),
                                    row[21].ToString().Trim());
                }

                GRILLA.DataSource = dt1;
                GRILLA.Columns[0].Width = 50;
                GRILLA.Columns[1].Width = 40;
                GRILLA.Columns[2].Width = 145;
                GRILLA.Columns[3].Width = 195;
                GRILLA.Columns[4].Width = 80;
                GRILLA.Columns[5].Width = 130;
                GRILLA.Columns[9].Width = 40;
                GRILLA.Columns[5].Visible = true;
                GRILLA.Columns[6].Visible = false;
                GRILLA.Columns[7].Visible = false;
                GRILLA.Columns[8].Visible = false;
                GRILLA.Columns[9].Visible = false;
                GRILLA.Columns[10].Visible = false;
                GRILLA.Columns[11].Visible = false;
                GRILLA.Columns[12].Visible = false;
                GRILLA.Columns[13].Visible = false;
                GRILLA.Columns[14].Visible = false;
                GRILLA.Columns[15].Visible = false;
                GRILLA.Columns[16].Visible = false;
                GRILLA.Columns[17].Visible = false;
                GRILLA.Columns[18].Visible = false;
                GRILLA.Columns[19].Visible = false;
                GRILLA.Columns[19].Width = 70;
                GRILLA.Columns[20].Visible = false;
                GRILLA.Columns[21].Visible = false;
            }
        }
        #endregion

        #region LLENAR GRILLA MESAS
        private void llenarGrillaMesas()
        {
            try
            {
                string QUERY = "SELECT MESA, ESTADO, DESDE, SOCIO, ID_COMANDA, NRO_SOC, NRO_DEP, BARRA, SECUENCIA, PERSONAS, FORMA_DE_PAGO, NRO, NRO_COMANDA FROM CONFITERIA_TEMP_MESAS WHERE ROL = '" + VGlobales.vp_role + "' ORDER BY NRO ASC;";
                DataSet ds1 = new DataSet();
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataTable dt1 = new DataTable("RESULTADOS");
                    dt1.Columns.Add("MESA", typeof(string));
                    dt1.Columns.Add("ESTADO", typeof(string));
                    dt1.Columns.Add("DESDE", typeof(string));
                    dt1.Columns.Add("NOMBRE Y APELLIDO", typeof(string));
                    dt1.Columns.Add("COM", typeof(string));
                    //ocultos
                    dt1.Columns.Add("NRO_SOC", typeof(string));
                    dt1.Columns.Add("NRO_DEP", typeof(string));
                    dt1.Columns.Add("BARRA", typeof(string));
                    dt1.Columns.Add("SECUENCIA", typeof(string));
                    dt1.Columns.Add("PE", typeof(string));
                    dt1.Columns.Add("PA", typeof(string));
                    dt1.Columns.Add("ID_MESA", typeof(string));
                    dt1.Columns.Add("ID_COMANDA", typeof(string));
                    //ocultos
                    ds1.Tables.Add(dt1);
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        string MESA = reader3.GetString(reader3.GetOrdinal("NRO")).Trim();
                        string ESTADO = reader3.GetString(reader3.GetOrdinal("ESTADO")).Trim();
                        string DESDE = reader3.GetString(reader3.GetOrdinal("DESDE")).Trim();
                        string SOCIO = reader3.GetString(reader3.GetOrdinal("SOCIO")).Trim();
                        string ID_COMANDA = reader3.GetString(reader3.GetOrdinal("ID_COMANDA")).Trim();
                        string NRO_SOC = reader3.GetString(reader3.GetOrdinal("NRO_SOC")).Trim();
                        string NRO_DEP = reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim();
                        string BARRA = reader3.GetString(reader3.GetOrdinal("BARRA")).Trim();
                        string SECUENCIA = reader3.GetString(reader3.GetOrdinal("SECUENCIA")).Trim();
                        string PERSONAS = reader3.GetString(reader3.GetOrdinal("PERSONAS"));
                        string FORMA_DE_PAGO = reader3.GetString(reader3.GetOrdinal("FORMA_DE_PAGO"));
                        string ID_MESA = reader3.GetString(reader3.GetOrdinal("MESA"));
                        string NRO_COMANDA = reader3.GetString(reader3.GetOrdinal("NRO_COMANDA"));
                        dt1.Rows.Add(MESA, ESTADO, DESDE, SOCIO, NRO_COMANDA, NRO_SOC, NRO_DEP, BARRA, SECUENCIA, PERSONAS, FORMA_DE_PAGO, ID_MESA, ID_COMANDA);
                    }

                    reader3.Close();
                    dgMesas.DataSource = dt1;
                    dgMesas.Columns[0].Width = 40;
                    dgMesas.Columns[1].Width = 65;
                    dgMesas.Columns[2].Width = 135;
                    dgMesas.Columns[3].Width = 300;
                    dgMesas.Columns[4].Width = 40;
                    dgMesas.Columns[5].Visible = false;
                    dgMesas.Columns[6].Visible = false;
                    dgMesas.Columns[7].Visible = false;
                    dgMesas.Columns[8].Visible = false;
                    dgMesas.Columns[9].Visible = false;
                    dgMesas.Columns[10].Visible = false;
                    dgMesas.Columns[11].Visible = false;
                    dgMesas.Columns[12].Visible = false;
                    transaction.Commit();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR AL CARGAR LOS RESULTADOS\n"+e);
            }
        }
        #endregion

        private void pintarMorosos()
        {
            int X = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[21].Value.ToString() == "S")
                {
                    dataGridView1.Rows[X].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[X].DefaultCellStyle.BackColor = Color.White;
                    dataGridView1.Rows[X].DefaultCellStyle.ForeColor = Color.Black;
                }

                X++;
            }
        }

        public void abrirMesa(int MESA, int ID_COMANDA, string NRO_MESA, int NRO_COMANDA)
        {
            Cursor = Cursors.WaitCursor;
            int GRUPO = 4;
            string ESTADO_MESA_SEL = dgMesas[1, dgMesas.CurrentCell.RowIndex].Value.ToString();
            DateTime DESDE = DateTime.Now;

            if (ID_COMANDA == 0)
            {
                int NRO_SOC = int.Parse(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());
                int NRO_DEP = int.Parse(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString());
                string SOCIO = dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString() + ", " + dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                int BARRA = int.Parse(dataGridView1[9, dataGridView1.CurrentCell.RowIndex].Value.ToString());
                int SECUENCIA = int.Parse(dataGridView1[8, dataGridView1.CurrentCell.RowIndex].Value.ToString());
                string MOROSO = dataGridView1[21, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                dlog.abrirMesa(MESA, "ABIERTA", DESDE, SOCIO, NRO_SOC, NRO_DEP, BARRA, SECUENCIA, 1, 1);
                llenarGrillaMesas();
                comanda com = new comanda(NRO_SOC.ToString(), NRO_DEP.ToString(), BARRA.ToString(), SOCIO, SECUENCIA, GRUPO, MESA, ID_COMANDA, 1, 1, MOROSO, NRO_MESA, 0);
                com.ShowDialog();
            }
            else
            {
                int NRO_SOC_M = int.Parse(dgMesas[5, dgMesas.CurrentCell.RowIndex].Value.ToString());
                int NRO_DEP_M = int.Parse(dgMesas[6, dgMesas.CurrentCell.RowIndex].Value.ToString());
                string SOCIO_M = dgMesas[3, dgMesas.CurrentCell.RowIndex].Value.ToString();
                int BARRA_M = int.Parse(dgMesas[7, dgMesas.CurrentCell.RowIndex].Value.ToString());
                int SECUENCIA_M = int.Parse(dgMesas[8, dgMesas.CurrentCell.RowIndex].Value.ToString());
                int PERSONAS = int.Parse(dgMesas[9, dgMesas.CurrentCell.RowIndex].Value.ToString());
                int PAGO = int.Parse(dgMesas[10, dgMesas.CurrentCell.RowIndex].Value.ToString());
                string MOROSO = dataGridView1[21, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                comanda com = new comanda(NRO_SOC_M.ToString(), NRO_DEP_M.ToString(), BARRA_M.ToString(), SOCIO_M, SECUENCIA_M, GRUPO, MESA, ID_COMANDA, PERSONAS, PAGO, MOROSO, NRO_MESA, NRO_COMANDA);
                com.ShowDialog();
            }

            Cursor = Cursors.Default;   
        }

        private void btnABM_Click(object sender, EventArgs e)
        {
            SOCIOS.buscar bu = new buscar();
            bu.ShowDialog();
            buscarIngresos("XXX", "NO");
            llenarGrillaIngresos(INGRESOS, dataGridView1);
            llenarGrillaMesas();
            pintarMorosos();
        }

        private void dgMesas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                string ESTADO_MESA = dgMesas[1, dgMesas.CurrentCell.RowIndex].Value.ToString();

                if (ESTADO_MESA == "ABIERTA")
                {
                    abrirMesaToolStripMenuItem.Enabled = false;
                    modificarMesaToolStripMenuItem.Enabled = true;
                    cambiarDeMesaToolStripMenuItem.Enabled = true;
                }
                else
                {
                    abrirMesaToolStripMenuItem.Enabled = true;
                    modificarMesaToolStripMenuItem.Enabled = false;
                    cambiarDeMesaToolStripMenuItem.Enabled = false;
                }

                cmMesas.Show(Cursor.Position);
            }
        }

        private void abrirMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int MESA = int.Parse(dgMesas[11, dgMesas.CurrentCell.RowIndex].Value.ToString());
            string NRO_MESA = dgMesas[0, dgMesas.CurrentCell.RowIndex].Value.ToString();
            abrirMesa(MESA, 0, NRO_MESA, 0);
            buscarIngresos(dpFiltroIngresos.Text, "NO");
            llenarGrillaIngresos(INGRESOS, dataGridView1);
            llenarGrillaMesas();
            pintarMorosos();
            Cursor = Cursors.Default;
        }

        private void modificarMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgMesas[4, dgMesas.CurrentCell.RowIndex].Value.ToString() == "" || dgMesas[12, dgMesas.CurrentCell.RowIndex].Value.ToString() == "")
            {
                MessageBox.Show("NO SE ENCONTRO EL NUMERO DE COMANDA", "ERROR");
            }
            else
            {
                int MESA = int.Parse(dgMesas[11, dgMesas.CurrentCell.RowIndex].Value.ToString());
                int ID_COMANDA = int.Parse(dgMesas[12, dgMesas.CurrentCell.RowIndex].Value.ToString());
                int NRO_COMANDA = int.Parse(dgMesas[4, dgMesas.CurrentCell.RowIndex].Value.ToString());
                string NRO_MESA = dgMesas[0, dgMesas.CurrentCell.RowIndex].Value.ToString();
                abrirMesa(MESA, ID_COMANDA, NRO_MESA, NRO_COMANDA);
                buscarIngresos("XXX", "NO");
                llenarGrillaIngresos(INGRESOS, dataGridView1);
                llenarGrillaMesas();
                Cursor = Cursors.Default;
            }
        }

        private void cerrarMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("CERRAR LA MESA SELECCIONADA", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string ESTADO_ACTUAL = dgMesas[1, dgMesas.CurrentCell.RowIndex].Value.ToString();

                if (ESTADO_ACTUAL == "CERRADA")
                {
                    MessageBox.Show("LA MESA SELECCIONADA YA SE ENCUENTRA CERRADA", "ERROR");
                }
                else
                {
                    try
                    {
                        int MESA = int.Parse(dgMesas[0, dgMesas.CurrentCell.RowIndex].Value.ToString());
                        string ESTADO = "CERRADA";
                        dlog.cerrarMesa(MESA, ESTADO);
                        llenarGrillaMesas();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO CERRAR LA MESA\n"+error, "ERROR");
                    }
                }
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

        #region LISTADO PDF
        public void listadoPDF(DataSet EFECTIVO, DataSet TARJETA, DataSet DESCUENTO, string RUTA, DataSet ESPECIALES, string CONTROL, string COMPLETO, DataSet COMANDAS = null)
        {
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _standardFontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _standardFontWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            iTextSharp.text.Font _standardFontBoldWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            iTextSharp.text.Font _mediumFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _mediumFontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _mediumFontWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            iTextSharp.text.Font _mediumFontBoldWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            
            BaseColor negro = new BaseColor(0, 0, 0);
            BaseColor gris = new BaseColor(230, 230, 230);
            BaseColor topo = new BaseColor(100, 100, 100);
            BaseColor blanco = new BaseColor(255, 255, 255);
            BaseColor blancoFondo = new BaseColor(255, 255, 255);

            Document doc = new Document(PageSize.A4);
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(RUTA, FileMode.Create));
            doc.AddTitle("LISTADO COMANDAS COMEDOR CSPFA");
            
            doc.AddCreator("CSPFA");
            doc.Open();

            Paragraph header = new Paragraph("LISTADO COMANDAS " + VGlobales.vp_role, _standardFontBold);
            header.Alignment = Element.ALIGN_CENTER;
            header.SpacingAfter = 5;
            doc.Add(header);

            PdfPTable TABLA_EFECTIVO = new PdfPTable(9);
            PdfPTable TABLA_TARJETAS = new PdfPTable(9);
            PdfPTable TABLA_DESCUENTO = new PdfPTable(10);
            PdfPTable TABLA_ESPECIALES = new PdfPTable(9);
            PdfPTable TABLA_FILTRADAS = new PdfPTable(9);
            PdfPTable TABLA_ESTADISTICAS = new PdfPTable(4);
            DataSet ESTADISTICAS = new DataSet();

            if (COMANDAS != null && COMPLETO == "SI")
            {
                ESTADISTICAS = utils.getItemsSuma(COMANDAS);
            }

            #region TABLA EFECTIVO

            if (EFECTIVO.Tables.Count > 0)
            {
                Paragraph sub = new Paragraph("EFECTIVO", _standardFontBold);
                sub.Alignment = Element.ALIGN_CENTER;
                sub.SpacingAfter = 5;
                doc.Add(sub);

                TABLA_EFECTIVO.WidthPercentage = 100;
                TABLA_EFECTIVO.SpacingAfter = 5;
                TABLA_EFECTIVO.SpacingBefore = 5;
                TABLA_EFECTIVO.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 3f, 1f, 1f });

                PdfPCell CELDA_NRO_COMANDA = new PdfPCell(new Phrase("COMANDA", _mediumFontBoldWhite));
                CELDA_NRO_COMANDA.BackgroundColor = topo;
                CELDA_NRO_COMANDA.BorderColor = blanco;
                CELDA_NRO_COMANDA.HorizontalAlignment = 1;
                CELDA_NRO_COMANDA.FixedHeight = 16f;
                TABLA_EFECTIVO.AddCell(CELDA_NRO_COMANDA);

                PdfPCell CELDA_NRO_BORRADOR = new PdfPCell(new Phrase("BORRADOR", _mediumFontBoldWhite));
                CELDA_NRO_BORRADOR.BackgroundColor = topo;
                CELDA_NRO_BORRADOR.BorderColor = blanco;
                CELDA_NRO_BORRADOR.HorizontalAlignment = 1;
                CELDA_NRO_BORRADOR.FixedHeight = 16f;
                TABLA_EFECTIVO.AddCell(CELDA_NRO_BORRADOR);

                PdfPCell CELDA_FECHA_COMANDA = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
                CELDA_FECHA_COMANDA.BackgroundColor = topo;
                CELDA_FECHA_COMANDA.BorderColor = blanco;
                CELDA_FECHA_COMANDA.HorizontalAlignment = 1;
                CELDA_FECHA_COMANDA.FixedHeight = 16f;
                TABLA_EFECTIVO.AddCell(CELDA_FECHA_COMANDA);

                PdfPCell CELDA_NRO_SOC_COMANDA = new PdfPCell(new Phrase("NRO SOC", _mediumFontBoldWhite));
                CELDA_NRO_SOC_COMANDA.BackgroundColor = topo;
                CELDA_NRO_SOC_COMANDA.BorderColor = blanco;
                CELDA_NRO_SOC_COMANDA.HorizontalAlignment = 1;
                CELDA_NRO_SOC_COMANDA.FixedHeight = 16f;
                TABLA_EFECTIVO.AddCell(CELDA_NRO_SOC_COMANDA);

                PdfPCell CELDA_AFILIADO_COMANDA = new PdfPCell(new Phrase("AFILIADO", _mediumFontBoldWhite));
                CELDA_AFILIADO_COMANDA.BackgroundColor = topo;
                CELDA_AFILIADO_COMANDA.BorderColor = blanco;
                CELDA_AFILIADO_COMANDA.HorizontalAlignment = 1;
                CELDA_AFILIADO_COMANDA.FixedHeight = 16f;
                TABLA_EFECTIVO.AddCell(CELDA_AFILIADO_COMANDA);

                PdfPCell CELDA_BENEFICIO_COMANDA = new PdfPCell(new Phrase("BENEFICIO", _mediumFontBoldWhite));
                CELDA_BENEFICIO_COMANDA.BackgroundColor = topo;
                CELDA_BENEFICIO_COMANDA.BorderColor = blanco;
                CELDA_BENEFICIO_COMANDA.HorizontalAlignment = 1;
                CELDA_BENEFICIO_COMANDA.FixedHeight = 16f;
                TABLA_EFECTIVO.AddCell(CELDA_BENEFICIO_COMANDA);

                PdfPCell CELDA_NOMAPE_COMANDA = new PdfPCell(new Phrase("NOMBRE Y APELLIDO", _mediumFontBoldWhite));
                CELDA_NOMAPE_COMANDA.BackgroundColor = topo;
                CELDA_NOMAPE_COMANDA.BorderColor = blanco;
                CELDA_NOMAPE_COMANDA.HorizontalAlignment = 1;
                CELDA_NOMAPE_COMANDA.FixedHeight = 16f;
                TABLA_EFECTIVO.AddCell(CELDA_NOMAPE_COMANDA);

                PdfPCell CELDA_IMPORTE_COMANDA = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                CELDA_IMPORTE_COMANDA.BackgroundColor = topo;
                CELDA_IMPORTE_COMANDA.BorderColor = blanco;
                CELDA_IMPORTE_COMANDA.HorizontalAlignment = 1;
                CELDA_IMPORTE_COMANDA.FixedHeight = 16f;
                TABLA_EFECTIVO.AddCell(CELDA_IMPORTE_COMANDA);

                PdfPCell CELDA_ANULADA_COMANDA = new PdfPCell(new Phrase("ANULADA", _mediumFontBoldWhite));
                CELDA_ANULADA_COMANDA.BackgroundColor = topo;
                CELDA_ANULADA_COMANDA.BorderColor = blanco;
                CELDA_ANULADA_COMANDA.HorizontalAlignment = 1;
                CELDA_ANULADA_COMANDA.FixedHeight = 16f;
                TABLA_EFECTIVO.AddCell(CELDA_ANULADA_COMANDA);
            }

            #endregion

            #region DATOS EFECTIVO

            decimal TOTAL_EFECTIVO = 0;

            if (EFECTIVO.Tables.Count > 0)
            {
                int X = 0;
                BaseColor colorFondo = new BaseColor(255, 255, 255);
                
                foreach (DataRow row in EFECTIVO.Tables[0].Rows)
                {
                    string NRO_COMANDA = row[0].ToString();
                    string FECHA = row[1].ToString();
                    decimal IMPORTE = Convert.ToDecimal(row[4].ToString());
                    string IMP_FINAL = string.Format("{0:n}", IMPORTE);
                    string NRO_SOC = row[5].ToString() + " " + row[6].ToString() + " " + row[7].ToString();
                    string NOM_APE = row[9].ToString();
                    string AFILIADO = row[10].ToString();
                    string BENEFICIO = row[11].ToString();
                    string ANULADA = row[14].ToString();
                    string COM_BORRADOR = row[15].ToString();
                    string ID_COMANDA = row[16].ToString();

                    if (ANULADA == "")
                        TOTAL_EFECTIVO = TOTAL_EFECTIVO + IMPORTE;
                    else
                        TOTAL_EFECTIVO = TOTAL_EFECTIVO + 0;

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

                    if (COMPLETO == "SI")
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                    }

                    PdfPCell CELL_NUMERO_COMANDA = new PdfPCell(new Phrase(NRO_COMANDA, _mediumFont));
                    CELL_NUMERO_COMANDA.HorizontalAlignment = 1;
                    CELL_NUMERO_COMANDA.BorderWidth = 0;
                    CELL_NUMERO_COMANDA.BackgroundColor = colorFondo;
                    CELL_NUMERO_COMANDA.FixedHeight = 14f;
                    TABLA_EFECTIVO.AddCell(CELL_NUMERO_COMANDA);

                    PdfPCell CELL_NUMERO_BORRADOR = new PdfPCell(new Phrase(COM_BORRADOR, _mediumFont));
                    CELL_NUMERO_BORRADOR.HorizontalAlignment = 1;
                    CELL_NUMERO_BORRADOR.BorderWidth = 0;
                    CELL_NUMERO_BORRADOR.BackgroundColor = colorFondo;
                    CELL_NUMERO_BORRADOR.FixedHeight = 14f;
                    TABLA_EFECTIVO.AddCell(CELL_NUMERO_BORRADOR);

                    PdfPCell CELL_FECHA_COMANDA = new PdfPCell(new Phrase(FECHA, _mediumFont));
                    CELL_FECHA_COMANDA.HorizontalAlignment = 1;
                    CELL_FECHA_COMANDA.BorderWidth = 0;
                    CELL_FECHA_COMANDA.BackgroundColor = colorFondo;
                    CELL_FECHA_COMANDA.FixedHeight = 14f;
                    TABLA_EFECTIVO.AddCell(CELL_FECHA_COMANDA);

                    PdfPCell CELL_NRO_SOC_COMANDA = new PdfPCell(new Phrase(NRO_SOC, _mediumFont));
                    CELL_NRO_SOC_COMANDA.HorizontalAlignment = 1;
                    CELL_NRO_SOC_COMANDA.BorderWidth = 0;
                    CELL_NRO_SOC_COMANDA.BackgroundColor = colorFondo;
                    CELL_NRO_SOC_COMANDA.FixedHeight = 14f;
                    TABLA_EFECTIVO.AddCell(CELL_NRO_SOC_COMANDA);

                    PdfPCell CELL_AFILIADO_COMANDA = new PdfPCell(new Phrase(AFILIADO, _mediumFont));
                    CELL_AFILIADO_COMANDA.HorizontalAlignment = 1;
                    CELL_AFILIADO_COMANDA.BorderWidth = 0;
                    CELL_AFILIADO_COMANDA.BackgroundColor = colorFondo;
                    CELL_AFILIADO_COMANDA.FixedHeight = 14f;
                    TABLA_EFECTIVO.AddCell(CELL_AFILIADO_COMANDA);

                    PdfPCell CELL_BENEFICIO_COMANDA = new PdfPCell(new Phrase(BENEFICIO, _mediumFont));
                    CELL_BENEFICIO_COMANDA.HorizontalAlignment = 1;
                    CELL_BENEFICIO_COMANDA.BorderWidth = 0;
                    CELL_BENEFICIO_COMANDA.BackgroundColor = colorFondo;
                    CELL_BENEFICIO_COMANDA.FixedHeight = 14f;
                    TABLA_EFECTIVO.AddCell(CELL_BENEFICIO_COMANDA);

                    PdfPCell CELL_NOMAPE_COMANDA = new PdfPCell(new Phrase(NOM_APE, _mediumFont));
                    CELL_NOMAPE_COMANDA.HorizontalAlignment = 1;
                    CELL_NOMAPE_COMANDA.BorderWidth = 0;
                    CELL_NOMAPE_COMANDA.BackgroundColor = colorFondo;
                    CELL_NOMAPE_COMANDA.FixedHeight = 14f;
                    TABLA_EFECTIVO.AddCell(CELL_NOMAPE_COMANDA);

                    PdfPCell CELL_IMPORTE_COMANDA = new PdfPCell(new Phrase(IMP_FINAL, _mediumFont));
                    CELL_IMPORTE_COMANDA.HorizontalAlignment = 1;
                    CELL_IMPORTE_COMANDA.BorderWidth = 0;
                    CELL_IMPORTE_COMANDA.BackgroundColor = colorFondo;
                    CELL_IMPORTE_COMANDA.FixedHeight = 14f;
                    TABLA_EFECTIVO.AddCell(CELL_IMPORTE_COMANDA);

                    PdfPCell CELL_ANULADA_COMANDA = new PdfPCell(new Phrase(ANULADA, _mediumFont));
                    CELL_ANULADA_COMANDA.HorizontalAlignment = 1;
                    CELL_ANULADA_COMANDA.BorderWidth = 0;
                    CELL_ANULADA_COMANDA.BackgroundColor = colorFondo;
                    CELL_ANULADA_COMANDA.FixedHeight = 14f;
                    TABLA_EFECTIVO.AddCell(CELL_ANULADA_COMANDA);

                    if (COMPLETO == "SI")
                    {
                        DataSet ITEMS = utils.getItemsByComanda(Convert.ToInt32(ID_COMANDA));

                        foreach (DataRow ROW_ITEM in ITEMS.Tables[0].Rows)
                        {
                            string PHRASE = ROW_ITEM[0] + " - " + ROW_ITEM[1] + " - " + ROW_ITEM[2] + " - $ " + ROW_ITEM[3] + " - $ " + ROW_ITEM[4];
                            PdfPCell CELL_ITEMS = new PdfPCell(new Phrase(PHRASE, _mediumFont));
                            CELL_ITEMS.HorizontalAlignment = 0;
                            CELL_ITEMS.BorderWidth = 0;
                            CELL_ITEMS.BackgroundColor = blancoFondo;
                            CELL_ITEMS.FixedHeight = 14f;
                            CELL_ITEMS.Colspan = 9;
                            TABLA_EFECTIVO.AddCell(CELL_ITEMS);
                        }
                    }
                }

                doc.Add(TABLA_EFECTIVO);
            }

            #endregion

            #region TABLA TOTAL EFECTIVO

            if (EFECTIVO.Tables.Count > 0)
            {
                PdfPTable TABLA_EFECTIVO_TOTAL = new PdfPTable(1);
                TABLA_EFECTIVO_TOTAL.WidthPercentage = 100;
                TABLA_EFECTIVO_TOTAL.SpacingAfter = 5;
                TABLA_EFECTIVO_TOTAL.SpacingBefore = 5;
                TABLA_EFECTIVO_TOTAL.SetWidths(new float[] { 1f });

                PdfPCell CELDA_TOTAL_EFECTIVO = new PdfPCell(new Phrase("TOTAL EFECTIVO $ " + string.Format("{0:n}", TOTAL_EFECTIVO), _mediumFontBoldWhite));
                CELDA_TOTAL_EFECTIVO.BackgroundColor = topo;
                CELDA_TOTAL_EFECTIVO.BorderColor = blanco;
                CELDA_TOTAL_EFECTIVO.HorizontalAlignment = 2;
                CELDA_TOTAL_EFECTIVO.FixedHeight = 16f;
                TABLA_EFECTIVO_TOTAL.AddCell(CELDA_TOTAL_EFECTIVO);

                doc.Add(TABLA_EFECTIVO_TOTAL);
            }

            #endregion

            #region TABLA TARJETAS

            if (TARJETA.Tables.Count > 0)
            {
                Paragraph sub2 = new Paragraph("TARJETAS", _standardFontBold);
                sub2.Alignment = Element.ALIGN_CENTER;
                sub2.SpacingAfter = 5;
                doc.Add(sub2);
                
                TABLA_TARJETAS.WidthPercentage = 100;
                TABLA_TARJETAS.SpacingAfter = 5;
                TABLA_TARJETAS.SpacingBefore = 5;
                TABLA_TARJETAS.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 3f, 1f, 1f });

                PdfPCell CELDA_NRO_COMANDA_T = new PdfPCell(new Phrase("COMANDA", _mediumFontBoldWhite));
                CELDA_NRO_COMANDA_T.BackgroundColor = topo;
                CELDA_NRO_COMANDA_T.BorderColor = blanco;
                CELDA_NRO_COMANDA_T.HorizontalAlignment = 1;
                CELDA_NRO_COMANDA_T.FixedHeight = 16f;
                TABLA_TARJETAS.AddCell(CELDA_NRO_COMANDA_T);

                PdfPCell CELDA_NRO_BORRADOR_T = new PdfPCell(new Phrase("BORRADOR", _mediumFontBoldWhite));
                CELDA_NRO_BORRADOR_T.BackgroundColor = topo;
                CELDA_NRO_BORRADOR_T.BorderColor = blanco;
                CELDA_NRO_BORRADOR_T.HorizontalAlignment = 1;
                CELDA_NRO_BORRADOR_T.FixedHeight = 16f;
                TABLA_TARJETAS.AddCell(CELDA_NRO_BORRADOR_T);

                PdfPCell CELDA_FECHA_COMANDA_T = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
                CELDA_FECHA_COMANDA_T.BackgroundColor = topo;
                CELDA_FECHA_COMANDA_T.BorderColor = blanco;
                CELDA_FECHA_COMANDA_T.HorizontalAlignment = 1;
                CELDA_FECHA_COMANDA_T.FixedHeight = 16f;
                TABLA_TARJETAS.AddCell(CELDA_FECHA_COMANDA_T);

                PdfPCell CELDA_NRO_SOC_COMANDA_T = new PdfPCell(new Phrase("NRO SOC", _mediumFontBoldWhite));
                CELDA_NRO_SOC_COMANDA_T.BackgroundColor = topo;
                CELDA_NRO_SOC_COMANDA_T.BorderColor = blanco;
                CELDA_NRO_SOC_COMANDA_T.HorizontalAlignment = 1;
                CELDA_NRO_SOC_COMANDA_T.FixedHeight = 16f;
                TABLA_TARJETAS.AddCell(CELDA_NRO_SOC_COMANDA_T);

                PdfPCell CELDA_AFILIADO_COMANDA_T = new PdfPCell(new Phrase("AFILIADO", _mediumFontBoldWhite));
                CELDA_AFILIADO_COMANDA_T.BackgroundColor = topo;
                CELDA_AFILIADO_COMANDA_T.BorderColor = blanco;
                CELDA_AFILIADO_COMANDA_T.HorizontalAlignment = 1;
                CELDA_AFILIADO_COMANDA_T.FixedHeight = 16f;
                TABLA_TARJETAS.AddCell(CELDA_AFILIADO_COMANDA_T);

                PdfPCell CELDA_BENEFICIO_COMANDA_T = new PdfPCell(new Phrase("BENEFICIO", _mediumFontBoldWhite));
                CELDA_BENEFICIO_COMANDA_T.BackgroundColor = topo;
                CELDA_BENEFICIO_COMANDA_T.BorderColor = blanco;
                CELDA_BENEFICIO_COMANDA_T.HorizontalAlignment = 1;
                CELDA_BENEFICIO_COMANDA_T.FixedHeight = 16f;
                TABLA_TARJETAS.AddCell(CELDA_BENEFICIO_COMANDA_T);

                PdfPCell CELDA_NOMAPE_COMANDA_T = new PdfPCell(new Phrase("NOMBRE Y APELLIDO", _mediumFontBoldWhite));
                CELDA_NOMAPE_COMANDA_T.BackgroundColor = topo;
                CELDA_NOMAPE_COMANDA_T.BorderColor = blanco;
                CELDA_NOMAPE_COMANDA_T.HorizontalAlignment = 1;
                CELDA_NOMAPE_COMANDA_T.FixedHeight = 16f;
                TABLA_TARJETAS.AddCell(CELDA_NOMAPE_COMANDA_T);

                PdfPCell CELDA_IMPORTE_COMANDA_T = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                CELDA_IMPORTE_COMANDA_T.BackgroundColor = topo;
                CELDA_IMPORTE_COMANDA_T.BorderColor = blanco;
                CELDA_IMPORTE_COMANDA_T.HorizontalAlignment = 1;
                CELDA_IMPORTE_COMANDA_T.FixedHeight = 16f;
                TABLA_TARJETAS.AddCell(CELDA_IMPORTE_COMANDA_T);

                PdfPCell CELDA_ANULADA_COMANDA_T = new PdfPCell(new Phrase("ANULADA", _mediumFontBoldWhite));
                CELDA_ANULADA_COMANDA_T.BackgroundColor = topo;
                CELDA_ANULADA_COMANDA_T.BorderColor = blanco;
                CELDA_ANULADA_COMANDA_T.HorizontalAlignment = 1;
                CELDA_ANULADA_COMANDA_T.FixedHeight = 16f;
                TABLA_TARJETAS.AddCell(CELDA_ANULADA_COMANDA_T);
            }

            #endregion

            #region DATOS TARJETAS

            decimal TOTAL_TARJETAS = 0;

            if (TARJETA.Tables.Count > 0)
            {
                int X = 0;
                BaseColor colorFondo = new BaseColor(255, 255, 255);

                foreach (DataRow row in TARJETA.Tables[0].Rows)
                {
                    string NRO_COMANDA = row[0].ToString();
                    string FECHA = row[1].ToString();
                    decimal IMPORTE = Convert.ToDecimal(row[4].ToString());
                    string IMP_FINAL = string.Format("{0:n}", IMPORTE);
                    string NRO_SOC = row[5].ToString() + " " + row[6].ToString() + " " + row[7].ToString();
                    string NOM_APE = row[9].ToString();
                    string AFILIADO = row[10].ToString();
                    string BENEFICIO = row[11].ToString();
                    string ANULADA = row[14].ToString();
                    string COM_BORRADOR = row[15].ToString();
                    string ID_COMANDA = row[16].ToString();

                    if (ANULADA == "")
                        TOTAL_TARJETAS = TOTAL_TARJETAS + IMPORTE;
                    else
                        TOTAL_TARJETAS = TOTAL_TARJETAS + 0;

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

                    if (COMPLETO == "SI")
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                    }

                    PdfPCell CELL_NUMERO_COMANDA_T = new PdfPCell(new Phrase(NRO_COMANDA, _mediumFont));
                    CELL_NUMERO_COMANDA_T.HorizontalAlignment = 1;
                    CELL_NUMERO_COMANDA_T.BorderWidth = 0;
                    CELL_NUMERO_COMANDA_T.BackgroundColor = colorFondo;
                    CELL_NUMERO_COMANDA_T.FixedHeight = 14f;
                    TABLA_TARJETAS.AddCell(CELL_NUMERO_COMANDA_T);

                    PdfPCell CELL_NUMERO_BORRADOR_T = new PdfPCell(new Phrase(COM_BORRADOR, _mediumFont));
                    CELL_NUMERO_BORRADOR_T.HorizontalAlignment = 1;
                    CELL_NUMERO_BORRADOR_T.BorderWidth = 0;
                    CELL_NUMERO_BORRADOR_T.BackgroundColor = colorFondo;
                    CELL_NUMERO_BORRADOR_T.FixedHeight = 14f;
                    TABLA_TARJETAS.AddCell(CELL_NUMERO_BORRADOR_T);

                    PdfPCell CELL_FECHA_COMANDA_T = new PdfPCell(new Phrase(FECHA, _mediumFont));
                    CELL_FECHA_COMANDA_T.HorizontalAlignment = 1;
                    CELL_FECHA_COMANDA_T.BorderWidth = 0;
                    CELL_FECHA_COMANDA_T.BackgroundColor = colorFondo;
                    CELL_FECHA_COMANDA_T.FixedHeight = 14f;
                    TABLA_TARJETAS.AddCell(CELL_FECHA_COMANDA_T);

                    PdfPCell CELL_NRO_SOC_COMANDA_T = new PdfPCell(new Phrase(NRO_SOC, _mediumFont));
                    CELL_NRO_SOC_COMANDA_T.HorizontalAlignment = 1;
                    CELL_NRO_SOC_COMANDA_T.BorderWidth = 0;
                    CELL_NRO_SOC_COMANDA_T.BackgroundColor = colorFondo;
                    CELL_NRO_SOC_COMANDA_T.FixedHeight = 14f;
                    TABLA_TARJETAS.AddCell(CELL_NRO_SOC_COMANDA_T);

                    PdfPCell CELL_AFILIADO_COMANDA_T = new PdfPCell(new Phrase(AFILIADO, _mediumFont));
                    CELL_AFILIADO_COMANDA_T.HorizontalAlignment = 1;
                    CELL_AFILIADO_COMANDA_T.BorderWidth = 0;
                    CELL_AFILIADO_COMANDA_T.BackgroundColor = colorFondo;
                    CELL_AFILIADO_COMANDA_T.FixedHeight = 14f;
                    TABLA_TARJETAS.AddCell(CELL_AFILIADO_COMANDA_T);

                    PdfPCell CELL_BENEFICIO_COMANDA_T = new PdfPCell(new Phrase(BENEFICIO, _mediumFont));
                    CELL_BENEFICIO_COMANDA_T.HorizontalAlignment = 1;
                    CELL_BENEFICIO_COMANDA_T.BorderWidth = 0;
                    CELL_BENEFICIO_COMANDA_T.BackgroundColor = colorFondo;
                    CELL_BENEFICIO_COMANDA_T.FixedHeight = 14f;
                    TABLA_TARJETAS.AddCell(CELL_BENEFICIO_COMANDA_T);

                    PdfPCell CELL_NOMAPE_COMANDA_T = new PdfPCell(new Phrase(NOM_APE, _mediumFont));
                    CELL_NOMAPE_COMANDA_T.HorizontalAlignment = 1;
                    CELL_NOMAPE_COMANDA_T.BorderWidth = 0;
                    CELL_NOMAPE_COMANDA_T.BackgroundColor = colorFondo;
                    CELL_NOMAPE_COMANDA_T.FixedHeight = 14f;
                    TABLA_TARJETAS.AddCell(CELL_NOMAPE_COMANDA_T);

                    PdfPCell CELL_IMPORTE_COMANDA_T = new PdfPCell(new Phrase(IMP_FINAL, _mediumFont));
                    CELL_IMPORTE_COMANDA_T.HorizontalAlignment = 1;
                    CELL_IMPORTE_COMANDA_T.BorderWidth = 0;
                    CELL_IMPORTE_COMANDA_T.BackgroundColor = colorFondo;
                    CELL_IMPORTE_COMANDA_T.FixedHeight = 14f;
                    TABLA_TARJETAS.AddCell(CELL_IMPORTE_COMANDA_T);

                    PdfPCell CELL_ANULADA_COMANDA_T = new PdfPCell(new Phrase(ANULADA, _mediumFont));
                    CELL_ANULADA_COMANDA_T.HorizontalAlignment = 1;
                    CELL_ANULADA_COMANDA_T.BorderWidth = 0;
                    CELL_ANULADA_COMANDA_T.BackgroundColor = colorFondo;
                    CELL_ANULADA_COMANDA_T.FixedHeight = 14f;
                    TABLA_TARJETAS.AddCell(CELL_ANULADA_COMANDA_T);

                    if (COMPLETO == "SI")
                    {
                        DataSet ITEMS = utils.getItemsByComanda(Convert.ToInt32(ID_COMANDA));

                        foreach (DataRow ROW_ITEM in ITEMS.Tables[0].Rows)
                        {
                            string PHRASE = ROW_ITEM[0] + " - " + ROW_ITEM[1] + " - " + ROW_ITEM[2] + " - $ " + ROW_ITEM[3] + " - $ " + ROW_ITEM[4];
                            PdfPCell CELL_ITEMS = new PdfPCell(new Phrase(PHRASE, _mediumFont));
                            CELL_ITEMS.HorizontalAlignment = 0;
                            CELL_ITEMS.BorderWidth = 0;
                            CELL_ITEMS.BackgroundColor = blancoFondo;
                            CELL_ITEMS.FixedHeight = 14f;
                            CELL_ITEMS.Colspan = 9;
                            TABLA_TARJETAS.AddCell(CELL_ITEMS);
                        }
                    }
                }
            }

            doc.Add(TABLA_TARJETAS);

            #endregion

            #region TABLA TOTAL TARJETAS

            if (TARJETA.Tables.Count > 0)
            {
                PdfPTable TABLA_TARJETAS_TOTAL = new PdfPTable(1);
                TABLA_TARJETAS_TOTAL.WidthPercentage = 100;
                TABLA_TARJETAS_TOTAL.SpacingAfter = 5;
                TABLA_TARJETAS_TOTAL.SpacingBefore = 5;
                TABLA_TARJETAS_TOTAL.SetWidths(new float[] { 1f });

                PdfPCell CELDA_TOTAL_TARJETAS = new PdfPCell(new Phrase("TOTAL TARJETAS $ " + string.Format("{0:n}", TOTAL_TARJETAS), _mediumFontBoldWhite));
                CELDA_TOTAL_TARJETAS.BackgroundColor = topo;
                CELDA_TOTAL_TARJETAS.BorderColor = blanco;
                CELDA_TOTAL_TARJETAS.HorizontalAlignment = 2;
                CELDA_TOTAL_TARJETAS.FixedHeight = 16f;
                TABLA_TARJETAS_TOTAL.AddCell(CELDA_TOTAL_TARJETAS);

                doc.Add(TABLA_TARJETAS_TOTAL);
            }

            #endregion

            #region TABLA DESCUENTO

            if (DESCUENTO.Tables.Count > 0)
            {
                Paragraph sub3 = new Paragraph("DESCUENTO", _standardFontBold);
                sub3.Alignment = Element.ALIGN_CENTER;
                sub3.SpacingAfter = 5;
                doc.Add(sub3);

                TABLA_DESCUENTO.WidthPercentage = 100;
                TABLA_DESCUENTO.SpacingAfter = 5;
                TABLA_DESCUENTO.SpacingBefore = 5;
                TABLA_DESCUENTO.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 3f, 1f, 1f, 1f });

                PdfPCell CELDA_NRO_COMANDA_D = new PdfPCell(new Phrase("COMANDA", _mediumFontBoldWhite));
                CELDA_NRO_COMANDA_D.BackgroundColor = topo;
                CELDA_NRO_COMANDA_D.BorderColor = blanco;
                CELDA_NRO_COMANDA_D.HorizontalAlignment = 1;
                CELDA_NRO_COMANDA_D.FixedHeight = 16f;
                TABLA_DESCUENTO.AddCell(CELDA_NRO_COMANDA_D);

                PdfPCell CELDA_NRO_BORRADOR_D = new PdfPCell(new Phrase("BORRADOR", _mediumFontBoldWhite));
                CELDA_NRO_BORRADOR_D.BackgroundColor = topo;
                CELDA_NRO_BORRADOR_D.BorderColor = blanco;
                CELDA_NRO_BORRADOR_D.HorizontalAlignment = 1;
                CELDA_NRO_BORRADOR_D.FixedHeight = 16f;
                TABLA_DESCUENTO.AddCell(CELDA_NRO_BORRADOR_D);

                PdfPCell CELDA_FECHA_COMANDA_D = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
                CELDA_FECHA_COMANDA_D.BackgroundColor = topo;
                CELDA_FECHA_COMANDA_D.BorderColor = blanco;
                CELDA_FECHA_COMANDA_D.HorizontalAlignment = 1;
                CELDA_FECHA_COMANDA_D.FixedHeight = 16f;
                TABLA_DESCUENTO.AddCell(CELDA_FECHA_COMANDA_D);

                PdfPCell CELDA_NRO_SOC_COMANDA_D = new PdfPCell(new Phrase("NRO SOC", _mediumFontBoldWhite));
                CELDA_NRO_SOC_COMANDA_D.BackgroundColor = topo;
                CELDA_NRO_SOC_COMANDA_D.BorderColor = blanco;
                CELDA_NRO_SOC_COMANDA_D.HorizontalAlignment = 1;
                CELDA_NRO_SOC_COMANDA_D.FixedHeight = 16f;
                TABLA_DESCUENTO.AddCell(CELDA_NRO_SOC_COMANDA_D);

                PdfPCell CELDA_AFILIADO_COMANDA_D = new PdfPCell(new Phrase("AFILIADO", _mediumFontBoldWhite));
                CELDA_AFILIADO_COMANDA_D.BackgroundColor = topo;
                CELDA_AFILIADO_COMANDA_D.BorderColor = blanco;
                CELDA_AFILIADO_COMANDA_D.HorizontalAlignment = 1;
                CELDA_AFILIADO_COMANDA_D.FixedHeight = 16f;
                TABLA_DESCUENTO.AddCell(CELDA_AFILIADO_COMANDA_D);

                PdfPCell CELDA_BENEFICIO_COMANDA_D = new PdfPCell(new Phrase("BENEFICIO", _mediumFontBoldWhite));
                CELDA_BENEFICIO_COMANDA_D.BackgroundColor = topo;
                CELDA_BENEFICIO_COMANDA_D.BorderColor = blanco;
                CELDA_BENEFICIO_COMANDA_D.HorizontalAlignment = 1;
                CELDA_BENEFICIO_COMANDA_D.FixedHeight = 16f;
                TABLA_DESCUENTO.AddCell(CELDA_BENEFICIO_COMANDA_D);

                PdfPCell CELDA_NOMAPE_COMANDA_D = new PdfPCell(new Phrase("NOMBRE Y APELLIDO", _mediumFontBoldWhite));
                CELDA_NOMAPE_COMANDA_D.BackgroundColor = topo;
                CELDA_NOMAPE_COMANDA_D.BorderColor = blanco;
                CELDA_NOMAPE_COMANDA_D.HorizontalAlignment = 1;
                CELDA_NOMAPE_COMANDA_D.FixedHeight = 16f;
                TABLA_DESCUENTO.AddCell(CELDA_NOMAPE_COMANDA_D);

                PdfPCell CELDA_IMPORTE_COMANDA_D = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                CELDA_IMPORTE_COMANDA_D.BackgroundColor = topo;
                CELDA_IMPORTE_COMANDA_D.BorderColor = blanco;
                CELDA_IMPORTE_COMANDA_D.HorizontalAlignment = 1;
                CELDA_IMPORTE_COMANDA_D.FixedHeight = 16f;
                TABLA_DESCUENTO.AddCell(CELDA_IMPORTE_COMANDA_D);

                PdfPCell CELDA_ANULADA_COMANDA_D = new PdfPCell(new Phrase("ANULADA", _mediumFontBoldWhite));
                CELDA_ANULADA_COMANDA_D.BackgroundColor = topo;
                CELDA_ANULADA_COMANDA_D.BorderColor = blanco;
                CELDA_ANULADA_COMANDA_D.HorizontalAlignment = 1;
                CELDA_ANULADA_COMANDA_D.FixedHeight = 16f;
                TABLA_DESCUENTO.AddCell(CELDA_ANULADA_COMANDA_D);

                PdfPCell CELDA_DESCUENTO_COMANDA_D = new PdfPCell(new Phrase("DESCUENTO", _mediumFontBoldWhite));
                CELDA_DESCUENTO_COMANDA_D.BackgroundColor = topo;
                CELDA_DESCUENTO_COMANDA_D.BorderColor = blanco;
                CELDA_DESCUENTO_COMANDA_D.HorizontalAlignment = 1;
                CELDA_DESCUENTO_COMANDA_D.FixedHeight = 16f;
                TABLA_DESCUENTO.AddCell(CELDA_DESCUENTO_COMANDA_D);
            }
            #endregion

            #region DATOS DESCUENTO

            decimal TOTAL_DESCUENTO = 0;

            if (DESCUENTO.Tables.Count > 0)
            {
                int X = 0;
                BaseColor colorFondo = new BaseColor(255, 255, 255);

                foreach (DataRow row in DESCUENTO.Tables[0].Rows)
                {
                    string NRO_COMANDA = row[0].ToString();
                    string FECHA = row[1].ToString();
                    decimal IMPORTE = Convert.ToDecimal(row[4].ToString());
                    string IMP_FINAL = string.Format("{0:n}", IMPORTE);
                    string NRO_SOC = row[5].ToString() + " " + row[6].ToString() + " " + row[7].ToString();
                    string NOM_APE = row[9].ToString();
                    string AFILIADO = row[10].ToString();
                    string BENEFICIO = row[11].ToString();
                    string SOL_DESC = row[12].ToString();
                    string ANULADA = row[14].ToString();
                    string COM_BORRADOR = row[15].ToString();
                    string ID_COMANDA = row[16].ToString();

                    if (ANULADA == "")
                        TOTAL_DESCUENTO = TOTAL_DESCUENTO + IMPORTE;
                    else
                        TOTAL_DESCUENTO = TOTAL_DESCUENTO + 0;

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

                    if (COMPLETO == "SI")
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                    }

                    PdfPCell CELL_NUMERO_COMANDA_D = new PdfPCell(new Phrase(NRO_COMANDA, _mediumFont));
                    CELL_NUMERO_COMANDA_D.HorizontalAlignment = 1;
                    CELL_NUMERO_COMANDA_D.BorderWidth = 0;
                    CELL_NUMERO_COMANDA_D.BackgroundColor = colorFondo;
                    CELL_NUMERO_COMANDA_D.FixedHeight = 14f;
                    TABLA_DESCUENTO.AddCell(CELL_NUMERO_COMANDA_D);

                    PdfPCell CELL_NUMERO_BORRADOR_D = new PdfPCell(new Phrase(COM_BORRADOR, _mediumFont));
                    CELL_NUMERO_BORRADOR_D.HorizontalAlignment = 1;
                    CELL_NUMERO_BORRADOR_D.BorderWidth = 0;
                    CELL_NUMERO_BORRADOR_D.BackgroundColor = colorFondo;
                    CELL_NUMERO_BORRADOR_D.FixedHeight = 14f;
                    TABLA_DESCUENTO.AddCell(CELL_NUMERO_BORRADOR_D);

                    PdfPCell CELL_FECHA_COMANDA_D = new PdfPCell(new Phrase(FECHA, _mediumFont));
                    CELL_FECHA_COMANDA_D.HorizontalAlignment = 1;
                    CELL_FECHA_COMANDA_D.BorderWidth = 0;
                    CELL_FECHA_COMANDA_D.BackgroundColor = colorFondo;
                    CELL_FECHA_COMANDA_D.FixedHeight = 14f;
                    TABLA_DESCUENTO.AddCell(CELL_FECHA_COMANDA_D);

                    PdfPCell CELL_NRO_SOC_COMANDA_D = new PdfPCell(new Phrase(NRO_SOC, _mediumFont));
                    CELL_NRO_SOC_COMANDA_D.HorizontalAlignment = 1;
                    CELL_NRO_SOC_COMANDA_D.BorderWidth = 0;
                    CELL_NRO_SOC_COMANDA_D.BackgroundColor = colorFondo;
                    CELL_NRO_SOC_COMANDA_D.FixedHeight = 14f;
                    TABLA_DESCUENTO.AddCell(CELL_NRO_SOC_COMANDA_D);

                    PdfPCell CELL_AFILIADO_COMANDA_D = new PdfPCell(new Phrase(AFILIADO, _mediumFont));
                    CELL_AFILIADO_COMANDA_D.HorizontalAlignment = 1;
                    CELL_AFILIADO_COMANDA_D.BorderWidth = 0;
                    CELL_AFILIADO_COMANDA_D.BackgroundColor = colorFondo;
                    CELL_AFILIADO_COMANDA_D.FixedHeight = 14f;
                    TABLA_DESCUENTO.AddCell(CELL_AFILIADO_COMANDA_D);

                    PdfPCell CELL_BENEFICIO_COMANDA_D = new PdfPCell(new Phrase(BENEFICIO, _mediumFont));
                    CELL_BENEFICIO_COMANDA_D.HorizontalAlignment = 1;
                    CELL_BENEFICIO_COMANDA_D.BorderWidth = 0;
                    CELL_BENEFICIO_COMANDA_D.BackgroundColor = colorFondo;
                    CELL_BENEFICIO_COMANDA_D.FixedHeight = 14f;
                    TABLA_DESCUENTO.AddCell(CELL_BENEFICIO_COMANDA_D);

                    PdfPCell CELL_NOMAPE_COMANDA_D = new PdfPCell(new Phrase(NOM_APE, _mediumFont));
                    CELL_NOMAPE_COMANDA_D.HorizontalAlignment = 1;
                    CELL_NOMAPE_COMANDA_D.BorderWidth = 0;
                    CELL_NOMAPE_COMANDA_D.BackgroundColor = colorFondo;
                    CELL_NOMAPE_COMANDA_D.FixedHeight = 14f;
                    TABLA_DESCUENTO.AddCell(CELL_NOMAPE_COMANDA_D);

                    PdfPCell CELL_IMPORTE_COMANDA_D = new PdfPCell(new Phrase(IMP_FINAL, _mediumFont));
                    CELL_IMPORTE_COMANDA_D.HorizontalAlignment = 1;
                    CELL_IMPORTE_COMANDA_D.BorderWidth = 0;
                    CELL_IMPORTE_COMANDA_D.BackgroundColor = colorFondo;
                    CELL_IMPORTE_COMANDA_D.FixedHeight = 14f;
                    TABLA_DESCUENTO.AddCell(CELL_IMPORTE_COMANDA_D);

                    PdfPCell CELL_ANULADA_COMANDA_D = new PdfPCell(new Phrase(ANULADA, _mediumFont));
                    CELL_ANULADA_COMANDA_D.HorizontalAlignment = 1;
                    CELL_ANULADA_COMANDA_D.BorderWidth = 0;
                    CELL_ANULADA_COMANDA_D.BackgroundColor = colorFondo;
                    CELL_ANULADA_COMANDA_D.FixedHeight = 14f;
                    TABLA_DESCUENTO.AddCell(CELL_ANULADA_COMANDA_D);

                    PdfPCell CELL_DESCUENTO_COMANDA_D = new PdfPCell(new Phrase(SOL_DESC, _mediumFont));
                    CELL_DESCUENTO_COMANDA_D.HorizontalAlignment = 1;
                    CELL_DESCUENTO_COMANDA_D.BorderWidth = 0;
                    CELL_DESCUENTO_COMANDA_D.BackgroundColor = colorFondo;
                    CELL_DESCUENTO_COMANDA_D.FixedHeight = 14f;
                    TABLA_DESCUENTO.AddCell(CELL_DESCUENTO_COMANDA_D);

                    if (COMPLETO == "SI")
                    {
                        DataSet ITEMS = utils.getItemsByComanda(Convert.ToInt32(ID_COMANDA));

                        foreach (DataRow ROW_ITEM in ITEMS.Tables[0].Rows)
                        {
                            string PHRASE = ROW_ITEM[0] + " - " + ROW_ITEM[1] + " - " + ROW_ITEM[2] + " - $ " + ROW_ITEM[3] + " - $ " + ROW_ITEM[4];
                            PdfPCell CELL_ITEMS = new PdfPCell(new Phrase(PHRASE, _mediumFont));
                            CELL_ITEMS.HorizontalAlignment = 0;
                            CELL_ITEMS.BorderWidth = 0;
                            CELL_ITEMS.BackgroundColor = blancoFondo;
                            CELL_ITEMS.FixedHeight = 14f;
                            CELL_ITEMS.Colspan = 9;
                            TABLA_DESCUENTO.AddCell(CELL_ITEMS);
                        }
                    }
                }
            }

            doc.Add(TABLA_DESCUENTO);

            #endregion

            #region TABLA TOTAL DESCUENTO

            if (DESCUENTO.Tables.Count > 0)
            {
                PdfPTable TABLA_DESCUENTO_TOTAL = new PdfPTable(1);
                TABLA_DESCUENTO_TOTAL.WidthPercentage = 100;
                TABLA_DESCUENTO_TOTAL.SpacingAfter = 5;
                TABLA_DESCUENTO_TOTAL.SpacingBefore = 5;
                TABLA_DESCUENTO_TOTAL.SetWidths(new float[] { 1f });

                PdfPCell CELDA_TOTAL_DESCUENTO = new PdfPCell(new Phrase("TOTAL DESCUENTOS $ " + string.Format("{0:n}", TOTAL_DESCUENTO), _mediumFontBoldWhite));
                CELDA_TOTAL_DESCUENTO.BackgroundColor = topo;
                CELDA_TOTAL_DESCUENTO.BorderColor = blanco;
                CELDA_TOTAL_DESCUENTO.HorizontalAlignment = 2;
                CELDA_TOTAL_DESCUENTO.FixedHeight = 16f;
                TABLA_DESCUENTO_TOTAL.AddCell(CELDA_TOTAL_DESCUENTO);

                doc.Add(TABLA_DESCUENTO_TOTAL);
            }

            #endregion

            #region TABLA ESPECIALES

            if (ESPECIALES.Tables.Count > 0)
            {
                Paragraph sub4 = new Paragraph("ESPECIALES", _standardFontBold);
                sub4.Alignment = Element.ALIGN_CENTER;
                sub4.SpacingAfter = 5;
                doc.Add(sub4);

                                TABLA_ESPECIALES.WidthPercentage = 100;
                TABLA_ESPECIALES.SpacingAfter = 5;
                TABLA_ESPECIALES.SpacingBefore = 5;
                TABLA_ESPECIALES.SetWidths(new float[] { 1f, 1f, 1f, 1f, 3f, 1f, 1f, 1f, 1f });

                PdfPCell CELDA_NRO_COMANDA_E = new PdfPCell(new Phrase("COMANDA", _mediumFontBoldWhite));
                CELDA_NRO_COMANDA_E.BackgroundColor = topo;
                CELDA_NRO_COMANDA_E.BorderColor = blanco;
                CELDA_NRO_COMANDA_E.HorizontalAlignment = 1;
                CELDA_NRO_COMANDA_E.FixedHeight = 16f;
                TABLA_ESPECIALES.AddCell(CELDA_NRO_COMANDA_E);

                PdfPCell CELDA_NRO_BORRADOR_E = new PdfPCell(new Phrase("BORRADOR", _mediumFontBoldWhite));
                CELDA_NRO_BORRADOR_E.BackgroundColor = topo;
                CELDA_NRO_BORRADOR_E.BorderColor = blanco;
                CELDA_NRO_BORRADOR_E.HorizontalAlignment = 1;
                CELDA_NRO_BORRADOR_E.FixedHeight = 16f;
                TABLA_ESPECIALES.AddCell(CELDA_NRO_BORRADOR_E);

                PdfPCell CELDA_FECHA_COMANDA_E = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
                CELDA_FECHA_COMANDA_E.BackgroundColor = topo;
                CELDA_FECHA_COMANDA_E.BorderColor = blanco;
                CELDA_FECHA_COMANDA_E.HorizontalAlignment = 1;
                CELDA_FECHA_COMANDA_E.FixedHeight = 16f;
                TABLA_ESPECIALES.AddCell(CELDA_FECHA_COMANDA_E);

                PdfPCell CELDA_NRO_SOC_COMANDA_E = new PdfPCell(new Phrase("NRO SOC", _mediumFontBoldWhite));
                CELDA_NRO_SOC_COMANDA_E.BackgroundColor = topo;
                CELDA_NRO_SOC_COMANDA_E.BorderColor = blanco;
                CELDA_NRO_SOC_COMANDA_E.HorizontalAlignment = 1;
                CELDA_NRO_SOC_COMANDA_E.FixedHeight = 16f;
                TABLA_ESPECIALES.AddCell(CELDA_NRO_SOC_COMANDA_E);

                PdfPCell CELDA_NOMAPE_COMANDA_E = new PdfPCell(new Phrase("NOMBRE Y APELLIDO", _mediumFontBoldWhite));
                CELDA_NOMAPE_COMANDA_E.BackgroundColor = topo;
                CELDA_NOMAPE_COMANDA_E.BorderColor = blanco;
                CELDA_NOMAPE_COMANDA_E.HorizontalAlignment = 1;
                CELDA_NOMAPE_COMANDA_E.FixedHeight = 16f;
                TABLA_ESPECIALES.AddCell(CELDA_NOMAPE_COMANDA_E);

                PdfPCell CELDA_IMPORTE_COMANDA_E = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                CELDA_IMPORTE_COMANDA_E.BackgroundColor = topo;
                CELDA_IMPORTE_COMANDA_E.BorderColor = blanco;
                CELDA_IMPORTE_COMANDA_E.HorizontalAlignment = 1;
                CELDA_IMPORTE_COMANDA_E.FixedHeight = 16f;
                TABLA_ESPECIALES.AddCell(CELDA_IMPORTE_COMANDA_E);

                PdfPCell CELDA_ANULADA_COMANDA_E = new PdfPCell(new Phrase("ANULADA", _mediumFontBoldWhite));
                CELDA_ANULADA_COMANDA_E.BackgroundColor = topo;
                CELDA_ANULADA_COMANDA_E.BorderColor = blanco;
                CELDA_ANULADA_COMANDA_E.HorizontalAlignment = 1;
                CELDA_ANULADA_COMANDA_E.FixedHeight = 16f;
                TABLA_ESPECIALES.AddCell(CELDA_ANULADA_COMANDA_E);

                PdfPCell CELDA_DESC_AP_COMANDA_E = new PdfPCell(new Phrase("% DESC", _mediumFontBoldWhite));
                CELDA_DESC_AP_COMANDA_E.BackgroundColor = topo;
                CELDA_DESC_AP_COMANDA_E.BorderColor = blanco;
                CELDA_DESC_AP_COMANDA_E.HorizontalAlignment = 1;
                CELDA_DESC_AP_COMANDA_E.FixedHeight = 16f;
                TABLA_ESPECIALES.AddCell(CELDA_DESC_AP_COMANDA_E);

                PdfPCell CELDA_IMP_FINAL_COMANDA_E = new PdfPCell(new Phrase("A DESC", _mediumFontBoldWhite));
                CELDA_IMP_FINAL_COMANDA_E.BackgroundColor = topo;
                CELDA_IMP_FINAL_COMANDA_E.BorderColor = blanco;
                CELDA_IMP_FINAL_COMANDA_E.HorizontalAlignment = 1;
                CELDA_IMP_FINAL_COMANDA_E.FixedHeight = 16f;
                TABLA_ESPECIALES.AddCell(CELDA_IMP_FINAL_COMANDA_E);
            }

            #endregion

            #region DATOS ESPECIALES

            decimal TOTAL_ESPECIALES = 0;

            if (ESPECIALES.Tables.Count > 0)
            {
                int X = 0;
                BaseColor colorFondo = new BaseColor(255, 255, 255);

                foreach (DataRow row in ESPECIALES.Tables[0].Rows)
                {
                    string NRO_COMANDA = row[0].ToString();
                    string FECHA = row[1].ToString();
                    decimal IMPORTE = Convert.ToDecimal(row[4].ToString());
                    string IMP_FINAL = string.Format("{0:n}", IMPORTE);
                    string NRO_SOC = row[5].ToString() + " " + row[6].ToString() + " " + row[7].ToString();
                    string NOM_APE = row[9].ToString();
                    string ANULADA = row[14].ToString();
                    string COM_BORRADOR = row[15].ToString();
                    string DESCUENTO_APLICADO = "% " + row[16].ToString();
                    decimal IMPORTE_DESCONTADO = Convert.ToDecimal(row[17].ToString());
                    string IMP_DESC_FINAL = string.Format("{0:n}", IMPORTE_DESCONTADO);
                    string ID_COMANDA = row[18].ToString();

                    if (ANULADA == "")
                        TOTAL_ESPECIALES = TOTAL_ESPECIALES + IMPORTE_DESCONTADO;
                    else
                        TOTAL_ESPECIALES = TOTAL_ESPECIALES + 0;

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

                    if (COMPLETO == "SI")
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                    }

                    PdfPCell CELL_NUMERO_COMANDA_E = new PdfPCell(new Phrase(NRO_COMANDA, _mediumFont));
                    CELL_NUMERO_COMANDA_E.HorizontalAlignment = 1;
                    CELL_NUMERO_COMANDA_E.BorderWidth = 0;
                    CELL_NUMERO_COMANDA_E.BackgroundColor = colorFondo;
                    CELL_NUMERO_COMANDA_E.FixedHeight = 14f;
                    TABLA_ESPECIALES.AddCell(CELL_NUMERO_COMANDA_E);

                    PdfPCell CELL_NUMERO_BORRADOR_E = new PdfPCell(new Phrase(COM_BORRADOR, _mediumFont));
                    CELL_NUMERO_BORRADOR_E.HorizontalAlignment = 1;
                    CELL_NUMERO_BORRADOR_E.BorderWidth = 0;
                    CELL_NUMERO_BORRADOR_E.BackgroundColor = colorFondo;
                    CELL_NUMERO_BORRADOR_E.FixedHeight = 14f;
                    TABLA_ESPECIALES.AddCell(CELL_NUMERO_BORRADOR_E);

                    PdfPCell CELL_FECHA_COMANDA_E = new PdfPCell(new Phrase(FECHA, _mediumFont));
                    CELL_FECHA_COMANDA_E.HorizontalAlignment = 1;
                    CELL_FECHA_COMANDA_E.BorderWidth = 0;
                    CELL_FECHA_COMANDA_E.BackgroundColor = colorFondo;
                    CELL_FECHA_COMANDA_E.FixedHeight = 14f;
                    TABLA_ESPECIALES.AddCell(CELL_FECHA_COMANDA_E);

                    PdfPCell CELL_NRO_SOC_COMANDA_E = new PdfPCell(new Phrase(NRO_SOC, _mediumFont));
                    CELL_NRO_SOC_COMANDA_E.HorizontalAlignment = 1;
                    CELL_NRO_SOC_COMANDA_E.BorderWidth = 0;
                    CELL_NRO_SOC_COMANDA_E.BackgroundColor = colorFondo;
                    CELL_NRO_SOC_COMANDA_E.FixedHeight = 14f;
                    TABLA_ESPECIALES.AddCell(CELL_NRO_SOC_COMANDA_E);

                    PdfPCell CELL_NOMAPE_COMANDA_E = new PdfPCell(new Phrase(NOM_APE, _mediumFont));
                    CELL_NOMAPE_COMANDA_E.HorizontalAlignment = 1;
                    CELL_NOMAPE_COMANDA_E.BorderWidth = 0;
                    CELL_NOMAPE_COMANDA_E.BackgroundColor = colorFondo;
                    CELL_NOMAPE_COMANDA_E.FixedHeight = 14f;
                    TABLA_ESPECIALES.AddCell(CELL_NOMAPE_COMANDA_E);

                    PdfPCell CELL_IMPORTE_COMANDA_E = new PdfPCell(new Phrase(IMP_FINAL, _mediumFont));
                    CELL_IMPORTE_COMANDA_E.HorizontalAlignment = 1;
                    CELL_IMPORTE_COMANDA_E.BorderWidth = 0;
                    CELL_IMPORTE_COMANDA_E.BackgroundColor = colorFondo;
                    CELL_IMPORTE_COMANDA_E.FixedHeight = 14f;
                    TABLA_ESPECIALES.AddCell(CELL_IMPORTE_COMANDA_E);

                    PdfPCell CELL_ANULADA_COMANDA_E = new PdfPCell(new Phrase(ANULADA, _mediumFont));
                    CELL_ANULADA_COMANDA_E.HorizontalAlignment = 1;
                    CELL_ANULADA_COMANDA_E.BorderWidth = 0;
                    CELL_ANULADA_COMANDA_E.BackgroundColor = colorFondo;
                    CELL_ANULADA_COMANDA_E.FixedHeight = 14f;
                    TABLA_ESPECIALES.AddCell(CELL_ANULADA_COMANDA_E);

                    PdfPCell CELL_DESC_AP_E = new PdfPCell(new Phrase(DESCUENTO_APLICADO, _mediumFont));
                    CELL_DESC_AP_E.HorizontalAlignment = 1;
                    CELL_DESC_AP_E.BorderWidth = 0;
                    CELL_DESC_AP_E.BackgroundColor = colorFondo;
                    CELL_DESC_AP_E.FixedHeight = 14f;
                    TABLA_ESPECIALES.AddCell(CELL_DESC_AP_E);

                    PdfPCell CELL_IMP_DESC_E = new PdfPCell(new Phrase(IMP_DESC_FINAL, _mediumFont));
                    CELL_IMP_DESC_E.HorizontalAlignment = 1;
                    CELL_IMP_DESC_E.BorderWidth = 0;
                    CELL_IMP_DESC_E.BackgroundColor = colorFondo;
                    CELL_IMP_DESC_E.FixedHeight = 14f;
                    TABLA_ESPECIALES.AddCell(CELL_IMP_DESC_E);

                    if (COMPLETO == "SI")
                    {
                        DataSet ITEMS = utils.getItemsByComanda(Convert.ToInt32(ID_COMANDA));

                        foreach (DataRow ROW_ITEM in ITEMS.Tables[0].Rows)
                        {
                            string PHRASE = ROW_ITEM[0] + " - " + ROW_ITEM[1] + " - " + ROW_ITEM[2] + " - $ " + ROW_ITEM[3] + " - $ " + ROW_ITEM[4];
                            PdfPCell CELL_ITEMS = new PdfPCell(new Phrase(PHRASE, _mediumFont));
                            CELL_ITEMS.HorizontalAlignment = 0;
                            CELL_ITEMS.BorderWidth = 0;
                            CELL_ITEMS.BackgroundColor = blancoFondo;
                            CELL_ITEMS.FixedHeight = 14f;
                            CELL_ITEMS.Colspan = 9;
                            TABLA_ESPECIALES.AddCell(CELL_ITEMS);
                        }
                    }
                }
            }

            doc.Add(TABLA_ESPECIALES);

            #endregion

            #region TABLA TOTAL ESPECIALES

            if (ESPECIALES.Tables.Count > 0)
            {
                PdfPTable TABLA_ESPECIALES_TOTAL = new PdfPTable(1);
                TABLA_ESPECIALES_TOTAL.WidthPercentage = 100;
                TABLA_ESPECIALES_TOTAL.SpacingAfter = 5;
                TABLA_ESPECIALES_TOTAL.SpacingBefore = 5;
                TABLA_ESPECIALES_TOTAL.SetWidths(new float[] { 1f });

                PdfPCell CELDA_TOTAL_ESPECIALES = new PdfPCell(new Phrase("TOTAL A DESCONTAR $ " + string.Format("{0:n}", TOTAL_ESPECIALES), _mediumFontBoldWhite));
                CELDA_TOTAL_ESPECIALES.BackgroundColor = topo;
                CELDA_TOTAL_ESPECIALES.BorderColor = blanco;
                CELDA_TOTAL_ESPECIALES.HorizontalAlignment = 2;
                CELDA_TOTAL_ESPECIALES.FixedHeight = 16f;
                TABLA_ESPECIALES_TOTAL.AddCell(CELDA_TOTAL_ESPECIALES);

                doc.Add(TABLA_ESPECIALES_TOTAL);
            }

            #endregion

            #region TABLA EMPLEADOS

            /*Paragraph sub5 = new Paragraph("EMPLEADOS", _standardFontBold);
            sub5.Alignment = Element.ALIGN_CENTER;
            sub5.SpacingAfter = 5;
            doc.Add(sub5);

            PdfPTable TABLA_EMPLEADOS = new PdfPTable(8);
            TABLA_EMPLEADOS.WidthPercentage = 100;
            TABLA_EMPLEADOS.SpacingAfter = 5;
            TABLA_EMPLEADOS.SpacingBefore = 5;
            TABLA_EMPLEADOS.SetWidths(new float[] { 1f, 1f, 1f, 1f, 3f, 1f, 1f, 1f });

            PdfPCell CELDA_NRO_COMANDA_EMP = new PdfPCell(new Phrase("COMANDA", _mediumFontBoldWhite));
            CELDA_NRO_COMANDA_EMP.BackgroundColor = topo;
            CELDA_NRO_COMANDA_EMP.BorderColor = blanco;
            CELDA_NRO_COMANDA_EMP.HorizontalAlignment = 1;
            CELDA_NRO_COMANDA_EMP.FixedHeight = 16f;
            TABLA_EMPLEADOS.AddCell(CELDA_NRO_COMANDA_EMP);

            PdfPCell CELDA_NRO_BORRADOR_EMP = new PdfPCell(new Phrase("BORRADOR", _mediumFontBoldWhite));
            CELDA_NRO_BORRADOR_EMP.BackgroundColor = topo;
            CELDA_NRO_BORRADOR_EMP.BorderColor = blanco;
            CELDA_NRO_BORRADOR_EMP.HorizontalAlignment = 1;
            CELDA_NRO_BORRADOR_EMP.FixedHeight = 16f;
            TABLA_EMPLEADOS.AddCell(CELDA_NRO_BORRADOR_EMP);

            PdfPCell CELDA_FECHA_COMANDA_EMP = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
            CELDA_FECHA_COMANDA_EMP.BackgroundColor = topo;
            CELDA_FECHA_COMANDA_EMP.BorderColor = blanco;
            CELDA_FECHA_COMANDA_EMP.HorizontalAlignment = 1;
            CELDA_FECHA_COMANDA_EMP.FixedHeight = 16f;
            TABLA_EMPLEADOS.AddCell(CELDA_FECHA_COMANDA_EMP);

            PdfPCell CELDA_NRO_SOC_COMANDA_EMP = new PdfPCell(new Phrase("NRO SOC", _mediumFontBoldWhite));
            CELDA_NRO_SOC_COMANDA_EMP.BackgroundColor = topo;
            CELDA_NRO_SOC_COMANDA_EMP.BorderColor = blanco;
            CELDA_NRO_SOC_COMANDA_EMP.HorizontalAlignment = 1;
            CELDA_NRO_SOC_COMANDA_EMP.FixedHeight = 16f;
            TABLA_EMPLEADOS.AddCell(CELDA_NRO_SOC_COMANDA_EMP);

            PdfPCell CELDA_NOMAPE_COMANDA_EMP = new PdfPCell(new Phrase("NOMBRE Y APELLIDO", _mediumFontBoldWhite));
            CELDA_NOMAPE_COMANDA_EMP.BackgroundColor = topo;
            CELDA_NOMAPE_COMANDA_EMP.BorderColor = blanco;
            CELDA_NOMAPE_COMANDA_EMP.HorizontalAlignment = 1;
            CELDA_NOMAPE_COMANDA_EMP.FixedHeight = 16f;
            TABLA_EMPLEADOS.AddCell(CELDA_NOMAPE_COMANDA_EMP);

            PdfPCell CELDA_IMPORTE_COMANDA_EMP = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
            CELDA_IMPORTE_COMANDA_EMP.BackgroundColor = topo;
            CELDA_IMPORTE_COMANDA_EMP.BorderColor = blanco;
            CELDA_IMPORTE_COMANDA_EMP.HorizontalAlignment = 1;
            CELDA_IMPORTE_COMANDA_EMP.FixedHeight = 16f;
            TABLA_EMPLEADOS.AddCell(CELDA_IMPORTE_COMANDA_EMP);

            PdfPCell CELDA_ANULADA_COMANDA_EMP = new PdfPCell(new Phrase("ANULADA", _mediumFontBoldWhite));
            CELDA_ANULADA_COMANDA_EMP.BackgroundColor = topo;
            CELDA_ANULADA_COMANDA_EMP.BorderColor = blanco;
            CELDA_ANULADA_COMANDA_EMP.HorizontalAlignment = 1;
            CELDA_ANULADA_COMANDA_EMP.FixedHeight = 16f;
            TABLA_EMPLEADOS.AddCell(CELDA_ANULADA_COMANDA_EMP);

            PdfPCell CELDA_DESC_AP_COMANDA_EMP = new PdfPCell(new Phrase("% DESC", _mediumFontBoldWhite));
            CELDA_DESC_AP_COMANDA_EMP.BackgroundColor = topo;
            CELDA_DESC_AP_COMANDA_EMP.BorderColor = blanco;
            CELDA_DESC_AP_COMANDA_EMP.HorizontalAlignment = 1;
            CELDA_DESC_AP_COMANDA_EMP.FixedHeight = 16f;
            TABLA_EMPLEADOS.AddCell(CELDA_DESC_AP_COMANDA_EMP);

            #endregion

            #region DATOS EMPLEADOS
            decimal TOTAL_EMPLEADOS = 0;

            if (EMPLEADOS.Tables.Count > 0)
            {
                int X = 0;
                BaseColor colorFondo = new BaseColor(255, 255, 255);

                foreach (DataRow row in EMPLEADOS.Tables[0].Rows)
                {
                    string NRO_COMANDA = row[0].ToString();
                    string FECHA = row[1].ToString();
                    decimal IMPORTE = Convert.ToDecimal(row[4].ToString());
                    string IMP_FINAL = string.Format("{0:n}", IMPORTE);
                    string NRO_SOC = row[5].ToString() + " " + row[6].ToString() + " " + row[7].ToString();
                    string NOM_APE = row[9].ToString();
                    string ANULADA = row[14].ToString();
                    string COM_BORRADOR = row[15].ToString();
                    string DESCUENTO_APLICADO = "% " + row[16].ToString();
                    decimal IMPORTE_DESCONTADO = Convert.ToDecimal(row[17].ToString());
                    string IMP_DESC_FINAL = string.Format("{0:n}", IMPORTE_DESCONTADO);

                    if (ANULADA == "")
                        TOTAL_EMPLEADOS = TOTAL_EMPLEADOS + IMPORTE_DESCONTADO;
                    else
                        TOTAL_EMPLEADOS = TOTAL_EMPLEADOS + 0;

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

                    PdfPCell CELL_NUMERO_COMANDA_EMP = new PdfPCell(new Phrase(NRO_COMANDA, _mediumFont));
                    CELL_NUMERO_COMANDA_EMP.HorizontalAlignment = 1;
                    CELL_NUMERO_COMANDA_EMP.BorderWidth = 0;
                    CELL_NUMERO_COMANDA_EMP.BackgroundColor = colorFondo;
                    CELL_NUMERO_COMANDA_EMP.FixedHeight = 14f;
                    TABLA_EMPLEADOS.AddCell(CELL_NUMERO_COMANDA_EMP);

                    PdfPCell CELL_NUMERO_BORRADOR_EMP = new PdfPCell(new Phrase(COM_BORRADOR, _mediumFont));
                    CELL_NUMERO_BORRADOR_EMP.HorizontalAlignment = 1;
                    CELL_NUMERO_BORRADOR_EMP.BorderWidth = 0;
                    CELL_NUMERO_BORRADOR_EMP.BackgroundColor = colorFondo;
                    CELL_NUMERO_BORRADOR_EMP.FixedHeight = 14f;
                    TABLA_EMPLEADOS.AddCell(CELL_NUMERO_BORRADOR_EMP);

                    PdfPCell CELL_FECHA_COMANDA_EMP = new PdfPCell(new Phrase(FECHA, _mediumFont));
                    CELL_FECHA_COMANDA_EMP.HorizontalAlignment = 1;
                    CELL_FECHA_COMANDA_EMP.BorderWidth = 0;
                    CELL_FECHA_COMANDA_EMP.BackgroundColor = colorFondo;
                    CELL_FECHA_COMANDA_EMP.FixedHeight = 14f;
                    TABLA_EMPLEADOS.AddCell(CELL_FECHA_COMANDA_EMP);

                    PdfPCell CELL_NRO_SOC_COMANDA_EMP = new PdfPCell(new Phrase(NRO_SOC, _mediumFont));
                    CELL_NRO_SOC_COMANDA_EMP.HorizontalAlignment = 1;
                    CELL_NRO_SOC_COMANDA_EMP.BorderWidth = 0;
                    CELL_NRO_SOC_COMANDA_EMP.BackgroundColor = colorFondo;
                    CELL_NRO_SOC_COMANDA_EMP.FixedHeight = 14f;
                    TABLA_EMPLEADOS.AddCell(CELL_NRO_SOC_COMANDA_EMP);

                    PdfPCell CELL_NOMAPE_COMANDA_EMP = new PdfPCell(new Phrase(NOM_APE, _mediumFont));
                    CELL_NOMAPE_COMANDA_EMP.HorizontalAlignment = 1;
                    CELL_NOMAPE_COMANDA_EMP.BorderWidth = 0;
                    CELL_NOMAPE_COMANDA_EMP.BackgroundColor = colorFondo;
                    CELL_NOMAPE_COMANDA_EMP.FixedHeight = 14f;
                    TABLA_EMPLEADOS.AddCell(CELL_NOMAPE_COMANDA_EMP);

                    PdfPCell CELL_IMPORTE_COMANDA_EMP = new PdfPCell(new Phrase(IMP_FINAL, _mediumFont));
                    CELL_IMPORTE_COMANDA_EMP.HorizontalAlignment = 1;
                    CELL_IMPORTE_COMANDA_EMP.BorderWidth = 0;
                    CELL_IMPORTE_COMANDA_EMP.BackgroundColor = colorFondo;
                    CELL_IMPORTE_COMANDA_EMP.FixedHeight = 14f;
                    TABLA_EMPLEADOS.AddCell(CELL_IMPORTE_COMANDA_EMP);

                    PdfPCell CELL_ANULADA_COMANDA_EMP = new PdfPCell(new Phrase(ANULADA, _mediumFont));
                    CELL_ANULADA_COMANDA_EMP.HorizontalAlignment = 1;
                    CELL_ANULADA_COMANDA_EMP.BorderWidth = 0;
                    CELL_ANULADA_COMANDA_EMP.BackgroundColor = colorFondo;
                    CELL_ANULADA_COMANDA_EMP.FixedHeight = 14f;
                    TABLA_EMPLEADOS.AddCell(CELL_ANULADA_COMANDA_EMP);

                    PdfPCell CELL_DESC_AP_EMP = new PdfPCell(new Phrase(DESCUENTO_APLICADO, _mediumFont));
                    CELL_DESC_AP_EMP.HorizontalAlignment = 1;
                    CELL_DESC_AP_EMP.BorderWidth = 0;
                    CELL_DESC_AP_EMP.BackgroundColor = colorFondo;
                    CELL_DESC_AP_EMP.FixedHeight = 14f;
                    TABLA_EMPLEADOS.AddCell(CELL_DESC_AP_EMP);
                }
            }

            doc.Add(TABLA_EMPLEADOS);

            #endregion

            #region TABLA TOTAL EMPLEADOS

            PdfPTable TABLA_EMPLEADOS_TOTAL = new PdfPTable(1);
            TABLA_EMPLEADOS_TOTAL.WidthPercentage = 100;
            TABLA_EMPLEADOS_TOTAL.SpacingAfter = 5;
            TABLA_EMPLEADOS_TOTAL.SpacingBefore = 5;
            TABLA_EMPLEADOS_TOTAL.SetWidths(new float[] { 1f });

            PdfPCell CELDA_TOTAL_EMPLEADOS = new PdfPCell(new Phrase("TOTAL EMPLEADOS $ " + string.Format("{0:n}", TOTAL_EMPLEADOS), _mediumFontBoldWhite));
            CELDA_TOTAL_EMPLEADOS.BackgroundColor = topo;
            CELDA_TOTAL_EMPLEADOS.BorderColor = blanco;
            CELDA_TOTAL_EMPLEADOS.HorizontalAlignment = 2;
            CELDA_TOTAL_EMPLEADOS.FixedHeight = 16f;
            TABLA_EMPLEADOS_TOTAL.AddCell(CELDA_TOTAL_EMPLEADOS);

            doc.Add(TABLA_EMPLEADOS_TOTAL);*/

            #endregion

            #region TABLA COMANDAS FILTRADAS

            if (COMANDAS != null && COMANDAS.Tables.Count > 0)
            {
                Paragraph sub4 = new Paragraph("COMANDAS FILTRADAS", _standardFontBold);
                sub4.Alignment = Element.ALIGN_CENTER;
                sub4.SpacingAfter = 5;
                doc.Add(sub4);

                TABLA_FILTRADAS.WidthPercentage = 100;
                TABLA_FILTRADAS.SpacingAfter = 5;
                TABLA_FILTRADAS.SpacingBefore = 5;
                TABLA_FILTRADAS.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 3f, 1f, 1f });

                PdfPCell CELDA_NRO_COMANDA = new PdfPCell(new Phrase("COMANDA", _mediumFontBoldWhite));
                CELDA_NRO_COMANDA.BackgroundColor = topo;
                CELDA_NRO_COMANDA.BorderColor = blanco;
                CELDA_NRO_COMANDA.HorizontalAlignment = 1;
                CELDA_NRO_COMANDA.FixedHeight = 16f;
                TABLA_FILTRADAS.AddCell(CELDA_NRO_COMANDA);

                PdfPCell CELDA_NRO_BORRADOR = new PdfPCell(new Phrase("BORRADOR", _mediumFontBoldWhite));
                CELDA_NRO_BORRADOR.BackgroundColor = topo;
                CELDA_NRO_BORRADOR.BorderColor = blanco;
                CELDA_NRO_BORRADOR.HorizontalAlignment = 1;
                CELDA_NRO_BORRADOR.FixedHeight = 16f;
                TABLA_FILTRADAS.AddCell(CELDA_NRO_BORRADOR);

                PdfPCell CELDA_FECHA_COMANDA = new PdfPCell(new Phrase("FECHA", _mediumFontBoldWhite));
                CELDA_FECHA_COMANDA.BackgroundColor = topo;
                CELDA_FECHA_COMANDA.BorderColor = blanco;
                CELDA_FECHA_COMANDA.HorizontalAlignment = 1;
                CELDA_FECHA_COMANDA.FixedHeight = 16f;
                TABLA_FILTRADAS.AddCell(CELDA_FECHA_COMANDA);

                PdfPCell CELDA_NRO_SOC_COMANDA = new PdfPCell(new Phrase("NRO SOC", _mediumFontBoldWhite));
                CELDA_NRO_SOC_COMANDA.BackgroundColor = topo;
                CELDA_NRO_SOC_COMANDA.BorderColor = blanco;
                CELDA_NRO_SOC_COMANDA.HorizontalAlignment = 1;
                CELDA_NRO_SOC_COMANDA.FixedHeight = 16f;
                TABLA_FILTRADAS.AddCell(CELDA_NRO_SOC_COMANDA);

                PdfPCell CELDA_AFILIADO_COMANDA = new PdfPCell(new Phrase("AFILIADO", _mediumFontBoldWhite));
                CELDA_AFILIADO_COMANDA.BackgroundColor = topo;
                CELDA_AFILIADO_COMANDA.BorderColor = blanco;
                CELDA_AFILIADO_COMANDA.HorizontalAlignment = 1;
                CELDA_AFILIADO_COMANDA.FixedHeight = 16f;
                TABLA_FILTRADAS.AddCell(CELDA_AFILIADO_COMANDA);

                PdfPCell CELDA_BENEFICIO_COMANDA = new PdfPCell(new Phrase("BENEFICIO", _mediumFontBoldWhite));
                CELDA_BENEFICIO_COMANDA.BackgroundColor = topo;
                CELDA_BENEFICIO_COMANDA.BorderColor = blanco;
                CELDA_BENEFICIO_COMANDA.HorizontalAlignment = 1;
                CELDA_BENEFICIO_COMANDA.FixedHeight = 16f;
                TABLA_FILTRADAS.AddCell(CELDA_BENEFICIO_COMANDA);

                PdfPCell CELDA_NOMAPE_COMANDA = new PdfPCell(new Phrase("NOMBRE Y APELLIDO", _mediumFontBoldWhite));
                CELDA_NOMAPE_COMANDA.BackgroundColor = topo;
                CELDA_NOMAPE_COMANDA.BorderColor = blanco;
                CELDA_NOMAPE_COMANDA.HorizontalAlignment = 1;
                CELDA_NOMAPE_COMANDA.FixedHeight = 16f;
                TABLA_FILTRADAS.AddCell(CELDA_NOMAPE_COMANDA);

                PdfPCell CELDA_IMPORTE_COMANDA = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                CELDA_IMPORTE_COMANDA.BackgroundColor = topo;
                CELDA_IMPORTE_COMANDA.BorderColor = blanco;
                CELDA_IMPORTE_COMANDA.HorizontalAlignment = 1;
                CELDA_IMPORTE_COMANDA.FixedHeight = 16f;
                TABLA_FILTRADAS.AddCell(CELDA_IMPORTE_COMANDA);

                PdfPCell CELDA_ANULADA_COMANDA = new PdfPCell(new Phrase("ANULADA", _mediumFontBoldWhite));
                CELDA_ANULADA_COMANDA.BackgroundColor = topo;
                CELDA_ANULADA_COMANDA.BorderColor = blanco;
                CELDA_ANULADA_COMANDA.HorizontalAlignment = 1;
                CELDA_ANULADA_COMANDA.FixedHeight = 16f;
                TABLA_FILTRADAS.AddCell(CELDA_ANULADA_COMANDA);
            }

            #endregion

            #region DATOS COMANDAS FILTRADAS

            decimal TOTAL_FILTRADAS = 0;

            if (COMANDAS != null && COMANDAS.Tables.Count > 0)
            {
                int X = 0;
                BaseColor colorFondo = new BaseColor(255, 255, 255);

                foreach (DataRow row in COMANDAS.Tables[0].Rows)
                {
                    string NRO_COMANDA = row[16].ToString();
                    string FECHA = row[1].ToString();
                    decimal IMPORTE = Convert.ToDecimal(row[2].ToString());
                    string IMP_FINAL = string.Format("{0:n}", IMPORTE);
                    string NRO_SOC = row[4].ToString() + " " + row[5].ToString() + " " + row[6].ToString();
                    string NOM_APE = row[3].ToString();
                    string AFILIADO = row[7].ToString();
                    string BENEFICIO = row[8].ToString();
                    string ANULADA = row[12].ToString();
                    string COM_BORRADOR = row[13].ToString();
                    string ID_COMANDA = row[0].ToString();

                    if (ANULADA == "")
                        TOTAL_FILTRADAS = TOTAL_FILTRADAS + IMPORTE;
                    else
                        TOTAL_FILTRADAS = TOTAL_FILTRADAS + 0;

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

                    if (COMPLETO == "SI")
                    {
                        colorFondo = new BaseColor(240, 240, 240);
                    }

                    PdfPCell CELL_NUMERO_COMANDA = new PdfPCell(new Phrase(NRO_COMANDA, _mediumFont));
                    CELL_NUMERO_COMANDA.HorizontalAlignment = 1;
                    CELL_NUMERO_COMANDA.BorderWidth = 0;
                    CELL_NUMERO_COMANDA.BackgroundColor = colorFondo;
                    CELL_NUMERO_COMANDA.FixedHeight = 14f;
                    TABLA_FILTRADAS.AddCell(CELL_NUMERO_COMANDA);

                    PdfPCell CELL_NUMERO_BORRADOR = new PdfPCell(new Phrase(COM_BORRADOR, _mediumFont));
                    CELL_NUMERO_BORRADOR.HorizontalAlignment = 1;
                    CELL_NUMERO_BORRADOR.BorderWidth = 0;
                    CELL_NUMERO_BORRADOR.BackgroundColor = colorFondo;
                    CELL_NUMERO_BORRADOR.FixedHeight = 14f;
                    TABLA_FILTRADAS.AddCell(CELL_NUMERO_BORRADOR);

                    PdfPCell CELL_FECHA_COMANDA = new PdfPCell(new Phrase(FECHA, _mediumFont));
                    CELL_FECHA_COMANDA.HorizontalAlignment = 1;
                    CELL_FECHA_COMANDA.BorderWidth = 0;
                    CELL_FECHA_COMANDA.BackgroundColor = colorFondo;
                    CELL_FECHA_COMANDA.FixedHeight = 14f;
                    TABLA_FILTRADAS.AddCell(CELL_FECHA_COMANDA);

                    PdfPCell CELL_NRO_SOC_COMANDA = new PdfPCell(new Phrase(NRO_SOC, _mediumFont));
                    CELL_NRO_SOC_COMANDA.HorizontalAlignment = 1;
                    CELL_NRO_SOC_COMANDA.BorderWidth = 0;
                    CELL_NRO_SOC_COMANDA.BackgroundColor = colorFondo;
                    CELL_NRO_SOC_COMANDA.FixedHeight = 14f;
                    TABLA_FILTRADAS.AddCell(CELL_NRO_SOC_COMANDA);

                    PdfPCell CELL_AFILIADO_COMANDA = new PdfPCell(new Phrase(AFILIADO, _mediumFont));
                    CELL_AFILIADO_COMANDA.HorizontalAlignment = 1;
                    CELL_AFILIADO_COMANDA.BorderWidth = 0;
                    CELL_AFILIADO_COMANDA.BackgroundColor = colorFondo;
                    CELL_AFILIADO_COMANDA.FixedHeight = 14f;
                    TABLA_FILTRADAS.AddCell(CELL_AFILIADO_COMANDA);

                    PdfPCell CELL_BENEFICIO_COMANDA = new PdfPCell(new Phrase(BENEFICIO, _mediumFont));
                    CELL_BENEFICIO_COMANDA.HorizontalAlignment = 1;
                    CELL_BENEFICIO_COMANDA.BorderWidth = 0;
                    CELL_BENEFICIO_COMANDA.BackgroundColor = colorFondo;
                    CELL_BENEFICIO_COMANDA.FixedHeight = 14f;
                    TABLA_FILTRADAS.AddCell(CELL_BENEFICIO_COMANDA);

                    PdfPCell CELL_NOMAPE_COMANDA = new PdfPCell(new Phrase(NOM_APE, _mediumFont));
                    CELL_NOMAPE_COMANDA.HorizontalAlignment = 1;
                    CELL_NOMAPE_COMANDA.BorderWidth = 0;
                    CELL_NOMAPE_COMANDA.BackgroundColor = colorFondo;
                    CELL_NOMAPE_COMANDA.FixedHeight = 14f;
                    TABLA_FILTRADAS.AddCell(CELL_NOMAPE_COMANDA);

                    PdfPCell CELL_IMPORTE_COMANDA = new PdfPCell(new Phrase(IMP_FINAL, _mediumFont));
                    CELL_IMPORTE_COMANDA.HorizontalAlignment = 1;
                    CELL_IMPORTE_COMANDA.BorderWidth = 0;
                    CELL_IMPORTE_COMANDA.BackgroundColor = colorFondo;
                    CELL_IMPORTE_COMANDA.FixedHeight = 14f;
                    TABLA_FILTRADAS.AddCell(CELL_IMPORTE_COMANDA);

                    PdfPCell CELL_ANULADA_COMANDA = new PdfPCell(new Phrase(ANULADA, _mediumFont));
                    CELL_ANULADA_COMANDA.HorizontalAlignment = 1;
                    CELL_ANULADA_COMANDA.BorderWidth = 0;
                    CELL_ANULADA_COMANDA.BackgroundColor = colorFondo;
                    CELL_ANULADA_COMANDA.FixedHeight = 14f;
                    TABLA_FILTRADAS.AddCell(CELL_ANULADA_COMANDA);

                    if (COMPLETO == "SI")
                    {
                        DataSet ITEMS = utils.getItemsByComanda(Convert.ToInt32(ID_COMANDA));

                        foreach (DataRow ROW_ITEM in ITEMS.Tables[0].Rows)
                        {
                            string PHRASE = ROW_ITEM[0] + " - " + ROW_ITEM[1] + " - " + ROW_ITEM[2] + " - $ " + ROW_ITEM[3] + " - $ " + ROW_ITEM[4];
                            PdfPCell CELL_ITEMS = new PdfPCell(new Phrase(PHRASE, _mediumFont));
                            CELL_ITEMS.HorizontalAlignment = 0;
                            CELL_ITEMS.BorderWidth = 0;
                            CELL_ITEMS.BackgroundColor = blancoFondo;
                            CELL_ITEMS.FixedHeight = 14f;
                            CELL_ITEMS.Colspan = 9;
                            TABLA_FILTRADAS.AddCell(CELL_ITEMS);
                        }
                    }
                }
            }

            doc.Add(TABLA_FILTRADAS);

            #endregion

            #region TABLA DATOS ESTADISTICOS
            
            if(ESTADISTICAS.Tables.Count>0)
            {
                Paragraph sub = new Paragraph("DATOS ESTADISTICOS", _standardFontBold);
                sub.Alignment = Element.ALIGN_CENTER;
                sub.SpacingAfter = 5;
                doc.Add(sub);

                TABLA_ESTADISTICAS.WidthPercentage = 50;
                TABLA_ESTADISTICAS.SpacingAfter = 5;
                TABLA_ESTADISTICAS.SpacingBefore = 5;
                TABLA_ESTADISTICAS.SetWidths(new float[] { 2f, 6f, 3f, 3f });

                PdfPCell CELDA_CANTIDAD = new PdfPCell(new Phrase("#", _mediumFontBoldWhite));
                CELDA_CANTIDAD.BackgroundColor = topo;
                CELDA_CANTIDAD.BorderColor = blanco;
                CELDA_CANTIDAD.HorizontalAlignment = 0;
                CELDA_CANTIDAD.FixedHeight = 16f;
                TABLA_ESTADISTICAS.AddCell(CELDA_CANTIDAD);

                PdfPCell CELDA_ITEM = new PdfPCell(new Phrase("ITEM", _mediumFontBoldWhite));
                CELDA_ITEM.BackgroundColor = topo;
                CELDA_ITEM.BorderColor = blanco;
                CELDA_ITEM.HorizontalAlignment = 0;
                CELDA_ITEM.FixedHeight = 16f;
                TABLA_ESTADISTICAS.AddCell(CELDA_ITEM);

                PdfPCell CELDA_IMPORTE = new PdfPCell(new Phrase("IMPORTE", _mediumFontBoldWhite));
                CELDA_IMPORTE.BackgroundColor = topo;
                CELDA_IMPORTE.BorderColor = blanco;
                CELDA_IMPORTE.HorizontalAlignment = 2;
                CELDA_IMPORTE.FixedHeight = 16f;
                TABLA_ESTADISTICAS.AddCell(CELDA_IMPORTE);

                PdfPCell CELDA_TOTAL = new PdfPCell(new Phrase("SUBTOTAL", _mediumFontBoldWhite));
                CELDA_TOTAL.BackgroundColor = topo;
                CELDA_TOTAL.BorderColor = blanco;
                CELDA_TOTAL.HorizontalAlignment = 2;
                CELDA_TOTAL.FixedHeight = 16f;
                TABLA_ESTADISTICAS.AddCell(CELDA_TOTAL);
            }

            #endregion

            #region DATOS ESTADISTICOS

            decimal TOTAL_ESTADISTICAS = 0;

            if (ESTADISTICAS.Tables.Count > 0)
            {
                int X = 0;
                BaseColor colorFondo = new BaseColor(255, 255, 255);

                foreach (DataRow row in ESTADISTICAS.Tables[0].Rows)
                {
                    int CANTIDAD = Convert.ToInt32(row[0]);
                    string NOMBRE_ITEM = row[1].ToString();
                    decimal SUBTOTAL = Convert.ToDecimal(row[2]);
                    string SUBTOTAL_FINAL = string.Format("{0:n}", SUBTOTAL);
                    decimal IMPORTE = SUBTOTAL / CANTIDAD;
                    string IMPORTE_FINAL = string.Format("{0:n}", IMPORTE);

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

                    TOTAL_ESTADISTICAS = TOTAL_ESTADISTICAS + IMPORTE;

                    PdfPCell CELL_CANTIDAD_ITEM = new PdfPCell(new Phrase(CANTIDAD.ToString(), _mediumFont));
                    CELL_CANTIDAD_ITEM.HorizontalAlignment = 0;
                    CELL_CANTIDAD_ITEM.BorderWidth = 0;
                    CELL_CANTIDAD_ITEM.BackgroundColor = colorFondo;
                    CELL_CANTIDAD_ITEM.FixedHeight = 14f;
                    TABLA_ESTADISTICAS.AddCell(CELL_CANTIDAD_ITEM);

                    PdfPCell CELL_NOMBRE_ITEM = new PdfPCell(new Phrase(NOMBRE_ITEM, _mediumFont));
                    CELL_NOMBRE_ITEM.HorizontalAlignment = 0;
                    CELL_NOMBRE_ITEM.BorderWidth = 0;
                    CELL_NOMBRE_ITEM.BackgroundColor = colorFondo;
                    CELL_NOMBRE_ITEM.FixedHeight = 14f;
                    TABLA_ESTADISTICAS.AddCell(CELL_NOMBRE_ITEM);

                    PdfPCell CELL_IMPORTE_ITEM = new PdfPCell(new Phrase("$ " + IMPORTE_FINAL, _mediumFont));
                    CELL_IMPORTE_ITEM.HorizontalAlignment = 2;
                    CELL_IMPORTE_ITEM.BorderWidth = 0;
                    CELL_IMPORTE_ITEM.BackgroundColor = colorFondo;
                    CELL_IMPORTE_ITEM.FixedHeight = 14f;
                    TABLA_ESTADISTICAS.AddCell(CELL_IMPORTE_ITEM);

                    PdfPCell CELL_SUBTOTAL_ITEM = new PdfPCell(new Phrase("$ " + SUBTOTAL_FINAL, _mediumFont));
                    CELL_SUBTOTAL_ITEM.HorizontalAlignment = 2;
                    CELL_SUBTOTAL_ITEM.BorderWidth = 0;
                    CELL_SUBTOTAL_ITEM.BackgroundColor = colorFondo;
                    CELL_SUBTOTAL_ITEM.FixedHeight = 14f;
                    TABLA_ESTADISTICAS.AddCell(CELL_SUBTOTAL_ITEM);
                }

                PdfPCell CELL_NOMBRE_TOTAL = new PdfPCell(new Phrase("TOTAL", _mediumFont));
                CELL_NOMBRE_TOTAL.HorizontalAlignment = 0;
                CELL_NOMBRE_TOTAL.BorderWidth = 0;
                CELL_NOMBRE_TOTAL.BackgroundColor = colorFondo;
                CELL_NOMBRE_TOTAL.FixedHeight = 14f;
                TABLA_ESTADISTICAS.AddCell(CELL_NOMBRE_TOTAL);

                PdfPCell CELL_IMPORTE_TOTAL = new PdfPCell(new Phrase("$ " + string.Format("{0:n}", TOTAL_ESTADISTICAS), _mediumFont));
                CELL_IMPORTE_TOTAL.HorizontalAlignment = 2;
                CELL_IMPORTE_TOTAL.BorderWidth = 0;
                CELL_IMPORTE_TOTAL.BackgroundColor = colorFondo;
                CELL_IMPORTE_TOTAL.FixedHeight = 14f;
                TABLA_ESTADISTICAS.AddCell(CELL_IMPORTE_TOTAL);
            }

            doc.Add(TABLA_ESTADISTICAS);

            #endregion

            doc.Close();
            writer.Close();
            AddPageNumber(RUTA);

            if (CONTROL == "NO")
            {
                bo dlog = new bo();
                dlog.confiteriaCajaDiaria(DateTime.Today.ToShortDateString(), VGlobales.vp_username, TOTAL_EFECTIVO, TOTAL_TARJETAS, TOTAL_DESCUENTO, TOTAL_ESPECIALES);
            }
        }

        #endregion

        public DataSet buscarComandas(string FECHA, string FORMA_DE_PAGO, string ORDEN, int RENDIDA)
        {
            conString conString = new conString();
            string connectionString = conString.get();

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                DataSet ds = new DataSet();
                string QUERY = string.Empty;

                switch (FORMA_DE_PAGO)
                {
                    case "EFECTIVO":
                        QUERY  = "SELECT C.NRO_COMANDA, C.FECHA, C.MESA, M.NOMBRE, C.IMPORTE, C.NRO_SOC, C.NRO_DEP, C.BARRA, C.PERSONAS, C.NOMBRE_SOCIO, C.AFILIADO, C.BENEFICIO, C.DESCUENTO, F.DETALLE, C.ANULADA, C.COM_BORRADOR, C.ID ";
                        QUERY += "FROM CONFITERIA_COMANDAS C, CONFITERIA_MOZOS M, FORMAS_DE_PAGO F ";
                        QUERY += "WHERE M.ID = C.MOZO AND F.ID = C.FORMA_DE_PAGO AND C.FORMA_DE_PAGO = 1 AND (C.TIPO_COMANDA = 1 OR C.TIPO_COMANDA = 4 OR C.TIPO_COMANDA = 5) AND C.ROL = '" + VGlobales.vp_role + "'";

                        if (RENDIDA > 0)
                            QUERY += "AND RENDIDA = " + RENDIDA + " ";
                        else
                            QUERY += "AND RENDIDA IS NULL ";

                        if (ORDEN == "COMANDA")
                            QUERY += "ORDER BY C.NRO_COMANDA ASC;";
                        else
                            QUERY += "ORDER BY C.COM_BORRADOR ASC;";

                        break;

                    case "TARJETA":
                        QUERY = "SELECT C.NRO_COMANDA, C.FECHA, C.MESA, M.NOMBRE, C.IMPORTE, C.NRO_SOC, C.NRO_DEP, C.BARRA, C.PERSONAS, C.NOMBRE_SOCIO, C.AFILIADO, C.BENEFICIO, C.DESCUENTO, F.DETALLE, C.ANULADA, C.COM_BORRADOR, C.ID ";
                        QUERY += "FROM CONFITERIA_COMANDAS C, CONFITERIA_MOZOS M, FORMAS_DE_PAGO F ";
                        QUERY += "WHERE M.ID = C.MOZO AND F.ID = C.FORMA_DE_PAGO AND (C.FORMA_DE_PAGO = 3 OR C.FORMA_DE_PAGO = 4 OR C.FORMA_DE_PAGO = 5 OR C.FORMA_DE_PAGO = 6) AND (C.TIPO_COMANDA = 1 OR C.TIPO_COMANDA = 4) AND C.ROL = '" + VGlobales.vp_role + "'";

                        if (RENDIDA > 0)
                            QUERY += "AND RENDIDA = " + RENDIDA + " ";
                        else
                            QUERY += "AND RENDIDA IS NULL ";

                        if (ORDEN == "COMANDA")
                            QUERY += "ORDER BY C.NRO_COMANDA ASC;";
                        else
                            QUERY += "ORDER BY C.COM_BORRADOR ASC;";

                        break;

                    case "DESCUENTO":
                        QUERY = "SELECT C.NRO_COMANDA, C.FECHA, C.MESA, M.NOMBRE, C.IMPORTE, C.NRO_SOC, C.NRO_DEP, C.BARRA, C.PERSONAS, C.NOMBRE_SOCIO, C.AFILIADO, C.BENEFICIO, C.DESCUENTO, F.DETALLE, C.ANULADA, C.COM_BORRADOR, C.ID ";
                        QUERY += "FROM CONFITERIA_COMANDAS C, CONFITERIA_MOZOS M, FORMAS_DE_PAGO F ";
                        QUERY += "WHERE M.ID = C.MOZO AND F.ID = C.FORMA_DE_PAGO AND C.FORMA_DE_PAGO = 8 AND C.TIPO_COMANDA = 1 AND C.ROL = '" + VGlobales.vp_role + "'";

                        if (RENDIDA > 0)
                            QUERY += "AND RENDIDA = " + RENDIDA + " ";
                        else
                            QUERY += "AND RENDIDA IS NULL ";

                        if (ORDEN == "COMANDA")
                            QUERY += "ORDER BY C.NRO_COMANDA ASC;";
                        else
                            QUERY += "ORDER BY C.COM_BORRADOR ASC;";
                        
                            break;

                    case "ESPECIALES":
                            QUERY = "SELECT C.NRO_COMANDA, C.FECHA, C.MESA, M.NOMBRE, C.IMPORTE, C.NRO_SOC, C.NRO_DEP, C.BARRA, C.PERSONAS, C.NOMBRE_SOCIO, C.AFILIADO, C.BENEFICIO, C.DESCUENTO, F.DETALLE, C.ANULADA, C.COM_BORRADOR, C.DESCUENTO_APLICADO, C.IMPORTE_DESCONTADO, C.ID ";
                            QUERY += "FROM CONFITERIA_COMANDAS C, CONFITERIA_MOZOS M, FORMAS_DE_PAGO F ";
                            QUERY += "WHERE M.ID = C.MOZO AND F.ID = C.FORMA_DE_PAGO AND C.TIPO_COMANDA = 2 AND C.NRO_SOC != 75022 AND C.ROL = '" + VGlobales.vp_role + "'";
                            
                            if (RENDIDA > 0)
                                QUERY += "AND RENDIDA = " + RENDIDA + " ";
                            else
                                QUERY += "AND RENDIDA IS NULL ";

                        if (ORDEN == "COMANDA")
                                QUERY += "ORDER BY C.NRO_COMANDA ASC;";
                            else
                                QUERY += "ORDER BY C.COM_BORRADOR ASC;";

                            break;

                    case "EMPLEADOS":
                        QUERY = "SELECT C.NRO_COMANDA, C.FECHA, C.MESA, M.NOMBRE, C.IMPORTE, C.NRO_SOC, C.NRO_DEP, C.BARRA, C.PERSONAS, C.NOMBRE_SOCIO, C.AFILIADO, C.BENEFICIO, C.DESCUENTO, F.DETALLE, C.ANULADA, C.COM_BORRADOR, C.DESCUENTO_APLICADO, C.IMPORTE_DESCONTADO, C.ID ";
                        QUERY += "FROM CONFITERIA_COMANDAS C, CONFITERIA_MOZOS M, FORMAS_DE_PAGO F ";
                        QUERY += "WHERE M.ID = C.MOZO AND F.ID = C.FORMA_DE_PAGO AND C.TIPO_COMANDA = 4 AND C.ROL = '" + VGlobales.vp_role + "'";

                        if (RENDIDA > 0)
                            QUERY += "AND RENDIDA = " + RENDIDA + " ";
                        else
                            QUERY += "AND RENDIDA IS NULL ";

                        if (ORDEN == "COMANDA")
                            QUERY += "ORDER BY C.NRO_COMANDA ASC;";
                        else
                            QUERY += "ORDER BY C.COM_BORRADOR ASC;";

                        break;
                }

                FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                cmd.CommandText = QUERY;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(cmd);
                da.Fill(ds);

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                    return ds;
                }
            }
        }

        static void OpenAdobeAcrobat(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ACRORD32.EXE";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }

        private void dpFiltroIngresos_ValueChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string FECHA = dpFiltroIngresos.Text;
            string HOY = DateTime.Today.ToShortDateString();

            if (FECHA != HOY)
            {
                lbNotToday.Visible = true;
            }
            else
            {
                lbNotToday.Visible = false;
            }

            buscarIngresos(FECHA, "NO");
            llenarGrillaIngresos(INGRESOS, dataGridView1);
            Cursor = Cursors.Default;
        }

        private void forzarCierreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MESA = int.Parse(dgMesas[11, dgMesas.CurrentCell.RowIndex].Value.ToString());

            if (dgMesas[4, dgMesas.CurrentCell.RowIndex].Value.ToString() != "")
            {
                MessageBox.Show("LA MESA TIENE NUMERO DE COMANDA", "ERROR");
            }
            else
            {
                if (MESA == 27)
                    dlog.cerrarMesa(MESA, "DELIVERY");
                else
                    dlog.cerrarMesa(MESA, "CERRADA");

                llenarGrillaMesas();
            }
        }

        private void rendidaEnComandas(string ID_COMANDA)
        {
            try
            {
                SOCIOS.maxid mid = new maxid();
                int CAJA_DIARIA = int.Parse(mid.m("ID", "CONFITERIA_CAJA_DIARIA"));
                dlog.rendidaEnComandas(int.Parse(ID_COMANDA), CAJA_DIARIA);
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR AL MARCAR LA COMANDA " + ID_COMANDA + " COMO RENDIDA\n" + error);
            }
        }

        private void marcarComandasRendidas(DataSet EFECTIVO, DataSet TARJETA, DataSet DESCUENTO, DataSet ESPECIALES)
        {
            if (EFECTIVO.Tables.Count > 0)
            {
                pbMarcandoComandas.Visible = true;
                pbMarcandoComandas.Minimum = 0;
                pbMarcandoComandas.Step = 1;
                pbMarcandoComandas.Maximum = EFECTIVO.Tables[0].Rows.Count;
                pbMarcandoComandas.Value = 0;

                foreach (DataRow row in EFECTIVO.Tables[0].Rows)
                {
                    rendidaEnComandas(row[16].ToString());
                    pbMarcandoComandas.PerformStep();
                }
            }

            if (TARJETA.Tables.Count > 0)
            {
                pbMarcandoComandas.Maximum = TARJETA.Tables[0].Rows.Count;
                pbMarcandoComandas.Value = 0;

                foreach (DataRow row in TARJETA.Tables[0].Rows)
                {
                    rendidaEnComandas(row[16].ToString());
                    pbMarcandoComandas.PerformStep();
                }
            }

            if (DESCUENTO.Tables.Count > 0)
            {
                pbMarcandoComandas.Maximum = DESCUENTO.Tables[0].Rows.Count;
                pbMarcandoComandas.Value = 0;

                foreach (DataRow row in DESCUENTO.Tables[0].Rows)
                {
                    rendidaEnComandas(row[16].ToString());
                    pbMarcandoComandas.PerformStep();
                }
            }

            if (ESPECIALES.Tables.Count > 0)
            {
                pbMarcandoComandas.Maximum = ESPECIALES.Tables[0].Rows.Count;
                pbMarcandoComandas.Value = 0;

                foreach (DataRow row in ESPECIALES.Tables[0].Rows)
                {
                    rendidaEnComandas(row[18].ToString());
                    pbMarcandoComandas.PerformStep();
                }
            }

            pbMarcandoComandas.Visible = false;
        }

        public void imprimirListado(DataSet COMANDAS, string CONTROL, string COMPLETO)
        {
            DataSet EFECTIVO = new DataSet();
            DataSet TARJETA = new DataSet();
            DataSet DESCUENTO = new DataSet();
            DataSet ESPECIALES = new DataSet();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivo PDF|*.PDF";
            saveFileDialog1.Title = "Guardar Listado";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string RUTA = saveFileDialog1.FileName;
                listadoPDF(EFECTIVO, TARJETA, DESCUENTO, RUTA, ESPECIALES, CONTROL, COMPLETO, COMANDAS);

                if (CONTROL == "NO")
                {
                    marcarComandasRendidas(EFECTIVO, TARJETA, DESCUENTO, ESPECIALES);
                }

                DialogResult result = MessageBox.Show("LISTADO GENERADO CORRECTAMENTE \n\n ¿ABRIR EL ARCHIVO?", "LISTO!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    OpenAdobeAcrobat(RUTA);
                }
            }
        }

        public void imprimirListado(string CONTROL, int RENDIDA, string COMPLETO)
        {
            string ORDEN = cbOrdenListado.SelectedItem.ToString();
            string FECHA = dpFechaListado.Text;
            
            DataSet EFECTIVO = buscarComandas(FECHA, "EFECTIVO", ORDEN, RENDIDA);
            DataSet TARJETA = buscarComandas(FECHA, "TARJETA", ORDEN, RENDIDA);
            DataSet DESCUENTO = buscarComandas(FECHA, "DESCUENTO", ORDEN, RENDIDA);
            DataSet ESPECIALES = buscarComandas(FECHA, "ESPECIALES", ORDEN, RENDIDA);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivo PDF|*.PDF";
            saveFileDialog1.Title = "Guardar Listado";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string RUTA = saveFileDialog1.FileName;
                listadoPDF(EFECTIVO, TARJETA, DESCUENTO, RUTA, ESPECIALES, CONTROL, COMPLETO);

                if (CONTROL == "NO")
                {
                    marcarComandasRendidas(EFECTIVO, TARJETA, DESCUENTO, ESPECIALES);
                }

                DialogResult result = MessageBox.Show("LISTADO GENERADO CORRECTAMENTE \n\n ¿ABRIR EL ARCHIVO?", "LISTO!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    OpenAdobeAcrobat(RUTA);
                }
            }
        }

        private bool validarCajaCerrada()
        {
            bool CAJA = false;
            string DIA = DateTime.Today.Day.ToString();
            string MES = DateTime.Today.Month.ToString();
            string ANO = DateTime.Today.Year.ToString();
            string FECHA = MES + "/" + DIA + "/" + ANO;

            string query = "SELECT FECHA FROM CONFITERIA_CAJA_DIARIA WHERE FECHA = '" + FECHA + "' AND ROL = '" + VGlobales.vp_role + "';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                CAJA = true;
            }

            return CAJA;
        }

        private void btnImprimirListado_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿CONFIRMA CERRAR LA CAJA DEL DIA?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (validarCajaCerrada() == false)
                    imprimirListado("NO", 0, "NO");
                else
                    MessageBox.Show("LA CAJA DEL DIA DE HOY YA FUE CERRADA", "ERROR");
            }
        }

        private void actualizarGrillas()
        {
            Cursor = Cursors.WaitCursor;
            buscarIngresos(dpFiltroIngresos.Text, "NO");
            llenarGrillaIngresos(INGRESOS, dataGridView1);
            llenarGrillaMesas();
            pintarMorosos();
            Cursor = Cursors.Default;
        }

        private void btnActualizarGrillas_Click(object sender, EventArgs e)
        {
            actualizarGrillas();
        }

        private void btnBuscarComandas_Click(object sender, EventArgs e)
        {
            listadoComandas lc = new listadoComandas();
            lc.ShowDialog();
        }

        private void btnAgrgarItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            abmProfesionales prof = new abmProfesionales(0);
            prof.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void submenuMesasVacias()
        {
            try
            {
                cambiarDeMesaToolStripMenuItem.DropDownItems.Clear();
                string QUERY = "SELECT MESA, NRO FROM CONFITERIA_TEMP_MESAS WHERE ESTADO = 'CERRADA' AND ROL = '" + VGlobales.vp_role + "' ORDER BY MESA ASC;";
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
                        string MESA = reader.GetString(reader.GetOrdinal("MESA")).Trim();
                        string NRO = reader.GetString(reader.GetOrdinal("NRO")).Trim();
                        string MESA_SHOW = "MESA Nº " + NRO + " - " + MESA;
                        cambiarDeMesaToolStripMenuItem.DropDownItems.Add(MESA_SHOW, null, subItemClick);
                    }

                    reader.Close(); 
                    transaction.Commit();
                }
            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR LOS RESULTADOS");
            }
        }

        private void subItemClick(object sender, EventArgs e)
        {
            int MESA_ANTIGUA = int.Parse(dgMesas[11, dgMesas.CurrentCell.RowIndex].Value.ToString());
            string MESA_NUEVA =  sender.ToString().Replace("MESA Nº ", "");
            string[] ID_MESA_NUEVA = MESA_NUEVA.Split('-');
            int ID_MN = int.Parse(ID_MESA_NUEVA[1]);
            int NRO_MESA_NUEVA = int.Parse(ID_MESA_NUEVA[0]);
            cambiarDeMesa(MESA_ANTIGUA, ID_MN, NRO_MESA_NUEVA);
        }

        private void cambiarDeMesa(int MESA_ANTIGUA, int ID_MESA_NUEVA, int NRO_MESA_NUEVA)
        {
            if (MessageBox.Show("CAMBIAR LA MESA Nº " + MESA_ANTIGUA + " A LA MESA Nº " + NRO_MESA_NUEVA, "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string DESDE = dgMesas[2, dgMesas.CurrentCell.RowIndex].Value.ToString();
                    string SOCIO = dgMesas[3, dgMesas.CurrentCell.RowIndex].Value.ToString();
                    int ID_COMANDA = int.Parse(dgMesas[12, dgMesas.CurrentCell.RowIndex].Value.ToString());
                    int NRO_COMANDA = int.Parse(dgMesas[4, dgMesas.CurrentCell.RowIndex].Value.ToString());
                    int NRO_SOC = int.Parse(dgMesas[5, dgMesas.CurrentCell.RowIndex].Value.ToString());
                    int NRO_DEP = int.Parse(dgMesas[6, dgMesas.CurrentCell.RowIndex].Value.ToString());
                    int BARRA = int.Parse(dgMesas[7, dgMesas.CurrentCell.RowIndex].Value.ToString());
                    int SECUENCIA = int.Parse(dgMesas[8, dgMesas.CurrentCell.RowIndex].Value.ToString());
                    int PERSONAS = int.Parse(dgMesas[9, dgMesas.CurrentCell.RowIndex].Value.ToString());
                    int FORMA_DE_PAGO = int.Parse(dgMesas[10, dgMesas.CurrentCell.RowIndex].Value.ToString());

                    dlog.cambiarMesa(ID_MESA_NUEVA, "ABIERTA", DESDE, SOCIO, ID_COMANDA, NRO_SOC, NRO_DEP, BARRA, SECUENCIA, PERSONAS, FORMA_DE_PAGO, NRO_COMANDA);
                    
                    dlog.cambiarMesaComanda(NRO_MESA_NUEVA, ID_COMANDA);

                    if (MESA_ANTIGUA == 27)
                        dlog.cerrarMesa(MESA_ANTIGUA, "DELIVERY");
                    else
                        dlog.cerrarMesa(MESA_ANTIGUA, "CERRADA");

                    llenarGrillaMesas();
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO CAMBIAR LA MESA\n" + error);
                }
            }
        }

        private void cambiarDeMesaToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            submenuMesasVacias();
        }

        private void btnListadoControl_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            imprimirListado("SI", 0, "NO");
            Cursor = Cursors.Default;
        }

        private void grillaPreComanda_Load(object sender, EventArgs e)
        {
            pintarMorosos();
        }

        public void buscarItems(string CONDICION)
        {
            var FILTRO = LISTA_ITEMS.Where(x => x.APELLIDO.Contains(CONDICION)).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = FILTRO;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 40;
            dataGridView1.Columns[2].Width = 145;
            dataGridView1.Columns[3].Width = 195;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[9].Width = 40;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = true;
            dataGridView1.Columns[19].Width = 70;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
        }

        private void tbBuscarIngresos_KeyUp(object sender, KeyEventArgs e)
        {
            string CONDICION = tbBuscarIngresos.Text.Trim();
            buscarItems(CONDICION);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            imprimirListado("SI", 0, "SI");
            Cursor = Cursors.Default;
        }
    }
}
