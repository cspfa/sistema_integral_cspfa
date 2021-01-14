using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace SOCIOS.Entrada_Campo
{
    public class DiasPileta
    {
        public int ID { get; set; }
        public string Desde_Hasta { get; set; }
    }

    public class InfoPiletaDia 
    {
        public string Horario  { get; set; }
        public int    Socio    { get; set; }
        public int    Inter    { get; set; }
        public int    Invi     { get; set; }
        public int    Menor    { get; set; }
        public int    Disc     { get; set; }
        public int    Oro      { get; set; }
        public int    Promo    { get; set; }
        public int    Total    { get; set; }
        public int HorarioID   { get; set; }
       
        public InfoPiletaDia()
        {
            Horario = "";
            Socio = 0;
            Inter = 0;
            Invi = 0;
            Menor = 0;
            Disc = 0;
            Oro = 0;
            Promo = 0;
            Total = 0;
        }

    }

    public class DiasPiletaService
    {
        bo_Entrada_Campo dlog = new bo_Entrada_Campo();
        string Mensaje_Aforo;
         
       


        public List<DiasPileta> getDiasPileta()
      { 
            List<DiasPileta> Lista = new List<DiasPileta>();
            DiasPileta item = new DiasPileta();


            


            string QUERY = @"SELECT   * from PILETA_HORARIOS where ID>-2";

            //AND ROL = '" + VGlobales.vp_role + "'";

           


            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {


                int I = 0;

                while (I <= (foundRows.Length - 1))
                {

                    item = new DiasPileta();
                    item.ID =Int32.Parse(foundRows[I][0].ToString().Trim());
                    item.Desde_Hasta = (foundRows[I][1].ToString().Trim() + " / " + (foundRows[I][2].ToString().Trim())) + " HS ";
                        
                    Lista.Add(item);
                    I = I + 1;
      
                }
                
            }

            return Lista;
        }

        public List<InfoPiletaDia> INFO_HORARIOS()
        {
            List<InfoPiletaDia> lista = new List<InfoPiletaDia>();
            InfoPiletaDia abono = this.Cantidad_Horario(System.DateTime.Now, 0);

            foreach (DiasPileta dia in getDiasPileta().OrderBy(x=>x.ID) )
            {
                InfoPiletaDia item = this.Cantidad_Horario(System.DateTime.Now, dia.ID);
                item.Horario = dia.Desde_Hasta;
                item.Socio   = item.Socio + abono.Socio;
                item.Inter   = item.Inter + abono.Inter;
                item.Invi    = item.Invi + abono.Invi;
                item.Menor = item.Menor + abono.Menor;
                item.Oro = item.Oro + abono.Oro;
                item.Promo = item.Promo + abono.Promo;
                item.Total = item.Total + abono.Total;
                lista.Add(item);
            }

            return lista;
        
        }


        public string  getDiasPileta(int Dia)
        {
            List<DiasPileta> Lista = new List<DiasPileta>();
            DiasPileta item = new DiasPileta();





            string QUERY = @"SELECT   * from PILETA_HORARIOS where ID=" + Dia.ToString();

            //AND ROL = '" + VGlobales.vp_role + "'";




            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {


                int I = 0;

                while (I <= (foundRows.Length - 1))
                {
                    return (foundRows[I][1].ToString().Trim() + " / " + (foundRows[I][2].ToString().Trim()));
                   
                    I = I + 1;

                }

            }

            return "";
        }

        public int AforoFecha(DateTime Fecha)
        {
            // return AforoFecha(Fecha, false) + ( AforoFecha(Fecha, true) * Cantidad_Horarios());
            return AforoFecha(Fecha, false);

        }


        public int AforoFecha(DateTime Fecha,bool Abono)
        {
            int cantidad=0;

            string QUERY = " select  SUM(Promo + Invitado_Pileta + SOCIO_PILETA + inter_pileta + Menor + Disca + DISCA_ACOM) from entrada_Campo where Fecha>'" + Fecha.AddDays(-1).ToString("MM/dd/yyyy") + "' and Fecha< '" + Fecha.AddDays(+1).ToString("MM/dd/yyyy") + "' and HORA_PILETA>-1  ";

            if (Abono)
                QUERY = QUERY + " AND HORA_PILETA=0";

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {

                if (foundRows[0][0].ToString().Length == 0)
                      return 0;

                return Int32.Parse(foundRows[0][0].ToString().Trim());;
            }
            else
                return 0;

            
        
        }


        public int PersonasFecha(DateTime Fecha)
        {
            int cantidad = 0;

            string QUERY = " select  SUM(INVITADO + SOCIO + INTER) from entrada_Campo where Fecha>'" + Fecha.AddDays(-1).ToString("MM/dd/yyyy") + "' and Fecha< '" + Fecha.AddDays(+1).ToString("MM/dd/yyyy") + "' and HORA_PILETA>-1  ";

       
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {

                if (foundRows[0][0].ToString().Length == 0)
                    return 0;

                return Int32.Parse(foundRows[0][0].ToString().Trim()); ;
            }
            else
                return 0;



        }


        public int AforoHorarios(DateTime Fecha, int Horario)
        {

            int cantidad = 0;

            string QUERY = " select  SUM(Promo + INVI_PILETA + SOCIO_PILETA + inter_pileta + Menor + Disca + DISCA_ACOM) from entrada_Campo_ph where Fecha>'" + Fecha.AddDays(-1).ToString("MM/dd/yyyy") + "' and Fecha< '" + Fecha.AddDays(+1).ToString("MM/dd/yyyy") + "'  and ID_HORA=  " + Horario.ToString() + "";

           

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                if (foundRows[0][0].ToString().Length == 0)
                    return 0;

                return Int32.Parse(foundRows[0][0].ToString().Trim()); ;
            }
            else
                return 0;

        }

        public InfoPiletaDia Cantidad_Horario(DateTime Fecha, int Horario)
        {

            int cantidad = 0;
            InfoPiletaDia info = new InfoPiletaDia();
            string QUERY = " select  Coalesce(SUM(SOCIO_PILETA),0),Coalesce(SUM(INTER_PILETA),0),Coalesce(SUM(INVI_PILETA),0),Coalesce(SUM(MENOR),0),Coalesce(SUM(DISCA),0),Coalesce(SUM(DISCA_ACOM),0),Coalesce(SUM(PROMO),0) from entrada_Campo_PH where Fecha>'" + Fecha.AddDays(-1).ToString("MM/dd/yyyy") + "' and Fecha< '" + Fecha.AddDays(+1).ToString("MM/dd/yyyy") + "'  and ID_HORA= " + Horario.ToString();



            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                info.Socio = Int32.Parse(foundRows[0][0].ToString().Trim());
                info.Inter = Int32.Parse(foundRows[0][1].ToString().Trim());
                info.Invi  = Int32.Parse(foundRows[0][2].ToString().Trim());
                info.Menor = Int32.Parse(foundRows[0][3].ToString().Trim());
                info.Disc  = Int32.Parse(foundRows[0][4].ToString().Trim());
                info.Oro   = Int32.Parse(foundRows[0][5].ToString().Trim());
                info.Promo = Int32.Parse(foundRows[0][6].ToString().Trim());
                info.Total = info.Socio + info.Inter + info.Invi + info.Menor + info.Disc + info.Oro + info.Promo;
               

                return info ;
            }
            else
                return info;

        }

        
        
        public int Cantidad_Horarios()
        {
            
            string QUERY = @"SELECT   count(*) from PILETA_HORARIOS";

            //AND ROL = '" + VGlobales.vp_role + "'";

           


            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {


                int I = 0;

                while (I <= (foundRows.Length - 1))
                {

                    return Int32.Parse(foundRows[I][0].ToString().Trim());
                }
                
            }

            return 0;


        }


        public List<InfoPiletaDia> Cantidad_Horarios_Entrada(int ID_EC, string ROL)
        {
            List<InfoPiletaDia> lista = new List<InfoPiletaDia>();

           
            string QUERY = " select  SOCIO_PILETA,INTER_PILETA,INVI_PILETA,MENOR,DISCA,DISCA_ACOM,PROMO,ID_HORA from ENTRADA_CAMPO_PH  where ID_EC=" + ID_EC.ToString() + " and ROL='"+ROL+"'";



            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            int I = 0;

            while (I<foundRows.Length)
           
            {
                InfoPiletaDia info = new InfoPiletaDia();
                info.Socio = Int32.Parse(foundRows[I][0].ToString().Trim());
                info.Inter = Int32.Parse(foundRows[I][1].ToString().Trim());
                info.Invi = Int32.Parse(foundRows[I][2].ToString().Trim());
                info.Menor = Int32.Parse(foundRows[I][3].ToString().Trim());
                info.Disc = Int32.Parse(foundRows[I][4].ToString().Trim());
                info.Oro = Int32.Parse(foundRows[I][5].ToString().Trim());
                info.Promo = Int32.Parse(foundRows[I][6].ToString().Trim());
                info.Total = info.Socio + info.Inter + info.Invi + info.Menor + info.Disc + info.Oro + info.Promo;
                info.HorarioID = Int32.Parse(foundRows[I][7].ToString().Trim());
                info.Horario = this.getDiasPileta(info.HorarioID);

                lista.Add(info);
                I = I + 1;
            }
            return lista;

        }


    }
    
    
    }


 