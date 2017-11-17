using System;
using Xamarin.Forms;

namespace xapps
{
    public class CustomTabCellLayoutData
    {
        public bool isUseImage { get; set; } = false;   // use image
        public bool isBoldText { get; set; } = true; // select Text is Bole Y/N

        #region isUseImage == true
        public string selImageName { get; set; }    // if isUseImage is true, used
        public string norImageName { get; set; }    // if isUseImage is true, used
        #endregion

        #region isUseImage == false
        public Color selColor { get; set; } = Color.FromRgba(0, 0, 0, 0);   // if isUseImage is false, used
        public Color norColor { get; set; } = Color.FromRgba(0, 0, 0, 0);   // if isUseImage is false, used
        #endregion
    }
}
