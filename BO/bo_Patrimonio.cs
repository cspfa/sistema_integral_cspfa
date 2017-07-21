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
    class bo_Patrimonio:bo
    {
        public void altaPatrimonio(int TIPO, int DIV_PATR, int NUMERO, string NOMBRE, string DOMICILIO, string LATITUD, string LONGITUD)
        {
            db resultado = new db();
            
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(DIV_PATR);
            vector_contenidos.Add(NUMERO);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(DOMICILIO);
            vector_contenidos.Add(LATITUD);
            vector_contenidos.Add(LONGITUD);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            
            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@TIPO");
            vector_nombres.Add("@DIV_PATR");
            vector_nombres.Add("@NUMERO");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@DOMICILIO");
            vector_nombres.Add("@LATITUD");
            vector_nombres.Add("@LONGITUD");

            string vprocedure = "PATRIMONIO_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }
    }
}
