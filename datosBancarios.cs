using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Text.RegularExpressions;

namespace SOCIOS
{
    public partial class datosBancarios : Form
    {
        public datosBancarios(int ID_SOCIO, string ID_ADHERENTE, string ID_FAMILIAR, string TIPO)
        {
            InitializeComponent();
            TBIDTITULAR.Text = ID_SOCIO.ToString();
            TBIDADHERENTE.Text = ID_ADHERENTE.ToString();
            TBIDFAMILIAR.Text = ID_FAMILIAR.ToString();
            TIPO_SOCIO = TIPO;
            ID_T = ID_SOCIO;
            ID_A = ID_ADHERENTE;
            ID_F = ID_FAMILIAR;
            buscarDatosBancarios(ID_SOCIO);
            comboTipoTarjeta();
        }

        private string TIPO_SOCIO { get; set; }
        private int ID_T { get; set; }
        private string ID_A { get; set; }
        private string ID_F { get; set; }

        private void comboTipoTarjeta()
        {
            cbTipoTarjeta.Items.Add("CREDITO");
            cbTipoTarjeta.Items.Add("DEBITO");
            cbTipoTarjeta.SelectedItem = "CREDITO";
        }

        private void limpiarDatosBancarios()
        {
            TBCBU.Text = "";
            DPALTA.Text = DateTime.Today.ToShortDateString();
            TBCODIGO.Text = "";
            DPBAJA.Text = DateTime.Today.ToShortDateString();
            CBBAJA.Checked = false;
            TBTC.Text = "";
            TBBANCO.Text = "";
            TBVENCIMIENTO.Text = "";
            BTNMODI.Enabled = false;
            BTNNUEVO.Enabled = true;
        }

        private void secuenciaDatosBancarios()
        {
            conString conString = new conString();
            string connectionString = conString.get();

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    string QUERY = "SELECT SECUENCIA FROM TITULAR_CBU WHERE ID_TITULAR = " + ID_T;
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int SECUENCIA = int.Parse(reader.GetString(reader.GetOrdinal("SECUENCIA"))) + 1;
                        TBSECUENCIA.Text = SECUENCIA.ToString(); 
                    }
                    else
                    {
                        TBSECUENCIA.Text = "1"; 
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

        private void buscarDatosBancarios(int ID_TITULAR)
        {
            conString conString = new conString();
            string connectionString = conString.get();

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    string QUERY = "";

                    if (TIPO_SOCIO == "ADH")
                    {
                        QUERY = "SELECT * FROM TITULAR_CBU WHERE ID_ADHERENTE = " + ID_A;
                    }
                    else if (TIPO_SOCIO == "INP")
                    {
                        QUERY = "SELECT * FROM TITULAR_CBU WHERE ID_ADHERENTE = " + ID_A;
                    }
                    else if (TIPO_SOCIO == "FAM")
                    {
                        QUERY = "SELECT * FROM TITULAR_CBU WHERE ID_FAMILIAR = " + ID_F;
                    }
                    else
                    {
                        QUERY = "SELECT * FROM TITULAR_CBU WHERE ID_TITULAR = " + ID_T + " AND ID_FAMILIAR = 0 AND ID_ADHERENTE = 0";
                    }

                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        mostrarDatosBancarios(reader);
                    }
                    else
                    {
                        label60.Text = "DATOS BANCARIOS CARGADOS: NO SE ENCONTRARON DATOS";
                    }

                    secuenciaDatosBancarios();
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

        private void mostrarDatosBancarios(FbDataReader reader)
        {
            lvBancariosCargados.Items.Clear();
            lvBancariosCargados.Columns.Clear();
            lvBancariosCargados.BeginUpdate();
            string FE_ALTA = string.Empty;
            string FE_BAJA = string.Empty;

            if (lvBancariosCargados.Columns.Count == 0)
            {
                lvBancariosCargados.Columns.Add("ID_TITULAR");
                lvBancariosCargados.Columns.Add("SECUENCIA");
                lvBancariosCargados.Columns.Add("CBU");
                lvBancariosCargados.Columns.Add("ALTA");
                lvBancariosCargados.Columns.Add("CODIGO");
                lvBancariosCargados.Columns.Add("BAJA");
                lvBancariosCargados.Columns.Add("TARJETA DE CREDITO");
                lvBancariosCargados.Columns.Add("BANCO TARJETA");
                lvBancariosCargados.Columns.Add("VENCIMIENTO");
                lvBancariosCargados.Columns.Add("TIPO");
            }
            do
            {
                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("ID_TITULAR")));

                FE_ALTA = reader.GetString(reader.GetOrdinal("FE_ALTA")).ToString();

                if (FE_ALTA != "")
                {
                    FE_ALTA = FE_ALTA.Substring(0, 10);
                }

                FE_BAJA = reader.GetString(reader.GetOrdinal("FE_BAJA")).ToString();

                if (FE_BAJA != "")
                {
                    FE_BAJA = FE_BAJA.Substring(0, 10);
                }

                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("SECUENCIA")));
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("CBU")));
                listItem.SubItems.Add(FE_ALTA);
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("CODIGO")));
                listItem.SubItems.Add(FE_BAJA);
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TARJETA_CREDITO")));
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("BANCO")));
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("VENCIMIENTO")));
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TIPO_TARJETA")));
                lvBancariosCargados.Items.Add(listItem);
            }

            while (reader.Read());
            lvBancariosCargados.EndUpdate();
            lvBancariosCargados.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvBancariosCargados.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private string validarDatosBancarios()
        {
            string MENSAJE = "OK";

            if (TBCBU.Text == "" && TBTC.Text == "")
            {
                MENSAJE = "ERROR: INGRESAR UN CBU O UNA TARJETA DE CREDITO";
            }
            else if (TBTC.Text != "" && TBVENCIMIENTO.Text == "")
            {
                MENSAJE = "ERROR: INGRESAR UNA FECHA DE VENCIMIENTO";
                TBVENCIMIENTO.Focus();
            }
            else if (TBTC.Text != "" && TBBANCO.Text == "")
            {
                MENSAJE = "ERROR: INGRESAR UN BANCO";
                TBBANCO.Focus();
            }
            else if (TBTC.Text != "" && TBTC.Text.Length < 16)
            {
                MENSAJE = "ERROR: EL NUMERO DE TARJETA DE CREDITO TIENE MENOS DE 16 DIGITOS";
                TBBANCO.Focus();
            }

            return MENSAJE;
        }

        private void BTNNUEVO_Click(object sender, EventArgs e)
        {
            string VALIDAR = validarDatosBancarios();

            if (VALIDAR.Contains("ERROR"))
            {
                MessageBox.Show(VALIDAR);
            }
            else
            {
                try
                {
                    int IDTITULAR = int.Parse(TBIDTITULAR.Text);
                    int SECUENCIA = int.Parse(TBSECUENCIA.Text);
                    string CBU = TBCBU.Text.Trim();
                    string ALTA = DPALTA.Text;
                    string CODIGO = TBCODIGO.Text;
                    string BAJA = null;
                    string TC = TBTC.Text.Trim();
                    string BANCO = TBBANCO.Text.Trim();
                    string VENCIMIENTO = TBVENCIMIENTO.Text;
                    string ID_ADHERENTE = TBIDADHERENTE.Text;
                    string ID_FAMILIAR = TBIDFAMILIAR.Text;
                    string TIPO_TARJETA = cbTipoTarjeta.SelectedItem.ToString().Substring(0, 1);

                    if (CBBAJA.Checked == true)
                    {
                        BAJA = DPBAJA.Text;
                    }

                    bo dlog = new bo();
                    dlog.altaCbuSocios(IDTITULAR, SECUENCIA, CBU, ALTA, CODIGO, BAJA, TC, BANCO, VENCIMIENTO, ID_ADHERENTE, ID_FAMILIAR, TIPO_TARJETA);
                    buscarDatosBancarios(IDTITULAR);
                    limpiarDatosBancarios();
                    MessageBox.Show("DATOS BANCARIOS CARGADOS CORRECTAMENTE", "LISTO!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE CARGARON LOS DATOS BANCARIOS\n" + error, "ERROR");
                }
            }
        }

        private void BTNMODI_Click(object sender, EventArgs e)
        {
            string VALIDAR = validarDatosBancarios();

            if (VALIDAR.Contains("ERROR"))
            {
                MessageBox.Show(VALIDAR);
            }
            else
            {
                try
                {
                    int IDTITULAR = int.Parse(TBIDTITULAR.Text);
                    int SECUENCIA = int.Parse(TBSECUENCIA.Text);
                    string CBU = TBCBU.Text.Trim();
                    string ALTA = DPALTA.Text;
                    string CODIGO = TBCODIGO.Text;
                    string BAJA = null;
                    string TC = TBTC.Text.Trim();
                    string BANCO = TBBANCO.Text.Trim();
                    string VENCIMIENTO = TBVENCIMIENTO.Text;
                    string TIPO_TARJETA = cbTipoTarjeta.SelectedItem.ToString().Substring(0, 1);

                    if (CBBAJA.Checked == true)
                    {
                        BAJA = DPBAJA.Text;
                    }

                    bo dlog = new bo();
                    dlog.modificaCbuSocios(IDTITULAR, SECUENCIA, CBU, ALTA, CODIGO, BAJA, TC, BANCO, VENCIMIENTO, TIPO_TARJETA);
                    buscarDatosBancarios(IDTITULAR);
                    limpiarDatosBancarios();
                    MessageBox.Show("DATOS BANCARIOS MODIFICADOS CORRECTAMENTE", "LISTO!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE MODIFICARON LOS DATOS BANCARIOS\n" + error, "ERROR");
                }
            }
        }

        private void lvBancariosCargados_Click(object sender, EventArgs e)
        {
            TBIDTITULAR.Text = lvBancariosCargados.SelectedItems[0].SubItems[0].Text.Trim();
            TBSECUENCIA.Text = lvBancariosCargados.SelectedItems[0].SubItems[1].Text.Trim();
            TBCBU.Text = lvBancariosCargados.SelectedItems[0].SubItems[2].Text.Trim();
            DPALTA.Text = lvBancariosCargados.SelectedItems[0].SubItems[3].Text.Trim();
            TBCODIGO.Text = lvBancariosCargados.SelectedItems[0].SubItems[4].Text.Trim();

            if (lvBancariosCargados.SelectedItems[0].SubItems[5].Text != "")
            {
                DPBAJA.Text = lvBancariosCargados.SelectedItems[0].SubItems[5].Text.Trim();
                CBBAJA.Checked = true;
            }
            else
            {
                DPBAJA.Text = DateTime.Today.ToShortDateString().Trim();
                CBBAJA.Checked = false;
            }

            TBTC.Text = lvBancariosCargados.SelectedItems[0].SubItems[6].Text.Trim();
            TBBANCO.Text = lvBancariosCargados.SelectedItems[0].SubItems[7].Text.Trim();
            TBVENCIMIENTO.Text = lvBancariosCargados.SelectedItems[0].SubItems[8].Text.Trim();
            BTNMODI.Enabled = true;
            BTNNUEVO.Enabled = false;
        }

        private void CBBAJA_CheckedChanged(object sender, EventArgs e)
        {
            if (CBBAJA.Checked == true)
            {
                DPBAJA.Enabled = true;
            }
            else
            {
                DPBAJA.Enabled = false;
            }
        }
    }
}
