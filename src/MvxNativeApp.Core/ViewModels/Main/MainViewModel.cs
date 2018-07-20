using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Navigation;

namespace MvxNativeApp.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MainViewModel()
        {
            _navigationService = Mvx.Resolve<IMvxNavigationService>();
            Title = nameof(MainViewModel);
        }

        public async Task ShowMenu()
        {
            await _navigationService.Navigate<MenuViewModel>();
        }
    }
}
