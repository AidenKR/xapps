using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xapps
{
    public class ListPageViewModel : BaseViewModel
    {
        public ObservableCollection<results> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ListPageViewModel()
        {
            Title = "영화";
            Items = new ObservableCollection<results>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var result = await NetworkManager.Instance().requestNowPlayingData("1");
                foreach (var item in result.results)
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


