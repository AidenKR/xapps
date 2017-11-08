
using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using xapps;

[assembly: ExportRenderer(typeof(xapps.PreviewPage), typeof(PreviewCustomRenderer))]
namespace xapps
{
    class PreviewCustomRenderer : PageRenderer
    {
        private ScreenOrientation _previousOrientation = ScreenOrientation.Unspecified;

        private VideoView videoView;
        private global::Android.Views.View view;
        private Android.Widget.Button playButton;
        private MediaController mediaController;

        private int width, height;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            var activity = Context as Activity;
            var viewHolder = activity.LayoutInflater.Inflate(Droid.Resource.Layout.MoviePreview, this, false);
            view = viewHolder;
            AddView(view);

            //Get and set Views
            videoView = FindViewById<VideoView>(Droid.Resource.Id.previewMovie);
            playButton = FindViewById<Android.Widget.Button>(Droid.Resource.Id.startBtn);

            mediaController = new Android.Widget.MediaController(activity);
            mediaController.SetAnchorView(videoView);
            videoView.SetMediaController(mediaController);
            videoView.RequestFocus();

            //uri for a free video
            var uri = Android.Net.Uri.Parse("http://sites.google.com/site/ubiaccessmobile/sample_video.mp4");
            //Set the videoView with our uri, this could also be a local video on device
            videoView.SetVideoURI(uri);
            Play(activity);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            //Calculate width and height for easier reading
            width = r - l;
            height = b - t;

            //If in Landscape, we want to make sure we are in full screen
            if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape)
            {
                //Landscape Orientation
                view.Layout(0, 0, width, height);
                videoView.Layout(0, 0, width, height);
                //You must also set the size of the videoView holder, or else full screen won't work
                //If the layout of the videoView increases, that doesn't mean the holder that holds the video automaticall increases
                videoView.Holder.SetFixedSize(width, height);
            }
            else
            {
                //Portrait Orientation, just layout everything nomally
                view.Layout(0, 0, width, height);
                videoView.Layout(0, 0, width, height - 150);
                //Still need to do this to ensure when you rotate from Landscape back to Portrait, the values are reset
                videoView.Holder.SetFixedSize(width, height - 150);
                playButton.Layout(0, height - 150, width, height);
            }
        }

        protected override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            //Hide the Status Bar when in full screen. 
            if (newConfig.Orientation == Android.Content.Res.Orientation.Landscape)
            {
                StatusBarHelper.DecorView.SystemUiVisibility = StatusBarVisibility.Hidden;
                //If you have an ActionBar, uncomment the line below
                //StatusBarHelper.AppActionBar.Hide ();
            }
            else
            {
                StatusBarHelper.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
                //If you have an ActionBar, uncomment the line below
                //StatusBarHelper.AppActionBar.Show ();
            }
        }

        protected override void OnWindowVisibilityChanged(ViewStates visibility)
        {
            base.OnWindowVisibilityChanged(visibility);
            var activity = (Activity)Context;
            if (visibility == ViewStates.Gone)
            {
                // Revert to previous orientation
                activity.RequestedOrientation = _previousOrientation == ScreenOrientation.Unspecified ?
               ScreenOrientation.Portrait : _previousOrientation;
            }
            else if (visibility == ViewStates.Visible)
            {
                if (_previousOrientation == ScreenOrientation.Unspecified)
                {
                    _previousOrientation = activity.RequestedOrientation;
                }

                activity.RequestedOrientation = ScreenOrientation.Landscape;
            }
        }

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

        }

    }
}