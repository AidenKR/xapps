using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace xapps
{
    public class CustomTabView : StackLayout
    {
        public CustomTabInterface Listener { get; set; } // Tab Changed Event Listener

        public int count;
        private List<CustomTabData> tabData;
        private int selectedIndex;

        public CustomTabView()
        {
            Orientation = StackOrientation.Horizontal;
            VerticalOptions = LayoutOptions.StartAndExpand;
            HorizontalOptions = LayoutOptions.StartAndExpand;
        }

        public void makeTabLayout(List<CustomTabData> textList)
        {
            if (textList == null || textList.Count <= 0)
            {
                return;
            }

            Debug.WriteLine("WidthRequest : " + WidthRequest);
            if (WidthRequest <= 0)
            {
                HorizontalOptions = LayoutOptions.FillAndExpand;
            }

            tabData = textList;
            count = textList.Count;
            int index = 0;
            foreach (CustomTabData data in textList)
            {
                CustomTabBarCell cell = new CustomTabBarCell(data.tabText, index);
                if (index == 0)
                {
                    if (data.isUseImage)
                    {
                        cell.Image = data.selImageName;
                    }
                    else
                    {
                        cell.BackgroundColor = Color.FromHex(data.selColor);
                    }

                    selectedIndex = cell.index;
                }
                else
                {
                    if (data.isUseImage)
                    {
                        cell.Image = data.norImageName;
                    }
                    else
                    {
                        cell.BackgroundColor = Color.FromHex(data.norColor);
                    }

                }
                Debug.WriteLine("add textview text = " + data.tabText + "item width = " + this.WidthRequest / count);
                cell.WidthRequest = this.WidthRequest / count;
                cell.Clicked += delegate
                {
                    if (!tabData[cell.index].isDuplicateClick)
                    {
                        if (cell.index == selectedIndex)
                        {
                            Debug.WriteLine("same item clicked. just do pass");
                            return;
                        }
                    }

                    selectedIndex = cell.index;

                    if (tabData[cell.index].tag == null)
                    {
                        Listener?.onClickTabButton(cell.index);
                    }
                    else
                    {
                        Listener?.onClickTabButton(tabData[cell.index].tag);
                    }

                    foreach (CustomTabBarCell btn in Children)
                    {
                        CustomTabData indexItem = (CustomTabData)tabData[btn.index];
                        if (indexItem.isUseImage)
                        {
                            btn.Image = indexItem.norImageName;
                        }
                        else
                        {
                            btn.BackgroundColor = Color.FromHex(indexItem.norColor);
                        }

                    }

                    CustomTabData item = tabData[cell.index];
                    if (item.isUseImage)
                    {
                        cell.Image = item.norImageName;
                    }
                    else
                    {
                        cell.BackgroundColor = Color.FromHex(tabData[cell.index].selColor);
                    }
                };
                Children.Add(cell);
                index += 1;
            }

        }
    }
}
