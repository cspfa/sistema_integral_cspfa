﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;
using System.Collections;

namespace SOCIOS.BO
{
    public class bo_ServiciosMedicos : bo
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


            string vprocedure = "P_BONO_ODONTOLOGICO_UPD_ID_ROL";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);






        }
        public void InsertOdontologico(int NRO_SOCIO_TITULAR, int NRO_SOCIO, int NRO_DEP, string DNI, int NRO_DEP_TITULAR, int BARRA, DateTime FE_BONO, int PROFESIONAL, int SEC_ACT, int TRAT, decimal SALDO_INICIAL, decimal SALDO_NETO, decimal SALDO_INTERES, string NOMBRE, string APELLIDO, string F_NACIM, string EDAD, string TELEFONO, string EMAIL, int AAR, int ACRJP1, int ACRJP2, int ACRJP3, int PAR, int PCRJP1, int PCRJP2, int PCRJP3, string OBS, string PROF, string PAGO, int TURNO, string USR, int CONTRALOR, string ROL)
        {
            db resultado = new db();

            ArrayList vector_contenidos = new ArrayList();
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
            vector_contenidos.Add(PROF);

            vector_contenidos.Add(PAGO);
            vector_contenidos.Add(TURNO);
            vector_contenidos.Add(USR);

            vector_contenidos.Add(System.DateTime.Now);
            vector_contenidos.Add(DNI);
            vector_contenidos.Add(CONTRALOR);
            vector_contenidos.Add(SALDO_NETO);
            vector_contenidos.Add(SALDO_INTERES);
            vector_contenidos.Add(ROL);
            ArrayList vector_tipos = new ArrayList();

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

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");

            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.VarChar");
            vector_tipos.Add("FbDbType.Integer");

            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.Float");
            vector_tipos.Add("FbDbType.VarChar");

            ArrayList vector_nombres = new ArrayList();


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
            vector_nombres.Add("@PROF");
            vector_nombres.Add("@PAGO");
            vector_nombres.Add("@TURNO");
            vector_nombres.Add("@USR_ALTA");
            vector_nombres.Add("@FE_ALTA");
            vector_nombres.Add("@DNI");
            vector_nombres.Add("@CONTRALOR");
            vector_nombres.Add("@SALDO_NETO");
            vector_nombres.Add("@SALDO_INTERES");
            vector_nombres.Add("@ROL");
            string vprocedure = "P_BONO_ODONTOLOGICO_I";
            resultado.Ejecuto_Stored_Insert(vprocedure, vector_contenidos, vector_tipos, vector_nombres);

        }
    }
}