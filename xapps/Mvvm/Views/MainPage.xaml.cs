using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xapps
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.ListView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null && item.TargetType != null)
            {
                var nextPage = (Page)Activator.CreateInstance(item.TargetType);
                Detail.Navigation.PushAsync(nextPage);

                masterPage.ListView.SelectedItem = null;
            }

            IsPresented = false;
        }
    }
}
