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
        private string ROLE { get; set; }

        public Importador()
        {
            InitializeComponent();
        }
    }
}
