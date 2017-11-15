using SQLite;
using Xamarin.Forms;

namespace xapps
{
    public class Database
    {
        static readonly object Lock = new object();
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

        public long GetSize()
        {
            return SQLite.GetSize(DatabaseName);
        }

        public TableConnector<T> GetTable<T>() where T : BaseItem, new()
        {
            lock (Lock)
            {
                TableConnector<T> conn = new TableConnector<T>(connection);
                return conn;
            }
        }
    }
}
