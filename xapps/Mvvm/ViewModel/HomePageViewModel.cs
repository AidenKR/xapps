using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xapps
{
    public class HomePageViewModel : BaseViewModel
    {
        public const int TYPE_NOW_PLAYING = 100; // 현재 상영중
        public const int TYPE_UPCOMING = TYPE_NOW_PLAYING + 1; // 개봉 예정 중

        public ObservableCollection<results> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        // selected Category index
        public int SelectedCategoryType = TYPE_NOW_PLAYING;

        public HomePageViewModel()
        {
            Title = "XAPPS";
            Items = new ObservableCollection<results>();

            LoadItemsCommand = new Command<int>(async (requestType) => await ExecuteLoadItemsCommand(requestType));
        }

        async Task ExecuteLoadItemsCommand(int requestType)
        {
            Debug.WriteLine("ExecuteLoadItemsCommand() IsBusy = {0}, requestType = {1}", IsBusy, requestType);
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                List<results> list = null;
                switch (requestType)
                {
                    case TYPE_NOW_PLAYING:
                        {
                            var result = await NetworkManager.NowPlaying("1");
                            list = result.results;
                            break;
                        }

                    case TYPE_UPCOMING:
                        {
                            var result = await NetworkManager.Upcoming("1");
                            list = result.results;
                            break;
                        }
                }

                if (list == null)
                {
                    return;
                }

                SelectedCategoryType = requestType;

                Items.Clear();
                foreach (var item in list)
                {
                    item.poster_path = "https://image.tmdb.org/t/p/w500/" + item.poster_path;
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
