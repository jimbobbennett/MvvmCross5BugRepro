using System;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using System.Diagnostics;
using MvvmCross.Platform;

namespace MvvmCross5repro.ViewModels
{
    public class MvvmCross5reproViewModel : MvxViewModel
    {
        readonly IMvxNavigationService navigationService;

        public MvvmCross5reproViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
   
        private IMvxAsyncCommand _next;
        public IMvxAsyncCommand Next => _next ?? (_next = new MvxAsyncCommand(NextPage));
        
        public async Task NextPage()
        {
            await navigationService.Navigate<NextViewModel, string>("Success");
        }
    }
    
    public class NextViewModel : MvxViewModel<string>
    {
        private string _content = "Failed";
		public string Content 
        {
            get => _content;
            private set => SetProperty(ref _content, value);
        }
        
        public NextViewModel()
        {
            Debug.WriteLine("NextViewModel constructor called!");
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task Initialize(string parameter)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            Content = parameter;
            await Task.FromResult(true);
        }
        
    }
}
