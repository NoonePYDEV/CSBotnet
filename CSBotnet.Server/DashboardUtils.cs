using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBotnet.Server
{
    class DashboardUtils
    {
        private static ListView Dashboard;

        public static void Init(ListView listView)
        {
            Dashboard = listView;
        }

        public static bool IsAnyClientSelected()
        {
            return Dashboard.SelectedItems.Count > 0;
        }

        public static Client GetSelectedClient()
        { 
            ListViewItem item = Dashboard.Invoke(() => Dashboard.SelectedItems[0]);
            return OnlineClients.Clients.GetValueOrDefault(item.SubItems[4].Text);
        }
    }
}
