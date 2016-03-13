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
        public static void SendMail(string destination, string error, string date)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("teamspeakstats@gmail.com", "mateolepddu06"),
                EnableSsl = true
            };
            try
            {
                client.Send("teamspeakstats@gmail.com", destination, "Notification d'erreur du BOT", "Une impossibilité d'envoi a été constatée lors d'une tentative de récupération des données du serveur TeamSpeak le " + date + ".\n" + "Mais que fait l'administration ?\n\nVoici l'erreur : \n" + error);
                Console.WriteLine("Envoyé");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
