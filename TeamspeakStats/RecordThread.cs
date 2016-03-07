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
        private string m_Url;

        public RecordThread(int time, string connect_file_location, string date_file_location, string url)
        {
            this.m_Con = new ConnectFileManager();
            this.m_Con.Initialize(connect_file_location);

            this.m_Date = new DateFileManager();
            this.m_Date.Initialize(date_file_location);

            this.m_Time = time;
            this.m_Url = url;
        }

        public void Start()
        {
            DateTime date = DateTime.Now;
            Console.WriteLine("------------------------------------------------\nRécupération des informations ... (" + date.ToString() + ")");

            int clients = ClientsGetter.GetClientsConnections(this.m_Url);
            Console.WriteLine(clients + " connectés.");

            Console.WriteLine("Ecriture des informations ...");         
            this.m_Con.AppendData(clients);
            this.m_Date.AppendData(date);

            Console.WriteLine("Done.\n------------------------------------------------\n\n");

            this.m_Con.Close();
            this.m_Date.Close();
        }

        public void Stop()
        {
            this.m_Con = null;
            this.m_Date = null;
        }
    }
}
