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
        bo_Bonos dlog = new bo_Bonos();

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
                QUERY = "SELECT F_NACIM FROM TITULAR WHERE ID_TITULAR=  " + ID + "AND NRO_SOC= " + NRO + " AND NRO_DEP=" + DEP;
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

            try
            {
                dlog.Update_Fecha_Nacimiento(dpFecha.Value, Int32.Parse(ID), Int32.Parse(NRO), Int32.Parse(DEP), Int32.Parse(BARRA), TIPO);
                
                MessageBox.Show("FECHA DE NACIMIENTO CAMBIADA CON EXITO.");
            } catch (Exception ex)
                { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
