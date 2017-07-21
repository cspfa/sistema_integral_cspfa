using MicroFour.StrataFrame.Data;
using System;
using System.Collections.Generic;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;
using System.Globalization;

namespace SOCIOS
{
    public partial class datosXescuela : Form
    {
        public datosXescuela()
        {
            InitializeComponent();
        }

        private void examinarTXT()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.txt";
            ofd.ShowDialog();
            string archivo = ofd.FileName;
            lbTxt.Text = archivo;
        }

        private void examinarXLS()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.xls";
            ofd.ShowDialog();
            string archivo = ofd.FileName;
            lbXls.Text = archivo;
        }

        private void eliminarRegistros()
        {
            try
            {
                string connString;
                Datos_ini ini = new Datos_ini();
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini.Servidor; cs.DataSource = ini.Puerto;
                cs.Database = ini.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connString = cs.ToString();
                string DELETE = "DELETE FROM CIRCULO_DATOS_TEMP";
                FbConnection connection = new FbConnection(connString);
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                FbCommand com = new FbCommand(DELETE, connection, transaction);
                com.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void guardarRegistros(string QUERY)
        {
            try
            {
                string connString;
                Datos_ini ini = new Datos_ini();
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini.Servidor; cs.DataSource = ini.Puerto;
                cs.Database = ini.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connString = cs.ToString();
                FbConnection connection = new FbConnection(connString);
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                FbCommand com = new FbCommand(QUERY, connection, transaction);
                com.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void llenaNetosTemp()
        {
            eliminarRegistros();

            string FILE = lbTxt.Text.Trim();
            string[] LINES = File.ReadAllLines(FILE);
            Int32 CRJP2;
            Int32 LP = 0;
            Int32 DESTINO;
            Int32 JERARQUIA;
            string NYA;
            Int32 NRO_DOC;
            string QUERY = "";
            string DELETE;
            
            pbar.Visible = true;
            pbar.Minimum = 0;
            pbar.Maximum = LINES.Length;
            pbar.Value = 0;
            pbar.Step = 1;

            foreach (string line in LINES)
            {
                Cursor = Cursors.WaitCursor;
                CRJP2 = Convert.ToInt32(line.Substring(0, 6));
                LP = Convert.ToInt32(line.Substring(6, 5));
                DESTINO = Convert.ToInt32(line.Substring(11, 3));
                JERARQUIA = Convert.ToInt32(line.Substring(14, 2));
                NYA = line.Substring(16, 35).Trim();
                NRO_DOC = Convert.ToInt32(line.Substring(51, 8));
                QUERY += "INSERT INTO CIRCULO_DATOS_TEMP (CRJP2, LP, DESTINO, JERARQUIA, NYA, NRO_DOC) VALUES (" + CRJP2 + ", " + LP + ", " + DESTINO + ", " + JERARQUIA + ", '" + NYA + "', " + NRO_DOC + ");\n";
                pbar.PerformStep();
            }

            //guardarRegistros(QUERY);

            Clipboard.SetData(DataFormats.Text, (Object)QUERY);

            pbar.Visible = false;
            Cursor = Cursors.Default;
        }

        private void btnExaminarTxt_Click(object sender, EventArgs e)
        {
            examinarTXT();
        }

        private void btnExaminarXls_Click(object sender, EventArgs e)
        {
            examinarXLS();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            llenaNetosTemp();
        }
    }
}
