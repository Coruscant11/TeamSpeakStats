﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamspeakStats
{
    abstract class FileManager
    {
        protected string m_File_Location;

        public void Initialize(string file)
        {
            this.m_File_Location = file;
        }

        public void AppendData(string data)
        {
            File.AppendText(data);
        }
        public abstract void Close();
    }
}
