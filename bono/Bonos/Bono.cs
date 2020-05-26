using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS.bono
{
 
    public partial class Bono : Form
    {
        public List<SOCIOS.bono.DatoSocio> Datos;
        public SOCIOS.bono.handlerDatosSocios srvDatosSocio;
        public int Nro_Socio_titular;
         public int Nro_Dep_Titular;
         SOCIOS.edad srvEDad = new edad();
         BO.bo_ServiciosMedicos dlog = new BO.bo_ServiciosMedicos();

         public int Socios=0 ;
         public int Intercirculo=0;
         public int Invitado=0;
         
         public int MenorInvitado = 0;
         public int MenorInter    = 0;
         public int MenorSocio    = 0;

         public int MenorPaquete  = 0;
         public decimal SaldoIngreso = 0;

         public int DESTINO;
         public int PROFESIONAL;
        
        public List<SOCIOS.Turismo.GridPersona> listaPersonas ;
         public List<PagoBono> PagosBono;
       public  SOCIOS.IngresoBono ingreso;
       public  int Contralor=0;
       public string InfoTarjeta = "";

       public string PACIENTE_NOMBRE="";
       public string PACIENTE_DNI="";
       public int Cuenta_Contable = 0;
       public SOCIOS.bono.BonoUtils bonoService = new BonoUtils();
        public Bono()
        { 
        
        }
      
        public Bono(DataGridViewSelectedRowCollection Personas,string pSocTitular,string pdepTitular,bool pMulti)
        {
            InitializeComponent();
            Datos = new List<DatoSocio>();

            Nro_Socio_titular = Int32.Parse(pSocTitular);
            Nro_Dep_Titular = Int32.Parse(pdepTitular);

            this.Iniciar(Personas,pSocTitular,pdepTitular);
           
            this.Multiple_Seleccion(pMulti);
           
        }



    


        public Bono(string pSocTitular, string pdepTitular, bool pMulti)
        {
            InitializeComponent();
            Datos = new List<DatoSocio>();

            Nro_Socio_titular = Int32.Parse(pSocTitular);
            Nro_Dep_Titular = Int32.Parse(pdepTitular);
            this.Iniciar(pSocTitular, pdepTitular);
            this.Cargar_Servicios(Nro_Socio_titular.ToString(),Nro_Dep_Titular.ToString());
            
           
            this.Multiple_Seleccion(pMulti);
            dgvGrupo.DataSource = null;

        }

        public Bono(string pNRo_Soc, string pNro_Dep, string pBarra, string pSocTitular, string pdepTitular,bool pMulti)
        {
            InitializeComponent();
            Nro_Socio_titular = Int32.Parse(pSocTitular);
            Nro_Dep_Titular = Int32.Parse(pdepTitular);

            Datos = new List<DatoSocio>();
            this.Iniciar(pNRo_Soc, pNro_Dep, pBarra, pSocTitular, pdepTitular);
            this.Multiple_Seleccion(pMulti);
        
        }

        private void Iniciar(string pNRo_Soc,string pNro_Dep,string pBarra ,string pSocTitular,string pdepTitular )

        {

            this.DatosTitular(pSocTitular, pdepTitular);
            this.Cargar_Servicios(pNRo_Soc, pNro_Dep, pBarra, pSocTitular, pdepTitular);
            GrillaPersonas_Habilitados(true);
            

        
        }

        private void Cargar_Servicios(string NRO_SOC, string NRO_DEP, string BARRA, string NRO_SOC_TIT, string NRO_DEP_TIT)
        {
            string query = "SELECT * FROM P_OBTENER_FAMADH(" + NRO_SOC_TIT + "," + NRO_DEP_TIT + ") WHERE NRO_SOC=" + NRO_SOC + " AND NRO_DEP=" + NRO_DEP + " AND BARRA=" + BARRA;
          
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

                    dt1.Columns.Add("ID_TITULAR", typeof(string));
                    dt1.Columns.Add("NRO_SOC", typeof(string));
                    dt1.Columns.Add("NRO_DEP", typeof(string));
                    dt1.Columns.Add("BARRA", typeof(string));
                    dt1.Columns.Add("APELLIDO", typeof(string));
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("TIPO", typeof(string));
                    dt1.Columns.Add("NUM_DOC", typeof(string));
                    dt1.Columns.Add("ACRJP2", typeof(string));
                    dt1.Columns.Add("SOCIO", typeof(string));
                    dt1.Columns.Add("CAT_SOC", typeof(string));
                    dt1.Columns.Add("TABLA", typeof(string));
                    dt1.Columns.Add("EDAD", typeof(string));
                    dt1.Columns.Add("BAJA", typeof(string));
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID_TITULAR")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NRO_SOC")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("BARRA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("APELLIDO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TIPO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NUM_DOC")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("ACRJP2")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("SOCIO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("CAT_SOC")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TABLA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("EDAD")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("BAJA")).Trim()); 
                    }        


                    reader3.Close();
                    dgvGrupo.DataSource = dt1;

                    // Datos.Add(ds);
                    dgvGrupo.Columns[0].Visible = false;
                    dgvGrupo.Columns[1].Visible = false;
                    dgvGrupo.Columns[2].Visible = false;
                    dgvGrupo.Columns[3].Visible = false;
                    dgvGrupo.Columns[9].Visible = false;
                    // dgvGrupo.Columns[10].Visible = false;

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //Lleno Datos de Persona

            foreach (DataGridViewRow r in dgvGrupo.Rows)
            {
                if (r.Cells[0].Value != null)
                {
                    DatoSocio ds = new DatoSocio();
                    ds.ID_TITULAR = r.Cells[0].Value.ToString().Trim();
                    ds.NRO_SOCIO  = r.Cells[1].Value.ToString().Trim();
                    ds.NRO_DEP    = r.Cells[2].Value.ToString().Trim();
                    ds.BARRA      = r.Cells[3].Value.ToString().Trim();
                    ds.APELLIDO   = r.Cells[4].Value.ToString().Trim();
                    ds.NOMBRE     = r.Cells[5].Value.ToString().Trim();
                    ds.TIPO       = r.Cells[6].Value.ToString().Trim();
                    ds.NUM_DOC    = r.Cells[7].Value.ToString().Trim();
                    ds.ACRJP2     = r.Cells[8].Value.ToString().Trim();
                    ds.SOCIO      = r.Cells[9].Value.ToString().Trim();
                    ds.CAT_SOC    = r.Cells[10].Value.ToString().Trim();
                    ds.TABLA      = r.Cells[11].Value.ToString().Trim();
                    ds.EDAD       = r.Cells[12].Value.ToString().Trim();
                    
                    if (r.Cells[13].Value.ToString().Trim() == "NO")
                        ds.BAJA = "NO";
                    else
                        ds.BAJA = "SI";


                    ds = srvDatosSocio.ContactoPersona(ds);

                    Datos.Add(ds);
                }
                }

        }


        private void Cargar_Servicios(string NRO_SOC, string NRO_DEP)
        {
            string query = "SELECT * FROM P_OBTENER_FAMADH(" + NRO_SOC + "," + NRO_DEP + ")";

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

                    dt1.Columns.Add("ID_TITULAR", typeof(string));
                    dt1.Columns.Add("NRO_SOC", typeof(string));
                    dt1.Columns.Add("NRO_DEP", typeof(string));
                    dt1.Columns.Add("BARRA", typeof(string));
                    dt1.Columns.Add("APELLIDO", typeof(string));
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("TIPO", typeof(string));
                    dt1.Columns.Add("NUM_DOC", typeof(string));
                    dt1.Columns.Add("ACRJP2", typeof(string));
                    dt1.Columns.Add("SOCIO", typeof(string));
                    dt1.Columns.Add("CAT_SOC", typeof(string));
                    dt1.Columns.Add("TABLA", typeof(string));
                    dt1.Columns.Add("EDAD", typeof(string));
                    dt1.Columns.Add("BAJA", typeof(string));
                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("ID_TITULAR")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NRO_SOC")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("BARRA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("APELLIDO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TIPO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NUM_DOC")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("ACRJP2")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("SOCIO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("CAT_SOC")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TABLA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("EDAD")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("BAJA")).Trim());
                    }


                    reader3.Close();
                    dgvGrupo.DataSource = dt1;

                    // Datos.Add(ds);
                    dgvGrupo.Columns[0].Visible = false;
                    dgvGrupo.Columns[1].Visible = false;
                    dgvGrupo.Columns[2].Visible = false;
                    dgvGrupo.Columns[3].Visible = false;
                    dgvGrupo.Columns[9].Visible = false;
                    // dgvGrupo.Columns[10].Visible = false;

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //Lleno Datos de Persona

            foreach (DataGridViewRow r in dgvGrupo.Rows)
            {
                if (r.Cells[0].Value != null)
                {
                    DatoSocio ds = new DatoSocio();
                    ds.ID_TITULAR = r.Cells[0].Value.ToString().Trim();
                    ds.NRO_SOCIO = r.Cells[1].Value.ToString().Trim();
                    ds.NRO_DEP = r.Cells[2].Value.ToString().Trim();
                    ds.BARRA = r.Cells[3].Value.ToString().Trim();
                    ds.APELLIDO = r.Cells[4].Value.ToString().Trim();
                    ds.NOMBRE = r.Cells[5].Value.ToString().Trim();
                    ds.TIPO = r.Cells[6].Value.ToString().Trim();
                    ds.NUM_DOC = r.Cells[7].Value.ToString().Trim();
                    ds.ACRJP2 = r.Cells[8].Value.ToString().Trim();
                    ds.SOCIO = r.Cells[9].Value.ToString().Trim();
                    ds.CAT_SOC = r.Cells[10].Value.ToString().Trim();
                    ds.TABLA = r.Cells[11].Value.ToString().Trim();
                    ds.EDAD = r.Cells[12].Value.ToString().Trim();

                    if (r.Cells[13].Value.ToString().Trim() == "NO")
                        ds.BAJA = "NO";
                    else
                        ds.BAJA = "SI";


                    ds = srvDatosSocio.ContactoPersona(ds);

                    Datos.Add(ds);
                }
            }

        }




        private void DatosTitular(string pSocTitular,string pdepTitular)

        {
            srvDatosSocio = new handlerDatosSocios(pSocTitular, pdepTitular);

            Categoria.Text = srvDatosSocio.CAB.TipoTitular;
            nroSocio.Text = srvDatosSocio.CAB.NroSocioTitular;
            Beneficio.Text = srvDatosSocio.CAB.NroBeneficioTitular;
            Afiliado.Text = srvDatosSocio.CAB.NroAfiliadoTitular;
            Nombres.Text = srvDatosSocio.CAB.NombreTitular;
            Dni.Text = srvDatosSocio.CAB.Dni;
            Sexo.Text = srvDatosSocio.CAB.Sexo;
            domicilio.Text = srvDatosSocio.CAB.Domicilio;
            Cp.Text = srvDatosSocio.CAB.Localidad;
            Telefono.Text = srvDatosSocio.CAB.Telefonos;
            DEP.Text = srvDatosSocio.CAB.NroDepTitular;
        
        }
        private void Iniciar(DataGridViewSelectedRowCollection Personas, string pSocTitular, string pdepTitular)
        {
        

            //Datos Titular
            this.DatosTitular(pSocTitular, pdepTitular);

            // Origen Lista Personas, 1 : Grupo Familiar, 2 : Inv.Participativo, 3: No Socio / Otro Titular

            listaPersonas = new List<SOCIOS.Turismo.GridPersona>();
            
            //Grilla Personas 
          //  this.ActualizarGrilla(Personas);
            

            this.ActualizarGrillaMemoria(Personas,1);
                 
                    
                   
        
        }


        private void Iniciar(string pSocTitular, string pdepTitular)
        {


            //Datos Titular
            this.DatosTitular(pSocTitular, pdepTitular);
            listaPersonas = new List<SOCIOS.Turismo.GridPersona>();



        }




       
        
        public void ActualizarGrilla(DataGridViewSelectedRowCollection Personas)
        {
            DataTable dt1 = new DataTable("RESULTADOS");
            DataSet ds1 = new DataSet();
            dt1.Columns.Add("ID_TITULAR", typeof(string));
            dt1.Columns.Add("NRO_SOC", typeof(string));
            dt1.Columns.Add("NRO_DEP", typeof(string));
            dt1.Columns.Add("BARRA", typeof(string));
            dt1.Columns.Add("APELLIDO", typeof(string));
            dt1.Columns.Add("NOMBRE", typeof(string));
            dt1.Columns.Add("TIPO", typeof(string));
            dt1.Columns.Add("TEL", typeof(string));
            dt1.Columns.Add("EMAIL", typeof(string));
            dt1.Columns.Add("NUM_DOC", typeof(string));
            dt1.Columns.Add("ACRJP2", typeof(string));
            dt1.Columns.Add("SOCIO", typeof(string));
            dt1.Columns.Add("EDAD", typeof(string));
            ds1.Tables.Add(dt1);
            



            foreach (DataGridViewRow r in Personas)
            {

                DatoSocio ds = new DatoSocio();
                ds.ID_TITULAR = r.Cells[0].Value.ToString().Trim();
                ds.NRO_SOCIO = r.Cells[1].Value.ToString().Trim();
                ds.NRO_DEP = r.Cells[2].Value.ToString().Trim();
                ds.BARRA = r.Cells[3].Value.ToString().Trim();
                ds.APELLIDO = r.Cells[4].Value.ToString().Trim();
                ds.NOMBRE = r.Cells[5].Value.ToString().Trim();
                ds.TIPO = r.Cells[6].Value.ToString().Trim();
                ds.NUM_DOC = r.Cells[7].Value.ToString().Trim();
                ds.ACRJP2 = r.Cells[8].Value.ToString().Trim();
                ds.SOCIO = r.Cells[9].Value.ToString().Trim();
                ds.EDAD = r.Cells[10].Value.ToString().Trim();
                ds = srvDatosSocio.ContactoPersona(ds);


                
                dt1.Rows.Add(r.Cells[0].Value.ToString().Trim(),
                              r.Cells[1].Value.ToString().Trim(),
                              r.Cells[2].Value.ToString().Trim(),
                              r.Cells[3].Value.ToString().Trim(),
                              r.Cells[4].Value.ToString().Trim(),
                              r.Cells[5].Value.ToString().Trim(),
                              r.Cells[6].Value.ToString().Trim(),
                              ds.TELEFONO,
                              ds.MAIL,
                              r.Cells[7].Value.ToString().Trim(),
                              r.Cells[8].Value.ToString().Trim(),
                              r.Cells[9].Value.ToString().Trim(),
                              r.Cells[10].Value.ToString().Trim());

                Datos.Add(ds);
            }




            dgvGrupo.DataSource = dt1;


            dgvGrupo.Columns[0].Visible = false;
            dgvGrupo.Columns[1].Visible = false;
            dgvGrupo.Columns[2].Visible = false;
            dgvGrupo.Columns[3].Visible = false;
            dgvGrupo.Columns[9].Visible = false;
           // dgvGrupo.Columns[10].Visible = false;



        
        }


  

        public void ActualizarGrilla(DataGridViewRowCollection Personas, CabeceraTitular nuevo)
        {   

            

            DataTable dt1 = new DataTable("RESULTADOS");
            DataSet ds1 = new DataSet();
            dt1.Columns.Add("ID_TITULAR", typeof(string));
            dt1.Columns.Add("NRO_SOC", typeof(string));
            dt1.Columns.Add("NRO_DEP", typeof(string));
            dt1.Columns.Add("BARRA", typeof(string));
            dt1.Columns.Add("APELLIDO", typeof(string));
            dt1.Columns.Add("NOMBRE", typeof(string));
            dt1.Columns.Add("TIPO", typeof(string));
            dt1.Columns.Add("TEL", typeof(string));
            dt1.Columns.Add("EMAIL", typeof(string));
            dt1.Columns.Add("NUM_DOC", typeof(string));
            dt1.Columns.Add("ACRJP2", typeof(string));
            dt1.Columns.Add("SOCIO", typeof(string));

            ds1.Tables.Add(dt1);


            //Grilla Existente

            foreach (DataGridViewRow r in Personas)
            {

                DatoSocio ds = new DatoSocio();
                ds.ID_TITULAR = r.Cells[0].Value.ToString().Trim();
                ds.NRO_SOCIO = r.Cells[1].Value.ToString().Trim();
                ds.NRO_DEP = r.Cells[2].Value.ToString().Trim();
                ds.BARRA = r.Cells[3].Value.ToString().Trim();
                ds.APELLIDO = r.Cells[4].Value.ToString().Trim();
                ds.NOMBRE = r.Cells[5].Value.ToString().Trim();
                ds.TIPO = r.Cells[6].Value.ToString().Trim();
                ds.NUM_DOC = r.Cells[7].Value.ToString().Trim();
                ds.ACRJP2 = r.Cells[8].Value.ToString().Trim();
                ds.SOCIO = r.Cells[9].Value.ToString().Trim();

              //  ds = srvDatosSocio.ContactoPersona(ds);



                dt1.Rows.Add(r.Cells[0].Value.ToString().Trim(),
                              r.Cells[1].Value.ToString().Trim(),
                              r.Cells[2].Value.ToString().Trim(),
                              r.Cells[3].Value.ToString().Trim(),
                              r.Cells[4].Value.ToString().Trim(),
                              r.Cells[5].Value.ToString().Trim(),
                              r.Cells[6].Value.ToString().Trim(),
                              "-",
                              "-",
                              r.Cells[7].Value.ToString().Trim(),
                              r.Cells[8].Value.ToString().Trim(),
                              r.Cells[9].Value.ToString().Trim());

                Datos.Add(ds);
            }


            DatoSocio dn = new DatoSocio();
             dn.ID_TITULAR = nuevo.NroSocioTitular.ToString();
             dn.NRO_SOCIO = nuevo.NroSocioTitular.ToString();
             dn.NRO_DEP = nuevo.NroDepTitular.ToString();
             dn.BARRA = "0";
             dn.APELLIDO = nuevo.NombreTitular;
             dn.NOMBRE = "-";
             dn.TIPO = nuevo.TipoTitular;
             dn.NUM_DOC = nuevo.Dni;
             dn.ACRJP2 = nuevo.ACRJP2.ToString();
             dn.SOCIO = nuevo.NroSocioTitular.ToString();

           //   dn = srvDatosSocio.ContactoPersona(dn);

              dt1.Rows.Add(dn.ID_TITULAR,
                           dn.NRO_SOCIO,
                           dn.NRO_DEP,
                           dn.BARRA,
                           dn.APELLIDO,
                           dn.NOMBRE,
                           dn.TIPO,
                           dn.TELEFONO,
                           dn.MAIL,
                          dn.NUM_DOC,
                           dn.ACRJP2,
                           dn.SOCIO);

              Datos.Add(dn);







            dgvGrupo.DataSource = dt1;


            dgvGrupo.Columns[0].Visible = false;
            dgvGrupo.Columns[1].Visible = false;
            dgvGrupo.Columns[2].Visible = false;
            dgvGrupo.Columns[3].Visible = false;
            dgvGrupo.Columns[9].Visible = false;
            dgvGrupo.Columns[10].Visible = false;




        }


        public void ActualizarGrillaMemoria(DataGridViewSelectedRowCollection Personas,int Origen)
        {
           // listaPersonas.RemoveAll(x => x.Origen == Origen);

            
         

            foreach (DataGridViewRow r in Personas)
            {

                DatoSocio ds = new DatoSocio();
                ds.ID_TITULAR = r.Cells[0].Value.ToString().Trim();
                ds.NRO_SOCIO = r.Cells[1].Value.ToString().Trim();
                ds.NRO_DEP = r.Cells[2].Value.ToString().Trim();
                ds.BARRA = r.Cells[3].Value.ToString().Trim();
                ds.APELLIDO = r.Cells[4].Value.ToString().Trim();
                ds.NOMBRE = r.Cells[5].Value.ToString().Trim();
                ds.TIPO = r.Cells[6].Value.ToString().Trim();
                ds.NUM_DOC = r.Cells[7].Value.ToString().Trim();
                ds.ACRJP2 = r.Cells[8].Value.ToString().Trim();
                ds.SOCIO = r.Cells[9].Value.ToString().Trim();
                ds.NACIMIENTO = r.Cells[10].Value.ToString().Trim();
               // ds.EDAD = r.Cells[12].Value.ToString().Trim();

                ds = srvDatosSocio.ContactoPersona(ds);
                
               SOCIOS.Turismo.GridPersona item = new SOCIOS.Turismo.GridPersona();
               item.Nombre          =  ds.NOMBRE;
               item.Apellido        =  ds.APELLIDO;
               item.Dni             =  ds.NUM_DOC;
               item.Mail            =  ds.MAIL;
               item.Telefono        =  ds.TELEFONO;
               item.Nacimiento      = ds.NACIMIENTO;
               item.NroSocioTitular = Int32.Parse(ds.ID_TITULAR);
               item.NroSocio        = Int32.Parse(ds.NRO_SOCIO);
               item.NroDep          = Int32.Parse(ds.NRO_DEP);
               item.Barra           = Int32.Parse(ds.BARRA);
               item.Tipo            = ds.TIPO;
               item.Origen          = Origen;
               item.Edad            = ds.EDAD;

               SOCIOS.Turismo.GridPersona testRepetido = new SOCIOS.Turismo.GridPersona();
                if (listaPersonas != null)
                 testRepetido = listaPersonas.Where(x => (x.NroSocio == item.NroSocio && x.NroDep == item.NroDep && x.Barra == item.Barra && x.Origen==item.Origen)).FirstOrDefault();

               if (testRepetido == null)
                   listaPersonas.Add(item);

             

       

                Datos.Add(ds);
            }




            dgvGrupo.DataSource = null;



            dgvGrupo.DataSource = listaPersonas;

            dgvGrupo.Columns[4].Visible = false;
            dgvGrupo.Columns[5].Visible = false;
            dgvGrupo.Columns[6].Visible = false;
            dgvGrupo.Columns[7].Visible = false;
            dgvGrupo.Columns[8].Visible = false;
         




        }



        public void ActualizarGrillaMemoria_Participativos(DataGridViewSelectedRowCollection Personas, int Origen)
        {
           
           // listaPersonas.RemoveAll(x => x.Origen == Origen);




            foreach (DataGridViewRow r in Personas)
            {

                



                SOCIOS.Turismo.GridPersona item = new SOCIOS.Turismo.GridPersona();
                item.Nombre = r.Cells[1].Value.ToString().Trim();
                item.Apellido = r.Cells[2].Value.ToString().Trim();
                item.Dni = r.Cells[0].Value.ToString().Trim();
                item.Mail = r.Cells[10].Value.ToString().Trim();
                item.Telefono = r.Cells[9].Value.ToString().Trim();
                item.Nacimiento = r.Cells[3].Value.ToString().Trim(); 
                
                item.NroSocioTitular =  Int32.Parse(r.Cells[5].Value.ToString().Trim());
                item.NroSocio        =  Int32.Parse( r.Cells[5].Value.ToString().Trim());
                item.NroDep          =  Int32.Parse( r.Cells[6].Value.ToString().Trim());
                item.Barra           =  Int32.Parse(r.Cells[7].Value.ToString().Trim());
                item.Tipo = r.Cells[4].Value.ToString().Trim();
                item.Origen = Origen;
                item.Edad = srvEDad.CALCULAR(item.Nacimiento).ToString();


                //filtro que ya no este

                var testRepetido = listaPersonas.Where(x => (x.NroSocio == item.NroSocio && x.NroDep == item.NroDep && x.Barra == item.Barra && x.Origen == item.Origen && x.Nombre == item.Nombre)).FirstOrDefault();
                
                if (testRepetido == null)
                    listaPersonas.Add(item);





              
            }




            dgvGrupo.DataSource = null;
            dgvGrupo.DataSource = listaPersonas;

            dgvGrupo.Columns[4].Visible = false;
            dgvGrupo.Columns[5].Visible = false;
            dgvGrupo.Columns[6].Visible = false;
            dgvGrupo.Columns[7].Visible = false;
            dgvGrupo.Columns[8].Visible = false;





        }



        public void ActualizarGrillaMemoria_DNI(CabeceraTitular tit)
        {






            if (tit == null)
                throw new Exception("El Dni Ingresado No Corresponde a una Persona ");
                
                SOCIOS.Turismo.GridPersona item = new SOCIOS.Turismo.GridPersona();
                item.Nombre = tit.NombreTitular;
                item.Apellido = tit.ApellidoTitular;
                item.Dni = tit.Dni;
                item.Mail = "";
                item.Telefono = tit.Telefonos;
                item.Nacimiento = tit.FechaNac;
                if (item.Nacimiento.Length != 0)
                {
                    item.Edad = (System.DateTime.Now - DateTime.Parse(item.Nacimiento)).Days.ToString();
                    if (item.Edad.Length > 0)
                        item.Edad = Decimal.Round(Int32.Parse(item.Edad) / 365).ToString(); 
                }
                item.NroSocioTitular =Int32.Parse( tit.NroSocioTitular);
                item.NroSocio = Int32.Parse(tit.NroSocioTitular);
                item.NroDep = Int32.Parse(tit.NroDepTitular);
                item.Barra = Int32.Parse("0");
                item.Tipo =   tit.TipoTitular;
                if (item.Tipo.Contains("NO SOCIO"))
                    item.Origen = 3;
                else
                    item.Origen = 1;


                var testRepetido = listaPersonas.Where(x => (x.NroSocio == item.NroSocio && x.NroDep == item.NroDep && x.Barra == item.Barra && x.Origen == item.Origen)).FirstOrDefault();

                if (testRepetido == null)
                    listaPersonas.Add(item);

            


               

            




            dgvGrupo.DataSource = null;
            dgvGrupo.DataSource = listaPersonas;

            dgvGrupo.Columns[4].Visible = false;
            dgvGrupo.Columns[5].Visible = false;
            dgvGrupo.Columns[6].Visible = false;
            dgvGrupo.Columns[7].Visible = false;
            dgvGrupo.Columns[8].Visible = false;





        }


       



        public void ActualizarGrillaMemoria(DataGridViewRowCollection Personas, CabeceraTitular nuevo)
        {

                       


            DatoSocio dn = new DatoSocio();
            dn.ID_TITULAR = nuevo.NroSocioTitular.ToString();
            dn.NRO_SOCIO = nuevo.NroSocioTitular.ToString();
            dn.NRO_DEP = nuevo.NroDepTitular.ToString();
            dn.BARRA = "0";
            dn.APELLIDO = nuevo.NombreTitular;
            dn.NOMBRE = "-";
            dn.TIPO = nuevo.TipoTitular;
            dn.NUM_DOC = nuevo.Dni;
            dn.ACRJP2 = nuevo.ACRJP2.ToString();
            dn.SOCIO = nuevo.NroSocioTitular.ToString();

            //   dn = srvDatosSocio.ContactoPersona(dn);





        }





        public int PersonasControl()

        {
            return dgvGrupo.Rows.Count;
        }

        public DataGridView gridPersonas()
        {
            return dgvGrupo;
        
        }


        public void SetPaciente()

        {
            if (dgvGrupo.Rows.Count > 0)
            {
                PACIENTE_NOMBRE = dgvGrupo.Rows[0].Cells[4].Value.ToString() + "," + dgvGrupo.Rows[0].Cells[5].Value.ToString();
                PACIENTE_DNI = dgvGrupo.Rows[0].Cells[7].Value.ToString();
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void lbNombre_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lbDni_Click(object sender, EventArgs e)
        {

        }

        private void lbEmail_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lbTelefono_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Sexo_Click(object sender, EventArgs e)
        {

        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            List<DatoSocio> seleccion = new List<DatoSocio>();
           

            bono.PersonasBono pb = new PersonasBono(srvDatosSocio.CAB.NroSocioTitular, srvDatosSocio.CAB.NroDepTitular, seleccion);
            
            DialogResult res = pb.ShowDialog();

            if (res == DialogResult.OK)
            {
               // this.ActualizarGrilla(pb.Seleccion);
                this.ActualizarGrillaMemoria(pb.Seleccion,1);
            }

        }

        public void mostrarPersonas(bool mostrar)

        {
         btnPersonas.Visible =mostrar;

        }

        private void btnAddDNI_Click(object sender, EventArgs e)
        {
            
              //this.AgregarPersona(srvDatosSocio.PersonaXdni(lbDni.Text));
            try
            {
                this.ActualizarGrillaMemoria_DNI(srvDatosSocio.PersonaXdni(lbDni.Text));
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AgregarPersona(CabeceraTitular cab)
        {
            if (cab == null)
                return;

            //DataTable dt1 = new DataTable();

       

            //dt1.Columns.Add( new DataColumn("ID_TITULAR"));
            //dt1.Columns.Add( new DataColumn("NRO_SOC"));
            //dt1.Columns.Add(new DataColumn("NRO_DEP"));
            // dt1.Columns.Add( new DataColumn("BARRA"));
            // dt1.Columns.Add( new DataColumn("APELLIDO"));
            //dt1.Columns.Add( new DataColumn("NOMBRE"));
            // dt1.Columns.Add( new DataColumn("TIPO"));
      
            //dt1.Columns.Add( new DataColumn("NUM_DOC"));
            //dt1.Columns.Add( new DataColumn("ACRJP2"));
            //dt1.Columns.Add( new DataColumn("SOCIO"));


            //object[] RowValues = { "", "", "", "", "", "", "", "", "", "" };


            //RowValues[0] = cab.NroSocioTitular;
            //RowValues[1] = cab.NroSocioTitular;
            //RowValues[2] = cab.NroDepTitular;
            //RowValues[3] = "0";
            //RowValues[4] = cab.NombreTitular;
            //RowValues[5] = cab.TipoTitular;
            //RowValues[6] = cab.Telefonos;
            //RowValues[7] = "";
            //RowValues[8] = cab.ACRJP2;
            //RowValues[9] = cab.NroSocioTitular;

            //DataRow dRow;
            //dRow = dt1.Rows.Add(RowValues);



            DataTable dt = dgvGrupo.DataSource as DataTable;
            dt.Rows.Add(cab.NroSocioTitular, cab.NroSocioTitular, cab.NroDepTitular, 0, cab.NombreTitular, cab.TipoTitular, cab.Telefonos, "", cab.ACRJP2, cab.NroSocioTitular);
           // dgvGrupo.Rows.Add(cab.NroSocioTitular, cab.NroSocioTitular, cab.NroDepTitular, 0, cab.NombreTitular, cab.TipoTitular, cab.Telefonos, "", cab.ACRJP2, cab.NroSocioTitular);
           // dgvGrupo.Rows.Add(RowValues);
            dgvGrupo.DataSource = dt;
        }

        private void Multiple_Seleccion(bool muestro)
        {
            btnPersonas.Visible = muestro;
            lbDni.Visible = muestro;
            btnAddDNI.Visible = muestro;
            lbTitNoSoc.Visible = muestro;
        
        }

        public void CalcularCantidadSociosGrupo(string tipoBono)
        {   
            int TopeEdad;

            //if (tipoBono == "PAQUETE")
            //   TopeEdad = 3;
            //else
            //    TopeEdad =18;

            TopeEdad = 3; // Tope ,se cambia a 3 para todos, no solo para paquete (antes 18 hoteles, 2 paquete )
           
            Socios        = 0;
            MenorSocio    = 0;
            Invitado      = 0;
            MenorInvitado = 0;
            Intercirculo  = 0;
            MenorInter    = 0;
            // los menores paquete, son personas entre 3 y 10 años . 
            MenorPaquete = 0;

            bool ControlEdad = false;

            foreach (SOCIOS.Turismo.GridPersona item in listaPersonas)
            {


                if (item.Edad == null)
                    throw new Exception("Existen Personas Sin Edad Cargada en la Lista De Personas");


                if (item.NroDep == 12)
                {
                    item.Tipo = "NO SOCIO";
                    item.Origen = 3;
                }

                if ( item.Origen ==1) //Origen 1, familiares, Socios
                {

                   Socios      = this.StatsTipoMayor(Socios, item.Edad, TopeEdad);

                   if (Control_Edad(item.Barra,item.Tipo) ==true && (tipoBono != "PAQUETE"))
                      MenorSocio  =  this.StatsTipoMenor(MenorSocio, item.Edad, TopeEdad);

                }
                else
                {
                    if (!item.Tipo.Contains("INTER"))
                    {

                       Invitado      =   this.StatsTipoMayor(Invitado, item.Edad, TopeEdad);
                       if (Control_Edad(item.Barra, item.Tipo) == true && (tipoBono != "PAQUETE"))
                            MenorInvitado =   this.StatsTipoMenor(MenorInvitado, item.Edad, TopeEdad);
                    }

                    else
                    {
                       Intercirculo   =   this.StatsTipoMayor(Intercirculo, item.Edad, TopeEdad);
                      if (tipoBono != "PAQUETE")
                       MenorInter     =   this.StatsTipoMenor(MenorInter, item.Edad, TopeEdad);
                        
                    
                    }
                
                }
           
               
            
            
            }

            MenorPaquete =  listaPersonas.Where(v=>v.Edad.Length >0).Where(x => ( Int32.Parse(x.Edad) >= 3 && Int32.Parse(x.Edad) < 11)).Count();



        }

        public bool Control_Edad(int Barra, string Tipo)

        {
            bool Control=false;

            if (Tipo.Contains("FAM") && Barra > 3)
                Control = true;

            if (Tipo.Contains("ADH") && Barra > 2)
                Control = true;
            if (Tipo.Contains("NO SOCIO") && Barra>2)
                Control =true;
            if (Tipo.Contains("EMP") && Barra > 2)
                Control = true;


            return Control;
            
        
        }

        private int StatsTipoMayor(int Tipo, string Edad, int Tope)

        {

            //sin edad, no cuenta el menor
            if (Edad == null)

               return    Tipo + 1;
            else
            {
                if (Edad.Length > 0)
                {
                    if (Int32.Parse(Edad) >= Tope)
                    {
                        return Tipo + 1;
                    }
                    else
                    {
                        return Tipo +  0;

                    }

                }

                else
                {
                    return Tipo + 1;

                }
            }
        
        }

        private int StatsTipoMenor( int Menor, string Edad, int Tope)
        {

            //sin edad, no cuenta el menor
            if (Edad == null )

                throw new Exception("Falta Cargar Edadades de  Socio/s");

            else
            {
                if (Edad.Length > 0)
                {
                    if (Int32.Parse(Edad) >= Tope)
                    {
                        return Menor +  0;
                    }
                    else
                    {
                        return Menor + 1;

                    }

                }

                else
                {
                    return 0;

                }
            }

        }



        public void GrillaPersonas_Habilitados(bool vista)
        {
            Socios        = 0;
            Invitado      = 0;
            Intercirculo  = 0;
            MenorInter    = 0;
            MenorSocio    = 0;
            MenorInvitado = 0;
            lbDni.Text = "";


            CleanGrid.Enabled = vista;
            btnPersonas.Enabled = vista;
            InvParticipativos.Enabled = vista;
            lbDni.Enabled = vista;
            btnAddDNI.Enabled = vista;
        
        }







        private void InvParticipativos_Click(object sender, EventArgs e)
        {
            
            bono.ParticipativoBono pb = new ParticipativoBono(srvDatosSocio.CAB.NroSocioTitular, srvDatosSocio.CAB.NroDepTitular);

            DialogResult res = pb.ShowDialog();
            if (res == DialogResult.OK)
            {
                // this.ActualizarGrilla(pb.Seleccion);
                this.ActualizarGrillaMemoria_Participativos(pb.Seleccion, 2);
            }
        }

        public int CantidadTotalPersonas()

        {
            return dgvGrupo.Rows.Count;
        
        }

        private void CleanGrid_Click(object sender, EventArgs e)
        {
            listaPersonas = new List<SOCIOS.Turismo.GridPersona>();
            Datos = new List<DatoSocio>();
            dgvGrupo.DataSource = null;

            
        }


        public void IngresoCaja(int BONO,string DNI,string NOMBRE,string APELLIDO,int NRO_SOCIO,int NRO_DEP, int BARRA,string Adicional)


        {
            this.Ingreso(BONO, DNI, NOMBRE, APELLIDO, NRO_SOCIO, NRO_DEP, BARRA, 1);
            this.Ingreso(BONO, DNI, NOMBRE, APELLIDO, NRO_SOCIO, NRO_DEP, BARRA, 2);

            this.Ingreso(BONO, DNI, NOMBRE, APELLIDO, NRO_SOCIO, NRO_DEP, BARRA, 3);






        }


        private void Ingreso(int BONO, string DNI, string NOMBRE, string APELLIDO, int NRO_SOCIO, int NRO_DEP, int BARRA,int Tipo)

        {
            int NRO_SOCIO_ADH = 0;
            int NRO_DEP_ADH = 0;
            decimal Monto = 0;
            string QUERY = "";
            string Mensaje = "";
            decimal Interes=0;

            //parche para ADH
            if (NRO_DEP == 978)
            {
                NRO_SOCIO_ADH = NRO_SOCIO;
                NRO_DEP_ADH = NRO_DEP;

            }

            //Calculo que cuota es la de efectivo
            int ID_CUOTA = 0;
            decimal SaldoRestante = 0;

            if (Tipo == 1) //Efectivo
            {
                QUERY = "select ID,MONTO,Interes from PAGOS_BONO WHERE TIPOPAGO=1 AND BONO   =" + BONO.ToString() + "AND ROL='" + VGlobales.vp_role + "'";
                Mensaje = "Efectivo, ";
            }
            else if (Tipo == 2) // Debito
            {
                QUERY = "select ID,MONTO,Interes from PAGOS_BONO WHERE (TIPOPAGO=2 or TIPOPAGO=9) AND BONO   =" + BONO.ToString() + "AND ROL='" + VGlobales.vp_role + "'"; ;
                Mensaje = "Tarjeta Debito, ";

            }
            else  // Credito
            {
                QUERY = "select ID,MONTO,Interes from PAGOS_BONO WHERE (TIPOPAGO=3 or TIPOPAGO=10) AND BONO   =" + BONO.ToString() + "AND ROL='" + VGlobales.vp_role + "'"; ;
                
                Mensaje = "Tarjeta Credito, "+ InfoTarjeta;
            }

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                ID_CUOTA = Int32.Parse(foundRows[0][0].ToString());
                Monto = Decimal.Round(decimal.Parse(foundRows[0][1].ToString()), 2);
                if (foundRows[0][2].ToString().Length>0)
                        Interes  = Decimal.Round(decimal.Parse(foundRows[0][2].ToString()), 2);
            }

            if (ID_CUOTA != 0)
            {
                Mensaje = " Bono Nro: " + BONO.ToString() + " " +  Mensaje;

                if (Tipo == 3)
                {
                    this.IngresoCredito(ID_CUOTA, BARRA, NRO_SOCIO_ADH, NRO_DEP_ADH, DNI, NOMBRE, APELLIDO, BONO, Monto, Interes, Mensaje);
                }
                else
                {
                    ingreso = new IngresoBono(ID_CUOTA, VGlobales.vp_role, false, Monto, Nro_Socio_titular, Nro_Dep_Titular, BARRA, NRO_SOCIO_ADH, NRO_DEP_ADH, DNI, NOMBRE, APELLIDO, DESTINO, PROFESIONAL, Mensaje, BONO);
                }
            
            }


        
        }

        private void IngresoDebito()

        { 
        
        }

        private void IngresoCredito(int ID_CUOTA,int BARRA,int NRO_SOCIO_ADH,int NRO_DEP_ADH,string DNI, string NOMBRE,string APELLIDO,int BONO, decimal Tarjeta,decimal Tarjeta_Interes,string Mensaje)
        {

            string Mensaje_Tarjeta = "T.C: $" + Tarjeta + " " + Mensaje;
            string Mensaje_Interes = "T.C: $" + Tarjeta_Interes + " " + Mensaje;

            ingreso = new IngresoBono(ID_CUOTA, VGlobales.vp_role, false,Tarjeta, Nro_Socio_titular, Nro_Dep_Titular, BARRA, NRO_SOCIO_ADH, NRO_DEP_ADH, DNI, NOMBRE, APELLIDO, DESTINO, PROFESIONAL,Mensaje_Tarjeta, BONO);
            ingreso = new IngresoBono(ID_CUOTA, VGlobales.vp_role, false,Tarjeta_Interes, Nro_Socio_titular, Nro_Dep_Titular, BARRA, NRO_SOCIO_ADH, NRO_DEP_ADH, DNI, NOMBRE, APELLIDO, DESTINO, PROFESIONAL, Mensaje_Interes, BONO);
        
        }

        private void dgvGrupo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvGrupo.Rows[e.RowIndex];// get you required index
                // check the cell value under your specific column and then you can toggle your colors
                if (row.Cells[9].Value.ToString().Length == 0)
                    row.DefaultCellStyle.BackColor = Color.Yellow;
            }
            catch (Exception ex)
            {


            }
        }

        public int get_Dni()
        {
            return Int32.Parse(Dni.Text);
        
        }
       

    }

    
}

    


