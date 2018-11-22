using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Data;


namespace SOCIOS.Res_Disp
{
    public class Servicios
    {
        bo dlog = new bo();
       public List<Resolucion_Dispocision> getDataResDisp(int Tipo,int Anio,int Numero,string Descripcion )
        {
            string Query = @"select R.ID,R.ANIO,R.NUMERO,R.ARCHIVOPDF,R.DESCRIPCION,R.TIPO,T.TIPO   from RES_Y_DISP R, RES_Y_DISP_TIPO T  WHERE R.TIPO=T.ID  ";

            if (Tipo != 0)
            {
                Query = Query + " and R.Tipo=  " + Tipo;
            }
            if (Anio !=0)
                Query = Query + " and R.ANIO=  " + Anio.ToString();
            if (Descripcion.Length > 0)
            { Query = Query + " and R.DESCRIPCION LIKE'%" + Descripcion.TrimEnd().TrimStart() + "%'";
            }

            List<Resolucion_Dispocision> lista = new List<Resolucion_Dispocision>();
            DataRow[] foundRows;

            foundRows = dlog.BO_EjecutoDataTable(Query).Select();
            int I = 0;
            foreach (DataRow dr in foundRows)
            {
                Resolucion_Dispocision item = new Resolucion_Dispocision();

                item.ID          = Int32.Parse(foundRows[I][0].ToString());
                item.ANIO        = Int32.Parse(foundRows[I][1].ToString());
                item.NUMERO      = Int32.Parse(foundRows[I][2].ToString());
                item.ARCHIVO     = foundRows[I][3].ToString();
                item.DESCRIPCION = foundRows[I][4].ToString();
                item.TIPO        = Int32.Parse(foundRows[I][5].ToString());
                item.TIPO_RES    = foundRows[I][6].ToString();
                I = I + 1;
                lista.Add(item);

            }




            return lista;

        
        }


       public Resolucion_Dispocision getRes_Disp(int ID)
       {
           string Query = @"select R.ID,R.ANIO,R.NUMERO,R.ARCHIVOPDF,R.DESCRIPCION,R.TIPO,T.TIPO   from RES_Y_DISP R, RES_Y_DISP_TIPO T  WHERE R.TIPO=T.ID and R.ID=  "+ ID.ToString();

           Resolucion_Dispocision item = new Resolucion_Dispocision();

           List<Resolucion_Dispocision> lista = new List<Resolucion_Dispocision>();
           DataRow[] foundRows;

           foundRows = dlog.BO_EjecutoDataTable(Query).Select();
           int I = 0;
           foreach (DataRow dr in foundRows)
           {
              

               item.ID = Int32.Parse(foundRows[I][0].ToString());
               item.ANIO = Int32.Parse(foundRows[I][1].ToString());
               item.NUMERO = Int32.Parse(foundRows[I][2].ToString());
               item.ARCHIVO = foundRows[I][3].ToString();
               item.DESCRIPCION = foundRows[I][4].ToString();
               item.TIPO = Int32.Parse(foundRows[I][5].ToString());
               item.TIPO_RES = foundRows[I][6].ToString();
              

           }




           return item;


       }


       public void Setear_Combo_Tipo(ComboBox comboTipo,bool Filtro)
       {
           comboTipo.DataSource = null;

           comboTipo.Items.Clear();
           int index = 0;
           if (Filtro)
           {
               comboTipo.Items.Insert(index, "TODOS");
               index = index + 1;
           }
          
           comboTipo.Items.Insert(index, "RESOLUCIONES");
                   index = index + 1;
           comboTipo.Items.Insert(index, "RESOLUCIONES PRESIDENCIALES");
                   index = index + 1;
           comboTipo.Items.Insert(index, "DISPOCISIONES");
                   index = index + 1;
           comboTipo.Items.Insert(index, "DISPOCISIONES PRESIDENCIALES");
           index = index + 1;

           comboTipo.SelectedValue = "1";
       }
       public int Obtener_Valor_Tipo(ComboBox comboTipo)
       {

           string CTIPO = comboTipo.SelectedItem.ToString();
           int Tipo = 0;
           if (CTIPO == "DISPOCISIONES")
               Tipo = (int)Tipo_Resolucion.DISPOCISION;
           else if (CTIPO == "DISPOCISIONES PRESIDENCIALES")
           {
               Tipo = (int)Tipo_Resolucion.DISPOCISION_PRESIDENCIAL;
           }
           else if (CTIPO == "RESOLUCIONES")
           {
               Tipo = (int)Tipo_Resolucion.RESOLUCION;
           }
           else if (CTIPO == "DISPOCISIONES PRESIDENCIALES")
           {
               Tipo = Tipo = (int)Tipo_Resolucion.RESOLUCION_PRESIDENCIAL;
           }

           return Tipo;

       }

       public string get_path(int ID)
       {

           Resolucion_Dispocision item = new Resolucion_Dispocision();

           string rutaArchivos = "\\\\192.168.1.6\\web\\resoluciones\\archivosPDF\\";
           item = this.getRes_Disp(ID);

           if (item.TIPO == (int)Tipo_Resolucion.DISPOCISION)
               rutaArchivos = rutaArchivos + "disposiciones\\";
           else if (item.TIPO == (int)Tipo_Resolucion.DISPOCISION_PRESIDENCIAL)
               rutaArchivos = rutaArchivos + "disposicionesp\\";
           else if (item.TIPO == (int)Tipo_Resolucion.RESOLUCION)
               rutaArchivos = rutaArchivos + "resoluciones\\";
           else if (item.TIPO == (int)Tipo_Resolucion.RESOLUCION_PRESIDENCIAL)
               rutaArchivos = rutaArchivos + "resolucionesp\\";

           return rutaArchivos + item.ARCHIVO;




         
       
       }


    }
}
