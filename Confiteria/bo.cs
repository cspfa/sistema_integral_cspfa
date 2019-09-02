using System;
using System.Collections;

namespace Confiteria
{
    public class bo:SOCIOS.bo
    {
        private SOCIOS.db datDatos;

        public bo()
        {
            datDatos = new SOCIOS.db(this);
        }

        //IMPORTAR COMANDAS CONFITERIA
        public void impComandaConfiteria(DateTime FECHA, int MESA, int MOZO, decimal IMPORTE, int NRO_SOC, int NRO_DEP, int BARRA, int PERSONAS, 
            string NOMBRE_SOCIO, string AFILIADO, string BENEFICIO, string USUARIO, int DESCUENTO, int FORMA_DE_PAGO, int RENDIDA, int CONTRALOR, string ANULADA, 
            string USR_ANULA, int COM_BORRADOR, string CONSUME, int TIPO_COMANDA, int DESCUENTO_APLICADO, decimal IMPORTE_DESCONTADO, int NRO_COMANDA, string ROL,
            int EXPORTADA, int ID_ANTERIOR)
        {
            
                SOCIOS.db resultado = new SOCIOS.db();

                ArrayList vector_contenidos = new ArrayList();
                vector_contenidos.Add(FECHA); vector_contenidos.Add(MESA);
                vector_contenidos.Add(MOZO); vector_contenidos.Add(IMPORTE);
                vector_contenidos.Add(NRO_SOC); vector_contenidos.Add(NRO_DEP);
                vector_contenidos.Add(BARRA); vector_contenidos.Add(PERSONAS);
                vector_contenidos.Add(AFILIADO); vector_contenidos.Add(BENEFICIO);
                vector_contenidos.Add(NOMBRE_SOCIO); vector_contenidos.Add(USUARIO);
                vector_contenidos.Add(DESCUENTO); vector_contenidos.Add(FORMA_DE_PAGO);
                vector_contenidos.Add(RENDIDA); vector_contenidos.Add(CONTRALOR);
                vector_contenidos.Add(ANULADA); vector_contenidos.Add(USR_ANULA);
                vector_contenidos.Add(COM_BORRADOR); vector_contenidos.Add(CONSUME);
                vector_contenidos.Add(TIPO_COMANDA); vector_contenidos.Add(DESCUENTO_APLICADO);
                vector_contenidos.Add(IMPORTE_DESCONTADO); vector_contenidos.Add(NRO_COMANDA);
                vector_contenidos.Add(ROL); vector_contenidos.Add(EXPORTADA);
                vector_contenidos.Add(ID_ANTERIOR);

                ArrayList vector_nombres = new ArrayList();
                vector_nombres.Add("@FECHA"); vector_nombres.Add("@MESA");
                vector_nombres.Add("@MOZO"); vector_nombres.Add("@IMPORTE");
                vector_nombres.Add("@NRO_SOC"); vector_nombres.Add("@NRO_DEP");
                vector_nombres.Add("@BARRA"); vector_nombres.Add("@PERSONAS");
                vector_nombres.Add("@AFILIADO"); vector_nombres.Add("@BENEFICIO");
                vector_nombres.Add("@NOMBRE_SOCIO"); vector_nombres.Add("@USUARIO");
                vector_nombres.Add("@DESCUENTO"); vector_nombres.Add("@FORMA_DE_PAGO");
                vector_nombres.Add("@RENDIDA"); vector_nombres.Add("@CONTRALOR");
                vector_nombres.Add("@ANULADA"); vector_nombres.Add("@USR_ANULA");
                vector_nombres.Add("@COM_BORRADOR"); vector_nombres.Add("@CONSUME");
                vector_nombres.Add("@TIPO_COMANDA"); vector_nombres.Add("@DESCUENTO_APLICADO");
                vector_nombres.Add("@IMPORTE_DESCONTADO"); vector_nombres.Add("@NRO_COMANDA");
                vector_nombres.Add("@ROL"); vector_nombres.Add("@EXPORTADA");
                vector_nombres.Add("@ID_ANTERIOR");


                ArrayList vector_tipos = new ArrayList();
                vector_tipos.Add("FbDbType.Timestamp"); vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer"); vector_tipos.Add("FbDbType.Numeric");
                vector_tipos.Add("FbDbType.Integer"); vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer"); vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Char"); vector_tipos.Add("FbDbType.Char");
                vector_tipos.Add("FbDbType.Char"); vector_tipos.Add("FbDbType.Char");
                vector_tipos.Add("FbDbType.Integer"); vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer"); vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.VarChar"); vector_tipos.Add("FbDbType.VarChar");
                vector_tipos.Add("FbDbType.Char"); vector_tipos.Add("FbDbType.Char");
                vector_tipos.Add("FbDbType.Integer"); vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Numeric"); vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.VarChar"); vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");

                string vprocedure = "CONFITERIA_IMPORTAR_COM";
                resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //IMPORTAR CAJA DIARIA CONFITERIA
        public bool impCajaDiariaConfiteria(string FECHA, string USUARIO, decimal EFECTIVO, decimal TARJETAS, decimal DESCUENTOS, decimal ESPECIALES, 
            string ROL, int EXPORTADA, int ID_ANTERIOR)
        {
            try
            {
                SOCIOS.db resultado = new SOCIOS.db();

                ArrayList vector_contenidos = new ArrayList();
                vector_contenidos.Add(FECHA);
                vector_contenidos.Add(USUARIO);
                vector_contenidos.Add(EFECTIVO);
                vector_contenidos.Add(TARJETAS);
                vector_contenidos.Add(DESCUENTOS);
                vector_contenidos.Add(ESPECIALES);
                vector_contenidos.Add(ROL);
                vector_contenidos.Add(EXPORTADA);
                vector_contenidos.Add(ID_ANTERIOR);

                ArrayList vector_tipos = new ArrayList();
                vector_tipos.Add("FbDbType.Date");
                vector_tipos.Add("FbDbType.Char");
                vector_tipos.Add("FbDbType.Numeric");
                vector_tipos.Add("FbDbType.Numeric");
                vector_tipos.Add("FbDbType.Numeric");
                vector_tipos.Add("FbDbType.Numeric");
                vector_tipos.Add("FbDbType.Char");
                vector_tipos.Add("FbDbType.Integer");
                vector_tipos.Add("FbDbType.Integer");

                ArrayList vector_nombres = new ArrayList();
                vector_nombres.Add("@FECHA");
                vector_nombres.Add("@USUARIO");
                vector_nombres.Add("@EFECTIVO");
                vector_nombres.Add("@TARJETAS");
                vector_nombres.Add("@DESCUENTOS");
                vector_nombres.Add("@ESPECIALES");
                vector_nombres.Add("@ROL");
                vector_nombres.Add("@EXPORTADA");
                vector_nombres.Add("@ID_ANTERIOR");

                string vprocedure = "CONFITERIA_IMPORTAR_CD";
                resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //RENDIDA EN COMANDAS 
        public void rendidaEnComandas(int ID_COMANDA, int CAJA_DIARIA)
        {
            SOCIOS.db resultado = new SOCIOS.db();

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
            SOCIOS.db resultado = new SOCIOS.db();

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
            SOCIOS.db resultado = new SOCIOS.db();

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

        //STORED MODIFICAR TIPO DE COMANDA CONFITERIA
        public void modificarTipoDeComanda(int ID_COMANDA, int TIPO_DE_COMANDA)
        {
            SOCIOS.db resultado = new SOCIOS.db();

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
            SOCIOS.db resultado = new SOCIOS.db();

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
            SOCIOS.db resultado = new SOCIOS.db();

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

        //STORED GUARDA DESCUENTO EN COMANDA
        public void descuentoEnComanda(int ID_COMANDA, int ID_DESCUENTO)
        {
            SOCIOS.db resultado = new SOCIOS.db();

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
            SOCIOS.db resultado = new SOCIOS.db();

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
            SOCIOS.db resultado = new SOCIOS.db();

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
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Numeric");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@FECHA");
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
            SOCIOS.db resultado = new SOCIOS.db();

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
            SOCIOS.db resultado = new SOCIOS.db();

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
            SOCIOS.db resultado = new SOCIOS.db();

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
        public void guardaComandaEnMesa(int ID_MESA, int NRO_COMANDA, int ID_COMANDA)
        {
            SOCIOS.db resultado = new SOCIOS.db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID_MESA);
            vector_contenidos.Add(NRO_COMANDA);
            vector_contenidos.Add(ID_COMANDA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@ID_MESA");
            vector_nombres.Add("@NRO_COMANDA");
            vector_nombres.Add("@ID_COMANDA");

            string vprocedure = "CONFITERIA_TEMP_MESAS_COMANDA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ELIMINA ITEMS
        public void eliminaItems(int ITEM)
        {
            SOCIOS.db resultado = new SOCIOS.db();

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
            SOCIOS.db resultado = new SOCIOS.db();

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
        public void modificarMesa(int ID_COMANDA, int MOZO, decimal IMPORTE, int PERSONAS, int FORMA_DE_PAGO, int CONTRALOR, string COM_BORRADOR, string CONSUME, int TIPO_COMANDA, decimal DESCUENTO_APLICADO, decimal IMPORTE_DESCONTADO)
        {
            SOCIOS.db resultado = new SOCIOS.db();

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
            vector_tipos.Add("FbDbType.Numeric");
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
                               string NOMBRE_SOCIO, string USUARIO, int FORMA_DE_PAGO, int CONTRALOR, string COM_BORRADOR, string CONSUME, int TIPO_COMANDA, decimal DESCUENTO_APLICADO,
                               decimal IMPORTE_DESCONTADO, int NRO_COMANDA, string ENTREGA, string NRO_ORDEN)
        {
            SOCIOS.db resultado = new SOCIOS.db();

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
            vector_contenidos.Add(NRO_COMANDA);
            vector_contenidos.Add(ENTREGA);
            vector_contenidos.Add(NRO_ORDEN);

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
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Numeric");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.VarChar");

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
            vector_nombres.Add("@NRO_COMANDA");
            vector_nombres.Add("@ENTREGA");
            vector_nombres.Add("@NRO_ORDEN");

            string vprocedure = "CONFITERIA_COMANDAS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED CAMBIAR MESA EN COMANDA
        public void cambiarMesaComanda(int MESA, int ID_COMANDA)
        {
            SOCIOS.db resultado = new SOCIOS.db();

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
        public void cambiarMesa(int MESA, string ESTADO, string DESDE, string SOCIO, int ID_COMANDA, int NRO_SOC, int NRO_DEP, int BARRA, int SECUENCIA, int PERSONAS, int PAGO, int NRO_COMANDA)
        {
            SOCIOS.db resultado = new SOCIOS.db();

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
            vector_contenidos.Add(NRO_COMANDA);

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
            vector_nombres.Add("@NRO_COMANDA");

            string vprocedure = "CONFITERIA_TEMP_MESAS_CAMBIAR";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ABRIR MESA
        public void abrirMesa(int MESA, string ESTADO, DateTime DESDE, string SOCIO, int NRO_SOC, int NRO_DEP, int BARRA, int SECUENCIA, int PERSONAS, int PAGO)
        {
            SOCIOS.db resultado = new SOCIOS.db();

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
            SOCIOS.db resultado = new SOCIOS.db();

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
            SOCIOS.db resultado = new SOCIOS.db();

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
    }
}
