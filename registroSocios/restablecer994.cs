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
    public partial class restablecer994 : Form
    {
        bo dlog = new bo();

        public restablecer994(int ID_TITULAR)
        {
            InitializeComponent();
            ID = ID_TITULAR;
        }

        private int ID { get; set; }

        private void buscarSocio(int ID_TITULAR)
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
                    string busco = "SELECT T.APE_SOC, T.NOM_SOC, T.NRO_SOC, T.NRO_DEP, T.CAT_SOC, C.SIGN, T.ACRJP2, T.COD_DTO, T.ID_EMPLEADO, T.ID_TITULAR_ANT FROM TITULAR T, CODIGOS C WHERE ID_TITULAR = " + ID_TITULAR + " AND 'CA0'||T.CAT_SOC = C.CODIGO;";
                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        mostrarResultadoSocio(reader);
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

            Cursor = Cursors.Default;
        }

        private void mostrarResultadoSocio(FbDataReader reader)
        {
            lvDatosSocio.Items.Clear();
            lvDatosSocio.Columns.Clear();
            lvDatosSocio.BeginUpdate();

            if (lvDatosSocio.Columns.Count == 0)
            {
                lvDatosSocio.Columns.Add("APELLIDO");
                lvDatosSocio.Columns.Add("NOMBRE");
                lvDatosSocio.Columns.Add("NRO SOC");
                lvDatosSocio.Columns.Add("NRO DEP");
                lvDatosSocio.Columns.Add("CAT SOC");
                lvDatosSocio.Columns.Add("CATEGORIA");
                lvDatosSocio.Columns.Add("ACRJP2");
                lvDatosSocio.Columns.Add("COD DTO");
                lvDatosSocio.Columns.Add("ID EMPLEADO");
                lvDatosSocio.Columns.Add("ID ANTERIOR");
            }
            do
            {
                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("APE_SOC")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NOM_SOC")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NRO_SOC")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NRO_DEP")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("CAT_SOC")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("SIGN")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ACRJP2")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("COD_DTO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ID_EMPLEADO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ID_TITULAR_ANT")).Trim());
                lvDatosSocio.Items.Add(listItem);
            }

            while (reader.Read());
            lvDatosSocio.EndUpdate();
            lvDatosSocio.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvDatosSocio.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private string right(string value, int length)
        {
            return value.Substring(value.Length - length);
        }

        private void comboCatSoc()
        {
            string query = "SELECT SUBSTRING(CODIGO FROM 4 FOR 4) AS ID, SIGN AS DETALLE FROM CODIGOS WHERE SUBSTRING(CODIGO FROM 1 FOR 2) = 'CA' AND CODIGO NOT IN ('CA0015', 'CA0011', 'CA0012', 'CA0009', 'CA0010', 'CA0005', 'CA0INP', 'CA0008', 'CA0007', 'CA0006', 'CA0013', 'CA0014', 'CA000Z');";
            cbCatSoc.DataSource = null;
            cbCatSoc.Items.Clear();
            cbCatSoc.DataSource = dlog.BO_EjecutoDataTable(query);
            cbCatSoc.DisplayMember = "DETALLE";
            cbCatSoc.ValueMember = "ID";
            cbCatSoc.SelectedItem = 0;
        }

        private void restablecer994_Load(object sender, EventArgs e)
        {
            buscarSocio(ID);
            string ID_SOCIO = lvDatosSocio.Items[0].SubItems[9].Text;
            string NRO_DEP = right(ID_SOCIO, 3);
            string NRO_SOC = ID_SOCIO.Replace(NRO_DEP, "");
            tbNroSoc.Text = NRO_SOC; 
            tbNroDep.Text = NRO_DEP;
            tbIdTitular.Text = ID_SOCIO;
            comboCatSoc();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            if (tbCodDto.Text == "")
            {
                MessageBox.Show("INGRESAR UN COD DTO", "ERROR!");
            }
            else if (MessageBox.Show("¿CONFIRMA RESTABLECER EL ADHERENTE INTERFUERZA SELECCIONADO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    int ID_TITULAR = int.Parse(tbIdTitular.Text);
                    int COD_DTO = int.Parse(tbCodDto.Text);
                    string CAT_SOC = cbCatSoc.SelectedValue.ToString();
                    int NRO_SOC = int.Parse(tbNroSoc.Text);
                    int NRO_DEP = int.Parse(tbNroDep.Text);
                    int ID_ADH = ID;
                    dlog.restablecer994(ID_TITULAR, COD_DTO, CAT_SOC, NRO_SOC, NRO_DEP, ID_ADH);
                    Cursor = Cursors.Default;
                    MessageBox.Show("SOCIO RESTABLECIDO CORRECTAMENTE", "ERROR!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO RESTABLECER EL SOCIO\n" + error, "ERROR!");
                    Cursor = Cursors.Default;
                }
            }
        }
    }
}
