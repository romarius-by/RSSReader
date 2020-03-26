using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RSSReader.Models;

namespace RSSReader.DAL
{
    public class NewsContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Source> Sources { get; set; }

        public NewsContext() : base("name=NewsContext")
        {
            Database.SetInitializer(new NewsInitializer());
        }
    }
}