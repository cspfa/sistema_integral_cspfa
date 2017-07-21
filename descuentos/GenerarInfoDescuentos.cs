using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.descuentos
{
    public partial class GenerarInfoDescuentos : Form
    {
        DescuentoUtils descuentoUtils = new DescuentoUtils();
        bo_Descuentos dLog = new bo_Descuentos();

        public GenerarInfoDescuentos()
        {
            InitializeComponent();
        }

        private void VER_Click(object sender, EventArgs e)
        {
             dgDescuentos.DataSource = null;
            
                dgDescuentos.DataSource = obtenerRegistros();
           

            GENERAR.Visible = true;
        }


        private List<Registro_Actividad> obtenerRegistros()


        {
            if (rbActivos.Checked)
               return descuentoUtils.DescuentosXmes((int)TIPO_ACTIVIDAD.ACTIVO);
            else
                return  descuentoUtils.DescuentosXmes((int)TIPO_ACTIVIDAD.PASIVO);
        }

        private void GENERAR_Click(object sender, EventArgs e)
        {


            foreach (Registro_Actividad r in this.obtenerRegistros())

            { 
            
               // dLog.FICENV_I(r.Mes,r.Anio,r.CRJP1,r.pc
            
            
            
            }

        }
    }
}
