using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;

namespace SOCIOS
{
    public partial class informeAranceles : Form
    {
        public informeAranceles(string CATEGORIA)
        {
            InitializeComponent();

            informe(CATEGORIA);
        }

        public void informe(string CATEGORIA)
        {
            string query = "SELECT SA.ROL AS SECTOR, SA.DETALLE, PR.NOMBRE AS PROFESIONAL, CO.SIGN AS CATEGORIA, AA.ARANCEL FROM ARANCELES_SERVICIOS AA, SECTACT SA, CODIGOS CO, PROFESIONALES PR WHERE AA.CATSOC = " + CATEGORIA + " AND AA.SECTACT = SA.ID AND AA.CATSOC = SUBSTRING (CO.CODIGO FROM 4 FOR 3) AND SUBSTRING (CO.CODIGO FROM 1 FOR 2) = 'CA' AND PR.ID = AA.PROFESIONAL ORDER BY SA.ROL, SA.DETALLE, PR.NOMBRE, AA.CATSOC;";

            string connectionString;
            
            DataSet ds1 = new DataSet();
            
            Datos_ini ini3 = new Datos_ini();
            
            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                
                cs.DataSource = ini3.Servidor;  cs.Port = int.Parse(ini3.Puerto);
                
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

                    dt1.Columns.Add("SECTOR", typeof(string));
 
                    dt1.Columns.Add("DETALLE", typeof(string));
                    
                    dt1.Columns.Add("PROFESIONAL", typeof(string));
                    
                    dt1.Columns.Add("CATEGORIA", typeof(string));
                    
                    dt1.Columns.Add("ARANCEL", typeof(string));
                    
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    
                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("SECTOR")).Trim(), 
                                     
                                     reader3.GetString(reader3.GetOrdinal("DETALLE")).Trim(), 
                            
                                     reader3.GetString(reader3.GetOrdinal("PROFESIONAL")).Trim(), 
                            
                                     reader3.GetString(reader3.GetOrdinal("CATEGORIA")).Trim(),
                            
                                     reader3.GetString(reader3.GetOrdinal("ARANCEL")).Trim());
                    }

                    reader3.Close();

                    dgvAranceles.DataSource = dt1;

                    dgvAranceles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    
                    dgvAranceles.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    
                    dgvAranceles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    
                    dgvAranceles.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    
                    dgvAranceles.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    
                    transaction.Commit();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR AL CARGAR LOS RESULTADOS\n\n"+error);
            }
        }
    }
}
