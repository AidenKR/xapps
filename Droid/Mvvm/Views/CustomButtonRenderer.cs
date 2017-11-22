using System;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using xapps;
using xapps.Droid;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
[assembly: ExportRenderer(typeof(CustomCheckBox), typeof(CustomCheckBoxRenderer))]
[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace xapps.Droid
{
    #region CustomButtonRenderer
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            this.Control.Elevation = 0;
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if ("Renderer" == e.PropertyName)
            {
                var xButton = (CustomButton)Element;
                if (null != xButton.BackgroundSource)
                {
                    var backbroundSource = xButton.BackgroundSource;
                    var selectorDrawable = Resources.GetDrawable(backbroundSource);
                    this.Control.SetCompoundDrawablesWithIntrinsicBounds(null, selectorDrawable, null, null);
                }
            }
        }
    }
    #endregion

    #region CustomCheckBoxRenderer
    public class CustomCheckBoxRenderer : ViewRenderer<CustomCheckBox, CheckBox>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomCheckBox> e)
        {
            base.OnElementChanged(e);
            var checkBox = new CheckBox(this.Context);
            if (e.OldElement != null)
            {
                checkBox.CheckedChange -= checkBox_CheckChanged;
            }
            if (e.NewElement != null)
            {
                checkBox.CheckedChange += checkBox_CheckChanged;
            }

            SetNativeControl(checkBox);
        }

        void checkBox_CheckChanged(object sender, EventArgs e)
        {
            Element.IsChecked = Control.Checked;
            Element.Checked.Invoke();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if ("Renderer" == e.PropertyName)
            {
                var xCheckBox = (CustomCheckBox)Element;
                if (xCheckBox.Text != null)
                    Control.Text = xCheckBox.Text;

            }
        }
    }
    #endregion

    #region CustomEntryRenderer
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if ("Renderer" == e.PropertyName)
            {
                var xEntry = (CustomEntry)Element;
                if (xEntry.BackgroundSource != null)
                {
                    var backbroundSource = xEntry.BackgroundSource;
                    var selectorDrawable = this.Context.Resources.GetIdentifier(backbroundSource, "drawable", this.Context.PackageName);
                    Control.SetBackgroundResource(selectorDrawable);
                }

                if (xEntry.LeftIconSource != null)
                {
                    var leftDrawableSource = xEntry.LeftIconSource;
                    var leftDrawable = Resources.GetDrawable(leftDrawableSource);
                    var drawables = Control.GetCompoundDrawables();

                    Control.SetCompoundDrawablesWithIntrinsicBounds(leftDrawable, drawables[1], drawables[2], drawables[3]);
                }

                if (xEntry.RightIconSource != null)
                {
                    var rightDrawableSource = xEntry.RightIconSource;
                    var rightDrawable = Resources.GetDrawable(rightDrawableSource);
                    var drawables = Control.GetCompoundDrawables();

                    Control.SetCompoundDrawablesWithIntrinsicBounds(drawables[0], drawables[1], rightDrawable, drawables[3]);
                }
            }
        }
    }
    #endregion
}
