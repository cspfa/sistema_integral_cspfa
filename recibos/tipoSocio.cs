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
    class tipoSocio
    {
        bo dlog = new bo();
        
        public string tipo(int ID_SOC)
        {
            string tipo = "";
            
            try
            {
                string query = "SELECT T.CAT_SOC, C.SIGN, T.COD_DTO FROM TITULAR T, CODIGOS C WHERE T.ID_TITULAR = " + ID_SOC + " AND SUBSTRING(C.CODIGO FROM 1 FOR 2) = 'CA' AND SUBSTRING(C.CODIGO FROM 4 FOR 6) = T.CAT_SOC";
                string cod_dto;
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();

                if (foundRows.Length > 0)
                {
                    cod_dto = foundRows[0][2].ToString();

                    if (cod_dto != "640" && cod_dto != "740" && cod_dto != "642" && cod_dto != "EEE" && cod_dto != "A/S" && cod_dto != "641" && cod_dto != "643" && cod_dto != "S/C")
                    {
                        tipo = foundRows[0][0].ToString().Trim() + " - " + foundRows[0][1].ToString().Trim() + " - NO SOCIO";
                    }
                    else
                    {
                        tipo = foundRows[0][0].ToString().Trim() + " - " + foundRows[0][1].ToString().Trim() + " - " + foundRows[0][2].ToString().Trim();
                    }
                }
                else
                {
                    tipo = "NO SE ENCONTRARON DATOS";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return tipo;
        }

        public string coddto_titular(int ID_SOC)
        {
            string cod_dto = string.Empty;

            try
            {
                string query = "SELECT T.COD_DTO FROM TITULAR T WHERE T.ID_TITULAR = " + ID_SOC;
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();

                if (foundRows.Length > 0)
                {
                    cod_dto = foundRows[0][0].ToString();
                }
                else
                {
                    cod_dto = "NO SE ENCONTRARON DATOS";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return cod_dto;
        }

        public string coddto_adh(int ID_SOC)
        {
            string cod_dto = string.Empty;

            try
            {
                int ID = (ID_SOC) * 100;
                string query = "SELECT A.COD_DTO FROM ADHERENT A WHERE A.ID_ADHERENTE = " + ID;
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();

                if (foundRows.Length > 0)
                {
                    cod_dto = foundRows[0][0].ToString();
                }
                else
                {
                    cod_dto = ID.ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return cod_dto;
        }
    }
}
