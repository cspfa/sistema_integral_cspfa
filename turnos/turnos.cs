using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Firebird;

namespace SOCIOS
{
    public partial class turnos : Form
    {
        bo dlog = new bo();

        public turnos(string var_NombreTabla, string var_Numero, string var_Depuracion, string var_Barra, string DNI)
        {
            InitializeComponent();
            tbTipo.Text = var_Barra;
            nro_dep = int.Parse(var_Depuracion);
            nro_soc = int.Parse(var_Numero);
            barra = int.Parse(var_Barra);
            tipo_soc = var_NombreTabla.Substring(0,3);
            tabla = var_NombreTabla;
            
            if (DNI != "")
                num_doc = DNI;
            else
                num_doc = null;

            tbDNI.Text = num_doc;

            nombreSocio ns = new nombreSocio();
            obrasocial os = new obrasocial();

            switch (var_NombreTabla)
            {
                case "TITULAR":
                    mostrarContacto(nro_soc, nro_dep, 0, 0, 0);
                    break;

                case "ADHERENT":
                    mostrarContacto(0, 0, nro_soc, nro_dep, barra);
                    break;

                case "FAMILIAR":
                    mostrarContacto(nro_soc, nro_dep, 0, 0, barra);
                    break;
            }

            if (var_NombreTabla == "TITULAR")
            {
                string[] datos = ns.NRO_SOC(int.Parse(var_Numero), int.Parse(var_Depuracion), "X");
                lbNombreSocio.Text = datos[0]+", "+datos[1];
                lbTelefono.Text = datos[2] + "-" + datos[3];
                lbEmail.Text = datos[4];
                lbObraSocial.Text = os.nroObraSocial(int.Parse(var_Numero), int.Parse(var_Depuracion), "X");
            }
            else
            {
                string[] datos = ns.NRO_SOC(int.Parse(var_Numero), int.Parse(var_Depuracion), var_Barra);
                lbNombreSocio.Text = datos[0] + ", " + datos[1];
                lbTelefono.Text = datos[2] + "-" + datos[3];
                lbEmail.Text = datos[4];
                lbObraSocial.Text = os.nroObraSocial(int.Parse(var_Numero), int.Parse(var_Depuracion), var_Barra);
            }

            comboEspecialidades();

            if (comboProfesional(cbEspecialidades.SelectedValue.ToString()) == true)
            {
                btnVerAgenda.Enabled = true;
            }
            else
            { 
                btnVerAgenda.Enabled = false;
            }

            dgvListadoDias.ColumnCount = 5;
            dgvListadoDias.Columns[0].Name = "FECHA";
            dgvListadoDias.Columns[1].Name = "DESDE";
            dgvListadoDias.Columns[2].Name = "HASTA";
            dgvListadoDias.Columns[3].Name = "ID";
            dgvListadoDias.Columns[4].Name = "PROFE";
            dgvListadoDias.Columns[3].Visible = false;
            dgvListadoDias.Columns[4].Visible = false;
            dgvListadoDias.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListadoDias.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListadoDias.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListadoDias.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListadoDias.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListadoDias.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListadoDias.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvListadoDias.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvListadoDias.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            btnAsignar.Enabled = false;
            btnCancelar.Enabled = false;
            btnCancelarDia.Enabled = false;
        }

        private void mostrarContacto(int NRO_SOC, int NRO_DEP, int NRO_ADH, int DEP_ADH, int BARRA)
        {
            bo dlog = new bo();
            string QUERY = "";

            if (NRO_SOC > 0)
            {
                QUERY = "SELECT FIRST 1 EMAIL, TELEFONO, INTERESES, OBRA_SOCIAL FROM CONTACTO WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = " + BARRA + " ORDER BY ID DESC;";
            }

            if (NRO_ADH > 0)
            {
                QUERY = "SELECT FIRST 1 EMAIL, TELEFONO, INTERESES, OBRA_SOCIAL FROM CONTACTO WHERE NRO_ADH = " + NRO_ADH + " AND DEP_ADH = " + DEP_ADH + " AND BARRA = " + BARRA + " ORDER BY ID DESC;";
            }

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                tbEmail.Text = foundRows[0][0].ToString();
                tbTelefono.Text = foundRows[0][1].ToString();
                tbIntereses.Text = foundRows[0][2].ToString();
                tbObraSocial.Text = foundRows[0][3].ToString();
            }
            else
            {
                tbEmail.Text = "";
                tbTelefono.Text = "";
                tbIntereses.Text = "";
                tbObraSocial.Text = "";
            }
        }

        private int idsoc;
        public int _idsoc
        {
            get
            {
                return idsoc;
            }
            set
            {
                idsoc = value;
            }
        }

        private int nro_soc;
        public int _nro_soc
        {
            get
            {
                return nro_soc;
            }
            set
            {
                nro_soc = value;
            }
        }

        private int nro_dep;
        public int _nro_dep
        {
            get
            {
                return nro_dep;
            }
            set
            {
                nro_dep = value;
            }
        }

        private int barra;
        public int _barra
        {
            get
            {
                return barra;
            }
            set
            {
                barra = value;
            }
        }

        private string tipo_soc;
        public string _tipo_soc
        {
            get
            {
                return tipo_soc;
            }
            set
            {
                tipo_soc = value;
            }
        }

        private string num_doc;
        public string _num_doc
        {
            get
            {
                return num_doc;
            }
            set
            {
                num_doc = value;
            }
        }

        private string tabla;
        public string _tabla
        {
            get
            {
                return tabla;
            }
            set
            {
                tabla = value;
            }
        }

        private void comboEspecialidades()
        {
            cbEspecialidades.DataSource = null;
            string query = "SELECT ID, DETALLE FROM SECTACT WHERE ROL = '"+VGlobales.vp_role+"' ORDER BY DETALLE;";
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

        public bool llenarListadoDelMes(int PROFESIONAL, int MES, int ANIO, int ULTIMODIA)
        {
            string query = "SELECT FECHA, DESDE, HASTA, ID, PROFESIONAL FROM AGENDA_PROFESIONALES WHERE PROFESIONAL = " + PROFESIONAL + " AND FECHA BETWEEN '" + ANIO + "/" + MES + "/01' AND '" + ANIO + "/" + MES + "/" + ULTIMODIA + "' AND BAJA IS NULL ORDER BY FECHA;";
            
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

                    string[] row = { fecha.ToString().Substring(0, 10), desde.ToString("HH:mm"), hasta.ToString("HH:mm"), foundRows[i][3].ToString(), foundRows[i][4].ToString() };

                    dgvListadoDias.Rows.Add(row);
                }

                return true;
            }
            else
            {
                while (dgvListadoDias.RowCount > 0)
                {
                    dgvListadoDias.Rows.Remove(dgvListadoDias.CurrentRow);
                }

                MessageBox.Show("No se encontraron datos");
                return false;
            }
        }

        private void llenarDatosTurno()
        {
            tbDiaHoraId.Text = dgvListadoDias[3, dgvListadoDias.CurrentCell.RowIndex].Value.ToString();
            string query = "SELECT * FROM TURNOS_MEDICOS WHERE BAJA IS NULL AND DIAYHORA = " + tbDiaHoraId.Text;

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                tbIdTurno.Text = foundRows[0][0].ToString();
                lbAsignado.Text = "TURNO ASIGNADO A:";
                lbAsignado.ForeColor = System.Drawing.Color.Red;
                btnAsignar.Enabled = false;
                btnCancelar.Enabled = true;
                lbSocioAsignado.Text = foundRows[0][15].ToString() + " - " + foundRows[0][3].ToString() + " - " + foundRows[0][11].ToString() + " - " + foundRows[0][13].ToString();
            }
            else
            {
                lbAsignado.Text = "TURNO DISPONIBLE";
                lbAsignado.ForeColor = System.Drawing.Color.Green;
                btnAsignar.Enabled = true;
                btnCancelar.Enabled = false;
                lbSocioAsignado.Text = "";
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            existeTurno et = new existeTurno();
            bool tieneTurno = et.existe(int.Parse(tbDiaHoraId.Text));

            if (tieneTurno == true)
            {
                string primeraVez = "";

                if (cbPrimeraVez.CheckState.ToString() == "Checked")
                {
                    primeraVez = "SI";
                }
                else
                {
                    primeraVez = "NO";
                }

                if (MessageBox.Show("¿CONFIRMA EL TURNO?", "ASIGNAR TURNO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                        cs.UserID = VGlobales.vp_username;
                        int mes = int.Parse(dpMes.Text.ToString().Substring(3, 2));
                        int anio = int.Parse(dpMes.Text.ToString().Substring(6, 4));


                        dlog.nuevoTurnoMedico(
                            int.Parse(dgvListadoDias.SelectedRows[0].Cells[4].Value.ToString()),
                            int.Parse(tbDiaHoraId.Text),
                            nro_soc,
                            int.Parse(cbEspecialidades.SelectedValue.ToString()),
                            mes,
                            anio,
                            cs.UserID.ToString(),
                            null,
                            nro_dep,
                            barra,
                            tipo_soc,
                            num_doc, lbNombreSocio.Text, tbEmail.Text, tbTelefono.Text, tbObraSocial.Text, primeraVez, tbObservaciones.Text);

                        MessageBox.Show("TURNO ASIGNADO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        llenarDatosTurno();

                        colorListaTurnos(int.Parse(cbProfesionales.SelectedValue.ToString()), mes, anio);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("NO SE PUDO ASIGNAR EL TURNO\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("EL TURNO SELECCIONADO YA FUE ASIGNADO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbEspecialidades_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            if (comboProfesional(cbEspecialidades.SelectedValue.ToString()) == true)
            {
                btnVerAgenda.Enabled = true;
                btnCancelarDia.Enabled = true;
            }
            else
            {
                btnVerAgenda.Enabled = false;
                btnCancelarDia.Enabled = false;
            }
        }

        private void llenarTablaTemporal(string USUARIO, int PROFESIONAL, int MES, int ANIO)
        {
            try
            {
                dlog.nuevoTablaTemporal(USUARIO, PROFESIONAL, MES, ANIO);
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR AL GUARDAR DATOS TEMPORALES");
            }
        }

        private void modificarTablaTemporal(string ID, int PROFESIONAL, int MES, int ANIO)
        {
            try
            {
                dlog.modificarTablaTemporal(ID, PROFESIONAL, MES, ANIO);
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR AL MODIFICAR DATOS TEMPORALES");
            }
        }

        private void vaciarTablaTemporal(string USUARIO)
        {
            string query = "SELECT ID FROM TURNOS_TEMP WHERE USUARIO = '" + USUARIO + "'";

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            try
            {
                dlog.modificarTablaTemporal(foundRows[0][0].ToString(), 0, 0, 0);
            }
            catch (Exception error)
            {
                MessageBox.Show("ERROR AL VACIAR DATOS TEMPORALES");
            }
        }

        private string usuarioDandoTurno(string USUARIO, int PROFESIONAL, int MES, int ANIO)
        {
            string query = "SELECT USUARIO FROM TURNOS_TEMP WHERE USUARIO != '" + VGlobales.vp_username + "' AND PROFESIONAL = " + PROFESIONAL + " AND MES = " + MES + " AND ANIO = " + ANIO;
            
            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
                return foundRows[0][0].ToString();
            else
                return "NADIE";
            
        }

        private void InitializeTimer()
        {
            timer1.Interval = 5000;
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object Sender, EventArgs e)
        {
            llenarDatosAgenda();
        }

        private void llenarDatosAgenda()
        {
            ultimodia ud = new ultimodia();
            DateTime fecha = Convert.ToDateTime(dpMes.Text);
            int ultimoDia = int.Parse(ud.GetLastDayOf(fecha).ToString().Substring(0, 2));
            int mes = int.Parse(dpMes.Text.ToString().Substring(3, 2));
            int anio = int.Parse(dpMes.Text.ToString().Substring(6, 4));

            if (llenarListadoDelMes(int.Parse(cbProfesionales.SelectedValue.ToString()), mes, anio, ultimoDia) == true)
            {
                if (VGlobales.vp_role == "SERVICIOS MEDICOS")
                {
                    string query = "SELECT ID FROM TURNOS_TEMP WHERE USUARIO = '" + VGlobales.vp_username + "'";
                    DataRow[] foundRows;
                    foundRows = dlog.BO_EjecutoDataTable(query).Select();

                    string USUARIO = usuarioDandoTurno(VGlobales.vp_username, int.Parse(cbProfesionales.SelectedValue.ToString()), mes, anio);

                    if (USUARIO != "NADIE")
                    {
                        lbAtencion.Visible = true;
                        lbAtencion.Text = "ATENCION: EL USUARIO " + USUARIO + " SE ENCUENTRA ASIGNANDO TURNOS PARA EL MISMO PROFESIONAL";
                    }
                    else
                    {
                        lbAtencion.Visible = false;
                    }

                    if (foundRows.Length > 0)
                        modificarTablaTemporal(foundRows[0][0].ToString(), int.Parse(cbProfesionales.SelectedValue.ToString()), mes, anio);
                    else
                        llenarTablaTemporal(VGlobales.vp_username, int.Parse(cbProfesionales.SelectedValue.ToString()), mes, anio);
                }

                llenarDatosTurno();
                colorListaTurnos(int.Parse(cbProfesionales.SelectedValue.ToString()), mes, anio);
            }
            else
            {
                lbAsignado.Text = "-";
                btnAsignar.Enabled = false;
                btnCancelar.Enabled = false;
                lbSocioAsignado.Text = "-";
            }
        }

        private void btnVerAgenda_Click(object sender, EventArgs e)
        {
            llenarDatosAgenda();
        }

        private void colorListaTurnos(int PROFESIONAL, int MES, int ANIO)
        {
            string query = "SELECT DIAYHORA FROM TURNOS_MEDICOS WHERE MES = " + MES + " AND PROFESIONAL = " + PROFESIONAL + " AND ANIO = " + ANIO + " AND BAJA IS NULL;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            for (int i = 0; i < foundRows.Length; i++)
            {
                for (int ii = 0; ii < dgvListadoDias.Rows.Count; ii++)
                {
                    if (dgvListadoDias[3, ii].Value.ToString() == foundRows[i][0].ToString())
                    {
                        dgvListadoDias.Rows[ii].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void dgvListadoDias_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            llenarDatosTurno();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Confirma cancelar el turno?", "Cancelar Turno", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                    cs.UserID = VGlobales.vp_username;
                    ultimodia ud = new ultimodia();
                    DateTime fecha = Convert.ToDateTime(dpMes.Text);
                    int mes = int.Parse(dpMes.Text.ToString().Substring(3, 2));
                    int anio = int.Parse(dpMes.Text.ToString().Substring(6, 4));
                    int ultimoDia = int.Parse(ud.GetLastDayOf(fecha).ToString().Substring(0, 2));
                    dlog.bajaTurnoMedico(int.Parse(tbIdTurno.Text), DateTime.Now.ToString(), cs.UserID.ToString());
                    MessageBox.Show("Se canceló el turno seleccionado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llenarListadoDelMes(int.Parse(cbProfesionales.SelectedValue.ToString()), mes, anio, ultimoDia);
                    llenarDatosTurno();
                    colorListaTurnos(int.Parse(cbProfesionales.SelectedValue.ToString()), mes, anio);
                }
                catch (Exception error)
                {
                    MessageBox.Show("No se pudo cancelar el turno\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelarDia_Click(object sender, EventArgs e)
        {
            /*int dia = int.Parse(dpMes.Text.ToString().Substring(0, 2));
            int mes = int.Parse(dpMes.Text.ToString().Substring(3, 2));
            int anio = int.Parse(dpMes.Text.ToString().Substring(6, 4));
            ultimodia ud = new ultimodia();
            DateTime fecha = Convert.ToDateTime(dpMes.Text);
            int ultimoDia = int.Parse(ud.GetLastDayOf(fecha).ToString().Substring(0, 2));

            string query = "SELECT ID FROM AGENDA_PROFESIONALES WHERE PROFESIONAL = " + cbProfesionales.SelectedValue.ToString() + " AND FECHA = '" + anio + "/" + mes + "/" + dia + "' AND BAJA IS NULL;";
            
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                if (MessageBox.Show("¿Confirma cancelar todos los turnos del día " + dpMes.Text + "?", "Cancelar Día", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        string BAJA = DateTime.Now.ToString();
                        string FECHA = anio + "/" + mes + "/" + dia;
                        int PROFESIONAL = int.Parse(cbProfesionales.SelectedValue.ToString());
                        dlog.bajaDia(BAJA, FECHA, PROFESIONAL);
                        MessageBox.Show("Se dieron de baja los turnos del día " + dpMes.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("No se encontraron turnos cargados para el dia " + dpMes.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        public void guardarInfoContacto()
        {
            int BARRA = int.Parse(tbTipo.Text);

            int NRO_SOC = 0;

            int NRO_DEP = 0;

            int NRO_ADH = 0;

            int DEP_ADH = 0;

            switch (tabla)
            {
                case "TITULAR":
                    NRO_SOC = nro_soc;
                    NRO_DEP = nro_dep;
                    break;

                case "ADHERENT":
                    NRO_ADH = nro_soc;
                    DEP_ADH = nro_dep;
                    break;

                case "FAMILIAR":
                    NRO_SOC = nro_soc;
                    NRO_DEP = nro_dep;
                    break;
            }

            string EMAIL = tbEmail.Text;
            
            string TELEFONO = tbTelefono.Text;
            
            string INTERESES = tbIntereses.Text;
            
            string OSOCIAL = tbObraSocial.Text;

            try
            {
                dlog.insertoContacto(NRO_SOC, NRO_DEP, BARRA, EMAIL, TELEFONO, INTERESES, OSOCIAL, NRO_ADH, DEP_ADH);
                MessageBox.Show("INFORMACION DE CONTACTO GUARDADA", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show("NO SE PUDO GUARDAR\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            guardarInfoContacto();
        }

        private void turnos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (VGlobales.vp_role == "SERVICIOS MEDICOS")
            {
                vaciarTablaTemporal(VGlobales.vp_username);
            }
        }
    }
}
