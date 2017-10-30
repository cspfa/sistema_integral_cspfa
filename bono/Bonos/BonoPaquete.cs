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
        bo dlog = new bo();
        public DatoSocio persona = new DatoSocio();
        SOCIOS.Turismo.TurismoUtils utilsTurismo;
        List<Pasaje> pasajes = new List<Pasaje>();
        int Inicio;
     
        string formaPago;
        int ID=0;
        int TipoPago;
        SOCIOS.Turismo.FormSalida fs;
        SOCIOS.Turismo.Salida salida;
        decimal Recargo = 0;
     
 
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


            gpDatos.Enabled = true;
            InfoPaquete.Enabled = true;
            Seleccion.Enabled = true;
                        

           
            
            foreach (DatoSocio d in Datos)
            {
                persona = d;
                

            }
           
            Inicio = 1;

            utilsTurismo.ComboSalida(cbPaquete);
            
        
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



                PagoBonos pb = new PagoBonos(0, "TURISMO", Saldo, true, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), Int32.Parse(srvDatosSocio.CAB.NroDepTitular), 0, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), srvDatosSocio.CAB.NroBeneficioTitular);

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
            this.GrillaPersonas_Habilitados(false);
            fs = new SOCIOS.Turismo.FormSalida(Int32.Parse(cbPaquete.SelectedValue.ToString()));
            Deseleccionar.Visible = true;
            Seleccion.Enabled = false;
            if (fs != null)

            {
                gpDatos.Visible = true;
                this.SeteoValorPaquete();
            
            }
        }


        private void SeteoValorPaquete()

        {
           int numeroSalida = Int32.Parse(cbPaquete.SelectedValue.ToString() );
           decimal totalSocio = 0;
           decimal totalInter = 0;
           decimal totalInvi = 0;
           decimal totalMenor = 0;
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

        }

        private void TotalizarTipo(TextBox tb, int Cantidad, decimal Monto,decimal Total)
        {
            if (Total != 0)
               tb.Text = (Cantidad * Monto).ToString("0.##");
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


                        dlog.InsertBonoTurismo(Nro_Socio_titular, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Nro_Dep_Titular, 0, dpFechaBono.Value, 0, 0, 0,Decimal.Round( Saldo + Recargo,2),Saldo,Recargo, Nombre, Apellido, persona.NUM_DOC, fechaNacimiento, "", Telefono, persona.MAIL, this.srvDatosSocio.CAB.AAR, this.srvDatosSocio.CAB.ACRJP1, this.srvDatosSocio.CAB.ACRJP2, this.srvDatosSocio.CAB.ACRJP3, this.srvDatosSocio.CAB.PAR, this.srvDatosSocio.CAB.PCRJP1, this.srvDatosSocio.CAB.PCRJP2, this.srvDatosSocio.CAB.PCRJP3, tbObs.Text, fpago.Text, Operador, TipoPasaje, ClasePasaje, VGlobales.vp_username, "PAQ", salida.ID, 0, "",Contralor);
                        ID = utilsTurismo.GetMaxID(Nro_Socio_titular.ToString(), "PAQ");
                        //VER CODINT
                      
                            int CodInt = 0;
                            // Grabar Pagos
                            utilsTurismo.GrabarPagos(ID, PagosBono, dpFechaBono.Value, CodInt, srvDatosSocio.CAB, Saldo + Recargo,TipoPago);
                            //Grabar Personas 
                            utilsTurismo.GrabarPersonas(ID, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), listaPersonas,"TURISMO");

                            this.IngresoCaja(ID, Dni, Nombre, Apellido, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Int32.Parse(persona.BARRA),InfoTarjeta);
                            gpDatos.Visible = false;
                            bntImprimir.Visible = true;
                            gpDatos.Enabled = false;
                            InfoPaquete.Enabled = false;
                            Seleccion.Enabled = true;
                        
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
            gpDatos.Visible = false;
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
        
       

        

        
     
        


    }



}
