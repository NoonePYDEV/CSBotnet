using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBotnet.Server
{
    internal class MsgBox
    {
        public static void Error(string Title, string Message)
        {
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Info(string Title, string Message)
        {
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string Title, string Message)
        {
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool AskYesNo(string Title, string Message, string IconType)
        {
            MessageBoxIcon Icon;

            if (IconType == "Warning")
            {
                Icon = MessageBoxIcon.Warning;
            }
            else if (IconType == "Info")
            {
                Icon = MessageBoxIcon.Information;
            }
            else if (IconType == "Question")
            {
                Icon = MessageBoxIcon.Question;
            }
            else if (IconType == "Error") 
            { 
                Icon = MessageBoxIcon.Error; 
            }
            else
            {
                return false;
            }

            return MessageBox.Show(Message, Title, MessageBoxButtons.YesNo, Icon) == DialogResult.Yes;
        }
    }
}
