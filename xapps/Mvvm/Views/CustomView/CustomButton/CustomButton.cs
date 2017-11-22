using System;
using Xamarin.Forms;

namespace xapps
{
    public class CustomButton : Button
    {
        public string BackgroundSource
        {
            get;
            set;
        }
    }

    public class CustomEntry : Entry
    {
        public string LeftIconSource
        {
            get;
            set;
        }

        public string RightIconSource
        {
            get;
            set;
        }

        public string BackgroundSource
        {
            get;
            set;
        }
    }

    public class CustomCheckBox : View
    {
        bool isChecked = false;

        public Action Checked = delegate
        {
        };

        public bool IsChecked
        {
            get; set;
        }

        public string Text
        {
            get;
            set;
        }
    }
}
