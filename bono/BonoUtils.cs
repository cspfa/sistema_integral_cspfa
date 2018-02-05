using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOCIOS.bono
{
   public  class BonoUtils
    {

       public List<Codigo_Dto_Bono> getCodigos(string ROL)

       {
           List<Codigo_Dto_Bono> lista = new List<Codigo_Dto_Bono>();
           if ( ROL.Contains("TUR"))
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
                          
           } else
               return null;

           return lista;

       
       }
    }
}
