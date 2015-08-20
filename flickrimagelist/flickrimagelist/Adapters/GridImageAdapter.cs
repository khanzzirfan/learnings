using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using System.Net.Http;
using Android.Graphics.Drawables;
using System.IO;

namespace flickrimagelist
{
	public class ViewHolder : Java.Lang.Object
	{
		public TextView Name { get; set; }
		public TextView Description { get; set; }
		public SquareImageView Image { get; set; }
	}

	public class GridImageAdapter:BaseAdapter<GridItem>
	{
		ImageView ivImageView;
		private List<GridItem> items = new List<GridItem>();
		private LayoutInflater inflater;
		private Activity context;
		public GridImageAdapter (Activity context, List<GridItem> items)
		{
			inflater = LayoutInflater.From (context);
			this.items = items;
			this.context = context;
		}

		public override GridItem this [int position]
		{
			get { return items [position]; }
		}

		public override int Count {
			get { return items.Count; }
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId (int position)
		{
			return 0;
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			ViewHolder holder;

			var view = convertView;
			var item = items [position];
			TextView tvTextView;

			if (view == null) {
				view = inflater.Inflate (Resource.Layout.gridviewitems, parent, false);
				view.SetTag (Resource.Id.picture, view.FindViewById (Resource.Id.picture));
				view.SetTag (Resource.Id.text, view.FindViewById (Resource.Id.text));

				holder = new ViewHolder ();
				holder.Name = (TextView)view.GetTag (Resource.Id.text);
				//holder.Image = (ImageViewAsync)view.GetTag (Resource.Id.picture);
				holder.Image = (SquareImageView)view.GetTag (Resource.Id.picture);
				view.Tag = holder;
			}else {
				holder = (ViewHolder)view.Tag;
			}

			ivImageView = (ImageView)view.GetTag (Resource.Id.picture);
			tvTextView = (TextView)view.GetTag (Resource.Id.text);
			//ivImageView.SetImageResource (item.DrawableId);
			tvTextView.Text = item.Name;
			var uri = new Uri(item.ImgUrl);
			var iw = new ImageWrapper(ivImageView, context);
			ivImageView.Tag = uri.ToString();

			try 
			{
				var drawable = ImageLoader.DefaultRequestImage(uri, iw);
				if (drawable != null) // use it
					ivImageView.SetImageDrawable(drawable);
				else // we're just going to grab it ourselves and not wait for the callback from ImageLoader
					ivImageView.SetImageResource (item.DrawableId);
			}
			catch (Exception ex) {
				Console.WriteLine (ex.ToString ());
			}

			return view;




		}


	}
}

