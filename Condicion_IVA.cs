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
    public partial class Condicion_IVA : Form
    {

        BO.bo_Socios dlog = new BO.bo_Socios();
        int ID = 0;
        public Condicion_IVA(int ID_Titular)
        {
            InitializeComponent();
            ID = ID_Titular;
            this.Carga_Combo();

            this.Cargo_Datos();

        }

        private void Cargo_Datos()

        { 
        
            string Query = @"SELECT COND_IVA from TITULAR WHERE ID_TITULAR=" + ID.ToString();

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(Query).Select();

            if (foundRows.Length > 0)
            {
                 lbInfo.Text ="Modificar Condicion IVA ";
              if  (foundRows[0][0].ToString().Length>0)
                cbTipo.SelectedValue = foundRows[0][0].ToString();



            }
            else
            { 
            lbInfo.Text ="Cargar Condicion IVA ";
            

            }

        }

        private void Grabo_Datos()

        {


            dlog.Condicion_IVA(ID, cbTipo.SelectedValue.ToString());


 
        }

        private void Carga_Combo()
        {
            string query = "SELECT ID, DETALLE FROM CONDICIONES_IVA ";





            cbTipo.DataSource = null;
            cbTipo.Items.Clear();
            cbTipo.DataSource = dlog.BO_EjecutoDataTable(query);
            cbTipo.DisplayMember = "DETALLE";
            cbTipo.ValueMember = "ID";
            cbTipo.SelectedItem = 1;
        }

        private void Grabar_Click(object sender, EventArgs e)
        {
            this.Cargo_Datos();
        }
    }
}
