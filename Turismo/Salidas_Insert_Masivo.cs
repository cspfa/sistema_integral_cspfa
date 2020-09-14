using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Turismo
{
  
    public partial class Salidas_Insert_Masivo : Form
    {

        bo_Turismo dlog = new bo_Turismo();
        SOCIOS.Turismo.TurismoUtils utilsTurismo = new TurismoUtils();

        int Inicio;
        string Nombre;
        int ID;
        string Modo;
        Turismo.Salida salida;
        List<LISTA_FECHAS> FECHAS = new List<LISTA_FECHAS>();

        public Salidas_Insert_Masivo()
        {
            InitializeComponent();

           
            this.Blanquear_Campos();
            this.InicializarCombos();         
            utilsTurismo.UpdateComboLocalidad(6500, cbLocalidadDesde);

            utilsTurismo.UpdateComboLocalidad(6500, cbLocalidadHasta);
            gpDatos.Visible = true;

        }



        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            compras c = new compras();
            c.ShowDialog();
            utilsTurismo.ComboOperador(cbOperador, false);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            this.Blanquear_Campos();
        }

        private void cbDiaria_CheckedChanged(object sender, EventArgs e)
        {
           

        }


        private void Seteo_diaria(bool Diaria)
        {
            dtSalida.Visible = !Diaria;
        }


        #region Combos

        private void InicializarCombos()
        {
            utilsTurismo.UpdateComboProvincia(0, cbProvinciaDesde);
            utilsTurismo.UpdateComboProvincia(0, cbProvinciaHasta);
            //   utilsTurismo.UpdateComboLocalidad(6500, cbLocalidadDesde);
            //  utilsTurismo.UpdateComboLocalidad(6500, cbLocalidadHasta);
            utilsTurismo.UpdateComboTabla("TURISMO_TIPO", cbTipo);
            utilsTurismo.UpdateComboTabla("TURISMO_REGIMEN", cbRegimen);
            utilsTurismo.UpdateComboTabla("TURISMO_TRASLADO", cbTraslado);

            utilsTurismo.ComboMoneda(cbMoneda);
            utilsTurismo.ComboOperador(cbOperador, false);


        }

        private void cbProvinciaDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Inicio == 0 && cbProvinciaDesde.SelectedItem != null)
            {
                cbLocalidadDesde.DataSource = null;
                utilsTurismo.UpdateComboLocalidad(Int32.Parse(cbProvinciaDesde.SelectedValue.ToString()), cbLocalidadDesde);
            }
        }

        private void cbProvinciaHasta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Inicio == 0 && cbProvinciaHasta.SelectedItem != null)
            {
                cbLocalidadHasta.DataSource = null;
                utilsTurismo.UpdateComboLocalidad(Int32.Parse(cbProvinciaHasta.SelectedValue.ToString()), cbLocalidadHasta);
            }
        }

        private void cbLocalidadDesde_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbLocalidadHasta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnLocalidad_Click(object sender, EventArgs e)
        {
            SOCIOS.Turismo.AgregarLocalidad al = new SOCIOS.Turismo.AgregarLocalidad(Int32.Parse(cbProvinciaDesde.SelectedValue.ToString()));
            DialogResult dr = al.ShowDialog();

            if (dr == DialogResult.OK)
            {
                cbLocalidadDesde.DataSource = null;
                cbLocalidadHasta.DataSource = null;

                utilsTurismo.UpdateComboLocalidad(Int32.Parse(cbProvinciaDesde.SelectedValue.ToString()), cbLocalidadDesde);
                utilsTurismo.UpdateComboLocalidad(Int32.Parse(cbProvinciaHasta.SelectedValue.ToString()), cbLocalidadHasta);
            }
        }

        private void NuevoBank_Click(object sender, EventArgs e)
        {
            Inicio = 0;
            this.Blanquear_Campos();
            Modo = "INS";
            utilsTurismo.UpdateComboLocalidad(6500, cbLocalidadDesde);

            utilsTurismo.UpdateComboLocalidad(6500, cbLocalidadHasta);
            gpDatos.Visible = true;

        }

        private void Blanquear_Campos()
        {


            tbNombre.Text = "";

            tbEstadia.Text = "";

            tbHotel.Text = "";

            tbPrecioSocio.Text = "0";
            tbPrecioInvitado.Text = "0";
            tbPrecioInterCirculo.Text = "0";

            tbObs.Text = "";


            cbAgotado.Checked = false;
            cbDestacado.Checked = false;
            dtSalida.Value = System.DateTime.Now;

            dgvFecha.DataSource = null;
            FECHAS = new List<LISTA_FECHAS>();

        }


        private void Validar()
        {
            if (tbHotel.Text.Length == 0)
                throw new Exception("Debe Ingresar Hotel");
            if (tbNombre.Text.Length == 0)
                throw new Exception("Debe Ingresar Nombre");
            if (tbPrecioSocio.Text.Length == 0)
                throw new Exception("Debe Ingresar Precio Socio");
            if (tbPrecioInvitado.Text.Length == 0)
                throw new Exception("Debe Ingresar Precio Invitado");
            if (tbPrecioInterCirculo.Text.Length == 0)
                throw new Exception("Debe Ingresar Precio Intercirculo");

        }

        private void Salidas_Insert_Masivo_Load(object sender, EventArgs e)
        {

        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            FECHAS.Add( new LISTA_FECHAS(dtSalida.Value));
            dgvFecha.DataSource = null;
            dgvFecha.DataSource = FECHAS;
            
                
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int ProvDesde = Int32.Parse(cbProvinciaDesde.SelectedValue.ToString());
                int ProvHasta = Int32.Parse(cbProvinciaHasta.SelectedValue.ToString());
                int LocDesde = Int32.Parse(cbLocalidadDesde.SelectedValue.ToString());
                int LocHasta = Int32.Parse(cbLocalidadHasta.SelectedValue.ToString());
                int Operador = Int32.Parse(cbOperador.SelectedValue.ToString());
                decimal Socio = decimal.Parse(tbPrecioSocio.Text);
                decimal Invitado = decimal.Parse(tbPrecioInvitado.Text);
                decimal InterCirculo = decimal.Parse(tbPrecioInterCirculo.Text);
                decimal Menor = decimal.Parse(tbMenor.Text);
                decimal CocheCama = decimal.Parse(tbCocheCama.Text);
                int Regimen = Int32.Parse(cbRegimen.SelectedValue.ToString());
                int Traslado = Int32.Parse(cbTraslado.SelectedValue.ToString());
                int Tipo = Int32.Parse(cbTipo.SelectedValue.ToString());
                int Hotel = 0;
               



                utilsTurismo.checkDestinosRepetidos(LocDesde, LocHasta);

                if (Socio == 0)
                    throw new Exception("El Valor Socio No Puede ser 0");
                if (Invitado == 0)
                    throw new Exception("El Valor Invitado No Puede ser 0");
                if (InterCirculo == 0)
                    throw new Exception("El Valor Intercirculo No Puede ser 0");
                if (Menor == 0)
                    throw new Exception("El Valor Menor No Puede ser 0");
                if (tbNombre.Text.Length==0)
                    throw new Exception("Ingrese Nombre de la Salida");

                string Mensaje = "Se van a generar " + FECHAS.Count.ToString() + " Salida/s , Aptas Confeccion Bono ";

                if (cbCabecera.Checked)
                {
                    Mensaje =  Mensaje + " , Tambien se genera una salida con todas las fechas para mostrar solo en WEB";
                
                }


                if (MessageBox.Show(Mensaje,"Generar Salidas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    
                    int count = 0;
                    foreach (LISTA_FECHAS  fecha in FECHAS)
                    {   
                        DateTime D = fecha.FECHAS;
                        if (count==0 &&  cbCabecera.Checked)
                            dlog.Salida_Ins(Concat_Fechas(tbNombre.Text), D, cbAgotado.Checked, ProvDesde, ProvHasta, Operador, LocDesde, LocHasta, Socio, Invitado, InterCirculo, Menor, tbEstadia.Text, Regimen, Traslado, Tipo, Hotel, tbHotel.Text, cbDestacado.Checked, cbMoneda.SelectedText, tbObs.Text, false, CocheCama, 1, 0,1);
                       
                        dlog.Salida_Ins(tbNombre.Text, D, cbAgotado.Checked, ProvDesde, ProvHasta, Operador, LocDesde, LocHasta, Socio, Invitado, InterCirculo, Menor, tbEstadia.Text, Regimen, Traslado, Tipo, Hotel, tbHotel.Text, cbDestacado.Checked, cbMoneda.SelectedText, tbObs.Text, false, CocheCama, 0, 1,1);
                        count = count + 1;
                    }

                    MessageBox.Show("Salidas Generadas con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string Concat_Fechas(string Titulo)
        {
            string Concat = Titulo;
            foreach (LISTA_FECHAS D in FECHAS)
            {
               Concat = Concat + " - "  + D.FECHAS.ToShortDateString() ;
            }

            return Concat;
        }

        private void cbProvinciaDesde_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbProvinciaDesde.SelectedItem != null)
            {
                cbLocalidadDesde.DataSource = null;
                utilsTurismo.UpdateComboLocalidad(Int32.Parse(cbProvinciaDesde.SelectedValue.ToString()), cbLocalidadDesde);
            }
        }

        private void cbProvinciaHasta_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Inicio == 0 && cbProvinciaHasta.SelectedItem != null)
            {
                cbLocalidadHasta.DataSource = null;
                utilsTurismo.UpdateComboLocalidad(Int32.Parse(cbProvinciaHasta.SelectedValue.ToString()), cbLocalidadHasta);
            }
        }

        
    }

    public class LISTA_FECHAS
    {
        public DateTime FECHAS { get; set; }
        public LISTA_FECHAS(DateTime date)
        {
            FECHAS = date; 
        }
    }
}
