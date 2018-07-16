using MvvmCross.Navigation;

namespace MvxNativeApp.Core.ViewModels.Main
{
    public class MainContainerViewModel : BaseViewModel
    {
        protected readonly IMvxNavigationService _navigationService;

        public MainContainerViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void ShowMenu()
        {
            _navigationService.Navigate<MenuViewModel>();
        }
    }
}
