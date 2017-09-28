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
    class bo_IngresosPersonas
    {
        db resultado = new db();

        //STORED ALTA CARGO / PUESTO
        public void altaCargoEscalafon(string NOMBRE, string WHICH)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            string vprocedure = "";
            vector_contenidos.Add(NOMBRE);
            vector_tipos.Add("FbDbType.VarChar");

            switch (WHICH)
            { 
                case "CARGO":
                    vector_nombres.Add("@CARGO");
                    vprocedure = "CARGO_I";
                    break;

                case "ESCALAFON":
                    vector_nombres.Add("@ESCALAFON");
                    vprocedure = "ESCALAFON_I";
                    break;
            }

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED BAJA DE TEMP_PA
        public void bajaTempPa(int PERSONA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(PERSONA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@PERSONA");

            string vprocedure = "TEMP_PA_D ";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED BAJA DE PERSONA
        public void bajaPersona(int PERSONA, int ESTADO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(PERSONA);
            vector_contenidos.Add(ESTADO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@PERSONA");
            vector_nombres.Add("@ESTADO");

            string vprocedure = "PERSONAS_B";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }


        //STORED ALTA DE TEMP_PA
        public void altaTempPa(int PERSONA, int PA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(PERSONA);
            vector_contenidos.Add(PA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@PERSONA");
            vector_nombres.Add("@PA");

            string vprocedure = "TEMP_PA_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ALTA DE PERSONA PARA INGRESOS
        public void altaPersonaIngresos(string NOMBRE, int ESCALAFON, int CARGO, int ESTADO, string ROL)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(ESCALAFON);
            vector_contenidos.Add(CARGO);
            vector_contenidos.Add(ESTADO);
            vector_contenidos.Add(ROL);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@ESCALAFON");
            vector_nombres.Add("@CARGO");
            vector_nombres.Add("@ESTADO");
            vector_nombres.Add("@ROL");

            string vprocedure = "PERSONAS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICACION DE PERSONA PARA INGRESOS
        public void modificarPersonaIngresos(int ID, string NOMBRE, int ESCALAFON, int CARGO, int ESTADO, string ROL)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(ESCALAFON);
            vector_contenidos.Add(CARGO);
            vector_contenidos.Add(ESTADO);
            vector_contenidos.Add(ROL);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@ESCALAFON");
            vector_nombres.Add("@CARGO");
            vector_nombres.Add("@ESTADO");
            vector_nombres.Add("@ROL");

            string vprocedure = "PERSONAS_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }
    }
}
