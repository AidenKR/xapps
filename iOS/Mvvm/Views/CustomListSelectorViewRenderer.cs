using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using xapps;
using xapps.iOS;

[assembly: ExportRenderer(typeof(ListSelectorView), typeof(CustomListSelectorViewRenderer))]
namespace xapps.iOS
{
    public class CustomListSelectorViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                Control.Source = new ListSelectorViewSource(e.NewElement as ListSelectorView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            //if (e.PropertyName == ListSelectorView.ItemsProperty.PropertyName)
            //{
            //    Control.Source = new ListSelectorViewSource(Element as ListSelectorView);
            //}
            //else 
            //    if (e.PropertyName == ListSelectorView.ItemsSourceProperty.PropertyName)
            //{
            //    Control.Source = new ListSelectorViewSource(Element as ListSelectorView);
            //}
        }
    }
}
