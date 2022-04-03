using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Email
{
    public class SendEmail
    {
        public void sendMail(String receiver, String subject, String body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("hads2205@gmail.com");
                mail.To.Add(receiver);

                mail.Subject = subject;

                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hads2205@gmail.com", "AprobarHADS2022");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}