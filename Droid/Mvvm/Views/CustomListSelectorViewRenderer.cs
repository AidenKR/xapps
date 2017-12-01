using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using xapps;
using xapps.Droid;

[assembly: ExportRenderer(typeof(ListSelectorView), typeof(CustomListSelectorViewRenderer))]
namespace xapps.Droid
{
    public class CustomListSelectorViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            Console.WriteLine("OnElementChanged()");

            if (e.OldElement != null)
            {
                //Console.WriteLine("OnElementChanged() e.OldElement != null");
                // unsubscribe
                Control.ItemClick -= OnItemClick;
            }

            if (e.NewElement != null)
            {
                //Console.WriteLine("OnElementChanged() e.NewElement != null");
                // subscribe
                Control.Adapter = new ListSelectorViewAdapter(Forms.Context as Android.App.Activity, e.NewElement as ListSelectorView);
                Control.ItemClick += OnItemClick;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            //Console.WriteLine("OnElementPropertyChanged() e.PropertyName: " + e.PropertyName);

            if (e.PropertyName == Xamarin.Forms.ListView.IsRefreshingProperty.PropertyName)
            {
                Control.Adapter = new ListSelectorViewAdapter(Forms.Context as Android.App.Activity, Element as ListSelectorView);
            }
        }

        void OnItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            try
            {
                ((ListSelectorView)Element).NotifyItemSelected(((ListSelectorView)Element).Items.ToList()[e.Position - 1]);
            }
            catch (Exception exception)
            {
                Console.WriteLine("OnItemClick() error: " + exception.Message);
            }
        }
    }
}