using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xapps
{
    public class MovieListPageViewModel : BaseViewModel
    {
        public ObservableCollection<MovieData> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public MovieListPageViewModel()
        {
            Title = "Movie List Page";
            Items = new ObservableCollection<MovieData>();
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
                var items = await NetworkManager.Instance().requestMovieList();
                foreach (var item in items)
                {
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

