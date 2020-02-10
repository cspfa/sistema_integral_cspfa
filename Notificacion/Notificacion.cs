using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS.Notificaciones
{
    public partial class Notificacion : Form
    {
        NotifyIcon nf = new NotifyIcon();
        public Notificacion()
        {
            InitializeComponent();
            CreateContextMenu();
            nf.Icon = new Icon(@"C:\CSPFA_SOCIOS\logo.ico");
            nf.Visible = true;
        }

     

        private void CreateContextMenu()
        {
            ContextMenuStrip menuStrip = new ContextMenuStrip();
            ToolStripMenuItem menuItem = new ToolStripMenuItem("Ver");
            menuItem.Click += new EventHandler(menuItem_Click);
            menuItem.Name = "Ver";
            menuStrip.Items.Add(menuItem);
    
            this.ContextMenuStrip = menuStrip;
        }

         void menuItem_Click(object sender, EventArgs e)
            {
                ToolStripItem menuItem = (ToolStripItem)sender;
                if (menuItem.Name == "Ver")
                {
                    Application.Exit();
                }
            }

        private void button1_Click(object sender, EventArgs e)
        {
     
         
            Push_Notificacion("Test");
        }

        public void Push_Notificacion(string Mensaje)
            
        {  nf.BalloonTipIcon = ToolTipIcon.Info;

           nf.BalloonTipText = Mensaje ;
 
           nf.BalloonTipTitle = "Nueva Notificacion!";
           nf.ShowBalloonTip(1000);
        
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

 

   
    }
}
