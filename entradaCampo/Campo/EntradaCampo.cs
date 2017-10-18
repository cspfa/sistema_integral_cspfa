using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Entrada_Campo
{
    public partial class EntradaCampoIngresoTotales : Form
    {
        string DNI        = "";
        string NOMBRE    = "";
        string APELLIDO  = "";
        int NRO_SOCIO = 0;
        int  NRO_DEP   = 0;
        int LEGAJO = 0;
        int modo = 1;

        string TIPO      = "";
        int Socio = 0;
        decimal Socio_Monto = 0;

        int Socio_Pileta                           = 0;
        decimal Socio_Pileta_Monto                 = 0;

        int     Socio_Estacionamiento              = 0;
        decimal Socio_Estacionamiento_Monto        = 0;

        int Invitado                               = 0;
        decimal Invitado_Monto                     = 0;
        
        int Invitado_Pileta                        = 0;
        decimal Invitado_Pileta_Monto              = 0;

        int Invitado_Estacionamiento               = 0;
        decimal Invitado_Estacionamiento_Monto     = 0;

        int Intercirculo                           = 0;
        decimal Intercirculo_Monto                 = 0;

        int Intercirculo_Pileta                    = 0;
        decimal Intercirculo_Pileta_Monto          = 0;

        int      Intercirculo_Estacionamiento      = 0;
        decimal Intercirculo_Estacionamiento_Monto = 0;

        int Menor = 0;
        int Discapacitado = 0;
        int Discapacitado_Acompa = 0;
        bool ModoInvitado=false;
        bool ModoIntercirculo = false;
        bool esReintegro = false;
        

        decimal MontoMaximoAReintegrar = 0;

        bo_Entrada_Campo dlog = new bo_Entrada_Campo();
      
        
        List<SOCIOS.RegistroEntradaCampo> lista = new List<RegistroEntradaCampo>();
        EntradaCampoService entradaCampoService = new EntradaCampoService();
        bool IngresoManual;
        public EntradaCampoIngresoTotales(string pDNI, string pNOMBRE, string pAPELLIDO, int pNRO_Socio,int pNRO_DEP,string pTIPO,bool soloInvitado,bool SoloInterCirculo,bool resta,int pLegajo,bool pIngresoManual )
        {
            DNI       = pDNI;
            NOMBRE    = pNOMBRE;
            APELLIDO  = pAPELLIDO;
            NRO_SOCIO = pNRO_Socio;
            NRO_DEP   = pNRO_DEP;
             LEGAJO   = pLegajo;
            TIPO      = pTIPO.TrimEnd();
            ModoIntercirculo = SoloInterCirculo;
            InitializeComponent();
            IngresoManual = pIngresoManual;
            this.Iniciar(soloInvitado,resta,IngresoManual);
        }

        private void Iniciar(bool Invitado, bool reintegro,bool IngresoManual)

        {
            lbDatos.Text = DNI + " - " + APELLIDO + ", " + NOMBRE + " - " + TIPO;

          
            ModoInvitado =Invitado;

            MostrarControles(true,reintegro,IngresoManual);
            esReintegro = reintegro;


            if (reintegro)
            {
                modo = -1;
                //lnk_Familiar_Estacionamiento.Visible = false;
                //lnk_InterCirculo_Estacionamiento.Visible = false;
                //lnk_Invitado_Estacionamiento.Visible = false;
                lnkFamiliar.Visible = false;
              
                gpSinCargo.Visible = false;
                
                gpInterCirculo.Visible = true;
                gpInvitados.Visible = true;
                gpFamiliares.Visible = true;

                MontoMaximoAReintegrar = entradaCampoService.Monto_Maximo_Reintegrar(DNI,System.DateTime.Now);
                lbReintegro.Text = "Monto Maximo a Reintegrar $" + MontoMaximoAReintegrar.ToString();
                lbReintegro.Visible = true;




            }
            else
            {
                modo = 1;
                lnk_Familiar_Estacionamiento.Visible = true;
                lnk_InterCirculo_Estacionamiento.Visible = true;
                lnk_Invitado_Estacionamiento.Visible = true;

                lnkFamiliar.Visible = true;
                lnkIntercirculo.Visible = true;
                lnkInvitado.Visible = true;
                gpSinCargo.Visible = true;
                lbReintegro.Visible = false;


            }

         



        }

       

        private void lnkFamiliar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.NuevoItem(entradaCampoService.EntradaSocio, 1);
        }



        #region internas 

        private void NuevoItem(decimal Monto, int Tipo)
        {   //Tipo 1 : Entrada Socio /Familiar
            //Tipo 2 : Entrada Pileta Socio /Familiar
            //Tipo 3 : Estacionamiento Socio

            //Tipo 4 : Entrada Invi
            //Tipo 5 : Entrada Invi Pileta 
            //Tipo 6 : Estacionamiento Invi

            //Tipo 7 : Entrada Inter
            //Tipo 8 : Entrada Inter Pileta 
            //Tipo 9 : Estacionamiento Inter
            //Tipo 10 : Entrada Menor Pileta
            //Tipo 11 : Entrada Disca Pileta
            //Tipo 12 : Entrada VITALICIO ORO



            RegistroEntradaCampo entrada = new RegistroEntradaCampo();

            switch (Tipo)
            {
                case 1:
             
                    entrada.Tipo = "ENTRADA SOCIO";
                    break;

                case 2:
                  
                    entrada.Tipo = "PILETA SOCIO";
                    break;
                case 3:
                  
                    entrada.Tipo = "ESTACIONAMIENTO ";
                    break;
                case 4:
                  
                    entrada.Tipo = "ENTRADA INVITADO";
                    break;
                case 5:
     
                    entrada.Tipo = "PILETA INVITADO";
                    break;
                case 6:
                   
                    entrada.Tipo = "ESTACIONAMIENTO INVITADO";
                    break;
                case 7:
                   
                    entrada.Tipo = "ENTRADA INTERCIRCULO";
                    break;
                case 8:

                    entrada.Tipo = "PILETA INTERCIRCULO";
                    break;
                case 10:

                    entrada.Tipo = "PILETA MENOR";
                    break;
                case 11:

                    entrada.Tipo = "PILETA DISCAPACITADO";
                    break;
                case 12:

                    entrada.Tipo = "PILETA VITALICIO ORO";
                    break;

                default:
                 
                    entrada.Tipo = "ESTACIONAMIENTO INTERCIRCULO";
                    break;
            }



            entrada.Monto = Monto * modo;
            

            entrada.TipoValor = Tipo ;
            if (lista == null)
                entrada.ID = 1;
            else
            {
                entrada.ID = lista.Count + 1;
            }

            lista.Add(entrada);




            this.ActualizoPersonas();

        }

        private void  ActualizoPersonas()
        {
           
            ActualizoTotal();
        }
        private void ActualizoTotal()

        {

            Personas.DataSource = null;

            Personas.DataSource = lista;
            decimal Saldo = lista.Sum(x => x.Monto);
            lbTotal.Text = Decimal.Round(Saldo, 2).ToString();
            Personas.Columns[0].Visible = false;
            Personas.Columns[1].Visible = false;




            lbSocio.Text            = lista.Where(x => (x.TipoValor == 1)).Count().ToString();
            lbSocioPileta.Text      = lista.Where(x => (x.TipoValor == 2)).Count().ToString();


            lbInvitado.Text         = lista.Where(x => (x.TipoValor == 4)).Count().ToString();
            lbInviPileta.Text       = lista.Where(x => (x.TipoValor == 5)).Count().ToString();

            lbInter.Text            = lista.Where(x => (x.TipoValor == 7)).Count().ToString();
            lbInterPileta.Text      = lista.Where(x => (x.TipoValor == 8)).Count().ToString();
            lbSinCargo.Text         = lista.Where(x => (x.TipoValor == 10 || x.TipoValor == 11 || x.TipoValor ==12)).Count().ToString();
            lbEstacionamiento.Text  = lista.Where(x => (x.TipoValor == 3 || x.TipoValor == 6 || x.TipoValor==9)).Count().ToString();



        }
        #endregion

        private void lnk_Familiar_Pileta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.NuevoItem(entradaCampoService.EntradaSocioPileta, 2);
        }

        private void lnkInvitado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.NuevoItem(entradaCampoService.EntradaInvi, 4);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.NuevoItem(entradaCampoService.EntradaInviPileta, 5);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
               int   ID = Int32.Parse(Personas.SelectedRows[0].Cells[0].Value.ToString());

               lista.RemoveAll(x => x.ID == ID);
               this.ActualizoTotal();
              
            }
            catch (Exception ex)

            { 
            
            
            }


        }

        private void Pago_Click(object sender, EventArgs e)
        {
            try
            {
             
                
                
                
                decimal Monto_Entrada =0;
                decimal Monto_Total=0;
           
                decimal Monto_Pileta=0;
                decimal Monto_Estacionamiento = 0;
               
                int Cantidad_Entrada=0;
                
                int Cantidad_Pileta=0;
                int Cantidad_Estacionamiento = 0;
                int Cantidad_Total=0;


               


                Socio = lista.Where(x => x.TipoValor == 1).Count();
                Socio_Pileta = lista.Where(x => x.TipoValor == 2).Count();
                Socio_Estacionamiento = lista.Where(x => x.TipoValor == 3).Count();

                Invitado = lista.Where(x => x.TipoValor == 4).Count();
                Invitado_Pileta = lista.Where(x => x.TipoValor == 5).Count();
                Invitado_Estacionamiento = lista.Where(x => x.TipoValor == 6).Count();

                Intercirculo = lista.Where(x => x.TipoValor == 7).Count();
                Intercirculo_Pileta = lista.Where(x => x.TipoValor == 8).Count();
                Intercirculo_Estacionamiento = lista.Where(x => x.TipoValor == 9).Count();


                Menor = lista.Where(x => x.TipoValor == 10).Count();
                Discapacitado = lista.Where(x => x.TipoValor == 11).Count();
                Discapacitado_Acompa = lista.Where(x => x.TipoValor == 12).Count();

                if (esReintegro)
                {
                    Socio = Socio * (-1);
                    Socio_Pileta = Socio_Pileta * (-1);
                    Socio_Estacionamiento = Socio_Estacionamiento * (-1);
                    
                    Invitado = Invitado * (-1);
                    Invitado_Pileta = Invitado_Pileta * (-1);
                    Invitado_Estacionamiento = Invitado_Estacionamiento * (-1);

                    Intercirculo         = Intercirculo * (-1);
                    Intercirculo_Pileta = Intercirculo_Pileta * (-1);
                    Intercirculo_Estacionamiento = Intercirculo_Estacionamiento * (-1);

                    Menor = Menor * (-1);
                    Discapacitado = Discapacitado * (-1);
                    Discapacitado_Acompa = Discapacitado_Acompa * (-1);

                }


                Cantidad_Total = Socio + Socio_Pileta + Socio_Estacionamiento+ Invitado + Invitado_Pileta + Invitado_Estacionamiento + Intercirculo + Intercirculo_Pileta + Intercirculo_Estacionamiento;


                Socio_Monto                        =       Decimal.Round(lista.Where(x => ((x.TipoValor == 1) )).Sum(x => x.Monto), 2);
                Socio_Pileta_Monto                 =       Decimal.Round(lista.Where(x => ((x.TipoValor == 2) )).Sum(x => x.Monto), 2);
                Socio_Estacionamiento_Monto        =       Decimal.Round(lista.Where(x => ((x.TipoValor == 3))).Sum(x => x.Monto), 2);
               
                Invitado_Monto                     =       Decimal.Round(lista.Where(x => ((x.TipoValor == 4) )).Sum(x => x.Monto), 2);
                Invitado_Pileta_Monto              =       Decimal.Round(lista.Where(x => ((x.TipoValor == 5) )).Sum(x => x.Monto), 2);
                Invitado_Estacionamiento_Monto     =       Decimal.Round(lista.Where(x => ((x.TipoValor == 6))).Sum(x => x.Monto), 2);

                Intercirculo_Monto                 =       Decimal.Round(lista.Where(x => ((x.TipoValor == 7))).Sum(x => x.Monto), 2);
                Intercirculo_Pileta_Monto          =       Decimal.Round(lista.Where(x => ((x.TipoValor == 8))).Sum(x => x.Monto), 2);
                Intercirculo_Estacionamiento_Monto =       Decimal.Round(lista.Where(x => ((x.TipoValor == 9))).Sum(x => x.Monto), 2);





                
                Monto_Total = Decimal.Round( Socio_Monto + Socio_Pileta_Monto + Socio_Estacionamiento_Monto + Invitado_Monto + Invitado_Pileta_Monto + Invitado_Estacionamiento_Monto + Intercirculo_Monto + Intercirculo_Pileta_Monto + Intercirculo_Estacionamiento_Monto ,2);






                string Tipo_reg = "ALTA";
                if  (Monto_Total <=0)
                    Tipo_reg ="BAJA";


             
                if (esReintegro && ( (-1) * Monto_Total  >   MontoMaximoAReintegrar))

                {
                    throw new Exception("El Monto Total no puede Exceder el Monto Maximo de Reintegro  ");
                }

                bool Ya_Ingreso = entradaCampoService.Persona_Ya_Ingresada(DNI, System.DateTime.Now);
                bool Anular_Ingreso = false;
                if (Ya_Ingreso && esReintegro ==false)
                {

                   
                    if (MessageBox.Show("Este DNI ya ha ingresado en el dia, desea proceder el ingreso?", "DNI repetido", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                         Anular_Ingreso = true;

                    }
                    
                       
                   
                   

                }


                int ID_INT = entradaCampoService.Ultimo_ID(VGlobales.vp_role);
               

                    dlog.Entrada_Campo_Ins(DNI, NOMBRE, APELLIDO, NRO_SOCIO, NRO_DEP, TIPO, Invitado, Invitado_Monto, Invitado_Pileta, Invitado_Pileta_Monto, Invitado_Estacionamiento, Invitado_Estacionamiento_Monto, Socio, Socio_Monto, Socio_Pileta, Socio_Pileta_Monto, Socio_Estacionamiento, Socio_Estacionamiento_Monto, Intercirculo, Intercirculo_Monto, Intercirculo_Pileta, Intercirculo_Pileta_Monto, Intercirculo_Estacionamiento, Intercirculo_Estacionamiento_Monto, Cantidad_Total, Monto_Total, System.DateTime.Now, VGlobales.vp_role, VGlobales.vp_username,Menor,Discapacitado,Discapacitado_Acompa,0,0,ID_INT,Tipo_reg,LEGAJO,tbCumple.Text,0,"","");

                
                MostrarControles(false,esReintegro,IngresoManual);

                if (Anular_Ingreso == false)
                {
                    DialogResult dr = MessageBox.Show("Ingreso Exitoso del Ticket Nro :  "+ ID_INT.ToString() + "  , imprimir Cupon ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (dr == DialogResult.OK)
                    {
                        this.Imprimir();
                        this.Close();
                    }
                }
                else

                {
                    int ID = entradaCampoService.GetMaxID(DNI);
                    dlog.Entrada_Campo_Anular(ID);
                    this.Close();
                
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void RestaCantidades()

        { 
        
         foreach ( RegistroEntradaCampo re in  lista )

         {
            
         }
        }

        public void MostrarControles(bool Mostrar,bool reintegro,bool Manual)

        {
           
                gpFamiliares.Visible = Mostrar;
                gpInvitados.Visible = Mostrar;
                gpInterCirculo.Visible =Mostrar;
                gpSinCargo.Visible = Mostrar;
                Delete.Visible      = Mostrar;
                Pago.Visible = Mostrar;
                btnImprimir.Visible= !Mostrar;


                if (reintegro && (Mostrar==true))

                {

                    //gpFamiliares.Visible    =   entradaCampoService.Existe_Entrada_Tipo(DNI, 1);
                    //gpInvitados.Visible     = entradaCampoService.Existe_Entrada_Tipo(DNI, 2);
                    //gpInterCirculo.Visible  = entradaCampoService.Existe_Entrada_Tipo(DNI, 3);
                    gpFamiliares.Visible   = true;
                    gpInvitados.Visible    = true;
                    gpInterCirculo.Visible = true;
                    lnkInvitado.Visible = true;
                    lnkIntercirculo.Visible = true;
                    Pago.Text = "Reintegro";
                
                
                }

                if (ModoInvitado )
                {
                    gpFamiliares.Visible = false;
                    gpInterCirculo.Visible = false;     
                
                }

                if (ModoIntercirculo)
                {
                    gpFamiliares.Visible = false;
                    gpInterCirculo.Visible = true;

                }

                chkSocio.Visible = Manual;
                chkPersonalPolicial.Visible = Manual;

            

                
                   

            
          
        
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            
            
            this.Imprimir();
        }

        private void Imprimir()

        {
            int ID = entradaCampoService.GetMaxID_ROL(DNI, VGlobales.vp_role.TrimEnd().TrimStart());
            entradaCampoService.Imprimir(Socio, Socio_Pileta, Socio_Estacionamiento, Invitado, Invitado_Pileta, Invitado_Estacionamiento, Intercirculo, Intercirculo_Pileta, Intercirculo_Estacionamiento, Menor, Discapacitado, Discapacitado_Acompa, ID, DNI + "-" + APELLIDO + "," + NOMBRE, TIPO, false,false,true,"",0,false);
            entradaCampoService.Imprimir(Socio, Socio_Pileta, Socio_Estacionamiento, Invitado, Invitado_Pileta, Invitado_Estacionamiento, Intercirculo, Intercirculo_Pileta, Intercirculo_Estacionamiento, Menor, Discapacitado, Discapacitado_Acompa,ID, DNI + "-" + APELLIDO + "," + NOMBRE, TIPO, false, false, false,"",0,false);
            this.Imprimir_Pileta();

        }




        private void Imprimir_Pileta()

        { 
            int CantidadPiletas = Invitado_Pileta + Socio_Pileta + Intercirculo_Pileta;


            for (int I = 0; I < CantidadPiletas; I++)
            {
               entradaCampoService.Imprimir_Pileta(DNI + "-" + APELLIDO + "," + NOMBRE, "Pileta " + (I + 1).ToString() + " de " + CantidadPiletas.ToString());
            }
        
        }

        private void lnk_Familiar_Estacionamiento_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.NuevoItem(entradaCampoService.EntradaSocioEstacionamiento, 3);
        }

        private void lnk_Invitado_Estacionamiento_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.NuevoItem(entradaCampoService.EntradaInviEstacionamiento, 6);
        }

        private void lnkIntercirculo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.NuevoItem(entradaCampoService.EntradaInter, 7);
        }

        private void lnk_Intercirculo_Pileta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.NuevoItem(entradaCampoService.EntradaInterPileta, 8);
        }

        private void lnk_InterCirculo_Estacionamiento_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.NuevoItem(entradaCampoService.EntradaInterEstacionamiento, 9);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lnkDisca_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.NuevoItem(0, 11);
        }

        private void lnkMenor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.NuevoItem(0, 10);
        }

        private void lnkDiscaAcom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.NuevoItem(0, 12);
        }

        private void chkCumple_CheckedChanged(object sender, EventArgs e)
        {
            tbCumple.Visible = chkCumple.Checked;
        }

        private void chkPersonalPolicial_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPersonalPolicial.Checked)
                gpInterCirculo.Visible = true;
            else
                gpInterCirculo.Visible = false;
              
        }

        private void chkSocio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSocio.Checked)
                gpFamiliares.Visible = true;
            else
                gpFamiliares.Visible = false;

                    
                   

        }
    }
}
