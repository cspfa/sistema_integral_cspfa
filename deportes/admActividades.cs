using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;

namespace SOCIOS.deportes
{


    public partial class admActividades : MicroFour.StrataFrame.UI.Windows.Forms.StandardForm
    {
        bo_Deportes  dlog = new bo_Deportes();
        SOCIOS.arancel arancelService = new arancel();
        bool INICIO;
        string ROL = "";
        public admActividades(int id_deporte,string Rol ,string Cat_Soc,int nro_soc,int nro_dep,int barra,string cod_dto)
        {
            InitializeComponent();
            INICIO = true;
            
            ID_HEAD = id_deporte;
            categoria_social = Cat_Soc;
            Nro_soc = nro_soc;
            Nro_dep = Nro_dep;
            Barra = barra;
            COD_DTO = cod_dto;
            ROL = Rol;
            if (ROL == "ROL")
                ROL = VGlobales.vp_role.TrimEnd();
            this.Refrescar_Grilla();
            this.InicializarGP();
          

            Seteo_Arancel();
          
            INICIO = false;


           
            



        }




        private void fMain_Shown(object sender, EventArgs e)
        {

            dataGridView.ClearSelection();
        }
    

      

        #region Variables Internas

        private int arancelID;
        public int _arancelID
        {
            get
            {
                return arancelID;
            }
            set
            {
                arancelID = value;
            }
        }

        private decimal Arancel;
        public decimal _Arancel
        {
            get
            {
                return Arancel;
            }
            set
            {
                Arancel = value;
            }
        }

        private int Profesional;
        public int _Profesional
        {
            get
            {
                return Profesional;
            }
            set
            {
                Profesional = value;
            }
        }

        private string categoria_social;
        public string _categoria_social
        {
            get
            {
                return categoria_social;
            }
            set
            {
                categoria_social = value;
            }
        }

        private int Nro_soc;
        public int _nro_soc
        {
            get
            {
                return Nro_soc;
            }
            set
            {
                Nro_soc = value;
            }
        }

        private int Nro_dep;
        public int _nro_dep
        {
            get
            {
                return Nro_dep;
            }
            set
            {
                Nro_dep = value;
            }
        }

        private int ID_HEAD;
        public int _ID_HEAD
        {
            get
            {
                return ID_HEAD;
            }
            set
            {
                ID_HEAD = value;
            }
        }

        private string MODO;
        public  string _MODO
        {
            get
            {
                return MODO;
            }
            set
            {
                MODO = value;
            }
        }

        private int Barra;
        public int _Barra
        {
            get
            {
                return Barra;
            }
            set
            {
                Barra = value;
            }
        }
        private string COD_DTO;
        public string _COD_DTO
        {
            get
            {
                return COD_DTO;
            }
            set
            {
                COD_DTO = value;
            }
        }


        #endregion


        #region Funciones
        private void Seteo_Arancel()
        {

            int SECTACT = 0;
            string valor_arancel="";
            DataRowView rowView = (DataRowView)cbActividad.SelectedItem;

            if (cbActividad.SelectedValue != null)
            {
                SECTACT = Int32.Parse(rowView[2].ToString());
                Profesional = Int32.Parse(rowView[1].ToString());
                getGrupo gg = new getGrupo();
                valor_arancel = arancelService.valorGrupo(SECTACT,gg.get(COD_DTO,categoria_social), Profesional).ToString();

                if (valor_arancel != "X")
                    Arancel = Decimal.Parse(valor_arancel);
                else
                    Arancel = 0;

                //lblArancel.Text = decimal.Round(Arancel, 2).ToString();
            }
            
        }

        private bool TieneCargadaCuota()

        {
            foreach ( DataGridViewRow dr in dataGridView.Rows)
            {
                if (dr.Cells[1].Value.ToString().Contains("CUOTA") && dr.Cells[5].Value.ToString()=="0")
                    return true;
            
            
            
            }
        
          return false;
        
        }

        private bool TieneCargadaActividad()
        {
            foreach (DataGridViewRow dr in dataGridView.Rows)
            {
                if (!(dr.Cells[1].Value.ToString().Contains("CUOTA")))
                    return true;



            }

            return false;

        }

        private void Refrescar_Grilla()
        {



            List<GridActividades> lista = new List<GridActividades>();
            SOCIOS.arancel aranceles = new arancel();

            string Query = "SELECT SOCIO_ACTIVIDADES.ID ID, SECTACT.DETALLE ACTIVIDAD , PROFESIONALES.NOMBRE PROFESIONAL ,SOCIO_ACTIVIDADES.ARANCEL ARANCEL, SOCIO_ACTIVIDADES.F_ALTA FECHA,SOCIO_ACTIVIDADES.ESTADO ESTADO, COALESCE(SOCIO_ACTIVIDADES.F_BAJA,'') BAJA,SOCIO_ACTIVIDADES.PROFESIONAL PROFESIONAL_ID ,SOCIO_ACTIVIDADES.SECTACT SECTACT" +
                            "  FROM   SOCIO_ACTIVIDADES ,PROFESIONALES,SECTACT    WHERE    " +
                            "  SOCIO_ACTIVIDADES.PROFESIONAL=PROFESIONALES.ID " +
                            " AND      SOCIO_ACTIVIDADES.SECTACT    =   SECTACT.ID  " +
                           " AND  SOCIO_ACTIVIDADES.ID_DEPORTE=  " + ID_HEAD.ToString() + "  AND SOCIO_ACTIVIDADES.ROL='" + ROL.TrimEnd() + "'" 
                           + " AND (SOCIO_ACTIVIDADES.F_UPDATE IS NULL OR (SOCIO_ACTIVIDADES.F_UPDATE IS NOT NULL AND SOCIO_ACTIVIDADES.ESTADO=1))   ORDER BY    ACTIVIDAD ;";


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

                    //DataTable dt1 = new DataTable("RESULTADOS");

                    //dt1.Columns.Add("ID", typeof(string));
                    //dt1.Columns.Add("ACTIVIDAD", typeof(string));
                    //dt1.Columns.Add("PROFESIONAL", typeof(string));
                    //dt1.Columns.Add("ARANCEL", typeof(decimal));
                    //dt1.Columns.Add("FECHA", typeof(DateTime));
                    //dt1.Columns.Add("Estado", typeof(string));
                    //dt1.Columns.Add("BAJA", typeof(string));

                    //ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        //dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID")).Trim(),
                        //             reader3.GetString(reader3.GetOrdinal("ACTIVIDAD")).Trim(),
                        //             reader3.GetString(reader3.GetOrdinal("PROFESIONAL")).Trim(),
                        //             reader3.GetString(reader3.GetOrdinal("ARANCEL")).Trim(),
                        //             reader3.GetString(reader3.GetOrdinal("FECHA")).Trim(),
                        //             reader3.GetString(reader3.GetOrdinal("ESTADO")).Trim(),
                        //             reader3.GetString(reader3.GetOrdinal("BAJA")).Trim());

                        GridActividades itemGrilla = new GridActividades();
                        itemGrilla.ID = Int32.Parse(reader3.GetString(reader3.GetOrdinal("ID")).Trim());
                        itemGrilla.ACTIVIDAD = reader3.GetString(reader3.GetOrdinal("ACTIVIDAD")).Trim();
                        itemGrilla.PROFESIONAL = reader3.GetString(reader3.GetOrdinal("PROFESIONAL")).Trim();
                        itemGrilla.FECHA = DateTime.Parse(reader3["FECHA"].ToString()).ToShortDateString();
                        itemGrilla.ESTADO      = Int32.Parse(reader3.GetOrdinal("ESTADO").ToString());
                        itemGrilla.BAJA = reader3["BAJA"].ToString();
                        itemGrilla.PROFESIONAL_ID = Int32.Parse(reader3.GetString(reader3.GetOrdinal("PROFESIONAL_ID")).Trim());
                        itemGrilla.SECTACT = Int32.Parse(reader3.GetString(reader3.GetOrdinal("SECTACT")).Trim());
                        itemGrilla.ARANCEL = aranceles.valorGrupo(itemGrilla.SECTACT, VGlobales.vp_Grupo, itemGrilla.PROFESIONAL_ID);

                        lista.Add(itemGrilla);
                    }

                    reader3.Close();


                   // dataGridView.DataSource = dt1;

                    dataGridView.DataSource = null;
                    dataGridView.DataSource = lista;
                    dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dataGridView.Columns[5].Visible =false;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[7].Visible = false;
                    dataGridView.Columns[8].Visible = false;
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            //Filtro Combo

            if (TieneCargadaCuota())
            {
                this.ComboActividad(false);
            }
            else
            {
                this.ComboActividad(true); 
            
            }

            //Coloreo si hay Planes de Cuota dados de baja
            foreach (DataGridViewRow row in dataGridView.Rows)
            {

                if (Convert.ToInt32(row.Cells["ESTADO"].Value) == 1)
                {

                    row.DefaultCellStyle.BackColor = Color.LightPink;

                }

            }


        }



        public string UltimaActividad()

        {   //Agrega todas las actividades en una lista, encuentra la ultima que no este dada de baja
            List<admDeportes.ItemComboString> Cuotas = new List<admDeportes.ItemComboString>();
            string result="";
            int cantidad=-1;
            string [] split;
            foreach( System.Windows.Forms.DataGridViewRow r in dataGridView.Rows )
            {
                if (r.Cells[1].Value.ToString().Contains("CUOTA"))
                {
                    admDeportes.ItemComboString i = new admDeportes.ItemComboString(r.Cells[6].Value.ToString(), r.Cells[1].Value.ToString());
                    Cuotas.Add(i);
                }
            }

            if (Cuotas.Count > 0)

                result = Cuotas.Find(x => x.ID == "") != null?Cuotas.Find(x => x.ID == "").Texto:"";
            if (result.Length > 40)
                result = result.Substring(0, 39);
           split = result.Split('-');
          
           result = split[0].ToString();
           
            return result;

        }




        private void ComboActividad(bool SoloCuotas)
        {
              string dato2 = "SELECT DESTINO, ID, ID_DESTINO FROM P_TMP_CURSOR('" +VGlobales.vp_role.TrimEnd().TrimStart()+ "')";
              string connectionString;
                DataSet ds2 = new DataSet();
                Datos_ini ini4 = new Datos_ini();
                getGrupo gg = new getGrupo();
                
                try
                {
                    FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                    cs.DataSource = ini4.Servidor;  cs.Port = int.Parse(ini4.Puerto);
                    cs.Database = ini4.Ubicacion;
                    cs.UserID = VGlobales.vp_username;
                    cs.Password = VGlobales.vp_password;
                    cs.Role = VGlobales.vp_role;
                    cs.Dialect = 3;
                    connectionString = cs.ToString();

                    using (FbConnection connection = new FbConnection(connectionString))
                    {
                        connection.Open();

                        FbTransaction transaction = connection.BeginTransaction();

                        //Carga COMBOBOX2

                        DataTable dt2 = new DataTable("DESTINOS");

                        dt2.Columns.Add("DESTINO", typeof(string));
                        dt2.Columns.Add("ID", typeof(string));
                        dt2.Columns.Add("ID_DESTINO", typeof(string));
                        ds2.Tables.Add(dt2);

                        FbCommand cmd2 = new FbCommand(dato2, connection, transaction);
                        FbDataReader reader4 = cmd2.ExecuteReader();

                        DataRow fila;

                        while (reader4.Read())
                        {

                            fila = dt2.NewRow();
                            fila["ID"] = reader4.GetString(reader4.GetOrdinal("ID")).Trim();
                            fila["DESTINO"] = reader4.GetString(reader4.GetOrdinal("DESTINO")).Trim() + "-" + reader4.GetString(reader4.GetOrdinal("ID_DESTINO")).Trim();
                            fila["ID_DESTINO"] = reader4.GetString(reader4.GetOrdinal("ID_DESTINO")).Trim();

                            //Si es solo cuotas solo muestras las opciones de "CUOTA"
                            //if (SoloCuotas)
                            //{


                            //    if (fila["DESTINO"].ToString().Contains("CUOTA MENO"))
                            //        dt2.Rows.Add(fila);
                            //    if (gg.get(COD_DTO, categoria_social) == 1) 
                            //    {   if (fila["DESTINO"].ToString().Contains("CUOTA SOCIO"))
                            //        dt2.Rows.Add(fila);
                            //    }
                            //    else
                            //    {
                            //       if (fila["DESTINO"].ToString().Contains("CUOTA INVITADO"))
                            //        dt2.Rows.Add(fila);
                            //    }

                            //}
                            //else
                            //{
                                dt2.Rows.Add(fila); 
                            
                            //}
                            
                        }
                        reader4.Close();

                        cbActividad.DataSource = dt2;

                        
                        cbActividad.DisplayMember = "DESTINO";

                        cbActividad.ValueMember = "ID";

                        cbActividad.SelectedIndex = -1;

                        transaction.Commit();
                    }
                }
                catch
                {
                    
                }

            }
        
        
        
        
        
        private void ComboActividad(int a )
        {
            string Query = "SELECT ID,DETALLE FROM SECTACT WHERE ROL='DEPORTES' AND DETALLE  NOT LIKE '%CUOTA%' and DETALLE NOT LIKE '%ATENCION AL PUBLICO%' AND DETALLE NOT LIKE '%TOALLAS%'  ORDER BY ID";

            cbActividad.DataSource = null;
            cbActividad.Items.Clear();
            cbActividad.DataSource = dlog.BO_EjecutoDataTable(Query);
            cbActividad.DisplayMember = "DETALLE";
            cbActividad.ValueMember = "ID";
            cbActividad.SelectedItem = 1;

            this.Seteo_Arancel();






        }

        private void getProfesionalArancel(int SECTACT, string CATSOC)
        {
            string Query = "select ID,PROFESIONAL from aranceles_servicios where SECTACT= " + SECTACT.ToString() +
                           " AND CATSOC=" + CATSOC;

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(Query).Select();

            if (foundRows.Length > 0)
            {
                arancelID = Int32.Parse(foundRows[0][0].ToString());
                Profesional = Int32.Parse(foundRows[0][1].ToString());
            }
            else
            {

                arancelID = 0;
                Profesional = 0;
            }


        }


        private void InicializarGP()
        { 
          DateTime hoy = System.DateTime.Now;
          
         
          tbAnioDto.Text = hoy.Year.ToString();
          tbMesDTO.Text =  hoy.Month.ToString();
          




        
        }

        #endregion
        #region Botones Y Combos
        private void CancelarBank_Click_1(object sender, EventArgs e)
        {
            
            
            int ID;
            DateTime hoy = System.DateTime.Now;
            

            
                
            
                

            if (dataGridView.SelectedRows.Count > 0)
            {
                int Estado=0;
                string Concepto = "";
                if (MessageBox.Show("¿Borro el Registro?", "BORRAR ACTIVIDAD", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ID = Int32.Parse(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
                    Concepto = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                    
                    //Estado, si es cuota es 1 , si es actividad es 0
                    // se saca 
                    //if (Concepto.Contains("CUOTA"))
                    //{
                    //    this.BorrarActividades(hoy);
                    //    MessageBox.Show("CUOTA Y ACTIVIDADES  BORRADA", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    {
                        Estado = 0;


                        dlog.BajaSociosActividad(ID, hoy, Estado);
                        MessageBox.Show("ACTIVIDAD BORRADA", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   
                    this.Refrescar_Grilla();
                }





            }

            else
            {
                MessageBox.Show("SELECCIONE UNA ACTIVIDAD\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void BorrarActividades(DateTime Fecha)

        {  int ID;
           String Concepto;
           int Estado;
          
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                ID        = Int32.Parse(row.Cells[0].Value.ToString());
                Concepto = row.Cells[1].Value.ToString();
                if (Concepto.Contains("CUOTA"))
                    Estado =1;
                else
                    Estado=0;

                dlog.BajaSociosActividad(ID, Fecha, Estado);

            }
        
        
        }

        private void NuevoBank_Click(object sender, EventArgs e)
        {


            gpValores.Visible = true;
            this.InicializarGP();
            MODO = "INSERT";
            dpFecha.Visible = true;
        }

        private void cbActividad_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (INICIO == false)
            {
                Seteo_Arancel();
            }
        }

        private void EditarBank_Click(object sender, EventArgs e)
        {

        }

        private void CancelarBank_Click(object sender, EventArgs e)
        {

        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int Estado;
            string Concepto =((System.Data.DataRowView)(cbActividad.SelectedItem)).Row.ItemArray[0].ToString();
            //Estado, si es cuota es 1 , si es actividad es 0
           

                  
         

                if (MessageBox.Show("¿Ingresar Actividad?", "INGRESO ACTIVIDAD", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int SEC_ACT = Int32.Parse(((System.Data.DataRowView)(cbActividad.SelectedItem)).Row.ItemArray[2].ToString());
                    DateTime fecha_dto = new DateTime(Int32.Parse(tbAnioDto.Text), Int32.Parse(tbMesDTO.Text), 1);

                    dlog.InsertSociosActividad(ID_HEAD,ROL.TrimEnd().TrimStart(), Nro_soc, Nro_dep, Barra, fecha_dto, categoria_social, Profesional, arancelID, Arancel, SEC_ACT, VGlobales.vp_username, DateTime.Parse(dpFecha.Text),0,Int32.Parse(tbDescuento.Text));

                    MessageBox.Show("ACTIVIDAD INGRESADA CON EXITO", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Refrescar_Grilla();
                }
                
            
            
            
                            
         }
        #endregion

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView.ClearSelection();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {

                if (Convert.ToInt32(row.Cells["ESTADO"].Value) == 1)
                {

                    row.DefaultCellStyle.BackColor = Color.LightPink;

                }

            }

        }

        private void admActividades_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

    }

    public class GridActividades
    {
        public int ID { get; set; }
        public string ACTIVIDAD { get; set; }
        public string PROFESIONAL { get; set; }
        public decimal ARANCEL { get; set; }
        public string FECHA { get; set; }
        public int ESTADO { get; set; }
        public string BAJA { get; set; }
        public int PROFESIONAL_ID { get; set; }

        public int SECTACT { get; set; }



    }
}