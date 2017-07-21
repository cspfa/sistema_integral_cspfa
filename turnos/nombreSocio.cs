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
    class nombreSocio
    {
        bo dlog = new bo();

        public string nombre(int ID_SOCIO)
        {
            string nombre = "";

            try
            {
                string query = "SELECT APE_SOC, NOM_SOC FROM TITULAR WHERE ID_TITULAR = " + ID_SOCIO;
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();

                if (foundRows.Length > 0)
                    nombre = foundRows[0][0].ToString().Trim() + ", " + foundRows[0][1].ToString().Trim();
                else
                    nombre = "NO SE ENCONTRARON DATOS";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());  
            }

            return nombre;
        }

        public string CUITL(string CUITL)
        {
            string nombre = "";

            try
            {
                string queryTIT = "SELECT APE_SOC, NOM_SOC FROM TITULAR WHERE CUIL = '" + CUITL + "';";
                DataRow[] foundTIT;
                foundTIT = dlog.BO_EjecutoDataTable(queryTIT).Select();

                if (foundTIT.Length > 0)
                {
                    nombre = foundTIT[0][0].ToString().Trim() + ", " + foundTIT[0][1].ToString().Trim();
                }
                else
                { 
                    nombre = "NO SE ENCONTRARON DATOS";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
           
            return nombre;
        }

        public string AFILIADO(int AAR, int ACRJP2)
        {
            string nombre = "";

            try
            {
                string queryTIT = "SELECT APE_SOC, NOM_SOC FROM TITULAR WHERE AAR = " + AAR + " AND ACRJP1 = 0 AND ACRJP2=" + ACRJP2 + " AND ACRJP3 = 0";
                DataRow[] foundTIT;
                foundTIT = dlog.BO_EjecutoDataTable(queryTIT).Select();

                if (foundTIT.Length > 0)
                {
                    nombre = foundTIT[0][0].ToString().Trim() + ", " + foundTIT[0][1].ToString().Trim();
                }
                else
                {
                    nombre = "NO SE ENCONTRARON DATOS";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return nombre;
        }

        public string BENEFICIO(int PCRJP1, int PCRJP2, int PCRJP3)
        {
            string nombre = "";

            try
            {
                string queryTIT = "SELECT APE_SOC, NOM_SOC FROM TITULAR WHERE PAR= 2 AND PCRJP1=" + PCRJP1 + " AND PCRJP2=" + PCRJP2 + " AND PCRJP3=" + PCRJP3;
                DataRow[] foundTIT;
                foundTIT = dlog.BO_EjecutoDataTable(queryTIT).Select();

                if (foundTIT.Length > 0)
                {
                    nombre = foundTIT[0][0].ToString().Trim() + ", " + foundTIT[0][1].ToString().Trim();
                }
                else
                {
                    nombre = "NO SE ENCONTRARON DATOS";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return nombre;
        }

        public string[] NRO_SOC(int NRO_SOC, int NRO_DEP, string BARRA)
        {
            string[] res = {"X", "X"};

            try
            {
                if (BARRA == "X")
                {
                    //TITULARES
                    string queryTIT = "SELECT APE_SOC, NOM_SOC, CAR_TE1, NUM_TE1, E_MAIL FROM TITULAR WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP;
                    DataRow[] foundTIT;
                    foundTIT = dlog.BO_EjecutoDataTable(queryTIT).Select();

                    if (foundTIT.Length > 0)
                    {
                        res = new string[] { foundTIT[0][0].ToString().Trim(), foundTIT[0][1].ToString().Trim(), foundTIT[0][2].ToString().Trim(), foundTIT[0][3].ToString().Trim(), foundTIT[0][4].ToString().Trim() };
                    }
                    else
                    {
                        res = new string[] { "NO SE ENCONTRARON DATOS" };
                    }
                }
                else
                {
                    //ADHERENTES
                    string queryADH = "SELECT APE_ADH, NOM_ADH, CAR_TE1ADH, NUM_TE1ADH, E_MAIL FROM ADHERENT WHERE NRO_ADH = " + NRO_SOC + " AND NRO_DEPADH = " + NRO_DEP + " AND BARRA = " + BARRA;
                    DataRow[] foundADH;
                    foundADH = dlog.BO_EjecutoDataTable(queryADH).Select();

                    //FAMILIARES
                    string queryFAM = "SELECT APE_FAM, NOM_FAM, CAR_TE1FAM, NUM_TE1FAM, E_MAIL FROM FAMILIAR WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP + " AND BARRA = " + BARRA;
                    DataRow[] foundFAM;
                    foundFAM = dlog.BO_EjecutoDataTable(queryFAM).Select();

                    if (foundADH.Length > 0)
                    {
                        res = new string[] { foundADH[0][0].ToString().Trim(), foundADH[0][1].ToString().Trim(), foundADH[0][2].ToString().Trim(), foundADH[0][3].ToString().Trim(), foundADH[0][4].ToString().Trim() };
                    }
                    else if (foundFAM.Length > 0)
                    {
                        res = new string[] { foundFAM[0][0].ToString().Trim(), foundFAM[0][1].ToString().Trim(), foundFAM[0][2].ToString().Trim(), foundFAM[0][3].ToString().Trim(), foundFAM[0][4].ToString().Trim() };
                    }
                    else
                    {
                        res = new string[] { "NO SE ENCONTRARON DATOS" };
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return res;
        }

        public string DNI(int DNI)
        {
            string nombre = "";

            try
            {
                //TITULARES
                string queryTIT = "SELECT APE_SOC, NOM_SOC FROM TITULAR WHERE NUM_DOC = " + DNI;
                DataRow[] foundTIT;
                foundTIT = dlog.BO_EjecutoDataTable(queryTIT).Select();

                //ADHERENTES
                string queryADH = "SELECT APE_ADH, NOM_ADH FROM ADHERENT WHERE NUM_DOCADH = " + DNI;
                DataRow[] foundADH;
                foundADH = dlog.BO_EjecutoDataTable(queryADH).Select();

                //FAMILIARES
                string queryFAM = "SELECT APE_FAM, NOM_FAM FROM FAMILIAR WHERE NUM_DOCF = " + DNI;
                DataRow[] foundFAM;
                foundFAM = dlog.BO_EjecutoDataTable(queryFAM).Select();

                if (foundTIT.Length > 0)
                {
                    nombre = foundTIT[0][0].ToString().Trim() + ", " + foundTIT[0][1].ToString().Trim();
                }
                else if (foundADH.Length > 0)
                {
                    nombre = foundADH[0][0].ToString().Trim() + ", " + foundADH[0][1].ToString().Trim();
                }
                else if (foundFAM.Length > 0)
                {
                    nombre = foundFAM[0][0].ToString().Trim() + ", " + foundFAM[0][1].ToString().Trim();
                }
                else
                {
                    nombre = "NO SE ENCONTRARON DATOS";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
                
            return nombre;
        }

        public string TIT(int IDSOCIO)
        {
            string nombre = "";

            try
            {
                string query = "SELECT APE_SOC, NOM_SOC FROM TITULAR WHERE ID_TITULAR = " + IDSOCIO;
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();

                if (foundRows.Length > 0)
                    nombre = foundRows[0][0].ToString().Trim() + ", " + foundRows[0][1].ToString().Trim();
                else
                    nombre = "NO SE ENCONTRARON DATOS - " + IDSOCIO;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return nombre;
        }

        public string ADH(string NRO_SOC, string NRO_DEP)
        {
            string nombre = "";

            try
            {
                string query = "SELECT APE_SOC, NOM_SOC FROM TITULAR WHERE NRO_SOC = " + NRO_SOC + " AND NRO_DEP = " + NRO_DEP;
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();

                if (foundRows.Length > 0)
                    nombre = foundRows[0][0].ToString().Trim() + ", " + foundRows[0][1].ToString().Trim();
                else
                    nombre = "NO SE ENCONTRARON DATOS";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return nombre;
        }
    }
}
