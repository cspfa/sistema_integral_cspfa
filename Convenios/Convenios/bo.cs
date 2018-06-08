using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.Firebird;
using System.Data;
using System.Collections;

namespace Convenios
{
    class bo:SOCIOS.bo
    {
        private SOCIOS.db datDatos;

        public bo()
        {
            datDatos = new SOCIOS.db(this);
        }

        //NUEVA LOCALIDAD
        public void nuevaLocalidad(string LOCALIDAD)
        {
            SOCIOS.db resultado = new SOCIOS.db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(LOCALIDAD);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@LOCALIDAD");

            string vprocedure = "CONVENIOS_LOCALIDADES_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }
    }
}
