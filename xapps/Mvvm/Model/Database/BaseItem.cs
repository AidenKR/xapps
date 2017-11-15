using System;
using SQLite;

namespace xapps
{
    public class BaseItem
    {
        [PrimaryKey, AutoIncrement]
        public long ID { get; set; }
    }
}
