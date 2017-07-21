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

namespace SOCIOS
{
    public partial class abmPersonas : Form
    {
        bo dlog = new bo();

        public abmPersonas()
        {
            InitializeComponent();
            comboEscalafones();
            comboCargos();
            buscarPersonas(0);
        }

        public void comboEscalafones()
        {
            cbEscalafon.DataSource = null;
            string query = "SELECT * FROM ESCALAFON ORDER BY ESCALAFON ASC;";
            cbEscalafon.Items.Clear();
            cbEscalafon.DataSource = dlog.BO_EjecutoDataTable(query);
            cbEscalafon.DisplayMember = "ESCALAFON";
            cbEscalafon.ValueMember = "ID";
            cbEscalafon.SelectedIndex = 0;
        }

        public void comboCargos()
        {
            cbCargo.DataSource = null;
            string query = "SELECT * FROM CARGO ORDER BY CARGO ASC;";
            cbCargo.Items.Clear();
            cbCargo.DataSource = dlog.BO_EjecutoDataTable(query);
            cbCargo.DisplayMember = "CARGO";
            cbCargo.ValueMember = "ID";
            cbCargo.SelectedIndex = 0;
        }

        private void buscarPersonas(int ID)
        {
            conString conString = new conString();
            string connectionString = conString.get();

            try
            {
                using (FbConnection connection = new FbConnection(connectionString))
                {
                    string QUERY = "";
                    
                    if (ID == 0)
                    {
                        QUERY = "SELECT P.ID, P.NOMBRE, E.ESCALAFON, C.CARGO FROM PERSONAS P, ESCALAFON E, CARGO C WHERE P.CARGO = C.ID AND P.ESCALAFON = E.ID AND ESTADO = 1 ORDER BY E.ID, C.ID;";
                    }
                    else 
                    {
                        QUERY = "SELECT P.ID, P.NOMBRE, P.ESCALAFON, P.CARGO FROM PERSONAS P WHERE P.ID = " + ID + ";";
                    }

                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
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
                            if (ID == 0)
                            {
                                llenarGrilla(ds);
                            }
                            else
                            {
                                llenarCampos(ds);
                            }
                        }
                    }

                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void llenarCampos(DataSet PERSONAS)
        {
            try
            {
                foreach (DataRow row in PERSONAS.Tables[0].Rows)
                {
                    string ID = row[0].ToString().Trim();
                    string NOMBRE = row[1].ToString().Trim();
                    string ESCALAFON = row[2].ToString().Trim();
                    string CARGO = row[3].ToString().Trim();
                    tbNombre.Text = NOMBRE.Trim();
                    cbEscalafon.SelectedValue = ESCALAFON;
                    cbCargo.SelectedValue = CARGO;
                    lbID.Text = ID;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void llenarGrilla(DataSet PERSONAS)
        {
            try
            {
                dgPersonas.Rows.Clear();

                foreach (DataRow row in PERSONAS.Tables[0].Rows)
                {
                    string ID = row[0].ToString().Trim();
                    string NOMBRE = row[1].ToString().Trim();
                    string ESCALAFON = row[2].ToString().Trim();
                    string CARGO = row[3].ToString().Trim();
                    dgPersonas.Rows.Add(ID, NOMBRE, CARGO, ESCALAFON);
                }

                dgPersonas.ClearSelection();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void dgPersonas_Click(object sender, EventArgs e)
        {
            lbID.Text = dgPersonas[0, dgPersonas.CurrentCell.RowIndex].Value.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO NOMBRE", "ERROR");
                tbNombre.Focus();
            }
            else
            {
                try
                {
                    string NOMBRE = tbNombre.Text.Trim();
                    int ESCALAFON = int.Parse(cbEscalafon.SelectedValue.ToString());
                    int CARGO = int.Parse(cbCargo.SelectedValue.ToString());
                    dlog.altaPersonaIngresos(NOMBRE, ESCALAFON, CARGO, 1);
                    maxid mid = new maxid();
                    string ID = mid.m("ID", "PERSONAS");
                    dlog.altaTempPa(int.Parse(ID), 2);
                    buscarPersonas(0);
                    MessageBox.Show("PERSONA CARGADA", "LISTO!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO CARGAR LA PERSONA\n" + error, "ERROR");
                }
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(lbID.Text);

            if (MessageBox.Show("¿DAR DE BAJA A LA PERSONA SELECCIONADA?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    dlog.bajaPersona(ID, 2);
                    dlog.bajaTempPa(ID);
                    buscarPersonas(0);
                    MessageBox.Show("PERSONA ELIMINADA", "LISTO!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO ELIMINAR LA PERSONA\n" + error, "ERROR");
                }
            }
        }
    }
}
