﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Firebird;
using System.Threading;


namespace SOCIOS
{
    public partial class recibos : Form
    {
        BO.bo_Caja BO_CAJA = new BO.bo_Caja();
        SOCIOS.CuentaSocio.PlanCuentaUtils pcu = new CuentaSocio.PlanCuentaUtils();
        bo dlog = new bo();
        nombreSocio ns = new nombreSocio();
        tipoSocio ts = new tipoSocio();
        edad ee = new edad();
        numeroRecibo nr = new numeroRecibo();
        nombreCuenta nc = new nombreCuenta();
        arancel aa = new arancel();
        nombreProf np = new nombreProf();
        sectAct sa = new sectAct();
        maxid mid = new maxid();
        genHTML gh = new genHTML();
        FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
        SOCIOS.bono.BonoUtils bonoUtils = new bono.BonoUtils();

        string Modo_Facturacion_Produccion = VGlobales.MODO_FACTURACION;

        private string MODIFICAR { get; set; }
        private string DENI { get; set; }
        private string NOMBRE_SOCIO { get; set; }
        private string COD_DTO { get; set; }
        private string TIT_SOC { get; set; }
        private string TIT_DEP { get; set; }
        private string NRO_SOC { get; set; }
        private string NRO_DEP { get; set; }
        private string numero_de_recibo { get; set; }
        private string RECIBO_BONO { get; set; }
        private string TABLA { get; set; }
        private string TITULO { get; set; }
        private string BOTON { get; set; }
        private decimal arancel_general { get; set; }
        private int idsoc { get; set; }
        private int secuencia { get; set; }
        private int recibo_id { get; set; }
        private int a { get; set; }
        private int idsectact { get; set; }
        private int idprof { get; set; }
        private int barra { get; set; }
        private string reintegro { get; set; }
        private int reintegro_de { get; set; }
        private decimal importe_traido { get; set; }
        private string NRO_CUIT { get; set; }
        private int ID_PROFESIONAL { get; set; }
        private string Leyenda_Profesional { get; set; }


        public recibos(int var_IdSocio, int var_IdSecAct, int var_IdProf, int var_Secuencia, string var_Apellido, string var_Nombre, 
            string var_TipSoc, string var_Barra, string var_CodDto, string var_NroRecibo, string NUMERO_SOCIO, string NUMERO_DEP, 
            string TITULAR_SOC, string TITULAR_DEP, int CUENTA, string DNI, int GRUPO, decimal IMPORTE, string RB, string REINTEGRO, string CUIT)
        {
            InitializeComponent();

            MODIFICAR = "NO";
            NRO_CUIT = CUIT;

            if (RB == "R")
            {
                TITULO = "RECIBO N° ";
                TABLA  = "RECIBOS_CAJA";
                BOTON  = "GUARDAR RECIBO";
            }

            if (RB == "B")
            {
                TITULO = "BONO N° ";
                TABLA  = "BONOS_CAJA";
                BOTON  = "GUARDAR BONO";
            }

            if (VGlobales.PTO_VTA_N != "0004")
                lbDisponibles.Visible = true;

            lbReciboBono.Text = TITULO;
            int CUENTA_DEBE = 0;
            int CUENTA_HABER = 0;
            lbPrueba.Text = var_CodDto;
            lbTipoSocioNoTitular.Text = var_TipSoc;
            barra = int.Parse(var_Barra);
            NOMBRE_SOCIO = var_Apellido + ", " + var_Nombre;
            DENI = DNI;
            NRO_SOC = NUMERO_SOCIO;
            NRO_DEP = NUMERO_DEP;
            TIT_SOC = TITULAR_SOC;
            TIT_DEP = TITULAR_DEP;
            RECIBO_BONO = RB;
            lbNroSoc.Text = TIT_SOC + " - " + TIT_DEP;
            int NRO_SOC_INT = int.Parse(TIT_SOC);
            int NRO_DEP_INT = int.Parse(TIT_DEP);
            int ID_TIT_INT = ((NRO_SOC_INT * 1000) + NRO_DEP_INT);
            string[] arancel = { "A", "A" };
            reintegro = REINTEGRO;
            string NUMERO_DE_RECIBO = var_NroRecibo;
            ID_PROFESIONAL = var_IdProf;
            comboBancoDepo();

            if (REINTEGRO == "NO")
            {
                numero_de_recibo = NUMERO_DE_RECIBO;
                comboPtoVta(0);
                cbPtoVta.Enabled = true;
            }
            else
            {
                numero_de_recibo = "";
                lbReciboBono.Text = "REINTEGRO Nº";
                comboPtoVta(0);
                cbPtoVta.SelectedValue = "0005";
                lbReintegro.Visible = true;
                lbReintegro.Text = "REINTEGRO DE " + VGlobales.PTO_VTA_N + "-" + NUMERO_DE_RECIBO + " - IMPORTE $ " + IMPORTE.ToString();
                reintegro_de = int.Parse(NUMERO_DE_RECIBO);
                label5.Text = "REINTEGRO:";
                lbNroRecibo.Left = 140;
                label5.Left = 35;
                cbSinCargo.Enabled = false;
                cbCuentasDebe.Enabled = false;
                cbCuentasHaber.Enabled = false;
                cbFormaDePago.Enabled = false;
                cbEditarArancel.Enabled = false;
                tbFactorArancel.Enabled = false;
                tbObservaciones.Text = lbReintegro.Text;
                tbArancel.Focus();
            }

            int IDSECTACT = var_IdSecAct;
            idsectact = IDSECTACT;
            int IDSOCIO = var_IdSocio;
            idsoc = IDSOCIO;
            int IDPROF = var_IdProf;
            idprof = IDPROF;
            string CAT_SOC = ts.tipo(ID_TIT_INT).Substring(0, 3);

            if (var_TipSoc == "ADH" || var_TipSoc == "INP")
            {
                CAT_SOC = "001";
            }  

            int edad = 0;

            //SI ES FAMILIAR BARRA MAYOR A 3 (HIJO) Y YA CUMPLIO 18 AÑOS -> NO SOCIO
            if (var_TipSoc == "FAM" && int.Parse(var_Barra) > 3)
            {
                edad = ee.FAMILIAR(var_IdSocio, var_Barra);

                if (edad >= 18)
                {
                    CAT_SOC = "005";
                }
            }

            //AVISAR SI ES VITALICIO DE ORO
            if (CAT_SOC == "002")
            {
                edad = ee.VITALICIO_ORO(var_IdSocio);

                if (edad >= 25)
                {
                    lbVitOro.Visible = true;
                }
            }

            //NOMBRE DEL SOCIO TITULAR
            if (var_TipSoc == "ADH" || var_TipSoc == "INP")
            {
                lbNombreSocioTitular.Text = ns.ADH(TIT_SOC, TIT_DEP);
                lbTipoSocio.Text = ts.tipo(ID_TIT_INT);
            }
            else
            {
                lbNombreSocioTitular.Text = ns.TIT(var_IdSocio);
                lbTipoSocio.Text = ts.tipo(idsoc);
            }

            //ARANCELES
            if (IMPORTE > 0 && REINTEGRO == "NO")
            {
                lbArancel.Visible = true;
                tbArancel.Visible = false;
                lbArancel.Text = IMPORTE.ToString();
                arancel_general = IMPORTE;
                cbCuentasDebe.Focus();
                a = 2;
                importe_traido = IMPORTE;
            }
            else if (IMPORTE > 0 && REINTEGRO == "SI")
            {
                tbArancel.Visible = true;
                lbArancel.Visible = false;
                arancel_general = 0;
                cbCuentasDebe.Focus();
                a = 1;
                importe_traido = IMPORTE;
            }
            else
            {
                decimal valorArancel = aa.valorGrupo(IDSECTACT, GRUPO, IDPROF);

                if (IDSECTACT == 160 && IDPROF == 76) //ARANCELES DE CUOTA SOCIAL
                {
                    valorArancel = aa.valorCuotaSocial(IDSECTACT, 1, IDPROF, CAT_SOC);
                }

                if (valorArancel == 0)
                {
                    lbArancel.Visible = false;
                    tbArancel.Visible = true;
                    tbArancel.Focus();
                    arancel_general = 0;
                    a = 1;
                }
                else
                {
                    lbArancel.Visible = true;
                    tbArancel.Visible = false;
                    lbArancel.Text = valorArancel.ToString();
                    arancel_general = valorArancel;
                    cbCuentasDebe.Focus();
                    a = 2;
                }
            }

            cbFormaDePago.SelectedValue = 1;
            int SECUENCIA = var_Secuencia;
            secuencia = SECUENCIA;

            if (idprof != 0)
            {
                lbNombreProf.Text = np.nombre(IDPROF);
                lbNombreProf.Visible = true;
                lbProfesional.Visible = true;
            }

            lbNombreSocio.Text = var_Apellido + ", " + var_Nombre;
            lbSectAct.Text = sa.sectact(IDSECTACT);

            if (numero_de_recibo == "") //RECIBO NUEVO
            {
                int numero_recibo = 0;

                if (RECIBO_BONO == "R")
                {
                    if (VGlobales.PTO_VTA_N == "0004")
                    {
                        //RECIBO NUEVO
                        numero_recibo = nr.obtenerNroComprobante("RECIBO", VGlobales.PTO_VTA_N);
                        recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;
                        lbNroRecibo.Text = (numero_recibo + 1).ToString();
                        cbPtoVta.SelectedValue = VGlobales.PTO_VTA_N;

                        if (REINTEGRO == "SI")
                        {
                            numero_recibo = nr.obtenerNroComprobante("RECIBO", "0005");
                            recibo_id = int.Parse(mid.m("ID", "RECIBOS_CAJA")) + 1;
                            lbNroRecibo.Text = (numero_recibo + 1).ToString();
                            cbPtoVta.SelectedValue = "0005";
                        }
                    }
                    else
                    {
                        //RECIBOS RESERVADOS
                        numero_recibo = nr.obtenerNumeracionReservada(VGlobales.PTO_VTA_N, "RECIBOS_CAJA");
                        recibo_id = nr.obtenerIdReservado(VGlobales.PTO_VTA_N, "RECIBOS_CAJA", numero_recibo);
                        lbDisponibles.Text = "DISPONIBLES - " + comprobantesRestantes("RECIBOS_CAJA", VGlobales.PTO_VTA_N).ToString();

                        if (numero_recibo > 0)
                        {
                            lbNroRecibo.Visible = false;
                            tbNroRecibo.Visible = true;
                            tbNroRecibo.Text = numero_recibo.ToString();
                            tbNroRecibo.ReadOnly = true;
                            comboPtoVta(0);
                            cbPtoVta.SelectedValue = VGlobales.PTO_VTA_N;
                            MODIFICAR = "SI";
                        }
                        else
                        {
                            tbNroRecibo.Visible = false;
                            lbNroRecibo.Visible = true;
                            lbNroRecibo.Text = "SOLICITAR COMPROBANTES";
                            lbNroRecibo.ForeColor = Color.Red;
                            groupBox1.Enabled = false;
                        }
                    }
                }

                if (RECIBO_BONO == "B")
                {
                    if (VGlobales.PTO_VTA_N == "0004")
                    {
                        //BONO
                        numero_recibo = nr.obtenerNroComprobante("BONO", VGlobales.PTO_VTA_N);
                        recibo_id = int.Parse(mid.m("ID", "BONOS_CAJA")) + 1;
                        lbNroRecibo.Text = (numero_recibo + 1).ToString();
                        cbPtoVta.SelectedValue = VGlobales.PTO_VTA_N;

                        if (REINTEGRO == "SI")
                        {
                            numero_recibo = nr.obtenerNroComprobante("BONO", "0005");
                            recibo_id = int.Parse(mid.m("ID", "BONOS_CAJA")) + 1;
                            lbNroRecibo.Text = (numero_recibo + 1).ToString();
                            cbPtoVta.SelectedValue = "0005";
                        }
                    }
                    else
                    {
                        //BONOS RESERVADOS
                        numero_recibo = nr.obtenerNumeracionReservada(VGlobales.PTO_VTA_N, "BONOS_CAJA");
                        recibo_id = nr.obtenerIdReservado(VGlobales.PTO_VTA_N, "BONOS_CAJA", numero_recibo);
                        lbDisponibles.Text = "DISPONIBLES - " + comprobantesRestantes("BONOS_CAJA", VGlobales.PTO_VTA_N).ToString();

                        if (numero_recibo > 0)
                        {
                            lbNroRecibo.Visible = false;
                            tbNroRecibo.Visible = true;
                            tbNroRecibo.Text = numero_recibo.ToString();
                            tbNroRecibo.ReadOnly = true;
                            comboPtoVta(0);
                            cbPtoVta.SelectedValue = VGlobales.PTO_VTA_N;
                            MODIFICAR = "SI";
                        }
                        else
                        {
                            tbNroRecibo.Visible = false;
                            lbNroRecibo.Visible = true;
                            lbNroRecibo.Text = "SOLICITAR COMPROBANTES";
                            lbNroRecibo.ForeColor = Color.Red;
                            groupBox1.Enabled = false;
                        }
                    }
                }

                
            }
            else if (numero_de_recibo == "0")
            {
                lbNroRecibo.Visible = false;
                tbNroRecibo.Visible = true;
            }
            else
            {
                lbNroRecibo.Text = numero_de_recibo;
            }
            
            comboCuentasDebe();
            comboCuentasHaber();
            comboFormasDePago();

            if (var_NroRecibo != "")
            {
                cbCuentasHaber.SelectedValue = CUENTA_HABER;
                cbCuentasDebe.SelectedValue = CUENTA_DEBE;
            }

            int CUENTA_ROL = nr.obtenerCuenta(VGlobales.PTO_VTA_N); //CAMBIAR AL ROLE PARA HACER DINAMICA
            cbCuentasDebe.SelectedValue = CUENTA_ROL;
            string CUENTA_PARA_NOMBRE = cbCuentasDebe.SelectedValue.ToString();
            lbNombreCuentaDebe.Text = nc.nombre(CUENTA_PARA_NOMBRE);

            if (CUENTA != 0)
            {
                cbCuentasHaber.SelectedValue = CUENTA;
                lbNombreCuentaHaber.Text = nc.nombre(cbCuentasHaber.SelectedValue.ToString());
            }
            else
            {
                cbCuentasHaber.Enabled = true;
            }

            if (numero_de_recibo != "" && numero_de_recibo != "0") //SOLO IMPRIMIR RECIBO
            {
                MODIFICAR = "IMP";
                cbSinCargo.Enabled = false;
                cbCuentasDebe.Enabled = false;
                cbCuentasHaber.Enabled = false;
                cbFormaDePago.Enabled = false;
                tbObservaciones.Enabled = false;
                cbEditarArancel.Enabled = false;
                tbFactorArancel.Enabled = false;
                dpFechaRecibo.Enabled = false;
                tbArancel.Visible = false;
                lbArancel.Visible = true;
                comboPtoVta(0);
                string query = "SELECT VALOR, OBSERVACIONES, CUENTA_DEBE, CUENTA_HABER, FECHA_RECIBO, FORMA_PAGO, PTO_VTA FROM " + TABLA + " WHERE NRO_COMP = " + numero_de_recibo + " AND PTO_VTA = " + VGlobales.PTO_VTA_N + ";";
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();

                if (foundRows.Length > 0)
                {
                    float A = float.Parse(IMPORTE.ToString());
                    cbPtoVta.SelectedValue = foundRows[0][6].ToString();
                    lbArancel.Text = A.ToString();
                    lbArancel.Enabled = false;
                    tbObservaciones.Text = foundRows[0][1].ToString();
                    cbCuentasDebe.SelectedValue = foundRows[0][2];
                    cbCuentasHaber.SelectedValue = foundRows[0][3];
                    lbNombreCuentaHaber.Text = nc.nombre(cbCuentasHaber.SelectedValue.ToString());
                    dpFechaRecibo.Text = foundRows[0][4].ToString();
                    cbFormaDePago.SelectedValue = foundRows[0][5].ToString();
                }
            }
            else if (numero_de_recibo == "0") //MODIFICAR RECIBO EN BLANCO
            {
                MODIFICAR = "SI";
                //cbEditarArancel.Enabled = false;
                //tbFactorArancel.Enabled = false;
                cbDobleDuplicado.Enabled = false;
                btnImprimirTicket.Text = BOTON;
                cbPtoVta.Enabled = true;
                lbPtoVta.Enabled = true;
                comboPtoVta(0);
            }
        }

        private void comboBancoDepo()
        {
            string QUERY = "SELECT TRIM(NOMBRE) AS NOMBRE FROM BANCOS;";
            cbBancoDepo.DataSource = null;
            cbBancoDepo.Items.Clear();
            cbBancoDepo.DataSource = dlog.BO_EjecutoDataTable(QUERY);
            cbBancoDepo.DisplayMember = "NOMBRE";
            cbBancoDepo.ValueMember = "NOMBRE";
            cbBancoDepo.SelectedItem = 0;
        }

        private void comboPtoVta(int DESTINO)
        {
            string QUERY = "SELECT PTO_VTA ||' - '|| DETALLE AS NOMBRE, PTO_VTA FROM PUNTOS_DE_VENTA ORDER BY PTO_VTA ASC";

            if (DESTINO > 0)
                QUERY = "SELECT P.PTO_VTA ||' - '|| P.DETALLE AS NOMBRE, P.PTO_VTA FROM PUNTOS_DE_VENTA P, SECTACT S WHERE S.ROL = P.ROL AND S.ID = " + DESTINO +" ORDER BY PTO_VTA ASC;";

            cbPtoVta.DataSource = null;
            cbPtoVta.Items.Clear();
            cbPtoVta.DataSource = dlog.BO_EjecutoDataTable(QUERY);
            cbPtoVta.DisplayMember = "NOMBRE";
            cbPtoVta.ValueMember = "PTO_VTA";
            cbPtoVta.SelectedItem = 0;
            this.Cargo_Combo_Pto_Vta_E(cbPtoVta.SelectedValue.ToString());

        }

        private void comboCuentasDebe()
        {
            string query = "SELECT NUMEROCTA FROM CUENTAS WHERE NUMEROCTA >= 1000 AND NUMEROCTA <= 202000 ";
            query += "OR NUMEROCTA >= 401101 AND NUMEROCTA <= 480206 ";
            query += "OR NUMEROCTA >= 301101 AND NUMEROCTA <= 301184 ";
            query += "OR NUMEROCTA >= 801100 AND NUMEROCTA <= 802000";
            query += "OR NUMEROCTA >= 301201 AND NUMEROCTA <= 301210 ORDER BY NUMEROCTA ASC;";
            cbCuentasDebe.DataSource = null;
            cbCuentasDebe.Items.Clear();
            cbCuentasDebe.DataSource = dlog.BO_EjecutoDataTable(query);
            cbCuentasDebe.DisplayMember = "NUMEROCTA";
            cbCuentasDebe.ValueMember = "NUMEROCTA";
            cbCuentasDebe.SelectedItem = 0;
        }

        private void comboCuentasHaber()
        {
            string query = "SELECT NUMEROCTA FROM CUENTAS WHERE NUMEROCTA >= 1000 AND NUMEROCTA <= 202000 ";
            query += "OR NUMEROCTA >= 401101 AND NUMEROCTA <= 480206 ";
            query += "OR NUMEROCTA >= 301101 AND NUMEROCTA <= 301184 ";
            query += "OR NUMEROCTA >= 801100 AND NUMEROCTA <= 802000";
            query += "OR NUMEROCTA >= 301201 AND NUMEROCTA <= 301210 ORDER BY NUMEROCTA ASC;";
            cbCuentasHaber.DataSource = null;
            cbCuentasHaber.Items.Clear();
            cbCuentasHaber.DataSource = dlog.BO_EjecutoDataTable(query);
            cbCuentasHaber.DisplayMember = "NUMEROCTA";
            cbCuentasHaber.ValueMember = "NUMEROCTA";
            cbCuentasHaber.SelectedItem = 0;
        }

        private void comboFormasDePago()
        {
            string query = "SELECT * FROM FORMAS_DE_PAGO ORDER BY ID ASC;";
            cbFormaDePago.DataSource = null;
            cbFormaDePago.Items.Clear();
            cbFormaDePago.SelectedItem = 0;
            cbFormaDePago.DataSource = dlog.BO_EjecutoDataTable(query);
            cbFormaDePago.DisplayMember = "DETALLE";
            cbFormaDePago.ValueMember = "ID";
        }

        private bool checkReintegro(decimal IMPORTE, int REINTEGRO_DE)
        {
            bool RET = false;
            string QUERY = "";
            string PLUS = "";

            if (reintegro == "SI")
            {
                if (IMPORTE > importe_traido)
                {
                    RET = true;
                }
                else
                {
                    if (RECIBO_BONO == "R")
                    {
                        QUERY = "SELECT SUM(VALOR) FROM RECIBOS_CAJA WHERE REINTEGRO_DE = " + reintegro_de;
                    }

                    if (RECIBO_BONO == "B")
                    {
                        QUERY = "SELECT SUM(VALOR) FROM BONOS_CAJA WHERE REINTEGRO_DE = " + reintegro_de;
                    }

                    DataRow[] FOUND = null;
                    FOUND = dlog.BO_EjecutoDataTable(QUERY).Select();
                    PLUS = FOUND[0][0].ToString();

                    /*if (PLUS  != "")
                    {
                        decimal PLUS_D = decimal.Parse(PLUS);
                        decimal DISPONIBLE = importe_traido - PLUS_D;

                        if (IMPORTE > DISPONIBLE)
                        {
                            RET = true;
                        }
                    }*/
                }
            }

            return RET;
        }

        private void guardarImprimirRecibo(string COMPROBANTE)
        {
            string FECHA_RECIBO = DateTime.Today.ToShortDateString();
            string DOBLE_DUPLICADO = "NO";
            decimal IMPORTE = 0;
            int REINTEGRO_DE = 0;
            string BANCO_DEPO = cbBancoDepo.SelectedValue.ToString();
            string PTO_VTA_N = "";
            string PTO_VTA_M = "";
            string PTO_VTA_O = "";
            int TC = (int)SOCIOS.Factura_Electronica.Tipo_Comprobante_Enum.RECIBO_C;
            int TD = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.DNI;
            int TF = (int)SOCIOS.Factura_Electronica.Tipo_FACTURACION_ENUM.UNITARIA;
            string NRO_CUIT_TRIM = NRO_CUIT.Trim();
            string NRO_DNI_TRIM = DENI.Trim();
            string CONCEPTO = "SERVICIOS PRESTADOS";
            string EXCEPTION = "";
            string NRO_FACT_ELECT = "XXXX";
            string COND_IVA = "CONSUMIDOR FINAL";
            bool RECIBOS_MULTIPLES = false;

            if (DENI != "0" && DENI != "")
            {
                TD = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.DNI;

                if (DENI.Length > 8)
                {
                    TD = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.CUIT;
                    CONCEPTO = tbObservaciones.Text.Trim();
                    COND_IVA = nr.obnenerCondicionPorCuit(DENI);
                }
            }

            if (cbPtoVta.SelectedValue.ToString() == "0005")
            {
                PTO_VTA_N = "0005"; //REINTEGROS
                PTO_VTA_O = "0005";
            }
            else
            {
                PTO_VTA_N = VGlobales.PTO_VTA_N;
                PTO_VTA_M = VGlobales.PTO_VTA_M;
                PTO_VTA_O = VGlobales.PTO_VTA_O;
            }
            
            if (cbDobleDuplicado.Checked == true)
            {
                DOBLE_DUPLICADO = "SI";
            }

            if (a == 1)
            {
                IMPORTE = decimal.Parse(tbArancel.Text.Replace(".", ","));
            }
            else
            {
                IMPORTE = decimal.Parse(lbArancel.Text.Replace(".", ","));
            }

            if (a == 1)
            {
                if (tbArancel.Text == "")
                {
                    MessageBox.Show("COMPLETAR EL CAMPO ARANCEL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbArancel.Focus();
                }
            }

            Leyenda_Profesional = bonoUtils.Leyenda_Bono_Profesional(ID_PROFESIONAL);


            bool CHECK_R = checkReintegro(IMPORTE, REINTEGRO_DE);

            if (cbCuentasDebe.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("COMPLETAR EL CAMPO CUENTA DEBE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbCuentasDebe.Focus();
            }
            else if (cbCuentasHaber.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("COMPLETAR EL CAMPO CUENTA HABER", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbCuentasHaber.Focus();
            }
            else if (CHECK_R == true)
            {
                MessageBox.Show("EL REINTEGRO NO PUEDE SER MAYOR QUE EL IMPORTE DEL COMPROBANTE", "ERROR!");
            }
            else
            {
                cs.UserID = VGlobales.vp_username;
                string DEBE = cbCuentasDebe.Text;
                string HABER = cbCuentasHaber.Text;

                if (reintegro == "SI")
                {
                    REINTEGRO_DE = reintegro_de;
                }

                try
                {
                    if (numero_de_recibo == "")
                    {
                        string NRO_COMP = (int.Parse(lbNroRecibo.Text)).ToString();
                        int NUM_COMP = int.Parse(lbNroRecibo.Text);

                        if (RECIBO_BONO == "R") //RECIBOS PROVISORIOS
                        {
                            if (TD == 99)
                            {
                                RECIBOS_MULTIPLES = true;
                                decimal CANTIDAD_FACTURAS = IMPORTE / 4999;
                                decimal CANTIDAD_FACTURAS_FLOOR = Math.Floor(CANTIDAD_FACTURAS);
                                decimal IMPORTE_FACTURADO = CANTIDAD_FACTURAS_FLOOR * 4999;
                                decimal IMPORTE_RESTANTE = IMPORTE - IMPORTE_FACTURADO;

                                for (int i = 1; i <= CANTIDAD_FACTURAS_FLOOR; i++)
                                {
                                    BO_CAJA.nuevoReciboCaja(recibo_id, int.Parse(cbCuentasDebe.Text), int.Parse(cbCuentasHaber.Text),
                                    idsectact, idsoc, 4999, cbFormaDePago.SelectedValue.ToString(), cs.UserID, idprof,
                                    lbNombreSocioTitular.Text, lbTipoSocio.Text.Substring(0, 3), tbObservaciones.Text, FECHA_RECIBO, barra,
                                    NOMBRE_SOCIO, DENI, lbTipoSocioNoTitular.Text, int.Parse(lbNroRecibo.Text), PTO_VTA_N, REINTEGRO_DE,
                                    BANCO_DEPO);
                                }

                                BO_CAJA.nuevoReciboCaja(recibo_id, int.Parse(cbCuentasDebe.Text), int.Parse(cbCuentasHaber.Text),
                                    idsectact, idsoc, IMPORTE_RESTANTE, cbFormaDePago.SelectedValue.ToString(), cs.UserID, idprof,
                                    lbNombreSocioTitular.Text, lbTipoSocio.Text.Substring(0, 3), tbObservaciones.Text, FECHA_RECIBO, barra,
                                    NOMBRE_SOCIO, DENI, lbTipoSocioNoTitular.Text, int.Parse(lbNroRecibo.Text), PTO_VTA_N, REINTEGRO_DE,
                                    BANCO_DEPO);
                            }
                            else
                            {
                                BO_CAJA.nuevoReciboCaja(recibo_id, int.Parse(cbCuentasDebe.Text), int.Parse(cbCuentasHaber.Text),
                                    idsectact, idsoc, IMPORTE, cbFormaDePago.SelectedValue.ToString(), cs.UserID, idprof,
                                    lbNombreSocioTitular.Text, lbTipoSocio.Text.Substring(0, 3), tbObservaciones.Text, FECHA_RECIBO, barra,
                                    NOMBRE_SOCIO, DENI, lbTipoSocioNoTitular.Text, int.Parse(lbNroRecibo.Text), PTO_VTA_N, REINTEGRO_DE,
                                    BANCO_DEPO);
                            }

                            if (VGlobales.vp_role == "CAJA" && RECIBOS_MULTIPLES == false) //RECIBOS ELECTRONICOS
                            {
                                if (IMPORTE > 0)
                                {
                                    string DIR = "";

                                    if (Modo_Facturacion_Produccion=="TEST")
                                        DIR = "\\\\192.168.1.6\\factura_electronica\\TEST\\" + VGlobales.PTO_VTA_O + "\\FACTURAS\\";
                                    else
                                        DIR = "\\\\192.168.1.6\\factura_electronica\\" + VGlobales.PTO_VTA_O + "\\FACTURAS\\";
                                                                   
                                    Factura_Electronica.Recibo_Request result = new Factura_Electronica.Recibo_Request();
                                    Factura_Electronica.Impresor_Factura imp_fact = new Factura_Electronica.Impresor_Factura(DIR);
                                    Factura_Electronica.FacturaCSPFA fe = new Factura_Electronica.FacturaCSPFA(int.Parse(PTO_VTA_O));
                                    result = fe.Facturo_Recibo(recibo_id, int.Parse(PTO_VTA_O), TC, TD, DENI, IMPORTE, DateTime.Now, TF);

                                    if (result.Result == true)
                                    {
                                        imp_fact.Genero_PDF(TC, int.Parse(PTO_VTA_O), result.Numero, DateTime.Now, DENI, COND_IVA, NOMBRE_SOCIO, IMPORTE,
                                            result.Cae, DateTime.Now.AddDays(10).ToShortDateString(), "ORIGINAL", CONCEPTO, recibo_id);
                                        NRO_FACT_ELECT = result.Numero.ToString();
                                    }
                                    //else
                                        //MessageBox.Show("NO SE PUDO REALIZAR EL RECIBO C\nINTENTAR NUEVAMENTE DESDE LA PLANILLA DE CAJA\n" + result.Excepcion);
                                }
                            }

                            if (reintegro == "NO") //REINTEGROS
                            {
                                BO_CAJA.reciboEnIngresos(secuencia, NRO_COMP, IMPORTE);
                                if (VGlobales.ID_CUOTA_PAGO != 0)
                                    this.Marcar_Cuota(VGlobales.ID_CUOTA_PAGO, true, Int32.Parse(NRO_COMP), Int32.Parse(cbFormaDePago.SelectedValue.ToString()), DateTime.Parse(FECHA_RECIBO));
                            }
                            else
                            {
                                if (VGlobales.ID_CUOTA_PAGO != 0)
                                    this.Desmarcar_Cuota(VGlobales.ID_CUOTA_PAGO,IMPORTE);
                              
                            }
                        }

                        if (RECIBO_BONO == "B") // BONOS PROVISORIOS
                        {
                            BO_CAJA.nuevoBonoCaja(recibo_id, int.Parse(cbCuentasDebe.Text), int.Parse(cbCuentasHaber.Text),
                                idsectact, idsoc, IMPORTE, cbFormaDePago.SelectedValue.ToString(), cs.UserID, idprof,
                                lbNombreSocioTitular.Text, lbTipoSocio.Text.Substring(0, 3), tbObservaciones.Text, FECHA_RECIBO, barra,
                                NOMBRE_SOCIO, DENI, lbTipoSocioNoTitular.Text, int.Parse(lbNroRecibo.Text), PTO_VTA_N, REINTEGRO_DE, BANCO_DEPO);

                            if (reintegro == "NO")
                            {
                                BO_CAJA.bonoEnIngresos(secuencia, NRO_COMP, IMPORTE);
                                if (VGlobales.ID_CUOTA_PAGO != 0)
                                   this.Marcar_Cuota(VGlobales.ID_CUOTA_PAGO, false, Int32.Parse(NRO_COMP), Int32.Parse(cbFormaDePago.SelectedValue.ToString()), DateTime.Parse(FECHA_RECIBO));
                            }
                            else
                            {
                                if (VGlobales.ID_CUOTA_PAGO != 0)
                                    this.Desmarcar_Cuota(VGlobales.ID_CUOTA_PAGO,IMPORTE);

                            }
                        }

                        string DETALLE = lbSectAct.Text + " - " + lbNombreProf.Text;
                        int IMPUTACION = 301207;
                        int BONO = 0;
                    }



                    if (COMPROBANTE == "RECIBO") //IMPRIME RECIBO EN A4
                    {
                        gh.gHTML(lbNroRecibo.Text, lbNombreSocio.Text, cbFormaDePago.SelectedText.ToString(), lbSectAct.Text, IMPORTE.ToString(), idprof,
                                lbNombreSocioTitular.Text, lbTipoSocio.Text.Substring(0, 3), tbObservaciones.Text, NRO_SOC, NRO_DEP, DOBLE_DUPLICADO, DENI, DEBE, HABER, PTO_VTA_N, RECIBO_BONO,Leyenda_Profesional);
                        printhtml p = new printhtml();
                        p.printHTML("recibo_temp.html");
                    }

                    if (COMPROBANTE == "TICKET") //IMPRIME TICKET EN COMANDERA
                    {
                        DateTime Hoy = DateTime.Today;
                        gh.reciboTicket(lbNroRecibo.Text, lbNombreSocio.Text, cbFormaDePago.SelectedText.ToString(), lbSectAct.Text, 
                            IMPORTE.ToString(), idprof, lbNombreSocioTitular.Text, lbTipoSocio.Text.Substring(0, 3), tbObservaciones.Text, 
                            NRO_SOC, NRO_DEP, DOBLE_DUPLICADO, DENI, DEBE, HABER, RECIBO_BONO, PTO_VTA_N, Hoy.ToString("dd/MM/yyyy"), reintegro, PTO_VTA_O, NRO_FACT_ELECT,Leyenda_Profesional);
                    }

                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("No se pudo guardar el recibo\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int comprobantesRestantes(string TABLA, string PTO_VTA)
        {
            int CANTIDAD = 0;
            string QUERY = "SELECT COUNT(ID) FROM " + TABLA + " WHERE PTO_VTA = " + PTO_VTA + " AND USUARIO_MOD = 'RESERVADO' AND CUENTA_DEBE IS NULL;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            CANTIDAD = int.Parse(foundRows[0][0].ToString());
            return CANTIDAD;
        }

        private void modificarImprimirRecibo(string COMPROBANTE, string ACCION)
        {
            float ARANCEL = 0;
            string ENBLANCO = "";
            numeroRecibo nr = new numeroRecibo();

            if (ACCION != "IMPRIMIR" && tbNroRecibo.Text == "")
            {
                MessageBox.Show("INGRESAR UN NUMERO DE COMPROBANTE", "ERROR!");
                tbNroRecibo.Focus();
            }
            else
            {
                try
                {
                    if (a == 1)
                    {
                        if (tbArancel.Text == "")
                        {
                            MessageBox.Show("INGRESAR UN VALOR PARA EL COMPROBANTE", "ERROR!");
                        }
                        else
                        {
                            ARANCEL = float.Parse(tbArancel.Text.Replace(".", ","));
                        }
                    }
                    else
                    {
                        ARANCEL = float.Parse(lbArancel.Text.Replace(".", ","));
                    }

                    string DOBLE_DUPLICADO = "NO";

                    if (cbDobleDuplicado.Checked == true)
                    {
                        DOBLE_DUPLICADO = "SI";
                    }

                    int DEBE = int.Parse(cbCuentasDebe.Text);
                    int HABER = int.Parse(cbCuentasHaber.Text);
                    string FORMA_DE_PAGO = cbFormaDePago.SelectedValue.ToString();
                    string FECHA_RECIBO = dpFechaRecibo.Text;
                    int NRO_SOC_INT = int.Parse(TIT_SOC);
                    int NRO_DEP_INT = int.Parse(TIT_DEP);
                    int ID_SOCIO = ((NRO_SOC_INT * 1000) + NRO_DEP_INT);
                    string PTO_VTA = cbPtoVta.SelectedValue.ToString();
                    string MSG = "";
                    string BANCO_DEPO = cbBancoDepo.SelectedValue.ToString();
                    string ROLE = "";
                    string ACTION = "";
                    string CAE = "";
                    string VENCE_CAE = "";
                    int PTO_VTA_E = 0;
                    int NUMERO_E = 0; ;
                    Leyenda_Profesional = bonoUtils.Leyenda_Bono_Profesional(ID_PROFESIONAL);
                   
                    if (tbNumeroElectronico.Text.Length > 0) // seba 22-04
                    {
                        NUMERO_E = Int32.Parse(tbNumeroElectronico.Text);
                    }

                    if (ACCION == "MODIFICAR")
                    {
                        int NRO_COMP = int.Parse(tbNroRecibo.Text);
                        
                        if (RECIBO_BONO == "R")
                        {
                            MSG = "RECIBO CARGADO CORRECTAMENTE";
                            ENBLANCO = nr.comprobanteVacio(NRO_COMP, PTO_VTA, "RECIBOS_CAJA").Trim();

                            if (ENBLANCO != "BLANCO" && ENBLANCO != "RESERVADO")
                            {
                                MessageBox.Show("EL RECIBO Nº " + NRO_COMP + " DEL PUNTO DE VENTA " + PTO_VTA + " NO ESTA EN BLANCO");
                            }
                            else
                            {
                                ACTION = nr.obtAccionPorPtoVta(PTO_VTA);

                                if (ACTION == "L" && tbCAE.Text == "")
                                {
                                    MessageBox.Show("EL CAMPO CAE NO PUEDE ESTAR VACÍO", "ERROR!");
                                }
                                else
                                {
                                    if(ACTION == "L")  //CARGA DE RECIBO ELECTRONICO HECHO POR WEB
                                    {
                                        CAE = tbCAE.Text.Trim();
                                        VENCE_CAE = dpVenceCAE.Text.Substring(6, 4) + "" + dpVenceCAE.Text.Substring(3, 2) + "" + dpVenceCAE.Text.Substring(0, 2);
                                        PTO_VTA_E = Int32.Parse(cbPtoVta_E.SelectedValue.ToString());  // int.Parse(PTO_VTA);
                                        NUMERO_E = NRO_COMP;
                                    }

                                    int TD = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.CONSUMIDOR_FINAL;

                                    if (DENI != "0" && DENI != "")
                                    {
                                        TD = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.DNI;

                                        if (DENI.Length > 8)
                                        {
                                            TD = (int)SOCIOS.Factura_Electronica.Tipo_Doc_Enum.CUIT;
                                        }

                                    }

                                    if (TD == 99)
                                    {
                                        decimal CANTIDAD_FACTURAS = Convert.ToDecimal(ARANCEL) / 4999;
                                        decimal CANTIDAD_FACTURAS_FLOOR = Math.Floor(CANTIDAD_FACTURAS);
                                        decimal IMPORTE_FACTURADO = CANTIDAD_FACTURAS_FLOOR * 4999;
                                        decimal IMPORTE_RESTANTE = Convert.ToDecimal(ARANCEL) - IMPORTE_FACTURADO;
                                        pbMultiples.Visible = true;
                                        pbMultiples.Step = 1;
                                        pbMultiples.Maximum = Convert.ToInt32(CANTIDAD_FACTURAS_FLOOR + 1);

                                        for (int i = 1; i <= CANTIDAD_FACTURAS_FLOOR; i++)
                                        {
                                            BO_CAJA.modificarRecibosEnBlanco(NRO_COMP, DEBE, HABER, 4999, FORMA_DE_PAGO, idsectact, VGlobales.vp_username,
                                            FECHA_RECIBO, ID_SOCIO, idprof, lbNombreSocioTitular.Text, lbTipoSocio.Text.Substring(0, 3), tbObservaciones.Text,
                                            barra, lbNombreSocio.Text, lbTipoSocioNoTitular.Text, DENI, PTO_VTA, BANCO_DEPO, CAE, VENCE_CAE, PTO_VTA_E, NUMERO_E);
                                            NRO_COMP = NRO_COMP + 1;
                                            Thread.Sleep(250);
                                            pbMultiples.PerformStep();
                                        }

                                        BO_CAJA.modificarRecibosEnBlanco(NRO_COMP, DEBE, HABER, float.Parse(IMPORTE_RESTANTE.ToString()), FORMA_DE_PAGO, idsectact, VGlobales.vp_username,
                                        FECHA_RECIBO, ID_SOCIO, idprof, lbNombreSocioTitular.Text, lbTipoSocio.Text.Substring(0, 3), tbObservaciones.Text,
                                        barra, lbNombreSocio.Text, lbTipoSocioNoTitular.Text, DENI, PTO_VTA, BANCO_DEPO, CAE, VENCE_CAE, PTO_VTA_E, NUMERO_E);
                                        pbMultiples.PerformStep();
                                        pbMultiples.Visible = false;
                                    }
                                    else
                                    {
                                        BO_CAJA.modificarRecibosEnBlanco(NRO_COMP, DEBE, HABER, ARANCEL, FORMA_DE_PAGO, idsectact, VGlobales.vp_username,
                                        FECHA_RECIBO, ID_SOCIO, idprof, lbNombreSocioTitular.Text, lbTipoSocio.Text.Substring(0, 3), tbObservaciones.Text,
                                        barra, lbNombreSocio.Text, lbTipoSocioNoTitular.Text, DENI, PTO_VTA, BANCO_DEPO, CAE, VENCE_CAE, PTO_VTA_E, NUMERO_E);
                                    }

                                    if (PTO_VTA == "0004")
                                    {
                                        MessageBox.Show(MSG);
                                    }
                                    else
                                    {
                                        if (ENBLANCO == "RESERVADO")
                                        {
                                            BO_CAJA.reciboEnIngresos(secuencia, NRO_COMP.ToString(), decimal.Parse(ARANCEL.ToString()));
                                            DateTime Hoy = DateTime.Today;
                                            gh.reciboTicket(tbNroRecibo.Text, lbNombreSocio.Text, cbFormaDePago.SelectedText.ToString(), lbSectAct.Text, ARANCEL.ToString(), idprof,
                                            lbNombreSocioTitular.Text, lbTipoSocio.Text.Substring(0, 3), tbObservaciones.Text, NRO_SOC, NRO_DEP, DOBLE_DUPLICADO, DENI, cbCuentasDebe.SelectedValue.ToString(), cbCuentasHaber.SelectedValue.ToString(), RECIBO_BONO, PTO_VTA, Hoy.ToString("dd/MM/yyyy"), "NO", "", "",Leyenda_Profesional);
                                        }

                                        if (ENBLANCO == "BLANCO")
                                        {
                                            BO_CAJA.reciboEnIngresos(secuencia, NRO_COMP.ToString(), decimal.Parse(ARANCEL.ToString()));
                                        }

                                        MessageBox.Show(MSG);
                                    }

                                    this.Close();
                                }
                            }
                        }

                        if (RECIBO_BONO == "B")
                        {
                            ENBLANCO = nr.comprobanteVacio(NRO_COMP, PTO_VTA, "BONOS_CAJA").Trim();

                            if (ENBLANCO != "BLANCO" && ENBLANCO != "RESERVADO")
                            {
                                MessageBox.Show("EL BONO Nº " + NRO_COMP + " DEL PUNTO DE VENTA " + PTO_VTA + " NO ESTA EN BLANCO");
                            }
                            else
                            {
                                BO_CAJA.modificarBonosEnBlanco(NRO_COMP, DEBE, HABER, ARANCEL, FORMA_DE_PAGO, idsectact, VGlobales.vp_username,
                                FECHA_RECIBO, ID_SOCIO, idprof, lbNombreSocioTitular.Text, lbTipoSocio.Text.Substring(0, 3), tbObservaciones.Text,
                                barra, lbNombreSocio.Text, lbTipoSocioNoTitular.Text, DENI, PTO_VTA, BANCO_DEPO);

                                if (PTO_VTA == "0004")
                                {
                                    MSG = "BONO CARGADO CORRECTAMENTE";
                                    MessageBox.Show(MSG);
                                }
                                else
                                {
                                    if (ENBLANCO == "RESERVADO")
                                    {
                                        BO_CAJA.reciboEnIngresos(secuencia, NRO_COMP.ToString(), decimal.Parse(ARANCEL.ToString()));
                                        DateTime Hoy = DateTime.Today;
                                        gh.reciboTicket(tbNroRecibo.Text, lbNombreSocio.Text, cbFormaDePago.SelectedText.ToString(), lbSectAct.Text, ARANCEL.ToString(), idprof,
                                        lbNombreSocioTitular.Text, lbTipoSocio.Text.Substring(0, 3), tbObservaciones.Text, NRO_SOC, NRO_DEP, DOBLE_DUPLICADO, DENI, cbCuentasDebe.SelectedValue.ToString(), cbCuentasHaber.SelectedValue.ToString(), RECIBO_BONO, PTO_VTA, Hoy.ToString("dd/MM/yyyy"), "NO", "", "",Leyenda_Profesional);
                                    }

                                    if (ENBLANCO == "BLANCO")
                                    {
                                        BO_CAJA.reciboEnIngresos(secuencia, NRO_COMP.ToString(), decimal.Parse(ARANCEL.ToString()));
                                    }

                                    MessageBox.Show(MSG);
                                }

                                this.Close();
                            }
                        }
                    }

                    if (ACCION == "IMPRIMIR")
                    {
                        gh.reciboTicket(lbNroRecibo.Text, lbNombreSocio.Text, cbFormaDePago.SelectedText.ToString(), lbSectAct.Text, lbArancel.Text, idprof,
                                lbNombreSocioTitular.Text, lbTipoSocio.Text.Substring(0, 3), tbObservaciones.Text, NRO_SOC, NRO_DEP, DOBLE_DUPLICADO, DENI, DEBE.ToString(), 
                                HABER.ToString(), RECIBO_BONO, PTO_VTA, FECHA_RECIBO, "NO", "", "",Leyenda_Profesional);
                      string NRO_COMP = lbNroRecibo.Text;
                        if (VGlobales.ID_CUOTA_PAGO != 0)
                            this.Marcar_Cuota(VGlobales.ID_CUOTA_PAGO, false, Int32.Parse(NRO_COMP), Int32.Parse(cbFormaDePago.SelectedValue.ToString()), DateTime.Parse(FECHA_RECIBO));

                        this.Close();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO CARGAR EL RECIBO\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        public void factorizarArancel()
        {
            decimal arancel_factorizado;
            int factor;

            if (tbFactorArancel.Text.ToString() != "")
            {
                factor = int.Parse(tbFactorArancel.Text.ToString());
                arancel_factorizado = arancel_general * factor;

                if (a == 1)
                {
                    tbArancel.Text = arancel_factorizado.ToString();
                }
                else
                {
                    lbArancel.Text = arancel_factorizado.ToString();
                }
            }
            else
            {
                if (a == 1)
                {
                    tbArancel.Text = arancel_general.ToString();
                }
                else
                {
                    lbArancel.Text = arancel_general.ToString();
                }
            }
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            guardarImprimirRecibo("RECIBO");
            Cursor = Cursors.Default;
        }

        private void cbEditarArancel_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbEditarArancel.Checked == true)
            {
                if (lbArancel.Text != "0")
                {
                    tbArancel.Visible = true;
                    lbArancel.Visible = false;
                    tbArancel.Focus();
                    a = 1;
                }
                else
                {
                    MessageBox.Show("EL CAMPO ARANCEL YA ES EDITABLE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lbArancel.Visible = true;
                tbArancel.Visible = false;
                a = 2;
            }
        }

        private void cbSinCargo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbSinCargo.Checked == true)
            {
                if (arancel_general == 0)
                {
                    tbArancel.Visible = false;
                    lbArancel.Visible = true;
                    lbArancel.Text = "0";
                    a = 2;
                }
                else
                {
                    lbArancel.Text = "0";
                }
            }
            else
            {
                if (arancel_general == 0)
                {
                    tbArancel.Visible = true;
                    lbArancel.Visible = false;
                    a = 1;
                }
                else
                {
                    lbArancel.Text = arancel_general.ToString();
                }
            }
        }

        private void tbFactorArancel_KeyUp_1(object sender, KeyEventArgs e)
        {
            factorizarArancel();
        }

        private void cbCuentasDebe_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            lbNombreCuentaDebe.Text = nc.nombre(cbCuentasDebe.SelectedValue.ToString());
        }

        private void cbCuentasHaber_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lbNombreCuentaHaber.Text = nc.nombre(cbCuentasHaber.SelectedValue.ToString());
        }


       

        private void btnImprimirTicket_Click(object sender, EventArgs e)
        {

            bool Control = false;
            int Forma_Pago= Int32.Parse( cbFormaDePago.SelectedValue.ToString());

            if (Forma_Pago == 1) // si es efectvo, controlar que no sea mas de 9900 por dni, por fecha 
            {
                Control = Control_Efectivo();
            }

            if (Control == true)
            {
                DialogResult res = MessageBox.Show("El total de la sumatoria de  cobro en efectivo en una misma  fecha para un solo DNI es 9900, el valor total de la fecha se excede , Proceder?", "ALERTA", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                    Imprimir();
            }
            else
            {
                Imprimir();
            }

           
        }

        public void Imprimir()

        {
            if (MODIFICAR == "NO")
            {

                Cursor = Cursors.WaitCursor;
                guardarImprimirRecibo("TICKET");
                Cursor = Cursors.Default;
            }

            if (MODIFICAR == "SI")
            {
                Cursor = Cursors.WaitCursor;
                modificarImprimirRecibo("TICKET", "MODIFICAR");
                Cursor = Cursors.Default;
            }

            if (MODIFICAR == "IMP")
            {
                Cursor = Cursors.WaitCursor;
                modificarImprimirRecibo("TICKET", "IMPRIMIR");
                Cursor = Cursors.Default;
            }
        
        }

        private void Marcar_Cuota(int ID_PAGO,bool EsRecibo,int NroPago,int FormaPago,DateTime FechaPago)
        {
            int bono=0;

            int recibo=0;
            recibo = EsRecibo==true?NroPago:0;
            bono   = EsRecibo==false?NroPago:0;
            pcu.MarcarPagaCuota(ID_PAGO, NroPago, EsRecibo, FormaPago, FechaPago);
        }

        private void Desmarcar_Cuota(int ID_PAGO,decimal MONTO)
        {
            pcu.DesmarcarPagaCuota(ID_PAGO,MONTO);

        }
       
        private void cbPtoVta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string PTO_VTA = cbPtoVta.SelectedValue.ToString();
            numeroRecibo nr = new numeroRecibo();
            int CUENTA = nr.obtenerCuenta(PTO_VTA);
            cbCuentasDebe.SelectedValue = CUENTA;
            lbNombreCuentaDebe.Text = nc.nombre(cbCuentasDebe.SelectedValue.ToString());
            Cargo_Combo_Pto_Vta_E(PTO_VTA);

        }

        private void Cargo_Combo_Pto_Vta_E(string PTO)
        {
            string query = "select distinct PR.PTO_VTA PTO_VTA from puntos_de_Venta  P , puntos_de_venta PR where PR.ROL=P.ROL and P.PTO_VTA='"+PTO+"' order by P.rol ";


            cbPtoVta_E.DataSource = null;
            cbPtoVta_E.Items.Clear();
            cbPtoVta_E.DataSource = dlog.BO_EjecutoDataTable(query);
            cbPtoVta_E.DisplayMember = "PTO_VTA";
            cbPtoVta_E.ValueMember = "PTO_VTA";
            cbPtoVta_E.SelectedItem = 1;
        
        }

        public bool Control_Efectivo()
        {

            string DNI = "";
            string FECHA_RECIBO = DateTime.Today.ToShortDateString();
            string[] FR = FECHA_RECIBO.Split('/');
            string FR_FINAL = FR[1] + "/" + FR[0] + "/" + FR[2];
            decimal Valor = 0;
            decimal Valor_Control = 0;

            if (tbArancel.Visible && !lbArancel.Visible)
                Valor_Control = Decimal.Parse(tbArancel.Text);
            else
                Valor_Control = Decimal.Parse(lbArancel.Text);


            string QUERY = "Select SUM(VALOR) from RECIBOS_CAJA  WHERE DNI = '" + DENI + "' AND FECHA_RECIBO='" + FR_FINAL + "' AND FORMA_PAGO='1' ";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                if (foundRows[0][0].ToString().Length > 0)
                    Valor = Decimal.Parse(foundRows[0][0].ToString().Trim());
            }
            else
                Valor = 0;


            decimal Total = Valor + Decimal.Round( Valor_Control,2);

            if (Total > 9900)
            {

                return true;
                


            }
            else
                return false;



        }
    }
}
