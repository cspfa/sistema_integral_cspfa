using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SOCIOS
{
    public class actSociosUpdate
    {
        public string actualizar()
        {
            string RESPONSE = "";
            string PATH_LAN = @"\\192.168.1.6\updates\socios_update.exe";
            string PATH_LOCAL = @"C:\CSPFA_SOCIOS\socios_update.exe";

            if (File.Exists(PATH_LAN))
            {
                DateTime DT_LAN = File.GetLastWriteTime(PATH_LAN);
                DateTime DT_LOCAL = File.GetLastWriteTime(PATH_LOCAL);

                if (DT_LOCAL < DT_LAN)
                {
                    try
                    {
                        File.Copy(PATH_LAN, PATH_LOCAL, true);
                        RESPONSE = "ACTUALIZADOR COPIADO";
                    }
                    catch
                    {
                        RESPONSE = "NO SE PUDO ACTUALIZAR";
                    }
                }
            }

            return RESPONSE;
        }
    }
}
