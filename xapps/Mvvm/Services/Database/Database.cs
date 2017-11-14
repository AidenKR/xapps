using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using xapps.Mvvm.Model.Database;
using xapps.Mvvm.Model.Database.FavoriteItem;
using xapps.Mvvm.NativeInterface;

namespace xapps.Mvvm.Services.Database
{
    public class Database
    {
        static object collisionLock = new object();
        ISQLiteService SQLite
        {
            get
            {
                return DependencyService.Get<ISQLiteService>();
            }
        }
        readonly SQLiteConnection connection;
        readonly string DatabaseName;

        public Database(string databaseName)
        {
            DatabaseName = databaseName;
            connection = SQLite.GetConnection(DatabaseName);
        }

        public void CreateTable<T>()
        {
            lock (collisionLock)
            {
                connection.CreateTable<T>();
            }
        }

        public long GetSize()
        {
            return SQLite.GetSize(DatabaseName);
        }

        public List<FavoriteItem> getFilteredMovieId(string movieId)
        {
            lock (collisionLock)
            {
                var query = from FavoriteItem in connection.Table<FavoriteItem>() 
                            where FavoriteItem.movieId == movieId 
                            select FavoriteItem;
                return query.AsEnumerable().ToList();
            }
        }

        public List<FavoriteItem> getAllDBItem() {
            lock (collisionLock)
            {
                var query = from FavoriteItem in connection.Table<FavoriteItem>()
                            where FavoriteItem.movieId != null
                            select FavoriteItem;
                return query.AsEnumerable().ToList();
            }
        }

        public int SaveItem<T>(T item)
        {
            lock (collisionLock)
            {
                var id = ((BaseItem)(object)item).ID;
                if (id != 0)
                {
                    connection.Update(item);
                    return id;
                }
                else
                {
                    return connection.Insert(item);
                }
            }
        }

        public void SaveAllItem<T>(List<T> list)
        {
            lock (collisionLock)
            {
                foreach (var item in list)
                {
                    var id = ((BaseItem)(object)item).ID;
                    if (id != 0)
                    {
                        connection.Update(item);
                    }
                    else
                    {
                        connection.Insert(item);
                    }
                }
            }
        }

        public void ExecuteQuery(string query, object[] args)
        {
            lock (collisionLock)
            {
                connection.Execute(query, args);
            }
        }

        public List<T> Query<T>(string query, object[] args) where T : new()
        {
            lock (collisionLock)
            {
                return connection.Query<T>(query, args);
            }
        }

        public IEnumerable<T> GetItems<T>() where T : new()
        {
            lock (collisionLock)
            {
                return (from i in connection.Table<T>() select i).ToList();
            }
        }

        public int DeleteItem<T>(int id)
        {
            lock (collisionLock)
            {
                return connection.Delete<T>(id);
            }
        }

        public int DeleteAll<T>()
        {
            lock (collisionLock)
            {
                return connection.DeleteAll<T>();
            }
        }
    }
}
