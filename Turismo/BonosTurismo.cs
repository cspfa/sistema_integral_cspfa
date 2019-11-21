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
    public partial class BonosTurismo : Form
    {
        int ID = 0;
        int ID_BASE;
        string TIPO = "";
        bo dlog = new bo();

        public BonosTurismo()
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
            cbFiltro.Items.Insert(1, "PASAJE");
            cbFiltro.Items.Insert(2, "PAQUETE");
            cbFiltro.Items.Insert(3, "HOTEL");
            cbFiltro.Items.Insert(4, "HOTEL - SOCIAL");
            cbFiltro.SelectedValue = 0;
            cbFiltro.Refresh();

            cbEstado.Items.Insert(0, "TODOS");
            cbEstado.Items.Insert(1, "IMPRESOS");
            cbEstado.Items.Insert(2, "ANULADOS");
       
            cbEstado.SelectedValue = 0;
            cbEstado.Refresh();

        }

        private void RefrescarGrilla()
        {
            string Desde = this.fechaUSA(DateTime.Parse(dpDesde.Text));
            string Hasta = this.fechaUSA(DateTime.Parse(dpHasta.Text));
            string query ="";

            if (!chkBlanco.Checked)
            {
                query = @"select B.ID_ROL ID_ROL,B.CODINT CODINT , B.TIPO TIPO, B.ROL ROL, B.FE_BONO FECHA,B.Nro_socio NRO_SOCIO, B.NRO_DEP NRO_DEP,B.NOMBRE NOMBRE,B.APELLIDO,B.SALDO SALDO,P.RAZON_SOCIAL OPERADOR,coalesce(B.FE_BAJA,'0') BAJA, B.BONO_BLANCO BONO_BLANCO, B.ID ID   from Bono_Turismo B left join Proveedores P
            on    B.Operador = P.ID WHERE 1=1 ";
            }
            else
            {
                query = @"select B.ID_ROL ID_ROL,B.CODINT CODINT , B.TIPO TIPO,B.ROL ROL, B.FE_BONO FECHA,B.Nro_socio NRO_SOCIO, B.NRO_DEP NRO_DEP,B.NOMBRE NOMBRE,B.APELLIDO,B.SALDO SALDO,'S/C' OPERADOR,coalesce(B.FE_BAJA,'0') BAJA, B.BONO_BLANCO BONO_BLANCO, B.ID ID    from Bono_Turismo B WHERE BONO_BLANCO='SI'  ";
        
            
            }
            query = query + " AND B.ROL='" + VGlobales.vp_role + "'";

            query = query + " AND    B.FE_BONO Between  '" + Desde + "' AND '" + Hasta + "'";
           
            if (cbEstado.Text.Contains("IMPRESOS"))
                query = query + " AND coalesce(B.FE_BAJA,'1') ='1' ";
            else if (cbEstado.Text.Contains("ANULADOS"))
                query = query + " AND coalesce(B.FE_BAJA,'1') <> '1' ";

            if (cbFiltro.Text.Contains("PASAJE"))
                query = query + " AND B.TIPO='PAS' ";
            else if (cbFiltro.Text.Contains("PAQUETE"))
                query = query + " AND B.TIPO='PAQ' ";
            else if (cbFiltro.Text.Contains("HOTEL"))
                query = query + " AND B.TIPO='HOT' ";
            else if (cbFiltro.Text.Contains("HOTEL - SOCIAL"))
                query = query + " AND B.TIPO='SOC' ";
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

                    dt1.Columns.Add("ID_ROL", typeof(string));
                    dt1.Columns.Add("CODINT", typeof(string));
                    dt1.Columns.Add("TIPO", typeof(string));
                    dt1.Columns.Add("ROL", typeof(string));
                    dt1.Columns.Add("FECHA", typeof(string));
                    dt1.Columns.Add("NRO_SOCIO", typeof(string));
                    dt1.Columns.Add("NRO_DEP", typeof(string));
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("APELLIDO", typeof(string));
                    dt1.Columns.Add("SALDO", typeof(string));
                    dt1.Columns.Add("OPERADOR", typeof(string));
                    dt1.Columns.Add("BAJA", typeof(string));
                    dt1.Columns.Add("BONO_BLANCO", typeof(string));
                   
                    dt1.Columns.Add("ID", typeof(string));
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID_ROL")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("CODINT")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TIPO")).Trim(),
                                      reader3.GetString(reader3.GetOrdinal("ROL")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("FECHA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("APELLIDO")).Trim(),
                 
                                     reader3.GetString(reader3.GetOrdinal("SALDO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("OPERADOR")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("BAJA")).Trim(),
                                      reader3.GetString(reader3.GetOrdinal("BONO_BLANCO")).Trim(),
                                   
                                      reader3.GetString(reader3.GetOrdinal("ID")).Trim());
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
              
                  dgBonos.Columns[6].Visible      = false; 
               
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
                if (dr.Cells[9].Value.ToString().Trim() != "0")
                    dr.DefaultCellStyle.BackColor = System.Drawing.Color.Red;



            }
            dgBonos.ClearSelection();
        
        }
        private void Imprimir_Click(object sender, EventArgs e)
        {
           
            
            SOCIOS.bono.Turismo rb = new SOCIOS.bono.Turismo(ID);
        }

        private void dgBonos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Int32.Parse(dgBonos.SelectedRows[0].Cells[11].Value.ToString());
        }

        private void Anular_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Esta Seguro de Anular/Reintegrar el Bono?", "Anulacion Bono ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    SOCIOS.bono.Pagos.Anulacion_Bono_Turismo ab = new Pagos.Anulacion_Bono_Turismo(ID);

                    ab.StartPosition = FormStartPosition.CenterScreen;
                    DialogResult res = ab.ShowDialog();

                    if (res == DialogResult.OK)
                    {
                        MessageBox.Show("Accion Realizada con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.RefrescarGrilla();

                    }else
                        MessageBox.Show("No se Puede Realizar La Accion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Valido_Seleccion()

        { if (ID==0)
            MessageBox.Show("Seleccione un Bono", "Seleccione un Bono", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ID = Int32.Parse(dgBonos.SelectedRows[0].Cells[0].Value.ToString());
          
            if (dgBonos.SelectedRows[0].Cells[10].Value.ToString() == "SI")
            {
                btn_CARGAR_BONO_BLANCO.Visible = true;
                ID_BASE = Int32.Parse(dgBonos.SelectedRows[0].Cells[11].Value.ToString());
                TIPO = dgBonos.SelectedRows[0].Cells[2].Value.ToString();

            }
            else
                btn_CARGAR_BONO_BLANCO.Visible = false;
        }

        private void btn_CARGAR_BONO_BLANCO_Click(object sender, EventArgs e)
        {
            SOCIOS.bono.Bonos.UPDATE_BONO_BLANCO upb = new Bonos.UPDATE_BONO_BLANCO(ID_BASE, ID, TIPO);
            upb.ShowDialog();
        }
    }
}
