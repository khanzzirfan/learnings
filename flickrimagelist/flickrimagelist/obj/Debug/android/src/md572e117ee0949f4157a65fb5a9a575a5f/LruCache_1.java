package md572e117ee0949f4157a65fb5a9a575a5f;


public abstract class LruCache_1
	extends android.util.LruCache
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("FFImageLoading.Cache.LruCache`1, FFImageLoading.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", LruCache_1.class, __md_methods);
	}


	public LruCache_1 (int p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == LruCache_1.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Cache.LruCache`1, FFImageLoading.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
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
