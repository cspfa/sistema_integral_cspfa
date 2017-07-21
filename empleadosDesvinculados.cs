using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS
{
    public partial class empleadosDesvinculados : Form
    {
        private MySqlConnection conexionBD;
        string connStr;
        bo dlog = new bo();

        private void conectar()
        {
            if (conexionBD != null)
            {
                conexionBD.Close();
            }
            try
            {
                connStr = "SERVER=192.168.1.6; DATABASE=licencias; UID=csharp; PASSWORD=171271;";
                conexionBD = new MySqlConnection(connStr);
                conexionBD.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar al servidor de MySQL: " + ex.Message, "Error al conectar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable buscarDatos()
        {
            DataTable datos;
            MySqlDataAdapter datosAdapter;
            MySqlCommandBuilder comandoSQL;
            string query;

            try
            {
                query = "SELECT e.ndoc AS DNI, e.apellido AS APELLIDO, e.nombre AS NOMBRE, m.motivo AS MOTIVO, STR_TO_DATE(b.baja, '%d-%m-%Y') AS FECHA FROM empleados e, bajas b, motivos_baja m ";
                query += "WHERE e.lp = b.empleado AND b.motivo = m.id ORDER BY FECHA DESC;";
                datos = new DataTable();
                datosAdapter = new MySqlDataAdapter(query, conexionBD);
                comandoSQL = new MySqlCommandBuilder(datosAdapter);
                datosAdapter.Fill(datos);
                return datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al obtener los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void llenarGrid(DataTable datos)
        {
            dgDatos.DataSource = datos;
        }

        public empleadosDesvinculados()
        {
            InitializeComponent();
            conectar();
            buscarDatos();
            DataTable datos = buscarDatos();
            llenarGrid(datos);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string connString;
                Datos_ini ini = new Datos_ini();
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini.Servidor; cs.DataSource = ini.Puerto;
                cs.Database = ini.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connString = cs.ToString();

                FbConnection connection = new FbConnection(connString);
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();

                string query = "DELETE FROM EMPLEADOS_DESVINCULADOS;";
                FbCommand cmd = new FbCommand(query, connection, transaction);
                cmd.ExecuteNonQuery();
                transaction.Commit();

                progressBar1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = dgDatos.Rows.Count;
                progressBar1.Value = 1;
                progressBar1.Step = 1;


                foreach (DataGridViewRow row in dgDatos.Rows)
                {
                    string DNI = row.Cells["DNI"].Value.ToString();
                    string APELLIDO = row.Cells["APELLIDO"].Value.ToString();
                    string NOMBRE = row.Cells["NOMBRE"].Value.ToString();
                    string FECHA_BAJA = row.Cells["FECHA"].Value.ToString();
                    string MOTIVO_BAJA = row.Cells["MOTIVO"].Value.ToString();
                    dlog.cargarEmpleadosDesvinculados(DNI, APELLIDO, NOMBRE, FECHA_BAJA, MOTIVO_BAJA);
                    progressBar1.PerformStep();
                }

                MessageBox.Show("DATOS ACTUALIZADOS");
                progressBar1.Visible = false;
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO COMPLETAR LA OPERACION\n" + error);
            }
        }
    }
}
