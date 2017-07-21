using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SOCIOS
{
    class newBullet
    {
        public Control nBullet(int i, int pa)
        {
            PictureBox bullet = new PictureBox();
            bullet.Location = new System.Drawing.Point(5, i * 22 - 1);
            bullet.Name = "Picture" + (i + 1);
            bullet.Size = new System.Drawing.Size(16, 16);

            if (pa == 1)
                bullet.Image = new Bitmap(SOCIOS.Properties.Resources.bullet_green);
            else
                bullet.Image = new Bitmap(SOCIOS.Properties.Resources.bullet_red);

            return bullet;
        }
    }
}
