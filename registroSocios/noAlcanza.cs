using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS.registroSocios
{
    public partial class noAlcanza : Form
    {
        bo dlog = new bo();
        BO.bo_RegSoc REG_SOC = new BO.bo_RegSoc();
        private string V_ID_SOCIO { get; set; }
        private string V_TIPO_SOCIO { get; set; }
        private int V_DNI_SOCIO { get; set; }

        public noAlcanza(string TIPO_SOCIO, string ID_SOCIO, int DNI_SOCIO)
        {
            InitializeComponent();
            V_ID_SOCIO = ID_SOCIO;
            V_TIPO_SOCIO = TIPO_SOCIO;
            V_DNI_SOCIO = DNI_SOCIO;
            buscarSocio(ID_SOCIO, TIPO_SOCIO);
            comboMotivos();
            buscarCuotas(DNI_SOCIO);
        }

        private void comboMotivos()
        {
            string query = "SELECT ID, MOTIVO FROM NO_ALCANZA_MOTIVOS ORDER BY MOTIVO ASC;";
            cbMotivos.DataSource = null;
            cbMotivos.Items.Clear();
            cbMotivos.DataSource = dlog.BO_EjecutoDataTable(query);
            cbMotivos.DisplayMember = "MOTIVO";
            cbMotivos.ValueMember = "ID";
            cbMotivos.SelectedItem = 0;
        }

        private void buscarSocio(string ID_SOCIO, string TIPO_SOCIO)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                conString cs = new conString();
                string connectionString = cs.get();
                string busco = "";

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();

                    if (TIPO_SOCIO == "TITULAR")
                    {
                        busco = "SELECT NUM_DOC, APE_SOC, NOM_SOC, NRO_SOC, NRO_DEP FROM TITULAR WHERE ID_TITULAR = " + ID_SOCIO;
                    }

                    if (TIPO_SOCIO == "ADHERENTE")
                    {
                        busco = "SELECT NUM_DOCADH AS NUM_DOC, APE_ADH AS APE_SOC, NOM_ADH AS NOM_SOC, NRO_ADH AS NRO_SOC, NRO_DEPADH AS NRO_DEP FROM ADHERENT A WHERE ID_ADHERENTE = " + ID_SOCIO;
                    }

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
                lvDatosSocio.Columns.Add("DNI");
                lvDatosSocio.Columns.Add("APELLIDO");
                lvDatosSocio.Columns.Add("NOMBRE");
                lvDatosSocio.Columns.Add("NRO SOC");
                lvDatosSocio.Columns.Add("NRO DEP");
            }
            do
            {
                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("NUM_DOC")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("APE_SOC")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NOM_SOC")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NRO_SOC")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NRO_DEP")).Trim());
                lvDatosSocio.Items.Add(listItem);
            }

            while (reader.Read());
            lvDatosSocio.EndUpdate();
            lvDatosSocio.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvDatosSocio.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buscarCuotas(int DNI)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                conString cs = new conString();
                string connectionString = cs.get();
                string QUERY = "SELECT N.ID, N.FECHA_A_DTO, M.MOTIVO, N.BAJA FROM NO_ALCANZA_CUOTA_SOCIAL N, NO_ALCANZA_MOTIVOS M ";
                QUERY += "WHERE N.DNI = " + DNI + " AND N.MOTIVO_NO_ALCANZA = M.ID ORDER BY N.FECHA_A_DTO DESC;";

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        mostrarResultadoCuotas(reader);
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

        private void mostrarResultadoCuotas(FbDataReader reader)
        {
            lvCuotasAdeudadas.Items.Clear();
            lvCuotasAdeudadas.Columns.Clear();
            lvCuotasAdeudadas.BeginUpdate();

            if (lvCuotasAdeudadas.Columns.Count == 0)
            {
                lvCuotasAdeudadas.Columns.Add("ID");
                lvCuotasAdeudadas.Columns.Add("A DTO");
                lvCuotasAdeudadas.Columns.Add("MOTIVO");
                lvCuotasAdeudadas.Columns.Add("BAJA");
            }
            do
            {
                string A_DTO = reader.GetString(reader.GetOrdinal("FECHA_A_DTO")).Trim().Replace(" 00:00:00", "").Substring(3, 7);
                string BAJA = "";

                if (reader.GetString(reader.GetOrdinal("BAJA"))!="")
                    BAJA = reader.GetString(reader.GetOrdinal("BAJA")).Trim().Replace(" 00:00:00", "").Substring(3, 7);

                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("ID")).Trim());
                listItem.SubItems.Add(A_DTO);
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("MOTIVO")).Trim());
                listItem.SubItems.Add(BAJA);
                lvCuotasAdeudadas.Items.Add(listItem);
            }

            while (reader.Read());
            lvCuotasAdeudadas.EndUpdate();
            lvCuotasAdeudadas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvCuotasAdeudadas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            pintarCuotas();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string A_DTO = dpAdto.Value.ToShortDateString();
                int MOTIVO = int.Parse(cbMotivos.SelectedValue.ToString());
                REG_SOC.nuevoNoAlcanza(V_DNI_SOCIO, A_DTO, MOTIVO);
                buscarCuotas(V_DNI_SOCIO);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void btnEliminarCuotas_Click(object sender, EventArgs e)
        {
            if (lvCuotasAdeudadas.SelectedItems.Count >= 1)
            {
                foreach (ListViewItem itemRow in lvCuotasAdeudadas.SelectedItems)
                {
                    try
                    {
                        int ID = int.Parse(itemRow.SubItems[0].Text);
                        string BAJA = DateTime.Now.ToShortDateString();
                        REG_SOC.bajaNoAlcanza(ID, BAJA);
                    }
                    catch(Exception error)
                    {
                        MessageBox.Show(error.ToString());
                    }
                }

                buscarCuotas(V_DNI_SOCIO);
            }
            else
            {
                MessageBox.Show("SELECCIONAR AL MENOS UNA CUOTA PARA ELIMINAR", "ERROR!");
            }        
        }

        private void pintarCuotas()
        {
            foreach (ListViewItem itemRow in lvCuotasAdeudadas.Items)
            {
                if(itemRow.SubItems[3].Text != "")
                {
                    itemRow.ForeColor = Color.DarkGreen;
                }
                else
                {
                    itemRow.ForeColor = Color.Red;
                }
            }
        }
    }
}
