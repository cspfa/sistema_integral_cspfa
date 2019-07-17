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
        int ID_PLAN_GRAL;
        
        int MODO = 1;
        List<PLanDeCuenta> planes = new List<PLanDeCuenta>();


        public PlanCuenta(string ROL,string NRO_SOC,string NRO_DEP)
        {
            InitializeComponent();
            utilsCuenta = new PlanCuentaUtils();
            this.ComboTipo();
            comboFormasDePago();
            this.Determinar_Modo(ROL);
            tbSocio_Tit.Text = NRO_SOC;
            tbDepuracion_Tit.Text = NRO_DEP;

            this.Filtrar();



            
        }

        private void Determinar_Modo(string ROL)

        {
            if (ROL == "SISTEMAS" || ROL=="DESCUENTOS" )
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
            planes = utilsCuenta.GetCuentas(Modo).ToList();
            dgvPlanes.DataSource = planes;
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

            lista.Add(new SOCIOS.admDeportes.ItemCombo(1, "SERVICIOS MEDICOS"));
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

            dgvCuotas.ClearSelection();
            dgvCuotas.Rows[0].Selected = false;

            this.GetDataPlan(Plan);
             
        }

        private void dgvPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
        }

        void Cargar_Plan()

        {

            dgvCuotas.ClearSelection();
            ID_PLAN = Convert.ToInt32(dgvPlanes[0, dgvPlanes.CurrentCell.RowIndex].Value.ToString());
            ID_PLAN_GRAL = Convert.ToInt32(dgvPlanes[0, dgvPlanes.CurrentCell.RowIndex].Value.ToString());
            LBCUOTA.Text = "";
            this.BindCuotas(ID_PLAN);


            

        

            gpPlanCuota.Visible = true;


            foreach (DataGridViewRow row in dgvCuotas.Rows)
            {
                row.Selected = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Selected = false;
                }
            }

            //this.FormatoGrilla();
        
        
        }

        private void GetDataPlan(int ID_PLAN)

        {
            this.Filtrar();
            //this.BindGrillaPLan(MODO);

             var item =planes.Where(x => x.Plan == ID_PLAN.ToString()).FirstOrDefault();


             Nombre       = item.Nombre;
             Apellido     = item.Apellido;
             DNI          = item.Dni;

             NRO_SOCIO    =    Int32.Parse( item.Nro_Socio);
             NRO_DEP       =   Int32.Parse( item.Nro_Dep);
             BARRA         =   Int32.Parse(item.Barra);

            NRO_SOCIO_TIT = Int32.Parse(item.Nro_Socio_Tit);
            NRO_DEP_TIT = Int32.Parse(item.Nro_Dep_Tit);
            lbNombreCompleto.Text = item.Referente;
        
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
            LBCUOTA.Text = "ID CUOTA:" + CuotaID.ToString();

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
            LBCUOTA.Text = CuotaID.ToString();
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
            Filtrar();
            
        }


        public void Filtrar()

        {

            var x = utilsCuenta.GetCuentas(MODO).ToList();
            if (x != null)
            {
                if (tbNombre.Text.Length > 0)
                    x = x.Where(v => v.Referente.Contains(tbNombre.Text)).ToList();
                if (tbApellido.Text.Length > 0)
                    x = x.Where(v => v.Referente.Contains(tbApellido.Text)).ToList();
                if (tbSocio.Text.Length > 0)
                    x = x.Where(v => v.Nro_Socio.Contains(tbSocio.Text)).ToList();
                if (tbDepuracion.Text.Length > 0)
                    x = x.Where(v => v.Nro_Dep.Contains(tbDepuracion.Text)).ToList();
                if (tbDni.Text.Length > 0)
                    x = x.Where(v => v.Referente_DNI.Contains(tbDni.Text)).ToList();
                if (tbBono.Text.Length > 0)
                    x = x.Where(v => v.Bono == tbBono.Text.TrimEnd().TrimStart()).ToList();

                if (tbPLanCuenta.Text.Length > 0)
                    x = x.Where(v => v.Plan == tbPLanCuenta.Text.TrimEnd().TrimStart()).ToList();

                if (tbCuenta.Text.Length > 0)
                {
                    x = x.Where(p => p.Cuenta == Int32.Parse(tbCuenta.Text.Trim())).ToList();
                }

                if (tbSocio_Tit.Text.Length > 0)
                    x = x.Where(v => v.Nro_Socio_Tit.Contains(tbSocio_Tit.Text)).ToList();

                if (tbDepuracion_Tit.Text.Length > 0)
                    x = x.Where(v => v.Nro_Dep_Tit.Contains(tbDepuracion_Tit.Text)).ToList();

        



                dgvPlanes.DataSource = x;
                planes = x;
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
               if  (!(utilsCuenta.Validar_Pagos_Anteriores(CuotaID, ID_PLAN)))
                   throw new Exception("No puede pagar la cuota seleccionada con cuotas anteriores no pagas");

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
                this.BindCuotas(ID_PLAN_GRAL);
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

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (cbTipo.Text.Contains("TURISMO"))
               MODO=2;
           else
               MODO=1;
        }

      
       
    }
}
