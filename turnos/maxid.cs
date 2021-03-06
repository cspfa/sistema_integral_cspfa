﻿using System;
using FirebirdSql.Data.Firebird;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace SOCIOS
{
    public class maxid
    {
        bo dlog = new bo();

        public string m(string campo, string tabla)
        {
            string ret = string.Empty;

            try
            {
                string query = "SELECT MAX(" + campo + ") FROM " + tabla + ";";
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();
                ret = foundRows[0][0].ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return ret;
        }

        public string role(string campo, string tabla, string f_role, string v_role)
        {
            string ret = string.Empty;

            try
            {
                string query = "SELECT MAX(" + campo + ") FROM " + tabla + " WHERE " + f_role + " = '" + v_role + "';";
                DataRow[] foundRows;
                foundRows = dlog.BO_EjecutoDataTable(query).Select();
                ret = foundRows[0][0].ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return ret;
        }

        internal string m(string p)
        {
            throw new NotImplementedException();
        }
    }
}
