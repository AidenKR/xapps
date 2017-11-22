using System;
using System.Collections.Generic;

namespace xapps
{
    public class results
    {
        public string vote_count { get; set; }
        public string id { get; set; }
        public string video { get; set; }
        public string vote_average { get; set; }
        public string title { get; set; }
        public string popularity { get; set; }
        public string poster_path { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }

        public List<string> genre_ids { get; set; }

        public string backdrop_path { get; set; }
        public string adult { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
    }
}
