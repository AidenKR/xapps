using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace xapps
{
    public class DatabaseManager
    {
        const string DatabaseName = "xappsDB.db3";


        static Database database;
        DatabaseManager(string databaseName)
        {
            database = new Database(databaseName);

            CreateTable();
        }

        private void CreateTable()
        {
            database.GetTable<FavoriteItem>();
        }

        static DatabaseManager instance;
        public static DatabaseManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseManager(DatabaseName);
                }
                return instance;
            }
        }

        /// <summary>
        /// Table에 사용된 Class를 전달하여 사용한다.
        /// 이후 TableConnector에서 제공되는 API를 통하여 기능을처리한다.
        /// </summary>
        /// <returns>The table.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public TableConnector<T> GetTable<T>() where T : BaseItem, new()
        {
            return database.GetTable<T>();
        }

        /// <summary>
        /// Gets the favorite item by movie identifier.
        /// </summary>
        /// <returns>The favorite item by movie identifier.</returns>
        /// <param name="movieId">Movie identifier.</param>
        public FavoriteItem GetFavoriteItemByMovieID(string movieId) {
            string query = "SELECT * FROM FavoriteItem WHERE movieId = '" + movieId + "'";
            List<FavoriteItem> items = database.GetTable<FavoriteItem>().Query(query, new object[] {"*"});
            if (null == items || 0 >= items.Count) {
                return null;
            }

            return items[0];
        }

    }
}
