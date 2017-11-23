using System;
namespace xapps
{
    public static class CategoryManager
    {
        public const int TYPE_MOVIE = 0x10000000; //
        public const int TYPE_MOVIE_NOW_PLAYING = 0x10000001; // 현재 상영중
        public const int TYPE_MOVIE_UPCOMING = 0x10000002; // 개봉 예정 중

        public const int TYPE_BOOKS = 0x20000000; //
        public const int TYPE_BOOKS_BEST_SELLER = 0x20000001; // best seller
        public const int TYPE_BOOKS_NEW_BOOK = 0x20000002; // 신작
        public const int TYPE_BOOKS_RECOMMEND = 0x20000004; // 추천

        public static bool IsMovieCategory(int category)
        {
            return (category & TYPE_MOVIE) != 0;
        }

        public static bool IsBooksCategory(int category)
        {
            return (category & TYPE_BOOKS) != 0;
        }
    }
}
