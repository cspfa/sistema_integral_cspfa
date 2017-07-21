using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace SOCIOS.Turismo.Hotel
{    
    
    public class DisponibilidadUtils
    {
        HotelUtils hu = new HotelUtils();
        bo dlog = new bo();

        public List<Disponibilidad> ListaDisponibilidad(int Hotel, int Mes, int Anio)

        {
            List<Disponibilidad> disponibilidad = new List<Disponibilidad>();
            List<InfoDisponibilidad> Reservado = new List<InfoDisponibilidad>();
            Reservado = this.Reservado(Hotel, Mes, Anio);



            foreach (Habitacion h in hu.getHabitaciones(Hotel))
            { 
            
               for (int i=1; i<32 ; i ++)
           
                {

                    Disponibilidad habOcupada = this.Ocupada(h, i, Reservado);

                    if (habOcupada != null)
                        disponibilidad.Add(habOcupada);
                    else
                        disponibilidad.Add( new Disponibilidad(i, h.Nombre_Habitacion,""));
                   

                
                }
                       
            
              }


            return disponibilidad;


        
        
        }

        private List<InfoDisponibilidad> Reservado (int HotelID, int Mes,int Anio)


        {
           List<InfoDisponibilidad> Dispo = new List<InfoDisponibilidad>();

           string QUERY = @"select HO.HABITACION_ID , H.NOMBRE , H.HOTEL_ID , HO.PLAZAS, HO.REGISTRO_ID , HO.FECHA , HO.BLOQUEADA from HOTEL_HABITACION_OCUPACION_TEMP HO, HOTEL_HABITACION    H
                            WHERE HO.HABITACION_ID = H.HABITACION_ID AND H.HOTEL_ID =" + HotelID.ToString() + " and extract(month from HO.fecha)=  " + Mes.ToString() + " and extract(year from HO.fecha)= " + Anio.ToString();
            
            DataRow[] foundRows;
            
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {

                foreach (DataRow dr in foundRows)
                {
                    InfoDisponibilidad  dispo  = new InfoDisponibilidad();
                    dispo.Habitacion           = Int32.Parse(dr[0].ToString().Trim());
                    dispo.Habitacion_S         = dr[1].ToString().Trim();
                    dispo.Hotel                = Int32.Parse(dr[2].ToString().Trim());
                    dispo.Plazas               = Int32.Parse(dr[3].ToString().Trim());
                    dispo.Registro             = Int32.Parse(dr[4].ToString().Trim());
                    dispo.Fecha                = DateTime.Parse(dr[5].ToString().Trim());
                    dispo.Bloqueada            = Int32.Parse(dr[6].ToString().Trim());
            

                    
                    Dispo.Add(dispo);

                }

            }
            else
                return null;

            
            return Dispo;

    
    
        }

        public bool MesConReservas(int HotelID, int Mes,int Anio)


        { 
            string QUERY = @"select HO.HABITACION_ID from HOTEL_HABITACION_OCUPACION_TEMP HO, HOTEL_HABITACION    H
                            WHERE HO.HABITACION_ID = H.HABITACION_ID AND H.HOTEL_ID =" + HotelID.ToString() + " and extract(month from HO.fecha)=  " + Mes.ToString() + " and extract(year from HO.fecha)= " + Anio.ToString();
            
            DataRow[] foundRows;
            
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return true;
            }
            else
                return false;


        
        
        
        
        }
        private Disponibilidad Ocupada(Habitacion H , int Dia, List<InfoDisponibilidad> lista)
        {

            if (lista == null)
                return null;
           var item = lista.Where(x=> ( x.Habitacion == H.Habitacion_ID && x.Fecha.Day==Dia)).FirstOrDefault();
           if (item != null)
           {
               Disponibilidad d = new Disponibilidad();
               d.Habitacion = H.Nombre_Habitacion;
               d.Dia = Dia;

               if (item.Bloqueada == 1 || (item.Plazas == H.PLazas))
                   d.Valor = "T";
               else
               {
                   d.Valor = "P";
               }

               return d;

           }
           else
               return null;
        
        
        }

        public List<Ocupacion> Ocupacion(int Habitacion, DateTime Fecha)
        {
            List<Ocupacion> lista = new List<Turismo.Hotel.Ocupacion>();
            string QUERY = @"select  HHT.ID ID ,HHT.SOLICITUD SOLICITUD , H.NOMBRE HOTEL, HB.NOMBRE HABITACION, HHT.PLAZAS PLAZAS ,
                                     HB.PLAZAS TOTAL_HABITACION , HHT.NRO_SOC NRO_SOC ,HHT.NRO_DEP NRO_DEP,HHT.BARRA BARRA ,
                                     HHT.NOMBRE NOMBRE , HHT.APELLIDO APELLIDO ,HHT.REGISTRO_ID REG
                                     from hotel_habitacion_ocupacion_temp   HHT, HOTEL H, HOTEL_HABITACION HB WHERE HHT.HABITACION_ID = HB.HABITACION_ID and H.ID = HB.HOTEL_ID  
                                     and HHT.HABITACION_ID = " + Habitacion.ToString() + " and extract(day from HHT.fecha )=" + Fecha.Day.ToString() + " and  extract(month from HHT.fecha)=  " + Fecha.Month.ToString() + " and extract(year from HHT.fecha)= " + Fecha.Year.ToString();
            
            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {

                foreach (DataRow dr in foundRows)
                {
                    Ocupacion    ocu = new Ocupacion();
                    ocu.ID           = Int32.Parse(dr[0].ToString().Trim());
                    ocu.Solicitud    = Int32.Parse(dr[1].ToString().Trim());
                    ocu.Hotel        = dr[2].ToString().Trim();
                    ocu.Habitacion   = dr[3].ToString().Trim();
                    ocu.Plazas       = Int32.Parse(dr[4].ToString().Trim());
                    ocu.Total        = Int32.Parse(dr[5].ToString().Trim());
                    ocu.NRO_SOC_TIT  = dr[6].ToString().Trim();
                    ocu.NRO_DEP_TIT  = dr[7].ToString().Trim();
                    ocu.BARRA        = dr[8].ToString().Trim();
                    ocu.NOMBRE_TIT   = dr[9].ToString().Trim();
                    ocu.APELLIDO_TIT = dr[10].ToString().Trim();
                    ocu.Reg          = Int32.Parse(dr[11].ToString().Trim());
                                  
                    lista.Add(ocu);

                }

            }
            else
                return null;


            return lista;

    
        
        
        }

        public void Liberar_Ocupacion(int ID)

        {
            dlog.HABITACION_HOTEL_OCUPACION_D(ID);
        
        }
    }



}
