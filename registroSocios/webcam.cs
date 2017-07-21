using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;


namespace EjemploWebcam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BuscarDispositivos();
        }

        private bool ExistenDispositivos = false;
        private FilterInfoCollection DispositivosDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            iniciar();
        }

        public void iniciar()
        {
            if (btnIniciarCapturar.Text == "INICIAR")
            {
                if (ExistenDispositivos)
                {
                    FuenteDeVideo = new VideoCaptureDevice(DispositivosDeVideo[cboDispositivos.SelectedIndex].MonikerString);
                    FuenteDeVideo.NewFrame += new NewFrameEventHandler(video_NuevoFrame);
                    FuenteDeVideo.Start();
                    btnIniciarCapturar.Text = "CAPTURAR";
                    lbMensajes.ForeColor = System.Drawing.Color.Orange;
                    lbMensajes.Text = "CAMARA INICIADA";
                    cboDispositivos.Enabled = false;
                }
                else
                {
                    lbMensajes.ForeColor = System.Drawing.Color.Red;
                    lbMensajes.Text = "NO SE ENCONTRÓ NINGUN DISPOSITIVO";
                }
            }
            else
            {
                if (FuenteDeVideo.IsRunning)
                {
                    TerminarFuenteDeVideo();
                    btnIniciarCapturar.Text = "INICIAR";
                    lbMensajes.ForeColor = System.Drawing.Color.Green;
                    lbMensajes.Text = "FOTO CAPTURADA";
                    cboDispositivos.Enabled = true;
                }
            }
        }

        public void CargarDispositivos(FilterInfoCollection Dispositivos)
        {
            for (int i = 0; i < Dispositivos.Count; i++)
            {
                cboDispositivos.Items.Add(Dispositivos[i].Name.ToString()); //cboDispositivos es nuestro combobox
                cboDispositivos.Text = cboDispositivos.Items[0].ToString();
            }
        }

        public void BuscarDispositivos()
        {
            DispositivosDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (DispositivosDeVideo.Count == 0)
            {
                ExistenDispositivos = false;
            }
            else
            {
                ExistenDispositivos = true;
                CargarDispositivos(DispositivosDeVideo);
            }
        }

        public void TerminarFuenteDeVideo()
        {
            if (!(FuenteDeVideo == null))
            {
                if (FuenteDeVideo.IsRunning)
                {
                    FuenteDeVideo.SignalToStop();
                    FuenteDeVideo = null;
                }
            }
        }

        private void video_NuevoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pbFotoUser.Image = Imagen;
        }

        public void save()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "GRABAR FOTO";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pbFotoUser.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                lbMensajes.ForeColor = System.Drawing.Color.Green;
                lbMensajes.Text = "LA FOTO FUE GUARDADA CORRECTAMENTE";
            }
            else
            {
                lbMensajes.ForeColor = System.Drawing.Color.Red;
                lbMensajes.Text = "LA FOTO NO FUE GUARDADA";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                iniciar();
            }
        }

        private void btnIniciarCapturar_Click(object sender, EventArgs e)
        {
            iniciar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void tbLP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                iniciar();
            }

            if (e.KeyCode == Keys.W)
            {
                iniciar();
            }

            if (e.KeyCode == Keys.E)
            {
                save();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TerminarFuenteDeVideo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FuenteDeVideo.IsRunning)
            {
                TerminarFuenteDeVideo();
                btnIniciarCapturar.Text = "INICIAR";
                lbMensajes.Text = "";
                cboDispositivos.Enabled = true;
            }
        }
    }
}
