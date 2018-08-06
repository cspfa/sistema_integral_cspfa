using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using SOCIOS;

namespace OrientacionSocial
{
    public partial class asignarElemento : Form
    {
        bo dlog = new bo();

        public asignarElemento(string TIPO_SOCIO, string ID_SOCIO)
        {
            InitializeComponent();
            buscarSocio(ID_SOCIO, TIPO_SOCIO);
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

                    DataSet ds = new DataSet();
                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mostrarDatosSocio(ds);
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

        private void mostrarDatosSocio(DataSet ds)
        {
            dgDatosSocio.Rows.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string APE_SOC = row[0].ToString().Trim();
                string NOM_SOC = row[1].ToString().Trim();
                string NRO_SOC = row[2].ToString().Trim();
                string NRO_DEP = row[3].ToString().Trim();
                string CAT_SOC = row[5].ToString().Trim();
                string ACRJP2 = row[6].ToString().Trim();
                string COD_DTO = row[7].ToString().Trim();
                string IDE_EMP = row[8].ToString().Trim();
                dgDatosSocio.Rows.Add(APE_SOC, NOM_SOC, NRO_SOC, NRO_DEP, CAT_SOC, ACRJP2, COD_DTO, IDE_EMP);
            }

            dgDatosSocio.ClearSelection();
        }
    }
}
