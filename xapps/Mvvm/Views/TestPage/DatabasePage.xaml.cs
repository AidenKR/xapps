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
            var item = new FavoriteItem
            {
                movieId = "id0",
                favoriteYN = true,
                original_title = "original_title 0",
                title = "title 0"
            };
            var result = DatabaseManager.Instance.GetTable<FavoriteItem>().InsertItem(item);
            Debug.WriteLine("Favorite save item result = {0}", result);
        }

        void OnSelectClicked(object sender, System.EventArgs e)
        {
            FavoriteItem item = DatabaseManager.Instance.GetTable<FavoriteItem>().GetItem("id0");
            Debug.WriteLine("Favorite item: " + item);
        }

        void OnDeleteClicked(object sender, System.EventArgs e)
        {
            int result = DatabaseManager.Instance.GetTable<FavoriteItem>().DeleteItem("id0");
            Debug.WriteLine("Favorite Delete result: " + result);
        }

        void OnInsertAllClicked(object sender, System.EventArgs e)
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
                list.Add(item);
            }

            int result = DatabaseManager.Instance.GetTable<FavoriteItem>().InsertAllITem(list);
            Debug.WriteLine("Favorite Insert All result: " + result);
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
