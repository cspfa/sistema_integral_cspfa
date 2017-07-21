using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.bono
{
    public class Odontologico
    {
        bo dlog = new bo();
        BonoOdontologico bono;
        int idBono;
        string Nro_Socio="", Nro_Dep="", Barra="", Nro_Socio_Titular="", Nro_Dep_titular="", Prof="", formaPago="", Obs="";
        int SECACT=0, TURNO=0;
        decimal Saldo = 0;
        DateTime Fecha;


        public Odontologico(int ID, bool Directo)
        {
            this.Datos(ID, Directo);
            ReporteBonoOdontologico rb = new ReporteBonoOdontologico(bono.srvDatosSocio.CAB, bono.persona, Fecha,idBono, Prof, formaPago, Obs, Saldo);
            rb.ShowDialog();
            rb.Focus();
        }

       
        

        private void Datos(int ID, bool Directo)

        {
         
            string QUERY = "SELECT  ID,Fe_Bono,SALDO_INICIAL,Nro_Socio,Nro_Dep,Barra,Nro_Socio_Titular,NRO_DEP_TITULAR,Sec_Act,Turno,Prof,Pago,Obs FROM BONO_ODONTOLOGICO";
            
            if (Directo)
                QUERY= QUERY +    " WHERE ID=" + ID.ToString();
            else
                QUERY = QUERY + " WHERE TURNO=" + ID.ToString();

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                idBono    = Int32.Parse(foundRows[0][0].ToString());
                Fecha = DateTime.Parse(foundRows[0][1].ToString());
                Saldo = Decimal.Parse( foundRows[0][2].ToString());

               Nro_Socio        = foundRows[0][3].ToString();
               Nro_Dep           = foundRows[0][4].ToString();
               Barra             = foundRows[0][5].ToString();
               Nro_Socio_Titular = foundRows[0][6].ToString();
               Nro_Dep_titular   = foundRows[0][7].ToString();
               SECACT            = Int32.Parse(foundRows[0][8].ToString());
               TURNO             = Int32.Parse(foundRows[0][9].ToString());
               Prof              = foundRows[0][10].ToString();
               formaPago         = foundRows[0][11].ToString();
               Obs               = foundRows[0][12].ToString();
               
               bono = new BonoOdontologico(Nro_Socio, Nro_Dep, Barra, Nro_Socio_Titular, Nro_Dep_titular,SECACT,TURNO,false,"TURNO");
               

            }
          


        
        
        }
        private void MostrarReporte()

        { 
        
        }
        
    }

    public class Turismo

    {     bo dlog = new bo();
        BonoPasaje  bono;
        handlerDatosSocios Socio;
        DatoSocio persona;
        int idBono;
        string Nro_Socio="", Nro_Dep="", Barra="", Nro_Socio_Titular="", Nro_Dep_titular="", Prof="", formaPago="", Obs="",Tipo="";
        int SECACT=0, TURNO=0, Salida =0;
        decimal Saldo = 0;
        DateTime Fecha;


        public Turismo(int ID)
        {
            this.Datos(ID);
            Socio = new handlerDatosSocios(Nro_Socio, Nro_Dep);
            if (Tipo.Contains("PAS"))
            {
                ReporteBonoPasaje rb = new ReporteBonoPasaje(Socio.CAB, Fecha, ID, formaPago, Obs, Saldo);
                rb.ShowDialog();
                rb.Focus();
            }
            else if (Tipo.Contains("PAQ"))
            {
                ReporteBonoPaquete rp = new ReporteBonoPaquete(Socio.CAB, Fecha, ID, formaPago, Obs, Saldo, Salida);
                rp.ShowDialog();
                rp.Focus();

            }
            else //hotel!
            {
                ReporteBonoHotel rp = new ReporteBonoHotel(Socio.CAB, Fecha, ID, formaPago, Obs, Saldo);
                rp.ShowDialog();
                rp.Focus();

            }
        }

       
        

        private void Datos(int ID)

        {

            string QUERY = "SELECT  ID,Fe_Bono,SALDO_INICIAL,Nro_Socio_Titular,Nro_Dep_Titular,Pago,Obs,TIPO,coalesce(SALIDA,'0') FROM BONO_TURISMO WHERE ID=" + ID.ToString();
            
       

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                idBono            = Int32.Parse(foundRows[0][0].ToString());
                Fecha             = DateTime.Parse(foundRows[0][1].ToString());
                Saldo             = Decimal.Parse( foundRows[0][2].ToString());
                Nro_Socio         = foundRows[0][3].ToString();
                Nro_Dep           = foundRows[0][4].ToString();
                formaPago         = foundRows[0][5].ToString();
                Obs               = foundRows[0][6].ToString();
                Tipo              = foundRows[0][7].ToString();
                Salida            = Int32.Parse( foundRows[0][8].ToString());
               // bono = new BonoPasaje  (null,Nro_Socio,Nro_Dep,false);
               

            }
            QUERY = "";
           
          


        
        
        }
        private void MostrarReporte()

        { 
        
        }
    
    
    }


}
