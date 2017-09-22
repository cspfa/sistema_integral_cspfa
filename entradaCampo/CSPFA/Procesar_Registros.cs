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

namespace SOCIOS.Entrada_Campo
{
    public partial class Procesar_Registros : Form
    {
        List<SOCIOS.EntradaCampo> LISTA = new List<SOCIOS.EntradaCampo>();
        bo_Entrada_Campo dlog = new bo_Entrada_Campo();
        EntradaCampoService entradaCampoService = new EntradaCampoService();
        string ROL = "";
        public Procesar_Registros(string ROLE)
        {
            InitializeComponent();
            this.InicializarCombos();
            ROL = ROLE;
           
        }

        private void InicializarCombos()

        {
            cbROLES.Items.Add("CPOCABA");
        
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

        private void dgvIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Importar_Click(object sender, EventArgs e)
        {
           
          
            dgvIngresos.DataSource = null;
            OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + lbArchivoXLS.Text + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
            con.Open();
            DataSet dset = new DataSet();
            OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT * FROM [Hoja1$] ;", con);
            //dadp.TableMappings.Add("", "LP");
            dadp.Fill(dset);
            DataTable table = dset.Tables[0];
            int CANTIDAD = table.Rows.Count;
            bo dlog = new bo();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                int OUT;
                int LP_INT;

                SOCIOS.EntradaCampo ec = new SOCIOS.EntradaCampo();

                ec.ID = Int32.Parse(table.Rows[i][0].ToString());
                ec.DNI = table.Rows[i][1].ToString();
                ec.NOMBRE = table.Rows[i][2].ToString();
                ec.APELLIDO = table.Rows[i][3].ToString();
                ec.NRO_SOCIO = Int32.Parse(table.Rows[i][4].ToString());
                ec.NRO_DEP = Int32.Parse(table.Rows[i][5].ToString());
                ec.Tipo = table.Rows[i][6].ToString();
                ec.INVITADO = Int32.Parse(table.Rows[i][7].ToString());
                ec.MONTO_INVITADO = Decimal.Parse(table.Rows[i][8].ToString());
                ec.INVITADO_PILETA = Int32.Parse(table.Rows[i][9].ToString());
                ec.MONTO_INVITADO_PILETA = Decimal.Parse(table.Rows[i][10].ToString());
                ec.INVITADO_ESTACIONAMIENTO = Int32.Parse(table.Rows[i][11].ToString());
                ec.MONTO_INVITADO_EST = Decimal.Parse(table.Rows[i][12].ToString());

                ec.SOCIO = Int32.Parse(table.Rows[i][13].ToString());
                ec.MONTO_SOCIO = Decimal.Parse(table.Rows[i][14].ToString());
                ec.SOCIO_PILETA = Int32.Parse(table.Rows[i][15].ToString());
                ec.MONTO_SOCIO_PILETA = Decimal.Parse(table.Rows[i][16].ToString());
                ec.SOCIO_ESTACIONAMIENTO = Int32.Parse(table.Rows[i][17].ToString());
                ec.MONTO_SOCIO_EST = Decimal.Parse(table.Rows[i][18].ToString());
                ec.INTERCIRCULO = Int32.Parse(table.Rows[i][19].ToString());
                ec.MONTO_INTER = Decimal.Parse(table.Rows[i][20].ToString());
                ec.INTERCIRCULO_PILETA = Int32.Parse(table.Rows[i][21].ToString());
                ec.MONTO_INTERCIRCULO_PILETA = Decimal.Parse(table.Rows[i][22].ToString());
                ec.INTERCIRCULO_ESTACIONAMIENTO = Int32.Parse(table.Rows[i][23].ToString());

                ec.MONTO_INTERCIRCULO_EST = Decimal.Parse(table.Rows[i][24].ToString());


                ec.TOTAL = Int32.Parse(table.Rows[i][25].ToString());
                ec.MONTO_TOTAL = Decimal.Parse(table.Rows[i][26].ToString());

                try
                {

                    ec.FECHA = DateTime.Parse(table.Rows[i][27].ToString());
                }
                catch
                {
                    int dia = Int32.Parse(table.Rows[i][27].ToString().Substring(0, 2));
                    int mes = Int32.Parse(table.Rows[i][27].ToString().Substring(3, 2));
                    int year = Int32.Parse(table.Rows[i][27].ToString().Substring(6, 4));
                    ec.FECHA = new DateTime(year, mes, dia);

                }

                ec.ROL = table.Rows[i][28].ToString();
                ec.USER = table.Rows[i][29].ToString();
                ec.ID_INTERNO = Int32.Parse(table.Rows[i][31].ToString());

                if (table.Rows[i][30].ToString().Length > 2)
                    ec.BAJA = DateTime.Parse(table.Rows[i][30].ToString());

                ec.MENOR = Int32.Parse(table.Rows[i][37].ToString());
                ec.DISCAPACITADO = Int32.Parse(table.Rows[i][38].ToString());
                ec.DISCAPACITADO_ACOM = Int32.Parse(table.Rows[i][39].ToString());
                ec.LEGAJO = Int32.Parse(table.Rows[i][41].ToString());
                ec.OBS_CUMPLE = table.Rows[i][42].ToString();


                LISTA.Add(ec);
               
                lbTextoProceso.Text = "Registro " + i.ToString() + "- de " + table.Rows.Count.ToString();



            
            }

            dgvIngresos.DataSource = LISTA.OrderBy(x=>x.ID_INTERNO).ToList();
        }

        private void Grabar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Procesar Registros?", "Confirmacion ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                string ROL = LISTA.FirstOrDefault().ROL;
                int ID_DESDE = LISTA.OrderBy(x => x.ID_INTERNO).FirstOrDefault().ID_INTERNO;
                int ID_HASTA = LISTA.OrderByDescending(x => x.ID_INTERNO).FirstOrDefault().ID_INTERNO;

                List<SOCIOS.EntradaCampo> YaProcesados = entradaCampoService.getIngresosXRol(ROL,ID_DESDE,ID_HASTA).ToList();

                try
                {
                    int i = 0;
                    foreach (SOCIOS.EntradaCampo item in LISTA)
                    {

                        if (YaProcesados.Where(x => x.ID == item.ID_INTERNO).Count() == 0)
                        {

                            dlog.Entrada_Campo_Ins(item.DNI, item.NOMBRE, item.APELLIDO, item.NRO_SOCIO, item.NRO_DEP, item.Tipo, item.INVITADO, item.MONTO_INVITADO, item.INVITADO_PILETA, item.MONTO_INVITADO_PILETA, item.INVITADO_ESTACIONAMIENTO, item.MONTO_INVITADO_EST, item.SOCIO, item.MONTO_SOCIO, item.SOCIO_PILETA, item.MONTO_SOCIO_PILETA, item.SOCIO_ESTACIONAMIENTO, item.MONTO_SOCIO_EST, item.INTERCIRCULO, item.MONTO_INTER, item.INTERCIRCULO_PILETA, item.MONTO_INTERCIRCULO_PILETA, item.INTERCIRCULO_ESTACIONAMIENTO, item.MONTO_INTERCIRCULO_EST, item.TOTAL, item.MONTO_TOTAL, item.FECHA, item.ROL, item.USER, item.MENOR, item.DISCAPACITADO, item.DISCAPACITADO_ACOM,item.EVENTO,item.MONTO_EVENTO, item.ID_INTERNO, "ALTA", item.LEGAJO, item.OBS_CUMPLE, 1,VGlobales.vp_username,VGlobales.vp_role);
                           // int ID = entradaCampoService.Ultimo_ID(item.ROL);


                           // entradaCampoService.Actualizo_Ingreso(item.DNI, item.BAJA, ID);
                        }

                        lbGrabar.Text = "Registro " + i.ToString() + "- de " + (LISTA.Count - 1).ToString();
                        i = i + 1;

                    }

                    MessageBox.Show("Proceso realizado con exito");
                    dgvIngresos.DataSource = null;
                    lbGrabar.Text = "-";
                    gpRed.Visible = false;


                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message);
                }


            }

        }

        private void procesarRed_Click(object sender, EventArgs e)
        {
            gpRed.Visible = true;
            if (ROL.Length > 0)
            {
                cbROLES.Visible = false;
                lbROL.Text = ROL;
            }
            else
            {
                cbROLES.Visible = true;
                lbROL.Text = "ROL";
            
            }
        }

        private void cbID_CheckedChanged(object sender, EventArgs e)
        {
            if (cbID.Checked)
                pnlID.Visible = true;
            else
                pnlID.Visible = false;
        }

        private void regRed_Click(object sender, EventArgs e)
        {
            string ROL_SELECCIONADO = "";

            if (ROL.Length > 0)
               ROL_SELECCIONADO = ROL;
            else
                ROL_SELECCIONADO = cbROLES.Text;

             LISTA= entradaCampoService.InfoExportar(chkFiltro.Checked, cbID.Checked, tbDESDE.Text, tbHASTA.Text,ROL_SELECCIONADO);
         
            dgvIngresos.DataSource = LISTA.OrderBy(x => x.ID_INTERNO).ToList();

        }
    }
}
