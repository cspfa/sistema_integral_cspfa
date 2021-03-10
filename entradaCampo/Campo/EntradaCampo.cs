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
        int Oro = 0;
        int Promo = 0;
        bool ModoInvitado=false;
        bool ModoIntercirculo = false;
        bool esReintegro = false;
        int Hora_Pileta = 0;
        

        decimal MontoMaximoAReintegrar = 0;

        bo_Entrada_Campo dlog = new bo_Entrada_Campo();
        Entrada_Campo.DiasPiletaService serviceDias = new Entrada_Campo.DiasPiletaService();
        
        
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
            ModoInvitado = false; // Segun pedido de susana 01-12-2020
            chkPersonalPolicial.Checked = true;
            chkSocio.Checked = true;
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

            this.Aforo_Total();
            lbInfoAforo.Text= entradaCampoService.INFO_AFORO();

         
            dgvInfo.DataSource =  serviceDias.INFO_HORARIOS();
           // cbPiletaHorario.Checked = true;


            if (VGlobales.vp_role.Contains("SISTEMAS"))
                btnConfig.Visible=true;
            else
                btnConfig.Visible =false;

         



        }

       

        private void lnkFamiliar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {  
            this.NuevoItem(entradaCampoService.EntradaSocio,1);
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
            //Tipo 13 : Entrada Pileta Promo



            RegistroEntradaCampo entrada = new RegistroEntradaCampo();
            int Horario = -1;
            string Horario_Leyenda = "D.C.";

            if (cbPiletaHorario.Checked)
            {
                Horario = Int32.Parse(cbHorario.SelectedValue.ToString());
                Horario_Leyenda = cbHorario.Text;
            }
             
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

                case 13:

                    entrada.Tipo = "PILETA PROMO";
                    break;

                default:
                 
                    entrada.Tipo = "ESTACIONAMIENTO INTERCIRCULO";
                    break;
            }



            entrada.Monto = Monto * modo;
            entrada.HorarioID = Horario;
            entrada.Horario = Horario_Leyenda;

            entrada.TipoValor = Tipo ;
            if (lista == null)
                entrada.ID = 1;
            else
            {
                entrada.ID = lista.Count + 1;
            }

            int Cantidad = 1;

            try
            {
                Cantidad = Int32.Parse(tbCantidad.Text);
            }
            catch
            {
                Cantidad = 1;
            }

            int Veces = 0;


            while (Veces < Cantidad)
            {
                lista.Add(entrada);
                Veces = Veces + 1;
            }



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
            Personas.Columns[5].Visible = false;
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
            lbSinCargo.Text = lista.Where(x => (x.TipoValor == 10 || x.TipoValor == 11 || x.TipoValor == 12 || x.TipoValor == 13)).Count().ToString();
            lbEstacionamiento.Text  = lista.Where(x => (x.TipoValor == 3 || x.TipoValor == 6 || x.TipoValor==9)).Count().ToString();



        }
        #endregion

        private void lnk_Familiar_Pileta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cbPiletaHorario.Checked==false)
              this.NuevoItem(entradaCampoService.EntradaSocioPileta, 2);
            else
                this.NuevoItem(entradaCampoService.EntradaSocioPiletaHora, 2);
        }

        private void lnkInvitado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.NuevoItem(entradaCampoService.EntradaInvi, 4);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (cbPiletaHorario.Checked == false)
                this.NuevoItem(entradaCampoService.EntradaInviPileta, 5);
            else
                this.NuevoItem(entradaCampoService.EntradaInviPiletaHora, 5);
            
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


                Hora_Pileta=0;

                if (cbPiletaHorario.Checked)
                    Hora_Pileta = 1; // Hora 1 , es que hay horarios que recorrer en la tabla anexa  //Hora_Pileta = Int32.Parse(cbHorario.SelectedValue.ToString());
               
                
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
                Oro = lista.Where(x => x.TipoValor == 12).Count();
                Promo = lista.Where(x => x.TipoValor == 13).Count();
                bool Control_Aforo = true;
                if (esReintegro)
                {
                    Socio = Socio * (-1);
                    Socio_Pileta = Socio_Pileta * (-1);
                    Socio_Estacionamiento = Socio_Estacionamiento * (-1);

                    Invitado = Invitado * (-1);
                    Invitado_Pileta = Invitado_Pileta * (-1);
                    Invitado_Estacionamiento = Invitado_Estacionamiento * (-1);

                    Intercirculo = Intercirculo * (-1);
                    Intercirculo_Pileta = Intercirculo_Pileta * (-1);
                    Intercirculo_Estacionamiento = Intercirculo_Estacionamiento * (-1);

                    Menor = Menor * (-1);
                    Discapacitado = Discapacitado * (-1);
                    Oro = Oro * (-1);
                    Promo = Promo * (-1);

                }
                else // Si no es reintegro, control de piletas y aforo
                {   int Piletas= Promo+ Menor+ Discapacitado+Oro+Invitado_Pileta + Socio_Pileta + Intercirculo_Pileta;
                    
                    if (Piletas !=0)
                    {
                        Control_Aforo = true;
                        if (cbPiletaHorario.Checked)
                        {
                            foreach (int hora in lista.GroupBy(x => x.HorarioID).Select(v => v.First().HorarioID).ToList())
                            {
                                Control_Aforo = ControlAforo(Piletas, hora);
                                if (Control_Aforo == false)
                                    return;
                            }
                        }
                        else
                        {
                            Control_Aforo = ControlAforo(Piletas,0);
                        }
                        if (Control_Aforo == false)
                            return;
                    }
                }


               
                     bool Control=   Control_Cantidad_Familiares(Socio_Pileta + Invitado_Pileta + Intercirculo_Pileta,Hora_Pileta);
                     if (!Control)
                     {
                         if (MessageBox.Show("La cantidad de entradas en el dia excede el limite de cantidade de personas del grupo familiar, esta seguro ?", "Control Grupo Familiar", MessageBoxButtons.YesNo) == DialogResult.No)
                         {
                             return;
                         }
                 
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

                string Hora = System.DateTime.Now.Hour.ToString() +":" + System.DateTime.Now.Minute.ToString(); 


                int ID_INT = entradaCampoService.Ultimo_ID(VGlobales.vp_role);
               
                
                    dlog.Entrada_Campo_Ins(DNI, NOMBRE, APELLIDO, NRO_SOCIO, NRO_DEP, TIPO, Invitado, Invitado_Monto, Invitado_Pileta, Invitado_Pileta_Monto, Invitado_Estacionamiento, Invitado_Estacionamiento_Monto, Socio, Socio_Monto, Socio_Pileta, Socio_Pileta_Monto, Socio_Estacionamiento, Socio_Estacionamiento_Monto, Intercirculo, Intercirculo_Monto, Intercirculo_Pileta, Intercirculo_Pileta_Monto, Intercirculo_Estacionamiento, Intercirculo_Estacionamiento_Monto, Cantidad_Total, Monto_Total, System.DateTime.Now, VGlobales.vp_role, VGlobales.vp_username,Menor,Discapacitado,Oro,0,0,ID_INT,Tipo_reg,LEGAJO,tbCumple.Text,0,"","",Hora,Promo,Hora_Pileta);

                    
                        Grabar_Horarios(ID_INT);
                MostrarControles(false,esReintegro,IngresoManual);

                if (Anular_Ingreso == false)
                {
                    DialogResult dr = MessageBox.Show("Ingreso Exitoso del Ticket Nro :  "+ ID_INT.ToString() + "  , Presione el Boton  de  imprimir Cupon! ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (dr == DialogResult.OK)
                    {
                        this.Imprimir_Directo();
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

        public bool Control_Cantidad_Familiares(int Cantidad,int Hora_Pileta)
        {
            if (NRO_SOCIO == 0)
                return false ;

          return entradaCampoService.Control_Grupo_Familiar(Cantidad, NRO_SOCIO, NRO_DEP, System.DateTime.Now,Hora_Pileta);

            
        }

        private void Grabar_Horarios(int ID_INT)
        {
            var lista_copia = lista;

            foreach (int hora in lista.GroupBy(x => x.HorarioID).Select(v => v.First().HorarioID).ToList())
            {
                //Tipo 1 : Entrada Socio /Familiar
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
            //Tipo 13 : Entrada Pileta Promo
                var item = lista_copia.Where(b => b.HorarioID == hora);
                int Socio=item.Where(x=>x.TipoValor==2).Count();
                int Inter = item.Where(x => x.TipoValor == 8).Count();
                int Invi = item.Where(x => x.TipoValor == 5).Count();
                int Disca = item.Where(x => x.TipoValor == 11).Count();
                int Menor = item.Where(x => x.TipoValor == 10).Count();
                int Promo = item.Where(x => x.TipoValor == 13).Count(); ;

                 dlog.Entrada_Campo_HORARIOS_Ins(ID_INT, hora, Socio, Inter, Invi, Menor, Disca, 0, Promo);
            
            }

        
        }

        private void Grabar(int ID_INT)
        {
            var lista_copia = lista;

            foreach (int hora in lista.GroupBy(x => x.HorarioID).Select(v => v.First().HorarioID).ToList())
            {
                //Tipo 1 : Entrada Socio /Familiar
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
                //Tipo 13 : Entrada Pileta Promo
                var item = lista_copia.Where(b => b.HorarioID == hora);
                int Socio = item.Where(x => x.TipoValor == 2).Count();
                int Inter = item.Where(x => x.TipoValor == 8).Count();
                int Invi = item.Where(x => x.TipoValor == 5).Count();
                int Disca = item.Where(x => x.TipoValor == 11).Count();
                int Menor = item.Where(x => x.TipoValor == 10).Count();
                int Promo = item.Where(x => x.TipoValor == 13).Count(); ;

                dlog.Entrada_Campo_HORARIOS_Ins(ID_INT, hora, Socio, Inter, Invi, Menor, Disca, 0, Promo);

            }


        }



        private bool ControlAforo(int TotalPiletas, int Horario)
        {
            
            
            
            int Aforo_Total = serviceDias.AforoFecha(System.DateTime.Now);
            int TopeDia=  entradaCampoService.Tope_Dia_Pileta;
            int TopeHora = entradaCampoService.Tope_Hora_Pileta;
            
          

            if (Horario != 0)
            {   int Aforo_Horario = serviceDias.AforoHorarios(System.DateTime.Now,Horario);
                if (TopeHora < Aforo_Horario + TotalPiletas)
                {

                    DialogResult dr = (MessageBox.Show("El Horario" + serviceDias.getDiasPileta(Horario) + " Excede la capacidad estimada, continuar?", "Control Aforo Horario", MessageBoxButtons.YesNo));
                    if (dr == DialogResult.No)
                        return false;

                }
              
            }

           
               

            if (TopeDia < Aforo_Total + TotalPiletas)
            {
                DialogResult drd = (MessageBox.Show("Los Ingresos Seleccionados Exceden la capacidad estimada Total, continuar?", "Control Aforo Total", MessageBoxButtons.YesNo));
                if (drd == DialogResult.No)
                    return false;
            }
          
                  


            return true;
          




        
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
            this.Close();
        }

        private void Imprimir()

        {
            int ID = entradaCampoService.GetMaxID_ROL(DNI, VGlobales.vp_role.TrimEnd().TrimStart());
            entradaCampoService.Imprimir(Socio, Socio_Pileta, Socio_Estacionamiento, Invitado, Invitado_Pileta, Invitado_Estacionamiento, Intercirculo, Intercirculo_Pileta, Intercirculo_Estacionamiento, Menor, Discapacitado, Oro,Promo, ID, DNI + "-" + APELLIDO + "," + NOMBRE, TIPO, false,false,true,"",0,false,false,"",Hora_Pileta);
            entradaCampoService.Imprimir(Socio, Socio_Pileta, Socio_Estacionamiento, Invitado, Invitado_Pileta, Invitado_Estacionamiento, Intercirculo, Intercirculo_Pileta, Intercirculo_Estacionamiento, Menor, Discapacitado, Oro,Promo,ID, DNI + "-" + APELLIDO + "," + NOMBRE, TIPO, false, false, false,"",0,false,false,"",Hora_Pileta);
            this.Imprimir_Pileta(false);

        }


        private void Imprimir_Directo()
        {
            int ID = entradaCampoService.GetMaxID_ROL(DNI, VGlobales.vp_role.TrimEnd().TrimStart());
            entradaCampoService.Imprimir(Socio, Socio_Pileta, Socio_Estacionamiento, Invitado, Invitado_Pileta, Invitado_Estacionamiento, Intercirculo, Intercirculo_Pileta, Intercirculo_Estacionamiento, Menor, Discapacitado, Oro,Promo, ID, DNI + "-" + APELLIDO + "," + NOMBRE, TIPO, false, false, true, "", 0, false, true,"",Hora_Pileta);
            
           entradaCampoService.Imprimir(Socio, Socio_Pileta, Socio_Estacionamiento, Invitado, Invitado_Pileta, Invitado_Estacionamiento, Intercirculo, Intercirculo_Pileta, Intercirculo_Estacionamiento, Menor, Discapacitado, Oro,Promo, ID, DNI + "-" + APELLIDO + "," + NOMBRE, TIPO, false, false, false, "", 0, false, true,"",Hora_Pileta);

           if (cbPiletaHorario.Checked)
           {
               this.Imprimir_Pileta_Horarios(ID);
           }
           else
                this.Imprimir_Pileta(true);
            

        }




        private void Imprimir_Pileta(bool Directo)

        { 
            int CantidadPiletas = Invitado_Pileta + Socio_Pileta + Intercirculo_Pileta + Menor + Discapacitado + Oro + Promo;
            int contador = 0;
           
            contador = Impresion_piletas(contador, CantidadPiletas, "SOC", Socio_Pileta, Directo);
            contador = Impresion_piletas(contador, CantidadPiletas, "INV", Invitado_Pileta, Directo);
            contador = Impresion_piletas(contador, CantidadPiletas, "MEN", Menor, Directo);
            contador = Impresion_piletas(contador, CantidadPiletas, "DIS", Discapacitado, Directo);
            contador = Impresion_piletas(contador, CantidadPiletas, "ORO", Oro, Directo);
            contador = Impresion_piletas(contador, CantidadPiletas, "INT", Intercirculo_Pileta, Directo);
            contador = Impresion_piletas(contador, CantidadPiletas, "PRM", Promo, Directo);
        
        
        }

        private void Imprimir_Pileta_Horarios(int ID_ROL)
        {
            int CantidadPiletas = 0;
            int contador = 0;

             CantidadPiletas = Invitado_Pileta + Socio_Pileta + Intercirculo_Pileta + Menor + Discapacitado + Oro + Promo;
            foreach (InfoPiletaDia dia in serviceDias.Cantidad_Horarios_Entrada(ID_ROL, VGlobales.vp_role))
            {
                entradaCampoService.Titulo_Horario = ID_ROL.ToString() + " TURNO " + dia.Horario + " HS";
                contador = Impresion_piletas(contador,CantidadPiletas, "SOC", dia.Socio, false);
                contador = Impresion_piletas(contador, CantidadPiletas, "INV", dia.Invi, false);
                contador = Impresion_piletas(contador,CantidadPiletas, "MEN", dia.Menor, false);
                contador = Impresion_piletas(contador,CantidadPiletas, "DIS",dia.Disc, false);
                contador = Impresion_piletas(contador,CantidadPiletas, "ORO", 0, false);
                contador = Impresion_piletas(contador,CantidadPiletas, "INT", dia.Inter, false);
                contador = Impresion_piletas(contador, CantidadPiletas, "PRM", dia.Promo, false);
            }


        }


        private int Impresion_piletas(int contador, int Total, string TIPO, int Tope, bool Directo)
        {
           
            for (int I=0; I<Tope;I++)
            {   
                contador = contador + 1;
                entradaCampoService.Imprimir_Pileta(DNI + "-" + APELLIDO + "," + NOMBRE, TIPO +"-Pileta " + (contador).ToString() + " de " + Total.ToString(), Directo);
               }

            return contador;
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

            if (cbPiletaHorario.Checked == false)
                this.NuevoItem(entradaCampoService.EntradaInterPileta, 8);
            else
                this.NuevoItem(entradaCampoService.EntradaInterPiletaHora, 8);
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

        private void lnkPromo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.NuevoItem(0, 13);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Imprimir_Directo();
            this.Close();
        }
        
        private void cbPiletaHorario_CheckedChanged(object sender, EventArgs e)
        {
            cbHorario.Visible = cbPiletaHorario.Checked;
            lbAforoDiario.Visible = cbPiletaHorario.Checked;

            if (cbPiletaHorario.Checked)
            {
                cbHorario.DataSource = null;
                cbHorario.Items.Clear();
                cbHorario.ValueMember = "ID";
                cbHorario.DisplayMember = "DESDE_HASTA";
                cbHorario.DataSource = serviceDias.getDiasPileta().Where(x=>x.ID>-1).ToList();
               


               
                cbHorario.SelectedItem = 1;
                Aforo_Horario(1);
            }
            else
            {
                cbHorario.Visible = false;
                lbAforoDiario.Visible = false;
                lbAvisoAbono.Visible = true;
                cbPiletaHorario.Enabled = false;
                lista = new List<RegistroEntradaCampo>();
                Personas.DataSource = null;
                lbSocio.Text = "0";
                lbInvitado.Text = "0";
                lbInter.Text = "0";
                lbInterPileta.Text = "0";
                lbInvitado.Text = "0";
                lbSocioPileta.Text = "0";
                lbEstacionamiento.Text = "0";
                lbSinCargo.Text = "0";
                lbTotal.Text = "0";


            
            }

           
        }

        private void Aforo_Horario(int Horario)
        {
            //int Estadias = (serviceDias.AforoHorarios(System.DateTime.Now, 0));
            //if (Estadias != 0)
            //    Estadias = Estadias - 1;
            lbAforoDiario.Text = " PILETAS EN EL HORARIO :" + (serviceDias.AforoHorarios(System.DateTime.Now, Horario)  ).ToString();
              
        }

        private void Aforo_Total()
        {
            lbAforoTotal.Text = "PILETAS EN EL DIA : " + serviceDias.AforoFecha(System.DateTime.Now).ToString();
            lbCampo.Text = "TOTAL ENTRADAS CAMPO:" + serviceDias.PersonasFecha(System.DateTime.Now).ToString();
        }

        private void cbHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            Aforo_Horario(Int32.Parse(cbHorario.SelectedValue.ToString()));

        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            SOCIOS.entradaCampo.CSPFA.ConfiguracionAforo aforo = new entradaCampo.CSPFA.ConfiguracionAforo();
            aforo.ShowDialog();
        }



        
    }
}
