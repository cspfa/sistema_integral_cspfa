using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;
using System.Data;
using System.Data.SqlClient;

namespace SOCIOS.bono
{


  public  class UtilsBono
    {
        bo dlog;

    


        public UtilsBono()

        {

            dlog = new bo();
        }
      public bool PlanCuotas(List<bono.PagoBono> PagosBono)
        {
            foreach (bono.PagoBono p in PagosBono)
            {

                if (p.TIPO > 3)
                {
                    return true;
                }
            }
            return false;


        }

        public int Anulado(int pBono)
        {
            string QUERY = "select ID  from  BONO_TURISMO WHERE coalesce(FE_BAJA,'1')='1' and  ID= " + pBono.ToString();
            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


            if (foundRows.Length > 0)
            {
                return 0;
            }
            else
                return 1;



        }

        public decimal SaldoBono(int pBono)

        {


            string QUERY = "select SALDO_INICIAL from  BONO_TURISMO WHERE   ID= " + pBono.ToString();
            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


            if (foundRows.Length > 0)
            {
                return Decimal.Parse(foundRows[0][0].ToString());
            }
            else
                return 0;
        
        
        
        }

        public bool Actividad_Odontologica(int SectAct)

        {

            string QUERY = "  SELECT ID from SECTACT  WHERE Detalle Like '%ODONT%' AND ID= " + SectAct.ToString();
            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


            if (foundRows.Length > 0)
            {
                return true;
            }
            else
                return false;
        
        }





    }
}
