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
    public partial class Contacto_Form : Form
    {
        SOCIOS.interior.serviceInterior si = new serviceInterior();
        BO.bo_interior dlog = new BO.bo_interior();
        TurismoUtils tu = new TurismoUtils();

        int ID;
        public Contacto_Form(int pID)
        {
            InitializeComponent();
            ID = pID;
            tu.UpdateComboTabla("INTERIOR_MOTIVO", cbSocial);
            Carga(ID);


           

        }


        public void UpdateComboSocial()
        {
            string query = "SELECT ID, NOMBRE  FROM  HOTEL ";






            cbSocial.DataSource = null;

            cbSocial.Items.Clear();

            cbSocial.Items.Insert((int)Hotel_Social_Enum.TRAMITE, "TRAMITE");
            cbSocial.Items.Insert((int)Hotel_Social_Enum.ENFERMEDAD, "ENFERMEDAD");
            cbSocial.Items.Insert((int)Hotel_Social_Enum.CIRUGIA, "CIRUGIA");
            cbSocial.SelectedValue = "1";



        }

        private void Carga(int ID)

        {

            this.Text = "Procesar Contacto Nro : " + ID.ToString();
             Contacto c= si.get_Contacto(ID);
             if (c.DESDE.Length > 0)
                 lbDesde.Text = c.DESDE;
             if (c.HASTA.Length > 0)
                 lbHasta.Text = c.HASTA;
             lbCantidad.Text = c.CANTIDAD.ToString();
             lbTel1.Text = c.TEL1;
             lbTel2.Text = c.TEL2;
             lbEmail.Text = c.EMAIL;
             tbObs.Text = c.OBS;
             lbVisto.Text = c.USER_VISTO;
             if (c.VISTO.Length > 0)
                 lbFechaVisto.Text = c.VISTO;
            if (c.FECHA_CONTACTO.Length > 0)
                 lbFechaContacto.Text = c.FECHA_CONTACTO;
             if (c.NYA.Length > 0)
                 lbNombre.Text = c.NYA;
             if (c.DNI.Length > 0)
                 lbDni.Text = c.DNI;
             if (c.NRO_SOCIO.Length > 0)
                 lbNroSocio.Text=c.NRO_SOCIO;

             lbProcedencia.Text = c.PROCEDENCIA; 
            cbSocial.SelectedValue = c.MOTIVO.ToString();
             




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PROCESAR_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se procede a marcar como visto el contacto ", "Confirmacion ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dlog.PROCESAR_CONTACTO(ID);

            }
        }

        private void Descartar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se procede a Anular el Contacto  ", "Confirmacion ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dlog.BAJA_CONTACTO(ID);
            }

        }
    }
}
