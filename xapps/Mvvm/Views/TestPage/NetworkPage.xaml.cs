using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public partial class NetworkPage : ContentPage, CustomTabInterface//, INetworkManager
    {
        public NetworkPage()
        {
            InitializeComponent();

            List<string> tabs = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                tabs.Add("one" + i);
            }

            CustomTabCellLayoutData layoutData = new CustomTabCellLayoutData
            {
                selColor = Color.FromHex("#F7D358"),
                norColor = Color.FromHex("#F5ECCE"),
            };

            CustomTabView tabView = new CustomTabView();

            tabView.makeTabLayout(tabs, layoutData);
            tabView.Listener = this;

            mainStack.Children.Add(tabView);
        }

        async public void onClickTabButton(object tag)
        {
            Debug.WriteLine("tag = " + tag);

            switch (tag)
            {
                case 0:
                    {
                        NetworkCallbackDelegate netDelegate = new NetworkCallbackDelegate((ResponseData data) =>
                        {
                            string result = data.ToString();
                            Debug.WriteLine("Network NowPlaying Delegate Callback Result : " + result);
                        });
                        Debug.WriteLine("Network NowPlaying Delegate Start...");
                        NetworkManager.NowPlayingToCallback("1", netDelegate);
                        Debug.WriteLine("Network NowPlaying Delegate End...");
                    }
                    break;
                case 1:
                    {
                        Debug.WriteLine("Network NowPlaying Start...");
                        var task = await NetworkManager.NowPlaying("1");
                        Debug.WriteLine("Network NowPlaying End...");
                    }
                    break;

                case 2:
                    {
                        NetworkCallbackDelegate netDelegate = new NetworkCallbackDelegate((ResponseData data) =>
                        {
                            string result = data.ToString();
                            Debug.WriteLine("Network NowPlaying Delegate Callback Result : " + result);
                        });
                        Debug.WriteLine("Network NowPlaying Delegate Start...");
                        NetworkManager.NowPlayingToCallback("1", netDelegate);
                        Debug.WriteLine("Network NowPlaying Delegate End...");

                        NetworkCallbackDelegate netDelegate1 = new NetworkCallbackDelegate((ResponseData data) =>
                        {
                            string result = data.ToString();
                            Debug.WriteLine("Network Upcomming Delegate Callback Result : " + result);
                        });
                        Debug.WriteLine("Network Upcomming Delegate Start...");
                        NetworkManager.UpcomingToCallback("1", netDelegate1);
                        Debug.WriteLine("Network Upcomming Delegate End...");
                    }
                    break;
                case 3:
                    {
                        Debug.WriteLine("Network Upcoming Start...");
                        await NetworkManager.Upcoming("1");
                        Debug.WriteLine("Network Upcoming Start...");
                    }
                    break;

                case 4:
                    {
                        await NetworkManager.Detail("284053");
                    }
                    break;

                default:
                    {
                        Image image = ImageManager.getImageFromUrl("https://www.w3schools.com/howto/img_fjords.jpg");
                        if (image == null)
                        {
                            Debug.WriteLine("image object is null T.T");
                        }
                        else
                        {
                            Debug.WriteLine("success download image to url");
                        }
                        break;
                    }
            }
        }
    }
}
