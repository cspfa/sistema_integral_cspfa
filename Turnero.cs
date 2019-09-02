using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Firebird;
using Confiteria;
using System.Threading;
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

        private void Turnero_Activated(object sender, EventArgs e)
        {
            buscarLlamadas();
            mostrarLlamadas(LLAMADAS, 1);
            InitTimer();
        }

        private void buscarLlamadas()
        {
            Confiteria.Utils cu = new Confiteria.Utils();
            string QUERY = "SELECT NOMBRE, APELLIDO, PUESTO_ATENCION, SECUENCIA, ORDEN_LLEGADA FROM INGRESOS_A_PROCESAR WHERE TILDE = 'L' ORDER BY ORDEN_LLEGADA DESC;";
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

        private void llamarPersonas()
        {
            int X = 0;
            LaSusy = new SpeechSynthesizer();
            LaSusy.SelectVoice("Microsoft Sabina Desktop");
            LaSusy.Volume = 100;
            LaSusy.Rate = 0;
            dgLlamadas.ClearSelection();

            foreach (DataGridViewRow row in dgLlamadas.Rows)
            {
                string ORDEN_LLEGADA = row.Cells[0].Value.ToString().Trim();
                string NOMBRE = row.Cells[1].Value.ToString().Trim();
                string PUESTO_ATENCION = row.Cells[2].Value.ToString().Trim();
                string MENSAJE = ORDEN_LLEGADA + ", " + NOMBRE + ", POR FAVOR DIRÍJASE AL PUESTO " + PUESTO_ATENCION + ".";
                dgLlamadas.Rows[X].DefaultCellStyle.BackColor = Color.FromArgb(229, 94, 64);
                LaSusy.Speak(MENSAJE);
                dgLlamadas.Rows[X].DefaultCellStyle.BackColor = Color.FromArgb(148, 177, 83);
                X++;
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
                    string[] NOMBRE_SPLIT = NOMBRE.Split(' ');
                    NOMBRE = NOMBRE_SPLIT[0];

                    string APELLIDO = row[1].ToString().Trim().Replace(" DE ", "*");
                    string[] APELLIDO_SPLIT = APELLIDO.Split('*');
                    APELLIDO = APELLIDO_SPLIT[0];

                    string PUESTO_ATENCION = row[2].ToString().Trim();
                    string ORDEN_LLEGADA = row[4].ToString().Trim();

                    dgLlamadas.Rows.Add(ORDEN_LLEGADA, NOMBRE + " " + APELLIDO, PUESTO_ATENCION);
                }

                if(PRIMERA_VEZ==0)
                    llamarPersonas();
            }

            dgLlamadas.ClearSelection();
        }

        private void Turnero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                this.Close();
            }
        }
    }
}
