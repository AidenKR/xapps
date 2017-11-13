using Xamarin.Forms;
using UIKit;
using Foundation;
using xapps.iOS;

[assembly: Dependency(typeof(ToastAlert))]
namespace xapps.iOS
{
    public class ToastAlert : IToastAlert
    {
        const double LONG_DELAY = 3.5;
        const double SHORT_DELAY = 2.0;

        NSTimer alertDelay;
        UIAlertController alert;

        public void showToast(string msg)
        {
            noti(msg, SHORT_DELAY);
        }

        public void showToast(string msg, bool LongToast)
        {
            noti(msg, LongToast ? LONG_DELAY : SHORT_DELAY);
        }

        private void noti(string msg, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                dissmiss();
            });

            alert = UIAlertController.Create(null, msg, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        private void dissmiss()
        {
            if (null != alert)
            {
                alert.DismissViewController(true, null);
            }

            if (null != alertDelay)
            {
                alertDelay.Dispose();
            }
        }
    }
}
