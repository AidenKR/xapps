using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xapps
{
    public partial class WebviewPage : ContentPage
    {
        public WebviewPage()
        {
            InitializeComponent();

            Browser.Source = "https://m.cgv.co.kr";
        }

        private void backClicked(object sender, EventArgs e)
        {
            // Check to see if there is anywhere to go back to
            if (Browser.CanGoBack)
            {
                Browser.GoBack();
            }
            else
            { // If not, leave the view
                Navigation.PopAsync();
            }
        }

        private void forwardClicked(object sender, EventArgs e)
        {
            if (Browser.CanGoForward)
            {
                Browser.GoForward();
            }
        }
    }
}
