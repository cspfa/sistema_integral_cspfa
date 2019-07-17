using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SOCIOS.cuentaSocio
{
    public partial class Reporte_Plan_Cuenta : Form
    {

        SOCIOS.CuentaSocio.PlanCuentaUtils pcu = new CuentaSocio.PlanCuentaUtils();
        int NRO_SOC = 0;
        int NRO_DEP = 0;

        public Reporte_Plan_Cuenta()
        {
            InitializeComponent();
            dgPLanes.DataSource =  pcu.getPlanes("","","","","",false);
           

        }

        private bool Validar_Seleccion()

        {   bool valido = true;
            if (NRO_SOC == 0 || NRO_DEP==0)
            {
                valido = false;
                MessageBox.Show("Seleccione un SOCIO", "Seleccione un REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valido;
        }

        private void dgPLanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             NRO_SOC  = Int32.Parse(dgPLanes.SelectedRows[0].Cells[3].Value.ToString());
             NRO_DEP = Int32.Parse(dgPLanes.SelectedRows[0].Cells[4].Value.ToString());
        }

        private void Ver_DETALLE_Planes_Click(object sender, EventArgs e)
        {
            bool Valido = Validar_Seleccion();

            if (Valido)
            {
                SOCIOS.CuentaSocio.PlanCuenta pc = new CuentaSocio.PlanCuenta(VGlobales.vp_role.ToString(), NRO_SOC.ToString(), NRO_DEP.ToString());
                pc.ShowDialog();
                
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string DNI      = "";
            string NOMBRE   = "";
            string APELLIDO = "";
            string NRO_SOC = "";
            string NRO_DEP = "";

            if (tbDNI.Text.Length > 0)
                DNI = tbDNI.Text;
            if (tbNombre.Text.Length > 0)
                NOMBRE = tbNombre.Text.TrimStart().TrimEnd();
            if (tbApellido.Text.Length >0)
                APELLIDO = tbApellido.Text.TrimStart().TrimEnd();
            if (tbSocio_Tit.Text.Length > 0)
                NRO_SOC = tbSocio_Tit.Text;
            if (tbDepuracion_Tit.Text.Length > 0)
                NRO_DEP = tbDepuracion_Tit.Text;

            
            dgPLanes.DataSource = pcu.getPlanes(NRO_SOC,NRO_DEP, DNI,NOMBRE,APELLIDO,cbSinCeros.Checked );
        }
    }
}
