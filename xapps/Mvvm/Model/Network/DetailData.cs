using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace xapps
{
    public class DetailData : dataItem
    {
        public string adult { get; set; }
        public string backdrop_path { get; set; }
        public string belongs_to_collection { get; set; }
        public string budget { get; set; }

        public List<genres> genres { get; set; }

        public string homepage { get; set; }
        public string id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string popularity { get; set; }
        public string poster_path { get; set; }

        public List<production_companies> production_companies { get; set; }
        public List<production_contries> production_contries { get; set; }

        public string release_date { get; set; }
        public string revenue { get; set; }
        public string runtime { get; set; }

        public List<spoken_languages> spoken_languages { get; set; }

        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public string video { get; set; }
        public string vote_average { get; set; }
        public string vote_count { get; set; }
    }
}

