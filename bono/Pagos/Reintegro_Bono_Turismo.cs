using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.bono
{
    public partial class Reintegro_Bono_Turismo : Form
    {   UtilsBono utils = new UtilsBono();
        decimal Saldo;
        decimal Reintegro;
        bo dlog = new bo();
        int BONO;


        public Reintegro_Bono_Turismo(int ID)
        {
            InitializeComponent();
            BONO = ID;
            Saldo =decimal.Round(utils.SaldoBono(ID), 2);

            lbSaldo.Text =Saldo.ToString();

        }

        private void btnReintegro_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                this.Validar_Montos();

                if (MessageBox.Show("Confirma Reintegro?", "Reintegro Bono ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dlog.Reintegro(BONO, Reintegro, tbObs.Text);


                    DialogResult = DialogResult.OK;
                }



            }


            catch (Exception ex)

            {
                DialogResult = DialogResult.Cancel;
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Validar_Montos()

        {

            if (tbReintegro.Text.Length == 0)
                throw new Exception("Ingrese Reintegro");
            Reintegro = decimal.Parse(tbReintegro.Text);

            if (Reintegro > Saldo)
                throw new Exception("Reintegro No Puede Ser Mayor a el Saldo del Bono");

            if (Reintegro ==0)
                throw new Exception("Reintegro No Puede ser cero.");

            if (Reintegro==Saldo)
                throw new Exception("Monto Reintegro es igual al Saldo, Proceda la Anulacion del Bono para Este Caso ");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
