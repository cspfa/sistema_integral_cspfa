using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOCIOS.Turismo.Hotel
{
   
        public class InfoPLazaHotel
        {
            public int Total      { get; set; }
            public int Disponible { get; set; }
            public int Ocupadas   { get; set; }


        }


        public class InfoDisponibilidad

        {
          
            public int            Habitacion   { get; set; }
            public string         Habitacion_S { get; set; }
            public int            Hotel        { get; set; }
            public DateTime       Fecha        { get; set; }
            public int            Registro     { get; set; }
            public int            Bloqueada    { get; set; }
            public int            Plazas       { get; set; }


        }

        public class Disponibilidad 
        
        {
            public int      Dia         { get; set; }
            public string   Habitacion  { get; set; }
            public string   Valor       { get; set; }
         
            public Disponibilidad(int pDia, string pHabitacion, string pValor)

            {
                Dia        = pDia;
                Habitacion = pHabitacion;
                Valor      = pValor;
            
            
            
            }
            public Disponibilidad()

            { 
            
            }
        
        }

        public class Ocupacion
        {
            public int              ID              { get; set; }
            public string           Hotel           { get; set; }
            public int              Solicitud       { get; set; }
            public string           Habitacion      { get; set; }
            public int              Plazas          { get; set; }
            public int              Total           { get; set; }
            public string           NRO_SOC_TIT     { get; set; }
            public string           NRO_DEP_TIT     { get; set; }
            public string           BARRA           { get; set; }
            public string           NOMBRE_TIT      { get; set; }
            public string           APELLIDO_TIT    { get; set; }
            public int              Reg             { get; set; }
        }
        
}
