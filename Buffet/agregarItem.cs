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
            CODEBAR = BARCODE;
            DataSet CATEGORIAS = u.getCategoriasPorRole("MENU CPOCABA");
            cbCategoria.DataSource = CATEGORIAS.Tables[0].DefaultView;
            cbCategoria.DisplayMember = "DETALLE";
            cbCategoria.ValueMember = "ID";
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if(tbNombre.Text !="" && tbPrecio.Text != "")
            {
                int ID = u.putNuevoItem(tbNombre.Text.Trim(), CODEBAR);
                bool PROF_ESP = u.setProfEsp(ID, int.Parse(cbCategoria.SelectedValue.ToString()));
                bool ARANCEL = u.setItemPrice(ID, tbPrecio.Text.Trim(), int.Parse(cbCategoria.SelectedValue.ToString()));

                if(ARANCEL)
                {
                    Cursor = Cursors.Default;
                    this.Close();
                }
            }
        }
    }
}
