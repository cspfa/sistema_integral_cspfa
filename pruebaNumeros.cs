using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class pruebaNumeros : Form
    {
        public pruebaNumeros()
        {
            InitializeComponent();
            prueba();
        }

        public void prueba()
        {
            numerosAletras nal = new numerosAletras();
            label1.Text = nal.convertir("2395803,16");

        }
    }
}
