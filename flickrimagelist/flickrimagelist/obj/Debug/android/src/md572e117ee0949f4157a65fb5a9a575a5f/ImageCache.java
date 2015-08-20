package md572e117ee0949f4157a65fb5a9a575a5f;


public class ImageCache
	extends md572e117ee0949f4157a65fb5a9a575a5f.LruCache_1
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_entryRemoved:(ZLjava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;)V:GetEntryRemoved_ZLjava_lang_Object_Ljava_lang_Object_Ljava_lang_Object_Handler\n" +
			"n_sizeOf:(Ljava/lang/Object;Ljava/lang/Object;)I:GetSizeOf_Ljava_lang_Object_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("FFImageLoading.Cache.ImageCache, FFImageLoading.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ImageCache.class, __md_methods);
	}


	public ImageCache (int p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == ImageCache.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Cache.ImageCache, FFImageLoading.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}


	public void entryRemoved (boolean p0, java.lang.Object p1, java.lang.Object p2, java.lang.Object p3)
	{
		n_entryRemoved (p0, p1, p2, p3);
	}

	private native void n_entryRemoved (boolean p0, java.lang.Object p1, java.lang.Object p2, java.lang.Object p3);


	public int sizeOf (java.lang.Object p0, java.lang.Object p1)
	{
		return n_sizeOf (p0, p1);
	}

	private native int n_sizeOf (java.lang.Object p0, java.lang.Object p1);

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
