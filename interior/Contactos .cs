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
    public partial class Contactos : Form
    {
        SOCIOS.interior.serviceInterior si = new serviceInterior();
        int ID=0;
        public Contactos()
        {
            InitializeComponent();
            this.BindData(true);
        }

        private void BindData(bool SoloVistos)

        {
            dgContactos.DataSource = si.get_Contactos(SoloVistos);
            this.Formatear_Grilla();
        
        
        }


        private void Formatear_Grilla()
        {
            try
            {
                foreach (DataGridViewRow dr in dgContactos.Rows)
                {
                    if (dr.Cells[4].Value.ToString().Trim().Length > 0)
                        dr.DefaultCellStyle.BackColor = System.Drawing.Color.Red;



                }
            }
            catch
            { 
            }

        }

        private void dgContactos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Int32.Parse(dgContactos.SelectedRows[0].Cells[13].Value.ToString());
        }

        private void Ver_Seleccionados_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                Contacto_Form cf = new Contacto_Form(ID);
                DialogResult dr = cf.ShowDialog();
                
                if (dr == DialogResult.OK)
                {
                    MessageBox.Show("Contacto Procesado con Exito!");
                    this.BindData(true);
                }
            
            }
        }


    }
}
