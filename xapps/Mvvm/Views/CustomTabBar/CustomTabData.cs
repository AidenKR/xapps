using System;
namespace xapps.Mvvm.Views.CustomTabBar
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
        public string selColor { get; set; }    // if isUseImage is false, used
        public string norColor { get; set; }    // if isUseImage is false, used
        #endregion

        public object tag { get; set; }        // tag functional ( if is nil return to default index, return to tag )
    }
}
