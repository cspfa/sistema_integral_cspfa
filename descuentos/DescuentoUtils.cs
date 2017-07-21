using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;
using System.Data;

namespace SOCIOS.descuentos
{

    public class ArancelesCuota

    {
        public int      Profesional { get; set; }
        public int      SecAct      { get; set; }
        public string   Detalle     {get;set;}
        public decimal  Arancel      { get; set; }
        
 


    
    
    }

    public class OBS_DESCUENTOS
    {
      public int     ID   {get; set; }
      public string  OBS  {get; set; }
    }

    public class TXT_Group
    {
        public int CRJP { get; set; }
        public int CODCC {get;set;}
    
    }

    public class DescuentoUtils
    {
        bo dlog = new bo();
        SOCIOS.arancel arancelService = new arancel();
        TXT_Utils txt_utils = new TXT_Utils();

        public List<DtoDeportes> getDto_Deportes(int Tipo,string pROL)
        {
            List<DtoDeportes> lista = new List<DtoDeportes>();
            this.SeteoArancelesDeportes();
            



            string query = @"select T.ID_TITULAR ID_SOCIO ,T.NUM_DOC DOC_TIT, T.NOM_SOC NOM_TIT, T.APE_SOC APE_TIT , T.PAR PAR,T.AAR AAR, T.ACRJP1 ACRJP1, T.ACRJP2 ACRJP2,T.ACRJP3 ACRJP3,T.PCRJP1 PCRJP1,T.PCRJP2 PCRJP2,T.PCRJP3 PCRJP3 ,
                                   D.Nombre NOMBRE, D.Apellido  APELLIDO  ,D.NRO_SOCIO NRO_SOCIO, D.NRO_DEP NRO_DEP, D.BARRA BARRA  , SA.PROFESIONAL PROF , SA.SECTACT SECTACT,S.DETALLE DETALLE,D.DNI DNI, D.ROL ROL
                                   from Titular T,    Deportes_adm D  , SOCIO_ACTIVIDADES SA   , Sectact S 
                                   where T.id_titular= D.ID_TITULAR       and SA.ID_DEPORTE = D.ID  
                                   AND (SA.F_UPDATE IS NULL OR (SA.F_UPDATE IS NOT NULL AND SA.ESTADO=1))
                                   AND (D.FE_BAJA IS NULL)  and SA.SECTACT = S.ID                                         ";
            if (pROL.Length > 1)
            {
                query = query + " and D.ROL='" + pROL +"'";
            
            }
            if (Tipo == (int)TIPO_ACTIVIDAD.ACTIVO)
            {
                query = query + "  AND T.AAR = 1  ";
            }
            else if (Tipo == (int)TIPO_ACTIVIDAD.PASIVO)
            {
                query = query + " AND T.PAR = 2  ";
            }
 


            query = query + " order by T.ID_TITULAR ";






            //MessageBox.Show(query);

            string connectionString;

            DataSet ds1 = new DataSet();

            Datos_ini ini3 = new Datos_ini();


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
                dt1.Columns.Add("DOC_TIT", typeof(string));
                dt1.Columns.Add("NOM_TIT", typeof(string));
                dt1.Columns.Add("APE_TIT", typeof(string));
                dt1.Columns.Add("PAR", typeof(string));
                dt1.Columns.Add("AAR", typeof(string));
                dt1.Columns.Add("ACRJP1", typeof(string));
                dt1.Columns.Add("ACRJP2", typeof(string));
                dt1.Columns.Add("ACRJP3", typeof(string));

                dt1.Columns.Add("PCRJP1", typeof(string));
                dt1.Columns.Add("PCRJP2", typeof(string));
                dt1.Columns.Add("PCRJP3", typeof(string));
                dt1.Columns.Add("NOMBRE", typeof(string));
                dt1.Columns.Add("APELLIDO", typeof(string));
                dt1.Columns.Add("NRO_SOC", typeof(string));
                dt1.Columns.Add("NRO_DEP", typeof(string));
                dt1.Columns.Add("BARRA", typeof(string));
                dt1.Columns.Add("PROF", typeof(string));
                dt1.Columns.Add("SECTACT", typeof(string));
                dt1.Columns.Add("DETALLE", typeof(string));
                dt1.Columns.Add("DNI", typeof(string));
                dt1.Columns.Add("ROL", typeof(string));
                ds1.Tables.Add(dt1);

                FbCommand cmd = new FbCommand(query, connection, transaction);

                FbDataReader reader3 = cmd.ExecuteReader();

                while (reader3.Read())
                {

                    DtoDeportes item = new DtoDeportes();

                    int Prof = Int32.Parse(reader3.GetString(reader3.GetOrdinal("PROF")).Trim());
                    int SectAct = Int32.Parse(reader3.GetString(reader3.GetOrdinal("SECTACT")).Trim());

                    var Cuota = aranceles.Where(x => (x.SecAct == SectAct && x.Profesional == Prof)).FirstOrDefault();
                    if (Cuota != null)
                    {

                        item.Tipo = Cuota.Detalle;
                        item.Monto = Cuota.Arancel;
                        
                        item.Id_Socio = Int32.Parse(reader3.GetString(reader3.GetOrdinal("ID_SOCIO")).Trim());

                        item.DNI_TTULAR     = reader3.GetString(reader3.GetOrdinal("DOC_TIT"));
                        item.NOMBRE_TITULAR = reader3.GetString(reader3.GetOrdinal("NOM_TIT"));
                        item.APELLIDO_TITULAR = reader3.GetString(reader3.GetOrdinal("APE_TIT"));

                        item.par = Int32.Parse(reader3.GetString(reader3.GetOrdinal("PAR")).Trim());
                        item.aar = Int32.Parse(reader3.GetString(reader3.GetOrdinal("AAR")).Trim());
                        item.acrjp1 = Int32.Parse(reader3.GetString(reader3.GetOrdinal("ACRJP1")).Trim());
                        item.acrjp2 = Int32.Parse(reader3.GetString(reader3.GetOrdinal("ACRJP2")).Trim());
                        item.acrjp3 = Int32.Parse(reader3.GetString(reader3.GetOrdinal("ACRJP3")).Trim());

                        item.pcrjp1 = Int32.Parse(reader3.GetString(reader3.GetOrdinal("PCRJP1")).Trim());
                        item.pcrjp2 = Int32.Parse(reader3.GetString(reader3.GetOrdinal("PCRJP2")).Trim());
                        item.pcrjp3 = Int32.Parse(reader3.GetString(reader3.GetOrdinal("PCRJP3")).Trim());

                        item.Nombre_Apellido = reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim().ToString().TrimEnd().TrimStart() + reader3.GetString(reader3.GetOrdinal("APELLIDO")).Trim().ToString().TrimEnd().TrimStart();
                        item.DNI = reader3.GetString(reader3.GetOrdinal("DNI"));
                        item.Nro_Socio = Int32.Parse(reader3.GetString(reader3.GetOrdinal("NRO_SOCIO")).Trim());
                        item.Nro_Dep = Int32.Parse(reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim());
                        item.Barra = Int32.Parse(reader3.GetString(reader3.GetOrdinal("BARRA")).Trim());
                        item.DETALLE = reader3.GetString(reader3.GetOrdinal("DETALLE"));
                        item.DNI = reader3.GetString(reader3.GetOrdinal("DNI"));
                        item.ROL = reader3.GetString(reader3.GetOrdinal("ROL"));




                        lista.Add(item);

                    }




                }



               
                //reader3.Close();



                //transaction.Commit();


                return lista;




            }




        }

        private List<ArancelesCuota> aranceles = new List<ArancelesCuota>();

        private void SeteoArancelesDeportes()
        {
            string Query = "select S.Profesional PROF ,S.SectAct SECTACT ,A.DEtalle DETA from socio_actividades S ,sectact A where  S.Sectact= A.id  and  A.detalle like '%CUOTA%'     group by S.Profesional,S.SectAct,A.DEtalle";
           

            //MessageBox.Show(query);

            string connectionString;

            DataSet ds1 = new DataSet();

            Datos_ini ini3 = new Datos_ini();


            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini3.Servidor; //cs.Port = int.Parse(ini3.Puerto);
            cs.Database = ini3.Ubicacion;
            cs.UserID = VGlobales.vp_username;
            cs.Password = VGlobales.vp_password;
            cs.Role = VGlobales.vp_role;
            cs.Dialect = 3;
            connectionString = cs.ToString();
            int Grupo;

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();

                FbTransaction transaction = connection.BeginTransaction();

                DataTable dt1 = new DataTable("RESULTADOS");

                dt1.Columns.Add("PROF", typeof(string));
                dt1.Columns.Add("SECTACT", typeof(string));
                dt1.Columns.Add("DETA", typeof(string));

                ds1.Tables.Add(dt1);

                FbCommand cmd = new FbCommand(Query, connection, transaction);

                FbDataReader reader3 = cmd.ExecuteReader();

                while (reader3.Read())
                {

                    ArancelesCuota item = new ArancelesCuota();
                    item.Profesional = Int32.Parse(reader3.GetString(reader3.GetOrdinal("PROF")).Trim());
                    item.SecAct = Int32.Parse(reader3.GetString(reader3.GetOrdinal("SECTACT")).Trim());
                    item.Detalle = reader3.GetString(reader3.GetOrdinal("DETA")).Trim();
                    getGrupo gg = new getGrupo();

                    if (item.Detalle.Contains("SOCIO"))
                        Grupo = 1;
                    else
                        Grupo = 3;

                    item.Arancel = arancelService.valorGrupo(item.SecAct, Grupo, item.Profesional);

                   



                    aranceles.Add(item);






                }




                //reader3.Close();



                //transaction.Commit();





            }
        }


        private decimal MontoCuota(int ID)
        {
            decimal Monto = 0;
            string Query = "SELECT SECTACT.DETALLE ACTIVIDAD ,SOCIO_ACTIVIDADES.ARANCEL MONTO  " +
                             "  FROM   SOCIO_ACTIVIDADES ,PROFESIONALES,SECTACT    WHERE    " +
                             "  SOCIO_ACTIVIDADES.PROFESIONAL=PROFESIONALES.ID " +
                             " AND      SOCIO_ACTIVIDADES.SECTACT    =   SECTACT.ID   " +
                            " AND  SOCIO_ACTIVIDADES.ID_DEPORTE=  " + ID.ToString()
                            + "AND (SOCIO_ACTIVIDADES.F_UPDATE IS NULL OR (SOCIO_ACTIVIDADES.F_UPDATE IS NOT NULL AND SOCIO_ACTIVIDADES.ESTADO=1))   ORDER BY    ACTIVIDAD ;";



            string connectionString;

            DataSet ds1 = new DataSet();

            Datos_ini ini3 = new Datos_ini();


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

                dt1.Columns.Add("ACTIVIDAD", typeof(string));
                dt1.Columns.Add("MONTO", typeof(string));

                ds1.Tables.Add(dt1);

                FbCommand cmd = new FbCommand(Query, connection, transaction);

                FbDataReader reader3 = cmd.ExecuteReader();

                while (reader3.Read())
                {


                    if (reader3.GetString(reader3.GetOrdinal("ACTIVIDAD")).Contains("CUOTA"))
                    {
                        Monto = decimal.Parse(reader3.GetString(reader3.GetOrdinal("MONTO")).Trim());


                    }







                }



            }

            return Monto;

        }


        private Decimal ArancelDeportes(bool Socio)

        {
            string Query = "SELECT DESTINO, ID, ID_DESTINO FROM P_TMP_CURSOR('DEPORTES')";
            if (Socio)
                Query = Query + " WHERE   DESTINO LIKE '%CUOTA SOCIO%' ";
            else
                Query = Query + "  WHERE DESTINO  LIKE '%CUOTA INVITADO%' ";

            Query = Query + "ORDER BY ID";
        



                return 0;
        
        }


        public  List<Registro_Actividad> DescuentosXmes(int Tipo)

        {
                    List<Registro_Actividad> registro         = new List<Registro_Actividad>();
                    List<Registro_Actividad> registroProcesado = new List<Registro_Actividad>();

                    registro.AddRange(this.DescuentosDeportes(Tipo));    
                    

                    return   Procesar(registro,Tipo);
               
         }


        private List<Registro_Actividad> Procesar(List<Registro_Actividad> mesActual,int Tipo)
        {
            List<Registro_Actividad> Descuentos = new List<Registro_Actividad>();
            List<Registro_Actividad> MesAnterior = new List<Registro_Actividad>();
            string Baja = "";
            string Alta = "";
           
            if (Tipo == (int)TIPO_ACTIVIDAD.ACTIVO)
            {
                MesAnterior = txt_utils.TXT_ACT_MES(System.DateTime.Now.AddMonths(-1).Month, System.DateTime.Now.AddMonths(-1).Year);
                Alta = "B";
                Baja = "A";
            }
            else
            {
                MesAnterior = txt_utils.TXT_PAS_MES(System.DateTime.Now.AddMonths(-1).Month, System.DateTime.Now.AddMonths(-1).Year);
                Alta = "T2";
                Baja = "SO";
            }
      
            // Determinar y procesar las Altas 
           
            
            foreach( Registro_Actividad  actual in  mesActual )

            {
               // busco en el mes Anterior
               // si esta , con <> Monto, pongo el mes como novedad, si no esta, es una alta tambien

                var ant = MesAnterior.Where(x => (x.CRJP2 == actual.CRJP2 && x.Cod_CC == actual.Cod_CC)).FirstOrDefault();

                if (ant == null)
                {
                    actual.Tipo = Alta;
                }
                else
                {
                    if (ant.Monto != actual.Monto)
                    {
                        actual.Tipo = Alta;
                    
                    }
                
                }

                if (actual.Tipo.Length > 0)
                    Descuentos.Add(actual);
            }

            // Procesar las Bajas

            foreach (Registro_Actividad actual in MesAnterior)

            {
                var reg = mesActual.Where(x => (x.CRJP2 == actual.CRJP2 && x.Cod_CC == actual.Cod_CC)).FirstOrDefault();
                if (reg == null)
                {
                    actual.Tipo = Baja;
                    
                    Descuentos.Add(actual);
                }

            
            }

            return Descuentos;

        
        }



        private List<Registro_Actividad> DescuentosDeportes(int Tipo)

        {   // Deportes tiene CODCC 633 en activos y 642 en pasivos siempre .

            List<DtoDeportes> deportes = new List<DtoDeportes>();
            List<Registro_Actividad> registro = new List<Registro_Actividad>();
            DateTime Fecha = System.DateTime.Now;

            deportes = this.getDto_Deportes(Tipo,"");
            List<int> Identificadores = new List<int>();
            decimal Monto;

            if (Tipo == (int)TIPO_ACTIVIDAD.ACTIVO)
            {
                Identificadores = deportes.GroupBy(x => x.acrjp2).Select(c => c.First().acrjp2).ToList();
            }
            else
            {
                Identificadores = deportes.GroupBy(x => x.pcrjp2).Select(c => c.First().pcrjp2).ToList();
            }



            foreach (int I in Identificadores)
            {

                Registro_Actividad ra = new Registro_Actividad();
                ra.CRJP2               = I;
                ra.Mes                = Fecha.Month;
                ra.Anio               = Fecha.Year;
            
                List<DtoDeportes> agrupado = new List<DtoDeportes>();

                if (Tipo == (int)TIPO_ACTIVIDAD.ACTIVO)
                {
                    agrupado = deportes.Where(x => x.acrjp2 == I).ToList();
                    ra.Monto = agrupado.Sum(x => x.Monto);
                    ra.CRJP1 = deportes.First().acrjp1;
                    ra.CRJP3 = deportes.First().acrjp3;
                    ra.Cod_CC = 633;
                }
                else
                {
                    agrupado = deportes.Where(x => x.pcrjp2 == I).ToList();
                    ra.Monto = deportes.Where(x => x.pcrjp2 == I).Sum(x => x.Monto);
                    ra.CRJP1 = deportes.First().pcrjp1;
                    ra.CRJP3 = deportes.First().pcrjp3;
                    ra.Cod_CC = 642;
                }
             
                registro.Add(ra);

              
            }

            return registro;
        
        }

        public List<OBS_DESCUENTOS> Observaciones(int? ID)
        {
            List<OBS_DESCUENTOS> lista = new List<OBS_DESCUENTOS>();
            string QUERY = "";

            if (ID != null)

                QUERY = @"select ID,NOMBRE from obs_dto  where ID =" + ID.Value.ToString();
            else
                QUERY = "select ID,NOMBRE from obs_dto ";

              DataRow[] foundRows;

             foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

        if (foundRows.Length > 0)
        {
            for (int i = 0; i < foundRows.Length; i++)
            {
                OBS_DESCUENTOS obs = new OBS_DESCUENTOS();
                obs.ID  = Int32.Parse(foundRows[i][0].ToString().Trim());
                obs.OBS = foundRows[i][1].ToString().Trim();
                lista.Add(obs);
            }
           
        }

        return lista;
         
        }



           


             

             




          


            
        }
    }

