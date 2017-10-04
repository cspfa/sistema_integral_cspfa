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
    class bo_Compras:bo
    {
        db resultado = new db();

        //ALTA SOLICITUD X ARTICULOS
        public void altaSolicitudArticulos(int ID_SOLICITUD, int ID_ARTICULO, int CANTIDAD)
        {
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(0);
            vector_contenidos.Add(ID_SOLICITUD);
            vector_contenidos.Add(ID_ARTICULO);
            vector_contenidos.Add(CANTIDAD);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("PIN_ID");
            vector_nombres.Add("PIN_ID_SOLICITUD");
            vector_nombres.Add("PIN_ID_ARTICULO");
            vector_nombres.Add("PIN_CANTIDAD");

            string vprocedure = "SOLICITUD_ARTICULOS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //ALTA SOLICITUD DE COMPRA
        public void nuevaSolicitudCompra(string FECHA, string PRIORIDAD, string SECTOR_ORIGEN, string SECTOR_DESTINO)
        {
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(FECHA);
            vector_contenidos.Add(VGlobales.vp_username);
            vector_contenidos.Add(SECTOR_ORIGEN);
            vector_contenidos.Add(SECTOR_DESTINO);
            vector_contenidos.Add("ENVIADA");
            vector_contenidos.Add(PRIORIDAD);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("PIN_FECHA_ALTA");
            vector_nombres.Add("PIN_USR_ALTA");
            vector_nombres.Add("PIN_SECTOR_ORIGEN");
            vector_nombres.Add("PIN_SECTOR_DESTINO");
            vector_nombres.Add("PIN_ESTADO");
            vector_nombres.Add("PIN_PRIORIDAD");

            string vprocedure = "SOLICITUDES_COMPRAS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //MODIFICA CAMPO OP_TEMP EN CHEQUERAS
        public void anularFactura(string ID, string ANULADO, string USR_ANULADO)
        {
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(ANULADO);
            vector_contenidos.Add(USR_ANULADO);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Date");
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("ID");
            vector_nombres.Add("ANULADO");
            vector_nombres.Add("USR_ANULADO");

            string vprocedure = "FACTURAS_ANULADO";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //MODIFICA CAMPO OP_TEMP EN CHEQUERAS
        public void modificarOpTemp(string VALOR, string CHEQUE, string BANCO_ID)
        {
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(VALOR);
            vector_contenidos.Add(CHEQUE);
            vector_contenidos.Add(BANCO_ID);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("VALOR");
            vector_nombres.Add("CHEQUE");
            vector_nombres.Add("BANCO_ID");

            string vprocedure = "CHEQUES_OP_TEMP_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }
        
        //STORED MODIFICAR CUENTA PLAN
        public void modificarCuentaPlan(string ID, string NUMEROCTA, string NOMBRECTA)
        {
            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(NUMEROCTA);
            vector_contenidos.Add(NOMBRECTA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("ID");
            vector_nombres.Add("NUMEROCTA");
            vector_nombres.Add("NOMBRECTA");
           

            string vprocedure = "CUENTAS_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVA CUENTA PLAN
        public void nuevaCuentaPlan(string ID, string NUMEROCTA, string NOMBRECTA)
        {
            

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(NUMEROCTA);
            vector_contenidos.Add(NOMBRECTA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("ID");
            vector_nombres.Add("NUMEROCTA");
            vector_nombres.Add("NOMBRECTA");

            string vprocedure = "CUENTAS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED ELIMINA UN PROVEEDOR
        public void eliminaUnProveedor(int ID, string USR_BAJA, string FE_BAJA)
        {
            

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
        public void modificaUnProveedor(int ID, string RAZON_SOCIAL, string EMAIL, string DOMICILIO, string TELEFONO, string WEB, string CONTACTO, string CUIT, string CUENTA, string USR_MOD, string FE_MOD, string CBU, string TIPO, string TIPO_DE_CUENTA)
        {
            

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

        //STORED GUARDA NUMERO DE REMITO EN FACTURA
        public void remitoEnFactura(int ID, string NRO_REMITO)
        {
            

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

        //ALTA TRANSFERENCIA
        public void altaTransferencia(int BANCO_ORIGEN, int CUENTA_ORIGEN, int CHEQUE, int PROVEEDOR, int CUENTA_DESTINO, decimal IMPORTE, string US_ALTA, string FE_ALTA, string FECHA, int ID_OP)
        {
            
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

        //STORED MODIFICA ARTICULOS DE UNA FACTURA
        public void modificarArticulos(int ID, string DETALLE, decimal VALOR, int CANTIDAD, string NSERIE, int TIPO, string DESCUENTO)
        {
            

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
        public void modificarFactura(int ID, int PROVEEDOR, string NUM_FACTURA, string FECHA, decimal IMPORTE, string OBSERVACIONES, string FE_MOD, string US_MOD, string SECTOR, string SEC_GRAL, int TIPO, int DESCUENTO)
        {
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
            vector_contenidos.Add(DESCUENTO);

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
            vector_nombres.Add("DESCUENTO");

            string vprocedure = "FACTURAS_U";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED NUEVO RECIBO OFICIAL
        public void nuevoReciboOficial(string NRO_RECIBO, string FE_RECIBO, decimal IMPORTE, string OBSERVACIONES, string FE_ALTA, string US_ALTA, string NRO_FACTURA)
        {
            

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
        public void nuevaFactura(int PROVEEDOR, string NUM_FACTURA, string FECHA, decimal IMPORTE, string OBSERVACIONES, string FE_ALTA, string US_ALTA, string SECTOR, string SEC_GRAL, int TIPO, int ORDEN_DE_PAGO, int REGIMEN, decimal RETENCION, int DEUDA, int DESCUENTO)
        {
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
            vector_contenidos.Add(DEUDA);
            vector_contenidos.Add(DESCUENTO);

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
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.Integer");

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
            vector_nombres.Add("DEUDA");
            vector_nombres.Add("DESCUENTO");

            string vprocedure = "FACTURAS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED MODIFICAR TIPO DE ARTICULO
        public void modificarTipoArticulo(int ID, string DETALLE)
        {
            

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
            

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(DETALLE.Trim());

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@DETALLE");

            string vprocedure = "TIPOS_ARTICULOS_I";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //STORED BAJA DE ARTICULO
        public void bajaArticulo(string ID, string FE_BAJA)
        {
            

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(FE_BAJA);

            ArrayList vector_tipos = new ArrayList();
            vector_tipos.Add("FbDbType.Char");
            vector_tipos.Add("FbDbType.Date");

            ArrayList vector_nombres = new ArrayList();
            vector_nombres.Add("@DETALLE");
            vector_nombres.Add("@FE_BAJA");

            string vprocedure = "ARTICULOS_BAJA";

            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);
        }

        //ALTA RETENCION 
        public void altaRetencion(string NUM_CERT, string FECHA, decimal IMPORTE, decimal RETENCION, int IMPUESTO, int REGIMEN, int OP, string US_ALTA, string FE_ALTA)
        {
            
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
    }
}
