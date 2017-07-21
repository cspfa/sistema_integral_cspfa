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

namespace SOCIOS.descuentos
{
    public class DtoBase
    {

        public int Id_Socio { get; set; }
        public int par { get; set; }
        public int aar { get; set; }
        public int acrjp1 { get; set; }
        public int acrjp2 { get; set; }
        public int acrjp3 { get; set; }
        public int pcrjp1 { get; set; }
        public int pcrjp2 { get; set; }
        public int pcrjp3 { get; set; }
        public int Nro_Socio { get; set; }
        public int Nro_Dep { get; set; }
        public int     Barra { get; set; }
        public decimal Monto { get; set; }
        public int     Origen        { get; set; }
        public string  OrigenDetalle { get; set; }
    }

    public class DtoDeportes : DtoBase
    {
        public string  Tipo              { get; set; }
        public string  Nombre_Apellido   { get; set; }
        public string  DETALLE           { get; set; }
        public string  DNI               { get; set; }
        public string  DNI_TTULAR        { get; set; }
        public string  NOMBRE_TITULAR    { get; set; }
        public string  APELLIDO_TITULAR  { get; set; }
        public string  ROL               { get; set; }
        public DtoDeportes()

        {
            Origen        =    (int)SOCIOS.descuentos.TIPO_ORIGEN.DEPORTES;
            OrigenDetalle =    "DEPORTES";
        
        }
       
    }

}



  