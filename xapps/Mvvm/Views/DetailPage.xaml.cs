using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public partial class DetailPage : ContentPage
    {
        private DetailPageViewModel viewModel;
        private string mRequestId;

        //public ObservableCollection<PerformerData> mlistData { get; set; }

        public DetailPage(String reqId)
        {
            InitializeComponent();

            mRequestId = reqId;
            printLog("reqServerData reqId : " + mRequestId);

            BindingContext = viewModel = new DetailPageViewModel(mRequestId);
            initView();
        }

        private void initView()
        {
        }

        async void onClickFullMoviePage(object sender, System.EventArgs e)
        {
            var url = DependencyService.Get<IMovieUrl>();
            if (url != null)
            {
                url.MovieUrl("http://sites.google.com/site/ubiaccessmobile/sample_video.mp4");
            }
            await Navigation.PushAsync(new PreviewPage());
        }

        void onClickMovieStoryMore(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            bool btnVisible = btn.IsVisible;

            mdpMovieInfoBtnMore.IsVisible = false;
            mdpMovieInfoTvStory.LineBreakMode = LineBreakMode.WordWrap;
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

    }
}
