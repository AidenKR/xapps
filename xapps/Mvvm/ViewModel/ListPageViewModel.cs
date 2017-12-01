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
        public ObservableCollection<ListPageItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command RefreshItemsCommand { get; set; }
        public Command MoreItemsCommand { get; set; }

        // selected Category index
        public int SelectedCategoryType = CategoryManager.TYPE_MOVIE_NOW_PLAYING;

        public ListPageViewModel()
        {
            Items = new ObservableCollection<ListPageItem>();

            LoadItemsCommand = new Command(async () => await ExecuteMoreItemsCommand());
            RefreshItemsCommand = new Command(async () => await ExecuteMoreItemsCommand());
            MoreItemsCommand = new Command<int>(async (reqValues) => await ExecuteMoreItemsCommand(reqValues));
        }

        async Task ExecuteMoreItemsCommand(int pageNumber = 1)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            IsLodingComplete = false;

            try
            {
                ObservableCollection<ListPageItem> result = null;
                if (CategoryManager.IsMovieCategory(SelectedCategoryType))
                {
                    result = await RequestMovieServer(pageNumber.ToString());
                }
                else if (CategoryManager.IsBooksCategory(SelectedCategoryType))
                {
                    result = await RequestBooksServer();
                }

                if (result != null)
                {
                    if (pageNumber == 1)
                    {
                        Items.Clear();
                    }
                    foreach (var item in result)
                    {
                        Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
                IsLodingComplete = true;
            }
        }

        async Task<ObservableCollection<ListPageItem>> RequestMovieServer(string pageNum)
        {
            ObservableCollection<ListPageItem> resultList = new ObservableCollection<ListPageItem>();

            List<results> list = null;
            switch (SelectedCategoryType)
            {
                case CategoryManager.TYPE_MOVIE_NOW_PLAYING:
                    {
                        var result = await NetworkManager.NowPlaying(pageNum);
                        list = result.results;
                        break;
                    }

                case CategoryManager.TYPE_MOVIE_UPCOMING:
                    {
                        var result = await NetworkManager.Upcoming(pageNum);
                        list = result.results;
                        break;
                    }
            }

            if (list == null)
            {
                return null;
            }

            foreach (var item in list)
            {
                resultList.Add(new ListPageItem
                {
                    Id = item.id,
                    Title = item.title,
                    Description = item.original_title,
                    Rank = item.vote_average,
                    SubDescription = String.Format("개봉일 : {0}", item.release_date),
                    ThumbUrl = "https://image.tmdb.org/t/p/w500/" + item.poster_path
                });
            }

            return resultList;
        }

        async Task<ObservableCollection<ListPageItem>> RequestBooksServer()
        {
            ObservableCollection<ListPageItem> resultList = new ObservableCollection<ListPageItem>();

            List<BookItem> list = null;
            switch (SelectedCategoryType)
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

            if (list == null)
            {
                return null;
            }

            foreach (var item in list)
            {
                resultList.Add(new ListPageItem
                {
                    Id = item.itemId.ToString(),
                    Title = item.title,
                    Description = item.author + " 저 / " + item.publisher,
                    Rank = item.customerReviewRank,
                    SubDescription = String.Format("판매가격 : {0:#,#}", item.priceSales),
                    ThumbUrl = item.coverSmallUrl,
                    NextPageUrl = item.mobileLink
                });
            }

            return resultList;
        }
    }
}


