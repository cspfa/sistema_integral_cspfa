﻿using System;
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
   public  class BO_Afip:bo
    {
       public void Marca_Afip_Recibo(int ID,int PTO_VTA,int NUMERO, string CAE, string VencimientoCAE)

       {

           db resultado = new db();
           ArrayList vector_contenidos = new ArrayList();
           ArrayList vector_nombres = new ArrayList();
           ArrayList vector_tipos = new ArrayList();

           vector_contenidos.Add(ID);
           vector_tipos.Add("FbDbType.Integer");
           vector_nombres.Add("@PIN_ID");

           vector_contenidos.Add(CAE);
           vector_tipos.Add("FbDbType.VarChar");
           vector_nombres.Add("@PIN_CAE");
           
           vector_contenidos.Add(VencimientoCAE);
           vector_tipos.Add("FbDbType.VarChar");
           vector_nombres.Add("@PIN_CAE_VENC");

           vector_contenidos.Add(PTO_VTA);
           vector_tipos.Add("FbDbType.Integer");
           vector_nombres.Add("@PIN_PTO_VTA_E");

           vector_contenidos.Add(NUMERO);
           vector_tipos.Add("FbDbType.Integer");
           vector_nombres.Add("@PIN_NUMERO_E");

           
           string vprocedure = "P_RECIBOS_MARCA_AFIP";

           resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

     
       }

       public void Marca_Afip_Bono(int ID, int PTO_VTA, int NUMERO, string CAE, string VencimientoCAE)
       {

           db resultado = new db();
           ArrayList vector_contenidos = new ArrayList();
           ArrayList vector_nombres = new ArrayList();
           ArrayList vector_tipos = new ArrayList();

           vector_contenidos.Add(ID);
           vector_tipos.Add("FbDbType.Integer");
           vector_nombres.Add("@PIN_ID");

           vector_contenidos.Add(CAE);
           vector_tipos.Add("FbDbType.VarChar");
           vector_nombres.Add("@PIN_CAE");

           vector_contenidos.Add(VencimientoCAE);
           vector_tipos.Add("FbDbType.VarChar");
           vector_nombres.Add("@PIN_CAE_VENC");

           vector_contenidos.Add(PTO_VTA);
           vector_tipos.Add("FbDbType.Integer");
           vector_nombres.Add("@PIN_PTO_VTA_E");

           vector_contenidos.Add(NUMERO);
           vector_tipos.Add("FbDbType.Integer");
           vector_nombres.Add("@PIN_NUMERO_E");


           string vprocedure = "P_BONOS_MARCA_AFIP";

           resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);


       }
    }
}
