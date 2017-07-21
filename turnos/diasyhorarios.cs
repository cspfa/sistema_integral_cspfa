using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class diasyhorarios : Form
    {
        bo dlog = new bo();

        public diasyhorarios()
        {
            InitializeComponent();
            
            comboProfesionales();
            comboTurno();
            
            labelEspecialidad(int.Parse(cbProfesionales.SelectedValue.ToString()));

            dgvListadoDias.ColumnCount = 3;
            dgvListadoDias.Columns[0].Name = "FECHA";
            dgvListadoDias.Columns[1].Name = "DESDE";
            dgvListadoDias.Columns[2].Name = "HASTA";

            dgvListadoDias.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListadoDias.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListadoDias.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvListadoDias.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListadoDias.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListadoDias.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvListadoDias.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvListadoDias.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvListadoDias.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void comboProfesionales()
        {
            cbProfesionales.DataSource = null;
            string query = "SELECT ID, NOMBRE FROM PROFESIONALES WHERE BAJA IS NULL AND NOMBRE != 'EMPLEADOS CSPFA' AND ROL = '"+VGlobales.vp_role+"' ORDER BY NOMBRE;";
            cbProfesionales.Items.Clear();
            cbProfesionales.SelectedItem = 0;
            cbProfesionales.DataSource = dlog.BO_EjecutoDataTable(query);
            cbProfesionales.DisplayMember = "NOMBRE";
            cbProfesionales.ValueMember = "ID";
        }

        public void comboTurno()
        {
            cbTurno.Items.Add("10");
            cbTurno.Items.Add("15");
            cbTurno.Items.Add("20");
            cbTurno.Items.Add("30");
        }

        public void llenarListadoDelMes(int PROFESIONAL, int MES, int ANIO, int ULTIMODIA)
        {
            string query = "SELECT FECHA, DESDE, HASTA FROM AGENDA_PROFESIONALES WHERE PROFESIONAL = " + PROFESIONAL + " AND FECHA BETWEEN '" + ANIO + "/" + MES + "/01' AND '" + ANIO + "/" + MES + "/" + ULTIMODIA + "' AND BAJA IS NULL ORDER BY ID;";

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                while (dgvListadoDias.RowCount > 0)
                {
                    dgvListadoDias.Rows.Remove(dgvListadoDias.CurrentRow);
                }

                for (int i = 0; i < foundRows.Length; i++)
                {
                    DateTime fecha = Convert.ToDateTime(foundRows[i][0].ToString());
                    DateTime desde = Convert.ToDateTime(foundRows[i][1].ToString());
                    DateTime hasta = Convert.ToDateTime(foundRows[i][2].ToString());

                    string[] row = { fecha.ToString().Substring(0, 10), desde.ToString("HH:mm"), hasta.ToString("HH:mm") };
                    
                    dgvListadoDias.Rows.Add(row);
                }
            }
            else
            {
                while (dgvListadoDias.RowCount > 0)
                {
                    dgvListadoDias.Rows.Remove(dgvListadoDias.CurrentRow);
                }

                MessageBox.Show("No se encontraron datos");
            }
        }

        public void labelEspecialidad(int PROFESIONAL)
        {
            string query = "SELECT SECTACT.DETALLE FROM SECTACT, PROFESIONALES, PROF_ESP WHERE " + cbProfesionales.SelectedValue.ToString() + " = PROF_ESP.PROFESIONAL AND PROF_ESP.ESPECIALIDAD = SECTACT.ID;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();
            lbEspecialidad.Text = foundRows[0][0].ToString();
        }

        private void cbProfesionales_SelectionChangeCommitted(object sender, EventArgs e)
        {
            labelEspecialidad(int.Parse(cbProfesionales.SelectedValue.ToString()));
        }

        private void btnNuevoDia_Click(object sender, EventArgs e)
        {
            if (!tbDesde.MaskCompleted)
            {
                tbDesde.Focus();
                MessageBox.Show("El campo Hora Desde no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!tbHasta.MaskCompleted)
            {
                tbDesde.Focus();
                MessageBox.Show("El campo Hora Hasta no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbTurno.Text == "")
            {
                cbTurno.Focus();
                MessageBox.Show("Seleccionar una duración para el turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    dlog.nuevaAgenda(int.Parse(cbProfesionales.SelectedValue.ToString()), dtFecha.Text, tbDesde.Text, tbHasta.Text, int.Parse(cbTurno.SelectedItem.ToString()));
                    
                    MessageBox.Show("Registro creado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ultimodia ud = new ultimodia();
                    DateTime fecha = Convert.ToDateTime(dtFecha.Text);
                    int ultimoDia = int.Parse(ud.GetLastDayOf(fecha).ToString().Substring(0, 2));
                    int mes = int.Parse(dtFecha.Text.ToString().Substring(3, 2));
                    int anio = int.Parse(dtFecha.Text.ToString().Substring(6, 4));
                    llenarListadoDelMes(int.Parse(cbProfesionales.SelectedValue.ToString()), mes, anio, ultimoDia);
                }
                catch (Exception error)
                {
                    MessageBox.Show("No se pudo crear el registro\n"+error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ultimodia ud = new ultimodia();
            DateTime fecha = Convert.ToDateTime(dtFecha.Text);
            int ultimoDia = int.Parse(ud.GetLastDayOf(fecha).ToString().Substring(0, 2));
            int mes = int.Parse(dtFecha.Text.ToString().Substring(3, 2));
            int anio = int.Parse(dtFecha.Text.ToString().Substring(6, 4));
            llenarListadoDelMes(int.Parse(cbProfesionales.SelectedValue.ToString()), mes, anio, ultimoDia);
        }

        private void btnCancelarDia_Click(object sender, EventArgs e)
        {
            /*int dia = int.Parse(dtFecha.Text.ToString().Substring(0, 2));
            int mes = int.Parse(dtFecha.Text.ToString().Substring(3, 2));
            int anio = int.Parse(dtFecha.Text.ToString().Substring(6, 4));
            ultimodia ud = new ultimodia();
            DateTime fecha = Convert.ToDateTime(dtFecha.Text);
            int ultimoDia = int.Parse(ud.GetLastDayOf(fecha).ToString().Substring(0, 2));

            string query = "SELECT ID FROM AGENDA_PROFESIONALES WHERE PROFESIONAL = " + cbProfesionales.SelectedValue.ToString() + " AND FECHA = '" + anio + "/" + mes + "/" + dia + "' AND BAJA IS NULL;";

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                if (MessageBox.Show("¿Confirma cancelar todos los turnos del día " + dtFecha.Text + "?", "Cancelar Día", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string BAJA = DateTime.Now.ToString();
                        string FECHA = anio + "/" + mes + "/" + dia;
                        int PROFESIONAL = int.Parse(cbProfesionales.SelectedValue.ToString());
                        dlog.bajaDia(BAJA, FECHA, PROFESIONAL);
                        MessageBox.Show("Se dieron de baja los turnos del día " + dtFecha.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        llenarListadoDelMes(int.Parse(cbProfesionales.SelectedValue.ToString()), mes, anio, ultimoDia);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("No se pudo dar de baja el dia seleccionado\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron turnos cargados para el dia " + dtFecha.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
    }
}
