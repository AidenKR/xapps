using Android.App;
using xapps.Droid;
using Android.Content;

namespace xapps
{
    public class NotificationUtil
    {

        public static void ShowNotification(Context activity, string messageBody)
        {
            var intent = new Intent(activity, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            var pendingIntent = PendingIntent.GetActivity(activity, 0, intent, PendingIntentFlags.OneShot);

            var notificationBuilder = new Notification.Builder(activity)
                .SetSmallIcon(Resource.Drawable.icon)
                .SetContentTitle("FCM Message")
                .SetContentText(messageBody)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManager.FromContext(activity);
            notificationManager.Notify(0, notificationBuilder.Build());
        }
    }
}
