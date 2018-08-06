using System;
/*using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;*/
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
            else if (lbArchivo.Text == "No se seleccionó ningún archivo")
            {
                MessageBox.Show("SELECCIONAR UN ARCHIVO", "ERROR");
            }
            else
            {
                try
                {
                    string FECHA_INICIO = cu.convertirFecha(dpInicio.Text, "/");
                    string FECHA_FIN = cu.convertirFecha(dpFin.Text, "/");
                    bo.nuevoConvenio(
                        int.Parse(tbNroInt.Text),
                        tbRegGral.Text.Trim(),
                        FECHA_INICIO,
                        FECHA_FIN,
                        int.Parse(cbEmpresas.SelectedValue.ToString()),
                        tbDetalle.Text.Trim(),
                        int.Parse(cbTipoConvenio.SelectedValue.ToString()),
                        tbObsevaciones.Text.Trim(),
                        int.Parse(tbAnio.Text));
                    string ID_CONVENIO = mid.m("ID", "CONVENIOS");
                    string RUTA_ORIGEN = lbArchivo.Text.Trim();
                    string NOMBRE_ARCHIVO = "CONVENIO_" + ID_CONVENIO + ".pdf";
                    string RUTA_DESTINO = @"\\192.168.1.6\secgral\CONVENIOS_SISTEMA\" + NOMBRE_ARCHIVO;
                    File.Copy(RUTA_ORIGEN, RUTA_DESTINO);
                    MessageBox.Show("SE CARGÓ EL CONVENIO CORRECTAMENTE", "LISTO");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO CARGAR EL CONVENIO\n" + error, "LISTO");
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
                string FECHA_INICIO = row[3].ToString().Trim();
                string FECHA_FIN = row[4].ToString().Trim();
                string ID_EMPRESA = row[5].ToString().Trim();
                string DETALLE = row[6].ToString().Trim();
                string ID_TIPO = row[7].ToString().Trim();
                string OBSERVACIONES = row[8].ToString().Trim();
                string RAZON_SOCIAL = row[9].ToString().Trim();
                string TIPO = row[10].ToString().Trim();
                dgResultadosBuscador.Rows.Add(CONVENIO_ID, NRO_REG_GRAL, NRO_INTERNO, FECHA_INICIO, FECHA_FIN, ID_EMPRESA, RAZON_SOCIAL, DETALLE, ID_TIPO, TIPO, OBSERVACIONES);
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
                    QUERY += "T.TIPO FROM CONVENIOS C, CONVENIOS_EMPRESAS E, CONVENIOS_LOCALIDADES L, CONVENIOS_TIPOS T ";
                    QUERY += "WHERE C.EMPRESA = E.ID AND E.LOCALIDAD = L.ID ";

                    if (tbDetalleBuscador.Text != "")
                        QUERY += " AND C.DETALLE LIKE '%" + tbDetalleBuscador.Text.Trim() + "%' ";

                    if (tbNroIntBuscador.Text != "")
                        QUERY += " AND C.NRO_INTERNO = " + tbNroIntBuscador.Text.Trim();

                    if (tbRegGralBuscador.Text != "")
                        QUERY += " AND C.NRO_REG_GRAL = " + tbRegGralBuscador.Text.Trim();

                    if (tbAnioBuscador.Text != "")
                        QUERY += " AND C.ANIO = " + tbAnioBuscador.Text.Trim();

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

        private void btnVerPdf_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarEmpresa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Empresa empresa = new Empresa();
            empresa.ShowDialog();
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
    }
}
