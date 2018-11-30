using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TargetTransport.CustomeControls
{
    public class TwoImagePicker : Picker
    {
        public TwoImagePicker()
        {
            this.HeightRequest = 50;
        }
        public static readonly BindableProperty ImageProperty =
            BindableProperty.Create(nameof(Image), typeof(string), typeof(TwoImagePicker), string.Empty);
        public static readonly BindableProperty Image1Property =
            BindableProperty.Create(nameof(Image1), typeof(string), typeof(TwoImagePicker), string.Empty);

        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create(nameof(LineColor), typeof(Xamarin.Forms.Color), typeof(TwoImagePicker), Color.White);

        public static readonly BindableProperty ImageHeightProperty =
            BindableProperty.Create(nameof(ImageHeight), typeof(int), typeof(TwoImagePicker), 40);

        public static readonly BindableProperty ImageWidthProperty =
            BindableProperty.Create(nameof(ImageWidth), typeof(int), typeof(TwoImagePicker), 40);

        public static readonly BindableProperty ImageHeight1Property =
            BindableProperty.Create(nameof(ImageHeight1), typeof(int), typeof(TwoImagePicker), 20);

        public static readonly BindableProperty ImageWidth2Property =
            BindableProperty.Create(nameof(ImageWidth1), typeof(int), typeof(TwoImagePicker), 20);
        public static readonly BindableProperty ImageAlignmentProperty =
            BindableProperty.Create(nameof(ImageAlignment), typeof(ImageAlignment), typeof(TwoImagePicker), ImageAlignment.Left);

        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }

        public int ImageWidth
        {
            get { return (int)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }
        public int ImageWidth1
        {
            get { return (int)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }
        public int ImageHeight
        {
            get { return (int)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }
        public int ImageHeight1
        {
            get { return (int)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }
        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public string Image1
        {
            get { return (string)GetValue(Image1Property); }
            set { SetValue(Image1Property, value); }
        }
        public ImageAlignment ImageAlignment
        {
            get { return (ImageAlignment)GetValue(ImageAlignmentProperty); }
            set { SetValue(ImageAlignmentProperty, value); }
        }
    }
}
