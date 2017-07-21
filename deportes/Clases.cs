using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace SOCIOS.deportes
{
   public class cCarnet
    {
        public string Alta { get; set; }
        public string Apto { get; set; }
        public string DNI  { get; set; }
        public string Tipo { get; set; }
        public string Socio { get; set; }
        public string Numero { get; set; }
        public byte[] Barcode { get; set; }
        public byte[] Foto { get; set; }
        public string BarcodeString { get; set; }

        

    }

   public class Vencimiento
   {

       public string Resultado { get; set; }
       public string Tipo { get; set; }
       public string Nombre { get; set; }
       public string Apellido { get; set; }
       public string Email { get; set; }
       public DateTime Fecha { get; set; }
       


   }

   public class VencimientoXLS
   {
       public string    NroSocio       { get; set; }
       public string    NroDepuracion  { get; set; }
       public string    BARRA          { get; set; }
       public string    Nombre         { get; set; }
       public string    Apellido       { get; set; }
       public string    Fecha          { get; set; }
       public string    Rol            { get; set; }

   }

   public class DeportesItem
   {
       public int  ID_ROL                { get; set; }
       public int  ID_TTULAR             { get; set; }
       public int  NRO_DEP               { get; set; }
       public int  NRO_SOCIO             { get; set; }
       public int  BARRA                 { get; set; }
       public int  ID_ADHERENTE          { get; set; }
       public DateTime  FE_APTO          { get; set; }
       public DateTime  FE_CARNET        { get; set; }
       public int  TIPO_CARNET           { get; set; }
       public int MOROSO                 { get; set; }
       public string USR_MODIFICACION    { get; set; }
       public DateTime FE_MODIFICACION   { get; set; }
       public string USR_ALTA            { get; set; }
       public DateTime FE_ALTA           { get; set; }
       public string DNI                 { get; set; }
       public DateTime FE_VENCIMIENTO    { get; set; }
       public string POC                 { get; set; }
       public decimal MONTO_MORA         { get; set; }
       public DateTime ANIO_MORA         { get; set; }
       public string NOMBRE              { get; set; }
       public string APELLIDO            { get; set; }
       public string EMAIL               { get; set; }
       public string OBS                 { get; set; }
       public DateTime FE_BAJA           { get; set; }
       public string USR_BAJA            { get; set; }
       public string SUSPENDIDO          { get; set; }
       public string ROL                 { get; set; }
       public int ID_BASE                { get; set; }
   }

    public class Deporte_Importacion : DeportesItem
    {
        public string TIPO { get; set; }
        public int ID_TITULAR_ANT { get; set; }
        public int NRO_SOCIO_ANT { get; set; }
        public int NRO_DEP_ANT    { get; set; }
    }


   public class DeporteX_ROL

   {
       public string ROL         { get; set; }
       public string Fecha       { get; set; }
       public string FechaBaja   { get; set; }
       public string User        { get; set; }
       public int    ID_ROL      { get; set; }
       public int    ID_REGISTRO { get; set; }

   
   }

   public class ActividadItem
   {
       public int ID_DEPORTE        { get; set; }
       public int ID_TTULAR         { get; set; }
       public int NRO_DEP           { get; set; }
       public int NRO_SOCIO         { get; set; }
       public int BARRA             { get; set; }
       public DateTime ANIO_DTO     { get; set; }
       public string CAT_SOC        { get; set; }
       public int PROFESIONAL       { get; set; }
       public decimal ARANCEL       { get; set; }
       public string USR_ALTA       { get; set; }
       public DateTime FE_ALTA      { get; set; }
       public string USR_U          { get; set; }
       public DateTime FE_U         { get; set; }
       public int ID_ARANCEL        { get; set; }
       public int SECTACT           { get; set; }
       public string ESTADO         { get; set; }
       public DateTime FE_BAJA      { get; set; }
       public string USR_BAJA       { get; set; }
       public string ROL            { get; set; }
       public int ID_ROL            { get; set; }
       public int POR_DTO           { get; set; }


      

   }

   public class VencimientoEdad

   {
       public string   Nombre     { get; set; }
       public string   Apellido   { get; set; }
       public string   Socio      { get; set; }
       public string   Dep        { get; set; }
       public string   Barra      { get; set; }
       public DateTime Nacimiento { get; set; }
       public int      ID         { get; set; }
       
       public List<VencimientoEdad> getDataReporteVencimientoEdad()

       {
           
           List<VencimientoEdad> vencimiento = new List<VencimientoEdad>();
           string Query = "select distinct   D.ID ID, D.NOMBRE NOMBRE, D.APELLIDO APELLIDO , D.NRO_SOCIO SOCIO,  D.NRO_DEP DEP, D.BARRA,  F.F_NACFAM NACIMIENTO from deportes_Adm D , FAMILIAR F where    D.Barra > 3 and F.NRO_DEP = D.NRO_DEP AND F.NRO_SOC = D.NRO_SOCIO and coalesce(D.FE_BAJA,'1') ='1'";
           bo_Deportes dlog = new bo_Deportes();
           
            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(Query).Select();
                DateTime fecha= new DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,1);
           


           foreach(DataRow r in dlog.BO_EjecutoDataTable(Query).Rows )

           {
               VencimientoEdad ve = new VencimientoEdad();
               ve.ID = Int32.Parse(r[0].ToString());
               ve.Nombre = r[1].ToString();
               ve.Apellido = r[2].ToString();
               ve.Socio = r[3].ToString();
               ve.Dep = r[4].ToString();
               ve.Barra =r[5].ToString();
               ve.Nacimiento = DateTime.Parse(r[6].ToString());
               if ((fecha - ve.Nacimiento).Days < 30)
                   vencimiento.Add(ve);

           
           }

           


      
         


           return vencimiento;
       
       
       }

       public void ProcesoBaja()
       {

           List<VencimientoEdad> vencimiento = new List<VencimientoEdad>();
          
           foreach( VencimientoEdad v in   this.getDataReporteVencimientoEdad() )
           {
           
                   string Query = "select  ID from SOCIO_ACTIVIDADES  where ID_DEPORTE =" + v.ID.ToString()
                       ;
                   bo_Deportes dlog = new bo_Deportes();

                   DataRow[] foundRows;

                   foundRows = dlog.BO_EjecutoDataTable(Query).Select();
                



                   foreach (DataRow r in dlog.BO_EjecutoDataTable(Query).Rows)
                   {
                      
                       
                       dlog.BajaSociosActividad(Int32.Parse(r[0].ToString()), System.DateTime.Now, 1);


                   }





           }


           


       }
   
   
   }

   public class InfoPersonaDeporte
   {
       public string DNI       { get; set; }
       public string NOMBRE    { get; set; }
       public string APELLIDO  { get; set; }
       public string SECACT    { get; set; }
       public string NRO_SOCIO { get; set; }
       public string NRO_DEP   { get; set; }
       public string BARRA     { get; set; }

   }

   public class Apto_Foto
   {
       public System.Drawing.Image Imagen         { get; set; }
       public DateTime             FechaApto      { get; set; }
   }


   

   

    



}
