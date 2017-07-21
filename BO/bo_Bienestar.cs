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

namespace SOCIOS.BO
{
    class bo_Bienestar:bo
    {

        public void Bienestar_Ins(string DNI, string AFILIADO, string TELEFONO, string CELULAR,string DOMICILIO,string CIUDAD,string PARTIDO,string PROVINCIA,string CP,string PISO,string DEPARTAMENTO,string TORRE,string PARCELA,string EMAIL)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            ArrayList vector_tipos = new ArrayList();



            vector_contenidos.Add(DNI);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@DNI");

            vector_contenidos.Add(AFILIADO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@AFILIADO");
            vector_contenidos.Add(TELEFONO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@TELEFONO");


            vector_contenidos.Add(CELULAR);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@CELULAR");
            vector_contenidos.Add(DOMICILIO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@DOMICILIO");
            vector_contenidos.Add(CIUDAD);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@CIUDAD");
            vector_contenidos.Add(PARTIDO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@PARTIDO");


            vector_contenidos.Add(PROVINCIA);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@PROVINCIA");



            vector_contenidos.Add(CP);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@CODIGO_POSTAL");

            vector_contenidos.Add(PISO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@PISO");


            vector_contenidos.Add(DEPARTAMENTO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@DEPARTAMENTO");

            vector_contenidos.Add(TORRE);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@TORRE");

            vector_contenidos.Add(PARCELA);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@PARCELA");


            vector_contenidos.Add(EMAIL);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@EMAIL");


            vector_contenidos.Add(System.DateTime.Now);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@FECHA");

            vector_contenidos.Add( VGlobales.vp_username);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@USUARIO");


                     



            string vprocedure = "P_BIENESTAR_DATOS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }


        public void Bienestar_Delete(string DNI)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            ArrayList vector_tipos = new ArrayList();



            vector_contenidos.Add(DNI);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@DNI");

           






            string vprocedure = "P_BIENESTAR_DATOS_D";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

    }
}
