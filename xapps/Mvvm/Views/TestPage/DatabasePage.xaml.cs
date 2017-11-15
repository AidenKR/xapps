using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public partial class DatabasePage : ContentPage
    {
        public DatabasePage()
        {
            InitializeComponent();
        }

        void OnCreateClicked(object sender, System.EventArgs e)
        {
            var result = DatabaseManager.Instance.GetTable<FavoriteItem>().CreateTable();
            Debug.WriteLine("Create Table : result = " + result);
        }

        void OnDropClicked(object sender, System.EventArgs e)
        {
            var result = DatabaseManager.Instance.GetTable<FavoriteItem>().DropTable();
            Debug.WriteLine("Drop Table : result = " + result);
        }

        void OnInsertClicked(object sender, System.EventArgs e)
        {
            List<FavoriteItem> list = new List<FavoriteItem>();
            for (int i = 0; i < 20; i++)
            {
                var item = new FavoriteItem
                {
                    movieId = "id" + i,
                    favoriteYN = true,
                    original_title = "original_title " + i,
                    title = "title" + i
                };
                var result = DatabaseManager.Instance.GetTable<FavoriteItem>().SaveItem(item);
                Debug.WriteLine("save item index {0}: result = {1}", i,result);
            }
        }

        void OnSelectAllClicked(object sender, System.EventArgs e)
        {
            var list = DatabaseManager.Instance.GetTable<FavoriteItem>().GetItems();
            Debug.WriteLine("Favorite list count: " + list.Count);

            foreach (FavoriteItem item in list)
                Debug.WriteLine("Favorite : " + item);

        }

        void OnDeleteAllClicked(object sender, System.EventArgs e)
        {
            var result = DatabaseManager.Instance.GetTable<FavoriteItem>().DeleteAll();
            Debug.WriteLine("Delete All : result = " + result);
        }
    }
}
