using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.DriverSction
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Driver_NavigationPage : MasterDetailPage
    {
        private bool IsPlaying = true;
        public Driver_NavigationPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            LabelShowTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            imgProfile.Source = Settings.ProfilePicture;
            lblUserName.Text = Settings.Name;
            labelEmail.Text = Settings.UserName;
            LabelPhoneNo.Text = Settings.PhoneNo;
        }
        private void GridHome_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new Driver_HomePage());
            App.DetailPage = new Driver_HomePage();
            detail.Title = "HomePage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridShift_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new EndShiftPage());
            App.DetailPage = new EndShiftPage();
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

        private void GridWorkSheet_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new Driver_WorksheetPage());
            App.DetailPage = new Driver_WorksheetPage();
            detail.Title = "WorksheetPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridMaintainance_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new Driver_MaintenanceRequestPage());
            App.DetailPage = new Driver_MaintenanceRequestPage();
            detail.Title = "MaintenanceRequestPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridTimesheet_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new Driver_TimeSheetPage());
            App.DetailPage = new Driver_TimeSheetPage();
            detail.Title = "TimeSheetPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridSettings_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new Driver_SettingsPage());
            App.DetailPage = new Driver_SettingsPage();
            detail.Title = "SettingsPage";
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
            //var detail = new NavigationPage(new Driver_HomePage());
            //App.DetailPage = new Driver_HomePage();
            //detail.Title = "HomePage";
            //App.Navigation = detail.Navigation;
            //Detail = detail;
            //IsPresented = false;
        }
    }
    public class MyTimer
    {
        private readonly TimeSpan _timespan;
        private readonly Action _callback;
        private readonly bool _repeat;

        private bool _running;
        private bool _timerCallbackPending;

        public MyTimer(TimeSpan timespan, Action callback, bool repeat)
        {
            _timespan = timespan;
            _callback = callback;
            _repeat = repeat;
        }

        public void Start()
        {
            _running = true;
            ScheduleTimerIfNeeded();
        }

        public void Stop()
        {
            _running = false;
        }

        private void ScheduleTimerIfNeeded()
        {
            if (!_timerCallbackPending)
            {
                {
                    _timerCallbackPending = true;
                    Device.StartTimer(_timespan, TimerCallback);
                }
            }

            bool TimerCallback()
            {
                if (_running)
                {
                    _callback.Invoke();
                }

                bool reschedule = _repeat && _running;

                _timerCallbackPending = reschedule;

                return reschedule;
            }
        }
    }
}