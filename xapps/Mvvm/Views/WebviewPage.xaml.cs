using System;

using Xamarin.Forms;

namespace xapps
{
    public partial class WebviewPage : ContentPage
    {
        public WebviewPage(string url = "http://13.124.169.220/")
        {
            InitializeComponent();

            Browser.Source = url;
        }

        void backClicked(object sender, EventArgs e)
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
