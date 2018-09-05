using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.bono
{
  
    public partial class BonoPaquete : Bono
    {
        bo_Turismo dlog = new bo_Turismo();
        public DatoSocio persona = new DatoSocio();
        SOCIOS.Turismo.TurismoUtils utilsTurismo;
        List<Pasaje> pasajes = new List<Pasaje>();
        int Inicio;
     
        string formaPago;
        public int ID=0;
        int TipoPago;
        SOCIOS.Turismo.FormSalida fs;
        SOCIOS.Turismo.Salida salida;
        decimal Recargo = 0;
        int CODINT = 0;
        int SUBCODIGO = 0;
        DateTime Fecha_Salida;
        bool Autorizacion;
        public bool BONO_BLANCO = false;
     
 
        public BonoPaquete(DataGridViewSelectedRowCollection Personas, string pSocTitular, string pdepTitular,bool pMuestro): base(Personas, pSocTitular, pdepTitular,pMuestro)
        {
            Inicio = 1;
            InitializeComponent();
            utilsTurismo = new SOCIOS.Turismo.TurismoUtils();
            this.Iniciar();
        }

        private void tbObs_TextChanged(object sender, EventArgs e)
        {

        }


        private void Iniciar()

        {


            comboFilial.Enabled = true;
            InfoPaquete.Enabled = true;
            Seleccion.Enabled = true;
                        

           
            
            foreach (DatoSocio d in Datos)
            {
                persona = d;
                

            }
           
            Inicio = 1;

            utilsTurismo.ComboSalida(cbPaquete);
            utilsTurismo.UpdateComboTabla("TURISMO_FILIALES", combo_Filial);
            CODINT = Int32.Parse(Config.getValor("TURISMO", "COD_TURISMO", 0));
            Autorizacion = Apto_Autorizacion();
        
        }

        private void pagBono_Click(object sender, EventArgs e)
        {
            try
            {
                decimal Saldo;
                if (lbSaldoTotal.Text.Length == 0)
                    Saldo = 0;
                else
                    Saldo = Decimal.Parse(lbSaldoTotal.Text);



                PagoBonos pb = new PagoBonos(0, "TURISMO", Saldo, true, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), Int32.Parse(srvDatosSocio.CAB.NroDepTitular), 0, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), srvDatosSocio.CAB.NroBeneficioTitular,Fecha_Salida);

                DialogResult res = pb.ShowDialog();

                if (res == DialogResult.OK)
                {
                    //lbFormaPago.Text = pb.formaPago;
                    PagosBono = pb.Pagos;
                    fpago.Text = pb.formaPago;
                    TipoPago = pb.tipoPago;
                    SaldoIngreso = pb.SaldoIngreso;
                    Contralor = pb.NumeroContraLor;
                    Recargo   = pb.Recargo;
                    InfoTarjeta = pb.InfoTarjeta;
                    Grabar.Visible = true;
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbPaquete_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void lbSocios_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbInvitados_Click(object sender, EventArgs e)
        {

        }

       

        private void InfoPaquete_Click(object sender, EventArgs e)
        {
            fs = new SOCIOS.Turismo.FormSalida(Int32.Parse(cbPaquete.SelectedValue.ToString()));
            fs.ShowDialog();

        }

        private void Seleccion_Click(object sender, EventArgs e)
        {
            try
            {
                this.GrillaPersonas_Habilitados(false);
                fs = new SOCIOS.Turismo.FormSalida(Int32.Parse(cbPaquete.SelectedValue.ToString()));
                Deseleccionar.Visible = true;
                Seleccion.Enabled = false;
                if (fs != null)
                {
                    comboFilial.Visible = true;

                    this.SeteoValorPaquete();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void SeteoValorPaquete()

        {
           int numeroSalida = Int32.Parse(cbPaquete.SelectedValue.ToString() );
           decimal totalSocio = 0;
           decimal totalInter = 0;
           decimal totalInvi = 0;
           decimal totalMenor = 0;
           decimal CocheCama = 0;
           tbSocios.Text = "0";
           tbInvitados.Text = "0";
           tbMenor.Text = "0";
           tbInterCirculo.Text = "0";


           salida = utilsTurismo.GetSalida(numeroSalida);

           this.CalcularCantidadSociosGrupo("PAQUETE");
           //04-09-2017 se calculan los menores aparte, por lo cual no se cuentan como socios 
           totalSocio = salida.Socio * (Socios - MenorPaquete);
           totalInter = salida.InterCirculo * Intercirculo;
           totalInvi = salida.Invitado * Invitado;
           totalMenor = salida.Menor * MenorPaquete;

       
           this.TotalizarTipo(tbSocios, Socios, salida.Socio, totalSocio);
           this.TotalizarTipo(tbInterCirculo, Intercirculo, salida.InterCirculo, totalInter);
           this.TotalizarTipo(tbInvitados, Invitado, salida.Invitado, totalInvi);
           this.TotalizarTipo(tbMenor, MenorPaquete, salida.Menor, totalMenor);

           lbSaldoTotal.Text = (totalInvi + totalSocio + totalInter + totalMenor).ToString("0.##");
          
           infoInter.Text = salida.InterCirculo.ToString("0.##");
           InfoInvi.Text = salida.Invitado.ToString("0.##");
           InfoMenor.Text = salida.Menor.ToString("0.##");
           infoSocio.Text = salida.Socio.ToString("0.##");
           Fecha_Salida = salida.Fecha;
                      
            if (cbCocheCama.Checked)
               lbLeyendaCocheCama.Visible = true;
           else
               lbLeyendaCocheCama.Visible = false;

            // Inicializo el punto de venta
            cbRecibo.Checked = true;
            this.Setear_Punto_Venta(1, false);



        }

        private void TotalizarTipo(TextBox tb, int Cantidad, decimal Monto,decimal Total)
        {
            decimal CocheCama=0;

            if (cbCocheCama.Checked)
            {
                CocheCama = salida.Coche_Cama;
            }
            
            if (Total != 0)
               tb.Text = (Cantidad * (Monto+CocheCama)).ToString("0.##");
            else
                tb.Text ="";
        }

        private void Grabar_Click(object sender, EventArgs e)
        {

            salida = utilsTurismo.GetSalida(Int32.Parse(cbPaquete.SelectedValue.ToString()));
            if (MessageBox.Show("Generar Bono de " + salida.Nombre  + " Salida , Forma de Pago : " + fpago.Text, "Confirmacion ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                decimal Saldo = decimal.Parse(lbSaldoTotal.Text);
                if (Saldo != 0)
                {


                    try
                    {
                        int Operador;
                        string TipoPasaje  = salida.Tipo_Nombre;
                        string ClasePasaje= "";

                        if (salida.Operador != null)
                            Operador = salida.Operador;
                        else
                            Operador = 0;

                        if (salida.Traslado_Nombre != null)
                            TipoPasaje = salida.Traslado_Nombre;
                        else
                            TipoPasaje = "";
                        string Nombre = this.srvDatosSocio.CAB.NOMBRE;
                        string Apellido = this.srvDatosSocio.CAB.APELLIDO;
                        string Dni = this.srvDatosSocio.CAB.Dni;
                        string fechaNacimiento = this.srvDatosSocio.CAB.FechaNac;
                  
                        string Telefono = this.srvDatosSocio.CAB.Telefonos;
                        
                        decimal Pago = decimal.Parse(lbSaldoTotal.Text);
                        int Comision_Directiva = 0;

                        if (Autorizacion)
                            Comision_Directiva = Int32.Parse(cbComisionDirectiva.SelectedValue.ToString());
                        else
                            Comision_Directiva = 0;


                        string NRO_RECIBO_FILIAL = "";
                        int FILIAL = 0;
                        string NRO_FACTURA_FILIAL = "";
                        string PUNTO_VENTA = "";

                        if (cbFilial.Checked)
                        {
                            NRO_RECIBO_FILIAL = tbReciboFilial.Text;
                            NRO_FACTURA_FILIAL = tbReciboFilial.Text;
                            FILIAL = Int32.Parse(combo_Filial.SelectedValue.ToString());
                            PUNTO_VENTA = lbPtoVta.Text;
                            // si es comprobante afip, va vacio el recibo, y viceversa
                            if (cbAfip.Checked)
                            {
                                NRO_RECIBO_FILIAL = "";
                            }
                            else
                                NRO_FACTURA_FILIAL = "";

                        }





                        if (BONO_BLANCO) // Si es bono_Blanco, Vamos por UPDATE
                        {
                            dlog.UpdateBonoTurismo(ID, Nro_Socio_titular, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Nro_Dep_Titular, 0, dpFechaBono.Value, 0, 0, 0, Decimal.Round(Saldo + Recargo, 2), Saldo, Recargo, Nombre, Apellido, persona.NUM_DOC, fechaNacimiento, "", Telefono, persona.MAIL, this.srvDatosSocio.CAB.AAR, this.srvDatosSocio.CAB.ACRJP1, this.srvDatosSocio.CAB.ACRJP2, this.srvDatosSocio.CAB.ACRJP3, this.srvDatosSocio.CAB.PAR, this.srvDatosSocio.CAB.PCRJP1, this.srvDatosSocio.CAB.PCRJP2, this.srvDatosSocio.CAB.PCRJP3, tbObs.Text, fpago.Text, Operador, "", ClasePasaje, VGlobales.vp_username, "HOT", 0,0,"", Contralor, VGlobales.vp_role.TrimEnd().TrimStart(), CODINT, SUBCODIGO, "NO", Comision_Directiva,FILIAL,NRO_RECIBO_FILIAL,NRO_FACTURA_FILIAL,PUNTO_VENTA);

                        }
                        else // si no es bono blanco, previo, no existe en la base, es INSERT
                        {
                            dlog.InsertBonoTurismo(Nro_Socio_titular, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Nro_Dep_Titular, 0, dpFechaBono.Value, 0, 0, 0, Decimal.Round(Saldo + Recargo, 2), Saldo, Recargo, Nombre, Apellido, persona.NUM_DOC, fechaNacimiento, "", Telefono, persona.MAIL, this.srvDatosSocio.CAB.AAR, this.srvDatosSocio.CAB.ACRJP1, this.srvDatosSocio.CAB.ACRJP2, this.srvDatosSocio.CAB.ACRJP3, this.srvDatosSocio.CAB.PAR, this.srvDatosSocio.CAB.PCRJP1, this.srvDatosSocio.CAB.PCRJP2, this.srvDatosSocio.CAB.PCRJP3, tbObs.Text, fpago.Text, Operador, TipoPasaje, ClasePasaje, VGlobales.vp_username, "PAQ", salida.ID, 0, "", Contralor, VGlobales.vp_role.TrimEnd().TrimStart(), CODINT, SUBCODIGO, "NO", Comision_Directiva,FILIAL,NRO_RECIBO_FILIAL,NRO_FACTURA_FILIAL,PUNTO_VENTA,0,0);
                       
                            ID = utilsTurismo.GetMaxID(Nro_Socio_titular.ToString(), "PAQ");
                        //Obtener Proximo ID_ROL
                        int ID_ROL = utilsTurismo.GetMax_ID_ROL(VGlobales.vp_role.TrimEnd().TrimStart(), CODINT) + 1;

                        dlog.Seteo_Id_ROL(ID, ID_ROL);
                        }
                            int CodInt = 0;
                            // Grabar Pagos
                            utilsTurismo.GrabarPagos(ID, PagosBono, dpFechaBono.Value, CodInt, srvDatosSocio.CAB, Saldo + Recargo,TipoPago,SUBCODIGO);
                            //Grabar Personas 
                            utilsTurismo.GrabarPersonas(ID, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), listaPersonas,"TURISMO");
                            if (cbFilial.Checked==false)
                                this.IngresoCaja(ID, Dni, Nombre, Apellido, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Int32.Parse(persona.BARRA),InfoTarjeta);
                            comboFilial.Visible = false;
                            bntImprimir.Visible = true;
                            comboFilial.Enabled = false;
                            InfoPaquete.Enabled = false;
                            Seleccion.Enabled = true;
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

        private void dpFechaBono_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AnularBono_Click(object sender, EventArgs e)
        {
            
        }

        private void bntImprimir_Click(object sender, EventArgs e)
        {

            this.ImprimirBono();
        }

        private void ImprimirBono()
        {
            string fPago = utilsTurismo.FormaPagoBono(ID);
            if (fPago.Length > 0)
            {
                ReporteBonoPaquete rb = new ReporteBonoPaquete(srvDatosSocio.CAB, dpFechaBono.Value, ID, fPago, tbObs.Text, Decimal.Parse(lbSaldoTotal.Text),salida.ID);
                rb.ShowDialog();
                rb.Focus();
            }
            else
            {
                MessageBox.Show("Debe Agregar Pago del Bono para Impresion!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void BonoPaquete_Load(object sender, EventArgs e)
        {

        }

        private void Deseleccionar_Click(object sender, EventArgs e)
        {
            this.GrillaPersonas_Habilitados(true);
            comboFilial.Visible = false;
            Deseleccionar.Visible = false;
            Seleccion.Enabled = true;

        }

        private void tbSocios_TextChanged(object sender, EventArgs e)
        {
            this.CalculoTotal();
        }

        private void CalculoTotal()

        { 
            decimal Socios=0;
            decimal Inter =0;
            decimal Invi  =0;
            decimal Menor =0;

            if (tbSocios.Text.Length > 0)
                Socios = Decimal.Parse(tbSocios.Text);

            if (tbInterCirculo.Text.Length > 0)
                Inter = Decimal.Parse(tbInterCirculo.Text);

            if (tbInvitados.Text.Length > 0)
                Invi = Decimal.Parse(tbInvitados.Text);

            if (tbMenor.Text.Length > 0)
                Menor = Decimal.Parse(tbMenor.Text);

            lbSaldoTotal.Text = Decimal.Round(Socios + Inter + Invi + Menor, 2).ToString();
        }

        private void tbInvitados_TextChanged(object sender, EventArgs e)
        {
            this.CalculoTotal();
        }

        private void tbInterCirculo_TextChanged(object sender, EventArgs e)
        {
            this.CalculoTotal();
        }

        private void tbMenor_TextChanged(object sender, EventArgs e)
        {
            this.CalculoTotal();
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
            if (cbFilial.Checked)
            {
                lbFilial.Visible = true;
              combo_Filial.Visible = true;
                tbReciboFilial.Visible = true;
                lbPtoVta.Visible = true;
                cbAfip.Visible = true;
                cbRecibo.Visible = true;
                titPtoVenta.Visible = true;

            }
            else
            {
                lbFilial.Visible = false;
                combo_Filial.Visible = false;
                tbReciboFilial.Visible = false;
                lbPtoVta.Visible = false;
                cbAfip.Visible = false;
                cbRecibo.Visible = false;
                titPtoVenta.Visible = false;
            }
        }

        private void lbFilial_Click(object sender, EventArgs e)
        {

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
                int Filial = Int32.Parse(combo_Filial.SelectedValue.ToString());
                bool Afip = true;
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

        private void combo_Filial_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Setear_Punto_Venta();
        }
            











    }



}
