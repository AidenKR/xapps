using System;
using System.Collections.Generic;
namespace xapps
{
    public class MovieDetailData : dataItem
    {
        public string movieCd { get; set; }
        public string movieNm { get; set; }
        public string movieNmEn { get; set; }
        public string movieNmOg { get; set; }
        public string prdtYear { get; set; }
        public string showTm { get; set; }
        public string openDt { get; set; }
        public string prdtStatNm { get; set; }
        public string typeNm { get; set; }
        public string nations { get; set; }
        public string nationNm { get; set; }

        public List<string> genreNm { get; set; }
        public List<People> directors { get; set; }
        public List<People> actors { get; set; }
        public List<ShowType> showTypes { get; set; }
        public List<Company> companys { get; set; }
        public List<Audit> audits { get; set; }
        public List<People> staffs { get; set; }
    }
}
