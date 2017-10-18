using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.entradaCampo.Campo
{
    
    public partial class EntradaEvento : Form
    {

        List<Ingreso_Evento> lista = new List<Ingreso_Evento>();
        EntradaCampoService es = new EntradaCampoService();
        bo_Entrada_Campo dlog = new bo_Entrada_Campo();
        bool Reintegro = false;
        string DNI = "";
        string NOMBRE = "";
        string APELLIDO = "";
        int NRO_SOCIO = 0;
        int NRO_DEP = 0;
        string LEGAJO = "";
        string TIPO = "";
        decimal MontoMaximo = 0;
        public EntradaEvento(string pDNI, string pNOMBRE, string pAPELLIDO, int pNRO_Socio,int pNRO_DEP,string pTIPO,string pLegajo, bool pReintegro,decimal pMontoMaximo, bool Manual)
        {

            InitializeComponent();
            Reintegro = pReintegro;
            DNI = pDNI;
            NOMBRE = pNOMBRE;
            APELLIDO = pAPELLIDO;
            NRO_SOCIO = pNRO_Socio;
            NRO_DEP = pNRO_DEP;
            LEGAJO = pLegajo;
            TIPO = pTIPO.TrimEnd();
            Reintegro = pReintegro;
            MontoMaximo = pMontoMaximo;

            if (VGlobales.vp_role == "SISTEMAS")
            {
                gpCantidad.Visible = true;
            }
            else
                gpCantidad.Visible = false;

            if (pReintegro)
            {
                lbReintegro.Text = pMontoMaximo.ToString();
                gpReintegro.Visible = true;
            }
            else
            {
                gpReintegro.Visible = false;
            
            }

            chkSocio.Visible = Manual;
            chkPersonalPolicial.Visible = Manual;


        }

        private void Pago_Click(object sender, EventArgs e)
        {
            try
            {

                int i = 0;

                while (i < Int32.Parse(tbCantidad.Text))
                {
                    if (Reintegro)
                    {


                        lista.Add(new Ingreso_Evento((-1) * es.EntradaEvento));
                    }
                    else
                    {
                        lista.Add(new Ingreso_Evento(es.EntradaEvento));
                    }
                    i = i + 1;

                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;
                lbCantidad.Text = lista.Count.ToString();
                lbMonto.Text  = lista.Sum(x => x.Monto).ToString();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void EntradaEvento_Load(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            lista = new List<Ingreso_Evento>();
            dataGridView1.DataSource = null;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int ID_INT = es.Ultimo_ID(VGlobales.vp_role);
            string Tipo_reg     = "ALTA";
            int Cantidad       = 0;
            decimal MontoTotal = 0;


            try
            {
                if (lista != null)
                {
                    Cantidad = lista.Count;
                    MontoTotal = Decimal.Round(lista.Sum(x => x.Monto), 2);
                }

                if (MontoTotal <= 0)
                {
                    Tipo_reg = "BAJA";
                    Cantidad = Cantidad * (-1);
                    MontoTotal = MontoTotal * (-1);
                }

                if (MontoTotal != 0)
                {
                    if (Reintegro)
                    {
                        if (MontoTotal > MontoMaximo)
                        {
                            throw new Exception("El monto del reintegro excede el Monto Maximo Posible a REintegrar");
                        }
                    
                    }

                    if (chkPersonalPolicial.Checked || chkSocio.Checked)
                    {
                        if (tbLegajoNroSocio.Text.Length > 0)
                            NRO_SOCIO = Int32.Parse(tbLegajoNroSocio.Text);
                    }
                    dlog.Entrada_Campo_Ins(DNI, NOMBRE, APELLIDO, NRO_SOCIO, NRO_DEP, TIPO, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Cantidad, MontoTotal, System.DateTime.Now, VGlobales.vp_role, VGlobales.vp_username, 0, 0, 0, Cantidad, MontoTotal, ID_INT, Tipo_reg, 0, "INGRESO EVENTO DEPORTIVO", 0, "", "");




                    DialogResult dr = MessageBox.Show("Ingreso Exitoso del Ticket Nro :  " + ID_INT.ToString() + "  , imprimir Cupon ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (dr == DialogResult.OK)
                    {
                        this.Imprimir();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            { 
              
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
            
        
        }

        public void Imprimir()
        {
            int ID = es.GetMaxID_ROL(DNI, VGlobales.vp_role.TrimEnd().TrimStart());
            int cantidad = lista.Count;
            es.Imprimir(0,0,0,0,0,0,0,0,0,0,0,0, ID, DNI + "-" + APELLIDO + "," + NOMBRE, TIPO, false, false, true, "", cantidad,false);
            es.Imprimir(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ID, DNI + "-" + APELLIDO + "," + NOMBRE, TIPO, false, false, false, "", cantidad,false);
        }

        private void chkSocio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkPersonalPolicial_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPersonalPolicial.Checked)
            {
                chkSocio.Checked = false;
                lbLegajoNroSocio.Text = "LEGAJO";
                lbLegajoNroSocio.Visible = true;
                tbLegajoNroSocio.Visible = true;

            }
            else if (chkSocio.Checked == false)
            {
                lbLegajoNroSocio.Visible = false;
                tbLegajoNroSocio.Visible = false;
            }
        }

        private void chkSocio_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkSocio.Checked)
            {
                chkPersonalPolicial.Checked = false;
                lbLegajoNroSocio.Text = "NRO SOCIO";
                lbLegajoNroSocio.Visible = true;
                tbLegajoNroSocio.Visible = true;

            }
            else if (chkPersonalPolicial.Checked == false)
            {
                lbLegajoNroSocio.Visible = false;
                tbLegajoNroSocio.Visible = false;
            }
        }

    }

    public class Ingreso_Evento
    {
        public string TITULO { get; set; }
        public decimal Monto { get; set; }
        public Ingreso_Evento(decimal pMonto)
        {
            TITULO = "Ingreso Evento Deportivo";
            Monto = pMonto;
        }

    }
}
