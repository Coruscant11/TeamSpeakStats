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
            StreamWriter sw = File.AppendText(this.m_File_Location);
            sw.WriteLine(clients);
            sw.Flush();
            sw.Close();
        }

        public override void Close()
        {
            
        }
    }
}
