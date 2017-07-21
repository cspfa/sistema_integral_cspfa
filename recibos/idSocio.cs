using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SOCIOS
{
    class idSocio
    {
        public string dni(string DNI)
        {
            bo dlog = new bo();

            string query = "SELECT ID_TITULAR FROM TITULAR WHERE NUM_DOC = " + DNI + ";";
            string res;

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
                res = foundRows[0][0].ToString().Trim();
            else
                res = "NO SE ENCONTRARON DATOS";

            return res;
        }

        public string cuil(string CUIL)
        {
            bo dlog = new bo();

            string query = "SELECT ID_TITULAR FROM TITULAR WHERE CUIL = '" + CUIL + "';";
            string res;

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
                res = foundRows[0][0].ToString().Trim();
            else
                res = "NO SE ENCONTRARON DATOS";

            return res;
        }

        public string afiliado(string AAR, string ACRJP2)
        {
            bo dlog = new bo();

            string query = "SELECT ID_TITULAR FROM TITULAR WHERE AAR = " + AAR + " AND ACRJP2 = " + ACRJP2 + " AND ACRJP1 = 0 AND ACRJP3 = 0;";
            string res;

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
                res = foundRows[0][0].ToString().Trim();
            else
                res = "NO SE ENCONTRARON DATOS";

            return res;
        }

        public string beneficio(string PCRJP1, string PCRJP2, string PCRJP3)
        {
            bo dlog = new bo();

            string query = "SELECT ID_TITULAR FROM TITULAR WHERE PAR = 2 AND PCRJP1 = " + PCRJP1 + " AND PCRJP2 = " + PCRJP2 + " AND PCRJP3 = " + PCRJP3 + ";";
            string res;

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
                res = foundRows[0][0].ToString().Trim();
            else
                res = "NO SE ENCONTRARON DATOS";

            return res;
        }
    }
}
