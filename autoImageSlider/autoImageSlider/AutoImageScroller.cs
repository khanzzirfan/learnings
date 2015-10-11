
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

using Android.Support.V4.App;
using Android.Support.V4.View;
using DK.Ostebaronen.Droid.ViewPagerIndicator;
using System.Threading.Tasks;
using System.Threading;

namespace autoImageSlider
{
	[Activity (Label = "AutoImageScroller")]	
	[IntentFilter(new[] { Android.Content.Intent.ActionMain }, Categories = new[] { "dk.ostebaronen.viewpagerindicator.droid.sample" })]
	public class AutoImageScroller : FragmentActivity
	{
		Button  btn;
		private List<int> itemData;
		private int imageValue;
		FragStateSupport _adapter;
		ViewPager _pager;
		protected IPageIndicator _indicator;
		bool Continue = false;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			itemData = new List<int> ();
			itemData.Add (Resource.Drawable.photo1);
			itemData.Add (Resource.Drawable.photo2);
			itemData.Add (Resource.Drawable.photo3);
			itemData.Add (Resource.Drawable.photo4);
			imageValue = 0;

			SetContentView(Resource.Layout.simple_circle_viewpager);

			//Set up adapter with List of photo ID as item Data
			_adapter = new FragStateSupport(SupportFragmentManager,itemData);

			//Setup pager reference
			_pager = FindViewById<ViewPager>(Resource.Id.pager);
			_pager.Adapter = _adapter;

			//Setup CirclePageIndicator Reference
			_indicator = FindViewById<CirclePageIndicator>(Resource.Id.indicator);
			_indicator.SetViewPager(_pager);


			btn = FindViewById<Button> (Resource.Id.myButton);
			btn.Click += HandleClick;
			btn.Text = "Run Slider";

		}

		async void HandleClick (object sender, EventArgs e)
		{
			
			if (Continue) {
				
				btn.Text = "Run Slider";
				Continue = false;
			} else {
				Continue = true;
				btn.Text = "Stop";
			}

			if (Continue) {
				ThreadPool.QueueUserWorkItem (o => RunSlowMethod ());
			}
		}

		public void RunSlowMethod()
		{
			while (Continue) {
				imageValue = imageValue + 1;
				if (imageValue > 3) {
					imageValue = 0;
					Console.WriteLine("Compute reset : t" + imageValue);
				}
				Thread.Sleep (2000);
				this.RunOnUiThread (() => _pager.SetCurrentItem (imageValue, true));
			}
		}

		protected override void OnDestroy ()
		{
			Continue = false;
			base.OnDestroy ();
		}
	}
}

