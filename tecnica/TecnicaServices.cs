using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;
using System.Data;
namespace SOCIOS.Tecnica
{


    public class Ticket
    {
        public int ID { get; set; }
        public string EQUIPO { get; set; }
        public string TECNICO { get; set; }
        public string USR_ALTA { get; set; }
        public string PROBLEMA { get; set; }
        public string PRIORIDAD { get; set; }
        public string ESTADO { get; set; }
        public string FECHA_PENDIENTE { get; set; }
        public string FECHA_ACTIVO { get; set; }
        public string FECHA_CUMPLIMENTADO { get; set; }
        public string FECHA_CANCELADO { get; set; }
        public string OBS_ACTIVO { get; set; }
        public string OBS_CUMPLIMENTADO { get; set; }
        public string OBS_CANCELADO { get; set; }
        public string FECHA_MODIFICACION { get; set; }
        public string USR_MODIFICACION { get; set; }
    }


    public class TicketReporte
    {
        public int ID { get; set; }
        public string EQUIPO { get; set; }
        public string TECNICO { get; set; }
        public string USR_ALTA { get; set; }
        public string PROBLEMA { get; set; }
        public string PRIORIDAD { get; set; }
        public string ESTADO { get; set; }
        public string FECHA_PENDIENTE { get; set; }
        public string FECHA { get; set; }
        public string OBS { get; set; }
        public string FECHA_MODIFICACION { get; set; }
        public string USR_MODIFICACION { get; set; }

    }


    public class TecnicaServices
    {

        bo_Tecnica dlog = new bo_Tecnica();
        public List<Ticket> Tickets(int ID, string Estado, bool SoloRol, bool FiltroFecha, DateTime Desde, DateTime Hasta)
        {
            List<Ticket> lista = new List<Ticket>();

            string query = "SELECT * FROM ASISTENCIAS_TECNICAS  WHERE 1=1 ";

            if (Estado != "NO")
            {
                query = query + "AND ESTADO = '" + Estado.ToString() + "' ";
            }

            if (ID != 0)
            {
                query = query + "AND  ID = " + ID.ToString();
            }

         

            if (FiltroFecha && (Estado=="PENDIENTE" || Estado=="NO"))
            {
                query = query + "AND FECHA_PENDIENTE  Between  '" + String.Format("{0:M/d/yyyy}", Desde) + "' AND '" + String.Format("{0:M/d/yyyy}", Hasta) + "' order by FECHA_PENDIENTE ASC ";

            }

            if (FiltroFecha && Estado == "ACTIVO")
            {
                query = query + "AND FECHA_ACTIVO  Between  '" + String.Format("{0:M/d/yyyy}", Desde) + "' AND '" + String.Format("{0:M/d/yyyy}", Hasta) + "' order by FECHA_ACTIVO ASC ";

            }
            if (FiltroFecha && Estado == "CUMPLIMENTADO")
            {
                query = query + "AND FECHA_CUMPLIMENTADO  Between  '" + String.Format("{0:M/d/yyyy}", Desde) + "' AND '" + String.Format("{0:M/d/yyyy}", Hasta) + "' order by FECHA_CUMPLIMENTADO ASC ";

            }
            if (FiltroFecha && Estado == "CANCELADO")
            {
                query = query + "AND FECHA_CANCELADO  Between  '" + String.Format("{0:M/d/yyyy}", Desde) + "' AND '" + String.Format("{0:M/d/yyyy}", Hasta) + "' order by FECHA_CANCELADO ASC ";

            }



            /*if (SoloRol)
            {
                if  (Estado != "NO")
                     query = query + " AND  ROL= '" +  VGlobales.vp_role + "'";
                else
                    query = query + " WHERE  ROL= '" + VGlobales.vp_role + "'";
            }*/

            conString cs = new conString();
            string connectionString = cs.get();

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                FbCommand cmd = new FbCommand(query, connection, transaction);
                FbDataReader reader3 = cmd.ExecuteReader();

                while (reader3.Read())
                {
                    Ticket item = new Ticket();

                    item.ESTADO = reader3.GetString(reader3.GetOrdinal("ESTADO")).Trim();

                    if (item.ESTADO == "CANCELADO")
                    {
                        if (reader3.GetString(reader3.GetOrdinal("FECHA_CANCELADO")).Trim().Length > 0)
                        {
                            item.FECHA_CANCELADO = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA_CANCELADO")).Trim()).ToShortDateString();
                            item.OBS_CANCELADO = reader3.GetString(reader3.GetOrdinal("OBS_CANCELADO")).Trim();
                        }
                    }
                    else if (item.ESTADO == "CUMPLIMENTADO")
                    {
                        if (reader3.GetString(reader3.GetOrdinal("FECHA_CUMPLIMENTADO")).Trim().Length > 0)
                        {
                            item.FECHA_CUMPLIMENTADO = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA_CUMPLIMENTADO")).Trim()).ToShortDateString();
                            item.OBS_CUMPLIMENTADO = reader3.GetString(reader3.GetOrdinal("OBS_CUMPLIMENTADO")).Trim();
                        }
                    }
                    else if (item.ESTADO == "ACTIVO")
                    {
                        if (reader3.GetString(reader3.GetOrdinal("FECHA_ACTIVO")).Trim().Length > 0)
                        {
                            item.FECHA_ACTIVO = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA_ACTIVO")).Trim()).ToShortDateString();
                            item.OBS_ACTIVO = reader3.GetString(reader3.GetOrdinal("OBS_ACTIVO")).Trim();
                        }
                    }

                    item.FECHA_PENDIENTE = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA_PENDIENTE")).Trim()).ToShortDateString();
                    item.ID = Int32.Parse(reader3.GetString(reader3.GetOrdinal("ID")).Trim());
                    item.EQUIPO = reader3.GetString(reader3.GetOrdinal("NOM_EQ")).Trim();
                    item.PROBLEMA = reader3.GetString(reader3.GetOrdinal("PROBLEMA")).Trim();
                    item.PRIORIDAD = reader3.GetString(reader3.GetOrdinal("PRIORIDAD")).Trim();
                    item.USR_ALTA = reader3.GetString(reader3.GetOrdinal("USUARIO_ALTA")).Trim();
                    item.TECNICO = reader3.GetString(reader3.GetOrdinal("TECNICO")).Trim();



                    if (reader3.GetString(reader3.GetOrdinal("FECHA_ACTIVO")) != "")
                    {
                        item.FECHA_ACTIVO = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA_ACTIVO")).Trim()).ToShortDateString();
                    }
                    else
                    {
                        item.FECHA_ACTIVO = "";
                    }

                    if (reader3.GetString(reader3.GetOrdinal("FECHA_CUMPLIMENTADO")) != "")
                    {
                        item.FECHA_CUMPLIMENTADO = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA_CUMPLIMENTADO")).Trim()).ToShortDateString();
                    }
                    else
                    {
                        item.FECHA_CUMPLIMENTADO = "";
                    }

                    if (reader3.GetString(reader3.GetOrdinal("FECHA_CANCELADO")) != "")
                    {
                        item.FECHA_CANCELADO = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA_CANCELADO")).Trim()).ToShortDateString();
                    }
                    else
                    {
                        item.FECHA_CANCELADO = "";
                    }

                    item.OBS_ACTIVO = reader3.GetString(reader3.GetOrdinal("OBS_ACTIVO")).Trim();
                    item.OBS_CUMPLIMENTADO = reader3.GetString(reader3.GetOrdinal("OBS_CUMPLIMENTADO")).Trim();
                    item.OBS_CANCELADO = reader3.GetString(reader3.GetOrdinal("OBS_CANCELADO")).Trim();
                    
                    if (reader3.GetString(reader3.GetOrdinal("USR_U")) != "")
                    {
                        item.USR_MODIFICACION = reader3.GetString(reader3.GetOrdinal("USR_U"));
                    }

                    if (reader3.GetString(reader3.GetOrdinal("FECHA_U")) != "")
                    {
                        item.FECHA_MODIFICACION = reader3.GetString(reader3.GetOrdinal("FECHA_U"));
                    }

                    lista.Add(item);
                }

                return lista;
            }
        }

      public   List<TicketReporte> ReporteTicket(List<Ticket> lista)

        {
          
            List<TicketReporte> repor = new List<TicketReporte>();
            foreach (Ticket t in lista)

            {
                TicketReporte r = new TicketReporte();
                r.ID = t.ID;
                r.FECHA_PENDIENTE = r.FECHA_PENDIENTE;
                r.PROBLEMA = t.PROBLEMA;
                r.TECNICO = t.TECNICO;
                r.USR_ALTA = t.USR_ALTA;
                r.USR_MODIFICACION = t.USR_MODIFICACION;
                r.ESTADO = t.ESTADO;
                r.EQUIPO = t.ESTADO;
              
                if (t.ESTADO == "ACTIVO")
                {
                    r.FECHA = t.FECHA_ACTIVO;
                    r.OBS = t.OBS_ACTIVO;
                }
                else if (t.ESTADO == "CANCELADO")
                { r.FECHA = t.FECHA_CANCELADO;
                    r.OBS = t.OBS_CUMPLIMENTADO;

                }
                else if (t.ESTADO == "CUMPLIMENTADO")
                {
                    r.FECHA = t.FECHA_CUMPLIMENTADO;
                    r.OBS = t.OBS_CUMPLIMENTADO;
                }

                repor.Add(r);
            
            }

            return repor;
        
        
        }

        public void CargoTEcnicos(ComboBox cb)
        {
            cb.Items.Add("SANTIAGO VEYGA");
            cb.Items.Add("ANDRES HERNANDEZ");
            cb.Items.Add("SUSANA BARBEITO");
            cb.Items.Add("NICOLAS PLATERO");
            cb.Items.Add("LORENA LOPEZ");
            cb.Items.Add("ELIANA MARTIRE");
        }


        public Ticket getTicket(int ID)
        {
            string QUERY = "SELECT * from ASISTENCIAS_TECNICAS WHERE ID= " + ID.ToString();


            conString cs = new conString();
            string connectionString = cs.get();

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                FbDataReader reader3 = cmd.ExecuteReader();

                while (reader3.Read())
                {
                    Ticket item = new Ticket();

                    item.ESTADO = reader3.GetString(reader3.GetOrdinal("ESTADO")).Trim();

                    if (item.ESTADO == "CANCELADO")
                    {
                        if (reader3.GetString(reader3.GetOrdinal("FECHA_CANCELADO")).Trim().Length > 0)
                        {
                            item.FECHA_CANCELADO = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA_CANCELADO")).Trim()).ToShortDateString();
                            item.OBS_CANCELADO = reader3.GetString(reader3.GetOrdinal("OBS_CANCELADO")).Trim();
                        }
                    }
                    else if (item.ESTADO == "CUMPLIMENTADO")
                    {
                        if (reader3.GetString(reader3.GetOrdinal("FECHA_CUMPLIMENTADO")).Trim().Length > 0)
                        {
                            item.FECHA_CUMPLIMENTADO = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA_CUMPLIMENTADO")).Trim()).ToShortDateString();
                            item.OBS_CUMPLIMENTADO = reader3.GetString(reader3.GetOrdinal("OBS_CUMPLIMENTADO")).Trim();
                        }
                    }
                    else if (item.ESTADO == "ACTIVO")
                    {
                        if (reader3.GetString(reader3.GetOrdinal("FECHA_ACTIVO")).Trim().Length > 0)
                        {
                            item.FECHA_ACTIVO = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA_ACTIVO")).Trim()).ToShortDateString();
                            item.OBS_ACTIVO = reader3.GetString(reader3.GetOrdinal("OBS_ACTIVO")).Trim();
                        }
                    }

                    item.FECHA_PENDIENTE = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA_PENDIENTE")).Trim()).ToShortDateString();
                    item.ID = Int32.Parse(reader3.GetString(reader3.GetOrdinal("ID")).Trim());
                    item.EQUIPO = reader3.GetString(reader3.GetOrdinal("NOM_EQ")).Trim();
                    item.PROBLEMA = reader3.GetString(reader3.GetOrdinal("PROBLEMA")).Trim();
                    item.PRIORIDAD = reader3.GetString(reader3.GetOrdinal("PRIORIDAD")).Trim();
                    item.USR_ALTA = reader3.GetString(reader3.GetOrdinal("USUARIO_ALTA")).Trim();
                    item.TECNICO = reader3.GetString(reader3.GetOrdinal("TECNICO")).Trim();



                    if (reader3.GetString(reader3.GetOrdinal("FECHA_ACTIVO")) != "")
                    {
                        item.FECHA_ACTIVO = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA_ACTIVO")).Trim()).ToShortDateString();
                    }
                    else
                    {
                        item.FECHA_ACTIVO = "";
                    }

                    if (reader3.GetString(reader3.GetOrdinal("FECHA_CUMPLIMENTADO")) != "")
                    {
                        item.FECHA_CUMPLIMENTADO = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA_CUMPLIMENTADO")).Trim()).ToShortDateString();
                    }
                    else
                    {
                        item.FECHA_CUMPLIMENTADO = "";
                    }

                    if (reader3.GetString(reader3.GetOrdinal("FECHA_CANCELADO")) != "")
                    {
                        item.FECHA_CANCELADO = DateTime.Parse(reader3.GetString(reader3.GetOrdinal("FECHA_CANCELADO")).Trim()).ToShortDateString();
                    }
                    else
                    {
                        item.FECHA_CANCELADO = "";
                    }

                    item.OBS_ACTIVO = reader3.GetString(reader3.GetOrdinal("OBS_ACTIVO")).Trim();
                    item.OBS_CUMPLIMENTADO = reader3.GetString(reader3.GetOrdinal("OBS_CUMPLIMENTADO")).Trim();
                    item.OBS_CANCELADO = reader3.GetString(reader3.GetOrdinal("OBS_CANCELADO")).Trim();
                    if (reader3.GetString(reader3.GetOrdinal("USR_U")) != "")
                    {
                        item.USR_MODIFICACION = reader3.GetString(reader3.GetOrdinal("USR_U"));
                    }

                    if (reader3.GetString(reader3.GetOrdinal("FECHA_U")) != "")
                    {
                        item.FECHA_MODIFICACION = reader3.GetString(reader3.GetOrdinal("FECHA_U"));
                    }

                    return item;
                }
                return null;





            }
        }
    }
}

