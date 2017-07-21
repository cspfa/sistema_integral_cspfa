using System;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Data;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;

namespace SOCIOS
{
    public class DA_Datos
    {
        private BO_Datos dat;
        private FbConnection connection;
        private FbTransaction transaction;
        private FbCommand cmd;
        private FbDataReader reader;

        public DA_Datos() {}

        public DA_Datos(BO_Datos datos)
        {
            dat = datos;
        }

        public void OpenCnn()
        {
            string connectionString;

            Datos_ini ini2 = new Datos_ini();

            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();

            cs.DataSource = ini2.Servidor;  cs.Port = int.Parse(ini2.Puerto);
            VGlobales.vp_datasource = ini2.Servidor;
            cs.Database = ini2.Ubicacion;
            VGlobales.vp_database = ini2.Ubicacion;
            cs.UserID = VGlobales.vp_username;
            cs.Password = VGlobales.vp_password;
            cs.Role = VGlobales.vp_role;
            cs.Dialect = 3;
            cs.Pooling = false;
            ini2 = null;

            connectionString = cs.ToString();

            connection = new FbConnection(connectionString);

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }


        public void CloseCnn()
        {
            /*if (connection.State != ConnectionState.Closed)
            {
                connection.Dispose();
            }*/
            connection.Close();
        }


        public void NewTransaction()
        {
            transaction = connection.BeginTransaction();
        }


        public void CommitTransaction()
        {
            try
            { 
                transaction.Commit(); 
            }
            finally
            {
                transaction = null;
            }
        }
        
         
        public void RollbackTransaction()
        {
            transaction.Rollback();
        }

        
        public FbDataReader EjecutoReader(string comando)
        {
            OpenCnn();
            NewTransaction();
            cmd = new FbCommand(comando, connection, transaction);
            FbDataReader reader = cmd.ExecuteReader();
            CommitTransaction();
            
            return reader;
            CloseCnn();
        }


        public DataSet EjecutoDataSet(string query)
        {
            DataSet dsRetorno = new DataSet();
            OpenCnn();
            NewTransaction();

            using ( FbCommand comando = new FbCommand(query,connection,transaction))

            using ( FbDataAdapter sqlDA = new FbDataAdapter(comando))
            {
                sqlDA.Fill(dsRetorno);
            }
            
            return dsRetorno;
            CloseCnn();
        }

        /*
        public DataSet1 EjecutoDataSetRep(string query)
        {
            DataSet1 dsRetorno = new DataSet1();
            OpenCnn();
            NewTransaction();

            using (FbCommand comando = new FbCommand(query, connection, transaction))

            using (FbDataAdapter sqlDA = new FbDataAdapter(comando))
            {
                sqlDA.Fill(dsRetorno);
            }
            return dsRetorno;
        }
        */
          
        public DataTable EjecutoDataTable(string query)
        {
            DataSet dsRetorno = new DataSet();
            OpenCnn();
            NewTransaction();

            using (FbCommand comando = new FbCommand(query, connection, transaction))

            using (FbDataAdapter sqlDA = new FbDataAdapter(comando))
            {
                sqlDA.Fill(dsRetorno);
            }
            
            return dsRetorno.Tables[0];
            CloseCnn();
        }

        /*
        public DataSet Find()
        {
            DataSet ds = null;

            try
            {
                OpenCnn();

                String selectStr = "select NRO_SOC, NRO_DEP, COD_DTO, APE_SOC, NOM_SOC from titular where APE_SOC = 'TABAREZ' ";
                FbDataAdapter da = new FbDataAdapter(selectStr, connection);
                ds = new DataSet();
                da.Fill(ds, "TITULAR");

                CloseCnn();
                
            }
            catch (Exception e)
            {
                String Str = e.Message;
            }

            return ds;
        }
        */


        public FbDataReader Ejecuto_Stored(string vprocedimiento, ArrayList vcont, ArrayList vtipodato, ArrayList vnombre)
        {

            OpenCnn();
            NewTransaction();

            FbCommand comando = new FbCommand(vprocedimiento, connection, transaction);

            for (int i = 0; i < vcont.Count; i++)
            {
                comando.Parameters.Add(new FbParameter(vnombre[i].ToString(),vtipodato[i].ToString()));
                comando.Parameters[i].Value = vcont[i];
            }
           
            FbDataReader reader = comando.ExecuteReader();

            //CommitTransaction();
            return reader;
            CloseCnn();
        }

        public void Ejecuto_Stored_Insert(string vprocedimiento, ArrayList vcont, ArrayList vtipodato, ArrayList vnombre)
        {
            OpenCnn();
            NewTransaction();

            FbCommand comando = new FbCommand(vprocedimiento, connection, transaction);

            for (int i = 0; i < vcont.Count; i++)
            {
                comando.Parameters.Add(new FbParameter(vnombre[i].ToString(), vtipodato[i].ToString()));
                comando.Parameters[i].Value = vcont[i];
            }
            comando.CommandType = CommandType.StoredProcedure;

            comando.ExecuteNonQuery();

            CommitTransaction();

            CloseCnn();
        }


        //protected void CargarParametros(FbCommand com, Object[] args)
        //{
        //    for (int i = 1; i < com.Parameters.Count; i++)
        //    {
        //        FbParameter p = (FbParameter)com.Parameters[i];
        //        p.Value = i <= args.Length ? args[i - 1] : null;
        //    }
        //} 

    }
}
