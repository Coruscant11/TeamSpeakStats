using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamspeakStats
{
    class ClientsGetter
    {
        public static int GetClientsConnections(string url)
        {
            try {
                 
                int clients = GetClients(url);

                /* TMTC matéo */
                if (clients >= 3)
                    return clients - 3;
                else return clients;

            } catch(Exception e) {

                Console.WriteLine("Erreur lors de la récupération du nombre de clients.");
                Console.WriteLine("Nous allons retenter dans 5 secondes.\n");
                Thread.Sleep(5000);

                try {
                    int clients = GetClients(url);
                    return clients;
                } catch (Exception ex) {
                    Console.WriteLine("La récupération est bel et bien impossible.\n0 clients connectés retournés au fichier.");
                    Console.WriteLine("Voici l'erreur : \n");
                    Console.Error.WriteLine(e.Message + "\n");
                    Console.WriteLine("Envois de l'email...");
                    MailSender.SendMail("mateox06@hotmail.fr", ex.Message, DateTime.Now.ToString());
                    return 0;
                }
            }
        }

        private static int GetClients(string url)
        {
            /* Connection au serveur TelNet du teamspeak */
            MinimalisticTelnet.TelnetConnection connection = new MinimalisticTelnet.TelnetConnection(url, 10011);
            connection.Read();

            /* Utilisation de l'id 1 */
            connection.WriteLine("use 1");
            connection.Read();

            /* Récupération des informations */
            connection.WriteLine("serverinfo");
            string serverinfo = connection.Read();
            Thread.Sleep(500);

            /* Recherche de la valeur dans le string */
            string searchForThis = "virtualserver_clientsonline=";
            int firstCharacter = serverinfo.IndexOf(searchForThis);
            string s = serverinfo.Substring(firstCharacter + searchForThis.Length, 2);

            connection.WriteLine("logout"); // Déconnexion

            int clients = int.Parse(s); // Conversion de la chaîne de caractère en int

            /* Destruction des variables */
            connection = null;
            serverinfo = null;
            s = null;
            firstCharacter = 0;
            searchForThis = null;

            return clients;
        }
    }
}
