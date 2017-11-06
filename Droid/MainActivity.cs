using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Firebase.Iid;
using Android.Gms.Common;

namespace xapps.Droid
{
    [Activity(Label = "xapps.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            if (IsPlayServicesAvailable())
            {
                var refreshedToken = FirebaseInstanceId.Instance.Token;
                ShowLog("refreshedToken : " + refreshedToken);
            }

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
    }
}
