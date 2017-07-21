using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOCIOS.bono;
   

namespace SOCIOS.Turismo.Solicitudes
{
    public partial class ProcesoSolicitudes : Form
    {
        SolicitudUtils su = new SolicitudUtils();
        TurismoUtils tu   = new TurismoUtils();
        int ID;
        public SOCIOS.bono.handlerDatosSocios srvDatosSocio;
        bo dLog = new bo();
        List<DatoFecha> fechas = new List<DatoFecha>();
        List<Habitacion> Alojamiento=new List<Habitacion>();
        int Total = 0;

        SOCIOS.Turismo.Solicitud Solicitud;


        public ProcesoSolicitudes()
        {
            InitializeComponent();

            gvSolicitudes.DataSource = su.getSolicitudes(0);
            

            this.FormateoGrillaSolicitudes();


            
            
        }

     
        #region Grillas
        private void gvSolicitudes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvSolicitudes.SelectedRows[0].Cells[0].Value.ToString() != "")
            {
                ID = Int32.Parse(gvSolicitudes.SelectedRows[0].Cells[0].Value.ToString());



                Solicitud = su.getSolicitudes(ID).FirstOrDefault();

              
                dpDesde.Value = Solicitud.Desde;
                dpHasta.Value = Solicitud.Hasta;
                tu.UpdateComboHabitacionTipo(cbTipo);
                cbTipo.SelectedValue = Solicitud.Habitacion_ID.ToString();
                this.Dias();


                if (Solicitud.Procesada == 1)
                    Procesar.Enabled = false;
                else
                    Procesar.Enabled = true;

            }




        }
          
        public void FormateoGrillaSolicitudes()
          
        {
                    gvSolicitudes.Columns[0].Visible = false;
                    gvSolicitudes.Columns[1].Visible = false;
                    gvSolicitudes.Columns[2].Visible = false;
                    gvSolicitudes.Columns[3].Visible = false;
                    gvSolicitudes.Columns[8].Visible = false;

                    gvSolicitudes.Columns[9].Visible = false;
                    gvSolicitudes.Columns[13].Visible = false;
                    gvSolicitudes.Columns[15].Visible = false;

                   
        }

        public void FormatearGrillaFechas()
        {
            if (dgvFechas.Rows.Count >0)

            {
                dgvFechas.Columns[1].Visible = false;
                foreach  ( DataGridViewRow dr in dgvFechas.Rows)
                {
                    if (bool.Parse(dr.Cells[1].Value.ToString()) == true)
                    {
                        dr.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        dr.ReadOnly = true;
                    }
            
                }
            }
        
        
        }


        #endregion
        private void Dias()
        {
            DateTime fecha1 = new DateTime(dpDesde.Value.Year, dpDesde.Value.Month, dpDesde.Value.Day, 0, 0, 0);
            DateTime fecha2 = new DateTime(dpHasta.Value.Year, dpHasta.Value.Month, dpHasta.Value.Day, 0, 0, 0);
            lbDias.Text = (fecha2 - fecha1).Days.ToString();

        }
     

        private void dpDesde_ValueChanged(object sender, EventArgs e)
        {
            this.Dias();
        }

        private void dpHasta_ValueChanged(object sender, EventArgs e)
        {
            this.Dias();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            gpUpdateSolicitud.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                dLog.SOLICITUD_ALOJAMIENTO_U(ID, dpDesde.Value, dpHasta.Value, Int32.Parse(cbTipo.SelectedValue.ToString()));
                gvSolicitudes.DataSource = su.getSolicitudes(0);
                MessageBox.Show("Datos Guardados con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gpUpdateSolicitud.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Procesar_Click(object sender, EventArgs e)
        {
            Total                = Int32.Parse(gvSolicitudes.SelectedRows[0].Cells[14].Value.ToString());
            lbTotalPersonas.Text = Total.ToString();

            this.AvanzoTab();
        }


        private void AvanzoTab()
        {
            TabPage t1 = tabSolicitudes.TabPages[0];
            TabPage t2 = tabSolicitudes.TabPages[1];

            if (tabSolicitudes.SelectedTab == t1)
            {
                t1.Enabled = false;
                this.InicializarTabHotel();
                tabSolicitudes.SelectedTab = t2;

            }
            else
                tabSolicitudes.SelectedTab = t1;
        
        }

        private void InicializarTabHotel()

        {
            dgvPersonas.DataSource = su.DatosPersonas(ID.ToString());
            this.Fechas();
            dgvFechas.DataSource = fechas;
            Solicitud = su.getSolicitudes(ID).FirstOrDefault();
        
        }

         private void Fechas()

        {
          
            
            DateTime fecha1 = new DateTime(dpDesde.Value.Year, dpDesde.Value.Month, dpDesde.Value.Day);
            DateTime fecha2 = new DateTime(dpDesde.Value.Year, dpHasta.Value.Month, dpHasta.Value.Day);


            while (fecha1 < fecha2)

            {
                fechas.Add(new DatoFecha(fecha1,false) );
                fecha1.AddDays(1);
            
            }

            fechas.Add(new DatoFecha(fecha2, false));
           
             this.FormatearGrillaFechas();
          


            
        
        }

         private void btnDisponibilidad_Click(object sender, EventArgs e)
         {
             DateTime Fecha      = DateTime.Parse(lbFecha.Text);
             int Plazas          = Int32.Parse(lbPersonas.Text);

             try
             {

                 if (!this.Valido_Cantidad_Personas(Fecha))
                     throw new Exception("No se Puede Exceder la Cantidad de Personas de La solicitud para esa fecha ");

                 SOCIOS.Turismo.Hoteles.Disponibilidad_Habitacion dispo = new Hoteles.Disponibilidad_Habitacion(Fecha, Plazas);
                 DialogResult res = dispo.ShowDialog();

                 if (res == DialogResult.OK)
                 {
                     
                     dispo.hab.Personas = this.ObtenerPersonas(dgvPersonas.SelectedRows);
                     Alojamiento.Add(dispo.hab);

                     dgvAlojamiento.DataSource = Alojamiento;
                     this.BindGrillaAlojamiento();

                     this.dgvFechas.SelectedRows[0].Selected = false;
                     dgvPersonas.SelectedRows[0].Selected = false;
                     ActualizarColorGridFecha(Fecha);
                     gpMarca.Visible = false;
                     btnConfirmar.Visible = true;


                 }
             }
             catch (Exception ex)

             {
                 MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
             }

         }



         public List<SOCIOS.Turismo.GridPersona> ObtenerPersonas(DataGridViewSelectedRowCollection Personas)
         {
             // listaPersonas.RemoveAll(x => x.Origen == Origen);
             List<SOCIOS.Turismo.GridPersona> lista = new List<GridPersona>();
             foreach (DataGridViewRow r in Personas)
             {

                
                 SOCIOS.Turismo.GridPersona item = new SOCIOS.Turismo.GridPersona();
                 item.Nombre                     = r.Cells[0].Value.ToString().Trim();
                 item.Apellido                   = r.Cells[1].Value.ToString().Trim();
                 item.Dni                        = r.Cells[4].Value.ToString().Trim();
                




                 lista.Add(item);





                 
             }

             return lista;
         }

         
         
         


         private void ActualizarColorGridFecha(DateTime pfecha)

         {
             
             foreach (DatoFecha f in fechas)

             {
                 if (f.F.Day == pfecha.Day && f.F.Month == pfecha.Month && f.F.Year == pfecha.Year && !this.Valido_Cantidad_Personas(pfecha))
                 {
                    
                                 
                     f.lleno = true;
                 }
                     
             }

             dgvFechas.DataSource = fechas;
             this.FormatearGrillaFechas();

          



         
         }

         private void BindGrillaAlojamiento()

         {

             dgvAlojamiento.Columns[0].Visible = false;
             dgvAlojamiento.Columns[1].Visible = false;
             dgvAlojamiento.Columns[3].Visible = false;
             dgvAlojamiento.Columns[5].Visible = false;
           
             dgvAlojamiento.Columns[7].Visible = false;

             dgvAlojamiento.Columns[8].HeaderText = "Personas";
             
         
         
         }



         private void btnMarcarDisponibilidad_Click(object sender, EventArgs e)
         {

             try
             {
                 if (dgvPersonas.SelectedRows.Count == 0)
                     throw new Exception(" Seleccione personas ");
                
                 if (dgvFechas.SelectedRows.Count == 0)
                     throw new Exception("Seleccione Fechas");


                 if (dgvPersonas.SelectedRows.Count > Total)
                     throw new Exception(" Cantidad de Personas No Puede Exceder La cantidad de la solicitud ");




                 gpMarca.Visible = true;

                 lbPersonas.Text = dgvPersonas.SelectedRows.Count.ToString();

                 lbFecha.Text = DateTime.Parse(dgvFechas.SelectedRows[0].Cells[0].Value.ToString()).ToShortDateString();


             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
             
             }

         }


         private bool Valido_Cantidad_Personas(DateTime Fecha)

         {
             var sum = Alojamiento.Where(x => (x.Fecha.Day == Fecha.Day && x.Fecha.Month == Fecha.Month && x.Fecha.Year == Fecha.Year)).Sum(x => x.Disponibles);

             if (sum == null)
                 return true;
            
             if (sum > Total)
                 return false;
             else
                 return true;

         
         
         }

         private void gpSolicitud_Enter(object sender, EventArgs e)
         {

         }

         private void  ValidarTotalCargado()


         {
             if (Alojamiento.Sum(x => x.Disponibles) != Total * fechas.Count)
                 throw new Exception("Faltan Cargar Personas en las fechas de la reserva");
         
         
         
         }

         private void btnConfirmar_Click(object sender, EventArgs e)
         {

             try
             {
                 this.ValidarTotalCargado();
                 if (MessageBox.Show("Se Generan las Reservas ? ","Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {

                     
                     foreach( Habitacion h in Alojamiento  )

                     {
                         dLog.REGISTRO_ALOJAMIENTO_I(Solicitud.ID,h.Fecha, Solicitud.Nro_Socio, Solicitud.Nro_Dep, Solicitud.Nro_Adh, Solicitud.Nro_Dep_Adh, Solicitud.Barra, h.Hotel_ID,h.Habitacion_ID, h.Disponibles,  h.Bloqueo);
                        
                         int Registro = su.GetRegistroMaxID(Solicitud.Nro_Socio, Solicitud.Nro_Dep, Solicitud.Barra);

                         bool Bloqueo;

                         if (h.Bloqueo == 1)
                             Bloqueo = true;
                         else
                             Bloqueo = false;

                         dLog.HABITACION_HOTEL_OCUPACION_I(h.Fecha, Solicitud.Nro_Socio, Solicitud.Nro_Dep,Solicitud.Barra, Solicitud.Nombre, Solicitud.Apellido, Solicitud.DNI, h.Habitacion_ID, h.Disponibles, Bloqueo, Solicitud.ID, Registro);

                         foreach (GridPersona p in h.Personas)

                         {
                          dLog.Registro_Persona_I(Registro, p.Nombre, p.Apellido, p.Dni);
                         
                         }

                     }

                     dLog.SOLICITUD_ALOJAMIENTO_PROCESO(Solicitud.ID);
                     btnConfirmar.Visible = false;
                     MessageBox.Show("Solicitud Procesada", "PROCESADA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                     

                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


             }


         }

         private void gvSolicitudes_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {

         }

         private void DispoHoteles_Click(object sender, EventArgs e)
         {
             SOCIOS.Turismo.Hoteles.OcupacionDispo dh = new SOCIOS.Turismo.Hoteles.OcupacionDispo();
             

             dh.ShowDialog();
         }

         private void gvSolicitudes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
         {
             DataGridViewRow row = gvSolicitudes.Rows[e.RowIndex];// get you required index
            if ( row.Cells[15].Value.ToString() =="1")
               row.DefaultCellStyle.BackColor = Color.Red;
         }





       
    }
}
