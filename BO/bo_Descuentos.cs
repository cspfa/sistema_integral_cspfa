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
    class bo_Descuentos : bo
    {
        public void Txt_Activo_I(int Mes, int Anio, string ACRJP2, int CODINT, int CODCC, string TIPO, decimal MONTO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Mes);
            vector_contenidos.Add(Anio);
            vector_contenidos.Add(ACRJP2);
            vector_contenidos.Add(CODINT);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(MONTO);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add(VGlobales.vp_role);
            vector_contenidos.Add(CODCC);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@MES");
            vector_nombres.Add("@ANIO");
            vector_nombres.Add("@ACRPJ2");
            vector_nombres.Add("@COD_INT");
            vector_nombres.Add("@TIPO");
            vector_nombres.Add("@MONTO");
            vector_nombres.Add("@USR_A");
            vector_nombres.Add("@FECHA_A");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@COD_CC");


            string vprocedure = "P_TXT_ACTIVOS_I";


            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }

        public void Txt_Pasivo_I(int Mes, int Anio, int PCRJP1, string PCRJP2, int PCRJP3, int CODINT, int CODCC, string TIPO, decimal MONTO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Mes);
            vector_contenidos.Add(Anio);
            vector_contenidos.Add(PCRJP1);
            vector_contenidos.Add(PCRJP2);
            vector_contenidos.Add(PCRJP3);
            vector_contenidos.Add(MONTO);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(CODINT);
            vector_contenidos.Add(VGlobales.vp_role);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add(CODCC);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");


            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@MES");
            vector_nombres.Add("@ANIO");
            vector_nombres.Add("@PCRJP1");
            vector_nombres.Add("@PCRJP2");
            vector_nombres.Add("@PCRJP3");
            vector_nombres.Add("@MONTO");
            vector_nombres.Add("@TIPO");
            vector_nombres.Add("@CODINT");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@USR_A");
            vector_nombres.Add("@FECHA_A");
            vector_nombres.Add("@COD_CC");

            string vprocedure = "P_TXT_PASIVOS_I";


            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }


        public void FICENV_I(int Mes, int Anio, string ACRJP2,int PCRJP1,int PCRJP2,int PCRJP3, int CODINT, int CODCC, string TIPO,int ACTIVIDAD, decimal MONTO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(Mes);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@MES");

            vector_contenidos.Add(Anio);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ANIO");

            vector_contenidos.Add(ACRJP2);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@ACRPJ2");
            
            vector_contenidos.Add(PCRJP1);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PCRJP1");
            
            vector_contenidos.Add(PCRJP2);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PCRJP2");
            
            vector_contenidos.Add(PCRJP3);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PCRJP3");

            vector_contenidos.Add(ACTIVIDAD);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ACTIVIDAD");

            vector_contenidos.Add(CODINT);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@COD_INT");

            vector_contenidos.Add(CODCC);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@COD_CC");
            
            vector_contenidos.Add(TIPO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@TIPO");
            
            vector_contenidos.Add(MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO");

            vector_contenidos.Add(VGlobales.vp_username);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@USR_A");

            vector_contenidos.Add(System.DateTime.Now);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@FECHA_A");

            vector_contenidos.Add(VGlobales.vp_role);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@ROL");


                 
       
      
         
     


            string vprocedure = "P_FICENV02_I";


            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }


        public void Actualizo_DTO(int ID, int TIPO_DTO,DateTime FECHA)

        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(ID);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID");


            vector_contenidos.Add(VGlobales.vp_username);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@USR_U");

            vector_contenidos.Add(System.DateTime.Now);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@FE_U");

            vector_contenidos.Add(TIPO_DTO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@FORMA_DTO");

            vector_contenidos.Add(FECHA);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@FECHA_DTO");

            




            string vprocedure = "P_PAGOS_BONO_DTO";


            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }




    }

}