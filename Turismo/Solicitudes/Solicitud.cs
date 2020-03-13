using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SOCIOS.bono;

namespace SOCIOS.Turismo.Solicitudes
{
    public partial class Solicitud : SOCIOS.bono.Bono
    {
        public DatoSocio persona = new DatoSocio();
        TurismoUtils tu = new TurismoUtils();
        bo dlog = new bo();
        SolicitudUtils su = new SolicitudUtils();

        public Solicitud()
        {
            InitializeComponent();
        }

        public Solicitud(DataGridViewSelectedRowCollection Personas, string pSocTitular, string pdepTitular, bool pMuestro)
            : base(Personas, pSocTitular, pdepTitular, pMuestro)
        {
            InitializeComponent();

            Nro_Socio_titular = Int32.Parse(pSocTitular);
            Nro_Dep_Titular = Int32.Parse(pdepTitular);
            foreach (DatoSocio d in Datos)
            {
                persona = d;


            }
        }

        private void nvSolicitud_Click(object sender, EventArgs e)
        {
            DateTime hoy=System.DateTime.Now;
            gpSolicitud.Visible = true;
            lbCantidad.Text = this.CantidadTotalPersonas().ToString();
            this.mostrarPersonas(false);

            tu.UpdateComboHabitacionTipo(cbTipo);

            dpDesde.Value = hoy.AddDays(1);
            dpHasta.Value = hoy.AddDays(1);
            lbDias.Text   = "1";
            btnAnular.Enabled = true;
            nvSolicitud.Enabled = false;

        }

        private void dpDesde_ValueChanged(object sender, EventArgs e)
        {
            this.Dias();
        }

        private void Dias()

        {
            DateTime fecha1 = new DateTime(dpDesde.Value.Year, dpDesde.Value.Month, dpDesde.Value.Day, 0, 0, 0);
            DateTime fecha2 = new DateTime(dpHasta.Value.Year, dpHasta.Value.Month, dpHasta.Value.Day, 0, 0, 0);
            lbDias.Text =  (fecha2 - fecha1).Days.ToString();
        
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            int NroAdh=0;
            int NroDepAdh=0;
            int ID_ROL = 0;
            try
            {
                DateTime Desde = new DateTime(dpDesde.Value.Year, dpDesde.Value.Month, dpDesde.Value.Day, 0, 0, 0);
                
                if (Desde < (new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, 0, 0, 0)))
                      throw new Exception("La fecha Desde no puede ser menor a Ayer");
                                
                if (persona.TIPO == "ADH")
                {
                    NroAdh =  Int32.Parse(persona.NRO_SOCIO);
                    NroDepAdh = Int32.Parse(persona.NRO_DEP);
                }
                




  
                dlog.SOLICITUD_ALOJAMIENTO_I(dpDesde.Value, dpHasta.Value, persona.TIPO, persona.NUM_DOC, persona.NOMBRE, persona.APELLIDO,Nro_Socio_titular,Nro_Dep_Titular , Int32.Parse(persona.BARRA),NroAdh,NroDepAdh, Int32.Parse(lbCantidad.Text), Int32.Parse(cbTipo.SelectedValue.ToString()),ID_ROL);
                gpSolicitud.Visible = false;

               int ID = su.GetMaxID(persona.NRO_SOCIO, persona.NRO_DEP, dpDesde.Value, dpHasta.Value, persona.TIPO);
               
               tu.GrabarPersonas(ID, Int32.Parse(srvDatosSocio.CAB.NroSocioTitular), listaPersonas,"INTERIOR");

               MessageBox.Show("Solicitud Generada Con Exito Guardados con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dpHasta_ValueChanged(object sender, EventArgs e)
        {
            this.Dias();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            gpSolicitud.Visible = false;
            this.mostrarPersonas(true);
            nvSolicitud.Enabled = true;
            btnAnular.Enabled = false;
            
        }




    }
}
