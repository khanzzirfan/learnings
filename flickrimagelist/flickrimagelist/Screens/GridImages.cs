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
using Android.Support.V7.App;
using Android.Support.V4.App;
using Android.Support.V4.View;

using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace flickrimagelist
{
	[Activity (Label = "GridImages")]			
	public class GridImages : Activity
	{
		List<GridItem> items = new List<GridItem> ();
		GridView gridview;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Create your application here
			SetContentView (Resource.Layout.gridlayout);

			// Create your application here
			gridview = FindViewById<GridView> (Resource.Id.grid_view);


		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			GC.Collect (1);
		}


		protected override void OnResume ()
		{
			base.OnResume ();
			GetImages ();
			string x = "1";
			string y = "1";
			//set Two //working

		}

		public void GetImages()
		{
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

						string baseFlickrUrl = string.Format(photoUrl,data.farm,data.server,data.id,data.secret,"n");
						string squareFlickrUrl  =  string.Format(photoUrl,data.farm,data.server,data.id,data.secret,"s");
						string thumbnailFlickrUrl  =  string.Format(photoUrl,data.farm,data.server,data.id,data.secret,"t");
						string largeFlickrUrl  =  string.Format(photoUrl,data.farm,data.server,data.id,data.secret,"b");
						string name = string.Format("Image{0}", counter);

						//string imgUrl, int drawableId, string squareUrl, string mediumUrl, string largeUrl, string thumbnailUrl)

							items.Add(new GridItem(){Name=name, 
								DrawableId = Resource.Drawable.grid1, 
								ImgUrl=baseFlickrUrl,
								SquareUrl = squareFlickrUrl,
								LargeUrl = largeFlickrUrl,
								ThumbnailUrl= thumbnailFlickrUrl,
							});
						}

					}
					else  //If failed to retrieve drawables from flicker, add some images from resource.
					{
						items.Add (new GridItem (){Name="Image1", DrawableId= Resource.Drawable.grid1});
						items.Add (new GridItem (){Name="Image2",DrawableId=Resource.Drawable.grid2});
						items.Add (new GridItem (){Name="Image3", DrawableId= Resource.Drawable.grid1});
						items.Add (new GridItem (){Name="Image4",DrawableId=Resource.Drawable.grid2});
						items.Add (new GridItem (){Name="Image5", DrawableId= Resource.Drawable.grid1});
						items.Add (new GridItem (){Name="Image6",DrawableId=Resource.Drawable.grid2});
						items.Add (new GridItem (){Name="Image7", DrawableId= Resource.Drawable.grid1});
						items.Add (new GridItem (){Name="Image8",DrawableId=Resource.Drawable.grid2});
						items.Add (new GridItem (){Name="Image9", DrawableId= Resource.Drawable.grid1});
						items.Add (new GridItem (){Name="Image10",DrawableId=Resource.Drawable.grid2});
					}

				this.RunOnUiThread(()=>{
					gridview.Adapter = new GridImageAdapter(this,items);	
				});



				});
			//} //Close http client


		}

	}
}

