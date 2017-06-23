using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Core;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Xamarin.Forms;

namespace MvvmCross5repro
{
    public class MvvmApp : MvxApplication
    {
        public MvvmApp()
        {
            this.CreatableTypes()
                .EndingWith("Page")
                .InNamespace("MvvmCross5repro.Pages")
                .AsTypes()
                .RegisterAsDynamic();

            this.RegisterAppStart<ViewModels.MvvmCross5reproViewModel>();
        }
    }

    public partial class App : MvxFormsApplication
    {
        public App()
        {
            InitializeComponent();
        }
        
        protected override void OnStart()
        {
            var startUp = Mvx.Resolve<IMvxAppStart>();
            startUp.Start();
        }
    }
}
