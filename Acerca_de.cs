using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOCIOS
{
    public partial class Acerca_de : MicroFour.StrataFrame.UI.Windows.Forms.StandardForm
    {
        public Acerca_de()
        {
            InitializeComponent();
        }

        private void themedDetailWindow1_Click(object sender, EventArgs e)
        {

        }

        /*
               private void button1_Click_1(object sender, EventArgs e)
               {
                   //-- Establish Locals
                   MicroFour.StrataFrame.Messaging.MessagingIcon loIcon;
                   ContextMenuStrip loContext = null;
                   MicroFour.StrataFrame.Messaging.MessagingSounds loSound;
                   string lcTitle = "";
                   string lcText = "";
                   MicroFour.StrataFrame.Messaging.MessagingCardinalPosition loPosition;
                   MicroFour.StrataFrame.Messaging.InfoBoxSpecialEffect loEffect;
                   MicroFour.StrataFrame.Messaging.InfoBoxItem loItem = new MicroFour.StrataFrame.Messaging.InfoBoxItem();
			
                   //-- Set the context menu
                   //loContext = "esta es una prueba";
			
                   //-- Get the end-user settings
                   loIcon = (MicroFour.StrataFrame.Messaging.MessagingIcon.Fatal);
                   loSound = (MicroFour.StrataFrame.Messaging.MessagingSounds.Warning) ;
                   loEffect = (MicroFour.StrataFrame.Messaging.InfoBoxSpecialEffect.DefaultEffect) ;
                   lcText = "AREA DE NOTIFICACION, EL MENSAJE COMPLETO VA ACA.----";
                   lcTitle = "TIULO DEL MENSAJE VA ACA";
                   loPosition = (MicroFour.StrataFrame.Messaging.MessagingCardinalPosition.SouthEast);
			
                   //-- Create an item
                   loItem.EmbeddedIcon = loIcon;
                   loItem.MaxOpacityPercent = 80;
                   loItem.OptionsContextMenu = loContext;
                   loItem.ParentControl = null;
                   loItem.ShowOptionsIcon = loContext != null;
                   loItem.Sound = loSound;
                   loItem.SpecialEffect = loEffect;
                   loItem.Text = lcText;
                   loItem.Title = lcTitle;
                   loItem.WindowPosition = loPosition;
                   loItem.Timeout = 5000;
			
                   switch ((MicroFour.StrataFrame.Messaging.InfoBoxFormType.ErrorBox) )
                   {
                       case MicroFour.StrataFrame.Messaging.InfoBoxFormType.AlertBox:
					
                           loItem.ColorTheme = MicroFour.StrataFrame.Tools.Common.GetOfficeXPColors(MicroFour.StrataFrame.UI.Windows.Forms.WindowsXPColorSchemes.Current);
                           break;
					
                       case MicroFour.StrataFrame.Messaging.InfoBoxFormType.ErrorBox:
					
                           loItem.ColorTheme = MicroFour.StrataFrame.Tools.Common.GetOfficeXPColors(MicroFour.StrataFrame.UI.Windows.Forms.WindowsXPColorSchemes.ErrorRed);
                           break;
					
                       case MicroFour.StrataFrame.Messaging.InfoBoxFormType.NotifyBox:
					
                           loItem.ColorTheme = MicroFour.StrataFrame.Tools.Common.GetOfficeXPColors(MicroFour.StrataFrame.UI.Windows.Forms.WindowsXPColorSchemes.Current);
                           break;
					
                       case MicroFour.StrataFrame.Messaging.InfoBoxFormType.TipBox:
					
                           loItem.ColorTheme = MicroFour.StrataFrame.Tools.Common.GetOfficeXPColors(MicroFour.StrataFrame.UI.Windows.Forms.WindowsXPColorSchemes.TipWindow);
                           break;
					
                       case MicroFour.StrataFrame.Messaging.InfoBoxFormType.WarningBox:
					
                           loItem.ColorTheme = MicroFour.StrataFrame.Tools.Common.GetOfficeXPColors(MicroFour.StrataFrame.UI.Windows.Forms.WindowsXPColorSchemes.Current);
                           break;
					
                   }
			
                   //-- Show the item
                   MicroFour.StrataFrame.Messaging.InfoBox.ShowInfoBox(loItem);
			
                   //-- You can also call the info box with the shared methods below for a one line solution.  The
                   //   approach used in this sample is for demonstration purposes to give a more flexible UI to set
                   //   the display.
			
                   //MicroFour.StrataFrame.Messaging.InfoBox.AlertBox(lcTitle, lcText, Nothing, loContext, loPosition, loIcon)
                   //MicroFour.StrataFrame.Messaging.InfoBox.ErrorBox(lcTitle, lcText, Nothing, loContext, loPosition, loIcon)
                   //MicroFour.StrataFrame.Messaging.InfoBox.NotifyBox(lcTitle, lcText, Nothing, loContext, loPosition, loIcon)
                   //MicroFour.StrataFrame.Messaging.InfoBox.TipBox(lcTitle, lcText, Nothing, loContext, loPosition, loIcon)
                   //MicroFour.StrataFrame.Messaging.InfoBox.WarningBox(lcTitle, lcText, Nothing, loContext, loPosition, loIcon)
			
               }
           }
         */
    }
}