using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamspeakStats
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le TeamspeakStats de l'OSBLC.");
            Console.WriteLine("Tous les combien de secondes voulez-vous enregister les données ?");

            string str = Console.ReadLine();
            short mins = short.Parse(str);
            mins *= 1000;

            TeamspeakStatsRecorder rec = new TeamspeakStatsRecorder("dates.txt", "connections.txt", mins);

            Console.WriteLine("Lancement du programme.");

            rec.StartRecord();
        }
    }
}
