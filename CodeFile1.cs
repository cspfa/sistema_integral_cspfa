using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;//namespaces requeridos
using System.Net;
using System.Net.Mail;
using SOCIOS;

namespace Mails
{
    public partial class Mails1 
    {

        public void Enviar_Mail_Error(string mensaje)
        {
            try
            {
                MailMessage mail = new MailMessage();
                //mail.To.Add("mamodarelli@gmail.com");
                mail.To.Add("saiz.hernan@gmail.com");
                MailAddress emisor = new MailAddress("info@prosoft-business.com.ar");
                mail.From = emisor;
                mail.Body = mensaje;
                mail.Subject = "INFORME DE ERROR, SISTEMA CSPFA, USUARIO "+VGlobales.vp_username.Trim()+" ROLE "+VGlobales.vp_role.Trim();
                SmtpClient smtpclient = new SmtpClient("smtp.gmail.com", 25);
                smtpclient.EnableSsl = true;
                NetworkCredential credencial = new NetworkCredential("her.saiz@gmail.com", "hernan1200");
                smtpclient.Credentials = credencial;
                smtpclient.Send(mail);
            }
            
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}