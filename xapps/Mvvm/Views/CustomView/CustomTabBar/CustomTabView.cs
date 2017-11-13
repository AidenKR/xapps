using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using xapps.Mvvm.Views.CustomTabBar;

namespace xapps
{
    public class CustomTabView : StackLayout
    {
        CustomTabInterface listener;
        public int count;
        private List<CustomTabData> tabData;
        private object selectedItem;

        public CustomTabView(CustomTabInterface listen, double width)
        {
            Debug.WriteLine("set view width = " + width);
            BackgroundColor = Color.White;
            WidthRequest = width;
            Orientation = StackOrientation.Horizontal;
            listener = listen;
        }

        public void makeTabLayout(List<CustomTabData> textList)
        {
            if(textList == null || textList.Count <= 0) {
                return;
            }

            tabData = textList;
            count = textList.Count;
            int index = 0;
            foreach (CustomTabData data in textList) {
                CustomTabBarCell cell = new CustomTabBarCell(data.tabText, index);
                if(index == 0) {
                    if(data.isUseImage) 
                    {
                        cell.Image = data.selImageName;
                    } else {
                        cell.BackgroundColor = Color.FromHex(data.selColor);
                    }

                    selectedItem = tabData[cell.index].tag;
                } else {
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
                cell.Clicked += delegate {

                    if (!tabData[cell.index].isDuplicateClick)
                    {
                        if (tabData[cell.index].tag == selectedItem)
                        {
                            Debug.WriteLine("same item clicked. just do pass");
                            return;
                        }
                    }

                    selectedItem = tabData[cell.index].tag;
                    
                    if(tabData[cell.index].tag == null) {
						listener.onClickTabButton(cell.index);
                    } else {
                        listener.onClickTabButton(tabData[cell.index].tag);
                    }

                    foreach(CustomTabBarCell btn in Children) {
                        CustomTabData indexItem = (CustomTabData)tabData[btn.index];
                        if(indexItem.isUseImage) {
                            btn.Image = indexItem.norImageName;
                        } else {
                            btn.BackgroundColor = Color.FromHex(indexItem.norColor);
                        }

                    }

                    CustomTabData item = tabData[cell.index];
                    if (item.isUseImage)
                    {
                        cell.Image = item.norImageName;
                    } else {
						cell.BackgroundColor = Color.FromHex(tabData[cell.index].selColor);
                    }
                };
                Children.Add(cell);
                index += 1;
            }

        }
    }
}
