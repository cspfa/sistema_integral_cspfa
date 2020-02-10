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
    class bo_Turismo :SOCIOS.bo
    {

        #region Pais_Localidad
        public void Pais_I(string PAIS)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            ArrayList vector_tipos = new ArrayList();


            vector_contenidos.Add(0);
            vector_tipos.Add("FbDbType.Char");
            vector_nombres.Add("@PROVINCIAID");
            
            vector_contenidos.Add(PAIS);
            vector_tipos.Add("FbDbType.Char");
            vector_nombres.Add("@NOMBRE");

          


            string vprocedure = "PROVINCIA_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }
        public void Localidad_Ins(int PROVINCIAID, string DESCRIPCION, string NOMBRE_CORTO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(PROVINCIAID);
            vector_contenidos.Add(DESCRIPCION);
            vector_contenidos.Add(NOMBRE_CORTO);





            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");



            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@PROVINCIAID");
            vector_nombres.Add("@DESCRICION");
            vector_nombres.Add("@DES_SHORT");


            string vprocedure = "P_LOCALIDAD_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);







        }

        #endregion

        #region Alojamiento

        public void Registro_Persona_I(int Registro_ID, string NOMBRE, string APELLIDO, string DNI)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(0);
            vector_contenidos.Add(Registro_ID);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(APELLIDO);
            vector_contenidos.Add(DNI);


            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@REGISTRO_ALOJAMIENTO_ID");


            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@DNI");

            string vprocedure = "P_ALOJAMIENTO_PERSONA_I";


            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }
        public void REGISTRO_ALOJAMIENTO_I(int Solicitud, DateTime Fecha, int NRO_SOC, int NRO_DEP, int NRO_ADH, int NRO_DEP_ADH, int BARRA, int HOTEL, int HABITACION, int PERSONAS, int BLOQUEADA)
        {

            int NroSocio = 0;
            int NroDep = 0;
            int NroAdh = 0;
            int NroDepAdh = 0;


            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(0);
            vector_contenidos.Add(Solicitud);
            vector_contenidos.Add(Fecha);
            vector_contenidos.Add(NRO_SOC);
            vector_contenidos.Add(NRO_DEP);
            vector_contenidos.Add(NRO_ADH);
            vector_contenidos.Add(NRO_DEP_ADH);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(HOTEL);
            vector_contenidos.Add(HABITACION);
            vector_contenidos.Add(PERSONAS);
            vector_contenidos.Add(BLOQUEADA);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);


            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");



            ArrayList vector_nombres = new ArrayList();


            vector_nombres.Add("@ID");
            vector_nombres.Add("@SOLICITUD_ID");
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@NRO_ADH");
            vector_nombres.Add("@NRO_DEP_ADH");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@HOTEL_ID");
            vector_nombres.Add("@HABITACION_ID");
            vector_nombres.Add("@PERSONAS");
            vector_nombres.Add("@HAB_BLOQUEADA");
            vector_nombres.Add("@USR_I");
            vector_nombres.Add("@FECHA_I");

            string vprocedure = "P_REGISTRO_ALOJAMIENTO_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }
        public void SOLICITUD_ALOJAMIENTO_U(int ID, DateTime Desde, DateTime Hasta, int Tipo_Habitacion)
        {

            int NroSocio = 0;
            int NroDep = 0;
            int NroAdh = 0;
            int NroDepAdh = 0;


            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(ID);
            vector_contenidos.Add(Desde);
            vector_contenidos.Add(Hasta);

            vector_contenidos.Add(Tipo_Habitacion);


            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);


            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();


            vector_nombres.Add("@ID");
            vector_nombres.Add("@DESDE");
            vector_nombres.Add("@HASTA");
            vector_nombres.Add("@TIPO_HABITACION");
            vector_nombres.Add("@USR_U");
            vector_nombres.Add("@F_U");


            string vprocedure = "P_SOLICITUD_INTERIOR_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }
        public void SOLICITUD_ALOJAMIENTO_PROCESO(int ID)
        {

            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add(1);
            vector_contenidos.Add(System.DateTime.Now);


            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@USR_U");
            vector_nombres.Add("@F_U");
            vector_nombres.Add("@PROCESADA");
            vector_nombres.Add("@F_PROCESO");

            string vprocedure = "P_PROCESAR_SOLICITUD_INTERIOR";


            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);



        }
        public void SOLICITUD_ALOJAMIENTO_I(DateTime Desde, DateTime Hasta, string Tipo, string Dni, string Nombre, string Apellido, int pNro_Socio, int pNro_Dep, int Barra, int pNro_Adh, int pNro_Dep_Adh, int Plazas, int Tipo_Habitacion)
        {

            int NroSocio = 0;
            int NroDep = 0;
            int NroAdh = 0;
            int NroDepAdh = 0;

            NroSocio = pNro_Socio;
            NroDep = pNro_Dep;
            NroAdh = pNro_Adh;
            NroDepAdh = pNro_Dep_Adh;


            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(0);
            vector_contenidos.Add(Desde);
            vector_contenidos.Add(Hasta);

            vector_contenidos.Add(Tipo);
            vector_contenidos.Add(Dni);
            vector_contenidos.Add(Nombre);
            vector_contenidos.Add(Apellido);


            vector_contenidos.Add(NroSocio);
            vector_contenidos.Add(NroDep);
            vector_contenidos.Add(NroAdh);
            vector_contenidos.Add(NroDepAdh);


            vector_contenidos.Add(Barra);

            vector_contenidos.Add(Plazas);

            vector_contenidos.Add(Tipo_Habitacion);

            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);


            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");


            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");




            ArrayList vector_nombres = new ArrayList();





            vector_nombres.Add("@ID");
            vector_nombres.Add("@DESDE");
            vector_nombres.Add("@HASTA");

            vector_nombres.Add("@TIPO");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@APELLIDO");

            vector_nombres.Add("@NRO_SOCIO");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@NRO_ADH");
            vector_nombres.Add("@NRO_DEP_ADH");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@PLAZAS");
            vector_nombres.Add("@TIPO_HABITACION");
            vector_nombres.Add("@USR_A");
            vector_nombres.Add("@F_A");


            string vprocedure = "P_SOLICITUD_INTERIOR_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        public void Tipo_Habitacion_Ins(string Tipo, int Camas, int Tipo_Habitacion_Persona)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Tipo);
            vector_contenidos.Add(Camas);
            vector_contenidos.Add(Tipo_Habitacion_Persona);
            // vector_contenidos.Add(System.DateTime.Now.ToShortDateString());

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");




            ArrayList vector_nombres = new ArrayList();



            vector_nombres.Add("@TIPO");

            vector_nombres.Add("@CAMAS");
            vector_nombres.Add("@TIPO_HAB");

            string vprocedure = "P_HOTEL_HABITACION_TIPO_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }
        public void Tipo_Habitacion_Upd(int ID, string Tipo, int Camas)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(Tipo);
            vector_contenidos.Add(Camas);

            vector_contenidos.Add(System.DateTime.Now.ToShortDateString());

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Varchar");





            ArrayList vector_nombres = new ArrayList();




            vector_nombres.Add("@ID");
            vector_nombres.Add("@TIPO");

            vector_nombres.Add("@CAMAS");

            string vprocedure = "P_HOTEL_HABITACION_TIPO_U";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }
        //STORED CARGAR OCUPACION HOTEL
        public void HABITACION_HOTEL_OCUPACION_I(DateTime Fecha, int Nro_Soc, int Nro_Dep, int Barra, string Nombre, string Apellido, string DNI, int Habitacion_ID, int Plazas, bool Bloqueada, int Solicitud, int Registro, int HOTEL)
        {

            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(Fecha);
            vector_contenidos.Add(Nro_Soc);
            vector_contenidos.Add(Nro_Dep);
            vector_contenidos.Add(Barra);
            vector_contenidos.Add(Nombre);
            vector_contenidos.Add(Apellido);
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(Habitacion_ID);
            vector_contenidos.Add(Plazas);
            vector_contenidos.Add(Bloqueada);
            vector_contenidos.Add(Solicitud);
            vector_contenidos.Add(Registro);
            vector_contenidos.Add(HOTEL);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@HABITACION_ID");
            vector_nombres.Add("@PLAZAS");
            vector_nombres.Add("@BLOQUEADA");
            vector_nombres.Add("@SOLICITUD");
            vector_nombres.Add("@REGISTRO_ID");
            vector_nombres.Add("@HOTEL");

            string vprocedure = "P_HABITACION_OCUPACION_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED BORRAR OCUPACION HOTEL
        public void HABITACION_HOTEL_OCUPACION_D(int ID)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);


            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");


            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");


            string vprocedure = "P_HABITACION_OCUPACION_D";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        public void Hotel_Habitacion_Ins(int Hotel, int Habitacion, int PLaza, string Nombre)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(Hotel);
            vector_contenidos.Add(PLaza);
            vector_contenidos.Add(Habitacion);
            vector_contenidos.Add(Nombre);




            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");



            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@HOTEL_ID");
            vector_nombres.Add("@PLAZA");
            vector_nombres.Add("@HABITACION_ID");
            vector_nombres.Add("@NOMBRE");

            string vprocedure = "P_HOTEL_HABITACION_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);



        }

        public void Hotel_Habitacion_Baja(int ID)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);





            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");





            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");


            string vprocedure = "P_HOTEL_HABITACION_D";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);



        }
     


        #endregion

        #region Voucher

        public void Voucher_HOTEL_Insert(int BONO, DateTime Desde, DateTime Hasta, int Hotel, int Noches, int Pasajeros, int Regimen, int Habitacion, string Nro_Habitacion, string Tipo, string Motivo)
        {

            try
            {
                db resultado = new db();


                ArrayList vector_contenidos = new ArrayList();
                vector_contenidos.Add(BONO);
                vector_contenidos.Add(Desde);
                vector_contenidos.Add(Hasta);
                vector_contenidos.Add(Hotel);
                vector_contenidos.Add(Noches);
                vector_contenidos.Add(Pasajeros);
                vector_contenidos.Add(Regimen);
                vector_contenidos.Add(Habitacion);
                vector_contenidos.Add(System.DateTime.Now);
                vector_contenidos.Add(VGlobales.vp_username);
                vector_contenidos.Add(Nro_Habitacion);
                vector_contenidos.Add(Tipo);
                vector_contenidos.Add(Motivo);

                ArrayList vector_tipos = new ArrayList();

                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Varchar");
                vector_tipos.Add("FbDbType.Varchar");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");

                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");

                vector_tipos.Add("FbDbType.Varchar");
                vector_tipos.Add("FbDbType.Varchar");
                vector_tipos.Add("FbDbType.Varchar");
                vector_tipos.Add("FbDbType.Varchar");
                vector_tipos.Add("FbDbType.Varchar");


                ArrayList vector_nombres = new ArrayList();

                vector_nombres.Add("@BONO");
                vector_nombres.Add("@DESDE");
                vector_nombres.Add("@HASTA");
                vector_nombres.Add("@HOTEL");
                vector_nombres.Add("@NOCHES");
                vector_nombres.Add("@PASAJEROS");

                vector_nombres.Add("@REGIMEN");
                vector_nombres.Add("@TIPO_HABITACION");

                vector_nombres.Add("@F_ALTA");
                vector_nombres.Add("@U_ALTA");
                vector_nombres.Add("@NRO_HABITACION");
                vector_nombres.Add("@TIPO");
                vector_nombres.Add("@MOTIVO");
                string vprocedure = "P_VOUCHER_BONO_HOTEL_I";

                resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
            }
            catch (Exception ex)
            {

            }
        }
        
        public void Voucher_HOTEL_Update(int ID, int BONO, DateTime Desde, DateTime Hasta, int Hotel, int Noches, int Pasajeros)
        {

            db resultado = new db();


            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(BONO);
            vector_contenidos.Add(Desde);
            vector_contenidos.Add(Hasta);
            vector_contenidos.Add(Hotel);
            vector_contenidos.Add(Noches);
            vector_contenidos.Add(Pasajeros);

            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);


            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");




            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@BONO");
            vector_nombres.Add("@DESDE");
            vector_nombres.Add("@HASTA");
            vector_nombres.Add("@HOTEL");
            vector_nombres.Add("@NOCHES");
            vector_nombres.Add("@PASAJEROS");
            vector_nombres.Add("@REGIMEN");
            vector_nombres.Add("@HABITACION");
            vector_nombres.Add("@F_ALTA");
            vector_nombres.Add("@U_ALTA");
            string vprocedure = "P_VOUCHER_BONO_HOTEL_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        public void HOTEL_DIAS_INSERT(int NRO_SOCIO, int NRO_DEP, int TRAMITE, int ENFERMEDAD, int CIRUGIA)
        {

            db resultado = new db();


            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(NRO_SOCIO);
            vector_contenidos.Add(NRO_DEP);
            vector_contenidos.Add(TRAMITE);
            vector_contenidos.Add(ENFERMEDAD);
            vector_contenidos.Add(CIRUGIA);


            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);


            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");



            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@PIN_NRO_SOCIO");
            vector_nombres.Add("@PIN_NRO_DEP");
            vector_nombres.Add("@PIN_TRAMITE");
            vector_nombres.Add("@PIN_ENFERMEDAD");
            vector_nombres.Add("@PIN_CIRUGIA");
            vector_nombres.Add("@PIN_U_ALTA");
            vector_nombres.Add("@PIN_F_ALTA");

            string vprocedure = "P_HOTEL_DIAS_ALOJAMIENTO_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        #endregion

        #region Salida_Traslado_Regimen

        public void Regimen_Ins(string DESCRIPCION)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(DESCRIPCION);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now.ToShortDateString());





            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Varchar");

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");



            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@U_ALTA");
            vector_nombres.Add("@F_ALTA");


            string vprocedure = "P_TURISMO_REGIMEN_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }
        public void Regimen_Baja(int ID)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now.ToShortDateString());





            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");



            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@U_BAJA");
            vector_nombres.Add("@F_BAJA");


            string vprocedure = "P_TURISMO_REGIMEN_U";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }
        public void Traslado_Ins(string DESCRIPCION)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(DESCRIPCION);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now.ToShortDateString());





            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Varchar");

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");



            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@U_ALTA");
            vector_nombres.Add("@F_ALTA");


            string vprocedure = "P_TURISMO_TRASLADO_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }
        public void Traslado_Baja(int ID)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now.ToShortDateString());





            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");



            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@U_BAJA");
            vector_nombres.Add("@F_BAJA");


            string vprocedure = "P_TURISMO_TRASLADO_U";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }

        public void Tipo_Salida_Ins(string DESCRIPCION)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(DESCRIPCION);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now.ToShortDateString());





            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Varchar");

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");



            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@U_ALTA");
            vector_nombres.Add("@F_ALTA");


            string vprocedure = "P_TURISMO_TIPO_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }
        public void Tipo_Salida_Baja(int ID)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now.ToShortDateString());





            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");



            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@U_BAJA");
            vector_nombres.Add("@F_BAJA");


            string vprocedure = "P_TIPO_U";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }

        public void Salida_Ins(string Nombre, DateTime Fecha, bool Agotado, int ProvDesde, int ProvHasta, int Operador, int LocDesde, int LocHasta, decimal Socio, decimal Invitado, decimal Intercirculo, decimal Menor, string Estadia, int Regimen, int Traslado, int Tipo, int Hotel, string HotelNombre, bool Destacado, string Moneda, string Observaciones, bool Diario,decimal Coche_Cama,int Mostrar_Web)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Nombre);
            vector_contenidos.Add(Fecha);
            vector_contenidos.Add(Agotado);
            vector_contenidos.Add(ProvDesde);
            vector_contenidos.Add(ProvHasta);
            vector_contenidos.Add(Operador);
            vector_contenidos.Add(LocDesde);
            vector_contenidos.Add(LocHasta);
            vector_contenidos.Add(Socio);
            vector_contenidos.Add(Invitado);
            vector_contenidos.Add(Intercirculo);
            vector_contenidos.Add(Estadia);
            vector_contenidos.Add(Regimen);
            vector_contenidos.Add(Traslado);
            vector_contenidos.Add(Tipo);
            vector_contenidos.Add(Hotel);
            vector_contenidos.Add(HotelNombre);
            vector_contenidos.Add(Destacado);
            vector_contenidos.Add(Moneda);
            vector_contenidos.Add(Destacado);

            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now.ToShortDateString());
            vector_contenidos.Add(Observaciones);
            vector_contenidos.Add(Menor);
            vector_contenidos.Add(Coche_Cama);
            vector_contenidos.Add(Mostrar_Web);




            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Integer");
            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@AGOTADO");
            vector_nombres.Add("@PROV_DESDE");
            vector_nombres.Add("@PROV_HASTA");
            vector_nombres.Add("@OPERADOR");
            vector_nombres.Add("@LOC_DESDE");
            vector_nombres.Add("@LOC_HASTA");
            vector_nombres.Add("@SOCIO");
            vector_nombres.Add("@INVITADO");
            vector_nombres.Add("@INTERCIRCULO");
            vector_nombres.Add("@ESTADIA");
            vector_nombres.Add("@REGIMEN");
            vector_nombres.Add("@TRASLADO");
            vector_nombres.Add("@TIPO");
            vector_nombres.Add("@HOTEL");
            vector_nombres.Add("@HOTEL_NOMBRE");
            vector_nombres.Add("@DESTACADO");
            vector_nombres.Add("@MONEDA");
            vector_nombres.Add("@U_ALTA");
            vector_nombres.Add("@F_ALTA");
            vector_nombres.Add("@OBSERVACIONES");
            vector_nombres.Add("@DESTACADO");
            vector_nombres.Add("@MENOR");
            vector_nombres.Add("@COCHE_CAMA");
            vector_nombres.Add("@MOSTRAR_WEB");
            string vprocedure = "P_TURISMO_SALIDA_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);


        }

        public void Salida_Upd(int ID, string Nombre, DateTime Fecha, bool Agotado, int ProvDesde, int ProvHasta, int Operador, int LocDesde, int LocHasta, decimal Socio, decimal Invitado, decimal Intercirculo, decimal Menor, string Estadia, int Regimen, int Traslado, int Tipo, int Hotel, string HotelNombre, bool Destacado, string Moneda, string Observaciones, bool Diaria,decimal Coche_Cama,int Mostrar_Web)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(Nombre);
            vector_contenidos.Add(Fecha);
            vector_contenidos.Add(Agotado);
            vector_contenidos.Add(ProvDesde);
            vector_contenidos.Add(ProvHasta);
            vector_contenidos.Add(Operador);
            vector_contenidos.Add(LocDesde);
            vector_contenidos.Add(LocHasta);
            vector_contenidos.Add(Socio);
            vector_contenidos.Add(Invitado);
            vector_contenidos.Add(Intercirculo);
            vector_contenidos.Add(Estadia);
            vector_contenidos.Add(Regimen);
            vector_contenidos.Add(Traslado);
            vector_contenidos.Add(Tipo);
            vector_contenidos.Add(Hotel);
            vector_contenidos.Add(HotelNombre);
            vector_contenidos.Add(Destacado);
            vector_contenidos.Add(Moneda);
            vector_contenidos.Add(Observaciones);
            vector_contenidos.Add(Diaria);
            vector_contenidos.Add(Menor);
            vector_contenidos.Add(Coche_Cama);
            vector_contenidos.Add(Mostrar_Web);



            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@AGOTADO");
            vector_nombres.Add("@PROV_DESDE");
            vector_nombres.Add("@PROV_HASTA");
            vector_nombres.Add("@OPERADOR");
            vector_nombres.Add("@LOC_DESDE");
            vector_nombres.Add("@LOC_HASTA");
            vector_nombres.Add("@SOCIO");
            vector_nombres.Add("@INVITADO");
            vector_nombres.Add("@INTERCIRCULO");
            vector_nombres.Add("@ESTADIA");
            vector_nombres.Add("@REGIMEN");
            vector_nombres.Add("@TRASLADO");
            vector_nombres.Add("@TIPO");
            vector_nombres.Add("@HOTEL");
            vector_nombres.Add("@HOTEL_NOMBRE");
            vector_nombres.Add("@DESTACADO");
            vector_nombres.Add("@MONEDA");

            vector_nombres.Add("@OBSERVACIONES");
            vector_nombres.Add("@DIARIA");
            vector_nombres.Add("@MENOR");
            vector_nombres.Add("@COCHE_CAMA");
            vector_nombres.Add("@MOSTRAR_WEB");
            string vprocedure = "P_TURISMO_SALIDA_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);


        }


        public void Salida_Baja(int ID)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now.ToShortDateString());





            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");



            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@U_BAJA");
            vector_nombres.Add("@F_BAJA");


            string vprocedure = "P_TURISMO_SALIDA_B";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);



        }

        #region Hoteles
        // Insert Hoteles- Con Modificacion 25/01/2016
        public void InsertHotel(string Nombre, int Provincia, int Localidad, string Domicilio, string Telefono, int Estrellas, string Obs, string Cuit, string Responsable, string Email_ope, string Email_Reservas, string Email_adm, string Email_Info, string CheckIn, string CheckOut, DateTime Fecha, string User, int Propio, int Social, decimal Late, int NroCuenta)
        {
            db resultado = new db();
            SOCIOS.maxid maximo = new maxid();
            this.nuevaEspecialidad("HOTELES", Nombre, 0, 0);
            int ID = Int32.Parse(maximo.m("ID", "SECTACT"));



            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(Nombre);
            vector_contenidos.Add(Provincia);
            vector_contenidos.Add(Localidad);
            vector_contenidos.Add(Domicilio);
            vector_contenidos.Add(Telefono);
            vector_contenidos.Add(Estrellas);
            vector_contenidos.Add(Obs);
            vector_contenidos.Add(Cuit);
            vector_contenidos.Add(Responsable);
            vector_contenidos.Add(Fecha);
            vector_contenidos.Add(User);
            vector_contenidos.Add(Email_ope);
            vector_contenidos.Add(Email_Reservas);
            vector_contenidos.Add(Email_adm);
            vector_contenidos.Add(Email_Info);
            vector_contenidos.Add(CheckIn);
            vector_contenidos.Add(CheckOut);
            vector_contenidos.Add(Propio);
            vector_contenidos.Add(Social);
            vector_contenidos.Add(Late);
            vector_contenidos.Add(NroCuenta);
            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@PROVINCIAID");
            vector_nombres.Add("@LOCALIDADID");
            vector_nombres.Add("@DOMICILIO");
            vector_nombres.Add("@TELEFONO");
            vector_nombres.Add("@ESTRELLAS");
            vector_nombres.Add("@OBSERVACIONES");
            vector_nombres.Add("@CUIT");
            vector_nombres.Add("@RESPONSABLE");
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@USR");


            vector_nombres.Add("@EMAIL_OPERACION");
            vector_nombres.Add("@EMAIL_RESERVAS");
            vector_nombres.Add("@EMAIL_ADM");
            vector_nombres.Add("@EMAIL_INFO");
            vector_nombres.Add("@CHECKIN");
            vector_nombres.Add("@CHECKOUT");
            vector_nombres.Add("@PROPIO");
            vector_nombres.Add("@SOCIAL");
            vector_nombres.Add("@LATE_CHK");
            vector_nombres.Add("@NRO_CUENTA");
            string vprocedure = "P_HOTEL_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);



        }
        //Update Hoteles

        public void UpdateHotel(int ID, string Nombre, int Provincia, int Localidad, string Domicilio, string Telefono, int Estrellas, string Obs, string Cuit, string Responsable, string Email_ope, string Email_Reservas, string Email_adm, string Email_Info, string CheckIn, string CheckOut, DateTime Fecha, string User, int Propio, int Social, decimal Late, int NroCuenta)
        {
            db resultado = new db();



            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(Nombre);
            vector_contenidos.Add(Provincia);
            vector_contenidos.Add(Localidad);
            vector_contenidos.Add(Domicilio);
            vector_contenidos.Add(Telefono);
            vector_contenidos.Add(Estrellas);
            vector_contenidos.Add(Obs);
            vector_contenidos.Add(Cuit);
            vector_contenidos.Add(Responsable);
            vector_contenidos.Add(Fecha);
            vector_contenidos.Add(User);
            vector_contenidos.Add(Email_ope);
            vector_contenidos.Add(Email_Reservas);
            vector_contenidos.Add(Email_adm);
            vector_contenidos.Add(Email_Info);
            vector_contenidos.Add(CheckIn);
            vector_contenidos.Add(CheckOut);
            vector_contenidos.Add(Propio);
            vector_contenidos.Add(Social);
            vector_contenidos.Add(Late);
            vector_contenidos.Add(NroCuenta);
            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@PROVINCIAID");
            vector_nombres.Add("@LOCALIDADID");
            vector_nombres.Add("@DOMICILIO");
            vector_nombres.Add("@TELEFONO");
            vector_nombres.Add("@ESTRELLAS");
            vector_nombres.Add("@OBSERVACIONES");
            vector_nombres.Add("@CUIT");
            vector_nombres.Add("@RESPONSABLE");
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@USR");
            vector_nombres.Add("@EMAIL_OPERACION");
            vector_nombres.Add("@EMAIL_RESERVAS");
            vector_nombres.Add("@EMAIL_ADM");
            vector_nombres.Add("@EMAIL_INFO");
            vector_nombres.Add("@CHECKIN");
            vector_nombres.Add("@CHECKOUT");
            vector_nombres.Add("@PROPIO");
            vector_nombres.Add("@SOCIAL");
            vector_nombres.Add("@LATE_CHK");
            vector_nombres.Add("@NRO_CUENTA");
            string vprocedure = "P_HOTEL_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);



        }
        //Delete Hoteles

        public void DeleteHotel(int ID)
        {

            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(ID);
            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add(VGlobales.vp_username);





            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");



            ArrayList vector_nombres = new ArrayList();



            vector_nombres.Add("@ID");

            vector_nombres.Add("@F_BAJA");
            vector_nombres.Add("@U_BAJA");
            string vprocedure = "P_HOTEL_B";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);












        }

        #endregion


        #endregion

        public void Seteo_Id_ROL(int ID, int ID_ROL)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(ID_ROL);
          





            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");



            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@ID_ROL");
         

            string vprocedure = "P_BONO_TURISMO_UPD_ID_ROL";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }




        #region Turismo


        public void InsertBonoTurismo(int NRO_SOCIO_TITULAR, int NRO_SOCIO, int NRO_DEP, int NRO_DEP_TITULAR, int BARRA, DateTime FE_BONO, int PROFESIONAL, int SEC_ACT, int TRAT, decimal SALDO_INICIAL, decimal SALDO_NETO, decimal INTERES, string NOMBRE, string APELLIDO, string DNI, string F_NACIM, string EDAD, string TELEFONO, string EMAIL, int AAR, int ACRJP1, int ACRJP2, int ACRJP3, int PAR, int PCRJP1, int PCRJP2, int PCRJP3, string OBS, string PAGO, int OPERADOR, string TIPO_PASAJE, string CLASE_PASAJE, string USR, string TIPO, int SALIDA, int DIAS, string HABITACION, int CONTRALOR, string ROL, int CODINT, int SUBCOD,string BONO_BLANCO,int DIRECTIVO,int BONO_FILIAL,string NRO_BONO_FILIAL,string NRO_FACTURA_FILIAL,string PUNTO_VENTA,int TIPO_HABITACION,int CANTIDAD_HABITACION,decimal EFECTIVO,decimal TARJETA_CREDITO,int CUOTAS_TARJETA,decimal TARJETA_DEBITO,decimal PLANILLA,int PLANILLA_CUOTAS,decimal TRANSFER)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(0);
            vector_contenidos.Add(NRO_SOCIO_TITULAR);
            vector_contenidos.Add(NRO_SOCIO);
            vector_contenidos.Add(NRO_DEP);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(FE_BONO);
            vector_contenidos.Add(PROFESIONAL);
            vector_contenidos.Add(SEC_ACT);
            vector_contenidos.Add(TRAT);
            vector_contenidos.Add(SALDO_INICIAL);
            vector_contenidos.Add(0);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(APELLIDO);
            vector_contenidos.Add(F_NACIM);
            vector_contenidos.Add(EDAD);
            vector_contenidos.Add(TELEFONO);
            vector_contenidos.Add(EMAIL);
            vector_contenidos.Add(AAR);
            vector_contenidos.Add(ACRJP1);
            vector_contenidos.Add(ACRJP2);
            vector_contenidos.Add(ACRJP3);
            vector_contenidos.Add(PAR);
            vector_contenidos.Add(PCRJP1);
            vector_contenidos.Add(PCRJP2);
            vector_contenidos.Add(PCRJP3);
            vector_contenidos.Add(NRO_DEP_TITULAR);
            vector_contenidos.Add(OBS);
            vector_contenidos.Add(PAGO);
            vector_contenidos.Add(OPERADOR);
            vector_contenidos.Add(TIPO_PASAJE);
            vector_contenidos.Add(CLASE_PASAJE);
            vector_contenidos.Add(USR);
            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(SALIDA);
            vector_contenidos.Add(DIAS);
            vector_contenidos.Add(HABITACION);
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(CONTRALOR);
            vector_contenidos.Add(SALDO_NETO);
            vector_contenidos.Add(INTERES);
            vector_contenidos.Add(ROL);
            vector_contenidos.Add(CODINT);
            vector_contenidos.Add(SUBCOD);
            vector_contenidos.Add(BONO_BLANCO);
            vector_contenidos.Add(DIRECTIVO);
            vector_contenidos.Add(BONO_FILIAL);
            vector_contenidos.Add(NRO_BONO_FILIAL);
            vector_contenidos.Add(TIPO_HABITACION);
            vector_contenidos.Add(CANTIDAD_HABITACION);
            vector_contenidos.Add(NRO_FACTURA_FILIAL);
            vector_contenidos.Add(PUNTO_VENTA);
            vector_contenidos.Add(EFECTIVO);
            vector_contenidos.Add(TARJETA_DEBITO);
            vector_contenidos.Add(TARJETA_CREDITO);
            vector_contenidos.Add(CUOTAS_TARJETA);
            vector_contenidos.Add(PLANILLA);
            vector_contenidos.Add(PLANILLA_CUOTAS);
            vector_contenidos.Add(TRANSFER);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@NRO_SOCIO_TITULAR");
            vector_nombres.Add("@NRO_SOCIO");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@FE_BONO");
            vector_nombres.Add("@PROFESIONAL");
            vector_nombres.Add("@SEC_ACT");
            vector_nombres.Add("@TRAT");
            vector_nombres.Add("@SALDO_INICIAL");
            vector_nombres.Add("@SALDO");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@F_NACIM");
            vector_nombres.Add("@EDAD");
            vector_nombres.Add("@TELEFONO");
            vector_nombres.Add("@EMAIL");
            vector_nombres.Add("@AAR");
            vector_nombres.Add("@ACRJP1");
            vector_nombres.Add("@ACRJP2");
            vector_nombres.Add("@ACRJP3");
            vector_nombres.Add("@PAR");
            vector_nombres.Add("@PCRJP1");
            vector_nombres.Add("@PCRJP2");
            vector_nombres.Add("@PCRJP3");
            vector_nombres.Add("@NRO_DEP_TITULAR");
            vector_nombres.Add("@OBS");
            vector_nombres.Add("@PAGO");
            vector_nombres.Add("@OPERADOR");
            vector_nombres.Add("@TIPO_PASAJE");
            vector_nombres.Add("@CLASE_PASAJE");
            vector_nombres.Add("@USR_ALTA");
            vector_nombres.Add("@FE_ALTA");
            vector_nombres.Add("@TIPO");
            vector_nombres.Add("@SALIDA");
            vector_nombres.Add("@DIAS");
            vector_nombres.Add("@HABITACION");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@CONTRALOR");
            vector_nombres.Add("@SALDO_NETO");
            vector_nombres.Add("@SALDO_INTERES");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@CODINT");
            vector_nombres.Add("@SUBCOD");
            vector_nombres.Add("@BONO_BLANCO");
            vector_nombres.Add("@COMISION_DIRECTIVA");
            vector_nombres.Add("@BONO_FILIAL");
            vector_nombres.Add("@NRO_BONO_FILIAL");
            
            vector_nombres.Add("@TIPO_HABITACION");
            vector_nombres.Add("@CANTIDAD_HABITACION");
            vector_nombres.Add("@NRO_FACTURA_FILIAL");
            vector_nombres.Add("@PUNTO_VENTA");
            
            vector_nombres.Add("@EFECTIVO");
            vector_nombres.Add("@DEBITO");
            vector_nombres.Add("@TARJETA");
            vector_nombres.Add("@TARJETA_CUOTAS");
            vector_nombres.Add("@PLANILLA");
            vector_nombres.Add("@PLANILLA_CUOTAS");
            vector_nombres.Add("@TRANSFER");

            string vprocedure = "P_BONO_TURISMO_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }


        public void UpdateBonoTurismo(int ID,int NRO_SOCIO_TITULAR, int NRO_SOCIO, int NRO_DEP, int NRO_DEP_TITULAR, int BARRA, DateTime FE_BONO, int PROFESIONAL, int SEC_ACT, int TRAT, decimal SALDO_INICIAL, decimal SALDO_NETO, decimal INTERES, string NOMBRE, string APELLIDO, string DNI, string F_NACIM, string EDAD, string TELEFONO, string EMAIL, int AAR, int ACRJP1, int ACRJP2, int ACRJP3, int PAR, int PCRJP1, int PCRJP2, int PCRJP3, string OBS, string PAGO, int OPERADOR, string TIPO_PASAJE, string CLASE_PASAJE, string USR, string TIPO, int SALIDA, int DIAS, string HABITACION, int CONTRALOR, string ROL, int CODINT, int SUBCOD, string BONO_BLANCO, int DIRECTIVO,int BONO_FILIAL,string NRO_BONO_FILIAL,string NRO_FACTURA_FILIAL,string PUNTO_VENTA,decimal EFECTIVO,decimal TARJETA_CREDITO,int CUOTAS_TARJETA,decimal TARJETA_DEBITO,decimal PLANILLA,int PLANILLA_CUOTAS)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(NRO_SOCIO_TITULAR);
            vector_contenidos.Add(NRO_SOCIO);
            vector_contenidos.Add(NRO_DEP);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(FE_BONO);
            vector_contenidos.Add(PROFESIONAL);
            vector_contenidos.Add(SEC_ACT);
            vector_contenidos.Add(TRAT);
            vector_contenidos.Add(SALDO_INICIAL);
            vector_contenidos.Add(0);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(APELLIDO);
            vector_contenidos.Add(F_NACIM);
            vector_contenidos.Add(EDAD);
            vector_contenidos.Add(TELEFONO);
            vector_contenidos.Add(EMAIL);
            vector_contenidos.Add(AAR);
            vector_contenidos.Add(ACRJP1);
            vector_contenidos.Add(ACRJP2);
            vector_contenidos.Add(ACRJP3);
            vector_contenidos.Add(PAR);
            vector_contenidos.Add(PCRJP1);
            vector_contenidos.Add(PCRJP2);
            vector_contenidos.Add(PCRJP3);
            vector_contenidos.Add(NRO_DEP_TITULAR);
            vector_contenidos.Add(OBS);
            vector_contenidos.Add(PAGO);
            vector_contenidos.Add(OPERADOR);
            vector_contenidos.Add(TIPO_PASAJE);
            vector_contenidos.Add(CLASE_PASAJE);
            vector_contenidos.Add(USR);
            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(SALIDA);
            vector_contenidos.Add(DIAS);
            vector_contenidos.Add(HABITACION);
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(CONTRALOR);
            vector_contenidos.Add(SALDO_NETO);
            vector_contenidos.Add(INTERES);
            vector_contenidos.Add(ROL);
            vector_contenidos.Add(CODINT);
            vector_contenidos.Add(SUBCOD);
            vector_contenidos.Add(BONO_BLANCO);
            vector_contenidos.Add(DIRECTIVO);
            vector_contenidos.Add(BONO_FILIAL);
            vector_contenidos.Add(NRO_BONO_FILIAL);
            vector_contenidos.Add(NRO_FACTURA_FILIAL);
            vector_contenidos.Add(PUNTO_VENTA);
            vector_contenidos.Add(EFECTIVO);
            vector_contenidos.Add(TARJETA_DEBITO);
            vector_contenidos.Add(TARJETA_CREDITO);
            vector_contenidos.Add(CUOTAS_TARJETA);
            vector_contenidos.Add(PLANILLA);
            vector_contenidos.Add(PLANILLA_CUOTAS);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@PIN_ID");
            vector_nombres.Add("@PIN_NRO_SOCIO_TITULAR");
            vector_nombres.Add("@PIN_NRO_SOCIO");
            vector_nombres.Add("@PIN_NRO_DEP");
            vector_nombres.Add("@PIN_PIN_BARRA");
            vector_nombres.Add("@PIN_FE_BONO");
            vector_nombres.Add("@PIN_PROFESIONAL");
            vector_nombres.Add("@PIN_SEC_ACT");
            vector_nombres.Add("@PIN_TRAT");
            vector_nombres.Add("@PIN_SALDO_INICIAL");
            vector_nombres.Add("@PIN_SALDO");
            vector_nombres.Add("@PIN_NOMBRE");
            vector_nombres.Add("@PIN_APELLIDO");
            vector_nombres.Add("@PIN_F_NACIM");
            vector_nombres.Add("@PIN_EDAD");
            vector_nombres.Add("@PIN_TELEFONO");
            vector_nombres.Add("@PIN_EMAIL");
            vector_nombres.Add("@PIN_AAR");
            vector_nombres.Add("@PIN_ACRJP1");
            vector_nombres.Add("@PIN_ACRJP2");
            vector_nombres.Add("@PIN_ACRJP3");
            vector_nombres.Add("@PIN_PAR");
            vector_nombres.Add("@PIN_PCRJP1");
            vector_nombres.Add("@PIN_PCRJP2");
            vector_nombres.Add("@PIN_PCRJP3");
            vector_nombres.Add("@PIN_NRO_DEP_TITULAR");
            vector_nombres.Add("@PIN_OBS");
            vector_nombres.Add("@PIN_PAGO");
            vector_nombres.Add("@PIN_OPERADOR");
            vector_nombres.Add("@PIN_TIPO_PASAJE");
            vector_nombres.Add("@PIN_CLASE_PASAJE");
            vector_nombres.Add("@PIN_USR_MODIFICACION");
            vector_nombres.Add("@PIN_FE_MODIFICACION");
            vector_nombres.Add("@PIN_TIPO");
            vector_nombres.Add("@PIN_SALIDA");
            vector_nombres.Add("@PIN_DIAS");
            vector_nombres.Add("@PIN_HABITACION");
            vector_nombres.Add("@PIN_DNI");
            vector_nombres.Add("@PIN_CONTRALOR");
            vector_nombres.Add("@PIN_SALDO_NETO");
            vector_nombres.Add("@PIN_SALDO_INTERES");
            vector_nombres.Add("@PIN_ROL");
            vector_nombres.Add("@PIN_CODINT");
            vector_nombres.Add("@PIN_SUBCOD");
            vector_nombres.Add("@PIN_BONO_BLANCO");
            vector_nombres.Add("@PIN_COMISION_DIRECTIVA");
            vector_nombres.Add("@PIN_NRO_BONO_FILIAL");
            vector_nombres.Add("@PIN_BONO_FILIAL");
            vector_nombres.Add("@PIN_NRO_FACTURA_FILIAL");
            vector_nombres.Add("@PIN_PUNTO_VENTA");

            vector_nombres.Add("@PIN_EFECTIVO");
            vector_nombres.Add("@PIN_DEBITO");
            vector_nombres.Add("@PIN_TARJETA");
            vector_nombres.Add("@PIN_TARJETA_CUOTAS");
            vector_nombres.Add("@PIN_PLANILLA");
            vector_nombres.Add("@PIN_PLANILLA_CUOTAS");


            string vprocedure = "P_BONO_TURISMO_U";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        public void UpdateBonoTurismo2(int ID, int NRO_SOCIO_TITULAR, int NRO_SOCIO, int NRO_DEP, int NRO_DEP_TITULAR, int BARRA, DateTime FE_BONO, int PROFESIONAL, int SEC_ACT, int TRAT, decimal SALDO_INICIAL, decimal SALDO_NETO, decimal INTERES, string NOMBRE, string APELLIDO, string DNI, string F_NACIM, string EDAD, string TELEFONO, string EMAIL, int AAR, int ACRJP1, int ACRJP2, int ACRJP3, int PAR, int PCRJP1, int PCRJP2, int PCRJP3, string OBS, string PAGO, int OPERADOR, string TIPO_PASAJE, string CLASE_PASAJE, string USR, string TIPO, int SALIDA, int DIAS, string HABITACION, int CONTRALOR, string ROL, int CODINT, int SUBCOD, string BONO_BLANCO, int DIRECTIVO, int BONO_FILIAL, string NRO_BONO_FILIAL, string NRO_FACTURA_FILIAL, string PUNTO_VENTA, decimal EFECTIVO, decimal TARJETA_CREDITO, int CUOTAS_TARJETA, decimal TARJETA_DEBITO, decimal PLANILLA, int PLANILLA_CUOTAS)
        {

            

            string Query = @"UPDATE BONO_TURISMO SET
    NRO_SOCIO_TITULAR = {0},NRO_SOCIO = {1},NRO_DEP = {2}, BARRA = {3},FE_BONO= '{4}', PROFESIONAL = {5},SEC_ACT= {5},TRAT= {6},SALDO_INICIAL= {7},
    SALDO             = {8},NOMBRE = '{9}', APELLIDO  = '{10}',F_NACIM   = '{11}', EDAD   = '{12}',TELEFONO   = '{13}',
    EMAIL             = '{14}', AAR  = {15},ACRJP1    = {16},ACRJP2    = {17}, ACRJP3  = {18},
    PAR               = {19}, PCRJP1  = {20}, PCRJP2     = {21},  PCRJP3  = {22}, NRO_DEP_TITULAR   = {23},
    OBS               = '{24}', PAGO    = '{25}', OPERADOR   = {26},  TIPO_PASAJE  = '{27}',CLASE_PASAJE  = '{28}',
    USR_MODIFICACION  = '{29}',   FE_MODIFICACION   ='{30}',  TIPO   = '{31}', SALIDA   = {32}, DIAS     = {33},
    HABITACION        = '{34}',   DNI               = '{35}',  CONTRALOR         = {36}, SALDO_NETO        = {37},
    SALDO_INTERES     = {38},   ROL               = '{39}',  CODINT            = {40}, BONO_BLANCO       = '{41}',
    COMISION_DIRECTIVA= {42},   BONO_FILIAL       = {43},  NRO_BONO_FILIAL   = {44}, PUNTO_VENTA       = '{45}',
    NRO_FACTURA_FILIAL= '{46}',   EFECTIVO          = {47},  TARJETA_DEBITO    = {48}, TARJETA_CREDITO   = {49},
    TARJETA_CREDITO_CUOTAS ={51},   PLANILLA      ={51},   PLANILLA_CUOTAS        ={52}    
  WHERE    ID = {53}";

           Query= Query.Replace("{0}", NRO_SOCIO_TITULAR.ToString());
           Query = Query.Replace("{1}", NRO_SOCIO.ToString());
           Query = Query.Replace("{2}", NRO_DEP.ToString());
           Query = Query.Replace("{3}", BARRA.ToString());
           
         //  

           // Query.Replace("{4}", BARRA.ToString());
           Query = Query.Replace("{4}", FE_BONO.ToShortDateString());

           Query = Query.Replace("{5}", PROFESIONAL.ToString());
           Query = Query.Replace("{6}", SEC_ACT.ToString());
           Query = Query.Replace("{7}", TRAT.ToString());
           Query = Query.Replace("{8}", SALDO_INICIAL.ToString());


           Query = Query.Replace("{9}", NOMBRE.ToString());
           Query = Query.Replace("{10}", APELLIDO.ToString());
           Query = Query.Replace("{11}", F_NACIM.ToString());
           Query = Query.Replace("{12}", EDAD.ToString());
           Query = Query.Replace("{13}", TELEFONO.ToString());
           Query = Query.Replace("{14}", EMAIL.ToString());
           Query = Query.Replace("{15}", AAR.ToString());
           Query = Query.Replace("{16}", ACRJP1.ToString());
           Query = Query.Replace("{17}", ACRJP2.ToString());
           Query = Query.Replace("{18}", ACRJP3.ToString());
           Query = Query.Replace("{19}", PAR.ToString());
           Query = Query.Replace("{20}", PCRJP1.ToString());
           Query = Query.Replace("{21}", PCRJP2.ToString());
           Query = Query.Replace("{22}", PCRJP3.ToString());
           Query = Query.Replace("{23}", NRO_DEP_TITULAR.ToString());
           Query = Query.Replace("{24}", OBS.ToString());

           Query = Query.Replace("{25}", PAGO.ToString());
           Query = Query.Replace("{26}", OPERADOR.ToString());
           Query = Query.Replace("{27}", TIPO_PASAJE.ToString());

           Query = Query.Replace("{28}", CLASE_PASAJE.ToString());
           Query = Query.Replace("{29}", USR.ToString());
           Query = Query.Replace("{30}", System.DateTime.Now.ToShortDateString());
           Query = Query.Replace("{31}", TIPO.ToString());
           Query = Query.Replace("{32}", SALIDA.ToString());
           Query = Query.Replace("{33}", DIAS.ToString());
           Query = Query.Replace("{34}", HABITACION.ToString());
           Query = Query.Replace("{35}", DNI.ToString());
           Query = Query.Replace("{36}", CONTRALOR.ToString());
           Query = Query.Replace("{37}", SALDO_NETO.ToString());

           Query = Query.Replace("{38}", INTERES.ToString());
           Query = Query.Replace("{39}", ROL.ToString());
           Query = Query.Replace("{40}", CODINT.ToString());
           Query = Query.Replace("{41}", BONO_BLANCO.ToString());
           Query = Query.Replace("{42}", DIRECTIVO.ToString());
           Query = Query.Replace("{43}", BONO_FILIAL.ToString());
           if (NRO_BONO_FILIAL.Length>0)
               Query = Query.Replace("{44}", NRO_BONO_FILIAL.ToString());
           else
               Query = Query.Replace("{44}", "0" );

           Query = Query.Replace("{45}", PUNTO_VENTA.ToString());
           Query = Query.Replace("{46}", NRO_FACTURA_FILIAL.ToString());

           Query = Query.Replace("{47}", EFECTIVO.ToString());
           Query = Query.Replace("{48}", TARJETA_DEBITO.ToString());
           Query = Query.Replace("{49}", TARJETA_CREDITO.ToString());
           Query = Query.Replace("{50}", CUOTAS_TARJETA.ToString());

           Query = Query.Replace("{51}", PLANILLA.ToString());
           Query = Query.Replace("{52}", PLANILLA_CUOTAS.ToString());


           Query = Query.Replace("{53}", ID.ToString());
            BO_EjecutoDataTable(Query);
        }


        public void Voucher_HOTEL_Insert(int BONO, DateTime Desde, DateTime Hasta, int Hotel, int Noches, int Pasajeros, int Regimen, int Habitacion, string Nro_Habitacion, string Tipo, string Motivo, string Late,string IN)
        {

            try
            {
                db resultado = new db();


                ArrayList vector_contenidos = new ArrayList();
                vector_contenidos.Add(BONO);
                vector_contenidos.Add(Desde);
                vector_contenidos.Add(Hasta);
                vector_contenidos.Add(Hotel);
                vector_contenidos.Add(Noches);
                vector_contenidos.Add(Pasajeros);
                vector_contenidos.Add(Regimen);
                vector_contenidos.Add(Habitacion);
                vector_contenidos.Add(System.DateTime.Now);
                vector_contenidos.Add(VGlobales.vp_username);
                vector_contenidos.Add(Nro_Habitacion);
                vector_contenidos.Add(Tipo);
                vector_contenidos.Add(Motivo);
                vector_contenidos.Add(Late);
                vector_contenidos.Add(IN);
                ArrayList vector_tipos = new ArrayList();

                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Varchar");
                vector_tipos.Add("FbDbType.Varchar");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");

                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");

                vector_tipos.Add("FbDbType.Varchar");
                vector_tipos.Add("FbDbType.Varchar");
                vector_tipos.Add("FbDbType.Varchar");
                vector_tipos.Add("FbDbType.Varchar");
                vector_tipos.Add("FbDbType.Varchar");
                vector_tipos.Add("FbDbType.Varchar");
                vector_tipos.Add("FbDbType.Varchar");

                ArrayList vector_nombres = new ArrayList();

                vector_nombres.Add("@BONO");
                vector_nombres.Add("@DESDE");
                vector_nombres.Add("@HASTA");
                vector_nombres.Add("@HOTEL");
                vector_nombres.Add("@NOCHES");
                vector_nombres.Add("@PASAJEROS");

                vector_nombres.Add("@REGIMEN");
                vector_nombres.Add("@TIPO_HABITACION");

                vector_nombres.Add("@F_ALTA");
                vector_nombres.Add("@U_ALTA");
                vector_nombres.Add("@NRO_HABITACION");
                vector_nombres.Add("@TIPO");
                vector_nombres.Add("@MOTIVO");
                vector_nombres.Add("@LATE_CHK");
                vector_nombres.Add("@LATE_IN");

                string vprocedure = "P_VOUCHER_BONO_HOTEL_I";

                resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion



    }
}
