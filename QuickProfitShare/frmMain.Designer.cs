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
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxAdClient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // notifyIconQuickProfitShare
            // 
            this.notifyIconQuickProfitShare.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconQuickProfitShare.Icon")));
            this.notifyIconQuickProfitShare.Text = "Quick ProfitShare";
            this.notifyIconQuickProfitShare.Visible = true;
            this.notifyIconQuickProfitShare.BalloonTipClicked += new System.EventHandler(this.notifyIconQuickProfitShare_BalloonTipClicked);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(343, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Renunță";
            this.button1.UseVisualStyleBackColor = true;
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 122);
            this.Controls.Add(this.checkBoxAutoStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAdClient);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.Text = "Quick ProfitShare";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconQuickProfitShare;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxAdClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxAutoStart;
    }
}

