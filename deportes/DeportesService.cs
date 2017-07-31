using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
namespace SOCIOS.deportes
{
   public  class DeportesService
    {
       SOCIOS.bo_Deportes dlog = new bo_Deportes();
       SOCIOS.deportes.Asistencia.AsistenciaService asistenciaService  = new SOCIOS.deportes.Asistencia.AsistenciaService();


    public    List<DeportesItem> RegistrosDeporte(bool filtroDesde, int Desde, int Hasta,string RolRemoto)
       {
           List<DeportesItem> LISTA = new List<DeportesItem>();

           string QUERY = @"SELECT   ID,  ID_TITULAR,  NRO_DEP,  NRO_SOCIO,  BARRA,  ID_ADHERENTE,  FE_APTO,  FE_CARNET,  TIPO_CARNET,  MOROSO,  USR_MODIFICACION,
                          FE_MODIFICACION,  USR_ALTA,  FE_ALTA,  DNI,  FE_VENCIMIENTO,  POC,  MONTOMORA,  A_MORA,  NOMBRE,  APELLIDO, EMAIL,  OBS,  FE_BAJA,
                        USR_BAJA,  SUSPENDIDO,  ROL,  ID_ROL FROM    DEPORTES_ADM WHERE ROL= '" + RolRemoto + "' ";


           if (filtroDesde)
           {
               if (Desde != 0)
                   QUERY = QUERY + " AND ID_ROL>=  " + Desde.ToString();
               if (Hasta!=0)
                   QUERY = QUERY + " AND ID_ROL<=  " + Hasta.ToString();
           }


            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable_Remota(QUERY,RolRemoto).Select();

           // foundRows = dlog.BO_EjecutoDataTable_Remota(QUERY,RolRemoto).Select();
            if (foundRows.Length > 0)
            {
                int I = 0;
                for (int i = 0; i < foundRows.Length; i++)
                {
                    DeportesItem item = new DeportesItem();
                    item.ID_BASE = Int32.Parse(foundRows[I][0].ToString().Trim()); 
                    item.ID_TTULAR = Int32.Parse(foundRows[I][1].ToString().Trim()); 
                    item.NRO_DEP = Int32.Parse(foundRows[I][2].ToString().Trim());
                    item.NRO_SOCIO = Int32.Parse(foundRows[I][3].ToString().Trim());
                    item.BARRA = Int32.Parse(foundRows[I][4].ToString().Trim());
                    item.ID_ADHERENTE = Int32.Parse(foundRows[I][5].ToString().Trim());

                    if (foundRows[I][6].ToString().Trim().Length > 1) ;
                    {
                        try
                        {
                            item.FE_APTO = DateTime.Parse(foundRows[I][6].ToString().Trim());

                        }
                        catch (Exception ex)
                        {

                        }

                    }

                    if (foundRows[I][7].ToString().Trim().Length > 1) ;
                    {
                        try
                        {
                            item.FE_CARNET = DateTime.Parse(foundRows[I][7].ToString().Trim());

                        }
                        catch (Exception ex)
                        {

                        }

                    }


                    item.TIPO_CARNET = Int32.Parse(foundRows[I][8].ToString().Trim());
                    item.MOROSO = Int32.Parse(foundRows[I][9].ToString().Trim());

                    if (foundRows[I][10].ToString().Trim().Length > 1) ;
                    {
                        try
                        {

                            item.USR_MODIFICACION = foundRows[I][10].ToString().Trim();
                            item.FE_MODIFICACION = DateTime.Parse(foundRows[I][11].ToString().Trim());
                        }
                        catch (Exception ex)
                        {

                        }

                    }





                    item.USR_ALTA = foundRows[I][12].ToString().Trim();
                    item.FE_ALTA = DateTime.Parse(foundRows[I][13].ToString().Trim());
                    item.DNI = foundRows[I][14].ToString().Trim();
                    item.FE_VENCIMIENTO = DateTime.Parse(foundRows[I][15].ToString().Trim());
                    item.POC = foundRows[I][16].ToString().Trim();
                    item.MONTO_MORA = Decimal.Parse(foundRows[I][17].ToString().Trim());
                    if (foundRows[I][18].ToString().Trim().Length > 1) ;
                    {
                        try
                        {
                            item.ANIO_MORA = DateTime.Parse(foundRows[I][18].ToString().Trim());

                        }
                        catch (Exception ex)
                        {

                        }


                    }

                    item.NOMBRE = foundRows[I][19].ToString().Trim();
                    item.APELLIDO = foundRows[I][20].ToString().Trim();
                    item.EMAIL = foundRows[I][21].ToString().Trim();
                    item.OBS = foundRows[I][22].ToString().Trim();


                    if (foundRows[I][23].ToString().Trim().Length > 1) ;
                    {
                        try
                        {
                            item.FE_BAJA = DateTime.Parse(foundRows[I][23].ToString().Trim());
                            item.USR_BAJA = foundRows[I][24].ToString().Trim();

                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    item.SUSPENDIDO = foundRows[I][25].ToString().Trim();
                    item.ROL = foundRows[I][26].ToString().Trim();
                    item.ID_ROL = Int32.Parse(foundRows[I][27].ToString());
                    LISTA.Add(item);
                    I = I + 1;

                }
            }
           
           return LISTA;
       
       
       }

    public   List<ActividadItem> RegistrosActividad(bool filtroDesde, int Desde,int Hasta,string pRol)
       {
           List<ActividadItem> LISTA = new List<ActividadItem>();
   

           string QUERY = @"SELECT ID,ID_DEPORTE,NRO_DEP,NRO_SOC,BARRA,A_DTO,CAT_SOC,PROFESIONAL,ARANCEL,USR_A,F_ALTA,USR_U,F_UPDATE,ID_ARANCEL,SECTACT,ESTADO,
                                   F_BAJA,USR_B,ROL FROM   SOCIO_ACTIVIDADES WHERE ROL= '" + pRol +"' ";


           if (filtroDesde)
           {
               if (Desde != 0)
                   QUERY = QUERY + " AND ID_DEPORTE >=  " + Desde.ToString();
               if (Hasta!=0)
                   QUERY = QUERY + " AND ID_DEPORTE <=  " + Hasta.ToString();
           }


            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable_Remota(QUERY, pRol).Select();

           // foundRows = dlog.BO_EjecutoDataTable_Remota(QUERY,RolRemoto).Select();
            if (foundRows.Length > 0)
            {
                int I = 0;
                for (int i = 0; i < foundRows.Length; i++)
                {
                    ActividadItem item = new ActividadItem();
                    item.ID_DEPORTE  = Int32.Parse( foundRows[I][1].ToString().Trim());
                    item.NRO_DEP     =  Int32.Parse( foundRows[I][2].ToString().Trim());
                    item.NRO_SOCIO   = Int32.Parse( foundRows[I][3].ToString().Trim());
                    item.BARRA        = Int32.Parse(foundRows[I][4].ToString().Trim());

                    if (foundRows[I][5].ToString().Length > 1)
                    {
                        item.ANIO_DTO = DateTime.Parse(foundRows[I][5].ToString());
                    }

                    item.CAT_SOC = foundRows[I][6].ToString();
                    item.PROFESIONAL =  Int32.Parse(foundRows[I][7].ToString());
                    item.ARANCEL = Decimal.Parse(foundRows[I][8].ToString());
                    item.USR_ALTA = foundRows[I][9].ToString();
                    item.FE_ALTA =  DateTime.Parse( foundRows[I][10].ToString());
                    if (foundRows[I][11].ToString().Length > 1)
                    {
                        item.USR_U = foundRows[I][11].ToString();
                        item.FE_U = DateTime.Parse( foundRows[I][12].ToString());
                    }

                    item.ID_ARANCEL = Int32.Parse( foundRows[I][13].ToString());
                    item.SECTACT    = Int32.Parse(foundRows[I][14].ToString());
                    item.ESTADO     = foundRows[I][15].ToString();
                    if (foundRows[I][16].ToString().Length > 1)
                    {
                        item.FE_BAJA = DateTime.Parse(foundRows[I][16].ToString());
                        item.USR_BAJA = foundRows[I][17].ToString();
                    
                    }

                    item.ROL = foundRows[I][18].ToString();

                    LISTA.Add(item);
                  

                }

            }



           return LISTA;


       }


 

    public List<ActividadItem> RegistrosActividad_Remoto(int ID_DEPORTE,  string pRol)
    {
        List<ActividadItem> LISTA = new List<ActividadItem>();


        string QUERY = @"SELECT  * FROM   SOCIO_ACTIVIDADES WHERE ROL= '" + pRol + "' AND ID_DEPORTE= " + ID_DEPORTE.ToString();


       


        DataRow[] foundRows;

        //foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

         foundRows = dlog.BO_EjecutoDataTable_Remota(QUERY,pRol).Select();
        if (foundRows.Length > 0)
        {
            int I = 0;
            for (int i = 0; i < foundRows.Length; i++)
            {
                ActividadItem item = new ActividadItem();
                item.ID_DEPORTE = Int32.Parse(foundRows[I][0].ToString().Trim());
                item.NRO_DEP = Int32.Parse(foundRows[I][2].ToString().Trim());
                item.NRO_SOCIO = Int32.Parse(foundRows[I][3].ToString().Trim());
                item.BARRA = Int32.Parse(foundRows[I][4].ToString().Trim());

                if (foundRows[I][5].ToString().Length > 1)
                {
                    item.ANIO_DTO = DateTime.Parse(foundRows[I][5].ToString());
                }

                item.CAT_SOC = foundRows[I][6].ToString();
                item.PROFESIONAL = Int32.Parse(foundRows[I][7].ToString());
                item.ARANCEL = Decimal.Parse(foundRows[I][8].ToString());
                item.USR_ALTA = foundRows[I][9].ToString();
                item.FE_ALTA = DateTime.Parse(foundRows[I][10].ToString());
                if (foundRows[I][11].ToString().Length > 1)
                {
                    item.USR_U = foundRows[I][11].ToString();
                    item.FE_U = DateTime.Parse(foundRows[I][12].ToString());
                }
                else
                    item.FE_U = null;

                item.ID_ARANCEL = Int32.Parse(foundRows[I][13].ToString());
                item.SECTACT = Int32.Parse(foundRows[I][14].ToString());
                item.ESTADO = foundRows[I][15].ToString();
                if (foundRows[I][16].ToString().Length > 1)
                {
                    item.FE_BAJA = DateTime.Parse(foundRows[I][16].ToString());
                    item.USR_BAJA = foundRows[I][17].ToString();

                }
                else
                    item.FE_BAJA = null;

                item.ROL = foundRows[I][18].ToString();
                item.ID_ROL =  Int32.Parse(foundRows[I][19].ToString());
                item.POR_DTO = Int32.Parse(foundRows[I][20].ToString());
                LISTA.Add(item);


            }

        }



        return LISTA;


    }

   




    public List<DeporteX_ROL> obtenerRoles_Deportes(string NroSocio, string Dep,string Barra)
    {
        List<DeporteX_ROL> lista = new List<DeporteX_ROL>();

        string QUERY = @"SELECT ROL,FE_ALTA,USR_ALTA,FE_BAJA,ID_ROL,ID   from deportes_adm where  NRO_DEP =  " + Dep.ToString() + " AND NRO_SOCIO=" + NroSocio.ToString() + " AND BARRA =" + Barra;

        DataRow[] foundRows;

        foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

        if (foundRows.Length > 0)
        {
            int I = 0;
            for (int i = 0; i < foundRows.Length; i++)
            {
                DeporteX_ROL item = new DeporteX_ROL();
               
                item.ROL   =foundRows[i][0].ToString().Trim();
                item.Fecha = foundRows[i][1].ToString().Trim();
                item.User  = foundRows[i][2].ToString().Trim();
                if (foundRows[i][3].ToString().Length > 0)
                {
                    item.FechaBaja = foundRows[i][3].ToString();
                }else
                    item.FechaBaja = "";
                item.ID_ROL      = Int32.Parse( foundRows[i][4].ToString().Trim());
                item.ID_REGISTRO = Int32.Parse( foundRows[i][5].ToString().Trim());
                lista.Add(item);
            }
        }

        return lista;
        

    }

    public bool  Tiene_Baja_Deportes(string NroSocio, string Dep, string Barra,string ROL)
    {
        List<DeporteX_ROL> lista = new List<DeporteX_ROL>();

        string QUERY = @"SELECT ROL,FE_ALTA,USR_ALTA   from deportes_adm where  NRO_DEP =  " + Dep.ToString() + " AND NRO_SOCIO=" + NroSocio.ToString() + " AND BARRA =" + Barra + "   and FE_BAJA is not null AND ROL='" + ROL + "'";

        DataRow[] foundRows;

        foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

        return (foundRows.Length > 0);
       


    }


        public List<DeporteX_ROL> obtenerRoles_Deportes(string DNI)
    {
        List<DeporteX_ROL> lista = new List<DeporteX_ROL>();

        string QUERY = @"SELECT ROL,FE_ALTA,USR_ALTA   from deportes_adm where  DNI =" + DNI.Trim();

        DataRow[] foundRows;

        foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

        if (foundRows.Length > 0)
        {
            int I = 0;
            for (int i = 0; i < foundRows.Length; i++)
            {
                DeporteX_ROL item = new DeporteX_ROL();
               
                item.ROL   =foundRows[i][0].ToString().Trim();
                item.User  = foundRows[i][1].ToString().Trim();
                item.Fecha = foundRows[i][2].ToString().Trim();
                lista.Add(item);
            }
        }

        return lista;
        

    }
    
       public bool ExistenRoles (string NroSocio, string Dep,string Barra)

    {

        return (this.obtenerRoles_Deportes(NroSocio, Dep,Barra).Count > 0);

    }

       public bool ExistenRoles(string NroSocio, string Dep, string Barra,string ROL)
       {

           return (this.obtenerRoles_Deportes(NroSocio, Dep, Barra).Count(b => b.ROL == ROL) > 0);

       }
    

      public List<SOCIOS.Titular>  Titular_Concurrente(string RolRemoto)

      {
          List<SOCIOS.Titular> lista = new List<Titular>();

          string QUERY = @"select  id_Titular,aar,acrjp1,acrjp2,acrjp3,par,pcrjp1,pcrjp2,pcrjp3, ape_soc, nom_soc,nro_soc, nro_dep,jerarq,
                               leg_per,destino,f_altpo,f_altci,tip_doc,num_doc, num_ced,call_par,loc_par,num_te1,num_te2, cod_dto, cat_soc,
                               gimnasio, escala, a_dto,usr_alta,ncod_dto, origen_alta,"+ "'Importacion Desde Campo'"   +@",f_nacim,sex,pro_par
                                from titular where nro_dep in  (18,19,20)";

            DataRow[] foundRows;

            //foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

             foundRows = dlog.BO_EjecutoDataTable_Remota(QUERY,RolRemoto).Select();
            if (foundRows.Length > 0)
            {
                int I = 0;
                for (int i = 0; i < foundRows.Length; i++)
                {
                    SOCIOS.Titular item = new SOCIOS.Titular();
                    item.ID_TITULAR = Int32.Parse(foundRows[I][0].ToString().Trim());
                    item.AAR        = Int32.Parse(foundRows[I][1].ToString().Trim());
                    item.ACRJP1     =  Int32.Parse(foundRows[I][2].ToString().Trim()); 
                    item.ACRJP2     = Int32.Parse(foundRows[I][3].ToString().Trim());
                    item.ACRJP3     = Int32.Parse(foundRows[I][4].ToString().Trim());
                    item.PAR        = Int32.Parse(foundRows[I][5].ToString().Trim());
                    item.PCRJP1     = Int32.Parse(foundRows[I][6].ToString().Trim());
                    item.PCRJP2     = Int32.Parse(foundRows[I][7].ToString().Trim());
                    item.PCRJP3     = Int32.Parse(foundRows[I][8].ToString().Trim());
                    item.APE_SOC    = foundRows[I][9].ToString().Trim();
                    item.NOM_SOC    = foundRows[I][10].ToString().Trim();
                    item.NRO_SOC    = Int32.Parse(foundRows[I][11].ToString().Trim());
                    item.NRO_DEP    =  Int32.Parse(foundRows[I][12].ToString().Trim()); 
                    item.JERARQ     =   foundRows[I][13].ToString().Trim();
                    item.LEG_PER    =  Int32.Parse(foundRows[I][14].ToString().Trim()); 
                    item.DESTINO    = foundRows[I][15].ToString().Trim(); 
                    if (foundRows[I][16].ToString().Trim().Length>1)
                         item.F_ALTPO    =DateTime.Parse(foundRows[I][16].ToString().Trim());
                    if (foundRows[I][27].ToString().Trim().Length>1)
                           item.F_ALTC     =DateTime.Parse(foundRows[I][17].ToString().Trim());
                    item.TIP_DOC    = foundRows[I][18].ToString().Trim(); 
                    item.NUM_DOC     =  Int32.Parse(foundRows[I][19].ToString().Trim());
                    item.NUM_CED    =  Int32.Parse(foundRows[I][20].ToString().Trim()); 
                    item.CALL_PAR    = foundRows[I][21].ToString().Trim(); 
                    item.LOC_PAR    = foundRows[I][22].ToString().Trim();  
                    item.NUM_TE1   = foundRows[I][23].ToString().Trim();   
                    item.NUM_TE2     = foundRows[I][24].ToString().Trim(); 
                    item.COD_DTO    = foundRows[I][25].ToString().Trim(); 
                    item.CAT_SOC    = foundRows[I][26].ToString().Trim();  
                    item.GIMNASIO   = foundRows[I][27].ToString().Trim(); 
                    item.ESCALA     = foundRows[I][28].ToString().Trim(); 
                    if (foundRows[I][29].ToString().Trim().Length>1)
                       item.A_DTO     =DateTime.Parse(foundRows[I][29].ToString().Trim()); 
                    item.USR_ALTA     = foundRows[I][30].ToString().Trim(); 
                    item.NCOD_DTO             = foundRows[I][31].ToString().Trim(); 
                    item.ORIGEN_ALTA           = foundRows[I][32].ToString().Trim(); 
                    item.OBSERVAC      = foundRows[I][33].ToString().Trim(); 
                    if (foundRows[I][0].ToString().Trim().Length>1)
                         item.F_NACIM     =DateTime.Parse(foundRows[I][34].ToString().Trim()); 
                    item.SEX          = foundRows[I][35].ToString().Trim();
                    item.PRO_PAR = foundRows[I][36].ToString().Trim();
                   
                    lista.Add(item);
                }
            }

            return lista;
      
      }

      public bool Existe_Concurrente(int TitularID)
      {
          List<SOCIOS.Titular> lista = new List<Titular>();

          string QUERY = @" select id_titular from Titular where id_titular= " + TitularID.ToString(); ;

          DataRow[] foundRows;

          foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


          if (foundRows.Length > 0)
          {
              return true;
          }
          else
              return false;
      }


      public List<InfoPersonaDeporte> getPersonasDeporte(int ID_TITULAR)
      {
          List<InfoPersonaDeporte> lista = new List<InfoPersonaDeporte>();
          string SQL = @"select D.DNI,D.NOMBRE,D.APELLIDO, A.detalle,D.NRO_SOCIO, D.NRO_DEP,D.BARRA from socio_actividades S, SectAct A ,Deportes_ADM D
                      where S.SECTACT =  A.ID  and S.F_BAJA is null  and S.ID_DEPORTE = D.ID_ROL AND D.ID_TITULAR=" + ID_TITULAR.ToString();

          DataRow[] foundRows;

          foundRows = dlog.BO_EjecutoDataTable(SQL).Select();

          
          if (foundRows.Length > 0)
          {
              int I = 0;
              for (int i = 0; i < foundRows.Length; i++)
              {
                  InfoPersonaDeporte item = new InfoPersonaDeporte();

                  item.DNI       = foundRows[i][0].ToString().Trim();
                  item.NOMBRE    = foundRows[i][1].ToString().Trim();
                  item.APELLIDO  = foundRows[i][2].ToString().Trim();
                  item.SECACT    =  foundRows[i][3].ToString().Trim();
                  item.NRO_SOCIO = foundRows[i][4].ToString().Trim();
                  item.NRO_DEP   = foundRows[i][5].ToString().Trim();
                  item.BARRA     = foundRows[i][6].ToString().Trim();
                 lista.Add(item);


              }

          }
          return lista;




      }

      public bool SOCIO_Becado(int Nro, int Dep, int Barra)

      {
          string SQL = @"SELECT select ID from socio_Actividades     where nro_soc ="+Nro.ToString()+" and Nro_Dep ="+Dep.ToString() +" and barra="+Barra.ToString()+"  and POR_DTO >0 and f_baja is not null  ";

          DataRow[] foundRows;

          foundRows = dlog.BO_EjecutoDataTable(SQL).Select();

          if (foundRows.Length > 1)
              return true;

          else return false;

      
      }


      public DateTime?  Fecha_Vencimiento_Apto(string DNI,string ROL)
      {
          string SQL = @"SELECT  FE_VENCIMIENTO from deportes_ADM     where DNI ='" + DNI + "' and ROL ='" + ROL + "'";

          DataRow[] foundRows;

          foundRows = dlog.BO_EjecutoDataTable(SQL).Select();

          if (foundRows.Length > 1)
              return DateTime.Parse(foundRows[0][0].ToString());

          return null;


      }

      #region Importar_Exportar


      public string fechaUSA(DateTime fecha)
      {
          string Fecha = fecha.Month.ToString("00") + "/" + fecha.Day.ToString("00") + "/" + fecha.Year.ToString("0000");

          return Fecha;


      }
      public List<SOCIOS.deportes.Deporte_Importacion> Importar_Exportar_Deporte(string DESDE, string  HASTA, string ROL_REMOTO, bool Deportes)
      {
          List<SOCIOS.deportes.Deporte_Importacion> Altas          = new List<SOCIOS.deportes.Deporte_Importacion>();
          List<SOCIOS.deportes.Deporte_Importacion> Modificaciones = new List<SOCIOS.deportes.Deporte_Importacion>();
          List<SOCIOS.deportes.Deporte_Importacion> Bajas          = new List<SOCIOS.deportes.Deporte_Importacion>();
          List<SOCIOS.deportes.Deporte_Importacion> Total = new List<Deporte_Importacion>();
          
          if (Deportes == false)
              return Total;

          Altas          = this.Registros_Importar("ALTAS", DESDE, HASTA, ROL_REMOTO);
          Modificaciones = this.Registros_Importar("MODIFICACIONES", DESDE, HASTA, ROL_REMOTO);
          Bajas = this.Registros_Importar("BAJAS", DESDE, HASTA, ROL_REMOTO);
          
          Total.AddRange(Altas);

          Total.AddRange(Modificaciones);
          Total.AddRange(Bajas);

          return Total;
        //  registros = this.getIngresos(FiltroSinProcesar, false, ID_DESDE, ID_HASTA, true, ROL).Where(x => x.ROL == ROL).ToList();

         

          
      }


      public List<SOCIOS.deportes.Deporte_Importacion> Registros_Importar(string MODO, string  Desde,string Hasta,string ROL )

      {

          List<SOCIOS.deportes.Deporte_Importacion> lista = new List<Deporte_Importacion>();
          string QUERY = @"SELECT ID,ID_TITULAR,NRO_SOCIO,NRO_DEP,BARRA,ID_ADHERENTE,FE_APTO,FE_CARNET,TIPO_CARNET,MOROSO,USR_MODIFICACION,
                               FE_MODIFICACION,USR_ALTA,FE_ALTA,DNI,FE_VENCIMIENTO,POC,MONTOMORA,A_MORA,NOMBRE,APELLIDO,EMAIL,OBS,
                               FE_BAJA,USR_BAJA,SUSPENDIDO,ROL,ID_ROL,ID_TITULAR_ANT,NRO_DEP_ANT,NRO_SOC_ANT FROM DEPORTES_ADM WHERE 1=1  ";

          if (MODO == "ALTAS")

          {
              QUERY = QUERY + " AND FE_ALTA >='" + Desde + "' AND FE_ALTA <='" + Hasta +"' ";
          }
          else if (MODO == "BAJAS")

          {
              QUERY = QUERY + " AND FE_BAJA >='" + Desde + "' AND FE_BAJA <='" + Hasta +"'";
          }
          else if (MODO == "MODIFICACIONES")
          {
              QUERY = QUERY + " AND FE_MODIFICACION >='" + Desde + "' AND FE_MODIFICACION <='" + Hasta + "' ";
          }

          QUERY = QUERY + " AND ROL='" + ROL +"'";

          DataRow[] foundRows;
          foundRows = dlog.BO_EjecutoDataTable_Remota(QUERY,ROL).Select();
        //  foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


          if (foundRows.Length > 0)
          {
              int I = 0;
              for (int i = 0; i < foundRows.Length; i++)
              {
                  Deporte_Importacion item = new Deporte_Importacion();

                  item.ID_BASE          =  Int32.Parse(foundRows[i][0].ToString().Trim());

                  item.ID_TTULAR        =  Int32.Parse(foundRows[i][1].ToString().Trim());
                  item.NRO_SOCIO        =  Int32.Parse(foundRows[i][2].ToString().Trim());
                  item.NRO_DEP          =  Int32.Parse(foundRows[i][3].ToString().Trim());
                  item.BARRA            =  Int32.Parse(foundRows[i][4].ToString().Trim());

                  item.ID_ADHERENTE         =Int32.Parse( foundRows[i][5].ToString().Trim());
                    if (foundRows[i][6].ToString().Length >1)
                  item.FE_APTO              = DateTime.Parse( foundRows[i][6].ToString().Trim());
                    if (foundRows[i][7].ToString().Length > 1)
                  item.FE_CARNET            = DateTime.Parse(foundRows[i][7].ToString());
                 
                  item.TIPO_CARNET          = Int32.Parse(foundRows[i][8].ToString().Trim());
                  item.MOROSO               = Int32.Parse(foundRows[i][9].ToString().Trim());
                  item.USR_MODIFICACION     = foundRows[i][10].ToString().Trim();
                  if (foundRows[i][11].ToString().Length > 1)
                      item.FE_MODIFICACION = DateTime.Parse(foundRows[i][11].ToString());
                  item.USR_ALTA = foundRows[i][12].ToString();
                  item.FE_ALTA = DateTime.Parse(foundRows[i][13].ToString());
                  item.DNI = foundRows[i][14].ToString();
                  if (foundRows[i][15].ToString().Length > 1)
                      item.FE_VENCIMIENTO = DateTime.Parse(foundRows[i][15].ToString());
                  item.POC = foundRows[i][16].ToString();
                  item.MONTO_MORA = Decimal.Parse(foundRows[i][17].ToString());
                  if (foundRows[i][18].ToString().Length > 1)
                      item.ANIO_MORA = DateTime.Parse(foundRows[i][18].ToString());
                  item.NOMBRE = foundRows[i][19].ToString();

                  item.APELLIDO = foundRows[i][20].ToString();
                  item.EMAIL  =  foundRows[i][21].ToString();
                  item.OBS = foundRows[i][22].ToString();
                  if (foundRows[i][23].ToString().Length > 1)
                      item.FE_BAJA = DateTime.Parse(foundRows[i][23].ToString());
                  
                  item.USR_BAJA=foundRows[i][24].ToString();
                  item.SUSPENDIDO = foundRows[i][25].ToString();
                  item.ROL = foundRows[i][26].ToString().TrimEnd();
                  item.ID_ROL = Int32.Parse(foundRows[i][27].ToString());

                  if (foundRows[i][28].ToString().Length > 0)
                      item.ID_TITULAR_ANT = Int32.Parse(foundRows[i][28].ToString());
                  else
                      item.ID_TITULAR_ANT = 0;

                  if (foundRows[i][29].ToString().Length > 0)
                      item.NRO_DEP_ANT = Int32.Parse(foundRows[i][29].ToString());
                  else
                      item.NRO_DEP_ANT = 0;

                  if (foundRows[i][30].ToString().Length > 0)
                      item.NRO_SOCIO_ANT = Int32.Parse(foundRows[i][30].ToString());
                  else
                      item.NRO_DEP_ANT = 0;


                  item.TIPO = MODO;
                  
                  if (MODO == "MODIFICACION") // modificacion,misma fecha de alta y modificacion. lo toma como alta

                  {
                      if ( (item.FE_ALTA.Day == item.FE_MODIFICACION.Day) && (item.FE_ALTA.Month == item.FE_MODIFICACION.Month ) && ( item.FE_ALTA.Year == item.FE_ALTA.Year) ) 
                      continue;
                  
                  }


                  lista.Add(item);


              }

          }
          return lista;

          return null;

      
      }

      public void Proceso_Importar_Exportar(List<SOCIOS.deportes.Deporte_Importacion> lista,DateTime Desde, DateTime Hasta,string ROL,bool Deportes, bool Asistencia)
      {
          bool Importa = false;

          if (Deportes && !(Control_Topes(Desde)))
          {

              if (MessageBox.Show("Tiene informacion en la base del Servidor con fechas ya existentes en los filtros, podria duplicarse informacion", "ATENCION ", MessageBoxButtons.YesNo) == DialogResult.Yes)
              {
                  Importa = true;
              }

             
          }


          if (Importa)
              this.Procesar_Deportes(lista, Desde, Hasta, ROL, Deportes, Asistencia);


       
      }

      public bool Control_Topes(DateTime Desde)

      {
          bool OK;
         
          List<SOCIOS.deportes.Deporte_Importacion> lista = new List<Deporte_Importacion>();
          string QUERY = @"select   ID,FE_ALTA  from deportes_Adm WHERE FE_ALTA <'" + fechaUSA( Desde) + "'  order by FE_ALTA desc   ";

              DataRow[] foundRows;
          foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
        //  foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


          if (foundRows.Length > 0)
          {

              return false;

          }
          else
              return true;


      
      }





      public void Procesar_Deportes(List<SOCIOS.deportes.Deporte_Importacion> lista,DateTime Desde,DateTime Hasta,string ROL,bool Deportes, bool Asistencia)

      {

          if (Deportes)
          {
              foreach (Deporte_Importacion item in lista)
              {
                  if (item.TIPO == "ALTAS")
                  {
                      Thread.Sleep(50);
                      dlog.InsertDeportes(item.ID_TTULAR, item.BARRA, item.ID_ADHERENTE, item.FE_APTO, item.FE_CARNET, item.TIPO_CARNET, item.MOROSO, item.FE_ALTA, item.USR_ALTA, item.NRO_SOCIO, item.NRO_DEP, item.DNI, item.FE_VENCIMIENTO, null, item.POC, item.MONTO_MORA, item.ANIO_MORA, item.NOMBRE, item.APELLIDO, item.EMAIL.TrimEnd(), item.OBS.TrimEnd(), item.ROL, item.ID_ROL);

                  }
                  else
                  {
                      dlog.Importacion_Deportes(item.ID_BASE, item.ID_ROL, item.ID_TTULAR, item.ROL, item.NRO_SOCIO, item.NRO_DEP, item.BARRA, item.DNI, item.NOMBRE, item.APELLIDO, item.EMAIL, item.ID_ADHERENTE, item.SUSPENDIDO, item.FE_APTO, item.FE_CARNET, item.TIPO_CARNET, item.FE_VENCIMIENTO, item.MOROSO, item.MONTO_MORA, item.ANIO_MORA, item.POC, item.USR_ALTA, item.FE_ALTA, item.USR_MODIFICACION, item.FE_MODIFICACION, item.USR_BAJA, item.FE_BAJA, item.ID_TITULAR_ANT, item.NRO_SOCIO_ANT, item.NRO_DEP_ANT, item.OBS);

                      dlog.Eliminar_Actividades(item.ID_ROL, item.ROL);

                  }

                  // hacer el insert de las actividades

                  foreach (ActividadItem a in this.RegistrosActividad_Remoto(item.ID_ROL, item.ROL))
                  {
                      Thread.Sleep(50);
                      dlog.Importacion_Actividad(a.ID_DEPORTE, a.NRO_SOCIO, a.NRO_DEP, a.BARRA, a.ANIO_DTO, a.CAT_SOC, a.SECTACT, a.PROFESIONAL, a.ID_ARANCEL, a.ARANCEL, Int32.Parse(a.ESTADO), a.USR_ALTA, a.FE_ALTA, a.USR_U, a.FE_U, a.USR_BAJA, a.FE_BAJA, a.ID_ROL, a.ROL, a.POR_DTO);


                  }







              }
          }

          if (Asistencia)
          {
              //hacer el insert de los presentes

              this.Procesar_Asistencia(lista, Desde, Hasta, ROL);
          }
         
      
      }

      public void Procesar_Asistencia(List<SOCIOS.deportes.Deporte_Importacion> lista,DateTime Desde, DateTime Hasta,string ROL)
      {

          DateTime desde = this.menorFecha(lista);
          DateTime hasta = this.mayorFecha(lista);


          foreach (Asistencia.ReporteAsistencia item in asistenciaService.ReporteAsistencia_Remoto(Desde, Hasta, ROL))
          {

              Thread.Sleep(50);
              dlog.AltaAsistencia(item.Sectact, Int32.Parse(item.PRESENTE), item.NOMBRE, item.APELLIDO, DateTime.Parse( item.FECHA), item.ROL, item.DNI);
          
          }



      
      
      }

      private DateTime menorFecha(List<SOCIOS.deportes.Deporte_Importacion> lista)

      {
          var  fechaM = lista.OrderBy(z => z.FE_ALTA).FirstOrDefault().FE_ALTA;
          var fechaA = lista.OrderBy(z => z.FE_MODIFICACION).FirstOrDefault().FE_MODIFICACION;
          if (fechaA != null && fechaM != null)
          {
              if (fechaA < fechaM)
                  return fechaA;
              else
                  return fechaM;
          }
          else if (fechaA == null && fechaM != null)
          {
              return fechaM;

          }
          else
          {
              return fechaA;
          
          }


      }


      private DateTime mayorFecha(List<SOCIOS.deportes.Deporte_Importacion> lista)
      {
          var fechaM = lista.OrderByDescending(z => z.FE_ALTA).FirstOrDefault().FE_ALTA;
          var fechaA = lista.OrderByDescending(z => z.FE_MODIFICACION).FirstOrDefault().FE_MODIFICACION;
          if (fechaA != null && fechaM != null)
          {
              if (fechaA > fechaM)
                  return fechaA;
              else
                  return fechaM;
          }
          else if (fechaA == null && fechaM != null)
          {
              return fechaM;

          }
          else
          {
              return fechaA;

          }


      }



      #endregion

      #region TraerFoto_Apto
    

      #endregion


    }

    
}
