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
  public class bo_Bonos:bo
    {
      public void InsertPagoBono(int Bono, int TipoPago, decimal Monto, string Cuota, string POC, DateTime fecha, int CodInt, int CodCp, DateTime? A_Dto, string User, string Fupdate, string NroBeneficio, string Rol, int Nro_Soc, int Nro_Dep, int Barra, int Nro_Soc_titular, int Nro_dep_titular, int PlanCuenta)
      {
          db resultado = new db();



          ArrayList vector_contenidos = new ArrayList();
          vector_contenidos.Add(0);
          vector_contenidos.Add(Bono);
          vector_contenidos.Add(TipoPago);
          vector_contenidos.Add(Monto);
          vector_contenidos.Add(Cuota);
          vector_contenidos.Add(fecha);
          vector_contenidos.Add(CodInt);
          if (A_Dto == null)
              vector_contenidos.Add("null");
          else
              vector_contenidos.Add(A_Dto);
          vector_contenidos.Add(User);
          vector_contenidos.Add(Fupdate);
          vector_contenidos.Add(NroBeneficio);
          vector_contenidos.Add(Rol);


          vector_contenidos.Add(Nro_Soc);
          vector_contenidos.Add(Nro_Dep);
          vector_contenidos.Add(Barra);
          vector_contenidos.Add(Nro_Soc_titular);
          vector_contenidos.Add(POC);
          vector_contenidos.Add(CodCp);
          vector_contenidos.Add(PlanCuenta);
          vector_contenidos.Add(Nro_dep_titular);

          ArrayList vector_tipos = new ArrayList();

          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.Float");
          vector_tipos.Add("FbDbType.VarChar");
          vector_tipos.Add("FbDbType.VarChar");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.VarChar");
          vector_tipos.Add("FbDbType.VarChar");
          vector_tipos.Add("FbDbType.VarChar");
          vector_tipos.Add("FbDbType.VarChar");
          vector_tipos.Add("FbDbType.VarChar");

          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.Integer");

          vector_tipos.Add("FbDbType.VarChar");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.Integer");
          ArrayList vector_nombres = new ArrayList();


          vector_nombres.Add("@ID");
          vector_nombres.Add("@BONO");
          vector_nombres.Add("@TIPOPAGO");
          vector_nombres.Add("@MONTO");
          vector_nombres.Add("@CUOTA");
          vector_nombres.Add("@FECHA");
          vector_nombres.Add("@CODINT");
          vector_nombres.Add("@A_DTO");
          vector_nombres.Add("@USR_U");
          vector_nombres.Add("@F_U");
          vector_nombres.Add("@NRO_BENEF");
          vector_nombres.Add("@ROL");
          vector_nombres.Add("@NRO_SOC");
          vector_nombres.Add("@NRO_DEP");
          vector_nombres.Add("@BARRA");
          vector_nombres.Add("@NRO_SOCIO_TITULAR");
          vector_nombres.Add("@POC");
          vector_nombres.Add("@CODCP");
          vector_nombres.Add("@PLAN_CUENTA");
          vector_nombres.Add("@NRO_DEP_TITULAR");
          string vprocedure = "P_PAGOS_BONO_I";
          resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

      }
<<<<<<< HEAD

      public void Update_Fecha_Nacimiento(DateTime Fecha_Nacimiento, int ID, int Nro_Soc, int Nro_Dep, int Barra, string Tipo)
      {
          db resultado = new db();



          ArrayList vector_contenidos = new ArrayList();
          vector_contenidos.Add(Fecha_Nacimiento);
          vector_contenidos.Add(System.DateTime.Now);
          vector_contenidos.Add(VGlobales.vp_username.TrimEnd().TrimStart());
          vector_contenidos.Add(ID);
          vector_contenidos.Add(Nro_Soc);
          vector_contenidos.Add(Nro_Dep);
          vector_contenidos.Add(Barra);
          vector_contenidos.Add(Tipo);
        

          ArrayList vector_tipos = new ArrayList();

     
          vector_tipos.Add("FbDbType.VarChar");
          vector_tipos.Add("FbDbType.VarChar");
          vector_tipos.Add("FbDbType.VarChar");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.VarChar");
         
          ArrayList vector_nombres = new ArrayList();


          vector_nombres.Add("@FECHA_NAC");
          vector_nombres.Add("@FECHA");
          vector_nombres.Add("@USR");
          vector_nombres.Add("@ID");
          vector_nombres.Add("@NRO_SOC");
          vector_nombres.Add("@NRO_DEP");
          vector_nombres.Add("@BARRA");
          vector_nombres.Add("@TIPO");

          string vprocedure = "P_FECHA_NAC_UPDATE";
          resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
      
      }
  }
=======
    }
>>>>>>> 101f5219f1f7aa8eff9c9b150ffe2e620f2705cf
}
