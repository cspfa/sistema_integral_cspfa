using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOCIOS.Turismo; 
namespace SOCIOS.interior
{
    public partial class Disponibilidad_Dias : Form
    {
        Hotel_Dias_Utils hotel_Dias_Utils = new Hotel_Dias_Utils();
        Datos_Dias service_Datos_Dias;
        public Disponibilidad_Dias(int Socio,int Dep,int Anio)
        {
            InitializeComponent();

            lbDias.Text = hotel_Dias_Utils.ConsultarDias(Socio, Dep, Anio);
            service_Datos_Dias = new Datos_Dias(Socio, Dep);
            dgvData.DataSource = service_Datos_Dias.DETALLE;

            lbCirugia.Text = service_Datos_Dias.CIRUGIA.ToString();
            lbEnfermedad.Text = service_Datos_Dias.ENFERMEDAD.ToString();
            lbTramite.Text = service_Datos_Dias.TRAMITE.ToString();




        }
    }
}
