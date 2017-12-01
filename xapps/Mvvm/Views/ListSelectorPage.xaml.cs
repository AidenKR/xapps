using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xapps
{
    public partial class ListSelectorPage : ContentPage
    {
        public ListSelectorPage()
        {
            InitializeComponent();

            listselectorview.ItemsSource = getData();
        }

        private List<ListPageItem> getData() {
            List<ListPageItem> returnData = new List<ListPageItem>();

            ListPageItem item;
            int ItemCount = 10;

            for (int i = 0; i <= ItemCount; i++) {
                item = new ListPageItem();
                item.Id = "T00" + i;
                item.Title = "제목 " + i;
                item.Description = "내용 " + i;

                returnData.Add(item);
            }

            return returnData;
        }
    }
}
