package md5193dd44a7fb3cfcfda1a26d42dc2b885;


public class VegeViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("recyclerviewlistner.VegeViewHolder, recyclerviewlistner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", VegeViewHolder.class, __md_methods);
	}


	public VegeViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == VegeViewHolder.class)
			mono.android.TypeManager.Activate ("recyclerviewlistner.VegeViewHolder, recyclerviewlistner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
