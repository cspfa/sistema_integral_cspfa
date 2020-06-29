using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;

namespace SOCIOS.Turismo
{
    public partial class Salidas : Form
    {
        bo_Turismo dlog = new bo_Turismo();
        SOCIOS.Turismo.TurismoUtils utilsTurismo = new TurismoUtils();

        int Inicio;
        string Nombre;
        int ID;
        string Modo;
        Turismo.Salida salida;

        public Salidas()
        {
            Inicio = 1;
            InitializeComponent();
            this.InicializarCombos();
            this.UpdateGrilla();

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int ProvDesde = Int32.Parse(cbProvinciaDesde.SelectedValue.ToString());
                int ProvHasta = Int32.Parse(cbProvinciaHasta.SelectedValue.ToString());
                if (cbLocalidadDesde.Text.Trim().Count() == 0)
                    throw new Exception("Ingrese Localidad Desde");
                if (cbLocalidadHasta.Text.Trim().Count() == 0)
                    throw new Exception("Ingrese Localidad Hasta");

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
                int Web = 1;
                int Bono = 1;



                utilsTurismo.checkDestinosRepetidos(LocDesde, LocHasta);

                if (Socio == 0)
                    throw new Exception("El Valor Socio No Puede ser 0");
                if (Invitado == 0)
                    throw new Exception("El Valor Invitado No Puede ser 0");
                if (InterCirculo == 0)
                    throw new Exception("El Valor Intercirculo No Puede ser 0");
                if (Menor == 0)
                    throw new Exception("El Valor Menor No Puede ser 0");

                if (cbWeb.Checked)
                    Web = 1;
                else
                    Web = 0;
                if (cbBono.Checked)
                    Bono = 1;
                else
                    Bono = 0;
                if (Modo == "INS")
                    dlog.Salida_Ins(tbNombre.Text, dtSalida.Value, cbAgotado.Checked, ProvDesde, ProvHasta, Operador, LocDesde, LocHasta, Socio, Invitado, InterCirculo, Menor, tbEstadia.Text, Regimen, Traslado, Tipo, Hotel, tbHotel.Text, cbDestacado.Checked, cbMoneda.SelectedText, tbObs.Text, cbDiaria.Checked, CocheCama, Web, Bono);
                else
                    dlog.Salida_Upd(ID, tbNombre.Text, dtSalida.Value, cbAgotado.Checked, ProvDesde, ProvHasta, Operador, LocDesde, LocHasta, Socio, Invitado, InterCirculo, Menor, tbEstadia.Text, Regimen, Traslado, Tipo, Hotel, tbHotel.Text, cbDestacado.Checked, cbMoneda.SelectedText, tbObs.Text, cbDiaria.Checked, CocheCama, Web, Bono);


                this.UpdateGrilla();
                MessageBox.Show("Datos Guardados con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerDatos(int ID)
        {
            Turismo.Salida salida = utilsTurismo.GetSalida(ID);
            tbNombre.Text = salida.Nombre;
            cbTipo.SelectedValue = salida.Tipo;
            cbTraslado.SelectedValue = salida.Traslado;
            tbEstadia.Text = salida.Estadia;
            cbRegimen.SelectedValue = salida.Regimen;
            tbHotel.Text = salida.Hotel_Nombre;
            cbMoneda.SelectedText = salida.Moneda;
            tbPrecioSocio.Text = salida.Socio.ToString("0.##");
            tbPrecioInvitado.Text = salida.Invitado.ToString("0.##");
            tbPrecioInterCirculo.Text = salida.InterCirculo.ToString("0.##");
            cbOperador.SelectedValue = salida.Operador.ToString();
            tbObs.Text = salida.Observaciones;
            cbProvinciaDesde.SelectedValue = salida.Prov_Desde.ToString();
            cbProvinciaHasta.SelectedValue = salida.Prov_Hasta.ToString();
            cbLocalidadDesde.DataSource = null;
            cbLocalidadHasta.DataSource = null;
            utilsTurismo.UpdateComboLocalidad(Int32.Parse(salida.Prov_Desde.ToString()), cbLocalidadDesde);
            utilsTurismo.UpdateComboLocalidad(Int32.Parse(salida.Prov_Hasta.ToString()), cbLocalidadHasta);
            cbLocalidadDesde.SelectedValue = salida.Loc_Desde.ToString();
            cbLocalidadHasta.SelectedValue = salida.Loc_Hasta.ToString();
            cbAgotado.Checked = Convert.ToBoolean(salida.Agotado);
            cbDestacado.Checked = Convert.ToBoolean(salida.Destacado);
            dtSalida.Value = salida.Fecha;
            tbCocheCama.Text = salida.Coche_Cama.ToString();
            if (salida.Diaria == 1)
            {
                cbDiaria.Checked = true;
                this.Seteo_diaria(true);
            }
            else
            {
                cbDiaria.Checked = false;
                this.Seteo_diaria(false);
            }

            tbMenor.Text = salida.Menor.ToString("0.##");
            cbWeb.Checked = salida.Web;
            cbBono.Checked = salida.Bono;






        }

        private void UpdateGrilla()
        {

            this.Blanquear_Campos();
            gpDatos.Visible = false;

            string Query = @"select  S.ID ID,S.Nombre NOMBRE,replace(cast(cast(S.FECHA as date) as varchar(10)), '-', '') FECHA  ,LO.DESCRIPCION ORIGEN, L.DESCRIPCION DESTINO, S.SOCIO SOCIO, S.INVITADO INVITADO,S.INTERCIRCULO INTERCIRCULO,O.RAZON_SOCIAL OPERADOR, S.MOSTRAR_BONO BONO, S.MOSTRAR_WEB WEB
                             from TURISMO_SALIDA  S , Localidad L,  PROVEEDORES O  ,Localidad LO
                             WHERE S.LOC_HASTA =L.LOCALIDADID AND S.LOC_DESDE = LO.LOCALIDADID AND  S.OPERADOR = O.ID AND  coalesce(S.F_BAJA,'1')='1'   ";

            string connectionString;

            DataSet ds1 = new DataSet();

            Datos_ini ini3 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini3.Servidor; //cs.Port = int.Parse(ini3.Puerto);
                cs.Database = ini3.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();
                string BONO = "NO";
                string WEB = "NO";

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    FbTransaction transaction = connection.BeginTransaction();

                    DataTable dt1 = new DataTable("RESULTADOS");

                    dt1.Columns.Add("BONO", typeof(string));
                    dt1.Columns.Add("WEB", typeof(string));
                    dt1.Columns.Add("ID", typeof(string));
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("FECHA", typeof(string));
                    dt1.Columns.Add("ORIGEN", typeof(string));
                    dt1.Columns.Add("DESTINO", typeof(string));
                    dt1.Columns.Add("SOCIO", typeof(float));
                    dt1.Columns.Add("INVITADO", typeof(float));
                    dt1.Columns.Add("INTERCIRCULO", typeof(float));
                    dt1.Columns.Add("OPERADOR", typeof(string));

                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();
                    //if (reader3.GetString(reader3.GetOrdinal("ID")).Trim() == "688")
                    //{ 
                    //}
                    while (reader3.Read())
                    {
                        if (reader3.GetString(reader3.GetOrdinal("BONO")).Trim() == "1")
                            BONO = "SI";
                        else
                            BONO = "NO";
                        if (reader3.GetString(reader3.GetOrdinal("WEB")).Trim() == "1")
                            WEB = "SI";
                        else
                            WEB = "NO";

                        dt1.Rows.Add(BONO,
                                      WEB,
                                     reader3.GetString(reader3.GetOrdinal("ID")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("FECHA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("ORIGEN")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("DESTINO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("SOCIO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("INVITADO")).Trim(),
                                      reader3.GetString(reader3.GetOrdinal("INTERCIRCULO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("OPERADOR")).Trim());
                    }

                    reader3.Close();


                    dgvSalidas.DataSource = dt1;
                    dgvSalidas.Columns[2].Visible = false;
                    dgvSalidas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvSalidas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvSalidas.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvSalidas.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvSalidas.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvSalidas.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvSalidas.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvSalidas.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }



        private void dgvSalidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Int32.Parse(dgvSalidas.SelectedRows[0].Cells[2].Value.ToString());

            this.ObtenerDatos(ID);
            gpDatos.Visible = true;
            Modo = "UPD";
        }

        private void CancelarBank_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Confirma Dar de Baja la Salida?", "Confirmar Baja Salida", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    try
                    {
                        ID = Int32.Parse(dgvSalidas.SelectedRows[0].Cells[2].Value.ToString());
                    }
                    catch
                    {

                        throw new Exception("Debe Seleccionar el Registro");
                    }

                    dlog.Salida_Baja(ID);
                    this.UpdateGrilla();
                    MessageBox.Show("Datos Guardados con Exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.ObtenerDatos(ID);
            gpDatos.Visible = true;
            Modo = "UPD";
        }

        private void cbRegimen_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            this.Seteo_diaria(cbDiaria.Checked);

        }


        private void Seteo_diaria(bool Diaria)
        {
            dtSalida.Visible = !Diaria;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            //{
            //    bool Bono = false;
            //    bool Web = false;
            //    try
            //    {

            //        ID = Int32.Parse(dgvSalidas.SelectedRows[0].Cells[2].Value.ToString());
            //        if (dgvSalidas.SelectedRows[0].Cells[0].Value.ToString() == "SI")
            //            Bono = true;
            //        if (dgvSalidas.SelectedRows[0].Cells[1].Value.ToString() == "SI")
            //            Web = true;

            //        string Titulo = dgvSalidas.SelectedRows[0].Cells[2].Value.ToString();
            //        Cambiar_Vistas_Salidas cvs = new Cambiar_Vistas_Salidas(ID, Bono, Web, Titulo);
            //        DialogResult res = cvs.ShowDialog();
            //        if (res == DialogResult.OK)
            //        {

            //            MessageBox.Show("DATOS ACTUALIZADOS CON EXITO");
            //            this.UpdateGrilla();
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }
            //}


        }
    }
}

