using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace QuickProfitShare
{
    public partial class frmMain : Form
    {

        #region declarations
        
        IntPtr nextClipboardViewer; //mumu mimi mami mo
        Regex emag; // emag regex
        String lastLink=String.Empty; // last link genereated
        bool isFormVisible = false; // used for SetVisibleCore(). a more elegant way to hide the form
        bool exitApp = false; // application should exit on close
        bool monitor = true;

        Thread checkUpdateThread; //thread used for updates

        #endregion declarations

        public frmMain()
        {
            InitializeComponent();
            LoadSettings();

            this.Text = "Quick-ProfitShare v:" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //pattern used for catching links in clipboard<div class="breadcrumbs-holder">
            string emagPattern = @"(http:\/\/(www\.)?emag\.ro\/)([a-zA-Z0-9\/\-\–_\=\.\?\&\;\/\#\~\+]*)";
            emag = new Regex(emagPattern);
            
            nextClipboardViewer = (IntPtr)API.SetClipboardViewer((int)this.Handle);

            //loadsettings
            LoadSettings();

            //check for updates
            checkUpdateThread = new System.Threading.Thread(CheckForUpdate);
            checkUpdateThread.SetApartmentState(System.Threading.ApartmentState.STA);
            checkUpdateThread.Start();
            CheckAdd_Client();
        }

        private void CheckAdd_Client()
        {
            if (QuickProfitShare.Properties.Settings.Default.ad_client == String.Empty)
            {
                monitor = false;
                LoadSettings();
                isFormVisible = true;
                this.Show();
            }
        }

        private void CheckForUpdate()
        {
            if (CheckUpdate.IsUpdateAvailable())
            {
                if (MessageBox.Show("O nouă versiune a lui Quick ProfitShare este disponibilă.\nVrei să descarci ultima versiune?", "O nouă versiune este disponibilă", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    Process.Start(CheckUpdate.GetUrlForDownload());
            }
        }

        #region override methods
        protected override void SetVisibleCore(bool value)
        {
            value = isFormVisible;
            base.SetVisibleCore(value);
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
           
                // defined in winuser.h
                const int WM_DRAWCLIPBOARD = 0x308;
                const int WM_CHANGECBCHAIN = 0x030D;

                switch (m.Msg)
                {
                    case WM_DRAWCLIPBOARD:
                        CatchClipboardData();
                        API.SendMessage(nextClipboardViewer, m.Msg, m.WParam,
                                    m.LParam);
                        break;

                    case WM_CHANGECBCHAIN:
                        if (m.WParam == nextClipboardViewer)
                            nextClipboardViewer = m.LParam;
                        else
                            API.SendMessage(nextClipboardViewer, m.Msg, m.WParam,
                                        m.LParam);
                        break;

                    default:
                        base.WndProc(ref m);
                        break;
                }
            
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            API.ChangeClipboardChain(this.Handle, nextClipboardViewer);
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        //http://www.codeguru.com/csharp/.net/net_general/tipstricks/article.php/c7315/
        //regex produse emag:
        // (http:\/\/(www\.)?emag\.ro\/)([a-zA-Z0-9\/\-\–\_\=\.\?\&\;\/\#\~\+]*)
        //regex profitshare:
        // (http:\/\/profitshare.emag\.ro\/)([a-zA-Z0-9\/\-\–\_\=\.\?\&\;\/\#\~\+]*)

        #endregion override methods

        void CatchClipboardData()
        {
            try
            {

                IDataObject iData = new DataObject();
                iData = Clipboard.GetDataObject();
                if (iData != null)
                {
                    String link = iData.GetData(DataFormats.Text).ToString();
                    if (emag.IsMatch(link))
                    {
                        PrepareLink(link);
                    }
                }
            }
            catch //(Exception e)
            {
                //catching all errors here
                //no internet connection. remote host not found...
                //invalid Link...or text with multiple links

                //Console.WriteLine(e.Message.ToString());
            }
        }

        void PrepareLink(string link)
        {
            if (monitor)
            {
                ProfitshareItem item = new ProfitshareItem(link);
                notifyIconQuickProfitShare.BalloonTipIcon = ToolTipIcon.Info;


                String body = item.Title;
                String price = item.Price;
                lastLink = item.ShortLink;
                if (price != String.Empty)
                {
                    body += "\nPreț: " + item.Price + " Lei";
                    body += "\nProfit: " + item.Profit + " Lei";
                }
                body += "\n\nClick aici pentru a copia link-ul în clipboard";
                notifyIconQuickProfitShare.BalloonTipTitle = lastLink;
                notifyIconQuickProfitShare.BalloonTipText = body;
                notifyIconQuickProfitShare.ShowBalloonTip(100);
            }
        }


        private void LoadSettings()
        {
            textBoxAdClient.Text = QuickProfitShare.Properties.Settings.Default.ad_client;
            checkBoxAutoStart.Checked = QuickProfitShare.Properties.Settings.Default.autoStart;
            lastLink = QuickProfitShare.Properties.Settings.Default.lastLink;

            if (QuickProfitShare.Properties.Settings.Default.autoStart)
            {
                //daca nu este in registrii
                if (AutoStarter.IsAutoStartEnabled == false)
                {
                    //o adugam acum
                    AutoStarter.SetAutoStart();
                }
                //daca  este in registrii verificam daca calea catre exe exista
                if (AutoStarter.IsAutoStartEnabled == true)
                {
                    //daca exista e totul ok 

                    //daca nu exista o bagam din nou
                    if (!File.Exists(AutoStarter.Read("QuickProfitShare")))
                        AutoStarter.SetAutoStart();
                }
            }
            if (QuickProfitShare.Properties.Settings.Default.autoStart == false)
            {
                if (AutoStarter.IsAutoStartEnabled == true)
                {
                    AutoStarter.UnSetAutoStart();
                }
            }
        }

        #region general ui methods
        private void notifyIconQuickProfitShare_BalloonTipClicked(object sender, EventArgs e)
        {
            try
            {
                if (lastLink != string.Empty)
                    Clipboard.SetText(lastLink);
                else
                    MessageBox.Show("Nu există nici un link în memorie", "Eroare Quick-ProfitShare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare Quick-ProfitShare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBoxAdClient.Text == String.Empty)
            {
                monitor = false;
                MessageBox.Show("Trebuie să completezi ID-ul, altfel aplicația nu va funcționa.\nUn ID incorect va duce la generarea greșită a link-urilor\nRenunță dacă nu vrei să continui!", "Lipsă date, Quick-ProfitShare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                monitor = true;
                QuickProfitShare.Properties.Settings.Default.ad_client = textBoxAdClient.Text;
                QuickProfitShare.Properties.Settings.Default.autoStart = checkBoxAutoStart.Checked;
                QuickProfitShare.Properties.Settings.Default.Save();

                isFormVisible = false;
                this.Hide();
            }
        }
        
        private void notifyIconQuickProfitShare_DoubleClick(object sender, EventArgs e)
        {
            LoadSettings();
            isFormVisible = true;
            this.Show();
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (QuickProfitShare.Properties.Settings.Default.ad_client == String.Empty)
            {
                MessageBox.Show("Trebuie să completezi ID-ul, altfel aplicația nu va funcționa.\nUn ID incorect va duce la generarea greșită a link-urilor\n", "Lipsă date, Quick-ProfitShare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                monitor = false;
            }
            isFormVisible = false;
            this.Hide();
        }
        
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitApp)
            {
                if (QuickProfitShare.Properties.Settings.Default.ad_client == String.Empty)
                {
                    MessageBox.Show("Trebuie să completezi ID-ul, altfel aplicația nu va funcționa.\nUn ID incorect va duce la generarea greșită a link-urilor\n", "Lipsă date, Quick-ProfitShare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    monitor = false;
                }
                e.Cancel = true;
                isFormVisible = false;
                this.Hide();
            }
           
        }
        #region context menu methods

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuickProfitShare.Properties.Settings.Default.lastLink = lastLink;
            QuickProfitShare.Properties.Settings.Default.Save();

            exitApp = true;
            Application.Exit();
        }
        private void optiuniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSettings();
            isFormVisible = true;
            this.Show();
        }
        private void UltimulLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(lastLink!=string.Empty)
                    Clipboard.SetText(lastLink);
                else
                    MessageBox.Show("Nu există nici un link în memorie", "Eroare Quick-ProfitShare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare Quick-ProfitShare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MonitorizeazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MonitorizeazaToolStripMenuItem.Checked)
            {
                MonitorizeazaToolStripMenuItem.Text = "Oprește Monitorizarea";
                monitor = true;
            }
            else
            {
                MonitorizeazaToolStripMenuItem.Text = "Monitorizeaza";

                monitor = false;
            }
        }

        #endregion context menu methods

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.olteteanu.com");
        }

        #endregion general ui methods

       
      


    }
}
