using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Android.App;
using Android.Graphics.Drawables;
using System.Net;
using FFImageLoading;
using FFImageLoading.Views;
using FFImageLoading.Work;

namespace flickrimagelist
{
	public class ImageFragment: Android.Support.V4.App.Fragment
	{
		int position;
		string imageUrl;
		Activity activity;
		ImageViewAsync ivImageView;


		//Drawable drawable;
		private const string KeyContent = "TestFragment:Content";
		private string _content = "???";
		public const string fragmentTag ="TestTag";
		public ImageFragment()
		{
		}
		public ImageFragment(int position=0, string imageUrl="" , Activity activity=null)
		{
			this.position = position;
			this.imageUrl = imageUrl;
			this.activity = activity;
		}

		public static ImageFragment NewInstance(string imgUrl)
		{
			//Could not get to work this piece of code. hence leaveing it for later fix.
			var fragment = new ImageFragment();
			//var fragmentTx = this.FragmentManager.BeginTransaction();
			Bundle args = new Bundle ();
			args.PutString (KeyContent,imgUrl);
			fragment.Arguments = args;
			//fragmentTx.Add (fragment, fragmentTag);
			//fragmentTx.Commit();
			return fragment;
		}


		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			if ((savedInstanceState != null) && savedInstanceState.ContainsKey(KeyContent))
				imageUrl = savedInstanceState.GetString(KeyContent);
		}

		public void setImageList(string imageUrl, Activity activity)
		{
			this.imageUrl = imageUrl;
			this.activity = activity;
		}


		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);

		}
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate (Resource.Layout.fragmentimages, container, false);

			var ivImageView = view.FindViewById<ImageViewAsync>(Resource.Id.imgDisplay);
			var textView = view.FindViewById<TextView>(Resource.Id.textView);
			ivImageView.SetScaleType (ImageView.ScaleType.FitXy);

			ImageService.LoadUrl(imageUrl)
				.Retry(3, 200)
				.DownSample(300, 300)
				.Into(ivImageView);
			
			textView.Text = "Image";
			return view;
		}

		public override void OnDestroy ()
		{
			base.OnDestroy ();
			if (ivImageView != null) {
				ivImageView.SetImageBitmap (null);
			}
		}

	}
}

