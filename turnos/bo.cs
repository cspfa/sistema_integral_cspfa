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

//ANDRES
namespace SOCIOS
{
    public class bo
    {
        private db datDatos;

        public bo()
        {
            datDatos = new db(this);
        }

        public DataSet BO_EjecutoDataSet(string query)
        {
            DataSet ds1 = null;
            ds1 = datDatos.EjecutoDataSet(query);
            return ds1;
        }

        public DataTable BO_EjecutoDataTable(string query)
        {
            DataTable dt1 = null;
            dt1 = datDatos.EjecutoDataTable(query);
            return dt1;
        }

        public DataTable BO_EjecutoDataTable_Remota(string query, string ROL)
        {
            DataTable dt1 = null;
            dt1 = datDatos.EjecutoDataTable_Remota(query, ROL);
            return dt1;
        }

        //STORED RESTABLECE ADH INTERFUERZAS A TITULAR
        public void restablecer994(int ID_TITULAR, int COD_DTO, string CAT_SOC, int NRO_SOC, int NRO_DEP, int ID_ADH)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_TITULAR);
            vector_contenidos.Add(COD_DTO);
            vector_contenidos.Add(CAT_SOC);
            vector_contenidos.Add(NRO_SOC);
            vector_contenidos.Add(NRO_DEP);
            vector_contenidos.Add(ID_ADH);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID_TITULAR");
            vector_nombres.Add("@COD_DTO");
            vector_nombres.Add("@CAT_SOC");
            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@ID_ADH");

            string vprocedure = "A_RESTABLECER_994";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }


        //STORED BAJA DE TEMP_PA
        public void bajaTempPa(int PERSONA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(PERSONA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@PERSONA");

            string vprocedure = "TEMP_PA_D ";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }
        //STORED BAJA DE PERSONA
        public void bajaPersona(int PERSONA, int ESTADO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(PERSONA);
            vector_contenidos.Add(ESTADO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@PERSONA");
            vector_nombres.Add("@ESTADO");

            string vprocedure = "PERSONAS_B";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ALTA DE TEMP_PA
        public void altaTempPa(int PERSONA, int PA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(PERSONA);
            vector_contenidos.Add(PA);
            
            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@PERSONA");
            vector_nombres.Add("@PA");

            string vprocedure = "TEMP_PA_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ALTA DE PERSONA PARA INGRESOS
        public void altaPersonaIngresos(string NOMBRE, int ESCALAFON, int CARGO, int ESTADO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(ESCALAFON);
            vector_contenidos.Add(CARGO);
            vector_contenidos.Add(ESTADO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@ESCALAFON");
            vector_nombres.Add("@CARGO");
            vector_nombres.Add("@ESTADO");

            string vprocedure = "PERSONAS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }
        
        

        //STORED ACTUALIZA ID EMPLEADO EN TITULAR
        public void idEmpleado(string ID_EMPLEADO, string COD_CIUDAD, string TRASPASADO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_EMPLEADO);
            vector_contenidos.Add(COD_CIUDAD);
            vector_contenidos.Add(TRASPASADO);
            
            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID_EMPLEADO");
            vector_nombres.Add("@COD_CIUDAD");
            vector_nombres.Add("@TRASPASADO");
            
            string vprocedure = "ID_EMPLEADO_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        public void Entrada_Campo_Ins(string DNI, string NOMBRE, string APELLIDO, int NRO_SOCIO, int NRO_DEP, string TIPO, int INVITADO, decimal INVITADO_MONTO, int INVITADO_PILETA, decimal INVITADO_PILETA_MONTO, int INVITADO_EST, decimal INVITADO_EST_MONTO, int SOCIO, decimal SOCIO_MONTO, int SOCIO_PILETA, decimal SOCIO_PILETA_MONTO, int SOCIO_EST, decimal SOCIO_EST_MONTO, int INT, decimal INT_MONTO, int INT_PILETA, decimal INT_PILETA_MONTO, int INT_EST, decimal INT_EST_MONTO, int CANTIDAD, decimal MONTO_TOTAL, DateTime FECHA, string ROL, string USUARIO, int MENOR, int DISCA, int DISCA_ACOM, int ID_ROL, string TIPO_REG)
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





            string vprocedure = "P_ENTRADA_CAMPO_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }




        public void Entrada_Campo_Marca(int ID)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            ArrayList vector_tipos = new ArrayList();

            vector_contenidos.Add(ID);
            vector_tipos.Add("FbDbType.Integer");
            vector_nombres.Add("@ID");







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







            string vprocedure = "P_ENTRADA_CAMPO_ANULAR";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }


        public void Bono_Turno_Ins(int BONO, int TURNO, string DETALLE)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(TURNO);
            vector_contenidos.Add(BONO);
            vector_contenidos.Add(DETALLE);



            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.VarChar");




            ArrayList vector_nombres = new ArrayList();


            vector_nombres.Add("@TURNO");
            vector_nombres.Add("@BONO");
            vector_nombres.Add("@DETALLE");


            string vprocedure = "P_TURNO_BONO_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        //STORED MODIFICAR TIPO DE COMANDA CONFITERIA
        public void modificarTipoDeComanda(int ID_COMANDA, int TIPO_DE_COMANDA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_COMANDA);
            vector_contenidos.Add(TIPO_DE_COMANDA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID_COMANDA");
            vector_nombres.Add("@TIPO_DE_COMANDA");

            string vprocedure = "CONFITERIA_MOD_TIPO_COMANDA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR FORMA DE PAGO CONFITERIA
        public void confiteriaModificarPago(int ID_COMANDA, int FORMA_DE_PAGO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_COMANDA);
            vector_contenidos.Add(FORMA_DE_PAGO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID_COMANDA");
            vector_nombres.Add("@FORMA_DE_PAGO");

            string vprocedure = "CONFITERIA_MOD_FORMA_PAGO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDA CAJA DIARIA CONFITERIA
        public void confiteriaCajaDiaria(string FECHA, string USUARIO, decimal EFECTIVO, decimal TARJETAS, decimal DESCUENTO, decimal ESPECIALES)
        {
            db resultado = new db();
            
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(USUARIO);
            vector_contenidos.Add(EFECTIVO);
            vector_contenidos.Add(TARJETAS);
            vector_contenidos.Add(DESCUENTO);
            vector_contenidos.Add(ESPECIALES);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@USUARIO");
            vector_nombres.Add("@EFECTIVO");
            vector_nombres.Add("@TARJETAS");
            vector_nombres.Add("@DESCUENTO");
            vector_nombres.Add("@ESPECIALES");

            string vprocedure = "CONFITERIA_CAJA_DIARIA_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED DAR INGRESO DESDE BUSQUEDA SOCIO //ANDRES
        public void Inserto_Ingreso(string vapellido, string vnombre, string vtipo, string vrol, string vdestino, string id_destino, string nro_soc, string nro_dep,
            string nro_adh, string nro_depadh, string barra, int dni, string vcod_dto, string vid_profesional, string egreso, string usuario, int GRUPO,
            decimal IMPORTE, int NRO_PAGO, string FECHA_INGRESO, string MC)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(vapellido.TrimEnd());
            vector_contenidos.Add(vnombre.TrimEnd());
            vector_contenidos.Add(vtipo.TrimEnd());
            vector_contenidos.Add(vrol.TrimEnd());
            vector_contenidos.Add(vdestino.TrimEnd());
            vector_contenidos.Add(id_destino.TrimEnd());
            vector_contenidos.Add((nro_soc == "" ? 0 : (int?)(System.Convert.ToInt32(nro_soc))));
            vector_contenidos.Add((nro_dep == "" ? 0 : (int?)(System.Convert.ToInt32(nro_dep))));
            vector_contenidos.Add((nro_adh == "" ? 0 : (int?)(System.Convert.ToInt32(nro_adh))));
            vector_contenidos.Add((nro_depadh == "" ? 0 : (int?)(System.Convert.ToInt32(nro_depadh))));
            vector_contenidos.Add((barra == "" ? 0 : (int?)(System.Convert.ToInt32(barra))));
            vector_contenidos.Add(dni);
            vector_contenidos.Add(vcod_dto.TrimEnd());

            if (vid_profesional.TrimEnd() == "0")
            {
                vid_profesional = "33";
            }

            if (vid_profesional.TrimEnd() == "")
            {
                vid_profesional = "33";
            }

            if (vid_profesional.TrimEnd() == id_destino.TrimEnd())
            {
                vid_profesional = "33";
            }

            vector_contenidos.Add((vid_profesional == "" ? 0 : (int?)(System.Convert.ToInt32(vid_profesional))));
            vector_contenidos.Add(egreso);
            vector_contenidos.Add(usuario);
            vector_contenidos.Add(GRUPO);
            vector_contenidos.Add(IMPORTE);
            vector_contenidos.Add(NRO_PAGO);
            vector_contenidos.Add(FECHA_INGRESO);
            vector_contenidos.Add(MC);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDBType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDBType.Integer");
            vector_tipos.Add("FbDBType.Numeric");
            vector_tipos.Add("FbDBType.Integer");
            vector_tipos.Add("FbDBType.Timestamp");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@TIPO");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@DESTINO");
            vector_nombres.Add("@ID_DESTINO");
            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@NRO_ADH");
            vector_nombres.Add("@NRO_DEPADH");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@COD_DTO");
            vector_nombres.Add("@ID_PROFESIONAL");
            vector_nombres.Add("@EGRESO");
            vector_nombres.Add("@USUARIO");
            vector_nombres.Add("@GRUPO");
            vector_nombres.Add("@IMPORTE");
            vector_nombres.Add("@NRO_PAGO");
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@MC");

            string vprocedure;

            vprocedure = "P_INGRESOS_A_PROCESAR_I2";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        //STORED DAR INGRESO DESDE BUSQUEDA SOCIO //SEBASTIAN
        public void Inserto_Ingreso(string vapellido, string vnombre, string vtipo, string vrol, string vdestino, string id_destino, string nro_soc, string nro_dep,
             string nro_adh, string nro_depadh, string barra, int dni, string vcod_dto, string vid_profesional, string egreso, string usuario, int GRUPO,
             decimal IMPORTE, int NRO_PAGO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(vapellido.TrimEnd());
            vector_contenidos.Add(vnombre.TrimEnd());
            vector_contenidos.Add(vtipo.TrimEnd());
            vector_contenidos.Add(vrol.TrimEnd());
            vector_contenidos.Add(vdestino.TrimEnd());
            vector_contenidos.Add(id_destino.TrimEnd());
            vector_contenidos.Add((nro_soc == "" ? 0 : (int?)(System.Convert.ToInt32(nro_soc))));
            vector_contenidos.Add((nro_dep == "" ? 0 : (int?)(System.Convert.ToInt32(nro_dep))));
            vector_contenidos.Add((nro_adh == "" ? 0 : (int?)(System.Convert.ToInt32(nro_adh))));
            vector_contenidos.Add((nro_depadh == "" ? 0 : (int?)(System.Convert.ToInt32(nro_depadh))));
            vector_contenidos.Add((barra == "" ? 0 : (int?)(System.Convert.ToInt32(barra))));
            vector_contenidos.Add(dni);
            vector_contenidos.Add(vcod_dto.TrimEnd());



            if (vid_profesional.TrimEnd() == "0")
            {
                vid_profesional = "33";
            }

            if (vid_profesional.TrimEnd() == "")
            {
                vid_profesional = "33";
            }

            if (vid_profesional.TrimEnd() == id_destino.TrimEnd())
            {
                vid_profesional = "33";
            }

            vector_contenidos.Add((vid_profesional == "" ? 0 : (int?)(System.Convert.ToInt32(vid_profesional))));
            vector_contenidos.Add(egreso);
            vector_contenidos.Add(usuario);
            vector_contenidos.Add(GRUPO);
            vector_contenidos.Add(IMPORTE);
            vector_contenidos.Add(NRO_PAGO);
            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add("0");

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDBType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDBType.Integer");
            vector_tipos.Add("FbDBType.Numeric");
            vector_tipos.Add("FbDBType.Integer");
            vector_tipos.Add("FbDBType.Timestamp");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@TIPO");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@DESTINO");
            vector_nombres.Add("@ID_DESTINO");
            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@NRO_ADH");
            vector_nombres.Add("@NRO_DEPADH");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@COD_DTO");
            vector_nombres.Add("@ID_PROFESIONAL");
            vector_nombres.Add("@EGRESO");
            vector_nombres.Add("@USUARIO");
            vector_nombres.Add("@GRUPO");
            vector_nombres.Add("@IMPORTE");
            vector_nombres.Add("@NRO_PAGO");
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@MC");
            string vprocedure;

            vprocedure = "P_INGRESOS_A_PROCESAR_I2";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }


        //RENDIDA EN COMANDAS
        public void rendidaEnComandas(int ID_COMANDA, int CAJA_DIARIA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_COMANDA);
            vector_contenidos.Add(CAJA_DIARIA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@RENDIDA");

            string vprocedure = "CONFITERIA_COMANDAS_RENDIDA";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //ANULACION SOLICITUD DE DESCUENTO
        public void anularSolicitud(int ID, string ANULADA, string USUARIO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(ANULADA);
            vector_contenidos.Add(USUARIO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Timestamp");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@ANULADA");
            vector_nombres.Add("@USUARIO");

            string vprocedure = "CONFITERIA_SOL_DESC_ANULAR";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //ANULACION COMANDA CONFITERIA
        public void anularComandaComedor(int ID, string ANULADA, string USUARIO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(ANULADA);
            vector_contenidos.Add(USUARIO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Timestamp");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@ANULADA");
            vector_nombres.Add("@USUARIO");

            string vprocedure = "CONFITERIA_COMANDAS_ANULAR";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //TXT ACTIVOS
        public void Txt_Activo_I(int Mes, int Anio, string ACRJP2, int CODINT, string TIPO, decimal MONTO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Mes);
            vector_contenidos.Add(Anio);
            vector_contenidos.Add(ACRJP2);
            vector_contenidos.Add(CODINT);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(MONTO);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add(VGlobales.vp_role);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@MES");
            vector_nombres.Add("@ANIO");
            vector_nombres.Add("@ACRPJ2");
            vector_nombres.Add("@COD_INT");
            vector_nombres.Add("@TIPO");
            vector_nombres.Add("@MONTO");
            vector_nombres.Add("@USR_A");
            vector_nombres.Add("@FECHA_A");
            vector_nombres.Add("@ROL");

            string vprocedure = "P_TXT_ACTIVOS_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //TXT PASIVOS
        public void Txt_Pasivo_I(int Mes, int Anio, int PCRJP1, string PCRJP2, int PCRJP3, int CODINT, string TIPO, decimal MONTO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Mes);
            vector_contenidos.Add(Anio);
            vector_contenidos.Add(PCRJP1);
            vector_contenidos.Add(PCRJP2);
            vector_contenidos.Add(PCRJP3);
            vector_contenidos.Add(MONTO);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(CODINT);
            vector_contenidos.Add(VGlobales.vp_role);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@MES");
            vector_nombres.Add("@ANIO");
            vector_nombres.Add("@PCRJP1");
            vector_nombres.Add("@PCRJP2");
            vector_nombres.Add("@PCRJP3");
            vector_nombres.Add("@MONTO");
            vector_nombres.Add("@TIPO");
            vector_nombres.Add("@CODINT");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@USR_A");
            vector_nombres.Add("@FECHA_A");

            string vprocedure = "P_TXT_PASIVOS_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //ALTA RETENCION 
        public void altaRetencion(string NUM_CERT, string FECHA, decimal IMPORTE, decimal RETENCION, int IMPUESTO, int REGIMEN, int OP, string US_ALTA, string FE_ALTA)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(NUM_CERT);
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(IMPORTE);
            vector_contenidos.Add(RETENCION);
            vector_contenidos.Add(IMPUESTO);
            vector_contenidos.Add(REGIMEN);
            vector_contenidos.Add(OP);
            vector_contenidos.Add(US_ALTA);
            vector_contenidos.Add(FE_ALTA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@NUM_CERT");
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@IMPORTE");
            vector_nombres.Add("@RETENCION");
            vector_nombres.Add("@REGIMEN");
            vector_nombres.Add("@OP");
            vector_nombres.Add("@US_ALTA");
            vector_nombres.Add("@FE_ALTA");

            string vprocedure = "RETENCIONES_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //MODIFICA CBU SOCIO DATOS BANCARIOS
        public void modificaCbuSocios(int IDTITULAR, int SECUENCIA, string CBU, string ALTA, string CODIGO, string BAJA, string TC, string BANCO, string VENCIMIENTO, string TIPO_TARJETA)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(IDTITULAR);
            vector_contenidos.Add(SECUENCIA);
            vector_contenidos.Add(CBU);
            vector_contenidos.Add(ALTA);
            vector_contenidos.Add(CODIGO);
            vector_contenidos.Add(BAJA);
            vector_contenidos.Add(TC);
            vector_contenidos.Add(BANCO);
            vector_contenidos.Add(VENCIMIENTO);
            vector_contenidos.Add(TIPO_TARJETA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID_TITULAR");
            vector_nombres.Add("@SECUENCIA");
            vector_nombres.Add("@CBU");
            vector_nombres.Add("@FE_ALTA");
            vector_nombres.Add("@CODIGO");
            vector_nombres.Add("@FE_BAJA");
            vector_nombres.Add("@TC");
            vector_nombres.Add("@BANCO");
            vector_nombres.Add("@VENCE");
            vector_nombres.Add("@TIPO_TARJETA");

            string vprocedure = "P_MODI_TITULAR_CBU";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //ALTA CBU SOCIO DATOS BANCARIOS
        public void altaCbuSocios(int IDTITULAR, int SECUENCIA, string CBU, string ALTA, string CODIGO, string BAJA, string TC, string BANCO, string VENCIMIENTO, string ID_ADHERENTE, string ID_FAMILIAR, string TIPO_TARJETA)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(IDTITULAR);
            vector_contenidos.Add(SECUENCIA);
            vector_contenidos.Add(CBU);
            vector_contenidos.Add(ALTA);
            vector_contenidos.Add(CODIGO);
            vector_contenidos.Add(BAJA);
            vector_contenidos.Add(TC);
            vector_contenidos.Add(BANCO);
            vector_contenidos.Add(VENCIMIENTO);
            vector_contenidos.Add(ID_ADHERENTE);
            vector_contenidos.Add(ID_FAMILIAR);
            vector_contenidos.Add(TIPO_TARJETA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID_TITULAR");
            vector_nombres.Add("@SECUENCIA");
            vector_nombres.Add("@CBU");
            vector_nombres.Add("@FE_ALTA");
            vector_nombres.Add("@CODIGO");
            vector_nombres.Add("@FE_BAJA");
            vector_nombres.Add("@TC");
            vector_nombres.Add("@BANCO");
            vector_nombres.Add("@VENCE");
            vector_nombres.Add("@ID_ADHERENTE");
            vector_nombres.Add("@ID_FAMILIAR");
            vector_nombres.Add("@TIPO_TARJETA");

            string vprocedure = "P_ALTA_TITULAR_CBU";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //ALTA TRANSFERENCIA
        public void altaTransferencia(int BANCO_ORIGEN, int CUENTA_ORIGEN, int CHEQUE, int PROVEEDOR, int CUENTA_DESTINO, decimal IMPORTE, string US_ALTA, string FE_ALTA, string FECHA, int ID_OP)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(BANCO_ORIGEN);
            vector_contenidos.Add(CUENTA_ORIGEN);
            vector_contenidos.Add(CHEQUE);
            vector_contenidos.Add(PROVEEDOR);
            vector_contenidos.Add(CUENTA_DESTINO);
            vector_contenidos.Add(IMPORTE);
            vector_contenidos.Add(US_ALTA);
            vector_contenidos.Add(FE_ALTA);
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(ID_OP);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@BANCO_ORIGEN");
            vector_nombres.Add("@CUENTA_ORIGEN");
            vector_nombres.Add("@CHEQUE");
            vector_nombres.Add("@PROVEEDOR");
            vector_nombres.Add("@CUENTA_DESTINO");
            vector_nombres.Add("@IMPORTE");
            vector_nombres.Add("@US_ALTA");
            vector_nombres.Add("@FE_ALTA");
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@OP");

            string vprocedure = "TRANSFERENCIAS_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }


        //BAJA CUENTA BANCARIA
        public void bajaCuentaBancaria(int ID, string US_BAJA, string FE_BAJA)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(US_BAJA);
            vector_contenidos.Add(FE_BAJA);
            
            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@US_BAJA");
            vector_nombres.Add("@FE_BAJA");

            string vprocedure = "CUENTAS_BANCARIAS_B";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //MODIFICAR CUENTA BANCARIA
        public void modificarCuentaBancaria(int ID, int BANCO, string CUENTA, int TIPO, string CBU, string SUCURSAL, int PROVEEDOR)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(BANCO);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(CUENTA);
            vector_contenidos.Add(CBU);
            vector_contenidos.Add(SUCURSAL);
            vector_contenidos.Add(PROVEEDOR);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@BANCO");
            vector_nombres.Add("@TIPO_CUENTA");
            vector_nombres.Add("@NRO_CUENTA");
            vector_nombres.Add("@CBU");
            vector_nombres.Add("@SUCURSAL");
            vector_nombres.Add("@PROVEEDOR");

            string vprocedure = "CUENTAS_BANCARIAS_U";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //ALTA CUENTA BANCARIA
        public void altaCuentaBancaria(int BANCO, string CUENTA, int TIPO, string US_ALTA, string FE_ALTA, string CBU, string SUCURSAL, int PROVEEDOR)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(BANCO);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(CUENTA);
            vector_contenidos.Add(US_ALTA);
            vector_contenidos.Add(FE_ALTA);
            vector_contenidos.Add(CBU);
            vector_contenidos.Add(SUCURSAL);
            vector_contenidos.Add(PROVEEDOR);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@BANCO");
            vector_nombres.Add("@TIPO_CUENTA");
            vector_nombres.Add("@NRO_CUENTA");
            vector_nombres.Add("@US_ALTA");
            vector_nombres.Add("@FE_ALTA");
            vector_nombres.Add("@CBU");
            vector_nombres.Add("@SUCURSAL");
            vector_nombres.Add("@PROVEEDOR");

            string vprocedure = "CUENTAS_BANCARIAS_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //BAJA BANCO
        public void bajaBanco(int ID, string US_BAJA, string FE_BAJA)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(US_BAJA);
            vector_contenidos.Add(FE_BAJA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@US_BAJA");
            vector_nombres.Add("@FE_BAJA");

            string vprocedure = "BANCOS_B";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //MODIFICAR BANCO
        public void modificarBanco(int ID, string BANCO)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(BANCO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            
            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@BANCO");
            
            string vprocedure = "BANCOS_U";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //CARGA NUEVO BANCO 
        public void nuevoBanco(string BANCO, string US_ALTA, string FE_ALTA)
        {
            db resultado = new db();
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(BANCO);
            vector_contenidos.Add(US_ALTA);
            vector_contenidos.Add(FE_ALTA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@BANCO");
            vector_nombres.Add("@US_ALTA");
            vector_nombres.Add("@FE_ALTA");

            string vprocedure = "BANCOS_I";
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


        //STORED CARGAR OCUPACION HOTEL
        public void HABITACION_HOTEL_OCUPACION_I(DateTime Fecha, int Nro_Soc, int Nro_Dep, int Barra, string Nombre, string Apellido, string DNI, int Habitacion_ID, int Plazas, bool Bloqueada, int Solicitud, int Registro)
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

       

        public void nuevaDependencia(string CODIGO, string SIGN, int ESTADO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(CODIGO);
            vector_contenidos.Add(SIGN);
            vector_contenidos.Add(ESTADO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@CODIGO");
            vector_nombres.Add("@SIGN");
            vector_nombres.Add("@ESTADO");

            string vprocedure = "CODIGOS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }


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

        public void actualizarDependencia(string CODIGO, string SIGN, int ESTADO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(CODIGO);
            vector_contenidos.Add(SIGN);
            vector_contenidos.Add(ESTADO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@CODIGO");
            vector_nombres.Add("@SIGN");
            vector_nombres.Add("@ESTADO");

            string vprocedure = "CODIGOS_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        public void Bono_SeteoIngreso(int Bono, int Ingreso)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Ingreso);
            vector_contenidos.Add(Bono);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            
            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@SECUENCIA");
            vector_nombres.Add("@BONO_ROL");

            string vprocedure = "P_INGRESO_SETEAR_BONO_ROL";
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

        //STORED GUARDA ASISTENCIA TECNICA
        public void altaAsistenciaTecnica(string NOM_EQ, string DIR_IP, string SO, string USUARIO_WIN, string USUARIO_ALTA, string PROBLEMA, string PRIORIDAD, string ESTADO, string FECHA_PENDIENTE)
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

            string vprocedure = "ASISTENCIAS_TECNICAS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }
               

        //STORED ELIMINAR OBSERVACION INTERIOR Y FILIALES
        public void eliminarObservacionInterior(int ID)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");

            string vprocedure = "OBS_INTERIOR_D";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED CARGAR OBSERVACION INTERIOR Y FILIALES
        public void cargarObservacionInterior(int DNI, string OBSERVACION)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(OBSERVACION);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@OBSERVACION");

            string vprocedure = "OBS_INTERIOR_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED CARGAR MOROSOS NO DESCONTADOS
        public void cargarMorososNoDescontados(string APELLIDO_NOMBRE, int DNI)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(APELLIDO_NOMBRE);
            vector_contenidos.Add(DNI);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@APELLIDO_NOMBRE");
            vector_nombres.Add("@DNI");

            string vprocedure = "MOROSOS_NO_DESC_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED CARGAR MOROSOS INVITADOS
        public void cargarMorososInvitados(string APELLIDO_NOMBRE, int DNI)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(APELLIDO_NOMBRE);
            vector_contenidos.Add(DNI);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@APELLIDO_NOMBRE");
            vector_nombres.Add("@DNI");

            string vprocedure = "MOROSOS_INVITADOS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED CARGAR MOROSOS
        public void cargarMorosos(int MES, int ANIO, int AR, int CL, int AFIL, int S)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(MES);
            vector_contenidos.Add(ANIO);
            vector_contenidos.Add(AR);
            vector_contenidos.Add(CL);
            vector_contenidos.Add(AFIL);
            vector_contenidos.Add(S);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@MES");
            vector_nombres.Add("@ANIO");
            vector_nombres.Add("@AR");
            vector_nombres.Add("@CL");
            vector_nombres.Add("@AFIL");
            vector_nombres.Add("@S");

            string vprocedure = "MOROSOS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED CARGAR MOROSOS_DEPORTES
        public void cargarMorososDeportes(string APELLIDO_NOMBRE, int DNI)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(APELLIDO_NOMBRE);
            vector_contenidos.Add(DNI);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@APELLIDO_NOMBRE");
            vector_nombres.Add("@DNI");

            string vprocedure = "MOROSOS_DEPORTES_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED CARGAR OBSERVACIONES MEDICAS
        public void cargarObesrvacionesMedicas(string FECHA, int DNI, string OBSERVACION)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(OBSERVACION);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@OBSERVACION");

            string vprocedure = "OBSERVACIONES_MEDICAS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED VACIAR TABLA
        public void vaciarTabla(string TABLA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(TABLA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@TABLA");

            string vprocedure = "VACIAR_TABLA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDA NUMERO DE REMITO EN FACTURA
        public void remitoEnFactura(int ID, string NRO_REMITO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(NRO_REMITO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@NRO_REMITO");

            string vprocedure = "REMITO_EN_FACTURAS";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        

        //STORED CAMBIA ESTADO DE CHEQUE
        public void cambiarEstadoDeCheque(int NRO_CHEQUE, int BANCO, string ESTADO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(NRO_CHEQUE);
            vector_contenidos.Add(BANCO);
            vector_contenidos.Add(ESTADO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@NRO_CHEQUE");
            vector_nombres.Add("@BANCO");
            vector_nombres.Add("@ESTADO");

            string vprocedure = "CAMBIAR_ESTADO_CHEQUE";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDA CHEQUERAS
        public void guardarChequeras(int BANCO, string SERIE, int NRO_CHEQUE, string ESTADO, string TIPO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(BANCO);
            vector_contenidos.Add(SERIE);
            vector_contenidos.Add(NRO_CHEQUE);
            vector_contenidos.Add(ESTADO);
            vector_contenidos.Add(TIPO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@BANCO");
            vector_nombres.Add("@SERIE");
            vector_nombres.Add("@NRO_CHEQUE");
            vector_nombres.Add("@ESTADO");
            vector_nombres.Add("@TIPO");

            string vprocedure = "CHEQUERAS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ORDEN DE PAGO EN FACTURA
        public void opEnFactura(int ID_FACTURA, int ID_OP)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_FACTURA);
            vector_contenidos.Add(ID_OP);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@ORDEN_DE_PAGO");

            string vprocedure = "OP_EN_FACTURAS";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ORDEN DE PAGO X FACTURA
        public void facturaXop(int ID_OP, int ID_FACTURA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_OP);
            vector_contenidos.Add(ID_FACTURA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID_OP");
            vector_nombres.Add("@ID_FACTURA");

            string vprocedure = "FACTURAS_OP_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }
         
        //STORED NUEVO CHEQUE X ORDEN DE PAGO
        public void chequeXop(int ID_CHEQUE, int ID_OP)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_CHEQUE);
            vector_contenidos.Add(ID_OP);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID_CHEQUE");
            vector_nombres.Add("@ID_OP");

            string vprocedure = "CHEQUES_ORDENES_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVO CHEQUE
        public void modificaCheque(int CHEQUE, int OP, decimal IMPORTE, string FECHA, string ESTADO, string VENCIMIENTO, string BENEFICIARIO)
        {
            if (VENCIMIENTO == "")
            {
                VENCIMIENTO = null;
            }
            
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(CHEQUE);
            vector_contenidos.Add(OP);
            vector_contenidos.Add(IMPORTE);
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(ESTADO);
            vector_contenidos.Add(VENCIMIENTO);
            vector_contenidos.Add(BENEFICIARIO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@NRO_CHEQUE");
            vector_nombres.Add("@OP_ASIGNADA");
            vector_nombres.Add("@IMPORTE");
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@ESTADO");
            vector_nombres.Add("@VENCIMIENTO");
            vector_nombres.Add("@BENEFICIARIO");
  
            string vprocedure = "CHEQUERAS_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDA ORDEN DE PAGO
        public void nuevaOrdenDePago(string FECHA, string OBSERVACIONES, decimal TOTAL, string BENEFICIARIO, int IDE, string US_ALTA, string FECHA_OP)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(OBSERVACIONES);
            vector_contenidos.Add(TOTAL);
            vector_contenidos.Add(BENEFICIARIO);
            vector_contenidos.Add(IDE);
            vector_contenidos.Add(US_ALTA);
            vector_contenidos.Add(FECHA_OP);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@OBSERVACIONES");
            vector_nombres.Add("@TOTAL");
            vector_nombres.Add("@BENEFICIARIO");
            vector_nombres.Add("@IDE");
            vector_nombres.Add("@US_ALTA");
            vector_nombres.Add("@FECHA_OP");

            string vprocedure = "ORDENES_DE_PAGO_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDA DESCUENTO EN COMANDA
        public void descuentoEnComanda(int ID_COMANDA, int ID_DESCUENTO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_COMANDA);
            vector_contenidos.Add(ID_DESCUENTO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID_COMANDA");
            vector_nombres.Add("@ID_DESCUENTO");

            string vprocedure = "CONFITERIA_COMANDAS_DESC";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDA SOLICITUD DE DESCUENTO ESPECIAL
        public void nuevaSolicitudEspecial(string FECHA, string NOM_SOC, decimal IMPORTE, string DESTINO, int LEG_PER, string AFILIADO, string BENEFICIO, string A_DTO, int COMANDA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(NOM_SOC);
            vector_contenidos.Add(IMPORTE);
            vector_contenidos.Add(DESTINO);
            vector_contenidos.Add(LEG_PER);
            vector_contenidos.Add(AFILIADO);
            vector_contenidos.Add(BENEFICIO);
            vector_contenidos.Add(A_DTO);
            vector_contenidos.Add(COMANDA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Numeric");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ITEM");
            vector_nombres.Add("@NOM_SOC");
            vector_nombres.Add("@IMPORTE");
            vector_nombres.Add("@DESTINO");
            vector_nombres.Add("@LEG_PER");
            vector_nombres.Add("@AFILIADO");
            vector_nombres.Add("@BENEFICIO");
            vector_nombres.Add("@A_DTO");
            vector_nombres.Add("@COMANDA");

            string vprocedure = "CONFITERIA_SOL_ESP_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDA SOLICITUD DE DESCUENTO CONFITERIA
        public void nuevaSolicitudDescuentoConfiteria(string FECHA, string NOM_SOC, decimal IMPORTE, string DESTINO, int LEG_PER, string AFILIADO, string BENEFICIO, string A_DTO, int COMANDA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(NOM_SOC);
            vector_contenidos.Add(IMPORTE);
            vector_contenidos.Add(DESTINO);
            vector_contenidos.Add(LEG_PER);
            vector_contenidos.Add(AFILIADO);
            vector_contenidos.Add(BENEFICIO);
            vector_contenidos.Add(A_DTO);
            vector_contenidos.Add(COMANDA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Numeric");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ITEM");
            vector_nombres.Add("@NOM_SOC");
            vector_nombres.Add("@IMPORTE");
            vector_nombres.Add("@DESTINO");
            vector_nombres.Add("@LEG_PER");
            vector_nombres.Add("@AFILIADO");
            vector_nombres.Add("@BENEFICIO");
            vector_nombres.Add("@A_DTO");
            vector_nombres.Add("@COMANDA");

            string vprocedure = "CONFITERIA_SOL_DESC_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MARCA ITEM COMO IMPRESO
        public void marcarItemImpreso(int ITEM)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ITEM);
            vector_contenidos.Add("SI");

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ITEM");
            vector_nombres.Add("@IMPRESO");

            string vprocedure = "CONFITERIA_ITEM_IMPRESO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDA COMANDA EN INGRESOS
        public void comandaEnIngresos(int SECUENCIA, int ID_COMANDA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(SECUENCIA);
            vector_contenidos.Add(ID_COMANDA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@SECUENCIA");
            vector_nombres.Add("@ID_COMANDA");

            string vprocedure = "COMANDA_EN_INGRESOS";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR IMPORTE COMANDA
        public void modificarImporteComanda(int ID_COMANDA, decimal IMPORTE)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_COMANDA);
            vector_contenidos.Add(IMPORTE);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Numeric");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID_COMANDA");
            vector_nombres.Add("@IMPORTE");

            string vprocedure = "CONFITERIA_COMANDAS_IMPORTE";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDAR COMANDA EN TEMP MESAS
        public void guardaComandaEnMesa(int COMANDA, int MESA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(COMANDA);
            vector_contenidos.Add(MESA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@COMANDA");
            vector_nombres.Add("@MESA");

            string vprocedure = "CONFITERIA_TEMP_MESAS_COMANDA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ELIMINA ITEMS
        public void eliminaItems(int ITEM)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ITEM);
            
            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ITEM");

            string vprocedure = "CONFITERIA_COMANDA_ITEM_D";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDA ITEMS
        public void guardaItems(int COMANDA, int ITEM, int CANTIDAD, int TIPO, string TIPO_DETALLE, string ITEM_DETALLE, decimal VALOR, decimal SUBTOTAL, string IMPRESO, string OBSERVACION)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(COMANDA);
            vector_contenidos.Add(ITEM);
            vector_contenidos.Add(CANTIDAD);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(VALOR);
            vector_contenidos.Add(SUBTOTAL);
            vector_contenidos.Add(ITEM_DETALLE);
            vector_contenidos.Add(TIPO_DETALLE);
            vector_contenidos.Add(IMPRESO);
            vector_contenidos.Add(OBSERVACION);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Char");
            
            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@COMANDA");
            vector_nombres.Add("@ITEM");
            vector_nombres.Add("@CANTIDAD");
            vector_nombres.Add("@TIPO");
            vector_nombres.Add("@VALOR");
            vector_nombres.Add("@SUBTOTAL");
            vector_nombres.Add("@ITEM_DETALLE");
            vector_nombres.Add("@TIPO_DETALLE");
            vector_nombres.Add("@IMPRESO");
            vector_nombres.Add("@OBSERVACION");

            string vprocedure = "CONFITERIA_COMANDA_ITEM_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR MESA
        public void modificarMesa(int ID_COMANDA, int MOZO, decimal IMPORTE, int PERSONAS, int FORMA_DE_PAGO, int CONTRALOR, string COM_BORRADOR, string CONSUME, int TIPO_COMANDA, int DESCUENTO_APLICADO, decimal IMPORTE_DESCONTADO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_COMANDA);
            vector_contenidos.Add(MOZO);
            vector_contenidos.Add(IMPORTE);
            vector_contenidos.Add(PERSONAS);
            vector_contenidos.Add(FORMA_DE_PAGO);
            vector_contenidos.Add(CONTRALOR);
            vector_contenidos.Add(COM_BORRADOR);
            vector_contenidos.Add(CONSUME);
            vector_contenidos.Add(TIPO_COMANDA);
            vector_contenidos.Add(DESCUENTO_APLICADO);
            vector_contenidos.Add(IMPORTE_DESCONTADO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Numeric");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@MOZO");
            vector_nombres.Add("@IMPORTE");
            vector_nombres.Add("@PERSONAS");
            vector_nombres.Add("@FORMA_DE_PAGO");
            vector_nombres.Add("@CONTRALOR");
            vector_nombres.Add("@COM_BORRADOR");
            vector_nombres.Add("@CONSUME");
            vector_nombres.Add("@TIPO_COMANDA");
            vector_nombres.Add("@DESCUENTO_APLICADO");
            vector_nombres.Add("@IMPORTE_DESCONTADO");

            string vprocedure = "CONFITERIA_COMANDAS_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDA MESA
        public void guardaMesa(string FECHA, int MESA, int MOZO, decimal IMPORTE, int NRO_SOC, int NRO_DEP, int BARRA, int PERSONAS, string AFILIADO, string BENEFICIO, 
                               string NOMBRE_SOCIO, string USUARIO, int FORMA_DE_PAGO, int CONTRALOR, string COM_BORRADOR, string CONSUME, int TIPO_COMANDA, int DESCUENTO_APLICADO,
                               decimal IMPORTE_DESCONTADO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(MESA);
            vector_contenidos.Add(MOZO);
            vector_contenidos.Add(IMPORTE);
            vector_contenidos.Add(NRO_SOC);
            vector_contenidos.Add(NRO_DEP);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(PERSONAS);
            vector_contenidos.Add(AFILIADO);
            vector_contenidos.Add(BENEFICIO);
            vector_contenidos.Add(NOMBRE_SOCIO);
            vector_contenidos.Add(USUARIO);
            vector_contenidos.Add(FORMA_DE_PAGO);
            vector_contenidos.Add(CONTRALOR);
            vector_contenidos.Add(COM_BORRADOR);
            vector_contenidos.Add(CONSUME);
            vector_contenidos.Add(TIPO_COMANDA);
            vector_contenidos.Add(DESCUENTO_APLICADO);
            vector_contenidos.Add(IMPORTE_DESCONTADO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Numeric");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@MESA");
            vector_nombres.Add("@MOZO");
            vector_nombres.Add("@IMPORTE");
            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@PERSONAS");
            vector_nombres.Add("@AFILIADO");
            vector_nombres.Add("@BENEFICIO");
            vector_nombres.Add("@NOMBRE_SOCIO");
            vector_nombres.Add("@USUARIO");
            vector_nombres.Add("@FORMA_DE_PAGO");
            vector_nombres.Add("@CONTRALOR");
            vector_nombres.Add("@COM_BORRADOR");
            vector_nombres.Add("@CONSUME");
            vector_nombres.Add("@TIPO_COMANDA");
            vector_nombres.Add("@DESCUENTO_APLICADO");
            vector_nombres.Add("@IMPORTE_DESCONTADO");

            string vprocedure = "CONFITERIA_COMANDAS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED CAMBIAR MESA EN COMANDA
        public void cambiarMesaComanda(int MESA, int ID_COMANDA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(MESA);
            vector_contenidos.Add(ID_COMANDA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@MESA");
            vector_nombres.Add("@ID_COMANDA");

            string vprocedure = "CONFITERIA_CAMBIAR_MESA_COMANDA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED CAMBIAR MESA
        public void cambiarMesa(int MESA, string ESTADO, string DESDE, string SOCIO, int ID_COMANDA, int NRO_SOC, int NRO_DEP, int BARRA, int SECUENCIA, int PERSONAS, int PAGO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(MESA);
            vector_contenidos.Add(ESTADO);
            vector_contenidos.Add(DESDE);
            vector_contenidos.Add(SOCIO);
            vector_contenidos.Add(ID_COMANDA);
            vector_contenidos.Add(NRO_SOC);
            vector_contenidos.Add(NRO_DEP);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(SECUENCIA);
            vector_contenidos.Add(PERSONAS);
            vector_contenidos.Add(PAGO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@MESA");
            vector_nombres.Add("@ESTADO");
            vector_nombres.Add("@DESDE");
            vector_nombres.Add("@SOCIO");
            vector_nombres.Add("@ID_COMANDA");
            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@SECUENCIA");
            vector_nombres.Add("@PERSONAS");
            vector_nombres.Add("@PAGO");

            string vprocedure = "CONFITERIA_TEMP_MESAS_CAMBIAR";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }


        //STORED ABRIR MESA
        public void abrirMesa(int MESA, string ESTADO, DateTime DESDE, string SOCIO, int NRO_SOC, int NRO_DEP, int BARRA, int SECUENCIA, int PERSONAS, int PAGO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(MESA);
            vector_contenidos.Add(ESTADO);
            vector_contenidos.Add(DESDE);
            vector_contenidos.Add(SOCIO);
            vector_contenidos.Add(NRO_SOC);
            vector_contenidos.Add(NRO_DEP);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(SECUENCIA);
            vector_contenidos.Add(PERSONAS);
            vector_contenidos.Add(PAGO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@MESA");
            vector_nombres.Add("@ESTADO");
            vector_nombres.Add("@DESDE");
            vector_nombres.Add("@SOCIO");
            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@SECUENCIA");
            vector_nombres.Add("@PERSONAS");
            vector_nombres.Add("@PAGO");

            string vprocedure = "CONFITERIA_TEMP_MESAS_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR PERSONAS PAGO EN TEMPORAL
        public void modPersoPagoTemp(int MESA, int PERSO, int PAGO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(MESA);
            vector_contenidos.Add(PERSO);
            vector_contenidos.Add(PAGO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@MESA");
            vector_nombres.Add("@PERSO");
            vector_nombres.Add("@PAGO");

            string vprocedure = "CONFITERIA_TEMP_MESAS_PP";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED CERRAR MESA
        public void cerrarMesa(int MESA, string ESTADO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(MESA);
            vector_contenidos.Add(ESTADO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@MESA");
            vector_nombres.Add("@ESTADO");

            string vprocedure = "CONFITERIA_TEMP_MESAS_C";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED AGREGAR PROFESIONAL A PROF_ESP 
        public void agregarProfesionalProfEsp(int PROF, int ESP)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(PROF);
            vector_contenidos.Add(ESP);
            
            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            
            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@PROF");
            vector_nombres.Add("@ESP");
            
            string vprocedure = "PROF_ESP_ADD";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        

        

        

        
        

        //STORED CARGAR EMPLEADOS DESVINCULADOS
        public void cargarEmpleadosDesvinculados(string DNI, string APELLIDO, string NOMBRE, string FECHA_BAJA, string MOTIVO_BAJA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(APELLIDO.Trim());
            vector_contenidos.Add(NOMBRE.Trim());
            vector_contenidos.Add(FECHA_BAJA);
            vector_contenidos.Add(MOTIVO_BAJA.Trim());

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@FECHA_BAJA");
            vector_nombres.Add("@MOTIVO_BAJA");

            string vprocedure = "EMPLEADOS_DESVINCULADOS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }


        //STORED MODIFICAR TIPO DE ARTICULO
        public void modificarTipoArticulo(int ID, string DETALLE)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(DETALLE.Trim());

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@DETALLE");

            string vprocedure = "TIPOS_ARTICULOS_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVO TIPO DE ARTICULO
        public void nuevoTipoArticulo(string DETALLE)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(DETALLE.Trim());
            
            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@DETALLE");

            string vprocedure = "TIPOS_ARTICULOS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }     

        public void guardarMovimiento(int PERSONA, int ACCION, string FECHA_HORA, string USUARIO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(PERSONA);
            vector_contenidos.Add(ACCION);
            vector_contenidos.Add(FECHA_HORA);
            vector_contenidos.Add(USUARIO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@PERSONA");
            vector_nombres.Add("@ACCION");
            vector_nombres.Add("@FECHA_HORA");
            vector_nombres.Add("@USUARIO");

            string vprocedure = "MOVIMIENTOS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        public void modificarPA(int PERSONA, int PA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(PERSONA);
            vector_contenidos.Add(PA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@PERSONA");
            vector_nombres.Add("@ID");

            string vprocedure = "TEMP_PA_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICA ARTICULOS DE UNA FACTURA
        public void modificarArticulos(int ID, string DETALLE, decimal VALOR, int CANTIDAD, string NSERIE, int TIPO, string DESCUENTO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(DETALLE);
            vector_contenidos.Add(VALOR);
            vector_contenidos.Add(CANTIDAD);
            vector_contenidos.Add(NSERIE);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(DESCUENTO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Decimal");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("ID");
            vector_nombres.Add("DETALLE");
            vector_nombres.Add("VALOR");
            vector_nombres.Add("CANTIDAD");
            vector_nombres.Add("NSERIE");
            vector_nombres.Add("TIPO");
            vector_nombres.Add("DESCUENTO");

            string vprocedure = "ARTICULOS_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED AGREGAR ARTICULOS A FACTURA
        public void nuevoArticulo(int ID_FACTURA, string DETALLE, decimal VALOR, int CANTIDAD, string NSERIE, int TIPO, string DESCUENTO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_FACTURA);
            vector_contenidos.Add(DETALLE);
            vector_contenidos.Add(VALOR);
            vector_contenidos.Add(CANTIDAD);
            vector_contenidos.Add(NSERIE);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(DESCUENTO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Decimal");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("ID_FACTURA");
            vector_nombres.Add("DETALLE");
            vector_nombres.Add("VALOR");
            vector_nombres.Add("CANTIDAD");
            vector_nombres.Add("NSERIE");
            vector_nombres.Add("TIPO");
            vector_nombres.Add("DESCUENTO");
            
            string vprocedure = "ARTICULOS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR FACTURA
        public void modificarFactura(int ID, int PROVEEDOR, string NUM_FACTURA, string FECHA, decimal IMPORTE, string OBSERVACIONES, string FE_MOD, string US_MOD, string SECTOR, string SEC_GRAL, int TIPO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(PROVEEDOR);
            vector_contenidos.Add(NUM_FACTURA);
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(IMPORTE);
            vector_contenidos.Add(OBSERVACIONES);
            vector_contenidos.Add(FE_MOD);
            vector_contenidos.Add(US_MOD);
            vector_contenidos.Add(SECTOR);
            vector_contenidos.Add(SEC_GRAL);
            vector_contenidos.Add(TIPO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Decimal");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("ID");
            vector_nombres.Add("PROVEEDOR");
            vector_nombres.Add("NUM_FACTURA");
            vector_nombres.Add("FECHA");
            vector_nombres.Add("IMPORTE");
            vector_nombres.Add("OBSERVACIONES");
            vector_nombres.Add("FE_MOD");
            vector_nombres.Add("US_MOD");
            vector_nombres.Add("SECTOR");
            vector_nombres.Add("SEC_GRAL");
            vector_nombres.Add("TIPO");

            string vprocedure = "FACTURAS_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVO RECIBO OFICIAL
        public void nuevoReciboOficial(string NRO_RECIBO, string FE_RECIBO, decimal IMPORTE, string OBSERVACIONES, string FE_ALTA, string US_ALTA, string NRO_FACTURA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(NRO_RECIBO);
            vector_contenidos.Add(FE_RECIBO);
            vector_contenidos.Add(IMPORTE);
            vector_contenidos.Add(OBSERVACIONES);
            vector_contenidos.Add(FE_ALTA);
            vector_contenidos.Add(US_ALTA);
            vector_contenidos.Add(NRO_FACTURA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("NRO_RECIBO");
            vector_nombres.Add("FE_RECIBO");
            vector_nombres.Add("IMPORTE");
            vector_nombres.Add("OBSERVACIONES");
            vector_nombres.Add("FE_ALTA");
            vector_nombres.Add("US_ALTA");
            vector_nombres.Add("NRO_FACTURA");

            string vprocedure = "RECIBOS_OFICIALES_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVO REMITO
        public void nuevoRemito(string NRO_REMITO, string FE_REMITO, decimal IMPORTE, string OBSERVACIONES, string FE_ALTA, string US_ALTA, string NRO_FACTURA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(NRO_REMITO);
            vector_contenidos.Add(FE_REMITO);
            vector_contenidos.Add(IMPORTE);
            vector_contenidos.Add(OBSERVACIONES);
            vector_contenidos.Add(FE_ALTA);
            vector_contenidos.Add(US_ALTA);
            vector_contenidos.Add(NRO_FACTURA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("NRO_REMITO");
            vector_nombres.Add("FE_REMITO");
            vector_nombres.Add("IMPORTE");
            vector_nombres.Add("OBSERVACIONES");
            vector_nombres.Add("FE_ALTA");
            vector_nombres.Add("US_ALTA");
            vector_nombres.Add("NRO_FACTURA");

            string vprocedure = "REMITOS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVA NOTA DE CREDITO / DEBITO
        public void nuevaNotaCreditoDebito(string NRO_NOTA, string FE_NOTA, decimal IMPORTE, string TIPO, string OBSERVACIONES, string FE_ALTA, string US_ALTA, string NRO_FACTURA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(NRO_NOTA);
            vector_contenidos.Add(FE_NOTA);
            vector_contenidos.Add(IMPORTE);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(OBSERVACIONES);
            vector_contenidos.Add(FE_ALTA);
            vector_contenidos.Add(US_ALTA);
            vector_contenidos.Add(NRO_FACTURA);
            
            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("NRO_NOTA");
            vector_nombres.Add("FE_NOTA");
            vector_nombres.Add("IMPORTE");
            vector_nombres.Add("TIPO");
            vector_nombres.Add("OBSERVACIONES");
            vector_nombres.Add("FE_ALTA");
            vector_nombres.Add("US_ALTA");
            vector_nombres.Add("NRO_FACTURA");

            string vprocedure = "NOTAS_CREDITO_DEBITO_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVA FACTURA
        public void nuevaFactura(int PROVEEDOR, string NUM_FACTURA, string FECHA, decimal IMPORTE, string OBSERVACIONES, string FE_ALTA, string US_ALTA, string SECTOR, string SEC_GRAL, int TIPO, int ORDEN_DE_PAGO, int REGIMEN, decimal RETENCION)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(PROVEEDOR);
            vector_contenidos.Add(NUM_FACTURA);
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(IMPORTE);
            vector_contenidos.Add(OBSERVACIONES);
            vector_contenidos.Add(FE_ALTA);
            vector_contenidos.Add(US_ALTA);
            vector_contenidos.Add(SECTOR);
            vector_contenidos.Add(SEC_GRAL);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(ORDEN_DE_PAGO);
            vector_contenidos.Add(REGIMEN);
            vector_contenidos.Add(RETENCION);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Decimal");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Numeric");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("PROVEEDOR");
            vector_nombres.Add("NUM_FACTURA");
            vector_nombres.Add("FECHA");
            vector_nombres.Add("IMPORTE");
            vector_nombres.Add("OBSERVACIONES");
            vector_nombres.Add("FE_ALTA");
            vector_nombres.Add("US_ALTA");
            vector_nombres.Add("SECTOR");
            vector_nombres.Add("SEC_GRAL");
            vector_nombres.Add("TIPO");
            vector_nombres.Add("ORDEN_DE_PAGO");
            vector_nombres.Add("REGIMEN");
            vector_nombres.Add("RETENCION");

            string vprocedure = "FACTURAS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ELIMINA UN PROVEEDOR
        public void eliminaUnProveedor(int ID, string USR_BAJA, string FE_BAJA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(USR_BAJA);
            vector_contenidos.Add(FE_BAJA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("ID");
            vector_nombres.Add("USR_BAJA");
            vector_nombres.Add("FE_BAJA");

            string vprocedure = "PROVEEDORES_B";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICA UN PROVEEDOR
        public void modificaUnProveedor(int ID, string RAZON_SOCIAL, string EMAIL, string DOMICILIO, string TELEFONO, string WEB, string CONTACTO, string CUIT, int CUENTA, string USR_MOD, string FE_MOD, string CBU, string TIPO, string TIPO_DE_CUENTA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(RAZON_SOCIAL);
            vector_contenidos.Add(EMAIL);
            vector_contenidos.Add(DOMICILIO);
            vector_contenidos.Add(TELEFONO);
            vector_contenidos.Add(WEB);
            vector_contenidos.Add(CONTACTO);
            vector_contenidos.Add(CUIT);
            vector_contenidos.Add(USR_MOD);
            vector_contenidos.Add(FE_MOD);
            vector_contenidos.Add(CUENTA);
            vector_contenidos.Add(CBU);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(TIPO_DE_CUENTA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("ID");
            vector_nombres.Add("RAZON_SOCIAL");
            vector_nombres.Add("EMAIL");
            vector_nombres.Add("DOMICILIO");
            vector_nombres.Add("TELEFONO");
            vector_nombres.Add("WEB");
            vector_nombres.Add("CONTACTO");
            vector_nombres.Add("CUIT");
            vector_nombres.Add("USR_MOD");
            vector_nombres.Add("FE_MOD");
            vector_nombres.Add("CUENTA");
            vector_nombres.Add("CBU");
            vector_nombres.Add("TIPO");
            vector_nombres.Add("TIPO_DE_CUENTA");

            string vprocedure = "PROVEEDORES_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDA UN PROVEEDOR
        public void guardarUnProveedor(string RAZON_SOCIAL, string EMAIL, string DOMICILIO, string TELEFONO, string WEB, string CONTACTO, string CUIT, string CUENTA, string USR_ALTA, string FE_ALTA, string CBU, string TIPO, string TIPO_DE_CUENTA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(RAZON_SOCIAL);
            vector_contenidos.Add(EMAIL);
            vector_contenidos.Add(DOMICILIO);
            vector_contenidos.Add(TELEFONO);
            vector_contenidos.Add(WEB);
            vector_contenidos.Add(CONTACTO);
            vector_contenidos.Add(CUIT);
            vector_contenidos.Add(USR_ALTA);
            vector_contenidos.Add(FE_ALTA);
            vector_contenidos.Add(CUENTA);
            vector_contenidos.Add(CBU);
            vector_contenidos.Add(TIPO);
            vector_contenidos.Add(TIPO_DE_CUENTA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("RAZON_SOCIAL");
            vector_nombres.Add("EMAIL");
            vector_nombres.Add("DOMICILIO");
            vector_nombres.Add("TELEFONO");
            vector_nombres.Add("WEB");
            vector_nombres.Add("CONTACTO");
            vector_nombres.Add("CUIT");
            vector_nombres.Add("USR_ALTA");
            vector_nombres.Add("FE_ALTA");
            vector_nombres.Add("CUENTA");
            vector_nombres.Add("CBU");
            vector_nombres.Add("TIPO");
            vector_nombres.Add("TIPO_DE_CUENTA");

            string vprocedure = "PROVEEDORES_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDA DATOS DE ENCUESTA
        public void guardarEncuesta(string NOMBRE, int DNI, int NRO_SOC, int NRO_DEP, int NRO_SOC_ADH, int NRO_DEP_ADH, int BARRA, string DIRECCION, Int64 TELEFONO, Int64 CELULAR, string EMAIL, string ALOJAMIENTO, string TURISMO, string DEPORTES, string CULTURA, string ASISTENCIALES, string OTROS, string SUGERENCIAS)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(NRO_SOC);
            vector_contenidos.Add(NRO_DEP);
            vector_contenidos.Add(NRO_SOC_ADH);
            vector_contenidos.Add(NRO_DEP_ADH);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(DIRECCION);
            vector_contenidos.Add(TELEFONO);
            vector_contenidos.Add(CELULAR);
            vector_contenidos.Add(EMAIL);
            vector_contenidos.Add(ALOJAMIENTO);
            vector_contenidos.Add(TURISMO);
            vector_contenidos.Add(DEPORTES);
            vector_contenidos.Add(CULTURA);
            vector_contenidos.Add(ASISTENCIALES);
            vector_contenidos.Add(OTROS);
            vector_contenidos.Add(SUGERENCIAS);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("NOMBRE");
            vector_nombres.Add("DNI");
            vector_nombres.Add("NRO_SOC");
            vector_nombres.Add("NRO_DEP");
            vector_nombres.Add("NRO_SOC_ADH");
            vector_nombres.Add("NRO_DEP_ADH");
            vector_nombres.Add("DIRECCION");
            vector_nombres.Add("TELEFONO");
            vector_nombres.Add("CELULAR");
            vector_nombres.Add("EMAIL");
            vector_nombres.Add("BARRA");
            vector_nombres.Add("ALOJAMIENTO");
            vector_nombres.Add("TURISMO");
            vector_nombres.Add("DEPORTES");
            vector_nombres.Add("CULTURA");
            vector_nombres.Add("ASISTENCIALES");
            vector_nombres.Add("OTROS");
            vector_nombres.Add("SUGERENCIAS");

            string vprocedure = "ENCUESTAS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }



        //STORED GUARDA REGISTRO DE LLAMADAS
        public void insertarRegistroLlamadas(string FECHA, string HORA, string INTERNO, string DURACION, string DESTINO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(HORA);
            vector_contenidos.Add(INTERNO);
            vector_contenidos.Add(DURACION);
            vector_contenidos.Add(DESTINO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("FECHA");
            vector_nombres.Add("HORA");
            vector_nombres.Add("INTERNO");
            vector_nombres.Add("DURACION");
            vector_nombres.Add("DESTINO");

            string vprocedure = "CALL_LOG_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED INSERTAR PADRES JARDIN MATERNAL
        public void insertarPadresJardin(int ID_TITULAR, int AAR, int ACRJP1, int ACRJP2, int ACRJP3, int PAR, int PCRJP1, int PCRJP2, int PCRJP3, string APE_SOC, string NOM_SOC, int NRO_SOC, int NRO_DEP, string JERARQ, int LEG_PER,
            string DESTINO, string F_ALTPO, string F_ALTCI, string TIP_DOC, int NUM_DOC, int NUM_CED, string CALL_PAR, string LOC_PAR, string NUM_TE1, string NUM_TE2, string COD_DTO, string CAT_SOC, string GIMNASIO, string ESCALA, string A_DTO,
            string USR_ALTA, string NCOD_DTO, string ORIGEN_ALTA, byte[] FOTO, byte[] OBSERVACIONES)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_TITULAR);  //1
            vector_contenidos.Add(AAR);         //2
            vector_contenidos.Add(ACRJP1);      //3
            vector_contenidos.Add(ACRJP2);      //4
            vector_contenidos.Add(ACRJP3);      //5
            vector_contenidos.Add(PAR);         //6
            vector_contenidos.Add(PCRJP1);      //7
            vector_contenidos.Add(PCRJP2);      //8
            vector_contenidos.Add(PCRJP3);      //9
            vector_contenidos.Add(APE_SOC);     //10
            vector_contenidos.Add(NOM_SOC);     //11
            vector_contenidos.Add(NRO_SOC);     //12
            vector_contenidos.Add(NRO_DEP);     //13
            vector_contenidos.Add(JERARQ);      //14
            vector_contenidos.Add(LEG_PER);     //15
            vector_contenidos.Add(DESTINO);     //16
            vector_contenidos.Add(F_ALTPO);     //17
            vector_contenidos.Add(F_ALTCI);     //18
            vector_contenidos.Add(TIP_DOC);     //19
            vector_contenidos.Add(NUM_DOC);     //20
            vector_contenidos.Add(NUM_CED);     //21
            vector_contenidos.Add(CALL_PAR);    //23
            vector_contenidos.Add(LOC_PAR);     //28
            vector_contenidos.Add(NUM_TE1);     //31
            vector_contenidos.Add(NUM_TE2);     //33
            vector_contenidos.Add(COD_DTO);     //39
            vector_contenidos.Add(CAT_SOC);     //40
            vector_contenidos.Add(GIMNASIO);    //46
            vector_contenidos.Add(ESCALA);      //56
            vector_contenidos.Add(A_DTO);       //59
            vector_contenidos.Add(USR_ALTA);    //63
            vector_contenidos.Add(NCOD_DTO);    //69
            vector_contenidos.Add(ORIGEN_ALTA); //76
            vector_contenidos.Add(FOTO); //76
            vector_contenidos.Add(OBSERVACIONES); //76

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.BLOB");
            vector_tipos.Add("FbDbType.BLOB");


            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("ID_TITULAR");  //1
            vector_nombres.Add("AAR");         //2
            vector_nombres.Add("ACRJP1");      //3
            vector_nombres.Add("ACRJP2");      //4
            vector_nombres.Add("ACRJP3");      //5
            vector_nombres.Add("PAR");         //6
            vector_nombres.Add("PCRJP1");      //7
            vector_nombres.Add("PCRJP2");      //8
            vector_nombres.Add("PCRJP3");      //9
            vector_nombres.Add("APE_SOC");     //10
            vector_nombres.Add("NOM_SOC");     //11
            vector_nombres.Add("NRO_SOC");     //12
            vector_nombres.Add("NRO_DEP");     //13
            vector_nombres.Add("JERARQ");      //14
            vector_nombres.Add("LEG_PER");     //15
            vector_nombres.Add("DESTINO");     //16
            vector_nombres.Add("F_ALTPO");     //17
            vector_nombres.Add("F_ALTCI");     //18
            vector_nombres.Add("TIP_DOC");     //19
            vector_nombres.Add("NUM_DOC");     //20
            vector_nombres.Add("NUM_CED");     //21
            vector_nombres.Add("CALL_PAR");    //23
            vector_nombres.Add("LOC_PAR");     //28
            vector_nombres.Add("NUM_TE1");     //31
            vector_nombres.Add("NUM_TE2");     //33
            vector_nombres.Add("COD_DTO");     //39
            vector_nombres.Add("CAT_SOC");     //40
            vector_nombres.Add("GIMNASIO");    //46
            vector_nombres.Add("ESCALA");      //56
            vector_nombres.Add("A_DTO");       //59
            vector_nombres.Add("USR_ALTA");    //63
            vector_nombres.Add("NCOD_DTO");    //69
            vector_nombres.Add("ORIGEN_ALTA"); //76
            vector_nombres.Add("FOTO"); //76
            vector_nombres.Add("OBS"); //76

            string vprocedure = "ALTA_PADRE_JARDIN";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED INSERTAR TITULARES VOLVE A SER PARTE
        public void insertarTitularesVolve(int ID_TITULAR, int AAR, int ACRJP1, int ACRJP2, int ACRJP3, int PAR, int PCRJP1, int PCRJP2, int PCRJP3, string APE_SOC, string NOM_SOC, int NRO_SOC, int NRO_DEP, string JERARQ, int LEG_PER,
            string DESTINO, string F_ALTPO, string F_ALTCI, string TIP_DOC, int NUM_DOC, int NUM_CED, string CALL_PAR, string LOC_PAR, string NUM_TE1, string NUM_TE2, string COD_DTO, string CAT_SOC, string GIMNASIO, string ESCALA, string A_DTO,
            string USR_ALTA, string NCOD_DTO, string ORIGEN_ALTA, byte[] FOTO, byte[] OBSERVACIONES)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_TITULAR);  //1
            vector_contenidos.Add(AAR);         //2
            vector_contenidos.Add(ACRJP1);      //3
            vector_contenidos.Add(ACRJP2);      //4
            vector_contenidos.Add(ACRJP3);      //5
            vector_contenidos.Add(PAR);         //6
            vector_contenidos.Add(PCRJP1);      //7
            vector_contenidos.Add(PCRJP2);      //8
            vector_contenidos.Add(PCRJP3);      //9
            vector_contenidos.Add(APE_SOC);     //10
            vector_contenidos.Add(NOM_SOC);     //11
            vector_contenidos.Add(NRO_SOC);     //12
            vector_contenidos.Add(NRO_DEP);     //13
            vector_contenidos.Add(JERARQ);      //14
            vector_contenidos.Add(LEG_PER);     //15
            vector_contenidos.Add(DESTINO);     //16
            vector_contenidos.Add(F_ALTPO);     //17
            vector_contenidos.Add(F_ALTCI);     //18
            vector_contenidos.Add(TIP_DOC);     //19
            vector_contenidos.Add(NUM_DOC);     //20
            vector_contenidos.Add(NUM_CED);     //21
            vector_contenidos.Add(CALL_PAR);    //23
            vector_contenidos.Add(LOC_PAR);     //28
            vector_contenidos.Add(NUM_TE1);     //31
            vector_contenidos.Add(NUM_TE2);     //33
            vector_contenidos.Add(COD_DTO);     //39
            vector_contenidos.Add(CAT_SOC);     //40
            vector_contenidos.Add(GIMNASIO);    //46
            vector_contenidos.Add(ESCALA);      //56
            vector_contenidos.Add(A_DTO);       //59
            vector_contenidos.Add(USR_ALTA);    //63
            vector_contenidos.Add(NCOD_DTO);    //69
            vector_contenidos.Add(ORIGEN_ALTA); //76
            vector_contenidos.Add(FOTO); //76
            vector_contenidos.Add(OBSERVACIONES); //76

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.BLOB");
            vector_tipos.Add("FbDbType.BLOB");


            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("ID_TITULAR");  //1
            vector_nombres.Add("AAR");         //2
            vector_nombres.Add("ACRJP1");      //3
            vector_nombres.Add("ACRJP2");      //4
            vector_nombres.Add("ACRJP3");      //5
            vector_nombres.Add("PAR");         //6
            vector_nombres.Add("PCRJP1");      //7
            vector_nombres.Add("PCRJP2");      //8
            vector_nombres.Add("PCRJP3");      //9
            vector_nombres.Add("APE_SOC");     //10
            vector_nombres.Add("NOM_SOC");     //11
            vector_nombres.Add("NRO_SOC");     //12
            vector_nombres.Add("NRO_DEP");     //13
            vector_nombres.Add("JERARQ");      //14
            vector_nombres.Add("LEG_PER");     //15
            vector_nombres.Add("DESTINO");     //16
            vector_nombres.Add("F_ALTPO");     //17
            vector_nombres.Add("F_ALTCI");     //18
            vector_nombres.Add("TIP_DOC");     //19
            vector_nombres.Add("NUM_DOC");     //20
            vector_nombres.Add("NUM_CED");     //21
            vector_nombres.Add("CALL_PAR");    //23
            vector_nombres.Add("LOC_PAR");     //28
            vector_nombres.Add("NUM_TE1");     //31
            vector_nombres.Add("NUM_TE2");     //33
            vector_nombres.Add("COD_DTO");     //39
            vector_nombres.Add("CAT_SOC");     //40
            vector_nombres.Add("GIMNASIO");    //46
            vector_nombres.Add("ESCALA");      //56
            vector_nombres.Add("A_DTO");       //59
            vector_nombres.Add("USR_ALTA");    //63
            vector_nombres.Add("NCOD_DTO");    //69
            vector_nombres.Add("ORIGEN_ALTA"); //76
            vector_nombres.Add("FOTO"); //76
            vector_nombres.Add("OBS"); //76

            string vprocedure = "ALTA_TITULAR_VOLVE";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED INSERTAR TITULARES ESCUELA
        public void insertarTitularesEscuela(int ID_TITULAR, int AAR, int ACRJP1, int ACRJP2, int ACRJP3, int PAR, int PCRJP1, int PCRJP2, int PCRJP3, string APE_SOC, string NOM_SOC, int NRO_SOC, int NRO_DEP, string JERARQ, int LEG_PER, 
            string DESTINO, string F_ALTPO, string F_ALTCI, string TIP_DOC, int NUM_DOC, int NUM_CED, string CALL_PAR, string LOC_PAR, string NUM_TE1, string NUM_TE2, string COD_DTO, string CAT_SOC, string GIMNASIO, string ESCALA, string A_DTO,
            string USR_ALTA, string NCOD_DTO, string ORIGEN_ALTA, byte[] FOTO, byte[] OBS, string OBSERVAC, string F_NACIM, string SEX, string PRO_PAR)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_TITULAR);  //1
            vector_contenidos.Add(AAR);         //2
            vector_contenidos.Add(ACRJP1);      //3
            vector_contenidos.Add(ACRJP2);      //4
            vector_contenidos.Add(ACRJP3);      //5
            vector_contenidos.Add(PAR);         //6
            vector_contenidos.Add(PCRJP1);      //7
            vector_contenidos.Add(PCRJP2);      //8
            vector_contenidos.Add(PCRJP3);      //9
            vector_contenidos.Add(APE_SOC);     //10
            vector_contenidos.Add(NOM_SOC);     //11
            vector_contenidos.Add(NRO_SOC);     //12
            vector_contenidos.Add(NRO_DEP);     //13
            vector_contenidos.Add(JERARQ);      //14
            vector_contenidos.Add(LEG_PER);     //15
            vector_contenidos.Add(DESTINO);     //16
            vector_contenidos.Add(F_ALTPO);     //17
            vector_contenidos.Add(F_ALTCI);     //18
            vector_contenidos.Add(TIP_DOC);     //19
            vector_contenidos.Add(NUM_DOC);     //20
            vector_contenidos.Add(NUM_CED);     //21
            vector_contenidos.Add(CALL_PAR);    //23
            vector_contenidos.Add(LOC_PAR);     //28
            vector_contenidos.Add(NUM_TE1);     //31
            vector_contenidos.Add(NUM_TE2);     //33
            vector_contenidos.Add(COD_DTO);     //39
            vector_contenidos.Add(CAT_SOC);     //40
            vector_contenidos.Add(GIMNASIO);    //46
            vector_contenidos.Add(ESCALA);      //56
            vector_contenidos.Add(A_DTO);       //59
            vector_contenidos.Add(USR_ALTA);    //63
            vector_contenidos.Add(NCOD_DTO);    //69
            vector_contenidos.Add(ORIGEN_ALTA); //76
            vector_contenidos.Add(FOTO); //76
            vector_contenidos.Add(OBS); //76
            vector_contenidos.Add(OBSERVAC); //76
            vector_contenidos.Add(F_NACIM); //76
            vector_contenidos.Add(SEX); //76
            vector_contenidos.Add(PRO_PAR); //76

            ArrayList vector_tipos = new ArrayList();
            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.BLOB");
            vector_tipos.Add("FbDbType.BLOB");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
             
            ArrayList vector_nombres = new ArrayList();
            
            vector_nombres.Add("ID_TITULAR");  //1
            vector_nombres.Add("AAR");         //2
            vector_nombres.Add("ACRJP1");      //3
            vector_nombres.Add("ACRJP2");      //4
            vector_nombres.Add("ACRJP3");      //5
            vector_nombres.Add("PAR");         //6
            vector_nombres.Add("PCRJP1");      //7
            vector_nombres.Add("PCRJP2");      //8
            vector_nombres.Add("PCRJP3");      //9
            vector_nombres.Add("APE_SOC");     //10
            vector_nombres.Add("NOM_SOC");     //11
            vector_nombres.Add("NRO_SOC");     //12
            vector_nombres.Add("NRO_DEP");     //13
            vector_nombres.Add("JERARQ");      //14
            vector_nombres.Add("LEG_PER");     //15
            vector_nombres.Add("DESTINO");     //16
            vector_nombres.Add("F_ALTPO");     //17
            vector_nombres.Add("F_ALTCI");     //18
            vector_nombres.Add("TIP_DOC");     //19
            vector_nombres.Add("NUM_DOC");     //20
            vector_nombres.Add("NUM_CED");     //21
            vector_nombres.Add("CALL_PAR");    //23
            vector_nombres.Add("LOC_PAR");     //28
            vector_nombres.Add("NUM_TE1");     //31
            vector_nombres.Add("NUM_TE2");     //33
            vector_nombres.Add("COD_DTO");     //39
            vector_nombres.Add("CAT_SOC");     //40
            vector_nombres.Add("GIMNASIO");    //46
            vector_nombres.Add("ESCALA");      //56
            vector_nombres.Add("A_DTO");       //59
            vector_nombres.Add("USR_ALTA");    //63
            vector_nombres.Add("NCOD_DTO");    //69
            vector_nombres.Add("ORIGEN_ALTA"); //76
            vector_nombres.Add("FOTO"); //76
            vector_nombres.Add("OBS"); //76
            vector_nombres.Add("OBSERVAC"); //76
            vector_nombres.Add("F_NACIM"); //76
            vector_nombres.Add("SEX"); //76
            vector_nombres.Add("PRO_PAR"); //76
            
            string vprocedure = "ALTA_TITULAR_ESCUELA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR TABLA TEMPORAL TURNOS MEDICOS
        public void modificarTablaTemporal(string ID, int PROFESIONAL, int MES, int ANIO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(PROFESIONAL);
            vector_contenidos.Add(MES);
            vector_contenidos.Add(ANIO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@PROFESIONAL");
            vector_nombres.Add("@MES");
            vector_nombres.Add("@ANIO");

            string vprocedure = "TURNOS_TEMP_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED LLENAR TABLA TEMPORAL TURNOS MEDICOS
        public void nuevoTablaTemporal(string USUARIO, int PROFESIONAL, int MES, int ANIO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(USUARIO);
            vector_contenidos.Add(PROFESIONAL);
            vector_contenidos.Add(MES);
            vector_contenidos.Add(ANIO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@USUARIO");
            vector_nombres.Add("@PROFESIONAL");
            vector_nombres.Add("@MES");
            vector_nombres.Add("@ANIO");

            string vprocedure = "TURNOS_TEMP_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR ESTADO SECT ACT
        public void modificarEstadoSectAct(int ID, int ESTADO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(ESTADO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@ESTADO");

            string vprocedure = "ESTADO_SECTACT_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVO ROL SECTACT
        public void nuevoRoleSectAct(string ROL, string DETALLE)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ROL);
            vector_contenidos.Add(DETALLE);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@DETALLE");

            string vprocedure = "SECTACT_ROLE_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ALTA DATOS DE CONTACTO EN INGRESO
        public void insertoContacto(int NRO_SOC, int NRO_DEP, int BARRA, string EMAIL, string TELEFONO, string INTERESES, string OBRA_SOCIAL, int NRO_ADH, int DEP_ADH)
        {
            DA_Datos resultado = new DA_Datos();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(NRO_SOC);
            vector_contenidos.Add(NRO_DEP);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(EMAIL.TrimEnd());
            vector_contenidos.Add(TELEFONO.TrimEnd());
            vector_contenidos.Add(INTERESES.TrimEnd());
            vector_contenidos.Add(OBRA_SOCIAL.TrimEnd());
            vector_contenidos.Add(NRO_ADH);
            vector_contenidos.Add(DEP_ADH);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@EMAIL");
            vector_nombres.Add("@TELEFONO");
            vector_nombres.Add("@INTERESES");
            vector_nombres.Add("@OBRA_SOCIAL");
            vector_nombres.Add("@NRO_ADH");
            vector_nombres.Add("@DEP_ADH");

            string vprocedure;
            vprocedure = "CONTACTO_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        //STORED GUARDAR FECHA DE EGRESO EN INGRESOS A PROCESAR
        public void guardarEgreso(int SECUENCIA, string EGRESO)
        {
            DA_Datos resultado = new DA_Datos();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(SECUENCIA);
            vector_contenidos.Add(EGRESO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@SECUENCIA");
            vector_nombres.Add("@EGRESO");

            string vprocedure;
            vprocedure = "GUARDAR_EGRESO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        

        

        

        

        

        //STORED BAJA DIA COMPLETO
        public void bajaDia(string BAJA, string DESDE, string HASTA, int PROFESIONAL)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(BAJA);
            vector_contenidos.Add(DESDE);
            vector_contenidos.Add(HASTA);
            vector_contenidos.Add(PROFESIONAL);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@BAJA");
            vector_nombres.Add("@DESDE");
            vector_nombres.Add("@HASTA");
            vector_nombres.Add("@PROFESIONAL");

            string vprocedure = "AGENDA_PROFESIONALES_BAJA_DIA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVO TURNO MEDICO
        public void nuevoTurnoMedico(int PROFESIONAL, int DIAYHORA, int NRO_SOC, int ESPECIALIDAD, int MES, int ANIO, string USUARIO, string USUARIO_BAJA, int NRO_DEP, int BARRA, string TIPO_SOC, string NUM_DOC, string NOMBRE, string EMAIL, string TELEFONO, string OBRA_SOCIAL, string PRIMERA_VEZ, string OBSERVACIONES)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(PROFESIONAL);
            vector_contenidos.Add(DIAYHORA);
            vector_contenidos.Add(NRO_SOC);
            vector_contenidos.Add(ESPECIALIDAD);
            vector_contenidos.Add(MES);
            vector_contenidos.Add(ANIO);
            vector_contenidos.Add(USUARIO);
            vector_contenidos.Add(USUARIO_BAJA);
            vector_contenidos.Add(NRO_DEP);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(TIPO_SOC);
            vector_contenidos.Add(NUM_DOC);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(EMAIL);
            vector_contenidos.Add(TELEFONO);
            vector_contenidos.Add(OBRA_SOCIAL);
            vector_contenidos.Add(PRIMERA_VEZ);
            vector_contenidos.Add(OBSERVACIONES);
            
            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@PROFESIONAL");
            vector_nombres.Add("@DIAYHORA");
            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@ESPECIALIDAD");
            vector_nombres.Add("@MES");
            vector_nombres.Add("@ANIO");
            vector_nombres.Add("@USUARIO");
            vector_nombres.Add("@USUARIO_BAJA");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@TIPO_SOC");
            vector_nombres.Add("@NUM_DOC");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@EMAIL");
            vector_nombres.Add("@TELEFONO");
            vector_nombres.Add("@OBRA_SOCIAL");
            vector_nombres.Add("@PRIMERA_VEZ");
            vector_nombres.Add("@OBSERVACIONES");
            
            string vprocedure = "TURNOS_MEDICOS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED BAJA TURNO MEDICO
        public void bajaTurnoMedico(int ID, string BAJA, string USUARIO_BAJA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(BAJA);
            vector_contenidos.Add(USUARIO_BAJA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@BAJA");
            vector_nombres.Add("@USUARIO_BAJA");

            string vprocedure = "TURNOS_MEDICOS_BAJA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVO PROFESIONAL
        public void nuevoProfesional(string NOMBRE, string MATRICULA, int DNI, string CORREO, int TELEFONO, int CELULAR, int TIPO_CONTRATO, string ROL, string COMPROBANTE, int CUENTA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
         
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(MATRICULA);
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(CORREO);
            vector_contenidos.Add(TELEFONO);
            vector_contenidos.Add(CELULAR);
            vector_contenidos.Add(TIPO_CONTRATO);
            vector_contenidos.Add(ROL);
            vector_contenidos.Add(COMPROBANTE);
            vector_contenidos.Add(CUENTA);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@MATRICULA");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@CORREO");
            vector_nombres.Add("@TELEFONO");
            vector_nombres.Add("@CELULAR");
            vector_nombres.Add("@TIPO_CONTRATO");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@COMPROBANTE");
            vector_nombres.Add("@CUENTA");

            string vprocedure = "PROFESIONALES_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR PROFESIONAL
        public void modificarProfesional(int ID, string NOMBRE, string MATRICULA, int DNI, string CORREO, int TELEFONO, int CELULAR, int TIPO_CONTRATO, string COMPROBANTE, string CUENTA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(ID);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(MATRICULA);
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(CORREO);
            vector_contenidos.Add(TELEFONO);
            vector_contenidos.Add(CELULAR);
            vector_contenidos.Add(TIPO_CONTRATO);
            vector_contenidos.Add(COMPROBANTE);
            vector_contenidos.Add(CUENTA);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@MATRICULA");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@CORREO");
            vector_nombres.Add("@TELEFONO");
            vector_nombres.Add("@CELULAR");
            vector_nombres.Add("@TIPO_CONTRATO");
            vector_nombres.Add("@COMPROBANTE");
            vector_nombres.Add("@CUENTA");

            string vprocedure = "PROFESIONALES_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED BAJA PROFESIONAL
        public void bajaProfesional(int ID, string BAJA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(ID);
            vector_contenidos.Add(BAJA);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@BAJA");

            string vprocedure = "PROFESIONALES_BAJA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVA ALTA PROFESIONAL
        public void nuevaAltaProfesional(int ID, string BAJA, string NUEVA_ALTA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(ID);
            vector_contenidos.Add(BAJA);
            vector_contenidos.Add(NUEVA_ALTA);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@BAJA");
            vector_nombres.Add("@NUEVA_ALTA");

            string vprocedure = "PROFESIONALES_NUEVA_ALTA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVO PROFESIONAL_ESPECIALIDAD
        public void nuevoProfEsp(int PROFESIONAL, int ESPECIALIDAD)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(PROFESIONAL);
            vector_contenidos.Add(ESPECIALIDAD);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@PROFESIONAL");
            vector_nombres.Add("@ESPECIALIDAD");

            string vprocedure = "PROF_ESP_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR PROFESIONAL_ESPECIALIDAD
        public void modificarProfEsp(int PROFESIONAL, int ESPECIALIDAD)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(PROFESIONAL);
            vector_contenidos.Add(ESPECIALIDAD);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@PROFESIONAL");
            vector_nombres.Add("@ESPECIALIDAD");

            string vprocedure = "PROF_ESP_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVA ESPECIALIDAD
        public void nuevaEspecialidad(string ROL, string DETALLE, int CODINT, int CODCP)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(ROL);
            vector_contenidos.Add(DETALLE);
            vector_contenidos.Add(CODINT);
            vector_contenidos.Add(CODCP);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@DETALLE");
            vector_nombres.Add("@CODINT");
            vector_nombres.Add("@CODCP");

            string vprocedure = "SECTACT_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR ESPECIALIDAD
        public void modificarEspecialidad(int ID, string DETALLE)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(ID);
            vector_contenidos.Add(DETALLE);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@DETALLE");

            string vprocedure = "SECTACT_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED BAJA ESPECIALIDAD - NO UTILIZADO
        public void bajaEspecialidad(int ID, string BAJA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(ID);
            vector_contenidos.Add(BAJA);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@BAJA");

            string vprocedure = "ESPECIALIDADES_BAJA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVA ALTA ESPECIALIDAD - NO UTILIZADO
        public void nuevaAltaEspecialidad(int ID, string BAJA, string NUEVA_ALTA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(ID);
            vector_contenidos.Add(BAJA);
            vector_contenidos.Add(NUEVA_ALTA);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@BAJA");
            vector_nombres.Add("@NUEVA_ALTA");

            string vprocedure = "ESPECIALIDADES_NUEVA_ALTA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ALTA AGENDA
        public void nuevaAgenda(int PROFESIONAL, string FECHA, string DESDE, string HASTA, int INTERVALO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();

            vector_contenidos.Add(PROFESIONAL);
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(DESDE);
            vector_contenidos.Add(HASTA);
            vector_contenidos.Add(INTERVALO);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@PROFESIONAL");
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@DESDE");
            vector_nombres.Add("@HASTA");
            vector_nombres.Add("@INTERVALO");

            string vprocedure = "AGENDA_PROFESIONALES_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        internal void cerrarCaja(string p, char p_2)
        {
            throw new NotImplementedException();
        }

        public int InsertDeportes(int ID_TITULAR, int BARRA, int ID_ADHERENTE, DateTime FE_APTO, DateTime FE_CARNET, int TIPO_CARNET, int MOROSO, DateTime FECHA, string USUARIO, int COD_SOC, int COD_DEP, string DNI, DateTime VENCIMIENTO, byte[] FOTO, string POC, decimal MONTO_MORA, DateTime? FECHA_MORA, string NOMBRE, string APELLIDO, string MAIL, string OBS)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_TITULAR);
            vector_contenidos.Add(COD_DEP);
            vector_contenidos.Add(COD_SOC);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(ID_ADHERENTE);
            vector_contenidos.Add(FE_APTO.ToShortDateString());
            vector_contenidos.Add(FE_CARNET.ToShortDateString());
            vector_contenidos.Add(TIPO_CARNET);
            vector_contenidos.Add(MOROSO);
            vector_contenidos.Add(USUARIO);
            vector_contenidos.Add(FECHA.ToShortDateString());
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(VENCIMIENTO);
            vector_contenidos.Add(FOTO);
            vector_contenidos.Add(POC);
            vector_contenidos.Add(MONTO_MORA);
            vector_contenidos.Add(FECHA_MORA);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(APELLIDO);
            vector_contenidos.Add(MAIL);
            vector_contenidos.Add(OBS);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Binary");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID_TITULAR");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@NRO_SOCIO");

            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@ID_ADHERENTE");
            vector_nombres.Add("@FE_APTO");
            vector_nombres.Add("@FE_CARNET");
            vector_nombres.Add("@TIPO_CARNET");
            vector_nombres.Add("@MOROSO");
            vector_nombres.Add("@USR_ALTA");
            vector_nombres.Add("@FE_ALTA");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@VENCIMIENTO");
            vector_nombres.Add("@FOTO");
            vector_nombres.Add("@POC");
            vector_nombres.Add("@MONTOMORA");
            vector_nombres.Add("@A_MORA");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@MAIL");
            vector_nombres.Add("@OBS");
            string vprocedure = "DEPORTES_ADM_I";



            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
            int retorno = 0;
            // FirebirdSql.Data.FirebirdClient.FbDataReader reader3 =
            //while (reader3.Read())
            //{
            //    retorno = Int32.Parse(reader3.GetString(reader3.GetOrdinal("RET")).Trim());

            //}

            //reader3.Close();

            return retorno;



        }

        public void UpdateDeportes(int ID, int ID_TITULAR, int BARRA, int ID_ADHERENTE, DateTime FE_APTO, DateTime FE_CARNET, int TIPO_CARNET, int MOROSO, DateTime FECHA, string USUARIO, int COD_SOC, int COD_DEP, string DNI, DateTime VENCIMIENTO, byte[] FOTO, string POC, decimal MONTO_MORA, DateTime? FECHA_MORA, string NOMBRE, string APELLIDO, string MAIL, string OBS)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(ID_TITULAR);
            vector_contenidos.Add(COD_DEP);
            vector_contenidos.Add(COD_SOC);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(ID_ADHERENTE);
            vector_contenidos.Add(FE_APTO.ToShortDateString());
            vector_contenidos.Add(FE_CARNET.ToShortDateString());
            vector_contenidos.Add(TIPO_CARNET);
            vector_contenidos.Add(MOROSO);
            vector_contenidos.Add(USUARIO);
            vector_contenidos.Add(FECHA.ToShortDateString());
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(VENCIMIENTO);
            vector_contenidos.Add(FOTO);
            vector_contenidos.Add(POC);
            vector_contenidos.Add(MONTO_MORA);
            vector_contenidos.Add(FECHA_MORA);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(APELLIDO);
            vector_contenidos.Add(MAIL);
            vector_contenidos.Add(OBS);
            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Binary");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@ID_TITULAR");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@NRO_SOCIO");

            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@ID_ADHERENTE");
            vector_nombres.Add("@FE_APTO");
            vector_nombres.Add("@FE_CARNET");
            vector_nombres.Add("@TIPO_CARNET");
            vector_nombres.Add("@MOROSO");
            vector_nombres.Add("@USR_MODIFICACION");
            vector_nombres.Add("@FE_MODIFICACION");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@VENCIMIENTO");
            vector_nombres.Add("@FOTO");
            vector_nombres.Add("@POC");
            vector_nombres.Add("@MONTOMORA");
            vector_nombres.Add("@A_MORA");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@MAIL");
            vector_nombres.Add("@OBS");
            string vprocedure = "DEPORTES_ADM_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }


        public void BajaDeportes(int ID)
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
            vector_nombres.Add("@FE_BAJA");
            vector_nombres.Add("@USR_BAJA");

            string vprocedure = "DEPORTES_ADM_B";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //Agregado por Sebastian - STORED SOCIOS DEPORTE ALTA

        public void InsertSociosActividad(int ID_DEPORTE, int NRO_SOCIO, int NRO_DEP, int BARRA, DateTime FECHA_DTO, string CAT_SOC, int PROFESIONAL, int ID_ARANCEL, decimal ARANCEL, int SECT_ACT, string USUARIO, DateTime FECHA, int ESTADO)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_DEPORTE);
            vector_contenidos.Add(NRO_DEP);
            vector_contenidos.Add(NRO_SOCIO);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(FECHA_DTO);
            vector_contenidos.Add(CAT_SOC);
            vector_contenidos.Add(PROFESIONAL);
            vector_contenidos.Add(ARANCEL);
            vector_contenidos.Add(ID_ARANCEL);
            vector_contenidos.Add(SECT_ACT);

            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(USUARIO);
            vector_contenidos.Add(ESTADO);


            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Float");

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");


            ArrayList vector_nombres = new ArrayList();


            vector_nombres.Add("@ID_DEPORTE");
            vector_nombres.Add("@NRO_DEP");

            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@A_DTO");
            vector_nombres.Add("@CAT_SOC");
            vector_nombres.Add("@PROFESIONAL");
            vector_nombres.Add("@ARANCEL");
            vector_nombres.Add("@ID_ARANCEL");
            vector_nombres.Add("@SECTACT");

            vector_nombres.Add("@F_ALTA");
            vector_nombres.Add("@USR_A");
            vector_nombres.Add("@ESTADO");





            string vprocedure = "SOCIO_ACTIVIDADES_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        
        
        /*(int ID, DateTime FECHA, int ESTADO)
        {

            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(ESTADO);



            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");


            ArrayList vector_nombres = new ArrayList();


            vector_nombres.Add("@ID");
            vector_nombres.Add("@F_BAJA");
            vector_nombres.Add("@USR");
            vector_nombres.Add("@ESTADO");

            string vprocedure = "SOCIO_ACTIVIDADES_D";


            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

            //Control Actividad si dar de baja el registro cabecera;

            string query = "select D.ID from socio_actividades DA, deportes_Adm D , Sectact S  where  coalesce(DA.F_BAJA,'1') <> '1' and S.ID= DA.sectact    and       DA.ID_DEPORTE =D.ID  and S.DETALLE like '%CUOTA%'    AND DA.ID= " + ID.ToString();
            try
            {
                DataRow[] foundRows = this.BO_EjecutoDataTable(query).Select();
                if (foundRows.Length == 0) ;
                {

                    this.BajaDeportes(Int32.Parse(foundRows[0][0].ToString().Trim()));

                }
            }
            catch (Exception ex)
            {

            }

        }*/

        //Agregado por Sebastian - STORED ASISTENCIA ALTA

        public void AltaAsistencia(int SECTACT, int P, string NOMBRE, string APELLIDO, DateTime FECHA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(0);
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(P);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(APELLIDO);
            vector_contenidos.Add(FECHA);


            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");



            ArrayList vector_nombres = new ArrayList();


            vector_nombres.Add("@ID");
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@P");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@FECHA");

            string vprocedure = "P_ASISTENCIA_DEPORTES_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }
        //Agregado por Sebastian - STORED UPDATE ASISTENCIA
        public void UpdateAsistencia(int ID, int SECTACT, int P, string NOMBRE, string APELLIDO, DateTime FECHA)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(P);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(APELLIDO);
            vector_contenidos.Add(FECHA);


            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");



            ArrayList vector_nombres = new ArrayList();


            vector_nombres.Add("@ID");
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@P");
            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@FECHA");

            string vprocedure = "P_ASISTENCIA_DEPORTES_U";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

     

        //Agregado Por Sebastian - Stored Alta Bono

        //Agregado por Sebastian -Stored Baja Bono

        public void BajaOdontologico(int Bono, string User, DateTime Fecha)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Bono);
            vector_contenidos.Add(User);
            vector_contenidos.Add(Fecha);




            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");



            ArrayList vector_nombres = new ArrayList();



            vector_nombres.Add("@ID");
            vector_nombres.Add("@USR_BAJA");
            vector_nombres.Add("@FE_BAJA");
            string vprocedure = "P_BONO_ODONTOLOGICO_B";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);


            this.UpdateTurnoBono(Bono, 0);



        }
        //Agregado por Sebastian 
        public void UpdateTurnoBono(int BONO, int Turno)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Turno);
            vector_contenidos.Add(BONO);


            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");



            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID");
            vector_nombres.Add("@BONO");

            string vprocedure = "P_BONO_ODONTOLOGICO_TURNO";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);



        }

        public void InsertPagoBono(int Bono, int TipoPago, decimal Monto, string Cuota, string POC, DateTime fecha, int CodInt, int CodCp, DateTime? A_Dto, string User, string Fupdate, string NroBeneficio, string Rol, int Nro_Soc, int Nro_Dep, int Barra, int Nro_Soc_titular, int Nro_dep_titular, int PlanCuenta,int SUBCODIGO)
        {
            db resultado = new db();



            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(0);
            vector_contenidos.Add(Bono);
            vector_contenidos.Add(TipoPago);
            vector_contenidos.Add(Monto);
            vector_contenidos.Add(Cuota);
            vector_contenidos.Add(fecha);
            vector_contenidos.Add(CodInt);
            if (A_Dto == null)
                vector_contenidos.Add("null");
            else
                vector_contenidos.Add(A_Dto);
            vector_contenidos.Add(User);
            vector_contenidos.Add(Fupdate);
            vector_contenidos.Add(NroBeneficio);
            vector_contenidos.Add(Rol);


            vector_contenidos.Add(Nro_Soc);
            vector_contenidos.Add(Nro_Dep);
            vector_contenidos.Add(Barra);
            vector_contenidos.Add(Nro_Soc_titular);
            vector_contenidos.Add(POC);
            vector_contenidos.Add(CodCp);
            vector_contenidos.Add(PlanCuenta);
            vector_contenidos.Add(Nro_dep_titular);
            vector_contenidos.Add(SUBCODIGO);
            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            ArrayList vector_nombres = new ArrayList();


            vector_nombres.Add("@ID");
            vector_nombres.Add("@BONO");
            vector_nombres.Add("@TIPOPAGO");
            vector_nombres.Add("@MONTO");
            vector_nombres.Add("@CUOTA");
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@CODINT");
            vector_nombres.Add("@A_DTO");
            vector_nombres.Add("@USR_U");
            vector_nombres.Add("@F_U");
            vector_nombres.Add("@NRO_BENEF");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@NRO_SOCIO_TITULAR");
            vector_nombres.Add("@POC");
            vector_nombres.Add("@CODCP");
            vector_nombres.Add("@PLAN_CUENTA");
            vector_nombres.Add("@NRO_DEP_TITULAR");
            vector_nombres.Add("@SUBCOD");
            string vprocedure = "P_PAGOS_BONO_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        //Agregado por Sebastian - VER 14-12-2015
        public void Baja_PagosBono(int idBono)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(idBono);
            vector_contenidos.Add(VGlobales.vp_username);

            vector_contenidos.Add(System.DateTime.Now.ToShortDateString());

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Varchar");


            vector_tipos.Add("FbDbType.Varchar");


            ArrayList vector_nombres = new ArrayList();



            vector_nombres.Add("@ID");

            vector_nombres.Add("@USR_B");

            vector_nombres.Add("@FE_B");

            string vprocedure = "PAGOS_BONO_D";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }


        //Agregado por Sebastian 
        public void InsertBonoDetalle(int idBono, decimal Monto, int CodInt, int CodCp, int SectAct, string ROL)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(idBono);
            vector_contenidos.Add(Monto);

            vector_contenidos.Add(CodInt);
            vector_contenidos.Add(CodCp);
            vector_contenidos.Add(SectAct);
            vector_contenidos.Add(ROL);
            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Float");


            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.String");

            ArrayList vector_nombres = new ArrayList();



            vector_nombres.Add("@BONO");

            vector_nombres.Add("@MONTO");

            vector_nombres.Add("@CODINT");
            vector_nombres.Add("@CODCP");
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@ROL");
            string vprocedure = "BONO_DETALLE_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }
        //Agregado por Sebastian 
        public void UpdateFormaPagoBonoOdonto(int Bono, string FormaPago)
        {
            db resultado = new db();



            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Bono);
            vector_contenidos.Add(FormaPago);

            ArrayList vector_tipos = new ArrayList();


            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");



            ArrayList vector_nombres = new ArrayList();


            vector_nombres.Add("@ID");
            vector_nombres.Add("@PAGO");
            string vprocedure = "P_BONO_ODONTOLOGICO_F_PAGO";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }
        //Agregado por Sebastian 
        public void InsertTratamientoOdontologico(int CodInt, int CodCp, string Descripcion, int SecAct)
        {
            db resultado = new db();



            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(CodInt);
            vector_contenidos.Add(CodCp);
            vector_contenidos.Add(Descripcion);
            vector_contenidos.Add(SecAct);
            ArrayList vector_tipos = new ArrayList();


            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");


            ArrayList vector_nombres = new ArrayList();


            vector_nombres.Add("@COD_INT");
            vector_nombres.Add("@COD_CP");
            vector_nombres.Add("@DESCRIPCION");
            vector_nombres.Add("@SECACT");

            string vprocedure = "P_TRATAMIENTO_ODONTOLOGICO_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }
        //Agregado por Sebastian 
        public void UpdateTratamientoOdontologico(int ID, int CodInt, int CodCp, string Descripcion, int SecAct)
        {
            db resultado = new db();



            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(CodInt);
            vector_contenidos.Add(CodCp);
            vector_contenidos.Add(Descripcion);
            vector_contenidos.Add(SecAct);
            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");


            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@COD_INT");
            vector_nombres.Add("@COD_CP");
            vector_nombres.Add("@DESCRIPCION");
            vector_nombres.Add("@SECACT");

            string vprocedure = "P_TRATAMIENTO_ODONTOLOGICO_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        //Agregado por Sebastian 
        public void DeleteTratamientoOdontologico(int ID)
        {
            db resultado = new db();



            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");



            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");


            string vprocedure = "P_TRATAMIENTO_ODONTOLOGICO_D";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);



        }
        #region 2902

        // Insert Hoteles- Con Modificacion 25/01/2016
        public void InsertHotel(string Nombre, int Provincia, int Localidad, string Domicilio, string Telefono, int Estrellas, string Obs, string Cuit, string Responsable, string Email_ope, string Email_Reservas, string Email_adm, string Email_Info, string CheckIn, string CheckOut, DateTime Fecha, string User, int Propio, int Social, decimal late_chk)
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
            vector_contenidos.Add(late_chk);
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
            vector_tipos.Add("FbDbType.Decimal");
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

            string vprocedure = "P_HOTEL_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);



        }
        //Update Hoteles

        public void UpdateHotel(int ID, string Nombre, int Provincia, int Localidad, string Domicilio, string Telefono, int Estrellas, string Obs, string Cuit, string Responsable, string Email_ope, string Email_Reservas, string Email_adm, string Email_Info, string CheckIn, string CheckOut, DateTime Fecha, string User, int Propio, int Social, decimal late_chk)
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
            vector_contenidos.Add(late_chk);

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
            vector_tipos.Add("FbDbType.Decimal");

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

        //Agregado por Sebastian 19/10/2015

        public void InsertBonoTurismo(int NRO_SOCIO_TITULAR, int NRO_SOCIO, int NRO_DEP, int NRO_DEP_TITULAR, int BARRA, DateTime FE_BONO, int PROFESIONAL, int SEC_ACT, int TRAT, decimal SALDO_INICIAL, decimal SALDO_NETO, decimal INTERES, string NOMBRE, string APELLIDO, string DNI, string F_NACIM, string EDAD, string TELEFONO, string EMAIL, int AAR, int ACRJP1, int ACRJP2, int ACRJP3, int PAR, int PCRJP1, int PCRJP2, int PCRJP3, string OBS, string PAGO, int OPERADOR, string TIPO_PASAJE, string CLASE_PASAJE, string USR, string TIPO, int SALIDA, int DIAS, string HABITACION, int CONTRALOR,string ROL,int CODINT,int SUBCOD)
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
            ArrayList vector_tipos = new  ArrayList();
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
            string vprocedure = "P_BONO_TURISMO_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        public void BajaTurismo(int Bono, string User, DateTime Fecha)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Bono);
            vector_contenidos.Add(User);
            vector_contenidos.Add(Fecha);




            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");



            ArrayList vector_nombres = new ArrayList();



            vector_nombres.Add("@ID");
            vector_nombres.Add("@USR_BAJA");
            vector_nombres.Add("@FE_BAJA");
            string vprocedure = "P_BONO_TURISMO_BAJA";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }

        public void Bono_Persona_Ins(int BONO, int ID_TITULAR, int NRO_SOC, int NRO_DEP, int BARRA, string NOMBRE, string APELLIDO, string F_NACIM, string EDAD, string TELEFONO, string EMAIL, string DNI, string ROL)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(0);
            vector_contenidos.Add(BONO);
            vector_contenidos.Add(ROL);
            vector_contenidos.Add(ID_TITULAR);
            vector_contenidos.Add(NRO_SOC);
            vector_contenidos.Add(NRO_DEP);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(NOMBRE);
            vector_contenidos.Add(APELLIDO);
            vector_contenidos.Add(F_NACIM);
            vector_contenidos.Add(EDAD);
            vector_contenidos.Add(TELEFONO);
            vector_contenidos.Add(EMAIL);
            vector_contenidos.Add(DNI);


            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");


            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@BONO");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@ID_TITULAR");
            vector_nombres.Add("@NRO_SOC");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@BARRA");

            vector_nombres.Add("@NOMBRE");
            vector_nombres.Add("@APELLIDO");
            vector_nombres.Add("@F_NACIM");
            vector_nombres.Add("@EDAD");
            vector_nombres.Add("@TELEFONO");
            vector_nombres.Add("@EMAIL");
            vector_nombres.Add("@DNI");
            string vprocedure = "P_BONO_PERSONAS_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }

        public void Bono_Pasaje_Ins(int BONO, int CANTIDAD, string BOLETO, DateTime SALIDA, int ORIGEN, int DESTINO, decimal IMPORTE_UNITARIO, decimal IMPORTE_TOTAL)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(0);
            vector_contenidos.Add(BONO);
            //   vector_contenidos.Add(VGlobales.vp_role);
            vector_contenidos.Add(CANTIDAD);
            vector_contenidos.Add(BOLETO);
            vector_contenidos.Add(SALIDA);
            vector_contenidos.Add(ORIGEN);
            vector_contenidos.Add(DESTINO);
            vector_contenidos.Add(IMPORTE_UNITARIO);
            vector_contenidos.Add(IMPORTE_TOTAL);




            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");


            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@BONO");
            vector_nombres.Add("@CANTIDAD");
            vector_nombres.Add("@BOLETO");
            vector_nombres.Add("@SALIDA");
            vector_nombres.Add("@ORIGEN");
            vector_nombres.Add("@DESTINO");

            vector_nombres.Add("@IMPORTE_UNITARIO");
            vector_nombres.Add("@IMPORTE_TOTAL");

            string vprocedure = "P_BONO_TURISMO_PASAJES_I";
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

       



        public void Tipo_Habitacion_Ins(string Tipo, int Camas)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Tipo);
            vector_contenidos.Add(Camas);

            // vector_contenidos.Add(System.DateTime.Now.ToShortDateString());

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Varchar");





            ArrayList vector_nombres = new ArrayList();





            vector_nombres.Add("@TIPO");

            vector_nombres.Add("@CAMAS");

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


        public void PlanCuota_Insert(int Socio, int Dep, decimal SaldoInicial, decimal Saldo, int Bono)
        {
            db resultado = new db();



            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Socio);
            vector_contenidos.Add(Dep);
            vector_contenidos.Add(SaldoInicial);
            vector_contenidos.Add(Saldo);
            vector_contenidos.Add(Bono);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add(VGlobales.vp_role);
            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@NRO_SOCIO");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@SALDO_INICIAL");
            vector_nombres.Add("@SALDO");
            vector_nombres.Add("@BONO");
            vector_nombres.Add("@U_ALTA");
            vector_nombres.Add("@F_ALTA");
            vector_nombres.Add("@ROL");

            string vprocedure = "P_PLAN_CUENTA_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);





        }




        public void PlanCuota_Update(int ID, decimal Saldo)
        {
            db resultado = new db();


            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(Saldo);

            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);
            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Float");

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@SALDO");


            vector_nombres.Add("@U_ALTA");
            vector_nombres.Add("@F_ALTA");

            string vprocedure = "P_PLAN_CUENTA_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        public void PlanCuenta_Insert(int Socio, int Dep, decimal SaldoInicial, decimal Saldo, int Bono, int Tipo)
        {
            db resultado = new db();



            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(Socio);
            vector_contenidos.Add(Dep);
            vector_contenidos.Add(SaldoInicial);
            vector_contenidos.Add(Saldo);
            vector_contenidos.Add(Bono);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add(VGlobales.vp_role);
            vector_contenidos.Add(Tipo);
            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@NRO_SOCIO");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@SALDO_INICIAL");
            vector_nombres.Add("@SALDO");
            vector_nombres.Add("@BONO");
            vector_nombres.Add("@U_ALTA");
            vector_nombres.Add("@F_ALTA");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@TIPO");

            string vprocedure = "P_PLAN_CUENTA_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);





        }

        public void Reintegro(int Bono, decimal Monto, string Obs)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(0);
            vector_contenidos.Add(Bono);

            vector_contenidos.Add(Monto);
            vector_contenidos.Add(Obs);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);




            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");


            ArrayList vector_nombres = new ArrayList();


            vector_nombres.Add("@ID");
            vector_nombres.Add("@BONO");
            vector_nombres.Add("@MONTO");
            vector_nombres.Add("@OBS");
            vector_nombres.Add("@USR_ALTA");
            vector_nombres.Add("@FE_ALTA");
            string vprocedure = "P_BONO_REINTEGRO_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }


        public void PlanCuenta_Update(int ID, decimal Saldo)
        {
            db resultado = new db();


            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(Saldo);

            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(System.DateTime.Now);
            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Float");

            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@SALDO");


            vector_nombres.Add("@U_ALTA");
            vector_nombres.Add("@F_ALTA");

            string vprocedure = "P_PLAN_CUENTA_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }

        public void Pagar_Cuota(int ID, int Recibo,int Bono,int FormaPago, DateTime FechaPago)
        {
            db resultado = new db();


            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(VGlobales.vp_username);

            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add("P");
            vector_contenidos.Add(Bono);
            vector_contenidos.Add(FechaPago);
            vector_contenidos.Add(Recibo);
            vector_contenidos.Add(FormaPago);

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Varchar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@ID");
            vector_nombres.Add("@USR_U");
            vector_nombres.Add("@FE_U");
            vector_nombres.Add("@POC");
            vector_nombres.Add("@NRO_BONO_CAJA");
            vector_nombres.Add("@F_PAGO");
            vector_nombres.Add("@NRO_RECIBO_CAJA");
            vector_nombres.Add("@FORMA_PAGO_CAJA");
            string vprocedure = "P_PAGO_BONO_PAGO_CUOTA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }


        //Agregado por Sebastian 3/3/2016


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

            vector_nombres.Add("@NRO_SOCIO");
            vector_nombres.Add("@NRO_DEP");
            vector_nombres.Add("@TRAMITE");
            vector_nombres.Add("@ENFERMEDAD");
            vector_nombres.Add("@CIRUGIA");
            vector_nombres.Add("@U_ALTA");
            vector_nombres.Add("@F_ALTA");

            string vprocedure = "P_HOTEL_DIAS_ALOJAMIENTO_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }
        #endregion
    }
}