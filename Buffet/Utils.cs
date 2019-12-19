using System.Data;
using FirebirdSql.Data.FirebirdClient;
using System;
using SOCIOS;

namespace Buffet
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

        public bool addNroOrden(string ROLE, int VALOR)
        {
            try
            {
                string QUERY = "UPDATE CONFIG SET VALOR = " + VALOR + " WHERE PARAM = 'NRO_ORDEN' AND ROL = '" + ROLE + "';";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public bool resetNroOrden(string ROLE)
        {
            try
            {
                string QUERY = "UPDATE CONFIG SET VALOR = 0 WHERE PARAM = 'NRO_ORDEN' AND ROL = '" + ROLE + "';";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public int getNroOrden(string ROLE)
        {
            int NRO_ORDEN = 0;
            string QUERY = "SELECT VALOR FROM CONFIG WHERE PARAM = 'NRO_ORDEN' AND ROL = '" + ROLE + "';";
            DataSet GET = getDataFromQuery(QUERY);

            foreach(DataRow row in GET.Tables[0].Rows)
            {
                NRO_ORDEN = Convert.ToInt16(row[0]);
            }

            return NRO_ORDEN;
        }

        public bool updateProfEsp(int PROFESIONAL, int ESPECIALIDAD)
        {
            try
            {
                string QUERY = "UPDATE PROF_ESP SET ESPECIALIDAD = " + ESPECIALIDAD + " WHERE PROFESIONAL = " + PROFESIONAL + ";";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public bool setProfBaja(int PROFESIONAL, string BAJA)
        {
            try
            {
                string QUERY = "";

                if (BAJA == null)
                    QUERY = "UPDATE PROFESIONALES SET BAJA = NULL WHERE ID = " + PROFESIONAL + ";";
                else
                    QUERY = "UPDATE PROFESIONALES SET BAJA = '" + BAJA + "' WHERE ID = " + PROFESIONAL + ";";

                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public bool setProfesionalName(int ID, string NOMBRE)
        {
            try
            {
                string QUERY = "UPDATE PROFESIONALES SET NOMBRE = '" + NOMBRE + "' WHERE ID = " + ID + ";";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public DataSet getReservadosPorRole(string ROLE)
        {
            string QUERY = "SELECT COUNT(ID) FROM PROFESIONALES WHERE NOMBRE = 'RESERVADO' AND ROL = '" + ROLE + "';";
            DataSet GET = getDataFromQuery(QUERY);
            return GET;
        }

        public DataSet getCategoriasPorRole(string ROLE)
        {
            string QUERY = "SELECT ID, DETALLE FROM SECTACT WHERE ROL = '" + ROLE + "' ORDER BY DETALLE ASC;";
            DataSet GET = getDataFromQuery(QUERY);
            return GET;
        }

        public bool setProfEsp(int PROF, int ESP)
        {
            try
            {
                string QUERY = "INSERT INTO PROF_ESP (PROFESIONAL, ESPECIALIDAD, PROF) VALUES (" + PROF + ", " + ESP + ", " + PROF + ");";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int putNuevoItem(string NOMBRE, string BARCODE)
        {
            try
            {
                maxid mid = new maxid();
                int ID = int.Parse(mid.m("ID", "PROFESIONALES")) + 1;
                string QUERY = "INSERT INTO PROFESIONALES (ID, NOMBRE, MATRICULA, DNI, CORREO, CELULAR, TELEFONO, TIPO_CONTRATO, ROL, BONO_RECIBO, CUENTA, STOCKEABLE, BARCODE) ";
                QUERY += "VALUES (" + ID + ", '" + NOMBRE + "', 0, 0, '', 0, 0, 0, 'MENU " + VGlobales.vp_role + "', 'R', 0, 0, '" + BARCODE + "');";
                db.Ejecuto_Consulta(QUERY);
                return ID;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public DataSet getCatSocs()
        {
            string QUERY = "SELECT SUBSTRING(CODIGO FROM 4 FOR 3) AS CODE FROM CODIGOS WHERE SUBSTRING(CODIGO FROM 1 FOR 2) = 'CA' ORDER BY CODE ASC;";
            DataSet GET = getDataFromQuery(QUERY);
            return GET;
        }

        public bool setItemPrice(int ID, string PRECIO, int SECACT)
        {
            try
            {
                DataSet CAT_SOCS = getCatSocs();

                foreach(DataRow ROW in CAT_SOCS.Tables[0].Rows)
                {
                    string QUERY = "INSERT INTO ARANCELES (SECTACT, CATSOC, PROFESIONAL, ARANCEL, US_ALTA) VALUES ";
                    QUERY += "(" + SECACT + ", '" + ROW[0].ToString() + "', " + ID + ", " + PRECIO + ", '" + VGlobales.vp_username + "');";
                    db.Ejecuto_Consulta(QUERY);
                }

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool setNroOrdenComanda(string NRO_LLEGADA, string ID)
        {
            try
            {
                string QUERY = "UPDATE CONFITERIA_COMANDAS SET NRO_LLEGADA = " + NRO_LLEGADA + " WHERE ID = " + ID + ";";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string getNroOrdenComanda(string ROL)
        {
            string QUERY = "SELECT MAX(NRO_ORDEN) FROM CONFITERIA_COMANDAS WHERE ROL = '" + ROL + "';";
            DataSet GET = getDataFromQuery(QUERY);
            string RETURN = "";

            if (GET.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow ROW in GET.Tables[0].Rows)
                {
                    RETURN = Convert.ToString(ROW[0]);
                }
            }

            return RETURN;
        }

        public string getOrdenDeLlegada()
        {
            maxid mid = new maxid();
            string SECUENCIA = mid.m("SECUENCIA", "INGRESOS_A_PROCESAR");
            string QUERY = "SELECT ORDEN_LLEGADA FROM INGRESOS_A_PROCESAR WHERE SECUENCIA = " + SECUENCIA;
            DataSet GET = getDataFromQuery(QUERY);
            string RETURN = "";

            if (GET.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow ROW in GET.Tables[0].Rows)
                {
                    RETURN = Convert.ToString(ROW[0]);
                }
            }

            return RETURN;
        }

        public string getIniPrinter()
        {
            Datos_ini ini = new Datos_ini();
            return ini.Impresora;
        }

        public DataSet getItemsByCategory(int COMANDA, string GRUPO)
        {
            string QUERY = "SELECT C.ITEM, C.CANTIDAD, C.TIPO, C.VALOR, C.SUBTOTAL, C.ITEM_DETALLE, C.TIPO_DETALLE, C.ID, C.IMPRESO, C.OBSERVACIONES FROM CONFITERIA_COMANDA_ITEM C WHERE C.COMANDA = " + COMANDA + " AND TIPO_DETALLE = '" + GRUPO + "' ORDER BY C.ID ASC;";
            DataSet GET = getDataFromQuery(QUERY);
            return GET;
        }

        public string getItemName(int ITEM)
        {
            string QUERY = "SELECT NOMBRE FROM PROFESIONALES WHERE ID = " + ITEM;
            DataSet GET = getDataFromQuery(QUERY);
            string RETURN = "";

            if (GET.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow ROW in GET.Tables[0].Rows)
                {
                    RETURN = Convert.ToString(ROW[0]);
                }
            }

            return RETURN;
        }

        public string getItemBarCode(int ITEM)
        {
            string QUERY = "SELECT BARCODE FROM PROFESIONALES WHERE ID = " + ITEM + ";";
            DataSet GET = getDataFromQuery(QUERY);
            string RETURN = String.Empty;
            
            if (GET.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow ROW in GET.Tables[0].Rows)
                {
                    RETURN = Convert.ToString(ROW[0]);
                }
            }

            return RETURN;
        }

        public DataSet barCodeSearch(string BARCODE)
        {
            string ID = BARCODE.Substring(7, 6);
            ID = ID.Replace("0", "");
            string QUERY = "SELECT P.ID, PE.ESPECIALIDAD, P.NOMBRE FROM PROFESIONALES P, PROF_ESP PE WHERE P.ID = PE.PROFESIONAL AND P.ROL = 'MENU " + VGlobales.vp_role + "' AND (P.BARCODE = '" + BARCODE + "' OR P.ID = " + ID + ");";
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
            catch (Exception)
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

        public int getNextItemId(string ROL)
        {
            string QUERY = "SELECT FIRST(1) ID FROM PROFESIONALES WHERE NOMBRE = 'RESERVADO'  AND ROL = '" + ROL + "' ORDER BY ID";
            DataSet GET = getDataFromQuery(QUERY);
            int ID = 0;

            foreach (DataRow row in GET.Tables[0].Rows)
            {
                ID = int.Parse(row[0].ToString());
            }

            return ID;
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
            catch (Exception)
            {
                return false;
            }
        }

        public bool setNewItem(int ID, string NOMBRE, string CODEBAR)
        {
            try
            {
                string QUERY = "UPDATE PROFESIONALES SET NOMBRE = '" + NOMBRE + "', BARCODE = '" + CODEBAR + "'  WHERE ID = " + ID + ";";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception)
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
            catch (Exception)
            {
                return false;
            }
        }

        public bool setCcPaga(int ID_COMANDA, string FECHA)
        {
            try
            {
                string QUERY = "UPDATE CONFITERIA_COMANDAS SET CC_PAGA = '" + FECHA + "' WHERE ID = " + ID_COMANDA + ";";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool setArancel(decimal ARANCEL, int ID_PROF, int SECTACT)
        {
            try
            {
                string QUERY = "UPDATE ARANCELES SET ARANCEL = " + ARANCEL + ", SECTACT = " + SECTACT + ", CATSOC = '001' WHERE PROFESIONAL = " + ID_PROF + " AND FE_BAJA IS NULL;";
                db.Ejecuto_Consulta(QUERY);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int getTipoComanda(int ID_COMANDA)
        {
            int TIPO = 0;

            string QUERY = "SELECT TIPO_COMANDA FROM CONFITERIA_COMANDAS WHERE ID = " + ID_COMANDA + ";";
            DataSet GET = getDataFromQuery(QUERY);

            if (GET.Tables.Count > 0)
            {
                foreach (DataRow ROW in GET.Tables[0].Rows)
                {
                     TIPO = Convert.ToInt32(ROW[0]);
                }
            }

            return TIPO;
        }

        public int getFormaDePago(int ID_COMANDA)
        {
            int FP = 0;

            string QUERY = "SELECT FORMA_DE_PAGO FROM CONFITERIA_COMANDAS WHERE ID = " + ID_COMANDA + ";";
            DataSet GET = getDataFromQuery(QUERY);

            if (GET.Tables.Count > 0)
            {
                foreach (DataRow ROW in GET.Tables[0].Rows)
                {
                    FP = Convert.ToInt32(ROW[0]);
                }
            }

            return FP;
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
            {
                return STOCKEABLE;
            }
        }
    }
}
