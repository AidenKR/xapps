using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SQLite;
using xapps.Mvvm.Model.Database.FavoriteItem;
using System.IO;

namespace xapps.Mvvm.Services.Database.FavoriteDB
{
    public class FavoriteDB
    {
        SQLiteAsyncConnection favoriteDB;

        /**
         * create.
         */
        public FavoriteDB(string dbPath)
        {
            favoriteDB = new SQLiteAsyncConnection(dbPath);

            try {
                favoriteDB.CreateTableAsync<FavoriteItem>().Wait();            
            } catch (SQLiteException e) {
                Debug.WriteLine(e);
            }
        }

        /**
         * insert.
         */
        public Task<int> InsertItemAsync(FavoriteItem item)
        {
            return favoriteDB.InsertAsync(item);
        }

        /**
         * update.
         */
        public Task<int> UpdateItemAsync(FavoriteItem item)
        {
            return favoriteDB.UpdateAsync(item);
        }

        /**
         * delete.
         */
        public Task<int> DeleteItemAsync(FavoriteItem item)
        {
            return favoriteDB.DeleteAsync(item);
        }

        /**
         * select.
         */
        private Task<List<FavoriteItem>> GetItemsQuery(string query)
        {
            return favoriteDB.QueryAsync<FavoriteItem>(query);
        }

        /**
         * select where.
         */
        private Task<List<FavoriteItem>> GetItemsSelect(string where)
        {
            return GetItemsQuery("SELECT * FROM " + DatabaseConsts.FavoriteDBFileName + "] WHERE " + where);
        }

        /**
         * select all.
         */
        public Task<List<FavoriteItem>> GetItemsAsync()
        {
            return favoriteDB.Table<FavoriteItem>().ToListAsync();
        }

        public Task<List<FavoriteItem>> findFavoriteList() {
            try {
                return favoriteDB.QueryAsync<FavoriteItem>("SELECT * FROM FavoriteData WHERE favoriteYN = 1");            
            } catch( SQLiteException e) {
                Debug.WriteLine(e);
                return null;
            }
        }

        //public async static Task<bool> IsFileExistAsync(this string fileName, IFolder rootFolder = null)
        //{
        //    // get hold of the file system
        //    IFolder folder = rootFolder ?? FileSystem.Current.LocalStorage;
        //    ExistenceCheckResult folderexist = await folder.CheckExistsAsync(fileName);
        //    // already run at least once, don't overwrite what's there
        //    if (folderexist == ExistenceCheckResult.FileExists)
        //    {
        //        return true;

        //    }
        //    return false;
        //}
    }
}
