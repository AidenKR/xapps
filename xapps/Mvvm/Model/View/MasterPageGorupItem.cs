using System;
using System.Collections.ObjectModel;

namespace xapps
{
    public class MasterPageGorupItem : ObservableCollection<MasterPageItem>
    {
        public string GroupTitle { get; set; }
        public string GroupIcon { get; set; }
        public bool IsExpanded { get; set; } = false;

        public static ObservableCollection<MasterPageGorupItem> All { private set; get; }

        public MasterPageGorupItem(string title, string icon, bool isExpanded = true)
        {
            GroupTitle = title;
            GroupIcon = icon;
            IsExpanded = isExpanded;
        }

        static MasterPageGorupItem()
        {
            ObservableCollection<MasterPageGorupItem> Groups = new ObservableCollection<MasterPageGorupItem>
            {
                new MasterPageGorupItem("영화","icon_movie.png")
                {
                    new MasterPageItem { Title = "메인화면", TargetType = typeof(HomePage) },
                    new MasterPageItem { Title = "즐겨찾기", TargetType = typeof(FavoritePage) },
                },
                new MasterPageGorupItem("도서","icon_books.png")
                {
                    new MasterPageItem { Title = "메인화면", TargetType = typeof(BooksHomePage) },
                },
                new MasterPageGorupItem("테스트","icon_test.png", false)
                {
                    new MasterPageItem { Title = "웹뷰 연동", TargetType = typeof(WebviewPage) },
                    new MasterPageItem { Title = "테스트 페이지", TargetType = typeof(TestingPage) },
                    new MasterPageItem { Title = "음악 재생", TargetType = typeof(MusicServicePage) },
                }
            };

            All = Groups;
        }
    }
}
