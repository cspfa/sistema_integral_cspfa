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
    public partial class cargaEncuesta : Form
    {
        bo dlog = new bo();

        private string VNOMBRE; public string _VNOMBRE { get { return VNOMBRE; } set { VNOMBRE = value; } }
        private int VDNI; public int _VDNI { get { return VDNI; } set { VDNI = value; } }
        private int VNRO_SOC; public int _VNRO_SOC { get { return VNRO_SOC; } set { VNRO_SOC = value; } }
        private int VNRO_DEP; public int _VNRO_DEP { get { return VNRO_DEP; } set { VNRO_DEP = value; } }
        private int VNRO_SOC_ADH; public int _VNRO_SOC_ADH { get { return VNRO_SOC_ADH; } set { VNRO_SOC_ADH = value; } }
        private int VNRO_DEP_ADH; public int _VNRO_DEP_ADH { get { return VNRO_DEP_ADH; } set { VNRO_DEP_ADH = value; } }
        private int VBARRA; public int _VBARRA { get { return VBARRA; } set { VBARRA = value; } }

        public cargaEncuesta(string NOMBRE, int DNI, int NRO_SOC, int NRO_DEP, int NRO_SOC_ADH, int NRO_DEP_ADH, int BARRA)
        {
            InitializeComponent();
            lbNombre.Text = "NOMBRE: " + NOMBRE;
            lbDNI.Text = "DNI: " + DNI.ToString();
            lbNroSoc.Text = "#SOC: " + NRO_SOC.ToString();
            lbNroDep.Text = "#DEP: " + NRO_DEP.ToString();
            lbNroSocAdh.Text = "#SOC ADH: " + NRO_SOC_ADH.ToString();
            lbNroDepAdh.Text = "#DEP ADH: " + NRO_DEP_ADH.ToString();
            lbBarra.Text = "BARRA: " + BARRA.ToString();

            VNOMBRE = NOMBRE;
            VDNI = DNI;
            VNRO_SOC = NRO_SOC;
            VNRO_DEP = NRO_DEP;
            VNRO_SOC_ADH = NRO_SOC_ADH;
            VNRO_DEP_ADH = NRO_DEP_ADH;
            VBARRA = BARRA;

            cargarCombos();
        }

        public void cargarCombos()
        {
            cbAlojamiento.Items.Add("NO INFORMA");
            cbAlojamiento.Items.Add("MUY BUENO");
            cbAlojamiento.Items.Add("BUENO");
            cbAlojamiento.Items.Add("REGULAR");
            cbAlojamiento.Items.Add("MALO");
            cbAlojamiento.SelectedIndex = 0;

            cbDeportes.Items.Add("NO INFORMA");
            cbDeportes.Items.Add("MUY BUENO");
            cbDeportes.Items.Add("BUENO");
            cbDeportes.Items.Add("REGULAR");
            cbDeportes.Items.Add("MALO");
            cbDeportes.SelectedIndex = 0;

            cbOtros.Items.Add("NO INFORMA");
            cbOtros.Items.Add("MUY BUENO");
            cbOtros.Items.Add("BUENO");
            cbOtros.Items.Add("REGULAR");
            cbOtros.Items.Add("MALO");
            cbOtros.SelectedIndex = 0;

            cbCultura.Items.Add("NO INFORMA");
            cbCultura.Items.Add("MUY BUENO");
            cbCultura.Items.Add("BUENO");
            cbCultura.Items.Add("REGULAR");
            cbCultura.Items.Add("MALO");
            cbCultura.SelectedIndex = 0;

            cbAsistenciales.Items.Add("NO INFORMA");
            cbAsistenciales.Items.Add("MUY BUENO");
            cbAsistenciales.Items.Add("BUENO");
            cbAsistenciales.Items.Add("REGULAR");
            cbAsistenciales.Items.Add("MALO");
            cbAsistenciales.SelectedIndex = 0;

            cbTurismo.Items.Add("NO INFORMA");
            cbTurismo.Items.Add("MUY BUENO");
            cbTurismo.Items.Add("BUENO");
            cbTurismo.Items.Add("REGULAR");
            cbTurismo.Items.Add("MALO");
            cbTurismo.SelectedIndex = 0;
        }

        private void btnCargarEncuesta_Click(object sender, EventArgs e)
        {
            string ALOJAMIENTO = cbAlojamiento.SelectedItem.ToString();
            string TURISMO = cbTurismo.SelectedItem.ToString();
            string DEPORTES = cbDeportes.SelectedItem.ToString();
            string CULTURA = cbCultura.SelectedItem.ToString();
            string ASISTENCIALES = cbAsistenciales.SelectedItem.ToString();
            string OTROS = cbOtros.SelectedItem.ToString();
            string SUGERENCIAS = tbSugerencias.Text;
            string DIRECCION = tbDireccion.Text;
            Int64 TELEFONO = 0;
            Int64 CELULAR = 0;

            if (tbTelefono.Text != "")
                TELEFONO = Int64.Parse(tbTelefono.Text);

            if (tbCelular.Text != "")
                CELULAR = Int64.Parse(tbCelular.Text);

            string EMAIL = tbEmail.Text;

            try
            {
                dlog.guardarEncuesta(VNOMBRE, VDNI, VNRO_SOC, VNRO_DEP, VNRO_SOC_ADH, VNRO_DEP_ADH, VBARRA, DIRECCION, TELEFONO, CELULAR, EMAIL, ALOJAMIENTO, TURISMO, DEPORTES, CULTURA, ASISTENCIALES, OTROS, SUGERENCIAS);
                MessageBox.Show("SE CARGO LA ENCUESTA CORRECTAMENTE", "LISTO!");
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO CARGAR LA ENCUESTA\n" + error, "ERROR");
            }
            
        }
    }
}
