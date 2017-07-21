using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace SOCIOS
{
    class newLabel
    {
        public Control label(int i, string nombre)
        {
            Label MyLabel = new Label();
            MyLabel.Location = new System.Drawing.Point(22, i * 22);
            MyLabel.Name = "Label" + (i + 1);
            MyLabel.Size = new System.Drawing.Size(200, 13);
            MyLabel.Text = nombre;
            return MyLabel;
        }
    }
}
