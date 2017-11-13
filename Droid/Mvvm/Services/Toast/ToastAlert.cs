using Xamarin.Forms;
using Android.Widget;
using xapps.Droid;

[assembly: Dependency(typeof(ToastAlert))]
namespace xapps.Droid
{
    public class ToastAlert : IToastAlert
    {
        public void showToast(string msg)
        {
            showToast(msg, false);
        }

        public void showToast(string msg, bool LongToast)
        {
            var context = Forms.Context;
            if (null != context)
            {
                Toast.MakeText(context, msg, LongToast ? ToastLength.Long : ToastLength.Short).Show();
            }
        }
    }
}
