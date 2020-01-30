using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace SOCIOS.bono
{
   public  class BonoUtils
   {
       bo dlog = new bo();

       public List<Codigo_Dto_Bono> getCodigos(string ROL)

       {

           List<Codigo_Dto_Bono> lista = new List<Codigo_Dto_Bono>();
           if (ROL.Contains("TUR"))
           {
               Codigo_Dto_Bono item = new Codigo_Dto_Bono();
               item.CODIGO = Int32.Parse(Config.getValor("TURISMO", "COD_TURISMO", 0));
               item.DES = item.CODIGO.ToString() + "- HOTEL";
               lista.Add(item);

               item = new Codigo_Dto_Bono();
               item.CODIGO = Int32.Parse(Config.getValor("TURISMO", "COD_TURISMO", 0));
               item.DES = item.CODIGO.ToString() + "- PAQUETE ";
               lista.Add(item);

               item = new Codigo_Dto_Bono();
               item.CODIGO = Int32.Parse(Config.getValor("TURISMO", "COD_TURISMO", 1));
               item.DES = item.CODIGO.ToString() + "- PASAJES";
               lista.Add(item);

           }
           else if (ROL.Contains("MEDICOS"))
           {
               Codigo_Dto_Bono item = new Codigo_Dto_Bono();
               item.CODIGO = Int32.Parse(Config.getValor("ODON-GENERAL-TAVELLA", "COD_ODONTO", 2));
               item.DES = "ODONTO GENERAL-TAVELLA";
               lista.Add(item);

                item = new Codigo_Dto_Bono();
               item.CODIGO = Int32.Parse(Config.getValor("ODON-GENERAL-ANER", "COD_ODONTO", 2));
               item.DES = "ODONTO GENERAL-ANER";
               lista.Add(item);
              item = new Codigo_Dto_Bono();
               item.CODIGO = Int32.Parse(Config.getValor("ODON-GENERAL-VILLAGRAN", "COD_ODONTO", 2));
               item.DES = "ODONTO GENERAL-VILLAGRAN";
               lista.Add(item);


               item.CODIGO = Int32.Parse(Config.getValor("ODON-ORTO-ANER", "COD_ODONTO", 2));
               item.DES = "ORTODONCIA-ANER";

               lista.Add(item);



           }
           else
               return null;
              

           return lista;

       
       }


       public List<Comision_Directiva> getComision_Directiva()
       {


           List<Comision_Directiva> lista = new List<Comision_Directiva>();
           
           string Query = @"select ID, CARGO,NOMBRE   from comision_directiva  ";

           

           DataRow[] foundRows;

           foundRows = dlog.BO_EjecutoDataTable(Query).Select();
           int I=0;
           foreach(DataRow dr in foundRows)
           {
               Comision_Directiva item = new Comision_Directiva();
               item.ID                 = Int32.Parse( foundRows[I][0].ToString());
               item.CARGO              =foundRows[I][1].ToString();
               item.NOMBRE             = foundRows[I][2].ToString();
               I = I + 1;
               lista.Add(item);

           }

        


           return lista;
         

       }

       public Comision_Directiva getComision_Directiva(int ID)
       {


         

           string Query = @"select ID, CARGO,NOMBRE   from comision_directiva  WHERE ID= " + ID.ToString();
            Comision_Directiva item = new Comision_Directiva();


           DataRow[] foundRows;

           foundRows = dlog.BO_EjecutoDataTable(Query).Select();
           int I = 0;
          if (foundRows.Length >0)
          {
               item.ID = Int32.Parse(foundRows[I][0].ToString());
               item.CARGO = foundRows[I][1].ToString();
               item.NOMBRE = foundRows[I][2].ToString();
              
              

           }




          return item;


       }

       public string Leyenda_Bono_Profesional(int ID_Profesional)

       {
           
           string Query = @"select Leyenda,Nombre   from PROFESIONALES  WHERE ID= " + ID_Profesional.ToString();
           Comision_Directiva item = new Comision_Directiva();


           DataRow[] foundRows;

           foundRows = dlog.BO_EjecutoDataTable(Query).Select();
           int I = 0;
           if (foundRows.Length > 0)
           {

               if (foundRows[I][0].ToString().Length > 0)
                 return  foundRows[I][0].ToString() + " " + foundRows[I][1].ToString();


           }




           return "";
       
       }

       public string LEYENDA_BONO_PROFESIONAL_DESDE_BONO(int pBono)
       {
           string QUERY = "select P.LEYENDA FROM  BONO_ODONTOLOGICO B, PROFESIONALES P  WHERE P.ID=B.PROFESIONAL  and B.ID= " + pBono.ToString();
           DataRow[] foundRows;


           foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


           if (foundRows.Length > 0)
           {

               if (foundRows[0][0].ToString().Length > 0)
                   return foundRows[0][0].ToString();
               else
                   return "";

           }
           return "";

       }

       public int Cuenta_Profesional(int Profesional)

       {

           string QUERY = "select CUENTA   FROM PROFESIONALES WHERE  ID=" +  Profesional.ToString();
           DataRow[] foundRows;


           foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


           if (foundRows.Length > 0)
           {

               if (foundRows[0][0].ToString().Length > 0)
                   return Int32.Parse( foundRows[0][0].ToString());
               else
                   return 0;

           }
           return 0;
       }

    }
}
