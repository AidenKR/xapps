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
using Android.Graphics;

namespace xapps.Droid
{
    [Activity(Theme = "@android:style/Theme.NoTitleBar.Fullscreen", ScreenOrientation = ScreenOrientation.Landscape)]
    public class FullScreenActivity : Activity
    {
        MediaController mediaController;
        VideoView videoView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            int duration = Intent.GetIntExtra("DURATION", 0);
            SetContentView(Resource.Layout.FullScreenPreview);
            videoView = FindViewById<VideoView>(Resource.Id.fullScreenPreview);

            mediaController = new Android.Widget.MediaController(this);
            mediaController.SetAnchorView(videoView);
            videoView.SetMediaController(mediaController);
            videoView.RequestFocus();
            //videoView.SetBackgroundColor(Color.Transparent);


            var uri = Android.Net.Uri.Parse(MovieUrlData.previewUrl);
            //Set the videoView with our uri, this could also be a local video on device
            videoView.SetVideoURI(uri);

            // Progress 다이얼 로그
            ProgressDialog dialog = new ProgressDialog(this);
            dialog.SetMessage("Loading, Please Wait...");
            dialog.SetCancelable(true);
            dialog.Show();

            videoView.Prepared += delegate
            {
                RunOnUiThread(() =>
                {
                    dialog.Dismiss();
                    mediaController.Show();
                    videoView.SeekTo(duration);
                    videoView.Start();
                });
            };

            videoView.Completion += delegate
            {
                this.OnBackPressed();
            };

            videoView.Error += delegate
            {
                dialog.Dismiss();
                this.OnBackPressed();
            };
        }

    }
}