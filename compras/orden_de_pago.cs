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
    public partial class orden_de_pago : Form
    {
        public orden_de_pago(int OP)
        {
            InitializeComponent();
            buscarOrdenDePago(OP);
            pintarOpAnulada();
            buscarFacturas(OP);
        }

        private void buscarFacturas(int OP)
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
                    string QUERY = "SELECT F.ID, F.PROVEEDOR, F.NUM_FACTURA, F.FECHA, F.IMPORTE, F.OBSERVACIONES, F.FE_ALTA, F.US_ALTA, F.FE_MOD, ";
                    QUERY += "F.US_MOD, P.RAZON_SOCIAL, F.SECTOR, F.ORDEN_DE_PAGO, F.NRO_REMITO, F.RETENCION, T.TIPO, P.CUIT, F.TIPO AS TC, F.DESCUENTO, F.ANULADO, F.OP_ANULADA ";
                    QUERY += "FROM FACTURAS F, PROVEEDORES P, TIPOS_CARGA_COMPROBANTE T ";
                    QUERY += "WHERE F.ORDEN_DE_PAGO = " + OP + " AND P.ID = F.PROVEEDOR AND F.TIPO = T.ID ORDER BY F.FECHA DESC";
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
                            mostrarResultadosFactura(reader);
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
                lvFacturas.Columns.Add("TIPO");
                lvFacturas.Columns.Add("DES%");
                lvFacturas.Columns.Add("ANULADA");
            }
            do
            {
                decimal IMPORTE = reader.GetDecimal(reader.GetOrdinal("IMPORTE"));
                string VALOR = string.Format("{0:n}", IMPORTE);
                DateTime FECHA = reader.GetDateTime(reader.GetOrdinal("FECHA"));
                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("ID")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("RAZON_SOCIAL")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NUM_FACTURA")).Trim());
                listItem.SubItems.Add(FECHA.ToShortDateString());
                listItem.SubItems.Add(VALOR);
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("OBSERVACIONES")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("SECTOR")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("TIPO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("DESCUENTO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ANULADO")).Trim());
                lvFacturas.Items.Add(listItem);
            }

            while (reader.Read());
            lvFacturas.EndUpdate();
            lvFacturas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvFacturas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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
    }
}
