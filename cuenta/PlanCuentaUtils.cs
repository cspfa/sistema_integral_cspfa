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
        public string Bono               { get; set; }
      
        public string Fecha              { get; set; }
        public string Tipo               { get; set; }
        public string NombreCompleto     { get; set; }
        public string Inicial            { get; set; }
        public string Saldo              { get; set; }
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
        public int      ID          { get; set; }
        public string   Detalle     { get; set; }
        public decimal  Monto       { get; set; }
        public int      RECIBO      { get; set; }
        public string   FechaPago   { get; set; }
        public string   Nro_Soc     { get; set; }
        public string   Nro_Dep     { get; set; }
        public string   Rol         { get; set; }
        public int      Plan        { get; set; }
    }


    public class PlanCuentaUtils
    {
        bo dlog = new bo();
        public List<PLanDeCuenta> GetCuentas(int Modo)
        {
            string query;
            
            //Modo 1 , Turismo Modo 2 , Odonto
            query = "select distinct P.ID  ID ,B.ID BONO , P.F_ALTA FECHA,PBT.DES TIPO,B.NRO_SOCIO_TITULAR SOCIO, B.NRO_SOCIO NRO_SOCIO , B.NRO_DEP NRO_DEP , trim(B.APELLIDO) || ','|| B.NOMBRE NOMBRE_COMPLETO,P.SALDO_INICIAL INICIAL, P.SALDO,B.PAGO OBS, P.ROL ROL, B.DNI DNI ,B.NOMBRE NOMBRE,B.APELLIDO APELLIDO, B.BARRA BARRA, B.NRO_SOCIO_TITULAR NRO_SOCIO_TIT , B.NRO_DEP_TITULAR NRO_DEP_TIT " +
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
                    pc.Plan = reader3.GetString(reader3.GetOrdinal("ID")).Trim();
                    pc.Bono = reader3.GetString(reader3.GetOrdinal("BONO")).Trim();
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
            string query = " select ID,Cuota,Monto,Nro_Recibo Recibo, F_Pago FechaPago,Nro_Soc,Nro_Dep,Rol   from pagos_Bono where PLan_Cuenta=" +PLan.ToString() ;


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
                    pc.Nro_Soc = reader3.GetString(reader3.GetOrdinal("NRO_SOC")).Trim();
                    pc.Nro_Dep = reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim();
                    string recibo = reader3.GetString(reader3.GetOrdinal("RECIBO")).Trim();
                    if (recibo.Length >0)
                        pc.RECIBO =  Int32.Parse(recibo);
                    pc.FechaPago = reader3.GetString(reader3.GetOrdinal("FECHAPAGO")).Trim();
                    pc.Rol       = reader3.GetString(reader3.GetOrdinal("ROL")).Trim();
                    Cuotas.Add(pc);


                }




            }

            return Cuotas;
        
        
        
        
        
        }

        public CuotaPlan getCuota(int Cuota)
        {
            string query = " select ID,Cuota,Monto,Nro_Recibo Recibo, F_Pago FechaPago,Nro_Soc,Nro_Dep,Rol,PLan_Cuenta Plan   from pagos_Bono where ID=" + Cuota.ToString();


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
                    pc.Nro_Soc = reader3.GetString(reader3.GetOrdinal("NRO_SOC")).Trim();
                    pc.Nro_Dep = reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim();
                    string recibo = reader3.GetString(reader3.GetOrdinal("RECIBO")).Trim();
                    if (recibo.Length > 0)
                        pc.RECIBO = Int32.Parse(recibo);
                    pc.FechaPago = reader3.GetString(reader3.GetOrdinal("FECHAPAGO")).Trim();
                    pc.Rol = reader3.GetString(reader3.GetOrdinal("ROL")).Trim();
                    pc.Plan  =Int32.Parse( reader3.GetString(reader3.GetOrdinal("PLAN")).Trim());
               
                   


                }




            }

            return pc;





        }

        public void MarcarPaga(int IdCuota, int Recibo,DateTime fechaPago)

        {

               CuotaPlan pc = new CuotaPlan();
             pc = this.getCuota(IdCuota);
            dlog.Pagar_Cuota(pc.Plan, Recibo, fechaPago);
          
            dlog.PlanCuenta_Update(pc.Plan, pc.Monto);

        
        }

    }
}
