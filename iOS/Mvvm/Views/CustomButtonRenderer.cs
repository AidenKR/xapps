using System;

using Foundation;
using UIKit;
using xapps;
using AVFoundation;
using CoreGraphics;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using xapps.iOS;
using CoreAnimation;
using System.Linq;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace xapps.iOS
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            UIButton thisButton = Control as UIButton;
            thisButton.TouchDown += delegate
            {
                System.Diagnostics.Debug.WriteLine("TouchDownEvent");

                var xButton = (CustomButton)Element;
                if (null != xButton.BackgroundSource)
                {
                    var backbroundSource = xButton.BackgroundSource;
                    string imgName = getImageName(backbroundSource);
                    UIImage image = UIImage.FromFile(imgName + "_p.png");
                    this.Control.SetBackgroundImage(image, UIControlState.Normal);
                }
            };
            thisButton.TouchUpInside += delegate
            {
                System.Diagnostics.Debug.WriteLine("TouchUpEvent");

                var xButton = (CustomButton)Element;
                if (null != xButton.BackgroundSource)
                {
                    var backbroundSource = xButton.BackgroundSource;
                    string imgName = getImageName(backbroundSource);
                    UIImage image = UIImage.FromFile(imgName + ".png");
                    this.Control.SetBackgroundImage(image, UIControlState.Normal);
                }
            };

            // init View
            var initButton = (CustomButton)Element;
            if (null != initButton.BackgroundSource)
            {
                var backbroundSource = initButton.BackgroundSource;
                string imgName = getImageName(backbroundSource);
                UIImage image = UIImage.FromFile(imgName + ".png");
                this.Control.SetBackgroundImage(image, UIControlState.Normal);
            }
        }

        private string getImageName(string backbroundSource)
        {
            NSString ns = new NSString(backbroundSource);
            return ns.Replace(getFindNameToNSRange(backbroundSource, "selector_"), new NSString("img_"));
        }

        private NSRange getFindNameToNSRange(string source, string substring)
        {
            var range = new NSRange
            {
                Location = source.IndexOf(substring),
                Length = substring.Length
            };

            return range;
        }
    }
}
