using Autofac;
using Codenutz.XFLabs.Basics.ViewModel;
using FFImageLoading.Forms.Touch;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using System;
using UIKit;
using XLabs.Ioc;
using XLabs.Ioc.Autofac;
using XLabs.Platform.Device;

namespace Codenutz.XFLabs.Basics.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : XLabs.Forms.XFormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(43, 132, 211); //bar background
            UINavigationBar.Appearance.TintColor = UIColor.White; //Tint color of button items
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                Font = UIFont.FromName("HelveticaNeue-Light", (nfloat)20f),
                TextColor = UIColor.White
            });
            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsMaps.Init();
            ImageCircleRenderer.Init();
            Corcav.Behaviors.Infrastructure.Init();
            CachedImageRenderer.Init();

            if (!Resolver.IsSet)
				SetIoc();

            
            LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}

		private void SetIoc()
		{
			var containerBuilder = new Autofac.ContainerBuilder();

			containerBuilder.Register(c => AppleDevice.CurrentDevice).As<IDevice>();
			containerBuilder.RegisterType<MainViewModel>().AsSelf();

			Resolver.SetResolver(new AutofacResolver(containerBuilder.Build()));

		}
	}
}
