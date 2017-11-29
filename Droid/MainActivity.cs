using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Firebase.Iid;
using Android.Gms.Common;
using CarouselView.FormsPlugin.Android;

namespace xapps.Droid
{
    [Activity(Label = "xapps.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.FormsGoogleMaps.Init(this, bundle);
            LoadApplication(new App());

            try {
                if (IsPlayServicesAvailable())
                {
                    var refreshedToken = FirebaseInstanceId.Instance.Token;
                    ShowLog("refreshedToken : " + refreshedToken);
                }
            } catch (Exception e) {
                e.GetBaseException();
                showPopup(e.Message);
            }

            var pixelWidth = (int)Resources.DisplayMetrics.WidthPixels;
            var pixelHeight = (int)Resources.DisplayMetrics.HeightPixels;
            var screenPixelDensity = (double)Resources.DisplayMetrics.Density;

            App.ScreenHeight = (double)((pixelHeight - 0.5f) / screenPixelDensity);
            App.ScreenWidth = (double)((pixelWidth - 0.5f) / screenPixelDensity);

            //Set our status bar helper DecorView. This enables us to hide the notification bar for fullscreen
            StatusBarHelper.DecorView = this.Window.DecorView;

            CarouselViewRenderer.Init();
        }

        public override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            //Set our status bar helper AppActionBar. This enables us to hide the ActionBar for fullscreen
            //Always hide the actionbar/toolbar if you are hiding the notification bar
            if (ActionBar != null)
                StatusBarHelper.AppActionBar = ActionBar;
        }

        /**
         * IsPlayServicesAvailable.
         */
        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    ShowLog(GoogleApiAvailability.Instance.GetErrorString(resultCode));
                else
                {
                    ShowLog("This device is not supported");
                    //Finish();
                }
                return false;
            }
            else
            {
                ShowLog("Google Play Services is available.");
                return true;
            }

        }

        private void ShowLog(string message)
        {
            System.Diagnostics.Debug.WriteLine("[TEST_LOG] " + message);
        }

        private void showPopup(string msg) {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("알림");
            alert.SetMessage(msg);
            alert.SetPositiveButton("확인", (senderAlert, args) => {
            });
            Dialog dialog = alert.Create();
            dialog.Show();
        }
    }
}
