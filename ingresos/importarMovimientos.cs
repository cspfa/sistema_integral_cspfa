using System;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace SOCIOS
{
    public partial class importarMovimientos : Form
    {
        bo dlog = new bo();

        public importarMovimientos(string ROLE)
        {
            InitializeComponent();
            buscarMovimientos(ROLE);
        }

        private void buscarMovimientos(string ROLE)
        {
            try
            {
                conString cs = new conString();
                string connectionString = cs.getRemota(ROLE);
                DataSet ds1 = new DataSet();
                Datos_ini ini3 = new Datos_ini();
                string query = @"SELECT M.ID, M.PERSONA AS PERSONA_ID, M.ACCION AS ACCION_ID, M.FECHA_HORA, M.ALTA, M.USUARIO, 
                P.ESCALAFON AS ESCALAFON_ID, P.CARGO AS CARGO_ID, P.NOMBRE, E.ESCALAFON, C.CARGO, A.ACCION 
                FROM MOVIMIENTOS M, PERSONAS P, ESCALAFON E, CARGO C, ACCIONES A 
                WHERE P.ROL = '" + ROLE + "' AND M.PERSONA = P.ID ";         
                query += @"AND P.CARGO = C.ID AND P.ESCALAFON = E.ID AND M.ACCION = A.ID
                AND M.EXPORTADO = 'N'
                ORDER BY M.FECHA_HORA DESC";

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataTable dt1 = new DataTable("RESULTADOS");
                    dt1.Columns.Add("ID", typeof(string));
                    dt1.Columns.Add("PERSONA_ID", typeof(string));
                    dt1.Columns.Add("ACCION_ID", typeof(string));
                    dt1.Columns.Add("FECHA_HORA", typeof(string));
                    dt1.Columns.Add("ALTA", typeof(string));
                    dt1.Columns.Add("USUARIO", typeof(string));
                    dt1.Columns.Add("ESCALAFON_ID", typeof(string));
                    dt1.Columns.Add("CARGO_ID", typeof(string));
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("ESCALAFON", typeof(string));
                    dt1.Columns.Add("CARGO", typeof(string));
                    dt1.Columns.Add("ACCION", typeof(string));

                    ds1.Tables.Add(dt1);
                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    FbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string ID = reader.GetString(reader.GetOrdinal("ID"));
                        string PERSONA_ID = reader.GetString(reader.GetOrdinal("PERSONA_ID"));
                        string ACCION_ID = reader.GetString(reader.GetOrdinal("ACCION_ID"));
                        string FECHA_HORA = reader.GetString(reader.GetOrdinal("FECHA_HORA"));
                        string ALTA = reader.GetString(reader.GetOrdinal("ALTA"));
                        string USUARIO = reader.GetString(reader.GetOrdinal("USUARIO"));
                        string ESCALAFON_ID = reader.GetString(reader.GetOrdinal("ESCALAFON_ID"));
                        string CARGO_ID = reader.GetString(reader.GetOrdinal("CARGO_ID"));
                        string NOMBRE = reader.GetString(reader.GetOrdinal("NOMBRE"));
                        string ESCALAFON = reader.GetString(reader.GetOrdinal("ESCALAFON"));
                        string CARGO = reader.GetString(reader.GetOrdinal("CARGO"));
                        string ACCION = reader.GetString(reader.GetOrdinal("ACCION"));
                        dt1.Rows.Add(ID, PERSONA_ID, ACCION_ID, FECHA_HORA, ALTA, USUARIO, ESCALAFON_ID, CARGO_ID, NOMBRE, ESCALAFON, CARGO, ACCION);

                    }

                    reader.Close();
                    dgMovimientos.DataSource = dt1;
                    dgMovimientos.Columns[0].Visible = false;
                    dgMovimientos.Columns[1].Visible = false;
                    dgMovimientos.Columns[2].Visible = false;
                    dgMovimientos.Columns[4].Visible = false;
                    dgMovimientos.Columns[5].Visible = false;
                    dgMovimientos.Columns[6].Visible = false;
                    dgMovimientos.Columns[7].Visible = false;
                    
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnImportar_Click(object sender, EventArgs e) 
        {
            if(MessageBox.Show("¿IMPORTAR TODOS LOS MOVIMIENTOS?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes) 
            {
                pb.Visible = true;
                pb.Minimum = 0;
                pb.Maximum = dgMovimientos.Rows.Count;
                pb.Value = 1;
                pb.Step = 1;

                foreach(DataGridViewRow row in dgMovimientos.Rows) 
                {
                    if (row.Cells[0].Value.ToString() != "") 
                    {
                        Cursor = Cursors.WaitCursor;
                        int PERSONA=int.Parse(row.Cells[1].Value.ToString());
                        int ACCION=int.Parse(row.Cells[2].Value.ToString());
                        string FECHA_HORA=row.Cells[3].Value.ToString();
                        string ALTA=row.Cells[4].Value.ToString();
                        string USUARIO=row.Cells[5].Value.ToString();
                        string EXPORTADO = "S";

                        try
                        {
                            dlog.importarMovimientos(PERSONA, ACCION, FECHA_HORA, ALTA, USUARIO, EXPORTADO);
                            pb.PerformStep();
                            Thread.Sleep(100);
                            Cursor = Cursors.Default;
                        }
                        catch (Exception error) 
                        {
                            Cursor = Cursors.Default;
                            MessageBox.Show("OCURRIO UN ERROR\n"+error, "ERROR");
                        }
                    }
                }

                MessageBox.Show("TODOS LOS MOVIMIENTOS FUERON IMPORTADOS", "LISTO!");
            }
        }
    }
}
