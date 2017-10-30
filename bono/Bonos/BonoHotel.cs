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


namespace SOCIOS.bono
{
    public partial class BonoHotel : SOCIOS.bono.Bono
    {
        bo dlog = new bo();
        SOCIOS.Turismo.TurismoUtils utilsTurismo = new TurismoUtils();
        SOCIOS.arancel arancelService = new arancel();
        public DatoSocio persona = new DatoSocio();
        int Inicio;
        int ID;
        bool Social;
        int TipoPago;
        decimal Recargo=0;
        VoucherUtils vu = new VoucherUtils();
        Hotel_Dias_Utils hotel_Dias_Utils = new Hotel_Dias_Utils();
        string InfoValorHabitacion = "";
        public BonoHotel()
        {
        
        }

         public BonoHotel(DataGridViewSelectedRowCollection Personas, string pSocTitular, string pdepTitular,bool pMuestro): base(Personas, pSocTitular, pdepTitular,pMuestro)
        {
            InitializeComponent();
            this.Iniciar();
        
        }


         private void Iniciar()
         {


             gpDatos.Enabled = true;

             Seleccion.Enabled = true;




             foreach (DatoSocio d in Datos)
             {
                 persona = d;


             }

             Inicio = 1;

             UpdateComboHabitacion();
             UpdateComboHotel();
             UpdateComboSocial();
             utilsTurismo.UpdateComboTabla("TURISMO_REGIMEN", cbRegimen);

             if (srvDatosSocio.CAB.Telefonos.Length > 0)
                 tbContacto.Text = srvDatosSocio.CAB.Telefonos;


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

            cbSocial.Items.Insert((int)Hotel_Social_Enum.TRAMITE   , "Tramite");
            cbSocial.Items.Insert((int)Hotel_Social_Enum.ENFERMEDAD , "Enfermedad");
            cbSocial.Items.Insert((int)Hotel_Social_Enum.CIRUGIA   , "Cirugia");
            cbSocial.SelectedValue = "1";
         
        
        
        }

        private void Seleccion_Click(object sender, EventArgs e)
        {



            this.Seteo_aranceles();

          

        }

        private void Seteo_aranceles()


        {

            try
            {

                decimal Arancel = 0;
                lbMenores.Text = "";
                lbMenores.Visible = false;

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

                if (Arancel < 9999)
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
                    gpDatos.Visible = false;

                    throw new Exception("No se Ecuentra Arancel Cargado");
                }






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
            totalSocio =   arancelService.valorGrupoHotel(hotel, 1, regimen, habitacion);
           
                tbSocios.Text =   decimal.Round(totalSocio, 2).ToString();
           

            }
            else if (Intercirculo > 0)
            {
         
                totalInter = arancelService.valorGrupoHotel(hotel, 2, regimen, habitacion);
                tbInterCirculo.Text =   totalInter.ToString("0.##");
            }
            else
            {

                totalInvi = arancelService.valorGrupoHotel(hotel, 3, regimen, habitacion);
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



                PagoBonos pb = new PagoBonos(0, "TURISMO", Saldo, true, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), Int32.Parse(srvDatosSocio.CAB.NroDepTitular), 0, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), srvDatosSocio.CAB.NroBeneficioTitular);

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


                        dlog.InsertBonoTurismo(Nro_Socio_titular, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Nro_Dep_Titular, 0, dpFechaBono.Value, 0, 0, 0, Decimal.Round(Saldo + Recargo, 2), Saldo, Recargo, Nombre, Apellido, persona.NUM_DOC, fechaNacimiento, "", Telefono, persona.MAIL, this.srvDatosSocio.CAB.AAR, this.srvDatosSocio.CAB.ACRJP1, this.srvDatosSocio.CAB.ACRJP2, this.srvDatosSocio.CAB.ACRJP3, this.srvDatosSocio.CAB.PAR, this.srvDatosSocio.CAB.PCRJP1, this.srvDatosSocio.CAB.PCRJP2, this.srvDatosSocio.CAB.PCRJP3, OBS, fpago.Text, Operador_CSPFA, "", ClasePasaje, VGlobales.vp_username, "HOT", 0, Int32.Parse(lbInfoDias.Text), tbNroHabitacion.Text, Contralor);
                       
                        ID = utilsTurismo.GetMaxID(Nro_Socio_titular.ToString(), "HOT");
                        //VER CODINT


                        int CodInt = 0;
                        // Grabar Pagos
                        utilsTurismo.GrabarPagos(ID, PagosBono, dpFechaBono.Value, CodInt, srvDatosSocio.CAB, Saldo + Recargo,TipoPago);
                        //Grabar Personas 
                        utilsTurismo.GrabarPersonas(ID, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), listaPersonas,"TURISMO");
                                                  
                     
                        
                            vu.GenerarVoucher(ID, Hotel, dpDesde.Value, dpHasta.Value, Regimen, Habit, tbNroHabitacion.Text,"HOT","");
                        
                        gpDatos.Visible = false;
                        bntImprimir.Visible = true;

                        gpDatos.Enabled = false;

                        Seleccion.Enabled = false;

                        this.IngresoCaja(ID,Dni,Nombre,Apellido,Int32.Parse(persona.NRO_SOCIO),Int32.Parse(persona.NRO_DEP),Int32.Parse(persona.BARRA),InfoTarjeta);

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

                        hotel_Dias_Utils.ProcesarDias(Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), Int32.Parse(srvDatosSocio.CAB.NroDepTitular), cbSocial.SelectedIndex,Int32.Parse(lbInfoDias.Text));



                        dlog.InsertBonoTurismo(Nro_Socio_titular, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Nro_Dep_Titular, 0, dpFechaBono.Value, 0, 0, 0,Saldo + Recargo,Saldo,Recargo, Nombre, Apellido, persona.NUM_DOC, fechaNacimiento, "", Telefono, persona.MAIL, this.srvDatosSocio.CAB.AAR, this.srvDatosSocio.CAB.ACRJP1, this.srvDatosSocio.CAB.ACRJP2, this.srvDatosSocio.CAB.ACRJP3, this.srvDatosSocio.CAB.PAR, this.srvDatosSocio.CAB.PCRJP1, this.srvDatosSocio.CAB.PCRJP2, this.srvDatosSocio.CAB.PCRJP3, tbObs.Text, MotivoViaje, Operador_CSPFA, "", ClasePasaje, VGlobales.vp_username, "SOC", 0, Int32.Parse(lbInfoDias.Text), tbNroHabitacion.Text,Contralor);

                        ID = utilsTurismo.GetMaxID(Nro_Socio_titular.ToString(), "SOC");
                        //VER CODINT


                        int CodInt = 0;
                        // Grabar Pagos 
                        // HAsta no saber como lo manejamos, todavia no

                       // utilsTurismo.GrabarPagos(ID, PagosBono, dpFechaBono.Value, CodInt, srvDatosSocio.CAB, Saldo);

                        //Grabar Personas 
                        utilsTurismo.GrabarPersonas(ID, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), listaPersonas,"TURISMO");

                        //Grabar Voucher si es propio


                        vu.GenerarVoucher(ID, Hotel, dpDesde.Value, dpHasta.Value, Regimen, Habit, tbNroHabitacion.Text, "SOC", MotivoViaje);
                        
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

                lnkDisponibilidad.Text    = hotel_Dias_Utils.ConsultarDias(Int32.Parse(this.srvDatosSocio.CAB.NroSocioTitular), Int32.Parse(this.srvDatosSocio.CAB.NroDepTitular));


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
            

    }
}
