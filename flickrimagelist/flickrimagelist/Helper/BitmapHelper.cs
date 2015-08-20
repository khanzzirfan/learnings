namespace flickrimagelist
{
	using System;
	using System.IO;
	using Android.Graphics;
	using Android.Graphics.Drawables;
	using Android.Widget;

	public static class BitmapHelpers
	{
		/// <summary>
		/// This method will recyle the memory help by a bitmap in an ImageView
		/// </summary>
		/// <param name="imageView">Image view.</param>
		public static void RecycleBitmap(this ImageView imageView)
		{
			if (imageView == null) {
				return;
			}

			Drawable toRecycle = imageView.Drawable;
			if (toRecycle != null) {
				Console.WriteLine("recycle using bitmap -RecycleBitmap(this ImageView imageView) ");
				((BitmapDrawable)toRecycle).Bitmap.Recycle ();
			}
		}

	}
}
