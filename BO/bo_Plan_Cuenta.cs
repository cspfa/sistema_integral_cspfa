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
    public class bo_Plan_Cuenta : bo
    {

        public void Pagar_Cuota(int ID, int Recibo, int Bono, int FormaPago, DateTime FechaPago)
        {
            db resultado = new db();


            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(VGlobales.vp_username);

            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add("P");
            vector_contenidos.Add(Bono);
            vector_contenidos.Add(FechaPago);
            vector_contenidos.Add(Recibo);
            vector_contenidos.Add(FormaPago);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@USR_U");
            vector_nombres.Add("@FE_U");
            vector_nombres.Add("@POC");
            vector_nombres.Add("@NRO_BONO_CAJA");
            vector_nombres.Add("@F_PAGO");
            vector_nombres.Add("@NRO_RECIBO_CAJA");
            vector_nombres.Add("@FORMA_PAGO_CAJA");
            string vprocedure = "P_PAGO_BONO_PAGO_CUOTA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        public void Anular_Cuota(int ID)
        {
            db resultado = new db();


            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);


            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");


            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@USR_A");
            vector_nombres.Add("@FE_A");

            string vprocedure = "P_PAGO_BONO_ANULO_CUOTA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }
    }
}