using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xapps
{
    public partial class NetworkPage : ContentPage
    {
        public static NetworkManager netManager;

        public NetworkPage()
        {
            InitializeComponent();

            netManager = new NetworkManager(new RestService());

            netManager.requestMovieList();
            netManager.requestMovieDetail("20161725");
        }
    }
}
