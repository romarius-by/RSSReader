using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RSSReader.Models;

namespace RSSReader.DAL
{
    public class NewsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<NewsContext>
    {
        protected override void Seed(NewsContext context)
        {
            var sources = new List<Source>
            {
            new Source{Name="Habrhabr",RSSLink="https://habr.com/ru/rss/all/"},
            new Source{Name="Interfax",RSSLink="https://interfax.by/news/feed/"}
            };

            sources.ForEach(s => context.Sources.Add(s));
            context.SaveChanges();
        }
    }
}