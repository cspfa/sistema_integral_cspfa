using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Data.OleDb;

namespace SOCIOS
{
    public partial class CargaEdad : Form
    {
        bo dlog = new bo();

        string ID;

        string NRO;
        
        string DEP;
        
        string BARRA;
        string TIPO;
        public CargaEdad(string Nombre,string Apellido, string pTipo,string pID,string pNRO,string pDEP,string pBARRA)
        {
            InitializeComponent();

            lbApellido.Text = Apellido;
            lbNombre.Text = Nombre;
            lbTipo.Text = pTipo;
           
            ID = pID;
            NRO = pNRO;
            DEP = pDEP;
            BARRA = pBARRA;
            TIPO = pTipo;
            this.Load_Fecha_Nacimiento();

        }

        private void Load_Fecha_Nacimiento()
        {
            string QUERY = "";

            if (TIPO == "TIT")
            { 
              QUERY = "SELECT F_NACIM FROM TITULAR WHERE ID_TITULAR=  " + ID + "AND NRO_SOC= " + NRO + " AND NRO_DEP=" + DEP + "AND BARRA=" + BARRA ;
            }
            else if (TIPO == "FAM")
            {
                QUERY = "SELECT F_NACFAM FROM FAMILIAR WHERE ID_TITULAR=  " + ID + "AND NRO_SOC= " + NRO + " AND NRO_DEP=" + DEP + "AND BARRA=" + BARRA;

            }
            else

            {
                QUERY = "SELECT F_NACIMADH FROM ADHERENT WHERE ID_TITULAR=  " + ID + "AND NRO_ADH= " + NRO + " AND NRO_DEPADH=" + DEP + "AND BARRA=" + BARRA;
            
            }

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
            if (foundRows.Length > 0)
            {
                if (foundRows[0][0].ToString().Trim().Length> 0)
                    dpFecha.Value = DateTime.Parse(foundRows[0][0].ToString().Trim());
                else
                    dpFecha.Value = System.DateTime.Now.AddYears(-18);
            }
            else
                dpFecha.Value = System.DateTime.Now.AddYears(-18);


            this.Edad();
        
        }

        private void GrabarFechaNacimiento()
        {
            string connectionString;
            string QUERY;


            if (TIPO == "TIT")
            {
                QUERY = "UPDATE TITULAR SET F_NACIM = '" + dpFecha.Value.ToShortDateString() + "' , USR_MOD=" + VGlobales.vp_username + " , FE_MOD='" + System.DateTime.Now.ToShortDateString() + "' WHERE ID_TITULAR=  " + ID + " AND NRO_SOC= " + NRO + " AND NRO_DEP=" + DEP + " AND BARRA=" + BARRA;
            }
            else if (TIPO == "FAM")
            {
                QUERY = "UPDATE FAMILIAR SET F_NACFAM= '" + dpFecha.Value.ToShortDateString() + "' , USR_MOD='" + VGlobales.vp_username + "' , FE_MOD='" + System.DateTime.Now.ToShortDateString() + "'  WHERE ID_TITULAR=  " + ID + " AND NRO_SOC= " + NRO + " AND NRO_DEP=" + DEP + " AND BARRA=" + BARRA;

            }
            else
            {
                QUERY = "UPDATE ADHERENT SET F_NACIMADH= '" + dpFecha.Value.ToShortDateString() + "' , USR_MOD='" + VGlobales.vp_username + "' , FE_MOD='" + System.DateTime.Now.ToShortDateString() + "'  WHERE ID_TITULAR=  " + ID + "AND NRO_ADH = " + NRO + "  AND NRO_DEPADH=" + DEP + " AND BARRA=" + BARRA;

            }



            Datos_ini ini2 = new Datos_ini();

            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.DataSource = ini2.Servidor; cs.Port = int.Parse(ini2.Puerto);
            cs.Database = ini2.Ubicacion;
            cs.UserID = VGlobales.vp_username;
            cs.Password = VGlobales.vp_password;
            cs.Role = VGlobales.vp_role;
            cs.Dialect = 3;
            connectionString = cs.ToString();

            using (FbConnection connection = new FbConnection(connectionString))
            {
            

               

                connection.Open();
                FbTransaction transaction = connection.BeginTransaction();
                FbCommand cmd = new FbCommand(QUERY, connection, transaction);
                cmd.CommandText = QUERY;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                transaction.Commit();
                connection.Dispose();
            }

            MessageBox.Show("FECHA DE NACIMIENTO CAMBIADA CON EXITO.");


        }
        
        private void Edad()

        {
            lbEdad.Text = Decimal.Round((System.DateTime.Now - dpFecha.Value).Days / 365, 0).ToString() + " Años";
        
        }

        private void dpFecha_ValueChanged(object sender, EventArgs e)
        {
            this.Edad();
        }

        private void Grabar_Click(object sender, EventArgs e)
        {
            this.GrabarFechaNacimiento();
        }
    }
}
