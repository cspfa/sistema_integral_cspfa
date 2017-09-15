using System;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace SOCIOS
{
    public partial class abmCargos : Form
    {
        BO.bo_IngresosPersonas IP = new BO.bo_IngresosPersonas();
        private string TITULO_FORM { get; set; }
        private string TITULO_LABEL { get; set; }
        private string ERROR_TB { get; set; }
        private string WHICH { get; set; }

        public abmCargos(string CUAL)
        {
            InitializeComponent();
            selector(CUAL);
            this.Text = TITULO_FORM;
            label1.Text = TITULO_LABEL;
        }

        private void selector(string CUAL)
        { 
            switch (CUAL)
            {
                case "CARGO":
                    TITULO_FORM = "ALTA NUEVO CARGO / PUESTO";
                    TITULO_LABEL = "NOMBRE DEL CARGO / PUESTO";
                    ERROR_TB = "COMPLETAR EL CAMPO CARGO / PUESTO";
                    WHICH = "CARGO";
                    break;

                case "ESCALAFON":
                    TITULO_FORM = "ALTA NUEVO ESCALAFON";
                    TITULO_LABEL = "NOMBRE DEL ESCALAFON";
                    ERROR_TB = "COMPLETAR EL CAMPO ESCALAFON";
                    WHICH = "ESCALAFON";
                    break;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (tbCargo.Text == "")
            {
                MessageBox.Show(ERROR_TB, "ERROR");
            }
            else
            {
                try
                {
                    string CARGO = tbCargo.Text.Trim();
                    IP.altaCargoEscalafon(CARGO, WHICH);
                    MessageBox.Show("TODO SALIÓ PERFECTO :)", "LISTO");
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("ALGO SALIÓ MAL :(\n"+error, "ERROR");
                }
            }
        }
    }
}
