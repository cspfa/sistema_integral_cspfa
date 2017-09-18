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
        public int CALCULAR(string FECHA)
        {
            string fecha_nacimiento = FECHA;
            DateTime dt_fecha_nacimiento = Convert.ToDateTime(fecha_nacimiento);
            int anio_nacimiento = dt_fecha_nacimiento.Year;
            int anio_actual = DateTime.Now.Year;
            int dif_anios = anio_actual - anio_nacimiento;
            DateTime cumple_anios = dt_fecha_nacimiento.AddYears(dif_anios);

            if (DateTime.Now.CompareTo(cumple_anios) < 0)
            {
                dif_anios--;
            }

            return dif_anios;
        }

        public int CALCULAR_VITALICIO(string ALTVI)
        {
            int edad = 0;

            if (ALTVI != "")
            {
                DateTime today = Convert.ToDateTime("07/03/" + DateTime.Today.Year);
                DateTime bday = Convert.ToDateTime(ALTVI);
                edad = today.Year - bday.Year;
            }

            return edad;
        }
        
        public int VITALICIO_ORO(int ID_TITULAR)
        {
            bo dlog = new bo();
            string query = "SELECT F_ALTVI FROM TITULAR WHERE ID_TITULAR = " + ID_TITULAR;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();
            int dif_anios = 0;

            if (foundRows.Length > 0)
            {
                dif_anios = CALCULAR_VITALICIO(foundRows[0][0].ToString());
            }
            else
            {
                dif_anios = 9999;
            }

            return dif_anios;
        }
        
        public int FAMILIAR(int ID_TITULAR, string BARRA)
        {
            bo dlog = new bo();
            string query = "SELECT F_NACFAM FROM FAMILIAR WHERE ID_TITULAR = " + ID_TITULAR + " AND BARRA = " + BARRA;
            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();
            int dif_anios = 0;

            if (foundRows.Length > 0)
            {
                if (foundRows[0][0].ToString().Length >0)
                dif_anios = CALCULAR(foundRows[0][0].ToString());
            }
            else
            {
                dif_anios = 9999;
            }

            return dif_anios;
        }
    }
}
