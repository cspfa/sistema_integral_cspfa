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
    public class bo_Plan_Cuenta :bo
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


        public void PlanCuenta_Insert(int Socio, int Dep, decimal SaldoInicial, decimal Saldo, int Bono, int Tipo, int TipoPlan,string Nombre_Referente,string DNI_referente,int DNI_TITULAR,int NRO_SOC_TIT,int NRO_DEP_TIT)
        {
            db resultado = new db();



            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Socio);
            vector_contenidos.Add(Dep);
            vector_contenidos.Add(SaldoInicial);
            vector_contenidos.Add(Saldo);
            vector_contenidos.Add(Bono);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add(VGlobales.vp_role);
            vector_contenidos.Add(Tipo);
            vector_contenidos.Add(TipoPlan);
            vector_contenidos.Add(Nombre_Referente);
            vector_contenidos.Add(DNI_referente);
            vector_contenidos.Add(DNI_TITULAR);
            vector_contenidos.Add(NRO_SOC_TIT);
            vector_contenidos.Add(NRO_DEP_TIT);
          

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@NRO_SOCIO");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@SALDO_INICIAL");
            vector_nombres.Add("@SALDO");
            vector_nombres.Add("@BONO");
            vector_nombres.Add("@U_ALTA");
            vector_nombres.Add("@F_ALTA");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@TIPO");
            vector_nombres.Add("@TIPO_PLAN");

            vector_nombres.Add("@REFERENTE");
            vector_nombres.Add("@REFERENTE_DNI");
            vector_nombres.Add("@DNI_TITULAR");

            vector_nombres.Add("@NRO_SOC_TIT");
            vector_nombres.Add("@NRO_DEP_TIT");
          

            string vprocedure = "P_PLAN_CUENTA_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);





        }


        public void PlanCuenta_Baja(int ID)
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

            vector_nombres.Add("@PIN_ID");
            vector_nombres.Add("@PIN_U_BAJA");
            vector_nombres.Add("@PIN_F_BAJA");
           

            string vprocedure = "P_PLAN_CUENTA_BAJA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }
    
    }
}
