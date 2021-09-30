using System;
using Xamarin.Forms;
using System.IO;
using System.Collections.Generic;

namespace LoginApp.CustomLayouts
{
    public class CustomEntry : Entry
    {

        protected static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create("CornerRadius",typeof(int), typeof(CustomEntry), 0);

        public int EntryCornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        protected static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(CustomEntry), Color.Red);

        public Color EntryBorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty,value); }
        }

        protected static readonly BindableProperty BorderThicknessProperty =
    BindableProperty.Create("BorderThickness", typeof(int), typeof(CustomEntry));

        public int EntryBorderThickness
        {
            get { return (int)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

    }
    
}
