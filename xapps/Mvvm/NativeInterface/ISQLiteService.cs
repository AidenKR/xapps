using System;
using SQLite;

namespace xapps.Mvvm.NativeInterface
{
    public interface ISQLiteService
    {
        SQLiteConnection GetConnection(string databaseName);
        long GetSize(string databaseName);
    }
}