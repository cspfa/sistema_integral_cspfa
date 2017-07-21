using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOCIOS.Turismo
{
   public  class Solicitud
   {
       public int ID                 { get; set; }
       public int Nro_Socio          { get;set; }
       public int Nro_Dep            { get;set; }
       public int Barra              { get;set; }
       public string DNI             { get;set; }
       public string Nombre          { get; set; }
       public string Apellido        { get; set; }
       public string Tipo            { get; set; }
       public int Nro_Adh            { get; set; }
       public int Nro_Dep_Adh        { get; set; }
       public DateTime Desde         { get; set; }
       public DateTime Hasta         { get; set; }
       public string Habitacion      { get; set; }
       public int    Habitacion_ID   { get; set; }
       public int    Plazas          { get; set; }
       public int Procesada          { get; set; }
    }

   public class Habitacion 
   
   {
       public int ID                                 {get;set;}
       public int Habitacion_ID                      {get;set;}
       public string Nombre_Habitacion               {get;set;}
       public int Hotel_ID                           {get;set;}
       public string Hotel                           {get;set;}
       public int Tipo                               {get;set;}
       public string Tipo_Habitacion                 {get;set;} 
       public int PLazas                             {get;set;}
       public int Disponibles                        {get;set;}
       public DateTime Fecha                         {get;set;}
       public int  Bloqueo                           {get;set;}
       public List<SOCIOS.Turismo.GridPersona> Personas { get; set; }

       public Habitacion()

       { 
       }
       public Habitacion(int pID, int pHabitacion_ID, string pNombre_HAbitacion, int pHotel_ID, string pHotel, int pTipo, string pTipo_Habitacion, int pPLazas, int pDisponibles, DateTime pFecha,bool pBloqueo)

       {
           ID                 = pID;
           Habitacion_ID      = pHabitacion_ID;
           Nombre_Habitacion  = pNombre_HAbitacion;
           Hotel_ID           = pHotel_ID;
           Hotel              = pHotel;
           Tipo               = pTipo;
           Tipo_Habitacion    = pTipo_Habitacion;
           pPLazas            = pPLazas;
           Disponibles        = pDisponibles;
           Fecha              = pFecha;
           if (pBloqueo)
               Bloqueo = 1;
           else
               Bloqueo = 0;
       
       }
   
   
   }

   

   public class DatoFecha
   {
       public DateTime F                { get; set; }
       public bool     lleno            { get; set; }
       
       
       public DatoFecha(DateTime pFecha, bool pLleno)
       {
        
           F     = pFecha;
           lleno = pLleno;
 
       
       }
   }

   public class Personas_Registro_Solicitud 
   {

       public string DNI { get; set; }
       public string Nombre   { get; set; }
       public string Apellido { get; set; }

       public Personas_Registro_Solicitud(string pDni, string pNombre, string pApellido)
       {
           DNI      = pDni;
           Nombre   = pNombre;
           Apellido = pApellido;
       }
   
   
   }


   
    
    


   

    
}
