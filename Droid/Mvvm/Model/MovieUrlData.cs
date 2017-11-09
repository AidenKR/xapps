using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
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