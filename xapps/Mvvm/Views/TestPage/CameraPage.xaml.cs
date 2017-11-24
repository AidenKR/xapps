using Plugin.Media;
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
    public partial class CameraPage : ContentPage
    {
        public CameraPage()
        {
            InitializeComponent();

            MediaCameraInit();
        }

        private async void MediaCameraInit()
        {
#if __IOS__
            // iOS 플랫폼
                        //Load an image as an overlay (this is in the iOS Project)
            Func<object> func = () =>
            {
                var imageView = new UIImageView(UIImage.FromBundle("icon.png"));
                imageView.ContentMode = UIViewContentMode.ScaleAspectFit;

                var screen = UIScreen.MainScreen.Bounds;
                imageView.Frame = screen;

                return imageView;
            };
#endif


            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            {
#if __IOS__
                OverlayViewProvider = func
#endif
                SaveToAlbum = true
            });

            if (photo != null)
            {
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }

            takePhoto.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true
                });

                if (file == null)
                    return;

                await DisplayAlert("File Location", file.Path, "OK");

                PhotoImage.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });

                //or:
                //image.Source = ImageSource.FromFile(file.Path);
                //image.Dispose();
            };
        }
    }
}