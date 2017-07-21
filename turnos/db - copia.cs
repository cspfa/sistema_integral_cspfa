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
    class db
    {
        private bo dat;
        private FbConnection connection;
        private FbTransaction transaction;
        private FbCommand cmd;
        private FbDataReader reader;

        public db() { }

        public db(bo datos)
        {
            dat = datos;
        }

        /*public void OpenCnn()
        {
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load("\\\\192.168.1.6\\datos_xml\\datos_socios.xml");

            XmlNodeList data = xDoc.GetElementsByTagName("data");

            XmlNodeList lista = ((XmlElement)data[0]).GetElementsByTagName("base");

            string server = "";
            string path = "";
            string user = "";
            string pass = "";

            foreach (XmlElement nodo in lista)
            {
                int i = 0;

                XmlNodeList s = nodo.GetElementsByTagName("server");
                XmlNodeList p = nodo.GetElementsByTagName("path");
                XmlNodeList u = nodo.GetElementsByTagName("user");
                XmlNodeList c = nodo.GetElementsByTagName("pass");

                server = s[i].InnerText;
                path = p[i].InnerText;
                user = u[i].InnerText;
                pass = c[i].InnerText;
            }

            string connectionString;
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = server;
            cs.Database = path;
            cs.UserID = user;
            cs.Password = pass;
            connectionString = cs.ToString();
            connection = new FbConnection(connectionString);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }*/

        public void OpenCnn()
        {
            string connectionString;

            Datos_ini ini2 = new Datos_ini();

            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();

            cs.DataSource = ini2.Servidor;
            VGlobales.vp_datasource = ini2.Servidor;
            cs.Database = ini2.Ubicacion;
            VGlobales.vp_database = ini2.Ubicacion;
            cs.UserID = VGlobales.vp_username;
            cs.Password = VGlobales.vp_password;
            cs.Role = VGlobales.vp_role;
            cs.Dialect = 3;
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
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
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
            using (FbCommand comando = new FbCommand(query, connection, transaction))
            using (FbDataAdapter sqlDA = new FbDataAdapter(comando))
            {
                sqlDA.Fill(dsRetorno);
            }
            
            return dsRetorno;
            CloseCnn();
        }

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

        public FbDataReader Ejecuto_Stored(string vprocedimiento, ArrayList vcont, ArrayList vtipodato, ArrayList vnombre)
        {
            OpenCnn();
            NewTransaction();
            FbCommand comando = new FbCommand(vprocedimiento, connection, transaction);

            for (int i = 0; i < vcont.Count; i++)
            {
                comando.Parameters.Add(new FbParameter(vnombre[i].ToString(), vtipodato[i].ToString()));
                comando.Parameters[i].Value = vcont[i];
            }

            FbDataReader reader = comando.ExecuteReader();
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
    }
}
