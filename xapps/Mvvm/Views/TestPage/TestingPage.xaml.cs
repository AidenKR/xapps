using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xapps
{
    public partial class TestingPage : ContentPage
    {
        public TestingPage()
        {
            InitializeComponent();
        }

        // Move To Network Test Page. 
        void NetTestBtnClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NetworkPage());
        }

        // Move To Database Test Page.
        void DBTestBtnClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new DatabasePage());
        }

        void FavoriteBtnClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new FavoritePage());
        }

        void MovieBtnClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PreviewPage());
        }
    }
}
