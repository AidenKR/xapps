using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public partial class DetailPage : ContentPage, CustomTabInterface
    {
        private DetailPageViewModel viewModel;
        private string mRequestId;
        FavoriteItem item;

        public DetailPage(string reqId)
        {
            InitializeComponent();

            mRequestId = reqId;
            printLog("reqServerData reqId : " + mRequestId);

            BindingContext = viewModel = new DetailPageViewModel(mRequestId);
            initView();
        }

        private void initView()
        {
            // TAB
            setTabBar(mdpTab);

            // favorite item
            setWishListButton();
        }

        private void setTabBar(StackLayout layout)
        {
            List<string> arrTabs = new List<string> { "평점", "포토/트레일러", "감독/배우" };
            Color[] arrTextColor = { Color.Aqua , Color.BlueViolet, Color.Red };
            CustomTabCellLayoutData tabLayout = new CustomTabCellLayoutData
            {
                selColor = Color.FromHex("#F7D358"),
                norColor = Color.FromHex("#F5ECCE"),
                selTextColors = arrTextColor,
                selTextFontSize = 20.0
            };

            mdpTab.makeTabLayout(arrTabs, tabLayout);
        }

        void onClickFullMoviePage(object sender, System.EventArgs e)
        {
            var url = DependencyService.Get<IMovieUrl>();
            if (url != null)
            {
                url.MovieUrl("http://sites.google.com/site/ubiaccessmobile/sample_video.mp4");
            }
            //await Navigation.PushAsync(new PreviewPage());
            MoviePreviewRenderer.IsVisible = true;
        }

        void onClickMovieStoryMore(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            bool btnVisible = btn.IsVisible;

            mdpMovieInfoBtnMore.IsVisible = false;
            mdpMovieInfoTvStory.LineBreakMode = LineBreakMode.WordWrap;
        }

        private void printLog(string msg)
        {
            Debug.WriteLine("################### " + msg);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.DetailItem == null)
                viewModel.LoadItemsCommand.Execute(mRequestId);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        public void onClickTabButton(int index)
        {
            // Event
            printLog("onClickTabButton() index : " + index);
        }

        void onClickButton(object sender, System.EventArgs e)
        {
            var button = sender as Button;

            if (mdpShareBtnWishList.Equals(button))
            {
                // 위시리스트
                checkWishList();
            }
            else if (mdpShareBtnShare.Equals(button))
            {
                // 같이볼래
                showToastPopup("같이볼래");
            }
            else if (mdpShareBtnNowTicketing.Equals(button))
            {
                // 지금예매
                showToastPopup("지금예매");
            }
        }

        private bool checkWishList()
        {
            bool returnValue = false;

            // db 에서 해당 key값의 아이탬을 가져온다.
            item = DatabaseManager.Instance.GetTable<FavoriteItem>().GetItem(mRequestId);

            // 해당 key값이 위시리스트에 존재하는가?
            if (null == item)
            {
                // 위시리스트 에 미등록됨
                // 추가
                addFavorite();
            }
            else
            {
                // 위시리스트 에 등록되어 있다. 
                // 제거
                delFavorite(item.movieId);
            }

            return returnValue;
        }

        private void addFavorite()
        {
            FavoriteItem addItem = new FavoriteItem();
            addItem.movieId = viewModel.DetailItem.id;
            addItem.favoriteYN = true;
            addItem.title = viewModel.DetailItem.title;
            addItem.original_title = viewModel.DetailItem.original_title;
            addItem.poster_path = viewModel.DetailItem.poster_path;
            addItem.vote_average = viewModel.DetailItem.vote_average;
            addItem.release_date = viewModel.DetailItem.release_date;
            DatabaseManager.Instance.GetTable<FavoriteItem>().InsertItem(addItem);

            // ui
            mdpShareBtnWishList.Image.File = "img_wishlist_p.png";
            showToastPopup("즐겨찾기 목록에 '" + viewModel.DetailItem.title + "' 항목을 추가 했습니다.");
        }
        private void delFavorite(string key)
        {
            DatabaseManager.Instance.GetTable<FavoriteItem>().DeleteItem(key);

            // ui
            mdpShareBtnWishList.Image.File = "img_wishlist.png";
            showToastPopup("즐겨찾기 목록에서 '" + viewModel.DetailItem.title + "' 항목을 제거 했습니다.");
        }
        private void setWishListButton()
        {
            item = DatabaseManager.Instance.GetTable<FavoriteItem>().GetItem(mRequestId);
            if (null == item)
            {
                mdpShareBtnWishList.Image.File = "img_wishlist.png";
            }
            else
            {
                mdpShareBtnWishList.Image.File = "img_wishlist_p.png";
            }
        }

        /**
         * 토스트 팝업.
         */
        void showToastPopup(string msg)
        {
            var toast = DependencyService.Get<IToastAlert>();
            if (null != toast)
            {
                toast.showToast(msg, false);
            }
        }
    }
}
