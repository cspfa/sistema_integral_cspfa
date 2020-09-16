using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace SOCIOS.Turismo
{
    public class Memoria
    {
        public int Nro_Solicitud  { get; set; }
        public string Fecha       { get; set; }
        public string Nombre_Apellido { get; set; }
        public string Destino     { get; set; }
        public string Pax         { get; set; }
        
        public string Contado     { get; set; }
        public string PLanilla    { get; set; }
        public string Cuotas      { get; set; }
        public string Valor_Cuota { get; set; }
        public string Total       { get; set; }
        public string Obs_Pago    { get; set; }
        public string Obs         { get; set; }
    }

    public class Memoria_Hotel:Memoria
    {
    
        public string Noches { get; set; }
        public string Plazas { get; set; }
        
    }



  
    public class TurismoStats
    {
        bo_Turismo dlog = new bo_Turismo();
        public List<Memoria> Stats_Memoria_Pasajes(DateTime pDesde, DateTime pHasta)
        {

            string Desde = this.fechaUSA(pDesde.AddDays(-1));
            string Hasta = this.fechaUSA(pHasta.AddDays(1));

         
                    return this.getPasajes(Desde, Hasta);
                
            
           
        
        }
        public List<Memoria_Hotel> Stats_Memoria_Hoteles(int Tipo, DateTime pDesde, DateTime pHasta)
        {

            string Desde = this.fechaUSA(pDesde.AddDays(-1));
            string Hasta = this.fechaUSA(pHasta.AddDays(1));

            switch (Tipo)
            {
               
                case 2:
                    return this.getHoteles(Desde, Hasta);
                    break;
                case 3:
                    return this.getSalidas(Desde, Hasta);
                    break;
                default:
                    return null;
            }
            return null;



        }



        public List<Memoria> getPasajes(string Desde, string Hasta)
        {
         

            List<Memoria> lista = new List<Memoria>();

            string QUERY = @"select  B.ID_ROL,
                                     B.FE_BONO,
                                     B.APELLIDO,
                                     B.NOMBRE ,
                                     L.DESCRIPCION,
                                     BTP.CANTIDAD,
(B.EFECTIVO + B.TARJETA_CREDITO + B.TARJETA_DEBITO +B.TRANSFER )CONTADO,
(B.PLANILLA )PLANILLA ,
 (B.PLANILLA_CUOTAS)CUOTAS,B.SALDO_INICIAL,B.OBS,B.PAGO,B.ID
from bono_turismo B,  Bono_Turismo_Pasajes BTP, Localidad L
where B.ID = BTP.BONO and  BTP.DESTINO= L.LOCALIDADID AND B.TIPO='PAS' and B.FE_BONO > '" + Desde + "' AND B.FE_BONO < '" + Hasta + "'" ;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            int I=0;
            if (foundRows.Length > 0)
            {
                Memoria m = new Memoria();
                m.Nro_Solicitud =  Int32.Parse(foundRows[I][0].ToString());
                m.Fecha         = foundRows[I][1].ToString();
                m.Nombre_Apellido = foundRows[I][2].ToString() + " " + foundRows[I][3].ToString();
                m.Destino         = foundRows[I][4].ToString();
                m.Pax             = foundRows[I][5].ToString();
                m.Contado         = foundRows[I][6].ToString();
                m.PLanilla        = foundRows[I][7].ToString();
                m.Cuotas          = foundRows[I][8].ToString();
                if (m.Cuotas.Length > 1)
                {
                    if (m.Cuotas != "0")
                    m.Valor_Cuota = Decimal.Round(Decimal.Parse(m.PLanilla) / Decimal.Parse(m.Cuotas), 2).ToString();
                }
                    m.Total           = foundRows[I][9].ToString();
                m.Obs             = foundRows[I][10].ToString();
                m.Obs_Pago            = foundRows[I][11].ToString();
                I=I+1;
                lista.Add(m);

            }

            return lista;

        }


      

        public List<Memoria_Hotel> getHoteles(string Desde, string Hasta)
        {


            List<Memoria_Hotel> lista = new List<Memoria_Hotel>();
            string QUERY = @"select  B.ID_ROL,
                                     B.FE_BONO,
                                     B.APELLIDO,
                                     B.NOMBRE ,
                                     H.NOMBRE,
                                     V.PASAJEROS,
(B.EFECTIVO + B.TARJETA_CREDITO + B.TARJETA_DEBITO +B.TRANSFER )CONTADO,
(B.PLANILLA )PLANILLA ,
 (B.PLANILLA_CUOTAS)CUOTAS,B.SALDO_INICIAL,B.OBS,B.PAGO,B.ID,V.NOCHES
from bono_turismo B, voucher_Bono_Hotel V, Hotel H 
where B.TIPO='HOT' and V.BONO=B.ID and H.ID=V.HOTEL and B.FE_BONO > '" + Desde + "' AND B.FE_BONO < '" + Hasta + "'";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            int I = 0;
            if (foundRows.Length > 0)
            {
                Memoria_Hotel m = new Memoria_Hotel();
                m.Nro_Solicitud = Int32.Parse(foundRows[I][0].ToString());
                m.Fecha = foundRows[I][1].ToString();
                m.Nombre_Apellido = foundRows[I][2].ToString() + " " + foundRows[I][3].ToString();
                m.Destino = foundRows[I][4].ToString();
                m.Pax = foundRows[I][5].ToString();
                m.Contado = foundRows[I][6].ToString();
                m.PLanilla = foundRows[I][7].ToString();
                m.Cuotas = foundRows[I][8].ToString();
                if (m.Cuotas.Length > 0)
                {   if (m.Cuotas !="0")
                    m.Valor_Cuota = Decimal.Round(Decimal.Parse(m.PLanilla) / Decimal.Parse(m.Cuotas), 2).ToString();
                }
                m.Total = foundRows[I][9].ToString();
                m.Obs = foundRows[I][10].ToString();
                m.Obs_Pago = foundRows[I][11].ToString();
                m.Noches = foundRows[I][13].ToString();
                m.Plazas =  (Int32.Parse(m.Noches) * Int32.Parse(m.Pax)).ToString();

                I = I + 1;
                lista.Add(m);

            }

            return lista;


        }

        public List<Memoria_Hotel> getSalidas(string Desde, string Hasta)
        {


            List<Memoria_Hotel> lista = new List<Memoria_Hotel>();
            int I = 0;
            string QUERY = @"select  B.ID_ROL,
                                     B.FE_BONO,
                                     B.APELLIDO,
                                     B.NOMBRE ,
                                     L.DESCRIPCION,
                                     BS.DIAS,
(B.EFECTIVO + B.TARJETA_CREDITO + B.TARJETA_DEBITO +B.TRANSFER )CONTADO,
(B.PLANILLA )PLANILLA ,
 (B.PLANILLA_CUOTAS)CUOTAS,B.SALDO_INICIAL,B.OBS,B.PAGO,(select count(ID) from bono_personas where bono=B.ID)
from bono_turismo B,  TURISMO_SALIDA BS, Localidad L
where B.SALIDA = BS.ID and  BS.LOC_HASTA= L.LOCALIDADID AND B.TIPO='PAQ' and B.FE_BONO > '" + Desde + "' AND B.FE_BONO < '" + Hasta + "'";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                Memoria_Hotel m = new Memoria_Hotel();
                m.Nro_Solicitud = Int32.Parse(foundRows[I][0].ToString());
                m.Fecha = foundRows[I][1].ToString();
                m.Nombre_Apellido = foundRows[I][2].ToString() + " " + foundRows[I][3].ToString();
                m.Destino = foundRows[I][4].ToString();
                m.Pax = foundRows[I][12].ToString();
                m.Contado = foundRows[I][6].ToString();
                m.PLanilla = foundRows[I][7].ToString();
                m.Cuotas = foundRows[I][8].ToString();
                if (m.Cuotas.Length > 0)
                {
                    if (m.Cuotas != "0")
                        m.Valor_Cuota = Decimal.Round(Decimal.Parse(m.PLanilla) / Decimal.Parse(m.Cuotas), 2).ToString();
                }
                m.Total = foundRows[I][9].ToString();
                m.Obs = foundRows[I][10].ToString();
                m.Obs_Pago = foundRows[I][11].ToString();
                m.Noches = foundRows[I][5].ToString();
                m.Plazas = (Int32.Parse(m.Noches) * Int32.Parse(m.Pax)).ToString();

                I = I + 1;
                lista.Add(m);




            }

            return lista;

        }

        private string fechaUSA(DateTime fecha)
        {
            string Fecha = fecha.Month.ToString("00") + "/" + fecha.Day.ToString("00") + "/" + fecha.Year.ToString("0000");

            return Fecha;


        }

    }
}
