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
    public class bo_Entrada_Campo:bo
    {

        public void Entrada_Campo_Importacion(string DNI, string NOMBRE, string APELLIDO, int NRO_SOCIO, int NRO_DEP, string TIPO, int INVITADO, decimal INVITADO_MONTO, int INVITADO_PILETA, decimal INVITADO_PILETA_MONTO, int INVITADO_EST, decimal INVITADO_EST_MONTO, int SOCIO, decimal SOCIO_MONTO, int SOCIO_PILETA, decimal SOCIO_PILETA_MONTO, int SOCIO_EST, decimal SOCIO_EST_MONTO, int INTER, decimal INTER_MONTO, int INTER_PILETA, decimal INTER_PILETA_MONTO, int INTER_EST, decimal INTER_EST_MONTO, int CANTIDAD, decimal MONTO_TOTAL, DateTime FECHA, string ROL, string USUARIO, int ID_INT, DateTime Fecha_Anul)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            ArrayList vector_tipos = new ArrayList();

            vector_contenidos.Add(DNI);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@DNI");

            vector_contenidos.Add(NOMBRE);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@NOMBRE");
            vector_contenidos.Add(APELLIDO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@APELLIDO");


            vector_contenidos.Add(NRO_SOCIO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@NRO_SOCIO");
            vector_contenidos.Add(NRO_DEP);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@NRO_DEP");
            vector_contenidos.Add(TIPO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@TIPO");
            vector_contenidos.Add(INVITADO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INVITADO");


            vector_contenidos.Add(INVITADO_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INVITADO");



            vector_contenidos.Add(INVITADO_PILETA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INVITADO_PILETA");

            vector_contenidos.Add(INVITADO_PILETA_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INVITADO_PIL");


            vector_contenidos.Add(INVITADO_EST);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INVITADO_EST");

            vector_contenidos.Add(INVITADO_EST_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INVITADO_EST");

            vector_contenidos.Add(SOCIO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@SOCIO");


            vector_contenidos.Add(SOCIO_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_SOCIO");


            vector_contenidos.Add(SOCIO_PILETA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@SOCIO_PILETA");

            vector_contenidos.Add(SOCIO_PILETA_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_SOCIO_PIL");


            vector_contenidos.Add(SOCIO_EST);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@SOCIO_EST");

            vector_contenidos.Add(SOCIO_EST_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_SOCIO_EST");


            vector_contenidos.Add(INTER);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INTER");


            vector_contenidos.Add(INTER_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INTER");


            vector_contenidos.Add(INTER_PILETA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INTER_PILETA");

            vector_contenidos.Add(INTER_PILETA_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INTER_PILETA");


            vector_contenidos.Add(INTER_EST);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INTER_EST");

            vector_contenidos.Add(INTER_EST_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INTER_EST");





            vector_contenidos.Add(CANTIDAD);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@CANTIDAD_TOTAL");

            vector_contenidos.Add(MONTO_TOTAL);
            vector_nombres.Add("@MONTO_TOTAL");
            vector_tipos.Add("FbDbType.Float");



            vector_contenidos.Add(FECHA);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@FECHA");

            vector_contenidos.Add(ROL);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@ROL");
            vector_contenidos.Add(USUARIO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@USUARIO");


            vector_contenidos.Add(ID_INT);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID_ROL");

            vector_contenidos.Add(System.DateTime.Now);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@FECHA_ANUL");


            vector_contenidos.Add(VGlobales.vp_username);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@USUARIO_IMPORTACION");

            vector_contenidos.Add(System.DateTime.Now);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@FECHA_IMPORTACION");

            vector_contenidos.Add(VGlobales.vp_role);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@ROL_IMPORTACION");








            string vprocedure = "ENTRADA_CAMPO_IMPOR";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        public void Entrada_Campo_Ins(string DNI, string NOMBRE, string APELLIDO, int NRO_SOCIO, int NRO_DEP, string TIPO, int INVITADO, decimal INVITADO_MONTO, int INVITADO_PILETA, decimal INVITADO_PILETA_MONTO, int INVITADO_EST, decimal INVITADO_EST_MONTO, int SOCIO, decimal SOCIO_MONTO, int SOCIO_PILETA, decimal SOCIO_PILETA_MONTO, int SOCIO_EST, decimal SOCIO_EST_MONTO, int INT, decimal INT_MONTO, int INT_PILETA, decimal INT_PILETA_MONTO, int INT_EST, decimal INT_EST_MONTO, int CANTIDAD, decimal MONTO_TOTAL, DateTime FECHA, string ROL, string USUARIO, int MENOR, int DISCA, int DISCA_ACOM,int EVENTO,decimal MONTO_EVENTO, int ID_ROL, string TIPO_REG,int Legajo,string OBS_CUMPLE,int EXPORTADO,string USUARIO_I,string ROL_I,string HORA,int PROMO,int HORA_PILETA)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            ArrayList vector_tipos = new ArrayList();



            vector_contenidos.Add(DNI);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@DNI");

            vector_contenidos.Add(NOMBRE);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@NOMBRE");
            vector_contenidos.Add(APELLIDO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@APELLIDO");


            vector_contenidos.Add(NRO_SOCIO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@NRO_SOCIO");
            vector_contenidos.Add(NRO_DEP);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@NRO_DEP");
            vector_contenidos.Add(TIPO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@TIPO");
            vector_contenidos.Add(INVITADO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INVITADO");


            vector_contenidos.Add(INVITADO_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INVITADO");



            vector_contenidos.Add(INVITADO_PILETA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INVITADO_PILETA");

            vector_contenidos.Add(INVITADO_PILETA_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INVITADO_PIL");


            vector_contenidos.Add(INVITADO_EST);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INVITADO_EST");

            vector_contenidos.Add(INVITADO_EST_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INVITADO_EST");

            vector_contenidos.Add(SOCIO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@SOCIO");


            vector_contenidos.Add(SOCIO_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_SOCIO");


            vector_contenidos.Add(SOCIO_PILETA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@SOCIO_PILETA");

            vector_contenidos.Add(SOCIO_PILETA_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_SOCIO_PIL");


            vector_contenidos.Add(SOCIO_EST);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@SOCIO_EST");

            vector_contenidos.Add(SOCIO_EST_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_SOCIO_EST");


            vector_contenidos.Add(INT);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INTER");


            vector_contenidos.Add(INT_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INTER");


            vector_contenidos.Add(INT_PILETA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INTER_PILETA");

            vector_contenidos.Add(INT_PILETA_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INTER_PILETA");


            vector_contenidos.Add(INT_EST);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INTER_EST");

            vector_contenidos.Add(INT_EST_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INTER_EST");





            vector_contenidos.Add(CANTIDAD);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@CANTIDAD_TOTAL");

            vector_contenidos.Add(MONTO_TOTAL);
            vector_nombres.Add("@MONTO_TOTAL");
            vector_tipos.Add("FbDbType.Float");



            vector_contenidos.Add(FECHA);
            vector_tipos.Add("FbDbType.Datetime");
            vector_nombres.Add("@FECHA");

            vector_contenidos.Add(ROL);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@ROL");
            vector_contenidos.Add(USUARIO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@USUARIO");


            vector_contenidos.Add(MENOR);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@MENOR");

            vector_contenidos.Add(DISCA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@DISCA");

            vector_contenidos.Add(DISCA_ACOM);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@DISCA_ACOM");
            
            vector_contenidos.Add(ID_ROL);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID_ROL");

            vector_contenidos.Add(TIPO_REG);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@TIPO_REG");

            vector_contenidos.Add(Legajo);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@LEGAJO");

            vector_contenidos.Add(OBS_CUMPLE);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@CUMPLE_OBS");

            vector_contenidos.Add(EXPORTADO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@EXPORTADO");

            vector_contenidos.Add(USUARIO_I);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@USUARIO_IMPORTACION");

            vector_contenidos.Add(System.DateTime.Now);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@FECHA_IMPORTACION");

            vector_contenidos.Add(ROL_I);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@ROL_IMPORTACION");

            vector_contenidos.Add(EVENTO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@EVENTO");

            vector_contenidos.Add(MONTO_EVENTO);
            vector_nombres.Add("@MONTO_EVENTO");
            vector_tipos.Add("FbDbType.Float");

            vector_contenidos.Add(HORA);
            vector_nombres.Add("@HORA");
            vector_tipos.Add("FbDbType.VarChar");

            vector_contenidos.Add(PROMO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PROMO");

            vector_contenidos.Add(HORA_PILETA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@HORA_PILETA");

            string vprocedure = "P_ENTRADA_CAMPO_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        public void Entrada_Campo_Impor(string DNI, string NOMBRE, string APELLIDO, int NRO_SOCIO, int NRO_DEP, string TIPO, int INVITADO, decimal INVITADO_MONTO, int INVITADO_PILETA, decimal INVITADO_PILETA_MONTO, int INVITADO_EST, decimal INVITADO_EST_MONTO, int SOCIO, decimal SOCIO_MONTO, int SOCIO_PILETA, decimal SOCIO_PILETA_MONTO, int SOCIO_EST, decimal SOCIO_EST_MONTO, int INT, decimal INT_MONTO, int INT_PILETA, decimal INT_PILETA_MONTO, int INT_EST, decimal INT_EST_MONTO, int CANTIDAD, decimal MONTO_TOTAL, DateTime FECHA, string ROL, string USUARIO, int MENOR, int DISCA, int DISCA_ACOM, int ID_ROL, string TIPO_REG, int Legajo, string OBS_CUMPLE, int EXPORTADO)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            ArrayList vector_tipos = new ArrayList();



            vector_contenidos.Add(DNI);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@DNI");

            vector_contenidos.Add(NOMBRE);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@NOMBRE");
            vector_contenidos.Add(APELLIDO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@APELLIDO");


            vector_contenidos.Add(NRO_SOCIO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@NRO_SOCIO");
            vector_contenidos.Add(NRO_DEP);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@NRO_DEP");
            vector_contenidos.Add(TIPO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@TIPO");
            vector_contenidos.Add(INVITADO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INVITADO");


            vector_contenidos.Add(INVITADO_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INVITADO");



            vector_contenidos.Add(INVITADO_PILETA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INVITADO_PILETA");

            vector_contenidos.Add(INVITADO_PILETA_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INVITADO_PIL");


            vector_contenidos.Add(INVITADO_EST);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INVITADO_EST");

            vector_contenidos.Add(INVITADO_EST_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INVITADO_EST");

            vector_contenidos.Add(SOCIO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@SOCIO");


            vector_contenidos.Add(SOCIO_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_SOCIO");


            vector_contenidos.Add(SOCIO_PILETA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@SOCIO_PILETA");

            vector_contenidos.Add(SOCIO_PILETA_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_SOCIO_PIL");


            vector_contenidos.Add(SOCIO_EST);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@SOCIO_EST");

            vector_contenidos.Add(SOCIO_EST_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_SOCIO_EST");


            vector_contenidos.Add(INT);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INTER");


            vector_contenidos.Add(INT_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INTER");


            vector_contenidos.Add(INT_PILETA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INTER_PILETA");

            vector_contenidos.Add(INT_PILETA_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INTER_PILETA");


            vector_contenidos.Add(INT_EST);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@INTER_EST");

            vector_contenidos.Add(INT_EST_MONTO);
            vector_tipos.Add("FbDbType.Float");
            vector_nombres.Add("@MONTO_INTER_EST");





            vector_contenidos.Add(CANTIDAD);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@CANTIDAD_TOTAL");

            vector_contenidos.Add(MONTO_TOTAL);
            vector_nombres.Add("@MONTO_TOTAL");
            vector_tipos.Add("FbDbType.Float");



            vector_contenidos.Add(FECHA);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@FECHA");

            vector_contenidos.Add(ROL);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@ROL");
            vector_contenidos.Add(USUARIO);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@USUARIO");


            vector_contenidos.Add(MENOR);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@MENOR");

            vector_contenidos.Add(DISCA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@DISCA");

            vector_contenidos.Add(DISCA_ACOM);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@DISCA_ACOM");

            vector_contenidos.Add(ID_ROL);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID_ROL");

            vector_contenidos.Add(TIPO_REG);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@TIPO_REG");

            vector_contenidos.Add(Legajo);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@LEGAJO");

            vector_contenidos.Add(OBS_CUMPLE);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@CUMPLE_OBS");

            vector_contenidos.Add(EXPORTADO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@EXPORTADO");



            vector_contenidos.Add(System.DateTime.Now);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@FECHA_IMPOR");

            vector_contenidos.Add(VGlobales.vp_role);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@ROL_IMPOR");
            vector_contenidos.Add(VGlobales.vp_username);
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@USUARIO_IMPOR");



            string vprocedure = "P_ENTRADA_CAMPO_IMPOR";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        public void Entrada_Campo_Marca(int ID,string ROL)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            ArrayList vector_tipos = new ArrayList();

            vector_contenidos.Add(ID);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID");
            vector_contenidos.Add(ROL);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@ROL");






            string vprocedure = "P_ENTRADA_CAMPO_MARCA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        public void Entrada_Campo_Anular(int ID)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            ArrayList vector_tipos = new ArrayList();

            vector_contenidos.Add(ID);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID");

            vector_contenidos.Add(System.DateTime.Now);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@FECHA_ANUL");

            vector_contenidos.Add(VGlobales.vp_username);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@USUARIO");


            string vprocedure = "P_ENTRADA_CAMPO_ANULAR";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }


        public void Entrada_Campo_HORARIOS_Ins(int ID_EC,int ID_HORA,int SOCIO,int INTER,int INVI, int MENOR,int DISCA,int DISCA_ACOM,int PROMO)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            ArrayList vector_tipos = new ArrayList();



            vector_contenidos.Add(ID_EC);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PIN_ID_EC");

            vector_contenidos.Add(ID_HORA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PIN_ID_HORA");

            vector_contenidos.Add(SOCIO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PIN_SOCIO_PILETA");


            vector_contenidos.Add(INTER);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PIN_INTER_PILETA");

            vector_contenidos.Add(INVI);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PIN_INVI_PILETA");


            vector_contenidos.Add(MENOR);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PIN_MENOR");

            vector_contenidos.Add(DISCA);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PIN_DISCA");

            vector_contenidos.Add(DISCA_ACOM);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PIN_DISCA_ACOM");

            vector_contenidos.Add(PROMO);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@PIN_PROMO");

            vector_contenidos.Add(System.DateTime.Now);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@PIN_FECHA");

            vector_contenidos.Add(VGlobales.vp_role);
            vector_tipos.Add("FbDbType.Varchar");
            vector_nombres.Add("@PIN_ROL");




          

            string vprocedure = "P_ENTRADA_CAMPO_PH_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

    }
}
