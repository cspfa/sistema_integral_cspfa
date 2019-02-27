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


      public int GetMax_ID_ROL(string ROL, int CODINT)
      {

          string Query = "";
          QUERY = "SELECT coalesce (MAX(ID_ROL),0) FROM Bono_Odontologico WHERE ROL='" + ROL + "' and CODINT=" + CODINT.ToString();
          if (CODINT == 10236 ||CODINT ==  10380)
          {
              QUERY = "SELECT coalesce (MAX(ID_ROL),0) FROM Bono_Odontologico WHERE ROL='" + ROL + "' and (CODINT=10236 or CODINT=10380)";
          }
          
          DataRow[] foundRows;
          foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

          if (foundRows.Length > 0)
          {
              return Int32.Parse(foundRows[0][0].ToString().Trim())+1;
          }
          else
              return 1;


      }


      public  int GetMaxID(string NRO_SOCIO,string NRO_DEP,string BARRA)
      {
          string QUERY = "SELECT MAX(ID) FROM Bono_Odontologico WHERE NRO_SOCIO= " + NRO_SOCIO + " AND NRO_DEP=" + NRO_DEP + " AND BARRA =" + BARRA;
          DataRow[] foundRows;
          foundRows = dlog.BO_EjecutoDataTable(QUERY).Select();

          if (foundRows.Length > 0)
          {
              return Int32.Parse(foundRows[0][0].ToString().Trim());
          }
          else
              return 0;







      }



      public int Tratamiento_Odontologico_CodInt(int idProfesional, int SecAct)
      {

          int CodInt = 0;

          if (idProfesional == 26)
          {
              idProfesional = Int32.Parse(Config.getValor("SERVICIOS_MEDICOS", "ANER", 1));
          }

          switch (idProfesional)
          {
              case 27:
                  CodInt = Int32.Parse(Config.getValor("ODON-GENERAL-TAVELLA", "COD_ODONTO", 2));
                  break;
              case 28:
                  {
                      if (SecAct == 110)
                          CodInt = Int32.Parse(Config.getValor("ODON-GENERAL-VILLAGRAN", "COD_ODONTO", 2));
                      else
                          CodInt = Int32.Parse(Config.getValor("ODON-PROTESIS-VILLAGRAN", "COD_ODONTO", 2));
                  }
                  break;
              case 170:

                  CodInt = Int32.Parse(Config.getValor("ODON-GENERAL-ANER", "COD_ODONTO", 2));
                  break;
              case 122:

                  CodInt = Int32.Parse(Config.getValor("ODON-PROTESIS-VILLAGRAN", "COD_ODONTO", 2));
                  break;
              case 374:
                  CodInt = Int32.Parse(Config.getValor("ODON-GENERAL-ANER", "COD_ODONTO", 2));
                  break;



          }

          return CodInt;

      }
    }
}
