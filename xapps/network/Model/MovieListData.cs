using System;
using System.Collections.Generic;

namespace xapps
{
    public class MovieListData : dataItem
    {
        public string boxofficeType { get; set; }
        public string showRange { get; set; }

        public List<MovieListItem> dailyBoxOfficeList { get; set; }
    }
}
