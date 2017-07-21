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
    public partial class Quorum : MicroFour.StrataFrame.UI.Windows.Forms.StandardForm
    {
        public Quorum()
        {
            InitializeComponent();
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string txtName;
                txtName = TreeView1.SelectedNode.Name.ToString();
                
                switch(txtName)
                {
                    case "AI":
                        SetAbrirIngreso();
                        break;

                    case "CI":
                      SetCerrarIngreso();
                      break;
                    
                    case "PI":
                      GetPrimerIngreso();
                      break;
                    
                    case "UI":
                      GetUltimoIngreso();
                      break;
                    
                    default :
                      label2.Text = " ";
                      label3.Text = " ";
                      MessageBox.Show("SELECCIONE ALGUN OTRO NODO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void ExplorerForm1_Load(object sender, EventArgs e)
        {
            TreeView1.ExpandAll();
        }

        private void timer1_Tick(object sender, EventArgs e)
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

                    //Asi no tiene sentido pues siempre devuelve algo el COUNT
                    if (reader1.Read()) 
                    {
                        textbox1.Text = reader1.GetString(reader1.GetOrdinal("ASISTEN"));
                        transaction1.Commit();
                        connection1.Close();
                    }
                    else
                    {
                        MessageBox.Show("NO HAY ASISTENTES A LA ASAMBLEA",
                                     "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            
        }



        private void SetAbrirIngreso()
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
                    fcmd = "UPDATE CONTROL_ASISTENCIA ";
                    fcmd = fcmd + " SET CERRADO='N'";
                    fcmd = fcmd + " WHERE ELECCION=extract(year from current_date) AND CERRADO='S'";
                    FbCommand cmd1 = new FbCommand(fcmd, connection1, transaction1);
                    cmd1.CommandText = fcmd;
                    cmd1.Connection = connection1;
                    cmd1.CommandType = CommandType.Text;
                    res = cmd1.ExecuteNonQuery();
                    // if (res == 1)
                    MessageBox.Show("INGRESO ABIERTO A LA ASAMBLEA",
                                     "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // else
                    //     MessageBox.Show ("No se pudo habilitar  el ingreso a la Asamblea");

                    transaction1.Commit();
                    connection1.Close();
                }
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }


        }

        private void SetCerrarIngreso()
        {
            try
            {
                int res;
                conString conString = new conString();
                string connectionString = conString.get();
               
                using(FbConnection connection1 = new FbConnection(connectionString))
                {
                    connection1.Open();
                    FbTransaction transaction1 = connection1.BeginTransaction();
                    string fcmd;
                    fcmd = "UPDATE CONTROL_ASISTENCIA ";
                    fcmd = fcmd + " SET CERRADO='S'";
                    fcmd = fcmd + " WHERE ELECCION=extract(year from current_date) AND CERRADO='N'";
                    FbCommand cmd1 = new FbCommand(fcmd, connection1, transaction1);
                    cmd1.CommandText = fcmd;
                    cmd1.Connection = connection1;
                    cmd1.CommandType = CommandType.Text;
                    res = cmd1.ExecuteNonQuery();
                    // if (res == 1)
                    MessageBox.Show("INGRESO CERRADO A LA ASAMBLEA",
                                         "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // else
                    //     MessageBox.Show ("No se pudo habilitar  el ingreso a la Asamblea");

                    transaction1.Commit();
                    connection1.Close();
                }
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }


        }

        
        private void GetPrimerIngreso()
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

                    fcmd = "select TRIM(a.ape_soc) || ', ' || TRIM(a.nom_soc) || ' -      ',  ";
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
                    reader1.Read();
                    label2.Text = reader1.GetString(0) + reader1.GetString(1);
                    label3.Text = "PRIMER INGRESO: ";
                    //textbox1.Text = reader1.GetString(reader1.GetOrdinal("ASISTEN"));
                    //MessageBox.Show("Ultimo Ingresado a la Asamblea");
                    //textbox1.Text = reader1.GetString(reader1.GetOrdinal("ASISTEN"));
                    //MessageBox.Show("Primer Ingresado a la Asamblea");
                    transaction1.Commit();
                    connection1.Close();
                  }
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }


        }
    
         private void GetUltimoIngreso()
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

                    fcmd = "select TRIM(a.ape_soc) || ', ' || TRIM(a.nom_soc) || ' -      ',  ";
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
                    reader1.Read();
                    label2.Text = reader1.GetString(0) + reader1.GetString(1);
                    label3.Text = "ULTIMO INGRESO: ";
                    //textbox1.Text = reader1.GetString(reader1.GetOrdinal("ASISTEN"));
                    //MessageBox.Show("Ultimo Ingresado a la Asamblea");
                    transaction1.Commit();
                    connection1.Close();
                }
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }


        }

        
    }
}