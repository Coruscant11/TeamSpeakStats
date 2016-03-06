using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamspeakStats
{
    abstract class FileManager
    {
        protected TextWriter m_Writer;
        protected FileStream m_FileStream;
        protected string m_File_Location;

        public abstract void Initialize(string file);
        public abstract void AppendData(string data);
        public abstract void Close();
    }
}
