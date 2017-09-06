using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
namespace SOCIOS.deportes
{
    public partial class admAsistencia : Form
    {
        bo_Deportes dlog = new bo_Deportes();
        string ID;
        bool Update;
        string ROL = "";
        SOCIOS.deportes.CamposService cs = new CamposService();
        public admAsistencia()
        {
            InitializeComponent();
            cs.ComboRol(cbRol);
            ROL = VGlobales.vp_role;

            //if (VGlobales.vp_role == "DEPORTES")
            
            //{
            //    cs.ComboActividad("DEPORTES",cbActividad);
            //    cbRol.Visible = true;
            //    lbRol.Visible = true;

            
            //}
            //else
            //{
            //    cs.ComboActividad(VGlobales.vp_role.TrimEnd().TrimStart(),cbActividad);
            //    cbRol.Visible = false;
            //    lbRol.Visible = false;
            //}

            this.ComboActividad();

            DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(col1);

        }

  

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime Fecha;
           
            Fecha = dpFecha.Value;
           
            ID = cbActividad.SelectedValue.ToString();

            this.Refrescar_Grilla(Fecha, Int32.Parse(ID));
          


        }

        private void Refrescar_Grilla(DateTime Fecha, int ID)

        {   
            


            if (TieneAsistencia(ID.ToString(), Fecha))
            {
                dataGridView1.DataSource = this.GetAsistencia(ID.ToString(), Fecha);
                Update = true;



            }
            else
            {
                dataGridView1.DataSource = this.GetActividad(ID.ToString());
                Update = false;


            }

            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.ActualizoChecks();
        }



        private bool TieneAsistencia(string ID, DateTime fecha)
        {
            string Query = "select P , Id , Nombre,Apellido   from socio_actividades_asistencia"
            + " where SECTACT =" + ID +
            " AND (Extract (DAY from  FECHA))= " + fecha.Day.ToString() +
             " AND (Extract (MONTH from  FECHA))= " + fecha.Month.ToString() +
              " AND (Extract (YEAR from  FECHA))= " + fecha.Year.ToString();

             

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(Query).Select();

            if (foundRows.Length > 0)
            {

                return true;
            }
            else
                return false;
        
        }
        private DataTable GetAsistencia(string ID,DateTime fecha)
        { string connectionString;
            DataTable dt1 = new DataTable("RESULTADOS");

            string Query = "select P , Id , Nombre,Apellido   from socio_actividades_asistencia"
                        + " where SECTACT =" + ID +
                        " AND (Extract (DAY from  FECHA))= " + fecha.Day.ToString() +
                         " AND (Extract (MONTH from  FECHA))= " + fecha.Month.ToString() +
                          " AND (Extract (YEAR from  FECHA))= " + fecha.Year.ToString();


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


                    dt1.Columns.Add("P", typeof(string));
                    dt1.Columns.Add("Id", typeof(string));
                    dt1.Columns.Add("Nombre", typeof(string));
                    dt1.Columns.Add("Apellido", typeof(string));
                  


                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("P")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Id")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Nombre")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Apellido")).Trim());

                    }

                    reader3.Close();



                    transaction.Commit();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dt1;

                   

        }
        private DataTable GetActividad(string ID)
        {

            string connectionString;
            DataTable dt1 = new DataTable("RESULTADOS");
            
            string Query = "select  '' P,D.ID_ROL Id, D.NOMBRE Nombre,D.APELLIDO Apellido,D.DNI DNI " +
                         "from deportes_adm D , socio_actividades A , sectact S " +
                         "where D.ID_ROL =A.ID_DEPORTE  and S.ID =A.SECTACT    and S.ID =" + ID + " AND D.ROL ='" + ROL +"'" ;

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

                    DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();

                    dt1.Columns.Add("P", typeof(string));

                    dt1.Columns.Add("Id", typeof(string));
                    dt1.Columns.Add("Nombre", typeof(string));
                    dt1.Columns.Add("Apellido", typeof(string));
                    dt1.Columns.Add("DNI", typeof(string));


                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("P")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Id")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Nombre")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Apellido")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("DNI")).Trim());

                    }

                    reader3.Close();



                    transaction.Commit();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dt1;


        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.ActualizoChecks();
        }
        private void ActualizoChecks()

        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value.ToString() == "1")
                {
                    //var oCell = row.Cells[0] as DataGridViewCheckBoxCell;
                    //bool bChecked = (null != oCell && null != oCell.Value && true == (bool)oCell.Value);
                    row.Cells[0].Value = true;

                }
            }
        }

        private void GrabarDatos(int ID,int SecAct, int P, string Nombre, string Apellido, DateTime Fecha,string ROL,string DNI)
        {
            if (Update)
            {
                dlog.UpdateAsistencia(ID, SecAct, P, Nombre, Apellido, Fecha,ROL,DNI);
                
            }
            else
            {

                dlog.AltaAsistencia(SecAct, P, Nombre, Apellido, Fecha,ROL,DNI);
                
            }

        }


        private void button4_Click(object sender, EventArgs e)
        {
            DateTime Fecha=dpFecha.Value;
            int SectAct=Int32.Parse(ID);
            string ROL = "";
            if (VGlobales.vp_role == "DEPORTES")
                 ROL = cbRol.SelectedText.TrimEnd().TrimStart();
            else
                ROL = VGlobales.vp_role.TrimEnd().TrimStart();


            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    var oCell = row.Cells[0] as DataGridViewCheckBoxCell;
                    int rID = Int32.Parse(row.Cells[2].Value.ToString());
                    string Nombre = row.Cells[3].Value.ToString();
                    string Apellido = row.Cells[4].Value.ToString();
                    string DNI = row.Cells[5].Value.ToString();
                    bool bChecked=false;

                    if (null != oCell && null != oCell.Value  )
                      bChecked= Convert.ToBoolean( oCell.Value.ToString());

                    if (bChecked == true)
                        this.GrabarDatos(rID, SectAct, 1, Nombre, Apellido, Fecha,ROL,DNI);
                    else
                        this.GrabarDatos(rID, SectAct, 0, Nombre, Apellido, Fecha,ROL,DNI);


                }
                MessageBox.Show("PROCESO REALIZADO CON EXITO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Refrescar_Grilla(Fecha, SectAct);



            }

        







            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

       

        private void selAll_Click(object sender, EventArgs e)
        {
            this.SetearChecksGrid(true);
        }

        private void SetearChecksGrid(bool pTipo)
        {
            int tipo;
            if (pTipo)
                tipo = 1;
            else
                tipo = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                row.Cells[0].Value = tipo;






            }
        
        }

        private void desAll_Click(object sender, EventArgs e)
        {
            this.SetearChecksGrid(false);
        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (VGlobales.vp_role == "DEPORTES")
            //{
            //    cs.ComboActividad("DEPORTES",cbActividad);
            //    ROL = cbRol.Text;
            //}
            //else
            //{
            //    cs.ComboActividad(VGlobales.vp_role.TrimEnd().TrimStart(),cbActividad);
            //    ROL = VGlobales.vp_role;
            //}

            this.ComboActividad();


        }

        private void ComboActividad()
        {
            if (VGlobales.vp_role == "DEPORTES")
            {

                ROL = cbRol.Text.TrimEnd().TrimStart();
                cbRol.Visible = true;
                lbRol.Visible = true;


            }
            else
            {
                ROL = VGlobales.vp_role.TrimEnd().TrimStart();
                cbRol.Visible = false;
                lbRol.Visible = false;
            }

            cs.ComboActividad(ROL, cbActividad);
        }



    }
}
