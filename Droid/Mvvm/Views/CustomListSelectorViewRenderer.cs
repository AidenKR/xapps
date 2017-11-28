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

            if (e.OldElement != null)
            {
                // unsubscribe
                Control.ItemClick -= OnItemClick;
            }

            if (e.NewElement != null)
            {
                // subscribe
                Control.Adapter = new ListSelectorViewAdapter(Forms.Context as Android.App.Activity, e.NewElement as ListSelectorView);
                Control.ItemClick += OnItemClick;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ListSelectorView.ItemsProperty.PropertyName)
            {
                Control.Adapter = new ListSelectorViewAdapter(Forms.Context as Android.App.Activity, Element as ListSelectorView);
            }
        }

        void OnItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            ((ListSelectorView)Element).NotifyItemSelected(((ListSelectorView)Element).Items.ToList()[e.Position - 1]);
        }
    }
}