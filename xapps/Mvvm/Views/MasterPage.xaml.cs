using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xapps
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Network Test",
                TargetType = typeof(NetworkPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Database Test",
                TargetType = typeof(DatabasePage)
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}
