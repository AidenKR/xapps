using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace xapps
{
    public class DetailData : BaseData
    {
        public string adult { get; set; }
        public string backdrop_path { get; set; }
        public belongs_to_collection belongs_to_collection { get; set; }
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

        public override string ToString()
        {
            return string.Format("[DetailData: adult={0}, backdrop_path={1}, belongs_to_collection={2}, budget={3}, genres={4}, homepage={5}, id={6}, imdb_id={7}, original_language={8}, original_title={9}, overview={10}, popularity={11}, poster_path={12}, production_companies={13}, production_contries={14}, release_date={15}, revenue={16}, runtime={17}, spoken_languages={18}, status={19}, tagline={20}, title={21}, video={22}, vote_average={23}, vote_count={24}]", adult, backdrop_path, belongs_to_collection, budget, genres, homepage, id, imdb_id, original_language, original_title, overview, popularity, poster_path, production_companies, production_contries, release_date, revenue, runtime, spoken_languages, status, tagline, title, video, vote_average, vote_count);
        }
    }
}

