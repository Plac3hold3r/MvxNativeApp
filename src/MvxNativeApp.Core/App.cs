using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvxNativeApp.Core.ViewModels.Main;

namespace MvxNativeApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
