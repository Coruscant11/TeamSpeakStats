using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamspeakStats
{
    class ClientsGetter
    {
        public static int GetClientsConnections()
        {
            /* Connection au serveur TelNet du teamspeak */
            MinimalisticTelnet.TelnetConnection connection = new MinimalisticTelnet.TelnetConnection("server.osblc.fr", 10011);
            connection.Read();

            /* Utilisation de l'id 1 */
            connection.WriteLine("use 1");
            connection.Read();

            /* Récupération des informations */
            connection.WriteLine("serverinfo");
            string serverinfo = connection.Read();
            
            /* Recherche de la valeur dans le string */
            string searchForThis = "virtualserver_clientsonline=";
            int firstCharacter = serverinfo.IndexOf(searchForThis);
            string s = serverinfo.Substring(firstCharacter + searchForThis.Length, 2);

            connection.WriteLine("logout"); // Déconnexion

            return int.Parse(s);
        }
    }
}
