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
        public ObservableCollection<results> MovieItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        // selected Category index
        public int SelectMovieCategoryType = CategoryManager.TYPE_MOVIE_NOW_PLAYING;

        public HomePageViewModel()
        {
            Title = "XAPPS";
            MovieItems = new ObservableCollection<results>();

            LoadItemsCommand = new Command<int>(async (requestType) => await ExecuteLoadItemsCommand(requestType));
        }

        async Task ExecuteLoadItemsCommand(int requestType)
        {
            Debug.WriteLine("ExecuteLoadItemsCommand() requestType = {0}", requestType);

            try
            {
                List<results> MovieList = await RequestMovieServer(requestType);
                Debug.WriteLine("MovieList() is " + MovieList?.Count);
                if (MovieList == null)
                {
                    return;
                }

                SelectMovieCategoryType = requestType;

                MovieItems.Clear();

                foreach (var item in MovieList)
                {
                    item.poster_path = "https://image.tmdb.org/t/p/w500/" + item.poster_path;
                    MovieItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        async Task<List<results>> RequestMovieServer(int category)
        {
            List<results> list = null;
            switch (category)
            {
                case CategoryManager.TYPE_MOVIE_NOW_PLAYING:
                    {
                        var result = await NetworkManager.NowPlaying("1");
                        list = result.results;
                        break;
                    }

                case CategoryManager.TYPE_MOVIE_UPCOMING:
                    {
                        var result = await NetworkManager.Upcoming("1");
                        list = result.results;
                        break;
                    }
            }

            return list;
        }
    }
}
