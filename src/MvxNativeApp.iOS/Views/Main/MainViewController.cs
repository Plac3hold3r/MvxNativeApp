using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross;
using MvvmCross.Core.Navigation;
using MvvmCross.iOS.Support.XamarinSidebar;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvxNativeApp.Core.ViewModels.Main;
using UIKit;

namespace MvxNativeApp.iOS.Views.Main
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
    public class MainViewController : BaseViewController<MainViewModel>
    {
        private UILabel _labelWelcome, _labelMessage;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ViewModel.ShowMenu();
        }
                
        protected override void CreateView()
        {
            _labelWelcome = new UILabel
            {
                Text = "Welcome!!",
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelWelcome);

            _labelMessage = new UILabel
            {
                Text = "App scaffolded with MvxScaffolding",
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelMessage);
        }

        protected override void LayoutView()
        {
            View.AddConstraints(new FluentLayout[]
           {
                _labelWelcome.WithSameCenterX(View),
                _labelWelcome.WithSameCenterY(View),

                _labelMessage.Below(_labelWelcome, 10f),
                _labelMessage.WithSameWidth(View)
           });
        }
    }
}
