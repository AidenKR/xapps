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

            map.Clicked += (sender, e) => {
                Navigation.PushAsync(new MapPage(""));
            };
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
            var url = DependencyService.Get<IMovieUrl>();
            if (url != null)
            {
                url.MovieUrl("http://sites.google.com/site/ubiaccessmobile/sample_video.mp4");
            }
            Navigation.PushAsync(new PreviewPage());
        }

        void ToastBtnClicked(object sender, System.EventArgs e)
        {
            string ToastMsg = "Test!!!"; // Toast메시지
            bool longTime = false; // Toast 띄우는시간

            var toast = DependencyService.Get<IToastAlert>();
            if (null != toast)
            {
                toast.showToast(ToastMsg, longTime);
            }
        }

        private void CamearBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CameraPage());
        }

        private void ListSelectorBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListSelectorPage());
        }
    }
}
