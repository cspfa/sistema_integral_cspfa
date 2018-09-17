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
    class bo_RegSoc:bo
    {
        db resultado = new db();

        //NUEVO REGISTRO NO ALCANZA COUTA SOCIAL
        public void nuevoNoAlcanza(int ID_TITULAR, string FECHA, int MOTIVO, string TARJETA, string CBU, int ID_ADHERENTE)
        {
            ArrayList vector_contenidos = new ArrayList {
                ID_TITULAR, FECHA, MOTIVO, TARJETA, CBU, ID_ADHERENTE
            };

            ArrayList vector_tipos = new ArrayList {
                "FbDbType.Integer", "FbDbType.Date", "FbDbType.Integer", "FbDbType.Char", "FbDbType.Char", "FbDbType.Integer"
            };

            ArrayList vector_nombres = new ArrayList {
                "@PIN_ID_TITULAR", "@PIN_", "@PIN_FECHA_A_DTO", "@PIN_MOTIVO_NO_ALCANZA", "@PIN_TARJETA", "@PIN_CBU", "@PIN_ID_ADHERENTE"
            };

            string vprocedure = "NO_ALCANZA_CUOTA_SOCIAL_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED PFA -> CABA
        public void PFA_CABA(int ID_TITULAR, int N_ID_TITULAR, int N_NRO_SOC, int N_COD_DTO)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(ID_TITULAR);
            vector_contenidos.Add(N_ID_TITULAR);
            vector_contenidos.Add(N_NRO_SOC);
            vector_contenidos.Add(N_COD_DTO);

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_nombres.Add("@ID_TITULAR");
            vector_nombres.Add("@N_ID_TITULAR");
            vector_nombres.Add("@N_NRO_SOC");
            vector_nombres.Add("@N_COD_DTO");
            
            string vprocedure = "A_PFA_CABA";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED CABA -> PFA
        public void CABA_PFA(int ID_TITULAR, int N_ID_TITULAR, int N_NRO_SOC, string N_COD_DTO, string N_CAT_SOC)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(ID_TITULAR);
            vector_contenidos.Add(N_ID_TITULAR);
            vector_contenidos.Add(N_NRO_SOC);
            vector_contenidos.Add(N_COD_DTO);
            vector_contenidos.Add(N_CAT_SOC);

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            vector_nombres.Add("@ID_TITULAR");
            vector_nombres.Add("@N_ID_TITULAR");
            vector_nombres.Add("@N_NRO_SOC");
            vector_nombres.Add("@N_COD_DTO");
            vector_nombres.Add("@N_CAT_SOC");

            string vprocedure = "A_CABA_PFA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }
    }
}
