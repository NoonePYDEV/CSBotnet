namespace CSBotnet.Server
{
    partial class ClientInfosWin
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
            ClientInfosListView = new ListView();
            NameCol = new ColumnHeader();
            ValueCol = new ColumnHeader();
            SuspendLayout();
            // 
            // ClientInfosListView
            // 
            ClientInfosListView.Columns.AddRange(new ColumnHeader[] { NameCol, ValueCol });
            ClientInfosListView.FullRowSelect = true;
            ClientInfosListView.GridLines = true;
            ClientInfosListView.Location = new Point(12, 12);
            ClientInfosListView.Name = "ClientInfosListView";
            ClientInfosListView.Size = new Size(406, 385);
            ClientInfosListView.TabIndex = 0;
            ClientInfosListView.UseCompatibleStateImageBehavior = false;
            ClientInfosListView.View = View.Details;
            // 
            // NameCol
            // 
            NameCol.Text = "Name";
            NameCol.Width = 150;
            // 
            // ValueCol
            // 
            ValueCol.Text = "Value";
            ValueCol.Width = 255;
            // 
            // ClientInfosWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 409);
            Controls.Add(ClientInfosListView);
            MaximumSize = new Size(446, 448);
            MinimumSize = new Size(446, 448);
            Name = "ClientInfosWin";
            Text = "Client's Informations";
            ResumeLayout(false);
        }

        #endregion
        private ColumnHeader NameCol;
        private ColumnHeader ValueCol;
        public ListView ClientInfosListView;
    }
}