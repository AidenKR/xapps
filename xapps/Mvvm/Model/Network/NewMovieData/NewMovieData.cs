using System;
using System.Collections.Generic;
namespace xapps
{
    public class NewMovieData : dataItem
    {
        public List<NewMovie> MovieList { get; set; }       // List

        public NewMovie movie { get; set; }     // one item
    }
}
