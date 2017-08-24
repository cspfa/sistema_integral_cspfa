using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;

namespace SOCIOS
{
    public partial class listadoMovimientos : Form
    {
        bo dlog = new bo();

        public listadoMovimientos()
        {
            InitializeComponent();
            comboPersonas();
        }

        private void comboPersonas()
        {
            string QUERY = "SELECT ID, NOMBRE FROM PERSONAS WHERE ESTADO = 1 ORDER BY NOMBRE ASC;";
            cbPersonas.DataSource = null;
            cbPersonas.Items.Clear();
            cbPersonas.DataSource = dlog.BO_EjecutoDataTable(QUERY);
            cbPersonas.DisplayMember = "NOMBRE";
            cbPersonas.ValueMember = "ID";
            cbPersonas.SelectedItem = 0;
        }

        private void mostrarResultados(FbDataReader reader)
        {
            lvMovimientos.Items.Clear();
            lvMovimientos.Columns.Clear();
            lvMovimientos.BeginUpdate();
            lvMovimientos.Columns.Add("NOMBRE Y APELLIDO");
            lvMovimientos.Columns.Add("CARGO");
            lvMovimientos.Columns.Add("MOVIMIENTO");
            lvMovimientos.Columns.Add("DIA Y HORA");

            if (cbTodos.Checked == false)
            {
                lvMovimientos.Columns.Add("CARGA");
            }
            
            string NOMBRE = "";
            string CARGO = "";
            string MOVIMIENTO = "";
            string FECHA_HORA = "";
            DateTime HORA_DESDE = DateTime.Now;
            DateTime HORA_HASTA = DateTime.Now;
            TimeSpan CARGA_HORARIA = TimeSpan.FromSeconds(0);
            TimeSpan TOTAL_HORAS = TimeSpan.FromSeconds(0);

            do
            {
                NOMBRE = reader.GetString(reader.GetOrdinal("NOMBRE")).Trim().ToUpper();
                CARGO = reader.GetString(reader.GetOrdinal("CARGO")).ToUpper();
                MOVIMIENTO = reader.GetString(reader.GetOrdinal("MOVIMIENTO")).Trim();
                FECHA_HORA = reader.GetString(reader.GetOrdinal("FECHA_HORA")).Trim();

                ListViewItem listItem = new ListViewItem(NOMBRE);
                listItem.SubItems.Add(CARGO);
                listItem.SubItems.Add(MOVIMIENTO);
                listItem.SubItems.Add(FECHA_HORA);

                if (cbTodos.Checked == false)
                {
                    if (MOVIMIENTO == "ENTRADA")
                    {
                        HORA_DESDE = Convert.ToDateTime(FECHA_HORA);
                    }

                    if (MOVIMIENTO == "SALIDA")
                    {
                        HORA_HASTA = Convert.ToDateTime(FECHA_HORA);
                        CARGA_HORARIA = HORA_HASTA.Subtract(HORA_DESDE);
                        listItem.SubItems.Add(CARGA_HORARIA.ToString());
                        TOTAL_HORAS = TOTAL_HORAS.Add(CARGA_HORARIA);
                    }
                }

                lvMovimientos.Items.Add(listItem);
            }

            while (reader.Read());
            lvMovimientos.EndUpdate();
            lvMovimientos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvMovimientos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lbTotalHoras.Text = "TOTAL DE HORAS REALIZADAS: " + TOTAL_HORAS.TotalHours;
        }

        private void buscarListado(int PERSONA, string DESDE, string HASTA)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini2.Servidor; 
                cs.Port = int.Parse(ini2.Puerto);
                cs.Database = ini2.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    string QUERY = "SELECT PERSONAS.NOMBRE, CASE WHEN MOVIMIENTOS.ACCION = '1' THEN 'ENTRADA' ELSE 'SALIDA' END AS MOVIMIENTO, MOVIMIENTOS.FECHA_HORA, CARGO.CARGO ";
                    QUERY += "FROM PERSONAS, MOVIMIENTOS, CARGO WHERE MOVIMIENTOS.PERSONA = PERSONAS.ID AND CAST(MOVIMIENTOS.FECHA_HORA AS DATE) >= '" + DESDE + "' ";
                    QUERY += "AND CAST(MOVIMIENTOS.FECHA_HORA AS DATE) <= '" + HASTA + "' AND PERSONAS.CARGO = CARGO.ID ";

                    if (PERSONA != 666)
                    {
                        QUERY += " AND PERSONAS.ID = " + PERSONA;
                    }
                    
                    QUERY += " ORDER BY MOVIMIENTOS.FECHA_HORA ASC;";
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        mostrarResultados(reader);
                    }
                    else
                    {
                        MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    reader.Close();
                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            int PERSONA = 666;

            if (cbTodos.Checked == true)
            {
                cbPersonas.Enabled = false;
            }
            else
            {
                cbPersonas.Enabled = true;
                PERSONA = int.Parse(cbPersonas.SelectedValue.ToString());
            }
            
            
            char[] SEP = { '/' };
            string DESDE = dpDesde.Text;
            string[] DE = DESDE.Split(SEP);
            string FECHA_DESDE = DE[1]+"/"+DE[0]+"/"+DE[2];
            string HASTA = dpHasta.Text;
            string[] HA = HASTA.Split(SEP);
            string FECHA_HASTA = HA[1]+"/"+HA[0]+"/"+HA[2];

            buscarListado(PERSONA, FECHA_DESDE, FECHA_HASTA);
        }

        private void cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodos.Checked == true)
            {
                cbPersonas.Enabled = false;
            }
            else
            {
                cbPersonas.Enabled = true;
            }
        }

        private void imprimirListado()
        {
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _standardFontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _standardFontWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            iTextSharp.text.Font _standardFontBoldWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            iTextSharp.text.Font _mediumFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _mediumFontBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _mediumFontWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            iTextSharp.text.Font _mediumFontBoldWhite = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            BaseColor negro = new BaseColor(0, 0, 0);
            BaseColor gris = new BaseColor(230, 230, 230);
            BaseColor topo = new BaseColor(100, 100, 100);
            BaseColor blanco = new BaseColor(255, 255, 255);
            BaseColor colorFondo = new BaseColor(255, 255, 255);

            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Archivo PDF|*.pdf";
            SFD.Title = "Guardar Listado";
            string PATH = "";

            if (SFD.ShowDialog() == DialogResult.OK)
            {
                PATH = SFD.FileName;
            }

            Document doc = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(PATH, FileMode.Create));
            doc.AddTitle("MOVIMIENTOS DE PERSONAL");
            doc.AddCreator("CSPFA");
            doc.Open();

            Paragraph TITULO = new Paragraph("INGRESOS Y EGRESOS DEL DIA " + DateTime.Today.ToShortDateString(), _mediumFont);
            TITULO.Alignment = Element.ALIGN_LEFT;
            TITULO.SpacingAfter = 5;
            doc.Add(TITULO);

            PdfPTable TABLA_HEADER = new PdfPTable(4);
            TABLA_HEADER.WidthPercentage = 100;
            TABLA_HEADER.SetWidths(new float[] { 1f, 1f, 1f, 1f });

            PdfPCell CELDA_NOMBRE = new PdfPCell(new Phrase("NOMBRE Y APELLIDO", _mediumFontBoldWhite));
            CELDA_NOMBRE.BackgroundColor = topo;
            CELDA_NOMBRE.BorderColor = blanco;
            CELDA_NOMBRE.HorizontalAlignment = 0;
            CELDA_NOMBRE.FixedHeight = 16f;
            TABLA_HEADER.AddCell(CELDA_NOMBRE);

            PdfPCell CELDA_CARGO = new PdfPCell(new Phrase("CARGO", _mediumFontBoldWhite));
            CELDA_CARGO.BackgroundColor = topo;
            CELDA_CARGO.BorderColor = blanco;
            CELDA_CARGO.HorizontalAlignment = 0;
            CELDA_CARGO.FixedHeight = 16f;
            TABLA_HEADER.AddCell(CELDA_CARGO);

            PdfPCell CELDA_MOVIMIENTO = new PdfPCell(new Phrase("MOVIMIENTO", _mediumFontBoldWhite));
            CELDA_MOVIMIENTO.BackgroundColor = topo;
            CELDA_MOVIMIENTO.BorderColor = blanco;
            CELDA_MOVIMIENTO.HorizontalAlignment = 0;
            CELDA_MOVIMIENTO.FixedHeight = 16f;
            TABLA_HEADER.AddCell(CELDA_MOVIMIENTO);

            PdfPCell CELDA_FECHA_HORA = new PdfPCell(new Phrase("FECHA Y HORA", _mediumFontBoldWhite));
            CELDA_FECHA_HORA.BackgroundColor = topo;
            CELDA_FECHA_HORA.BorderColor = blanco;
            CELDA_FECHA_HORA.HorizontalAlignment = 0;
            CELDA_FECHA_HORA.FixedHeight = 16f;
            TABLA_HEADER.AddCell(CELDA_FECHA_HORA);
            int X = 0;

            foreach (ListViewItem itemRow in lvMovimientos.Items)
            {
                string NOMBRE = itemRow.SubItems[0].Text;
                string CARGO = itemRow.SubItems[1].Text;
                string MOVIMIENTO = itemRow.SubItems[2].Text;
                string FECHA_HORA = itemRow.SubItems[3].Text;

                if (X == 0)
                {
                    colorFondo = new BaseColor(255, 255, 255);
                    X++;
                }
                else
                {
                    colorFondo = new BaseColor(240, 240, 240);
                    X--;
                }

                PdfPCell DATO_NOMBRE = new PdfPCell(new Phrase(NOMBRE, _mediumFont));
                DATO_NOMBRE.BackgroundColor = colorFondo;
                DATO_NOMBRE.BorderColor = colorFondo;
                DATO_NOMBRE.HorizontalAlignment = 0;
                DATO_NOMBRE.FixedHeight = 16f;
                TABLA_HEADER.AddCell(DATO_NOMBRE);

                PdfPCell DATO_CARGO = new PdfPCell(new Phrase(CARGO, _mediumFont));
                DATO_CARGO.BackgroundColor = colorFondo;
                DATO_CARGO.BorderColor = colorFondo;
                DATO_CARGO.HorizontalAlignment = 0;
                DATO_CARGO.FixedHeight = 16f;
                TABLA_HEADER.AddCell(DATO_CARGO);

                PdfPCell DATO_MOVIMIENTO = new PdfPCell(new Phrase(MOVIMIENTO, _mediumFont));
                DATO_MOVIMIENTO.BackgroundColor = colorFondo;
                DATO_MOVIMIENTO.BorderColor = colorFondo;
                DATO_MOVIMIENTO.HorizontalAlignment = 0;
                DATO_MOVIMIENTO.FixedHeight = 16f;
                TABLA_HEADER.AddCell(DATO_MOVIMIENTO);

                PdfPCell DATO_FECHA_HORA = new PdfPCell(new Phrase(FECHA_HORA, _mediumFont));
                DATO_FECHA_HORA.BackgroundColor = colorFondo;
                DATO_FECHA_HORA.BorderColor = colorFondo;
                DATO_FECHA_HORA.HorizontalAlignment = 0;
                DATO_FECHA_HORA.FixedHeight = 16f;
                TABLA_HEADER.AddCell(DATO_FECHA_HORA);
            }

            doc.Add(TABLA_HEADER);
            doc.Close();
            writer.Close();
            MessageBox.Show("LISTADO GENERADO", "LISTO!");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimirListado();
        }

        static void OpenAdobeAcrobat(string f)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "ACROBAT.EXE";
                startInfo.Arguments = f;
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
