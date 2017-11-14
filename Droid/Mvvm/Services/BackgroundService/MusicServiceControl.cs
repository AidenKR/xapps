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

[assembly: Dependency(typeof(MusicServiceControl))]
namespace xapps.Droid
{
    class MusicServiceControl : IBackgroundService
    {
        public void startBackgroundService()
        {
            var context = Forms.Context;
            context.StartService(new Intent(context, typeof(MusicBackgroundService)));
        }

        public void stopBackgroundService()
        {
            var context = Forms.Context;
            context.StopService(new Intent(context, typeof(MusicBackgroundService)));
        }
    }
}