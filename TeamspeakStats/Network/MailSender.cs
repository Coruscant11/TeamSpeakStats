using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TeamspeakStats
{
    class MailSender
    {
        public static void SendMail(string from, string destination, string text)
        {
            using (SmtpClient smtpClient = new SmtpClient("smtp.live.com"))
            {
                MailMessage message = new MailMessage();

                message.From = new MailAddress("mabiteosblc@hotmail.com", "Coruscant11");
                message.To.Add("mateox06@hotmail.fr");
                message.Subject = "Subject email";
                message.Body = "Content email";
                message.IsBodyHtml = false;

                smtpClient.SendAsync(message, null);
            }
        }
    }
}
