using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SOCIOS.bono
{
    public class DatoSocio
    {
        public string ID_TITULAR { get; set; }
        public string NRO_SOCIO  { get; set; }
        public string NRO_DEP    { get; set; }
        public string BARRA      { get; set; }
        public string APELLIDO   { get; set; }
        public string NOMBRE     { get; set; }
        public string TIPO       { get; set; }
        public string NUM_DOC    { get; set; }
        public string ACRJP2     { get; set; }
        public string SOCIO      { get; set; }
        public string TELEFONO   { get; set; }
        public string MAIL       { get; set; }
        public string NACIMIENTO { get; set; }
        public string EDAD       { get; set; }
        public string LOCALIDAD  { get; set; }
        public string DOMICILIO  { get; set; }
        public string CAT_SOC    { get; set; }
        public string TABLA      { get; set; }
        public string BAJA       { get; set; }
     
    }

    

    public class CabeceraTitular
    {
        public string NombreTitular       { get; set; }
        public string TipoTitular         { get; set; }
        public string NroSocioTitular     { get; set; }
        public string NroDepTitular       { get; set; }
        public string NroAfiliadoTitular  { get; set; }
        public string NroBeneficioTitular { get; set; }
        public string FechaNac            { get; set; }
        public string Dni                 { get; set; }
        public string Ci                  { get; set; }
        public string Sexo                { get; set; }
        public string Domicilio           { get; set; }
        public string Localidad           { get; set; }
        public string Telefonos           { get; set; }

        public int AAR                    { get; set; }
        public int ACRJP1                 { get; set; }
        public int ACRJP2                 { get; set; }
        public int ACRJP3                 { get; set; }
        public int PAR                    { get; set; }
        public int PCRJP1                 { get; set; }
        public int PCRJP2                 { get; set; }
        public int         PCRJP3         { get; set; }
        public string ApellidoTitular     { get;set;}
        public string Procedencia         { get; set; }
        public string COD_DTO             { get; set; }
        public string NOMBRE              { get; set; }
        public string APELLIDO            { get; set; }

    }

    public class BonoOdonto
    {
        public int Profesional { get; set; }
        public int Prestacion { get; set; }
        public string dProfesional { get; set; }
        public string dPrestacion { get; set; }
        public string Fecha { get; set; }
        public string ID { get; set; }

    }
   
    public class Tratamiento
    {
       public int Secuencia   { get; set; }
       public int ID { get; set; }
       public int CodInt { get; set; }
       public int CodCp { get; set; }
       public string  Descripcion { get; set; }
       public int SecAct { get; set; }
       public decimal Monto { get; set; }
    
    }

    public class Pasaje
    {

        public int Cantidad { get; set; }
        public string NroBoleto { get; set; }
        public string FechaSalida { get; set; }
        public int Origen { get; set; }
        public string OrigenText { get; set; }
        public int Destino { get; set; }
        public string DestinoText { get; set; } 
       
        public decimal Monto { get; set; }
     

        
    }

    public class PersonaPasaje
    {

        
        public string Nombre { get; set; }
        public string Dni    { get; set; }
  



    }


    public class PagoBono

    {
       // public int      ID          {get;set;}

        public string   DES_FECHA     {get;set;}
        public string   DES_TIPO    {get;set;}
        public decimal  MONTO       {get;set;}
        public string   MES         {get;set;}
        public string   ANIO        {get;set;}
        public string   CUOTA       {get;set;}
        
        public string   POC         {get;set;}
        public DateTime FECHA       {get;set;}
        public int TIPO             {get;set;}
        public DateTime FECHA_DTO   {get;set;}
        public bool Ingreso_Caja    {get;set;}
    
    
    }


   

    public class handlerDatosSocios
    {
        #region Variables
        private CabeceraTitular _CAB;

        public CabeceraTitular CAB
        {
            get { return _CAB; }
            set { _CAB = value; }
        }


        private List<DatoSocio> _Socios;

        public List<DatoSocio> Socios
        {
            get { return _Socios; }
            set { _Socios = value; }
        }

        private nombreSocio ns;
        internal nombreSocio _ns
        {
            get
            {
                return ns;
            }
            set
            {
                ns = value;
            }

        }
        private tipoSocio ts;

        internal tipoSocio _ts
        {
            get { return ts; }
            set { ts = value; }
        }

        private edad ee;

        internal edad _ee
        {
            get { return ee; }
            set { ee = value; }
        }

        bo dlog;

        #endregion
        #region Constructor
        public handlerDatosSocios(string pSocTitular, string pDepTitular)
        {
            if (!((pSocTitular.Length==pDepTitular.Length && pDepTitular.Length==0)))
            //Obtengo Datos de Cliente
            {
                this.SetearDatosCabecera(pSocTitular, pDepTitular);
            }
            else
            {

                CAB = new CabeceraTitular();
                CAB.NroSocioTitular = "";
                CAB.NroDepTitular = "";
                CAB.NombreTitular = "";
                CAB.NOMBRE = "";
                CAB.APELLIDO = "";
                CAB.TipoTitular = "";
                CAB.NroAfiliadoTitular = "";
                CAB.AAR = 0;
                CAB.ACRJP1 = 0;
                CAB.ACRJP2 = 0;
                CAB.ACRJP3 = 0;
                CAB.PAR = 0;
                CAB.PCRJP1 = 0;
                CAB.PCRJP2 = 0;
                CAB.PCRJP3 = 0;
                CAB.NroBeneficioTitular = "";
                CAB.FechaNac = "";
                CAB.Dni = "";
                CAB.Ci = "";
                CAB.COD_DTO = "";
                CAB.Sexo = "";
                CAB.Domicilio = "";

                CAB.Localidad = "";
                CAB.Procedencia = "";
                CAB.Telefonos = "";
                
            
            }



        }
        #endregion

        #region MEtodos

        private void SetearDatosCabecera(string NRO_SOCIO, string NRO_DEP)
        {
            string Query = "SELECT A.*, B.FOTO, (SELECT C.SIGN FROM CODIGOS C WHERE 'CA0'||A.CAT_SOC = C.CODIGO) AS CATEGORIA, (SELECT C.SIGN FROM CODIGOS C WHERE 'DE'||A.DESTINO = C.CODIGO) AS DEST, ";
            Query += "(SELECT C.SIGN FROM CODIGOS C WHERE 'PR00'||A.PRO_PAR = C.CODIGO) AS PROVINCIA, (SELECT C.SIGN FROM CODIGOS C WHERE 'TC000'||A.TIP_CAR = C.CODIGO) AS TIPO_CARNET, (SELECT C.SIGN FROM CODIGOS C WHERE 'JE'||A.JERARQ = C.CODIGO) AS JERARQUIA, (SELECT C.SIGN FROM CODIGOS C WHERE 'BP000'||A.M_BAJPO = C.CODIGO) AS BAJPO ";
            Query += "FROM TITULAR A, TITULAR_IMAGEN B WHERE A.ID_TITULAR = B.ID_TITULAR AND A.NRO_SOC = " + NRO_SOCIO + " AND A.NRO_DEP = " + NRO_DEP + ";";
            DataRow[] foundRows;

            dlog = new bo();

            foundRows = dlog.BO_EjecutoDataTable(Query).Select();
            if (foundRows.Length > 0)
            {
                CAB = new CabeceraTitular();
                CAB.NroSocioTitular = foundRows[0][11].ToString().Trim();
                CAB.NroDepTitular = foundRows[0][12].ToString().Trim();
                CAB.NombreTitular = foundRows[0][10].ToString().Trim() + "   " + foundRows[0][9].ToString().Trim();
                CAB.NOMBRE = foundRows[0][10].ToString().Trim();
                CAB.APELLIDO = foundRows[0][9].ToString().Trim();
                CAB.TipoTitular = foundRows[0][88].ToString().Trim();
                CAB.NroAfiliadoTitular = foundRows[0][1].ToString().Trim() + '/' + foundRows[0][3].ToString().Trim();
                CAB.AAR                = foundRows[0][1].ToString().Trim().Length >0 ? Int32.Parse(foundRows[0][1].ToString().Trim()):0;
                CAB.ACRJP1             = foundRows[0][2].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][2].ToString().Trim()) : 0;
                CAB.ACRJP2             = foundRows[0][3].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][3].ToString().Trim()) : 0;
                CAB.ACRJP3             = foundRows[0][4].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][4].ToString().Trim()) : 0;
                CAB.PAR                = foundRows[0][5].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][5].ToString().Trim()) : 0;
                CAB.PCRJP1             = foundRows[0][6].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][6].ToString().Trim()) : 0;
                CAB.PCRJP2             = foundRows[0][7].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][7].ToString().Trim()) : 0;
                CAB.PCRJP3             = foundRows[0][8].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][8].ToString().Trim()) : 0;
                CAB.NroBeneficioTitular = foundRows[0][6].ToString().Trim() + '/' + foundRows[0][7].ToString().Trim() + '/' + foundRows[0][8].ToString().Trim();
                CAB.FechaNac = foundRows[0][21].ToString().Trim();
                CAB.Dni = foundRows[0][19].ToString().Trim();
                CAB.Ci = foundRows[0][20].ToString().Trim();
                CAB.COD_DTO = foundRows[0][38].ToString().Trim();
                CAB.Sexo = foundRows[0][54].ToString().Trim();
                CAB.Domicilio = foundRows[0][22].ToString().Trim() + " -  NRO  :  " + foundRows[0][23].ToString().Trim() + " PISO  : " + foundRows[0][24].ToString().Trim() +
                                           " DEPTO  :" + foundRows[0][25].ToString().Trim();
                CAB.Localidad    = foundRows[0][26].ToString().Trim() + "-" + foundRows[0][27].ToString().Trim();
                CAB.Procedencia  = foundRows[0][26].ToString().Trim() + "-" + foundRows[0][27].ToString().Trim();
                CAB.Telefonos = foundRows[0][29].ToString().Trim() + foundRows[0][30].ToString().Trim() + "  " + foundRows[0][31].ToString().Trim() + foundRows[0][32].ToString().Trim();

            }






        }

        public CabeceraTitular PersonaXdni (string DNI)
        {
            string Query = "SELECT A.*, B.FOTO, (SELECT C.SIGN FROM CODIGOS C WHERE 'CA0'||A.CAT_SOC = C.CODIGO) AS CATEGORIA, (SELECT C.SIGN FROM CODIGOS C WHERE 'DE'||A.DESTINO = C.CODIGO) AS DEST, ";
            Query += "(SELECT C.SIGN FROM CODIGOS C WHERE 'PR00'||A.PRO_PAR = C.CODIGO) AS PROVINCIA, (SELECT C.SIGN FROM CODIGOS C WHERE 'TC000'||A.TIP_CAR = C.CODIGO) AS TIPO_CARNET, (SELECT C.SIGN FROM CODIGOS C WHERE 'JE'||A.JERARQ = C.CODIGO) AS JERARQUIA, (SELECT C.SIGN FROM CODIGOS C WHERE 'BP000'||A.M_BAJPO = C.CODIGO) AS BAJPO ";
            Query += "FROM TITULAR A, TITULAR_IMAGEN B WHERE A.ID_TITULAR = B.ID_TITULAR AND A.NUM_DOC = " + DNI + ";";
            DataRow[] foundRows;

            dlog = new bo();

            CabeceraTitular CabeceraAux = new CabeceraTitular();

            foundRows = dlog.BO_EjecutoDataTable(Query).Select();
            if (foundRows.Length > 0)
            {

                CabeceraAux.NroSocioTitular = foundRows[0][11].ToString().Trim();
                CabeceraAux.NroDepTitular = foundRows[0][12].ToString().Trim();
                CabeceraAux.NombreTitular = foundRows[0][10].ToString().Trim();
                CabeceraAux.ApellidoTitular =  foundRows[0][9].ToString().Trim();
                CabeceraAux.TipoTitular = foundRows[0][93].ToString().Trim();
                CabeceraAux.NroAfiliadoTitular = foundRows[0][1].ToString().Trim() + '/' + foundRows[0][3].ToString().Trim();
                CabeceraAux.AAR = foundRows[0][1].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][1].ToString().Trim()) : 0;
                CabeceraAux.ACRJP1 = foundRows[0][2].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][2].ToString().Trim()) : 0;
                CabeceraAux.ACRJP2 = foundRows[0][3].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][3].ToString().Trim()) : 0;
                CabeceraAux.ACRJP3 = foundRows[0][4].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][4].ToString().Trim()) : 0;
                CabeceraAux.PAR = foundRows[0][5].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][5].ToString().Trim()) : 0;
                CabeceraAux.PCRJP1 = foundRows[0][6].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][6].ToString().Trim()) : 0;
                CabeceraAux.PCRJP2 = foundRows[0][7].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][7].ToString().Trim()) : 0;
                CabeceraAux.PCRJP3 = foundRows[0][8].ToString().Trim().Length > 0 ? Int32.Parse(foundRows[0][8].ToString().Trim()) : 0;
                CabeceraAux.NroBeneficioTitular = foundRows[0][6].ToString().Trim() + '/' + foundRows[0][7].ToString().Trim() + '/' + foundRows[0][8].ToString().Trim();
                CabeceraAux.FechaNac = foundRows[0][21].ToString().Trim();
                CabeceraAux.Dni = foundRows[0][19].ToString().Trim();
                CabeceraAux.Ci = foundRows[0][20].ToString().Trim();
                CabeceraAux.Sexo = foundRows[0][54].ToString().Trim();
                CabeceraAux.Domicilio = foundRows[0][22].ToString().Trim() + " -  NRO  :  " + foundRows[0][23].ToString().Trim() + " PISO  : " + foundRows[0][24].ToString().Trim() +
                                           " DEPTO  :" + foundRows[0][25].ToString().Trim();
                CabeceraAux.Localidad = foundRows[0][26].ToString().Trim() + "-" + foundRows[0][27].ToString().Trim();
                CabeceraAux.Telefonos = foundRows[0][29].ToString().Trim() + foundRows[0][30].ToString().Trim() + "  " + foundRows[0][31].ToString().Trim() + foundRows[0][32].ToString().Trim();
                return CabeceraAux;
            }
            return null;
        }


        public DatoSocio ContactoPersona(DatoSocio ds)
        {
            string Telefono = "";
            string Mail = "";

            switch (ds.TIPO)
            {
                case "TIT":
                    datosContacto(ds.NRO_SOCIO, ds.NRO_DEP, "0", "TIT", "0", "0", Telefono, Mail);

                    break;

                case "ADH":
                    datosContacto("0", "0", ds.BARRA, "ADH", ds.NRO_SOCIO, ds.NRO_DEP, Telefono, Mail);

                    break;

                case "FAM":
                    datosContacto(ds.NRO_SOCIO, ds.NRO_DEP, ds.BARRA, "FAM", "0", "0", Telefono, Mail);

                    break;
            }
            ds.TELEFONO = Telefono;
            ds.MAIL = Mail;

            this.DatosPersona(ds.NRO_SOCIO, ds.NRO_DEP, ds.BARRA, ds.TIPO,ds);

            return ds;


        }

        private void datosContacto(string NRO_SOC, string NRO_DEP, string BARRA, string TIPO, string NRO_ADH, string DEP_ADH, string Telefono, string Email)
        {
            bo dlog = new bo();

            string query = "";



            switch (TIPO)
            {
                case "TIT":
                    query = "SELECT FIRST 1 ID, NRO_SOC, NRO_DEP, BARRA, EMAIL, TELEFONO, INTERESES, OBRA_SOCIAL, ACTUALIZADO, NRO_ADH, DEP_ADH FROM CONTACTO WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = 0 AND (EMAIL != '' OR TELEFONO != '' OR OBRA_SOCIAL != '') ORDER BY ID DESC;";

                    break;

                case "ADH":
                    query = "SELECT FIRST 1 ID, NRO_SOC, NRO_DEP, BARRA, EMAIL, TELEFONO, INTERESES, OBRA_SOCIAL, ACTUALIZADO, NRO_ADH, DEP_ADH FROM CONTACTO WHERE NRO_ADH = " + NRO_ADH + " AND DEP_ADH = " + DEP_ADH + " AND BARRA = " + BARRA + " AND (EMAIL != '' OR TELEFONO != '' OR OBRA_SOCIAL != '') ORDER BY ID DESC;";

                    // this.getIdAdherente(NRO_ADH, DEP_ADH, BARRA);

                    break;

                case "FAM":
                    query = "SELECT FIRST 1 ID, NRO_SOC, NRO_DEP, BARRA, EMAIL, TELEFONO, INTERESES, OBRA_SOCIAL, ACTUALIZADO, NRO_ADH, DEP_ADH FROM CONTACTO WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = " + BARRA + " AND (EMAIL != '' OR TELEFONO != '' OR OBRA_SOCIAL != '') ORDER BY ID DESC;";
                    break;

                case "EMPLEADO":
                    query = "SELECT FIRST 1 ID, NRO_SOC, NRO_DEP, BARRA, EMAIL, TELEFONO, INTERESES, OBRA_SOCIAL, ACTUALIZADO, NRO_ADH, DEP_ADH FROM CONTACTO WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = 0 AND (EMAIL != '' OR TELEFONO != '' OR OBRA_SOCIAL != '') ORDER BY ID DESC;";
                    break;
            }

            //MessageBox.Show(query);

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                Telefono = foundRows[0][5].ToString();
                Email = foundRows[0][4].ToString();
                //tbObraSocialContacto.Text = foundRows[0][7].ToString();

            }
        }


        private void Datos_Adherente(string NRO_SOC, string NRO_DEP, string BARRA, string NRO, DatoSocio DS)
        {
            string query = "select F_NACIMADH  from adherent where    nro_DEPADH=" + NRO_DEP + " and nro_adh=" + NRO_SOC + " and barra=" + BARRA;//+ " and NUM_DOCADH="+  DS.NUM_DOC ;
          
           DataRow[] foundRows;

           foundRows = dlog.BO_EjecutoDataTable(query).Select();

           if (foundRows.Length > 0)
           {
               DS.NACIMIENTO = foundRows[0][0].ToString();
               DS.DOMICILIO = CAB.Domicilio;
               DS.LOCALIDAD = CAB.Localidad;
            
               //tbObraSocialContacto.Text = foundRows[0][7].ToString();

           }

        }
        private void Datos_Titular_Familiar(string NRO_SOC, string NRO_DEP, string BARRA, string TIPO, DatoSocio DS)
        {
            string query = "";

            if (TIPO == "TIT" || TIPO == "EMPLEADO")
                query = "select F_NACIM from titular where nro_soc=" + NRO_SOC + "and nro_dep=" + NRO_DEP;

            else if (TIPO == "FAM")

                query = "select F_NACFAM from FAMILIAR where nro_SOC=" + NRO_SOC + " and nro_dep =" + NRO_DEP + " and barra=" + BARRA;


            //case "EMPLEADO":
            //    query = "SELECT FIRST 1 ID, NRO_SOC, NRO_DEP, BARRA, EMAIL, TELEFONO, INTERESES, OBRA_SOCIAL, ACTUALIZADO, NRO_ADH, DEP_ADH FROM CONTACTO WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = 0 AND (EMAIL != '' OR TELEFONO != '' OR OBRA_SOCIAL != '') ORDER BY ID DESC;";
            //    break;


            //MessageBox.Show(query);

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                DS.NACIMIENTO = foundRows[0][0].ToString();
                DS.DOMICILIO = CAB.Domicilio;
                DS.LOCALIDAD = CAB.Localidad;
                //tbObraSocialContacto.Text = foundRows[0][7].ToString();

            }

        }
        private void DatosPersona(string NRO_SOC, string NRO_DEP, string BARRA, string TIPO, DatoSocio DS)
        {
            bo dlog = new bo();
            SOCIOS.edad ee = new edad();
            string query = "";

            if (TIPO != "ADH")
                Datos_Titular_Familiar(NRO_SOC, NRO_DEP, BARRA, TIPO, DS);
            else
                Datos_Adherente(NRO_SOC, NRO_DEP, BARRA,DS.NRO_SOCIO,DS);

            if (DS.NACIMIENTO.Length > 1)
                DS.EDAD = ee.CALCULAR(DS.NACIMIENTO).ToString();

        }





        #endregion



    }

    public class Codigo_Dto_Bono
    {
        public int CODIGO { get; set; }
        public string DES { get; set; }
    
    }
    public class Comision_Directiva
    {
        public int ID                { get; set; }
        public string CARGO          { get; set; }
        public string NOMBRE         { get; set; }
        public string DESCRIPCION    { get; set; }

    
    }
}

