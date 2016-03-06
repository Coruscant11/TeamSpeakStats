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
        public static int GetClientsConnections()
        {
            try {
                /* Connection au serveur TelNet du teamspeak */
                MinimalisticTelnet.TelnetConnection connection = new MinimalisticTelnet.TelnetConnection("localhost", 10011);
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

                /* TMTC matéo */
                if (clients >= 3)
                    return clients - 3;
                else return clients;

            } catch(Exception e) {

                Console.WriteLine("Erreur lors de la récupération du nombre de clients. 0 Clients retournés au fichier.");
                return 0;
            }
        }
    }
}
