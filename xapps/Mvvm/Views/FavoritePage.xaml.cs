using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xapps
{
    public partial class FavoritePage : ContentPage
    {
        //MovieFavoritesDB favoriteDb;
        public ObservableCollection<FavoriteViewModel> favorite { get; set; }

        public FavoritePage()
        {
            InitializeComponent();

            //favoriteDb = new MovieFavoritesDB(DependencyService.Get<IDBFilePath>().GetLocalFilePath(DatabaseConsts.DataBaseFileFullName));

            favorite = new ObservableCollection<FavoriteViewModel>();
            favorite.Add(new FavoriteViewModel { Name = "Tomato", Type = "Fruit", Image = "" , url = "http://i.imgur.com/2PBLK.jpg"});
            favorite.Add(new FavoriteViewModel { Name = "Romaine Lettuce", Type = "Vegetable", Image = "", url = "http://cfile26.uf.tistory.com/image/2463694C53D0A5D80629B3" });
            favorite.Add(new FavoriteViewModel { Name = "Zucchini", Type = "Vegetable", Image = "", url = "http://cfs10.blog.daum.net/original/10/blog/2007/12/01/20/58/47514c5e8e6a8&filename=34851.jpg" });

            favorite.Add(new FavoriteViewModel { Name = "Tomato", Type = "Fruit", Image = "", url = "http://i.imgur.com/2PBLK.jpg" });
            favorite.Add(new FavoriteViewModel { Name = "Romaine Lettuce", Type = "Vegetable", Image = "", url = "http://cfile26.uf.tistory.com/image/2463694C53D0A5D80629B3" });
            favorite.Add(new FavoriteViewModel { Name = "Zucchini", Type = "Vegetable", Image = "", url = "http://cfs10.blog.daum.net/original/10/blog/2007/12/01/20/58/47514c5e8e6a8&filename=34851.jpg" });

            favorite.Add(new FavoriteViewModel { Name = "Tomato", Type = "Fruit", Image = "", url = "http://i.imgur.com/2PBLK.jpg" });
            favorite.Add(new FavoriteViewModel { Name = "Romaine Lettuce", Type = "Vegetable", Image = "", url = "http://cfile26.uf.tistory.com/image/2463694C53D0A5D80629B3" });
            favorite.Add(new FavoriteViewModel { Name = "Zucchini", Type = "Vegetable", Image = "", url = "http://cfs10.blog.daum.net/original/10/blog/2007/12/01/20/58/47514c5e8e6a8&filename=34851.jpg" });

            favorite.Add(new FavoriteViewModel { Name = "Tomato", Type = "Fruit", Image = "", url = "http://i.imgur.com/2PBLK.jpg" });
            favorite.Add(new FavoriteViewModel { Name = "Romaine Lettuce", Type = "Vegetable", Image = "", url = "http://cfile26.uf.tistory.com/image/2463694C53D0A5D80629B3" });
            favorite.Add(new FavoriteViewModel { Name = "Zucchini", Type = "Vegetable", Image = "", url = "http://cfs10.blog.daum.net/original/10/blog/2007/12/01/20/58/47514c5e8e6a8&filename=34851.jpg" });

            favorite.Add(new FavoriteViewModel { Name = "Tomato", Type = "Fruit", Image = "", url = "http://i.imgur.com/2PBLK.jpg" });
            favorite.Add(new FavoriteViewModel { Name = "Romaine Lettuce", Type = "Vegetable", Image = "", url = "http://cfile26.uf.tistory.com/image/2463694C53D0A5D80629B3" });
            favorite.Add(new FavoriteViewModel { Name = "Zucchini", Type = "Vegetable", Image = "", url = "http://cfs10.blog.daum.net/original/10/blog/2007/12/01/20/58/47514c5e8e6a8&filename=34851.jpg" });

            favoriteListView.ItemsSource = favorite;

            //favoriteListView.ItemAppearing += (sender, e) =>
            //{
            //    Debug.WriteLine("ItemAppearing....");
            //};
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Debug.WriteLine("clicked delete button");
        }

        // show list item
        void Handle_ItemAppearing(object sender, Xamarin.Forms.ItemVisibilityEventArgs e)
        {
            Debug.WriteLine("appearing item");
        }
    }

    public class FavoriteViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public string url { get; set; }
    }
}
