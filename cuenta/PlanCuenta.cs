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
        bo dlog = new bo();
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

        public PlanCuenta()
        {
            InitializeComponent();
            utilsCuenta = new PlanCuentaUtils();
            this.ComboTipo();
            this.BindGrillaPLan();
            
        }

        private void BindGrillaPLan()
        {
            dgvPlanes.DataSource = utilsCuenta.GetCuentas(Int32.Parse(cbTipo.SelectedValue.ToString()));
            this.FormatoGrilla();
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

        private void  BindCuotas(int Plan)

        {
           dgvCuotas.DataSource =  utilsCuenta.Cuotas(Plan);

           dgvPlanes.Columns[3].Width = 500;
           dgvPlanes.Columns[6].Width = 1000;
        
        }

        private void dgvPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            this.BindCuotas( Convert.ToInt32(dgvPlanes[0, dgvPlanes.CurrentCell.RowIndex].Value.ToString()));

            Nombre     = dgvPlanes[12, dgvPlanes.CurrentCell.RowIndex].Value.ToString();
            Apellido   = dgvPlanes[13, dgvPlanes.CurrentCell.RowIndex].Value.ToString();
            DNI        = dgvPlanes[14, dgvPlanes.CurrentCell.RowIndex].Value.ToString();
            NRO_SOCIO  = Int32.Parse(dgvPlanes[9, dgvPlanes.CurrentCell.RowIndex].Value.ToString());
            NRO_DEP    = Int32.Parse(dgvPlanes[10, dgvPlanes.CurrentCell.RowIndex].Value.ToString());
            BARRA      = Int32.Parse(dgvPlanes[15, dgvPlanes.CurrentCell.RowIndex].Value.ToString());

            NRO_SOCIO_TIT = Int32.Parse(dgvPlanes[16, dgvPlanes.CurrentCell.RowIndex].Value.ToString());
            NRO_DEP_TIT = Int32.Parse(dgvPlanes[17, dgvPlanes.CurrentCell.RowIndex].Value.ToString());
      



            this.FormatoGrilla();
           
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
            Genero_Ingreso.Visible = true;

           
        }

     

        private void Genero_Ingreso_Click_1(object sender, EventArgs e)
        {
            try
            {

             
                //IngresoBono ingreso = new IngresoBono(CuotaID, ROL, true, Importe,NRO_SOCIO_TIT, NRO_DEP_TIT,BARRA,NRO_SOCIO,NRO_DEP, DNI, Nombre, Apellido, 0, 0, "Ingreso Automatico Generado Por Pago de Cuota");



                MessageBox.Show("Ingreso generado con exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BindGrillaPLan();
        }

      
       
    }
}
