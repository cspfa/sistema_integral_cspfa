using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;
using SOCIOS.Notificacion;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace SOCIOS.interior
{


    public class serviceInterior
    {

        public List<Contacto> get_Contactos(bool SoloNoVistos)
        {

            string query = @"SELECT * FROM CONTACTO_INTERIOR  WHERE coalesce(FECHA_BAJA,'1') = '1' ";
            List<Contacto> lista = new List<Contacto>();
            bo dlog = new bo();
            if (SoloNoVistos)
                query = query + " AND coalesce(FECHA_VISTO,'1') = '1'  ";
           

            query = query + " order by ID descending";




           DataRow[] foundRows;

           foundRows = dlog.BO_EjecutoDataTable(query).Select();
           int I = 0;
            int Tot = foundRows.Count();
          
            
            if (foundRows.Length >0)
          {
               
              while (I<Tot)

              {
                  Contacto c = new Contacto();
                        c.ID = Int32.Parse( foundRows[I][0].ToString());
                        c.DNI = foundRows[I][1].ToString();
                        c.NRO_SOCIO = foundRows[I][2].ToString();
                        c.NYA = foundRows[I][3].ToString()+ foundRows[I][4].ToString();
                        c.TEL1 = foundRows[I][5].ToString();
                        c.TEL2 = foundRows[I][6].ToString();
                        c.EMAIL = foundRows[I][7].ToString();
                        c.CANTIDAD = Int32.Parse(foundRows[I][8].ToString());
                        if ((foundRows[I][9].ToString().Length > 0))
                            c.HASTA = DateTime.Parse(foundRows[I][9].ToString()).ToShortDateString();
                        if (foundRows[I][10].ToString().Length > 0)
                            c.DESDE = DateTime.Parse(foundRows[I][10].ToString()).ToShortDateString();
                        if (foundRows[I][11].ToString().Length > 0)
                            c.FECHA_CONTACTO = DateTime.Parse(foundRows[I][11].ToString()).ToShortDateString();
                        if (foundRows[I][12].ToString().Length > 0)
                            c.VISTO = DateTime.Parse(foundRows[I][12].ToString()).ToShortDateString();
                        c.USER_VISTO = foundRows[I][13].ToString();
                        c.OBS = foundRows[I][14].ToString();   
                       
                            
                   
                       
                    
                       
                        lista.Add(c);
                        I = I + 1;


                 
              }

           }




          return lista;


       }


        public Contacto get_Contacto(int ID)
        {

            string query = @"SELECT * FROM CONTACTO_INTERIOR  where ID=" + ID.ToString();
           
            bo dlog = new bo();
           

           




            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();
            int I = 0;
            int Tot = foundRows.Count();


            if (foundRows.Length > 0)
            {

                while (I < Tot)
                {
                    Contacto c = new Contacto();
                    c.ID = Int32.Parse(foundRows[I][0].ToString());
                    c.DNI = foundRows[I][1].ToString();
                    c.NRO_SOCIO = foundRows[I][2].ToString();
                    c.NYA = foundRows[I][3].ToString() + foundRows[I][4].ToString();
                    c.TEL1 = foundRows[I][5].ToString();
                    c.TEL2 = foundRows[I][6].ToString();
                    c.EMAIL = foundRows[I][7].ToString();
                    c.CANTIDAD = Int32.Parse(foundRows[I][8].ToString());
                    if ((foundRows[I][9].ToString().Length > 0))
                        c.HASTA = DateTime.Parse(foundRows[I][9].ToString()).ToShortDateString();
                    else
                        c.HASTA = "";

                    if (foundRows[I][10].ToString().Length > 0)
                        c.DESDE = DateTime.Parse(foundRows[I][10].ToString()).ToShortDateString();
                    else
                        c.DESDE = "";

                    if (foundRows[I][11].ToString().Length > 0)
                        c.FECHA_CONTACTO = DateTime.Parse(foundRows[I][11].ToString()).ToShortDateString();
                    else
                        c.FECHA_CONTACTO = "";

                    if (foundRows[I][12].ToString().Length > 0)
                        c.VISTO = DateTime.Parse(foundRows[I][12].ToString()).ToShortDateString();
                    else
                        c.VISTO = "";
                    c.USER_VISTO = foundRows[I][13].ToString();
                    c.OBS = foundRows[I][14].ToString();

                                 
                    if (foundRows[I][15].ToString().Length > 0)
                        c.MOTIVO =Int32.Parse( foundRows[I][15].ToString());
                    else
                        c.MOTIVO = 1;


                    if (foundRows[I][16].ToString().Length > 0)
                        c.PROCEDENCIA = foundRows[I][16].ToString();
                    else
                        c.PROCEDENCIA = "";








                    return c;



                }

            }
            return null;





        }

         
        Notificaciones.Notificacion nf = new Notificaciones.Notificacion();
        private int No_Leidos()

        {
            return this.get_Contactos(true).Count;
        
        }
        public int Calculo_NoLeidos()
        {
            int cantidad = 0;
            cantidad = No_Leidos();
            if (cantidad > 0)
                nf.Push_Notificacion("TIENE NOTIFICACIONES SIN LEER");
            return cantidad;
                  
        
        }

        


    }
}
