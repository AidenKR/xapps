using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public class CustomTabView : StackLayout
    {
        public class TabData
        {
            public string Title { get; set; }
            public Object Tag { get; set; }
        }

        public ICustomTabInterface Listener { get; set; } // Tab Changed Event Listener

        CustomTabCellLayoutData TabCellLayoutData;
        int selectedIndex;

        public CustomTabView()
        {
            Orientation = StackOrientation.Horizontal;
            VerticalOptions = LayoutOptions.Start;
            HorizontalOptions = LayoutOptions.Start;
        }

        public void MakeTabLayout(List<string> titleList, CustomTabCellLayoutData layout = null, int selIndex = 0)
        {
            if (titleList == null || titleList.Count <= 0)
            {
                return;
            }

            List<TabData> tabList = new List<TabData>();
            foreach (string item in titleList)
            {
                tabList.Add(new TabData
                {
                    Title = item
                });
            }

            MakeTabLayout(tabList, layout, selIndex);
        }

        public void MakeTabLayout(List<TabData> tabList, CustomTabCellLayoutData layout = null, int selIndex = 0)
        {
            if (tabList == null || tabList.Count <= 0)
            {
                return;
            }

            TabCellLayoutData = layout;

            Debug.WriteLine("WidthRequest : " + WidthRequest);
            if (WidthRequest <= 0)
            {
                HorizontalOptions = LayoutOptions.FillAndExpand;
            }

            int index = 0;

            if (TabCellLayoutData == null)
            {
                TabCellLayoutData = new CustomTabCellLayoutData();
            }

            foreach (TabData tab in tabList)
            {
                CustomTabCell cell = new CustomTabCell(tab.Title, index);
                ChangeCellSelected(cell, index == selIndex);

                // setting text color
                if (null != TabCellLayoutData.selTextColors && (index + 1) <= TabCellLayoutData.selTextColors.Length)
                {
                    cell.TextColor = TabCellLayoutData.selTextColors[index];
                }

                // setting text font size
                if (0 < TabCellLayoutData.selTextFontSize)
                {
                    cell.FontSize = TabCellLayoutData.selTextFontSize;
                }

                if (index == selIndex)
                {
                    selectedIndex = index;
                }

                cell.WidthRequest = this.WidthRequest / tabList.Count;
                Debug.WriteLine("add textview text = " + tab + "item width = " + cell.WidthRequest);

                cell.Clicked += delegate
                {
                    ClickedCell(cell, tab.Tag);
                };

                Children.Add(cell);
                index += 1;
            }

        }

        void ClickedCell(CustomTabCell clickCell, Object tag = null)
        {
            if (clickCell.index == selectedIndex)
            {
                Debug.WriteLine("same item clicked. just do pass");
                return;
            }

            int preSelectIndex = selectedIndex;
            selectedIndex = clickCell.index;

            CustomTabCell preCell = Children[preSelectIndex] as CustomTabCell;
            ChangeCellSelected(preCell, false);
            ChangeCellSelected(clickCell, true);

            // SEND LISTENER
            Listener?.OnClickTabButton(clickCell.index, tag);
        }

        void ChangeCellSelected(CustomTabCell cell, Boolean isSelected)
        {
            if (TabCellLayoutData.isUseImage)
            {
                cell.Image = isSelected ? TabCellLayoutData.selImageName : TabCellLayoutData.norImageName;
            }
            else
            {
                cell.BackgroundColor = isSelected ? TabCellLayoutData.selColor : TabCellLayoutData.norColor;
            }

            if (TabCellLayoutData.isBoldText)
            {
                cell.FontAttributes = isSelected ? FontAttributes.Bold : FontAttributes.None;
            }
        }
    }
}
