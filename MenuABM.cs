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
using Convenios;
using Confiteria;

namespace SOCIOS
{
    public partial class MenuABM : MicroFour.StrataFrame.UI.Windows.Forms.StandardForm
    {

        BindingSource BindingSourceFamiliar = new BindingSource();

        public MenuABM()
        {
            InitializeComponent();

            procesosToolStripMenuItem.Enabled = false;

            Datos_ini servidor = new Datos_ini();

            string s = servidor.Ubicacion;

            if (s != "/u1/Data/CSPFA_DATOS7.FDB")
            {
                lbServidor.Text = "SERVIDOR PRUEBA";
            }
            else
            {
                lbServidor.Text = "SERVIDOR PRODUCCION";
            }

            DirectoryInfo di = new DirectoryInfo(@"C:\CSPFA_SOCIOS");
            string FECHA = "";
            
            foreach (var fi in di.GetFiles("SOCIOS.EXE"))
            {
                FECHA = fi.LastWriteTime.ToShortDateString();
            }

            lbVersion.Text = "VERSION " + FECHA;

            actSociosUpdate asu = new actSociosUpdate();
            asu.actualizar();
        }

        private void ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            FLogin();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            FLogin();
        }

       private void FLogin()
        {
            LoginForm1 frmDialog = new LoginForm1();
            DialogResult result;
            result = frmDialog.ShowDialog();

            switch (result)
            {
                case DialogResult.OK:

                    frmDialog.Dispose();
                    toolStripStatusLabel1.Text = VGlobales.vp_timestamp;
                    toolStripStatusLabel2.Text = VGlobales.vp_username;
                    toolStripStatusLabel3.Text = VGlobales.vp_role;

                    AsambleatoolStripMenuItem7.Enabled = false;

                    if (VGlobales.vp_role.Trim() == "CPOCABA" || VGlobales.vp_role.Trim() == "CPOPOLVORINES" || VGlobales.vp_role.Trim() == "CPORANELAGH")
                    {
                        cajaToolStripMenuItem.Enabled = true;
                        imprimirRecibosEnBlancoToolStripMenuItem.Visible = false;
                        arancelesToolStripMenuItem.Visible = false;
                        puntosDeVentaToolStripMenuItem.Visible = false;
                        confiteríaToolStripMenuItem.Enabled = true;
                        camposToolStripMenuItem1.Enabled = true;
                        deportesToolStrip.Enabled = true;
                    }

                    if (VGlobales.vp_role.Trim() == "SISTEMAS")
                    {
                        deportesToolStrip.Enabled = true;
                        servToolStrip.Enabled = true;
                        procesosToolStripMenuItem.Enabled = true;
                        afiliacionesToolStripMenuItem.Enabled = true;
                        AsambleatoolStripMenuItem7.Enabled = true;
                        creditosToolStripMenuItem.Enabled = true;
                        tesoreríaToolStripMenuItem.Enabled = true;
                        contaduríaToolStripMenuItem.Enabled = true;
                        turismoToolStripMenuItem.Enabled = true;
                        interiorToolStripMenuItem.Enabled = true;
                        camposToolStripMenuItem1.Enabled = true;
                        patrimonioToolStripMenuItem.Enabled = true;
                        comprasToolStripMenuItem.Enabled = true;
                        conveniosToolStripMenuItem.Enabled = true;
                    }

                    if (VGlobales.vp_role.Trim() == "PATRIMONIO")
                    {
                        patrimonioToolStripMenuItem.Enabled = true;
                    }

                    if (VGlobales.vp_role.Trim() == "TECNICA" || VGlobales.vp_role.Trim() == "INFORMES" || VGlobales.vp_role.Trim() == "SISTEMAS")
                    {
                        soporteTñecnicoToolStripMenuItem.Enabled = true;
                    }

                    if (VGlobales.vp_role.Trim() == "PROSECRETARIA")
                    {
                        afiliacionesToolStripMenuItem.Enabled = true;
                        AsambleatoolStripMenuItem7.Enabled = true;
                    }

                    if (VGlobales.vp_role.Trim() == "INTERIOR")
                    {
                        interiorToolStripMenuItem.Enabled = true;
                    }

                    if (VGlobales.vp_role.Trim() == "CREDITOS")
                    {
                        creditosToolStripMenuItem.Enabled = true;
                    }

                    if (VGlobales.vp_role.Trim() == "INFORMES")
                    {
                        servToolStrip.Enabled = true;
                    }

                    if (VGlobales.vp_role.Trim() == "CAJA" || VGlobales.vp_role.Trim() == "INFORMES" || VGlobales.vp_role.Trim() == "CONTADURIA" || VGlobales.vp_role.Trim() == "CAJA2")
                    {
                        cajaToolStripMenuItem.Enabled = true;
                        servToolStrip.Enabled = false;
                    }
                    
                    if (VGlobales.vp_role.Trim() == "CONFITERIA")
                    {
                        confiteríaToolStripMenuItem.Enabled = true;
                    }

                    if (VGlobales.vp_role.Trim() == "SERVICIOS MEDICOS")
                    {
                        servToolStrip.Enabled = true;
                    }

                    if (VGlobales.vp_role.Trim() == "DEPORTES" || VGlobales.vp_role.Trim() == "CAPOCABA" || VGlobales.vp_role.Trim() == "CPOPOLVORINES")
                    {
                        deportesToolStrip.Enabled = true;
                    }

                    if (VGlobales.vp_role.StartsWith("TURISMO"))
                    {
                        turismoToolStripMenuItem.Enabled = true;
                    }

                    if (VGlobales.vp_role.Trim() == "TESORERIA")
                    {
                        tesoreríaToolStripMenuItem.Enabled = true;
                        conveniosToolStripMenuItem.Enabled = true;
                    }

                    if (VGlobales.vp_role.Trim() == "CONTADURIA")
                    {
                        contaduríaToolStripMenuItem.Enabled = true;
                        comprasToolStripMenuItem.Enabled = true;
                        conveniosToolStripMenuItem.Enabled = true;
                    }

                    if (VGlobales.vp_role.Trim() == "COMPRAS")
                    {
                        comprasToolStripMenuItem.Enabled = true;
                    }

                    if (VGlobales.vp_role.Trim() == "SECGRAL")
                    {
                        conveniosToolStripMenuItem.Enabled = true;
                    }

                    break;
                    case DialogResult.Cancel:
                    Application.ExitThread();
                    break;
            }

            timer1.Enabled = true;
        }

       private void checkForUpdates()
       {
           /*Ping Pings = new Ping();
           int timeout = 100;

           if (Pings.Send("192.168.1.6", timeout).Status == IPStatus.Success)
           {
               string pathLan = "\\\\192.168.1.6\\Updates\\SOCIOS.exe";
               string pathLocal = "C:\\CSPFA_SOCIOS\\SOCIOS.exe";

               if (File.Exists(pathLan))
               {
                   DateTime dtLan = File.GetLastWriteTime(pathLan);
                   DateTime dtLocal = File.GetLastWriteTime(pathLocal);

                   if (dtLocal < dtLan)
                   {
                       lbUpdate.Visible = true;
                   }
               }
           }*/
       }

       private void fechaTimer()
       {
           if (VGlobales.vp_username != null)
           {
               string connString3;

               Datos_ini ini3 = new Datos_ini();

               try
               {
                   FbConnectionStringBuilder cs3 = new FbConnectionStringBuilder();
                   cs3.DataSource = ini3.Servidor;
                   cs3.Database = ini3.Ubicacion;
                   cs3.Port = int.Parse(ini3.Puerto);
                   cs3.UserID = VGlobales.vp_username;
                   cs3.Password = VGlobales.vp_password;
                   cs3.Role = VGlobales.vp_role;
                   cs3.Dialect = 3;
                   connString3 = cs3.ToString();

                   using (FbConnection connection3 = new FbConnection(connString3))
                   {
                       connection3.Open();
                       FbTransaction transaction3 = connection3.BeginTransaction();
                       string veo_fecha;
                       veo_fecha = "SELECT current_timestamp FROM RDB$Database";
                       FbCommand cmd3 = new FbCommand(veo_fecha, connection3, transaction3);
                       cmd3.CommandText = veo_fecha;
                       cmd3.Connection = connection3;
                       cmd3.CommandType = CommandType.Text;
                       FbDataReader reader3 = cmd3.ExecuteReader();
                       reader3.Read();
                       toolStripStatusLabel1.Text = reader3.GetString(reader3.GetOrdinal("current_timestamp"));

                       ini3 = null;
                       transaction3.Commit();
                       connection3.Close();
                       cs3 = null;
                       transaction3 = null;

                       connection3.Dispose();
                   }

               }
               catch (Exception ex)
               {
                   System.Windows.Forms.MessageBox.Show(ex.ToString());
               }
           }
       }
        
       private void aBMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            buscar frmbuscar = new buscar();
            frmbuscar.ShowDialog(this);
            Cursor = Cursors.Default;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (File.Exists(@"TEMP.RTF"))
            {
                File.Delete(@"TEMP.RTF");
            }
            
        }

        private void ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            CbioPassForm frmCambioClave = new CbioPassForm();
            frmCambioClave.ShowDialog(this);
            Cursor = Cursors.Default;
        }

        private void profesionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            abmProfesionales prof = new abmProfesionales(0);
            prof.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            especialidades esp = new especialidades(0);
            esp.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void díasYHorariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            diasyhorarios dh = new diasyhorarios();
            dh.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void recibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GrillaPreRecibo gpr = new GrillaPreRecibo();
            gpr.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void arancelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abmAranceles aa = new abmAranceles();
            //aa.ShowDialog();
        }

        private void imprimirRecibosEnBlancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            recibosEnBlanco reb = new recibosEnBlanco();
            reb.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void anularReciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            anularRecibo ar = new anularRecibo();
            ar.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            listadoTurnos lt = new listadoTurnos(1);
            lt.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void cerrarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            planillaDeCaja pc = new planillaDeCaja();
            pc.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void imprimirAutorizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            solicitudTitular st = new solicitudTitular();
            st.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void sectoresYActividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            sect_act_abm sa = new sect_act_abm();
            sa.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void profesionalesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            abmProfesionales prof = new abmProfesionales(0);
            prof.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void actualizarEmailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("CONFIRMA EL PROCESO", "ATENCION",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {

                string vcomando1;
                string connectionString;
                Datos_ini ini2 = new Datos_ini();
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini2.Servidor;  cs.Port = int.Parse(ini2.Puerto);
                cs.Database = ini2.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;

                connectionString = cs.ToString();
                FbConnection connection = new FbConnection(connectionString);

                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();

                try
                {
                    vcomando1 = "P_ACTUALIZAR_MAIL_TELEFONO";
                    FbCommand cmd = new FbCommand(vcomando1, connection, transaction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Dispose();
                    MessageBox.Show("OPERACION EFECTUADA EXITOSAMENTE", "ACTUALIZAR MAILS Y TELEFONOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    transaction.Rollback();
                    connection.Close();
                    System.Windows.Forms.MessageBox.Show("OCURRIO UN ERROR - " + e.ToString());
                }
            }
        }

        private void renunciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            renuncias rn = new renuncias();
            rn.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void asistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            asistenciaAsamblea aa = new asistenciaAsamblea();
            aa.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void ingresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            IngresoAsamblea frmIngresoAsamblea = new IngresoAsamblea();
            frmIngresoAsamblea.ShowDialog(this);
            Cursor = Cursors.Default;
        }

        private void asambleaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            abmAsambleas aa = new abmAsambleas();
            aa.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void diasYHorariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            diasyhorarios dh = new diasyhorarios();
            dh.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void actualizarMorososToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.xls";
            ofd.ShowDialog();
            string archivo = ofd.FileName;

            if (archivo != "*.xls")
            {
                OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
                con.Open();
                DataSet dset = new DataSet();
                OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT * FROM [PAGOS$] WHERE DNI IS NOT NULL;", con);
                dadp.TableMappings.Add("DNI", "NOMBRE");
                dadp.Fill(dset);
                DataTable table = dset.Tables[0];
                int DNI = 0;
                string NOMBRE = "";

                try
                {
                    progressBar1.Visible = true;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = table.Rows.Count;
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;
                    Cursor = Cursors.WaitCursor;
                    bo dlog = new bo();
                    dlog.vaciarTabla("MOROSOS_DEPORTES");


                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        if (table.Rows[i][0].ToString().Length > 0)
                            DNI = int.Parse(table.Rows[i][0].ToString().Replace(",", ""));
                        else
                            throw new Exception("Existen filas DNI sin cargar, deben respetarse datos en todas las filas  ");

                        NOMBRE = table.Rows[i][1].ToString();
                        dlog.cargarMorososDeportes(NOMBRE, DNI);
                        progressBar1.PerformStep();
                    }

                    MessageBox.Show("OPERACION FINALIZADA", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Visible = false;
                    Cursor = Cursors.Default;
                }
                catch (Exception error)
                {
                    MessageBox.Show("SE PRODUJO UN ERROR\n\nDNI " + DNI.ToString() + "\n\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void actualizarMorososToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.xls";
            ofd.ShowDialog();
            string archivo = ofd.FileName;

            if (archivo != "*.xls")
            {
                OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
                con.Open();
                DataSet dset = new DataSet();
                OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT * FROM [___NOMINAL$] WHERE MES IS NOT NULL;", con);
                dadp.TableMappings.Add("MES", "AÑO");
                dadp.Fill(dset);
                DataTable table = dset.Tables[0];

                try
                {
                    progressBar1.Visible = true;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = table.Rows.Count;
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;
                    Cursor = Cursors.WaitCursor;
                    bo dlog = new bo();
                    dlog.vaciarTabla("MOROSOS");

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        int MES = int.Parse(table.Rows[i][0].ToString());
                        int ANIO = int.Parse(table.Rows[i][1].ToString());
                        int AR = int.Parse(table.Rows[i][2].ToString());
                        int CL = int.Parse(table.Rows[i][3].ToString());
                        int AFIL = int.Parse(table.Rows[i][4].ToString());
                        int S = int.Parse(table.Rows[i][5].ToString());
                        dlog.cargarMorosos(MES, ANIO, AR, CL, AFIL, S);
                        progressBar1.PerformStep();
                    }

                    MessageBox.Show("OPERACION FINALIZADA", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Visible = false;
                    Cursor = Cursors.Default;
                }
                catch (Exception error)
                {
                    MessageBox.Show("SE PRODUJO UN ERROR\n\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void morososInvitados_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.xls";
            ofd.ShowDialog();
            string archivo = ofd.FileName;

            if (archivo != "*.xls")
            {
                OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
                con.Open();
                DataSet dset = new DataSet();
                OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT * FROM [MOROSOS$] WHERE DNI IS NOT NULL;", con);
                dadp.TableMappings.Add("DNI", "NOMBRE");
                dadp.Fill(dset);
                DataTable table = dset.Tables[0];

                try
                {
                    progressBar1.Visible = true;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = table.Rows.Count;
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;
                    Cursor = Cursors.WaitCursor;
                    bo dlog = new bo();
                    dlog.vaciarTabla("MOROSOS_INVITADOS");

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        dlog.cargarMorososInvitados(table.Rows[i][1].ToString(), int.Parse(table.Rows[i][0].ToString()));
                        progressBar1.PerformStep();
                    }

                    MessageBox.Show("OPERACION FINALIZADA", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Visible = false;
                    Cursor = Cursors.Default;
                }
                catch (Exception error)
                {
                    MessageBox.Show("SE PRODUJO UN ERROR\n\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listadoPresentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            cancelarTurnos ct = new cancelarTurnos();
            ct.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void listadoDeTurnosCanceladosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            listadoTurnos lt = new listadoTurnos(0);
            lt.ShowDialog();
            Cursor = Cursors.Default;
        }
     
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void cargaEscuelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registroSocios.cargaEscuela ce = new registroSocios.cargaEscuela();
            ce.ShowDialog();
        }

        private void registroDeLlamadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leerCarpeta();
        }

        public void leerCarpeta()
        {
            bo dlog = new bo();
            string[] files = { "x", "x" };
            string fecha;
            string anio;
            string hora;
            string interno;
            string duracion;
            string destino;
            string insert;

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

            try
            {
                files = Directory.GetFiles("\\\\172.16.0.101\\CALL_LOGS", "*.*");

                foreach (string s in files)
                {
                    string[] lines = File.ReadAllLines(s);

                    progressBar1.Visible = true;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = lines.Length;
                    progressBar1.Value = 0;
                    progressBar1.Step = 1;

                    foreach (string line in lines)
                    {
                        fecha = line.Substring(0, 5);
                        fecha = fecha.Replace(".", "/");
                        anio = "20" + line.Substring(6, 2);
                        fecha = fecha + "/" + anio;
                        hora = line.Substring(8, 8);
                        interno = line.Substring(21, 4);
                        duracion = line.Substring(29, 9);
                        destino = line.Substring(38, 15);

                        try
                        {
                            insert = "INSERT INTO CALL_LOG (FECHA, HORA, INTERNO, DESTINO, DURACION) VALUES ('" + fecha + "', '" + hora + "', " + interno + ", '" + destino + "', '" + duracion + "');";
                            FbTransaction transaction = connection.BeginTransaction();
                            FbCommand com = new FbCommand(insert, connection, transaction);
                            com.ExecuteNonQuery();
                            transaction.Commit();
                            progressBar1.PerformStep();
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.ToString());
                        }
                    }

                    string copiaOrigen = s;
                    string fileDestino = s.Replace("\\\\172.16.0.101\\CALL_LOGS\\", "").ToString();
                    string copiaDestino = "\\\\172.16.0.101\\CALL_LOGS\\backup\\" + fileDestino;
                    
                    try 
                    {
                        File.Copy(copiaOrigen, copiaDestino);

                        try
                        {
                            File.Delete(s);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("NO SE PUDO ELIMINAR EL ARCHIVO");
                        }
                    }
                    catch (Exception error)
                    { 
                        MessageBox.Show("NO SE PUDO COPIAR EL ARCHIVO");
                    }
                }

                progressBar1.Visible = false;
                registro_llamadas rll = new registro_llamadas();
                rll.ShowDialog();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void tsListadoEscuela_Click(object sender, EventArgs e)
        {
            listadoExcel le = new listadoExcel();
            le.ShowDialog();
        }

        private void cargarObservaciones_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.xls";
            ofd.ShowDialog();
            string archivo = ofd.FileName;

            if (archivo != "*.xls")
            {
                OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
                con.Open();
                DataSet dset = new DataSet();
                OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT * FROM [Hoja1$] WHERE DNI IS NOT NULL;", con);
                dadp.TableMappings.Add("FECHA", "DNI");
                dadp.Fill(dset);
                DataTable table = dset.Tables[0];

                try
                {
                    Cursor = Cursors.WaitCursor;
                    progressBar1.Visible = true;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = table.Rows.Count;
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;
                    bo dlog = new bo();
                    //dlog.vaciarTabla("OBSERVACIONES_MEDICAS");

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        string fecha = table.Rows[i][0].ToString().Substring(0, 10);
                        string dia = fecha.Substring(0, 2);
                        string mes = fecha.Substring(3, 2);
                        string ano = fecha.Substring(6, 4);
                        string fecha_final = dia + "/" + mes + "/" + ano;
                        dlog.cargarObesrvacionesMedicas(fecha_final, int.Parse(table.Rows[i][1].ToString()), table.Rows[i][2].ToString());
                        Thread.Sleep(250);
                        progressBar1.PerformStep();
                    }

                    MessageBox.Show("OPERACION FINALIZADA", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor = Cursors.Default;
                    progressBar1.Visible = false;
                }
                catch (Exception error)
                {
                    MessageBox.Show("SE PRODUJO UN ERROR\n\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ingresosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ingresos ing = new ingresos();
            ing.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //employees ee = new employees();
            //ee.ShowDialog();
        }

        private void copiarImágenesDeCámarasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            camaras ca = new camaras();
            ca.ShowDialog();
        }

        private void vToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.xls";
            ofd.ShowDialog();
            string archivo = ofd.FileName;

            if (archivo != "*.xls")
            {
                OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
                con.Open();
                DataSet dset = new DataSet();
                OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT NRO_DOC, COD_DTO, AAR, ACRJP2, PAR, NYA, DESTINO, JERARQ, LP FROM [SOCIOS$] WHERE NRO_DOC > 0;", con);
                dadp.Fill(dset);
                DataTable table = dset.Tables[0];
                bo dlog = new bo();

                try
                {
                    string insert = "";
                    string numerador = "";
                    progressBar1.Visible = true;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = table.Rows.Count;
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        nroSocio ns = new nroSocio();
                        int AAR = int.Parse(table.Rows[i][2].ToString());
                        int ACRJP1 = 0;
                        int ACRJP2 = int.Parse(table.Rows[i][3].ToString());
                        int ACRJP3 = 0;
                        int PAR = int.Parse(table.Rows[i][4].ToString());
                        int PCRJP1 = 0;
                        int PCRJP2 = 0;
                        int PCRJP3 = 0;
                        string[] NYA = table.Rows[i][5].ToString().Split(new Char[] { ',' });
                        string APE_SOC = NYA[0];
                        string NOM_SOC = NYA[1];
                        int NRO_SOC = ns.numero(7);
                        int ID_TITULAR = ((NRO_SOC * 1000) + 994);
                        int NRO_DEP = 994;
                        string JERARQ = table.Rows[i][7].ToString();
                        int LEG_PER = int.Parse(table.Rows[i][8].ToString());
                        string DESTINO = table.Rows[i][6].ToString();
                        string F_ALTPO = null;
                        string F_ALTCI = null;
                        string TIP_DOC = "3";
                        VGlobales.NUM_DOC = int.Parse(table.Rows[i][0].ToString());
                        int NUM_CED = 0;
                        string F_NACIM = null;
                        string CALL_PAR = null;
                        CALL_PAR = null;
                        CALL_PAR = null;
                        CALL_PAR = null;
                        string NRO_PAR = null;
                        string PIS_PAR = null;
                        string DPT_PAR = null;
                        string CP_PART = null;
                        string LOC_PAR = null;
                        string PRO_PAR = null;
                        string TELEFONOS = null;
                        //string[] TEL_SPLIT = TELEFONOS.Split(new Char[] { '/' });
                        int CAR_TE1 = 0;
                        string NUM_TE1 = null;
                        int CAR_TE2 = 0;
                        string NUM_TE2 = null;
                        string F_BAJPO = null;
                        string M_BAJPO = null;
                        string F_BAJCI = null;
                        string M_BAJCI = null;
                        string F_CESDE = null;
                        string COD_DTO = null;
                        string CAT_SOC = null;
                        string F_CACAT = null;
                        string BEAUCHEF = null;
                        string AVAL = null;
                        string F_ALTRE = null;
                        string F_ALTVI = null;
                        string GIMNASIO = null;
                        string F_ULTMO = null;
                        string EMPLEAD = null;
                        string F_CARN = null;
                        string TIP_CAR = null;
                        string DAT_DOM = null;
                        string CAM_JER = null;
                        string SEX = null;
                        string NJERARQ = null;
                        string NDESTINO = null;
                        string ESCALA = null;
                        int CC = 0;
                        string A_DTO = null;
                        int SECUENCIA = 0;
                        int CAR_FAX = 0;
                        string NUM_FAX = null;
                        string USR_ALTA = "SYSDBA";
                        string FE_ALTA = null;
                        string USR_MOD = null;
                        string FE_MOD = null;
                        string USR_BAJA = null;
                        string FE_BAJA = null;
                        string NCOD_DTO = null;
                        string E_MAIL = null;
                        string SUSCRIP = null;
                        int ORD_DIA2 = 0;
                        string ORD_FEC2 = null;
                        int ORD_DIA3 = 0;
                        string ORD_FEC3 = null;
                        string ORIGEN_ALTA = "VOL";
                        string CUIL = null;
                        string OBRA_SOCIAL = null;
                        byte[] FOTO = imageToByteArray(pbFoto.Image);
                        byte[] OBSERVACIONES = imageToByteArray(pbFoto.Image);

                        dlog.insertarTitularesVolve(ID_TITULAR, AAR, ACRJP1, ACRJP2, ACRJP3, PAR, PCRJP1, PCRJP2, PCRJP3, APE_SOC, NOM_SOC,
                               NRO_SOC, NRO_DEP, JERARQ, LEG_PER, DESTINO, F_ALTPO, F_ALTCI, TIP_DOC, VGlobales.NUM_DOC, NUM_CED, CALL_PAR, LOC_PAR,
                               NUM_TE1, NUM_TE2, COD_DTO, CAT_SOC, GIMNASIO, ESCALA, A_DTO, USR_ALTA, NCOD_DTO, ORIGEN_ALTA, FOTO, OBSERVACIONES);

                        progressBar1.PerformStep();
                        VGlobales.CANTIDAD++;
                        Thread.Sleep(1000);
                    }

                    progressBar1.Visible = false;
                    MessageBox.Show("OPERACION FINALIZADA\n\nREGISTROS INSERTADOS " + VGlobales.CANTIDAD, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    progressBar1.Visible = false;
                    MessageBox.Show("SE PRODUJO UN ERROR EN EL REGISTRO CON DNI: " + VGlobales.NUM_DOC + "\n\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void reporteAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SOCIOS.deportes.ReporteAsistencia asistencia = new deportes.ReporteAsistencia();
            asistencia.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void cargaAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SOCIOS.deportes.admAsistencia aa = new SOCIOS.deportes.admAsistencia();
            aa.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void enviarVencimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SOCIOS.deportes.VencimientoAptoFisico ve = new SOCIOS.deportes.VencimientoAptoFisico();
            ve.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            compras co = new compras();
            co.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void arancelesPruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            nuevoAbmAranceles ar = new nuevoAbmAranceles();
            ar.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            nuevoAbmAranceles ar = new nuevoAbmAranceles();
            ar.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void empleadosDesvinculadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //empleadosDesvinculados ed = new empleadosDesvinculados();
           // ed.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void comprasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            compras co = new compras();
            co.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void arancelesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            nuevoAbmAranceles aa = new nuevoAbmAranceles();
            aa.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void noDescontadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.xls";
            ofd.ShowDialog();
            string archivo = ofd.FileName;

            if (archivo != "*.xls")
            {
                OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
                con.Open();
                DataSet dset = new DataSet();
                OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT * FROM [MOROSOS$] WHERE DNI IS NOT NULL;", con);
                dadp.TableMappings.Add("DNI", "NOMBRE");
                dadp.Fill(dset);
                DataTable table = dset.Tables[0];

                try
                {
                    progressBar1.Visible = true;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = table.Rows.Count;
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;
                    Cursor = Cursors.WaitCursor;
                    bo dlog = new bo();
                    dlog.vaciarTabla("MOROSOS_NO_DESC");

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        dlog.cargarMorososNoDescontados(table.Rows[i][1].ToString(), int.Parse(table.Rows[i][0].ToString()));
                        progressBar1.PerformStep();
                    }

                    MessageBox.Show("OPERACION FINALIZADA", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Visible = false;
                    Cursor = Cursors.Default;
                }
                catch (Exception error)
                {
                    MessageBox.Show("SE PRODUJO UN ERROR\n\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void escuelaVsNetosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datosXescuela de = new datosXescuela();
            de.ShowDialog();
        }

        private void actSexoYAltaPolicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.xls";
            ofd.ShowDialog();
            string archivo = ofd.FileName;

            if (archivo != "*.xls")
            {
                OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
                con.Open();
                DataSet dset = new DataSet();
                OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT GENERO, ALTA, DNI FROM [Hoja1$] WHERE DNI IS NOT NULL;", con);
                dadp.TableMappings.Add("GENERO", "ALTA");
                dadp.Fill(dset);
                DataTable table = dset.Tables[0];
                
                try
                {
                    string UPDATE = "";
                    progressBar1.Visible = true;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = table.Rows.Count;
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        string SEX = table.Rows[i][0].ToString();
                        
                        DateTime F_ALTPO = Convert.ToDateTime(table.Rows[i][1].ToString().Substring(0, 10));
                        string ALTA = F_ALTPO.ToString("dd/MM/yyyy");
                        
                        int NUM_DOC = Convert.ToInt32(table.Rows[i][2]);

                        UPDATE += "UPDATE TITULAR SET SEX = '" + SEX + "', F_ALTPO = '" + ALTA + "' WHERE NUM_DOC = " + NUM_DOC + " AND USR_ALTA ='AHERNANDEZ';\n";
                        progressBar1.PerformStep();
                    }

                    Clipboard.SetData(DataFormats.Text, (Object)UPDATE);
                }
                catch (Exception error)
                {
                    MessageBox.Show("SE PRODUJO UN ERROR\n\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    progressBar1.Visible = false;
                    MessageBox.Show("OPERACION FINALIZADA", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cargaJardinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.xls";
            ofd.ShowDialog();
            string archivo = ofd.FileName;

            if (archivo != "*.xls")
            {
                OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
                con.Open();
                DataSet dset = new DataSet();
                OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT APELLIDO, NOMBRE, DNI FROM [Hoja1$] WHERE DNI > 0;", con);
                dadp.Fill(dset);
                DataTable table = dset.Tables[0];
                bo dlog = new bo();

                try
                {
                    string insert = "";
                    string numerador = "";
                    progressBar1.Visible = true;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = table.Rows.Count;
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        nroSocio ns = new nroSocio();
                        int AAR = 0;
                        int ACRJP1 = 0;
                        int ACRJP2 = 0;
                        int ACRJP3 = 0;
                        int PAR = 0;
                        int PCRJP1 = 0;
                        int PCRJP2 = 0;
                        int PCRJP3 = 0;
                        string APE_SOC = table.Rows[i][0].ToString().Trim();
                        string NOM_SOC = table.Rows[i][1].ToString().Trim();
                        int NRO_SOC = ns.numero(4);
                        int ID_TITULAR = ((NRO_SOC * 1000) + 12);
                        int NRO_DEP = 12;
                        string JERARQ = "000Z";
                        int LEG_PER = 0;
                        string DESTINO = null;
                        string F_ALTPO = null;
                        string F_ALTCI = DateTime.Today.ToShortDateString();
                        string TIP_DOC = "3";
                        VGlobales.NUM_DOC = int.Parse(table.Rows[i][2].ToString());
                        int NUM_CED = 0;
                        string F_NACIM = null;
                        string CALL_PAR = null;
                        string NRO_PAR = null;
                        string PIS_PAR = null;
                        string DPT_PAR = null;
                        string CP_PART = null;
                        string LOC_PAR = null;
                        string PRO_PAR = null;
                        string TELEFONOS = null;
                        int CAR_TE1 = 0;
                        string NUM_TE1 = null;
                        int CAR_TE2 = 0;
                        string NUM_TE2 = null;
                        string F_BAJPO = null;
                        string M_BAJPO = "X";
                        string F_BAJCI = null;
                        string M_BAJCI = "X";
                        string F_CESDE = null;
                        string COD_DTO = "000";
                        string CAT_SOC = "005";
                        string F_CACAT = null;
                        string BEAUCHEF = null;
                        string AVAL = null;
                        string F_ALTRE = null;
                        string F_ALTVI = null;
                        string GIMNASIO = null;
                        string F_ULTMO = null;
                        string EMPLEAD = null;
                        string F_CARN = null;
                        string TIP_CAR = null;
                        string DAT_DOM = null;
                        string CAM_JER = null;
                        string SEX = null;
                        string NJERARQ = null;
                        string NDESTINO = null;
                        string ESCALA = null;
                        int CC = 0;
                        string A_DTO = null;
                        int SECUENCIA = 0;
                        int CAR_FAX = 0;
                        string NUM_FAX = null;
                        string USR_ALTA = VGlobales.vp_username.Trim();
                        string FE_ALTA = null;
                        string USR_MOD = null;
                        string FE_MOD = null;
                        string USR_BAJA = null;
                        string FE_BAJA = null;
                        string NCOD_DTO = null;
                        string E_MAIL = null;
                        string SUSCRIP = null;
                        int ORD_DIA2 = 0;
                        string ORD_FEC2 = null;
                        int ORD_DIA3 = 0;
                        string ORD_FEC3 = null;
                        string ORIGEN_ALTA = "SED";
                        string CUIL = null;
                        string OBRA_SOCIAL = null;
                        byte[] FOTO = imageToByteArray(pbFoto.Image);
                        byte[] OBSERVACIONES = imageToByteArray(pbFoto.Image);

                        dlog.insertarPadresJardin(ID_TITULAR, AAR, ACRJP1, ACRJP2, ACRJP3, PAR, PCRJP1, PCRJP2, PCRJP3, APE_SOC, NOM_SOC,
                               NRO_SOC, NRO_DEP, JERARQ, LEG_PER, DESTINO, F_ALTPO, F_ALTCI, TIP_DOC, VGlobales.NUM_DOC, NUM_CED, CALL_PAR, LOC_PAR,
                               NUM_TE1, NUM_TE2, COD_DTO, CAT_SOC, GIMNASIO, ESCALA, A_DTO, USR_ALTA, NCOD_DTO, ORIGEN_ALTA, FOTO, OBSERVACIONES);

                        progressBar1.PerformStep();
                        VGlobales.CANTIDAD++;
                        Thread.Sleep(500);
                    }

                    progressBar1.Visible = false;
                    MessageBox.Show("OPERACION FINALIZADA\n\nREGISTROS INSERTADOS " + VGlobales.CANTIDAD, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    progressBar1.Visible = false;
                    MessageBox.Show("SE PRODUJO UN ERROR EN EL REGISTRO CON DNI: " + VGlobales.NUM_DOC + "\n\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public void excel(DataSet ds, string path)
        {
            string data = null;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add();
            xlWorkSheet = xlWorkBook.Worksheets[1];
            xlWorkSheet.Range["A1:Z1"].Font.Bold = true;
            xlWorkSheet.Cells[1, 1] = "NRO_SOC";
            xlWorkSheet.Cells[1, 2] = "NRO_DEP";
            xlWorkSheet.Cells[1, 3] = "APE_SOC";
            xlWorkSheet.Cells[1, 4] = "NOM_SOC";

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString().Trim();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                    xlWorkSheet.Columns[j + 1].AutoFit();
                }
            }

            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        static void OpenAdobeAcrobat(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "ACRORD32.EXE";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }

        static void OpenMicrosoftExcel(string f)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = f;
            Process.Start(startInfo);
        }

        public void buscarIngresosAsamblea(string INGRESO)
        {
            try
            {
                conString conString = new conString();
                string connectionString = conString.get();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    FbTransaction transaction = connection.BeginTransaction();
                    DataSet ds = new DataSet();
                    string query = "SELECT A.NRO_SOC, A.NRO_DEP, T.APE_SOC, T.NOM_SOC, A.FE_ALTA FROM ASAMBLEA A, TITULAR T WHERE A.ELECCION = EXTRACT(YEAR FROM CURRENT_DATE) AND A.INGRESO = '" + INGRESO + "' AND T.NRO_SOC = A.NRO_SOC AND T.NRO_DEP = A.NRO_DEP ORDER BY T.APE_SOC ASC;";
                    FbCommand cmd = new FbCommand(query, connection, transaction);
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataAdapter da = new FbDataAdapter(cmd);
                    da.Fill(ds);

                    try
                    {
                        using (FbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                                saveFileDialog1.Filter = "Archivo XLS|*.xls";
                                saveFileDialog1.Title = "Guardar Nominal Asamblea";

                                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    Cursor = Cursors.WaitCursor;
                                    excel(ds, saveFileDialog1.FileName);
                                    Cursor = Cursors.Default;
                                    DialogResult result = MessageBox.Show("LISTADO GENERADO CORRECTAMENTE \n\n ¿ABRIR EL ARCHIVO?", "LISTO!", MessageBoxButtons.YesNo);

                                    if (result == DialogResult.Yes)
                                    {
                                        OpenMicrosoftExcel(saveFileDialog1.FileName);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("NO EXISTEN REGISTROS CON LA CONDICION INDICADA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
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
            }
        }

        private void importarCuotasDescuentos()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.xls";
            ofd.ShowDialog();
            string archivo = ofd.FileName;

            if (archivo != "*.xls")
            {
                OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivo + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
                con.Open();
                DataSet dset = new DataSet();
                OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT MES, AÑO, AR, CL, AFIL, S, NYA, MA, CPTE, IMPORTE, E, SUS, CONCEPTO, CODINT FROM [CTAS_DTOS$] WHERE MES > 0;", con);
                dadp.TableMappings.Add("MES", "AÑO");
                dadp.Fill(dset);
                DataTable table = dset.Tables[0];

                try
                {
                    string INSERT = "";
                    progressBar1.Visible = true;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = table.Rows.Count;
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        int MES = int.Parse(table.Rows[i][0].ToString());
                        int AÑO = int.Parse(table.Rows[i][1].ToString());
                        int AR = int.Parse(table.Rows[i][2].ToString());
                        int CL = int.Parse(table.Rows[i][3].ToString());
                        int AFIL = int.Parse(table.Rows[i][4].ToString());
                        int S = int.Parse(table.Rows[i][5].ToString());
                        string NYA = table.Rows[i][6].ToString();
                        string MA = table.Rows[i][7].ToString();
                        int CPTE = int.Parse(table.Rows[i][8].ToString());
                        decimal IMPORTE = decimal.Parse(table.Rows[i][9].ToString().Replace(",", "."));
                        string E = table.Rows[i][10].ToString();
                        string SUS = table.Rows[i][11].ToString();
                        string CONCEPTO = table.Rows[i][12].ToString();
                        int CODINT = int.Parse(table.Rows[i][13].ToString());

                        INSERT += "INSERT INTO CUOTAS (MES, ANIO, AR, CL, AFIL, S, NYA, MA, CODINT, CPTE, IMPORTE, E, SUS, CONCEPTO) ";
                        INSERT += "VALUES (" + MES + ", " + AÑO + ", " + AR + ", " + CL + ", " + AFIL + ", " + S + ", '" + NYA + "', '" + MA + "', " + CODINT + ", " + CPTE + ", " + IMPORTE + ", '" + E + "', '" + SUS + "', '" + CONCEPTO + "');\n";
                        progressBar1.PerformStep();
                    }

                    Clipboard.SetData(DataFormats.Text, (Object)INSERT);
                }
                catch (Exception error)
                {
                    MessageBox.Show("SE PRODUJO UN ERROR\n\n" + error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    progressBar1.Visible = false;
                    MessageBox.Show("OPERACION FINALIZADA", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importarCuotasDescuentos();
        }

        private void buscarAdjunto()
        {
            string connectionString;
            Datos_ini ini2 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini2.Servidor;  cs.Port = int.Parse(ini2.Puerto);
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
                    string busco = "SELECT ID, ADJUNTO FROM FACTURAS WHERE ADJUNTO IS NOT NULL;";
                    FbCommand cmd = new FbCommand(busco, connection, transaction);
                    cmd.CommandText = busco;
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    FbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        progressBar1.Visible = true;
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = 758;
                        progressBar1.Value = 1;
                        progressBar1.Step = 1;

                        while (reader.Read())
                        {
                            string FILE = reader.GetString(reader.GetOrdinal("ID"));
                            Byte[] ADJUNTO  = (Byte[])reader.GetValue(reader.GetOrdinal("ADJUNTO"));
                            File.WriteAllBytes(@"C:\PDF\" + FILE + ".PDF", ADJUNTO);
                            progressBar1.PerformStep();
                        }
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

        private void bajarPDFsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            buscarAdjunto();
            Cursor = Cursors.Default;
        }

        private void capturarFotoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            EjemploWebcam.Form1 frmfoto = new EjemploWebcam.Form1();
            frmfoto.ShowDialog(this);
            Cursor = Cursors.Default;
        }

        private void abmProfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            abmProfesionales ap = new abmProfesionales(0);
            ap.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void calcularCuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            tarjetas tc = new tarjetas();
            tc.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void solicitudPasajesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bonosTurismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            bono.BonosTurismo bt = new bono.BonosTurismo();
            bt.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void aBMRegimenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SOCIOS.Tabla.AbmTabla regimen = new Tabla.AbmTabla("REGIMEN");
            regimen.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void hotelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            turismos.Hoteles htl = new turismos.Hoteles();
            htl.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void aBMTrasladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SOCIOS.Tabla.AbmTabla traslado = new Tabla.AbmTabla("TRASLADO");
            traslado.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void aBMTipoSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SOCIOS.Tabla.AbmTabla tipoSalida = new Tabla.AbmTabla("TIPOSALIDA");
            tipoSalida.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void aBMSalidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SOCIOS.Turismo.Salidas salida = new Turismo.Salidas();
            salida.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void bonosOdontologicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            bono.BonosOdontologia boodonto = new bono.BonosOdontologia();
            boodonto.Show();
            Cursor = Cursors.Default;
        }

        private void listadoDeSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Confiteria.grillaPreComanda gpc = new Confiteria.grillaPreComanda();
            gpc.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void listadoDeComandasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Confiteria.listadoComandas lc = new Confiteria.listadoComandas();
            lc.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            compras co = new compras();
            co.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            compras co = new compras();
            co.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void arancelesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            nuevoAbmAranceles ar = new nuevoAbmAranceles();
            ar.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem1_Click_2(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            compras co = new compras();
            co.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void ingresosPersonalYDirectivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            listadoMovimientos lm = new listadoMovimientos();
            lm.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            nuevoUsuario nu = new nuevoUsuario();
            nu.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void abrirTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ticketAsistencia ta = new ticketAsistencia();
            ta.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GrillaPreRecibo gpr = new GrillaPreRecibo();
            gpr.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            anularRecibo ar = new anularRecibo();
            ar.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void actualizadorDeDependenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registroSocios.dependencias de = new registroSocios.dependencias();
            de.ShowDialog();
        }

        private void generarTXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            descuentos.GENERACION_TXT gtxt = new descuentos.GENERACION_TXT();
            gtxt.ShowDialog();
        }

        private void archivosProcesadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            descuentos.ARCHIVOS_PROCESADOS archivos = new descuentos.ARCHIVOS_PROCESADOS();
            archivos.ShowDialog();
        }

        private void solicitudAlojamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Turismo.Solicitudes.ProcesoSolicitudes ps = new Turismo.Solicitudes.ProcesoSolicitudes();
            ps.ShowDialog();
        }

        private void hotelXHabitaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Turismo.HabitacionHotel hh = new Turismo.HabitacionHotel();
            hh.ShowDialog();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GrillaPreRecibo gpr = new GrillaPreRecibo();
            gpr.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            planillaDeCaja pc = new planillaDeCaja();
            pc.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void listadoDescuentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deportes.DescuentoDeportes dd = new deportes.DescuentoDeportes();
            dd.ShowDialog();
        }

        private void exportarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SOCIOS.Entrada_Campo.IngresosCampo ic = new Entrada_Campo.IngresosCampo();
            ic.ShowDialog();
        }

        private void ingresosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SOCIOS.Entrada_Campo.ListadoIngresos li = new Entrada_Campo.ListadoIngresos();
            li.ShowDialog();
        }

        private void importarDatosCamposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SOCIOS.Entrada_Campo.Procesar_Registros rp = new Entrada_Campo.Procesar_Registros("CPOCABA");
            rp.ShowDialog();
        }

        private void toolStripMenuItem10_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GrillaPreRecibo gpr = new GrillaPreRecibo();
            gpr.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            anularRecibo ar = new anularRecibo();
            ar.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            planillaDeCaja pc = new planillaDeCaja();
            pc.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void ingresaronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscarIngresosAsamblea("S");
        }

        private void noIngresaronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscarIngresosAsamblea("N");
        }

        private void aBMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            abmPatrimonio ap = new abmPatrimonio();
            ap.ShowDialog();
        }

        private void importarBienestarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bienestar.DatosBienestar ds = new Bienestar.DatosBienestar();
            ds.ShowDialog();

        }

        private void ingresoXCantidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SOCIOS.Entrada_Campo.CSPFA.EntradaCampoXmayor ec = new Entrada_Campo.CSPFA.EntradaCampoXmayor();
            ec.ShowDialog();
        }

        private void iDEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bo dlog = new bo();
            string QUERY = "SELECT ID FROM ID_CUIL_TRASPASADOS;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                Cursor = Cursors.WaitCursor;

                foreach (DataRow dr in foundRows)
                {
                    string ID_EMPLEADO = dr[0].ToString();
                    string COD_CIUDAD = "7811000";
                    string TRASPASADO = "S";
                    dlog.idEmpleado(ID_EMPLEADO, COD_CIUDAD, TRASPASADO);
                    Thread.Sleep(100);
                }

                Cursor = Cursors.Default;

                MessageBox.Show("FIN");
            }
        }

        private void noEstanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conString conString = new conString();
            string connectionString = conString.get();
            FbConnection connection = new FbConnection(connectionString);
            connection.Open();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.xls";
            ofd.ShowDialog();
            string ARCHIVO = ofd.FileName;

            OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ARCHIVO + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"");
            con.Open();
            DataSet dset = new DataSet();
            OleDbDataAdapter dadp = new OleDbDataAdapter("SELECT * FROM [Hoja1$] WHERE QUERY IS NOT NULL;", con);
            dadp.TableMappings.Add("QUERY", "QUERY");
            dadp.Fill(dset);
            DataTable table = dset.Tables[0];
            int X = 0;
            Cursor = Cursors.WaitCursor;
            FbTransaction transaction = connection.BeginTransaction();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                try
                {
                    FbCommand com = new FbCommand(table.Rows[i][0].ToString(), connection, transaction);
                    com.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show("error en linea " + X + "\n" + error);
                }

                X++;
            }

            transaction.Commit();
            Cursor = Cursors.Default;
            //Clipboard.SetData(DataFormats.Text, (Object)QUERY);
            MessageBox.Show("LISTO");
        }

        private void margenesPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "*.pdf";
            ofd.ShowDialog();
            string archivo = ofd.FileName;

        }

        private void cajasAnterioresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cajasAnteriores ca = new cajasAnteriores();
            ca.ShowDialog();
        }

        private void verTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SOCIOS.Tecnica.Tickets ti = new SOCIOS.Tecnica.Tickets();
            ti.ShowDialog();
        }

        private void listaDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Confiteria.listadoAranceles la = new Confiteria.listadoAranceles();
            la.ShowDialog();
        }

        private void puntosDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            puntosDeVenta pv = new puntosDeVenta();
            pv.ShowDialog();
        }

        private void dePFAACABAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PFA_CABA PFA_CABA = new PFA_CABA();
            PFA_CABA.ShowDialog();
        }

        private void deCABAAPFAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CABA_PFA CABA_PFA = new CABA_PFA();
            CABA_PFA.ShowDialog();
        }

        private void reporteDeVerificacionAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SOCIOS.deportes.Asistencia.VerificacionAsistencia va = new deportes.Asistencia.VerificacionAsistencia();
            va.ShowDialog();
        }

        private void netUse(string SERVER, string USUARIO, string PASSWORD)
        {
            ProcessStartInfo PInfo;
            Process P;
            PInfo = new ProcessStartInfo("cmd", @"/c net use \\" + SERVER + " " + PASSWORD + " /user:" + USUARIO);
            PInfo.CreateNoWindow = true; 
            PInfo.UseShellExecute = true;
            P = Process.Start(PInfo);
            P.WaitForExit(5000);
            P.Close();
        }

        private void stopFirebird()
        {
            ProcessStartInfo PInfo;
            Process P;
            PInfo = new ProcessStartInfo("cmd", @"/c net stop FirebirdServerDefaultInstance");
            PInfo.CreateNoWindow = false; 
            PInfo.UseShellExecute = true; 
            P = Process.Start(PInfo);
            P.WaitForExit(5000);
            P.Close();
        }

        private void actualizarDBToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            netUse("192.168.1.6", "ahernandez", "C1rc4C0mb4t");

            if (File.Exists(@"\\192.168.1.6\Data\BACKUP\CSPFA_DATOS7.FDB"))
            {
                string FOLDER = "";
                string FULLPATH = "";
                string NEWNAME = "";
                FolderBrowserDialog FBD = new FolderBrowserDialog();

                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    FOLDER = FBD.SelectedPath;
                    List<String> TempFiles = new List<String>();
                    TempFiles.Add(@"\\192.168.1.6\Data\BACKUP\CSPFA_DATOS7.FDB");
                    FULLPATH = FOLDER + "CSPFA_DATOS7.FDB";
                    NEWNAME = FOLDER + "CSPFA_DATOS7.OLD";

                    DialogResult dr = MessageBox.Show("¿CONFIRMA REALIZAR LA ACTUALIZACIÓN DE LA BASE DE DATOS?", "PREGUNTA", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        if (File.Exists(FULLPATH))
                        {
                            stopFirebird();

                            if (File.Exists(NEWNAME))
                            {
                                File.Delete(NEWNAME);
                            }

                            File.Move(FULLPATH, NEWNAME);
                            File.Delete(FULLPATH);
                        }

                        CopyFiles.CopyFiles Temp = new CopyFiles.CopyFiles(TempFiles, FOLDER, "UPDATE");
                        CopyFiles.DIA_CopyFiles TempDiag = new CopyFiles.DIA_CopyFiles("Actualizando la base de datos...");
                        TempDiag.SynchronizationObject = this;
                        Temp.CopyAsync(TempDiag);
                    }
                }
            }
            else
            {
                MessageBox.Show("EL ARCHIVO DE BASE DE DATOS NO EXISTE EN ORIGEN", "ERROR");
            }
        }

        private void backupDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿CONFIRMA REALIZAR EL BACKUP DE LA BASE DE DATOS?", "PREGUNTA", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                List<String> TempFiles = new List<String>();
                TempFiles.Add(@"\\192.168.1.6\Data\CSPFA_DATOS7.FDB");
                CopyFiles.CopyFiles Temp = new CopyFiles.CopyFiles(TempFiles, @"\\192.168.1.6\Data\BACKUP", "BACKUP");
                CopyFiles.DIA_CopyFiles TempDiag = new CopyFiles.DIA_CopyFiles("Realizando backup de la base de datos...");
                TempDiag.SynchronizationObject = this;
                Temp.CopyAsync(TempDiag);
            }
        }

        private void generalBelgranoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importarComprobantes ic = new importarComprobantes("IMPORTAR COMPROBANTES CAMPO GENERAL BELGRANO", "CPOPOLVORINES");
            ic.ShowDialog();
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SOCIOS.deportes.Campos.Exportar_Deportes ed = new deportes.Campos.Exportar_Deportes("DEPORTES");
            ed.ShowDialog();
        }

        private void aBMTipoHabitaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SOCIOS.Turismo.TipoHabitacion tp = new Turismo.TipoHabitacion();
            tp.ShowDialog();
        }

        private void aBMPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abmPersonas ap = new abmPersonas();
            ap.ShowDialog();
        }

        private void comprobantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importarComprobantes ic = new importarComprobantes("IMPORTAR COMPROBANTES CAMPO DELFO CABRERA", "CPOCABA");
            ic.ShowDialog();
        }

        private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SOCIOS.Entrada_Campo.Procesar_Registros rp = new Entrada_Campo.Procesar_Registros("CPOCABA");
            rp.ShowDialog();
        }

        private void movimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importarMovimientos im = new importarMovimientos("CPOCABA");
            im.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            importarComprobantes ic = new importarComprobantes("IMPORTAR COMPROBANTES CAMPO GENERAL BELGRANO", "CPORANELAGH");
            ic.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            SOCIOS.Entrada_Campo.Procesar_Registros rp = new Entrada_Campo.Procesar_Registros("CPOCABA");
            rp.ShowDialog();
        }

        private void toolStripMenuItem12_Click_1(object sender, EventArgs e)
        {
            importarMovimientos im = new importarMovimientos("CPORANELAGH");
            im.ShowDialog();
        }

        private void listadoIngresosPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoMovimientos lm = new listadoMovimientos();
            lm.ShowDialog();
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            compras co = new compras();
            co.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void planDeCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SOCIOS.CuentaSocio.PlanCuenta pc = new CuentaSocio.PlanCuenta(VGlobales.vp_role.TrimEnd().TrimStart());
            pc.ShowDialog();
        }

        private void planDeCuentaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SOCIOS.CuentaSocio.PlanCuenta pc = new CuentaSocio.PlanCuenta(VGlobales.vp_role.TrimEnd().TrimStart());
            pc.ShowDialog();
        }

        private void planDeCuentaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SOCIOS.CuentaSocio.PlanCuenta pc = new CuentaSocio.PlanCuenta(VGlobales.vp_role.TrimEnd().TrimStart());
            pc.ShowDialog();
        }

        private void bonosEnBlancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SOCIOS.bono.Bonos.Carga_Bonos_Blanco_Turismo b = new bono.Bonos.Carga_Bonos_Blanco_Turismo();
            b.ShowDialog();
        }

        private void conveniosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Convenios.Convenios co = new Convenios.Convenios();
            co.ShowDialog();
        }

        private void turismoControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Turismo.Stats_Hoteles sh = new Turismo.Stats_Hoteles();
            sh.ShowDialog();
        }

        private void bonosEnBlancoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SOCIOS.bono.Bonos.Carga_Bonos_Blanco_Odontologia co = new bono.Bonos.Carga_Bonos_Blanco_Odontologia();
            co.Show();
        }

        private void completarBonosEnBlancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SOCIOS.bono.Bonos.Carga_Bono_Blanco_Socio bb = new bono.Bonos.Carga_Bono_Blanco_Socio(VGlobales.vp_role);
            bb.ShowDialog();
        }

        private void testFacturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Factura_Electronica.Testing_Facturacion tf = new Factura_Electronica.Testing_Facturacion();
            tf.ShowDialog();
        }

        private void tESTINGFCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Factura_Electronica.Testing_Facturacion tf = new Factura_Electronica.Testing_Facturacion();
            tf.ShowDialog();
        }

        private void tESTINGFCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Factura_Electronica.Testing_Facturacion tf = new Factura_Electronica.Testing_Facturacion();
            tf.ShowDialog();
        }

        private void confiteríaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Confiteria.importador imp = new Confiteria.importador("CPOCABA");
            imp.ShowDialog();
        }
    }
}