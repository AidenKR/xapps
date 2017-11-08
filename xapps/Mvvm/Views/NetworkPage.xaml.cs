using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public partial class NetworkPage : ContentPage
    {
        public static NetworkManager netManager;

        public NetworkPage()
        {
            InitializeComponent();
            //NetworkManager.Instance().requestMovieList();
            //NetworkManager.Instance().requestMovieDetail("05313");

            NetworkManager.Instance().requestNowPlayingData("1");
            NetworkManager.Instance().requestUpCommingData("1");

            //NetworkManager.requestMovieDetail("05313");   // // 독도 KOREA

            Image image = ImageManager.getImageFromUrl("https://www.w3schools.com/howto/img_fjords.jpg");
            if(image == null) {
                Debug.WriteLine("image object is null T.T");
            } else {
                Debug.WriteLine("success download image to url");
            }
        }


    }
}
