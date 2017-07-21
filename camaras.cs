using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace SOCIOS
{
    public partial class camaras : Form
    {
        public camaras()
        {
            InitializeComponent();
            tbFechaDesde.Text = DateTime.Today.ToShortDateString();
            tbFechaHasta.Text = DateTime.Today.ToShortDateString();
        }

        private string ruta;
        public string _ruta
        {
            get
            {
                return ruta;
            }
            set
            {
                ruta = value;
            }
        }

        public class ItemCombo
        {
            public string ID { get; set; }
            public string TEXTO { get; set; }
            public ItemCombo(string id, string texto)
            {
                ID = id;
                TEXTO = texto;
            }
        }

        public void comboCamaras(string ruta)
        {
            cbCamaras.Items.Clear();

            try
            {
                DirectoryInfo directory = new DirectoryInfo(ruta);
                DirectoryInfo[] directories = directory.GetDirectories();
                List<ItemCombo> lista = new List<ItemCombo>();

                for (int i = 0; i < directories.Length; i++)
                {
                    string id = ((DirectoryInfo)directories[i]).Name;
                    
                    string texto = ((DirectoryInfo)directories[i]).Name.ToUpper().Replace("CSPFA", "");

                    lista.Add(new ItemCombo(id, texto));
                }

                cbCamaras.Items.Clear();
                cbCamaras.DisplayMember = "TEXTO";
                cbCamaras.ValueMember = "ID";
                cbCamaras.DataSource = lista;
                cbCamaras.SelectedItem = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnVerImagenes_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Today.ToShortDateString();
            DateTime date1 = DateTime.Parse(tbFechaDesde.Text);
            DateTime date2 = DateTime.Parse(tbFechaHasta.Text);
            DateTime time1 = DateTime.Parse(tbHoraDesde.Text);
            DateTime time2 = DateTime.Parse(tbHoraHasta.Text);
            int resultDate = DateTime.Compare(date1, date2);
            int resultTime = DateTime.Compare(time1, time2);

            if (date1.ToShortDateString() == fecha)
            {
                ruta = @"\\192.168.1.2\camaras\hoy";
            }
            else
            {
                string DAY = date1.ToShortDateString().Substring(0, 2);
                string MONTH = date1.ToShortDateString().Substring(3, 2);
                string YEAR = date1.ToShortDateString().Substring(6, 4);
                string FECHA_FINAL = YEAR + "" + MONTH + "" + DAY;
                ruta = @"\\192.168.1.2\camaras\backup\" + FECHA_FINAL;
            }

            if (resultDate < 0)
            {
                //OK COMPARO HORA
                if (resultTime < 0)
                {
                    comboCamaras(ruta);
                }
                else if (resultTime == 0)
                {
                    comboCamaras(ruta);
                }
                else
                {
                    MessageBox.Show("ERROR: LA HORA HASTA NO PUEDE SER MENOR QUE LA HORA DESDE");
                }
            }
            else if (resultDate == 0)
            {
                //OK COMPARO HORA
                if (resultTime < 0)
                {
                    comboCamaras(ruta);
                }
                else if (resultTime == 0)
                {
                    comboCamaras(ruta);
                }
                else
                {
                    MessageBox.Show("ERROR: LA HORA HASTA NO PUEDE SER MENOR QUE LA HORA DESDE");
                }
            }
            else
            {
                MessageBox.Show("ERROR: LA FECHA HASTA NO PUEDE SER MENOR QUE LA FECHA DESDE");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string camara = cbCamaras.SelectedValue.ToString();
            copiarImagenes(ruta + @"\" + camara);
        }

        public void copiarImagenes(string desde)
        {
            Cursor = Cursors.WaitCursor;

            DirectoryInfo directory = new DirectoryInfo(desde);
            FileInfo[] files = directory.GetFiles("*.jpg");

            string anoDesde = tbFechaDesde.Text.Substring(6, 4);
            string mesDesde = tbFechaDesde.Text.Substring(3, 2);
            string diaDesde = tbFechaDesde.Text.Substring(0, 2);
            string horaDesde = tbHoraDesde.Text.Substring(0, 2);
            string minutoDesde = tbHoraDesde.Text.Substring(3, 2);

            string archivoDesde = anoDesde + "" + mesDesde + "" + diaDesde + "" + horaDesde + "" + minutoDesde +"00";

            string anoHasta = tbFechaHasta.Text.Substring(6, 4);
            string mesHasta = tbFechaHasta.Text.Substring(3, 2);
            string diaHasta = tbFechaHasta.Text.Substring(0, 2);
            string horaHasta = tbHoraHasta.Text.Substring(0, 2);
            string minutoHasta = tbHoraHasta.Text.Substring(0, 2);

            string archivoHasta = anoHasta + "" + mesHasta + "" + diaHasta + "" + horaHasta + "" + minutoHasta + "00";

            string carpetaDestino = @"\\192.168.1.6\Publico\CAMARAS\" + anoDesde + "." + mesDesde + "." + diaDesde + "\\" + cbCamaras.SelectedValue.ToString().Replace(@"\\172.16.0.100\camaras\hoy", "");

            if (!Directory.Exists(carpetaDestino))
            {
                try
                {
                    Directory.CreateDirectory(carpetaDestino);
                }
                catch (Exception error)
                {
                    MessageBox.Show("ERROR: NO SE PUDO CREAR LA CARPETA");
                }
            }

            Int64 arcDesde = Int64.Parse(archivoDesde);
            Int64 arcHasta = Int64.Parse(archivoHasta);
            Int64 arc;
            string archivo;
            int contador=0;

            for (int i = 0; i < files.Length; i++)
            {
                archivo = files[i].Name.ToString().Replace("_MD.jpg", "");
                arc = Int64.Parse(archivo);
                
                if (arc >= arcDesde && arc <= arcHasta)
                {
                    contador++;
                }
            }

            progressBar1.Maximum = contador;

            for (int i = 0; i < files.Length; i++)
            {
                archivo = files[i].Name.ToString().Replace("_MD.jpg", "");
                arc = Int64.Parse(archivo);
                
                if (arc >= arcDesde && arc <= arcHasta)
                {
                    try
                    {
                        File.Copy(desde + @"\" + files[i].Name, carpetaDestino + @"\" + files[i].Name);
                        progressBar1.PerformStep();
                    }
                    catch (Exception error)
                    { 
                        MessageBox.Show("ERROR: NO SE PUDO COPIAR EL ARCHIVO");
                    }
                }
            }

            MessageBox.Show("COPIA FINALIZADA");
            Cursor = Cursors.Default;
            progressBar1.Value = 0;
            cbCamaras.DataSource = null;
        }
    }
}
