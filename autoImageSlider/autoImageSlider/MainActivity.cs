using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace autoImageSlider
{
	[Activity (Label = "autoImageSlider", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			button.Text = "Run Image Scroller";
			button.Click += delegate {
				//button.Text = string.Format ("{0} clicks!", count++);
				RunAutoImageScroller();
			};
		}

		void RunAutoImageScroller()
		{
			var taskIntentActivity = new Intent (this, typeof(AutoImageScroller));
			StartActivity (taskIntentActivity);
		}
	}
}


