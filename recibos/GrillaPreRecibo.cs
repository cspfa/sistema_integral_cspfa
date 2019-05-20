using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS
{
    public partial class GrillaPreRecibo : Form
    {
        bo dlog = new bo();
        BO.bo_Caja BO_CAJA = new BO.bo_Caja();

        public GrillaPreRecibo()
        {
            InitializeComponent();
        }

        private void Llenar_grilla(string FECHA, string IMPRESO)
        {
            string v_consulta = "";

            try
            {
                v_consulta = "SELECT CASE TIP_SOCIO WHEN 'ADH' THEN A.NRO_ADH WHEN 'INP' THEN A.NRO_ADH WHEN 'VIS' THEN A.NRO_SOC ELSE A.NRO_SOC END AS NRO_SOC,";
                v_consulta = v_consulta + " CASE TIP_SOCIO WHEN 'ADH' THEN A.NRO_DEPADH WHEN 'INP' THEN A.NRO_DEPADH WHEN 'VIS' THEN A.NRO_DEP ELSE A.NRO_DEP END AS NRO_DEP,";
                v_consulta = v_consulta + " A.APELLIDO, A.NOMBRE, A.TIP_SOCIO, A.ROL, A.ID_DESTINO, A.ID_PROFESIONAL, A.SECUENCIA, A.BARRA, A.COD_DTO, SA.DETALLE, P.NOMBRE AS NOMBREPROF,";
                v_consulta = v_consulta + " A.NRO_RECIBO, A.NRO_SOC AS NUMERO_SOCIO, A.NRO_DEP AS NUMERO_DEPURACION, A.NRO_BONO, P.BONO_RECIBO, P.CUENTA, A.DNI, A.GRUPO, A.IMPORTE , A.NRO_PAGO NRO_PAGO, A.CUIL,A.DESTINO DESTINO_DETA ";
                v_consulta = v_consulta + " FROM INGRESOS_A_PROCESAR A, SECTACT SA, PROFESIONALES P";
                v_consulta = v_consulta + " WHERE A.ID_DESTINO IN (SELECT C.SECTACT FROM ARANCELES C WHERE C.FE_BAJA IS NULL GROUP BY C.SECTACT) AND A.ID_DESTINO <> 50 AND A.SECUENCIA > 268461";


                if (VGlobales.vp_role == "INTERIOR")
                {
                    v_consulta = v_consulta + " AND A.ROL = 'ALOJAMIENTO'";
                }
                else if (VGlobales.vp_role != "CAJA" && VGlobales.vp_role != "INFORMES" && VGlobales.vp_role != "SISTEMAS" && VGlobales.vp_role != "CONTADURIA" && VGlobales.vp_role != "CAJA2")
                {
                    v_consulta = v_consulta + " AND A.ROL = '" + VGlobales.vp_role + "' AND APELLIDO <> 'CONTADURIA' AND APELLIDO <> 'TESORERIA' AND APELLIDO <> 'SISTEMAS'";
                }
                else if (VGlobales.vp_role == "CAJA" || VGlobales.vp_role == "INFORMES" || VGlobales.vp_role == "CAJA2")
                {
                    v_consulta = v_consulta + " AND A.ROL != 'CONFITERIA'";
                }

                if (FECHA == "XXX")
                {
                    v_consulta = v_consulta + " AND EXTRACT(DAY FROM A.FECHA)=EXTRACT(DAY FROM CURRENT_TIMESTAMP)";
                    v_consulta = v_consulta + " AND EXTRACT(MONTH FROM A.FECHA)=EXTRACT(MONTH FROM CURRENT_TIMESTAMP)";
                    v_consulta = v_consulta + " AND EXTRACT(YEAR FROM A.FECHA)=EXTRACT(YEAR FROM CURRENT_TIMESTAMP)";
                }
                else
                {
                    string DAY = FECHA.Substring(0, 2);
                    string MONTH = FECHA.Substring(3, 2);
                    string YEAR = FECHA.Substring(6, 4);
                    v_consulta = v_consulta + " AND EXTRACT(DAY FROM A.FECHA)=" + DAY;
                    v_consulta = v_consulta + " AND EXTRACT(MONTH FROM A.FECHA)=" + MONTH;
                    v_consulta = v_consulta + " AND EXTRACT(YEAR FROM A.FECHA)=" + YEAR;

                    if (IMPRESO == "NO")
                    {
                        v_consulta = v_consulta + " AND NRO_RECIBO = '' AND NRO_BONO IS NULL";
                    }
                    else if (IMPRESO == "SI")
                    {
                        v_consulta = v_consulta + " AND (NRO_RECIBO != '' OR NRO_BONO != '')";
                    }
                }

                v_consulta = v_consulta + " AND A.ID_DESTINO = SA.ID";
                v_consulta = v_consulta + " AND A.ID_PROFESIONAL = P.ID";
                v_consulta = v_consulta + " ORDER BY A.NRO_RECIBO ASC, A.NRO_BONO ASC, A.SECUENCIA DESC";
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR");
            }

            try
            {
                string connectionString;
                DataSet ds1 = new DataSet();
                Datos_ini ini3 = new Datos_ini();
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini3.Servidor;  cs.Port = int.Parse(ini3.Puerto);
                cs.Database = ini3.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataTable dt1 = new DataTable("RESULTADOS");
                    dt1.Columns.Add("NRO", typeof(string));
                    dt1.Columns.Add("DEP", typeof(string));
                    dt1.Columns.Add("APELLIDO", typeof(string));
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("TIP_SOCIO", typeof(string));
                    dt1.Columns.Add("ROL", typeof(string));
                    dt1.Columns.Add("DESTINO", typeof(string));
                    dt1.Columns.Add("PROFESIONAL", typeof(string));
                    dt1.Columns.Add("SECUENCIA", typeof(string));
                    dt1.Columns.Add("BAR", typeof(string));
                    dt1.Columns.Add("DTO", typeof(string));
                    dt1.Columns.Add("RECIBO", typeof(string));
                    dt1.Columns.Add("ID_PROFESIONAL", typeof(string));
                    dt1.Columns.Add("ID_DESTINO", typeof(string));
                    dt1.Columns.Add("DESTINO_DETA", typeof(string));
                    dt1.Columns.Add("NRO_SOC", typeof(string));
                    dt1.Columns.Add("NRO_DEP", typeof(string));
                    dt1.Columns.Add("BONO", typeof(string));
                    dt1.Columns.Add("BR", typeof(string));
                    dt1.Columns.Add("CUENTA", typeof(string));
                    dt1.Columns.Add("DNI", typeof(string));
                    dt1.Columns.Add("GRUPO", typeof(string));
                    dt1.Columns.Add("IMPORTE", typeof(string));
                    dt1.Columns.Add("NRO_PAGO", typeof(string));
                    dt1.Columns.Add("CUIL/CUIT", typeof(string));
                   

                    ds1.Tables.Add(dt1);
                    FbCommand cmd = new FbCommand(v_consulta, connection, transaction);
                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("NRO_SOC")).Trim(), //0
                                     reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim(), //1
                                     reader3.GetString(reader3.GetOrdinal("APELLIDO")).Trim(), //2
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(), //3
                                     reader3.GetString(reader3.GetOrdinal("TIP_SOCIO")).Trim(), //4
                                     reader3.GetString(reader3.GetOrdinal("ROL")).Trim(), //5
                                     reader3.GetString(reader3.GetOrdinal("DETALLE")).Trim(), //6
                                     reader3.GetString(reader3.GetOrdinal("NOMBREPROF")).Trim(), //7
                                     reader3.GetString(reader3.GetOrdinal("SECUENCIA")).Trim(), //8
                                     reader3.GetString(reader3.GetOrdinal("BARRA")).Trim(), //9
                                     reader3.GetString(reader3.GetOrdinal("COD_DTO")).Trim(), //10
                                     reader3.GetString(reader3.GetOrdinal("NRO_RECIBO")).Trim(), //11
                                     reader3.GetString(reader3.GetOrdinal("ID_PROFESIONAL")).Trim(), //12
                                     reader3.GetString(reader3.GetOrdinal("ID_DESTINO")).Trim(), //13
                                      reader3.GetString(reader3.GetOrdinal("DESTINO_DETA")).TrimEnd().TrimStart(), //14
                                     reader3.GetString(reader3.GetOrdinal("NUMERO_SOCIO")).Trim(), //15
                                     reader3.GetString(reader3.GetOrdinal("NUMERO_DEPURACION")).Trim(),//16
                                     reader3.GetString(reader3.GetOrdinal("NRO_BONO")).Trim(), //17
                                     reader3.GetString(reader3.GetOrdinal("BONO_RECIBO")).Trim(), //18
                                     reader3.GetString(reader3.GetOrdinal("CUENTA")).Trim(),//19 
                                     reader3.GetString(reader3.GetOrdinal("DNI")), //20
                                     reader3.GetString(reader3.GetOrdinal("GRUPO")), //21
                                     reader3.GetString(reader3.GetOrdinal("IMPORTE")),//22
                                     reader3.GetString(reader3.GetOrdinal("NRO_PAGO")), //23
                                     reader3.GetString(reader3.GetOrdinal("CUIL"))//24,
                                     
                                     ); 
                    }

                    reader3.Close();
                    dataGridView1.DataSource = dt1;
                    dataGridView1.Columns[0].Width = 65;
                    dataGridView1.Columns[1].Width = 65;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView1.Columns[9].Width = 40;
                    dataGridView1.Columns[10].Width = 40;
                    dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView1.Columns[17].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    transaction.Commit();
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                    dataGridView1.Columns[13].Visible = false;
                    //dataGridView1.Columns[14].Visible = false;
                    dataGridView1.Columns[16].Visible = false;
                    dataGridView1.Columns[17].Visible = false;
                    dataGridView1.Columns[18].Visible = false;
                    dataGridView1.Columns[20].Visible = false;
                   // dataGridView1.Columns[21].Visible = false;
                    //dataGridView1.Columns[21].Visible = false;
                    //pintarAnulados();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR AL CARGAR LOS RESULTADOS\n" + error);
            }
        }

        private void pintarAnulados()
        {
            bool ANULADO = false;
            int ROW_INDEX = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[16].Value.ToString() != "") //NRO_BONO
                {
                    string QUERY = "SELECT ANULADO FROM BONOS_CAJA WHERE ID = " + int.Parse(row.Cells[16].Value.ToString()) + ";";
                    DataRow[] foundRows;
                    foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

                    if (foundRows[0][0].ToString() != "")
                    {
                        row.Cells[2].Value = "ANULADO";
                        row.Cells[3].Value = "ANULADO";
                    }
                }
                
                if (row.Cells[11].Value.ToString() != "") //NRO_RECIBO
                {
                    string QUERY = "SELECT ANULADO FROM RECIBOS_CAJA WHERE ID = " + int.Parse(row.Cells[11].Value.ToString()) + ";";
                    DataRow[] foundRows;
                    foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

                    if (foundRows[0][0].ToString() != "")
                    {
                        row.Cells[2].Value = "ANULADO";
                        row.Cells[3].Value = "ANULADO";
                    }
                }

                ROW_INDEX++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Llenar_grilla("XXX", "X");
            Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Llenar_grilla(dtpFecha.Text, "NO");
            Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Llenar_grilla(dtpFecha.Text, "SI");
            Cursor = Cursors.Default;
        }

        private void btnSociosAbm_Click(object sender, EventArgs e)
        {
            buscar bu = new buscar();
            bu.ShowDialog();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (VGlobales.vp_username == "SVALLEJOS" || VGlobales.vp_username == "PDEREYES" || VGlobales.vp_username == "AHERNANDEZ" || VGlobales.vp_username == "SBARBEITO")
            {
                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void modificarFormaDePago(string RECIBO, string BONO, string FORMA_DE_PAGO)
        {
            if (RECIBO != "")
            {
                try
                {
                    BO_CAJA.modificarFormaPagoRecibos(int.Parse(RECIBO), int.Parse(FORMA_DE_PAGO));
                    MessageBox.Show("FORMA DE PAGO MODIFICADA", "LISTO!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO MODIFICAR LA FORMA DE PAGO\n" + error, "ERROR");
                }

            }

            if (BONO != "")
            {
                try
                {
                    BO_CAJA.modificarFormaPagoBonos(int.Parse(BONO), int.Parse(FORMA_DE_PAGO));
                    MessageBox.Show("FORMA DE PAGO MODIFICADA", "LISTO!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO MODIFICAR LA FORMA DE PAGO\n" + error, "ERROR");
                }
            }

            if (BONO == "" && RECIBO == "")
            {
                MessageBox.Show("EL INGRESO SELECCIONADO NO TIENE COMPROBANTE", "ERROR");
            }
        }

        private void subItemClick(object sender, EventArgs e)
        {
            try
            {
                int s = sender.ToString().IndexOf("·");
                int index = s - 1;
                string FORMA_DE_PAGO = sender.ToString().Substring(0, index);
                string RECIBO = dataGridView1[11, dataGridView1.CurrentCell.RowIndex].Value.ToString();
               
                string BONO = dataGridView1[18, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                modificarFormaDePago(RECIBO, BONO, FORMA_DE_PAGO);
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO MODIFICAR LA FORMA DE PAGO\n" + error, "ERROR");
            }
        }

        private void subitemsFormasDePago()
        {
            string query = "SELECT * FROM FORMAS_DE_PAGO ORDER BY ID ASC;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                for (int i = 0; i < foundRows.Length; i++)
                {
                    this.modificarFormaDePagoToolStripMenuItem.DropDownItems.Add(foundRows[i][0].ToString() + " · " + foundRows[i][1].ToString(), null, subItemClick);
                }
            }
        }

        private void GrillaPreRecibo_Load(object sender, EventArgs e)
        {
            Llenar_grilla("XXX", "X");
            subitemsFormasDePago();
        }

        private void elimiarCajaDiaria(string RECIBO, string BONO)
        {
            if (RECIBO != "")
            {
                try
                {
                    BO_CAJA.eliminarCDRecibo(int.Parse(RECIBO));
                    MessageBox.Show("CAJA DIARIA ELIMINADA", "LISTO!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO ELIMINAR LA CAJA DIARIA\n" + error, "ERROR");
                }

            }

            if (BONO != "")
            {
                try
                {
                    BO_CAJA.eliminarCDBono(int.Parse(BONO));
                    MessageBox.Show("CAJA DIARIA ELIMINADA", "LISTO!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("NO SE PUDO ELIMINAR LA CAJA DIARIA\n" + error, "ERROR");
                }
            }

            if (BONO == "" && RECIBO == "")
            {
                MessageBox.Show("EL INGRESO SELECCIONADO NO TIENE COMPROBANTE", "ERROR");
            }
        }

        private void eliminarCajaDiariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string RECIBO = dataGridView1[11, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            string BONO = dataGridView1[18, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            elimiarCajaDiaria(RECIBO, BONO);
        }

        private void imprimirComprobante(string REINTEGRO)
        {
            Cursor = Cursors.WaitCursor;
            VGlobales.vp_IdScocio = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()) * 1000;
            VGlobales.vp_IdScocio = VGlobales.vp_IdScocio + Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString());
        
            VGlobales.vp_IdSecAct = Convert.ToInt32(dataGridView1[13, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            VGlobales.vp_IDProf = Convert.ToInt32(dataGridView1[12, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            VGlobales.vp_Secuencia = Convert.ToInt32(dataGridView1[8, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            VGlobales.vp_Apellido = dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            VGlobales.vp_Nombre = dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            VGlobales.vp_TipSoc = dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            VGlobales.vp_Barra = dataGridView1[9, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            VGlobales.vp_CodDto = dataGridView1[10, dataGridView1.CurrentCell.RowIndex].Value.ToString();

            string RB = dataGridView1[18, dataGridView1.CurrentCell.RowIndex].Value.ToString();

            if (RB == "R")
                VGlobales.vp_NroRecibo = dataGridView1[11, dataGridView1.CurrentCell.RowIndex].Value.ToString();

            if (RB == "B")
                VGlobales.vp_NroRecibo = dataGridView1[18, dataGridView1.CurrentCell.RowIndex].Value.ToString();



            string NRO_SOC = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            string NRO_DEP = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
           
             string TIT_SOC = dataGridView1[15, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            string TIT_DEP = dataGridView1[16, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            string ROLE = dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value.ToString();
           
            string DNI = dataGridView1[20, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            int GRUPO = int.Parse(dataGridView1[21, dataGridView1.CurrentCell.RowIndex].Value.ToString());
           
            int CUENTA = 0;
            decimal IMPORTE = decimal.Parse(dataGridView1[22, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            string ID_PAGO = dataGridView1[23, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            string CUIT = dataGridView1[24, dataGridView1.CurrentCell.RowIndex].Value.ToString();

            if (ID_PAGO.Length > 0)
                VGlobales.ID_CUOTA_PAGO = Int32.Parse(ID_PAGO);

            if (dataGridView1[18, dataGridView1.CurrentCell.RowIndex].Value.ToString() != "")
            {
                CUENTA = int.Parse(dataGridView1[19, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            }

            if (VGlobales.vp_IdScocio == 0)
            {
                MessageBox.Show("Se debe ingresar como Socio Invitado para poder generar recibo", "INFORME DE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (REINTEGRO == "SI" && VGlobales.vp_NroRecibo == "")
            {
                MessageBox.Show("NO SE PUEDE HACER UN REINTEGRO SI TODAVIA NO SE GENERO EL COMPROBANTE", "ERROR");
            }
            else
            {
                recibos r = new recibos(VGlobales.vp_IdScocio, VGlobales.vp_IdSecAct, VGlobales.vp_IDProf, VGlobales.vp_Secuencia,
                        VGlobales.vp_Apellido, VGlobales.vp_Nombre, VGlobales.vp_TipSoc, VGlobales.vp_Barra, VGlobales.vp_CodDto,
                        VGlobales.vp_NroRecibo, NRO_SOC, NRO_DEP, TIT_SOC, TIT_DEP, CUENTA, DNI, GRUPO, IMPORTE, RB, REINTEGRO, CUIT);
                r.ShowDialog();

                if (VGlobales.vp_NroRecibo == "")
                    Llenar_grilla("XXX", "X");
            }

            Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imprimirComprobante("NO");
        }

        private void btnReintegro_Click(object sender, EventArgs e)
        {
            imprimirComprobante("SI");
        }
    }
}
