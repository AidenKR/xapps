using Xamarin.Forms;

namespace xapps
{
    public partial class xappsPage : ContentPage
    {
        public xappsPage()
        {
            InitializeComponent();

            // reqeust data with netManager( get method )
            App.netManager.requestMovieList();
            App.netManager.requestMovieDetail("20161725");
        }
    }
}
