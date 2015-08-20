using System;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Support.V4.View;
using Android.Content.Res;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.App;

using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Android.Util;

namespace flickrimagelist
{
	[Activity (Label = "ScollImageActivity",Theme = "@style/ImageLoading.Theme")]			
	public class ScollImageActivity : AppCompatActivity
	{
		public const string POSITION = "position";
		ViewPager viewPager;
		List<ScrollImages> items = new List<ScrollImages> ();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.ScrollImages);

			var position = Intent.GetIntExtra(POSITION, 0);

			viewPager = FindViewById<ViewPager>(Resource.Id.pager);
			viewPager.SetClipToPadding(false);
			//viewPager.PageMargin = DimensionHelper.DpToPx(12);


			//More documentation is available on this page
			//https://channel9.msdn.com/Series/Windows-Phone-8-Development-for-Absolute-Beginners/Part-26-Retrieving-a-Photo-from-Flickrs-API
			string[] licenses = { "4", "5", "6", "7" };
			string license = String.Join(",", licenses);
			license = license.Replace(",", "%2C");

			string url = "https://api.flickr.com/services/rest/" +
				"?method=flickr.photos.search" +
				"&api_key={0}" +
				"&user_id={1}" +
				"&format=json" +
				"&page={2}" +
				"&per_page={3}" +
				"&nojsoncallback=1";

			var baseUrl = string.Format(url,
				ImageConfig.flickrApiKey,
				ImageConfig.userId,
				ImageConfig.page,
				ImageConfig.per_page);

			HttpClient client = new HttpClient ();
			client.GetStringAsync (baseUrl).ContinueWith ((requestString) => {

				var flickrResult = requestString.Result;
				FlickrData apiData = JsonConvert.DeserializeObject<FlickrData>(flickrResult);
				int counter = 0;
				if (apiData.stat == "ok")
				{
					foreach (Photo data in apiData.photos.photo)
					{
						// To retrieve one photo, use this format:
						//http://farm{farm-id}.staticflickr.com/{server-id}/{id}_{secret}{size}.jpg
						counter = counter+1;
						string photoUrl = "https://farm{0}.staticflickr.com/{1}/{2}_{3}_{4}.jpg";
						string largeFlickrUrl  =  string.Format(photoUrl,data.farm,data.server,data.id,data.secret,"b");
						string name = string.Format("Image{0}", counter);
						items.Add(new ScrollImages(){Images=largeFlickrUrl , Activity=this});

					}
				}

				viewPager.Adapter = new SwipeGalleryStateAdapter(SupportFragmentManager, items);
				viewPager.SetCurrentItem(position, false);

			});

			
		}

		protected override void OnResume ()
		{
			base.OnResume ();

		}
	}

	public class SwipeGalleryStateAdapter : FragmentStatePagerAdapter
	{
		private List<ScrollImages> images;
		Android.Support.V4.App.FragmentManager fm;
		public SwipeGalleryStateAdapter(Android.Support.V4.App.FragmentManager fm, List<ScrollImages> images) : base(fm)
		{
			this.images = images;
			this.fm = fm;
		}

		public override int Count
		{
			get { return images.Count; }
		}
		public override float GetPageWidth(int position)
		{
			return 0.93f;
		}

		public override Android.Support.V4.App.Fragment GetItem(int position)
		{
			var imgUrl = images [position];
			var fragment = new ImageFragment (); //.NewInstance (imgUrl.Images); //for some reason not saving instance so have to create below method again
			fragment.setImageList (imgUrl.Images, imgUrl.Activity);
			return fragment;

		}
	}
}

