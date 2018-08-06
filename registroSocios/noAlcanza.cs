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

        public noAlcanza(string TIPO_SOCIO, string ID_SOCIO)
        {
            InitializeComponent();
            buscarSocio(ID_SOCIO, TIPO_SOCIO);
            buscarTarjetas(ID_SOCIO, TIPO_SOCIO);
            buscarCbus(ID_SOCIO, TIPO_SOCIO);
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
                        busco = "SELECT T.APE_SOC, T.NOM_SOC, T.NRO_SOC, T.NRO_DEP, T.CAT_SOC, C.SIGN, T.ACRJP2, T.COD_DTO, T.ID_EMPLEADO, T.ID_TITULAR_ANT FROM TITULAR T, CODIGOS C WHERE ID_TITULAR = '" + ID_SOCIO + "' AND 'CA0'||T.CAT_SOC = C.CODIGO;";
                    }

                    if (TIPO_SOCIO == "ADHERENTE")
                    {
                        busco = "SELECT A.APE_ADH, A.NOM_ADH, A.NRO_ADH, A.NRO_DEPADH FROM ADHERENT A WHERE ID_ADHERENTE = '" + ID_SOCIO + "';";
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

        private void buscarTarjetas(string ID_SOCIO, string TIPO_SOCIO)
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
                        busco = "SELECT TARJETA_CREDITO, BANCO, VENCIMIENTO, TIPO_TARJETA, FE_ALTA, FE_BAJA FROM TITULAR_CBU WHERE ID_TITULAR = '" + ID_SOCIO + "' AND ID_ADHERENTE = 0 AND TARJETA_CREDITO IS NOT NULL;";
                    }

                    if (TIPO_SOCIO == "ADHERENTE")
                    {
                        busco = "SELECT TARJETA_CREDITO, BANCO, VENCIMIENTO, TIPO_TARJETA, FE_ALTA, FE_BAJA FROM TITULAR_CBU WHERE ID_ADHERENTE = '" + ID_SOCIO + "' AND TARJETA_CREDITO IS NOT NULL;";
                    }
                    
                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        mostrarResultadoTarjeta(reader);
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

        private void buscarCbus(string ID_SOCIO, string TIPO_SOCIO)
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
                        busco = "SELECT CBU, FE_ALTA, FE_BAJA FROM TITULAR_CBU WHERE ID_TITULAR = '" + ID_SOCIO + "' AND ID_ADHERENTE = 0 AND TARJETA_CREDITO IS NULL AND CBU IS NOT NULL;";
                    }

                    if (TIPO_SOCIO == "ADHERENTE")
                    {
                        busco = "SELECT CBU, FE_ALTA FROM TITULAR_CBU WHERE ID_ADHERENTE = '" + ID_SOCIO + "' AND TARJETA_CREDITO IS NULL AND CBU IS NOT NULL;";
                    }

                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        mostrarResultadoCbu(reader);
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
                lvDatosSocio.Items.Add(listItem);
            }

            while (reader.Read());
            lvDatosSocio.EndUpdate();
            lvDatosSocio.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvDatosSocio.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void mostrarResultadoTarjeta(FbDataReader reader)
        {
            lvTarjetas.Items.Clear();
            lvTarjetas.Columns.Clear();
            lvTarjetas.BeginUpdate();

            if (lvTarjetas.Columns.Count == 0)
            {
                lvTarjetas.Columns.Add("NRO TARJETA");
                lvTarjetas.Columns.Add("BANCO");
                lvTarjetas.Columns.Add("VENCIMIENTO");
                lvTarjetas.Columns.Add("TIPO");
                lvTarjetas.Columns.Add("ALTA");
                lvTarjetas.Columns.Add("BAJA");
            }
            do
            {
                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("TARJETA_CREDITO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("BANCO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("VENCIMIENTO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TIPO_TARJETA")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("FE_ALTA")).Trim().Substring(0, 10));

                if (reader.GetString(reader.GetOrdinal("FE_BAJA")) != "")
                {
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("FE_BAJA")).Trim().Substring(0, 10));
                }
                else
                {
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("FE_BAJA")).Trim());
                }
                
                lvTarjetas.Items.Add(listItem);
            }

            while (reader.Read());
            lvTarjetas.EndUpdate();
            lvTarjetas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvTarjetas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void mostrarResultadoCbu(FbDataReader reader)
        {
            lvCbus.Items.Clear();
            lvCbus.Columns.Clear();
            lvCbus.BeginUpdate();

            if (lvCbus.Columns.Count == 0)
            {
                lvCbus.Columns.Add("CBU");
                lvCbus.Columns.Add("ALTA");
                lvCbus.Columns.Add("BAJA");
            }
            do
            {
                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("CBU")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("FE_ALTA")).Trim().Substring(0, 10));

                if (reader.GetString(reader.GetOrdinal("FE_BAJA")) != "")
                {
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("FE_BAJA")).Trim().Substring(0, 10));
                }
                else
                {
                    listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("FE_BAJA")).Trim());
                }

                lvCbus.Items.Add(listItem);
            }

            while (reader.Read());
            lvCbus.EndUpdate();
            lvCbus.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvCbus.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {

        }
    }
}
