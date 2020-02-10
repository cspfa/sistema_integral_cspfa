using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SOCIOS.Notificacion
{
   public class Notificaciones
    {
       NotifyIcon nf = new NotifyIcon();
   
       public Notificaciones()
       {
           nf.Icon = new Icon(@"C:\CSPFA_SOCIOS\logo.ico");
           nf.Visible = true;

       }

       public void Push_Notificacion(string Mensaje)
       {
           nf.BalloonTipIcon = ToolTipIcon.Info;

           nf.BalloonTipText = Mensaje;

           nf.BalloonTipTitle = "Nueva Notificacion!";
           nf.ShowBalloonTip(1000);

       }

    }
}
