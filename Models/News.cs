using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSReader.Models
{
    public class News
    {
        public int NewsId { get; set; }
        public string Source { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PublicationTime { get; set; }

        public Source SourceObj { get; set; }
    }
}