using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using TargetTransport.CustomeControls;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using TargetTransport.Droid.Renderers;
using Xamarin.Forms;
using Android.Support.V4.Content.Res;

[assembly: ExportRenderer(typeof(TwoImagePicker), typeof(TwoImagePickerRenderer))]
namespace TargetTransport.Droid.Renderers
{
    public class TwoImagePickerRenderer : PickerRenderer
    {
        public TwoImagePickerRenderer(Context context) : base(context)
        {

        }
        TwoImagePicker element;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (TwoImagePicker)this.Element;


            var editText = this.Control;
            if (!string.IsNullOrEmpty(element.Image) || !string.IsNullOrEmpty(element.Image1))
            {
                switch (element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Image), null, GetDrawable1(element.Image1), null);
                        break;
                    case ImageAlignment.Right:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Image), null);
                        break;
                }
            }
            // editText.SetBackground()
            editText.CompoundDrawablePadding = 25;
            Control.Background.SetColorFilter(element.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
        }

        private BitmapDrawable GetDrawable(string imageEntryImage)
        {
            int resID = Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth * 2, element.ImageHeight * 2, true));
        }
        private Drawable GetDrawable1(string imageEntryImage)
        {
            Drawable imgDropDownArrow = ResourcesCompat.GetDrawable(Resources, Resource.Drawable.drop_down, null);
            //Resources.GetDrawable(Resource.Drawable.arrow);                
             imgDropDownArrow.SetBounds(0, 0, 15, 0);
            // Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(null, null, imgDropDownArrow, null);

            //int resID = Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
            //var drawable = ContextCompat.GetDrawable(this.Context, resID);
            //var bitmap = ((BitmapDrawable)drawable).Bitmap;
            return imgDropDownArrow;
            //return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth1 , element.ImageHeight1 , true));
        }
    }
}