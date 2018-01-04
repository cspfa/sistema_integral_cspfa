using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace SOCIOS.CuentaSocio
{
    public class PLanDeCuenta
    {

        public string Plan               { get; set; }
        public string Fecha              { get; set; }
        public string Tipo               { get; set; }
        public string NombreCompleto     { get; set; }
        public string Inicial            { get; set; }
        public string Saldo              { get; set; }

     
        public string Bono               { get; set; }
        public int CODINT                { get; set; }
      
 
        public string Obs                { get; set; }
        public string Socio              { get; set; }
        public string Nro_Socio          { get; set; }
        public string Nro_Dep            { get; set; }
        public string Rol                { get; set; }
        
        public string Nombre             { get; set; }
        public string Apellido           { get; set; }
        public string Dni                { get; set; }
        public string Barra              { get; set; }
        public string Nro_Socio_Tit      { get; set; }
        public string Nro_Dep_Tit        { get; set; }
      
      

    }

    public class CuotaPlan
    {
        public int      ID               { get; set; }
        public string   Detalle          { get; set; }
        public decimal  Monto            { get; set; }
        public int      RECIBO_CAJA      { get; set; }
        public string   FechaPago        { get; set; }
        public string   FechaDTO         { get; set; }
        public string   FormaPago        { get; set; }
        public string Rol                { get; set; }
        public int    Nro_Soc          { get; set; }
        public int   Nro_Dep          { get; set; }
        public int  Barra              { get; set; }
        public int      Plan             { get; set; }
        public int      Bono_CAJA        { get; set; }
        public string  FormaDescuento    { get; set; }
        public decimal SaldoPlan         { get; set; }

        public int Bono                  { get; set; }
        public int TipoPago              { get; set; }
        public string Cuota              { get; set; }

        public    string POC            { get; set; }
        public int COD_INT              { get; set; }
        public int COD_CP               { get; set; }
        public string NRO_BENEFICIO     { get; set; }
        public int NRO_SOC_TITULAR      { get; set; }
        public int NRO_DEP_TITULAR      { get; set; }
          
    }

    public class Montos_PLan

    {
        public decimal Inicial { get; set; }
        public decimal Saldo   { get; set; }
        
    }
    public class PlanCuentaUtils
    {
        bo_Bonos dlog = new bo_Bonos();
        BO.bo_Plan_Cuenta BO_PLANCUENTA = new BO.bo_Plan_Cuenta();
       
        SOCIOS.descuentos.DescuentoUtils du = new descuentos.DescuentoUtils();

        public List<PLanDeCuenta> GetCuentas(int Modo)
        {
            string query;
            
            //Modo 1 , Turismo Modo 2 , Odonto
            query = "select distinct  P.F_ALTA FECHA, trim(B.APELLIDO) || ','|| B.NOMBRE NOMBRE_COMPLETO,P.SALDO_INICIAL INICIAL, P.SALDO, B.CODINT CODINT,PBT.DES TIPO,P.ID  ID ,B.ID_ROL BONO ,B.NRO_SOCIO_TITULAR SOCIO, B.NRO_SOCIO NRO_SOCIO , B.NRO_DEP NRO_DEP ,B.PAGO OBS, P.ROL ROL, B.DNI DNI ,B.NOMBRE NOMBRE,B.APELLIDO APELLIDO, B.BARRA BARRA, B.NRO_SOCIO_TITULAR NRO_SOCIO_TIT , B.NRO_DEP_TITULAR NRO_DEP_TIT " +
                    "from plan_cuenta P," ;

            if (Modo == 2)
               query = query + "Bono_Turismo B ";
            else
                query = query + "Bono_Odontologico B ";
            
            
            query = query + " , Pagos_bono PB, PAGOS_BONO_TIPOS PBT  where P.BONO = B.ID    and PB.bono=B.ID and PBT.ID = P.TIPO ";


            if (Modo == 2)
                 query = query + " and P.ROL  = 'TURISMO' ";
       
            else
                query = query + " and  P.ROL ='SERVICIOS MEDICOS'";
            query = query + " order by P.Id descending ";
         

            List<PLanDeCuenta> Planes = new List<PLanDeCuenta>();
            string connectionString;
            DataSet ds1 = new DataSet();
            Datos_ini ini3 = new Datos_ini();

            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini3.Servidor;
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



                FbCommand cmd = new FbCommand(query, connection, transaction);

                FbDataReader reader3 = cmd.ExecuteReader();

                while (reader3.Read())
                {
                    PLanDeCuenta pc = new PLanDeCuenta();
                    pc.Plan   = reader3.GetString(reader3.GetOrdinal("ID")).Trim();
                   if (reader3.GetString(reader3.GetOrdinal("BONO")).Trim().Length >0)
                       pc.Bono   = reader3.GetString(reader3.GetOrdinal("BONO")).Trim();
                    else
                       pc.Bono ="0";
                   if (reader3.GetString(reader3.GetOrdinal("CODINT")).Trim().Length > 1)
                       pc.CODINT = Int32.Parse(reader3.GetString(reader3.GetOrdinal("CODINT")).Trim());
                   else
                       pc.CODINT = 0;

                    pc.Fecha =DateTime.Parse( reader3.GetString(reader3.GetOrdinal("FECHA")).Trim()).ToShortDateString();
                    pc.Socio  = reader3.GetString(reader3.GetOrdinal("SOCIO")).Trim();
                    pc.Nro_Socio = reader3.GetString(reader3.GetOrdinal("NRO_SOCIO")).Trim();
                    pc.Nro_Dep = reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim();
                    pc.NombreCompleto = reader3.GetString(reader3.GetOrdinal("NOMBRE_COMPLETO")).TrimEnd();
                    pc.Inicial = reader3.GetString(reader3.GetOrdinal("INICIAL")).Trim();
                    pc.Saldo = reader3.GetString(reader3.GetOrdinal("SALDO")).Trim();
                    pc.Tipo = reader3.GetString(reader3.GetOrdinal("TIPO")).Trim();
                    pc.Obs = reader3.GetString(reader3.GetOrdinal("OBS")).Trim();
                    pc.Rol = reader3.GetString(reader3.GetOrdinal("ROL")).Trim();
                    pc.Nombre = reader3.GetString(reader3.GetOrdinal("NOMBRE")).TrimEnd();
                    pc.Apellido = reader3.GetString(reader3.GetOrdinal("APELLIDO")).TrimEnd();
                    pc.Dni = reader3.GetString(reader3.GetOrdinal("DNI")).TrimEnd();
                    pc.Nro_Dep_Tit =reader3.GetString(reader3.GetOrdinal("NRO_DEP_TIT")).TrimEnd();
                    pc.Nro_Socio_Tit = reader3.GetString(reader3.GetOrdinal("NRO_SOCIO_TIT")).TrimEnd();
                    pc.Barra          =reader3.GetString(reader3.GetOrdinal("BARRA")).TrimEnd();
                    Planes.Add(pc);

                }




            }

            return Planes;



        }

        public List<CuotaPlan> Cuotas(int PLan)

        {
            string query = " select P.ID,P.Cuota,P.Monto,P.Nro_Recibo_Caja, P.F_Pago FechaPago,P.Nro_Soc,P.Nro_Dep,P.Rol,P.nro_bono_Caja,tipopago,forma_dto DTO, fecha_dto DTO_FECHA     from pagos_Bono P WHERE  P.PLan_Cuenta=" + PLan.ToString();


            List<CuotaPlan> Cuotas = new List<CuotaPlan>();
            string connectionString;
            DataSet ds1 = new DataSet();
            Datos_ini ini3 = new Datos_ini();

            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini3.Servidor;
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



                FbCommand cmd = new FbCommand(query, connection, transaction);

                FbDataReader reader3 = cmd.ExecuteReader();

                while (reader3.Read())
                {
                    CuotaPlan pc = new CuotaPlan();
                    pc.ID    = Int32.Parse(reader3.GetString(reader3.GetOrdinal("ID")).Trim());
                    pc.Monto   = Decimal.Round( Decimal.Parse(reader3.GetString(reader3.GetOrdinal("MONTO")).Trim()),2);
                    pc.Detalle = reader3.GetString(reader3.GetOrdinal("CUOTA")).Trim();
                    pc.Nro_Soc = Int32.Parse(reader3.GetString(reader3.GetOrdinal("NRO_SOC")).Trim());
                    pc.Nro_Dep = Int32.Parse( reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim());
                    pc.FechaDTO = reader3.GetString(reader3.GetOrdinal("DTO_FECHA")).Trim();
                    string recibo = reader3.GetString(reader3.GetOrdinal("NRO_RECIBO_CAJA")).Trim();
                    if (recibo.Length >0)
                        pc.RECIBO_CAJA =  Int32.Parse(recibo);

                    pc.FechaPago = reader3.GetString(reader3.GetOrdinal("FECHAPAGO")).Trim();
                    
                    pc.Rol       = reader3.GetString(reader3.GetOrdinal("ROL")).Trim();
                    string bono_caja = reader3.GetString(reader3.GetOrdinal("NRO_BONO_CAJA")).Trim();
                    if (bono_caja.Length > 0)
                        pc.Bono_CAJA = Int32.Parse(bono_caja);
                    
                   // if (reader3.GetString(reader3.GetOrdinal("TIPOPAGO")).Trim().Length > 1)
                     //   pc.FormaPago = SOCIOS.formasPago.DETALLE_FORMA_PAGO(Int32.Parse(reader3.GetString(reader3.GetOrdinal("TIPOPAGO")).Trim()));
                    if (reader3.GetString(reader3.GetOrdinal("DTO")).Trim().Length > 1)
                    {
                        int dto = Int32.Parse(reader3.GetString(reader3.GetOrdinal("DTO")).Trim());
                        pc.FormaDescuento = du.Observaciones(dto).First().OBS;
                    }
                    Cuotas.Add(pc);


                }




            }

            return Cuotas;
        
        
        
        
        
        }

        public CuotaPlan getCuota(int Cuota)
        {
            string query = @" select P.ID,P.Cuota,P.Monto,P.Nro_Recibo_caja Recibo,P.Nro_Bono_Caja Bono, P.F_Pago FechaPago,P.Nro_Soc NRO_SOCIO ,P.Nro_Dep NRO_DEP, P.BARRA BARRA, P.Rol, P.Plan_Cuenta Plan_Cuenta ,
                                    P.FORMA_PAGO_CAJA FP ,PL.SALDO SALDO_PC, P.CODINT CODINT, P.CODCP CODCP, P.NRO_SOCIO_TITULAR NRO_SOCIO_TITULAR, P.NRO_DEP_TITULAR NRO_DEP_TITULAR   from pagos_Bono P ,PLan_Cuenta PL  WHERE P.PLAN_CUENTA=PL.ID and
                                    P.ID=" + Cuota.ToString();


            List<CuotaPlan> Cuotas = new List<CuotaPlan>();
            string connectionString;
            DataSet ds1 = new DataSet();
            Datos_ini ini3 = new Datos_ini();

            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini3.Servidor;
            cs.Database = ini3.Ubicacion;
            cs.UserID = VGlobales.vp_username;
            cs.Password = VGlobales.vp_password;
            cs.Role = VGlobales.vp_role;
            cs.Dialect = 3;
            connectionString = cs.ToString();
            CuotaPlan pc = new CuotaPlan();
            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();

                FbTransaction transaction = connection.BeginTransaction();



                FbCommand cmd = new FbCommand(query, connection, transaction);

                FbDataReader reader3 = cmd.ExecuteReader();

                while (reader3.Read())
                {
                 
                    pc.ID = Int32.Parse(reader3.GetString(reader3.GetOrdinal("ID")).Trim());
                    pc.Monto = Decimal.Round(Decimal.Parse(reader3.GetString(reader3.GetOrdinal("MONTO")).Trim()), 2);
                    pc.Detalle = reader3.GetString(reader3.GetOrdinal("CUOTA")).Trim();
                    pc.Nro_Soc = Int32.Parse(reader3.GetString(reader3.GetOrdinal("NRO_SOCIO")).Trim());
                    pc.Nro_Dep = Int32.Parse( reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim());
                    pc.Barra = Int32.Parse(reader3.GetString(reader3.GetOrdinal("BARRA")).Trim());
                    string recibo = reader3.GetString(reader3.GetOrdinal("RECIBO")).Trim();
                    if (recibo.Length > 0)
                        pc.RECIBO_CAJA = Int32.Parse(recibo);

                    pc.FechaPago = reader3.GetString(reader3.GetOrdinal("FECHAPAGO")).Trim();
                    pc.Rol = reader3.GetString(reader3.GetOrdinal("ROL")).Trim();
                    pc.Plan  =Int32.Parse( reader3.GetString(reader3.GetOrdinal("PLAN_CUENTA")).Trim());
                    string bono_caja = reader3.GetString(reader3.GetOrdinal("BONO")).Trim();
                    if (bono_caja.Length > 0)
                        pc.Bono_CAJA = Int32.Parse(bono_caja);
                    //if (reader3.GetString(reader3.GetOrdinal("RECIBO")).Trim().Length > 1)
                       // pc.FormaPago = formasPago.DETALLE_FORMA_PAGO(Int32.Parse(reader3.GetString(reader3.GetOrdinal("RECIBO")).Trim()));

                    if (reader3.GetString(reader3.GetOrdinal("SALDO_PC")).Trim().Length > 0)
                        pc.SaldoPlan = Decimal.Parse(reader3.GetString(reader3.GetOrdinal("SALDO_PC")).Trim());

                    pc.COD_INT = Int32.Parse(reader3.GetString(reader3.GetOrdinal("CODINT")).Trim());
                    pc.COD_CP = Int32.Parse(reader3.GetString(reader3.GetOrdinal("CODCP")).Trim());
                    pc.NRO_SOC_TITULAR = Int32.Parse(reader3.GetString(reader3.GetOrdinal("NRO_SOCIO_TITULAR")).Trim());
                    pc.NRO_DEP_TITULAR = Int32.Parse(reader3.GetString(reader3.GetOrdinal("NRO_DEP_TITULAR")).Trim());

                }




            }

            return pc;





        }

        
        public void MarcarPagaCuota(int IdCuota, int NRO_COMPROBANTE,bool esRecibo,int TipoPago,DateTime fechaPago)

        {
            int recibo=0;
            int bono =0;
           
            if (esRecibo)
                 recibo = NRO_COMPROBANTE;
               
            else
                bono = NRO_COMPROBANTE;


               CuotaPlan pc = new CuotaPlan();
               pc = this.getCuota(IdCuota);
               
               BO_PLANCUENTA.Pagar_Cuota(IdCuota, recibo,TipoPago, bono, fechaPago);
               pc.SaldoPlan = decimal.Round( pc.SaldoPlan + (pc.Monto * (-1)),2);
            dlog.PlanCuenta_Update(pc.Plan, pc.SaldoPlan);

        
        }

        public void DesmarcarPagaCuota(int IdCuota,decimal Monto)
        {
        


            CuotaPlan pc = new CuotaPlan();
            pc = this.getCuota(IdCuota);

            //BO_PLANCUENTA.Anular_Cuota(IdCuota);
            dlog.InsertPagoBono(pc.Bono, pc.TipoPago, (-1) * Monto, pc.Cuota, pc.POC, System.DateTime.Now, pc.COD_INT, pc.COD_CP,DateTime.Parse(pc.FechaDTO), VGlobales.vp_username, System.DateTime.Now.ToString(), pc.NRO_BENEFICIO, pc.Rol, pc.Nro_Soc, pc.Nro_Dep, pc.Barra, pc.NRO_SOC_TITULAR, pc.NRO_DEP_TITULAR, pc.Plan);


            pc.SaldoPlan = decimal.Round(pc.SaldoPlan + (pc.Monto), 2);
            dlog.PlanCuenta_Update(pc.Plan, pc.SaldoPlan);


        }

        public Montos_PLan getMontos(int ID)

        {
            string query = @" select  SALDO_INICIAL INICIAL, SALDO SALDO from PLAN_CUENTA WHERE  ID =" + ID.ToString();


    
            string connectionString;
            DataSet ds1 = new DataSet();
            Datos_ini ini3 = new Datos_ini();

            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini3.Servidor;
            cs.Database = ini3.Ubicacion;
            cs.UserID = VGlobales.vp_username;
            cs.Password = VGlobales.vp_password;
            cs.Role = VGlobales.vp_role;
            cs.Dialect = 3;
            connectionString = cs.ToString();
            Montos_PLan plan = new Montos_PLan();
            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();

                FbTransaction transaction = connection.BeginTransaction();



                FbCommand cmd = new FbCommand(query, connection, transaction);

                FbDataReader reader3 = cmd.ExecuteReader();

                while (reader3.Read())
                {

                   plan.Inicial =  Decimal.Parse(reader3.GetString(reader3.GetOrdinal("INICIAL")).Trim());
                   plan.Saldo = Decimal.Parse(reader3.GetString(reader3.GetOrdinal("SALDO")).Trim());

                }




            }

            return plan;



        
        }



    }
}
