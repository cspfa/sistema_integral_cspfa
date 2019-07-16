using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Firebird;
//using Confiteria;
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

        private void Turnero_Load(object sender, EventArgs e)
        {
            buscarLlamadas();
            mostrarLlamadas(LLAMADAS, 1);
            InitTimer();
        }

        private void buscarLlamadas()
        {
            //Confiteria.Utils cu = new Confiteria.Utils();
            //string QUERY = "SELECT NOMBRE, APELLIDO, PUESTO_ATENCION, SECUENCIA FROM INGRESOS_A_PROCESAR WHERE TILDE = 'L' ORDER BY SECUENCIA DESC;";
            //LLAMADAS = cu.getDataFromQuery(QUERY);
        }

        
        public void InitTimer()
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 10000; 
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
            LaSusy.Rate = -2;
            LaSusy.Speak(MENSAJE);
        }

        private void llamarPersonas()
        {
            foreach (DataGridViewRow row in dgLlamadas.Rows)
            {
                string NOMBRE = row.Cells[0].Value.ToString().Trim();
                string SECUENCIA = row.Cells[1].Value.ToString().Trim();
                string LETRA_PUESTO = row.Cells[2].Value.ToString().Trim().Substring(0, 1);
                string NUMERO_PUESTO = row.Cells[2].Value.ToString().Trim().Substring(1, 2);
                string MENSAJE = SECUENCIA + ", " + NOMBRE + ", POR FAVOR DIRIJASE AL PUESTO " + LETRA_PUESTO + ", " + NUMERO_PUESTO;
                reproducirVoz(MENSAJE);
                Thread.Sleep(2000);
            }
        }

        private void mostrarLlamadas(DataSet ds, int PRIMERA_VEZ)
        {
            dgLlamadas.Rows.Clear();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string NOMBRE = row[0].ToString().Trim();
                string APELLIDO = row[1].ToString().Trim();
                string LETRA_PUESTO = row[2].ToString().Trim().Substring(0,1);
                string NUMERO_PUESTO = row[2].ToString().Trim().Substring(1, 2);
                string SECUENCIA = row[3].ToString().Trim();
                string MENSAJE = SECUENCIA + ", " + NOMBRE + " " + APELLIDO + ", POR FAVOR DIRIJASE AL PUESTO " + LETRA_PUESTO + ", " + NUMERO_PUESTO;
                dgLlamadas.Rows.Add(NOMBRE + " " + APELLIDO, SECUENCIA, LETRA_PUESTO +""+ NUMERO_PUESTO);
            }

            dgLlamadas.ClearSelection();
        }     

        private void Turnero_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
