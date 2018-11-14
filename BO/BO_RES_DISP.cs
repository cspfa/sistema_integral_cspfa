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
  public  class BO_RES_DISP
    {
      public void Resolucion_Dispocision_Insert(int ANIO, int NUMERO, string ARCHIVOPDF,string DESCRIPCION,int TIPO)
      {

          db resultado = new db();
          ArrayList vector_contenidos = new ArrayList();
          ArrayList vector_nombres = new ArrayList();
          ArrayList vector_tipos = new ArrayList();

          vector_contenidos.Add(0);
          vector_tipos.Add("FbDbType.Integer");
          vector_nombres.Add("@PIN_ID");

          vector_contenidos.Add(ANIO);
          vector_tipos.Add("FbDbType.Integer");
          vector_nombres.Add("@PIN_ANIO");

          vector_contenidos.Add(NUMERO);
          vector_tipos.Add("FbDbType.Integer");
          vector_nombres.Add("@PIN_NUMERO");

          vector_contenidos.Add(ARCHIVOPDF);
          vector_tipos.Add("FbDbType.Varchar");
          vector_nombres.Add("@PIN_ARCHIVOPDF");

          vector_contenidos.Add(DESCRIPCION);
          vector_tipos.Add("FbDbType.Integer");
          vector_nombres.Add("@PIN_DESCRIPCION");

          vector_contenidos.Add(TIPO);
          vector_tipos.Add("FbDbType.Integer");
          vector_nombres.Add("@PIN_TIPO");

          string vprocedure = "P_RES_Y_DISP_I";

          resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);


      }

      public void Resolucion_Dispocision_Update(int ID,int ANIO, int NUMERO, string ARCHIVOPDF,string DESCRIPCION, int TIPO)
      {

          db resultado = new db();
          ArrayList vector_contenidos = new ArrayList();
          ArrayList vector_nombres = new ArrayList();
          ArrayList vector_tipos = new ArrayList();

          vector_contenidos.Add(ID);
          vector_tipos.Add("FbDbType.Integer");
          vector_nombres.Add("@PIN_ID");

          vector_contenidos.Add(ANIO);
          vector_tipos.Add("FbDbType.Integer");
          vector_nombres.Add("@PIN_ANIO");

          vector_contenidos.Add(NUMERO);
          vector_tipos.Add("FbDbType.Integer");
          vector_nombres.Add("@PIN_NUMERO");

          vector_contenidos.Add(ARCHIVOPDF);
          vector_tipos.Add("FbDbType.Varchar");
          vector_nombres.Add("@PIN_ARCHIVOPDF");

          vector_contenidos.Add(DESCRIPCION);
          vector_tipos.Add("FbDbType.Integer");
          vector_nombres.Add("@PIN_DESCRIPCION");

          vector_contenidos.Add(TIPO);
          vector_tipos.Add("FbDbType.Integer");
          vector_nombres.Add("@PIN_TIPO");

          string vprocedure = "P_RES_Y_DISP_I";

          resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);


      }
    }
}
