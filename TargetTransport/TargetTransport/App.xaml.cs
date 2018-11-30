using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TargetTransport.Helpers;
using TargetTransport.Models;
using TargetTransport.View;
using TargetTransport.View.DriverSction;
using Xamarin.Forms;

namespace TargetTransport
{
    public partial class App : Application
    {
        public static INavigation Navigation;
        public static NavigationPage NavigationPage { get; private set; }
        public static Page DetailPage;
        public static MasterDetailPage MasterDetail
        {
            get;
            private set;
        }

        public static Page GetMainPage()
        {
            MasterDetail = new MasterDetailPage
            {
                //Detail = new Driver_HomePage(),
                //Master = new ContentPage() { Title = "Loading..." }
            };

            return MasterDetail;
        }
        public App()
        {
            InitializeComponent();
            FlowListView.Init();
            Settings.Url = Domain.Url;
            DetailPage = new Driver_HomePage();
             NavigationPage = new NavigationPage(new SplashSignInPage());
          //  NavigationPage = new NavigationPage(new WorkSheetDetailsPage());
            MainPage = NavigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
