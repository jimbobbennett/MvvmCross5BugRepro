using MvvmCross.Forms.Core;
using Xamarin.Forms;

namespace MvvmCross5repro.Pages
{
    public class MvvmCross5reproPageContentPage : MvxContentPage<ViewModels.MvvmCross5reproViewModel>
    {
    }
    
    public partial class MvvmCross5reproPage : MvvmCross5reproPageContentPage
    {
        public MvvmCross5reproPage()
        {
            InitializeComponent();
        }
    }
}
