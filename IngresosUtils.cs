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
using System.Data.SqlClient;
using SOCIOS.bono;


namespace SOCIOS
{

    public enum PagoIngresoEnum
    {
        DESTINO_ODONTO            = 110,
        PROF_ODONTO               = 27,
        
        
        DESTINO_PAGO_CUOTA_ODONTO = 342,
        PROF_PAGO_CUOTA_ODONTO    = 337,

        DESTINO_PAGO_CUOTA_TURISMO = 341,
        PROF_PAGO_CUOTA_TURISMO    = 338,

        DESTINO_PASAJE             = 210,
        PROF_PASAJE                = 96,

        DESTINO_SALIDA             = 209,
        PROF_SALIDA                = 97,

        DESTINO_HOTEL              = 340,
        PROF_HOTEL                 = 336,
        


     
    
    }

    public class IngresoBono
    {
        public int ID { get; set; }
        public int NRO_SOCIO { get; set; }
        public int NRO_DEP { get; set; }
        public string TIPO { get; set; }
        public int DESTINO { get; set; }
        public int PROF { get; set; }
        bo_Bonos  dlog = new bo_Bonos();


        CabeceraTitular DatosSocio = new CabeceraTitular();
        public IngresoBono(int ID, string ROL, bool Pago, decimal Monto,int pNro_Socio,int pNro_Dep,int pBarra,int pNRo_SocioADH, int pNro_DepADH,string Dni,string Nombre,string Apellido,int Destino,int Prof,string Titulo,int BONO)
        {
            //Defino si es un pago, uno de turismo u odontologico
            DESTINO = Destino;
            
            if (Pago)
            {
                this.Init_PagoCuota(ID);

            }
            else if (ROL.Contains("MEDICOS"))
            {
                this.Init_BonoOdontologico(BONO,Destino,Prof);
            }
            else if (ROL.Contains("TURISMO"))
            {
                this.Init_Turismo(BONO);

            }
            //Obtengo Datos del Titular
           if (pNro_Socio ==0)
              DatosSocio = new SOCIOS.bono.handlerDatosSocios(NRO_SOCIO.ToString(), NRO_DEP.ToString()).CAB;
           else
               DatosSocio = new SOCIOS.bono.handlerDatosSocios(pNro_Socio.ToString(), pNro_Dep.ToString()).CAB;
            //Grabo Ingreso
             dlog.Inserto_Ingreso(Apellido,Nombre,"Tit", VGlobales.vp_role, Titulo, DESTINO.ToString(),pNro_Socio.ToString(),pNro_Dep.ToString(), pNRo_SocioADH.ToString(), pNro_DepADH.ToString(), pBarra.ToString(),Int32.Parse (Dni), "0", PROF.ToString(),"", VGlobales.vp_username, 1, Monto, ID);
        }



        private void Init_BonoOdontologico(int pID,int Destino, int Profesional)
        {
            string QUERY = "select ID,NRO_SOCIO_TITULAR NRO_SOCIO, NRO_DEP  from  BONO_ODONTOLOGICO WHERE   ID= " + pID.ToString();
            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();



            if (foundRows.Length > 0)
            {
                ID = Int32.Parse(foundRows[0][0].ToString());
                NRO_SOCIO = Int32.Parse(foundRows[0][1].ToString());
                NRO_DEP = Int32.Parse(foundRows[0][2].ToString());
                TIPO = "ODONTOLOGICO";

                DESTINO = Destino;
                PROF = Profesional; 


            }



        }

        private void Init_PagoCuota(int Cuota)
        {
            string QUERY = "select BONO, NRO_SOCIO_TITULAR, NRO_DEP,ROL  from  PAGOS_BONO WHERE   ID= " + Cuota.ToString();
            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


            if (foundRows.Length > 0)
            {
                ID = Int32.Parse(foundRows[0][0].ToString());
                NRO_SOCIO = Int32.Parse(foundRows[0][1].ToString());
                NRO_DEP = Int32.Parse(foundRows[0][2].ToString());
                string ROL = foundRows[0][3].ToString();

                TIPO = " PAGO CUOTA";

                if (ROL.Contains("MEDICOS"))
                {
                    DESTINO = (int)SOCIOS.PagoIngresoEnum.DESTINO_PAGO_CUOTA_ODONTO;
                    PROF = (int)SOCIOS.PagoIngresoEnum.PROF_PAGO_CUOTA_ODONTO;
                }
                else
                {
                    DESTINO = (int)SOCIOS.PagoIngresoEnum.DESTINO_PAGO_CUOTA_TURISMO;
                    PROF = (int)SOCIOS.PagoIngresoEnum.PROF_PAGO_CUOTA_TURISMO;

                }

            }



        }


        private void Init_Turismo(int pID)
        {
            string QUERY = "select ID,NRO_SOCIO_TITULAR NRO_SOCIO, NRO_DEP,TIPO  from  BONO_TURISMO  WHERE  ID= " + pID.ToString();
            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();


            if (foundRows.Length > 0)
            {
                ID = Int32.Parse(foundRows[0][0].ToString());
                NRO_SOCIO = Int32.Parse(foundRows[0][1].ToString());
                NRO_DEP = Int32.Parse(foundRows[0][2].ToString());
                string Tipo_Bono = foundRows[0][3].ToString();
                if (Tipo_Bono.Contains("PAS"))
                {
                    TIPO = "PASAJE";
                    DESTINO = (int)SOCIOS.PagoIngresoEnum.DESTINO_PASAJE;
                    PROF = (int)SOCIOS.PagoIngresoEnum.PROF_PASAJE;


                } if (Tipo_Bono.Contains("PAQ"))
                {
                    TIPO = "PAQUETE";
                    DESTINO = (int)SOCIOS.PagoIngresoEnum.DESTINO_SALIDA;
                    PROF = (int)SOCIOS.PagoIngresoEnum.PROF_SALIDA;

                }
                else
                {
                    TIPO = "HOTEL";
                    DESTINO = (int)SOCIOS.PagoIngresoEnum.DESTINO_HOTEL;
                    PROF = (int)SOCIOS.PagoIngresoEnum.PROF_HOTEL;


                }


            }



        }
    }
}
