using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SOCIOS.bono.Odontologia
{
  public class ServicioOdonto
    {

      bo dlog = new bo();
      DataRow[] foundRows;
      string QUERY = "";

     

      private void CalculoQuery(int Turno)

      {
           QUERY = "SELECT B.ID ID , S.DETALLE DETALLE  FROM TURNO_BONO T,BONO_ODONTOLOGICO B, SECTACT S WHERE B.ID = T.BONO and S.ID = B.SEC_ACT and T.TURNO=" + Turno.ToString();


          foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();
      }
      
      public int CantidadBonos(int Turno)

      {
          this.CalculoQuery(Turno);

          return foundRows.Length;
        
      
      }

      public void ComboBonos(ComboBox combo,int turno)

      {


          this.CalculoQuery(turno);
          combo.DataSource = null;
          combo.Items.Clear();
          combo.DataSource = dlog.BO_EjecutoDataTable(QUERY);
          combo.DisplayMember = "DETALLE";
          combo.ValueMember = "ID";
          combo.SelectedItem = 1;

      }


    }
}
