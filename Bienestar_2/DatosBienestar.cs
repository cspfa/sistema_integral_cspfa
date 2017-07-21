using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;


namespace SOCIOS.Bienestar
{
    public partial class DatosBienestar : Form
    {
        BO.bo_Bienestar dlogBienestar = new BO.bo_Bienestar();
        BienestarService bs = new BienestarService();

        public DatosBienestar()
        {
            InitializeComponent();
            DataBienestar.DataSource = bs.getRegistro("");
        }

        private void btnAbrirXLS_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.xls";
            ofd.ShowDialog();
            string archivo = ofd.FileName;

            if (archivo != "*.xls")
            {
                lbArchivoXLS.Text = archivo;
            }
        }

        private void Importar_Click(object sender, EventArgs e)
        {

            List<SOCIOS.Bienestar.RegistroBienestar> lista = new List<RegistroBienestar>();
 
            OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + lbArchivoXLS.Text + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
            con.Open();
            DataSet dset = new DataSet();
            OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT * FROM [AFILIADOS_straser$] ;", con);
            //dadp.TableMappings.Add("", "LP");
            dadp.Fill(dset);
            DataTable table = dset.Tables[0];
            int CANTIDAD = table.Rows.Count;
            bo dlog = new bo();
            progressBar.Maximum= CANTIDAD;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int OUT;
                int LP_INT;






                SOCIOS.Bienestar.RegistroBienestar re = new Bienestar.RegistroBienestar();


                re.NroAfiliado = table.Rows[i][0].ToString();
                re.DNI = table.Rows[i][1].ToString();
                re.Telefono = table.Rows[i][2].ToString();
                re.Celular = table.Rows[i][3].ToString();
                re.Domiclio = table.Rows[i][4].ToString();
                re.Ciudad = table.Rows[i][5].ToString();
                re.Partido = table.Rows[i][6].ToString();
                re.Provincia = table.Rows[i][7].ToString();
                re.CP = table.Rows[i][8].ToString();
                re.Departamento = table.Rows[i][9].ToString();
                re.Piso = table.Rows[i][10].ToString();
                re.Torre = table.Rows[i][11].ToString();
                re.Parcela = table.Rows[i][12].ToString();
                re.Email = table.Rows[i][13].ToString();
              
                if (re.NroAfiliado.Length > 0)
                {
                    if (bs.getRegistro(re.DNI).Count > 0)
                        dlogBienestar.Bienestar_Delete(re.DNI);

                    if (re.DNI == "12276412")
                    {

                    }

                    dlogBienestar.Bienestar_Ins(re.DNI, re.NroAfiliado, re.Telefono, re.Celular, re.Domiclio, re.Ciudad, re.Partido, re.Provincia, re.CP, re.Piso, re.Departamento, re.Torre, re.Parcela, re.Email);
                }
                progressBar.Value = i;
                lbTextoProceso.Text = "PROCESANDO REGISTRO " + i.ToString() + " de " + table.Rows.Count.ToString();


               //  lista.Add(re);

                Application.DoEvents();
              
            }
            
            MessageBox.Show("Proceso realizado con exito");
            lbTextoProceso.Text = "LISTO, ARCHIVO PROCESADO";

            DataBienestar.DataSource = bs.getRegistro("");






         
        }

        }
}


