using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;

namespace SOCIOS
{
    class codDtoTitular
    {
        public string codigo (string TIT_SOC, string TIT_DEP)
        {
            bo dlog = new bo();
            string query = "SELECT COD_DTO FROM TITULAR WHERE NRO_SOC = " + TIT_SOC + " AND NRO_DEP = " + TIT_DEP;
            DataRow[] foundRows;
            string COD;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                COD = foundRows[0][0].ToString();
            }
            else
            {
                COD = "XXX";
            }

            return COD;
        }
    }
}
