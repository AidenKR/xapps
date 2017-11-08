using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace xapps
{
    public class NowPlayingData : BaseData
    {
        public List<results> results { get; set; }
        public string page { get; set; }
        public string total_results { get; set; }
        public Dates dates { get; set; }
        public string total_pages { get; set; }
    }
}

