namespace QuickProfitShare
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

      

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.notifyIconQuickProfitShare = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MonitorizeazaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxAdClient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.optiuniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UltimulLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.contextMenuStripRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconQuickProfitShare
            // 
            this.notifyIconQuickProfitShare.ContextMenuStrip = this.contextMenuStripRightClick;
            this.notifyIconQuickProfitShare.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconQuickProfitShare.Icon")));
            this.notifyIconQuickProfitShare.Text = "Quick ProfitShare";
            this.notifyIconQuickProfitShare.Visible = true;
            this.notifyIconQuickProfitShare.BalloonTipClicked += new System.EventHandler(this.notifyIconQuickProfitShare_BalloonTipClicked);
            this.notifyIconQuickProfitShare.DoubleClick += new System.EventHandler(this.notifyIconQuickProfitShare_DoubleClick);
            // 
            // contextMenuStripRightClick
            // 
            this.contextMenuStripRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optiuniToolStripMenuItem,
            this.MonitorizeazaToolStripMenuItem,
            this.UltimulLinkToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStripRightClick.Name = "contextMenuStripRightClick";
            this.contextMenuStripRightClick.Size = new System.Drawing.Size(192, 92);
            // 
            // MonitorizeazaToolStripMenuItem
            // 
            this.MonitorizeazaToolStripMenuItem.Checked = true;
            this.MonitorizeazaToolStripMenuItem.CheckOnClick = true;
            this.MonitorizeazaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MonitorizeazaToolStripMenuItem.Name = "MonitorizeazaToolStripMenuItem";
            this.MonitorizeazaToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.MonitorizeazaToolStripMenuItem.Text = "Oprește Monitorizarea";
            this.MonitorizeazaToolStripMenuItem.Click += new System.EventHandler(this.MonitorizeazaToolStripMenuItem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(262, 87);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Salvează";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(343, 87);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Renunță";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxAdClient
            // 
            this.textBoxAdClient.Location = new System.Drawing.Point(105, 12);
            this.textBoxAdClient.Name = "textBoxAdClient";
            this.textBoxAdClient.Size = new System.Drawing.Size(313, 20);
            this.textBoxAdClient.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID ProfitShare:";
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.AutoSize = true;
            this.checkBoxAutoStart.Location = new System.Drawing.Point(105, 48);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(130, 17);
            this.checkBoxAutoStart.TabIndex = 3;
            this.checkBoxAutoStart.Text = "Pornește cu Windows";
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            // 
            // optiuniToolStripMenuItem
            // 
            this.optiuniToolStripMenuItem.Image = global::QuickProfitShare.Properties.Resources.optiuni;
            this.optiuniToolStripMenuItem.Name = "optiuniToolStripMenuItem";
            this.optiuniToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.optiuniToolStripMenuItem.Text = "Opțiuni";
            this.optiuniToolStripMenuItem.Click += new System.EventHandler(this.optiuniToolStripMenuItem_Click);
            // 
            // UltimulLinkToolStripMenuItem
            // 
            this.UltimulLinkToolStripMenuItem.Image = global::QuickProfitShare.Properties.Resources.link;
            this.UltimulLinkToolStripMenuItem.Name = "UltimulLinkToolStripMenuItem";
            this.UltimulLinkToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.UltimulLinkToolStripMenuItem.Text = "Copiează ultimul Link";
            this.UltimulLinkToolStripMenuItem.Click += new System.EventHandler(this.UltimulLinkToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::QuickProfitShare.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exitToolStripMenuItem.Text = "EXIT";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 100);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(101, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.olteteanu.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 122);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.checkBoxAutoStart);
            this.Controls.Add(this.textBoxAdClient);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quick-ProfitShare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.contextMenuStripRightClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconQuickProfitShare;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxAdClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxAutoStart;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRightClick;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optiuniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MonitorizeazaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UltimulLinkToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

