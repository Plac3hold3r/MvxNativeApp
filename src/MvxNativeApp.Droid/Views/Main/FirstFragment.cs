using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvxNativeApp.Core.ViewModels.Main;

namespace MvxNativeApp.Droid.Views.Main
{
    [MvxFragmentPresentation(typeof(MainContainerViewModel), Resource.Id.content_frame)]
    public class FirstFragment : BaseFragment<FirstViewModel>
    {
        protected override int FragmentLayoutId => Resource.Layout.fragment_first;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}
