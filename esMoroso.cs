using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using FirebirdSql.Data.FirebirdClient;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Mails;
using SOCIOS;

namespace SOCIOS
{
    class esMoroso
    {
        //public string vdatabase;

        //public string vdatasource;

        //bo dlog = new bo();

        BO_Datos dlog = new BO_Datos();

        public bool cuota(string ACRJP2)
        {
            string query = "SELECT COUNT(AFIL) AS MOROSO FROM MOROSOS WHERE AFIL = " + ACRJP2 + ";";

            DataRow[] foundRows;
            
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                if (foundRows[0][0].ToString() == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public bool deportes(string DNI)
        {
            string query = "SELECT COUNT(DNI) AS MOROSO FROM MOROSOS_DEPORTES WHERE DNI = " + DNI + ";";

            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                if (foundRows[0][0].ToString() == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
