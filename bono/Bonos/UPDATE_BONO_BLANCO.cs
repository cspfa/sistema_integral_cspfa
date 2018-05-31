using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.bono.Bonos
{
    public partial class UPDATE_BONO_BLANCO : Form
    {
        int ID;
        int ID_ROL;
        string TIPO;
       // DataGridViewSelectedRowCollection lista_nula= new DataGridViewSelectedRowCollection();
        public UPDATE_BONO_BLANCO(int pID,int pID_ROL,string pTIPO)
        {
            InitializeComponent();
            ID = pID;
            ID_ROL = pID_ROL;
            TIPO = pTIPO;

            lb_ID.Text = ID.ToString();
            lb_ID_ROL.Text = ID_ROL.ToString();
            lb_TIPO.Text = TIPO;
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
         
            try
            {
                if (tbSoc.Text.Length == 0)
                    throw new Exception("Ingresa Nro.Soc.");
                if (tbDep.Text.Length==0)
                    throw new Exception("Ingresa Nro.Dep.");

                if (lb_TIPO.Text=="HOT") 
                {
                    BonoHotel bh = new BonoHotel(tbSoc.Text, tbDep.Text, true);
                    bh.ID = ID;
                    bh.BONO_BLANCO = true;

                    bh.ShowDialog();
                }
                else if (lb_TIPO.Text == "PAS")
                {
                }
                else
                { 
                }




            }   catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

        }
    }
}
