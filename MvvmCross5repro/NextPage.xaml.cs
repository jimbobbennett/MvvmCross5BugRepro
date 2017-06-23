using System;
using System.Collections.Generic;
using MvvmCross.Forms.Core;
using Xamarin.Forms;

namespace MvvmCross5repro.Pages
{
    public class NextPageContentPage : MvxContentPage<ViewModels.NextViewModel>
    {

    }

    public partial class NextPage : NextPageContentPage
    {
        public NextPage()
        {
            InitializeComponent();
        }
    }
}
