using SQLite;

namespace xapps
{
    /**
     * MovieFavorites 관련 데이터객체
     * DataItem
     * by 한수현.
     */
    public struct MovieFavoritesDataItem
    {
        [PrimaryKey, AutoIncrement]
        public int IDX { get; set; }

        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }
        public string Column5 { get; set; }
        public string Column6 { get; set; }
        public string Column7 { get; set; }
        public string Column8 { get; set; }
        public string Column9 { get; set; }

        public static string getClassName()
        {
            return "MovieFavoritesDataItem";
        }
    }
}
