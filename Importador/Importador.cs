using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using SOCIOS;

namespace Importador
{
    public partial class Importador : Form
    {
        List<SOCIOS.EntradaCampo> LISTA_EC = new List<SOCIOS.EntradaCampo>();
        List<SOCIOS.deportes.Deporte_Importacion> LISTA_DEPORTES = new List<SOCIOS.deportes.Deporte_Importacion>();

        SOCIOS.bo_Entrada_Campo dlog = new bo_Entrada_Campo();
        EntradaCampoService entradaCampoService = new EntradaCampoService();
        SOCIOS.deportes.DeportesService deporteService = new SOCIOS.deportes.DeportesService();
       
        //SOCIOS.conString 

        private string ROLE { get; set; }

        public Importador()
        {
            InitializeComponent();
            ROLE = "CPOCABA";
        }

        private void cbID_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gpRed_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Refrescar_EC_Click(object sender, EventArgs e)
        {
            this.Refrescar_Entrada_Campo();
        }

        private void Refrescar_Entrada_Campo()
        {
            lBerrores.Text = "";
            lbResultEC.Text = "-";
        LISTA_EC=      entradaCampoService.InfoExportar(chkFiltro.Checked, cbID.Checked, tbDESDE.Text, tbHASTA.Text,ROLE);
        lbEntradaCampo.Text= LISTA_EC.Count.ToString();
        }

        private void Importar_EC_Click(object sender, EventArgs e)
        {
            try {
                lBerrores.Text = "";
                entradaCampoService.Importar_Entrada_Campo(LISTA_EC);
                 lbResultEC.Text = "OK";
                }

            catch (Exception ex)

            {
              Error("ERROR EN ENTRADA CAMPO:"+ ex.Message);
            }
        }

        private void Error(string ERR)

        {
             gpErrores.Visible=true;
            lBerrores.Text =ERR;
        }

        private void btnFiltrarDeportes_Click(object sender, EventArgs e)
        {

            lBerrores.Text = "";
            lbResultDeportes.Text = "-";
            this.Filtrar_Deportes();
        
        
        }

        private void Filtrar_Deportes()

        {
            LISTA_DEPORTES = deporteService.Importar_Exportar_Deporte(FECHAS.fechaUSA(fechaDesde.Value), FECHAS.fechaUSA(fechaHasta.Value), ROLE, true);
            infoDepAlta.Text = LISTA_DEPORTES.Where(x => x.TIPO.Contains("ALTA")).Count().ToString();
            InfoDepDEL.Text = LISTA_DEPORTES.Where(x => x.TIPO.Contains("BAJ")).Count().ToString();
            InfoDepUPD.Text = LISTA_DEPORTES.Where(x => x.TIPO.Contains("MOD")).Count().ToString();
        }

        private void btnImportarDeportes_Click(object sender, EventArgs e)
        {
            try {
                lBerrores.Text = "";
                deporteService.Proceso_Importar_Exportar(LISTA_DEPORTES, fechaDesde.Value, fechaHasta.Value,ROLE, true, true);
                lbResultDeportes.Text = "OK";
            }

            catch (Exception ex)
               {


                   Error("ERROR DEPORTES:" + ex.Message);
            }
        }
    
    }
    }

