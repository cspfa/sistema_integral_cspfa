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
    public partial class puntosDeVenta : Form
    {
        bo dlog = new bo();

        public puntosDeVenta()
        {
            InitializeComponent();
            //DataSet PTO_VTA = buscarPuntosDeVenta(0);
            //mostrarPuntosDeVenta(PTO_VTA);
            comboRoles();
        }

        private void comboRoles()
        {
            string QUERY = "SELECT RDB$RELATION_NAME as USRROLE FROM RDB$USER_PRIVILEGES WHERE RDB$PRIVILEGE = 'M'  GROUP BY USRROLE ORDER BY 1";
            cbRoles.DataSource = null;
            cbRoles.Items.Clear();
            cbRoles.DataSource = dlog.BO_EjecutoDataTable(QUERY);
            cbRoles.DisplayMember = "USRROLE";
            cbRoles.ValueMember = "USRROLE";
            cbRoles.SelectedItem = 0;
        }

        /*private DataSet buscarPuntosDeVenta(int ID)
        {
            Cursor = Cursors.WaitCursor;
            DataSet DS = null;

            try
            {
                conString cs = new conString();
                string connectionString = cs.get();
                string BUSCO = "";

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();

                    if (ID == 0)
                        BUSCO = "SELECT ID, PTO_VTA, DETALLE, NUM_RECIBO, NUM_BONO, DESTINO FROM PUNTOS_DE_VENTA ORDER BY PTO_VTA;";
                    else
                        BUSCO = "SELECT * FROM PUNTOS_DE_VETA WHERE ID = " + ID + ";";

                    FbCommand cmd = new FbCommand(BUSCO, connection, transaction);
                    cmd.CommandText = BUSCO;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    READER = cmd.ExecuteReader();
                    READER.Close();
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

            return READER;
            Cursor = Cursors.Default;
        }*/

        private void mostrarPuntosDeVenta(FbDataReader reader)
        {
            lvPuntosDeVenta.Items.Clear();
            lvPuntosDeVenta.Columns.Clear();
            lvPuntosDeVenta.BeginUpdate();

            if (lvPuntosDeVenta.Columns.Count == 0)
            {
                lvPuntosDeVenta.Columns.Add("ID");
                lvPuntosDeVenta.Columns.Add("PTO VTA");
                lvPuntosDeVenta.Columns.Add("LUGAR");
                lvPuntosDeVenta.Columns.Add("# RECIBO");
                lvPuntosDeVenta.Columns.Add("# BONO");
                lvPuntosDeVenta.Columns.Add("DESTINO");
            }
            do
            {
                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("ID")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("PTO_VTA")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("DETALLE")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NUM_RECIBO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NUM_BONO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("DESTINO")).Trim());
                lvPuntosDeVenta.Items.Add(listItem);
            }

            while (reader.Read());
            lvPuntosDeVenta.EndUpdate();
            lvPuntosDeVenta.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvPuntosDeVenta.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void llenarDatosPtoVta(FbDataReader reader)
        {
            string ID = "";
            string ROLE = "";
            string PTO_VTA = "";
            string NRO_RECIBO = "";
            string NRO_BONO = "";
            string CUENTA = "";
            string ACCION = "";
            string DESTINO = "";
            string DETALLE = "";

            do
            {
                ID = reader.GetString(reader.GetOrdinal("ID")).Trim();
                ROLE = reader.GetString(reader.GetOrdinal("ROL")).Trim();
                PTO_VTA = reader.GetString(reader.GetOrdinal("PTO_VTA")).Trim();
                NRO_RECIBO = reader.GetString(reader.GetOrdinal("NRO_RECIBO")).Trim();
                NRO_BONO = reader.GetString(reader.GetOrdinal("NRO_BONO")).Trim();
                CUENTA = reader.GetString(reader.GetOrdinal("CUENTA")).Trim();
                ACCION = reader.GetString(reader.GetOrdinal("ACCION")).Trim();
                DESTINO = reader.GetString(reader.GetOrdinal("DESTINO")).Trim();
                DETALLE = reader.GetString(reader.GetOrdinal("DETALLE")).Trim();
            }

            while (reader.Read());
        }

        private void lvPuntosDeVenta_MouseUp(object sender, MouseEventArgs e)
        {
            int ID_PTO_VTA = int.Parse(lvPuntosDeVenta.SelectedItems[0].SubItems[0].Text);
            //FbDataReader PTO_VTA = buscarPuntosDeVenta(ID_PTO_VTA);
            //llenarDatosPtoVta(PTO_VTA);
        }

        private void btnModPtoVta_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddPtoVta_Click(object sender, EventArgs e)
        {

        }
    }
}
