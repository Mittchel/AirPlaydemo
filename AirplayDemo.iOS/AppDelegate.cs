using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace AirplayDemo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private UIWindow _airplayWindow;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            NSNotificationCenter.DefaultCenter.AddObserver(UIScreen.DidConnectNotification, OnNotifity);

            return base.FinishedLaunching(app, options);
        }

        private void OnNotifity(NSNotification notification)
        {
            UIScreen connectedScreen = (UIScreen)notification.Object;

            if (connectedScreen != null)
            {
                CreateAirplayWindow(connectedScreen);
            }
        }

        private void CreateAirplayWindow(UIScreen connectedScreen)
        {
            _airplayWindow = new UIWindow(connectedScreen.Bounds)
            {
                Screen = connectedScreen,
                Hidden = false
            };

            _airplayWindow.BackgroundColor = UIColor.Red;
        }
    }
}
