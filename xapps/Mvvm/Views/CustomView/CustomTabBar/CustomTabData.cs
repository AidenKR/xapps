using System;
using Xamarin.Forms;

namespace xapps
{
    public class CustomTabData
    {
        public string tabText { get; set; }     // tab text
        public bool isUseImage { get; set; }    // use image
        public bool isDuplicateClick { get; set; }  // duplicate clickable

        #region isUseImage == true
        public string selImageName { get; set; }    // if isUseImage is true, used
        public string norImageName { get; set; }    // if isUseImage is true, used
        #endregion

        #region isUseImage == false
        public Color selColor { get; set; } = Color.FromRgba(247, 211, 88, 255);   // if isUseImage is false, used
        public Color norColor { get; set; } = Color.FromRgba(0, 0, 0, 0);   // if isUseImage is false, used
        #endregion

        public object tag { get; set; }        // tag functional ( if is nil return to default index, return to tag )
    }
}
