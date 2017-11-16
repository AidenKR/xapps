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
using Android.Content.PM;

namespace xapps.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", ScreenOrientation = ScreenOrientation.Landscape)]
    class FullScreenActivity : Activity
    {
        MediaController mediaController;
        VideoView videoView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MoviePreview);
            VideoView v = FindViewById<VideoView>(Resource.Id.previewMovie);

            mediaController = new Android.Widget.MediaController(this);
            mediaController.SetAnchorView(videoView);
            videoView.SetMediaController(mediaController);
            videoView.RequestFocus();

            var uri = Android.Net.Uri.Parse(MovieUrlData.previewUrl);
            //Set the videoView with our uri, this could also be a local video on device
            videoView.SetVideoURI(uri);

            RunOnUiThread(() => {
                videoView.Visibility = ViewStates.Visible;
                videoView.Start();
            });

            videoView.Completion += delegate
            {
                this.OnBackPressed();
            };

            videoView.Error += delegate
            {
                this.OnBackPressed();
            };
        }
    }
}