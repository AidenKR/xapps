using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xapps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviePreviewPage : ContentPage
    {
        public MoviePreviewPage()
        {
            //InitializeComponent();
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            // 기본 설정을 Landscape로 셋팅.

            WidthRequest = App.ScreenWidth;
            HeightRequest = App.ScreenHeight;

            base.LayoutChildren(x, y, width, height);
        }
    }
}