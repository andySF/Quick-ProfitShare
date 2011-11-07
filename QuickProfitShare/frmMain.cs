using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;

namespace QuickProfitShare
{
    public partial class frmMain : Form
    {
        IntPtr nextClipboardViewer;
        Regex emag;
        String curLink;
        public frmMain()
        {
            InitializeComponent();
            string emagPattern = @"(http:\/\/(www\.)?emag\.ro\/)([a-zA-Z0-9\/\-\–_\=\.\?\&\;\/\#\~\+]*)";
            emag = new Regex(emagPattern);
            nextClipboardViewer = (IntPtr)API.SetClipboardViewer((int)this.Handle);
        }

        protected override void SetVisibleCore(bool value)
        {
            value = false;
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
                        notifyIconQuickProfitShare.BalloonTipIcon = ToolTipIcon.Info;
                        notifyIconQuickProfitShare.BalloonTipTitle = "Quick ProfitShare";
                        notifyIconQuickProfitShare.BalloonTipText = "Generez Link-ul...";
                        notifyIconQuickProfitShare.ShowBalloonTip(100);
                        ShowNotification(link,GetProfitshareLink(link));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        void ShowNotification(string originalLink, string link)
        {
            curLink = link;
            notifyIconQuickProfitShare.BalloonTipIcon = ToolTipIcon.Info;
            notifyIconQuickProfitShare.BalloonTipTitle = GetProfitshareHeader(originalLink);
            notifyIconQuickProfitShare.BalloonTipText = "Click aici pentru a copia în clipboard link-ul:\n"+curLink;
            notifyIconQuickProfitShare.ShowBalloonTip(100);

        }

        string GetProfitshareLink(string link)
        {
            Uri u = new Uri(link);
            string ad_client=QuickProfitShare.Properties.Settings.Default.ad_client;
            string linkAbsolutePath = u.AbsolutePath.Remove(0,2);
            string profitShare = @"http://profitshare.emag.ro/click.php?ad_client=" + ad_client + "&redirect=" + linkAbsolutePath;
            return ShortUrl.WithGoogl(profitShare);
            
        }

        string GetProfitshareHeader(string link)
        {
            WebClient wc=new WebClient();
            string emagPage = wc.DownloadString(link);
            Regex header = new Regex("<title>*.*</title>");
            Match m = header.Match(emagPage);

            if (m.Success)
            {
                var value = m.Value.Replace("<title>", String.Empty);
                value = value.Replace("- eMAG.ro </title>", String.Empty);
                return value;
            }
            return String.Empty;
           
        }

        private void notifyIconQuickProfitShare_BalloonTipClicked(object sender, EventArgs e)
        {
            Clipboard.SetText(curLink);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            textBoxAdClient.Text = QuickProfitShare.Properties.Settings.Default.ad_client;
            checkBoxAutoStart.Checked = QuickProfitShare.Properties.Settings.Default.autoStart;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            QuickProfitShare.Properties.Settings.Default.ad_client = textBoxAdClient.Text;
            QuickProfitShare.Properties.Settings.Default.autoStart = checkBoxAutoStart.Checked;
            QuickProfitShare.Properties.Settings.Default.Save();
        }
    }
}
