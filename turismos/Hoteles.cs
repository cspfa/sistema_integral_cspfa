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
        public Hoteles()
        {
            InitializeComponent();
            this.Iniciar();
        }

        private void Iniciar()

        {

            this.IniciarCombos();
            this.UpdateGrilla(0);
        
        }


        private void IniciarCombos()

        {   //Filtro
            cbFiltro.Items.Insert(0, "POR NOMBRE");
            cbFiltro.Items.Insert(1, "POR PROVINCIA");
            cbFiltro.Items.Insert(2, "POR LOCALIDAD");
            cbFiltro.SelectedValue = 0;
            cbFiltro.Refresh();

            //Estrellas
            cbEstrellas.Items.Insert(0, "1");
            cbEstrellas.Items.Insert(1, "2");
            cbEstrellas.Items.Insert(2, "3");
            cbEstrellas.Items.Insert(3, "4");
            cbEstrellas.Items.Insert(4, "5");
            cbEstrellas.SelectedValue = "1";
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
                query = "SELECT PROVINCIAID ID, NOMBRE DETALLE FROM PROVINCIA";
            else
                query = "SELECT PROVINCIAID ID, NOMBRE DETALLE FROM PROVINCIA WHERE PROVINCIAID=" + Provincia.ToString();

            cbProvincia.DataSource = null;
            cbProvincia.Items.Clear();
            cbProvincia.DataSource = dlog.BO_EjecutoDataTable(query);
            cbProvincia.DisplayMember = "DETALLE";
            cbProvincia.ValueMember = "ID";
            cbProvincia.SelectedItem = 1; 
        
        }

        private void UpdateComboLocalidad(int Provincia)

        {   string query = "SELECT LOCALIDADID ID, DESCRIPCION DETALLE FROM LOCALIDAD WHERE PROVINCIAID=" + Provincia.ToString();

            
            cbLocalidad.DataSource = null;
            cbLocalidad.Items.Clear();
            cbLocalidad.DataSource = dlog.BO_EjecutoDataTable(query);
            cbLocalidad.DisplayMember = "DETALLE";
            cbLocalidad.ValueMember = "ID";
            cbLocalidad.SelectedItem = 1;
        
        }

        public void UpdateGrilla(int pFiltro)

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
                                    H.RESPONSABLE RESPONSABLE  ";
                           

            if (pFiltro != 0)
            {
            Query = Query + this.FiltroSQL(pFiltro,tbFiltro.Text);
            }

            Query =Query + @" from HOTEL H, LOCALIDAD L, PROVINCIA P
                              WHERE P.PROVINCIAID=H.PROVINCIAID 
                              AND   L.LOCALIDADID = H.LOCALIDADID  ";
            string connectionString;

            DataSet ds1 = new DataSet();

            Datos_ini ini3 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini3.Servidor;
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
                                     reader3.GetString(reader3.GetOrdinal("RESPONSABLE")).Trim());
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
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        
        }

        private string FiltroSQL(int pFiltro,string pTexto)

        {
            if (pFiltro ==1)
               return " WHERE H.NOMBRE LIKE '%"+ pTexto +"%'";
            else  if (pFiltro==2)
                return " WHERE P.NOMBRE LIKE '%" + pTexto + "%'";
            else
                return " WHERE L.DESCRIPCION LIKE '%" + pTexto + "%'";
            
        }

        private void dgvHotel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Hoteles_Load(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            
        }

        private void cbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (cbProvincia.SelectedText.Length >0)
               this.UpdateComboLocalidad(Int32.Parse(cbProvincia.SelectedItem.ToString()));
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
            cbEstrellas.SelectedValue = 1;
            cbEstrellas.Refresh();




        
        }
        private void NuevoBank_Click(object sender, EventArgs e)
        {
            MODO = "INS";
            gpHotel.Visible = true;
            this.BlanquearControles();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Confirma Cambios?", "Confirmar Datos Hotel", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                  
                    if (MODO == "INS")
                    {
                        dlog.InsertHotel(tbNombre.Text, Int32.Parse(cbProvincia.SelectedValue.ToString()), Int32.Parse(cbLocalidad.SelectedValue.ToString()), tbDomicilio.Text, tbTelefono.Text, Int32.Parse(cbEstrellas.SelectedItem.ToString()), tbObservaciones.Text, tbCuit.Text, tbResponsable.Text, System.DateTime.Now, VGlobales.vp_username);
                        this.UpdateGrilla(0);
                        MessageBox.Show("HOTEL REGISTRADO CON EXITO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dlog.UpdateHotel(ID, tbNombre.Text, Int32.Parse(cbProvincia.SelectedValue.ToString()), Int32.Parse(cbLocalidad.SelectedValue.ToString()), tbDomicilio.Text, tbTelefono.Text, Int32.Parse(cbEstrellas.SelectedItem.ToString()), tbObservaciones.Text, tbCuit.Text, tbResponsable.Text, System.DateTime.Now, VGlobales.vp_username);
                        this.UpdateGrilla(0);
                        MessageBox.Show("HOTEL MODIFICADO CON EXITO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            { 
            
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvHotel.SelectedRows.Count < 1)
            {
                MessageBox.Show("DEBE SELECCIONAR UN REGISTRO\n", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                gpHotel.Visible = true;
                ID = Int32.Parse(dgvHotel.SelectedRows[0].Cells[0].Value.ToString());
               
                
                this.LlenoDatos(dgvHotel.SelectedRows[0].Cells[1].Value.ToString(), Int32.Parse( dgvHotel.SelectedRows[0].Cells[3].Value.ToString()),Int32.Parse(dgvHotel.SelectedRows[0].Cells[4].Value.ToString()), dgvHotel.SelectedRows[0].Cells[6].Value.ToString(), dgvHotel.SelectedRows[0].Cells[7].Value.ToString(), dgvHotel.SelectedRows[0].Cells[2].Value.ToString(), dgvHotel.SelectedRows[0].Cells[8].Value.ToString(), dgvHotel.SelectedRows[0].Cells[9].Value.ToString(), dgvHotel.SelectedRows[0].Cells[10].Value.ToString());
            }
        }

        private void LlenoDatos(string Nombre, int Provincia,int Localidad,string Domicilio,string Telefono,string Estrellas,string Cuit,string Responsable,string OBS)
        {
            tbNombre.Text = Nombre;
            cbProvincia.SelectedValue = Provincia;

            tbDomicilio.Text = Domicilio;
            tbTelefono.Text = Telefono;
            cbEstrellas.SelectedValue = Estrellas;
           
            tbCuit.Text = Cuit;
            tbResponsable.Text = Responsable;
            tbObservaciones.Text = OBS;
        
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
                }
            }

        }






    }
}
