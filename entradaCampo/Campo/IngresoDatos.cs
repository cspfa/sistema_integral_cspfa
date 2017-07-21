using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOCIOS;

namespace SOCIOS.Entrada_Campo
{
    public partial class IngresoDatos : Form
    {
        bool Resta = true;
        bool Invitado =true;
        bool Intercirculo = false;
        bo dlog = new bo();
        EntradaCampoService entradaCampoService = new EntradaCampoService();
        
        public IngresoDatos(bool pResta)
        {
            InitializeComponent();
            Resta = pResta;
        }

        private void Validar()

        {
            if (tbDni.Text.Length == 0)
                throw new Exception("Falta Ingresar DNI");
            if (tbNombre.Text.Length == 0)
                throw new Exception("Falta Agregar Nombre");
            if (tbApellido.Text.Length == 0)
                throw new Exception("Falta Agregar Apellido");

        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            int NroSocio = 0;
            int Legajo = 0;

            try
            {
                if (tbDni.Text.Length == 0)
                    throw new Exception("Debe Ingresa Dni");
                if (tbNombre.Text.Length == 0)
                    throw new Exception("Debe Ingresar Nombre ");
                if (tbApellido.Text.Length == 0)
                    throw new Exception("Debe Ingresar Apellido ");

                Invitado = this.DeterminarInvitados(tbDni.Text);
              

                if ( (entradaCampoService.Monto_Maximo_Reintegrar(tbDni.Text,System.DateTime.Now) == 0 ) & Resta == true)
                {
                    throw new Exception("No existen movimientos a Reintegrar en el dia de la fecha  ");

                }
                 Intercirculo = DeterminarInterCirculo(tbDni.Text);


                 if (chkPersonalPolicial.Checked || chkSocio.Checked)
                 { 
                    if (tbLegajoNroSocio.Text.Length ==0)
                        throw new Exception("Debe Ingresar Legajo/Nro de Socio ");
                 
                 }


                 if (chkPersonalPolicial.Checked)
                 {

                    

                     Legajo = Int32.Parse(tbLegajoNroSocio.Text);
                     Intercirculo = true;

                 }
                 if (chkSocio.Checked)
                 {
                     NroSocio = Int32.Parse(tbLegajoNroSocio.Text);
                     Invitado = false;

                 
                 }



                 if (cbEvento.Checked == false)
                 {
                     EntradaCampoIngresoTotales ent = new EntradaCampoIngresoTotales(tbDni.Text, tbNombre.Text, tbApellido.Text, NroSocio, 0, "", Invitado, Intercirculo, Resta, Legajo);
                     tbDni.Text = "";
                     tbApellido.Text = "";
                     tbNombre.Text = "";

                     ent.Show();
                 }
                 else

                 {
                     SOCIOS.entradaCampo.Campo.EntradaEvento ee = new entradaCampo.Campo.EntradaEvento(tbDni.Text, tbNombre.Text, tbApellido.Text, NroSocio, 0, "", tbLegajoNroSocio.Text, false,0);
                     tbDni.Text = "";
                     tbApellido.Text = "";
                     tbNombre.Text = "";

                     ee.Show();
                 }
              
              
            }
            catch (Exception ex)

            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private bool DeterminarInvitados(string Dni)
        {
            //titular 1 , familiar 2 , adherente 3 
            if (DeterminarInvitado(Dni, 1))
                return false;
            else if (DeterminarInvitado(Dni, 2))
                return false;
            else if (DeterminarInvitado(Dni, 3))
                return false;

            
            //si no encuntra nada, es invitado
            return true;
        
        }
        private bool DeterminarInvitado(string dni,int Tipo)

        {
            //titular 1 , familiar 2 , adherente 3 
            string QUERY = "";
            
            if (Tipo ==1)
               QUERY= "select ID_Titular from titular where num_doc=" + dni  + " and cat_soc<>'009'";
            else if (Tipo ==2)
                 QUERY= "select ID_Titular from familiar where num_docf=" + dni;
            else
                QUERY = "select ID_Titular from adherent where num_docadh=" + dni;


            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
                
            
            }


        
        
        }

        private bool DeterminarInterCirculo(string Dni)

        {
            

         
             string QUERY = "select ID_Titular from titular where num_doc=" +Dni + " and Cat_Soc='008'";
          

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return true;
            }
            else
            {
                return false;


            }

        
        
        }




        private void tbDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void chkPersonal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPersonalPolicial.Checked)

            {
                chkSocio.Checked = false;
                lbLegajoNroSocio.Text = "LEGAJO";
                lbLegajoNroSocio.Visible = true;
                tbLegajoNroSocio.Visible = true;

            }
            else if (chkSocio.Checked == false)
            {
                lbLegajoNroSocio.Visible = false;
                tbLegajoNroSocio.Visible = false;
            }







        }

        private void chkSocio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSocio.Checked)
            {
                chkPersonalPolicial.Checked = false;
                lbLegajoNroSocio.Text = "NRO SOCIO";
                lbLegajoNroSocio.Visible = true;
                tbLegajoNroSocio.Visible = true;

            }
            else if (chkPersonalPolicial.Checked == false)

            {
                lbLegajoNroSocio.Visible = false;
                tbLegajoNroSocio.Visible = false;
            }
        }
    }
}
