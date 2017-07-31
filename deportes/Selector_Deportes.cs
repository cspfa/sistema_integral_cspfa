using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SOCIOS.deportes
{
    public partial class Selector_Deportes : Form
    {

        string NombreTabla;
        string Numero;
        string Depuracion;
        string Barra;
        string NumeroTitular;
        string DepuracionTitular;
        int IdSocio = 0;
        string DNI;
        string NOMBRE;
        string APELLIDO;
        Image imagen;
        string ROL;
        DeportesService ds = new DeportesService();
        bo_Deportes dlog = new bo_Deportes();
        Apto_Foto apto = new Apto_Foto();

        public Selector_Deportes(string var_NombreTabla, string var_Numero, string var_Depuracion, string var_Barra, string var_Numero_Titular, string var_Depuracion_Titular, int var_Id_Socio, string var_DNI, string var_Nombre, string var_Apellido,Image imagenTitular)
        {
            InitializeComponent();
            NombreTabla = var_NombreTabla;
            Numero      = var_Numero;
            Depuracion  = var_Depuracion;
            Barra = var_Barra;
            NumeroTitular = var_Numero_Titular;
            DepuracionTitular = var_Depuracion_Titular;
            IdSocio = var_Id_Socio;
            DNI = var_DNI;
            NOMBRE = var_Nombre;
            APELLIDO = var_Apellido;
            imagen = imagenTitular;
            ROL =  ds.obtenerRoles_Deportes(Numero, Depuracion,Barra).ToList().First().ROL;

            


        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // Selector_Deportes
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    this.Name = "Selector_Deportes";
        //    this.Load += new System.EventHandler(this.Selector_Deportes_Load);
        //    this.ResumeLayout(false);

        //}

        private void Selector_Deportes_Load(object sender, EventArgs e)
        {


            this.BindData();

            

            
        }

        private void BindData()
        {
            List<DeporteX_ROL> lista = new List<DeporteX_ROL>();
            lista = ds.obtenerRoles_Deportes(Numero, Depuracion, Barra).ToList();
            dgvRegistros.DataSource = lista;
            btnAgregar.Text = "Agregar Registro " + VGlobales.vp_role.Trim();

            // determinar el boton de nuevo
            var x = lista.Where(b => (b.ROL.Trim() == VGlobales.vp_role && b.FechaBaja.Length == 0)).ToList();
            if (x.Count == 0)
                btnAgregar.Visible = true;
            else
                btnAgregar.Visible = false;

            foreach (DataGridViewRow row in dgvRegistros.Rows)
            {

                if (row.Cells[2].Value.ToString().Length > 1)
                {

                    row.DefaultCellStyle.BackColor = Color.Red;

                }

            } 
        
        }

        private void verRegistro_Click(object sender, EventArgs e)
        {

            bool SoloVista;
            int ID_REGISTRO;

            if (dgvRegistros.SelectedRows.Count > 0)
            {
                if (ROL.Length > 0)
                {

                    ID_REGISTRO = Int32.Parse(dgvRegistros.SelectedRows[0].Cells[5].Value.ToString());
                    

                    admDeportes admdepo = new admDeportes(NombreTabla, Numero, Depuracion, Barra, NumeroTitular, DepuracionTitular, IdSocio, DNI, NOMBRE, APELLIDO, imagen, ROL,ID_REGISTRO,false,System.DateTime.Now);

                    admdepo.Show();
                    admdepo.Focus();
                  //DialogResult dr =  admdepo.ShowDialog();
                  //if (dr == DialogResult.No)
                  //    this.BindData();
                }
            }
            else
            {
                MessageBox.Show( "Debe seleccionar un registro ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             ROL =dgvRegistros.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void dgvRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ROL = dgvRegistros.SelectedRows[0].Cells[0].Value.ToString();
            if (dgvRegistros.SelectedRows[0].Cells[2].Value.ToString().Length > 1)
                verRegistro.Visible = false;
            else verRegistro.Visible = true;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ROL.Length > 0)
                {
                    int ID_REGISTRO = Int32.Parse(dgvRegistros.SelectedRows[0].Cells[5].Value.ToString());
                    apto = this.get_Apto_Foto(ID_REGISTRO);

                    admDeportes admdepo = new admDeportes(NombreTabla, Numero, Depuracion, Barra, NumeroTitular, DepuracionTitular, IdSocio, DNI, NOMBRE, APELLIDO, apto.Imagen, VGlobales.vp_role, 0, true, apto.FechaApto);
                    DialogResult dr = admdepo.ShowDialog();
                    if (dr == DialogResult.Yes)
                        BindData();

                    admdepo.Focus();
                }
            }
            catch (Exception ex)

            { 
            
            }
        }

        public Apto_Foto get_Apto_Foto(int RegistroID)
        {

            Byte[] byteBLOBData1 = new Byte[0];
            Apto_Foto item = new Apto_Foto();

            string Query = "SELECT  FE_APTO,FOTO FROM   DEPORTES_ADM  WHERE ID=" + RegistroID.ToString();

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(Query).Select();
            if (foundRows.Length > 0)
            {

                if (foundRows[0][0].ToString().Trim().Length > 0)
                    item.FechaApto = DateTime.Parse(foundRows[0][0].ToString().Trim());
                else
                    item.FechaApto = null;
                if (foundRows[0][1].ToString().Length != 0)
                {
                    byteBLOBData1 = (byte[])foundRows[0][1];
                    MemoryStream stmBLOBData1 = new MemoryStream(byteBLOBData1);
                   item.Imagen= Image.FromStream(stmBLOBData1);
                }

            }
            return item;
        }

      

      
    }
}
