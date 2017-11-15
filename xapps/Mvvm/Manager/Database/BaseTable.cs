using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace xapps
{
    public class BaseTable<T> where T : BaseItem, new()
    {
        
        SQLiteConnection Connection;
        protected BaseTable(SQLiteConnection conn)
        {
            Connection = conn;
        }

        public void CreateTable(CreateFlags createFlag = CreateFlags.None)
        {
            lock (collisionLock)
            {
                Connection.CreateTable<T>(createFlag);
            }
        }

        public long GetSize()
        {
            return SQLite.GetSize(DatabaseName);
        }

        public long SaveItem(T item)
        {
            lock (collisionLock)
            {
                var id = item.ID;
                if (id != 0)
                {
                    Connection.Update(item);
                    return id;
                }
                else
                {
                    return Connection.Insert(item);
                }
            }
        }

        public void SaveAllItem(List<T> list)
        {
            lock (collisionLock)
            {
                foreach (var item in list)
                {
                    var id = ((BaseItem)(object)item).ID;
                    if (id != 0)
                    {
                        Connection.Update(item);
                    }
                    else
                    {
                        Connection.Insert(item);
                    }
                }
            }
        }

        public void ExecuteQuery(string query, object[] args)
        {
            lock (collisionLock)
            {
                Connection.Execute(query, args);
            }
        }

        public List<T> Query(string query, params object[] args)
        {
            lock (collisionLock)
            {
                return Connection.Query<T>(query, args);
            }
        }

        // Item의 ID에 해당하는 값을 반환한다.
        public T GetItem(long id)
        {
            lock (collisionLock)
            {
                return Connection.Get<T>(id);
            }
        }

        public List<T> GetItems()
        {
            lock (collisionLock)
            {
                return (from i in Connection.Table<T>() select i).ToList();
            }
        }

        public int DeleteItem(int id)
        {
            lock (collisionLock)
            {
                return Connection.Delete<T>(id);
            }
        }

        public int DeleteAll()
        {
            lock (collisionLock)
            {
                return Connection.DeleteAll<T>();
            }
        }
    }
}
