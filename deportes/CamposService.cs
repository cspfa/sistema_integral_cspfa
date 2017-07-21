using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using FirebirdSql.Data.Services;
using FirebirdSql.Data.Server;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace SOCIOS.deportes
{
  public   class CamposService
    {
        public void ComboRol(ComboBox cb)
        {
            string Query = "select RDB$ROLE_NAME  NAME from RDB$ROLES  WHERE (RDB$ROLE_NAME ='DEPORTES' or  LEFT(RDB$ROLE_NAME, 3) = 'CPO') ";
            bo dlog = new bo();

            cb.DataSource = null;
            cb.Items.Clear();
            cb.DataSource = dlog.BO_EjecutoDataTable(Query);
            cb.DisplayMember = "NAME";
            cb.ValueMember = "NAME";
            cb.SelectedItem = 1;
        }

        public void ComboActividad(string ROL,ComboBox cb)
        {
            string Query = "SELECT ID,DETALLE FROM SECTACT WHERE ROL='" + ROL + "' AND DETALLE  NOT LIKE '%CUOTA%' and DETALLE NOT LIKE '%ATENCION AL PUBLICO%' AND DETALLE NOT LIKE '%TOALLAS%'  ORDER BY ID";
            bo dlog = new bo();
            cb.DataSource = null;
            cb.Items.Clear();
          
           
            cb.DataSource = dlog.BO_EjecutoDataTable(Query);
            cb.DisplayMember = "DETALLE";
            cb.ValueMember = "ID";
            cb.SelectedItem = 1;








        }
    }
}
