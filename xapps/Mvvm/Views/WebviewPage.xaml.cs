using System;
using System.Diagnostics;
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

        public WebviewPage(): this("http://13.124.169.220/")
        {
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Debug.WriteLine("WebviewPage OnAppearing()");
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

        void forwardClicked(object sender, EventArgs e)
        {
            if (Browser.CanGoForward)
            {
                Browser.GoForward();
            }
        }

        void OnNavigating(object sender, Xamarin.Forms.WebNavigatingEventArgs e)
        {
            Debug.WriteLine("WebviewPage OnNavigating(e) : " + e.Url);
        }

        void OnNavigated(object sender, Xamarin.Forms.WebNavigatedEventArgs e)
        {
            Debug.WriteLine("WebviewPage OnNavigated(e) : " + e.Url);
        }
    }
}
