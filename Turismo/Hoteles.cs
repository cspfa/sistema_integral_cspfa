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

namespace SOCIOS.turismos
{
    public partial class Hoteles : Form
    {
        bo dlog = new bo();
        public string MODO = "";
        int ID;
        int Inicio = 1;
        public Hoteles()
        {
            InitializeComponent();
            this.Iniciar();
        }

        private void Iniciar()

        {

            this.IniciarCombos();
            this.UpdateGrilla("");
        
        }


        private void IniciarCombos()

        {   //Filtro
            cbFiltro.Items.Insert(0, "POR NOMBRE");
            cbFiltro.Items.Insert(1, "POR PROVINCIA");
            cbFiltro.Items.Insert(2, "POR LOCALIDAD");
            cbFiltro.SelectedIndex = 0;
            cbFiltro.Refresh();

            //Estrellas
            cbEstrellas.Items.Insert(0, "1");
            cbEstrellas.Items.Insert(1, "2");
            cbEstrellas.Items.Insert(2, "3");
            cbEstrellas.Items.Insert(3, "4");
            cbEstrellas.Items.Insert(4, "5");
            cbEstrellas.SelectedValue = "0";
            cbEstrellas.SelectedIndex = 0;
            cbEstrellas.Refresh();
            //Provincia
            this.UpdateComboProvincia(0);
            //Localidad
            this.UpdateComboLocalidad(6500);


        }

        private void UpdateComboProvincia(int Provincia)
        {
            string query ;

            if (Provincia == 0)
                query = "SELECT PROVINCIAID ID, TRIM(NOMBRE) DETALLE FROM PROVINCIA ORDER BY DETALLE";
            else
                query = "SELECT PROVINCIAID ID, TRIM(NOMBRE) DETALLE FROM PROVINCIA WHERE PROVINCIAID=" + Provincia.ToString() + " ORDER BY DETALLE";

            cbProvincia.DataSource = null;
            cbProvincia.Items.Clear();
            cbProvincia.DataSource = dlog.BO_EjecutoDataTable(query);
            cbProvincia.DisplayMember = "DETALLE";
            cbProvincia.ValueMember = "ID";
            cbProvincia.SelectedItem = 1; 
        
        }

        private void UpdateComboLocalidad(int Provincia)

        {   string query = "SELECT LOCALIDADID ID, TRIM(DESCRIPCION) DETALLE FROM LOCALIDAD WHERE PROVINCIAID=" + Provincia.ToString() + " ORDER BY DETALLE";

            
            cbLocalidad.DataSource = null;
            cbLocalidad.Items.Clear();
            cbLocalidad.DataSource = dlog.BO_EjecutoDataTable(query);
            cbLocalidad.DisplayMember = "DETALLE";
            cbLocalidad.ValueMember = "ID";
            cbLocalidad.SelectedItem = 1;
        
        }

        public void UpdateGrilla(string pFiltro)
        {
            string Query = @"select H.ID ID ,
                                    H.NOMBRE NOMBRE,
                                    P.NOMBRE PROVINCIA,
                                    P.PROVINCIAID PROVINCIAID,
                                    L.LOCALIDADID LOCALIDADID,
                                    L.DESCRIPCION LOCALIDAD,
                                    H.TELEFONO TELEFONO ,
                                    H.DOMICILIO DOMICILIO,
                                    H.ESTRELLAS ESTRELLAS ,
                                    H.CUIT CUIT,
                                    H.RESPONSABLE   RESPONSABLE,
                                    H.OBSERVACIONES OBSERVACIONES,
                                    H.EMAIL_OPERACION EMAIL_OPERACION,
                                    H.EMAIL_RESERVAS  EMAIL_RESERVAS,
                                    H.EMAIL_ADM       EMAIL_ADM,
                                    H.EMAIL_INFO       EMAIL_INFO,
                                    H.CHECKIN         CHECKIN,
                                    H.CHECKOUT        CHECKOUT,
                                    H.PROPIO          PROPIO,
                                    H.SOCIAL          SOCIAL         ";


            Query = Query + @" from HOTEL H, LOCALIDAD L, PROVINCIA P
                              WHERE P.PROVINCIAID=H.PROVINCIAID 
                              AND   L.LOCALIDADID = H.LOCALIDADID 
                              AND  coalesce(H.F_BAJA,'1') = '1' ";
            
            if (pFiltro.Length != 0)
            {
                Query = Query + this.FiltroSQL(pFiltro, tbFiltro.Text);
            }

      
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

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    FbTransaction transaction = connection.BeginTransaction();

                    DataTable dt1 = new DataTable("RESULTADOS");

                    dt1.Columns.Add("ID", typeof(string));
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("PROVINCIA", typeof(string));
                    dt1.Columns.Add("PROVINCIAID", typeof(int));
                    dt1.Columns.Add("LOCALIDADID", typeof(int));
                    dt1.Columns.Add("LOCALIDAD", typeof(string));
                    dt1.Columns.Add("TELEFONO", typeof(string));
                    dt1.Columns.Add("DOMICILIO", typeof(string));
                    dt1.Columns.Add("ESTRELLAS", typeof(string));
                    dt1.Columns.Add("CUIT", typeof(string));
                    dt1.Columns.Add("RESPONSABLE", typeof(string));
                    dt1.Columns.Add("OBSERVACIONES", typeof(string));
                    dt1.Columns.Add("EMAIL_OPERACION", typeof(string));
                    dt1.Columns.Add("EMAIL_RESERVAS", typeof(string));
                    dt1.Columns.Add("EMAIL_ADM", typeof(string));
                    dt1.Columns.Add("EMAIL_INFO", typeof(string));
                    dt1.Columns.Add("CHECKIN", typeof(string));
                    dt1.Columns.Add("CHECKOUT", typeof(string));
                    dt1.Columns.Add("PROPIO", typeof(string));
                    dt1.Columns.Add("SOCIAL", typeof(string));
                    ds1.Tables.Add(dt1);


                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("PROVINCIA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("PROVINCIAID")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("LOCALIDADID")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("LOCALIDAD")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TELEFONO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("DOMICILIO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("ESTRELLAS")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("CUIT")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("RESPONSABLE")).Trim(),
                                      reader3.GetString(reader3.GetOrdinal("OBSERVACIONES")).Trim(),
                                       reader3.GetString(reader3.GetOrdinal("EMAIL_OPERACION")).Trim(),
                                        reader3.GetString(reader3.GetOrdinal("EMAIL_RESERVAS")).Trim(),
                                         reader3.GetString(reader3.GetOrdinal("EMAIL_ADM")).Trim(),
                                          reader3.GetString(reader3.GetOrdinal("EMAIL_INFO")).Trim(),
                                           reader3.GetString(reader3.GetOrdinal("CHECKIN")).Trim(),
                                            reader3.GetString(reader3.GetOrdinal("CHECKOUT")).Trim(),
                                            reader3.GetString(reader3.GetOrdinal("PROPIO")).Trim(),
                                             reader3.GetString(reader3.GetOrdinal("SOCIAL")).Trim());
                    }

                    reader3.Close();

                 
                       dgvHotel.DataSource = dt1;
                       dgvHotel.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                       dgvHotel.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                       dgvHotel.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                       dgvHotel.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                       dgvHotel.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                       dgvHotel.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                       dgvHotel.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                       dgvHotel.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                       dgvHotel.Columns[3].Visible      = false;
                       dgvHotel.Columns[4].Visible      = false;
                       dgvHotel.Columns[9].Visible      = false;
                       dgvHotel.Columns[11].Visible = false;
                       dgvHotel.Columns[12].Visible = false;
                       dgvHotel.Columns[13].Visible = false;
                       dgvHotel.Columns[14].Visible = false;
                       dgvHotel.Columns[15].Visible = false;
                       dgvHotel.Columns[16].Visible = false;
                       dgvHotel.Columns[17].Visible = false;
                       dgvHotel.Columns[18].Visible = false;
                           dgvHotel.Columns[19].Visible = false;
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        
        }

        private string FiltroSQL(string pFiltro,string pTexto)
        {
            if (pFiltro.Length< 2)
                return "";

            if (pFiltro.Contains("NOMBRE"))
               return " AND H.NOMBRE LIKE '%"+ pTexto +"%'";
            else  if (pFiltro.Contains("PROVINCIA"))
                return " AND UPPER(P.NOMBRE) LIKE '%" + pTexto + "%'";
            else
                return " AND UPPER(L.DESCRIPCION) LIKE '%" + pTexto + "%'";
            
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.UpdateGrilla(cbFiltro.SelectedItem.ToString());
        }

        private void cbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Inicio == 0 && cbProvincia.SelectedItem != null)
               this.UpdateComboLocalidad(Int32.Parse(cbProvincia.SelectedValue.ToString()));
        }

        private void BlanquearControles()
        {
            tbCuit.Text      = "";
            tbDomicilio.Text = "";
            tbNombre.Text = "";
            tbObservaciones.Text = "";
            tbResponsable.Text = "";
            tbTelefono.Text = "";
            this.UpdateComboProvincia(0);
            this.UpdateComboLocalidad(6500);
            cbEstrellas.SelectedIndex = 0;
            cbEstrellas.Refresh();
            cbPropio.Checked = false;
            tbCheckIn.Text = "";
            tbCheckOut.Text = "";
            tbMailAdm.Text = "";
            tbMailInfo.Text = "";
            tbMailOperacion.Text = "";
            tbMailReservas.Text = "";
            tbLateCheckOut.Text = "0";
            gpHotel.Visible = false;
        }

        private void NuevoBank_Click(object sender, EventArgs e)
        {
            MODO = "INS";
            Inicio = 0;
           
            this.BlanquearControles();
            gpHotel.Visible = true;
        }
         
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Confirma Cambios?", "Confirmar Datos Hotel", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int Propio = Convert.ToInt32( cbPropio.Checked);
                    int Social = Convert.ToInt32(cbSocial.Checked);

                    if (MODO == "INS")
                    {
                        dlog.InsertHotel(tbNombre.Text, Int32.Parse(cbProvincia.SelectedValue.ToString()), Int32.Parse(cbLocalidad.SelectedValue.ToString()), tbDomicilio.Text, tbTelefono.Text, Int32.Parse(cbEstrellas.SelectedItem.ToString()), tbObservaciones.Text, tbCuit.Text, tbResponsable.Text,tbMailOperacion.Text,tbMailReservas.Text,tbMailAdm.Text,tbMailInfo.Text,tbCheckIn.Text,tbCheckOut.Text, System.DateTime.Now, VGlobales.vp_username,Propio,Social,Decimal.Parse(tbLateCheckOut.Text));
                        dlog.nuevoProfesional("EMPLEADOS CSPFA", "0", 0, "@", 0, 0, 1, "HOTELES", "R", 0);
                        maxid mid = new maxid();
                        int PROFESIONAL = int.Parse(mid.m("ID", "PROFESIONALES"));
                        int ESPECIALIDAD = int.Parse(mid.m("ID", "SECTACT"));
                        dlog.nuevoProfEsp(PROFESIONAL, ESPECIALIDAD);
                        this.UpdateGrilla("");
                        MessageBox.Show("HOTEL REGISTRADO CON EXITO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BlanquearControles();
                    }
                    else
                    {
                        dlog.UpdateHotel(ID, tbNombre.Text, Int32.Parse(cbProvincia.SelectedValue.ToString()), Int32.Parse(cbLocalidad.SelectedValue.ToString()), tbDomicilio.Text, tbTelefono.Text, Int32.Parse(cbEstrellas.SelectedItem.ToString()), tbObservaciones.Text, tbCuit.Text, tbResponsable.Text, tbMailOperacion.Text, tbMailReservas.Text, tbMailAdm.Text, tbMailInfo.Text, tbCheckIn.Text, tbCheckOut.Text, System.DateTime.Now, VGlobales.vp_username, Propio, Social, Decimal.Parse(tbLateCheckOut.Text));
                        this.UpdateGrilla("");
                        MessageBox.Show("HOTEL MODIFICADO CON EXITO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BlanquearControles();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIO UN ERROR\n"+ex, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Inicio = 0;
            MODO = "UPD";
            if (dgvHotel.SelectedRows.Count < 1)
            {
                MessageBox.Show("DEBE SELECCIONAR UN REGISTRO\n", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                gpHotel.Visible = true;
                ID = Int32.Parse(dgvHotel.SelectedRows[0].Cells[0].Value.ToString());
           
                
                this.LlenoDatos(dgvHotel.SelectedRows[0].Cells[1].Value.ToString(),
                    Int32.Parse(dgvHotel.SelectedRows[0].Cells[3].Value.ToString()),
                    Int32.Parse(dgvHotel.SelectedRows[0].Cells[4].Value.ToString()),
                    dgvHotel.SelectedRows[0].Cells[7].Value.ToString(),
                    dgvHotel.SelectedRows[0].Cells[6].Value.ToString(),
                    dgvHotel.SelectedRows[0].Cells[8].Value.ToString(),
                    dgvHotel.SelectedRows[0].Cells[9].Value.ToString(),
                    dgvHotel.SelectedRows[0].Cells[10].Value.ToString(),
                    dgvHotel.SelectedRows[0].Cells[11].Value.ToString(),
                    dgvHotel.SelectedRows[0].Cells[12].Value.ToString(),
                    dgvHotel.SelectedRows[0].Cells[13].Value.ToString(),
                    dgvHotel.SelectedRows[0].Cells[14].Value.ToString(),
                    dgvHotel.SelectedRows[0].Cells[15].Value.ToString(),
                    dgvHotel.SelectedRows[0].Cells[16].Value.ToString(),
                    dgvHotel.SelectedRows[0].Cells[17].Value.ToString(), 
                    Int32.Parse(dgvHotel.SelectedRows[0].Cells[18].Value.ToString()),
                    Int32.Parse(dgvHotel.SelectedRows[0].Cells[19].Value.ToString()));
            }
        }

        private void LlenoDatos(string Nombre, int Provincia,int Localidad,string Domicilio,string Telefono,string Estrellas,string Cuit,string Responsable,string OBS,string Email_operacion,string Email_reservas,string Email_Adm, string Email_info,string CheckIn,string CheckOut,int Propio,int Social)
        {

            
            tbNombre.Text = Nombre.Trim();
            cbProvincia.SelectedValue = Provincia;
            this.UpdateComboLocalidad(Int32.Parse(cbProvincia.SelectedValue.ToString()));
            cbLocalidad.SelectedValue = Localidad;

            tbDomicilio.Text = Domicilio;
            tbTelefono.Text = Telefono;
            cbEstrellas.SelectedItem = Estrellas;
           
            tbCuit.Text = Cuit;
            tbResponsable.Text = Responsable;
            tbObservaciones.Text = OBS;
            tbMailOperacion.Text = Email_operacion;
            tbMailReservas.Text = Email_reservas;
            tbMailInfo.Text = Email_info;
            tbMailAdm.Text = Email_Adm;
            tbCheckOut.Text = CheckOut;
            tbCheckIn.Text = CheckIn;

            if (Propio == 1)
                cbPropio.Checked = true;
            else
                cbPropio.Checked = false;

            if (Social == 1)
                cbSocial.Checked = true;
            else
                cbSocial.Checked = false;


        
        }

        private void CancelarBank_Click(object sender, EventArgs e)
        {
            if (dgvHotel.SelectedRows.Count < 1)
            {
                MessageBox.Show("DEBE SELECCIONAR UN REGISTRO\n", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ID = Int32.Parse(dgvHotel.SelectedRows[0].Cells[0].Value.ToString());
                if (MessageBox.Show("¿Confirma Dar de Baja Hotel?", "Confirmar Baja Hotel", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dlog.DeleteHotel(ID);
                    MessageBox.Show("HOTEL BORRADO CON EXITO\n", "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.UpdateGrilla("");
                    gpHotel.Visible = false;
                    this.BlanquearControles();
                }
            }

        }

        private void dgvHotel_Click(object sender, EventArgs e)
        {
            if (dgvHotel.SelectedRows[0].Cells[0].Value.ToString() != "")
            {
                ID = Int32.Parse(dgvHotel.SelectedRows[0].Cells[0].Value.ToString());
                gpHotel.Visible = true;
                this.LlenoDatos(dgvHotel.SelectedRows[0].Cells[1].Value.ToString(),
                Int32.Parse(dgvHotel.SelectedRows[0].Cells[3].Value.ToString()),
                Int32.Parse(dgvHotel.SelectedRows[0].Cells[4].Value.ToString()),
                dgvHotel.SelectedRows[0].Cells[6].Value.ToString(),
                dgvHotel.SelectedRows[0].Cells[7].Value.ToString(),
                dgvHotel.SelectedRows[0].Cells[8].Value.ToString(),
                dgvHotel.SelectedRows[0].Cells[9].Value.ToString(),
                dgvHotel.SelectedRows[0].Cells[10].Value.ToString(),
                dgvHotel.SelectedRows[0].Cells[11].Value.ToString(),
                dgvHotel.SelectedRows[0].Cells[12].Value.ToString(),
                dgvHotel.SelectedRows[0].Cells[13].Value.ToString(),
                dgvHotel.SelectedRows[0].Cells[14].Value.ToString(),
                dgvHotel.SelectedRows[0].Cells[15].Value.ToString(),
                dgvHotel.SelectedRows[0].Cells[16].Value.ToString(),
                dgvHotel.SelectedRows[0].Cells[17].Value.ToString(),
                Int32.Parse(dgvHotel.SelectedRows[0].Cells[18].Value.ToString()),
                 Int32.Parse(dgvHotel.SelectedRows[0].Cells[19].Value.ToString()));
            }
        }

        private void cbProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Inicio == 0 && cbProvincia.SelectedItem != null)
                this.UpdateComboLocalidad(Int32.Parse(cbProvincia.SelectedValue.ToString()));
        }

        private void dgvHotel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MODO = "UPD";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Turismo.AgregarLocalidad al = new Turismo.AgregarLocalidad(Int32.Parse(cbProvincia.SelectedValue.ToString()));
            al.ShowDialog();
            this.UpdateComboLocalidad(Int32.Parse(cbProvincia.SelectedValue.ToString()));
        }

        private void Hoteles_Load(object sender, EventArgs e)
        {

        }
    }
}
