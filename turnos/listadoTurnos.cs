using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;

namespace SOCIOS
{
    public partial class listadoTurnos : Form
    {
        bo dlog = new bo();
        string NRO_SOC;
        string NRO_DEP;
        string BARRA;
        string TIPO;
        string NRO_SOC_TIT;
        string NRO_DEP_TIT;
        int Turno;
        string  Bono;

        SOCIOS.bono.Odontologia.ServicioOdonto serviceOdonto = new bono.Odontologia.ServicioOdonto();


        public listadoTurnos(int STATUS)
        {
            InitializeComponent();
            comboEspecialidades();
            ComboOdontologia();
            ESTADO = STATUS;

            if (ESTADO == 1)
            {
                this.Text = "LISTADO DE TURNOS ACTIVOS";
            }
            else
            {
                this.Text = "LISTADO DE TURNOS CANCELADOS";
            }
        }

        private int ESTADO;
        public int _ESTADO
        {
            get
            {
                return ESTADO;
            }
            set
            {
                ESTADO = value;
            }
        }

        public void comboEspecialidades()
        {
            cbEspecialidades.DataSource = null;
            string query = "SELECT ID, DETALLE FROM SECTACT WHERE ROL = '"+VGlobales.vp_role+"' AND ESTADO = 1 ORDER BY DETALLE;";
            cbEspecialidades.Items.Clear();
            cbEspecialidades.DataSource = dlog.BO_EjecutoDataTable(query);
            cbEspecialidades.DisplayMember = "DETALLE";
            cbEspecialidades.ValueMember = "ID";
            cbEspecialidades.SelectedIndex = -1;
        }

        public bool comboProfesional(string ESPECIALIDAD,ComboBox cbProfesionales)
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

        public void ComboOdontologia()

        {
            cbOdontologia.DataSource = null;
            string query = "SELECT ID, DETALLE FROM SECTACT WHERE ROL = '" + VGlobales.vp_role + "' AND DETALLE LIKE '%ODONTO%'  ORDER BY DETALLE;";
            cbOdontologia.Items.Clear();
            cbOdontologia.DataSource = dlog.BO_EjecutoDataTable(query);
            cbOdontologia.DisplayMember = "DETALLE";
            cbOdontologia.ValueMember = "ID";
            cbOdontologia.SelectedIndex = -1;
        
        }

        private void cargarTurnos(string PROFESIONAL, string FECHA)
        {
            string DAY = DateTime.Parse(FECHA).Day.ToString();


            string MONTH = DateTime.Parse(FECHA).Month.ToString();

            string YEAR = DateTime.Parse(FECHA).Year.ToString();

            string FECHA_FINAL = MONTH+"/"+DAY+"/"+YEAR;

            int PROF = int.Parse(cbProfesionales.SelectedValue.ToString());

            string query = "SELECT * FROM P_LISTADO_TURNOS ("+PROF.ToString()+", '"+FECHA_FINAL+"', "+ESTADO+")";

            //MessageBox.Show(query);

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

                    dt1.Columns.Add("NRO_SOCIO", typeof(string));
                    dt1.Columns.Add("NRO_DEP", typeof(string));
                    dt1.Columns.Add("TIPO", typeof(string));
                    dt1.Columns.Add("BARRA", typeof(string));
                    dt1.Columns.Add("DNI", typeof(string));
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("EMAIL", typeof(string));
                    dt1.Columns.Add("TELEFONO", typeof(string));
                    dt1.Columns.Add("OBRA_SOCIAL", typeof(string));
                    dt1.Columns.Add("DESDE", typeof(string));
                    dt1.Columns.Add("HASTA", typeof(string));
                    dt1.Columns.Add("PRIMERA_VEZ", typeof(string));
                    dt1.Columns.Add("OBSERVACIONES", typeof(string));
                    dt1.Columns.Add("TURNO", typeof(string));
                    dt1.Columns.Add("BONO", typeof(string));  
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("NRO_SOC")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TIPO_SOC")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("BARRA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NRO_DOC")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("EMAIL")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TELEFONO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("OBRA_SOCIAL")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("DESDE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("HASTA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("PRIMERA_VEZ")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("OBSERVACIONES")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TURNO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("BONO")).Trim()); 
                    }

                    reader3.Close();

                    dgvListadoTurnos.DataSource = dt1;
                    dgvListadoTurnos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvListadoTurnos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvListadoTurnos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvListadoTurnos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvListadoTurnos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvListadoTurnos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvListadoTurnos.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvListadoTurnos.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvListadoTurnos.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvListadoTurnos.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvListadoTurnos.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dgvListadoTurnos.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dgvListadoTurnos.Columns[13].Visible      = false;
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cbEspecialidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboProfesional(cbEspecialidades.SelectedValue.ToString(),cbProfesionales);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Refrescar();

        }

        private void Refrescar()
        {
            string PROFESIONAL = cbProfesionales.SelectedValue.ToString();

            string FECHA = dtpFecha.Text;

            cargarTurnos(PROFESIONAL, FECHA);

            if (cbEspecialidades.Text.Contains("ODONTO"))
            {
                btnBono.Visible = true;
                gpOtras.Visible = true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string FECHA = dtpFecha.Text;
            string DAY = FECHA.Substring(0, 2);
            string MONTH = FECHA.Substring(3, 2);
            string YEAR = FECHA.Substring(6, 4);
            string FECHA_FINAL = MONTH + "/" + DAY + "/" + YEAR;
            string PROFESIONAL = cbProfesionales.SelectedValue.ToString();
            string ESPECIALIDAD = cbEspecialidades.SelectedValue.ToString();
            genHTML gh = new genHTML();
            gh.listadoTurnos(PROFESIONAL, FECHA_FINAL, ESPECIALIDAD, FECHA, ESTADO);
            printhtml p = new printhtml();
            p.printHTML("listado_turnos.html");
        }

        private void cbEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnBono_Click(object sender, EventArgs e)
        {
            this.SetearDatosBono();
            int secAct = Int32.Parse(cbEspecialidades.SelectedValue.ToString());
            string Profesional = cbProfesionales.SelectedText;

            if ((Bono.Length == 0) || Bono.Trim() == "0")
            {
                bono.BonoOdontologico admBonoOdonto = new bono.BonoOdontologico(NRO_SOC, NRO_DEP, BARRA, NRO_SOC_TIT, NRO_DEP_TIT, secAct, Turno, false,"TURNO");
                admBonoOdonto.idProfesional = Int32.Parse(cbProfesionales.SelectedValue.ToString());
                admBonoOdonto.nombreProfesional = cbProfesionales.Text;
                DialogResult dr = admBonoOdonto.ShowDialog();
                
                this.Refrescar();

            }
            else
            {
                if (serviceOdonto.CantidadBonos(Turno) > 1)
                {

                    SOCIOS.bono.Odontologia.BonosXturno bt = new bono.Odontologia.BonosXturno(Turno);
                    bt.ShowDialog();
                    bt.Focus();
                }
                else
                {
                    SOCIOS.bono.Odontologico odonto = new bono.Odontologico(Turno, false);
                }
            }
        }

        private void SetearDatosBono( )
        {
            string Query = "";
            if (dgvListadoTurnos.SelectedRows.Count > 0)
            {

                bo dlog = new bo();

                NRO_SOC = dgvListadoTurnos.SelectedRows[0].Cells[0].Value.ToString();
                NRO_DEP = dgvListadoTurnos.SelectedRows[0].Cells[1].Value.ToString();
                TIPO    = dgvListadoTurnos.SelectedRows[0].Cells[2].Value.ToString();
                BARRA   = dgvListadoTurnos.SelectedRows[0].Cells[3].Value.ToString();
                Turno   = Int32.Parse(dgvListadoTurnos.SelectedRows[0].Cells[13].Value.ToString());
                Bono    = dgvListadoTurnos.SelectedRows[0].Cells[14].Value.ToString();

                if (TIPO == "ADH")
                {
                    Query="SELECT NRO_SOCIO,NRO_DEP   FROM ADHERENT   WHERE NRO_ADH=  " + NRO_SOC + "AND NRO_DEPADH="+ NRO_DEP  +"AND BARRA=" + BARRA;
                    DataRow[] foundRows;
                    foundRows = dlog.BO_EjecutoDataTable(Query).Select();

                    if (foundRows.Length > 0)
                    {
                        NRO_SOC_TIT = foundRows[0][0].ToString().Trim();
                        NRO_DEP_TIT = foundRows[0][1].ToString().Trim();
                    }
                   


                }
                else
                {
                    NRO_SOC_TIT = NRO_SOC;
                    NRO_DEP_TIT = NRO_DEP;
                
                }
            }
        
        }

        public string nombre(int ID_SOCIO)
        {
            bo dlog = new bo();
            string nombre = "";
            string query = "SELECT APE_SOC, NOM_SOC FROM TITULAR WHERE ID_TITULAR = " + ID_SOCIO;

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
                nombre = foundRows[0][0].ToString().Trim() + ", " + foundRows[0][1].ToString().Trim();
            else
                nombre = "NO SE ENCONTRARON DATOS";

            return nombre;
        }

        private void dgvListadoTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBonoEspecialidad_Click(object sender, EventArgs e)
        {
            this.SetearDatosBono();
            int secAct = Int32.Parse(cbOdontologia.SelectedValue.ToString());
            string Profesional = cbProfesionalesOdontologia.SelectedText;

        
            bono.BonoOdontologico admBonoOdonto = new bono.BonoOdontologico(NRO_SOC, NRO_DEP, BARRA, NRO_SOC_TIT, NRO_DEP_TIT, secAct, Turno, false, "TURNO");
            admBonoOdonto.idProfesional = Int32.Parse(cbProfesionalesOdontologia.SelectedValue.ToString());
            admBonoOdonto.nombreProfesional = cbProfesionalesOdontologia.Text;
            admBonoOdonto.ShowDialog();
            admBonoOdonto.Focus();

           
        }

        private void cbOdontologia_SelectedIndexChanged(object sender, EventArgs e)
        {
          if (cbOdontologia.SelectedValue != null)
            comboProfesional(cbOdontologia.SelectedValue.ToString(), cbProfesionalesOdontologia);
        }
    }
}
