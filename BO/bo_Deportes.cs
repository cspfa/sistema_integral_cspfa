using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using FirebirdSql.Data.Firebird;

namespace SOCIOS
{
    class bo_Deportes:bo
    {
        SOCIOS.bo dlog = new bo();

        public int InsertDeportes(int ID_TITULAR, int BARRA, int ID_ADHERENTE, DateTime? FE_APTO, DateTime? FE_CARNET, int TIPO_CARNET, int MOROSO, DateTime FECHA, string USUARIO, int COD_SOC, int COD_DEP, string DNI, DateTime? VENCIMIENTO, byte[] FOTO, string POC, decimal MONTO_MORA, DateTime? FECHA_MORA, string NOMBRE, string APELLIDO, string MAIL, string OBS,string ROL, int ID_ROL)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_TITULAR);
            vector_contenidos.Add(COD_DEP);
            vector_contenidos.Add(COD_SOC);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(ID_ADHERENTE);
           
            if (FE_APTO !=null)
               vector_contenidos.Add(null);
            else
                vector_contenidos.Add(FE_APTO.Value.ToShortDateString());
            if (FE_CARNET != null)
                vector_contenidos.Add(FE_CARNET.Value.ToShortDateString());
            else
                vector_contenidos.Add(null);

            vector_contenidos.Add(TIPO_CARNET);
            vector_contenidos.Add(MOROSO);
            vector_contenidos.Add(USUARIO);
            vector_contenidos.Add(FECHA.ToShortDateString());
            vector_contenidos.Add(DNI);
          
            if (VENCIMIENTO != null)
                vector_contenidos.Add(VENCIMIENTO);
            else
                vector_contenidos.Add(null);

            vector_contenidos.Add(FOTO);
            vector_contenidos.Add(POC);
            vector_contenidos.Add(MONTO_MORA);
            vector_contenidos.Add(FECHA_MORA);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(APELLIDO);
            vector_contenidos.Add(MAIL);
            vector_contenidos.Add(OBS);

            vector_contenidos.Add(ROL);
            vector_contenidos.Add(ID_ROL);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Binary");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID_TITULAR");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@NRO_SOCIO");

            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@ID_ADHERENTE");
            vector_nombres.Add("@FE_APTO");
            vector_nombres.Add("@FE_CARNET");
            vector_nombres.Add("@TIPO_CARNET");
            vector_nombres.Add("@MOROSO");
            vector_nombres.Add("@USR_ALTA");
            vector_nombres.Add("@FE_ALTA");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@VENCIMIENTO");
            vector_nombres.Add("@FOTO");
            vector_nombres.Add("@POC");
            vector_nombres.Add("@MONTOMORA");
            vector_nombres.Add("@A_MORA");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@MAIL");
            vector_nombres.Add("@OBS");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@ID_ROL");

            string vprocedure = "DEPORTES_ADM_I";



            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
            int retorno = 0;
            // FirebirdSql.Data.FirebirdClient.FbDataReader reader3 =
            //while (reader3.Read())
            //{
            //    retorno = Int32.Parse(reader3.GetString(reader3.GetOrdinal("RET")).Trim());

            //}

            //reader3.Close();

            return retorno;



        }

        public void UpdateDeportes(int ID, int ID_TITULAR, int BARRA, int ID_ADHERENTE, DateTime? FE_APTO, DateTime? FE_CARNET, int TIPO_CARNET, int MOROSO, DateTime FECHA, string USUARIO, int COD_SOC, int COD_DEP, string DNI, DateTime? VENCIMIENTO, byte[] FOTO, string POC, decimal MONTO_MORA, DateTime? FECHA_MORA, string NOMBRE, string APELLIDO, string MAIL, string OBS)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(ID_TITULAR);
            vector_contenidos.Add(COD_DEP);
            vector_contenidos.Add(COD_SOC);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(ID_ADHERENTE);
            if (FE_APTO != null)
                vector_contenidos.Add(FE_APTO.Value.ToShortDateString());
            else
                vector_contenidos.Add(null);

            if (FE_CARNET != null)
                vector_contenidos.Add(FE_CARNET.Value.ToShortDateString());
            else
                vector_contenidos.Add(null);

            vector_contenidos.Add(TIPO_CARNET);
            vector_contenidos.Add(MOROSO);
            vector_contenidos.Add(USUARIO);
            vector_contenidos.Add(FECHA.ToShortDateString());
            vector_contenidos.Add(DNI);
            if (VENCIMIENTO != null)
                vector_contenidos.Add(VENCIMIENTO.Value.ToShortDateString());
            else
                vector_contenidos.Add(null);

            vector_contenidos.Add(FOTO);
            vector_contenidos.Add(POC);
            vector_contenidos.Add(MONTO_MORA);
            vector_contenidos.Add(FECHA_MORA);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(APELLIDO);
            vector_contenidos.Add(MAIL);
            vector_contenidos.Add(OBS);
         

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Binary");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
         
            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@ID_TITULAR");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@NRO_SOCIO");

            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@ID_ADHERENTE");
            vector_nombres.Add("@FE_APTO");
            vector_nombres.Add("@FE_CARNET");
            vector_nombres.Add("@TIPO_CARNET");
            vector_nombres.Add("@MOROSO");
            vector_nombres.Add("@USR_MODIFICACION");
            vector_nombres.Add("@FE_MODIFICACION");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@VENCIMIENTO");
            vector_nombres.Add("@FOTO");
            vector_nombres.Add("@POC");
            vector_nombres.Add("@MONTOMORA");
            vector_nombres.Add("@A_MORA");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@MAIL");
            vector_nombres.Add("@OBS");
          
            string vprocedure = "DEPORTES_ADM_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }


        public void BajaDeportes(int ID)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add(VGlobales.vp_username);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@FE_BAJA");
            vector_nombres.Add("@USR_BAJA");

            string vprocedure = "DEPORTES_ADM_B";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }


        public void Eliminar_Actividades(int ID,string ROLE)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(ROLE);
     

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
        

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID_DEPORTE");
            vector_nombres.Add("@ROL");


            string vprocedure = "SOCIO_ACTIVIDADES_E";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //Agregado por Sebastian - STORED SOCIOS DEPORTE ALTA

        public void InsertSociosActividad(int ID_DEPORTE,string ROL, int NRO_SOCIO, int NRO_DEP, int BARRA, DateTime FECHA_DTO, string CAT_SOC, int PROFESIONAL, int ID_ARANCEL, decimal ARANCEL, int SECT_ACT, string USUARIO, DateTime FECHA, int ESTADO,int POR_DTO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_DEPORTE);
            vector_contenidos.Add(NRO_DEP);
            vector_contenidos.Add(NRO_SOCIO);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(FECHA_DTO);
            vector_contenidos.Add(CAT_SOC);
            vector_contenidos.Add(PROFESIONAL);
            vector_contenidos.Add(ARANCEL);
            vector_contenidos.Add(ID_ARANCEL);
            vector_contenidos.Add(SECT_ACT);

            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(USUARIO);
            vector_contenidos.Add(ESTADO);
            vector_contenidos.Add(ROL);
            vector_contenidos.Add(POR_DTO);
            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Float");

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            ArrayList vector_nombres = new ArrayList();


            vector_nombres.Add("@ID_DEPORTE");
            vector_nombres.Add("@NRO_DEP");

            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@A_DTO");
            vector_nombres.Add("@CAT_SOC");
            vector_nombres.Add("@PROFESIONAL");
            vector_nombres.Add("@ARANCEL");
            vector_nombres.Add("@ID_ARANCEL");
            vector_nombres.Add("@SECTACT");

            vector_nombres.Add("@F_ALTA");
            vector_nombres.Add("@USR_A");
            vector_nombres.Add("@ESTADO");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@POR_DTO");



            string vprocedure = "SOCIO_ACTIVIDADES_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        public void BajaSociosActividad(int ID, DateTime FECHA, int ESTADO)
        {

            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(ESTADO);



            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");


            ArrayList vector_nombres = new ArrayList();


            vector_nombres.Add("@ID");
            vector_nombres.Add("@F_BAJA");
            vector_nombres.Add("@USR");
            vector_nombres.Add("@ESTADO");

            string vprocedure = "SOCIO_ACTIVIDADES_D";


            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

            //Control Actividad si dar de baja el registro cabecera;
            // 03-05-2017 se saca lo de borrar la cabecera 
            //string query = "select D.ID from socio_actividades DA, deportes_Adm D , Sectact S  where  coalesce(DA.F_BAJA,'1') <> '1' and S.ID= DA.sectact    and       DA.ID_DEPORTE =D.ID  and S.DETALLE like '%CUOTA%'    AND DA.ID= " + ID.ToString();
            //try
            //{
            //    DataRow[] foundRows = this.BO_EjecutoDataTable(query).Select();
            //    if (foundRows.Length == 0) ;
            //    {

            //        this.BajaDeportes(Int32.Parse(foundRows[0][0].ToString().Trim()));

            //    }
            //}
            //catch (Exception ex)
            //{

            //}

        }

        //Agregado por Sebastian - STORED ASISTENCIA ALTA

        public void AltaAsistencia(int SECTACT, int P, string NOMBRE, string APELLIDO, DateTime FECHA,string ROL,string DNI)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(0);
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(P);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(APELLIDO);
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(ROL);
      
            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");


            ArrayList vector_nombres = new ArrayList();



            vector_nombres.Add("@ID");
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@P");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@ROL");
           
            string vprocedure = "P_ASISTENCIA_DEPORTES_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }
        //Agregado por Sebastian - STORED UPDATE ASISTENCIA
        public void UpdateAsistencia(int ID, int SECTACT, int P, string NOMBRE, string APELLIDO, DateTime FECHA,string ROL,string DNI)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(P);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(APELLIDO);
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(ROL);
            vector_contenidos.Add(DNI);
            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();


            vector_nombres.Add("@ID");
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@P");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@DNI");
            string vprocedure = "P_ASISTENCIA_DEPORTES_U";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }


        public int Proximo_ID(string ROL)

        {


            string QUERY = "SELECT  first 1  ID_ROL   from DEPORTES_ADM WHERE ROL='" + ROL + "' order by ID_ROL desc";


            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            try
            {
                if (foundRows.Length > 0)
                {
                    if (foundRows[0][0] != null)
                        return Int32.Parse(foundRows[0][0].ToString()) + 1;
                    else return 1;

                }
                else
                    return 1;
            }
            catch (Exception ex)
            {

                return 1;
            }

        
        }



        private int Obtener_PK(int ID_ROL,string ROL)
        {


            string QUERY = "SELECT  first 1  ID_ROL   from DEPORTES_ADM WHERE ROL='" + ROL + "' order by ID_ROL desc";


            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            try
            {
                if (foundRows.Length > 0)
                {
                    if (foundRows[0][0] != null)
                        return Int32.Parse(foundRows[0][0].ToString()) + 1;
                    else return 1;

                }
                else
                    return 1;
            }
            catch (Exception ex)
            {

                return 1;
            }


        }


        //STORED INSERTAR TITULAR
        public void inserta_Titular_Concurrente(int ID_TITULAR, int AAR, int ACRJP1, int ACRJP2, int ACRJP3, int PAR, int PCRJP1, int PCRJP2, int PCRJP3, string APE_SOC, string NOM_SOC, int NRO_SOC, int NRO_DEP, string JERARQ, int LEG_PER,
            string DESTINO, string F_ALTPO, string F_ALTCI, string TIP_DOC, int NUM_DOC, int NUM_CED, string CALL_PAR, string LOC_PAR, string NUM_TE1, string NUM_TE2, string COD_DTO, string CAT_SOC, string GIMNASIO, string ESCALA, string A_DTO,
            string USR_ALTA, string NCOD_DTO, string ORIGEN_ALTA, string OBSERVAC, string F_NACIM, string SEX, string PRO_PAR)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_TITULAR);  //1
            vector_contenidos.Add(AAR);         //2
            vector_contenidos.Add(ACRJP1);      //3
            vector_contenidos.Add(ACRJP2);      //4
            vector_contenidos.Add(ACRJP3);      //5
            vector_contenidos.Add(PAR);         //6
            vector_contenidos.Add(PCRJP1);      //7
            vector_contenidos.Add(PCRJP2);      //8
            vector_contenidos.Add(PCRJP3);      //9
            vector_contenidos.Add(APE_SOC);     //10
            vector_contenidos.Add(NOM_SOC);     //11
            vector_contenidos.Add(NRO_SOC);     //12
            vector_contenidos.Add(NRO_DEP);     //13
            vector_contenidos.Add(JERARQ);      //14
            vector_contenidos.Add(LEG_PER);     //15
            vector_contenidos.Add(DESTINO);     //16
            vector_contenidos.Add(F_ALTPO);     //17
            vector_contenidos.Add(F_ALTCI);     //18
            vector_contenidos.Add(TIP_DOC);     //19
            vector_contenidos.Add(NUM_DOC);     //20
            vector_contenidos.Add(NUM_CED);     //21
            vector_contenidos.Add(CALL_PAR);    //23
            vector_contenidos.Add(LOC_PAR);     //28
            vector_contenidos.Add(NUM_TE1);     //31
            vector_contenidos.Add(NUM_TE2);     //33
            vector_contenidos.Add(COD_DTO);     //39
            vector_contenidos.Add(CAT_SOC);     //40
            vector_contenidos.Add(GIMNASIO);    //46
            vector_contenidos.Add(ESCALA);      //56
            vector_contenidos.Add(A_DTO);       //59
            vector_contenidos.Add(USR_ALTA);    //63
            vector_contenidos.Add(NCOD_DTO);    //69
            vector_contenidos.Add(ORIGEN_ALTA); //76
  
            vector_contenidos.Add(OBSERVAC); //76
            vector_contenidos.Add(F_NACIM); //76
            vector_contenidos.Add(SEX); //76
            vector_contenidos.Add(PRO_PAR); //76

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.BLOB");
            vector_tipos.Add("FbDbType.BLOB");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("ID_TITULAR");  //1
            vector_nombres.Add("AAR");         //2
            vector_nombres.Add("ACRJP1");      //3
            vector_nombres.Add("ACRJP2");      //4
            vector_nombres.Add("ACRJP3");      //5
            vector_nombres.Add("PAR");         //6
            vector_nombres.Add("PCRJP1");      //7
            vector_nombres.Add("PCRJP2");      //8
            vector_nombres.Add("PCRJP3");      //9
            vector_nombres.Add("APE_SOC");     //10
            vector_nombres.Add("NOM_SOC");     //11
            vector_nombres.Add("NRO_SOC");     //12
            vector_nombres.Add("NRO_DEP");     //13
            vector_nombres.Add("JERARQ");      //14
            vector_nombres.Add("LEG_PER");     //15
            vector_nombres.Add("DESTINO");     //16
            vector_nombres.Add("F_ALTPO");     //17
            vector_nombres.Add("F_ALTCI");     //18
            vector_nombres.Add("TIP_DOC");     //19
            vector_nombres.Add("NUM_DOC");     //20
            vector_nombres.Add("NUM_CED");     //21
            vector_nombres.Add("CALL_PAR");    //23
            vector_nombres.Add("LOC_PAR");     //28
            vector_nombres.Add("NUM_TE1");     //31
            vector_nombres.Add("NUM_TE2");     //33
            vector_nombres.Add("COD_DTO");     //39
            vector_nombres.Add("CAT_SOC");     //40
            vector_nombres.Add("GIMNASIO");    //46
            vector_nombres.Add("ESCALA");      //56
            vector_nombres.Add("A_DTO");       //59
            vector_nombres.Add("USR_ALTA");    //63
            vector_nombres.Add("NCOD_DTO");    //69
            vector_nombres.Add("ORIGEN_ALTA"); //76
 
            vector_nombres.Add("OBSERVAC"); //76
            vector_nombres.Add("F_NACIM"); //76
            vector_nombres.Add("SEX"); //76
            vector_nombres.Add("PRO_PAR"); //76

            string vprocedure = "CONCURRENTE_ALTA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }



        public void UPDATE_Titular_Concurrente(int ID_TITULAR, string APE_SOC, string NOM_SOC, int NRO_SOC, int NRO_DEP, string JERARQ, int LEG_PER,
            string DESTINO, string F_ALTPO, DateTime F_ALTCI, string TIP_DOC, int NUM_DOC,int NUM_CED, string CALL_PAR, string NUM_TE1, string NUM_TE2, string COD_DTO, string CAT_SOC, string GIMNASIO, string ESCALA, DateTime A_DTO,
            string USR_MODIF,DateTime FECHA_MODIF, string NCOD_DTO, string ORIGEN_ALTA, DateTime  F_NACIM, string SEX)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_TITULAR);  //1
            vector_contenidos.Add(APE_SOC);     //10
            vector_contenidos.Add(NOM_SOC);     //11
            vector_contenidos.Add(NRO_SOC);     //12
            vector_contenidos.Add(NRO_DEP);     //13
            vector_contenidos.Add(JERARQ);      //14
            vector_contenidos.Add(LEG_PER);     //15
            vector_contenidos.Add(DESTINO);     //16
            vector_contenidos.Add(F_ALTPO);     //17
            vector_contenidos.Add(F_ALTCI);     //18
            vector_contenidos.Add(TIP_DOC);     //19
            vector_contenidos.Add(NUM_DOC);     //20
            vector_contenidos.Add(NUM_CED);     //21
            vector_contenidos.Add(CALL_PAR);    //23
            vector_contenidos.Add(NUM_TE1);     //31
            vector_contenidos.Add(NUM_TE2);     //33
            vector_contenidos.Add(COD_DTO);     //39
            vector_contenidos.Add(CAT_SOC);     //40
            vector_contenidos.Add(GIMNASIO);    //46
            vector_contenidos.Add(SEX);    //46
            vector_contenidos.Add(ESCALA);      //56
            vector_contenidos.Add(A_DTO);       //59
            vector_contenidos.Add(USR_MODIF);    //63
            vector_contenidos.Add(FECHA_MODIF);    //63

            vector_contenidos.Add(NCOD_DTO);    //69
            vector_contenidos.Add(ORIGEN_ALTA); //76

       

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");


        

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("ID_TITULAR");  //1
            vector_nombres.Add("APE_SOC");     //10
            vector_nombres.Add("NOM_SOC");     //11
            vector_nombres.Add("NRO_SOC");     //12
            vector_nombres.Add("NRO_DEP");     //13
            vector_nombres.Add("JERARQ");      //14
            vector_nombres.Add("LEG_PER");     //15
            vector_nombres.Add("DESTINO");     //16
            vector_nombres.Add("F_ALTPO");     //17
            vector_nombres.Add("F_ALTCI");     //18
            vector_nombres.Add("TIP_DOC");     //19
            vector_nombres.Add("NUM_DOC");     //20
            vector_nombres.Add("NUM_CED");     //21
            vector_nombres.Add("F_NACIM");    
            vector_nombres.Add("CALL_PAR");    //23
            vector_nombres.Add("NUM_TE1");     //31
            vector_nombres.Add("NUM_TE2");     //33
            vector_nombres.Add("COD_DTO");     //39
            vector_nombres.Add("CAT_SOC");     //40
            vector_nombres.Add("GIMNASIO");    //46
            vector_nombres.Add("SEX"); //76
            vector_nombres.Add("ESCALA");      //56
            vector_nombres.Add("A_DTO");       //59
            vector_nombres.Add("USR_MOD");       //59
            vector_nombres.Add("FE_MOD");       //59
         
            vector_nombres.Add("NCOD_DTO");    //69
            vector_nombres.Add("ORIGEN_ALTA"); //76

         
    
          
 

            string vprocedure = "CONCURRENTE_UPDATE";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }


        public void Baja_Concurrente(int ID_TITULAR,string USR, DateTime FECHA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_TITULAR);  //1
          



            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

        




            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("ID_TITULAR"); 
            vector_nombres.Add("USR_BAJA");    
            vector_nombres.Add("FE_BAJA");     
          






            string vprocedure = "CONCURRENTE_BAJA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }


        public void Importacion_Deportes(int ID, int ID_ROL, int ID_TITULAR, string ROL, int NRO_SOCIO, int NRO_DEP, int BARRA, string DNI, string NOMBRE, string APELLIDO, string EMAIL, int ID_ADHERENTE,string SUSPENDIDO, DateTime FE_APTO, DateTime FE_CARNET, int TIPO_CARNET, DateTime FE_VENCIMIENTO, int MOROSO, decimal MONTO_MORA, DateTime A_MORA, string POC, string USR_A, DateTime FE_A, string USR_U, DateTime FE_U, string USR_B, DateTime FE_B,int ID_TITULAR_ANT,int NRO_SOC_ANT,int NRO_DEP_ANT,string OBS)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(ID);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID");

            vector_contenidos.Add(ID_TITULAR);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID_TITULAR");

            vector_contenidos.Add(NRO_DEP);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@NRO_DEP");

            vector_contenidos.Add(NRO_SOCIO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@NRO_SOCIO");
           
            vector_contenidos.Add(BARRA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@BARRA");

            vector_contenidos.Add(ID_ADHERENTE);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID_ADHERENTE");

            vector_contenidos.Add(FE_APTO);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@FE_APTO");

             vector_contenidos.Add(FE_CARNET);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@FE_CARNET");

             vector_contenidos.Add(TIPO_CARNET);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@TIPO_CARNET");
           
             vector_contenidos.Add(MOROSO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@MOROSO");
    
            vector_contenidos.Add(USR_U);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@USR_MODIFICACION");
            
            vector_contenidos.Add(FE_U);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@FE_MODIFICACION");

            vector_contenidos.Add(USR_A);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@USR_ALTA");
            
            vector_contenidos.Add(FE_A);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@FE_ALTA");

            vector_contenidos.Add(DNI);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@DNI");
           
             vector_contenidos.Add(FE_VENCIMIENTO);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@FE_VENCIMIENTO");
    
            vector_contenidos.Add(POC);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@POC");


             vector_contenidos.Add(MONTO_MORA);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTOMORA");
    
            vector_contenidos.Add(A_MORA);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@A_MORA");
    
            vector_contenidos.Add(NOMBRE);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@NOMBRE");

            vector_contenidos.Add(APELLIDO);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@APELLIDO");

            vector_contenidos.Add(EMAIL);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@EMAIL");

            vector_contenidos.Add(OBS);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@OBS");

            vector_contenidos.Add(FE_B);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@FE_BAJA");
             
            vector_contenidos.Add(USR_B);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@USR_BAJA");

            vector_contenidos.Add(SUSPENDIDO);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@SUSPENDIDO");
            
            vector_contenidos.Add(ROL);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@ROL");
            
            vector_contenidos.Add(ID_ROL);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID_ROL");
 
            vector_contenidos.Add(ID_TITULAR_ANT);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID_TITULAR_ANT");
            
             vector_contenidos.Add(NRO_DEP_ANT);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@NRO_DEP_ANT");

              vector_contenidos.Add(NRO_SOC_ANT);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@NRO_SOC_ANT");
    


            string vprocedure = "P_DEPORTES_ADM_IMP";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        public void Importacion_Actividad(int ID_DEPORTE,int NRO_SOC,int NRO_DEP,int BARRA,DateTime  A_DTO,string CAT_SOC,int SECTACT,int PROFESIONAL,int ID_ARANCEL,decimal ARANCEL,int ESTADO,string USR_A,DateTime F_ALTA,string USR_U,DateTime? F_UPDATE,string USR_B,DateTime? F_BAJA,int ID_ROL, string ROL, int POR_DTO )
        {
             db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(ID_DEPORTE);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID_DEPORTE");

             vector_contenidos.Add(NRO_DEP);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@NRO_DEP");
            
            vector_contenidos.Add(NRO_SOC);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@NRO_SOC");
           
             vector_contenidos.Add(BARRA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@BARRA");
             
              vector_contenidos.Add(A_DTO);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@A_DTO");
   
              vector_contenidos.Add(CAT_SOC);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@CAT_SOC");
  
            vector_contenidos.Add(PROFESIONAL);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PROFESIONAL");
  
            vector_contenidos.Add(ARANCEL);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@ARANCEL");

             vector_contenidos.Add(USR_A);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@USR_A");

            vector_contenidos.Add(F_ALTA);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@F_ALTA");

             vector_contenidos.Add(USR_U);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@USR_U");

            vector_contenidos.Add(F_UPDATE);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@F_UPDATE");

            vector_contenidos.Add(ID_ARANCEL);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID_ARANCEL");

            vector_contenidos.Add(SECTACT);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@SECTACT");

             vector_contenidos.Add(ESTADO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ESTADO");

                 vector_contenidos.Add(F_BAJA);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@F_BAJA");
            
                vector_contenidos.Add(USR_B);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@USR_B");
 
              vector_contenidos.Add(ROL);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@ROL");

             vector_contenidos.Add(ID_ROL);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID_ROL");

              vector_contenidos.Add(POR_DTO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@POR_DTO");


            string vprocedure = "P_SOCIO_ACTIVIDADES_IMP";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }



      

        public void Actualizo_Fecha_Update(int ID_ROL, string ROL)

        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();


            vector_contenidos.Add(VGlobales.vp_username.TrimStart().TrimEnd());
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@USR_MODIFICACION");

            vector_contenidos.Add(System.DateTime.Now);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@FE_MODIFICACION");

            vector_contenidos.Add(ROL);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@ROL");

            vector_contenidos.Add(ID_ROL);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID_ROL");

           
            string vprocedure = "P_DEPORTES_ADM_U_FECHA";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        
        }

        public void Insert_Persona_Responsable(int ID_ROL, string ROL, string APELLIDO, string NOMBRE, string TELEFONO, string EMAIL, DateTime FECHA,string VINCULO,string DNI)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(ID_ROL);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PIN_ID_ROL_DEPORTE");

            vector_contenidos.Add(ROL);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@PIN_ROL");

            vector_contenidos.Add(APELLIDO);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@PIN_APELLIDO");

            vector_contenidos.Add(NOMBRE);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@PIN_NOMBRE");


            vector_contenidos.Add(TELEFONO);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@PIN_TELEFONO");

            vector_contenidos.Add(EMAIL);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@PIN_EMAIL");


            vector_contenidos.Add(FECHA);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@PIN_FECHA");
            
            vector_contenidos.Add(VGlobales.vp_username.TrimEnd().TrimStart());
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@PIN_USR");

            vector_contenidos.Add(VINCULO);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@PIN_VINCULO");

            vector_contenidos.Add(DNI);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@PIN_DNI");

            string vprocedure = "P_DEPORTES_RESPONSABLE_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        public void Borro_Persona_Responsable(int ID,string USER,DateTime Fecha)
        {

            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(ID);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PIN_ID");

            vector_contenidos.Add(Fecha);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@PIN_ANULADO");

            vector_contenidos.Add(USER);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@PIN_USR_ANULADO");


            string vprocedure = "P_DEPORTES_RESPONSABLE_D";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }
        
       
    }
}
