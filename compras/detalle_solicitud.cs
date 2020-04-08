using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buffet;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SOCIOS
{
    public partial class detalle_solicitud : Form
    {
        Buffet.Utils utils = new Buffet.Utils();

        private int ID_SOL { get; set; }

        public detalle_solicitud(int ID_SOLICITUD)
        {
            InitializeComponent();
            ID_SOL = ID_SOLICITUD;
            lbTitle.Text = "SOLICITUD DE COMPRA #" + ID_SOLICITUD.ToString();
            llenar_detalle(ID_SOLICITUD);
            llenar_articulos(ID_SOLICITUD);
        }

        private void llenar_articulos(int ID_SOLICITUD)
        {
            DataSet ARTICULOS = utils.getDataFromQuery("SELECT A.DETALLE, TA.DETALLE, SA.CANTIDAD, SA.CANTIDAD_ENTREGADA, (SA.CANTIDAD - SA.CANTIDAD_ENTREGADA) AS PENDIENTE, SA.ID FROM ARTICULOS A, SOLICITUD_ARTICULOS SA, TIPOS_ARTICULOS TA WHERE SA.ID_SOLICITIUD = " + ID_SOLICITUD + " AND SA.ID_ARTICULO = A.ID AND TA.ID = A.TIPO ORDER BY SA.ID ASC; ");

            if (ARTICULOS.Tables.Count > 0)
            {
                DataTable dt2 = new DataTable("ARTICULOS");
                dt2.Columns.Add("DETALLE", typeof(string));
                dt2.Columns.Add("TIPO", typeof(string));
                dt2.Columns.Add("CANTIDAD", typeof(string));
                dt2.Columns.Add("ENTREGADOS", typeof(string));
                dt2.Columns.Add("PENDIENTE", typeof(string));
                dt2.Columns.Add("ID", typeof(string));

                foreach (DataRow row in ARTICULOS.Tables[0].Rows)
                {
                    dt2.Rows.Add(row[0].ToString().Trim(),
                                 row[1].ToString().Trim(),
                                 row[2].ToString().Trim(),
                                 row[3].ToString().Trim(),
                                 row[4].ToString().Trim(),
                                 row[5].ToString().Trim());
                }

                dgArticulos.DataSource = dt2;
            }
        }

        private void llenar_detalle(int ID_SOLICITUD)
        {
            DataSet DETALLE = utils.getDataFromQuery("SELECT * FROM SOLICITUDES_COMPRAS WHERE ID = " + ID_SOLICITUD + ";");            

            if (DETALLE.Tables.Count > 0)
            {
                DataTable dt1 = new DataTable("RESULTADOS");
                dt1.Columns.Add("ID", typeof(string));
                dt1.Columns.Add("ALTA", typeof(string));
                dt1.Columns.Add("USUARIO", typeof(string));
                dt1.Columns.Add("ORIGEN", typeof(string));
                dt1.Columns.Add("DESTINO", typeof(string));
                dt1.Columns.Add("ESTADO", typeof(string));
                dt1.Columns.Add("PRIORIDAD", typeof(string));
                dt1.Columns.Add("BAJA", typeof(string));
                dt1.Columns.Add("USR BAJA", typeof(string));
                
                foreach (DataRow row in DETALLE.Tables[0].Rows)
                {
                    dt1.Rows.Add(row[0].ToString().Trim(),
                                 row[1].ToString().Trim().Replace(" 00:00:00", ""),
                                 row[2].ToString().Trim(),
                                 row[3].ToString().Trim(),
                                 row[4].ToString().Trim(),
                                 row[5].ToString().Trim(),
                                 row[6].ToString().Trim(),
                                 row[7].ToString().Trim(),
                                 row[8].ToString().Trim());            
                }

                dgDetalle.DataSource = dt1;
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            #region CONFIG
            Document doc = new Document(PageSize.A4);
            //doc.SetPageSize(iTextSharp.text.PageSize.LEGAL.Rotate());
            string PATH = "";

            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Archivo PDF|*.pdf";
            SFD.Title = "Guardar Solicitud";

            if (SFD.ShowDialog() == DialogResult.OK)
            {
                PATH = SFD.FileName;
            }

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(PATH, FileMode.Create));
            doc.AddTitle("PLANILLA DE CAJA");
            doc.AddCreator("CSPFA");
            doc.Open();

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

            Paragraph header = new Paragraph("// SOLICITUD DE COMPRA # //", _standardFontBold);
            header.Alignment = Element.ALIGN_CENTER;
            header.SpacingAfter = 5;
            doc.Add(header);
            #endregion
        }

        private void BtnEntregar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgArticulos.SelectedRows)
            {
                int CANTIDAD = Convert.ToInt32(row.Cells[2].Value);
                int ENTREGAR = Convert.ToInt32(tbEntregar.Text);
                int ID = Convert.ToInt32(row.Cells[5].Value);

                if (ENTREGAR > CANTIDAD)
                {
                    MessageBox.Show("LA CANTIDAD ENTREGADA NO PUEDE SER MAYOR A LA SOLICITADA");
                }
                else
                {
                    try
                    {
                        db db = new db();
                        string QUERY = "UPDATE SOLICITUD_ARTICULOS SET CANTIDAD_ENTREGADA = " + ENTREGAR + " WHERE ID = " + ID + ";";
                        db.Ejecuto_Consulta(QUERY);
                        llenar_articulos(ID_SOL);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("OCURRIO UN ERROR \n\r" + error);
                    }
                }
            }
        }
    }
}
