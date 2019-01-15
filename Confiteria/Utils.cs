using System.Data;
using SOCIOS;
using FirebirdSql.Data.FirebirdClient;
using System;

namespace Confiteria
{
    class Utils
    {
        bo dlog = new bo();
        db db = new db();

        public DataSet getDataFromQuery(string QUERY)
        {
            conString conString = new conString();
            string connectionString = conString.get();

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                DataSet ds = new DataSet();
                FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                cmd.CommandText = QUERY;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet getDataFromQuery(string QUERY, string ROL)
        {
            conString conString = new conString();
            string connectionString = conString.getRemota(ROL);

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                DataSet ds = new DataSet();
                FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                cmd.CommandText = QUERY;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                FbDataAdapter da = new FbDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }

        public bool setExportado(string TABLA, string CAMPO, int ID, string  ROL, int VALOR)
        {
            try
            {
                string QUERY = "UPDATE " + TABLA + " SET " + CAMPO + " = " + VALOR + " WHERE ID = " + ID + ";";
                db.Ejecuto_Consulta_Remota(QUERY, ROL);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }       

        public bool setGrabaComanda(string VALOR)
        {
            try
            {
                string QUERY = "UPDATE CONFIG SET VALOR = '"+ VALOR +"' WHERE PARAM = 'GRABA_COMANDA' AND ROL = 'CONFITERIA';";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool setGrabaCaja(string VALOR)
        {
            try
            {
                string QUERY = "UPDATE CONFIG SET VALOR = '" + VALOR + "' WHERE PARAM = 'GRABA_CAJA' AND ROL = 'CONFITERIA';";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string getGrabaComanda()
        {
            string GRABA = "N";
            string QUERY = "SELECT VALOR FROM CONFIG WHERE PARAM = 'GRABA_COMANDA' AND ROL = 'CONFITERIA';";
            DataSet GET = getDataFromQuery(QUERY);

            if (GET.Tables.Count > 0)
            {
                foreach (DataRow ROW in GET.Tables[0].Rows)
                {
                    GRABA = ROW[0].ToString().Trim();
                }
            }

            return GRABA;
        }

        public string getGrabaCaja()
        {
            string GRABA= "N";
            string QUERY = "SELECT VALOR FROM CONFIG WHERE PARAM = 'GRABA_CAJA' AND ROL = 'CONFITERIA';";
            DataSet GET = getDataFromQuery(QUERY);

            if (GET.Tables.Count > 0)
            {
                foreach (DataRow ROW in GET.Tables[0].Rows)
                {
                    GRABA = ROW[0].ToString().Trim();
                }
            }

            return GRABA;
        }
    }
}
