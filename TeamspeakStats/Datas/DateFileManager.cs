using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamspeakStats
{
    class DateFileManager : FileManager
    {
        /* Même fonction, mais avec une date en paramètre */
        public void AppendData(DateTime date)
        {
            string dateText = String.Format("{0:dd/MM/yyyy HH:mm:ss}", date);
            StreamWriter sw = File.AppendText(this.m_File_Location);
            sw.WriteLine(dateText);
            sw.Flush();
            sw.Close();
        }

        /* Ferme les flux */
        public override void Close()
        {

        }
    }
}
