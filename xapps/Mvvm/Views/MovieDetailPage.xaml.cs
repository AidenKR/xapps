using System;
using Xamarin.Forms;

namespace xapps
{
    public partial class MovieDetailPage : ContentPage
    {
        MovieData mData;
        //public ObservableCollection<PerformerData> mlistData { get; set; }

        public MovieDetailPage(MovieData item)
        {
            InitializeComponent();

            mData = item;
            initView();
            initData();
        }

        private void initView()
        {
            mdpMovieImageIvPoster.Source = null;
            mdpMovieImageIvBg.Source = null;
        }

        private void initData()
        {
            // set item
            string urlPoster = mData.posters;
            string urlBg = mData.posters;
            string txtMovieTitle = mData.title;
            string txtMovieDesc = mData.runtime + "분 * " + mData.genre;
            if (!string.IsNullOrWhiteSpace(mData.rating)) {
                txtMovieDesc += " * " + mData.rating;
            }
            string txtMovieStory = mData.plot;
            string stateNowPlaying = getNowPlayState(mData.repRlsDate);
            string txtNowPlayingAdvanceRate = "25.5%";
            string txtNowPlayingReleaseDate = string.IsNullOrWhiteSpace(mData.repRlsDate) ? "개봉 미정" : mData.repRlsDate + " 개봉";

            // set view
            setImage(mdpMovieImageIvPoster, urlPoster);
            setImage(mdpMovieImageIvBg, urlBg);

            mdpNowPlayingTvState.Text = stateNowPlaying;
            mdpNowPlayingTvAdvanceRate.Text = txtNowPlayingAdvanceRate;
            mdpNowPlayingTvReleaseDate.Text = txtNowPlayingReleaseDate;

            mdpMovieInfoTvTitle.Text = txtMovieTitle;
            mdpMovieInfoTvDesc.Text = txtMovieDesc;
            mdpMovieInfoTvStory.Text = txtMovieStory;

            //setPerformerListData();
        }

        void onClickMovieStoryMore(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            bool btnVisible = btn.IsVisible;

            mdpMovieInfoBtnMore.IsVisible = false;
            mdpMovieInfoTvStory.LineBreakMode = LineBreakMode.WordWrap;
        }

        private string getNowPlayState(string date) {
            // 2011-07-13
            if (string.IsNullOrWhiteSpace(date)) {
                return "개봉 미정";
            }

            return "현재상영중";
        }

        private void setImage(Image img, string url)
        {
            if (string.IsNullOrWhiteSpace(url)) {
                return;
            }

            img.Source = ImageManager.getImageFromUrl(url).Source;
        }

        //private void setPerformerListData()
        //{
        //    mlistData = new ObservableCollection<PerformerData>();
        //    mdpListView.ItemTemplate = new DataTemplate(typeof(CustomVeggieCell));

        //    // 감독
        //    List<director> arrDirectors = mData.directors;
        //    foreach (director dName in arrDirectors)
        //    {
        //        mlistData.Add(new PerformerData() { name = dName.directorNm, role = "감독" });
        //    }

        //    // 출연 배우
        //    List<actor> arrActors = mData.actors;
        //    foreach (actor aName in arrActors)
        //    {
        //        mlistData.Add(new PerformerData() { name = aName.actorNm, role = "배우" });
        //    }

        //    // 스태프
        //    List<staff> arrStaffs = mData.staffs;
        //    foreach (staff sName in arrStaffs)
        //    {
        //        mlistData.Add(new PerformerData() { name = sName.staffNm, role = sName.staffRole });
        //    }

        //    mdpListView.ItemsSource = mlistData;
        //    Content = mdpListView;
        //}

        //public class CustomVeggieCell : ViewCell {
        //    public CustomVeggieCell() {
        //        var name = new Label();
        //        var role = new Label();
        //        var verticaLayout = new StackLayout();
        //        var horizontalLayout = new StackLayout() { BackgroundColor = Color.Olive };

        //        name.SetBinding(Label.TextProperty, new Binding("name"));
        //        role.SetBinding(Label.TextProperty, new Binding("role"));

        //        horizontalLayout.Orientation = StackOrientation.Horizontal;
        //        horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
        //        role.HorizontalOptions = LayoutOptions.End;
        //        name.FontSize = 24;

        //        verticaLayout.Children.Add(name);
        //        horizontalLayout.Children.Add(verticaLayout);
        //        horizontalLayout.Children.Add(role);

        //        View = horizontalLayout;
        //    }
        //}
    }
}
