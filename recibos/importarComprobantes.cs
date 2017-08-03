using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class importarComprobantes : Form
    {
        bo dlog = new bo();

        string ROLE { get; set; }
        string PTO_VTA { get; set; }

        public importarComprobantes(string TITULO, string ROL)
        {
            InitializeComponent();
            this.Text = TITULO;
            ROLE = ROL;
        }

        private string testConnection()
        {
            string CONN = "";
            string QUERY = "SELECT FIRST(1) ID_TITULAR FROM TITULAR;";
            DataRow[] foundRows;

            try
            {
                foundRows = dlog.BO_EjecutoDataTable_Remota(QUERY, ROLE).Select();
                CONN = "BASE DE DATOS: Conectada";
            }
            catch (Exception error)
            {
                CONN = "BASE DE DATOS: Desconectada";
            }
            
            return CONN;
        }

        private void importarComprobantes_Load(object sender, EventArgs e)
        {
            lbConexion.Text = testConnection();
        }
    }
}
