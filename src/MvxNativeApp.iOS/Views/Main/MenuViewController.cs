using Foundation;
using MvxNativeApp.Core.ViewModels.Main;
using UIKit;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using System.Threading.Tasks;
using MvvmCross.Plugin.Sidebar;

namespace MvxNativeApp.iOS.Views.Main
{
    [Register("MenuViewController")]
    [MvxSidebarPresentation(MvxPanelEnum.Left, MvxPanelHintType.PushPanel, false)]
    public class MenuViewController : BaseViewController<MenuViewModel>
    {
        public MenuViewController()
        { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var scrollView = new UIScrollView(View.Frame)
            {
                ShowsHorizontalScrollIndicator = false,
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight
            };

            // create a binding set for the appropriate view model
            //var set = this.CreateBindingSet<MenuViewController, MenuViewModel>();

            var homeButton = new UIButton(new CGRect(0, 100, 320, 40));
            homeButton.SetTitle("Home", UIControlState.Normal);
            homeButton.BackgroundColor = UIColor.White;
            homeButton.SetTitleColor(UIColor.Black, UIControlState.Normal);

            homeButton.TouchDown += delegate
            {
                Task.Run(async () => await ViewModel.Navigate<MainViewModel>());
            };

            var settingsButton = new UIButton(new CGRect(0, 100, 320, 40));
            settingsButton.SetTitle("Settings", UIControlState.Normal);
            settingsButton.BackgroundColor = UIColor.White;
            settingsButton.SetTitleColor(UIColor.Black, UIControlState.Normal);

            settingsButton.TouchDown += delegate
            {
                Task.Run(async () => await ViewModel.Navigate<MainViewModel>());
            };

            var helpButton = new UIButton(new CGRect(0, 100, 320, 40));
            helpButton.SetTitle("Help & Feedback", UIControlState.Normal);
            helpButton.BackgroundColor = UIColor.White;
            helpButton.SetTitleColor(UIColor.Black, UIControlState.Normal);

            helpButton.TouchDown += delegate
            {
                Task.Run(async () => await ViewModel.Navigate<MainViewModel>());
            };

            Add(scrollView);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                scrollView.AtLeftOf(View),
                scrollView.AtTopOf(View),
                scrollView.WithSameWidth(View),
                scrollView.WithSameHeight(View));

            scrollView.Add(homeButton);
            scrollView.Add(settingsButton);
            scrollView.Add(helpButton);

            scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var constraints = scrollView.VerticalStackPanelConstraints(new Margins(20, 10, 20, 10, 5, 5), scrollView.Subviews);
            scrollView.AddConstraints(constraints);
        }

        public override void ViewWillAppear(bool animated)
        {
            Title = "Left Menu View";
            base.ViewWillAppear(animated);

            NavigationController.NavigationBarHidden = true;
        }
    }
}
