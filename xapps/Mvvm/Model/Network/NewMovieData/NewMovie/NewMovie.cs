using System;
using System.Collections.Generic;
namespace xapps
{
    public class NewMovie : dataItem
    {
        public string DOCID { get; set; }
        public string movieId { get; set; }
        public string movieSeq { get; set; }
        public string title { get; set; }
        public string titleEng { get; set; }

        public string titleOrg { get; set; }
        public string titleEtc { get; set; }
        public string prodYear { get; set; }
        public List<director> directors { get; set; }
        public List<actor> actors { get; set; }

        public string nation { get; set; }
        public string company { get; set; }
        public string plot { get; set; }
        public string runtime { get; set; }
        public string rating { get; set; }

        public string genre { get; set; }
        public string kmdbUrl { get; set; }
        public string type { get; set; }
        public string use { get; set; }
        public string episodes { get; set; }

        public string ratedYn { get; set; }
        public string repRatDate { get; set; }
        public string repRlsDate { get; set; }
        public List<rating> ratings { get; set; }
        public string keywords { get; set; }

        public string posters { get; set; }
        public string stlls { get; set; }
        public List<staff> staffs { get; set; }
        public List<vod> vods { get; set; }
        public string openThtr { get; set; }

        public List<stat> stats { get; set; }
        public string themeSong { get; set; }
        public string soundtrack { get; set; }
        public string fLocation { get; set; }
        public string Awards1 { get; set; }

        public string Awards2 { get; set; }
        public string regDate { get; set; }
        public string modDate { get; set; }
        public string isanCode { get; set; }
        public string ALIAS { get; set; }
    }
}