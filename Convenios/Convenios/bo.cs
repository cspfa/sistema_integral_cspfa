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

        //MODIFICAR CONVENIO
        public void modificarConvenio(int ID, int NRO_INTERNO, string REG_GRAL, string FECHA_INICIO, string FECHA_FIN, int EMPRESA, string DETALLE, int TIPO, string OBSERVACIONES, int ANIO)
        {
            SOCIOS.db resultado = new SOCIOS.db();
            ArrayList vector_contenidos = new ArrayList
            {
                ID, NRO_INTERNO, REG_GRAL, FECHA_INICIO, FECHA_FIN, EMPRESA, DETALLE, TIPO, OBSERVACIONES, ANIO
            };

            ArrayList vector_tipos = new ArrayList
            {
                "FbDbType.Integer", "FbDbType.Integer", "FbDbType.VarChar", "FbDbType.VarChar", "FbDbType.VarChar", "FbDbType.Integer", "FbDbType.VarChar", "FbDbType.Integer", "FbDbType.VarChar",
                "FbDbType.Integer"
            };

            ArrayList vector_nombres = new ArrayList
            {
                "@PIN_ID", "@PIN_NRO_INTERNO", "@PIN_REG_GRAL", "@PIN_FECHA_INICIO", "@PIN_EMPRESA", "@PIN_DETALLE", "@PIN_TIPO", "@PIN_OBSERVACIONES", "@PIN_ANIO"
            };
            resultado.Ejecuto_Stored_Insert("CONVENIOS_U", vector_contenidos, vector_tipos, vector_nombres);
        }

        //NUEVO CONVENIO
        public void nuevoConvenio(int NRO_INTERNO, string REG_GRAL, string FECHA_INICIO, string FECHA_FIN, int EMPRESA, string DETALLE, int TIPO, string OBSERVACIONES, int ANIO)
        {
            SOCIOS.db resultado = new SOCIOS.db();
            ArrayList vector_contenidos = new ArrayList
            {
                NRO_INTERNO, REG_GRAL, FECHA_INICIO, FECHA_FIN, EMPRESA, DETALLE, TIPO, OBSERVACIONES, ANIO
            };

            ArrayList vector_tipos = new ArrayList
            {
                "FbDbType.Integer", "FbDbType.VarChar", "FbDbType.Date", "FbDbType.Date", "FbDbType.Integer", "FbDbType.VarChar", "FbDbType.Integer", "FbDbType.VarChar", "FbDbType.Integer"
            };

            ArrayList vector_nombres = new ArrayList
            {
                "@PIN_NRO_INTERNO", "@PIN_NRO_REG_GRAL", "@PIN_FECHA_INICIO", "@PIN_FECHA_FIN", "@PIN_EMPRESA", "@PIN_DETALLE", "@PIN_TIPO", "@PIN_OBSERVACIONES", "@PIN_ANIO"
            };
            resultado.Ejecuto_Stored_Insert("CONVENIOS_I", vector_contenidos, vector_tipos, vector_nombres);
        }

        //MODIFICAR EMPRESA
        public void modificarEmpresa(int ID, string RAZON_SOCIAL, string DOMICILIO, int LOCALIDAD)
        {
            SOCIOS.db resultado = new SOCIOS.db();
            ArrayList vector_contenidos = new ArrayList
            {
                ID, RAZON_SOCIAL, DOMICILIO, LOCALIDAD
            };

            ArrayList vector_tipos = new ArrayList
            {
                "FbDbType.Integer", "FbDbType.VarChar", "FbDbType.VarChar", "FbDbType.Integer"
            };

            ArrayList vector_nombres = new ArrayList
            {
                "@PIN_ID", "@PIN_RAZON_SOCIAL", "@PIN_DOMICILIO", "@PIN_LOCALIDAD"
            };
            resultado.Ejecuto_Stored_Insert("CONVENIOS_EMPRESAS_U", vector_contenidos, vector_tipos, vector_nombres);
        }

        //NUEVA EMPRESA
        public void nuevaEmpresa(string RAZON_SOCIAL, string DOMICILIO, int LOCALIDAD)
        {
            SOCIOS.db resultado = new SOCIOS.db();
            ArrayList vector_contenidos = new ArrayList
            {
                RAZON_SOCIAL, DOMICILIO, LOCALIDAD
            };

            ArrayList vector_tipos = new ArrayList
            {
                "FbDbType.VarChar", "FbDbType.VarChar", "FbDbType.Integer"
            };

            ArrayList vector_nombres = new ArrayList
            {
                "@PIN_RAZON_SOCIAL", "@PIN_DOMICILIO", "@PIN_LOCALIDAD"
            };
            resultado.Ejecuto_Stored_Insert("CONVENIOS_EMPRESAS_I", vector_contenidos, vector_tipos, vector_nombres);
        }

        //MODIFICAR LOCALIDAD
        public void modificarLocalidad(int ID, string LOCALIDAD)
        {
            SOCIOS.db resultado = new SOCIOS.db();
            ArrayList vector_tipos = new ArrayList
            {
                "FbDbType.Integer", "FbDbType.VarChar"
            };
            ArrayList vector_nombres = new ArrayList
            {
                "@ID", "@LOCALIDAD"
            };
            ArrayList vector_contenidos = new ArrayList
            {
                ID, LOCALIDAD
            };
            resultado.Ejecuto_Stored_Insert("CONVENIOS_LOCALIDADES_U", vector_contenidos, vector_tipos, vector_nombres);
        }

        //NUEVA LOCALIDAD
        public void nuevaLocalidad(string LOCALIDAD)
        {
            SOCIOS.db resultado = new SOCIOS.db();
            ArrayList vector_contenidos = new ArrayList
            {
                LOCALIDAD
            };

            ArrayList vector_tipos = new ArrayList
            {
                "FbDbType.VarChar"
            };

            ArrayList vector_nombres = new ArrayList
            {
                "@LOCALIDAD"
            };
            resultado.Ejecuto_Stored_Insert("CONVENIOS_LOCALIDADES_I", vector_contenidos, vector_tipos, vector_nombres);
        }
    }
}
