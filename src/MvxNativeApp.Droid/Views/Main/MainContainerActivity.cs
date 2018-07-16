using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using MvxNativeApp.Core.ViewModels.Main;

namespace MvxNativeApp.Droid.Views.Main
{
    [Activity(
        Theme = "@style/AppTheme",
        WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class MainContainerActivity : BaseActivity<MainContainerViewModel>, INavigationActivity
    {
        public DrawerLayout Drawer { get; set; }

        protected override int ActivityLayoutId => Resource.Layout.activity_main_container;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            if (savedInstanceState == null)
                ViewModel.ShowMenu();
        }

        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null)
                return;

            var inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

            CurrentFocus.ClearFocus();
        }
    }

    public interface INavigationActivity
    {
        DrawerLayout Drawer { get; set; }
        void HideSoftKeyboard();
    }
}
