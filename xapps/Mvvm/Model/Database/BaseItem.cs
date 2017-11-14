using System;
using SQLite;

namespace xapps
{
    public class BaseItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
