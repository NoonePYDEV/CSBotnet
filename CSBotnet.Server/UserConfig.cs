using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBotnet.Server
{
    internal class UserConfig
    {
        public static int ServerPort = 4444;
        public static List<string> BlackListedIPs = new List<string>();
        public static List<string> BlackListedUUIDs = new List<string>();
        public static string ConfigPath = "C:\\Users\\b64\\source\\repos\\CSBotnet\\CSBotnet.Server\\CSBotnet.Server\\UserConfig\\config.json";

        public static void LoadConfig() 
        { 
            string RawConfig = File.ReadAllText(ConfigPath);  
            dynamic Config = JsonConvert.DeserializeObject(RawConfig);

            ServerPort = Config.serverPort;
            BlackListedIPs = ((JArray)Config.blacklistedIps).ToObject<List<string>>();
            BlackListedUUIDs = ((JArray)Config.blacklistedUuids).ToObject<List<string>>();
        }

        public static void UpdateConfig(bool RestartNeeded = false, Form? Window = null)
        {
            if (RestartNeeded)
            {
                if (!MsgBox.AskYesNo("Server restart", "Are you sure you want to restart the server ?", "Question"))
                {
                    return;
                }
            }

            string RawConfig = System.Text.Json.JsonSerializer.Serialize(new
            {
                serverPort = ServerPort,
                blacklistedIps = BlackListedIPs,
                blacklistedUuids = BlackListedUUIDs
            });

            File.WriteAllText(ConfigPath, RawConfig);

            if (RestartNeeded)
            {
                Process Reloader = new Process();

                Reloader.StartInfo.FileName = Application.ExecutablePath;
                Reloader.StartInfo.CreateNoWindow = true;
                Reloader.Start();

                Application.Exit();
            }
        }
    }
}
