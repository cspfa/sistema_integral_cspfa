using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOCIOS;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS.bono
{
    public partial class ParticipativoBono : Form
    {
        public List<SOCIOS.Turismo.GridPersona> listaPersonas;
        
        public DataGridViewSelectedRowCollection Seleccion;

        public ParticipativoBono(string NroSocio,string NroDep)
        {
            InitializeComponent();
            CargarGrilla(NroSocio, NroDep);


        }


        private void  CargarGrilla(string NroSocio,string Dep)

        {

            string query = "SELECT NUM_DOCADH DNI ,NOM_ADH NOMBRE,APE_ADH APELLIDO,CAST(F_NACIMADH as varchar(10)) NACIMIENTO, 'ADH' TIPO,NRO_SOCIO NROSOCIOTITULAR,NRO_ADH  NroSocio, NRO_DEPADH NroDep,Barra BARRA,NUM_TE1ADH Telefono, E_MAIL Email FROM ADHERENT WHERE NRO_SOCIO=" + NroSocio + " AND NRO_DEP=" + Dep + " AND NRO_DEPADH = 11  ORDER BY ID_ADHERENTE ASC";



            string connectionString;
            DataSet ds1 = new DataSet();
            Datos_ini ini3 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini3.Servidor; //cs.Port = int.Parse(ini3.Puerto);
                cs.Database = ini3.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    FbTransaction transaction = connection.BeginTransaction();

                    DataTable dt1 = new DataTable("RESULTADOS");

                    dt1.Columns.Add("DNI", typeof(string));
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("APELLIDO", typeof(string));
                    dt1.Columns.Add("NACIMIENTO", typeof(string));
                    dt1.Columns.Add("TIPO", typeof(string));
                    dt1.Columns.Add("NROSOCIOTITULAR", typeof(string));
                    dt1.Columns.Add("NROSOCIO", typeof(string));
                    dt1.Columns.Add("NRODEP", typeof(string));
                    dt1.Columns.Add("BARRA", typeof(string));
                    dt1.Columns.Add("TELEFONO", typeof(string));
                    dt1.Columns.Add("EMAIL", typeof(string));
                   
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("DNI")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("APELLIDO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NACIMIENTO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TIPO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NROSOCIOTITULAR")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NROSOCIO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NRODEP")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("BARRA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TELEFONO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("EMAIL")).Trim());
                    }


                    reader3.Close();
                    DgvGrupo.DataSource = dt1;

                    // Datos.Add(ds);
                  
                    // dgvGrupo.Columns[10].Visible = false;

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void ParticipativoBono_Load(object sender, EventArgs e)
        {

        }

        private void Seleccionar_Click(object sender, EventArgs e)
        {
            Seleccion = DgvGrupo.SelectedRows;
        }

        private void DgvGrupo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
