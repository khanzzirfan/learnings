using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;

namespace flickrimagelist
{
	public class GridItem
	{
		public string Name{ get; set; }
		public string ImgUrl { get; set; }  //Ending Url with n.jpg
		public int DrawableId { get; set; }
		public string SquareUrl { get; set; }  //Ending Url with s.jpg
		public string LargeSquareUrl { get; set; }  //Ending Url with g.jpg
		public string MediumUrl { get; set; }  //Ending Url with n.jpg
		public string ThumbnailUrl { get; set; }  //Ending Url with t.jpg
		public string LargeUrl { get; set; }  //Ending Url with b.jpg

		public GridItem()
		{
		}
		public GridItem(string name, string imgUrl, int drawableId, string squareUrl, string mediumUrl, string largeUrl, string thumbnailUrl)
		{
			this.Name = name;
			this.ImgUrl = imgUrl;
			this.DrawableId = drawableId;

			this.SquareUrl = squareUrl;
			this.MediumUrl = mediumUrl;
			this.LargeUrl = largeUrl;
			this.ThumbnailUrl = thumbnailUrl;

		}
	}

	public class ScrollImages
	{
		public string Images { get; set; }
		public Activity Activity { get; set; }
		public ScrollImages()
		{
			
		}
		public ScrollImages(string images, Activity activity)
		{
			this.Images = images;
			this.Activity = activity;
		}
	}
}

