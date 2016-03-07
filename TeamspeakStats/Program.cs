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
            int mins = int.Parse(File.ReadAllText("config.txt"));
            mins *= 1000;

            TeamspeakStatsRecorder rec = new TeamspeakStatsRecorder("datas/dates.txt", "datas/connections.txt", mins);

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
