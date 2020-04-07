using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;
using SOCIOS.Turismo;
using SOCIOS.interior;


namespace SOCIOS.bono
{
    public partial class BonoHotel : SOCIOS.bono.Bono
    {
        bo_Turismo dlog = new bo_Turismo();
        SOCIOS.BO.bo_interior dlogI = new BO.bo_interior();
        SOCIOS.Turismo.TurismoUtils utilsTurismo = new TurismoUtils();
        SOCIOS.arancel arancelService = new arancel();
        public DatoSocio persona = new DatoSocio();
        int Inicio;
        public int ID;
        bool Social;
        int TipoPago;
        decimal Recargo=0;
        VoucherUtils vu = new VoucherUtils();
        Hotel_Dias_Utils hotel_Dias_Utils = new Hotel_Dias_Utils();
        string InfoValorHabitacion = "";
        bool Autorizacion = false;
        int CODINT = 0;
        int SUBCODIGO = 0;
        public  bool BONO_BLANCO = false;
        private bool MODO_PERSONA = false;
        public decimal Efectivo = 0;
        public decimal Tarjeta_credito = 0;
        public int Tarjeta_credito_cuotas = 0;
        public decimal Tarjeta_Debito = 0;
        public decimal Planilla = 0;
        public int Planilla_Cuotas = 0;
        public decimal Transferencia = 0;

        public BonoHotel()
        {
        
        }

         public BonoHotel(DataGridViewSelectedRowCollection Personas, string pSocTitular, string pdepTitular,bool pMuestro): base(Personas, pSocTitular, pdepTitular,pMuestro)
        {
            InitializeComponent();
            this.Iniciar();
        
        }

        

         public BonoHotel(string pSocTitular, string pdepTitular, bool pMuestro)
             : base(pSocTitular, pdepTitular, pMuestro)
         {
             InitializeComponent();
             this.Iniciar();

         }


         private void Iniciar()
         {


             gpDatos.Enabled = true;

             Seleccion.Enabled = true;



             if (Datos != null)
             {
                 foreach (DatoSocio d in Datos)
                 {
                     persona = d;


                 }
             }
             Inicio = 1;

             UpdateComboHabitacion();
             UpdateComboHotel();
             UpdateComboSocial();
             utilsTurismo.UpdateComboTabla("TURISMO_REGIMEN", cbRegimen);
             utilsTurismo.UpdateComboTabla("TURISMO_FILIALES", comboFilial);

             if (srvDatosSocio.CAB.Telefonos.Length > 0)
                 tbContacto.Text = srvDatosSocio.CAB.Telefonos;
             CODINT = Int32.Parse(Config.getValor("TURISMO", "COD_TURISMO", 0));
             Autorizacion = Apto_Autorizacion();

         }
        

        public void UpdateComboHabitacion()
        {
            string query = "SELECT ID, TIPO  FROM  HOTEL_HABITACION_TIPO ORDER BY TIPO ";






            cbHabitacion.DataSource = null;

            cbHabitacion.Items.Clear();

            cbHabitacion.DataSource = dlog.BO_EjecutoDataTable(query);

            cbHabitacion.DisplayMember = "TIPO";

            cbHabitacion.ValueMember = "ID";

            cbHabitacion.SelectedItem = 1;

        }

        public void UpdateComboHotel()
        {
            string query = "SELECT ID, NOMBRE  FROM  HOTEL ";






            cbHotel.DataSource = null;

            cbHotel.Items.Clear();

            cbHotel.DataSource = dlog.BO_EjecutoDataTable(query);

            cbHotel.DisplayMember = "NOMBRE";

            cbHotel.ValueMember = "ID";

            cbHotel.SelectedItem = 1;

        }
        public void UpdateComboSocial()
        {
            string query = "SELECT ID, NOMBRE  FROM  HOTEL ";






            cbSocial.DataSource = null;

            cbSocial.Items.Clear();
            cbSocial.Items.Insert(0, "-");
            cbSocial.Items.Insert((int)Hotel_Social_Enum.TRAMITE   , "Tramite");
            cbSocial.Items.Insert((int)Hotel_Social_Enum.ENFERMEDAD , "Enfermedad");
            cbSocial.Items.Insert((int)Hotel_Social_Enum.CIRUGIA   , "Cirugia");
            cbSocial.SelectedValue = "1";
         
        
        
        }

        private void Seleccion_Click(object sender, EventArgs e)
        {



            this.Seteo_aranceles();

          

        }

        #region Habitaciones
        private void Determino_Numero_Habitaciones()

        {

            if (cbHabitacion.Text.Contains("PERSONA") && Hotel_Propio(Int32.Parse(cbHotel.SelectedValue.ToString()) ))
                MODO_PERSONA=true;
            else
                MODO_PERSONA=false;


            if (MODO_PERSONA)
            {
                lbStatTipoHabitacion.Visible = true;
                StatTipoHabitacion.Visible = true;
                lbCantidadHabitacion.Visible = true;
                StatNumeroHabitacion.Visible = true;
                Lleno_Combo_Stats_Habitacion(0);
            }
            else
            {
                lbStatTipoHabitacion.Visible = false;
                StatTipoHabitacion.Visible   = false;
                StatNumeroHabitacion.Visible = false;
            }



           
        
        }

        private bool Hotel_Propio(int ID)
        {
            string QUERY = "SELECT ID FROM HOTEL WHERE PROPIO=1 AND ID=" + ID.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
               return true;
            }
            else
                return false;
            
        }

        private void Lleno_Combo_Stats_Habitacion(int Tipo)

        {

            string query = "select ID,TIPO from hotel_habitacion_tipo  where Tipo not  like'%PERSONA%' ORDER BY TIPO ";






            StatTipoHabitacion.DataSource = null;

            StatTipoHabitacion.Items.Clear();

            StatTipoHabitacion.DataSource = dlog.BO_EjecutoDataTable(query);

            StatTipoHabitacion.DisplayMember = "TIPO";

            StatTipoHabitacion.ValueMember = "ID";

            StatTipoHabitacion.SelectedItem = 1;
        
        
        }

        

        


        #endregion

        private void Seteo_aranceles()


        {

            try
            {

                decimal Arancel = 0;
                lbMenores.Text = "";
                lbMenores.Visible = false;
                
                Determino_Numero_Habitaciones();

                if (cbHabitacion.Text.ToUpper().Contains("PERSONA"))
                {
                    Arancel = this.SeteoValorHotelXPersona(cbLateCheck.Checked);
                    lbCartelHabitacion.Visible = true;
                    lnkInfoHabitacion.Visible = true;
                }
                else
                {   Arancel = this.SeteoValorHotelXHabitacion();
                    lbCartelHabitacion.Visible = false;
                    lnkInfoHabitacion.Visible = false;
                }

                if (Arancel < 9999) // si no tiene arancel cargado!
                {

                    gpDatos.Visible = true;
                    Deselecionar.Visible = true;
                    Seleccion.Enabled = false;
                    this.GrillaPersonas_Habilitados(false);
                    Social = utilsTurismo.HotelSocial(Int32.Parse(cbHotel.SelectedValue.ToString()));

                    if (Social)
                    {
                        chkBonoSocial.Visible = true;
                    }
                    else
                    {
                        chkBonoSocial.Visible = false;

                    }


                   
                   

                }
                else
                {

                    tbSocios.Text = "0";
                    tbInvitado.Text = "0";
                    tbInterCirculo.Text = "0";

                    gpDatos.Visible = true;
                    Deselecionar.Visible = true;
                    Seleccion.Enabled = false;
                    this.GrillaPersonas_Habilitados(false);
                    MessageBox.Show("No se Encuentra el arancel Cargado, proceder a cargarlo de manera manual");


                    //gpDatos.Visible = false;

                   // throw new Exception("No se Ecuentra Arancel Cargado");
                }
                // Inicializo el punto de venta
                cbRecibo.Checked = true;
                this.Setear_Punto_Venta(1, false);






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        
        }


        private decimal SeteoValorHotelXPersona(bool LateCheckOut)
        {
            int hotel      = Int32.Parse(cbHotel.SelectedValue.ToString());
            int regimen    = Int32.Parse(cbRegimen.SelectedValue.ToString());
            int habitacion = Int32.Parse(cbHabitacion.SelectedValue.ToString());

            decimal totalSocio = 0;
            decimal totalInter = 0;
            decimal totalInvi = 0;
            tbSocios.Text       = "0";
            tbInterCirculo.Text = "0";
            tbInvitado.Text     = "0";
            decimal Late_Check = 0;
            if (LateCheckOut)
                Late_Check = utilsTurismo.Hotel_Late_Chk(hotel);

            
            decimal arancelSocio   = arancelService.valorGrupoHotel(hotel, 1, regimen, habitacion) + Late_Check;
            decimal arancelInter = arancelService.valorGrupoHotel(hotel, 2, regimen, habitacion) + Late_Check; ;
            decimal arancelInvitado = arancelService.valorGrupoHotel(hotel, 3, regimen, habitacion) + Late_Check; ;

          
                      

            this.CalcularCantidadSociosGrupo("HOTEL");

            totalSocio = (arancelSocio * Socios) + (Decimal.Round(arancelSocio/2,2) * MenorSocio);
            totalInter = arancelInter * Intercirculo + (Decimal.Round(arancelInter / 2, 2) * MenorInter); 
            totalInvi = arancelInvitado * Invitado + (Decimal.Round(arancelInvitado / 2, 2) * MenorInvitado); 

           // totalSocio = this.Menores(totalSocio, Socios, MenorSocio);
           //  totalInter = this.Menores(totalInter, Intercirculo, MenorInter);
           // totalInvi = this.Menores(totalInvi, Invitado, MenorInvitado);
            tbSocios.Text = totalSocio.ToString();
            tbInterCirculo.Text = totalInter.ToString();
            tbInvitado.Text = totalInvi.ToString();

            this.TotalizarTipo("-SOCIOS", Socios, arancelSocio, totalSocio);
            this.TotalizarTipo("-INTER", Intercirculo, arancelInter, totalInter);
            this.TotalizarTipo("-INV", Invitado, arancelInvitado, totalInvi);

            if (MenorSocio + MenorInter + MenorInvitado > 0)
            {
                InfoValorHabitacion = InfoValorHabitacion + " - MENORES " + (MenorSocio + MenorInter + MenorInvitado);
            }




            lblSaldoTotal.Text = decimal.Round((totalInvi + totalSocio + totalInter),2).ToString();


            lbMenores.Visible = true;

            lbMenores.Text = "Menores  - Socio : " + MenorSocio.ToString() + " - Invitado :  " + MenorInvitado.ToString() + " - Intercirculo : " + MenorInter.ToString();



            return totalInvi + totalSocio + totalInter;


        }


        private decimal SeteoValorHotelXHabitacion()
        {
            int hotel = Int32.Parse(cbHotel.SelectedValue.ToString());
            int regimen = Int32.Parse(cbRegimen.SelectedValue.ToString());
            int habitacion = Int32.Parse(cbHabitacion.SelectedValue.ToString());

            decimal totalSocio = 0;
            decimal totalInter = 0;
            decimal totalInvi = 0;
            this.CalcularCantidadSociosGrupo("HOTEL");

            decimal arancelSocio =0;
           
            decimal arancelInter =0;
         
            decimal arancelInvitado = 0;






            if ((Socios + Intercirculo + Invitado) > utilsTurismo.Camas_Habitacion(habitacion))
                throw new Exception("La Cantidad de Personas no puede ser mayor a la cantidad de personas permitidas por el tipo de Habitacion");


            // totalSocio = this.Menores(totalSocio, Socios, MenorSocio);
            //  totalInter = this.Menores(totalInter, Intercirculo, MenorInter);
            // totalInvi = this.Menores(totalInvi, Invitado, MenorInvitado);
          try
            {
            if (Socios > 0)
            {
                totalSocio        =   arancelService.valorGrupoHotel(hotel, 1, regimen, habitacion);
           
                tbSocios.Text     =   decimal.Round(totalSocio, 2).ToString();
           

            }
            else if (Intercirculo > 0)
            {
         
                totalInter          =   arancelService.valorGrupoHotel(hotel, 2, regimen, habitacion);
                tbInterCirculo.Text =   totalInter.ToString("0.##");
            }
            else
            {

               totalInvi       =  arancelService.valorGrupoHotel(hotel, 3, regimen, habitacion);
               tbInvitado.Text =  totalInvi.ToString("0.##");
            
            }

            //18-08-16 se saca el *, ya que es por habitacion no importa la cantida de personas 
            //totalSocio = totalSocio * Socios;
            //totalInter = totalInter * Intercirculo;
           //  totalInvi  = totalInvi  * Invitado;

            }
          catch { }
          




            lblSaldoTotal.Text = (totalInvi + totalSocio + totalInter).ToString("0.##");

            return totalInvi + totalSocio + totalInter;


        }



        private decimal Menores(decimal Total, int Personas, int Menores)
        {
            if (Menores == 0)
                return 0;

            decimal resto = (Total / Personas);
            resto = resto / 2;
            return Total - (resto * Menores);
        
        }


        private void TotalizarTipo(string Tipo, int Cantidad, decimal Monto, decimal Total)
        {
            try
            {
                if (Total != 0)
                    InfoValorHabitacion  = InfoValorHabitacion +  Tipo +" " +   Cantidad.ToString() + " - $ " + Decimal.Round(Monto, 2).ToString() + " C/U";
               


            }
            catch (Exception ex)
            { 
            
            }
        }

       



        private void pagBono_Click(object sender, EventArgs e)
        {
            try
            {
                decimal Saldo;
                if (lblSaldoTotal.Text.Length == 0)
                    Saldo = 0;
                else
                    Saldo = Decimal.Parse(lblSaldoTotal.Text);



                PagoBonos pb = new PagoBonos(0, "TURISMO", Saldo, true, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), Int32.Parse(srvDatosSocio.CAB.NroDepTitular), 0, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), srvDatosSocio.CAB.NroBeneficioTitular,dpHasta.Value);

                DialogResult res = pb.ShowDialog();

                if (res == DialogResult.OK)
                {
                    //lbFormaPago.Text = pb.formaPago;
                    PagosBono = pb.Pagos;
                    TipoPago = pb.tipoPago;
                    Contralor = pb.NumeroContraLor;
                    fpago.Text = pb.formaPago;
                    Recargo = pb.Recargo;
                    InfoTarjeta = pb.InfoTarjeta;

                    Efectivo = pb.Efectivo;


                    Tarjeta_credito = pb.Tarjeta_credito;
                    Tarjeta_credito_cuotas = pb.Tarjeta_credito_cuotas;
                    Tarjeta_Debito = pb.Tarjeta_Debito;
                    Planilla = pb.Planilla;
                    Planilla_Cuotas = pb.Planilla_Cuotas;
                    Transferencia = pb.Transfrencia;


                  //  lblSaldoTotal.Text = Decimal.Round(Decimal.Parse(lblSaldoTotal.Text) + pb.Recargo,2).ToString();
                    Grabar.Visible = true;
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dpHasta_ValueChanged(object sender, EventArgs e)
        {
            lbInfoDias.Text = ( (int) (dpHasta.Value - dpDesde.Value).TotalDays ).ToString();
            this.Dias();

        }

        private void Grabar_Click(object sender, EventArgs e)
        {
            if (chkBonoSocial.Checked)
            {
                this.GrabarSocial();
            }
            else

            {
                this.GrabarBonoPago();

            }
        }


        private void GrabarBonoPago()

        {


            int Operador_CSPFA = utilsTurismo.getCSPFA_Proveedor(); ;
            int Hotel = Int32.Parse(cbHotel.SelectedValue.ToString());
            int Regimen = Int32.Parse(cbRegimen.SelectedValue.ToString());
            int Habit = Int32.Parse(cbHabitacion.SelectedValue.ToString());
            int ID_ROL = 0;
            int Comision_Directiva = 0;
            string LATE_CHECKOUT="";
            string CHECKIN = tbCheckIn.Text;
            LATE_CHECKOUT = tbCheckOut.Text;


            int nro_habitacion_stat = 0;
            int tipo_habitacion_stat = 0;

            if (Autorizacion)
                Comision_Directiva = Int32.Parse(cbComisionDirectiva.SelectedValue.ToString());
            else
                Comision_Directiva = 0;
            if (MessageBox.Show("Generar Bono de Estadia en  Hotel: " + cbHotel.Text + "  , Forma de Pago : " + fpago.Text, "Confirmacion ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                decimal Saldo = decimal.Parse(lblSaldoTotal.Text);

             
                if (Saldo != 0)
                {


                    try
                    {
                        int Operador;

                        string ClasePasaje = "";



                        string Nombre = this.srvDatosSocio.CAB.NOMBRE;
                        string Apellido = this.srvDatosSocio.CAB.APELLIDO;
                        string Dni = this.srvDatosSocio.CAB.Dni;
                        string fechaNacimiento = this.srvDatosSocio.CAB.FechaNac;
                       
                        string Telefono = this.srvDatosSocio.CAB.Telefonos;

                        decimal Pago = decimal.Parse(lblSaldoTotal.Text);
                        string OBS = "";
                     
                        
                        if (cbHabitacion.Text.ToUpper().Contains("PERSONA"))
                            OBS = tbObs.Text + " - " + lbMenores.Text;
                        else
                            OBS = tbObs.Text;

                        string NRO_RECIBO_FILIAL  =  "";
                        string NRO_FACTURA_FILIAL =  "";
                        int FILIAL = 0;
                        string PUNTO_VENTA = "";
                        

                        if (cbFilial.Checked)
                        {
                            
                            NRO_RECIBO_FILIAL = tbReciboFilial.Text;
                            NRO_FACTURA_FILIAL = tbReciboFilial.Text;
                            FILIAL = Int32.Parse(comboFilial.SelectedValue.ToString());
                            PUNTO_VENTA = lbPtoVta.Text;
                            // si es comprobante afip, va vacio el recibo, y viceversa
                            if (cbAfip.Checked)
                            {
                                NRO_RECIBO_FILIAL = "";
                            }
                            else
                                NRO_FACTURA_FILIAL = "";




                        }

                        //determino si es por persona o por habitacion

                        if (MODO_PERSONA)
                        {
                            nro_habitacion_stat = Int32.Parse(StatNumeroHabitacion.Text);
                            tipo_habitacion_stat = Int32.Parse(StatTipoHabitacion.SelectedValue.ToString());

                        }
                        else
                        {
                            nro_habitacion_stat = 1;
                            tipo_habitacion_stat = Int32.Parse(cbHabitacion.SelectedValue.ToString());
                        }

                        if (BONO_BLANCO) // Si es bono_Blanco, Vamos por UPDATE
                        {
                            dlog.UpdateBonoTurismo(ID, Nro_Socio_titular, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Nro_Dep_Titular, 0, dpFechaBono.Value, 0, 0, 0, Decimal.Round(Saldo + Recargo, 2), Saldo, Recargo, Nombre, Apellido, persona.NUM_DOC, fechaNacimiento, "", Telefono, persona.MAIL, this.srvDatosSocio.CAB.AAR, this.srvDatosSocio.CAB.ACRJP1, this.srvDatosSocio.CAB.ACRJP2, this.srvDatosSocio.CAB.ACRJP3, this.srvDatosSocio.CAB.PAR, this.srvDatosSocio.CAB.PCRJP1, this.srvDatosSocio.CAB.PCRJP2, this.srvDatosSocio.CAB.PCRJP3, OBS, fpago.Text, Operador_CSPFA, "", ClasePasaje, VGlobales.vp_username, "HOT", 0, Int32.Parse(lbInfoDias.Text), tbNroHabitacion.Text, Contralor, VGlobales.vp_role.TrimEnd().TrimStart(), CODINT, SUBCODIGO,"NO", Comision_Directiva,FILIAL,NRO_RECIBO_FILIAL,NRO_FACTURA_FILIAL,PUNTO_VENTA, Efectivo, Tarjeta_credito, Tarjeta_credito_cuotas, Tarjeta_Debito, Planilla, Planilla_Cuotas);
                        }
                        else // si no es bono blanco, previo, no existe en la base, es INSERT
                        {
                            dlog.InsertBonoTurismo(Nro_Socio_titular, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Nro_Dep_Titular, 0, dpFechaBono.Value, 0, 0, 0, Decimal.Round(Saldo + Recargo, 2), Saldo, Recargo, Nombre, Apellido, persona.NUM_DOC, fechaNacimiento, "", Telefono, persona.MAIL, this.srvDatosSocio.CAB.AAR, this.srvDatosSocio.CAB.ACRJP1, this.srvDatosSocio.CAB.ACRJP2, this.srvDatosSocio.CAB.ACRJP3, this.srvDatosSocio.CAB.PAR, this.srvDatosSocio.CAB.PCRJP1, this.srvDatosSocio.CAB.PCRJP2, this.srvDatosSocio.CAB.PCRJP3, OBS, fpago.Text, Operador_CSPFA, "", ClasePasaje, VGlobales.vp_username, "HOT", 0, Int32.Parse(lbInfoDias.Text), tbNroHabitacion.Text, Contralor, VGlobales.vp_role.TrimEnd().TrimStart(), CODINT, SUBCODIGO, "NO", Comision_Directiva,FILIAL,NRO_RECIBO_FILIAL,NRO_FACTURA_FILIAL,PUNTO_VENTA,tipo_habitacion_stat,nro_habitacion_stat,Efectivo,Tarjeta_credito,Tarjeta_credito_cuotas,Tarjeta_Debito,Planilla,Planilla_Cuotas,Transferencia);

                            ID = utilsTurismo.GetMaxID(Nro_Socio_titular.ToString(), "HOT");

                            //Obtener Proximo ID_ROL
                            ID_ROL = utilsTurismo.GetMax_ID_ROL(VGlobales.vp_role.TrimEnd().TrimStart(), CODINT) + 1;

                            dlog.Seteo_Id_ROL(ID, ID_ROL);
                        }

                        int CodInt = 0;
                        if (VGlobales.vp_role.Contains("TURISMO"))
                            CodInt = 1001;
                        else
                            CodInt = 1008; //Codint De Interior
                        // Grabar Pagos
                        utilsTurismo.GrabarPagos(ID, PagosBono, dpFechaBono.Value, CodInt, srvDatosSocio.CAB, Saldo + Recargo,TipoPago,SUBCODIGO,Int32.Parse(persona.NRO_SOCIO),Int32.Parse(persona.NRO_DEP));
                        //Grabar Personas 
                        utilsTurismo.GrabarPersonas(ID, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), listaPersonas,"TURISMO");
                                                  
                                             
                        vu.GenerarVoucher(ID, Hotel, dpDesde.Value, dpHasta.Value, Regimen, Habit, tbNroHabitacion.Text,"HOT","",LATE_CHECKOUT,CHECKIN,CodInt);
                        
                        gpDatos.Visible = false;
                        bntImprimir.Visible = true;

                        gpDatos.Enabled = false;

                        Seleccion.Enabled = false;

                        this.IngresoCaja(ID,Dni,Nombre,Apellido,Int32.Parse(persona.NRO_SOCIO),Int32.Parse(persona.NRO_DEP),Int32.Parse(persona.BARRA),InfoTarjeta);
                        Grabar.Enabled = false;

                        MessageBox.Show("Bono Grabado con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }



                }
                else
                {
                    MessageBox.Show("Debe Ingresar Pagos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }


        private void GrabarSocial()

        {
            int Operador_CSPFA = utilsTurismo.getCSPFA_Proveedor(); ;
            int Hotel = Int32.Parse(cbHotel.SelectedValue.ToString());
            int Regimen = Int32.Parse(cbRegimen.SelectedValue.ToString());
            int Habit = Int32.Parse(cbHabitacion.SelectedValue.ToString());
            string LATE_CHECKOUT = "";
            string CHECKIN = "";

            LATE_CHECKOUT = tbCheckOut.Text;
            CHECKIN       = tbCheckIn.Text;
           
            if (cbSocial.SelectedItem.ToString().Length ==0)
                MessageBox.Show("Ingrese Motivo de Bono Social", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            string MotivoViaje =  cbSocial.SelectedItem.ToString();


            if (MessageBox.Show("Generar Bono de Estadia en  Hotel: " + cbHotel.Text + "  , Motivo de Viaje : " + MotivoViaje, "Confirmacion ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                decimal Saldo = 0;
                try
                {
                    decimal.Parse(lblSaldoTotal.Text);
                }
                catch
                {
                    Saldo = 0;
                }


                    try
                    {
                        int Operador;

                        string ClasePasaje = "";



                        string Nombre = persona.NOMBRE;
                        string Apellido = persona.APELLIDO;
                        string Dni = persona.NUM_DOC;
                        string fechaNacimiento = this.srvDatosSocio.CAB.FechaNac;
                   
                        string Telefono = this.srvDatosSocio.CAB.Telefonos;

                        decimal Pago = decimal.Parse(lblSaldoTotal.Text);

                        hotel_Dias_Utils.ProcesarDias(Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), Int32.Parse(srvDatosSocio.CAB.NroDepTitular), cbSocial.SelectedIndex,System.DateTime.Now.Year,Int32.Parse(lbInfoDias.Text));
                        int CodInt = 0;
                        if (VGlobales.vp_role.Contains("TURISMO"))
                            CodInt = 1001;
                        else
                            CodInt = 1008; //Codint De Interior


                        dlog.InsertBonoTurismo(Nro_Socio_titular, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Nro_Dep_Titular, 0, dpFechaBono.Value, 0, 0, 0, Saldo + Recargo, Saldo, Recargo, Nombre, Apellido, persona.NUM_DOC, fechaNacimiento, "", Telefono, persona.MAIL, this.srvDatosSocio.CAB.AAR, this.srvDatosSocio.CAB.ACRJP1, this.srvDatosSocio.CAB.ACRJP2, this.srvDatosSocio.CAB.ACRJP3, this.srvDatosSocio.CAB.PAR, this.srvDatosSocio.CAB.PCRJP1, this.srvDatosSocio.CAB.PCRJP2, this.srvDatosSocio.CAB.PCRJP3, tbObs.Text, MotivoViaje, Operador_CSPFA, "", ClasePasaje, VGlobales.vp_username, "SOC", 0, Int32.Parse(lbInfoDias.Text), tbNroHabitacion.Text, Contralor, VGlobales.vp_role.TrimEnd().TrimStart(), CodInt, SUBCODIGO, "NO", 0, 0, "", "", "", 0, 0, Efectivo, Tarjeta_credito, Tarjeta_credito_cuotas, Tarjeta_Debito, Planilla, Planilla_Cuotas, Transferencia);

                        ID = utilsTurismo.GetMaxID(Nro_Socio_titular.ToString(), "SOC");

                                            

                        //Obtener Proximo ID_ROL
                       int  ID_ROL = utilsTurismo.GetMax_ID_ROL(VGlobales.vp_role.TrimEnd().TrimStart(), CODINT) + 1;

                        dlog.Seteo_Id_ROL(ID, ID_ROL);


                        
                        
                        //VER CODINT

                                        
                        vu.GenerarVoucher(ID, Hotel, dpDesde.Value, dpHasta.Value, Regimen, Habit, tbNroHabitacion.Text, "SOC", MotivoViaje, LATE_CHECKOUT, CHECKIN,CodInt);





                        int ID_V = vu.GetMaxID(ID);
                        ID_ROL = vu.GetMax_ID_ROL(VGlobales.vp_role.TrimEnd().TrimStart(), CodInt);

                        dlogI.Seteo_Id_ROL(ID_V, ID_ROL);
                        
                        // Grabar Pagos 
                        // HAsta no saber como lo manejamos, todavia no

                        utilsTurismo.GrabarPagos(ID, PagosBono, dpFechaBono.Value, CodInt, srvDatosSocio.CAB, Saldo + Recargo, TipoPago, SUBCODIGO, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP));

                        //Grabar Personas 
                        utilsTurismo.GrabarPersonas(ID, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), listaPersonas,VGlobales.vp_role.TrimEnd().TrimStart());

                        //Grabar Voucher si es propio
                        
                       // vu.GenerarVoucher(ID, Hotel, dpDesde.Value, dpHasta.Value, Regimen, Habit, tbNroHabitacion.Text, "SOC", MotivoViaje,LATE_CHECKOUT,CHECKIN,CodInt);
                        this.IngresoCaja(ID, Dni, Nombre, Apellido, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Int32.Parse(persona.BARRA), InfoTarjeta);
                       
                        gpDatos.Visible = false;
                        bntImprimir.Visible = true;

                        gpDatos.Enabled = false;

                        Seleccion.Enabled = false;

                        MessageBox.Show("Bono Grabado con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }



                
               
            }
        
        
        
        }

       

        private void bntImprimir_Click(object sender, EventArgs e)
        {
            string fPago = utilsTurismo.FormaPagoBono(ID);
            //if (fPago.Length > 0)
            //{
                ReporteBonoHotel rb = new ReporteBonoHotel(srvDatosSocio.CAB, dpFechaBono.Value, ID, fPago, tbObs.Text, Decimal.Parse(lblSaldoTotal.Text));
                rb.ShowDialog();
                rb.Focus();
            //}
            //else
            //{
            //    MessageBox.Show("Debe Agregar Pago del Bono para Impresion!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
        
       
            ReporteBonoVoucher rb = new ReporteBonoVoucher(ID);
            rb.ShowDialog();
            rb.Focus();
          
        }

        private void chkBonoSocial_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBonoSocial.Checked)
            {
                Grabar.Visible            =  true;
                fpago.Text                = "PAGO SOCIAL";
                pagBono.Visible           = false;
                cbSocial.Visible          = true;
                lnkDisponibilidad.Visible = true;
                bntImprimir.Visible       = false;
                AnularBono.Visible        = false;

                lnkDisponibilidad.Text = hotel_Dias_Utils.ConsultarDias(Int32.Parse(this.srvDatosSocio.CAB.NroSocioTitular), Int32.Parse(this.srvDatosSocio.CAB.NroDepTitular), System.DateTime.Now.Year);


            }
            else
            {
                Grabar.Visible  = false;
                pagBono.Visible = true;
                cbSocial.Visible = false;
                lnkDisponibilidad.Visible = false;
                lnkDisponibilidad.Text = "";
            }
        }

        private void dpDesde_ValueChanged(object sender, EventArgs e)
        {
            this.Dias();
        }

        private void Deselecionar_Click(object sender, EventArgs e)
        {
            this.GrillaPersonas_Habilitados(true);
            gpDatos.Visible = false;
            Deselecionar.Visible = false;
            Seleccion.Enabled = true;
        }

        private void Dias()


        {

            DateTime fecha1 = new DateTime(dpDesde.Value.Year, dpDesde.Value.Month, dpDesde.Value.Day, 0, 0, 0);
            DateTime fecha2 = new DateTime(dpHasta.Value.Year, dpHasta.Value.Month, dpHasta.Value.Day, 0, 0, 0);
            int Dias = (fecha2 - fecha1).Days;
            lbInfoDias.Text = Dias.ToString();
            
            if (Dias >= 1)
            {

               // this.Seteo_aranceles();
                decimal Total = Total_MontosSinArancel();

                lblSaldoTotal.Text = Decimal.Parse((Total * Dias).ToString("0.##")).ToString();
            }
        
        }

        private decimal Total_MontosSinArancel()
        {
            decimal MONTO_Socio        =0;
            decimal MONTO_Invitado     =0;
            decimal MONTO_InterCirculo =0;
            decimal totalSocio=0;
            decimal totalInvi =0;
            decimal totalInter=0;
            if (tbSocios.Text.Length > 0)
               MONTO_Socio  = decimal.Parse( tbSocios.Text);
            if (tbInterCirculo.Text.Length  >0)
                MONTO_InterCirculo = decimal.Parse(tbInterCirculo.Text);
            if (tbInvitado.Text.Length >0)
                MONTO_Invitado = decimal.Parse(tbInvitado.Text);


            if (cbHabitacion.Text.ToUpper().Contains("PERSONA"))
            {
                return Decimal.Round(MONTO_Socio + MONTO_InterCirculo + MONTO_Invitado, 2);
            }
            else
            {
                this.CalcularCantidadSociosGrupo("HOTEL");


                 totalSocio = (MONTO_Socio * Socios) + (Decimal.Round(MONTO_Socio / 2, 2) * MenorSocio);
                totalInter = MONTO_InterCirculo * Intercirculo + (Decimal.Round(MONTO_InterCirculo / 2, 2) * MenorInter);
                 totalInvi = MONTO_Invitado * Invitado + (Decimal.Round(MONTO_Invitado / 2, 2) * MenorInvitado);
            }
            return totalSocio + totalInter + totalInvi;
            

        }

        
        private void personaMode_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void tbSocios_TextChanged(object sender, EventArgs e)
        {
            this.DefinirSaldoTotal();
            this.Dias();
        }


        private void DefinirSaldoTotal()

        {
            decimal Socio = 0;
            decimal Invi = 0;
            decimal Inter = 0;

            if (tbSocios.Text.Length > 0)
            {
                Socio = decimal.Parse(tbSocios.Text);

            }
            else
                Socio = 0;

            if (tbInvitado.Text.Length > 0)
            {
                Invi = decimal.Parse(tbInvitado.Text);

            }
            else
                Invi = 0;


            if (tbInterCirculo.Text.Length > 0)
            {
                Inter = decimal.Parse(tbInterCirculo.Text);

            }
            else
                Inter = 0;


            lblSaldoTotal.Text =Decimal.Round(  Socio + Invi + Inter,2).ToString();


        }

        private void tbInvitado_TextChanged(object sender, EventArgs e)
        {
            this.DefinirSaldoTotal();
            this.Dias();
        }

        private void tbInterCirculo_TextChanged(object sender, EventArgs e)
        {
            this.Dias();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void lnkInfoHabitacion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(InfoValorHabitacion);
        }

        private void lbCartelHabitacion_Click(object sender, EventArgs e)
        {

        }

        private void UpdateCombo_ComisionDirectiva()
        {

            string Query = @"select ID, (CARGO ||'  '  || NOMBRE) CARGO   from comision_directiva  ";
            cbComisionDirectiva.DataSource = null;
            cbComisionDirectiva.Items.Clear();
            cbComisionDirectiva.DataSource = dlog.BO_EjecutoDataTable(Query);
            cbComisionDirectiva.DisplayMember = "CARGO";
            cbComisionDirectiva.ValueMember = "ID";
            cbComisionDirectiva.SelectedItem = 1;
        }


        private bool Apto_Autorizacion()
        {
            bool retorno = true;
            if (!VGlobales.vp_role.Contains("ADM"))
            {
                retorno = false;
                lbComisionDirectiva.Visible = false;
                cbComisionDirectiva.Visible = false;
            }
            else
            {

                lbComisionDirectiva.Visible = true;
                cbComisionDirectiva.Visible = true;
                UpdateCombo_ComisionDirectiva();

            }

            return retorno;


        }

        private void cbFilial_CheckedChanged(object sender, EventArgs e)
        {
            this.Vista_Filial();
        }

        private void Vista_Filial()

        {

            if (cbFilial.Checked)
            {
                lbFilial.Visible = true;
                comboFilial.Visible = true;
                tbReciboFilial.Visible = true;
                cbAfip.Visible = true;
                cbRecibo.Visible = true;
                lbPtoVta.Visible = true;
                titPtoVta.Visible = true;

            }
            else
            {
                lbFilial.Visible = false;
                comboFilial.Visible = false;
                tbReciboFilial.Visible = false;
                cbAfip.Visible = false;
                cbRecibo.Visible = false;
                lbPtoVta.Visible = false;
                titPtoVta.Visible = false;
            }
        }

        private void comboFilial_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Vista_Filial();
            this.Setear_Punto_Venta();
        }

       

        private void cbRecibo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRecibo.Checked)
            {
                cbAfip.Checked = false;
            }
            else
            {
                cbAfip.Checked = true;
            }
            this.Setear_Punto_Venta();
        }

        private void cbAfip_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAfip.Checked)
            {
                cbRecibo.Checked = false;
            }
            else
            {
                cbRecibo.Checked = true;
            }

            this.Setear_Punto_Venta();
        }

        private void Setear_Punto_Venta()
        {
            try
            {
                int Filial = Int32.Parse(comboFilial.SelectedValue.ToString());
                bool Afip=true;
                if (cbAfip.Checked)
                    Afip = true;
                else
                    Afip = false;
          
                this.Setear_Punto_Venta(Filial, Afip);
                
            }
            catch
            { 
            }
        }

        private void Setear_Punto_Venta(int Filial, bool Afip)

        {
            
                lbPtoVta.Text = utilsTurismo.Punto_Venta_Filial(Filial, Afip).ToString();
           
        
        }

        private void lnkDisponibilidad_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Disponibilidad_Dias dd = new Disponibilidad_Dias(Nro_Socio_titular, Nro_Dep_Titular,System.DateTime.Now.Year);
            dd.ShowDialog();
        }
            
            

    }
}
