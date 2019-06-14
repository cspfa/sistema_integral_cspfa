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

namespace SOCIOS.BO
{
    class bo_Caja:bo
    {
        db resultado = new db();

        //STORED ASIGNAR RECIBO C A COMPROBANTE
        public void asignarReciboC(int ID, string PTO_VTA)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(PTO_VTA);
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_nombres.Add("@PIN_ID");
            vector_nombres.Add("@PIN_PTO_VTA");
            string vprocedure = "ASIGNAR_RECIBO_C";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED IMPORTAR CAJA DIARIA
        public void importarCajaDiaria(string FECHA, string US_ALTA, decimal INGRESOS_EFECTIVO, decimal INGRESOS_OTROS, decimal SUBTOTAL_INGRESOS, decimal EGRESOS,
        decimal SALDO_CAJA, string ROL, decimal TOTAL, int DEPOSITADA, int BANCO, int IMPUTACION, int CAJA_DEPOSITADA, string CODIGO_DEPOSITO, int ID_ROL)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(US_ALTA);
            vector_contenidos.Add(INGRESOS_EFECTIVO);
            vector_contenidos.Add(INGRESOS_OTROS);
            vector_contenidos.Add(SUBTOTAL_INGRESOS);
            vector_contenidos.Add(EGRESOS);
            vector_contenidos.Add(SALDO_CAJA);
            vector_contenidos.Add(ROL);
            vector_contenidos.Add(TOTAL);
            vector_contenidos.Add(DEPOSITADA);
            vector_contenidos.Add(BANCO);
            vector_contenidos.Add(IMPUTACION);
            vector_contenidos.Add(CAJA_DEPOSITADA);
            vector_contenidos.Add(CODIGO_DEPOSITO);
            vector_contenidos.Add(ID_ROL);

            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");

            vector_nombres.Add("@PIN_FECHA");
            vector_nombres.Add("@PIN_US_ALTA");
            vector_nombres.Add("@PIN_INGRESOS_EFECTIVO");
            vector_nombres.Add("@PIN_INGRESOS_OTROS");
            vector_nombres.Add("@PIN_SUBTOTAL_INGRESOS");
            vector_nombres.Add("@PIN_EGRESOS");
            vector_nombres.Add("@PIN_SALDO_CAJA");
            vector_nombres.Add("@PIN_ROL");
            vector_nombres.Add("@PIN_TOTAL");
            vector_nombres.Add("@PIN_DEPOSITADA");
            vector_nombres.Add("@PIN_BANCO");
            vector_nombres.Add("@PIN_IMPUTACION");
            vector_nombres.Add("@PIN_CAJA_DEPOSITADA");
            vector_nombres.Add("@PIN_CODIGO_DEPOSITO");
            vector_nombres.Add("@PIN_ID_ROL");

            string vprocedure = "CAJA_DIARIA_IMPORTAR";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED IMPORTAR BONOS
        public void importarBonos(int NRO_COMP, int CUENTA_DEBE, int CUENTA_HABER, decimal VALOR, string FORMA_DE_PAGO, int SECTACT,
            string USUARIO_MOD, string FECHA_RECIBO, int ID_SOCIO, int ID_PROFESIONAL, string NOMBRE_SOCIO_TITULAR, string TIPO_SOCIO_TITULAR,
            string OBSERVACIONES, int BARRA, string NOMBRE_SOCIO, string TIPO_SOCIO, int DNI, string PTO_VTA, int CAJA_DIARIA, string ROL)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(NRO_COMP);
            vector_contenidos.Add(CUENTA_DEBE);
            vector_contenidos.Add(CUENTA_HABER);
            vector_contenidos.Add(VALOR);
            vector_contenidos.Add(FORMA_DE_PAGO);
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(USUARIO_MOD);
            vector_contenidos.Add(FECHA_RECIBO);
            vector_contenidos.Add(ID_SOCIO);
            vector_contenidos.Add(ID_PROFESIONAL);
            vector_contenidos.Add(NOMBRE_SOCIO_TITULAR);
            vector_contenidos.Add(TIPO_SOCIO_TITULAR);
            vector_contenidos.Add(OBSERVACIONES);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(NOMBRE_SOCIO);
            vector_contenidos.Add(TIPO_SOCIO);
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(PTO_VTA);
            vector_contenidos.Add(CAJA_DIARIA);
            vector_contenidos.Add(ROL);

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");

            vector_nombres.Add("@NRO_COMP");
            vector_nombres.Add("@CUENTA_DEBE");
            vector_nombres.Add("@CUENTA_HABER");
            vector_nombres.Add("@VALOR");
            vector_nombres.Add("@FORMA_DE_PAGO");
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@USUARIO_MOD");
            vector_nombres.Add("@FECHA_RECIBO");
            vector_nombres.Add("@ID_SOCIO");
            vector_nombres.Add("@ID_PROFESIONAL");
            vector_nombres.Add("@NOMBRE_SOCIO_TITULAR");
            vector_nombres.Add("@TIPO_SOCIO_TITULAR");
            vector_nombres.Add("@OBSERVACIONES");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@NOMBRE_SOCIO");
            vector_nombres.Add("@TIPO_SOCIO");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@PTO_VTA");
            vector_nombres.Add("@CAJA_DIARIA");
            vector_nombres.Add("@ROL");

            string vprocedure = "BONOS_CAJA_IMPORTAR";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED IMPORTAR RECIBOS
        public void importarRecibos(int NRO_COMP, int CUENTA_DEBE, int CUENTA_HABER, decimal VALOR, string FORMA_DE_PAGO, int SECTACT,
            string USUARIO_MOD, string FECHA_RECIBO, int ID_SOCIO, int ID_PROFESIONAL, string NOMBRE_SOCIO_TITULAR, string TIPO_SOCIO_TITULAR,
            string OBSERVACIONES, int BARRA, string NOMBRE_SOCIO, string TIPO_SOCIO, Int64 DNI, string PTO_VTA, int CAJA_DIARIA, string ROL, 
            int DEPOSITADO, string CAE, string CAE_VENC, int PTO_VTA_E, int NUMERO_E, string USR_FACT)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(NRO_COMP);
            vector_contenidos.Add(CUENTA_DEBE);
            vector_contenidos.Add(CUENTA_HABER);
            vector_contenidos.Add(VALOR);
            vector_contenidos.Add(FORMA_DE_PAGO);
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(USUARIO_MOD);
            vector_contenidos.Add(FECHA_RECIBO);
            vector_contenidos.Add(ID_SOCIO);
            vector_contenidos.Add(ID_PROFESIONAL);
            vector_contenidos.Add(NOMBRE_SOCIO_TITULAR);
            vector_contenidos.Add(TIPO_SOCIO_TITULAR);
            vector_contenidos.Add(OBSERVACIONES);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(NOMBRE_SOCIO);
            vector_contenidos.Add(TIPO_SOCIO);
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(PTO_VTA);
            vector_contenidos.Add(CAJA_DIARIA);
            vector_contenidos.Add(ROL);
            vector_contenidos.Add(DEPOSITADO);
            vector_contenidos.Add(CAE);
            vector_contenidos.Add(CAE_VENC);
            vector_contenidos.Add(PTO_VTA_E);
            vector_contenidos.Add(NUMERO_E);
            vector_contenidos.Add(USR_FACT);

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.BigInt");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");

            vector_nombres.Add("@NRO_COMP");
            vector_nombres.Add("@CUENTA_DEBE");
            vector_nombres.Add("@CUENTA_HABER");
            vector_nombres.Add("@VALOR");
            vector_nombres.Add("@FORMA_DE_PAGO");
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@USUARIO_MOD");
            vector_nombres.Add("@FECHA_RECIBO");
            vector_nombres.Add("@ID_SOCIO");
            vector_nombres.Add("@ID_PROFESIONAL");
            vector_nombres.Add("@NOMBRE_SOCIO_TITULAR");
            vector_nombres.Add("@TIPO_SOCIO_TITULAR");
            vector_nombres.Add("@OBSERVACIONES");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@NOMBRE_SOCIO");
            vector_nombres.Add("@TIPO_SOCIO");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@PTO_VTA");
            vector_nombres.Add("@CAJA_DIARIA");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@DEPOSITADO");
            vector_nombres.Add("@CAE");
            vector_nombres.Add("@CAE_VENC");
            vector_nombres.Add("@PTO_VTA_E");
            vector_nombres.Add("@NUMERO_E");
            vector_nombres.Add("@USR_FACT");

            string vprocedure = "RECIBOS_CAJA_IMPORTAR";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }
        
        //STORED MODIFICAR CAJA DIARIA
        public void modificarCajaDiaria(decimal INGRESOS_EFECTIVO, decimal INGRESOS_OTROS, decimal SUBTOTAL_INGRESOS, decimal EGRESOS, 
            decimal SALDO_CAJA, decimal TOTAL, int ID)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(INGRESOS_EFECTIVO);
            vector_contenidos.Add(INGRESOS_OTROS);
            vector_contenidos.Add(SUBTOTAL_INGRESOS);
            vector_contenidos.Add(EGRESOS);
            vector_contenidos.Add(SALDO_CAJA);            
            vector_contenidos.Add(TOTAL);
            vector_contenidos.Add(ID);
            
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Integer");

            vector_nombres.Add("@INGRESOS_EFECTIVO");
            vector_nombres.Add("@INGRESOS_OTROS");
            vector_nombres.Add("@SUBTOTAL_INGRESOS");
            vector_nombres.Add("@EGRESOS");
            vector_nombres.Add("@SALDO_CAJA");
            vector_nombres.Add("@TOTAL");
            vector_nombres.Add("@ID");

            string vprocedure = "CAJA_DIARIA_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED BAJA GRUPO DE ARANCELES
        public void bajaArancelesNuevos(int SECTACT, string CATSOC, int PROFESIONAL, string FE_BAJA)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(CATSOC.Trim());
            vector_contenidos.Add(PROFESIONAL);
            vector_contenidos.Add(FE_BAJA);

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Date");

            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@CATSOC");
            vector_nombres.Add("@PROFESIONAL");
            vector_nombres.Add("@FE_BAJA");

            string vprocedure = "ARANCELES_B";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR GRUPO DE ARANCELES
        public void modificarArancelesNuevos(int SECTACT, string CATSOC, int PROFESIONAL, decimal ARANCEL, string US_MOD, string FE_MOD)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(CATSOC.Trim());
            vector_contenidos.Add(PROFESIONAL);
            vector_contenidos.Add(ARANCEL);
            vector_contenidos.Add(US_MOD);
            vector_contenidos.Add(FE_MOD);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");

            
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@CATSOC");
            vector_nombres.Add("@PROFESIONAL");
            vector_nombres.Add("@ARANCEL");
            vector_nombres.Add("@US_MOD");
            vector_nombres.Add("@FE_MOD");

            string vprocedure = "ARANCELES_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVO ARANCEL ABM NUEVO DE ARANCELES
        public void agregarArancel(int SECTACT, string CATSOC, int PROFESIONAL, decimal ARANCEL, string US_ALTA, string FE_ALTA, int REGIMEN, int HABITACION)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(CATSOC.Trim());
            vector_contenidos.Add(PROFESIONAL);
            vector_contenidos.Add(ARANCEL);
            vector_contenidos.Add(US_ALTA);
            vector_contenidos.Add(FE_ALTA);
            vector_contenidos.Add(REGIMEN);
            vector_contenidos.Add(HABITACION);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@CATSOC");
            vector_nombres.Add("@PROFESIONAL");
            vector_nombres.Add("@ARANCEL");
            vector_nombres.Add("@US_ALTA");
            vector_nombres.Add("@FE_ALTA");
            vector_nombres.Add("@REGIMEN");
            vector_nombres.Add("@HABITACION");

            string vprocedure = "ARANCELES_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED IMPRIMIR RECIBOS EN BLANCO
        public void recibosEnBlanco(int DESDE, int HASTA, string USUARIO, int DESTINO, string PTO_VTA, int ID, string USUARIO_MOD)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(DESDE);
            vector_contenidos.Add(HASTA);
            vector_contenidos.Add(USUARIO);
            vector_contenidos.Add(DESTINO);
            vector_contenidos.Add(PTO_VTA);
            vector_contenidos.Add(ID);
            vector_contenidos.Add(USUARIO_MOD);
            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            
            vector_nombres.Add("@DESDE");
            vector_nombres.Add("@HASTA");
            vector_nombres.Add("@USUARIO");
            vector_nombres.Add("@DESTINO");
            vector_nombres.Add("@PTO_VTA");
            vector_nombres.Add("@ID");
            vector_nombres.Add("@USUARIO_MOD");

            string vprocedure = "RECIBOS_CAJA_EN_BLANCO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED IMPRIMIR BONOS EN BLANCO
        public void bonosEnBlanco(int DESDE, int HASTA, string USUARIO, int DESTINO, string PTO_VTA, int ID, string USUARIO_MOD)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(DESDE);
            vector_contenidos.Add(HASTA);
            vector_contenidos.Add(USUARIO);
            vector_contenidos.Add(DESTINO);
            vector_contenidos.Add(PTO_VTA);
            vector_contenidos.Add(ID);
            vector_contenidos.Add(USUARIO_MOD);

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");

            vector_nombres.Add("@DESDE");
            vector_nombres.Add("@HASTA");
            vector_nombres.Add("@USUARIO");
            vector_nombres.Add("@DESTINO");
            vector_nombres.Add("@PTO_VTA");
            vector_nombres.Add("@ID");
            vector_nombres.Add("@USUARIO_MOD");

            string vprocedure = "BONOS_CAJA_EN_BLANCO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ANULAR RECIBO
        public void anularRecibo(int ID, string ANULADO, string PTO_VTA)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(ID);
            vector_contenidos.Add(ANULADO);
            vector_contenidos.Add(PTO_VTA);
            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            
            vector_nombres.Add("@ID");
            vector_nombres.Add("@ANULADO");
            vector_nombres.Add("@PTO_VTA");

            string vprocedure = "RECIBOS_CAJA_ANULADO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ANULAR BONO
        public void anularBono(int ID, string ANULADO, string PTO_VTA)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(ID);
            vector_contenidos.Add(ANULADO);
            vector_contenidos.Add(PTO_VTA);

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            vector_nombres.Add("@ID");
            vector_nombres.Add("@ANULADO");
            vector_nombres.Add("@PTO_VTA");

            string vprocedure = "BONOS_CAJA_ANULADO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED SUMAR BONO
        public void sumarBono(string PTO_VTA, int NUM_BONO)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(PTO_VTA);
            vector_contenidos.Add(NUM_BONO);

            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");

            vector_nombres.Add("@PTO_VTA");
            vector_nombres.Add("@NUM_BONO");

            string vprocedure = "SUMAR_BONO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED SUMAR RECIBO
        public void sumarRecibo(string PTO_VTA, int NUM_RECIBO)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(PTO_VTA);
            vector_contenidos.Add(NUM_RECIBO);
           
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");

            vector_nombres.Add("@PTO_VTA");
            vector_nombres.Add("@NUM_RECIBO");

            string vprocedure = "SUMAR_RECIBO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GRABAR NRO RECIBO EN INGRESOS A PROCESAR
        public void reciboEnIngresos(int SECUENCIA, string NRO_RECIBO, decimal IMPORTE)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(SECUENCIA);
            vector_contenidos.Add(NRO_RECIBO);
            vector_contenidos.Add(IMPORTE);

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Numeric");
            
            vector_nombres.Add("@SECUENCIA");
            vector_nombres.Add("@NRO_RECIBO");
            vector_nombres.Add("@IMPORTE");

            string vprocedure = "INGRESOS_A_PROCESAR_RECIBO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GRABAR NRO BONO EN INGRESOS A PROCESAR
        public void bonoEnIngresos(int SECUENCIA, string NRO_BONO, decimal IMPORTE)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(SECUENCIA);
            vector_contenidos.Add(NRO_BONO);
            vector_contenidos.Add(IMPORTE);

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Numeric");

            vector_nombres.Add("@SECUENCIA");
            vector_nombres.Add("@NRO_BONO");
            vector_nombres.Add("@IMPORTE");

            string vprocedure = "INGRESOS_A_PROCESAR_BONO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVO RECIBO DE CAJA
        public void nuevoReciboCaja(int ID, int CUENTA_DEBE, int CUENTA_HABER, int SECTACT, int ID_SOCIO, decimal VALOR,
            string FORMA_DE_PAGO, string USUARIO, int ID_PROFESIONAL, string NOMBRE_SOCIO_TITULAR, string TIPO_SOCIO_TITULAR,
            string OBSERVACIONES, string FECHA_RECIBO, int BARRA, string NOMBRE_SOCIO, string DNI, string TIPO_SOCIO_NO_TITULAR, 
            int NRO_COMP, string PTO_VTA, int REINTEGRO_DE, string BANCO_DEPO)
        {

            try
            {
                Valido_Recibo_Existe(PTO_VTA, NRO_COMP);

                ArrayList vector_contenidos = new ArrayList();
                ArrayList vector_tipos = new ArrayList();
                ArrayList vector_nombres = new ArrayList();

                vector_contenidos.Add(ID);
                vector_contenidos.Add(CUENTA_DEBE);
                vector_contenidos.Add(CUENTA_HABER);
                vector_contenidos.Add(SECTACT);
                vector_contenidos.Add(ID_SOCIO);
                vector_contenidos.Add(VALOR);
                vector_contenidos.Add(FORMA_DE_PAGO);
                vector_contenidos.Add(USUARIO);
                vector_contenidos.Add(ID_PROFESIONAL);
                vector_contenidos.Add(NOMBRE_SOCIO_TITULAR);
                vector_contenidos.Add(TIPO_SOCIO_TITULAR);
                vector_contenidos.Add(OBSERVACIONES);
                vector_contenidos.Add(FECHA_RECIBO);
                vector_contenidos.Add(BARRA);
                vector_contenidos.Add(NOMBRE_SOCIO);
                vector_contenidos.Add(DNI);
                vector_contenidos.Add(TIPO_SOCIO_NO_TITULAR);
                vector_contenidos.Add(NRO_COMP);
                vector_contenidos.Add(PTO_VTA);
                vector_contenidos.Add(REINTEGRO_DE);
                vector_contenidos.Add(BANCO_DEPO);

                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Numeric");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Char");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Char");

                vector_nombres.Add("@ID");
                vector_nombres.Add("@CUENTA_DEBE");
                vector_nombres.Add("@CUENTA_HABER");
                vector_nombres.Add("@SECTACT");
                vector_nombres.Add("@ID_SOCIO");
                vector_nombres.Add("@VALOR");
                vector_nombres.Add("@FORMA_DE_PAGO");
                vector_nombres.Add("@USUARIO");
                vector_nombres.Add("@ID_PROFESIONAL");
                vector_nombres.Add("@NOMBRE_SOCIO_TITULAR");
                vector_nombres.Add("@TIPO_SOCIO_TITULAR");
                vector_nombres.Add("@OBSERVACIONES");
                vector_nombres.Add("@FECHA_RECIBO");
                vector_nombres.Add("@BARRA");
                vector_nombres.Add("@NOMBRE_SOCIO");
                vector_nombres.Add("@DNI");
                vector_nombres.Add("@TIPO_SOCIO_NO_TITULAR");
                vector_nombres.Add("@NRO_COMP");
                vector_nombres.Add("@PTO_VTA");
                vector_nombres.Add("@REINTEGRO_DE");
                vector_nombres.Add("@BANCO_DEPO");

                string vprocedure = "RECIBOS_CAJA_I";

                resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }


        public void nuevoReciboCaja_NC(int ID, int CUENTA_DEBE, int CUENTA_HABER, int SECTACT, int ID_SOCIO, decimal VALOR,
          string FORMA_DE_PAGO, string USUARIO, int ID_PROFESIONAL, string NOMBRE_SOCIO_TITULAR, string TIPO_SOCIO_TITULAR,
          string OBSERVACIONES, string FECHA_RECIBO, int BARRA, string NOMBRE_SOCIO, string DNI, string TIPO_SOCIO_NO_TITULAR,
          int NRO_COMP, string PTO_VTA, int REINTEGRO_DE, string BANCO_DEPO,int NUMERO_NC,string CAE_NC, string CAE_VENC_NC,string USR_NC)
        {

            try
            {
                Valido_Recibo_Existe(PTO_VTA, NRO_COMP);

                ArrayList vector_contenidos = new ArrayList();
                ArrayList vector_tipos = new ArrayList();
                ArrayList vector_nombres = new ArrayList();

                vector_contenidos.Add(ID);
                vector_contenidos.Add(CUENTA_DEBE);
                vector_contenidos.Add(CUENTA_HABER);
                vector_contenidos.Add(SECTACT);
                vector_contenidos.Add(ID_SOCIO);
                vector_contenidos.Add(VALOR);
                vector_contenidos.Add(FORMA_DE_PAGO);
                vector_contenidos.Add(USUARIO);
                vector_contenidos.Add(ID_PROFESIONAL);
                vector_contenidos.Add(NOMBRE_SOCIO_TITULAR);
                vector_contenidos.Add(TIPO_SOCIO_TITULAR);
                vector_contenidos.Add(OBSERVACIONES);
                vector_contenidos.Add(FECHA_RECIBO);
                vector_contenidos.Add(BARRA);
                vector_contenidos.Add(NOMBRE_SOCIO);
                vector_contenidos.Add(DNI);
                vector_contenidos.Add(TIPO_SOCIO_NO_TITULAR);
                vector_contenidos.Add(NRO_COMP);
                vector_contenidos.Add(PTO_VTA);
                vector_contenidos.Add(REINTEGRO_DE);
                vector_contenidos.Add(BANCO_DEPO);
            
                vector_contenidos.Add(NUMERO_NC);
                vector_contenidos.Add(CAE_NC);
                vector_contenidos.Add(CAE_VENC_NC);
                vector_contenidos.Add(USR_NC);

                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Numeric");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Char");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Char");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.VarChar");

                vector_nombres.Add("@ID");
                vector_nombres.Add("@CUENTA_DEBE");
                vector_nombres.Add("@CUENTA_HABER");
                vector_nombres.Add("@SECTACT");
                vector_nombres.Add("@ID_SOCIO");
                vector_nombres.Add("@VALOR");
                vector_nombres.Add("@FORMA_DE_PAGO");
                vector_nombres.Add("@USUARIO");
                vector_nombres.Add("@ID_PROFESIONAL");
                vector_nombres.Add("@NOMBRE_SOCIO_TITULAR");
                vector_nombres.Add("@TIPO_SOCIO_TITULAR");
                vector_nombres.Add("@OBSERVACIONES");
                vector_nombres.Add("@FECHA_RECIBO");
                vector_nombres.Add("@BARRA");
                vector_nombres.Add("@NOMBRE_SOCIO");
                vector_nombres.Add("@DNI");
                vector_nombres.Add("@TIPO_SOCIO_NO_TITULAR");
                vector_nombres.Add("@NRO_COMP");
                vector_nombres.Add("@PTO_VTA");
                vector_nombres.Add("@REINTEGRO_DE");
                vector_nombres.Add("@BANCO_DEPO");

                string vprocedure = "RECIBOS_CAJA_NC_I";

                resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Valido_Recibo_Existe(string PTO_VTA,int RECIBO)
        {
            string QUERY = "SELECT ID FROM RECIBOS_CAJA WHERE PTO_VTA = '" + PTO_VTA + "' AND NRO_COMP = " + RECIBO;

            DataRow[] foundRows;
            foundRows = this.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {
                throw new Exception("Ya existe ese numero de recibo asociado a ese punto de venta!");
            }
        }


        //STORED NUEVO BONO DE CAJA
        public void nuevoBonoCaja(int ID, int CUENTA_DEBE, int CUENTA_HABER, int SECTACT, int ID_SOCIO, decimal VALOR, string FORMA_DE_PAGO,
            string USUARIO, int ID_PROFESIONAL, string NOMBRE_SOCIO_TITULAR, string TIPO_SOCIO_TITULAR, string OBSERVACIONES,
            string FECHA_RECIBO, int BARRA, string NOMBRE_SOCIO, string DNI, string TIPO_SOCIO_NO_TITULAR, int NRO_COMP, string PTO_VTA, 
            int REINTEGRO_DE, string BANCO_DEPO)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(ID);
            vector_contenidos.Add(CUENTA_DEBE);
            vector_contenidos.Add(CUENTA_HABER);
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(ID_SOCIO);
            vector_contenidos.Add(VALOR);
            vector_contenidos.Add(FORMA_DE_PAGO);
            vector_contenidos.Add(USUARIO);
            vector_contenidos.Add(ID_PROFESIONAL);
            vector_contenidos.Add(NOMBRE_SOCIO_TITULAR);
            vector_contenidos.Add(TIPO_SOCIO_TITULAR);
            vector_contenidos.Add(OBSERVACIONES);
            vector_contenidos.Add(FECHA_RECIBO);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(NOMBRE_SOCIO);
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(TIPO_SOCIO_NO_TITULAR);
            vector_contenidos.Add(NRO_COMP);
            vector_contenidos.Add(PTO_VTA);
            vector_contenidos.Add(REINTEGRO_DE);
            vector_contenidos.Add(BANCO_DEPO);

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
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
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");

            vector_nombres.Add("@ID");
            vector_nombres.Add("@CUENTA_DEBE");
            vector_nombres.Add("@CUENTA_HABER");
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@ID_SOCIO");
            vector_nombres.Add("@VALOR");
            vector_nombres.Add("@FORMA_DE_PAGO");
            vector_nombres.Add("@USUARIO");
            vector_nombres.Add("@ID_PROFESIONAL");
            vector_nombres.Add("@NOMBRE_SOCIO_TITULAR");
            vector_nombres.Add("@TIPO_SOCIO_TITULAR");
            vector_nombres.Add("@OBSERVACIONES");
            vector_nombres.Add("@FECHA_RECIBO");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@NOMBRE_SOCIO");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@TIPO_SOCIO_NO_TITULAR");
            vector_nombres.Add("@NRO_COMP");
            vector_nombres.Add("@PTO_VTA");
            vector_nombres.Add("@REINTEGRO_DE");
            vector_nombres.Add("@BANCO_DEPO");

            string vprocedure = "BONOS_CAJA_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDA CHEQUE X CAJA DIARIA
        public void guardarChequeCajaDiaria(int CAJA_DIARIA, int CHEQUE)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(CAJA_DIARIA);
            vector_contenidos.Add(CHEQUE);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            
            vector_nombres.Add("@CAJA_DIARIA");
            vector_nombres.Add("@CHEQUE");

            string vprocedure = "CAJA_DIARIA_CHEQUES_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED GUARDA CAMBIO EN CAJA
        public void guardarCambio(int CAJA_DIARIA, decimal CAMBIO)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(CAJA_DIARIA);
            vector_contenidos.Add(CAMBIO);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Numeric");

            
            vector_nombres.Add("@CAJA_DIARIA");
            vector_nombres.Add("@CAMBIO");

            string vprocedure = "CAJA_CAMBIO_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED CAJA DIARIA X CAJAS ANTERIORES
        public void guardarCajasAnteriores(int CAJA_ANTERIOR, int CAJA_DIARIA)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(CAJA_ANTERIOR);
            vector_contenidos.Add(CAJA_DIARIA);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            
            vector_nombres.Add("@CAJA_ANTERIOR");
            vector_nombres.Add("@CAJA_DIARIA");

            string vprocedure = "CAJAS_ANTERIORES_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED CAJA DIARIA NULL
        public void borrarCajaDeComprobante(string TABLA, int CAJA_DIARIA)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(TABLA);
            vector_contenidos.Add(CAJA_DIARIA);

            
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Integer");

            
            vector_nombres.Add("@TABLA");
            vector_nombres.Add("@CAJA_DIARIA");

            string vprocedure = "CAJA_DIARIA_NULL";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED CERRAR CAJA DIARIA
        public void cerrarCajaDiaria(string FECHA, decimal INGRESOS_EFECTIVO, decimal INGRESOS_OTROS, decimal SUBTOTAL_INGRESOS, decimal EGRESOS, decimal SALDO_CAJA, string ROL, decimal TOTAL, string ID_ROL)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(INGRESOS_EFECTIVO);
            vector_contenidos.Add(INGRESOS_OTROS);
            vector_contenidos.Add(SUBTOTAL_INGRESOS);
            vector_contenidos.Add(EGRESOS);
            vector_contenidos.Add(SALDO_CAJA);
            vector_contenidos.Add(ROL);
            vector_contenidos.Add(TOTAL);
            vector_contenidos.Add(ID_ROL);
            
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Integer");
                        
            vector_nombres.Add("@FECHA");
            vector_nombres.Add("@INGRESOS_EFECTIVO");
            vector_nombres.Add("@INGRESOS_OTROS");
            vector_nombres.Add("@SUBTOTAL_INGRESOS");
            vector_nombres.Add("@EGRESOS");
            vector_nombres.Add("@SALDO_CAJA");
            vector_nombres.Add("@ROL");
            vector_nombres.Add("@TOTAL");
            vector_nombres.Add("@ID_ROL");

            string vprocedure = "CAJA_DIARIA_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED DEPOSITO AL CIERRE
        public void depositarCajaAlCierre(int CAJA, int DEPOSITADO, int CAJA_DEPOSITADA)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(CAJA);
            vector_contenidos.Add(DEPOSITADO);
            vector_contenidos.Add(CAJA_DEPOSITADA);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            
            vector_nombres.Add("@ID");
            vector_nombres.Add("@DEPOSITADO");
            vector_nombres.Add("@CAJA_DEPOSITADA");

            string vprocedure = "DEPOSITAR_CAJA_CIERRE";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED DEPOSITAR CAJA
        public void depositarCaja(int CAJA, int DEPOSITADO, int BANCO, int IMPUTACION, string CODIGO_DEPOSITO)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            vector_contenidos.Add(CAJA);
            vector_contenidos.Add(DEPOSITADO);
            vector_contenidos.Add(BANCO);
            vector_contenidos.Add(IMPUTACION);
            vector_contenidos.Add(CODIGO_DEPOSITO);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");

            
            vector_nombres.Add("@ID");
            vector_nombres.Add("@DEPOSITADO");
            vector_nombres.Add("@BANCO");
            vector_nombres.Add("@IMPUTACION");
            vector_nombres.Add("@CODIGO_DEPOSITO");

            string vprocedure = "DEPOSITAR_CAJA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED DEPOSITAR CHEQUE CIERRE
        public void depositarChequeAlCierre(int ID, int DEPOSITADO, int CAJA_DEPOSITADO)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            
            vector_contenidos.Add(ID);
            vector_contenidos.Add(DEPOSITADO);
            vector_contenidos.Add(CAJA_DEPOSITADO);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            
            vector_nombres.Add("@ID");
            vector_nombres.Add("@DEPOSITADO");
            vector_nombres.Add("@CAJA_DEPOSITADO");

            string vprocedure = "DEPOSITAR_CHEQUE_CIERRE";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED DEPOSITAR CHEQUE
        public void depositarCheque(int ID, int DEPOSITADO, int BANCO, string COMP)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(ID);
            vector_contenidos.Add(DEPOSITADO);
            vector_contenidos.Add(BANCO);
            vector_contenidos.Add(COMP);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");

            
            vector_nombres.Add("@ID");
            vector_nombres.Add("@DEPOSITADO");
            vector_nombres.Add("@BANCO_DEPOSITO");
            vector_nombres.Add("@BOLETA_DEPOSITO");

            string vprocedure = "DEPOSITAR_CHEQUE";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR BONOS EN BLANCO
        public void modificarBonosEnBlanco(int NRO_COMP, int CUENTA_DEBE, int CUENTA_HABER, float VALOR, string FORMA_DE_PAGO, int SECTACT,
            string USUARIO_MOD, string FECHA_RECIBO, int ID_SOCIO, int ID_PROFESIONAL, string NOMBRE_SOCIO_TITULAR, string TIPO_SOCIO_TITULAR,
            string OBSERVACIONES, int BARRA, string NOMBRE_SOCIO, string TIPO_SOCIO, string DNI, string PTO_VTA, string BANCO_DEPO)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(NRO_COMP);
            vector_contenidos.Add(CUENTA_DEBE);
            vector_contenidos.Add(CUENTA_HABER);
            vector_contenidos.Add(VALOR);
            vector_contenidos.Add(FORMA_DE_PAGO);
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(USUARIO_MOD);
            vector_contenidos.Add(FECHA_RECIBO);
            vector_contenidos.Add(ID_SOCIO);
            vector_contenidos.Add(ID_PROFESIONAL);
            vector_contenidos.Add(NOMBRE_SOCIO_TITULAR);
            vector_contenidos.Add(TIPO_SOCIO_TITULAR);
            vector_contenidos.Add(OBSERVACIONES);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(NOMBRE_SOCIO);
            vector_contenidos.Add(TIPO_SOCIO);
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(PTO_VTA);
            vector_contenidos.Add(BANCO_DEPO);

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Char");

            vector_nombres.Add("@NRO_COMP");
            vector_nombres.Add("@CUENTA_DEBE");
            vector_nombres.Add("@CUENTA_HABER");
            vector_nombres.Add("@VALOR");
            vector_nombres.Add("@FORMA_DE_PAGO");
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@USUARIO_MOD");
            vector_nombres.Add("@FECHA_RECIBO");
            vector_nombres.Add("@ID_SOCIO");
            vector_nombres.Add("@ID_PROFESIONAL");
            vector_nombres.Add("@NOMBRE_SOCIO_TITULAR");
            vector_nombres.Add("@TIPO_SOCIO_TITULAR");
            vector_nombres.Add("@OBSERVACIONES");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@NOMBRE_SOCIO");
            vector_nombres.Add("@TIPO_SOCIO");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@PTO_VTA");
            vector_nombres.Add("@BANCO_DEPO");

            string vprocedure = "BONOS_CAJA_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR RECIBOS EN BLANCO
        public void modificarRecibosEnBlanco(int NRO_COMP, int CUENTA_DEBE, int CUENTA_HABER, float VALOR, string FORMA_DE_PAGO, int SECTACT, 
            string USUARIO_MOD, string FECHA_RECIBO, int ID_SOCIO, int ID_PROFESIONAL, string NOMBRE_SOCIO_TITULAR, string TIPO_SOCIO_TITULAR, 
            string OBSERVACIONES, int BARRA, string NOMBRE_SOCIO, string TIPO_SOCIO, string DNI, string PTO_VTA, string BANCO_DEPO, string CAE, 
            string VENCE_CAE, int PTO_VTA_E, int NUMERO_E)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(NRO_COMP);
            vector_contenidos.Add(CUENTA_DEBE);
            vector_contenidos.Add(CUENTA_HABER);
            vector_contenidos.Add(VALOR);
            vector_contenidos.Add(FORMA_DE_PAGO);
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(USUARIO_MOD);
            vector_contenidos.Add(FECHA_RECIBO);
            vector_contenidos.Add(ID_SOCIO);
            vector_contenidos.Add(ID_PROFESIONAL);
            vector_contenidos.Add(NOMBRE_SOCIO_TITULAR);
            vector_contenidos.Add(TIPO_SOCIO_TITULAR);
            vector_contenidos.Add(OBSERVACIONES);
            vector_contenidos.Add(BARRA);
            vector_contenidos.Add(NOMBRE_SOCIO);
            vector_contenidos.Add(TIPO_SOCIO);
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(PTO_VTA);
            vector_contenidos.Add(BANCO_DEPO);
            vector_contenidos.Add(CAE);
            vector_contenidos.Add(VENCE_CAE);
            vector_contenidos.Add(PTO_VTA_E);
            vector_contenidos.Add(NUMERO_E);

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.BigInt");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_nombres.Add("@NRO_COMP");
            vector_nombres.Add("@CUENTA_DEBE");
            vector_nombres.Add("@CUENTA_HABER");
            vector_nombres.Add("@VALOR");
            vector_nombres.Add("@FORMA_DE_PAGO");
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@USUARIO_MOD");
            vector_nombres.Add("@FECHA_RECIBO");
            vector_nombres.Add("@ID_SOCIO");
            vector_nombres.Add("@ID_PROFESIONAL");
            vector_nombres.Add("@NOMBRE_SOCIO_TITULAR");
            vector_nombres.Add("@TIPO_SOCIO_TITULAR");
            vector_nombres.Add("@OBSERVACIONES");
            vector_nombres.Add("@BARRA");
            vector_nombres.Add("@NOMBRE_SOCIO");
            vector_nombres.Add("@TIPO_SOCIO");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@PTO_VTA");
            vector_nombres.Add("@BANCO_DEPO");
            vector_nombres.Add("@CAE");
            vector_nombres.Add("@VENCE_CAE");
            vector_nombres.Add("@PTO_VTA_E");
            vector_nombres.Add("@NUMERO_E");

            string vprocedure = "RECIBOS_CAJA_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        

        //STORED MODIFICAR ARANCEL
        public void modificarArancel(int ID, float ARANCEL)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            
            vector_contenidos.Add(ID);
            vector_contenidos.Add(ARANCEL);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Numeric");

            
            vector_nombres.Add("@ID");
            vector_nombres.Add("@ARANCEL");

            string vprocedure = "ARANCELES_SERVICIOS_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVO ARANCEL
        public void nuevoArancel(int SECTACT, int ARANCEL, string CATSOC, int PROFESIONAL)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(ARANCEL);
            vector_contenidos.Add(CATSOC.TrimEnd());
            vector_contenidos.Add(PROFESIONAL);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");

            
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@ARANCEL");
            vector_nombres.Add("@CATSOC");
            vector_nombres.Add("@PROFESIONAL");

            string vprocedure = "ARANCELES_SERVICIOS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ELIMINAR CAJA DIARIA BONO
        public void eliminarCDBono(int ID)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(ID);

            
            vector_tipos.Add("FbDbType.Integer");

            
            vector_nombres.Add("@ID");

            string vprocedure = "ELIMINAR_CD_BONO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ELIMINAR CAJA DIARIA RECIBO
        public void eliminarCDRecibo(int ID)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(ID);

            
            vector_tipos.Add("FbDbType.Integer");

            
            vector_nombres.Add("@ID");

            string vprocedure = "ELIMINAR_CD_RECIBO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR IMPORTE COMPROBANTE
        public void modificarImporteComprobante(int ID, decimal IMPORTE, string PROCEDURE)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            
            vector_contenidos.Add(ID);
            vector_contenidos.Add(IMPORTE);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Numeric");

            
            vector_nombres.Add("@ID");
            vector_nombres.Add("@IMPORTE");

            string vprocedure = PROCEDURE;

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR FORMA DE PAGO BONOS
        public void modificarFormaPagoBonos(int ID_COMP, int FORMA_DE_PAGO)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            
            vector_contenidos.Add(ID_COMP);
            vector_contenidos.Add(FORMA_DE_PAGO);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            
            vector_nombres.Add("@ID");
            vector_nombres.Add("@FORMA_DE_PAGO");

            string vprocedure = "MOD_FORMA_PAGO_BONO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR FORMA DE PAGO RECIBOS
        public void modificarFormaPagoRecibos(int ID_COMP, int FORMA_DE_PAGO)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(ID_COMP);
            vector_contenidos.Add(FORMA_DE_PAGO);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            
            vector_nombres.Add("@ID");
            vector_nombres.Add("@FORMA_DE_PAGO");

            string vprocedure = "MOD_FORMA_PAGO_RECIBO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR ROLE Y DESTINO RECIBOS
        public void modificarRoleDestRecibos(int ID_COMP, int SECTACT, int ID_PROF, int CUENTA_HABER)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(ID_COMP);
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(ID_PROF);
            vector_contenidos.Add(CUENTA_HABER);

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_nombres.Add("@ID");
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@ID_PROF");
            vector_nombres.Add("@CUENTA_HABER");

            string vprocedure = "MOD_ROLE_DEST_RECIBOS";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR ROLE Y DESTINO BONOS
        public void modificarRoleDestBonos(int ID_COMP, int SECTACT, int ID_PROF, int CUENTA_HABER)
        {
            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();

            vector_contenidos.Add(ID_COMP);
            vector_contenidos.Add(SECTACT);
            vector_contenidos.Add(ID_PROF);
            vector_contenidos.Add(CUENTA_HABER);

            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            vector_nombres.Add("@ID");
            vector_nombres.Add("@SECTACT");
            vector_nombres.Add("@ID_PROF");
            vector_nombres.Add("@CUENTA_HABER");

            string vprocedure = "MOD_ROL_DEST_BONOS";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ACTUALIZA CAJA_DIARIA EN RECIBOS_CAJA
        public void cajaEnRecibos(int ID_RECIBO, int CAJA_DIARIA)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(ID_RECIBO);
            vector_contenidos.Add(CAJA_DIARIA);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            
            vector_nombres.Add("@ID_RECIBO");
            vector_nombres.Add("@CAJA_DIARIA");

            string vprocedure = "CAJA_EN_RECIBO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ACTUALIZA CAJA_DIARIA EN BONOS_CAJA
        public void cajaEnBonos(int ID_BONO, int CAJA_DIARIA)
        {

            ArrayList vector_contenidos = new ArrayList();
            ArrayList vector_tipos = new ArrayList();
            ArrayList vector_nombres = new ArrayList();
            
            vector_contenidos.Add(ID_BONO);
            vector_contenidos.Add(CAJA_DIARIA);

            
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            
            vector_nombres.Add("@ID_BONO");
            vector_nombres.Add("@CAJA_DIARIA");

            string vprocedure = "CAJA_EN_BONOS";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }





    }
}
