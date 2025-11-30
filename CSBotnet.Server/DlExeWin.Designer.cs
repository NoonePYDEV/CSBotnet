namespace CSBotnet.Server
{
    partial class DlExeWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FileUrlEntry = new TextBox();
            FileNameEntry = new TextBox();
            FileExtensionCombobox = new ComboBox();
            ExecuteBtn = new Button();
            FileArgsEntry = new TextBox();
            FileExecutionModeCombobox = new ComboBox();
            SuspendLayout();
            // 
            // FileUrlEntry
            // 
            FileUrlEntry.Location = new Point(25, 19);
            FileUrlEntry.Name = "FileUrlEntry";
            FileUrlEntry.Size = new Size(313, 23);
            FileUrlEntry.TabIndex = 0;
            FileUrlEntry.Text = "https://example.com/files/MyFile.exe";
            // 
            // FileNameEntry
            // 
            FileNameEntry.Location = new Point(25, 60);
            FileNameEntry.Name = "FileNameEntry";
            FileNameEntry.Size = new Size(200, 23);
            FileNameEntry.TabIndex = 1;
            FileNameEntry.Text = "MyFileName";
            // 
            // FileExtensionCombobox
            // 
            FileExtensionCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            FileExtensionCombobox.FormattingEnabled = true;
            FileExtensionCombobox.Items.AddRange(new object[] { ".exe", ".bat", ".cmd", ".ps", ".vbs", ".msi", ".lnk", ".reg", ".scr" });
            FileExtensionCombobox.Location = new Point(231, 60);
            FileExtensionCombobox.Name = "FileExtensionCombobox";
            FileExtensionCombobox.Size = new Size(107, 23);
            FileExtensionCombobox.TabIndex = 2;
            // 
            // ExecuteBtn
            // 
            ExecuteBtn.Location = new Point(25, 177);
            ExecuteBtn.Name = "ExecuteBtn";
            ExecuteBtn.Size = new Size(313, 39);
            ExecuteBtn.TabIndex = 3;
            ExecuteBtn.Text = "Execute";
            ExecuteBtn.UseVisualStyleBackColor = true;
            ExecuteBtn.Click += button1_Click;
            // 
            // FileArgsEntry
            // 
            FileArgsEntry.Location = new Point(25, 99);
            FileArgsEntry.Name = "FileArgsEntry";
            FileArgsEntry.Size = new Size(312, 23);
            FileArgsEntry.TabIndex = 4;
            FileArgsEntry.Text = "--arg-example --leave-blank-for-no-args";
            // 
            // FileExecutionModeCombobox
            // 
            FileExecutionModeCombobox.FormattingEnabled = true;
            FileExecutionModeCombobox.Items.AddRange(new object[] { "Run as Administrator (UAC)", "Run as User" });
            FileExecutionModeCombobox.Location = new Point(25, 141);
            FileExecutionModeCombobox.Name = "FileExecutionModeCombobox";
            FileExecutionModeCombobox.Size = new Size(312, 23);
            FileExecutionModeCombobox.TabIndex = 5;
            // 
            // DlExeWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 228);
            Controls.Add(FileExecutionModeCombobox);
            Controls.Add(FileArgsEntry);
            Controls.Add(ExecuteBtn);
            Controls.Add(FileExtensionCombobox);
            Controls.Add(FileNameEntry);
            Controls.Add(FileUrlEntry);
            Name = "DlExeWin";
            Text = "Download & Run";
            Load += DlExeWin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox FileUrlEntry;
        private TextBox FileNameEntry;
        private ComboBox FileExtensionCombobox;
        private Button ExecuteBtn;
        private TextBox FileArgsEntry;
        private ComboBox FileExecutionModeCombobox;
    }
}