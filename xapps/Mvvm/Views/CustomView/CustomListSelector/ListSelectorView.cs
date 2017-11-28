using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace xapps
{
    public class ListSelectorView : ListView
    {
        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create("Items", typeof(IEnumerable<ListPageItem>), typeof(ListSelectorView), new List<ListPageItem>());

        public IEnumerable<ListPageItem> Items
        {
            get { return (IEnumerable<ListPageItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

        public void NotifyItemSelected(object item)
        {
            if (ItemSelected != null)
            {
                ItemSelected(this, new SelectedItemChangedEventArgs(item));
            }
        }
    }
}
