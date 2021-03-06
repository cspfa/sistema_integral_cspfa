﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace SOCIOS
{
    class numeroRecibo
    {
        bo dlog = new bo();

                     
        public string obtener(string ROL)
        { 
            string NRO_RECIBO = "0";

            try
            {
                string QUERY = "SELECT FIRST 1 R.ID FROM RECIBOS_CAJA R, RECIBOS_DESTINOS D WHERE R.DESTINO = D.ID AND D.ROLLING = '" + ROL + "' AND R.USUARIO_MOD = 'BLANCO';";
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

                if (foundRows.Length > 0)
                {
                    NRO_RECIBO = foundRows[0][0].ToString();
                }
                else
                {
                    NRO_RECIBO = "NO HAY RECIBOS DISPONIBLES";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return NRO_RECIBO;
        }

        public int obtenerCuenta(string PTO_VTA)
        {
            int CUENTA = 301101;

            try
            {
                string QUERY = "SELECT CUENTA FROM PUNTOS_DE_VENTA WHERE PTO_VTA = '" + PTO_VTA + "';";
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

                if (foundRows.Length > 0)
                {
                    CUENTA = int.Parse(foundRows[0][0].ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            
            return CUENTA;
        }

        public int obtenerNroComprobante(string COMPROBANTE, string PTO_VTA)
        {
            int NRO_COMP = 0;

            try
            {
                string QUERY = "";
                string CAMPO = "";

                if (COMPROBANTE == "RECIBO")
                {
                    CAMPO = "NUM_RECIBO";
                }

                if (COMPROBANTE == "BONO")
                {
                    CAMPO = "NUM_BONO";
                }

                QUERY = "SELECT " + CAMPO + " FROM PUNTOS_DE_VENTA WHERE PTO_VTA = '" + PTO_VTA + "';";
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
                int dif_anios = 0;

                if (foundRows.Length > 0)
                {
                    NRO_COMP = int.Parse(foundRows[0][0].ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return NRO_COMP;
        }

        public string obtenerPuntoDeVenta(string ROL)
        {
            string PTO_VTA = "000";

            try
            {
                string QUERY = "SELECT PTO_VTA FROM PUNTOS_DE_VENTA WHERE ROL = 'PUNTO_VENTA' AND ROL = '" + VGlobales.vp_role + "';";
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
                int dif_anios = 0;

                if (foundRows.Length > 0)
                {
                    PTO_VTA = foundRows[0][0].ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return PTO_VTA;
        }

        public string comprobanteVacio(int NRO_COMP, string PTO_VTA, string TABLA)
        {
            string query = "SELECT USUARIO_MOD FROM " + TABLA + " WHERE NRO_COMP = " + NRO_COMP + " AND PTO_VTA = '" + PTO_VTA + "' AND CUENTA_DEBE IS NULL;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
                return foundRows[0][0].ToString();
            else
                return "USADO";
        }

        public int obtenerNumeracionReservada(string PTO_VTA, string TABLA)
        {
            int NRO_COMP = 0;
            string FOUND = "";
            string QUERY = "SELECT MIN(NRO_COMP) AS NUMERO FROM " + TABLA + " WHERE PTO_VTA = '" + PTO_VTA + "' AND CUENTA_DEBE IS NULL AND USUARIO_MOD = 'RESERVADO';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                FOUND = foundRows[0][0].ToString();

                if (FOUND != "")
                    NRO_COMP = int.Parse(FOUND);
                else
                    NRO_COMP = 0;
            }

            return NRO_COMP;
        }

        public int obtenerIdReservado(string PTO_VTA, string TABLA, int NRO_COMP)
        {
            int ID = 0;
            string QUERY = "SELECT ID FROM " + TABLA + " WHERE PTO_VTA = '" + PTO_VTA + "' AND NRO_COMP = " + NRO_COMP + " AND CUENTA_DEBE IS NULL AND USUARIO_MOD = 'RESERVADO';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                ID = int.Parse(foundRows[0][0].ToString());
            }

            return ID;
        }

        public string obtenerObservacion(int ID)
        {
            string OBSERVACION = "";
            string QUERY = "SELECT OBSERVACIONES FROM RECIBOS_CAJA WHERE ID = " + ID + ";";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                OBSERVACION = foundRows[0][0].ToString();
            }

            return OBSERVACION;
        }

        public string obtenerPtoVtaOficial(string ROL)
        {
            string PTO_VTA_O = "";
            string QUERY = "SELECT PTO_VTA FROM PUNTOS_DE_VENTA WHERE ROL = '" + ROL + "' AND ACCION = 'O';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                PTO_VTA_O = foundRows[0][0].ToString();
            }

            return PTO_VTA_O;
        }

        public string obtenerRole(string PTO_VTA_INTERNO)
        {
            string ROLE = "";
            string QUERY = "SELECT ROL FROM PUNTOS_DE_VENTA WHERE PTO_VTA = '" + PTO_VTA_INTERNO + "';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                ROLE = foundRows[0][0].ToString();
            }

            return ROLE.Trim();
        }

        public String obtenerCaePorRecibo(string PTO_VTA_E,int NRO_E)
        {
            string CAE = "";
            string QUERY = "SELECT CAE FROM RECIBOS_CAJA WHERE NUMERO_E = '" + NRO_E +  "' AND PTO_VTA_E= "+ PTO_VTA_E  + " ;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                CAE = foundRows[0][0].ToString();
            }

            return CAE.Trim();
        }


        public String obtenerCaePorNC(string PTO_VTA_E, int NRO_NC_E)
        {
            string CAE = "";
            string QUERY = "SELECT CAE_NC FROM RECIBOS_CAJA WHERE NUMERO_NC_E = '" + NRO_NC_E + "' AND PTO_VTA_E= " + PTO_VTA_E + " ;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                CAE = foundRows[0][0].ToString();
            }

            return CAE.Trim();
        }

        public int obtenerIdComprobante(string TIPO, string PTO_VTA, int NRO_COMP)
        {
            int ID = 0;
            string QUERY = "";
            string TABLA = "";

            if (TIPO == "RECIBO")
                TABLA = "RECIBOS_CAJA";

            if (TIPO == "BONO")
                TABLA = "BONOS_CAJA";

            QUERY = "SELECT ID FROM " + TABLA + " WHERE PTO_VTA = '" + PTO_VTA + "' AND NRO_COMP = " + NRO_COMP + ";";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
                ID = int.Parse(foundRows[0][0].ToString());

            return ID;
        }

        public DataRow[] obtenerPuntosPorRole(string ROLE)
        {
            string QUERY = "SELECT PTO_VTA FROM PUNTOS_DE_VENTA WHERE ROL = '" + ROLE + "';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            return foundRows;
        }

        public bool existeReciboC(string PTO_VTA, string NRO_RECIBO)
        {
            bool EXISTE = true;
            string QUERY = "SELECT ID FROM RECIBOS_CAJA WHERE PTO_VTA_E = '" + PTO_VTA + "' AND NUMERO_E = '" + NRO_RECIBO + "';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length == 0)
                EXISTE = false;

            return EXISTE;
        }

        public string obnenerCondicionPorCuit(string CUIT)
        {
            string CONDICION = "";
            string QUERY = "SELECT C.DETALLE FROM CONDICIONES_IVA C, TITULAR T WHERE T.NUM_DOC = " + CUIT + " AND T.COND_IVA = C.ID;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
                CONDICION = foundRows[0][0].ToString();

            return CONDICION;
        }

        public string obtAccionPorPtoVta(string PTO_VTA)
        {
            string ACCION = "";
            string QUERY = "SELECT ACCION FROM PUNTOS_DE_VENTA WHERE PTO_VTA = '" + PTO_VTA + "';";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
                ACCION = foundRows[0][0].ToString();

            return ACCION;
        }
    }
}
