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
using xapps.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Util;

[assembly: ExportRenderer(typeof(DetailPreview), typeof(DetailPreviewCustomRenderer))]
namespace xapps.Droid
{
    class DetailPreviewCustomRenderer : ViewRenderer<DetailPreview, DetailPreviewCustomRenderer>, Android.Views.View.IOnClickListener
    {
        VideoView videoView;
        global::Android.Views.View view;
        MediaController mediaController;

        Android.Widget.Button playButton;

        protected override void OnElementChanged(ElementChangedEventArgs<DetailPreview> e)
        {
            base.OnElementChanged(e);
            Log.Debug("TEST", "DetailPreviewCustomRenderer");


            var activity = Context as Activity;
            var viewHolder = activity.LayoutInflater.Inflate(Resource.Layout.DetailPreview, this, false);
            view = viewHolder;
            AddView(view);

            //Get and set Views
            videoView = FindViewById<VideoView>(Resource.Id.detailPreview);
            playButton = FindViewById<Android.Widget.Button>(Resource.Id.detailPlayBtn);
            //poster = FindViewById<ImageView>(Resource.Id.detailPosterIV);

            mediaController = new Android.Widget.MediaController(activity);
            mediaController.SetAnchorView(videoView);
            videoView.SetMediaController(mediaController);
            videoView.RequestFocus();

            var uri = Android.Net.Uri.Parse(MovieUrlData.previewUrl);
            //Set the videoView with our uri, this could also be a local video on device
            videoView.SetVideoURI(uri);

            playButton.Click += PlayVideo;
            videoView.Visibility = ViewStates.Gone;

            videoView.Completion += delegate
            {
                videoView.Visibility = ViewStates.Gone;
                playButton.Visibility = ViewStates.Visible;
                //poster.Visibility = ViewStates.Visible;
            };

            videoView.Error += delegate
            {
                videoView.Visibility = ViewStates.Gone;
            };

            mediaController.Click += delegate
            {
                activity.StartActivity(new Intent(activity.ApplicationContext, typeof(FullScreenActivity)));
            };

            mediaController.SetPrevNextListeners(this, this);
        }

        private void PlayVideo(object sender, EventArgs e)
        {
            var activity = Context as Activity;
            activity.RunOnUiThread(() => {
                videoView.Visibility = ViewStates.Visible;
                videoView.Start();
            });
            playButton.Visibility = ViewStates.Gone;
            //poster.Visibility = ViewStates.Gone;
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            //Calculate width and height for easier reading
            var width = r - l;
            var height = b - t;

            //Portrait Orientation, just layout everything nomally
            view.Layout(0, 0, width, height);
            videoView.Layout(0, 0, width, height);
            playButton.Layout(width / 2 - 50, height / 2 - 50, width / 2 + 50, height / 2 + 50);
            //poster.Layout(0, 0, width, height);
            //Still need to do this to ensure when you rotate from Landscape back to Portrait, the values are reset
            videoView.Holder.SetFixedSize(width, height);
        }

        public void OnClick(Android.Views.View v)
        {
            Log.Debug("TEST", "Click");
        }

        /*
        private void Play(Activity activity)
        {
            ProgressDialog dialog = new ProgressDialog(activity);
            dialog.SetMessage("Loading, Please Wait...");
            dialog.SetCancelable(true);
            dialog.Show();

            activity.RunOnUiThread(() =>
            {
                videoView.Prepared += (sender, args) =>
                {
                    dialog.Dismiss();
                    videoView.Start();
                };
            });

            videoView.Completion += delegate
            {
                activity.OnBackPressed();
            };

            videoView.Error += delegate
            {
                dialog.Dismiss();

                AlertDialog.Builder builder = new AlertDialog.Builder(activity);
                builder.SetNeutralButton("OK", (send, args) => { activity.OnBackPressed(); });
                builder.SetMessage("동영상 재생에 실패 했습니다.");
                builder.SetTitle("Alert");
                builder.Show();
            };

        }
        */
    }
}