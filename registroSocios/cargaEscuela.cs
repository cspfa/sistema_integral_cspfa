using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Linq;

namespace SOCIOS.registroSocios
{
    public partial class cargaEscuela : Form
    {
        bo dlog = new bo();

        public cargaEscuela()
        {
            InitializeComponent();
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void insertarRegistros()
        {
            int LEG_PER = 0;

            try
            {
                bo dlog = new bo();
                string insert = "";
                string numerador = "";
                int CANTIDAD = 0;

                progressBar1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = dgAspirantes.Rows.Count;
                progressBar1.Value = 0;
                progressBar1.Step = 1;

                foreach (DataGridViewRow row in dgAspirantes.Rows)
                {
                    nroSocio ns = new nroSocio();
                    int NRO_SOC = ns.numero(1);
                    int ID_TITULAR = ((NRO_SOC * 1000) + 994);
                    int NRO_DEP = 994;
                    LEG_PER = int.Parse(row.Cells[1].Value.ToString());
                    int AAR = 1;
                    int ACRJP1 = 0;
                    int ACRJP2 = int.Parse(row.Cells[7].Value.ToString());
                    int ACRJP3 = 0;
                    string APE_SOC = row.Cells[2].Value.ToString();
                    string NOM_SOC = row.Cells[3].Value.ToString();
                    int NUM_DOC = int.Parse(row.Cells[6].Value.ToString());
                    string COD_DTO = "640";
                    string NCOD_DTO = "633";
                    string F_ALTPO = row.Cells[5].Value.ToString();
                    string F_ALTCI = dpAdto.Text;
                    string A_DTO = dpAdto.Text;
                    string DESTINO = "0175";
                    string JERARQ = "0041";
                    string CAT_SOC = "001";
                    string OBS = "PROMOCION " + tbPromocion.Text.Trim();
                    string CALL_PAR = "";
                    string LOC_PAR = "";
                    string NUM_TE1 = "";
                    string SEX = row.Cells[4].Value.ToString().Substring(0,1);
                    string OBRA_SOCIAL = "";
                    string F_NACIM = "01/01/1990";

                    #region VARIABLES VACIAS
                    int PAR = 0;
                    int PCRJP1 = 0;
                    int PCRJP2 = 0;
                    int PCRJP3 = 0;
                    string TIP_DOC = "3";
                    int NUM_CED = 0;
                    string NRO_PAR = "0";
                    string PIS_PAR = "0";
                    string DPT_PAR = "0";
                    string CP_PART = "0";
                    string PRO_PAR = "02";
                    string TELEFONOS = "";
                    int CAR_TE1 = 0;
                    int CAR_TE2 = 0;
                    string NUM_TE2 = "0";
                    string F_BAJPO = "";
                    string M_BAJPO = "";
                    string F_BAJCI = "";
                    string M_BAJCI = "";
                    string F_CESDE = "";
                    string F_CACAT = "";
                    string BEAUCHEF = "";
                    string AVAL = "";
                    string F_ALTRE = "";
                    string F_ALTVI = "";
                    string GIMNASIO = "N";
                    string F_ULTMO = "";
                    string EMPLEAD = "";
                    string F_CARN = "";
                    string TIP_CAR = "";
                    string DAT_DOM = "";
                    string CAM_JER = "";
                    string NJERARQ = "";
                    string NDESTINO = "";
                    string ESCALA = "";
                    int CC = 0;
                    int SECUENCIA = 0;
                    int CAR_FAX = 0;
                    string NUM_FAX = "";
                    string USR_ALTA = VGlobales.vp_username;
                    string FE_ALTA = "";
                    string USR_MOD = "";
                    string FE_MOD = "";
                    string USR_BAJA = "";
                    string FE_BAJA = "";
                    string E_MAIL = "";
                    string SUSCRIP = "";
                    int ORD_DIA2 = 0;
                    string ORD_FEC2 = "";
                    int ORD_DIA3 = 0;
                    string ORD_FEC3 = "";
                    string ORIGEN_ALTA = "ESC";
                    string CUIL = "";
                    byte[] FOTO = imageToByteArray(pbFoto.Image);
                    byte[] OBSERVACIONES = imageToByteArray(pbFoto.Image);
                    #endregion

                    dlog.insertarTitularesEscuela(ID_TITULAR, AAR, ACRJP1, ACRJP2, ACRJP3, PAR, PCRJP1, PCRJP2, PCRJP3, APE_SOC, NOM_SOC,
                           NRO_SOC, NRO_DEP, JERARQ, LEG_PER, DESTINO, F_ALTPO, F_ALTCI, TIP_DOC, NUM_DOC, NUM_CED, CALL_PAR, LOC_PAR,
                           NUM_TE1, NUM_TE2, COD_DTO, CAT_SOC, GIMNASIO, ESCALA, A_DTO, USR_ALTA, NCOD_DTO, ORIGEN_ALTA, FOTO, OBSERVACIONES, OBS, F_NACIM, SEX,PRO_PAR);

                    progressBar1.PerformStep();
                    CANTIDAD++;
                    Thread.Sleep(50);
                }

                progressBar1.Value = 0;
                MessageBox.Show("OPERACION FINALIZADA\n\nREGISTROS INSERTADOS " + CANTIDAD.ToString(), "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                progressBar1.Value = 0;
                MessageBox.Show("SE PRODUJO UN ERROR EN EL REGISTRO CON LP: " + LEG_PER + "\n\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbrirTXT_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.txt";
            ofd.ShowDialog();
            string archivo = ofd.FileName;

            if (archivo != "*.txt")
            {
                Cursor = Cursors.WaitCursor;
                lbArchivoTXT.Text = archivo;
                generarListaNetos();
                Cursor = Cursors.Default;
            }
        }

        private void btnAbrirXLS_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.xls";
            ofd.ShowDialog();
            string archivo = ofd.FileName;

            if (archivo != "*.xls")
            {
                Cursor = Cursors.WaitCursor;
                lbArchivoXLS.Text =  archivo;
                generarListaAspirantes(lbArchivoXLS.Text);
                Cursor = Cursors.Default;
            }
        }

        #region NETOS
        public class NETOS
        {
            public string CRJP2 { get; set; }
            public string LP { get; set; }
            public string DESTINO { get; set; }
            public string JERARQ { get; set; }
            public string NOMBRE { get; set; }
            public int DNI { get; set; }

            public NETOS(string crjp2, string lp, string dest, string jerarq, string nombre, int dni)
            {
                this.CRJP2 = crjp2;
                this.LP = lp;
                this.DESTINO = dest;
                this.JERARQ = jerarq;
                this.NOMBRE = nombre;
                this.DNI = dni;
            }
        }

        private void generarListaNetos()
        {
            List<NETOS> NETOS = new List<NETOS>();

            using (StreamReader SR = new StreamReader(lbArchivoTXT.Text))
            {
                string LINEA;

                while ((LINEA = SR.ReadLine()) != null)
                {
                    int OUT;
                    string CRJP2 = LINEA.Substring(0, 6);
                    string LP = LINEA.Substring(6, 5);
                    string DEST = LINEA.Substring(11, 3);
                    string JERARQ = LINEA.Substring(14, 3);
                    string NOMBRE = LINEA.Substring(17, 34);
                    int DNI = int.Parse(LINEA.Substring(52, 8));
                    NETOS.Add(new NETOS(CRJP2.Trim(), LP.Trim(), DEST.Trim(), JERARQ.Trim(), NOMBRE.Trim(), DNI));
                }
            }

            dgNetos.DataSource = NETOS;
        }

        #endregion

        #region ASPIRANTES
        public class ASPIRANTES
        {
            public int ORDEN { get; set; }
            public int LP { get; set; }
            public string APELLIDOS { get; set; }
            public string NOMBRES { get; set; }
            public string GENERO { get; set; }
            public string ALTA { get; set; }
            public int DNI { get; set; }
            public int AFILIADO { get; set; }
            public int NRO_SOC { get; set; }

            public ASPIRANTES(int orden, int lp, string apellidos, string nombres, int dni, string genero, string alta, int afiliado, int nro_soc)
            {
                this.ORDEN = orden;
                this.LP = lp;
                this.APELLIDOS = apellidos;
                this.NOMBRES = nombres;
                this.GENERO = genero;
                this.ALTA = alta;
                this.DNI = dni;
                this.AFILIADO = afiliado;
                this.NRO_SOC = nro_soc;
            }
        }

        private void generarListaAspirantes(string ARCHIVO)
        {
            List<ASPIRANTES> ASPIRANTES = new List<ASPIRANTES>();
            OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ARCHIVO + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
            con.Open();
            DataSet dset = new DataSet();
            OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT * FROM [Hoja1$] WHERE LP IS NOT NULL;", con);
            dadp.TableMappings.Add("APELLIDOS", "LP");
            dadp.Fill(dset);
            DataTable table = dset.Tables[0];
            int CANTIDAD = table.Rows.Count;
            bo dlog = new bo();
            int LP = 0;
            int DNI = 0;
            int DEST = 0;
            int OSOC = 0;
            int AFILIADO = 0;
            int ORD = 0;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                string ORDEN = table.Rows[i][0].ToString().Replace(".", "");
                string ELEPE = table.Rows[i][1].ToString().Replace(".", "");
                string APELLIDOS = table.Rows[i][2].ToString().Trim().ToUpper();
                string NOMBRES = table.Rows[i][3].ToString().Trim().ToUpper();
                string GENERO = table.Rows[i][4].ToString().Trim().ToUpper();
                string ESCALAFON = table.Rows[i][5].ToString().Trim().ToUpper();
                string ALTA = table.Rows[i][6].ToString();
                string S_DNI = table.Rows[i][7].ToString().Replace(".", "");
                string AFIL = table.Rows[i][8].ToString().Replace(".", "");

                if (ORDEN != "")
                    ORD = int.Parse(ORDEN);

                if (ELEPE != "")
                    LP = int.Parse(ELEPE);

                if (S_DNI != "")
                    DNI = int.Parse(S_DNI);

                if (AFIL != "")
                    AFILIADO = int.Parse(AFIL);

                ASPIRANTES.Add(new ASPIRANTES(ORD, LP, APELLIDOS, NOMBRES, DNI, GENERO, ALTA.Replace(" 0:00:00", ""), AFILIADO, 0));
            }

            dgAspirantes.DataSource = ASPIRANTES;
        }
        #endregion

        private void compararListas()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = dgNetos.Rows.Count;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            foreach (DataGridViewRow row1 in dgNetos.Rows)
            {
                foreach (DataGridViewRow row2 in dgAspirantes.Rows)
                {
                    int DNI_NETO = int.Parse(row1.Cells[5].Value.ToString());
                    int DNI_ASPI = int.Parse(row2.Cells[6].Value.ToString());

                    if (DNI_NETO == DNI_ASPI)
                    {
                        row2.Cells[7].Value = row1.Cells[0].Value.ToString();
                    }
                }

                progressBar1.PerformStep();
            }

            progressBar1.Value = 0;
            //lbCantidadInsertos.Text = "CANTIDAD DE INSERTOS: " + dataGridView3.Rows.Count;
            //insertarRegistros();*/
        }

        private void btnCruzar_Click(object sender, EventArgs e)
        {
            if (lbArchivoTXT.Text.Contains("NINGUNO"))
            {
                MessageBox.Show("SELECCIONAR UN ARCHIVO TXT", "ERROR");
            }
            else if (lbArchivoXLS.Text.Contains("NINGUNO"))
            {
                MessageBox.Show("SELECCIONAR UN ARCHIVO XLS", "ERROR");
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                compararListas();
                Cursor = Cursors.Default;
            }
        }

        private void buscarXdni()
        {
            /*try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    string QUERY = "v ";
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        dataGridView3.DataSource = ds;
                    }

                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
        }

        private void btnEranSocios_Click(object sender, EventArgs e)
        {
            /*string ARCHIVO = lbArchivoXLS.Text;
            Cursor = Cursors.WaitCursor;
            OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ARCHIVO + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
            con.Open();
            DataSet dset = new DataSet();
            OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT DNI FROM [Hoja1$] WHERE DNI IS NOT NULL;", con);
            dadp.TableMappings.Add("DNI", "DNI");
            dadp.Fill(dset);
            DataTable table = dset.Tables[0];
            int CANTIDAD = table.Rows.Count;
            bo dlog = new bo();
            DataRow[] foundRows;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = table.Rows.Count;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            string QUERY = "SELECT NUM_DOC FROM TITULAR WHERE ID_TITULAR > 79579994 AND ORIGEN_ALTA = 'ESC';";
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            for (int y = 0; y < table.Rows.Count; y++)
            {
                for (int i = 0; i < foundRows.Length; i++)
                {
                    
                        if (foundRows[i][0].ToString() == table.Rows[y][0].ToString())
                        {
                            dataGridView3.Rows.Add(foundRows[i][0].ToString());
                        }
                        else
                        {
                            dataGridView4.Rows.Add(table.Rows[y][0].ToString());
                        }
                    
                }

                progressBar1.PerformStep();
            }

            Cursor = Cursors.Default;*/
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string QUERY = "";

            foreach (DataGridViewRow row in dgAspirantes.Rows)
            {
                string SEX = row.Cells[3].Value.ToString();
                string OBRA_SOCIAL = row.Cells[7].Value.ToString();
                string F_NACIM = row.Cells[6].Value.ToString();
                char sep = '/';
                string[] NACIM = F_NACIM.Split(sep); 
                string NACIMIENTO = NACIM[1] + "/" + NACIM[0] + "/" + NACIM[2];
                string DNI = row.Cells[5].Value.ToString();
                QUERY += "UPDATE TITULAR SET SEX = '" + SEX + "', OBRA_SOCIAL = '" + OBRA_SOCIAL + "', F_NACIM = '" + NACIMIENTO + "' WHERE NUM_DOC = " + DNI + ";\r\n";
            }            

            Clipboard.SetData(DataFormats.Text, (Object)QUERY);
            MessageBox.Show("CONSULTA COPIADA");
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int DNI = 0;
            int DNI_BASE = 0;
            int NRO_SOC = 0;

            try
            {
                conString cs = new conString();
                string connectionString = cs.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string QUERY = "SELECT NUM_DOC, NRO_SOC FROM TITULAR WHERE NUM_DOC IN (";

                    foreach (DataGridViewRow row in dgAspirantes.Rows)
                    {
                        DNI = int.Parse(row.Cells[6].Value.ToString());
                        QUERY += DNI + ",";
                    }

                    QUERY = QUERY.TrimEnd(',');
                    QUERY = QUERY + ");";

                    FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                    cmd.CommandText = QUERY;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            foreach (DataGridViewRow row in dgAspirantes.Rows)
                            {
                                DNI = int.Parse(row.Cells[6].Value.ToString());
                                
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    DNI_BASE = int.Parse(dr[0].ToString().Trim());
                                    NRO_SOC = int.Parse(dr[1].ToString().Trim());

                                    if (DNI_BASE == DNI)
                                    {
                                        row.Cells[8].Value = NRO_SOC.ToString();
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Cursor = Cursors.Default;
                        }

                        reader.Close();
                    }

                    transaction.Commit();
                    connection.Close();
                    cmd = null;
                    transaction = null;
                    Cursor = Cursors.Default;
                    //Clipboard.SetData(DataFormats.Text, (Object)QUERY);
                    //MessageBox.Show("CONSULTA COPIADA");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("OCURRIO UN ERROR AL EJECUTAR LA CONSULTA\n"+error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Cursor = Cursors.Default;
            }
        }

        private void btnImportarRegistros_Click_1(object sender, EventArgs e)
        {
            insertarRegistros();
        }

        private void btnListadoFinal_Click(object sender, EventArgs e)
        {
            int NUM_DOC = 0;
            int DNI_DGV = 0;
            int DNI_TIT = 0;
            int NRO_SOC = 0;
            DateTime A_DTO = Convert.ToDateTime(dpAdto.Text);
            string A_DTO_S = A_DTO.ToString("MM/dd/yyyy");
            string QUERY = "SELECT NRO_SOC, NUM_DOC FROM TITULAR WHERE NUM_DOC IN (";

            if (dgAspirantes.Rows.Count == 0)
            {
                MessageBox.Show("CARGAR EXCEL ESCUELA", "ERROR");
            }
            else
            {
                Cursor = Cursors.WaitCursor;

                foreach (DataGridViewRow row in dgAspirantes.Rows)
                {
                    NUM_DOC = int.Parse(row.Cells[6].Value.ToString());
                    QUERY += NUM_DOC + ",";
                }

                QUERY = QUERY.TrimEnd(',');
                QUERY = QUERY + ") AND ORIGEN_ALTA = 'ESC' AND A_DTO = '" + A_DTO_S + "' ORDER BY LEG_PER ASC;";
                //Clipboard.SetData(DataFormats.Text, (Object)QUERY);
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

                if (foundRows.Length > 0)
                {
                    foreach (DataGridViewRow DG_ASPIRANTES in dgAspirantes.Rows)
                    {
                        foreach (DataRow TITULARES in foundRows)
                        {
                            DNI_DGV = int.Parse(DG_ASPIRANTES.Cells[6].Value.ToString());
                            DNI_TIT = int.Parse(TITULARES[1].ToString());
                            NRO_SOC = int.Parse(TITULARES[0].ToString());

                            if (DNI_DGV == DNI_TIT)
                            {
                                DG_ASPIRANTES.Cells[8].Value = NRO_SOC.ToString();
                            }

                            progressBar1.PerformStep();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("NO SE ECONTRARON DATOS", "ERROR");
                }

                Cursor = Cursors.Default;
            }
        }

        private void btnAbrirXLSPros_Click(object sender, EventArgs e)
        {

        }
    }
}
