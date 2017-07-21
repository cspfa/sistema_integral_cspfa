using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class listadoDeControlPrint : Form
    {
        public listadoDeControlPrint(int PAR, string ADTO, string ORIGEN_ALTA)
        {
            InitializeComponent();
            dgvResultadoListado.ColumnCount = 16;
            dgvResultadoListado.Columns[0].Name = "Afiliado";
            dgvResultadoListado.Columns[1].Name = "Beneficio";
            dgvResultadoListado.Columns[2].Name = "Apellido";
            dgvResultadoListado.Columns[3].Name = "Nombres";
            dgvResultadoListado.Columns[4].Name = "Nº Socio";
            dgvResultadoListado.Columns[5].Name = "Jerarquía";
            dgvResultadoListado.Columns[6].Name = "LP";
            dgvResultadoListado.Columns[7].Name = "Destino";
            dgvResultadoListado.Columns[8].Name = "Alta Policial";
            dgvResultadoListado.Columns[9].Name = "Alta Circulo";
            dgvResultadoListado.Columns[10].Name = "Tipo Doc";
            dgvResultadoListado.Columns[11].Name = "Nº Doc";
            dgvResultadoListado.Columns[12].Name = "Cod Dto";
            dgvResultadoListado.Columns[13].Name = "Categoria";
            dgvResultadoListado.Columns[14].Name = "Alta Dto";
            dgvResultadoListado.Columns[15].Name = "Origen Alta";

            llenarDataGrid(PAR, ADTO, ORIGEN_ALTA);
        }

        public void llenarDataGrid(int PAR, string ADTO, string ORIGEN_ALTA)
        {
            string month = ADTO.Substring(3, 2);
            string year = ADTO.Substring(6, 4);
            string origen = ORIGEN_ALTA.Substring(3, 3);

            string query = "SELECT TITULAR.AAR, TITULAR.ACRJP1, TITULAR.ACRJP2, TITULAR.ACRJP3, TITULAR.PAR, TITULAR.PCRJP1, TITULAR.PCRJP2, TITULAR.PCRJP3, ";
            query += "TITULAR.APE_SOC, TITULAR.NOM_SOC, TITULAR.NRO_SOC, TITULAR.NRO_DEP, CODIGOS.SIGN AS JERARQ, TITULAR.LEG_PER, TITULAR.DESTINO, TITULAR.F_ALTPO, TITULAR.F_ALTCI, ";
            query += "TITULAR.TIP_DOC, TITULAR.NUM_DOC, TITULAR.COD_DTO, CODIGOS.SIGN AS CAT_SOC, TITULAR.A_DTO, TITULAR.ORIGEN_ALTA FROM TITULAR, CODIGOS ";
            query += "WHERE TITULAR.PAR = " + PAR + " ";
            query += "AND TITULAR.ORIGEN_ALTA = '" + origen + "' ";
            query += "AND TITULAR.A_DTO = '" + year + "/" + month + "/01' ";
            query += "AND SUBSTRING(CODIGOS.CODIGO FROM 1 FOR 2) = 'JE' AND SUBSTRING(CODIGOS.CODIGO FROM 3 FOR 4) = TITULAR.JERARQ ";
            query += "AND SUBSTRING(CODIGOS.CODIGO FROM 1 FOR 2) = 'CA' AND SUBSTRING(CODIGOS.CODIGO FROM 4 FOR 3) = TITULAR.CAT_SOC;";

            //Clipboard.SetDataObject(query);
            //MessageBox.Show(query);

            BO_Datos dlog = new BO_Datos();

            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(query).Select();

            if (foundRows.Length > 0)
            {
                for (int i = 0; i < foundRows.Length; i++)
                {
                    string afiliado = foundRows[i][0] + "/" + foundRows[i][1] + "/" + foundRows[i][2] + "/" + foundRows[i][3];
                    string beneficio = foundRows[i][4] + "/" + foundRows[i][5] + "/" + foundRows[i][6] + "/" + foundRows[i][7];
                    string nsocio = foundRows[i][10] + "/" + foundRows[i][11];
                    
                    string[] row = { 
                                       afiliado,
                                       beneficio,
                                       foundRows[i][8].ToString(),
                                       foundRows[i][9].ToString(),
                                       nsocio,
                                       foundRows[i][12].ToString(),
                                       foundRows[i][13].ToString(),
                                       foundRows[i][14].ToString(),
                                       foundRows[i][15].ToString(),
                                       foundRows[i][16].ToString(),
                                       foundRows[i][17].ToString(),
                                       foundRows[i][18].ToString(),
                                       foundRows[i][19].ToString(),
                                       foundRows[i][20].ToString(),
                                       foundRows[i][21].ToString(),
                                       foundRows[i][22].ToString(),
                                   };

                    dgvResultadoListado.Rows.Add(row);
                }
            }
        }
    }
}
