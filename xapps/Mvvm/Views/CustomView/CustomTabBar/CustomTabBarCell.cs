using System;
using Xamarin.Forms;

namespace xapps
{
    public class CustomTabBarCell : Button
    {
        public int index { get; set; }

        public CustomTabBarCell(string text, int idx)
        {
            BackgroundColor = Color.FromHex("#E6E6E6");
            index = idx;
            Text = text;
            TextColor = Color.Black;
            FontSize = 14.0;

            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.Center;
        }
    }
}
