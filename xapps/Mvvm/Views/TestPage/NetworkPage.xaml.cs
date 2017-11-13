using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using xapps.Mvvm.Views.CustomTabBar;

namespace xapps
{
    public partial class NetworkPage : ContentPage, CustomTabInterface//, INetworkManager
    {
        public static NetworkManager netManager;

        public NetworkPage()
        {
            InitializeComponent();

            //NetworkManager.Instance().requestNowPlayingData("1");
            //NetworkManager.Instance().requestUpCommingData("1");
            //NetworkManager.Instance().requestDetailsData("284053");

            //Image image = ImageManager.getImageFromUrl("https://www.w3schools.com/howto/img_fjords.jpg");
            //if(image == null) {
            //    Debug.WriteLine("image object is null T.T");
            //} else {
            //    Debug.WriteLine("success download image to url");
            //}

            List<CustomTabData> tabs = new List<CustomTabData>();

            for (int i = 0; i < 5; i++) {
                CustomTabData tab = new CustomTabData();
                tab.tabText = "one" + i;
                tab.isUseImage = false;
                tab.selColor = "#F7D358";
                tab.norColor = "#F5ECCE";
                tab.tag = i;
                tabs.Add(tab);
            }

            CustomTabData add = new CustomTabData();
            add.tabText = "one6";
            add.isUseImage = false;
            add.selColor = "#000000";
            add.norColor = "#ffffff";
            add.tag = "i'm select";
            tabs.Add(add);

            CustomTabView tabView = new CustomTabView(this, 375);

            tabView.makeTabLayout(tabs);

            mainStack.Children.Add(tabView);
        }

        public void onClickTabButton(object tag) {
            Debug.WriteLine("tag = " + tag);

            switch (tag)
            {
                case 0:
                case 1:
                    {
                        NetworkManager.Instance().requestNowPlayingData("1");
                    }
                    break;

                case 2:
                case 3:
                    {
                        NetworkManager.Instance().requestUpCommingData("1");
                    }
                    break;

                case 4:
                    {
                        NetworkManager.Instance().requestDetailsData("284053");
                    }
                    break;

                default: {
                        Image image = ImageManager.getImageFromUrl("https://www.w3schools.com/howto/img_fjords.jpg");
                        if(image == null) {
                            Debug.WriteLine("image object is null T.T");
                        } else {
                            Debug.WriteLine("success download image to url");
                        }
                        break;
                    }
            }
        }
    }
}
