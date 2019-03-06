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

namespace SOCIOS.bono
{
    public partial class BonosOdontologia : Form
    {
        int ID = 0;
        bo dlog = new bo();
        public BonosOdontologia()
        {
            InitializeComponent();
            dgBonos.ClearSelection();
            this.IniciarFiltros();
           
        }

        private void IniciarFiltros()


        {   
            dpDesde.Text = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 1).ToShortDateString();
            dpHasta.Text = new DateTime(System.DateTime.Now.AddMonths(1).Year, System.DateTime.Now.AddMonths(1).Month,1).ToShortDateString();
            cbFiltro.Items.Insert(0, "TODOS");
            cbFiltro.Items.Insert(1, "ACTIVOS");
            cbFiltro.Items.Insert(2, "ANULADOS");
            cbFiltro.SelectedValue = 0;
            cbFiltro.Refresh();
            
        }

        private void RefrescarGrilla()
        {
            string Desde = this.fechaUSA(DateTime.Parse(dpDesde.Text));
            string Hasta = this.fechaUSA(DateTime.Parse(dpHasta.Text));

            string query = @"select B.ID_ROL ID,B.FE_BONO FECHA,B.NOMBRE NOMBRE,B.APELLIDO, S.DETALLE TRATAMIENTO,B.PROF PROFESIONAL,B.SALDO SALDO,coalesce(B.FE_BAJA,'1') BAJA, B.ID SEC   from turnos_medicos  TM, Bono_Odontologico B ,SECTACT S
            where    B.turno = TM.ID AND TM.ESPECIALIDAD=S.ID 
            AND    B.FE_BONO Between  '" + Desde + "' AND '" + Hasta + "'";
           
            if (cbFiltro.Text.Contains("ACTIVOS"))
                query = query + " AND coalesce(B.FE_BAJA,'1') <> '1' ";
            else if (cbFiltro.Text.Contains("ANULADOS"))
                query = query + " AND coalesce(B.FE_BAJA,'1') = '1' "; 
            
            
           query = query +  " order by B.ID descending";



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
                    dt1.Columns.Add("FECHA", typeof(string));
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("APELLIDO", typeof(string));
                    dt1.Columns.Add("TRATAMIENTO", typeof(string));
                    dt1.Columns.Add("PROFESIONAL", typeof(string));
                    dt1.Columns.Add("SALDO", typeof(string));
                    dt1.Columns.Add("BAJA", typeof(string));
                    dt1.Columns.Add("SEC", typeof(string));
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("FECHA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("APELLIDO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TRATAMIENTO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("PROFESIONAL")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("SALDO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("BAJA")).Trim(),
                                      reader3.GetString(reader3.GetOrdinal("SEC")).Trim()
                                     );
                    }

                    reader3.Close();

                  dgBonos.DataSource = dt1;
                  dgBonos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                  dgBonos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                  dgBonos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                  dgBonos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                  dgBonos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                  dgBonos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                  dgBonos.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                  dgBonos.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                  dgBonos.Columns[7].Visible      = false; 
               
                    transaction.Commit();
                }



                this.Formatear_Grilla();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        
        }


        private void Formatear_Grilla()

        {
            foreach (DataGridViewRow dr in dgBonos.Rows)
            {
                if (dr.Cells[7].Value.ToString().Trim() == "1")
                    dr.DefaultCellStyle.BackColor = System.Drawing.Color.Red;



            }
        
        }
        private void Imprimir_Click(object sender, EventArgs e)
        {
           bool retorno=  Valido_Seleccion();
           if (retorno)
           {
               SOCIOS.bono.Odontologico odonto = new bono.Odontologico(ID, true);
           }
        }

        private void dgBonos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void Anular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro de Anular el Bono?", "Anulacion Bono ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool retorno=  Valido_Seleccion();
                if (retorno)
                {

                    dlog.BajaOdontologico(ID, VGlobales.vp_username, System.DateTime.Now);
                    MessageBox.Show("Bono Anulado con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.RefrescarGrilla();
                }
            }
        }

        private bool Valido_Seleccion()
        {
            bool valido = true;
            if (ID == 0)
            {
                valido = false;
                MessageBox.Show("Seleccione un Bono", "Seleccione un Bono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valido;
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            this.RefrescarGrilla();
        }


        private string fechaUSA(DateTime fecha)

        {
            string Fecha = fecha.Month.ToString("00") + "/" + fecha.Day.ToString("00") + "/" + fecha.Year.ToString("0000");
           
            return Fecha;
        
        
        }

        private void dgBonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Int32.Parse(dgBonos.SelectedRows[0].Cells[8].Value.ToString());
        }
    }
}
