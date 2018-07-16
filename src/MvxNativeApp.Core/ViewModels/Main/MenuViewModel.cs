using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MvxNativeApp.Core.ViewModels.Main
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MenuViewModel()
        {
            _navigationService = Mvx.Resolve<IMvxNavigationService>();
        }

        public async Task Navigate<TViewModel>() where TViewModel : class, IMvxViewModel
        {
            await _navigationService.Navigate<TViewModel>();
        }
    }
}
