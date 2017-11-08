using System;
using System.Collections.Generic;

namespace xapps
{
    public class UpCommingData
    {
        public List<results> results { get; set; }
        public string page { get; set; }
        public string total_results { get; set; }
        public Dates dates { get; set; }
        public string total_pages { get; set; }
    }
}
