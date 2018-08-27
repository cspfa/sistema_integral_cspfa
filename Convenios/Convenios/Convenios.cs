using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using SOCIOS;
using System.Data;

namespace Convenios
{
    public partial class Convenios : Form
    {
        bo bo = new bo();
        ConveniosUtils cu = new ConveniosUtils();
        maxid mid = new maxid();
        private int ID_CONVENIO { get; set; }

        public Convenios()
        {
            InitializeComponent();
            comboEmpresas(cbEmpresaBuscador);
            comboEmpresas(cbEmpresas);
            comboTipos(cbTipoConvenio);
            ID_CONVENIO = 0;
        }

        private void comboEmpresas(ComboBox COMBO)
        {
            string query = "SELECT ID, RAZON_SOCIAL FROM CONVENIOS_EMPRESAS ORDER BY RAZON_SOCIAL ASC;";
            COMBO.DataSource = null;
            COMBO.Items.Clear();
            COMBO.DataSource = bo.BO_EjecutoDataTable(query);
            COMBO.DisplayMember = "RAZON_SOCIAL";
            COMBO.ValueMember = "ID";
            COMBO.SelectedItem = 0;
        }

        private void comboTipos(ComboBox COMBO)
        {
            string query = "SELECT ID, TIPO FROM CONVENIOS_TIPOS ORDER BY TIPO ASC;";
            COMBO.DataSource = null;
            COMBO.Items.Clear();
            COMBO.DataSource = bo.BO_EjecutoDataTable(query);
            COMBO.DisplayMember = "TIPO";
            COMBO.ValueMember = "ID";
            COMBO.SelectedItem = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            DateTime DT_DESDE = DateTime.Parse(dpInicio.Text);
            DateTime DT_HASTA = DateTime.Parse(dpFin.Text);
            int DATE_COMP = DateTime.Compare(DT_DESDE, DT_HASTA);
            string MSG_FAIL = "NO SE PUDO CARGAR EL CONVENIO";
            string MSG_SUCC = "SE CARGÓ EL CONVENIO CORRECTAMENTE";

            if (tbDetalle.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO DETALLE", "ERROR");
            }
            else if (tbRegGral.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO REG GRAL", "ERROR");
            }
            else if (tbNroInt.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO NRO INTERNO", "ERROR");
            }
            else if (tbAnio.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO AÑO", "ERROR");
            }
            else if (DATE_COMP == 1)
            {
                MessageBox.Show("LA FECHA DE FINALIZACIÓN NO PUEDE SER MENOR QUE LA FECHA DE INICIO", "ERROR");
            }
            else if (DATE_COMP == 0)
            {
                MessageBox.Show("LA FECHA DE FINALIZACIÓN NO PUEDE SER IGUAL QUE LA FECHA DE INICIO", "ERROR");
            }
            else if (lbArchivo.Text == "No se seleccionó ningún archivo" && ID_CONVENIO == 0)
            {
                MessageBox.Show("SELECCIONAR UN ARCHIVO", "ERROR");
            }
            else
            {
                try
                {
                    string FECHA_INICIO = cu.convertirFecha(dpInicio.Text, "/");
                    string FECHA_FIN = cu.convertirFecha(dpFin.Text, "/");

                    if (ID_CONVENIO > 0)
                    {
                        bo.modificarConvenio(ID_CONVENIO, int.Parse(tbNroInt.Text), tbRegGral.Text.Trim(), FECHA_INICIO, FECHA_FIN, int.Parse(cbEmpresas.SelectedValue.ToString()), tbDetalle.Text.Trim(),
                            int.Parse(cbTipoConvenio.SelectedValue.ToString()), tbObsevaciones.Text.Trim(), int.Parse(tbAnio.Text));
                        MSG_FAIL = "NO SE PUDO MODIFICAR EL CONVENIO";
                        MSG_SUCC = "SE MODIFICÓ EL CONVENIO CORRECTAMENTE";
                    }
                    else
                    {
                        bo.nuevoConvenio(int.Parse(tbNroInt.Text), tbRegGral.Text.Trim(), FECHA_INICIO, FECHA_FIN, int.Parse(cbEmpresas.SelectedValue.ToString()), tbDetalle.Text.Trim(),
                            int.Parse(cbTipoConvenio.SelectedValue.ToString()), tbObsevaciones.Text.Trim(), int.Parse(tbAnio.Text));
                    }

                    if (lbArchivo.Text != "No se seleccionó ningún archivo")
                    {
                        string ID_CONV = mid.m("ID", "CONVENIOS");
                        string RUTA_ORIGEN = lbArchivo.Text.Trim();
                        string NOMBRE_ARCHIVO = "CONVENIO_" + ID_CONV + ".pdf";
                        string RUTA_DESTINO = @"\\192.168.1.6\secgral\CONVENIOS_SISTEMA\" + NOMBRE_ARCHIVO;
                        File.Copy(RUTA_ORIGEN, RUTA_DESTINO);
                    }

                    buscar();
                    MessageBox.Show(MSG_SUCC, "LISTO");
                }
                catch (Exception error)
                {
                    MessageBox.Show(MSG_FAIL+"\n" + error, "LISTO");
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void mostrar(DataSet ds)
        {
            dgResultadosBuscador.Rows.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string CONVENIO_ID = row[0].ToString().Trim();
                string NRO_INTERNO = row[1].ToString().Trim();
                string NRO_REG_GRAL = row[2].ToString().Trim();
                string FECHA_INICIO = row[3].ToString().Trim().Replace(" 00:00:00", "");
                string FECHA_FIN = row[4].ToString().Trim().Replace(" 00:00:00", ""); ;
                string ID_EMPRESA = row[5].ToString().Trim();
                string DETALLE = row[6].ToString().Trim();
                string ID_TIPO = row[7].ToString().Trim();
                string OBSERVACIONES = row[8].ToString().Trim();
                string RAZON_SOCIAL = row[9].ToString().Trim();
                string TIPO = row[10].ToString().Trim();
                string ANIO = row[11].ToString().Trim();
                dgResultadosBuscador.Rows.Add(CONVENIO_ID, NRO_REG_GRAL, NRO_INTERNO, FECHA_INICIO, FECHA_FIN, ID_EMPRESA, RAZON_SOCIAL, DETALLE, ID_TIPO, TIPO, OBSERVACIONES, ANIO);
            }
        }

        private void buscar()
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
                    string QUERY = "SELECT C.ID, C.NRO_INTERNO, C.NRO_REG_GRAL, C.FECHA_INICIO, C.FECHA_FIN, C.EMPRESA, C.DETALLE, C.TIPO, C.OBSERVACIONES, E.RAZON_SOCIAL, ";
                    QUERY += "T.TIPO, C.ANIO FROM CONVENIOS C, CONVENIOS_EMPRESAS E, CONVENIOS_LOCALIDADES L, CONVENIOS_TIPOS T ";
                    QUERY += "WHERE C.EMPRESA = E.ID AND E.LOCALIDAD = L.ID ";

                    if (tbDetalleBuscador.Text != "")
                        QUERY += " AND C.DETALLE LIKE '%" + tbDetalleBuscador.Text.Trim() + "%' ";

                    if (tbNroIntBuscador.Text != "")
                        QUERY += " AND C.NRO_INTERNO = " + tbNroIntBuscador.Text.Trim();

                    if (tbRegGralBuscador.Text != "")
                        QUERY += " AND C.NRO_REG_GRAL = " + tbRegGralBuscador.Text.Trim();

                    if (tbAnioBuscador.Text != "")
                        QUERY += " AND C.ANIO = " + tbAnioBuscador.Text.Trim();

                    if (cbEmpresaBuscador.SelectedValue.ToString() != "")
                        QUERY += " AND C.EMPRESA = " + cbEmpresaBuscador.SelectedValue.ToString();

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
                            mostrar(ds);
                        }
                        else
                        {
                            MessageBox.Show("NO SE ENCONTRARON RESULTADOS", "OUCH!");
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbDetalleBuscador.Text == "" && tbNroIntBuscador.Text == "" && tbRegGralBuscador.Text == "" && tbAnioBuscador.Text == "" && cbEmpresaBuscador.SelectedValue.ToString() == "")
            {
                MessageBox.Show("INGRESAR UN CRITERIO DE BÚSQUEDA", "ERROR");
            }
            else
            {
                buscar();
            }
        }

        static void OpenAdobeAcrobat(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\Program Files (x86)\Adobe\Acrobat Reader DC\Reader\AcroRd32.exe";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }

        private void btnVerPdf_Click(object sender, EventArgs e)
        {
            if (dgResultadosBuscador.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow row in dgResultadosBuscador.SelectedRows)
                {
                    string ID_CONV = row.Cells[0].Value.ToString();
                    string NOMBRE_ARCHIVO = "CONVENIO_" + ID_CONV + ".pdf";
                    string RUTA_DESTINO = @"\\192.168.1.6\secgral\CONVENIOS_SISTEMA\" + NOMBRE_ARCHIVO;

                    try
                    {
                        OpenAdobeAcrobat(RUTA_DESTINO);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO ABRIR EL ARCHIVO\n" + error);
                    }
                }
            }
        }

        private void btnAgregarEmpresa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Empresa empresa = new Empresa();
            empresa.ShowDialog();
            comboEmpresas(cbEmpresas);
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.pdf";
            ofd.ShowDialog();
            string archivo = ofd.FileName;

            if (archivo != "*.pdf")
            {
                lbArchivo.Text = archivo;
            }
        }

        private void dgResultadosBuscador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgResultadosBuscador.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow row in dgResultadosBuscador.SelectedRows)
                {
                    ID_CONVENIO = int.Parse(row.Cells[0].Value.ToString());
                    tbDetalle.Text = row.Cells[7].Value.ToString();
                    cbEmpresas.SelectedValue = row.Cells[5].Value.ToString();
                    tbRegGral.Text = row.Cells[1].Value.ToString();
                    tbNroInt.Text = row.Cells[2].Value.ToString();
                    tbAnio.Text = row.Cells[11].Value.ToString();
                    cbTipoConvenio.SelectedValue = row.Cells[8].Value.ToString();
                    tbObsevaciones.Text = row.Cells[10].Value.ToString();
                    dpInicio.Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
                    dpFin.Value = Convert.ToDateTime(row.Cells[4].Value.ToString());
                }
            }
        }
    }
}
