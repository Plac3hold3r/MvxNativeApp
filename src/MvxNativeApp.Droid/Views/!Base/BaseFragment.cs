using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V4;
using MvvmCross.ViewModels;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvxNativeApp.Droid.Views.Main;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content.Res;

namespace MvxNativeApp.Droid.Views
{
    public abstract class BaseFragment<TViewModel> : MvxFragment<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
        protected bool ShowHamburgerMenu { get; set; } = false;
        protected abstract int FragmentLayoutId { get; }

        protected virtual string Title { get; set; }

        private Toolbar _toolbar;
        private MvxActionBarDrawerToggle _drawerToggle;
        private View _view;

        public BaseFragment()
        {
            Title = "Title";
        }

        public MvxAppCompatActivity ParentActivity => ((MvxAppCompatActivity)Activity);

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            _view = this.BindingInflate(FragmentLayoutId, null);

            _toolbar = _view.FindViewById<Toolbar>(Resource.Id.toolbar);
            if (_toolbar != null && ParentActivity != null)
            {
                ParentActivity.SetSupportActionBar(_toolbar);
                ParentActivity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);

                if (ShowHamburgerMenu)
                {
                    _drawerToggle = new MvxActionBarDrawerToggle(
                    ParentActivity, // host Activity
                    (ParentActivity as INavigationActivity).Drawer, // DrawerLayout object
                    _toolbar, // nav drawer icon to replace 'Up' caret
                    Resource.String.drawer_open, // "open drawer" description
                    Resource.String.drawer_close // "close drawer" description
                );
                    _drawerToggle.DrawerOpened +=
                        (object sender, ActionBarDrawerEventArgs e) => (ParentActivity as INavigationActivity).HideSoftKeyboard();
                    (ParentActivity as INavigationActivity).Drawer.AddDrawerListener(_drawerToggle);
                }

                if (!string.IsNullOrEmpty(Title))
                    ParentActivity.SupportActionBar.Title = Title;

                ParentActivity.SupportActionBar.SetDisplayShowTitleEnabled(false);
                var titleTextView = (TextView)_toolbar.FindViewById(Resource.Id.toolbar_title);
                if (titleTextView != null)
                {
                    if (!string.IsNullOrEmpty(Title))
                        titleTextView.Text = Title;
                }

            }

            return _view;
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            if (_drawerToggle != null)
            {
                _drawerToggle.OnConfigurationChanged(newConfig);
            }
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            if (_drawerToggle != null)
            {
                _drawerToggle.SyncState();
            }
        }
    }
}
