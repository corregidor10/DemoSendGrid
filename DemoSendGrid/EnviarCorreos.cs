using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace DemoSendGrid
{
    public class EnviarCorreos
    {
        // TODO 002. Creamos un metodo que nos genera el envío de de correos
        public void PostMails(String Name,String mailFrom,String mailsender, String asunto, String body)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress(mailsender));

                // From
                mailMsg.From = new MailAddress(mailFrom, Name);

                // Subject and multipart/alternative Body
                mailMsg.Subject = asunto;
                string text = body;
                string html = body;
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

              
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
             

                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}