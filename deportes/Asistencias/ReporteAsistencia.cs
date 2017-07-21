using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class ReporteAsistencia : MicroFour.StrataFrame.UI.Windows.Forms.StandardForm
    {
       SOCIOS.bo dlog;
       SOCIOS.deportes.CamposService cs = new CamposService();
       string ROL = "";

        public ReporteAsistencia()
        {
           
            InitializeComponent();
            ROL = VGlobales.vp_role;
            
            cs.ComboRol(cbRol);

            this.ComboActividad();

            
     
        

        }

        //private void ComboActividad()
        //{
        //    string Query = "SELECT ID,DETALLE FROM SECTACT WHERE ROL='DEPORTES' AND DETALLE  NOT LIKE '%CUOTA%' and DETALLE NOT LIKE '%ATENCION AL PUBLICO%' AND DETALLE NOT LIKE '%TOALLAS%'  ORDER BY ID";
        //    bo dlog = new bo();
        //    cbActividad.DataSource = null;
        //    cbActividad.Items.Clear();
        //    cbActividad.DataSource = dlog.BO_EjecutoDataTable(Query);
        //    cbActividad.DisplayMember = "DETALLE";
        //    cbActividad.ValueMember = "ID";
        //    cbActividad.SelectedItem = 1;

      


        //}

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

        private void ReporteAsistencia_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }


        private DataTable Datos(string ID)

        { 
       
            string connectionString;
            DataTable dt1 = new DataTable("RESULTADOS");
            string Query = "select D.ID_ROL Id, D.NOMBRE Nombre,D.APELLIDO Apellido,D.FE_VENCIMIENTO Fecha,IIF(char_length(MD.DNI)>0,'SI','NO') Moroso " +
                         "from deportes_adm D left join MOROSOS_DEPORTES MD on MD.DNI = cast(D.dni as Integer) , socio_actividades A , sectact S " +
                         "where D.ID_ROL =A.ID_DEPORTE and D.ROL=A.ROL  and S.ID =A.SECTACT    and S.ID =" + ID + "  AND D.ROL='" + ROL + "' ORDER BY Apellido";
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

                   

                    dt1.Columns.Add("Id", typeof(string));
                    dt1.Columns.Add("Nombre", typeof(string));
                    dt1.Columns.Add("Apellido", typeof(string));
                    dt1.Columns.Add("Fecha", typeof(string));
                    dt1.Columns.Add("Moroso", typeof(string));

                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("Id")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Nombre")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Apellido")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Fecha")).Trim(),
                                      reader3.GetString(reader3.GetOrdinal("Moroso")).Trim());
                                    
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


        private void Reporte_Click(object sender, EventArgs e)
        {
            string Fecha;
            string Actividad;
            string ID;
            Fecha = dpFecha.Value.Day.ToString() +" - " + dpFecha.Value.Month.ToString() + " - " + dpFecha.Value.Year.ToString();
            Actividad = cbActividad.Text.Trim();
            ID = cbActividad.SelectedValue.ToString();
            DataTable ds = this.Datos(ID);
            try
            {

                bo dlog = new bo();
                //Array que contendrá los parámetros
                ReportParameter[] parameters = new ReportParameter[2];
                //Establecemos el valor de los parámetros
                parameters[0] = new ReportParameter("Actividad", Actividad);
                parameters[1] = new ReportParameter("Fecha", Fecha);




                this.reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", ds));

                this.reportViewer1.RefreshReport();
                reportViewer1.Visible = true;
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ComboActividad();
        }
    }
}