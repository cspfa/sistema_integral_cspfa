using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace SOCIOS
{
    public partial class ticketAsistencia : Form
    {
        bo_Tecnica dlog = new bo_Tecnica();
        string NOM_EQ = "";
        string DIR_IP = "";
        string SO = "";
        string USUARIO_WIN = "";
        string USUARIO_ALTA = VGlobales.vp_username;
        string ROL = "";
        bool Mostrar_IP = false;
        Mailer mailer = new Mailer();

        public ticketAsistencia()
        {
            InitializeComponent();
            this.Inicio();

            comboPara();
            comboPrioridad();
        }

        private void comboPara()
        {
            if ( Mostrar_IP==true) 
             cbPara.Items.Add("ESTE EQUIPO");
           
            cbPara.Items.Add("OTRO EQUIPO");
            cbPara.Items.Add("IMPRESORA");
        }

        private void comboPrioridad()
        {
            cbPrioridad.Items.Add("NORMAL");
            cbPrioridad.Items.Add("ALTA");
            cbPrioridad.Items.Add("BAJA");
        }

        private void cbPara_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbPara.Text == "OTRO EQUIPO" || cbPara.Text == "IMPRESORA")
            {
                lbNombreEq.Visible = true;
                tbNombreEq.Visible = true;
            }
            else
            {
                lbNombreEq.Visible = false;
                tbNombreEq.Visible = false;
            }
        }

        private void tbProblema_KeyUp(object sender, KeyEventArgs e)
        {
            int DISP = 300 - tbProblema.Text.Length;
            lbDisponibles.Text = "CARACTERES DISPONIBLES: " + DISP.ToString();

            if (DISP < 50)
            {
                lbDisponibles.ForeColor = Color.Red;
            }
            else
            {
                lbDisponibles.ForeColor = Color.Black;
            }
        }

        public string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    if (ip.ToString().Substring(0, 10) == "192.168.1.")
                    {
                        localIP = ip.ToString();
                    }
                }
            }

            return localIP;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CONTINUAR = "N";
            string Prioridad = cbPrioridad.Text;

            if (Prioridad.Length == 0)
            {
                MessageBox.Show("INGRESAR  PRIORIDAD ");
                return;
            }
            else
                CONTINUAR = "S";

            if (cbPara.Text == "OTRO EQUIPO" || cbPara.Text == "IMPRESORA" )
            {
                if (tbNombreEq.Text == "")
                {
                    MessageBox.Show("INGRESAR EL NOMBRE DEL EQUIPO");
                    return;
                }
                else if (tbProblema.Text == "")
                {
                    MessageBox.Show("INGRESAR LA DESCRIPCION DEL PROBLEMA");
                    return;
                }
                else 
                {
                    CONTINUAR = "S";
                }

                NOM_EQ = tbNombreEq.Text;
            }
            else if (tbProblema.Text == "")
            {
                MessageBox.Show("INGRESAR LA DESCRIPCION DEL PROBLEMA");
                return;
            }
            else
            {
                CONTINUAR = "S";
            }
            if (Mostrar_IP == false)
            {
                ROL = cbRol.SelectedText.ToString();
            }
          
            if (CONTINUAR == "S")
            {
                this.Grabar(tbProblema.Text, cbPrioridad.SelectedItem.ToString(), 1);
            }
        }


        private void Grabar(string PROBLEMA,string PRIORIDAD,int TIPO)
        {
            try
            {
                string ESTADO = "PENDIENTE";
                string Texto = "";
                string FECHA_PENDIENTE = DateTime.Now.ToString();
              
                if (VGlobales.vp_role == "SISTEMAS" || VGlobales.vp_role.Contains("TECNICA"))
                    ROL = cbRol.SelectedText.ToString();
                else
                    ROL = VGlobales.vp_role;

                dlog.altaAsistenciaTecnica(NOM_EQ, DIR_IP, SO, USUARIO_WIN, USUARIO_ALTA, PROBLEMA, PRIORIDAD, ESTADO, FECHA_PENDIENTE,ROL,TIPO);
                int ID = this.GetMaxID();

                /*string mail = Config.getValor(ROL, "MAIL", 0);

                if (mail.Length > 0)
                {
                    mail = ";" + mail;
                }

                if (TIPO == 1)
                    Texto = GetTexto(NOM_EQ, DIR_IP, SO, USUARIO_WIN, USUARIO_ALTA, PROBLEMA, PRIORIDAD, ROL);
                else
                    Texto = "PEDIDO DE INSUMO :" + PROBLEMA;*/
 
                //mailer.EnvioMail("cspfaweb@gmail.com" , "ALTA TICKET NRO:" + ID.ToString(),Texto);

                MessageBox.Show("DADO DE ALTA EL TICKET NRO " + ID.ToString(), "ALTA TICKET");
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO DAR DE ALTA A LA SOLICITUD DE ASISTENCIA TECNICA\n" + error, "ERROR");
            }
        
        }

        private string GetTexto(string NOM_EQ, string DIR_IP, string SO, string USUARIO_WIN, string USUARIO_ALTA, string PROBLEMA, string PRIORIDAD, string ROL)

        {
            string Texto="";
            Texto = Texto + "<b> EQUIPO:</b>" + NOM_EQ + "<br>";
            Texto = Texto + " <b> IP:</b>" + DIR_IP + "<br>";
            Texto = Texto + "<b> SISTEMA OPERATIVO:</b>" + SO + "<br>";
            Texto = Texto + "<b> USUARIO WINDOWS:</b>" + USUARIO_WIN + "<br>";
            Texto = Texto + "<b> USUARIO ALTA:</b>" + USUARIO_ALTA + "<br>";
            Texto = Texto + "<b> PROBLEMA:</b>" + PROBLEMA + "<br>";
            Texto = Texto + "<b> ROL:</b>" + ROL + "<br>";
            Texto = Texto + "<b> PRIORIDAD:</b>" + PRIORIDAD;

            return Texto;
        
        }

        public int GetMaxID()
        {
            string QUERY = "SELECT coalesce (MAX(ID),0) FROM ASISTENCIAS_TECNICAS ";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return Int32.Parse(foundRows[0][0].ToString().Trim());
            }
            else
                return 0;


        }

        private void Inicio()

        {
            /*if (VGlobales.vp_role.Contains("SISTEMAS") || VGlobales.vp_role.Contains("TECNICA"))
            {
                Mostrar_IP = false;
                lbNombreEq.Visible = true;
                tbNombreEq.Visible = true;
                lbRol.Visible      = true;
                cbRol.Visible      = true;
                this.Cargo_Roles();

            }
            else
            {
                Mostrar_IP = true;
                NOM_EQ = System.Environment.MachineName;
                DIR_IP = LocalIPAddress();
                SO = Environment.OSVersion.ToString();
                USUARIO_WIN = Environment.UserName;
                USUARIO_ALTA = VGlobales.vp_username;
                ROL = VGlobales.vp_role;

            }*/

            Mostrar_IP = false;
            lbNombreEq.Visible = true;
            tbNombreEq.Visible = true;
            lbRol.Visible = true;
            cbRol.Visible = true;
            this.Cargo_Roles();
        
        }

        private void Cargo_Roles()

        { 
               
          
           
             cbRol.DataSource = null;
             cbRol.Items.Clear();
             cbRol.DataSource = dlog.BO_EjecutoDataTable("SELECT  rdb$role_name ROL  FROM RDB$ROLES ORDER BY ROL;");
             cbRol.DisplayMember = "ROL";
             cbRol.ValueMember = "ROL";
             cbRol.SelectedItem = 1; 
        }
       
        private void btnVerTickets_Click(object sender, EventArgs e)
        {
            SOCIOS.Tecnica.Tickets ti = new SOCIOS.Tecnica.Tickets();
            ti.ShowDialog();
        }


    }
}
