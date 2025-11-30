using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CSBotnet.Server
{
    internal class Client
    {
        private static readonly Random _random = new Random();

        public string Id;
        public string Ip;
        public string GPU;
        public string CPU;
        public string RAM;
        public string UUID;
        public string[] Antiviruses;
        public string MachineName;
        public string Username;
        public string CountryCode;
        public string Os;
        public string CountryFlagPath;

        public NetworkStream Stream;
        public TcpClient Socket;

        public Client(string Ip, string CountryCode, string UserName, string MachineName, string GPU, string CPU, string Ram, string UUID, string OsDetails, string[] Antiviruses, NetworkStream Stream, TcpClient Socket)
        {
            this.Id = NewId();
            this.Ip = Ip;
            this.CountryCode = CountryCode;
            this.UUID = UUID;
            this.Os = OsDetails;
            this.CPU = CPU;
            this.GPU = GPU;
            this.RAM = Ram;
            this.Username = UserName;
            this.MachineName = MachineName;
            this.Antiviruses = Antiviruses;
            this.Socket = Socket;
            this.Stream = Stream;
            this.CountryFlagPath = "C:\\Users\\b64\\source\\repos\\CSBotnet\\CSBotnet.Server\\CSBotnet.Server\\Img\\Flags" + "\\" + CountryCode.ToLower() + ".png";
        }

        private static string NewId(int length = 32)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = _random.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }


    }
}
