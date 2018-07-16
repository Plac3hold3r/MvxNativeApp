using Foundation;
using MvvmCross.Platforms.Ios.Core;
using MvxNativeApp.Core;

namespace MvxNativeApp.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}
