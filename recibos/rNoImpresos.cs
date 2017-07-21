using System;
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

namespace SOCIOS
{
    public partial class rNoImpresos : Form
    {
        public rNoImpresos()
        {
            InitializeComponent();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            int dia = int.Parse(dpFecha.Text.ToString().Substring(0, 2));
            int mes = int.Parse(dpFecha.Text.ToString().Substring(3, 2));
            int anio = int.Parse(dpFecha.Text.ToString().Substring(6, 4));
            llenarGrilla(anio+"-"+mes+"-"+dia);
        }

        private void llenarGrilla(string FECHA)
        {
            string v_consulta = "";

            v_consulta = "SELECT CASE TIP_SOCIO WHEN 'ADH' THEN A.NRO_ADH WHEN 'INP' THEN A.NRO_ADH WHEN 'VIS' THEN A.NRO_SOC ELSE A.NRO_SOC END AS NRO_SOC, ";

            v_consulta = v_consulta + " CASE TIP_SOCIO WHEN 'ADH' THEN A.NRO_DEPADH WHEN 'INP' THEN A.NRO_DEPADH WHEN 'VIS' THEN A.NRO_DEP ELSE A.NRO_DEP END AS NRO_DEP,";

            v_consulta = v_consulta + " A.APELLIDO, A.NOMBRE, A.TIP_SOCIO, A.ROL, SA.DETALLE, A.SECUENCIA, A.BARRA, A.COD_DTO, P.NOMBRE AS NOMBREPROF, A.NRO_RECIBO ";

            v_consulta = v_consulta + " FROM INGRESOS_A_PROCESAR A, SECTACT SA, PROFESIONALES P, RDB$Database ";

            v_consulta = v_consulta + " WHERE A.ROL IN (SELECT B.ROL FROM SECTACT B WHERE B.ID IN (SELECT C.SECTACT FROM ARANCELES_SERVICIOS C )) ";

            v_consulta = v_consulta + " AND A.ID_DESTINO IN (SELECT D.SECTACT FROM ARANCELES_SERVICIOS D) ";

            v_consulta = v_consulta + " AND EXTRACT(DAY FROM A.FECHA)=EXTRACT(DAY FROM CURRENT_TIMESTAMP) ";

            v_consulta = v_consulta + " AND EXTRACT(MONTH FROM A.FECHA)=EXTRACT(MONTH FROM CURRENT_TIMESTAMP) ";

            v_consulta = v_consulta + " AND EXTRACT(YEAR FROM A.FECHA)=EXTRACT(YEAR FROM CURRENT_TIMESTAMP) ";

            v_consulta = v_consulta + " AND A.ID_DESTINO = SA.ID ";

            v_consulta = v_consulta + " AND A.ID_PROFESIONAL = P.ID ";

            v_consulta = v_consulta + " ORDER BY A.NRO_RECIBO ASC;";

            string connectionString;
            DataSet ds1 = new DataSet();
            Datos_ini ini3 = new Datos_ini();
            try
            {
                FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                cs.DataSource = ini3.Servidor;  cs.Port = int.Parse(ini3.Puerto);
                cs.Database = ini3.Ubicacion;
                cs.UserID = VGlobales.vp_username;
                cs.Password = VGlobales.vp_password;
                cs.Role = VGlobales.vp_role;
                cs.Dialect = 3;
                connectionString = cs.ToString();

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();

                    FbTransaction transaction = connection.BeginTransaction();

                    DataTable dt1 = new DataTable("RESULTADOS");

                    dt1.Columns.Add("RECIBO", typeof(string));
                    dt1.Columns.Add("NRO_SOC", typeof(string));
                    dt1.Columns.Add("NRO_DEP", typeof(string));
                    dt1.Columns.Add("COD_DTO", typeof(string));
                    dt1.Columns.Add("BARRA", typeof(string));
                    dt1.Columns.Add("APELLIDO", typeof(string));
                    dt1.Columns.Add("NOMBRE", typeof(string));
                    dt1.Columns.Add("TIP_SOCIO", typeof(string));
                    dt1.Columns.Add("ROL", typeof(string));
                    dt1.Columns.Add("DESTINO", typeof(string));
                    dt1.Columns.Add("PROFESIONAL", typeof(string));

                    ds1.Tables.Add(dt1);

                    FbCommand cmd = new FbCommand(v_consulta, connection, transaction);
                    FbDataReader reader3 = cmd.ExecuteReader();

                    while (reader3.Read())
                    {
                        dt1.Rows.Add(reader3.GetString(reader3.GetOrdinal("NRO_RECIBO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NRO_SOC")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NRO_DEP")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("COD_DTO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("BARRA")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("APELLIDO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBRE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("TIP_SOCIO")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("ROL")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("DETALLE")).Trim(),
                                     reader3.GetString(reader3.GetOrdinal("NOMBREPROF")).Trim());
                    }
                    reader3.Close();

                    dgvListado.DataSource = dt1;

                    transaction.Commit();
                }

            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR LOS RESULTADOS");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}
