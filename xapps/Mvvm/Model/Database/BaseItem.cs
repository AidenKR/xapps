using System;
using SQLite;

namespace xapps.Mvvm.Model.Database
{
    public class BaseItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
