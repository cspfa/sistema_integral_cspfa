using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Firebird;
using System.Threading;
using Buffet;
using System.Speech.Synthesis;

namespace SOCIOS
{
    public partial class Turnero : Form
    {
        DataSet LLAMADAS = null;
        private System.Windows.Forms.Timer timer1;
        public static SpeechSynthesizer LaSusy;

        public Turnero()
        {
            InitializeComponent();
        }

        private void styleDataGrid()
        {
            dgLlamadas.EnableHeadersVisualStyles = false;
            dgLlamadas.ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent;
            dgLlamadas.RowHeadersDefaultCellStyle.BackColor = Color.Transparent;

            foreach (DataGridViewColumn col in dgLlamadas.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void Turnero_Activated(object sender, EventArgs e)
        {
            //styleDataGrid();
            buscarLlamadas();
            mostrarLlamadas(LLAMADAS, 1);
            InitTimer();
        }

        private void buscarLlamadas()
        {
            Buffet.Utils cu = new Buffet.Utils();
            string QUERY = "SELECT NOMBRE, APELLIDO, PUESTO_ATENCION, SECUENCIA, ORDEN_LLEGADA FROM INGRESOS_A_PROCESAR WHERE TILDE = 'L' ORDER BY SECUENCIA DESC;";
            LLAMADAS = cu.getDataFromQuery(QUERY);
        }

        
        public void InitTimer()
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 2000; 
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buscarLlamadas();
            mostrarLlamadas(LLAMADAS, 0);
        }

        private void reproducirVoz(string MENSAJE)
        {
            LaSusy = new SpeechSynthesizer();
            LaSusy.SelectVoice("Microsoft Sabina Desktop");
            LaSusy.Volume = 100;
            LaSusy.Rate = 0;
            LaSusy.Speak(MENSAJE);
        }

        private void llamarPersonas()
        {
            foreach (DataGridViewRow row in dgLlamadas.Rows)
            {
                //dgLlamadas.ClearSelection();
                //dgLlamadas.Rows[row.Index].Selected = true;
                string ORDEN_LLEGADA = row.Cells[0].Value.ToString().Trim();
                string NOMBRE = row.Cells[1].Value.ToString().Trim();
                string LETRA_PUESTO = row.Cells[2].Value.ToString().Trim().Substring(0, 1);
                string NUMERO_PUESTO = row.Cells[2].Value.ToString().Trim().Substring(1, 2);
                string MENSAJE = ORDEN_LLEGADA + ", " + NOMBRE + ", POR FAVOR DIRIJASE AL PUESTO " + LETRA_PUESTO + ", " + NUMERO_PUESTO;
                reproducirVoz(MENSAJE);
                Thread.Sleep(1000);
            }
        }

        private void mostrarLlamadas(DataSet ds, int PRIMERA_VEZ)
        {
            dgLlamadas.Rows.Clear();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string NOMBRE = row[0].ToString().Trim();
                    string APELLIDO = row[1].ToString().Trim();
                    string LETRA_PUESTO = row[2].ToString().Trim().Substring(0, 1);
                    string NUMERO_PUESTO = row[2].ToString().Trim().Substring(1, 2);
                    string ORDEN_LLEGADA = row[4].ToString().Trim();
                    dgLlamadas.Rows.Add(ORDEN_LLEGADA, NOMBRE + " " + APELLIDO, LETRA_PUESTO + "" + NUMERO_PUESTO);
                }

                if(PRIMERA_VEZ==0)
                    llamarPersonas();
            }

            dgLlamadas.ClearSelection();
        }

        private void Turnero_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
