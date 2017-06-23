using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Core;
using MvvmCross.Forms.iOS;
using MvvmCross.Forms.iOS.Presenters;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using UIKit;
using Xamarin.Forms;

namespace MvvmCross5repro.iOS
{
    public class MvvmSetup : MvxIosSetup
    {
        public MvxFormsApplication MvxFormsApp { get; private set; }
        public MvvmSetup(IMvxApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new MvvmApp();
        }

        protected override IMvxIosViewPresenter CreatePresenter()
        {
            Forms.Init();

            MvxFormsApp = new App();

            var presenter = new MvxFormsIosPagePresenter(Window, MvxFormsApp);
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }
    }

    [Register("AppDelegate")]
    public partial class AppDelegate : MvxFormsApplicationDelegate
    {
        private UIWindow _window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            _window = new UIWindow(UIScreen.MainScreen.Bounds);
            var setup = new MvvmSetup(this, _window);
            setup.Initialize();

            _window.MakeKeyAndVisible();

            LoadApplication(setup.MvxFormsApp);

            return base.FinishedLaunching(app, options);
        }
    }
}
