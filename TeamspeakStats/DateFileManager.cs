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
        /* Charge le fichier */
        public override void Initialize(string file)
        {
            this.m_File_Location = file;

            this.m_FileStream = new FileStream(file, FileMode.Append, FileAccess.Write);
            this.m_Writer = new StreamWriter(this.m_FileStream);
        }

        /* Ajoute des données au fichier */
        public override void AppendData(string data)
        {
            m_Writer.WriteLine(data);
            this.m_Writer.Flush();
            this.m_FileStream.Flush();
        }

        /* Même fonction, mais avec une date en paramètre */
        public void AppendData(DateTime date)
        {
            string dateText = String.Format("{0:dd/MM/yyyy HH:mm:ss}", date);
            m_Writer.WriteLine(dateText);
            this.m_Writer.Flush();
            this.m_FileStream.Flush();
        }

        /* Ferme les flux */
        public override void Close()
        {
            this.m_Writer.Close();
            this.m_FileStream.Close();
        }
    }
}
