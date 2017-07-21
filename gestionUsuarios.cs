using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using FirebirdSql.Data.FirebirdClient;
using System.Data.OleDb;
using FirebirdSql.Data.Services;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class gestionUsuarios : Form
    {
        public gestionUsuarios()
        {
            InitializeComponent();
            muestraRoles();
            muestraUsuarios();
        }

        public void muestraUsuarios()
        {
            string con;
            int cmbRows = 0;

            try
            {
                Datos_ini ini1 = new Datos_ini();
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini1.Servidor;  cs.Port = int.Parse(ini1.Puerto);
                cs.Database = ini1.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Dialect = 3;
                con = cs.ToString();

                using (FbConnection connection = new FbConnection(con))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    string busco;
                    busco = "SELECT RDB$ROLE_NAME FROM RDB$ROLES ORDER BY 1";
                    FbCommand cmd = new FbCommand(busco, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        cmbRows++;
                        cbRoles.Items.Add(reader3.GetString(reader3.GetOrdinal("RDB$ROLE_NAME")));
                    }

                    if (cmbRows == 1) //Tiene exactamente 1 fila
                    {
                        cbRoles.SelectedIndex = 0; //setea ese directamente, empieza en cero
                    }

                    reader3.Close();
                    ini1 = null;
                    transaction.Commit();
                    connection.Close();
                    cs = null;
                    transaction = null;
                    FbConnection.ClearPool(connection);
                }
            }

            catch (FbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       
        public void muestraRoles()
        {
            string con;
            int cmbRows = 0;

            try
            {
                Datos_ini ini1 = new Datos_ini();
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini1.Servidor;  cs.Port = int.Parse(ini1.Puerto);
                cs.Database = ini1.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Dialect = 3;
                con = cs.ToString();

                using (FbConnection connection = new FbConnection(con))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    string busco;
                    busco = "SELECT RDB$ROLE_NAME FROM RDB$ROLES ORDER BY 1";
                    FbCommand cmd = new FbCommand(busco, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        cmbRows++;
                        cbRoles.Items.Add(reader3.GetString(reader3.GetOrdinal("RDB$ROLE_NAME")));
                    }

                    if (cmbRows == 1) //Tiene exactamente 1 fila
                    {
                        cbRoles.SelectedIndex = 0; //setea ese directamente, empieza en cero
                    }

                    reader3.Close();
                    ini1 = null;
                    transaction.Commit();
                    connection.Close();
                    cs = null;
                    transaction = null;
                    FbConnection.ClearPool(connection);
                }
            }

            catch (FbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
