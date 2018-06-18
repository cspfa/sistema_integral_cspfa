using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Data;


namespace SOCIOS.Turismo
{
    public class Salida
    {
        public int       ID              { get; set; }
        public string    Nombre          { get; set; }
        public DateTime Fecha            { get; set; }
        public int      Agotado          { get; set; }
        public int      Prov_Desde       { get; set; }
        public string  Prov_Desde_Nombre { get; set; }
        public int      Prov_Hasta       { get; set; }
        public string Prov_Hasta_Nombre  { get; set; }
        public int      Operador         { get; set; }
        public string   Operador_Nombre  { get; set; }
        public int      Loc_Desde        { get; set; }
        public string   Loc_Desde_Nombre { get; set; }
        public int      Loc_Hasta        { get; set; }
        public string   Loc_Hasta_Nombre { get; set; }
        public decimal  Socio            { get; set; }
        public decimal  Invitado         { get; set; }
        public decimal  InterCirculo     { get; set; }
        public string   Estadia          { get; set; }
        public int      Regimen          { get; set; }
        public string   Regimen_Nombre   { get; set; }
        public int      Traslado         { get; set; }
        public string   Traslado_Nombre  { get; set; }
        public int      Tipo             { get; set; }
        public string   Tipo_Nombre      { get; set; }
        public int      Hotel            { get; set; }
        public string   Hotel_Nombre     { get; set; }
        public int      Destacado        { get; set; }
        public string   Moneda           { get; set; }
        public string   Observaciones    { get; set; }
        public int      Diaria           { get; set; }
        public decimal  Menor            { get; set; }
        public decimal  Coche_Cama       { get; set; }

    
    }

    public class voucherHotel
    {  //Hotel
        public int Hotel                 { get; set; }
        public string Hotel_Nombre       { get; set; }
   
      
        public string Lugar              { get; set; }
        public string Telefono           { get; set; }
        public string Direccion          { get; set; }
        public string CheckIn            { get; set; }
        public string CheckOut           { get; set; }
        public string ObsHotel          { get; set; }
        // Voucher
        public int    Regimen            { get; set; }
        public string Regimen_Nombre     { get; set; }

        public int    Habitacion         { get; set; }
        public string Habitacion_Nombre  { get; set; }
     

        public int Pasajeros             { get; set; }
        public string Estadia            { get; set; }
        public string Desde              { get; set; }
        public string Hasta              { get; set; }
        public Boolean BonoSocial        { get; set; }
        public string Nro_Habitacion     { get; set; }
        public string Motivo             { get; set; }
        public string OBS                { get; set; }
        public int ID_ROL_BONO           { get; set; }
        public string ROL                { get; set; }

    }

    
    public class GridPersona
    {
      
        public string  Dni                  { get; set; }
        public string  Nombre               { get; set; }
        public string  Apellido             { get; set; }
        public string  Tipo                 { get; set; }
        public string  Nacimiento           { get; set; }
        public int     NroSocioTitular      { get; set; }
        public int     NroSocio             { get; set; }
        public int     NroDep               { get; set; }
        public int     Barra                { get; set; }
    
        public string  Edad                 { get; set; }
        public string  Telefono             { get; set; }
        public string  Mail                 { get; set; }
        public int Origen                   { get; set; }
         
    }

    public class ID_ROL
    {
        public string ROL  { get; set; }
        public int ID  { get; set; }
        public string INFO { get; set; }

        public ID_ROL(int ID)

        {
            bo dlog = new bo();
            string QUERY = "Select ID_ROL,ROL  from BONO_TURISMO  WHERE ID= " + ID.ToString();
            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                ID =  Int32.Parse(foundRows[0][0].ToString().Trim());
                ROL    = foundRows[0][1].ToString().Trim();
                INFO = ID.ToString() + "-" + ROL.Substring(0, 3);

            }
           
          
        
        }
    }
   public class TurismoUtils
    {

       bo dlog = new bo();

        public void UpdateComboProvincia(int Provincia, ComboBox cbProvincia)
        {
            string query;

            if (Provincia == 0)
                query = "SELECT PROVINCIAID ID, NOMBRE DETALLE FROM PROVINCIA";
            else
                query = "SELECT PROVINCIAID ID, NOMBRE DETALLE FROM PROVINCIA WHERE PROVINCIAID=" + Provincia.ToString();

            cbProvincia.DataSource = null;
            cbProvincia.Items.Clear();
            cbProvincia.DataSource = dlog.BO_EjecutoDataTable(query);
            cbProvincia.DisplayMember = "DETALLE";
            cbProvincia.ValueMember = "ID";
            cbProvincia.SelectedItem = 1;

        }

        public void UpdateComboLocalidad(int Provincia, ComboBox cbLocalidad)
        {
            if (cbLocalidad.DataSource == null)
            {
                string query = "SELECT LOCALIDADID ID, TRIM ('' From DESCRIPCION) DETALLE FROM LOCALIDAD WHERE PROVINCIAID=" + Provincia.ToString()  + " ORDER BY DESCRIPCION";


                cbLocalidad.DataSource = null;
                cbLocalidad.Items.Clear();

                cbLocalidad.DisplayMember = "DETALLE";
                cbLocalidad.ValueMember   = "ID";

                cbLocalidad.DataSource = dlog.BO_EjecutoDataTable(query);
                cbLocalidad.SelectedItem = 1;
            }

        }


        public void UpdateComboTabla(string Tabla, ComboBox cbCombo)
        {
            string query = "SELECT ID, NOMBRE DETALLE FROM " + Tabla + " WHERE coalesce(F_BAJA,'1') = '1'";

            
            
           


            cbCombo.DataSource = null;
            cbCombo.Items.Clear();
            cbCombo.DataSource = dlog.BO_EjecutoDataTable(query);
            cbCombo.DisplayMember = "DETALLE";
            cbCombo.ValueMember = "ID";
            cbCombo.SelectedItem = 1;

        }

        public void UpdateComboHotelPropio(ComboBox cbCombo)
        {
            string query = "SELECT ID, NOMBRE DETALLE FROM HOTEL WHERE coalesce(F_BAJA,'1') = '1' AND PROPIO=1";






            cbCombo.DataSource = null;
            cbCombo.Items.Clear();
            cbCombo.DataSource = dlog.BO_EjecutoDataTable(query);
            cbCombo.DisplayMember = "DETALLE";
            cbCombo.ValueMember = "ID";
            cbCombo.SelectedItem = 1;

        }


        public void UpdateComboHabitacionTipo(ComboBox cbCombo)
        {
            string query = "SELECT ID, TIPO DETALLE FROM HOTEL_HABITACION_TIPO";






            cbCombo.DataSource = null;
            cbCombo.Items.Clear();
            cbCombo.DataSource = dlog.BO_EjecutoDataTable(query);
            cbCombo.DisplayMember = "DETALLE";
            cbCombo.ValueMember = "ID";
            cbCombo.SelectedItem = 1;

        }


        public int PLazasInicialesTipoHabitacion(int ID)

        {


            string QUERY = "Select CAMAS from HOTEL_HABITACION_TIPO  WHERE ID= "+  ID.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return Int32.Parse(foundRows[0][0].ToString().Trim());
            }
            else
                return 0;
        
        }



        public int CamasDisponiblesHotel(int Hotel)


        {
            string QUERY = "Select SUM(plazas) from HOTEL_HABITACION   WHERE HOTEL_ID= " + Hotel.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return Int32.Parse(foundRows[0][0].ToString().Trim());
            }
            else
                return 0;
        
        }




        public void ComboMoneda(ComboBox combo)

        {
            List<SOCIOS.admDeportes.ItemCombo> lista = new List<SOCIOS.admDeportes.ItemCombo>();

            lista.Add(new SOCIOS.admDeportes.ItemCombo(1, "PESOS"));
            lista.Add(new SOCIOS.admDeportes.ItemCombo(2, "DOLARES"));
      
            combo.Items.Clear();
            combo.DisplayMember = "Texto";
            combo.ValueMember = "ID";
            combo.DataSource = lista;
            combo.SelectedItem = 1;
        

        }



        public void ComboOperador(ComboBox combo,bool Pasaje)
        {
            string query = "SELECT ID, RAZON_SOCIAL FROM PROVEEDORES ";
            
            if (Pasaje)
              query = query + " WHERE TIPO='67'";
            else
                query = query + " WHERE TIPO='66' or TIPO='67'";

            combo.DataSource = null;
            combo.Items.Clear();
            combo.DataSource = dlog.BO_EjecutoDataTable(query);
            combo.DisplayMember = "RAZON_SOCIAL";
            combo.ValueMember = "ID";

            combo.SelectedItem = 1;

        }

        public void ComboSalida(ComboBox combo)
        {
            string query = "SELECT ID ,( NOMBRE || '- ' ||  extract(day from  FECHA)  || '/' || extract(month from Fecha) || '/' ||  extract(year from Fecha)    ) as NOMBRE   FROM TURISMO_SALIDA where  (U_BAJA is null)  order by NOMBRE,FECHA ";


            combo.DataSource = null;
            combo.Items.Clear();
            combo.DataSource = dlog.BO_EjecutoDataTable(query);
            combo.DisplayMember = "NOMBRE";
            combo.ValueMember = "ID";
            combo.SelectedItem = 1;

        }



        public void comboEmpresa(ComboBox cbEmpresa,int tipo)
        {
            string Query = "SELECT ID,NOMBRE FROM TURISMO_OPERADOR WHERE TIPO= " + tipo.ToString();


            cbEmpresa.DataSource = null;
            cbEmpresa.Items.Clear();
            cbEmpresa.DataSource = dlog.BO_EjecutoDataTable(Query);
            cbEmpresa.DisplayMember = "NOMBRE";
            cbEmpresa.ValueMember = "ID";
            cbEmpresa.SelectedItem = 1;

        }

        public int GetMaxID(string NRO_SOCIO,string TIPO)
        {
            string QUERY = "SELECT coalesce (MAX(ID),0) FROM Bono_Turismo WHERE NRO_SOCIO_TITULAR= " + NRO_SOCIO +  " AND TIPO ='" + TIPO + "'";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return Int32.Parse(foundRows[0][0].ToString().Trim());
            }
            else
                return 0;


        }

        public int GetMax_ID_ROL(string ROL,int CODINT)
        {
            string QUERY = "SELECT coalesce (MAX(ID_ROL),0) FROM Bono_Turismo WHERE ROL='" + ROL + "' and CODINT=" + CODINT.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return Int32.Parse(foundRows[0][0].ToString().Trim()) ;
            }
            else
                return 0;


        }


       

        public bool HotelPropio(int ID)
        {
            string QUERY = "SELECT * FROM HOTEL WHERE PROPIO=1 AND ID= " + ID.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return true;
            }
            else
                return false;

        }

        public int Camas_Habitacion(int ID)
        {
            string QUERY = "SELECT CAMAS FROM hotel_habitacion_tipo WHERE   ID= " + ID.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return Int32.Parse(foundRows[0][0].ToString().Trim());
            }
            else
                return 0;

        }



        public bool HotelSocial(int ID)
        {
            string QUERY = "SELECT * FROM HOTEL WHERE Social=1 AND ID= " + ID.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return true;
            }
            else
                return false;

        }

        public decimal Hotel_Late_Chk(int ID)
        {
            string QUERY = "SELECT  COALESCE(Late_chk,0) FROM HOTEL WHERE ID= " + ID.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return Decimal.Parse(foundRows[0][0].ToString());
            }
            else
                return 0;

        }


        public int getCSPFA_Proveedor()

        {
            string QUERY = "select ID from proveedores  where razon_social='CSPFA'";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return Int32.Parse(foundRows[0][0].ToString().Trim());
            }
            else
                return 0;
        
        }

        public void GrabarPagos(int idBono,List<bono.PagoBono> PagosBono,DateTime Fecha,int CodInt,bono.CabeceraTitular CAB,decimal Saldo,int TipoPago,int SUBCODIGO)
        {

            
            //VER QUE PASA ACA CON EL WORKBENCH
             dlog.PlanCuenta_Insert(Int32.Parse(CAB.NroSocioTitular), Int32.Parse(CAB.NroDepTitular), Saldo, Saldo, idBono, TipoPago);

             maxid m = new maxid();

             int Plan = Int32.Parse(m.m("ID", "PLAN_CUENTA").ToString());
          

            foreach (bono.PagoBono p in PagosBono)
            {
                dlog.InsertPagoBono(idBono, p.TIPO, p.MONTO, p.CUOTA, p.POC, Fecha, CodInt, 0, p.FECHA_DTO, VGlobales.vp_username, System.DateTime.Now.ToString(), CAB.NroBeneficioTitular, VGlobales.vp_role, Int32.Parse(CAB.NroSocioTitular), Int32.Parse(CAB.NroDepTitular), 0, Int32.Parse(CAB.NroSocioTitular), Int32.Parse(CAB.NroDepTitular), Plan,SUBCODIGO);

            }


        }
   
      //  public void GrabarPersonas(int idBono,int nroSocioTitular, List<bono.DatoSocio> Datos)
        public void GrabarPersonas(int idBono, int nroSocioTitular, List<GridPersona> Datos,string Rol)
        {

            foreach (GridPersona dato in Datos)

            {
                dlog.Bono_Persona_Ins(idBono, nroSocioTitular, dato.NroSocio,dato.NroDep,dato.Barra, dato.Nombre, dato.Apellido, dato.Nacimiento, dato.Edad, dato.Telefono, dato.Mail,dato.Dni,Rol);
            
            
            }
        
        
        }

        public void GrabarPasajes(int idBono,List<bono.Pasaje> Pasajes)
        {
            foreach (bono.Pasaje paj in Pasajes)
            {
                dlog.Bono_Pasaje_Ins(idBono, paj.Cantidad, paj.NroBoleto,DateTime.Parse( paj.FechaSalida), paj.Origen, paj.Destino, paj.Monto, paj.Monto);

            
            }
        
        }
        public Turismo.Salida GetSalida(int ID)
        {
            if (ID == 0)
                return null;
            Turismo.Salida salida = new Salida();
            string Query = @"SELECT   TS.ID,TS.NOMBRE,TS.FECHA,TS.AGOTADO,TS.PROV_DESDE,TS.PROV_HASTA,TS.OPERADOR,TS.LOC_DESDE,
                             TS.LOC_HASTA,TS.SOCIO,TS.INVITADO,TS.INTERCIRCULO,TS.ESTADIA,TS.REGIMEN,TS.TRASLADO,TS.TIPO,
                             TS.HOTEL,TS.HOTEL_NOMBRE,TS.DESTACADO,TS.MONEDA,TS.U_BAJA,TS.F_BAJA,TS.OBSERVACIONES,PD.NOMBRE,
                             PH.NOMBRE,LD.DESCRIPCION,LH.DESCRIPCION,P.RAZON_SOCIAL,TR.NOMBRE,TT.NOMBRE,TTP.NOMBRE,TS.DIARIA,TS.MENOR,TS.COCHE_CAMA
                             FROM  TURISMO_SALIDA TS ,
                             PROVINCIA PD,
                             PROVINCIA PH, 
                             LOCALIDAD LD,
                             LOCALIDAD LH,
                             PROVEEDORES P,
                             TURISMO_REGIMEN TR,
                             TURISMO_TIPO TTP,
                             TURISMO_TRASLADO TT
                               WHERE TS.PROV_DESDE = PD.PROVINCIAID
                                    AND TS.PROV_HASTA = PH.PROVINCIAID 
                                    AND TS.LOC_DESDE = LD.LOCALIDADID 
                                    AND TS.LOC_HASTA=LH.LOCALIDADID 
                                    AND   TS.OPERADOR = P.ID          
                                    AND TS.REGIMEN = TR.ID AND TS.TRASLADO = TT.ID 
                                    AND TS.TIPO = TTP.ID AND TS.ID =   " + ID.ToString();

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(Query).Select();

            if (foundRows.Length > 0)
            {
                salida.ID = Int32.Parse(foundRows[0][0].ToString());
                salida.Nombre = foundRows[0][1].ToString();
                salida.Fecha =  DateTime.Parse(foundRows[0][2].ToString());
                salida.Agotado = Int32.Parse(foundRows[0][3].ToString());
                salida.Prov_Desde =Int32.Parse( foundRows[0][4].ToString());
                salida.Prov_Hasta =Int32.Parse( foundRows[0][5].ToString());
                salida.Operador = Int32.Parse(foundRows[0][6].ToString());
                salida.Loc_Desde =Int32.Parse(foundRows[0][7].ToString());
                salida.Loc_Hasta =Int32.Parse( foundRows[0][8].ToString());
                salida.Socio = decimal.Round( decimal.Parse(foundRows[0][9].ToString()));
                salida.Invitado =decimal.Round(decimal.Parse( foundRows[0][10].ToString()));
                salida.InterCirculo = decimal.Parse(foundRows[0][11].ToString());
                salida.Estadia = foundRows[0][12].ToString();
                salida.Regimen = Int32.Parse(foundRows[0][13].ToString());
                salida.Traslado =  Int32.Parse(foundRows[0][14].ToString());
                salida.Tipo =      Int32.Parse(foundRows[0][15].ToString());
                salida.Hotel =     Int32.Parse( foundRows[0][16].ToString());
                salida.Hotel_Nombre = foundRows[0][17].ToString();
                salida.Destacado = Int32.Parse(foundRows[0][18].ToString());
                salida.Moneda = foundRows[0][19].ToString();
                salida.Observaciones = foundRows[0][22].ToString();
                salida.Prov_Desde_Nombre = foundRows[0][23].ToString();
                salida.Prov_Hasta_Nombre =foundRows[0][24].ToString();
                salida.Loc_Desde_Nombre   = foundRows[0][25].ToString();
                salida.Loc_Hasta_Nombre   = foundRows[0][26].ToString();
                salida.Operador_Nombre    = foundRows[0][27].ToString();
                salida.Regimen_Nombre     = foundRows[0][28].ToString();
                salida.Traslado_Nombre    = foundRows[0][29].ToString();
                salida.Tipo_Nombre        = foundRows[0][30].ToString();
                salida.Diaria             = Int32.Parse( foundRows[0][31].ToString());
                salida.Menor =  Decimal.Round( Decimal.Parse(foundRows[0][32].ToString()) ,2);
                if (foundRows[0][33].ToString().Length > 0)
                    salida.Coche_Cama = Decimal.Round(decimal.Parse(foundRows[0][33].ToString()), 2);
                else
                    salida.Coche_Cama = 0;

            }

            
            return salida;
         

        }

        public string FormaPagoBono(int ID)
        {
            string QUERY = "SELECT PAGO FROM Bono_turismo WHERE ID=" + ID.ToString();
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                return foundRows[0][0].ToString();
            }
            else
                return "";


        }

        public DataTable DatosPersonas(string ID)
        {

            string connectionString;
            DataTable dt1 = new DataTable("RESULTADOS");
            string Query = @" select Nombre,Apellido,'ARG' Nacionalidad, 'Dni' TipoDni, Dni from bono_Personas
            where  ROL ='TURISMO' and BONO=" + ID;
            DataSet ds1 = new DataSet();

            Datos_ini ini3 = new Datos_ini();

            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini3.Servidor; //cs.Port = int.Parse(ini3.Puerto);
                cs.Database = ini3.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    FbTransaction transaction = connection.BeginTransaction();



                    dt1.Columns.Add("Nombre", typeof(string));
                    dt1.Columns.Add("Apellido", typeof(string));
                    dt1.Columns.Add("Nacionalidad", typeof(string));
                    dt1.Columns.Add("TipoDni", typeof(string));
                    dt1.Columns.Add("Dni", typeof(string));


                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(Query, connection, transaction);

                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("Nombre")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Apellido")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Nacionalidad")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TipoDni")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("Dni")).Trim());


                    }

                    reader3.Close();



                    transaction.Commit();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return dt1;


        }

        public void checkDestinosRepetidos( int pLocalidadOrigen, int pLocalidadDestino )

        { 
            if ( pLocalidadDestino==pLocalidadOrigen)
                throw new Exception("NO SE PUEDE EFECTUAR LA OPERACION CON EL MISMO ORIGEN Y DESTINO");
        
        }

        public void Tipos_Habitacion(ComboBox cbHabitacion)
        {
            string query;

            query = "select ID, TIPO from hotel_habitacion_Tipo where tipo not  like'%PERSON%'";

            cbHabitacion.DataSource = null;
            cbHabitacion.Items.Clear();
            cbHabitacion.DataSource = dlog.BO_EjecutoDataTable(query);
            cbHabitacion.DisplayMember = "TIPO";
            cbHabitacion.ValueMember = "ID";
            cbHabitacion.SelectedItem = 1;

        }

        

    }
}
