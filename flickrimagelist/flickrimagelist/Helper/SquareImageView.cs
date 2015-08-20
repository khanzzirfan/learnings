using System;
using Android.Content;
using Android.Util;
using Android.Widget;


namespace flickrimagelist
{
	public class SquareImageView:ImageView
	{
		public SquareImageView (Context context):base(context)
		{
		}

		public SquareImageView(Context context , IAttributeSet attrs):base(context,attrs)
		{
		}

		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			base.OnMeasure (widthMeasureSpec, heightMeasureSpec);
			SetMeasuredDimension (MeasuredWidth, MeasuredWidth);
		}


	}
}
