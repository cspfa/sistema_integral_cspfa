using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.interior
{
    public partial class Vouchers_Social : Form
    {
        SOCIOS.Turismo.VoucherUtils vu = new Turismo.VoucherUtils();
        int ID = 0;
        public Vouchers_Social()
        {
            InitializeComponent();
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {

            this.Refrescar_Grilla();
        }

        private void Refrescar_Grilla()
        {
            dgcDatos.DataSource = vu.getVouchers_Social(dpDesde.Value, dpHasta.Value);
        }

        private bool Valido_Seleccion()
        {
            bool valido = true;
            if (ID == 0)
            {
                valido = false;
                MessageBox.Show("Seleccione un Bono", "Seleccione un Bono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valido;
        }


        private void Anular_Click(object sender, EventArgs e)
        {
            bool Seleccion = Valido_Seleccion();

            if (Seleccion)
            {
                if (MessageBox.Show("Esta Seguro de Anular el voucher?", "Anulacion Bono ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    vu.Baja_Voucher_Bono(ID);
                    MessageBox.Show("Bono Anulado con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Refrescar_Grilla();

                }
            }
        }

        private void dgcDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Int32.Parse(dgcDatos.SelectedRows[0].Cells[0].Value.ToString());
        }
    }
}
