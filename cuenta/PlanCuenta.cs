using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOCIOS;

namespace SOCIOS.CuentaSocio
{
    public partial class PlanCuenta : Form
    {
        PlanCuentaUtils utilsCuenta;
        SOCIOS.bo_Descuentos dlog = new   SOCIOS.bo_Descuentos ();
        int CuotaID;
        decimal Importe;
        string ROL;
        string Nombre;
        string Apellido;
        string DNI;

        int NRO_SOCIO;
        int NRO_DEP;
        int BARRA;

        int NRO_SOCIO_TIT;
        int NRO_DEP_TIT;
        int ID_PLAN;
        
        int MODO = 1;


        public PlanCuenta(string ROL)
        {
            InitializeComponent();
            utilsCuenta = new PlanCuentaUtils();
            this.ComboTipo();
            comboFormasDePago();
            this.Determinar_Modo(ROL);

            
        }

        private void Determinar_Modo(string ROL)

        {
            if (ROL == "SISTEMAS")
            {
                MODO = 2;
               
                gpRol.Visible = true;
            }
            else
            {
                gpRol.Visible = false;
                if (ROL.Contains("TURISMO"))
                {
                    MODO = 2;
                  
                }
                else if (ROL.Contains("SERVICIOS MEDICOS"))
                {
                    MODO = 1;
                    
                }

                this.BindGrillaPLan(MODO);
            
            }
        }

        private void BindGrillaPLan(int Modo)
        {

            dgvPlanes.DataSource = utilsCuenta.GetCuentas(Modo);
            this.FormatoGrilla();
        }


        private void ComboDTO()

        {
            SOCIOS.descuentos.DescuentoUtils utils = new descuentos.DescuentoUtils();


            cbDescuento.DataSource = null;
            cbDescuento.Items.Clear();
            cbDescuento.DataSource = utils.Observaciones(null).ToList();
            cbDescuento.DisplayMember = "OBS";
            cbDescuento.ValueMember = "ID";
            cbDescuento.SelectedItem = 1;
        
        }



        private void ComboTipo()
        {
            List<SOCIOS.admDeportes.ItemCombo> lista = new List<SOCIOS.admDeportes.ItemCombo>();

            lista.Add(new SOCIOS.admDeportes.ItemCombo(1, "ODONTOLOGIA"));
            lista.Add(new SOCIOS.admDeportes.ItemCombo(2, "TURISMO"));
         

            cbTipo.Items.Clear();
            cbTipo.DisplayMember = "Texto";
            cbTipo.ValueMember = "ID";
            cbTipo.DataSource = lista;
            cbTipo.SelectedItem = 1;

        }

        private void BindCuotas(int Plan)
        {
            dgvCuotas.DataSource = null;
            dgvCuotas.DataSource = utilsCuenta.Cuotas(Plan);

            dgvPlanes.Columns[3].Width = 500;
            dgvPlanes.Columns[6].Width = 1000;
             Montos_PLan m = new Montos_PLan();
            int contRow=0;

            foreach (DataGridViewRow row in dgvCuotas.Rows)
            {
                  if (contRow ==0)
                      ID_PLAN = Int32.Parse((row.Cells[0].Value.ToString()));
                contRow++;

                if (row.Cells[4].Value.ToString().Length > 1)
                {

                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
                if (row.Cells[5].Value.ToString().Length > 1)
                {

                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                }


            }

            m = utilsCuenta.getMontos(Plan);

            lbMonto.Text = m.Inicial.ToString();
            lbSaldo.Text = m.Saldo.ToString();

           
             
        }

        private void dgvPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
        }

        void Cargar_Plan()

        {
            ID_PLAN = Convert.ToInt32(dgvPlanes[0, dgvPlanes.CurrentCell.RowIndex].Value.ToString());
         
            this.BindCuotas(ID_PLAN);

            Nombre = dgvPlanes[12, dgvPlanes.CurrentCell.RowIndex].Value.ToString();
            Apellido = dgvPlanes[13, dgvPlanes.CurrentCell.RowIndex].Value.ToString();
            DNI = dgvPlanes[14, dgvPlanes.CurrentCell.RowIndex].Value.ToString();
            NRO_SOCIO = Int32.Parse(dgvPlanes[9, dgvPlanes.CurrentCell.RowIndex].Value.ToString());
            NRO_DEP = Int32.Parse(dgvPlanes[10, dgvPlanes.CurrentCell.RowIndex].Value.ToString());
            BARRA = Int32.Parse(dgvPlanes[15, dgvPlanes.CurrentCell.RowIndex].Value.ToString());

            NRO_SOCIO_TIT = Int32.Parse(dgvPlanes[16, dgvPlanes.CurrentCell.RowIndex].Value.ToString());
            NRO_DEP_TIT = Int32.Parse(dgvPlanes[17, dgvPlanes.CurrentCell.RowIndex].Value.ToString());

            gpPlanCuota.Visible = true;


            //this.FormatoGrilla();
        
        
        }

        private void FormateoCuotas()

        {

            foreach (DataGridViewRow dr in dgvCuotas.Rows)
            {
                if (dr.Cells[6].Value.ToString().Trim() != "0")
                    dr.DefaultCellStyle.BackColor = System.Drawing.Color.Red;



            }
            dgvCuotas.ClearSelection();
        
        }


        private void FormatoGrilla()
        {
           // dgvPlanes.Columns[7].Visible = false;
          //  dgvPlanes.Columns[8].Visible = false;
            dgvPlanes.Columns[9].Visible = false;
            dgvPlanes.Columns[3].Width = 120;
            dgvPlanes.Columns[7].Width = 300;
            dgvPlanes.Columns[6].Width = 120;
            dgvPlanes.Columns[9].Width = 120;
            dgvPlanes.Columns[12].Visible = false;
            dgvPlanes.Columns[13].Visible = false;
            dgvPlanes.Columns[14].Visible = false;
        
        }


        private void dgvCuotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CuotaID = Convert.ToInt32(dgvCuotas.SelectedRows[0].Cells[0].Value.ToString());


            Importe = Convert.ToDecimal(dgvCuotas.SelectedRows[0].Cells[2].Value.ToString());

            ROL = dgvCuotas.SelectedRows[0].Cells[7].Value.ToString();


            if (dgvCuotas.SelectedRows[0].Cells[4].Value.ToString().Length == 0) 
            {
               // Genero_Ingreso.Visible = true;
                butonInfoDescuento.Visible = true;
                btnPago.Visible = true;
            } 
            else
            {
                Genero_Ingreso.Visible = false;
                butonInfoDescuento.Visible = false;
                btnPago.Visible = false;
            }


        }

     

        private void Genero_Ingreso_Click_1(object sender, EventArgs e)
        {
            try
            {

                
                IngresoBono ingreso = new IngresoBono(CuotaID, ROL, true, Importe,NRO_SOCIO_TIT, NRO_DEP_TIT,BARRA,NRO_SOCIO,NRO_DEP, DNI, Nombre, Apellido, 0, 0, "Ingreso Automatico Generado Por Pago de Cuota",0);



                MessageBox.Show("Ingreso generado con exito");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MODO = Int32.Parse(cbTipo.SelectedValue.ToString());
            this.BindGrillaPLan(MODO);
        }

        private void butonInfoDescuento_Click(object sender, EventArgs e)
        {
            gpDescuento.Visible = true;
            gpPago.Visible = false;
            this.ComboDTO();
           

        }

        private void GrabarNovedad_Click(object sender, EventArgs e)
        {

            try
            {
                dlog.Actualizo_DTO(CuotaID, Int32.Parse(cbDescuento.SelectedValue.ToString()), System.DateTime.Now);
                MessageBox.Show("Cuota Actualizada con Exito");
                this.BindCuotas(ID_PLAN);
                gpDescuento.Visible = false;
                gpPago.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvCuotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CuotaID = Convert.ToInt32(dgvCuotas.SelectedRows[0].Cells[0].Value.ToString());


            Importe = Convert.ToDecimal(dgvCuotas.SelectedRows[0].Cells[2].Value.ToString());

            ROL = dgvCuotas.SelectedRows[0].Cells[7].Value.ToString();

            Genero_Ingreso.Visible = true;
            butonInfoDescuento.Visible = true;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Seleccion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cargar_Plan();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            var x =  utilsCuenta.GetCuentas(MODO).ToList();
            if (x != null)
            {
                if (tbNombre.Text.Length > 0)
                    x = x.Where(v=>v.Nombre.Contains(tbNombre.Text)).ToList();
                if (tbApellido.Text.Length > 0)
                    x = x.Where(v => v.Apellido.Contains(tbApellido.Text)).ToList();
                if (tbSocio.Text.Length > 0)
                   x = x.Where(v => v.Nro_Socio.Contains(tbSocio.Text)).ToList();
                if (tbDepuracion.Text.Length > 0)
                    x = x.Where(v => v.Nro_Dep.Contains(tbDepuracion.Text)).ToList();
                if (tbDni.Text.Length > 0)
                    x = x.Where(v => v.Dni.Contains(tbDni.Text)).ToList();

                dgvPlanes.DataSource = x;
                this.FormatoGrilla();

            }
        }

        private void comboFormasDePago()
        {
            string query = "SELECT * FROM FORMAS_DE_PAGO ORDER BY ID ASC;";
            cbFormaDePago.DataSource = null;
            cbFormaDePago.Items.Clear();
            cbFormaDePago.SelectedItem = 0;
            cbFormaDePago.DataSource = dlog.BO_EjecutoDataTable(query);
            cbFormaDePago.DisplayMember = "DETALLE";
            cbFormaDePago.ValueMember = "ID";
        }

        private void chkRecibo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRecibo.Checked)
                chkBono.Checked = false;
            else
                chkBono.Checked = true;
        }

        private void chkBono_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBono.Checked)
                chkRecibo.Checked = false;
            else
                chkRecibo.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                bool EsRecibo;
                if (chkBono.Checked)
                    EsRecibo = false;
                else
                    EsRecibo = true;
                if (tbNroPago.Text.Length == 0)
                    throw new Exception("Ingrese Numero de Recibo/Bono");
                int NroPago = Int32.Parse(tbNroPago.Text);

                int FormaPago = Int32.Parse(cbFormaDePago.SelectedValue.ToString());

                utilsCuenta.MarcarPagaCuota(CuotaID, NroPago, EsRecibo, FormaPago, dpFecha.Value);
                gpPago.Visible = false;
                gpDescuento.Visible = false;
                this.BindCuotas(ID_PLAN);
                gpPlanCuota.Visible = false;
                gpPago.Visible = false;
                MessageBox.Show("Pago Realizado Con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            gpPago.Visible = true;
            tbNroPago.Text = "";
            chkRecibo.Checked = false;
            chkBono.Checked = false;
        }

      
       
    }
}
