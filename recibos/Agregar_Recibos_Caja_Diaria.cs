using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;
namespace SOCIOS
{  
    

    public partial class Agregar_Recibos_Caja_Diaria : Form
    {
        bo dlog = new bo();
        List<int> RECIBOS= new List<int>();

        public Agregar_Recibos_Caja_Diaria(List<int> pRECIBOS)
        {
            InitializeComponent();
             RECIBOS=pRECIBOS;
            tbCantidad.Text = "Se van a actualizar " + pRECIBOS.Count.ToString()+ " Recibos";
 
        }

        private void ComboPrestacion()
        {
            string Query = "select  FECHA, ID_ROL from CAJA_DIARIA order by FECHA desc";


            cbCaja.DataSource = null;
            cbCaja.Items.Clear();
            cbCaja.DataSource = dlog.BO_EjecutoDataTable(Query);
            cbCaja.DisplayMember = "FECHA";
            cbCaja.ValueMember = "ID_ROL";
            cbCaja.SelectedItem = 1;


        }

        private void Procesar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Va a Procesar los Recibos en la Caja Seleccionada?", "Confirmacion ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Asignar();
                MessageBox.Show("RECIBOS ACTUALIZADOS CON EXITO");
                Procesar.Enabled = false;
            }
        }

        private void Asignar()
        {
            string caja = cbCaja.SelectedValue.ToString();

            foreach (int RECIBO in RECIBOS)
            { 
            dlog.BO_EjecutoConsulta("UPDATE RECIBOS_CAJA SET CAJA_DIARIA="+caja + " where ID =" + RECIBO.ToString() );
            
            }
        }
    }
}
