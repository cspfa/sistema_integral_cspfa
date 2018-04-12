using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Collections;
using FirebirdSql.Data.Firebird;



namespace SOCIOS.TEST
{ 
   public class conString 
       {
       }

}

namespace SOCIOS
{

    
    public class conString
    {
        public string get()
        {
            string connectionString = string.Empty;
            Datos_ini ini2 = new Datos_ini();
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini2.Servidor;
            cs.Port = int.Parse(ini2.Puerto);
            cs.Database = ini2.Ubicacion;
            cs.UserID = VGlobales.vp_username;
            cs.Password = VGlobales.vp_password;
            cs.Role = VGlobales.vp_role;
            cs.Dialect = 3;
            connectionString = cs.ToString();
            return connectionString;
        }

        public string getRemota(string ROL)
        {   
            string connectionString = string.Empty;
            Datos_ini ini2 = new Datos_ini();
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            
            if (ROL == "CPOCABA")
            {
                cs.DataSource = ini2.Servidor_Delfo;
                cs.Database = ini2.Ubicacion_Delfo;
            }

            if (ROL == "CPOPOLVORINES")
            {
                cs.DataSource = ini2.Servidor_Belgrano;
                cs.Database = ini2.Ubicacion_Belgrano;
            }

            cs.Port = int.Parse(ini2.Puerto);
            cs.UserID = VGlobales.vp_username;
            cs.Password = VGlobales.vp_password;
            cs.Role = VGlobales.vp_role;
            cs.Dialect = 3;
            connectionString = cs.ToString();
            return connectionString;
        }
    }
}
