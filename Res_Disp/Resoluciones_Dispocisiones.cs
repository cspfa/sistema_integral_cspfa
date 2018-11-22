using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Res_Disp
{
    public partial class Resoluciones_Dispocisiones : Form
    {
        SOCIOS.Res_Disp.Servicios service_RD = new Servicios();
        int ID = 0;
        public Resoluciones_Dispocisiones()
        {
            InitializeComponent();
            this.UpdateComboCriterio();
            this.UpdateComboTipo();

        }

        private void dgResu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dgResu.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume

                if (Myrow.Cells[2].Value != "VER")
                {
                    int valor = Convert.ToInt32(Myrow.Cells[2].Value);

                    if (valor == (int)Tipo_Resolucion.RESOLUCION)// Or your condition 
                    {
                        Myrow.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (valor == (int)Tipo_Resolucion.RESOLUCION_PRESIDENCIAL)
                    {
                        Myrow.DefaultCellStyle.ForeColor = Color.Brown;
                    }
                    else if (valor == (int)Tipo_Resolucion.DISPOCISION)
                    {
                        Myrow.DefaultCellStyle.ForeColor = Color.LightBlue;
                    }
                    else
                    {
                        Myrow.DefaultCellStyle.ForeColor = Color.IndianRed;
                    }
                }
            }
        }

        public void UpdateComboTipo()
        {

            service_RD.Setear_Combo_Tipo(comboTipo,true);

           

        }

        private void UpdateComboCriterio()
        {
            ComboCriterio.DataSource = null;

            ComboCriterio.Items.Clear();

            ComboCriterio.Items.Insert(0, "DESCRIPCION");
            ComboCriterio.Items.Insert(1, "AÑO");
            ComboCriterio.Items.Insert(2, "NUMERO");
            ComboCriterio.SelectedValue = "1";
        }

        private void Crear_Boton()
        {
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "";
            bcol.Text = "VER";
            bcol.Name = "btnVer";
            bcol.UseColumnTextForButtonValue = true;
            dgResu.Columns.Add(bcol);
        
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            this.Filtrar();
        }

        private void Filtrar()
        {
            int Anio = 0;

            int Numero = 0;
            string DES = "";
            int Tipo = 0;

            if (tbTexto.Text.Length == 0)
                return;
            if (ComboCriterio.Text.Contains("DES"))
            {
                DES = tbTexto.Text.TrimEnd().TrimStart();
            }
            else if (ComboCriterio.Text.Contains("AÑO"))
                Anio = Int32.Parse(tbTexto.Text.TrimEnd().TrimStart());
            else
            {
                Numero = Int32.Parse(tbTexto.Text.TrimEnd().TrimStart());
            }

            Tipo = service_RD.Obtener_Valor_Tipo(comboTipo);


            dgResu.DataSource = service_RD.getDataResDisp(Tipo, Anio, Numero, DES);
            dgResu.Refresh();

            this.Crear_Boton();
        
        }

        private void dgResu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            ID = Int32.Parse(dgResu.SelectedRows[0].Cells[4].Value.ToString());
            string path = "";
            if (ID != 0)
            {

            }

            if (e.ColumnIndex == 7)
            {
                path = service_RD.get_path(ID);
                System.Diagnostics.Process.Start(path);
          
            }

       

        }

        private void Nuevo_Click(object sender, EventArgs e)
        {

            DialogResult dr = new DialogResult();
            
            Form_Registro frm = new Form_Registro(0);
            dr                = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.Filtrar();
            }
            
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();

            Form_Registro frm = new Form_Registro(ID);
            dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.Filtrar();
            }
        }
    }
}
