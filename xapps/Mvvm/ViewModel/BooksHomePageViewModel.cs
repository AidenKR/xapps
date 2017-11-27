using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xapps
{
    public class BooksHomePageViewModel : BaseViewModel
    {
        public ObservableCollection<BookItem> BooksItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        // selected Category index
        public int SelectBooksCategoryType = CategoryManager.TYPE_BOOKS_BEST_SELLER;

        public BooksHomePageViewModel()
        {
            Title = "XAPPS";
            BooksItems = new ObservableCollection<BookItem>();

            LoadItemsCommand = new Command<int>(async (requestType) => await ExecuteLoadItemsCommand(requestType));
        }

        async Task ExecuteLoadItemsCommand(int requestType)
        {
            Debug.WriteLine("ExecuteLoadItemsCommand() requestType = {0}", requestType);

            try
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
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
