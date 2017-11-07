using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace xapps
{
    public partial class FavoritePage : ContentPage
    {
        public ObservableCollection<FavoriteViewModel> veggies { get; set; }

        public FavoritePage()
        {
            InitializeComponent();

            veggies = new ObservableCollection<FavoriteViewModel>();


            veggies.Add(new FavoriteViewModel { Name = "Tomato", Type = "Fruit", Image = "" });
            veggies.Add(new FavoriteViewModel { Name = "Romaine Lettuce", Type = "Vegetable", Image = "" });
            veggies.Add(new FavoriteViewModel { Name = "Zucchini", Type = "Vegetable", Image = "" });
            lstView.ItemsSource = veggies;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }

        // show list item
        void Handle_ItemAppearing(object sender, Xamarin.Forms.ItemVisibilityEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public class FavoriteViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
    }
}
