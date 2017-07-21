using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Tecnica
{
    public partial class Tickets : Form
    {
        TecnicaServices ts = new TecnicaServices();
        bo_Tecnica dlog = new bo_Tecnica();

        private int ID { get; set; }
        private string Estado { get; set; }
        private string ROL { get; set; }
        bool Modo_Solo_ROL=true;
        private string PROF { get; set; }

        private DateTime DESDE { get; set; }

        private DateTime HASTA { get; set; }
        List<Ticket> tickets = new List<Ticket>();
        public Tickets()
        {
            InitializeComponent();
            this.CargarFiltro();
            if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role.Contains("TECNICA"))
            {
                Modo_Solo_ROL = false;
                //tbSeguimiento.Visible = true;
            }

            dpDesde.Text = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 1).ToShortDateString();
            dpHasta.Text = new DateTime(System.DateTime.Now.AddMonths(1).Year, System.DateTime.Now.AddMonths(1).Month, 1).ToShortDateString();




        }

        private void CargarFiltro()

         {
             cbfiltro.Items.Add("TODOS");
             cbfiltro.Items.Add("PENDIENTE");
             cbfiltro.Items.Add("ACTIVO");
             cbfiltro.Items.Add("CANCELADO");
             cbfiltro.Items.Add("CUMPLIMENTADO");
         }

      

        private void BindData()
        {
            string Estado = cbfiltro.Text;

            if (cbfiltro.Text == "TODOS")
            {
                Estado = "NO";
            }

            dataGridView1.DataSource = ts.Tickets(0, Estado, Modo_Solo_ROL,cbFiltroFecha.Checked,dpDesde.Value,dpHasta.Value);
            tickets = ts.Tickets(0, Estado, Modo_Solo_ROL, cbFiltroFecha.Checked, dpDesde.Value, dpHasta.Value);
        }

        private void Activo_Click(object sender, EventArgs e)
        {
            Pasar_Estado(1);
        }

        private void Pasar_Estado(int Modo)
        {
            
            // aca meter control de que si tiene el mismo estado, no pasar 

            if (Modo == 1)
            {
                Estado = "ACTIVO";

            }
            else if (Modo == 2)
            {
                Estado = "CUMPLIMENTADO";

            }
            else
            {
                Estado = "CANCELADO";
            }


            if (ControlEstado(ID, Estado) == false)
            {


                PasarEstado pe = new PasarEstado(ID, Estado, Modo, ROL, PROF);
                DialogResult res = pe.ShowDialog();

                if (res == DialogResult.OK)
                {
                    MessageBox.Show("Pasado de Estado Con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.BindData();
                }
            }
            else
            {
                MessageBox.Show("El Ticket Ya tiene Ese Estado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }

        }


        public bool ControlEstado(int ID, string ESTADO)

        {
            string QUERY = "Select ID from ASISTENCIAS_TECNICAS WHERE ID=" + ID.ToString() + " AND  ESTADO ='" + ESTADO + "'";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return true;
            }
            else
                return false;



        
        }

        private void CancelarBank_Click(object sender, EventArgs e)
        {
            Pasar_Estado(3);
        }

        private void Cumplimentar_Click(object sender, EventArgs e)
        {
            Pasar_Estado(2);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ID != 0)

            {
                Seguimientos segui = new Seguimientos(ID);
                segui.ShowDialog();
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.Filtrar();
        }

        private void Filtrar()

        {
            this.BindData();
            this.Seleccion();
            reporte.Visible = true;
           
        }

        private void Seleccion()

        {
            if (dataGridView1.Rows.Count > 0)
            {
                ID = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                Estado = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                ROL = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                PROF = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                DESDE = dpDesde.Value;
                HASTA = dpHasta.Value;

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            this.Seleccion();
        }

        private void Tickets_Load(object sender, EventArgs e)
        {
            Timer MyTimer = new Timer();
            MyTimer.Interval = ( 20 * 1000); // 1 mins
            MyTimer.Tick += new EventHandler(TimerFiltro);
            MyTimer.Start();
        }

        private void TimerFiltro(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ID = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            UpdateTicket ut = new UpdateTicket(ID);
            ut.Show();



        }

        private void reporte_Click(object sender, EventArgs e)
        {
            string INFO = "filtro " + cbfiltro.Text;
            if (cbFiltroFecha.Checked)
                INFO = INFO + " - Fecha Desde: " + dpDesde.Text + " - Hasta :" + dpHasta.Text; 

          
            SOCIOS.Tecnica.ReporteTickets rt = new Tecnica.ReporteTickets(ts.ReporteTicket(tickets) ,INFO);
            rt.ShowDialog();

        }
    }
}
