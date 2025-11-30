using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBotnet.Server
{
    internal class BuildConfig
    {
        public string FileName = "CsClient.exe";

        public bool Startup = false;
        public string StartupScope = "<UserScope>";

        public bool AntiVM = false;

        public bool SleepBeforeStart = false;
        public int SleepTime = 0;

        public int TimeBetweenReconnects = 3;

        public string Mutex = "<CsMutex>";

        public string[] C2s = { };
        public string Port = "";

        public BuildConfig() 
        {
        }
    }
}
