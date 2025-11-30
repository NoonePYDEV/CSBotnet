namespace CSBotnet.Server
{
    partial class MainWin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            MainTabControl = new TabControl();
            MainPanel = new TabPage();
            DashboardListView = new ListView();
            ClientCountryCol = new ColumnHeader();
            ClientIpCol = new ColumnHeader();
            ClientUsernameCol = new ColumnHeader();
            ClientMachineNameCol = new ColumnHeader();
            ClientIdCol = new ColumnHeader();
            ClientUuidCol = new ColumnHeader();
            ClientOsCol = new ColumnHeader();
            ClientsAntivirusesCol = new ColumnHeader();
            ClientGpuCol = new ColumnHeader();
            ClientCpuCol = new ColumnHeader();
            ClientRamCol = new ColumnHeader();
            ClientOptionsCtxMenu = new ContextMenuStrip(components);
            cleintInformationsToolStripMenuItem = new ToolStripMenuItem();
            disconnectToolStripMenuItem = new ToolStripMenuItem();
            restartToolStripMenuItem = new ToolStripMenuItem();
            runFileToolStripMenuItem = new ToolStripMenuItem();
            AttackPanel = new TabPage();
            groupBox6 = new GroupBox();
            AttackingClientsListView = new ListView();
            AttackerCountry = new ColumnHeader();
            AttackerUserCol = new ColumnHeader();
            AttackerTargetUrlCol = new ColumnHeader();
            AttackerIdCol = new ColumnHeader();
            groupBox5 = new GroupBox();
            AttackDurationLabel = new Label();
            ClientCountLabel = new Label();
            button8 = new Button();
            label2 = new Label();
            AttackDurationTrackbar = new TrackBar();
            ClientCountTrackBar = new TrackBar();
            label1 = new Label();
            CheckTargetServerBtm = new Button();
            TargetPortEntry = new TextBox();
            TargetDomainEntry = new TextBox();
            SecurityPanel = new TabPage();
            groupBox4 = new GroupBox();
            StartRecoveryBtn = new Button();
            ClientsIdsCheckbox = new CheckBox();
            ClientAntivirusesCheckbox = new CheckBox();
            ClientSysinfosCheckbox = new CheckBox();
            ClientIpsAddrCheckbox = new CheckBox();
            groupBox3 = new GroupBox();
            button7 = new Button();
            button6 = new Button();
            groupBox2 = new GroupBox();
            button5 = new Button();
            ServerPortEntry = new TextBox();
            groupBox1 = new GroupBox();
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            BlackListedUUIDsListbox = new ListBox();
            BlacklistIpEntry = new TextBox();
            BlacklistUuidEntry = new TextBox();
            button2 = new Button();
            BlacklistedIpsListbox = new ListBox();
            BuilderPanel = new TabPage();
            groupBox9 = new GroupBox();
            BuilderPortEntry = new TextBox();
            BuildBtn = new Button();
            groupBox8 = new GroupBox();
            BuilderMutexEntry = new TextBox();
            label4 = new Label();
            BuilderFileNameEntry = new TextBox();
            TimeBetweenReconnnectsEntry = new NumericUpDown();
            label3 = new Label();
            SleepTimeEntry = new NumericUpDown();
            BuilderStartupScope = new ComboBox();
            BuilderSleepCbx = new CheckBox();
            BuilderAntiVmCbx = new CheckBox();
            BuilderStartupCbx = new CheckBox();
            groupBox7 = new GroupBox();
            button10 = new Button();
            button9 = new Button();
            BuilderC2Entry = new TextBox();
            C2sListbox = new ListBox();
            LogsPanel = new TabPage();
            LogsListView = new ListView();
            LogsDateCol = new ColumnHeader();
            LogTypeCol = new ColumnHeader();
            LogMessageCol = new ColumnHeader();
            LogsMenuStrip = new ContextMenuStrip(components);
            copyToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            MainTabControl.SuspendLayout();
            MainPanel.SuspendLayout();
            ClientOptionsCtxMenu.SuspendLayout();
            AttackPanel.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AttackDurationTrackbar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ClientCountTrackBar).BeginInit();
            SecurityPanel.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            BuilderPanel.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TimeBetweenReconnnectsEntry).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SleepTimeEntry).BeginInit();
            groupBox7.SuspendLayout();
            LogsPanel.SuspendLayout();
            LogsMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MainTabControl
            // 
            MainTabControl.Controls.Add(MainPanel);
            MainTabControl.Controls.Add(AttackPanel);
            MainTabControl.Controls.Add(SecurityPanel);
            MainTabControl.Controls.Add(BuilderPanel);
            MainTabControl.Controls.Add(LogsPanel);
            MainTabControl.Location = new Point(12, 12);
            MainTabControl.Name = "MainTabControl";
            MainTabControl.SelectedIndex = 0;
            MainTabControl.Size = new Size(784, 426);
            MainTabControl.TabIndex = 0;
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.White;
            MainPanel.Controls.Add(DashboardListView);
            MainPanel.ForeColor = Color.White;
            MainPanel.Location = new Point(4, 24);
            MainPanel.Name = "MainPanel";
            MainPanel.Padding = new Padding(3);
            MainPanel.Size = new Size(776, 398);
            MainPanel.TabIndex = 0;
            MainPanel.Text = "Dashboard";
            // 
            // DashboardListView
            // 
            DashboardListView.Columns.AddRange(new ColumnHeader[] { ClientCountryCol, ClientIpCol, ClientUsernameCol, ClientMachineNameCol, ClientIdCol, ClientUuidCol, ClientOsCol, ClientsAntivirusesCol, ClientGpuCol, ClientCpuCol, ClientRamCol });
            DashboardListView.ContextMenuStrip = ClientOptionsCtxMenu;
            DashboardListView.FullRowSelect = true;
            DashboardListView.GridLines = true;
            DashboardListView.Location = new Point(3, 6);
            DashboardListView.Name = "DashboardListView";
            DashboardListView.Size = new Size(770, 386);
            DashboardListView.TabIndex = 0;
            DashboardListView.UseCompatibleStateImageBehavior = false;
            DashboardListView.View = View.Details;
            DashboardListView.MouseClick += DashboardListView_MouseClick;
            // 
            // ClientCountryCol
            // 
            ClientCountryCol.Text = "Country";
            ClientCountryCol.Width = 80;
            // 
            // ClientIpCol
            // 
            ClientIpCol.Text = "IP Address";
            ClientIpCol.Width = 150;
            // 
            // ClientUsernameCol
            // 
            ClientUsernameCol.Text = "Username";
            ClientUsernameCol.Width = 120;
            // 
            // ClientMachineNameCol
            // 
            ClientMachineNameCol.Text = "Machine Name";
            ClientMachineNameCol.Width = 130;
            // 
            // ClientIdCol
            // 
            ClientIdCol.Text = "Client ID";
            ClientIdCol.Width = 150;
            // 
            // ClientUuidCol
            // 
            ClientUuidCol.Text = "UUID";
            ClientUuidCol.Width = 100;
            // 
            // ClientOsCol
            // 
            ClientOsCol.Text = "OS";
            ClientOsCol.Width = 120;
            // 
            // ClientsAntivirusesCol
            // 
            ClientsAntivirusesCol.Text = "Antiviruses";
            ClientsAntivirusesCol.Width = 80;
            // 
            // ClientGpuCol
            // 
            ClientGpuCol.Text = "GPU";
            ClientGpuCol.Width = 80;
            // 
            // ClientCpuCol
            // 
            ClientCpuCol.Text = "CPU";
            ClientCpuCol.Width = 80;
            // 
            // ClientRamCol
            // 
            ClientRamCol.Text = "RAM";
            ClientRamCol.Width = 80;
            // 
            // ClientOptionsCtxMenu
            // 
            ClientOptionsCtxMenu.Items.AddRange(new ToolStripItem[] { cleintInformationsToolStripMenuItem, disconnectToolStripMenuItem, restartToolStripMenuItem, runFileToolStripMenuItem });
            ClientOptionsCtxMenu.Name = "contextMenuStrip1";
            ClientOptionsCtxMenu.Size = new Size(177, 92);
            // 
            // cleintInformationsToolStripMenuItem
            // 
            cleintInformationsToolStripMenuItem.Image = (Image)resources.GetObject("cleintInformationsToolStripMenuItem.Image");
            cleintInformationsToolStripMenuItem.Name = "cleintInformationsToolStripMenuItem";
            cleintInformationsToolStripMenuItem.Size = new Size(176, 22);
            cleintInformationsToolStripMenuItem.Text = "Client Informations";
            cleintInformationsToolStripMenuItem.Click += cleintInformationsToolStripMenuItem_Click;
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Image = (Image)resources.GetObject("disconnectToolStripMenuItem.Image");
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new Size(176, 22);
            disconnectToolStripMenuItem.Text = "Disconnect";
            disconnectToolStripMenuItem.Click += disconnectToolStripMenuItem_Click;
            // 
            // restartToolStripMenuItem
            // 
            restartToolStripMenuItem.Image = (Image)resources.GetObject("restartToolStripMenuItem.Image");
            restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            restartToolStripMenuItem.Size = new Size(176, 22);
            restartToolStripMenuItem.Text = "Restart";
            restartToolStripMenuItem.Click += restartToolStripMenuItem_Click;
            // 
            // runFileToolStripMenuItem
            // 
            runFileToolStripMenuItem.Image = (Image)resources.GetObject("runFileToolStripMenuItem.Image");
            runFileToolStripMenuItem.Name = "runFileToolStripMenuItem";
            runFileToolStripMenuItem.Size = new Size(176, 22);
            runFileToolStripMenuItem.Text = "Run file";
            runFileToolStripMenuItem.Click += runFileToolStripMenuItem_Click;
            // 
            // AttackPanel
            // 
            AttackPanel.Controls.Add(groupBox6);
            AttackPanel.Controls.Add(groupBox5);
            AttackPanel.Location = new Point(4, 24);
            AttackPanel.Name = "AttackPanel";
            AttackPanel.Padding = new Padding(3);
            AttackPanel.Size = new Size(776, 398);
            AttackPanel.TabIndex = 4;
            AttackPanel.Text = "Attack";
            AttackPanel.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(AttackingClientsListView);
            groupBox6.Location = new Point(304, 6);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(466, 372);
            groupBox6.TabIndex = 1;
            groupBox6.TabStop = false;
            groupBox6.Text = "Progression";
            // 
            // AttackingClientsListView
            // 
            AttackingClientsListView.Columns.AddRange(new ColumnHeader[] { AttackerCountry, AttackerUserCol, AttackerTargetUrlCol, AttackerIdCol });
            AttackingClientsListView.GridLines = true;
            AttackingClientsListView.Location = new Point(15, 40);
            AttackingClientsListView.Name = "AttackingClientsListView";
            AttackingClientsListView.Size = new Size(434, 309);
            AttackingClientsListView.TabIndex = 0;
            AttackingClientsListView.UseCompatibleStateImageBehavior = false;
            AttackingClientsListView.View = View.Details;
            // 
            // AttackerCountry
            // 
            AttackerCountry.Text = "Country";
            // 
            // AttackerUserCol
            // 
            AttackerUserCol.Text = "User@Ip";
            AttackerUserCol.Width = 120;
            // 
            // AttackerTargetUrlCol
            // 
            AttackerTargetUrlCol.Text = "Target URL";
            AttackerTargetUrlCol.Width = 270;
            // 
            // AttackerIdCol
            // 
            AttackerIdCol.Text = "Client ID";
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.White;
            groupBox5.Controls.Add(AttackDurationLabel);
            groupBox5.Controls.Add(ClientCountLabel);
            groupBox5.Controls.Add(button8);
            groupBox5.Controls.Add(label2);
            groupBox5.Controls.Add(AttackDurationTrackbar);
            groupBox5.Controls.Add(ClientCountTrackBar);
            groupBox5.Controls.Add(label1);
            groupBox5.Controls.Add(CheckTargetServerBtm);
            groupBox5.Controls.Add(TargetPortEntry);
            groupBox5.Controls.Add(TargetDomainEntry);
            groupBox5.Location = new Point(6, 6);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(292, 372);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "New Attack";
            // 
            // AttackDurationLabel
            // 
            AttackDurationLabel.AutoSize = true;
            AttackDurationLabel.Location = new Point(116, 212);
            AttackDurationLabel.Name = "AttackDurationLabel";
            AttackDurationLabel.Size = new Size(65, 15);
            AttackDurationLabel.TabIndex = 10;
            AttackDurationLabel.Text = "30 seconds";
            AttackDurationLabel.Click += AttackDurationLabel_Click;
            // 
            // ClientCountLabel
            // 
            ClientCountLabel.AutoSize = true;
            ClientCountLabel.Location = new Point(94, 133);
            ClientCountLabel.Name = "ClientCountLabel";
            ClientCountLabel.Size = new Size(13, 15);
            ClientCountLabel.TabIndex = 9;
            ClientCountLabel.Text = "0";
            // 
            // button8
            // 
            button8.Location = new Point(6, 296);
            button8.Name = "button8";
            button8.Size = new Size(261, 37);
            button8.TabIndex = 8;
            button8.Text = "Start";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(8, 212);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 7;
            label2.Text = "Attack Duration :";
            // 
            // AttackDurationTrackbar
            // 
            AttackDurationTrackbar.BackColor = Color.White;
            AttackDurationTrackbar.Location = new Point(6, 245);
            AttackDurationTrackbar.Maximum = 3600;
            AttackDurationTrackbar.Minimum = 30;
            AttackDurationTrackbar.MinimumSize = new Size(1, 0);
            AttackDurationTrackbar.Name = "AttackDurationTrackbar";
            AttackDurationTrackbar.Size = new Size(263, 45);
            AttackDurationTrackbar.TabIndex = 6;
            AttackDurationTrackbar.TickFrequency = 15;
            AttackDurationTrackbar.Value = 30;
            AttackDurationTrackbar.Scroll += AttackDurationTrackbar_Scroll;
            // 
            // ClientCountTrackBar
            // 
            ClientCountTrackBar.BackColor = Color.White;
            ClientCountTrackBar.Location = new Point(8, 164);
            ClientCountTrackBar.Name = "ClientCountTrackBar";
            ClientCountTrackBar.Size = new Size(263, 45);
            ClientCountTrackBar.TabIndex = 5;
            ClientCountTrackBar.Scroll += ClientCountTrackBar_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 133);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 4;
            label1.Text = "Client count :";
            // 
            // CheckTargetServerBtm
            // 
            CheckTargetServerBtm.Location = new Point(8, 83);
            CheckTargetServerBtm.Name = "CheckTargetServerBtm";
            CheckTargetServerBtm.Size = new Size(263, 23);
            CheckTargetServerBtm.TabIndex = 3;
            CheckTargetServerBtm.Text = "Check";
            CheckTargetServerBtm.UseVisualStyleBackColor = true;
            CheckTargetServerBtm.Click += CheckTargetServerBtm_Click;
            // 
            // TargetPortEntry
            // 
            TargetPortEntry.Location = new Point(201, 52);
            TargetPortEntry.Name = "TargetPortEntry";
            TargetPortEntry.Size = new Size(70, 23);
            TargetPortEntry.TabIndex = 2;
            TargetPortEntry.Text = "80";
            // 
            // TargetDomainEntry
            // 
            TargetDomainEntry.Location = new Point(6, 52);
            TargetDomainEntry.Name = "TargetDomainEntry";
            TargetDomainEntry.Size = new Size(189, 23);
            TargetDomainEntry.TabIndex = 1;
            TargetDomainEntry.Text = "https://example-domain.com";
            // 
            // SecurityPanel
            // 
            SecurityPanel.Controls.Add(groupBox4);
            SecurityPanel.Controls.Add(groupBox3);
            SecurityPanel.Controls.Add(groupBox2);
            SecurityPanel.Controls.Add(groupBox1);
            SecurityPanel.Location = new Point(4, 24);
            SecurityPanel.Name = "SecurityPanel";
            SecurityPanel.Padding = new Padding(3);
            SecurityPanel.Size = new Size(776, 398);
            SecurityPanel.TabIndex = 1;
            SecurityPanel.Text = "Security";
            SecurityPanel.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(StartRecoveryBtn);
            groupBox4.Controls.Add(ClientsIdsCheckbox);
            groupBox4.Controls.Add(ClientAntivirusesCheckbox);
            groupBox4.Controls.Add(ClientSysinfosCheckbox);
            groupBox4.Controls.Add(ClientIpsAddrCheckbox);
            groupBox4.Location = new Point(458, 251);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(311, 135);
            groupBox4.TabIndex = 11;
            groupBox4.TabStop = false;
            groupBox4.Text = "Recovery";
            // 
            // StartRecoveryBtn
            // 
            StartRecoveryBtn.Location = new Point(28, 95);
            StartRecoveryBtn.Name = "StartRecoveryBtn";
            StartRecoveryBtn.Size = new Size(257, 25);
            StartRecoveryBtn.TabIndex = 4;
            StartRecoveryBtn.Text = "Start recovery";
            StartRecoveryBtn.UseVisualStyleBackColor = true;
            StartRecoveryBtn.Click += StartRecoveryBtn_Click;
            // 
            // ClientsIdsCheckbox
            // 
            ClientsIdsCheckbox.AutoSize = true;
            ClientsIdsCheckbox.Location = new Point(201, 61);
            ClientsIdsCheckbox.Name = "ClientsIdsCheckbox";
            ClientsIdsCheckbox.Size = new Size(42, 19);
            ClientsIdsCheckbox.TabIndex = 3;
            ClientsIdsCheckbox.Text = "IDs";
            ClientsIdsCheckbox.UseVisualStyleBackColor = true;
            // 
            // ClientAntivirusesCheckbox
            // 
            ClientAntivirusesCheckbox.AutoSize = true;
            ClientAntivirusesCheckbox.Location = new Point(201, 36);
            ClientAntivirusesCheckbox.Name = "ClientAntivirusesCheckbox";
            ClientAntivirusesCheckbox.Size = new Size(84, 19);
            ClientAntivirusesCheckbox.TabIndex = 2;
            ClientAntivirusesCheckbox.Text = "Antiviruses";
            ClientAntivirusesCheckbox.UseVisualStyleBackColor = true;
            // 
            // ClientSysinfosCheckbox
            // 
            ClientSysinfosCheckbox.AutoSize = true;
            ClientSysinfosCheckbox.Location = new Point(28, 61);
            ClientSysinfosCheckbox.Name = "ClientSysinfosCheckbox";
            ClientSysinfosCheckbox.Size = new Size(93, 19);
            ClientSysinfosCheckbox.TabIndex = 1;
            ClientSysinfosCheckbox.Text = "System infos";
            ClientSysinfosCheckbox.UseVisualStyleBackColor = true;
            // 
            // ClientIpsAddrCheckbox
            // 
            ClientIpsAddrCheckbox.AutoSize = true;
            ClientIpsAddrCheckbox.Location = new Point(29, 36);
            ClientIpsAddrCheckbox.Name = "ClientIpsAddrCheckbox";
            ClientIpsAddrCheckbox.Size = new Size(92, 19);
            ClientIpsAddrCheckbox.TabIndex = 0;
            ClientIpsAddrCheckbox.Text = "Ip Addresses";
            ClientIpsAddrCheckbox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button7);
            groupBox3.Controls.Add(button6);
            groupBox3.Location = new Point(250, 251);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(202, 135);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Dangerous Area";
            // 
            // button7
            // 
            button7.Location = new Point(26, 75);
            button7.Name = "button7";
            button7.Size = new Size(140, 33);
            button7.TabIndex = 1;
            button7.Text = "Kill ALL";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Location = new Point(26, 36);
            button6.Name = "button6";
            button6.Size = new Size(140, 33);
            button6.TabIndex = 0;
            button6.Text = "Kill + Uninstall ALL";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(ServerPortEntry);
            groupBox2.Location = new Point(16, 251);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(228, 135);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Network";
            // 
            // button5
            // 
            button5.Location = new Point(11, 75);
            button5.Name = "button5";
            button5.Size = new Size(204, 23);
            button5.TabIndex = 1;
            button5.Text = "Save and Restart";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // ServerPortEntry
            // 
            ServerPortEntry.Location = new Point(11, 46);
            ServerPortEntry.Name = "ServerPortEntry";
            ServerPortEntry.Size = new Size(204, 23);
            ServerPortEntry.TabIndex = 0;
            ServerPortEntry.Text = "Server Port";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(BlackListedUUIDsListbox);
            groupBox1.Controls.Add(BlacklistIpEntry);
            groupBox1.Controls.Add(BlacklistUuidEntry);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(BlacklistedIpsListbox);
            groupBox1.Location = new Point(16, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(753, 225);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Blacklist";
            // 
            // button4
            // 
            button4.Location = new Point(678, 183);
            button4.Name = "button4";
            button4.Size = new Size(59, 24);
            button4.TabIndex = 6;
            button4.Text = "Remove";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(393, 184);
            button3.Name = "button3";
            button3.Size = new Size(53, 23);
            button3.TabIndex = 7;
            button3.Text = "Add";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            button3.KeyDown += button3_KeyDown;
            // 
            // button1
            // 
            button1.Location = new Point(296, 183);
            button1.Name = "button1";
            button1.Size = new Size(59, 24);
            button1.TabIndex = 3;
            button1.Text = "Remove";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BlackListedUUIDsListbox
            // 
            BlackListedUUIDsListbox.FormattingEnabled = true;
            BlackListedUUIDsListbox.ItemHeight = 15;
            BlackListedUUIDsListbox.Location = new Point(393, 22);
            BlackListedUUIDsListbox.Name = "BlackListedUUIDsListbox";
            BlackListedUUIDsListbox.Size = new Size(344, 139);
            BlackListedUUIDsListbox.TabIndex = 0;
            // 
            // BlacklistIpEntry
            // 
            BlacklistIpEntry.Location = new Point(70, 183);
            BlacklistIpEntry.Name = "BlacklistIpEntry";
            BlacklistIpEntry.Size = new Size(220, 23);
            BlacklistIpEntry.TabIndex = 2;
            BlacklistIpEntry.Text = "Add/Remove IP Address to blacklist";
            BlacklistIpEntry.TextChanged += BlacklistIpEntry_TextChanged;
            BlacklistIpEntry.Enter += BlacklistIpEntry_Enter;
            BlacklistIpEntry.KeyDown += BlacklistIpEntry_KeyDown;
            // 
            // BlacklistUuidEntry
            // 
            BlacklistUuidEntry.Location = new Point(452, 184);
            BlacklistUuidEntry.Name = "BlacklistUuidEntry";
            BlacklistUuidEntry.Size = new Size(220, 23);
            BlacklistUuidEntry.TabIndex = 5;
            BlacklistUuidEntry.Text = "Add/Remove UUID to blacklist";
            BlacklistUuidEntry.Enter += BlacklistUuidEntry_Enter;
            // 
            // button2
            // 
            button2.Location = new Point(11, 183);
            button2.Name = "button2";
            button2.Size = new Size(53, 23);
            button2.TabIndex = 4;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // BlacklistedIpsListbox
            // 
            BlacklistedIpsListbox.FormattingEnabled = true;
            BlacklistedIpsListbox.ItemHeight = 15;
            BlacklistedIpsListbox.Location = new Point(11, 22);
            BlacklistedIpsListbox.Name = "BlacklistedIpsListbox";
            BlacklistedIpsListbox.Size = new Size(344, 139);
            BlacklistedIpsListbox.TabIndex = 1;
            // 
            // BuilderPanel
            // 
            BuilderPanel.Controls.Add(groupBox9);
            BuilderPanel.Controls.Add(BuildBtn);
            BuilderPanel.Controls.Add(groupBox8);
            BuilderPanel.Controls.Add(groupBox7);
            BuilderPanel.Location = new Point(4, 24);
            BuilderPanel.Name = "BuilderPanel";
            BuilderPanel.Padding = new Padding(3);
            BuilderPanel.Size = new Size(776, 398);
            BuilderPanel.TabIndex = 2;
            BuilderPanel.Text = "Builder";
            BuilderPanel.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(BuilderPortEntry);
            groupBox9.Location = new Point(21, 283);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(345, 109);
            groupBox9.TabIndex = 4;
            groupBox9.TabStop = false;
            groupBox9.Text = "Port";
            // 
            // BuilderPortEntry
            // 
            BuilderPortEntry.Location = new Point(6, 46);
            BuilderPortEntry.Name = "BuilderPortEntry";
            BuilderPortEntry.Size = new Size(320, 23);
            BuilderPortEntry.TabIndex = 0;
            BuilderPortEntry.Text = "Port here";
            BuilderPortEntry.TextChanged += BuilderPortEntry_TextChanged;
            BuilderPortEntry.Enter += textBox2_Enter;
            // 
            // BuildBtn
            // 
            BuildBtn.Location = new Point(372, 338);
            BuildBtn.Name = "BuildBtn";
            BuildBtn.Size = new Size(388, 54);
            BuildBtn.TabIndex = 2;
            BuildBtn.Text = "Build";
            BuildBtn.UseVisualStyleBackColor = true;
            BuildBtn.Click += button11_Click;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(BuilderMutexEntry);
            groupBox8.Controls.Add(label4);
            groupBox8.Controls.Add(BuilderFileNameEntry);
            groupBox8.Controls.Add(TimeBetweenReconnnectsEntry);
            groupBox8.Controls.Add(label3);
            groupBox8.Controls.Add(SleepTimeEntry);
            groupBox8.Controls.Add(BuilderStartupScope);
            groupBox8.Controls.Add(BuilderSleepCbx);
            groupBox8.Controls.Add(BuilderAntiVmCbx);
            groupBox8.Controls.Add(BuilderStartupCbx);
            groupBox8.Location = new Point(372, 20);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(388, 312);
            groupBox8.TabIndex = 1;
            groupBox8.TabStop = false;
            groupBox8.Text = "File settings";
            // 
            // BuilderMutexEntry
            // 
            BuilderMutexEntry.Location = new Point(193, 109);
            BuilderMutexEntry.Name = "BuilderMutexEntry";
            BuilderMutexEntry.Size = new Size(140, 23);
            BuilderMutexEntry.TabIndex = 10;
            BuilderMutexEntry.Text = "<CsMutex>";
            BuilderMutexEntry.Enter += textBox2_Enter_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 242);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 9;
            label4.Text = "Build file name";
            // 
            // BuilderFileNameEntry
            // 
            BuilderFileNameEntry.Location = new Point(25, 263);
            BuilderFileNameEntry.Name = "BuilderFileNameEntry";
            BuilderFileNameEntry.Size = new Size(328, 23);
            BuilderFileNameEntry.TabIndex = 8;
            BuilderFileNameEntry.Text = "CsClient.exe";
            // 
            // TimeBetweenReconnnectsEntry
            // 
            TimeBetweenReconnnectsEntry.Location = new Point(26, 194);
            TimeBetweenReconnnectsEntry.Name = "TimeBetweenReconnnectsEntry";
            TimeBetweenReconnnectsEntry.Size = new Size(120, 23);
            TimeBetweenReconnnectsEntry.TabIndex = 7;
            TimeBetweenReconnnectsEntry.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 160);
            label3.Name = "label3";
            label3.Size = new Size(247, 15);
            label3.TabIndex = 6;
            label3.Text = "Time in seconds between reconnect attempts";
            // 
            // SleepTimeEntry
            // 
            SleepTimeEntry.Enabled = false;
            SleepTimeEntry.Location = new Point(193, 59);
            SleepTimeEntry.Name = "SleepTimeEntry";
            SleepTimeEntry.Size = new Size(120, 23);
            SleepTimeEntry.TabIndex = 5;
            SleepTimeEntry.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // BuilderStartupScope
            // 
            BuilderStartupScope.DropDownStyle = ComboBoxStyle.DropDownList;
            BuilderStartupScope.DropDownWidth = 150;
            BuilderStartupScope.Enabled = false;
            BuilderStartupScope.FormattingEnabled = true;
            BuilderStartupScope.Items.AddRange(new object[] { "Machine Scope (Admin)", "User Scope" });
            BuilderStartupScope.Location = new Point(25, 58);
            BuilderStartupScope.Name = "BuilderStartupScope";
            BuilderStartupScope.Size = new Size(121, 23);
            BuilderStartupScope.TabIndex = 4;
            // 
            // BuilderSleepCbx
            // 
            BuilderSleepCbx.AutoSize = true;
            BuilderSleepCbx.Location = new Point(193, 33);
            BuilderSleepCbx.Name = "BuilderSleepCbx";
            BuilderSleepCbx.Size = new Size(140, 19);
            BuilderSleepCbx.TabIndex = 2;
            BuilderSleepCbx.Text = "Sleep time in seconds";
            BuilderSleepCbx.UseVisualStyleBackColor = true;
            BuilderSleepCbx.CheckedChanged += BuilderSleepCbx_CheckedChanged;
            // 
            // BuilderAntiVmCbx
            // 
            BuilderAntiVmCbx.AutoSize = true;
            BuilderAntiVmCbx.Location = new Point(25, 113);
            BuilderAntiVmCbx.Name = "BuilderAntiVmCbx";
            BuilderAntiVmCbx.Size = new Size(109, 19);
            BuilderAntiVmCbx.TabIndex = 1;
            BuilderAntiVmCbx.Text = "Anti VM/Debug";
            BuilderAntiVmCbx.UseVisualStyleBackColor = true;
            // 
            // BuilderStartupCbx
            // 
            BuilderStartupCbx.AutoSize = true;
            BuilderStartupCbx.Location = new Point(25, 33);
            BuilderStartupCbx.Name = "BuilderStartupCbx";
            BuilderStartupCbx.Size = new Size(102, 19);
            BuilderStartupCbx.TabIndex = 0;
            BuilderStartupCbx.Text = "Add to startup";
            BuilderStartupCbx.UseVisualStyleBackColor = true;
            BuilderStartupCbx.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(button10);
            groupBox7.Controls.Add(button9);
            groupBox7.Controls.Add(BuilderC2Entry);
            groupBox7.Controls.Add(C2sListbox);
            groupBox7.Location = new Point(21, 20);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(345, 257);
            groupBox7.TabIndex = 0;
            groupBox7.TabStop = false;
            groupBox7.Text = "Network settings";
            // 
            // button10
            // 
            button10.Location = new Point(268, 222);
            button10.Name = "button10";
            button10.Size = new Size(71, 23);
            button10.TabIndex = 3;
            button10.Text = "Remove";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button9
            // 
            button9.Location = new Point(6, 222);
            button9.Name = "button9";
            button9.Size = new Size(47, 23);
            button9.TabIndex = 2;
            button9.Text = "Add";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // BuilderC2Entry
            // 
            BuilderC2Entry.Location = new Point(59, 222);
            BuilderC2Entry.Name = "BuilderC2Entry";
            BuilderC2Entry.Size = new Size(203, 23);
            BuilderC2Entry.TabIndex = 1;
            BuilderC2Entry.Text = "Add/Remove C2 here...";
            BuilderC2Entry.TextChanged += textBox1_TextChanged;
            BuilderC2Entry.Enter += textBox1_Enter;
            // 
            // C2sListbox
            // 
            C2sListbox.FormattingEnabled = true;
            C2sListbox.ItemHeight = 15;
            C2sListbox.Location = new Point(6, 22);
            C2sListbox.Name = "C2sListbox";
            C2sListbox.Size = new Size(333, 184);
            C2sListbox.TabIndex = 0;
            // 
            // LogsPanel
            // 
            LogsPanel.Controls.Add(LogsListView);
            LogsPanel.Location = new Point(4, 24);
            LogsPanel.Name = "LogsPanel";
            LogsPanel.Padding = new Padding(3);
            LogsPanel.Size = new Size(776, 398);
            LogsPanel.TabIndex = 3;
            LogsPanel.Text = "Logs";
            LogsPanel.UseVisualStyleBackColor = true;
            // 
            // LogsListView
            // 
            LogsListView.Columns.AddRange(new ColumnHeader[] { LogsDateCol, LogTypeCol, LogMessageCol });
            LogsListView.FullRowSelect = true;
            LogsListView.GridLines = true;
            LogsListView.Location = new Point(6, 6);
            LogsListView.Name = "LogsListView";
            LogsListView.RightToLeftLayout = true;
            LogsListView.Size = new Size(764, 389);
            LogsListView.TabIndex = 0;
            LogsListView.UseCompatibleStateImageBehavior = false;
            LogsListView.View = View.Details;
            LogsListView.MouseClick += LogsListView_MouseClick;
            // 
            // LogsDateCol
            // 
            LogsDateCol.Text = "Date";
            LogsDateCol.Width = 150;
            // 
            // LogTypeCol
            // 
            LogTypeCol.Text = "Type";
            LogTypeCol.Width = 100;
            // 
            // LogMessageCol
            // 
            LogMessageCol.Text = "Message";
            LogMessageCol.Width = 510;
            // 
            // LogsMenuStrip
            // 
            LogsMenuStrip.Items.AddRange(new ToolStripItem[] { copyToolStripMenuItem, clearToolStripMenuItem });
            LogsMenuStrip.Name = "LogsMenuStrip";
            LogsMenuStrip.Size = new Size(103, 48);
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = (Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(102, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Image = (Image)resources.GetObject("clearToolStripMenuItem.Image");
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(102, 22);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // MainWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(808, 450);
            Controls.Add(MainTabControl);
            Cursor = Cursors.Cross;
            ForeColor = Color.Black;
            Name = "MainWin";
            Text = "CS Botnet";
            FormClosing += Form1_FormClosing;
            MainTabControl.ResumeLayout(false);
            MainPanel.ResumeLayout(false);
            ClientOptionsCtxMenu.ResumeLayout(false);
            AttackPanel.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AttackDurationTrackbar).EndInit();
            ((System.ComponentModel.ISupportInitialize)ClientCountTrackBar).EndInit();
            SecurityPanel.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            BuilderPanel.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TimeBetweenReconnnectsEntry).EndInit();
            ((System.ComponentModel.ISupportInitialize)SleepTimeEntry).EndInit();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            LogsPanel.ResumeLayout(false);
            LogsMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl MainTabControl;
        private TabPage MainPanel;
        private TabPage SecurityPanel;
        private TabPage BuilderPanel;
        private ListView DashboardListView;
        private ColumnHeader ClientCountryCol;
        private ColumnHeader ClientIpCol;
        private ColumnHeader ClientUsernameCol;
        private ColumnHeader ClientMachineNameCol;
        private ColumnHeader ClientIdCol;
        private ColumnHeader ClientUuidCol;
        private ColumnHeader ClientsAntivirusesCol;
        private Button button3;
        private Button button4;
        private TextBox BlacklistUuidEntry;
        private Button button2;
        private Button button1;
        private TextBox BlacklistIpEntry;
        private ListBox BlacklistedIpsListbox;
        private ListBox BlackListedUUIDsListbox;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button button6;
        private Button button5;
        private TextBox ServerPortEntry;
        private GroupBox groupBox4;
        private CheckBox ClientAntivirusesCheckbox;
        private CheckBox ClientSysinfosCheckbox;
        private CheckBox ClientIpsAddrCheckbox;
        private Button button7;
        private Button StartRecoveryBtn;
        private CheckBox ClientsIdsCheckbox;
        private TabPage LogsPanel;
        private ListView LogsListView;
        private ColumnHeader LogsDateCol;
        private ColumnHeader LogTypeCol;
        private ColumnHeader LogMessageCol;
        private TabPage AttackPanel;
        private GroupBox groupBox5;
        private Label label1;
        private Button CheckTargetServerBtm;
        private TextBox TargetPortEntry;
        private TextBox TargetDomainEntry;
        private TrackBar ClientCountTrackBar;
        private Label label2;
        private Button button8;
        private ColumnHeader ClientOsCol;
        private ColumnHeader ClientGpuCol;
        private ColumnHeader ClientCpuCol;
        private ColumnHeader ClientRamCol;
        private ContextMenuStrip LogsMenuStrip;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private GroupBox groupBox6;
        private ListView AttackingClientsListView;
        private ColumnHeader AttackerCountry;
        private ColumnHeader AttackerUserCol;
        private ColumnHeader AttackerTargetUrlCol;
        private Label ClientCountLabel;
        private Label AttackDurationLabel;
        private TrackBar AttackDurationTrackbar;
        private ColumnHeader AttackerIdCol;
        private ContextMenuStrip ClientOptionsCtxMenu;
        private ToolStripMenuItem cleintInformationsToolStripMenuItem;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private ToolStripMenuItem restartToolStripMenuItem;
        private ToolStripMenuItem runFileToolStripMenuItem;
        private GroupBox groupBox8;
        private GroupBox groupBox7;
        private Button button9;
        private TextBox BuilderC2Entry;
        private ListBox C2sListbox;
        private Button BuildBtn;
        private Button button10;
        private CheckBox BuilderSleepCbx;
        private CheckBox BuilderAntiVmCbx;
        private CheckBox BuilderStartupCbx;
        private GroupBox groupBox9;
        private TextBox BuilderPortEntry;
        private ComboBox BuilderStartupScope;
        private NumericUpDown SleepTimeEntry;
        private Label label4;
        private TextBox BuilderFileNameEntry;
        private NumericUpDown TimeBetweenReconnnectsEntry;
        private Label label3;
        private TextBox BuilderMutexEntry;
    }
}
