using System;
using System.Collections.Generic;
using System.IO;
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
            Console.WriteLine("Appuyer sur entrée pour lancer le processus.");
            Console.ReadLine();

            CheckDirectorys();
            string url;
            int mins;

            string[] linesConfig = File.ReadAllLines("config.txt");

            mins = int.Parse(linesConfig[0]);
            url = linesConfig[1];

            mins *= 1000;

            TeamspeakStatsRecorder rec = new TeamspeakStatsRecorder(url, "datas/dates.txt", "datas/connections.txt", mins);

            Console.WriteLine("Lancement du programme.");

            rec.StartRecord();
        }
        
        static void CheckDirectorys()
        {
            if (!Directory.Exists("datas"))
                Directory.CreateDirectory("datas");
        }
    }
}
