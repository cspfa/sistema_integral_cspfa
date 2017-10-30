using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.bono
{   
    public partial class BonoOdontologico : SOCIOS.bono.Bono
    {
        bo dlog = new bo();
        public DatoSocio persona = new DatoSocio();
        int CodInt;
        int SecAct;
        int Profesional;
        string Actividad;
        decimal Saldo=0;
        
        public string nombreProfesional;
        public int idProfesional;
        int idBono;
        int Turno;
        PagoBonos pb;
        public int TipoPago;
        public string MODO;

        List<Tratamiento> Tratamientos;
        List<PagoBono>    PagosBono;
        string            formaPago;
        string TIPO;
        SOCIOS.arancel arancelService = new arancel();
        decimal Recargo = 0;

        
        public BonoOdontologico(DataGridViewSelectedRowCollection Personas,string pSocTitular,string pdepTitular,bool pMuestro):base(Personas,pSocTitular,pdepTitular,pMuestro)
        {
           
            this.Iniciar();
        }
         public BonoOdontologico(string pNRo_Soc, string pNro_Dep, string pBarra, string pSocTitular, string pdepTitular,int pSecAct,int pTurno,bool pMuestro,string pTipo)
            : base(pNRo_Soc, pNro_Dep, pBarra, pSocTitular, pdepTitular,pMuestro)
        {

            SecAct = pSecAct;
            DESTINO = pSecAct;
            Turno = pTurno;
            TIPO = pTipo;

            this.Iniciar();

         }

        private void Iniciar()

        {

            InitializeComponent();
        

            if (this.PersonasControl() > 2)
            {
                MessageBox.Show("Seleccione  solo una persona del grupo para otorgarle el Correspondiente Bono Odontologico", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            this.mostrarPersonas(false);
            this.ComboPrestacion();
            this.SeteoDatos();
            this.SeteoActividad(SecAct);
          
            Tratamientos = new List<Tratamiento>();
            PagosBono         = new List<PagoBono>();
          
            
        
        }

        private void SeteoDatos()

        {

            foreach (DatoSocio d in Datos)
            {
                persona = d;
            

            
            }
            
            lbEdad.Text = persona.EDAD;

            try
            {
                lbNacimiento.Text = DateTime.Parse(persona.NACIMIENTO).ToShortDateString();
            } catch (Exception ex)
            {
                lbNacimiento.Text = "";
            
            }
            lbNombre.Text = persona.APELLIDO + "," + persona.NOMBRE;
        
        }
        private void ComboPrestacion()
        {
            string Query = "select  distinct  (Trim (P.ID) || '-' ||  S.ID || '-' ||  S.CODINT) as  VALOR,(Trim (S.DETALLE) || ',' ||  P.NOMBRE)  as DETALLE from sectact S, aranceles A, Profesionales P  where S.rol ='SERVICIOS MEDICOS' and  S.Detalle Like '%ODONT%' and S.ID = A.SECTACT and A.PROFESIONAL=P.ID";

                        
            cbEspecialidad.DataSource = null;
            cbEspecialidad.Items.Clear();
            cbEspecialidad.DataSource = dlog.BO_EjecutoDataTable(Query);
            cbEspecialidad.DisplayMember = "DETALLE";
            cbEspecialidad.ValueMember = "VALOR";
            cbEspecialidad.SelectedItem = 1;


        }

        private void SeteoActividad(int SecAct)

        {
            string QUERY = "SELECT S.CODINT, S.DETALLE,PE.PROFESIONAL,P.NOMBRE FROM SECTACT S,PROF_ESP PE, PROFESIONALES P WHERE P.ID=PE.PROFESIONAL AND  S.ROL =  'TRATAMIENTO_ODONTOLOGICO' AND S.ESTADO = 1 AND S.ID =" + SecAct + " AND PE.ESPECIALIDAD=S.ID ORDER BY DETALLE;";
          DataRow[] foundRows;
          foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

          if (foundRows.Length > 0)
          {
              CodInt            = Int32.Parse(foundRows[0][0].ToString().Trim());
              Actividad         = foundRows[0][1].ToString().Trim();
              Profesional       = Int32.Parse(foundRows[0][2].ToString().Trim());
              nombreProfesional = foundRows[0][3].ToString().Trim();

              lbEspecialidad.Text = Actividad;
          }
        
        
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Grabar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Generar Bono de " + gvTratamientos.RowCount.ToString() + " Tratamientos , Forma de Pago : " + lbFormaPago.Text, "Confirmacion ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                try
                {
                    dlog.InsertOdontologico(Nro_Socio_titular, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), persona.NUM_DOC, Nro_Dep_Titular, Int32.Parse(persona.BARRA), dpFecha.Value, PROFESIONAL, SecAct, 0,Decimal.Round(Recargo + Saldo,2) ,Saldo,Recargo , srvDatosSocio.CAB.NOMBRE,srvDatosSocio.CAB.APELLIDO, persona.NACIMIENTO, persona.EDAD, persona.TELEFONO, persona.MAIL, this.srvDatosSocio.CAB.AAR, this.srvDatosSocio.CAB.ACRJP1, this.srvDatosSocio.CAB.ACRJP2, this.srvDatosSocio.CAB.ACRJP3, this.srvDatosSocio.CAB.PAR, this.srvDatosSocio.CAB.PCRJP1, this.srvDatosSocio.CAB.PCRJP2, this.srvDatosSocio.CAB.PCRJP3, tbObs.Text, nombreProfesional, lbFormaPago.Text, Turno, VGlobales.vp_username, Contralor);
                    idBono = this.GetMaxID();
                    if (idBono != 0)
                    {
                        // Preparo el Bono Para el Pago y Grabo sus tratamientos


                        bntImprimir.Visible = true;
                        this.GrabarTratamientos();
                        this.GrabarPagos();

                        this.IngresoCaja(idBono, persona.NUM_DOC, persona.NOMBRE, persona.APELLIDO, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Int32.Parse(persona.BARRA),InfoTarjeta);

                        btnPago.Visible   = false;
                        Grabar.Visible     = false;
                        Reiniciar.Visible  = false;
                        AnularBono.Visible = true;

                        if (TIPO == "TURNO")
                        {
                            dlog.UpdateTurnoBono(idBono, Turno);
                            dlog.Bono_Turno_Ins(idBono, Turno, Actividad);
                        }
                        else // Turno Devenido en Id de Secuencia de Ingreso para casos que no son turno
                            dlog.Bono_SeteoIngreso(idBono, Turno);

                        this.ImprimirBono();


                    }
                    MessageBox.Show("Bono Grabado con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch    (Exception ex)     
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
           }


        private void ImprimirBono()

        {
            string fPago = FormaPagoBono();
            if (fPago.Length > 0)
            {
                ReporteBonoOdontologico rb = new ReporteBonoOdontologico(srvDatosSocio.CAB, persona, dpFecha.Value, idBono, nombreProfesional, fPago, tbObs.Text, Decimal.Parse(lbSaldoTotal.Text));
                rb.ShowDialog();
                rb.Focus();
            }
            else
            {
                MessageBox.Show("Debe Agregar Pago del Bono para Impresion!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        
        
        }
        private void ImprimirBonoDirecto()

        {
            string fPago = FormaPagoBono();
            ReporteBonoOdontologico rb = new ReporteBonoOdontologico(srvDatosSocio.CAB, persona, dpFecha.Value, idBono, nombreProfesional, fPago, tbObs.Text, Decimal.Parse(lbSaldoTotal.Text));
            
            rb.ImprimirDirecto();
            rb.ImprimirDirecto();
            rb.ImprimirDirecto();
        
        }
        private int GetMaxID()

        {
          string QUERY = "SELECT MAX(ID) FROM Bono_Odontologico WHERE NRO_SOCIO= " + persona.NRO_SOCIO + " AND NRO_DEP=" + persona.NRO_DEP +" AND BARRA =" + persona.BARRA ;
          DataRow[] foundRows;
          foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

          if (foundRows.Length > 0)
          {
              return Int32.Parse(foundRows[0][0].ToString().Trim());
          }
          else
              return 0;





        
        
        }
        private void GrabarTratamientos()

        {
            decimal Monto;
            int codCp;
            int Sec_Act;
            //Borro Detalle si es que existe
            //string QUERY = "DELETE FROM BONO_DETALLE WHERE ID="+ idBono.ToString();
            //DataRow[] foundRows;
          
            //foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();   
          
            //Grabo Detalles  

            foreach ( DataGridViewRow r in  gvTratamientos.Rows)
            {
                Monto   = Decimal.Parse( r.Cells[6].Value.ToString().Trim());
                codCp   =Int32.Parse(r.Cells[3].Value.ToString().Trim());
                Sec_Act = Int32.Parse(r.Cells[5].Value.ToString().Trim());
                dlog.InsertBonoDetalle(idBono, Monto, CodInt, codCp, Sec_Act, VGlobales.vp_role);
            }
        
        
        }

        private void btnPago_Click(object sender, EventArgs e)
        {

            try
            {   
                    if (lbSaldoTotal.Text.Length == 0)
                        Saldo = 0;
                    else
                        Saldo = Decimal.Parse(lbSaldoTotal.Text);
                PagoBonos pb = new PagoBonos( idBono, "SERVICIOS MEDICOS",Saldo, true, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Int32.Parse(persona.BARRA), Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), srvDatosSocio.CAB.NroBeneficioTitular);

                DialogResult res = pb.ShowDialog();

                if (res == DialogResult.OK)
                {
                    lbFormaPago.Text = pb.formaPago;
                    TipoPago = pb.tipoPago;
                    Contralor = pb.NumeroContraLor;
                    PagosBono = pb.Pagos;
                    Grabar.Visible = true;
                    SaldoIngreso = pb.SaldoIngreso;
                    InfoTarjeta = pb.InfoTarjeta;
                    Recargo = pb.Recargo;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }

        }

        private void cbPrestacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataCombo("CODINT");
           
  
        }
        private int getDataCombo(string DATO)


        {
           // string Combo = ((System.Data.DataRowView)(cbPrestacion.SelectedValue)).Row.ItemArray[0].ToString();
            string Combo = cbEspecialidad.SelectedValue.ToString();
            string[] valores = Combo.Split('-');

            try
            {
                switch (DATO)
                {
                    case "PROF":
                        return Int32.Parse(valores[0].ToString());
                        break;
                    case "SECACT":
                        return Int32.Parse(valores[1].ToString());
                        break;

                    case "CODINT":
                        return Int32.Parse(valores[2].ToString());
                        break;




                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void NuevoBank_Click(object sender, EventArgs e)
        {
            NuevoBank.Enabled = false;
            this.IniciarGpOdonto();
        }
        
        private void IniciarGpOdonto()
        {
            gpOdonto.Visible = true;

            this.parche_Tratamiento_Odontologico();

            this.ComboTratamiento();
            gvTratamientos.DataSource = null;
            gvTratamientos.Refresh();

            if (cbTratamiento.Text.Trim().Length > 0)
                tbMonto.Text = Seteo_Arancel().ToString("0.##");
        
        
        }

        private void parche_Tratamiento_Odontologico()

        {
            if (idProfesional == 26)
            {
                idProfesional = Int32.Parse(Config.getValor("SERVICIOS_MEDICOS", "ANER", 1));
            }
        }

        private void ComboTratamiento()

        {   //Se agrega el campo codcp
            string Query = "select  ID,DETALLE FROM SECTACT WHERE ROL='TRATAMIENTO_ODONTOLOGICO' AND  CODINT=" + CodInt.ToString() + " and     ID in (select Especialidad from prof_esp where PROFESIONAL="+ idProfesional +")";

            cbTratamiento.DataSource = null;
            cbTratamiento.Items.Clear();
            cbTratamiento.DataSource = dlog.BO_EjecutoDataTable(Query);
            cbTratamiento.DisplayMember = "DETALLE";
            cbTratamiento.ValueMember = "ID";
            cbTratamiento.SelectedItem = 1;

        
        }


        #region Tratamientos
        private void btnAddTrat_Click(object sender, EventArgs e)
        {
            try
            {
                int codCp = this.getCodCp();
                if (tbMonto.Text.Length ==0)
                    throw new Exception("Ingrese Monto");

                decimal Arancel = Decimal.Parse(tbMonto.Text);
                Tratamiento trat = new Tratamiento();

                trat.CodInt = CodInt;
                trat.CodCp = codCp;
                trat.Descripcion = cbTratamiento.Text.Trim();
                trat.SecAct = Int32.Parse(cbTratamiento.SelectedValue.ToString());
                trat.Monto = Arancel;
                trat.Secuencia = Tratamientos.Count + 1;

                Tratamientos.Add(trat);
                this.UpdateGrillaTratamiento();
                

            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
           
             

        }
        private void CancelarBank_Click(object sender, EventArgs e)
        {
            if (gvTratamientos.SelectedRows.Count > 0)
            {
                int Secuencia = Int32.Parse(gvTratamientos.SelectedRows[0].Cells[0].Value.ToString());
                Tratamientos.RemoveAll(x => x.Secuencia == Secuencia);
                this.UpdateGrillaTratamiento();
            }
        }

        private int getCodCp()

        {
            string QUERY = "SELECT CODCP FROM SECTACT WHERE ID="+ cbTratamiento.SelectedValue.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return Int32.Parse(foundRows[0][0].ToString());
            }
            else
                return 0;
        
        }

        private void UpdateGrillaTratamiento()

        {
            gvTratamientos.DataSource = null;
            gvTratamientos.DataSource = Tratamientos;
            gvTratamientos.Refresh();
            this.SumaTratamiento();
           
            gvTratamientos.Columns[0].Visible = false;
            gvTratamientos.Columns[1].Visible = false;
            gvTratamientos.Columns[2].Visible = false;
            gvTratamientos.Columns[3].Visible = false;
            gvTratamientos.Columns[5].Visible = false;

            if (gvTratamientos.Rows.Count > 0)
            {
                btnPago.Visible = true;
                Reiniciar.Visible = true;
            }
        }

        private void SumaTratamiento()
        {
            decimal suma = 0;
            foreach (Tratamiento t in Tratamientos)

            {
                suma = suma + t.Monto;
            }

            lbSaldoTotal.Text = suma.ToString("0.##");
            lbSaldoTotal.Visible = true;

        
        }


        #endregion

        public void setearFormaPago(string pforma)
        {
            lbFormaPago.Text = pforma;
        
        }

        private void cbTratamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbTratamiento.Text.Trim().Length >0)
                    tbMonto.Text = Seteo_Arancel().ToString("0.##");
            }
            catch (Exception ex)

            { 
            }
        }


        private decimal Seteo_Arancel()
        {
            //VER EL TEMA DEL ARANCEL 
            int grupo;
            string valor_arancel = "";
        
            decimal Arancel;
             SOCIOS.COD_DTO dto = new SOCIOS.COD_DTO();
             int Sec_act = Int32.Parse(cbTratamiento.SelectedValue.ToString());

            string COD_DTO = dto.getCodigoDTO(persona.NRO_SOCIO,persona.NRO_DEP, persona.TABLA);
            getGrupo gg = new getGrupo();

            //30-3-2016 Parche Adherentes e Invitados Participativos
            //27-06-2016 , se le agrega si tiene fecha de baja

            if (Int32.Parse(persona.NRO_DEP) ==11 || Int32.Parse(persona.NRO_DEP) ==978 ) 
                grupo=1;
            else
                grupo=  gg.get(COD_DTO, persona.CAT_SOC);
            
            //si es familiar ,barra mayor a 3, mayor a 18
            //try por si no tiene cargada la edad ;
            try   {
                    if (persona.TABLA.ToUpper().Contains("F") && Int32.Parse(persona.BARRA) > 3 && Int32.Parse(persona.EDAD) >= 18)
                        grupo = 3;
                  }
                
            catch {
                
                  }

            if (persona.BAJA == "SI")
                grupo = 3;


            PROFESIONAL = idProfesional;

            valor_arancel = arancelService.valorGrupo(Sec_act, grupo,idProfesional).ToString(); 

                if (valor_arancel != "X")
                    return Decimal.Parse(valor_arancel);
                else
                    return  0;

                //lblArancel.Text = decimal.Round(Arancel, 2).ToString();
         }

        private void bntImprimir_Click(object sender, EventArgs e)
        {
            this.ImprimirBono();
        }

        private string FormaPagoBono()
        {
            string QUERY = "SELECT PAGO FROM Bono_Odontologico WHERE ID=" + idBono.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return foundRows[0][0].ToString();
            }
            else
                return "";


        }
  

        private void GrabarPagos()
        {
            decimal Saldo = Decimal.Parse(lbSaldoTotal.Text);
      
           dlog.PlanCuenta_Insert(Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Saldo, Saldo, idBono,TipoPago);

            maxid m = new maxid();

             int Plan = Int32.Parse(m.m("ID", "PLAN_CUENTA").ToString());
            
            foreach(PagoBono p in PagosBono)
            {


                dlog.InsertPagoBono(idBono, p.TIPO, p.MONTO, p.CUOTA, p.POC, dpFecha.Value, CodInt, 0, p.FECHA_DTO, VGlobales.vp_username, System.DateTime.Now.ToString(), srvDatosSocio.CAB.NroBeneficioTitular, VGlobales.vp_role, Int32.Parse(persona.NRO_SOCIO), Int32.Parse(persona.NRO_DEP), Int32.Parse(persona.BARRA), Nro_Socio_titular, Nro_Dep_Titular, Plan);
        
            }
        
        
        }

        private void Reiniciar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro de Limpiar Los Datos de la Pantalla?", "Confirmacion ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Tratamientos = new List<Tratamiento>();
                PagosBono = new List<PagoBono>();
                gvTratamientos.DataSource = Tratamientos;
                gpOdonto.Visible = false;
            }
        }

        private void AnularBono_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro de Anular el Bono?", "Anulacion Bono ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dlog.BajaOdontologico(idBono, VGlobales.vp_username, System.DateTime.Now);
                this.ImprimirBonoDirecto();
                MessageBox.Show("Bono Anulado con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbTotal_Click(object sender, EventArgs e)
        {

        }


        }

   
    }



