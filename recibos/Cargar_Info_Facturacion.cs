using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class Cargar_Info_Facturacion : Form
    {
        int ID;
        BO.BO_Afip dlog = new BO.BO_Afip();
    
        public Cargar_Info_Facturacion(int pID_RECIBO)
        {
            InitializeComponent();
            ID = pID_RECIBO;
            this.Info_NOTA(pID_RECIBO);
            this.Cargo_COMBO();
        }



        public void Info_NOTA(int ID)
        {
            string QUERY = "select NUMERO_E,CAE,CAE_VENC from RECIBOS_CAJA WHERE ID=" + ID;
            DataRow[] foundRows;


            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


            if (foundRows.Length > 0)
            {

                if (foundRows[0][0].ToString().Length > 0)
                {
                    lbAerta.Visible = true;
                    lbInfo.Visible = true;

                    lbInfo.Text = "Ya Existe FE cargada " + foundRows[0][0].ToString().TrimEnd().TrimStart() + " CON CAE " + foundRows[0][1].ToString().TrimEnd().TrimStart();
                }
                else
                {

                    lbAerta.Visible = false;
                    lbInfo.Visible  = false;
                
                }

            }
        

        }


        private void Cargo_COMBO()
        {

            string query = "select PTO_VTA ID from puntos_de_Venta  order  by PTO_VTA ";


            ComboPtoVenta.DataSource = null;
            ComboPtoVenta.Items.Clear();
            ComboPtoVenta.DataSource = dlog.BO_EjecutoDataTable(query);
            ComboPtoVenta.DisplayMember = "ID";
            ComboPtoVenta.ValueMember = "ID";
            ComboPtoVenta.SelectedItem = 1;
        }

        private void btnGrabarInfo_Click(object sender, EventArgs e)
        {
            try
            {
                int punto_venta = 0;

                if (cbElectronico.Checked)
                    punto_venta = Int32.Parse( ComboPtoVenta.SelectedValue.ToString());
                else
                    punto_venta = Int32.Parse(tbPuntoVenta.Text);

                dlog.Marca_Afip_Recibo(ID,punto_venta, Int32.Parse(lbNumero.Text), lbCAE.Text, lbVencimiento.Text,1);
                MessageBox.Show("Informacion Grabada con Exito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void cbElectronico_CheckedChanged(object sender, EventArgs e)
        {
            ComboPtoVenta.Visible = cbElectronico.Checked;
            tbPuntoVenta.Visible = !cbElectronico.Checked;
               
        }
    }
}

