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
            buscarPuntosDeVenta(0);
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

        private void buscarPuntosDeVenta(int ID)
        {
            Cursor = Cursors.WaitCursor;
            
            try
            {
                conString cs = new conString();
                string connectionString = cs.get();
                string BUSCO = "";

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();

                    if (ID == 0)
                        BUSCO = "SELECT ID, PTO_VTA, DETALLE, NUM_RECIBO, NUM_BONO, DESTINO FROM PUNTOS_DE_VENTA ORDER BY PTO_VTA;";
                    else
                        BUSCO = "SELECT ID, PTO_VTA, DETALLE, NUM_RECIBO, NUM_BONO, DESTINO FROM PUNTOS_DE_VENTA WHERE ID = " + ID + ";";

                    FbCommand cmd = new FbCommand(BUSCO, connection, transaction);
                    cmd.CommandText = BUSCO;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mostrarPuntosDeVenta(ds);
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

        private void mostrarPuntosDeVenta(DataSet ds)
        {
            dgPtosDeVta.Rows.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string ID = row[0].ToString().Trim();
                string PTO_VTA = row[1].ToString().Trim();
                string DETALLE = row[2].ToString().Trim();
                string NUM_RECIBO = row[3].ToString().Trim();
                string NUM_BONO = row[4].ToString().Trim();
                string DESTINO = row[5].ToString().Trim();
                dgPtosDeVta.Rows.Add(ID, PTO_VTA, DETALLE, NUM_RECIBO, NUM_BONO, DESTINO);
            }
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
            //int ID_PTO_VTA = int.Parse(lvPuntosDeVenta.SelectedItems[0].SubItems[0].Text);
            //FbDataReader PTO_VTA = buscarPuntosDeVenta(ID_PTO_VTA);
            //llenarDatosPtoVta(PTO_VTA);
        }

        private void btnModPtoVta_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddPtoVta_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevoPtoVta_Click(object sender, EventArgs e)
        {

        }
    }
}
