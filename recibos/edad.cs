using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Firebird;

namespace SOCIOS
{
    class edad
    {
        bo dlog = new bo();

        public int CALCULAR(string FECHA)
        {
            int dif_anios = 0;

            try
            {
                string fecha_nacimiento = FECHA;
                DateTime dt_fecha_nacimiento = Convert.ToDateTime(fecha_nacimiento);
                int anio_nacimiento = dt_fecha_nacimiento.Year;
                int anio_actual = DateTime.Now.Year;
                dif_anios = anio_actual - anio_nacimiento;
                DateTime cumple_anios = dt_fecha_nacimiento.AddYears(dif_anios);

                if (DateTime.Now.CompareTo(cumple_anios) < 0)
                {
                    dif_anios--;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return dif_anios;
        }

        public int CALCULAR_VITALICIO(string ALTVI)
        {
            int edad = 0;

            try
            {
                if (ALTVI != "")
                {
                    DateTime today = Convert.ToDateTime("07/03/" + DateTime.Today.Year);
                    DateTime bday = Convert.ToDateTime(ALTVI);
                    edad = today.Year - bday.Year;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return edad;
        }
        
        public int VITALICIO_ORO(int ID_TITULAR)
        {
            int dif_anios = 0;

            try
            {
                string query = "SELECT F_ALTVI FROM TITULAR WHERE ID_TITULAR = " + ID_TITULAR;
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();

                if (foundRows.Length > 0)
                {
                    dif_anios = CALCULAR_VITALICIO(foundRows[0][0].ToString());
                }
                else
                {
                    dif_anios = 9999;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return dif_anios;
        }
        
        public int FAMILIAR(int ID_TITULAR, string BARRA)
        {
            int dif_anios = 0;

            try
            {
                string query = "SELECT F_NACFAM FROM FAMILIAR WHERE ID_TITULAR = " + ID_TITULAR + " AND BARRA = " + BARRA;
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();

                if (foundRows.Length > 0)
                {
                    dif_anios = CALCULAR(foundRows[0][0].ToString());
                }
                else
                {
                    dif_anios = 9999;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return dif_anios;
        }
    }
}
