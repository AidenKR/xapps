using System;
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
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
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
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                return result;
            }
        }

        public int InsertItem(T item)
        {
            lock (TableLock)
            {
                int result = -1;
                try
                {
                    result = connection.Insert(item);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                return result;
            }
        }

        public int InsertOrUpdate(T item)
        {
            lock (TableLock)
            {
                int result = -1;
                try
                {
                    result = connection.InsertOrReplace(item);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                return result;
            }
        }

        public int InsertAllITem(List<T> list)
        {
            lock (TableLock)
            {
                int result = -1;
                try
                {
                    result = connection.InsertAll(list);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                return result;
            }
        }

        public void InsertOrUpdateAll(List<T> list)
        {
            lock (TableLock)
            {
                try
                {
                    foreach (var item in list)
                    {
                        connection.InsertOrReplace(item);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
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
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
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
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                return result;
            }
        }

        public T GetItem(Object pk)
        {
            lock (TableLock)
            {
                T result = null;
                try
                {
                    result = connection.Get<T>(pk);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
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
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                return result;
            }
        }

        public int DeleteItem(Object pk)
        {
            lock (TableLock)
            {
                int result = -1;
                try
                {
                    result = connection.Delete<T>(pk);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
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
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                return result;
            }
        }
    }
}
