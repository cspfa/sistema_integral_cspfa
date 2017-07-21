using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FirebirdSql.Data.Firebird;
using System.Data.OleDb;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SOCIOS
{
    public class DataSetConfiguration 
    {
        private const string DATATABLE_TIT = "Titulares";
        private const string DATATABLE_FAM = "Familiares";
        private const string DATATABLE_ADH = "Adherentes";
        
            public static DataSet TitFamAdh 
            {
                get
                {
                    Datos_ini ini2 = new Datos_ini();

                    FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
                    cs.DataSource = ini2.Servidor;
                    cs.Database = ini2.Ubicacion;
                    cs.UserID = "";
                    cs.Password = "C0wb0ysFr0mH3ll";
                    cs.Dialect = 3;
                    cs.Pooling = false; ;
                    string connectionString = cs.ToString();

                    string QRY_STR_TIT;
                    string QRY_STR_FAM;
                    string QRY_STR_ADH;

                    string vnro_soc;
                    string vnro_dep;
                    DataRow dr;
                    string path = Directory.GetCurrentDirectory() + "\\PARAMETERS.BIN";

                    TextReader defecto = new StreamReader(path);
                    vnro_soc = defecto.ReadLine().ToString();
                    vnro_dep = defecto.ReadLine().ToString();
                    defecto.Close();

                    QRY_STR_TIT = "SELECT A.*, B.FOTO FROM TITULAR A, TITULAR_IMAGEN B WHERE A.ID_TITULAR=B.ID_TITULAR AND A.NRO_SOC = " + vnro_soc + " AND NRO_DEP = " + vnro_dep;
                    
                    QRY_STR_FAM = "SELECT * FROM FAMILIAR WHERE NRO_SOC = " + vnro_soc + " AND NRO_DEP = " + vnro_dep + " ORDER BY BARRA ASC";
                    
                    QRY_STR_ADH = "SELECT * FROM ADHERENT WHERE NRO_SOCIO = " + vnro_soc + " AND NRO_DEP = " + vnro_dep + " ORDER BY ID_ADHERENTE ASC";

                    string qry_detalle;

                    qry_detalle = "SELECT B.DESCRIP,C.DESCRIP AS MBPOL,D.DESCRIP AS MBCIR,E.DESCRIP AS GRADO, ";
                    qry_detalle = qry_detalle + " F.DESCRIP AS DESTINO, G.DESCRIP AS PROVINCIA, H.DESCRIP AS TIPO_CARNET ";
                    qry_detalle = qry_detalle + " FROM P_OBTENER_TABLA ('CA') B,P_OBTENER_TABLA ('BP') C, P_OBTENER_TABLA ('BC') D, ";
                    qry_detalle = qry_detalle + " TITULAR A, P_OBTENER_TABLA('JE') E, P_OBTENER_TABLA('DE') F, ";
                    qry_detalle = qry_detalle + " P_OBTENER_TABLA('PR') G, P_OBTENER_TABLA('TC') H ";
                    qry_detalle = qry_detalle + " WHERE A.NRO_SOC = " + vnro_soc + " AND A.NRO_DEP = " + vnro_dep + " AND ";
                    qry_detalle = qry_detalle + " A.CAT_SOC=SUBSTR(B.CODIGO,2,4) AND ";
                    qry_detalle = qry_detalle + " A.M_BAJPO=SUBSTR(C.CODIGO,4,4) AND A.M_BAJCI=SUBSTR(D.CODIGO,4,4) AND ";
                    qry_detalle = qry_detalle + " A.JERARQ=E.CODIGO AND A.DESTINO=F.CODIGO AND A.PRO_PAR=SUBSTR(G.CODIGO,3,4) AND ";
                    qry_detalle = qry_detalle + " A.TIP_CAR=SUBSTR(H.CODIGO,4,4) ";

                    TitFamAdhSchema dataSet = new TitFamAdhSchema();
                    //FbConnection oleDbConnection = new FbConnection(CONNECTION_STRING);

                    using (FbConnection connection = new FbConnection(connectionString))
                    {
                        connection.Open();
                        FbTransaction transaction = connection.BeginTransaction();
                        DataSet ds = new DataSet();
                        FbCommand cmd = new FbCommand(QRY_STR_TIT, connection, transaction);
                        cmd.CommandText = QRY_STR_TIT;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
                        FbDataAdapter da = new FbDataAdapter(cmd);
                        da.Fill(ds, DATATABLE_TIT);
                    }

                    //Cargo Titular + Foto
                    //FbDataAdapter oleDbDataAdapter = new FbDataAdapter(QRY_STR_TIT, oleDbConnection);
                    //oleDbDataAdapter.Fill(dataSet, DATATABLE_TIT);

                    //Cargo Familiar
                    /*oleDbDataAdapter = new FbDataAdapter(QRY_STR_FAM, oleDbConnection);
                    oleDbDataAdapter.Fill(dataSet, DATATABLE_FAM);

                    //Cargo Adherente
                    oleDbDataAdapter = new FbDataAdapter(QRY_STR_ADH, oleDbConnection);
                    oleDbDataAdapter.Fill(dataSet, DATATABLE_ADH);

                    //Cargo Detalles de Titulares
                    oleDbDataAdapter = new FbDataAdapter(qry_detalle, oleDbConnection);
                    oleDbDataAdapter.Fill(dataSet, "Detalle_Titulares");*/

                    // inicio de la imagen
                    path = Directory.GetCurrentDirectory();
                    path = path + "\\TMP.tif";
                    Byte[] byteBLOBData1 = new Byte[0];
                    byteBLOBData1 = (Byte[])dataSet.Tables["Titulares"].Rows[0]["FOTO"];
                    MemoryStream stmBLOBData1 = new MemoryStream(byteBLOBData1);
                    byte[] imagenBytes;
                    Image.FromStream(stmBLOBData1).Save(path, System.Drawing.Imaging.ImageFormat.Tiff);
                    imagenBytes = File.ReadAllBytes(path);
                    dr = dataSet.Tables["Imagen"].NewRow();
                    dr["FOTO"] = imagenBytes;
                    dataSet.Tables["Imagen"].Rows.Add(dr);
                    // fin imagen
                    
                    return dataSet;
                }
            }
        }
     }

