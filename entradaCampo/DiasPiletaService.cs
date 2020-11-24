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

    public class DiasPiletaService
    {
        bo_Entrada_Campo dlog = new bo_Entrada_Campo();
        string Mensaje_Aforo;
         
        public List<DiasPileta> getDiasPileta()
      { 
            List<DiasPileta> Lista = new List<DiasPileta>();
            DiasPileta item = new DiasPileta();


            


            string QUERY = @"SELECT   * from PILETA_HORARIOS";

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
                    item.Desde_Hasta = (foundRows[I][1].ToString().Trim() + " / " + (foundRows[I][2].ToString().Trim()));
                    Lista.Add(item);
                    I = I + 1;
      
                }
                
            }

            return Lista;
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
            return AforoFecha(Fecha, false) + ( AforoFecha(Fecha, true) * Cantidad_Horarios());
        
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

        public int AforoHorarios(DateTime Fecha, int Horario)
        {

            int cantidad = 0;

            string QUERY = " select  SUM(Promo + Invitado_Pileta + SOCIO_PILETA + inter_pileta + Menor + Disca + DISCA_ACOM) from entrada_Campo where Fecha>'" + Fecha.AddDays(-1).ToString("MM/dd/yyyy") + "' and Fecha< '" + Fecha.AddDays(+1).ToString("MM/dd/yyyy") + "'  and HORA_PILETA>-1 and (HORA_PILETA=0 or HORA_PILETA=  " + Horario.ToString() + ")";

           

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
    }
    
    
    }


 