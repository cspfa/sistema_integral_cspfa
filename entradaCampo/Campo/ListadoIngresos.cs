using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Entrada_Campo
{
    public partial class ListadoIngresos : Form
    {
        int ID = 0;
        bo_Entrada_Campo dlog = new bo_Entrada_Campo();
        EntradaCampoService es = new EntradaCampoService();
        bool filtroRol = false;
        public ListadoIngresos()
        {
            InitializeComponent();
         


            if (!VGlobales.vp_role.StartsWith("CPO"))
            {
                gpRol.Visible = true;
               

            }

            else
            {
                gpRol.Visible = false;
               

            }



              gpUsuario.Visible = true;


          



            dpDesde.Value  =    System.DateTime.Now;
            dpHasta.Value  =    System.DateTime.Now;

            this.Filtrar();
           



        }

        private void Filtrar()

        {

            dgvIngresos.DataSource = this.DatosFiltrados();


        }

        List<SOCIOS.EntradaCampo> DatosFiltrados()

        {
            string ROL = cbROL.Text;


            string USER = tbUser.Text;


            int ID_D = 0;
            int ID_H = 0;


            if (ID_DESDE.Text.Length > 0)
                ID_D = Int32.Parse(ID_DESDE.Text);

            if (ID_HASTA.Text.Length > 0)
                ID_H = Int32.Parse(ID_HASTA.Text);
            

            return es.getIngresos(chkFecha.Checked,chkID.Checked, dpDesde.Value, dpHasta.Value, ID_D, ID_H, tbDni.Text, tbNombre.Text, tbApellido.Text, ROL,USER).ToList();
        
        }

        private void dgvIngresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Int32.Parse(dgvIngresos.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dgvIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Int32.Parse(dgvIngresos.SelectedRows[0].Cells[0].Value.ToString());
         
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Esta Seguro de Anular el Ingreso?", "Anulacion Ingreso ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    dlog.Entrada_Campo_Anular(ID);
                    MessageBox.Show("Anulado con Exito");
                    this.Filtrar();
                    // dgvIngresos.DataSource = es.getIngresos(false, true).OrderByDescending(x => x.ID).Take(30).ToList();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void ReintegrarIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Esta Seguro de Reintegrar  el Ingreso? va a generar informacion en el dia que reste en los montos ", "Reintegrar Ingreso ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    es.Reintegrar(ID);
                   
                    MessageBox.Show("Reintegrado con Exito");
                    this.Filtrar();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Filtrar();
        }

        private string FiltroUsuarioTexto()

        {
            string Usuario = "";
            if (tbUser.Text.Length > 1)
                Usuario =  tbUser.Text;
            return Usuario;
        }
        private void btnTotal_Click(object sender, EventArgs e)
        {

            
            
            es.Impresion_Totales(this.DatosFiltrados(),this.FiltroUsuarioTexto());
            es.Impresion_Totales_Reintegro(this.DatosFiltrados());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
           
                List<SOCIOS.EntradaCampo> datos =  this.DatosFiltrados();
                if (datos.Count > 0)
                {
                    SOCIOS.entradaCampo.Reporte.ReporteIngresos repor = new SOCIOS.entradaCampo.Reporte.ReporteIngresos(datos.OrderBy(x => x.FECHA).FirstOrDefault().FECHA, datos.OrderByDescending(x => x.FECHA).FirstOrDefault().FECHA, datos,this.FiltroUsuarioTexto());
                    // ReporteIngresosCampo repor = new ReporteIngresosCampo(datos.OrderBy(x => x.FECHA).FirstOrDefault().FECHA, datos.OrderByDescending(x => x.FECHA).FirstOrDefault().FECHA, datos);
                    repor.ShowDialog();
                }

            
        }

        private void Reimprimir_Click(object sender, EventArgs e)
        {
            
            
            try
            {

                if (ID==0)
                    ID = Int32.Parse(dgvIngresos.SelectedRows[0].Cells[0].Value.ToString());

                es.Imprimir(ID);

                MessageBox.Show("Re-Impreso con Exito");
                    this.Filtrar();
                

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void reintegroParcial_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Esta Seguro de Reintegrar  el Ingreso? va a generar informacion en el dia que reste en los montos ", "Reintegrar Ingreso ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    int NRO_SOC     = int.Parse(dgvIngresos.SelectedRows[0].Cells[7].Value.ToString());
                    int NRO_DEP     = int.Parse(dgvIngresos.SelectedRows[0].Cells[8].Value.ToString());


                    string DNI      = dgvIngresos.SelectedRows[0].Cells[4].Value.ToString();
                    string NOMBRE   = dgvIngresos.SelectedRows[0].Cells[5].Value.ToString();
                    string APELLIDO = dgvIngresos.SelectedRows[0].Cells[6].Value.ToString();
                    string TIPO     = dgvIngresos.SelectedRows[0].Cells[3].Value.ToString();
                   

                    bool Invitado = false;
                    bool Inter = false;

                    if (TIPO.ToUpper().Contains("FAM") || TIPO.ToUpper().Contains("ADH") || TIPO.ToUpper().Contains("TIT") || TIPO.ToUpper().Contains("VITAL") || TIPO.ToUpper().Contains("INT") || TIPO.ToUpper().Contains("ACTIVO") && TIPO.ToUpper().Contains("METRO"))
                        Invitado = false;
                    else
                        Invitado = true;


                    if (TIPO.ToUpper().Contains("INT"))
                        Inter = true;

                   

                    if (es.Monto_Maximo_Reintegrar(DNI,System.DateTime.Now) == 0)
                    {

                        throw new Exception("No existen movimientos a Reintegrar en el dia de la fecha  ");


                    }

                    else
                    {

                        Entrada_Campo.EntradaCampoIngresoTotales ec = new Entrada_Campo.EntradaCampoIngresoTotales(DNI, NOMBRE, APELLIDO, NRO_SOC, NRO_DEP, TIPO, Invitado, Inter, true, 0,false);

                        ec.ShowDialog();
                    }



                    this.Filtrar();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btn_Reintegro_Evento_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime FECHA;

               

                if (MessageBox.Show("Esta Seguro de Reintegrar  el Ingreso? va a generar informacion en el dia que reste en los montos ", "Reintegrar Ingreso ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    int NRO_SOC = int.Parse(dgvIngresos.SelectedRows[0].Cells[7].Value.ToString());
                    int NRO_DEP = int.Parse(dgvIngresos.SelectedRows[0].Cells[8].Value.ToString());
                   

                    string DNI = dgvIngresos.SelectedRows[0].Cells[4].Value.ToString();
                    string NOMBRE = dgvIngresos.SelectedRows[0].Cells[5].Value.ToString();
                    string APELLIDO = dgvIngresos.SelectedRows[0].Cells[6].Value.ToString();
                    string TIPO = dgvIngresos.SelectedRows[0].Cells[3].Value.ToString();
                    try
                    {
                        FECHA = DateTime.Parse(dgvIngresos.SelectedRows[0].Cells[2].Value.ToString());
                    }
                    catch {
                        FECHA = System.DateTime.Now;
                    }
                    if (!es.Existe_Entrada_Tipo(DNI, 4,FECHA))
                        throw new Exception("No Existen entradas de Evento Estacionamiento con el DNI indicado en la fecha ");



                    bool Invitado = false;
                    bool Inter = false;

             


                 


                     decimal MontoReintegro = es.Monto_Maximo_Reintegrar(DNI,FECHA);
                    if ( MontoReintegro == 0)
                    {

                        throw new Exception("No existen movimientos a Reintegrar en el dia de la fecha  ");


                    }

                    else
                    {

                       SOCIOS.entradaCampo.Campo.EntradaEvento ee = new SOCIOS.entradaCampo.Campo.EntradaEvento(DNI, NOMBRE, APELLIDO, NRO_SOC, NRO_DEP, TIPO,"",true,MontoReintegro,false);

                        ee.ShowDialog();
                    }



                    this.Filtrar();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        
    }
}
