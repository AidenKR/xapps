using System;
using Xamarin.Forms;

namespace xapps
{
    sealed class ImageManager
    {
        private static readonly object _lockObj = new object();
        private static ImageManager imageManager = null;
        private ImageManager()
        {
        }
        static internal ImageManager Instance()
        {
            // can thread safety
            lock (_lockObj)
            {
                if (imageManager == null)
                {
                    imageManager = new ImageManager();
                }
                return imageManager;
            }
        }

        public static Image getImageFromUrl(string url) {
            return new Image { Source = ImageSource.FromUri(new Uri(url)) };
        }
    }
}