using System.Text;
using Android.OS;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using Android.Views;
using System.Drawing;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using System;
using Android.Views.Animations;

using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace autoImageSlider
{
	public class TestFragment: Fragment
	{
		private const string KeyContent = "TestFragment:Content";
		private string _content = "???";
		private int itemData;
		private Bitmap myBitmap;
		private ImageView ivImageView;


		public static TestFragment NewInstance()
		{
			TestFragment f = new TestFragment ();
			return f;
		}
		public void setImageList(int intData)
		{
			this.itemData = intData;
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			if ((savedInstanceState != null) && savedInstanceState.ContainsKey(KeyContent))
				_content = savedInstanceState.GetString(KeyContent);
		}

		public override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);
			outState.PutString(KeyContent, _content);
		}


		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View root = inflater.Inflate (Resource.Layout.ViewImageFlipper, container, false);
			ivImageView = root.FindViewById<ImageView>(Resource.Id.img);

			int height = ivImageView.Height;
			int width = Resources.DisplayMetrics.WidthPixels;

			BitmapFactory.Options options = GetBitmapOptionsOfImage();

			//using block is used here to not hold any image reference and releasing the memory.
			using (Bitmap bitmapToDisplay = LoadScaledDownBitmapForDisplay (options, 500, 300)) {
				//ivImageView.RecycleBitmap();
				ivImageView.SetImageBitmap(bitmapToDisplay);
			}
			return root;
		}
		public Bitmap LoadScaledDownBitmapForDisplay(BitmapFactory.Options options, int reqWidth, int reqHeight)
		{
			// Calculate inSampleSize
			options.InSampleSize = CalculateInSampleSize(options, reqWidth, reqHeight);
			// Decode bitmap with inSampleSize set
			options.InJustDecodeBounds = false;
			return BitmapFactory.DecodeResource(Resources, itemData, options);
		}

		public static int CalculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
		{
			// Raw height and width of image
			float height = options.OutHeight;
			float width = options.OutWidth;
			double inSampleSize = 1D;

			if (height > reqHeight || width > reqWidth)
			{
				int halfHeight = (int)(height / 2);
				int halfWidth = (int)(width / 2);

				// Calculate a inSampleSize that is a power of 2 - the decoder will use a value that is a power of two anyway.
				while ((halfHeight / inSampleSize) > reqHeight && (halfWidth / inSampleSize) > reqWidth)
				{
					inSampleSize *= 2;
				}
			}

			return (int)inSampleSize;
		}

		public BitmapFactory.Options GetBitmapOptionsOfImage()
		{
			//Get only the bounds of the bitmap image
			BitmapFactory.Options options = new BitmapFactory.Options
			{
				InJustDecodeBounds = true,
				InPurgeable=true,
			};

			// The result will be null because InJustDecodeBounds == true.
			Bitmap result=  BitmapFactory.DecodeResource(Resources, itemData, options);
			int imageHeight = options.OutHeight;
			int imageWidth = options.OutWidth;
			Console.WriteLine(string.Format("Original Size= {0}x{1}", imageWidth, imageHeight));
			return options;
		}

		public override void OnDestroyView()
		{	
			//When Image Is out of view, Clear the Memory use. 
			base.OnDestroyView ();
			if (ivImageView != null) {
				ivImageView.SetImageBitmap (null);
				GC.Collect (1);
			}
		}

	}
}

