using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SOCIOS
{
    public partial class employees : Form
    {
        private MySqlConnection conexionBD;
        string connStr;

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

        public employees()
        {
            InitializeComponent();
            conectar();
            buscarDatos();
            DataTable datos = buscarDatos();
            llenarGrid(datos);
        }

        public void llenarGrid(DataTable datos)
        {
            dgDatos.DataSource = datos;
        }

        public DataTable buscarDatos()
        {
            DataTable datos;
            MySqlDataAdapter datosAdapter;
            MySqlCommandBuilder comandoSQL;
            string query;

            try
            {
                query = "SELECT e.lp AS LP, CONCAT(TRIM(UPPER(e.apellido)), ', ', TRIM(UPPER(e.nombre))) AS EMPLEADO, UPPER(s.sexo) AS SEXO, STR_TO_DATE(e.fecha_nacimiento, '%d-%m-%Y') AS NACIMIENTO, ";

                query += "TIMESTAMPDIFF(YEAR, STR_TO_DATE(e.fecha_nacimiento, '%d-%m-%Y'), CURDATE()) AS EDAD, UPPER(ca.categoria) AS CATEGORIA, ce.desde, ce.hasta, al.alta ";

                query += "FROM empleados e, sexos s, categorias ca, categorias_empleados ce, altas al WHERE e.sexo = s.id AND e.estado = 1 AND ca.id = ce.categoria AND ce.empleado = e.id AND e.lp = al.empleado ";

                query += "ORDER BY EDAD DESC, EMPLEADO ASC, ce.id DESC";

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
    }
}
