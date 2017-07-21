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
    public partial class cargarObservacion : Form
    {
        bo dlog = new bo();

        public cargarObservacion(string DNI, string NOM_APE_SOC)
        {
            InitializeComponent();
            tbObservacion.Focus();
            cargarDatosSocio(DNI, NOM_APE_SOC);
            buscarObservaciones(int.Parse(DNI));
        }

        private void cargarDatosSocio(string DNI, string NOM_APE_SOC)
        {
            lvDatosSocio.Items.Clear();
            lvDatosSocio.Columns.Clear();
            lvDatosSocio.BeginUpdate();

            if (lvDatosSocio.Columns.Count == 0)
            {
                lvDatosSocio.Columns.Add("DNI");
                lvDatosSocio.Columns.Add("NOMBRE Y APELLIDO");
            }

            ListViewItem listItem = new ListViewItem(DNI);
            listItem.SubItems.Add(NOM_APE_SOC);
            lvDatosSocio.Items.Add(listItem);
            lvDatosSocio.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvDatosSocio.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void mostrarObservaciones(FbDataReader reader)
        {
            do
            {
                string FECHA = reader.GetString(reader.GetOrdinal("FECHA"));
                FECHA = DateTime.Parse(FECHA).ToShortDateString();
                    
                ListViewItem listItem = new ListViewItem(reader.GetString(reader.GetOrdinal("ID")).Trim().ToUpper());
                listItem.SubItems.Add(FECHA);
                listItem.SubItems.Add(reader.GetString(reader.GetOrdinal("OBSERVACION")).Trim());
                lvObservaciones.Items.Add(listItem);
            }

            while (reader.Read());
            lvObservaciones.EndUpdate();
            lvObservaciones.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvObservaciones.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buscarObservaciones(int DNI)
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
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
                    string busco = "SELECT * FROM OBS_INTERIOR_S(@DNI)";
                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new FbParameter("@DNI", FbDbType.Char));
                    cmd.Parameters["@DNI"].Value = DNI;
                    FbDataReader reader = cmd.ExecuteReader();
                    lvObservaciones.Items.Clear();

                    if (reader.Read())
                    {
                        mostrarObservaciones(reader);
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tbObservacion.Text == "")
            {
                MessageBox.Show("COMPLETAR EL CAMPO OBSERVACION");
                tbObservacion.Focus();
            }
            else
            {
                try
                {
                    int DNI = int.Parse(lvDatosSocio.Items[0].SubItems[0].Text);
                    string OBSERVACION = tbObservacion.Text.Trim();
                    dlog.cargarObservacionInterior(DNI, OBSERVACION);
                    buscarObservaciones(DNI);
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO CARGAR LA OBSERVACION\n" + error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lvObservaciones.SelectedItems.Count == 0)
            {
                MessageBox.Show("SELECCIONAR UNA OBSERVACION PARA ELIMINAR");
            }
            else
            {
                if (MessageBox.Show("¿CONFIRMA ELIMINAR LA OBSERVACION SELECCIONADA?", "PREGUNTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int ID = int.Parse(lvObservaciones.SelectedItems[0].SubItems[0].Text);
                    int DNI = int.Parse(lvDatosSocio.Items[0].SubItems[0].Text);
                    dlog.eliminarObservacionInterior(ID);
                    buscarObservaciones(DNI);
                }
            }
        }
    }
}
