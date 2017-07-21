using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using FirebirdSql.Data.Firebird;

namespace SOCIOS
{
    class bo_Tecnica:bo
    {        //STORED GUARDA ASISTENCIA TECNICA

        public void altaAsistenciaTecnica(string NOM_EQ, string DIR_IP, string SO, string USUARIO_WIN, string USUARIO_ALTA, string PROBLEMA, string PRIORIDAD, string ESTADO, string FECHA_PENDIENTE, string ROL, int TIPO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(NOM_EQ);
            vector_contenidos.Add(DIR_IP);
            vector_contenidos.Add(SO);
            vector_contenidos.Add(USUARIO_WIN);
            vector_contenidos.Add(USUARIO_ALTA);
            vector_contenidos.Add(PROBLEMA);
            vector_contenidos.Add(PRIORIDAD);
            vector_contenidos.Add(ESTADO);
            vector_contenidos.Add(FECHA_PENDIENTE);
            vector_contenidos.Add(ROL);
            vector_contenidos.Add(TIPO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@NOM_EQ");
            vector_nombres.Add("@DIR_IP");
            vector_nombres.Add("@SO");
            vector_nombres.Add("@USUARIO_WIN");
            vector_nombres.Add("@USUARIO_ALTA");
            vector_nombres.Add("@PROBLEMA");
            vector_nombres.Add("@PRIORIDAD");
            vector_nombres.Add("@ESTADO");
            vector_nombres.Add("@FECHA_PENDIENTE");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@TIPO");
            string vprocedure = "ASISTENCIAS_TECNICAS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }


        public void AsistenciaTecnica_Cambio_Estado(int ID, string Texto, int Estado, string User, string ROL)
        {
            db resultado = new db();
            Mailer mailer = new Mailer();
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(Texto);
            vector_contenidos.Add(User);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@OBS");
            vector_nombres.Add("@TECNICO");

            string vprocedure = "";
            if (Estado == 1)
                vprocedure = "ASISTENCIA_TECNICA_ACTIVO";
            else if (Estado == 3)
                vprocedure = "ASISTENCIA_TECNICA_CANCELADO";
            else
            {
                vprocedure = "ASISTENCIA_TECNICA_CUMPLIMENTA";
            }
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

            if (Estado == 2)
            {
                string mail = Config.getValor(ROL, "MAIL", 0);
                if (mail.Length > 0)
                    mail = ";" + mail;
                mailer.EnvioMail("cspfaweb@gmail.com;tecnicacspfa@gmail.com;admcsicspfa@gmail.com" + mail, "SOLUCION TICKET NRO:" + ID.ToString(), "Ticket Solucionado : " + Texto);


            }
        }


        public void Asistencia_Tecnica_Nuevo_Seguimiento(int ID, string Texto, DateTime Fecha)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(Fecha);
            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(Texto);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");



            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ASISTENCIA_TECNICA");
            vector_nombres.Add("@FECHA");

            vector_nombres.Add("@F_A");
            vector_nombres.Add("@USR_A");
            vector_nombres.Add("@COMEN");
            string vprocedure = "SEGUIMIENTOS_ASISTENCIA_TECNI_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        public void Asistencia_Tecnica_Borro_Seguimiento(int ID)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);


            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");

            string vprocedure = "SEGUIMIENTOS_ASISTENCIA_TECNI_D";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        public void Asistencia_Tecnica_Update(int ID, string ObsActivo, string ObsCancel, string ObsCumpli, string Tecnico, string Prioridad)

        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(ObsActivo);
            vector_contenidos.Add(ObsCumpli);
            vector_contenidos.Add(ObsCancel);
            vector_contenidos.Add(Tecnico);
            vector_contenidos.Add(Prioridad);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);
          

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
  
            vector_tipos.Add("FbDbType.Date");
  
          
            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@OBS_ACTIVO");
            vector_nombres.Add("@OBS_CUMPLIMENTADO");
            vector_nombres.Add("@OBS_CANCELADO");
            vector_nombres.Add("@TECNICO");
            vector_nombres.Add("@PRIORIDAD");
            vector_nombres.Add("@USR_U");
            vector_nombres.Add("@FECHA_U");
            
            string vprocedure = "ASISTENCIAS_TECNICAS_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        
        }

    }
}
