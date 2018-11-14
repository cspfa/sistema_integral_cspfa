using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOCIOS;

namespace SOCIOS.Res_Disp
{
    

    public partial class Form_Registro : Form
    {
        SOCIOS.Res_Disp.Servicios service_RD = new Servicios();
        SOCIOS.BO.BO_RES_DISP dlog = new BO.BO_RES_DISP();

        bool Modo_Insert = false;
        int  Anio   = 0;
        int  Numero = 0;
        string Descripcion = "";
        int Tipo = 0;
        int ID = 0;
        public Form_Registro(int pID)
        {
            InitializeComponent();
            ID = pID;
            service_RD.Setear_Combo_Tipo(comboTipo,false);
            if (ID == 0)
                Modo_Insert = true;


        }

        private void Obtener_datos_Controles()

        {
            Numero      =  Int32.Parse(tbNumero.Text);
            Descripcion = tbDes.Text;
            Anio        = Int32.Parse(tbAnio.Text);
            Tipo        = service_RD.Obtener_Valor_Tipo(comboTipo);

        
        }

        private void Grabar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Obtener_datos_Controles();

                if (Modo_Insert)
                {
                    dlog.Resolucion_Dispocision_Insert(Anio, Numero, "", Descripcion, Tipo);
                   
                }
                else
                    dlog.Resolucion_Dispocision_Update(ID, Anio, Numero, "", Descripcion, Tipo);

            }
            catch (Exception ex)
            { 

            }
        }
    }
}
