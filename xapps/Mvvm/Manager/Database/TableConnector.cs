using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SQLite;

namespace xapps
{
    public class TableConnector<T> where T : BaseItem, new()
    {
        static readonly object TableLock = new object();

        readonly SQLiteConnection connection;

        public TableConnector(SQLiteConnection conn)
        {
            connection = conn;
        }

        public int CreateTable(CreateFlags createFlag = CreateFlags.None)
        {
            lock (TableLock)
            {
                int result = -1;
                try
                {
                    result = connection.CreateTable<T>(createFlag);
                }
                catch (SQLiteException SQLe)
                {
                    Debug.WriteLine(SQLe.Message);
                }
                return result;
            }
        }

        public int DropTable()
        {
            lock (TableLock)
            {
                int result = -1;
                try
                {
                    result = connection.DropTable<T>();
                }
                catch (SQLiteException SQLe)
                {
                    Debug.WriteLine(SQLe.Message);
                }
                return result;
            }
        }

        public long SaveItem(T item)
        {
            lock (TableLock)
            {
                long result = -1;
                try
                {
                    long id = item.ID;
                    if (id != 0)
                    {
                        connection.Update(item);
                        result = id;
                    }
                    else
                    {
                        result = connection.Insert(item);
                    }
                }
                catch (SQLiteException SQLe)
                {
                    Debug.WriteLine(SQLe.Message);
                }
                return result;
            }
        }

        public void SaveAllItem(List<T> list)
        {
            lock (TableLock)
            {
                try
                {
                    foreach (var item in list)
                    {
                        var id = item.ID;
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
                catch (SQLiteException SQLe)
                {
                    Debug.WriteLine(SQLe.Message);
                }
            }
        }

        public int ExecuteQuery(string query, object[] args)
        {
            lock (TableLock)
            {
                int result = -1;
                try
                {
                    result = connection.Execute(query, args);
                }
                catch (SQLiteException SQLe)
                {
                    Debug.WriteLine(SQLe.Message);
                }
                return result;
            }
        }

        public List<T> Query(string query, params object[] args)
        {
            lock (TableLock)
            {
                List<T> result = null;
                try
                {
                    result = connection.Query<T>(query, args);
                }
                catch (SQLiteException SQLe)
                {
                    Debug.WriteLine(SQLe.Message);
                }
                return result;
            }
        }

        public T GetItem(long id)
        {
            lock (TableLock)
            {
                T result = null;
                try
                {
                    result = connection.Get<T>(id);
                }
                catch (SQLiteException SQLe)
                {
                    Debug.WriteLine(SQLe.Message);
                }
                return result;
            }
        }

        public List<T> GetItems()
        {
            lock (TableLock)
            {
                List<T> result = null;
                try
                {
                    result = (from i in connection.Table<T>() select i).ToList();
                }
                catch (SQLiteException SQLe)
                {
                    Debug.WriteLine(SQLe.Message);
                }
                return result;
            }
        }

        public int DeleteItem(int id)
        {
            lock (TableLock)
            {
                int result = -1;
                try
                {
                    result = connection.Delete<T>(id);
                }
                catch (SQLiteException SQLe)
                {
                    Debug.WriteLine(SQLe.Message);
                }
                return result;
            }
        }

        public int DeleteAll()
        {
            lock (TableLock)
            {
                int result = -1;
                try
                {
                    result = connection.DeleteAll<T>();
                }
                catch (SQLiteException SQLe)
                {
                    Debug.WriteLine(SQLe.Message);
                }
                return result;
            }
        }
    }
}
