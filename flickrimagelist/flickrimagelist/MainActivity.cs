using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace flickrimagelist
{
	[Activity (Label = "flickrimagelist", MainLauncher = true, Icon = "@drawable/icon")]
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
			Button btnLarge = FindViewById<Button> (Resource.Id.largeImages);

			button.Text = "Start Grid Activity";
			button.Click += delegate {
				StartGridActivity();
			};


			btnLarge.Click += delegate {
				LoadLargeImagesActivity();
			};
		}

		void StartGridActivity()
		{
			var gridActivity = new Intent (this, typeof(GridImages));
			StartActivity (gridActivity);
		}

		void LoadLargeImagesActivity()
		{
			var activity = new Intent (this, typeof(ScollImageActivity));
			StartActivity (activity);
		}

	}
}


