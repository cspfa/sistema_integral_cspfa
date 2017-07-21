using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Bienestar
{
    public partial class DatosSocioBienestar : Form
    {
        public DatosSocioBienestar(string DNI)
        {
            InitializeComponent();

            SOCIOS.Bienestar.BienestarService bs = new BienestarService();
            if  
                
                (bs.getRegistro(DNI).Count >0 )
            {
                RegistroBienestar reg =  bs.getRegistro(DNI).First();

           if (reg != null)
           {

               lbDni.Text       = reg.DNI;
               lbAfiliado.Text  = reg.NroAfiliado;
               lbCelular.Text   = reg.Celular;
               lbCiudad.Text    = reg.Ciudad;
               lbCP.Text        = reg.CP;
               lbDepto.Text     = reg.Departamento;
               lbEmail.Text     = reg.Email;
               lbParcela.Text   = reg.Parcela;
               lbPartido.Text   = reg.Partido;
               lbPiso.Text      = reg.Piso;
               lbTelefono.Text  = reg.Telefono;
               lbTorre.Text     = reg.Torre;
               lbDomicilio.Text = reg.Domiclio;
               lbProvincia.Text = reg.Provincia;
               
           }
                } else
                    {
                        lbDni.Text = "NO SE ENCUENTA EL DNI EN LA BASE DE BIENESTAR";
            
            
                    }


        }
    }
}
