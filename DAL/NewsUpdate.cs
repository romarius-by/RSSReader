using RSSReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSReader.DAL
{
    public class NewsUpdate
    {
        public static void Update(NewsContext db, Source source)
        {
            foreach (var item in NewsReader.Read(source.RSSLink))
            {
                var hasWithSameName = db.News.Any(x => x.Name == item.Name);
                if (!hasWithSameName)
                {
                    item.Source = source.Name;
                    item.SourceObj = source;
                    db.News.Add(item);
                }
            }
            db.SaveChanges();
        }
    }
}