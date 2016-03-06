using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamspeakStats
{
    class RecordThread
    {
        private ConnectFileManager m_Con;
        private DateFileManager m_Date;
        private int m_Time;

        private bool m_Run;

        public RecordThread(int time, string connect_file_location, string date_file_location)
        {
            this.m_Con = new ConnectFileManager();
            this.m_Con.Initialize(connect_file_location);

            this.m_Date = new DateFileManager();
            this.m_Date.Initialize(date_file_location);

            this.m_Time = time;
            this.m_Run = false;
        }

        public void Start()
        {
            this.m_Run = true;

            do
            {
                DateTime date = DateTime.Now;
                Console.WriteLine("Récupération des informations ... (" + date.ToString() + ")");

                int clients = ClientsGetter.GetClientsConnections();
                Console.WriteLine(clients + " connectés.");

                Console.WriteLine("Ecriture des informations ...");         
                this.m_Con.AppendData(clients);
                this.m_Date.AppendData(date);

                Console.WriteLine("Done.\n");

                Thread.Sleep(this.m_Time);
            } while (this.m_Run);
        }

        public void Stop()
        {
            this.m_Con.Close();
            this.m_Date.Close();
            this.m_Run = false;
        }
    }
}
