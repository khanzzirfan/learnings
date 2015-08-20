package md547d34cffa36765bad5123b9f67b48815;


public class ManagedBitmapDrawable
	extends android.graphics.drawable.BitmapDrawable
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("FFImageLoading.Drawables.ManagedBitmapDrawable, FFImageLoading.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ManagedBitmapDrawable.class, __md_methods);
	}


	public ManagedBitmapDrawable () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ManagedBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.ManagedBitmapDrawable, FFImageLoading.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public ManagedBitmapDrawable (android.content.res.Resources p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == ManagedBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.ManagedBitmapDrawable, FFImageLoading.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Res.Resources, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public ManagedBitmapDrawable (android.content.res.Resources p0, android.graphics.Bitmap p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == ManagedBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.ManagedBitmapDrawable, FFImageLoading.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Res.Resources, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Graphics.Bitmap, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public ManagedBitmapDrawable (android.content.res.Resources p0, java.io.InputStream p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == ManagedBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.ManagedBitmapDrawable, FFImageLoading.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Res.Resources, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.IO.Stream, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public ManagedBitmapDrawable (android.content.res.Resources p0, java.lang.String p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == ManagedBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.ManagedBitmapDrawable, FFImageLoading.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Res.Resources, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public ManagedBitmapDrawable (android.graphics.Bitmap p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == ManagedBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.ManagedBitmapDrawable, FFImageLoading.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Graphics.Bitmap, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public ManagedBitmapDrawable (java.io.InputStream p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == ManagedBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.ManagedBitmapDrawable, FFImageLoading.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "System.IO.Stream, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}


	public ManagedBitmapDrawable (java.lang.String p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == ManagedBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.ManagedBitmapDrawable, FFImageLoading.Droid, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
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
