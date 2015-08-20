package md5423b0cb700dd32419de54c23aacfcf39;


public class ScollImageActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"";
		mono.android.Runtime.register ("flickrimagelist.ScollImageActivity, flickrimagelist, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ScollImageActivity.class, __md_methods);
	}


	public ScollImageActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ScollImageActivity.class)
			mono.android.TypeManager.Activate ("flickrimagelist.ScollImageActivity, flickrimagelist, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();

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
