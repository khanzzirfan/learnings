using System;
using Android;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace recyclerviewlistner
{
	[Activity (Label = "Vegetable List", MainLauncher = true, Icon = "@drawable/icon",Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
	public class MainActivity : Activity
	{
		int count = 1;
		// RecyclerView instance that displays the photo album:
		RecyclerView mRecyclerView;
		// Layout manager that lays out each card in the RecyclerView:
		RecyclerView.LayoutManager mLayoutManager;

		// Adapter that accesses the data set (a photo album):
		RecycleAdapter	mAdapter;

		//Vegetable List
		List<Vegetable> vegeList;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			vegeList = new List<Vegetable> () {
				new Vegetable (1,"Onion",0,false,10, Resource.Drawable.rsz_onion_images),
				new Vegetable (2,"Cucumber",0,false,10, Resource.Drawable.rsz_cucumber),
				new Vegetable (3,"Carrot",0,false,10, Resource.Drawable.rsz_carrot),
			};
			// Get our button from the layout resource,
			// and attach an event to it
			Button btnReset = FindViewById<Button> (Resource.Id.myButton);

			// Get our RecyclerView layout:
			mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

			// Use the built-in linear layout manager:
			mLayoutManager = new LinearLayoutManager(this);

			// Plug the layout manager into the RecyclerView:
			mRecyclerView.SetLayoutManager(mLayoutManager);

			// Create an adapter for the RecyclerView, and pass it the
			// data set (the photo album) to manage:
			mAdapter = new RecycleAdapter(this,vegeList);

			// Register the item click handler (below) with the adapter:
			mAdapter.ItemClick += OnItemClick;
			mAdapter.SpinnerItemSelectionChanged += SpinnerItemSelectionChangedEvent;

			// Plug the adapter into the RecyclerView:
			mRecyclerView.SetAdapter(mAdapter);

			//Reset the complete view;
			btnReset.Click += delegate {
				if(vegeList!=null)
				{
					for(int i=0;i<vegeList.Count;i++)
					{
						vegeList[i].Quantity = 0;
					}
					mAdapter.NotifyDataSetChanged();
				}

			};

		}

		// Handler for the item click event:
		void OnItemClick(object sender, int position)
		{
			// Display a toast that briefly shows the enumeration of the selected photo:
			int itemPosition = position + 1;
			Toast.MakeText(this, "Vegetable Item " + itemPosition, ToastLength.Short).Show();
		}

		void SpinnerItemSelectionChangedEvent(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			var itemPosition = Convert.ToInt32 (spinner.Tag);
			//Update the view by Total Amount, after spinner value is been selected.
			var currentquantity = vegeList[itemPosition].Quantity;
			var selectedQuantity = Convert.ToInt32( spinner.GetItemAtPosition (e.Position).ToString());
			if (currentquantity != selectedQuantity) {
				vegeList [itemPosition].Quantity = selectedQuantity;
				mAdapter.NotifyItemChanged (itemPosition);
			}

		}
	}
}


