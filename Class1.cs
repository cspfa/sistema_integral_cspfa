using System;
using FirebirdSql.Data.FirebirdClient;
using System.Data.OleDb;
using System.IO;
using System.Globalization;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;                   // Para Image
using System.Drawing.Imaging;           // Para trabajar con imágenes
using System.Drawing.Drawing2D;         // Para trabajar con Imágenes
using System.Runtime.InteropServices;   // Para usar API
using System.Security.Cryptography;     // Para encriptar y desencriptar
using System.Data;


namespace SOCIOS
{

    public sealed class Botonera: System.Object
    {
        private string connectionString;
        private static readonly object padlock = new object();

        public FbDataReader Lleno_Datos(string comando, int p1, int p2)
        {
            Datos_ini ini2 = new Datos_ini();

            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini2.Servidor;  cs.Port = int.Parse(ini2.Puerto);
            cs.Database = ini2.Ubicacion;
            cs.UserID = VGlobales.vp_username;
            cs.Password = VGlobales.vp_password;
            cs.Role = VGlobales.vp_role;
            cs.Dialect = 3;
            connectionString = cs.ToString();
            FbConnection connection = new FbConnection(connectionString);

            connection.Open();
            FbTransaction transaction = connection.BeginTransaction();

            FbCommand cmd = new FbCommand(comando, connection, transaction);

            cmd.Parameters.Add(new FbParameter("@VNRO_SOC", FbDbType.Integer));
            cmd.Parameters.Add(new FbParameter("@VNRO_DEP", FbDbType.Integer));
            cmd.Parameters.Add(new FbParameter("@VTIPO", FbDbType.Char));

            cmd.Parameters["@VNRO_SOC"].Value = p1;
            cmd.Parameters["@VNRO_DEP"].Value = p2;

            FbDataReader reader = cmd.ExecuteReader();

            reader.Read();

            connection.Close();

            return (reader);
        }

        public static Botonera Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                            instance = new Botonera();
                    }
                }

                return instance;
            }
        }
        private static volatile Botonera instance = null;

    }

    public class Datos_ini
    {
        public string Servidor;
        public string Ubicacion;
        public string Puerto;
        public string Vpassword;
        public string Vcarnet_familiar;
        public string Vcarnet_titular;
        public string Vcarnet_adherente;
        public string Vcarnet_adh_interfuerza;
        public string Vcarnet_adh_interfuerza_adh;
        public string Vcarnet_adh_interfuerza_adh_vto;
        public string Vcarnet_adh_interfuerza_fam;
        public string Vcarnet_adh_interfuerza_cad;
        public string Vcarnet_vitalicio;
        public string Vcarnet_cadete;
        public string Vcarnet_adh_menor;
        public string Vcarnet_invitado;
        public string Vcarnet_socio_invitado;
        public string Vcarnet_socio_invitado_vto;
        public string Vcarnet_socio_empleado;
        public string vp_FecTope;
        public string Vcarnet_metro;
        public string Servidor_Delfo;
        public string Ubicacion_Delfo;
        public string Servidor_Belgrano;
        public string Ubicacion_Belgrano;

        public Datos_ini()
        {
            IniReader ini = new IniReader("C:\\CSPFA_SOCIOS\\_EXENET.INI");
            ini.Section = "BASE";
            Servidor = ini.ReadString("SERVER");
            Ubicacion = ini.ReadString("UBICACION");
            Puerto = ini.ReadString("PUERTO");
            Vpassword = ini.ReadString("PASSWORD");
            Vcarnet_familiar = ini.ReadString("CARNET_FAMILIAR");
            Vcarnet_titular = ini.ReadString("CARNET_TITULAR");
            Vcarnet_adherente = ini.ReadString("CARNET_ADHERENTE");
            Vcarnet_vitalicio = ini.ReadString("CARNET_VITALICIO");
            Vcarnet_cadete = ini.ReadString("CARNET_CADETE");
            Vcarnet_adh_menor = ini.ReadString("CARNET_ADH_MENOR");
            Vcarnet_invitado = ini.ReadString("CARNET_INVITADO");
            Vcarnet_socio_invitado = ini.ReadString("CARNET_SOCIO_INVITADO");
            Vcarnet_socio_invitado_vto = ini.ReadString("CARNET_SOCIO_INVITADO_VTO");
            Vcarnet_socio_empleado = ini.ReadString("CARNET_SOCIO_EMPLEADO");
            Vcarnet_metro = ini.ReadString("CARNET_METRO");
            Vcarnet_adh_interfuerza = ini.ReadString("CARNET_ADH_INTERFUERZA");
            Vcarnet_adh_interfuerza_adh = ini.ReadString("CARNET_ADH_INTERFUERZA_ADH");
            Vcarnet_adh_interfuerza_adh_vto = ini.ReadString("CARNET_ADH_INTERFUERZA_ADH_VTO");
            Vcarnet_adh_interfuerza_fam = ini.ReadString("CARNET_ADH_INTERFUERZA_FAM");
            Vcarnet_adh_interfuerza_cad = ini.ReadString("CARNET_ADH_INTERFUERZA_CAD");
            VGlobales.v_fechatope = ini.ReadString("FECHA_TOPE");
            Servidor_Delfo = ini.ReadString("DELFO_TEST");
            Ubicacion_Delfo = ini.ReadString("UBICACION_DELFO");
            Servidor_Belgrano = ini.ReadString("BELGRANO_TEST");
            Ubicacion_Belgrano = ini.ReadString("UBICACION_BELGRANO");
        }
    }

    // ************** LEER Y GRABAR ARCHIVOS .INI ************** //
    public class IniReader : System.Object
    {
        public IniReader(string file)
        {
            Filename = file;
        }

        private const int MAX_ENTRY = 32768;
        private string m_Filename;
        private string m_Section;

        public bool DeleteKey(string key)
        {
            return (WritePrivateProfileString(Section, key, null, Filename) != 0);
        }

        public bool DeleteKey(string section, string key)
        {
            return (WritePrivateProfileString(section, key, null, Filename) != 0);
        }

        public bool DeleteSection(string section)
        {
            return WritePrivateProfileSection(section, null, Filename) != 0;
        }

        public ArrayList GetSectionNames()
        {
            try
            {
                byte[] buffer = new byte[MAX_ENTRY];
                GetPrivateProfileSectionNames(buffer, MAX_ENTRY, Filename);
                string[] parts = Encoding.ASCII.GetString(buffer).Trim('\0').Split('\0');
                return new ArrayList(parts);
            }
            catch { }
            return null;
        }

        public bool ReadBoolean(string key)
        {
            return ReadBoolean(Section, key);
        }

        public bool ReadBoolean(string key, bool defVal)
        {
            return ReadBoolean(Section, key, defVal);
        }

        public bool ReadBoolean(string section, string key)
        {
            return ReadBoolean(section, key, false);
        }

        public bool ReadBoolean(string section, string key, bool defVal)
        {
            return Boolean.Parse(ReadString(section, key, defVal.ToString()));
        }

        public byte[] ReadByteArray(string key)
        {
            return ReadByteArray(Section, key);
        }

        public byte[] ReadByteArray(string section, string key)
        {
            try
            {
                return Convert.FromBase64String(ReadString(section, key));
            }
            catch { }
            return null;
        }

        public int ReadInteger(string key)
        {
            return ReadInteger(key, 0);
        }

        public int ReadInteger(string key, int defVal)
        {
            return ReadInteger(Section, key, defVal);
        }

        public int ReadInteger(string section, string key)
        {
            return ReadInteger(section, key, 0);
        }

        public int ReadInteger(string section, string key, int defVal)
        {
            return GetPrivateProfileInt(section, key, defVal, Filename);
        }

        public long ReadLong(string key)
        {
            return ReadLong(key, 0);
        }

        public long ReadLong(string key, long defVal)
        {
            return ReadLong(Section, key, defVal);
        }

        public long ReadLong(string section, string key)
        {
            return ReadLong(section, key, 0);
        }

        public long ReadLong(string section, string key, long defVal)
        {
            return long.Parse(ReadString(section, key, defVal.ToString()));
        }

        public string ReadString(string key)
        {
            return ReadString(Section, key);
        }

        public string ReadString(string section, string key)
        {
            return ReadString(section, key, "");
        }

        public string ReadString(string section, string key, string defVal)
        {
            StringBuilder sb = new StringBuilder(MAX_ENTRY);
            int Ret = GetPrivateProfileString(section, key, defVal, sb, MAX_ENTRY, Filename);
            return sb.ToString();
        }

        public bool Write(string key, bool value)
        {
            return Write(Section, key, value);
        }

        public bool Write(string key, int value)
        {
            return Write(Section, key, value);
        }

        public bool Write(string key, long value)
        {
            return Write(Section, key, value);
        }

        public bool Write(string key, string value)
        {
            return Write(Section, key, value);
        }

        public bool Write(string section, string key, bool value)
        {
            return Write(section, key, value.ToString());
        }

        public bool Write(string section, string key, int value)
        {
            return Write(section, key, value.ToString());
        }

        public bool Write(string section, string key, long value)
        {
            return Write(section, key, value.ToString());
        }

        public bool Write(string section, string key, string value)
        {
            return (WritePrivateProfileString(section, key, value, Filename) != 0);
        }

        public bool Write(string section, string key, byte[] value)
        {
            if (value == null)
                return Write(section, key, (string)null);
            else
                return Write(section, key, value, 0, value.Length);
        }

        public bool Write(string section, string key, byte[] value, int offset, int length)
        {
            if (value == null)
                return Write(section, key, (string)null);
            else
                return Write(section, key, Convert.ToBase64String(value, offset, length));
        }

        public bool Write(string key, byte[] value)
        {
            return Write(Section, key, value);
        }

        [DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileIntA", CharSet = CharSet.Ansi)]
        private static extern int GetPrivateProfileInt(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName);

        [DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileSectionNamesA", CharSet = CharSet.Ansi)]
        private static extern int GetPrivateProfileSectionNames(byte[] lpszReturnBuffer, int nSize, string lpFileName);

        [DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileStringA", CharSet = CharSet.Ansi)]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder
    lpReturnedString, int nSize, string lpFileName);

        [DllImport("KERNEL32.DLL", EntryPoint = "WritePrivateProfileSectionA", CharSet = CharSet.Ansi)]
        private static extern int WritePrivateProfileSection(string lpAppName, string lpString, string lpFileName);

        [DllImport("KERNEL32.DLL", EntryPoint = "WritePrivateProfileStringA", CharSet = CharSet.Ansi)]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string
    lpFileName);

        public string Filename
        {
            get
            {
                return m_Filename;
            }
            set
            {
                m_Filename = value;
            }
        }

        public string Section
        {
            get
            {
                return m_Section;
            }
            set
            {
                m_Section = value;
            }
        }
    }
    // ************** FIN LEER Y GRABAR ARCHIVOS .INI ************** //

    public class Fechauser
    {
        public string miPropiedad;
        
        public string MiPropiedad
        {
            get
            {
                return miPropiedad;
            }
            set
            {
                miPropiedad = value;
            }
        }
    }

   
    public static class VGlobales
    {
        public static string vp_Titular_Soc;
        public static string vp_Titular_Dep;
        public static string vp_nuevo_socio = "NO";
        public static int CANTIDAD = 0;
        public static int NUM_DOC;
        public static string vp_username;
        public static string vp_password;
        public static string vp_role;
        public static string vp_timestamp;
        public static bool vp_ntp;
        public static string vp_boton_alta;
        public static string vp_boton_modi;
        public static string vp_cod_bar; //indica si ingreso codigo de barra y si es Tit, Fam o Adh
        public static string vp_adh_inp;
        public static string v_soc_fallecido;
        public static bool vp_esSocioTit;
        public static bool vp_esSocioAdh;
        public static string[,] vp_arraySolapas = new string[15, 2];
        public static int vp_IdScocio = 0;
        public static int vp_IdSecAct = 0;
        public static int vp_IDProf = 0;
        public static int vp_Secuencia = 0;
        public static string vp_Apellido = "";
        public static string vp_Nombre = "";
        public static int vp_IdSocio2 = 0;
        public static string vp_TipSoc = "";

        public static string vp_NombreTabla = "";
        public static string vp_Numero = "";
        public static string vp_Depuracion = "";
        public static string vp_Barra = "";
        public static string vp_CodDto = "";

        public static string vp_idTipo;
        public static string vp_idBusco;
        public static string vp_datasource;
        public static string vp_database = "";

        public static string vp_viene_de_barras = "";
        public static int vp_id_adhbarra = 0;
        public static string vp_idadh_barra = "";

        public static string vp_NroRecibo = "";
        public static string vp_servyact = "";
        public static string v_fechatope = "";
        //Agregado por Sebastian 20-01-2016
        public static int vp_Grupo = 0;
        public static string vp_CatSoc = "";

        public static Image Imagen_Carnet;
        public static bool Imagen_Editada = false;

        public static string ID_EMPLEADO = "";

        public static string PTO_VTA_N = "";
        public static string PTO_VTA_M = "";
        public static string PTO_VTA_O = "";
        public static string ID_PTO_VTA_N = "";
        public static string ID_PTO_VTA_M = "";
        public static string ID_PTO_VTA_O = "";

        public static int ID_CUOTA_PAGO = 0;


       

    }


    public static class CUIL
    {
        public static bool verificarCUIL(string numeroCUIL)
        {
            int suma, longitud, valor1, valor2;
            suma = 0;
            string final;
            longitud = numeroCUIL.Length;
            string patron = "5432765432";

            if (longitud == 11)
            {
                if (numeroCUIL.Substring(0, 2).CompareTo("20") == 0 || numeroCUIL.Substring(0, 2).CompareTo("23") == 0 || numeroCUIL.Substring(0, 2).CompareTo("24") == 0 || numeroCUIL.Substring(0, 2).CompareTo("27") == 0 || numeroCUIL.Substring(0, 2).CompareTo("30") == 0)
                {

                    final = numeroCUIL[10].ToString();

                    for (int i = 0; i <= 9; i++)
                    {
                        try
                        {

                            suma += int.Parse(patron[i].ToString()) * int.Parse(numeroCUIL[i].ToString());

                        }
                        catch
                        {
                            MessageBox.Show("CUIL INFORMADO NO NUMERICO",
                                        "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                          
                        }

                    }

                    valor1 = suma % 11;
                    valor2 = 11 - valor1;

                    if (valor2 == 11)
                    {
                        valor2 = 0;
                    }
                    else if (valor2 == 10)
                    {
                        valor2 = 9;
                    }

                    if (String.Equals(Convert.ToString(valor2), final))
                        return true;
                    else
                        return false;

                }
                else
                {
                    MessageBox.Show("CUIL INFORMADO INVALIDO",
                                        "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                   
                }
            }
            else
            {
                MessageBox.Show("LONGITUD CUIL INFORMADO ERRONEA",
                                        "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;

            }
        }
    }

    public static class CBU
    {
        public static bool ValidarCBU(string CBU)
        {
            int[] sumatoria1 = { 7, 1, 3, 9, 7, 1, 3 };
            int[] sumatoria2 = { 3, 9, 7, 1, 3, 9, 7, 1, 3, 9, 7, 1, 3 };
 
            char[] bloque1 = CBU.Substring(0, 8).ToCharArray();
            char[] bloque2 = CBU.Substring(8, 14).ToCharArray();
 
            int suma1 = 0;
            int suma2 = 0;
 
            for (int i = 0; i < bloque1.Length - 1; i++)
            {
                suma1 = suma1 + (int.Parse(bloque1[i].ToString()) * sumatoria1[i]);
            }
            for (int i = 0; i < bloque2.Length - 1; i++)
            {
                suma2 = suma2 + (int.Parse(bloque2[i].ToString()) * sumatoria2[i]);
            }
 
            suma1 = 10 - int.Parse(suma1.ToString().Substring(suma1.ToString().Length - 1, 1));
 
            suma2 = 10 - int.Parse(suma2.ToString().Substring(suma2.ToString().Length - 1, 1));

            if (suma2.ToString() == bloque2[bloque2.Length - 1].ToString() && suma1.ToString() == bloque1[bloque1.Length - 1].ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
