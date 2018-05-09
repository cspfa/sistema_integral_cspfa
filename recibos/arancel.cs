using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace SOCIOS
{
    public class arancel
    {
        public decimal valorCuotaSocial(int SECTACT, int GRUPO, int PROFESIONAL, string CATSOC)
        {
            bo dlog = new bo();
            decimal arancel = 9999;
            string query = "SELECT A.ARANCEL FROM ARANCELES A, GRUPOS_CATEGORIAS C WHERE A.PROFESIONAL = " + PROFESIONAL + " AND A.SECTACT = " + SECTACT + " AND C.GRUPO = " + GRUPO + " AND C.CAT_SOC = A.CATSOC AND A.CATSOC = '" + CATSOC + "' AND A.FE_BAJA IS NULL;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                arancel = Convert.ToDecimal(foundRows[0][0]);
            }

            return arancel;
        }

        public decimal valorGrupo(int SECTACT, int GRUPO, int PROFESIONAL)
        {
            bo dlog = new bo();
            decimal arancel = 0;
            string query = "SELECT FIRST(1) A.ARANCEL FROM ARANCELES A, GRUPOS_CATEGORIAS C WHERE A.PROFESIONAL = " + PROFESIONAL + " AND A.SECTACT = " + SECTACT + " AND C.GRUPO = " + GRUPO + " AND C.CAT_SOC = A.CATSOC AND A.FE_BAJA IS NULL;";
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                arancel = Convert.ToDecimal(foundRows[0][0]);
            }

            return arancel;
        }
        
        public string[] valor(int SECTACT, string CAT_SOC, int PROFESIONAL, string COD_DTO)
        {
            bo dlog = new bo();

            if (CAT_SOC == "00Z")
            {
                CAT_SOC = "005";
            }

            if (COD_DTO == "0" || COD_DTO == "000" || COD_DTO == "PNS" || COD_DTO == "")
            {
                if (CAT_SOC != "008")
                {
                    CAT_SOC = "005";
                }
            }
        
            string query = "SELECT ARANCEL, ID FROM ARANCELES_SERVICIOS WHERE SECTACT = " + SECTACT + " AND CATSOC = " + CAT_SOC + " AND PROFESIONAL = " + PROFESIONAL + ";";

            string[] valor;

            DataRow[] foundRows;
            
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                valor = new string[] { foundRows[0][0].ToString().Trim(), foundRows[0][1].ToString().Trim() };
            }
            else
            {
                valor = new string[] { "X", "X" };
            }

            return valor;
        }

        public string[] valorABM(int SECTACT, string CAT_SOC, int PROFESIONAL)
        {
            bo dlog = new bo();

            string query = "SELECT ARANCEL, ID FROM ARANCELES_SERVICIOS WHERE SECTACT = " + SECTACT + " AND CATSOC = " + CAT_SOC + " AND PROFESIONAL = " + PROFESIONAL + ";";

            string[] valor;

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                valor = new string[] { foundRows[0][0].ToString().Trim(), foundRows[0][1].ToString().Trim() };
            }
            else
            {
                valor = new string[] { "X", "X" };
            }

            return valor;
        }

        public decimal valorGrupoHotel(int HOTEL, int GRUPO, int REGIMEN, int HABITACION)
        {
            bo dlog = new bo();
            // HOTEL = SECTACT , REGIMEN Y HABITACION
            decimal arancel = 9999;

            string query = "SELECT FIRST(1) A.ARANCEL FROM ARANCELES A, GRUPOS_CATEGORIAS C WHERE  A.SECTACT = " + HOTEL + " AND C.GRUPO = " + GRUPO + " AND C.CAT_SOC = A.CATSOC AND REGIMEN=" + REGIMEN + " AND HABITACION=" + HABITACION + "  and A.FE_BAJA is null ";

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                arancel = Convert.ToDecimal(foundRows[0][0]);
            }

            return arancel;
        }
    }
}
