using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBotnet.Server
{
    internal class Logger
    {
        public static ListView LogFrame;

        public static void Init(ListView listView)
        {
            LogFrame = listView;
        }

        public static void Info(string Message)
        {
            string Date = DateTime.Now.ToString();
            
            ListViewItem item = new ListViewItem(Date);

            item.SubItems.Add("INFO");
            item.SubItems.Add(Message);

            LogFrame.Invoke(() => LogFrame.Items.Add(item));
        }

        public static void Error(string Message)
        {
            string Date = DateTime.Now.ToString();

            ListViewItem item = new ListViewItem(Date);

            item.SubItems.Add("ERROR");
            item.SubItems.Add(Message);

            LogFrame.Invoke(() => LogFrame.Items.Add(item));
        }

        public static void Warning(string Message)
        {
            string Date = DateTime.Now.ToString();

            ListViewItem item = new ListViewItem(Date);

            item.SubItems.Add("WARNING");
            item.SubItems.Add(Message);

            LogFrame.Invoke(() => LogFrame.Items.Add(item));
        }
    }
}
