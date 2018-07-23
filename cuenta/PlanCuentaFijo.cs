using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOCIOS.cuenta
{
   public class PlanCuentaFijo
   {
      SOCIOS.BO.bo_Plan_Cuenta dlog_pc = new SOCIOS.BO.bo_Plan_Cuenta();
       public void Nuevo_Plan(int NRO_SOCIO,int NRO_DEP, decimal MONTO, int ID_BONO)
       {
           dlog_pc.PlanCuenta_Insert(NRO_SOCIO,NRO_DEP, MONTO, MONTO, ID_BONO, 5, (int)SOCIOS.CuentaSocio.Tipo_Cuenta.FIJO);
       
       }
       public void Baja_Plan(int ID)
       {
           dlog_pc.PlanCuenta_Baja(ID);
       
       }

    }
}
