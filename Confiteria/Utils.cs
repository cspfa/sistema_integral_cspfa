using System.Data;
using SOCIOS;
using FirebirdSql.Data.FirebirdClient;
using System;

namespace Confiteria
{
    public class Utils
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

        public DataSet barCodeSearch(string BARCODE)
        {
            string QUERY = "SELECT P.ID, PE.ESPECIALIDAD, P.NOMBRE FROM PROFESIONALES P, PROF_ESP PE WHERE P.ID = PE.PROFESIONAL AND P.ROL = 'MENU " + VGlobales.vp_role + "' AND P.BARCODE = '" + BARCODE + "';";
            DataSet GET = getDataFromQuery(QUERY);
            return GET;
        }

        public bool setBarcode(int ITEM, string BARCODE)
        {
            try
            {
                string QUERY = "UPDATE PROFESIONALES SET BARCODE = '" + BARCODE + "' WHERE ID = " + ITEM + ";";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public DataSet getItemsSuma(DataSet COMANDAS)
        {
            string QUERY = "SELECT COUNT(ITEM_DETALLE) AS CANTIDAD, ITEM_DETALLE, SUM(SUBTOTAL) FROM CONFITERIA_COMANDA_ITEM WHERE COMANDA IN(";
            int TOTAL = COMANDAS.Tables[0].Rows.Count;

            foreach (DataRow ROW in COMANDAS.Tables[0].Rows)
            {
                QUERY += Convert.ToInt32(ROW[0])+",";               
            }

            QUERY = QUERY.TrimEnd(',');
            QUERY +=") GROUP BY ITEM_DETALLE;";
            DataSet GET = getDataFromQuery(QUERY);
            return GET;
        }

        public DataSet getItemsByComanda(int ID_COMANDA)
        {
            string QUERY = "SELECT CANTIDAD, TIPO_DETALLE, ITEM_DETALLE, VALOR, SUBTOTAL FROM CONFITERIA_COMANDA_ITEM WHERE COMANDA = " + ID_COMANDA + " ORDER BY ID DESC;";
            DataSet GET = getDataFromQuery(QUERY);
            return GET;
        }

        public bool setStock(int STOCK, int ID_PROF)
        {
            try
            {
                string QUERY = "UPDATE PROFESIONALES SET STOCK = " + STOCK + " WHERE ID = " + ID_PROF + ";";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public bool setArancel(decimal ARANCEL, int ID_PROF)
        {
            try
            {
                string QUERY = "UPDATE ARANCELES SET ARANCEL = " + ARANCEL + " WHERE PROFESIONAL = " + ID_PROF + " AND FE_BAJA IS NULL;";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public bool getTieneDescuento(int TIPO_COMANDA)
        {
            bool RESULTADO = false;
            int DESC = 0;

            string QUERY = "SELECT DESCUENTO FROM CONFITERIA_TIPO_COMANDA WHERE ID = " + TIPO_COMANDA + ";";
            DataSet GET = getDataFromQuery(QUERY);

            if (GET.Tables.Count > 0)
            {
                foreach (DataRow ROW in GET.Tables[0].Rows)
                {
                     DESC = Convert.ToInt32(ROW[0]);
                }
            }

            if (DESC > 0)
                RESULTADO = true;

            return RESULTADO;
        }

        public int getGeneratorValue(string GENERATOR)
        {
            int VALUE = 0;
            string QUERY = "SELECT NEXT VALUE FOR " + GENERATOR + " FROM RDB$DATABASE;";
            DataSet GET = getDataFromQuery(QUERY);

            if (GET.Tables.Count > 0)
            {
                foreach (DataRow ROW in GET.Tables[0].Rows)
                {
                    VALUE = Convert.ToInt32(ROW[0]);
                }
            }

            return VALUE;
        }

        public bool setGeneratorValue(string GENERATOR, int VALUE)
        {
            try
            {
                string QUERY = "SET GENERATOR " + GENERATOR + " TO " + VALUE + ";";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public bool setIdAnteriorComanda(string ROL)
        {
            try
            {
                string QUERY = "UPDATE CONFITERIA_COMANDAS SET ID_ANTERIOR = ID WHERE EXPORTADA = 0 AND ROL = '" + ROL + "';";
                db.Ejecuto_Consulta_Remota(QUERY, ROL);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public bool setIdAnteriorCaja(string ROL)
        {
            try
            {
                string QUERY = "UPDATE CONFITERIA_CAJA_DIARIA SET ID_ANTERIOR = ID WHERE EXPORTADA = 0 AND ROL = '" + ROL + "';";
                db.Ejecuto_Consulta_Remota(QUERY, ROL);
                return true;
            }
            catch (Exception error)
            {
                return false;
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

        public bool setItemStock(int ID_PROFESIONAL, int STOCK)
        {
            try
            {
                string QUERY = "UPDATE PROFESIONALES SET STOCK = " + STOCK + " WHERE ID = " + ID_PROFESIONAL + ";";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public int getItemStock(int ID_PROFESIONAL)
        {
            int STOCK = 0;
            string QUERY = "SELECT STOCK FROM PROFESIONALES WHERE ID = " + ID_PROFESIONAL + ";";
            DataSet GET = getDataFromQuery(QUERY);

            try
            {
                if (GET.Tables.Count > 0)
                {
                    foreach (DataRow ROW in GET.Tables[0].Rows)
                    {
                        STOCK = Convert.ToInt32(ROW[0]);
                    }
                }

                return STOCK;
            }
            catch (Exception error)
            {
                return STOCK;
            }
        }

        public int getStockFinal(int ITEM_STOCK, int CANTIDAD, string OPER)
        {
            if (ITEM_STOCK > 0)
            {
                if(OPER == "-")
                    return ITEM_STOCK - CANTIDAD;
                else
                    return ITEM_STOCK + CANTIDAD;
            }
            else
                return 0;
        }

        public bool isStockeable(int ITEM)
        {
            bool STOCKEABLE = false;
            string QUERY = "SELECT STOCKEABLE FROM PROFESIONALES WHERE ID = " + ITEM + ";";
            DataSet GET = getDataFromQuery(QUERY);

            try
            {
                if (GET.Tables.Count > 0)
                {
                    foreach (DataRow ROW in GET.Tables[0].Rows)
                    {
                        STOCKEABLE = Convert.ToBoolean(ROW[0]);
                    }
                }

                return STOCKEABLE;
            }
            catch (Exception error)
            {
                return STOCKEABLE;
            }
        }
    }
}
