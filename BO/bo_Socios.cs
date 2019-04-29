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
    public class bo_Socios:bo
    {

        public void Condicion_IVA(int ID,string Condicion)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
            vector_contenidos.Add(ID);
            vector_contenidos.Add(Condicion);
           

            ArrayList vector_tipos = new ArrayList();

            vector_tipos.Add("FbDbType.Integer");
            
            vector_tipos.Add("FbDbType.VarChar");
            
            ArrayList vector_nombres = new ArrayList();

            vector_nombres.Add("@PIN_ID_TITULAR");
            vector_nombres.Add("@PIN_COND_IVA");
           
            string vprocedure = "P_TITULAR_IVA";


            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);







        }

    }
}
