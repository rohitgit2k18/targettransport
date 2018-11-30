using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.NonDriverSection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NonDriver_NavigationPage : MasterDetailPage
    {
        private bool IsPlaying = true;
        public NonDriver_NavigationPage()
        {  
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            imgProfile.Source = Settings.ProfilePicture;
            Emailtxt.Text = Settings.UserName;
            Mobiletxt.Text = Settings.PhoneNo;
        }

        private void GridHome_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new NDriver_HomePage());
            App.DetailPage = new NDriver_HomePage();
            detail.Title = "NDHomePage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private async void GridLogout_Tapped(object sender, EventArgs e)
        {
            Settings.IsLoggedIn = false;
            Settings.TokenCode = string.Empty;
            var otherPage = new LoginPage();
            var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            await App.NavigationPage.PopToRootAsync(false);
        }

        private void GridSettings_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new NonDriver_SettingsPage());
            App.DetailPage = new NonDriver_SettingsPage();
            detail.Title = "NDSettingsPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridTimesheet_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new NDriverTimeSheetPage());
            App.DetailPage = new NDriverTimeSheetPage();
            detail.Title = "NDTimeSheetPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridShift_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new ND_EndShiftPage());
            App.DetailPage = new ND_EndShiftPage();
            detail.Title = "EndShiftPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridPlayTime_Tapped(object sender, EventArgs e)
        {
            // MyTimer onjMyTimer = new MyTimer();
            if (IsPlaying)
            {
                ImageTimer.Source = "pause.png";
                IsPlaying = false;
                // onjMyTimer
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    Device.BeginInvokeOnMainThread(action: () => LabelShowTime.Text = DateTime.Now.ToString("HH:mm:ss"));
                    return true;
                });
            }
            else
            {
                ImageTimer.Source = "play.png";
                IsPlaying = true;

                LabelShowTime.Text = DateTime.Now.ToString("HH:mm:ss");

                //Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                //{
                //    Device.BeginInvokeOnMainThread(action: () => LabelShowTime.Text = DateTime.Now.ToString("HH:mm:ss"));
                //    return false;
                //});



                // System.Threading.Interlocked.Exchange(ref this.cancellation, new CancellationTokenSource()).Cancel();

            }
            //var detail = new NavigationPage(new Driver_HomePage());
            //App.DetailPage = new Driver_HomePage();
            //detail.Title = "HomePage";
            //App.Navigation = detail.Navigation;
            //Detail = detail;
            //IsPresented = false;
        }
    }
}