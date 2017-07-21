using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace SOCIOS.Turismo.Hotel
{


    public class HotelUtils
    {
        bo dlog = new bo();
        public InfoPLazaHotel getInfoPLazas(int HotelID,DateTime fecha)
        {
            //Al Final,muestro resultados en la clase
            InfoPLazaHotel info = new InfoPLazaHotel();
            info.Total = this.TotalPLazasHotel(HotelID);
            info.Ocupadas = this.TotalPLazasReservadas(HotelID, fecha);
            info.Disponible = info.Total - info.Ocupadas;
            return info;
    


        }



        public List<Habitacion> HabitacionesDisponibles(int Hotel, DateTime Fecha,int Plazas)
        {
            List<Habitacion> lista = new List<Habitacion>();



            foreach (Habitacion hab in this.getHabitaciones(Hotel))

            {

                hab.Disponibles = this.PLazas_Disponibes(hab, Fecha);
                
                if ((hab.Disponibles >= Plazas))
                            lista.Add(hab);
                hab.Fecha = Fecha;


            
            
            }

            return lista;
        
        
        
        
        
        }



        #region Privadas

        private int TotalPLazasHotel(int HotelID)


        {
            string QUERY = "select sum(plazas) from  hotel_habitacion where hotel_id=" + HotelID.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return Int32.Parse(foundRows[0][0].ToString().Trim());

            }
            else
                return 0;
        
        }


        

        private int TotalPLazasReservadas(int HotelID, DateTime Fecha)
        {

            int Bloqueadas = 0;
            int Reservas = 0;

            string QUERY = @"select SUM(HAB.PLAZAS)  from hotel_habitacion_ocupacion_temp RES    , HOTEL_HABITACION HAB 
                             WHERE           RES.HABITACION_ID = HAB.HABITACION_ID       and RES.BLOQUEADA=1  
                             and    Extract (Day from RES.FECHA)={0} 
                             and Extract (Month from RES.Fecha) = {1}
                             and Extract (year from RES.fecha ) ={2} and HAB.HOTEL_ID = {3}";

            QUERY.Replace("{0}", Fecha.Day.ToString());
            QUERY.Replace("{1}", Fecha.Month.ToString());
            QUERY.Replace("{2}", Fecha.Year.ToString());
            QUERY.Replace("{3}", HotelID.ToString());
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                
                try
                {
                    Bloqueadas= Int32.Parse(foundRows[0][0].ToString().Trim()); 
                }
                
                catch
                {
                    Bloqueadas = 0;
                }


            }
            else
               Bloqueadas =0;



            QUERY = @"select SUM(RES.PLAZAS)  from hotel_habitacion_ocupacion_temp RES    , HOTEL_HABITACION HAB 
                             WHERE           RES.HABITACION_ID = HAB.HABITACION_ID       and RES.BLOQUEADA=0  
                             and    Extract (Day from RES.FECHA)={0} 
                             and Extract (Month from RES.Fecha) = {1}
                             and Extract (year from RES.fecha ) ={2} and HAB.HOTEL_ID = {3}";

              QUERY.Replace("{0}", Fecha.Day.ToString());
              QUERY.Replace("{1}", Fecha.Month.ToString());
              QUERY.Replace("{2}", Fecha.Year.ToString());
              QUERY.Replace("{3}", HotelID.ToString());
              foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

             if (foundRows.Length > 0)
                 {

                   try
                      {
                        Reservas = Int32.Parse(foundRows[0][0].ToString().Trim());
                      }

                   catch
                      {
                        Reservas = 0;
                      }


                    }
                    else
                        Reservas= 0;


             return Reservas + Bloqueadas;
        }



        public List<Habitacion> getHabitaciones(int HotelID)

        {


            List<Habitacion> habitaciones = new List<Habitacion>();

            string QUERY = @"select HB.ID ,HB.Hotel_ID,H.NOMBRE , HB.PLAZAS,HB.HABITACION_ID    ,HT.ID TIPO, HB.NOMBRE,HT.TIPO
                             from  hotel_habitacion HB , Hotel H, HOTEL_Habitacion_Tipo HT
                             where H.ID =HB.HOTEL_ID  and HT.ID = HB.HABITACION_ID AND HB.HOTEL_ID=" + HotelID.ToString();
            
            DataRow[] foundRows;
            
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {

                foreach (DataRow dr in foundRows)
                {
                    Habitacion hab = new Habitacion();
                    hab.ID                = Int32.Parse(dr[0].ToString().Trim());
                    hab.Hotel_ID          = Int32.Parse(dr[1].ToString().Trim());
                    hab.Hotel             = dr[2].ToString().Trim();
                    hab.PLazas            = Int32.Parse(dr[3].ToString().Trim());
                    hab.Habitacion_ID     = Int32.Parse(dr[4].ToString().Trim());
                    hab.Tipo              = Int32.Parse(dr[5].ToString().Trim());
                    hab.Nombre_Habitacion = dr[6].ToString().Trim() + "-" + dr[7].ToString().Trim();
                    hab.Tipo_Habitacion   = dr[7].ToString().Trim();
                    
                    habitaciones.Add(hab);

                }

            }
           

            
            return habitaciones;
        
        }


        public void ComboHabitacion(ComboBox combo, int Hotel)


        {
            string Query = @"select H.HABITACION_ID ID, (H.NOMBRE ||'-'|| T.TIPO) NOMBRE from Hotel_Habitacion H , Hotel_Habitacion_Tipo T
                             WHERE H.HABITACION_ID = T.ID AND H.HOTEL_ID =  " + Hotel.ToString();
           


            combo.DataSource = null;
            combo.Items.Clear();
            combo.DataSource = dlog.BO_EjecutoDataTable(Query);
            combo.DisplayMember = "NOMBRE";
            combo.ValueMember = "ID";
            combo.SelectedItem = 1;
        
        }


        private int PLazas_Disponibes(Habitacion hab, DateTime Fecha)

        {

            
            if (this.Habitacion_Bloqueada(hab.Habitacion_ID,Fecha))
                return 0;

            string QUERY = @"select coalesce (sum(plazas),0) from hotel_habitacion_Ocupacion_temp
                             where HABITACION_ID=" +  hab.Habitacion_ID.ToString() + " and  Extract(day from fecha)=" + Fecha.Day.ToString() + "  and extract(month from fecha)=" + Fecha.Month.ToString() + " and extract(year from fecha )=" + Fecha.Year.ToString();
           
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                
              return (hab.PLazas - Int32.Parse(foundRows[0][0].ToString().Trim()));
            }
            else
            {
                return hab.PLazas;
            
            }


        
        
        
        }

        private bool Habitacion_Bloqueada(int HabitacionID, DateTime Fecha)

        {

            string QUERY = @"select ID, plazas from hotel_habitacion_Ocupacion_temp
                             where HABITACION_ID=" + HabitacionID.ToString() + " and  Extract(day from fecha)=" + Fecha.Day.ToString() + "  and extract(month from fecha)=" + Fecha.Month.ToString() + " and extract(year from fecha )=" + Fecha.Year.ToString() + "   and Bloqueada=1 ";
            
            DataRow[] foundRows;
          
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        
        }









        #endregion



    }
}
