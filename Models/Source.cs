using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSReader.Models
{
    public class Source
    {
        public int SourceId { get; set; }
        public string Name { get; set; }
        public string RSSLink { get; set; }

        public ICollection<News> News { get; set; }
        public Source()
        {
            News = new List<News>();
        }
    }
}