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
                Title = "Send Push & Notification",
                //TargetType = typeof(DatabasePage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Move To Bookmark",
                //TargetType = typeof(DatabasePage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Move To WebviewPage",
                TargetType = typeof(WebviewPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Move To TestPage",
                TargetType = typeof(TestingPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Move To Background Music",
                TargetType = typeof(MusicServicePage)
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}
