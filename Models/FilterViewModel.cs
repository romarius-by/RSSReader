using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSSReader.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Source> sources, string sourceName)
        {
            sources.Insert(0, new Source { Name = "Все", SourceId = 0 });
            Sources = new SelectList(sources, "Name", "Name");
            SelectedName = sourceName;
        }

        public SelectList Sources { get; set; }
        public string SelectedName { get; private set; }
    }
}