using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using xapps;

[assembly: Dependency(typeof(MovieUrlData))]
namespace xapps
{
    class MovieUrlData : IMovieUrl
    {
        public static string previewUrl { get; set; }

        public void MovieUrl(string url)
        {
            previewUrl = url;
        }
    }
}