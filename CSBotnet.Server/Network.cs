using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CSBotnet.Server
{
    public class Network
    {
        public static string ReceiveString(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            StringBuilder messageBuilder = new StringBuilder();
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string chunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                messageBuilder.Append(chunk);

                if (messageBuilder.ToString().EndsWith("<End>"))
                    break;
            }

            string fullMessage = messageBuilder.ToString();
            return fullMessage.Replace("<End>", "");
        }

        public static void SendString(NetworkStream stream, string message)
        {
            if (stream == null || !stream.CanWrite)
                return;

            string dataToSend = message + "<End>";
            byte[] buffer = Encoding.UTF8.GetBytes(dataToSend);
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
