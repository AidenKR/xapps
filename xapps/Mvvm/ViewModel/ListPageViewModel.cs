using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xapps
{
    public class ListPageViewModel : BaseViewModel
    {
        public const int TYPE_NOW_PLAYING = 100; // 현재 상영중
        public const int TYPE_UPCOMING = TYPE_NOW_PLAYING + 1; // 개봉 예정 중

        public ObservableCollection<results> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command RefreshItemsCommand { get; set; }
        public Command MoreItemsCommand { get; set; }

        // selected Category index
        private int SelectedCategoryType = TYPE_NOW_PLAYING;

        public ListPageViewModel()
        {
            Title = "영화";
            Items = new ObservableCollection<results>();

            LoadItemsCommand = new Command<int>(async (requestType) => await ExecuteLoadItemsCommand(requestType));
            RefreshItemsCommand = new Command(async () => await ExecuteRefreshItemsCommand());
            MoreItemsCommand = new Command<int[]>(async (reqValues) => await ExecuteMoreItemsCommand(reqValues));
        }

        async Task ExecuteRefreshItemsCommand() {
            Debug.WriteLine("ExecuteRefreshItemsCommand : " + SelectedCategoryType);
            await ExecuteLoadItemsCommand(SelectedCategoryType);
        }

        async Task ExecuteLoadItemsCommand(int requestType)
        {
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
                            var result = await NetworkManager.ReqNowPlaying("1");
                            list = result.results;
                            break;
                        }

                    case TYPE_UPCOMING:
                        {
                            var result = await NetworkManager.ReqUpComming("1");
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

        async Task ExecuteMoreItemsCommand(int[] reqValues)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                int requestType = reqValues[0];
                int pageNumber = reqValues[1];

                List<results> list = null;
                switch (requestType)
                {
                case TYPE_NOW_PLAYING:
                {
                var result = await NetworkManager.ReqNowPlaying(pageNumber.ToString());
                list = result.results;
                            break;
                        }

                    case TYPE_UPCOMING:
                        {
                            var result = await NetworkManager.ReqUpComming(pageNumber.ToString());
                            list = result.results;
                            break;
                        }
                }

                if (list == null)
                {
                    return;
                }

                SelectedCategoryType = requestType;

                //Items.Clear();
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


