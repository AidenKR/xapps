using System;
using Xamarin.Forms;

namespace xapps
{
    public class CustomTabCell : Button
    {
        public int index { get; set; }

        public CustomTabCell(string text, int idx)
        {
            index = idx;
            Text = text;
            TextColor = Color.Black;
            FontSize = 14.0;

            BorderRadius = 0;

            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.Center;
        }
    }
}
