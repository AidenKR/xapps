using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public class CustomTabView : StackLayout
    {
        public CustomTabInterface Listener { get; set; } // Tab Changed Event Listener

        List<string> TabTextList;
        CustomTabCellLayoutData TabCellLayoutData;
        int selectedIndex;

        public CustomTabView()
        {
            Orientation = StackOrientation.Horizontal;
            VerticalOptions = LayoutOptions.Start;
            HorizontalOptions = LayoutOptions.Start;
        }

        public void makeTabLayout(List<string> textList, CustomTabCellLayoutData layout = null, int selIndex = 0)
        {
            if (textList == null || textList.Count <= 0)
            {
                return;
            }

            TabCellLayoutData = layout;

            Debug.WriteLine("WidthRequest : " + WidthRequest);
            if (WidthRequest <= 0)
            {
                HorizontalOptions = LayoutOptions.FillAndExpand;
            }

            TabTextList = textList;
            int index = 0;

            if (TabCellLayoutData == null)
            {
                TabCellLayoutData = new CustomTabCellLayoutData();
            }

            foreach (string tabText in textList)
            {
                CustomTabCell cell = new CustomTabCell(tabText, index);
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

                cell.WidthRequest = this.WidthRequest / textList.Count;
                Debug.WriteLine("add textview text = " + tabText + "item width = " + cell.WidthRequest);

                cell.Clicked += delegate
                {
                    ClickedCell(cell);
                };

                Children.Add(cell);
                index += 1;
            }

        }

        void ClickedCell(CustomTabCell clickCell)
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
            Listener?.onClickTabButton(clickCell.index);
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
