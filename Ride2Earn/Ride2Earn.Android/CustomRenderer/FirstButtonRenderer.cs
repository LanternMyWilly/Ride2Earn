﻿using System;
using Android.Content;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Graphics.Drawables;
using Android.Util;
using Ride2Earn.Droid.CustomRenderer;
using Ride2Earn;

[assembly: ExportRenderer(typeof(CurvedCornersButton), typeof(FirstButtonRenderer))]
namespace Ride2Earn.Droid.CustomRenderer
{
    public class FirstButtonRenderer : ButtonRenderer
    {
        private GradientDrawable _gradientBackground;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            var view = (CurvedCornersButton)Element;
            if (view == null) return;

            // creating gradient drawable for the curved background
            _gradientBackground = new GradientDrawable();
            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetColor(view.CurvedBackgroundColor.ToAndroid());

            // Thickness of the stroke line
            _gradientBackground.SetStroke(4, view.CurvedBackgroundColor.ToAndroid());

            // Radius for the curves
            _gradientBackground.SetCornerRadius(
                DpToPixels(this.Context,
                Convert.ToSingle(view.CurvedCornerRadius)));

            // set the background of the label
            Control.SetBackground(_gradientBackground);
        }

        /// <summary>
        /// Device Independent Pixels to Actual Pixles conversion
        /// </summary>
        /// <param name="context"></param>
        /// <param name="valueInDp"></param>
        /// <returns></returns>
        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}