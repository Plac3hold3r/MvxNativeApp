/***************************************************************************
 * Copyright (C) 2018 Smart software s.r.o. - All Rights Reserved
 *
 * This file is part of MyMarkeeta
 *
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 *
 * Written by Martin Pěnkava, martin.penkava@smart-software.cz.
 *
 **************************************************************************/

using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvxNativeApp.Core.ViewModels.Main;

namespace MvxNativeApp.Droid.Views.Main
{
    [MvxFragmentPresentation(typeof(MainContainerViewModel), Resource.Id.navigation_frame, false)]
    public class MenuFragment : BaseFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        protected override int FragmentLayoutId => Resource.Layout.fragment_menu;
        private NavigationView _navigationView;
        private IMenuItem previousMenuItem;
        private View _view;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _view = base.OnCreateView(inflater, container, savedInstanceState);

            _navigationView = _view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            _navigationView.SetNavigationItemSelectedListener(this);

            var navigationActivity = ParentActivity as INavigationActivity;

            //var drawer = navigationActivity?.Drawer;
            //if (drawer != null)
            //{
            //    drawer.DrawerOpened += delegate
            //    {
            //        SetMenuLanguage();
            //    };
            //}

            InitializeMenu();

            return _view;
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            Navigate(item.ItemId);
            return true;
        }

        private void SetAppVersion()
        {
            if (_navigationView != null)
            {
                var footer = _view.FindViewById<TextView>(Resource.Id.appVersion);
                if (footer != null)
                {
                    var version = Context.PackageManager.GetPackageInfo(Context.PackageName, 0).VersionName;
                    var versionText = "Version";
                    footer.Text = $"{versionText}: {version}";
                }
            }
        }

        private void InitializeMenu()
        {
            var navFirst = _view.FindViewById<TextView>(Resource.Id.nav_sales);
            if (navFirst != null)
            {
                navFirst.Click += delegate
                {
                    Navigate(Resource.Id.nav_sales);
                };
            }

            var navSecond = _view.FindViewById<TextView>(Resource.Id.nav_attendance);
            if (navSecond != null)
            {
                navSecond.Click += delegate
                {
                    Navigate(Resource.Id.nav_attendance);
                };
            }

            var navSettings = _view.FindViewById<TextView>(Resource.Id.nav_settings);
            if (navSettings != null)
            {
                navSettings.Click += delegate
                {
                    Navigate(Resource.Id.nav_settings);
                };
            }

            var navTechnicalSupport = _view.FindViewById<TextView>(Resource.Id.nav_technicalsupport);
            if (navTechnicalSupport != null)
            {
                navTechnicalSupport.Click += delegate
                {
                    Navigate(Resource.Id.nav_technicalsupport);
                };
            }

            var navLogout = _view.FindViewById<TextView>(Resource.Id.nav_logout);
            if (navLogout != null)
            {
                navLogout.Click += delegate
                {
                    Navigate(Resource.Id.nav_logout);
                };
            }
        }

        private async Task Navigate(int itemId)
        {
            var navigationActivity = ParentActivity as INavigationActivity;
            navigationActivity?.Drawer.CloseDrawers();
            await Task.Delay(TimeSpan.FromMilliseconds(250));

            switch (itemId)
            {
                case Resource.Id.nav_sales:
                    await ViewModel.Navigate<FirstViewModel>();
                    break;
                case Resource.Id.nav_attendance:
                    await ViewModel.Navigate<FirstViewModel>();
                    break;
                case Resource.Id.nav_settings:
                    await ViewModel.Navigate<FirstViewModel>();
                    break;
                case Resource.Id.nav_technicalsupport:
                    await ViewModel.Navigate<FirstViewModel>();
                    break;
                case Resource.Id.nav_logout:
                    await ViewModel.Navigate<FirstViewModel>();
                    break;
            }
        }
    }
}
