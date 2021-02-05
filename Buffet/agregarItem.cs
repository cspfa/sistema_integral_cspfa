using System;
using System.Data;
using System.Windows.Forms;

namespace Buffet
{
    public partial class agregarItem : Form
    {
        Utils u = new Utils();
        string CODEBAR { get; set; }
        public agregarItem(string BARCODE)
        {
            InitializeComponent();
            DataSet RESERVADOS = u.getReservadosPorRole("MENU CPOCABA");

            foreach (DataRow row in RESERVADOS.Tables[0].Rows)
            {
                lbReservados.Text = row[0].ToString().Trim();
            }
                
            CODEBAR = BARCODE;
            DataSet CATEGORIAS = u.getCategoriasPorRole("MENU CPOCABA");
            cbCategoria.DataSource = CATEGORIAS.Tables[0].DefaultView;
            cbCategoria.DisplayMember = "DETALLE";
            cbCategoria.ValueMember = "ID";
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if(tbNombre.Text !="" && tbPrecio.Text != "")
            {
                Cursor = Cursors.WaitCursor;
                int ID = u.getNextItemId("MENU CPOCABA");
                u.setNewItem(ID, tbNombre.Text.Trim(), CODEBAR);
                u.updateProfEsp(ID, int.Parse(cbCategoria.SelectedValue.ToString()));
                u.setArancel(decimal.Parse(tbPrecio.Text), ID, int.Parse(cbCategoria.SelectedValue.ToString()));
                Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void AgregarItem_Load(object sender, EventArgs e)
        {

        }
    }
}
