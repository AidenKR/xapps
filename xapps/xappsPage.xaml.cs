using Xamarin.Forms;

namespace xapps
{
    public partial class xappsPage : ContentPage
    {
        public xappsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing() {
            base.OnAppearing();

            await App.netManager.requestMovieList();
            await App.netManager.requestMovieDetail("20161725");
        }
    }
}
