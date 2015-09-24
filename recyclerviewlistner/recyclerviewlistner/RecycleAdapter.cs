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
	//----------------------------------------------------------------------
	// VIEW HOLDER

	// Implement the ViewHolder pattern: each ViewHolder holds references
	// to the UI components (ImageView and TextView) within the CardView 
	// that is displayed in a row of the RecyclerView:
	public class VegeViewHolder: RecyclerView.ViewHolder
	{
		public ImageView Image { get; set; }
		public TextView Name { get; set; }
		public Spinner Quantity { get; set; }
		public TextView Price { get; set; }
		public TextView TotalAmount { get; set; }

		// Get references to the views defined in the CardView layout.
		public VegeViewHolder(View itemView, Action<int> itemlistner, Action<object,AdapterView.ItemSelectedEventArgs> spinnerItemSelected )
			:base(itemView)
		{
			Image = itemView.FindViewById<ImageView> (Resource.Id.list_image);
			Name = itemView.FindViewById<TextView> (Resource.Id.Name);
			Price = itemView.FindViewById<TextView> (Resource.Id.Price);
			Quantity = itemView.FindViewById<Spinner> (Resource.Id.spinner1);
			TotalAmount = itemView.FindViewById<TextView> (Resource.Id.total);

			itemView.Click += (sender, e) => itemlistner (base.Position);
			Quantity.ItemSelected+=	new EventHandler<AdapterView.ItemSelectedEventArgs> (spinnerItemSelected);
		}

	}
	public class RecycleAdapter:RecyclerView.Adapter
	{
		//Event Handlers;
		public event EventHandler<int> ItemClick;
		public event EventHandler<AdapterView.ItemSelectedEventArgs> SpinnerItemSelectionChanged;

		public List<Vegetable> Items;
		Activity Context;
		List<string> _quantity = new List<string> ();

		public RecycleAdapter (Activity context, List<Vegetable> list)
		{
			this.Items = list;
			this.Context = context;
			PopulateSpinnerDropDownValues ();
		}

		void PopulateSpinnerDropDownValues()
		{
			_quantity.Add ("0");
			_quantity.Add ("1");
			_quantity.Add ("2");
			_quantity.Add ("3");
			_quantity.Add ("4");
			_quantity.Add ("5");
			_quantity.Add ("6");
			_quantity.Add ("7");
			_quantity.Add ("8");
			_quantity.Add ("9");
		}

		// Create a new photo CardView (invoked by the layout manager): 
		public override RecyclerView.ViewHolder
		OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			// Inflate the CardView for the photo:
			View itemView = LayoutInflater.From(parent.Context).
				Inflate(Resource.Layout.list_items, parent, false);

			// Create a ViewHolder to find and hold these view references, and 
			// register OnClick with the view holder:
			VegeViewHolder vh = new VegeViewHolder(itemView, OnClick,spinner_ItemSelected);
			return vh;
		}

		public override int ItemCount
		{
			get { return Items != null ? Items.Count : 0; }
		}

		void OnClick(int position)
		{
			if (ItemClick != null)
				ItemClick (this, position);
		}

		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			if (SpinnerItemSelectionChanged != null)
				SpinnerItemSelectionChanged (sender, e);
		}
		// Replace the contents of a view (invoked by the layout manager)
		public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
		{
			var item = Items[position];

			var vh = viewHolder as VegeViewHolder;
			var spinnerPos = 0;
			var adapter =new ArrayAdapter<String>(Context, Android.Resource.Layout.SimpleSpinnerItem, _quantity);
			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);

			vh.Name.Text = item.Name;
			vh.Price.Text = string.Format("Price: ${0}",item.Price);
			vh.ItemView.Tag = position;
			if (item.Quantity > 0) {
				spinnerPos = adapter.GetPosition (item.Quantity.ToString ());
				vh.TotalAmount.Text = string.Format ("${0}", item.Price * item.Quantity);
			} else {
				vh.TotalAmount.Text = "";
			}
			vh.Quantity.Tag = position; //keep reference to list view row position
			vh.Quantity.Adapter = adapter;
			vh.Quantity.SetSelection (spinnerPos);
			vh.Image.SetImageResource (item.ImageId);
		}


	}
}

