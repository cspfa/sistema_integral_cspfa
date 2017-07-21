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
    class obrasocial
    {
        public string nroObraSocial(int NRO_SOC, int NRO_DEP, string BARRA)
        {
            bo dlog = new bo();
            string nro = "";

            if (BARRA == "X")
            {
                //TITULARES
                string queryTIT = "SELECT OBRA_SOCIAL FROM TITULAR WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP;
                DataRow[] foundTIT;
                foundTIT = dlog.BO_EjecutoDataTable(queryTIT).Select();

                if (foundTIT.Length > 0)
                {
                    nro = foundTIT[0][0].ToString().Trim();
                }
                else
                {
                    nro = "NO SE ENCONTRARON DATOS";
                }
            }
            else
            {
                //ADHERENTES
                string queryADH = "SELECT OBRA_SOCIAL FROM ADHERENT WHERE NRO_ADH = " + NRO_SOC + " AND NRO_DEPADH = " + NRO_DEP + " AND BARRA = " + BARRA;
                DataRow[] foundADH;
                foundADH = dlog.BO_EjecutoDataTable(queryADH).Select();

                //FAMILIARES
                string queryFAM = "SELECT OBRA_SOCIAL FROM FAMILIAR WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = " + BARRA;
                DataRow[] foundFAM;
                foundFAM = dlog.BO_EjecutoDataTable(queryFAM).Select();

                if (foundADH.Length > 0)
                {
                    nro = foundADH[0][0].ToString().Trim();
                }
                else if (foundFAM.Length > 0)
                {
                    nro = foundFAM[0][0].ToString().Trim();
                }
                else
                {
                    nro = "NO SE ENCONTRARON DATOS";
                }
            }

            return nro;
        }
    }
}
