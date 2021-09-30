using System;
using CoreAnimation;
using CoreGraphics;
using LoginApp.CustomLayouts;
using LoginApp.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRendereriOS))]

namespace LoginApp.iOS
{
    public class CustomEntryRendereriOS : EntryRenderer
    {
        public CustomEntryRendereriOS()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var customEntry = (CustomEntry)e.NewElement;

                //Control.Layer.CornerRadius = customEntry.EntryCornerRadius;
                //Control.Layer.BorderWidth = customEntry.EntryBorderThickness;

                //Control.Layer.BorderColor = customEntry.EntryBorderColor.ToCGColor();
                Control.BorderStyle = UITextBorderStyle.None;

                //Create borders(bottom only)
                CALayer border = new CALayer();
                float width = 2.0f;
                border.BorderColor = Color.White.ToCGColor();
                border.Frame = new CGRect(0, 40, 400, 2.0f);
                border.BorderWidth = width;

                Control.Layer.AddSublayer(border);
                Control.Layer.MasksToBounds = true;

            }


            


        }

        
    }
}
