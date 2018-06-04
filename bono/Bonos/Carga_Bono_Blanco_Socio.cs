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


namespace SOCIOS.bono.Bonos
{
    public partial class Carga_Bono_Blanco_Socio : Form
    {
        string TIPO = "";
        int ID;
        DataGridViewSelectedRowCollection Personas;
        string NRO_SOCIO;
        string NRO_DEP;
        public Carga_Bono_Blanco_Socio(string pTIPO, DataGridViewSelectedRowCollection pPersonas,string pNRO_SOC,string pNRO_DEP)
        {
            InitializeComponent();
            dpDesde.Value = System.DateTime.Now.AddMonths(-1);
            dpHasta.Value = System.DateTime.Now;
            TIPO = pTIPO;
            Personas = pPersonas;
            NRO_SOCIO = pNRO_SOC;
            NRO_DEP = pNRO_DEP;
            cbFecha.Checked = true;
            this.RefrescarGrilla();
            gpFecha.Visible = false;
            gpID.Visible = false;

        }


        private void RefrescarGrilla()
        {
            string Desde = this.fechaUSA(dpDesde.Value);
            string Hasta = this.fechaUSA(dpHasta.Value);
            int ID=0;
            if (tbID.Text.Length>0)
                ID = Int32.Parse(tbID.Text);



            string query = "Select ID ID,ID_ROL SECUENCIA,FE_BONO FECHA FROM BONO_TURISMO WHERE BONO_BLANCO='SI' AND TIPO='" + TIPO + "'";

            if (cbFecha.Checked)
            {
                query = query + " AND FE_BONO Between '" + Desde + "' AND '" + Hasta + "'";
            }
            if (cbID.Checked)
            {
                query = query + " AND ID_ROL= " + ID.ToString();
            }




            //MessageBox.Show(query);

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
                    dt1.Columns.Add("ID", typeof(string));
                    dt1.Columns.Add("SECUENCIA", typeof(string));
                    dt1.Columns.Add("FECHA", typeof(string));
                  
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("SECUENCIA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("FECHA")).Trim());
                    }

                    reader3.Close();

                    dgvDatos.DataSource = dt1;
                    dgvDatos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvDatos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvDatos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                   

                    transaction.Commit();
                }






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private string fechaUSA(DateTime fecha)
        {
            string Fecha = fecha.Month.ToString("00") + "/" + fecha.Day.ToString("00") + "/" + fecha.Year.ToString("0000");

            return Fecha;


        }

        private void btn_Bono_Click(object sender, EventArgs e)
        {
            if  (TIPO.Contains("HOT"))
            {

                BonoHotel bh = new BonoHotel(Personas,NRO_SOCIO,NRO_DEP,true);
                bh.ID=ID;
                bh.BONO_BLANCO=true;
                bh.ShowDialog();


            } else if (TIPO.Contains("PAS"))
            {
                 BonoPasaje bp = new BonoPasaje(Personas,NRO_SOCIO,NRO_DEP,true);
                 bp.ID=ID;
                 bp.BONO_BLANCO=true;
                 bp.ShowDialog();
            }
            else
            {
                BonoPaquete bs = new BonoPaquete(Personas, NRO_SOCIO, NRO_DEP, true);
                bs.ID = ID;
                bs.BONO_BLANCO = true;
                bs.ShowDialog();
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Int32.Parse(dgvDatos.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbID_CheckedChanged(object sender, EventArgs e)
        {
            if (cbID.Checked)
            {
                gpID.Visible = true;
                gpFecha.Visible = false;
               
            }
            else
            {
                gpID.Visible = false;
                gpFecha.Visible = true;
              
            
            }
            Controlar_checks();
           
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFecha.Checked)
            {
                gpID.Visible = false;
                gpFecha.Visible = true;
              
            }
            else
            {
                gpID.Visible = true;
                gpFecha.Visible = false;
               
            }
            Controlar_checks();
        }

        private void Refrescar_Click(object sender, EventArgs e)
        {
            this.RefrescarGrilla();
        }
        private void Controlar_checks()
        {
            if (gpFecha.Visible == true)
                cbFecha.Checked = true;
            else
                cbFecha.Checked = false;

            if (gpID.Visible == true)
                cbID.Checked = true;
            else
                cbID.Checked = false;
        
        }
    }
}
