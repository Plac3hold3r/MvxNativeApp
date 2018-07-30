using System.Threading.Tasks;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Plugin.Sidebar;
using MvxNativeApp.Core.ViewModels.Main;
using MvxNativeApp.iOS.Styles;
using UIKit;

namespace MvxNativeApp.iOS.Views.Main
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
    public class MainViewController : BaseViewController<MainViewModel>
    {
        private UILabel _labelWelcome, _labelMessage;
        private UIButton _button;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //ViewModel.ShowMenu();
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

            _button = new UIButton
            {
                BackgroundColor = ColorPalette.PrimaryLight
            };
            _button.SetTitleColor(ColorPalette.Primary, UIControlState.Normal);
            _button.SetTitle("CLICK", UIControlState.Normal);
            Add(_button);
        }

        protected override void LayoutView()
        {
            View.AddConstraints(new FluentLayout[]
           {
                _labelWelcome.WithSameCenterX(View),
                _labelWelcome.WithSameCenterY(View),

                _labelMessage.Below(_labelWelcome, 10f),
                _labelMessage.WithSameWidth(View),

                _button.Below(_labelMessage, 10f),
                _button.WithSameWidth(View)
           });
        }

        protected override void BindView()
        {
            base.BindView();

            _button.TouchDown += delegate
            {
                Task.Run(async () => await ViewModel.ShowMenu());
            };
        }
    }
}
