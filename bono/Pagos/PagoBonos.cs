using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;


namespace SOCIOS.bono
{
    public partial class PagoBonos : Form
    {
        bo dlog;
        bool esFinanciable;
        bool Inicio;
        decimal MontoPlanilla;
        int idBono;
        string ROL;
        int Nro_Soc;
        int Nro_Dep;
        int Barra;
        string NroBeneficio;
        int Nro_Socio_Titular;
        decimal Saldo=0;

        decimal MontoCuota;
        int CantidadCuotas;

        int MaxCuotas;
        public  int tipoPago;
        public  string formaPago;
        public  List<PagoBono> Pagos;
        public  decimal SaldoIngreso = 0;
        public  decimal MontoEfectivo;
        public  int NumeroContraLor;
        public  decimal Recargo = 0;
        public  string InfoTarjeta = "";
        public  bool Tarjeta = false;
       public  decimal SaldoInteres = 0;
       public int CuotasTarjeta = 0;
        decimal SaldoNeto = 0;
        public bool Control_Fecha_Cuotas = false;
        public int Cantidad_Control_Fechas_Cuota = 3;
        DateTime Fecha_Referencia_Cuotas=System.DateTime.Now;
        
        public decimal Efectivo           = 0;
        public decimal Tarjeta_credito    = 0;
        public int Tarjeta_credito_cuotas = 0;
        public decimal Interes_Tarjeta_Credito = 0;

        public decimal Tarjeta_Debito     = 0;
        public decimal Planilla           = 0;
        public int     Planilla_Cuotas    = 0;

        public decimal Transfrencia = 0;
        public decimal Total        = 0;
        public decimal Gastos_Gestion = 0;
        public DateTime? Fecha_Paquete;

        


        public PagoBonos(int pidBono, string pROL, decimal pSaldo, bool Financiable, int pNro_Soc, int pNro_Dep, int pBarra, int pNro_Socio_Titular, string Beneficio,DateTime? pFecha_Referencia_Cuotas )
        {
            InitializeComponent();
    
            dlog = new bo();
            Inicio = true;


            Nro_Soc = pNro_Soc;
            Nro_Dep = pNro_Dep;
            Barra = pBarra;
            NroBeneficio = Beneficio;

            idBono = pidBono;
            ROL = pROL;
            Saldo = pSaldo;
            SaldoNeto = Saldo;
            ROL = pROL;
            Pagos = new List<PagoBono>();
            //si el id Bono es 0 , va todo en memoria
            if (idBono != 0)
                this.Refrescar_Grilla();
            else
                this.Refrescar_Grilla_Memoria();



            lblSaldo.Text = Saldo.ToString("0.##");
            lblBono.Text =  ROL;
            esFinanciable = Financiable;
            this.ComboTipoPago();
            MaxCuotas = Int32.Parse(Config.getValor("CREDITOS", "MAX_CUOTAS", 0));
            dpDTO.Format = DateTimePickerFormat.Custom;
            dpDTO.CustomFormat = "MMMM yyyy";
            dpDTO.Value = dpFecha.Value.AddMonths(1);

            dpSeniaFecha.Format = DateTimePickerFormat.Custom;
            dpSeniaFecha.CustomFormat = "MMMM yyyy";
            //int AnioDto =Int32.Parse(Config.getValor("CREDITOS", "FECHA_DTO", 0));
            //int MesDto = Int32.Parse(Config.getValor("CREDITOS", "FECHA_DTO", 1));
            
            dpSeniaFecha.Value =  new DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,1);

            if (pFecha_Referencia_Cuotas != null)
            {
                Control_Fecha_Cuotas = true;
                Fecha_Referencia_Cuotas = pFecha_Referencia_Cuotas.Value;
                Fechas_Tope();
            }


        }

        private void ComboTipoPago()
        {


            string Query;
            if (esFinanciable)
                Query = "select ID,DES from PAGOS_BONO_TIPOS ";
            else
                Query = "select FIRST 3 ID,DES from PAGOS_BONO_TIPOS ";
            //7-9-2016 : sacar 
            Query = Query + " WHERE ID <> 9 AND ID<>10";

            //16-08-2017 , financiacion efectivo para todos 
            //if (ROL != "TURISMO" )
            //{
            //    Query =Query+  " AND ID <> 6";
            //}

            Query = Query + "ORDER BY ID";
            cbTipoPago.DataSource = null;
            cbTipoPago.Items.Clear();
            cbTipoPago.DataSource = dlog.BO_EjecutoDataTable(Query);
            cbTipoPago.DisplayMember = "DES";
            cbTipoPago.ValueMember = "ID";
            cbTipoPago.SelectedItem = 1;
            Inicio = false;


        }




        private void Refrescar_Grilla()
        {





            string Query = "select PAGOS_BONO.ID ID ,  (extract(day from PAGOS_BONO.FECHA)||'/'||extract(month from PAGOS_BONO.FECHA)||'/'||extract(year from PAGOS_BONO.FECHA) ) FECHA ,PAGOS_BONO_TIPOS.DES TIPO,PAGOS_BONO.Monto MONTO  ,extract(MONTH from PAGOS_BONO.A_DTO) MES,extract(YEAR from PAGOS_BONO.A_DTO) ANIO,PAGOS_BONO.CUOTA CUOTA from PAGOS_BONO ,PAGOS_BONO_TIPOS  " +
                            "WHERE PAGOS_BONO.TIPOPAGO=PAGOS_BONO_TIPOS.ID AND PAGOS_BONO.BONO =" + idBono.ToString() + " AND PAGOS_BONO.NRO_SOC=" + Nro_Soc.ToString() +
                            "AND NRO_DEP= " + Nro_Dep.ToString() + " AND BARRA =" + Barra.ToString();


            string connectionString;

            DataSet ds1 = new DataSet();

            Datos_ini ini3 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini3.Servidor;
                cs.Database = ini3.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    FbTransaction transaction = connection.BeginTransaction();

                    DataTable dt1 = new DataTable("RESULTADOS");

                    dt1.Columns.Add("ID", typeof(string));
                    dt1.Columns.Add("FECHA", typeof(string));
                    dt1.Columns.Add("TIPO", typeof(string));

                    dt1.Columns.Add("MONTO", typeof(decimal));
                    dt1.Columns.Add("MES", typeof(string));
                    dt1.Columns.Add("ANIO", typeof(string));
                    dt1.Columns.Add("CUOTA", typeof(string));


                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("FECHA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TIPO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("MONTO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("MES")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("ANIO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("CUOTA")).Trim());

                    }

                    reader3.Close();


                    dataGridView.DataSource = dt1;
                    dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



                    dataGridView.Columns[0].Visible = false;
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }






        }

        private void tbPorcentaje_TextChanged(object sender, EventArgs e)
        {
            decimal Saldo = Decimal.Parse(lblSaldo.Text);

            //Control de Porcentaje
           
            
            string sPorc = tbPorcentaje.Text;
            
            //if (Int32.Parse(sPorc) < Int32.Parse(Config.getValor("SERVICIOS MEDICOS", "PORC_FINANC", 0).Trim())) ;
            //    sPorc = Config.getValor("SERVICIOS MEDICOS", "PORC_FINANC", 0).Trim();

            if (sPorc.Trim().Length == 0 )
            {

                OK.Enabled = false;
            }
            else
            {
                OK.Enabled = true;


                int tipo = this.GetTipoPago();


                this.SeteoPagoCB(Saldo, tipo, sPorc);
            }
        }

        private int GetTipoPago()
        {
            string st = cbTipoPago.SelectedValue.ToString();
            return Int32.Parse(st);

        }

        private void getContralor()

        {
            if (tbContralor.Text.Length == 0 ||tbContralor.Text =="0")
                throw new Exception("Debe ingresar un Numero De Contralor, no puede ser 0");
            else
                NumeroContraLor = Int32.Parse(tbContralor.Text);        
        }

        private void  Control_Efectivo(decimal Efectivo)

        {
          if (Efectivo > 9900)
                    throw new Exception("No se puede abonar mas de 9900 en efectivo!");
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            tipoPago = this.GetTipoPago();
         

            try
            {
                formaPago = "Saldo Total $" + Saldo.ToString(); 
                switch (tipoPago)
                {
                    case 1:
                        // Todo en Efectivo, 1 solo pago
                        this.ValidarMonto(Saldo);
                      
                        formaPago = formaPago + ", Se va a a Abonar el Bono en 1 solo pago  en  Efectivo de :$" + Saldo.ToString();
                        SaldoIngreso = Saldo;
                        Efectivo = Saldo;
                        Control_Efectivo(Efectivo);
                       
                        break;
                    case 2:
                        //Parte en Efectivo , Parte en Debito
                       // this.ValidarMonto(Decimal.Parse(lbMonto1.Text));
                        this.ValidarMonto(Decimal.Parse(lbMonto2.Text));
                        formaPago = formaPago + ", Se va a Abonar el Bono en  Efectivo:$ " + lbMonto1.Text + " , Debito: $ " + lbMonto2.Text;
                        SaldoIngreso    = Decimal.Parse(lbMonto1.Text);
                        Efectivo        = Decimal.Round(Decimal.Parse(lbMonto1.Text), 2);
                        Tarjeta_Debito = Decimal.Round(Decimal.Parse(lbMonto2.Text), 2);

                        Control_Efectivo(Efectivo);


                        break;
                    case 3:
                        //Parte en Efectivo, parte en Credito
                       // this.ValidarMonto(Decimal.Parse(lbMonto1.Text));
                        this.ValidarMonto(Decimal.Parse(lbMonto2.Text));
                        //30-08-2017 se cambia lbMontoTarjeta.Text por las cuotas
                        formaPago = formaPago + ", Se va a Abonar el Bono en Efectivo $ " + lbMonto1.Text + " , Tarjeta de Credito $ "+ lbMonto2.Text + " en " +  CuotasTarjeta.ToString()  + " Cuotas";
                        SaldoIngreso = Decimal.Round(Decimal.Parse(lbMonto1.Text),2);
                        
                        
                      
                        SaldoInteres = Decimal.Round(Decimal.Parse(lbMontoTarjeta.Text)  - Decimal.Parse(lbMonto2.Text),2);
                        Saldo = Saldo + SaldoInteres;
                        
                        // 9-08-2017 - no se agrega el interes en el valor del bono  
                        Saldo =  Decimal.Round(Decimal.Parse(lbMonto2.Text),2);
                        this.ValidarTarjeta();

                        Efectivo = SaldoIngreso;
                        Tarjeta_credito = Saldo;
                        Tarjeta_credito_cuotas = CuotasTarjeta;
                        Control_Efectivo(Efectivo);
                        
                      
                        
                        break;
                    case 4:
                        //Parte en Efectiv, parte en planilla en cuotas
                        this.getContralor();
                        this.ValidoCuotas(tbCantidadCuotas);
                        this.ValidarMonto(Decimal.Parse(lbMonto1.Text));
                        this.ValidarMonto(Decimal.Parse(lbMonto2.Text));
                      

                        MontoCuota = Decimal.Round(Decimal.Parse(tbMontoCuotas.Text), 2);
                        formaPago = formaPago + ", Se va a Abonar el Bono en  Efectivo $" + lbMonto1.Text + " ,  " + lbMonto2.Text +
                            " a Pagarse en " + tbCantidadCuotas.Text + " Cuota/s de   $" + MontoCuota.ToString();
                        SaldoIngreso = Decimal.Round( Decimal.Parse(lbMonto1.Text),2);

                        Efectivo = SaldoIngreso;
                        Control_Efectivo(Efectivo);
                        Planilla = Decimal.Round(Decimal.Parse(lbMonto2.Text), 2);
                        Planilla_Cuotas = Int32.Parse(tbCantidadCuotas.Text);
                        Gastos_Gestion = Decimal.Round(Decimal.Parse(lbGestion.Text), 2);
                        
                        break;
                    case 7:
                        //Parte en Debito, parte en planilla en cuotas
                        this.getContralor();
                        this.ValidoCuotas(tbCantidadCuotas);
                        this.ValidarMonto(Decimal.Parse(lbMonto1.Text));
                        this.ValidarMonto(Decimal.Parse(lbMonto2.Text));
                       
                        MontoCuota = Decimal.Round(Decimal.Parse(tbMontoCuotas.Text), 2);
                        formaPago = formaPago + ", Se va a Abonar el Bono en  Debito $" + lbMonto1.Text + " ,  " + lbMonto2.Text +
                            " a Pagarse en " + tbCantidadCuotas.Text + " Cuota/s de   $" + MontoCuota.ToString();
                        SaldoIngreso = Decimal.Round(Decimal.Parse(lbMonto1.Text),2);

                        Tarjeta_Debito = SaldoIngreso;
                        Planilla = Decimal.Round(Decimal.Parse(lbMonto2.Text), 2);
                        Planilla_Cuotas = Int32.Parse(tbCantidadCuotas.Text);
                        break;

                    case 8:
                        //Parte en Credito, parte en planilla en cuotas
                        this.getContralor();
                        this.ValidoCuotas(tbCantidadCuotas);
                        this.ValidarMonto(Decimal.Parse(lbMonto1.Text));
                        this.ValidarMonto(Decimal.Parse(lbMonto2.Text));
                        MontoCuota = Decimal.Round(Decimal.Parse(tbMontoCuotas.Text), 2);
                        formaPago = formaPago + ", Se va a Abonar el Bono en  Tarjeta de Credito $" + lbMonto1.Text + " ,  " + lbMonto2.Text +
                            " a Pagarse en " + tbCantidadCuotas.Text + " Cuota/s de   $" + MontoCuota.ToString();
                        SaldoIngreso = Decimal.Round(Decimal.Parse(lbMonto1.Text),2);
                        this.ValidarTarjeta();

                        Tarjeta_credito        = SaldoIngreso;
                        Tarjeta_credito_cuotas = Tarjeta_credito_cuotas;
                         Planilla = Decimal.Round(Decimal.Parse(lbMonto2.Text), 2);
                         Planilla_Cuotas = Int32.Parse(tbCantidadCuotas.Text);
                       Gastos_Gestion=  Decimal.Round(Decimal.Parse(lbGestion.Text), 2);
                        break;

                    case 5:
                        //Todo en planilla en cuotas
                        this.getContralor();
                        this.ValidoCuotas(tbCantidadCuotas);
                       // this.ValidarMonto(Decimal.Parse(lbMonto1.Text));
                        MontoCuota = Decimal.Round(Decimal.Parse(lbMonto1.Text), 2);
                       // this.ValidarMonto(Decimal.Parse(lbMonto2.Text));
                      //  this.ValidarMonto(Decimal.Parse(MontoCuota.ToString()));

                        this.ValidarMonto(Decimal.Parse(lblSaldo.Text));
                        this.ValidarMonto(decimal.Parse(tbMontoCuotas.Text));


                        formaPago = formaPago + ", Financiacion por planilla $ " + lblSaldo.Text +
                        ",a Pagarse en " + tbCantidadCuotas.Text + " Cuota/s de   $" +tbMontoCuotas.Text;
                        SaldoIngreso = 0;
                        Planilla = Decimal.Round(Decimal.Parse(lblSaldo.Text), 2);
                        Planilla_Cuotas = Int32.Parse(tbCantidadCuotas.Text);
                       Gastos_Gestion = Decimal.Round(Decimal.Parse(lbGestion.Text), 2);
                        break;
                    case 6:
                        //Todo en Financiacion Efectivo

                        this.ValidoCuotas(tbSeniaCantidadCuotas);
                        this.ValidarMonto(Decimal.Parse(lbSeniaMonto.Text));
                        this.ValidarMonto(Decimal.Parse(lbSaldoSenia.Text));
                        this.ValidarMonto(Decimal.Parse(lbMontoCuotaSenia.Text));

                        formaPago = formaPago + ", Financiacion Efectivo, Seña $ " + lbSeniaMonto.Text +
                        ",Saldo de $" + lbSaldoSenia.Text + "a Pagarse en " + tbSeniaCantidadCuotas.Text + " Cuota/s de   $" + lbMontoCuotaSenia.Text.ToString();
                       
                        SaldoIngreso = Decimal.Round( Decimal.Parse(lbSeniaMonto.Text),2);
                        Efectivo = SaldoIngreso;
                       
                        break;

                    case 11:
                    //Transferencia bancaria 
                        this.ValidarBancario();
                        string Banco_ref = " ";
                        if (rbTBPatagonia.Checked)
                            Banco_ref = " Banco Patagonia ";
                        else
                            Banco_ref = " Banco Ciudad ";
                        Banco_ref = Banco_ref + " , Referencia" + tbTBreferencia.Text;

                        formaPago             = formaPago + ", Se va a a Abonar el Bono en 1 solo pago  en  Transferencia Bancaria de :$" + Saldo.ToString() + "  " + Banco_ref;
                        SaldoIngreso          = Saldo;
                        Transfrencia          = Saldo;
                    break;

                    case 12:
                        this.ValidoCuotas(tbSeniaCantidadCuotas);
                        this.ValidarMonto(Decimal.Parse(lbSeniaMonto.Text));
                        this.ValidarMonto(Decimal.Parse(lbSaldoSenia.Text));
                        this.ValidarMonto(Decimal.Parse(lbMontoCuotaSenia.Text));
                        this.ValidarMonto(Decimal.Parse(lbMonto1.Text));

                        formaPago = formaPago + ", Se va a Abonar el Bono en  Debito $" + lbMonto1.Text;

                        formaPago = formaPago + ", Financiacion Efectivo $" + lbSaldoSenia.Text + "a Pagarse en " + tbSeniaCantidadCuotas.Text + " Cuota/s de   $" + lbMontoCuotaSenia.Text.ToString();
                        Tarjeta_Debito = Decimal.Parse(lbMonto1.Text);
                        SaldoIngreso = Tarjeta_Debito;
                       // Efectivo = Decimal.Round(Decimal.Parse(lbSaldoSenia.Text), 2);


                    break;
                    case 13 :

                        this.ValidoCuotas(tbSeniaCantidadCuotas);
                        this.ValidarMonto(Decimal.Parse(lbSeniaMonto.Text));
                        this.ValidarMonto(Decimal.Parse(lbSaldoSenia.Text));
                        this.ValidarMonto(Decimal.Parse(lbMontoCuotaSenia.Text));
                        this.ValidarMonto(Decimal.Parse(lbMonto1.Text));
                        formaPago = formaPago + ", Se va a Abonar el Bono en  Tarjeta de Credito $" + lbMonto1.Text + "a Pagarse en " + tbCantidadCuotas.Text + " Cuota/s de   $" + MontoCuota.ToString();
                        formaPago = formaPago + ", Financiacion Efectivo $ "+ lbSaldoSenia.Text + "a Pagarse en " + tbSeniaCantidadCuotas.Text + " Cuota/s de   $" + lbMontoCuotaSenia.Text.ToString();

                        SaldoIngreso = Decimal.Round(Decimal.Parse(lbMonto1.Text),2);
                        this.ValidarTarjeta();

                        Tarjeta_credito        = SaldoIngreso;
                        Tarjeta_credito_cuotas = Tarjeta_credito_cuotas;
                       // Efectivo               = Decimal.Round( Decimal.Parse(lbSaldoSenia.Text),2);

                    break;
                 



                       


                }




           

          
                    if (MessageBox.Show(formaPago, "Confirmar Pago", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {



                        this.GrabarPagos(tipoPago, formaPago);
                        this.Refrescar_Grilla_Memoria();
                        //this.Refrescar_Grilla();





                    }

                    DialogResult = DialogResult.OK;
                    this.Close();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            
            }

       

        }


        public decimal Total_Actualizado()
        {




            return decimal.Round(Saldo + Gastos_Gestion, 2);
        }

        private void ValidarTarjeta()

        {
            if ((!Tarjeta) || lbMontoTarjeta.Text == "0")
                throw new Exception("Debe Ingresar Las condiciones del Pago Con Tarjeta de Credito ");
        
        
        }

        private void ValidoCuotas(TextBox cuotas)

        {
            bool Validar = false;

            if (cuotas.Text.Length == 0)
                Validar = true;
            try
            {
                if (Int32.Parse(cuotas.Text) == 0)
                    Validar = true;
            }
            catch (Exception ex)

            { 
               throw new Exception("Ingrese El Numero de Cuotas ");
            }


            if (Validar)
            {
                throw new Exception("Ingrese El Numero de Cuotas ");
            }

        
        }

        private void ValidarMonto(decimal Monto)

        {
            if (Monto == 0)
                throw new Exception("Montos No Pueden Ser cero.!");
        }

        private void ValidarBancario()
        {
            if (rbTBCiudad.Checked==false && rbTBPatagonia.Checked==false )
                throw new Exception("Seleccione un banco Destino!");
            if (tbTBreferencia.Text.Length == 0)
            {
                throw new Exception("Ingrese Referencia Transferencia Bancaria!");
            }
        }

        private void Mostrar_Seña(bool Mostrar)
        {
            lbSeniaMonto.Visible = Mostrar;
            lbSenia.Visible = Mostrar;
        }
        private void cbTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Inicio == true)
                    return;
                string st = cbTipoPago.SelectedValue.ToString();
                int tipo = Int32.Parse(st);
           
                this.SeteoPago(tipo);
                OK.Visible = true;
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            
            }

        }

        private void SeteoPago(int idTipoPago)
        {
            decimal control_saldo = Decimal.Parse(lblSaldo.Text);
            //this.SetearCBpago(Saldo, idTipoPago,sPorc);
            Recargo = 0;
            Tarjeta = false;
            lbMontoTarjeta.Text = "0";
            lbSeniaMonto.Enabled = true;

            this.Mostrar_Seña(true);

            //si es tipo de pago efectivo solo hace esto
            if (idTipoPago == 6)
            {
                gpPlanilla.Visible = false;
                gpPago.Visible = false;
                gpSenia.Visible = true;
               

                return;
            }
            else
            {
                gpPlanilla.Visible = true;
                gpPago.Visible = true;
                gpSenia.Visible = false;

            }

            decimal Saldo = Decimal.Parse(lblSaldo.Text);
            decimal MontoOne = 0;

            string sPorc = Config.getValor("CREDITOS", "PORC_FINANC", 0);
            this.SeteoPagoCB(Saldo, idTipoPago, sPorc);

            if (idTipoPago < 5)
            {

                gpPago.Visible = true;
            }
            else
                gpPago.Visible = false;

            if (idTipoPago < 4)
                gpPlanilla.Visible = false;
            else
                gpPlanilla.Visible = true;

            //Para Pago puro en efectivo

            if (idTipoPago == 1)
            {
                gpPlanilla.Visible = false;
                gpPago.Visible = false;
                gpSenia.Visible = false;
            }

            if (idTipoPago == 7 || idTipoPago ==8)

            {
                gpPago.Visible = true;

            }

            if (idTipoPago == 8 || idTipoPago == 3)
            {
                btnTarjeta.Visible = true;
                lbMontoTarjeta.Visible = true;
            }
            else

            {
                btnTarjeta.Visible = false;
                lbMontoTarjeta.Visible = false;
            }

            if (idTipoPago == 11)
            {
                gpBancaria.Visible = true;
                gpPlanilla.Visible = false;
                gpSenia.Visible = false;
                gpPago.Visible = false;
                lbSeniaMonto.Enabled = false;
               
            }

            if (idTipoPago == 12)
            {
                gpPago.Visible = true;
                gpSenia.Visible = true;
                gpPlanilla.Visible = false;
                gpBancaria.Visible = false;
                this.Mostrar_Seña(false);
                
            }
            if (idTipoPago == 13)
            {
                gpSenia.Visible = true ;
                gpPago.Visible = true;
                gpPlanilla.Visible = false;
                gpBancaria.Visible = false;
                btnTarjeta.Visible = true;
                lbMontoTarjeta.Visible = true;
                this.Mostrar_Seña(false);
            
            }
            

        }

        private void SeteoPagoCB(decimal pSaldo, int Tipo, string sPorcentaje)
        {
            decimal MontoResto = 0;
            string TipoPago = "";
            decimal MontoPlanilla = 0;
            decimal Monto1 = 0;
            decimal porc ;
            
           
            porc = (decimal)Int32.Parse(sPorcentaje) / 100;//  Decimal.Parse("0." + sPorcentaje);
          

            lbMonto2.Text = "";
            lbFp2.Text = "";

            lbFp1.Text = "";
            lbMonto1.Text = "";

            tbPorcentaje.Text = sPorcentaje;

            Monto1 = Decimal.Round(pSaldo * porc, 2);
            MontoResto = pSaldo - Monto1;
            if (MontoResto != 0)
            {
                var decimalMonto1 = Decimal.Round(Monto1 - Math.Truncate(Monto1),2);
                
                if (decimalMonto1 > 0)
                {
                    MontoResto = Decimal.Round(MontoResto + decimalMonto1);
                    Monto1 = Decimal.Round(Monto1, 0);

                
                }
            }

         

            lbFp1.Text = "Efectivo :";
            lbMonto1.Text = Monto1.ToString("0.##");




            if (Tipo == 1)
            {
                gpPago.Visible = false;
                lbMonto2.Text = "";
                lbFp2.Text = "";

                lbFp1.Text = "Efectivo :";
                lbMonto1.Text = Saldo.ToString("0.##");
            }
            else
                gpPago.Visible = true;



            lbMonto2.Text = MontoResto.ToString("0.##");


            if (Tipo == 2)
                TipoPago = "Debito   :";
            else if (Tipo == 3)
                TipoPago = "Credito  :";
            else if (Tipo == 4 || Tipo ==7 || Tipo ==8  || Tipo ==12 || Tipo ==13)
            {
                //if (Tipo == 4)
                    TipoPago = "Planilla :";
                 if (Tipo == 7 || Tipo ==12)
                {
                    lbFp1.Text =  "Debito :";
                    if (Tipo == 12)
                    {
                        lbSeniaMonto.Text = lbMonto2.Text;
                        lbSaldoSenia.Text = lbMonto2.Text;
                        
                    }
                }
                else if (Tipo ==8 || Tipo ==13)
                {
                    lbFp1.Text =  "Credito :";
                    if (Tipo == 13)
                    {
                        
                        lbSeniaMonto.Text = lbMonto2.Text;
                        lbSaldoSenia.Text = lbMonto2.Text;
                    }
                }


                MontoPlanilla = MontoResto;
                this.SeteoInicialCuotas(MontoResto);
            } 
            else
            {
                TipoPago = "Planilla :";
                MontoPlanilla = Saldo;
                this.SeteoInicialCuotas(Saldo);

            }

            // 20-04 con 0 en el porcentaje es 0 en efectivo y 100 % en el otro tipo de pago;
            if (porc == 0 && Tipo !=1)
            {
                MontoResto = pSaldo;
                Monto1 = 0;
            }

            lbFp2.Text = TipoPago;
            lbMonto2.Text = MontoResto.ToString("0.##");


            if (Tipo == 3 || Tipo == 8)

            { 
              
            }


        }

        private void SeteoInicialCuotas(decimal Saldo)
        {
            lblSaldoCuotas.Text = Saldo.ToString("0.##");
            tbCantidadCuotas.Text = "1";
            tbMontoCuotas.Text = Saldo.ToString("0.##");



        }


        private void GrabarPagos(int tipoPago, string formaPago)
        {
            //1 Pago  Todo En Efectivo
            if (tipoPago == 1)
            {
                this.GraboPago(tipoPago, Saldo,0,System.DateTime.Now,"UNICO PAGO","C",true);

            }
            else if (tipoPago == 2 || tipoPago == 3)
            {
                this.GraboPago(1, decimal.Parse(lbMonto1.Text),0, System.DateTime.Now, "UNICO PAGO", "C",true);
                if (tipoPago==2)
                   this.GraboPago(9, decimal.Parse(lbMonto2.Text),0, System.DateTime.Now, "RESTO EN DEBITO", "C",true);
                else
                    this.GraboPago(10, Tarjeta_credito,Interes_Tarjeta_Credito, System.DateTime.Now, "RESTO EN CREDITO", "C",true);
            }
            else if (tipoPago == 4 || tipoPago==7 || tipoPago==8)
            {

               if (tipoPago==4)
                   this.GraboPago(1, decimal.Parse(lbMonto1.Text),0, System.DateTime.Now, "1ER PAGO EN EFECTIVO", "C",true);
               else if (tipoPago == 7 )
                   this.GraboPago(9, decimal.Parse(lbMonto1.Text),0, System.DateTime.Now, "1ER PAGO EN DEBITO", "C",true);
                else
                    this.GraboPago(10, decimal.Parse(lbMonto1.Text),0, System.DateTime.Now, "1ER PAGO EN CREDITO", "C",true);

                this.GenerarPLanDePago(tipoPago,tbCantidadCuotas,tbMontoCuotas,dpFecha);
            }
            else if (tipoPago == 6)
            
            {
                this.GraboPago(1, Decimal.Parse(lbSeniaMonto.Text),0, System.DateTime.Now, "Seña ", "C", true);
                this.GenerarPLanDePago(tipoPago,tbSeniaCantidadCuotas,lbMontoCuotaSenia,dpSeniaFecha);
            }

            else if (tipoPago == 11)
            {
                this.GraboPago(tipoPago, Saldo, 0, System.DateTime.Now, "UNICO PAGO - TRANSFERENCIA", "C", true);
            } else if (tipoPago ==12)
            {
                this.GraboPago(9, decimal.Parse(lbMonto1.Text), 0, System.DateTime.Now, "1ER PAGO EN DEBITO", "C", true);
                this.GraboPago(1, Decimal.Parse(lbSeniaMonto.Text), 0, System.DateTime.Now, "Seña ", "C", true);
                this.GenerarPLanDePago(6, tbSeniaCantidadCuotas, lbMontoCuotaSenia, dpSeniaFecha);
            }
            else if (tipoPago == 13)
            {
                this.GraboPago(10, decimal.Parse(lbMonto1.Text), 0, System.DateTime.Now, "1ER PAGO EN CREDITO", "C", true);
                this.GraboPago(1, Decimal.Parse(lbSeniaMonto.Text), 0, System.DateTime.Now, "Seña ", "C", true);
                this.GenerarPLanDePago(6, tbSeniaCantidadCuotas, lbMontoCuotaSenia, dpSeniaFecha);
            
            }
            else
            {

                this.GenerarPLanDePago(tipoPago, tbCantidadCuotas, tbMontoCuotas, dpFecha);

            }


            
            // dlog.UpdateFormaPagoBonoOdonto(idBono, formaPago);


        }

        private void GenerarPLanDePago(int tipo,TextBox tbCantidad,Label lbMonto,DateTimePicker Fecha)
        {

            CantidadCuotas = Int32.Parse(tbCantidad.Text);
            decimal MontoCuota = Decimal.Parse(lbMonto.Text);
            int i;
            DateTime fecha = dpDTO.Value;
            fecha = fecha.AddMonths(-1);
            
            
            for (i = 1; i <= CantidadCuotas; i++)
            {
                fecha = fecha.AddMonths(1);
                this.GraboPago(tipo, MontoCuota,0, fecha, "Cuota :" + i.ToString(), "P",false);


            }

        }
        private void GraboPago(int TipoPago, decimal Monto,decimal Interes, DateTime A_DTO, string desCuota, string POC,bool IngresoCaja)
        {
            bono.PagoBono item = new PagoBono();
            item.FECHA = dpFecha.Value;
            item.DES_FECHA = dpFecha.Value.Day.ToString("00") + "/" + dpFecha.Value.Month.ToString("00") + "/" + dpFecha.Value.Year.ToString();
            item.FECHA_DTO = A_DTO;
            item.MES = A_DTO.Month.ToString("00");
            item.ANIO = A_DTO.Year.ToString();
            item.CUOTA = desCuota;
            item.TIPO = TipoPago;
            item.DES_TIPO = this.getTipoPago(TipoPago);
            item.MONTO = Monto;
            item.POC = POC;
            item.Ingreso_Caja = false;
            item.Interes = Interes;


            Pagos.Add(item);
            this.Refrescar_Grilla_Memoria();


            //dlog.InsertPagoBono(idBono, TipoPago, Monto, desCuota,POC, dpFecha.Value, 0,0, A_DTO, VGlobales.vp_username, System.DateTime.Now.ToString(), NroBeneficio, ROL, Nro_Soc, Nro_Dep, Barra, Nro_Socio_Titular);
        }

        private void Refrescar_Grilla_Memoria()
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = Pagos;
            dataGridView.Refresh();
            dataGridView.Columns[0].HeaderText = "FECHA";
            dataGridView.Columns[1].HeaderText = "TIPO";
            dataGridView.Columns[2].HeaderText = "MONTO";
            dataGridView.Columns[3].HeaderText = "MES";
            dataGridView.Columns[4].HeaderText = "ANIO";
            dataGridView.Columns[5].HeaderText = "";

            dataGridView.Columns[6].Visible = false;
            dataGridView.Columns[7].Visible = false;
            dataGridView.Columns[8].Visible = false;
            dataGridView.Columns[9].Visible = false;

        }



        private string getTipoPago(int pTipo)
        {
            string QUERY = "select DES from    PAGOS_BONO_TIPOS  WHERE ID=" + pTipo.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return foundRows[0][0].ToString();
            }
            else
                return "";

        }

        private void tbCantidadCuotas_TextChanged(object sender, EventArgs e)
        {
            bool isTurismo=false;

            if (VGlobales.vp_role == "TURISMO")
                isTurismo = true;



            if (tbCantidadCuotas.Text.Length > 0)
            {
                int CantidadCuotas = Int32.Parse(tbCantidadCuotas.Text);
                //Controlar maximo de cuotas !

                if (CantidadCuotas <= MaxCuotas)
                {
                    decimal Saldo = Decimal.Round(Decimal.Parse(lblSaldoCuotas.Text));
                    if ( isTurismo && CantidadCuotas>1)
                    {
                        Calculo_Turismo(Saldo, CantidadCuotas);
                    }
                    else
                        tbMontoCuotas.Text = Decimal.Round((Saldo / CantidadCuotas), 2).ToString();

                    if (CantidadCuotas <= 1)
                    {
                        lbGestion.Text = "";
                        lbGestionLeyenda.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Excede el Maximo de Cuotas Permitido \n", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }


        private void Calculo_Turismo(decimal Saldo, int Cuotas)

        { 

            
            decimal CuotaPura = Decimal.Round(Saldo/Cuotas,2);
            decimal SaldoMonto=0;
            decimal por = decimal.Parse("25");
            decimal Recargo = 0;
            decimal RecargoCuota =0;
            int contador = 0;
            decimal Capital = 0;

            
            for(int I=0;I<Cuotas;I++)

             { 
                if (I==0)
                {
                   // Recargo = Decimal.Round( (CuotaPura * por) /1000 ,2);
                    
                    Capital = Saldo - CuotaPura;
                    Recargo = Decimal.Round((Saldo* por) / 1000, 2);
                    SaldoMonto = Recargo;
                    
 
                } else
                {
                  
                    Recargo  =Decimal.Round(( Capital * por)/1000,2);
                    SaldoMonto = SaldoMonto + Recargo;
                    Capital = Capital - CuotaPura;
                    
                    //SaldoMonto = SaldoMonto - CuotaPura;
                }

                

                contador = contador + 1;


             }


            lbGestion.Visible = true;
            lbGestionLeyenda.Visible = true;
            lbGestionLeyenda.Text = "Gastos Gestion  $ ";
            lbGestion.Text =  Decimal.Round(SaldoMonto,2).ToString();
            RecargoCuota =  Recargo;
            tbMontoCuotas.Text =  Decimal.Round((Saldo+SaldoMonto)/Cuotas,2).ToString();



          
              
        
        
        }

        private void dpFecha_ValueChanged(object sender, EventArgs e)
        {
            dpDTO.Value = dpFecha.Value.AddMonths(1);
        }

        public string FormaPago()
        {
            return formaPago;

        }

        private void lbSeniaMonto_TextChanged(object sender, EventArgs e)
        {
            if (lbSeniaMonto.Text.Length > 0)
            {
                lbSaldoSenia.Text = (Decimal.Parse(lblSaldo.Text) - Decimal.Parse(lbSeniaMonto.Text)).ToString("0.##");
            }

        }

        private void tbSeniaCantidadCuotas_TextChanged(object sender, EventArgs e)
        {
            if (tbSeniaCantidadCuotas.Text.Length > 0)
            {
                int CantidadCuotas = Int32.Parse(tbSeniaCantidadCuotas.Text);
                //Controlar maximo de cuotas !
                MaxCuotas = Cantidad_Control_Fechas_Cuota;
                if (CantidadCuotas <= MaxCuotas)
                {
                    decimal Saldo = Decimal.Round(Decimal.Parse(lbSaldoSenia.Text));

                    lbMontoCuotaSenia.Text = Decimal.Round((Saldo / CantidadCuotas), 2).ToString();
                }
                else
                {
                    MessageBox.Show("Excede el Maximo de Cuotas Permitido \n", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void gpSenia_Enter(object sender, EventArgs e)
        {

        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {

            decimal Monto = 0;
            string st = cbTipoPago.SelectedValue.ToString();
            int tipo = Int32.Parse(st);

            if (tipo == 3)
            {
                Monto = Decimal.Parse(lbMonto2.Text);
            }
            else
            {
                Monto = Decimal.Parse(lbMonto1.Text);
            
            }
            tarjetas tar = new tarjetas(Monto);
            DialogResult dr = tar.ShowDialog();

            if (dr == DialogResult.OK)

            {

                Interes_Tarjeta_Credito = decimal.Round(Decimal.Parse(tar.IMPORTE_TOTAL) - Monto, 2);
                Tarjeta_credito = Decimal.Round(Monto,2);

                InfoTarjeta = "TOTAL TARJETA CREDITO   $ " + tar.IMPORTE_TOTAL + ", EN " + tar.CUOTAS.ToString() + " DE  $ " + tar.IMPORTE_CUOTA + " - TOTAL INTERES $" + Interes_Tarjeta_Credito.ToString();
                lbMontoTarjeta.Text = tar.IMPORTE_TOTAL;
                CuotasTarjeta = tar.CUOTAS;
                Tarjeta = true;


                



             }
        }

        private void Calculo_Tope_Cuotas()
        { 
        
        
        }

        private void dpDTO_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void dpSeniaFecha_ValueChanged(object sender, EventArgs e)
        {
         
        }


        private void Fechas_Tope()

        {

            try
            {
                if (Control_Fecha_Cuotas)
                {
                    Tope_Cuotas(Fecha_Referencia_Cuotas);
                    lbCantidadMaximaCuotas_Efectivo.Text = "Cantidad cuotas Maximas " + Cantidad_Control_Fechas_Cuota.ToString();

                }
            }
            catch (Exception ex)
            {
                lbCantidadMaximaCuotas_Efectivo.Text = "";
                lbCantidadMaximaCuotas_Efectivo.Text = "";
            }
        
        }
        private void Tope_Cuotas(DateTime fecha)
        {
            Cantidad_Control_Fechas_Cuota = ((fecha - System.DateTime.Now).Days / 30);


            if (Cantidad_Control_Fechas_Cuota == 0)
                Cantidad_Control_Fechas_Cuota = 1;
            if (Cantidad_Control_Fechas_Cuota < 0)
                Cantidad_Control_Fechas_Cuota = Cantidad_Control_Fechas_Cuota * (-1);
        }
    }
}