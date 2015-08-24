using System;
using System.Collections.Generic;

namespace flickrimagelist
{
	public class ImageConfig
	{
		public const string flickrApiKey = "850e32be70ca5a7e04b39b6a7e130e38";
		public const string userId = "10734446@N06";
		public const int page = 0;
		public const int per_page = 80;

		public ImageConfig()
		{
			
		}

	}

	public class Photo
	{
		public string id { get; set; }
		public string owner { get; set; }
		public string secret { get; set; }
		public string server { get; set; }
		public int farm { get; set; }
		public string title { get; set; }
		public int ispublic { get; set; }
		public int isfriend { get; set; }
		public int isfamily { get; set; }
	}

	public class Photos
	{
		public int page { get; set; }
		public int pages { get; set; }
		public int perpage { get; set; }
		public string total { get; set; }
		public List<Photo> photo { get; set; }
	}

	public class FlickrData
	{
		public Photos photos { get; set; }
		public string stat { get; set; }
	}
}

