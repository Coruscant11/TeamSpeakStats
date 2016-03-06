﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamspeakStats
{
    class TeamspeakStatsRecorder
    {
        private RecordThread m_RT;
        private string m_DateFile;
        private string m_ConnectFile;
        private int m_Time;
        private bool run;

        public TeamspeakStatsRecorder(string date_file_location, string connects_file_location, int seconds)
        {
            this.m_Time = seconds;
            this.m_DateFile = date_file_location;
            this.m_ConnectFile = connects_file_location;
        }

        public void StartRecord()
        {
            run = true;
            do
            {
                this.m_RT = new RecordThread(this.m_Time, this.m_ConnectFile, this.m_DateFile);
                this.m_RT.Start();
                Thread.Sleep(this.m_Time);
                this.m_RT.Stop();
                this.m_RT = null;
            } while (run);
        }

        public void StopRecord()
        {
            this.run = false;
        }
    }
}
