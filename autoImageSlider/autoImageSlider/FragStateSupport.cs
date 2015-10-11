using System;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Frag = Android.Support.V4.App;
using System.Collections.Generic;
using System.Runtime;
using Android.App;
using Android.Runtime;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace autoImageSlider
{
	public class FragStateSupport:FragmentStatePagerAdapter
	{
		private int _count;
		private List<int> items;

		public FragStateSupport (Frag.FragmentManager fm, List<int> data) : base (fm)
		{
			this.items = data;
			_count = data.Count;

		}

		public override int Count{
			get{return _count; }
		}

		public override Android.Support.V4.App.Fragment GetItem (int position)
		{

			var _itemPosition = items [position];
			TestFragment f = new TestFragment ();
			f.setImageList(_itemPosition);
			return f;
		}


	}
}

