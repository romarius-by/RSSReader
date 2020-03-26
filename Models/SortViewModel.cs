using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSReader.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; }
        public SortState DateSort { get; private set; }
        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
                NameSort = SortState.Name;
                DateSort = SortState.Date;
            Current = sortOrder;
        }
    }
}