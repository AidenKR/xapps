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
        public ObservableCollection<BookItem> BooksItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        // selected Category index
        public int SelectMovieCategoryType = CategoryManager.TYPE_MOVIE_NOW_PLAYING;
        public int SelectBooksCategoryType = CategoryManager.TYPE_BOOKS_BEST_SELLER;

        public HomePageViewModel()
        {
            Title = "XAPPS";
            MovieItems = new ObservableCollection<results>();
            BooksItems = new ObservableCollection<BookItem>();

            LoadItemsCommand = new Command<int>(async (requestType) => await ExecuteLoadItemsCommand(requestType));
        }

        async Task ExecuteLoadItemsCommand(int requestType)
        {
            Debug.WriteLine("ExecuteLoadItemsCommand() requestType = {0}", requestType);

            try
            {
                if (CategoryManager.IsMovieCategory(requestType))
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
                else if (CategoryManager.IsBooksCategory(requestType))
                {
                    List<BookItem> BooksList = await RequestBooksServer(requestType);
                    Debug.WriteLine("BooksList() is " + BooksList?.Count);
                    if (BooksList == null)
                    {
                        return;
                    }

                    SelectBooksCategoryType = requestType;

                    BooksItems.Clear();

                    foreach (var item in BooksList)
                    {
                        BooksItems.Add(item);
                    }
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

        async Task<List<BookItem>> RequestBooksServer(int category)
        {
            List<BookItem> list = null;
            switch (category)
            {
                case CategoryManager.TYPE_BOOKS_BEST_SELLER:
                    {
                        var result = await NetworkManager.BestSeller();
                        list = result.item;
                        break;
                    }

                case CategoryManager.TYPE_BOOKS_NEW_BOOK:
                    {
                        var result = await NetworkManager.NewBook();
                        list = result.item;
                        break;
                    }

                case CategoryManager.TYPE_BOOKS_RECOMMEND:
                    {
                        var result = await NetworkManager.Recommend();
                        list = result.item;
                        break;
                    }
            }

            return list;
        }
    }
}
