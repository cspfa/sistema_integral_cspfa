using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class asistenciaAsamblea : Form
    {
        public asistenciaAsamblea()
        {
            InitializeComponent();
            primerIngreso();
            ultimoIngreso();
            asistencia();
            timer.Enabled = true;
        }

        private void asistencia()
        {
            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection1 = new FbConnection(connectionString))
                {
                    connection1.Open();
                    FbTransaction transaction1 = connection1.BeginTransaction();
                    string vcuento;
                    vcuento = "SELECT COUNT(A.NRO_SOC) AS ASISTEN FROM ASAMBLEA A, ";
                    vcuento = vcuento + "CONTROL_ASISTENCIA B WHERE A.ELECCION=B.ELECCION AND B.CERRADO='N'";
                    vcuento = vcuento + " AND A.TIPO=B.TIPO ";
                    FbCommand cmd1 = new FbCommand(vcuento, connection1, transaction1);
                    cmd1.CommandText = vcuento;
                    cmd1.Connection = connection1;
                    cmd1.CommandType = CommandType.Text;
                    FbDataReader reader1 = cmd1.ExecuteReader();

                    if (reader1.Read())
                    {
                        lbQuorum.Text = reader1.GetString(reader1.GetOrdinal("ASISTEN"));
                        transaction1.Commit();
                        connection1.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void primerIngreso()
        {
            try
            {
                int res;
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection1 = new FbConnection(connectionString))
                {
                    connection1.Open();
                    FbTransaction transaction1 = connection1.BeginTransaction();
                    string fcmd;
                    fcmd = "select TRIM(a.ape_soc) || ', ' || TRIM(a.nom_soc) || ' - ',  ";
                    fcmd = fcmd + " B.fe_alta ";
                    fcmd = fcmd + " from titular a, asamblea b ";
                    fcmd = fcmd + " where a.nro_soc = b.NRO_SOC ";
                    fcmd = fcmd + " and a.nro_dep = b.NRO_DEP ";
                    fcmd = fcmd + " and extract(year from current_date) = b.ELECCION ";
                    fcmd = fcmd + " and b.tipo = 'A' ";
                    fcmd = fcmd + " and b.secuencia = (Select MIN(secuencia) ";
                    fcmd = fcmd + " from asamblea ";
                    fcmd = fcmd + " where extract(year from current_date) = ELECCION ";
                    fcmd = fcmd + " and tipo = 'A')";
                    FbCommand cmd1 = new FbCommand(fcmd, connection1, transaction1);
                    cmd1.CommandText = fcmd;
                    cmd1.Connection = connection1;
                    cmd1.CommandType = CommandType.Text;
                    FbDataReader reader1 = cmd1.ExecuteReader();

                    if (reader1.Read())
                    {
                        lbPrimerIngreso.Text = reader1.GetString(0) + reader1.GetString(1);
                    }

                    transaction1.Commit();
                    connection1.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void ultimoIngreso()
        {
            try
            {
                int res;
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection1 = new FbConnection(connectionString))
                {
                    connection1.Open();
                    FbTransaction transaction1 = connection1.BeginTransaction();
                    string fcmd;
                    fcmd = "select TRIM(a.ape_soc) || ', ' || TRIM(a.nom_soc) || ' - ',  ";
                    fcmd = fcmd + " B.fe_alta ";
                    fcmd = fcmd + " from titular a, asamblea b ";
                    fcmd = fcmd + " where a.nro_soc = b.NRO_SOC ";
                    fcmd = fcmd + " and a.nro_dep = b.NRO_DEP ";
                    fcmd = fcmd + " and extract(year from current_date) = b.ELECCION ";
                    fcmd = fcmd + " and b.tipo = 'A' ";
                    fcmd = fcmd + " and b.secuencia = (Select MAX(secuencia) ";
                    fcmd = fcmd + " from asamblea ";
                    fcmd = fcmd + " where extract(year from current_date) = ELECCION ";
                    fcmd = fcmd + " and tipo = 'A')";
                    FbCommand cmd1 = new FbCommand(fcmd, connection1, transaction1);
                    cmd1.CommandText = fcmd;
                    cmd1.Connection = connection1;
                    cmd1.CommandType = CommandType.Text;
                    FbDataReader reader1 = cmd1.ExecuteReader();

                    if (reader1.Read())
                    {
                        lbUltimoIngreso.Text = reader1.GetString(0) + reader1.GetString(1);
                    }

                    transaction1.Commit();
                    connection1.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            primerIngreso();
            ultimoIngreso();
            asistencia();
        }

        private void asistenciaAsamblea_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Enabled = false;
        }

        private void btnActualizarQuorum_Click(object sender, EventArgs e)
        {
            primerIngreso();
            ultimoIngreso();
            asistencia();
        }
    }
}
