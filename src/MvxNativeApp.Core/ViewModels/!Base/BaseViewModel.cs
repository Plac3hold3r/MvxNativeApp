using MvvmCross.ViewModels;

namespace MvxNativeApp.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        public virtual string Title { get; set; }

        public BaseViewModel()
        {
            Title = "Title";
        }
    }
}
