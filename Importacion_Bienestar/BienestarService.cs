using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace SOCIOS.Bienestar
{
    



    public class RegistroBienestar

    {
        public string NroAfiliado  { get; set; }
        public string DNI          { get; set; }
        public string Telefono     { get; set; }
        public string Celular      { get; set; }
        public string Domiclio     { get; set; }
        public string Ciudad       { get; set; }
        public string Partido      { get; set; }
        public string Provincia    { get; set; }
        public string CP           { get; set; }
        public string Departamento { get; set; }
        public string Piso         { get; set; }
        public string Torre        { get; set; }
        public string Parcela      { get; set; }
        public string Email        { get; set; }


    }
    class BienestarService
    {
        bo_Entrada_Campo dlog = new bo_Entrada_Campo();

        public List<RegistroBienestar> getRegistro(string DNI)

        {
            List<RegistroBienestar> Lista = new List<RegistroBienestar>();
            RegistroBienestar  item = new RegistroBienestar();

            string QUERY = @"SELECT  * from  BIENESTAR_DATOS  WHERE 1=1";

            //AND ROL = '" + VGlobales.vp_role + "'";

            if (DNI.Length>0)
                QUERY = QUERY + " AND  DNI='" +DNI +"' ";

            



            DataRow[] foundRows;
            foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

            if (foundRows.Length > 0)
            {


                int I = 0;

                while (I <= (foundRows.Length - 1))
                {

                    item = new RegistroBienestar();

               
                    item.DNI             = foundRows[I][1].ToString().Trim();
                    item.NroAfiliado     = foundRows[I][2].ToString().Trim();
                    item.Telefono        = foundRows[I][3].ToString().Trim();
                    item.Celular         = foundRows[I][4].ToString().Trim();
                    item.Domiclio        = foundRows[I][5].ToString().Trim();
                    item.Ciudad          = foundRows[I][6].ToString().Trim();
                    item.Partido         = foundRows[I][7].ToString().Trim();
                    item.Provincia       = foundRows[I][8].ToString().Trim();
                    item.CP              = foundRows[I][9].ToString().Trim();
                    item.Piso            = foundRows[I][10].ToString().Trim();
                    item.Departamento    = foundRows[I][11].ToString().Trim();
                    item.Torre           = foundRows[I][12].ToString().Trim();
                    item.Parcela         = foundRows[I][13].ToString().Trim();
                    item.Email           = foundRows[I][14].ToString().Trim();

                  

                    I = I + 1;

                    Lista.Add(item);
                }
            }




            return Lista;

        }
    }
}
