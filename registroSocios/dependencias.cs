using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS.registroSocios
{
    public partial class dependencias : Form
    {
        public dependencias()
        {
            InitializeComponent();
            buscarDependencias("");
        }

        private void buscarDetalles(string CODIGO)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
                cs.Database = ini2.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    string busco = "SELECT CODIGO, ORDEN, UPPER(NOMBRE) AS NOMBRE, UPPER(DEPENDENCIA) AS DEPENDENCIA, UPPER(DOMICILIO) AS DOMICILIO, PISO, COD_POST, UPPER(LOCALIDAD) AS LOCALIDAD, UPPER(DATOS_UTILES) ";
                    busco += "AS DATOS_UTILES, EMAIL, ORD_DIST, ORD71, ID FROM DEPENDENCIAS_DETALLES WHERE CODIGO = '" + CODIGO + "' ORDER BY ORDEN ASC;";
                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        mostrarResultadosDetalles(reader);
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

        private void mostrarResultadosDetalles(FbDataReader reader)
        {
            LVDETALLES.Items.Clear();
            LVDETALLES.Columns.Clear();
            LVDETALLES.BeginUpdate();

            if (LVDETALLES.Columns.Count == 0)
            {
                LVDETALLES.Columns.Add("CODIGO");
                LVDETALLES.Columns.Add("ORDEN");
                LVDETALLES.Columns.Add("NOMBRE");
                LVDETALLES.Columns.Add("DEPENDENCIA");
                LVDETALLES.Columns.Add("DOMICILIO");
                LVDETALLES.Columns.Add("PISO");
                LVDETALLES.Columns.Add("COD_POST");
                LVDETALLES.Columns.Add("LOCALIDAD");
                LVDETALLES.Columns.Add("DATOS UTILES");
                LVDETALLES.Columns.Add("EMAIL");
                LVDETALLES.Columns.Add("ORD_DIST");
                LVDETALLES.Columns.Add("ORD71");
                LVDETALLES.Columns.Add("ID");
            }
            do
            {
                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("CODIGO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ORDEN")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NOMBRE")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("DEPENDENCIA")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("DOMICILIO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("PISO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("COD_POST")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("LOCALIDAD")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("DATOS_UTILES")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("EMAIL")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ORD_DIST")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ORD71")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("ID")).Trim());
                LVDETALLES.Items.Add(listItem);
            }

            while (reader.Read());
            LVDETALLES.EndUpdate();
            LVDETALLES.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            LVDETALLES.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buscarDependencias(string CODIGO)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
                cs.Database = ini2.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    string busco = "";
                    
                    if (CODIGO == "")
                        busco = "SELECT CODIGO, UPPER(SIGN) AS NOMBRE, ESTADO FROM CODIGOS WHERE SUBSTRING(CODIGO FROM 1 FOR 2) = 'DE' OR SUBSTRING(CODIGO FROM 1 FOR 2) = 'CI' ORDER BY CODIGO ASC;";
                    else
                        busco = "SELECT CODIGO, UPPER(SIGN) AS NOMBRE, ESTADO FROM CODIGOS WHERE SUBSTRING(CODIGO FROM 1 FOR 2) = 'DE' OR SUBSTRING(CODIGO FROM 1 FOR 2) = 'CI' AND SUBSTRING(CODIGO FROM 3 FOR 4) = '" + CODIGO + "' ORDER BY CODIGO ASC;";
                    

                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        mostrarResultadosDependencias(reader);
                    }
                    else
                    {
                        MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void mostrarResultadosDependencias(FbDataReader reader)
        {
            LVDEPENDENCIAS.Items.Clear();
            LVDEPENDENCIAS.Columns.Clear();
            LVDEPENDENCIAS.BeginUpdate();

            if (LVDEPENDENCIAS.Columns.Count == 0)
            {
                LVDEPENDENCIAS.Columns.Add("CODIGO");
                LVDEPENDENCIAS.Columns.Add("NOMBRE");
            }
            do
            {
                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("CODIGO")).Trim());
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("NOMBRE")).Trim());
                LVDEPENDENCIAS.Items.Add(listItem);
            }

            while (reader.Read());
            LVDEPENDENCIAS.EndUpdate();
            LVDEPENDENCIAS.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            LVDEPENDENCIAS.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void BTNAPLICAR_Click(object sender, EventArgs e)
        {
            string CODIGO = TBFILTRO.Text.Trim();
            buscarDependencias(CODIGO);
        }

        private void desbloquearSistemas()
        { 
            
        }

        private void limpiar()
        {
            //MODIFICAR
            TBDESCRIPCION.Text = "";
            TBCODIGO.Text = "";
            TBESTADO.Text = "";
            TBORDEN.Text = "";
            TBORD71.Text = "";
            TBDOMICILIO.Text = "";
            TBPISO.Text = "";
            TBCODPOST.Text = "";
            TBLOCALIDAD.Text = "";
            TBORDDIST.Text = "";
            TBDEPENDENCIA.Text = "";
            TBEMAIL.Text = "";
            TBDATOSUTILES.Text = "";
            TBFILTRO.Text = "";

            //NUEVA
            TBNUEVOCODIGO.Text = "";
            TBNUEVADESCRIPCION.Text = "";
            TBNUEVOESTADO.Text = "1";
        }

        private void BTNMODIFICAR_Click(object sender, EventArgs e)
        {
            if (TBCODIGO.Text == "")
            {
                MessageBox.Show("SELECCIONAR UN REGISTRO PARA MODIFICAR", "ERROR");
            }
            else if (MessageBox.Show("¿CONFIRMA LA MODIFICACION DEL REGISTRO?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string CODIGO = TBCODIGO.Text.Trim();
                    string DESCIPCION = TBDESCRIPCION.Text.Trim();
                    int ESTADO = int.Parse(TBESTADO.Text.Trim());
                    bo dlog = new bo();
                    dlog.actualizarDependencia(CODIGO, DESCIPCION, ESTADO);
                    MessageBox.Show("ACTUALIZACION FINALIZADA", "LISTO!");
                    limpiar();
                    buscarDependencias("");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
            }
        }

        private void LVDEPENDENCIAS_Click(object sender, EventArgs e)
        {
            string CODIGO = LVDEPENDENCIAS.SelectedItems[0].SubItems[0].Text;
            string DESCIPCION = LVDEPENDENCIAS.SelectedItems[0].SubItems[1].Text;
            LVDETALLES.Clear();
            buscarDetalles(CODIGO);
        }

        private void BTNNUEVADEP_Click(object sender, EventArgs e)
        {
            string DESCRIPCION = TBNUEVADESCRIPCION.Text.Trim();
            string CODIGO = "DE" + TBNUEVOCODIGO.Text.Trim().ToUpper();
            int ESTADO = int.Parse(TBNUEVOESTADO.Text.Trim());

            if (DESCRIPCION == "")
            {
                MessageBox.Show("INGRESAR UNA DESCRIPCION", "ERROR");
            }
            else if (CODIGO == "")
            {
                MessageBox.Show("INGRESAR UNA CODIGO", "ERROR");
            }
            else
            {
                try
                {
                    bo dlog = new bo();
                    dlog.nuevaDependencia(CODIGO, DESCRIPCION, ESTADO);
                    MessageBox.Show("SE CREO EL NUEVO REGISTRO", "LISTO!");
                    limpiar();
                    buscarDependencias("");
                }
                catch (Exception error)
                {
                    MessageBox.Show("INGRESAR UNA CODIGO\n" + error, "ERROR");
                }
            }
        }

        private void BTNLIMPIAR_Click(object sender, EventArgs e)
        {
            limpiar();
            buscarDependencias("");
        }

        private void LVDETALLES_Click(object sender, EventArgs e)
        {
            TBDESCRIPCION.Text = LVDETALLES.SelectedItems[0].SubItems[2].Text;
            TBCODIGO.Text = LVDETALLES.SelectedItems[0].SubItems[0].Text;
            TBORDEN.Text = LVDETALLES.SelectedItems[0].SubItems[1].Text;
            TBORD71.Text = LVDETALLES.SelectedItems[0].SubItems[11].Text;
            TBDOMICILIO.Text = LVDETALLES.SelectedItems[0].SubItems[4].Text;
            TBPISO.Text = LVDETALLES.SelectedItems[0].SubItems[5].Text;
            TBCODPOST.Text = LVDETALLES.SelectedItems[0].SubItems[6].Text;
            TBLOCALIDAD.Text = LVDETALLES.SelectedItems[0].SubItems[7].Text;
            TBORDDIST.Text = LVDETALLES.SelectedItems[0].SubItems[10].Text;
            TBDEPENDENCIA.Text = LVDETALLES.SelectedItems[0].SubItems[3].Text;
            TBEMAIL.Text = LVDETALLES.SelectedItems[0].SubItems[9].Text;
            TBDATOSUTILES.Text = LVDETALLES.SelectedItems[0].SubItems[8].Text;
            LBID.Text = LVDETALLES.SelectedItems[0].SubItems[12].Text;
        }
    }
}
