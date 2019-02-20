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
  public class bo_Bonos:bo
    {
      public void InsertPagoBono(int Bono, int TipoPago, decimal Monto, string Cuota, string POC, DateTime fecha, int CodInt, int CodCp, DateTime? A_Dto, string User, string Fupdate, string NroBeneficio, string Rol, int Nro_Soc, int Nro_Dep, int Barra, int Nro_Soc_titular, int Nro_dep_titular, int PlanCuenta)
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
          string vprocedure = "P_PAGOS_BONO_I";
          resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

      }

      public void Update_Fecha_Nacimiento(DateTime Fecha_Nacimiento, int ID, int Nro_Soc, int Nro_Dep, int Barra, string Tipo)
      {
          db resultado = new db();



          ArrayList vector_contenidos = new ArrayList();
          vector_contenidos.Add(Fecha_Nacimiento);
          vector_contenidos.Add(System.DateTime.Now);
          vector_contenidos.Add(VGlobales.vp_username.TrimEnd().TrimStart());
          vector_contenidos.Add(ID);
          vector_contenidos.Add(Nro_Soc);
          vector_contenidos.Add(Nro_Dep);
          vector_contenidos.Add(Barra);
          vector_contenidos.Add(Tipo);
        

          ArrayList vector_tipos = new ArrayList();

     
          vector_tipos.Add("FbDbType.VarChar");
          vector_tipos.Add("FbDbType.VarChar");
          vector_tipos.Add("FbDbType.VarChar");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.Integer");
          vector_tipos.Add("FbDbType.VarChar");
         
          ArrayList vector_nombres = new ArrayList();


          vector_nombres.Add("@FECHA_NAC");
          vector_nombres.Add("@FECHA");
          vector_nombres.Add("@USR");
          vector_nombres.Add("@ID");
          vector_nombres.Add("@NRO_SOC");
          vector_nombres.Add("@NRO_DEP");
          vector_nombres.Add("@BARRA");
          vector_nombres.Add("@TIPO");

          string vprocedure = "P_FECHA_NAC_UPDATE";
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
          vector_contenidos.Add("");

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
          vector_tipos.Add("FbDbType.VarChar");

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
          vector_nombres.Add("@CUIL");
          string vprocedure;

          vprocedure = "P_INGRESOS_A_PROCESAR_I2";

          resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

      }
  }
}
