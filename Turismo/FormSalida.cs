using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Turismo
{
    public partial class FormSalida : Form
    {   public Salida salida;
        public FormSalida(int ID)
        {
            InitializeComponent();
            this.LlenoControl(ID);

        }


        private void LlenoControl(int ID)
        {
            SOCIOS.Turismo.TurismoUtils utilsTurismo = new TurismoUtils();
            salida= utilsTurismo.GetSalida(ID);
            lbNombre.Text = salida.Nombre;
            lbFecha.Text = salida.Fecha.ToShortDateString();
            lbDesde.Text = salida.Loc_Desde_Nombre;
            lbHasta.Text = salida.Loc_Hasta_Nombre;
            lbOperador.Text = salida.Operador_Nombre;
            lbTraslado.Text = salida.Traslado_Nombre;
            lbHotel.Text = salida.Hotel_Nombre;
            lbRegimen.Text = salida.Regimen_Nombre;
            lbTipo.Text = salida.Tipo_Nombre;
            lbEstadia.Text = salida.Estadia;
            lbSocio.Text = salida.Socio.ToString("0.##");
            lbIntercirculo.Text = salida.InterCirculo.ToString("0.##");
            lbInvitado.Text = salida.Invitado.ToString("0.##");
            lbObs.Text = salida.Observaciones;
            lbMenor.Text = salida.Menor.ToString("0.##"); 
            lbCocheCama.Text = salida.Coche_Cama.ToString("0.##"); 
        
        
        
        }
        private void lbHasta_Click(object sender, EventArgs e)
        {

        }

        private void FormSalida_Load(object sender, EventArgs e)
        {

        }
    }
}
