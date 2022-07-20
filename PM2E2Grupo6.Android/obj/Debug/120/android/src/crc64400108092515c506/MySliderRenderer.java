package crc64400108092515c506;


public class MySliderRenderer
	extends crc643f46942d9dd1fff9.SliderRenderer
	implements
		mono.android.IGCUserPeer,
		android.widget.SeekBar.OnSeekBarChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onProgressChanged:(Landroid/widget/SeekBar;IZ)V:GetOnProgressChanged_Landroid_widget_SeekBar_IZHandler:Android.Widget.SeekBar/IOnSeekBarChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onStartTrackingTouch:(Landroid/widget/SeekBar;)V:GetOnStartTrackingTouch_Landroid_widget_SeekBar_Handler:Android.Widget.SeekBar/IOnSeekBarChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onStopTrackingTouch:(Landroid/widget/SeekBar;)V:GetOnStopTrackingTouch_Landroid_widget_SeekBar_Handler:Android.Widget.SeekBar/IOnSeekBarChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("XamarinAudioPlayer.Android.MySliderRenderer, XamarinAudioPlayer.Android", MySliderRenderer.class, __md_methods);
	}


	public MySliderRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MySliderRenderer.class)
			mono.android.TypeManager.Activate ("XamarinAudioPlayer.Android.MySliderRenderer, XamarinAudioPlayer.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public MySliderRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MySliderRenderer.class)
			mono.android.TypeManager.Activate ("XamarinAudioPlayer.Android.MySliderRenderer, XamarinAudioPlayer.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public MySliderRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MySliderRenderer.class)
			mono.android.TypeManager.Activate ("XamarinAudioPlayer.Android.MySliderRenderer, XamarinAudioPlayer.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void onProgressChanged (android.widget.SeekBar p0, int p1, boolean p2)
	{
		n_onProgressChanged (p0, p1, p2);
	}

	private native void n_onProgressChanged (android.widget.SeekBar p0, int p1, boolean p2);


	public void onStartTrackingTouch (android.widget.SeekBar p0)
	{
		n_onStartTrackingTouch (p0);
	}

	private native void n_onStartTrackingTouch (android.widget.SeekBar p0);


	public void onStopTrackingTouch (android.widget.SeekBar p0)
	{
		n_onStopTrackingTouch (p0);
	}

	private native void n_onStopTrackingTouch (android.widget.SeekBar p0);

	private java.util.ArrayList refList;
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
