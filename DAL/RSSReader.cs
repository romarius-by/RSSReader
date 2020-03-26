using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSSReader.Models;
using System.Xml.XPath;
using System.Net;
using System.Xml.Linq;
using System.Xml;
using System.Text;
using System.Globalization;

namespace RSSReader.DAL
{
    public class NewsReader
    {
        public static IEnumerable<News> Read(string url)
        {
            IEnumerable<News> RSSFeedData = new List<News>();
            try
            {
                WebClient wclient = new WebClient();
                string RSSData = wclient.DownloadString(url);

                Encoding utf8 = Encoding.GetEncoding("UTF-8");
                Encoding win1251 = Encoding.GetEncoding("Windows-1251");

                byte[] utf8Bytes = win1251.GetBytes(RSSData);
                byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
                RSSData = win1251.GetString(win1251Bytes);

                XDocument xml = XDocument.Parse(RSSData);
                RSSFeedData = (from x in xml.Descendants("item")
                               select new News
                               {
                                   Name = (string)x.Element("link"),
                                   Description = (string)x.Element("title"),
                                   PublicationTime = (string)x.Element("pubDate")
                               });
            }
            catch { RSSFeedData = null; }
            return RSSFeedData;
        }
    }
}