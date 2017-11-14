using System;
using SQLite;

namespace xapps.Mvvm.Model.Database.FavoriteItem
{
    public class FavoriteItem : BaseItem
    {
        public string movieId { get; set; }
        public bool favoriteYN { get; set; }
        public string title { get; set; }
        public string original_title { get; set; }
        public string poster_path { get; set; }
        public string vote_average { get; set; }
        public string release_date { get; set; }
        public override string ToString()
        {
            return $"{ID}, {movieId}, {favoriteYN}, {title}, {original_title}, {poster_path}, {vote_average}, {release_date}";
        }
    }
}
