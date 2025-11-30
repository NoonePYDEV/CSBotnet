using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBotnet.Server
{
    public class AttackDetails
    {
        public static bool Attacking = false;
        public static string? TargetUrl = null;
        public static int? TargetPort = null;
        public static int? ClientCount = null;

        public static void SetAttackStatus(bool Status, string? Url = null, int? Port = null, int? _ClientCount = null)
        {
            if (Status == true)
            {
                TargetUrl = Url;
                TargetPort = Port;
                Attacking = true;
                ClientCount = _ClientCount;
            }
            else 
            {
                TargetUrl = null;
                TargetPort = null;
                Attacking = false;
                ClientCount = null;
            }
        }
    }
}
