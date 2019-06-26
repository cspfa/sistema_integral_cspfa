using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class informePagos : Form
    {
        public informePagos(int ID_SOC, string ROL)
        {
            InitializeComponent();
            buscarRecibos(ID_SOC, ROL);
        }

        public void buscarRecibos(int ID_SOC, string ROL)
        {
            try
            {
                string connectionString;
                DataSet ds1 = new DataSet();
                Datos_ini ini3 = new Datos_ini();   
    
                string query = "SELECT * FROM PAGOS_REALIZADOS ("+ID_SOC+", '"+ROL+"');";

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
                    dt1.Columns.Add("PTO_VENTA", typeof(int));
                    dt1.Columns.Add("COMP", typeof(int));
                    dt1.Columns.Add("TIPO", typeof(string));
                    dt1.Columns.Add("DEBE", typeof(int));
                    dt1.Columns.Add("HABER", typeof(int));
                    dt1.Columns.Add("SECTOR", typeof(string));
                    dt1.Columns.Add("SERVICIO", typeof(string));
                    dt1.Columns.Add("VALOR", typeof(decimal));
                    dt1.Columns.Add("ALTA", typeof(DateTime));
                    dt1.Columns.Add("PAGO", typeof(string));
                    dt1.Columns.Add("FECHA", typeof(DateTime));
                    dt1.Columns.Add("PROFESIONAL", typeof(string));
                    dt1.Columns.Add("OBSERVACIONES", typeof(string));
                    dt1.Columns.Add("TITULAR", typeof(string));
                    dt1.Columns.Add("TIP TIT" , typeof(string));
                    dt1.Columns.Add("SOCIO", typeof(string));
                    dt1.Columns.Add("TIP SOC" , typeof(string));
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    FbDataReader reader3 = cmd.ExecuteReader();
                    
                    string VALOR = string.Empty;
                    decimal IMPORTE;

                    while (reader3.Read())
                    {
                        IMPORTE = reader3.GetDecimal(reader3.GetOrdinal("VALOR"));
                        VALOR = string.Format("{0:n}", IMPORTE);

                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("PTO_VTA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NRO_COMP")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("BR")).Trim(),         
                                     reader3.GetString(reader3.GetOrdinal("CUENTA_DEBE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("CUENTA_HABER")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("ROLL")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("DETALLE")).Trim(),
                                     VALOR,
                                     reader3.GetString(reader3.GetOrdinal("FECHA_ALTA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("PAGO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("FECHA_RECIBO")).Trim().Substring(0, 10),
                                     reader3.GetString(reader3.GetOrdinal("PROFESIONAL")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("OBSERVACIONES")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE_SOCIO_TITULAR")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TIPO_SOCIO_TITULAR")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE_SOCIO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TIPO_SOCIO")).Trim());
                    }

                    reader3.Close();
                    dgvPagos.DataSource = dt1;
                    dgvPagos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPagos.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvPagos.Columns[15].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
