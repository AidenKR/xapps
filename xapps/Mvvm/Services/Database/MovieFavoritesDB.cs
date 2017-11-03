using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using xapps.DatabaseHelper.Model;

namespace xapps.DatabaseHelper
{

    /**
     * MovieFavorites Table Create, insert, update, delete
     * DataBase Control
     * by 한수현.
     */
    public class MovieFavoritesDB
    {
        readonly SQLiteAsyncConnection mDB;

        /**
         * create.
         */
        public MovieFavoritesDB(string dbPath)
        {
            mDB = new SQLiteAsyncConnection(dbPath);
            mDB.CreateTableAsync<MovieFavoritesDataItem>().Wait();
        }

        /**
         * insert.
         */
        public Task<int> InsertItemAsync(MovieFavoritesDataItem item)
        {
            return mDB.InsertAsync(item);
        }

        /**
         * update.
         */
        public Task<int> UpdateItemAsync(MovieFavoritesDataItem item)
        {
            return mDB.UpdateAsync(item);
        }

        /**
         * delete.
         */
        public Task<int> DeleteItemAsync(MovieFavoritesDataItem item)
        {
            return mDB.DeleteAsync(item);
        }

        /**
         * select.
         */
        private Task<List<MovieFavoritesDataItem>> GetItemsQuery(string query)
        {
            return mDB.QueryAsync<MovieFavoritesDataItem>(query);
        }

        /**
         * select where.
         */
        private Task<List<MovieFavoritesDataItem>> GetItemsSelect(string where)
        {
            return GetItemsQuery("SELECT * FROM [" + MovieFavoritesDataItem.getClassName() + "] WHERE " + where);
        }

        /**
         * select all.
         */
        public Task<List<MovieFavoritesDataItem>> GetItemsAsync()
        {
            return mDB.Table<MovieFavoritesDataItem>().ToListAsync();
        }
    }
}
