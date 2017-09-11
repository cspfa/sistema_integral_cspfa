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
using Excel = Microsoft.Office.Interop.Excel;


namespace SOCIOS.deportes
{
   
    public partial class VencimientoAptoFisico : Form
    {
        bo dlog = new bo();
        SOCIOS.deportes.CamposService cs = new CamposService();
        string ROL = "";

        public VencimientoAptoFisico()
        {
            InitializeComponent();
          
            tbMes.Text = System.DateTime.Now.Month.ToString();
            tbAnio.Text = System.DateTime.Now.Year.ToString();
            cs.ComboRol(cbRol);

            if (VGlobales.vp_role == "DEPORTES")
            {
                
                cbRol.Visible = true;
                lbRol.Visible = true;
                ROL = cbRol.Text.TrimEnd().TrimStart();

            }
            else
            {
                
                cbRol.Visible = false;
                lbRol.Visible = false;
                ROL = VGlobales.vp_role.TrimEnd().TrimStart();
            }


            Vencimientos.DataSource = this.ObtenerVencimiento();
            Grilla.DataSource = this.ObtenerDatos();

        }

        private void BindData()

        {
            if (VGlobales.vp_role == "DEPORTES")
            {

               
                ROL = cbRol.Text.TrimEnd().TrimStart();

            }
            else
            {

               
                ROL = VGlobales.vp_role.TrimEnd().TrimStart();
            }


            Vencimientos.DataSource = this.ObtenerVencimiento();
            Grilla.DataSource = this.ObtenerDatos();
        
        }

        public List<Vencimiento>  ObtenerDatos()
        {
            List<Vencimiento> Vencimientos = new List<Vencimiento>();
            Vencimiento itemVencimiento    ;
            string Query;

            DateTime hoy = System.DateTime.Now;
            string connectionString;
            DataTable dt1 = new DataTable("RESULTADOS");
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

                    dt1.Columns.Add("Nombre", typeof(string));

                    dt1.Columns.Add("Apellido", typeof(string));
                    dt1.Columns.Add("Email", typeof(string));
                    dt1.Columns.Add("FE_Vencimiento", typeof(string));



                    ds1.Tables.Add(dt1);


                    //Obtengo Vencidos

                    Query = "select Nombre,Apellido,Email,FE_Vencimiento from deportes_adm where  Extract(year from FE_VENCIMIENTO )= " +
                            hoy.AddMonths(-1).Year.ToString() + " and Extract(month from FE_VENCIMIENTO) =  " + hoy.AddMonths(-1).Month.ToString() + " AND ROL='" +ROL + "'";


                   


                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        itemVencimiento = new Vencimiento();

                        itemVencimiento.Nombre   = reader3.GetString(reader3.GetOrdinal("Nombre")).Trim();
                        itemVencimiento.Apellido = reader3.GetString(reader3.GetOrdinal("Apellido")).Trim();
                        itemVencimiento.Email    = reader3.GetString(reader3.GetOrdinal("Email")).Trim();
                        itemVencimiento.Fecha    =   DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FE_Vencimiento")).Trim());
                        itemVencimiento.Resultado = "";
                        itemVencimiento.Tipo = "Segundo Aviso";
                        Vencimientos.Add(itemVencimiento);

                    }



                    //Obtengo Que Vencen Este Mes 
                    Query = "select Nombre,Apellido,Email,FE_Vencimiento from deportes_adm where  Extract(year from FE_VENCIMIENTO )= " +
                            hoy.Year.ToString() + " and Extract(month from FE_VENCIMIENTO) =  " + hoy.Month.ToString()  + "AND ROL='" +  ROL+  "'";



                     cmd = new FbCommand(Query, connection, transaction);

                    reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        itemVencimiento = new Vencimiento();

                        
                        itemVencimiento.Nombre    = reader3.GetString(reader3.GetOrdinal("Nombre")).Trim();
                        itemVencimiento.Apellido  = reader3.GetString(reader3.GetOrdinal("Apellido")).Trim();
                        itemVencimiento.Email     = reader3.GetString(reader3.GetOrdinal("Email")).Trim();
                        itemVencimiento.Fecha     = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FE_Vencimiento")).Trim());
                        itemVencimiento.Tipo      = "Primer Aviso";
                        itemVencimiento.Resultado = "";
                        Vencimientos.Add(itemVencimiento);

                    }


                    reader3.Close();



                    transaction.Commit();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }






           


            return Vencimientos;
        
        
        }



        public List<VencimientoXLS> ObtenerVencimiento()
        {
            List<VencimientoXLS> Vencimientos = new List<VencimientoXLS>();
            VencimientoXLS itemVencimiento;
            string Query;

            DateTime hoy = System.DateTime.Now;
            string connectionString;
            DataTable dt1 = new DataTable("RESULTADOS");
            DataSet ds1 = new DataSet();

            Datos_ini ini3 = new Datos_ini();
            int Mes  = Int32.Parse( tbMes.Text.ToString());
            int Anio = Int32.Parse(tbAnio.Text.ToString());
 

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

                    dt1.Columns.Add("NRO_SOCIO", typeof(string));

                    dt1.Columns.Add("NRO_DEP", typeof(string));
                    dt1.Columns.Add("BARRA", typeof(string));
                    
                    dt1.Columns.Add("Nombre", typeof(string));
                    dt1.Columns.Add("Apellido", typeof(string));
       

                    dt1.Columns.Add("FE_Vencimiento", typeof(string));
                    dt1.Columns.Add("ROL", typeof(string));


                    ds1.Tables.Add(dt1);


                    //Obtengo Vencidos

                    Query = "select NRO_SOCIO, NRO_DEP, BARRA, Nombre,Apellido,FE_VENCIMIENTO,ROL from deportes_adm where  Extract(year from FE_VENCIMIENTO )= " +
                            Anio.ToString() + " and Extract(month from FE_VENCIMIENTO) =  " + Mes.ToString() + " and fe_Baja is  null AND ROL='" +  ROL+  "'";

                    


                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        itemVencimiento = new VencimientoXLS();
                        itemVencimiento.NroSocio       = reader3.GetString(reader3.GetOrdinal("NRO_SOCIO")).Trim();
                        itemVencimiento.NroDepuracion  = reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim();
                        itemVencimiento.BARRA           = reader3.GetString(reader3.GetOrdinal("BARRA")).Trim();
                        itemVencimiento.Nombre          = reader3.GetString(reader3.GetOrdinal("Nombre")).Trim();
                        itemVencimiento.Apellido = reader3.GetString(reader3.GetOrdinal("Apellido")).Trim();
                      
                        itemVencimiento.Fecha = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FE_Vencimiento")).Trim()).ToShortDateString();
                        itemVencimiento.Rol = reader3.GetString(reader3.GetOrdinal("ROL")).Trim();
                    
                        Vencimientos.Add(itemVencimiento);

                    }



                  

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }









            return Vencimientos;


        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.EnvioMails();
        }


        private void EnvioMails()
        {
            

            Cursor.Current = Cursors.WaitCursor;
          
            foreach (DataGridViewRow row in Grilla.Rows)
           
            {

                this.Envio(row);


            }

            Cursor.Current = Cursors.Default;
        
        }

        private void Envio(DataGridViewRow row)
        {
            string Mensaje;
            string Asunto;
            string Nombre;
            string Apellido;
            string Email;
            string Fecha;
            Mailer mailer = new Mailer();


            Asunto = "Aviso Vencimiento Apto Fisico";
            Nombre = row.Cells[2].Value.ToString();
            Apellido = row.Cells[3].Value.ToString();
            Email = row.Cells[4].Value.ToString();
            Fecha = DateTime.Parse( row.Cells[5].Value.ToString()).ToShortDateString();

            Mensaje = " Estimado/a  " + Apellido + "," + Nombre + " Se le comunica que el dia " + Fecha + " Vence su Apto Fisico en el departamento de deportes, por favor acerquese a regularizar su situacion";

            try
            {
                mailer.EnvioMail(Email, Asunto, Mensaje);
                row.Cells[0].Value = "OK";
            }
            catch (Exception ex)
            {
                row.Cells[0].Value = "FALLO";
            } 
        
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fltrar_Click(object sender, EventArgs e)
        {
            if (VGlobales.vp_role == "DEPORTES")
            {


                ROL = cbRol.Text.TrimEnd().TrimStart();

            }
            else
            {


                ROL = VGlobales.vp_role.TrimEnd().TrimStart();
            }


            Vencimientos.DataSource = this.ObtenerVencimiento();
        }

        private void XLS_Click(object sender, EventArgs e)
        {
            string data = null;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add();
            xlWorkSheet = xlWorkBook.Worksheets[1];
            xlWorkSheet.Range["A1:Z1"].Font.Bold = true;
            xlWorkSheet.Cells[1, 1] = "NRO_SOCIO";
            xlWorkSheet.Cells[1, 2] = "NRO_DEP";
            xlWorkSheet.Cells[1, 3] = "BARRA";
            xlWorkSheet.Cells[1, 4] = "NOMBRE";
            xlWorkSheet.Cells[1, 5] = "APELLIDO";
            xlWorkSheet.Cells[1, 6] = "FECHA";
            xlWorkSheet.Cells[1, 7] = "ROL";
      
           // string ruta = "C://CSPFA_SOCIOS//vencimientos.xls";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
    
                saveFileDialog1.Filter = "*.xls| *.csv";
          

            saveFileDialog1.Title = "Guardar Listado";





            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                DialogResult result = MessageBox.Show("LISTADO GENERADO CORRECTAMENTE \n\n", "LISTO!");
                if (VGlobales.vp_role == "DEPORTES")
                {


                    ROL = cbRol.Text.TrimEnd().TrimStart();

                }
                else
                {


                    ROL = VGlobales.vp_role.TrimEnd().TrimStart();
                }


              
                


                int i = 2;


                foreach (VencimientoXLS r in this.ObtenerVencimiento())
                {
                    xlWorkSheet.Cells[i, 1] = r.NroSocio;
                    xlWorkSheet.Columns[1].AutoFit();

                    xlWorkSheet.Cells[i, 2] = r.NroDepuracion;
                    xlWorkSheet.Columns[2].AutoFit();

                    xlWorkSheet.Cells[i, 3] = r.BARRA;
                    xlWorkSheet.Columns[3].AutoFit();

                    xlWorkSheet.Cells[i, 4] = r.Nombre;
                    xlWorkSheet.Columns[4].AutoFit();

                    xlWorkSheet.Cells[i, 5] = r.Apellido;
                    xlWorkSheet.Columns[5].AutoFit();

                    xlWorkSheet.Cells[i, 6] = r.Fecha;
                    xlWorkSheet.Columns[6].AutoFit();

                    xlWorkSheet.Cells[i, 7] = r.Rol;
                    xlWorkSheet.Columns[7].AutoFit();




                    i = i + 1;
                }


                xlWorkSheet.Columns[6].EntireColumn.NumberFormat = "DD/MM/AAAA";

                xlWorkBook.SaveAs(saveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();


                SOCIOS.XLS.releaseObject(xlWorkSheet);
                SOCIOS.XLS.releaseObject(xlWorkBook);
                SOCIOS.XLS.releaseObject(xlApp);
            }
        

                   

        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (VGlobales.vp_role == "DEPORTES")
            {


                ROL = cbRol.Text.TrimEnd().TrimStart();

            }
            else
            {


                ROL = VGlobales.vp_role.TrimEnd().TrimStart();
            }


            Vencimientos.DataSource = this.ObtenerVencimiento();
         
        }

        private void filtrar_Venc_Click(object sender, EventArgs e)
        {
            if (VGlobales.vp_role == "DEPORTES")
            {


                ROL = cbRol.Text.TrimEnd().TrimStart();

            }
            else
            {


                ROL = VGlobales.vp_role.TrimEnd().TrimStart();
            }


            Vencimientos.DataSource = this.ObtenerVencimiento();

        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // VencimientoAptoFisico
        //    // 
        //    this.ClientSize = new System.Drawing.Size(370, 261);
        //    this.Name = "VencimientoAptoFisico";
        //    this.ResumeLayout(false);

        //}



    }
}
