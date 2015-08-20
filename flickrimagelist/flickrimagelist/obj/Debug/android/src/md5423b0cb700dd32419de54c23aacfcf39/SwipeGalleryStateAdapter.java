package md5423b0cb700dd32419de54c23aacfcf39;


public class SwipeGalleryStateAdapter
	extends android.support.v4.app.FragmentStatePagerAdapter
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_getCount:()I:GetGetCountHandler\n" +
			"n_getPageWidth:(I)F:GetGetPageWidth_IHandler\n" +
			"n_getItem:(I)Landroid/support/v4/app/Fragment;:GetGetItem_IHandler\n" +
			"";
		mono.android.Runtime.register ("flickrimagelist.SwipeGalleryStateAdapter, flickrimagelist, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SwipeGalleryStateAdapter.class, __md_methods);
	}


	public SwipeGalleryStateAdapter (android.support.v4.app.FragmentManager p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == SwipeGalleryStateAdapter.class)
			mono.android.TypeManager.Activate ("flickrimagelist.SwipeGalleryStateAdapter, flickrimagelist, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Support.V4.App.FragmentManager, Xamarin.Android.Support.v4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public int getCount ()
	{
		return n_getCount ();
	}

	private native int n_getCount ();


	public float getPageWidth (int p0)
	{
		return n_getPageWidth (p0);
	}

	private native float n_getPageWidth (int p0);


	public android.support.v4.app.Fragment getItem (int p0)
	{
		return n_getItem (p0);
	}

	private native android.support.v4.app.Fragment n_getItem (int p0);

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
