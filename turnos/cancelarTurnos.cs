using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class cancelarTurnos : Form
    {
        bo dlog = new bo();

        public cancelarTurnos()
        {
            InitializeComponent();
            comboEspecialidades();
        }

        private void comboEspecialidades()
        {
            cbEspecialidades.DataSource = null;
            string query = "SELECT ID, DETALLE FROM SECTACT WHERE ROL = '" + VGlobales.vp_role + "' ORDER BY DETALLE;";
            cbEspecialidades.Items.Clear();
            cbEspecialidades.SelectedItem = 0;
            cbEspecialidades.DataSource = dlog.BO_EjecutoDataTable(query);
            cbEspecialidades.DisplayMember = "DETALLE";
            cbEspecialidades.ValueMember = "ID";
        }

        public bool comboProfesional(string ESPECIALIDAD)
        {
            cbProfesionales.DataSource = null;
            string query = "SELECT P.ID, P.NOMBRE FROM PROFESIONALES P, PROF_ESP PE WHERE PE.ESPECIALIDAD = " + ESPECIALIDAD + " AND PE.PROFESIONAL = P.ID AND P.BAJA IS NULL ORDER BY P.NOMBRE ASC;";

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                cbProfesionales.Items.Clear();
                cbProfesionales.SelectedItem = 0;
                cbProfesionales.DataSource = dlog.BO_EjecutoDataTable(query);
                cbProfesionales.DisplayMember = "NOMBRE";
                cbProfesionales.ValueMember = "ID";
                return true;
            }
            else
            {
                return false;
            }
        }

        private void cbEspecialidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboProfesional(cbEspecialidades.SelectedValue.ToString()) == true)
            {
                btnCancelar.Enabled = true;
            }
            else
            {
                btnCancelar.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            int diaD = int.Parse(dpDesde.Text.ToString().Substring(0, 2));
            int mesD = int.Parse(dpDesde.Text.ToString().Substring(3, 2));
            int aniD = int.Parse(dpDesde.Text.ToString().Substring(6, 4));

            int diaH = int.Parse(dpHasta.Text.ToString().Substring(0, 2));
            int mesH = int.Parse(dpHasta.Text.ToString().Substring(3, 2));
            int aniH = int.Parse(dpHasta.Text.ToString().Substring(6, 4));

            //ultimodia ud = new ultimodia();
            //DateTime fecha = Convert.ToDateTime(dpMes.Text);
            //int ultimoDia = int.Parse(ud.GetLastDayOf(fecha).ToString().Substring(0, 2));

            string query = "SELECT ID FROM AGENDA_PROFESIONALES WHERE PROFESIONAL = " + cbProfesionales.SelectedValue.ToString() + " AND FECHA >= '" + aniD + "/" + mesD + "/" + diaD + "' AND FECHA <= '" + aniH + "/" + mesH + "/" + diaH + "' AND BAJA IS NULL;";

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                if (MessageBox.Show("¿Confirma cancelar todos los turnos de los dias seleccionados?", "Cancelar Turnos", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string BAJA = DateTime.Now.ToString();
                        string DESDE = aniD + "/" + mesD + "/" + diaD;
                        string HASTA = aniH + "/" + mesH + "/" + diaH;
                        int PROFESIONAL = int.Parse(cbProfesionales.SelectedValue.ToString());
                        dlog.bajaDia(BAJA, DESDE, HASTA, PROFESIONAL);
                        MessageBox.Show("Se cancelaron los turnos de los días seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("No se pudo cancelar los turnos\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron turnos cargados para los días seleccionados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
