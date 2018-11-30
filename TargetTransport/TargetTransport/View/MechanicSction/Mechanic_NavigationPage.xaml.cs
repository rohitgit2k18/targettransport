using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.MechanicSction
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mechanic_NavigationPage : MasterDetailPage
    {
        public Mechanic_NavigationPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            imgProfile.Source = Settings.ProfilePicture;
            lblUserName.Text = Settings.Name;
            Emailtxt.Text = Settings.UserName;
            Mobiletxt.Text = Settings.PhoneNo;
        }
        private void GridHome_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new Mechanic_HomePage());
            App.DetailPage = new Mechanic_HomePage();
            detail.Title = "MecHomePage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridRequestHistory_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new Mechanic_RequestHistoryPage());
            App.DetailPage = new Mechanic_RequestHistoryPage();
            detail.Title = "MecRequestHistoryPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridNotification_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new Mechanic_NotificationPage());
            App.DetailPage = new Mechanic_NotificationPage();
            detail.Title = "MecNotificationPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridSettings_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new Mechanic_SettingsPage());
            App.DetailPage = new Mechanic_SettingsPage();
            detail.Title = "MecSettingsPage";
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
    }
}