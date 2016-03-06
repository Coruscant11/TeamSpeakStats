using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamspeakStats
{
    class ConnectFileManager : FileManager
    {
        public void AppendData(int clients)
        {
            File.AppendText(clients.ToString());
        }

        public override void Close()
        {
            
        }
    }
}
