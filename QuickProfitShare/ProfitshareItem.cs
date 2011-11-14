using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using System.Xml;
using System.IO;
namespace QuickProfitShare
{
    class ProfitshareItem
    {

        private String document;
        private String link;
        public ProfitshareItem(String lnk)
        {
            link = lnk;
            WebClient wc = new WebClient();
            document = wc.DownloadString(link);
        }


        private string GetProfitshareLink(string link)
        {
            Uri u = new Uri(link);
            string ad_client = QuickProfitShare.Properties.Settings.Default.ad_client;
            string linkAbsolutePath = u.AbsolutePath.Remove(0, 1);
            string profitShare = @"http://profitshare.emag.ro/click.php?ad_client=" + ad_client + "&redirect=" + linkAbsolutePath;
            return ShortUrl.WithGoogl(profitShare);

        }

        public string Price
        {
            get
            {
                //Get Document Header Name
                Regex pricePattern = new Regex("id=\"product-price-rate\" value=\"*.*\" />");
                Match m = pricePattern.Match(document);

                if (m.Success)
                {
                    var mValue = m.Value.Replace("id=\"product-price-rate\" value=\"", String.Empty);
                    mValue = mValue.Replace("\" />", String.Empty);
                    return mValue;
                }
                return String.Empty;
            }
        }

        public CategorieEnum Categorie
        {
            get
            {
                if (document.Contains("<a href=\"/carti?ref=bc\">"))
                {
                    return CategorieEnum.Carti;
                }
                else if ((document.Contains("<a href=\"/muzica?ref=bc\">")))
                {
                    return CategorieEnum.Muzica;
                }
                else if ((document.Contains("<a href=\"/jucarii-copii-bebe?ref=bc\">")))
                {
                    return CategorieEnum.JucariiCopiiBebe;
                }
                else
                {
                    return CategorieEnum.Other;
                }
            }
        }

        public string Profit
        {
            get
            {
                if (Price != String.Empty)
                {
                    double comision;
                    double price = double.Parse(Price);
                    int procent=(int)Categorie;
                    comision = (procent * price) / 100;
                    var x = Categorie;
                    return "(" + procent.ToString() + "%) " + Math.Round(comision, 2).ToString();
                }
                return String.Empty;
            }
        }
        public string Title
        {
            get
            {

                Regex titlePattern = new Regex("<title>*.*</title>");
                Match m = titlePattern.Match(document);

                if (m.Success)
                {
                    var mValue = m.Value.Replace("<title>", String.Empty);
                    mValue = mValue.Replace("- eMAG.ro </title>", String.Empty);
                    return mValue;
                }
                return String.Empty;
            }
        }

        public string ShortLink
        {
            get
            {
                return GetProfitshareLink(link);
            }
        }

        public enum CategorieEnum:int
        {
            Carti=8,
            Muzica=6,
            JucariiCopiiBebe=6,
            Other=3
        }
    }
}
