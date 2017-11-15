using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.bono
{
  
    public partial class BonoPasaje : Bono
    {
        bo dlog = new bo();
        public DatoSocio persona = new DatoSocio();
        SOCIOS.Turismo.TurismoUtils utilsTurismo;
        List<Pasaje> pasajes = new List<Pasaje>();
        int Inicio;
        List<PagoBono> PagosBono;
        int TipoPago;
        string formaPago;
        int ID=0;
        decimal Recargo = 0;
        int CODINT=0;
        int SUBCODIGO=0;
 
        public BonoPasaje(DataGridViewSelectedRowCollection Personas, string pSocTitular, string pdepTitular,bool pMuestro): base(Personas, pSocTitular, pdepTitular,pMuestro)
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


            MostrarControles(true);

            gpDatos.Visible = false;
            gpPasaje.Visible = false;
            
            foreach (DatoSocio d in Datos)
            {
                persona = d;
                

            }
            rbMicro.Checked = true;
            rbAereo.Checked = false;
            Inicio = 1;
            utilsTurismo.UpdateComboProvincia(0,cbProvinciaDesde);
            utilsTurismo.UpdateComboProvincia(0, cbProvinciaHasta);
            this.ComboTipo();
            utilsTurismo.ComboOperador(cbEmpresa,true);
            lbSaldoTotal.Text = "0";

            CODINT = Int32.Parse(Config.getValor("TURISMO","COD_TURISMO", 2));

         
            
        
        }

        private void ComboTipo()

        {
            //List<SOCIOS.admDeportes.ItemCombo> lista = new List<SOCIOS.admDeportes.ItemCombo>();

            //lista.Add(new SOCIOS.admDeportes.ItemCombo(1,"CAMA"));
            //lista.Add(new SOCIOS.admDeportes.ItemCombo(2, "SEMI-CAMA"));
            //lista.Add(new SOCIOS.admDeportes.ItemCombo(3, "AEREO"));
            //lista.Add(new SOCIOS.admDeportes.ItemCombo(4, "EJECUTIVO"));
            //lista.Add(new SOCIOS.admDeportes.ItemCombo(5, "SUITE"));
            //cbTipoViaje.Items.Clear();
            //cbTipoViaje.DisplayMember = "Texto";
            //cbTipoViaje.ValueMember = "ID";
            //cbTipoViaje.DataSource = lista;
            //cbTipoViaje.SelectedItem = 1;


            utilsTurismo.UpdateComboTabla("TURISMO_TRASLADO", cbTipoViaje);

        
        }
       

        private void btnMicro_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMicro.Checked)
                rbAereo.Checked = false;
            else
                rbAereo.Checked = true;
        }

        private void rbAereo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAereo.Checked)
                rbMicro.Checked = false;
            else
                rbMicro.Checked = true;
        }

        private void cbProvinciaDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Inicio == 0 && cbProvinciaDesde.SelectedItem != null)
            {
                cbLocalidadDesde.DataSource = null;
                utilsTurismo.UpdateComboLocalidad(Int32.Parse(cbProvinciaDesde.SelectedValue.ToString()), cbLocalidadDesde);
            }
        }

        private void cbLocalidadDesde_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbProvinciaHasta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Inicio == 0 && cbProvinciaHasta.SelectedItem != null)
            {
                cbLocalidadHasta.DataSource = null;
                utilsTurismo.UpdateComboLocalidad(Int32.Parse(cbProvinciaHasta.SelectedValue.ToString()), cbLocalidadHasta);
            }
        }

        private void tbCantidad_TextChanged(object sender, EventArgs e)
        {
            //lbTotal.Text = Decimal.Round(Int32.Parse(tbCantidad.Text) * Decimal.Parse(tbUnitario.Text), 2).ToString(); 
        }

        private void NuevoBank_Click(object sender, EventArgs e)
        {
            
            gpPasaje.Visible = true;
            btnAddTrat.Enabled = true;
            this.SeteoVuelta(false);
            Inicio = 0;
            tbCantidad.Text = this.CantidadTotalPersonas().ToString();
            utilsTurismo.UpdateComboLocalidad(6500, cbLocalidadDesde);
            utilsTurismo.UpdateComboLocalidad(6500, cbLocalidadHasta);
           
        }
        private void IniciarGP()
        {
            tbBoleto.Text = "";
            tbCantidad.Text = "1";
            tbUnitario.Text = "0";

            utilsTurismo.UpdateComboProvincia(6500, cbProvinciaDesde);
            utilsTurismo.UpdateComboProvincia(6500, cbProvinciaHasta);
        
        }


       

        private void btnAddTrat_Click(object sender, EventArgs e)
        {
            try
            {
                int Boleto = 0;
                int CantidadPersonas = this.CantidadTotalPersonas();

                if (Int32.Parse(tbUnitario.Text) == 0)
                    throw new Exception("El Monto Unitario de los pasajes no puede ser 0");
                
                if (MessageBox.Show("Viajan " + CantidadPersonas.ToString() + " Personas ", "Confirmacion  Personas ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tbCantidad.Text = CantidadPersonas.ToString();
                    int cantidad = Int32.Parse(tbCantidad.Text);
                    int Origen = Int32.Parse(cbLocalidadDesde.SelectedValue.ToString());
                    string OrigenText = cbLocalidadDesde.Text.ToString();
                    int Destino = Int32.Parse(cbLocalidadHasta.SelectedValue.ToString());
                    string DestinoText = cbLocalidadHasta.Text.ToString();
                    string Fecha = dpFecha.Value.ToShortDateString();
                    string FechaVuelta = dpFechaVuelta.Value.ToShortDateString();



                    utilsTurismo.checkDestinosRepetidos(Origen, Destino);

                    if (tbBoleto.Text.Length > 1)
                        Boleto = Int32.Parse(tbBoleto.Text) - 1;
                    else
                    {
                        throw new Exception("DEBE INGRESAR NRO BOLETO");
                    
                        return;


                    }

                    //Grabo las Idas 




                    for (int i = 0; i < cantidad; i++)
                    {
                        Boleto = Boleto + 1;
                        Pasaje paj = new Pasaje();
                        paj.Cantidad = 1;
                        if (Decimal.Parse(tbUnitario.Text) > 0)
                            paj.Monto = Decimal.Parse(tbUnitario.Text);
                        else
                            throw new Exception("DEBE INGRESAR MONTO MAYOR A CERO");
                          
                        paj.Origen = Origen;
                        paj.OrigenText = OrigenText.TrimEnd().TrimStart();
                        paj.Destino = Destino;
                        paj.DestinoText = DestinoText.TrimEnd().TrimStart();
                        paj.FechaSalida = Fecha.TrimEnd().TrimStart();
                        paj.NroBoleto = Boleto.ToString().TrimEnd().TrimStart();
                        pasajes.Add(paj);

                    }

                    // Grabo las Vueltas 



                    if (chkSetVuelta.Checked)
                    {
                        if (chkVuelta.Checked)
                        {
                            if (tbBoletoVuelta.Text.Length > 1)
                                Boleto = Int32.Parse(tbBoletoVuelta.Text) - 1;
                            else
                            {
                                throw new Exception("DEBE INGRESAR NRO BOLETO VUELTA");
                             
                                return;


                            }
                        }

                        for (int i = 0; i < cantidad; i++)
                        {

                            Boleto = Boleto + 1;

                            Pasaje paj = new Pasaje();



                            paj.NroBoleto = Boleto.ToString();

                            paj.Cantidad = 1;
                            if (Decimal.Parse(tbUnitario.Text) > 0)
                                paj.Monto = Decimal.Parse(tbUnitario.Text);
                            else
                                throw new Exception("DEBE INGRESAR MONTO MAYOR A CERO");
                            paj.Origen = Destino;
                            paj.OrigenText = DestinoText;
                            paj.Destino = Origen;
                            paj.DestinoText = OrigenText;

                            if (chkVuelta.Checked || chkSetVuelta.Checked)
                                paj.FechaSalida = FechaVuelta;
                            else
                                paj.FechaSalida = "";

                            pasajes.Add(paj);

                        }






                    }




                    this.ActualizarGrilla();
                    btnAddTrat.Enabled = false;
                    gpPasaje.Visible = false;
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }

        }

        private void ActualizarGrilla()

        {
            gvPasajes.DataSource = null;
            gvPasajes.DataSource = pasajes;
            gvPasajes.Refresh();
            this.SumaPasajes();

            gvPasajes.Columns[0].HeaderText = "Cant";
            gvPasajes.Columns[0].Width = 40;
           
            gvPasajes.Columns[1].HeaderText = "Boleto";
            gvPasajes.Columns[2].HeaderText = "Fecha";
            gvPasajes.Columns[4].HeaderText = "Desde";
            gvPasajes.Columns[4].Width = 40;
            gvPasajes.Columns[6].HeaderText = "Hasta";
           
            gvPasajes.Columns[3].Visible = false;
            gvPasajes.Columns[5].Visible = false;
            
            
            if (gvPasajes.Rows.Count > 0)
            {
                
                Reiniciar.Visible = true;
            }
            
         
        
        
        }

        private void SumaPasajes()
        {
            decimal suma = 0;
            foreach (Pasaje p in pasajes)
            {
                suma = suma + p.Monto;
            }

            lbSaldoTotal.Text = suma.ToString("0.##");
        
        
        }

        private void lbTotal_Click(object sender, EventArgs e)
        {

        }

        private void tbUnitario_TextChanged(object sender, EventArgs e)
        {

        }

        private void gvPasajes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grabar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Generar Bono de " + gvPasajes.RowCount.ToString() + " Pasajes , Forma de Pago : " + fpago.Text, "Confirmacion ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                decimal Saldo = decimal.Parse(lbSaldoTotal.Text);
                if (Saldo != 0)
                {


                    try
                    {
                        int Operador;
                        string TipoPasaje;
                        string ClasePasaje;
                        Operador = Int32.Parse(cbEmpresa.SelectedValue.ToString());
                        ClasePasaje =this.cbTipoViaje.Text;
                        if (rbMicro.Checked == true)
                        {
                            TipoPasaje = "MICRO";
                        }
                        else
                        {
                            TipoPasaje = "AEREO";
                        }

                        string Nombre = this.srvDatosSocio.CAB.NOMBRE;
                        string Apellido = this.srvDatosSocio.CAB.APELLIDO;
                        string Dni = this.srvDatosSocio.CAB.Dni;

                        string fechaNacimiento = this.srvDatosSocio.CAB.FechaNac;
                 
                        string Telefono = this.srvDatosSocio.CAB.Telefonos;

                        decimal Pago = decimal.Parse(lbSaldoTotal.Text) ;


                        dlog.InsertBonoTurismo(Nro_Socio_titular, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Nro_Dep_Titular, 0, dpFecha.Value, 0, 0, 0, Decimal.Round(Saldo + Recargo, 2), Saldo, Recargo, Nombre, Apellido, persona.NUM_DOC, fechaNacimiento, "", Telefono, persona.MAIL, this.srvDatosSocio.CAB.AAR, this.srvDatosSocio.CAB.ACRJP1, this.srvDatosSocio.CAB.ACRJP2, this.srvDatosSocio.CAB.ACRJP3, this.srvDatosSocio.CAB.PAR, this.srvDatosSocio.CAB.PCRJP1, this.srvDatosSocio.CAB.PCRJP2, this.srvDatosSocio.CAB.PCRJP3, tbObs.Text, fpago.Text, Operador, TipoPasaje, ClasePasaje, VGlobales.vp_username, "PAS", 0, 0, "", Contralor,VGlobales.vp_role.TrimEnd().TrimStart(),CODINT,SUBCODIGO);
                         ID = utilsTurismo.GetMaxID(Nro_Socio_titular.ToString(), "PAS");
                        //VER CODINT
                        if (ID != 0)
                        {
                            int CodInt = 0;
                            // Grabar Pagos
                            utilsTurismo.GrabarPagos(ID, PagosBono, dpFechaBono.Value, CodInt, srvDatosSocio.CAB,Saldo + Recargo,TipoPago,SUBCODIGO);
                            //Grabar Personas 
                            utilsTurismo.GrabarPersonas(ID, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), listaPersonas,"TURISMO");
                            //Grabar Pasajes
                            utilsTurismo.GrabarPasajes(ID, pasajes);

                            this.IngresoCaja(ID,Dni,Nombre,Apellido,Int32.Parse(persona.NRO_SOCIO),Int32.Parse(persona.NRO_DEP),Int32.Parse(persona.BARRA),InfoTarjeta);

                            MostrarControles(false);
                            bntImprimir.Visible = true;
                        }
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
        

        private void CancelarBank_Click(object sender, EventArgs e)
        {
            gvPasajes.DataSource = null;
            pasajes = null;
            
            this.SeteoVuelta(false);
            
        }

        private void MostrarControles(bool Mostrar)

        {
            gpDatos.Visible = Mostrar;
            gpPasaje.Visible = Mostrar;
            AccionesGrilla.Visible = Mostrar;
        
        
        }

        private void tbBoleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void btnPago_Click(object sender, EventArgs e)
        {

         
        }

        private void BonoPasaje_Load(object sender, EventArgs e)
        {
            
        }

        private void pagBono_Click(object sender, EventArgs e)
        {
            if (gvPasajes.Rows.Count == 0)
                return;
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
                        SaldoIngreso = pb.SaldoIngreso;
                        TipoPago = pb.tipoPago;
                        Contralor = pb.NumeroContraLor;
                        gpDatos.Visible = true;
                        Grabar.Visible = true;
                      
                        InfoTarjeta = pb.InfoTarjeta;
                        Recargo = pb.Recargo;
                        
                    }
                }
               
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void bntImprimir_Click(object sender, EventArgs e)
        {
            this.ImprimirBono();
        }

        private void ImprimirBono()
        {
            string fPago = FormaPagoBono();
            if (fPago.Length > 0)
            {
                ReporteBonoPasaje rb = new ReporteBonoPasaje (srvDatosSocio.CAB, dpFecha.Value, ID, fPago, tbObs.Text, Decimal.Parse(lbSaldoTotal.Text));
                rb.ShowDialog();
                rb.Focus();
            }
            else
            {
                MessageBox.Show("Debe Agregar Pago del Bono para Impresion!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private string FormaPagoBono()
        {
            string QUERY = "SELECT PAGO FROM Bono_turismo WHERE ID=" + ID.ToString(); 
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return foundRows[0][0].ToString();
            }
            else
                return "";


        }

        private void btnLocalidad_Click(object sender, EventArgs e)
        {
            SOCIOS.Turismo.AgregarLocalidad al = new SOCIOS.Turismo.AgregarLocalidad(Int32.Parse(cbProvinciaDesde.SelectedValue.ToString()));
            DialogResult dr = al.ShowDialog();

            if (dr == DialogResult.OK)
            {
                cbLocalidadDesde.DataSource = null;
                cbLocalidadHasta.DataSource = null;

                utilsTurismo.UpdateComboLocalidad(Int32.Parse(cbProvinciaDesde.SelectedValue.ToString()), cbLocalidadDesde);
                utilsTurismo.UpdateComboLocalidad(Int32.Parse(cbProvinciaHasta.SelectedValue.ToString()), cbLocalidadHasta);
            
            
            }
        }

        private void cbTipoViaje_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkSetVuelta_CheckedChanged(object sender, EventArgs e)
        {
             
            
            this.SeteoVuelta(chkSetVuelta.Checked);

          
             
            
            
            
        }

        private void SeteoVuelta(bool vista)

        {


          
            chkVuelta.Enabled      = vista;
            dpFechaVuelta.Enabled  = vista;
            tbBoleto.Text = "";
            tbBoletoVuelta.Text = "";
            tbCantidad.Text = "1";
            tbUnitario.Text = "0";

        }

        private void Reiniciar_Click(object sender, EventArgs e)
        {
            pagBono.Visible = true;
            
            chkSetVuelta.Checked = false;
            chkVuelta.Checked = false;

        }

        private void chkVuelta_CheckedChanged(object sender, EventArgs e)
        {
            tbBoletoVuelta.Enabled = chkVuelta.Checked;
            dpFechaVuelta.Enabled   = chkVuelta.Checked;
            if (chkVuelta.Checked || chkSetVuelta.Checked)
                this.SeteoVuelta(true);
            else
                this.SeteoVuelta(false);
        }

        private void AnularBono_Click(object sender, EventArgs e)
        {

        }

        private void tbBoleto_TextChanged(object sender, EventArgs e)
        {
            tbCantidad.Text = this.CantidadTotalPersonas().ToString();
        }

     
        


    }



}
