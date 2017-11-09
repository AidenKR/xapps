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
    public partial class MusicServicePage : ContentPage
    {
        public MusicServicePage()
        {
            InitializeComponent();
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
        }

        void MusicBntPlayClicked(object sender, System.EventArgs e)
        {
            var play = DependencyService.Get<IBackgroundService>();
            if (play != null)
            {
                play.startBackgroundService();
            }
        }

        void MusicBntStopClicked(object sender, System.EventArgs e)
        {
            var stop = DependencyService.Get<IBackgroundService>();
            if (stop != null)
            {
                stop.stopBackgroundService();
            }
        }
    }
}