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
    public class bo_interior
    {
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


            string vprocedure = "P_BONO_VOUCHER_UPD_ID_ROL";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }
    }
}