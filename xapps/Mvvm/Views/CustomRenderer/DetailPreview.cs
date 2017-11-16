using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace xapps
{
    public class DetailPreview : View
    {
        public DetailPreview()
        {
            Debug.WriteLine("TEST" +  " DetailPreview()");
            var url = DependencyService.Get<IMovieUrl>();
            if (url != null)
            {
                url.MovieUrl("http://sites.google.com/site/ubiaccessmobile/sample_video.mp4");
            }
        }
    }
}