using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.SubContractorSction
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubContractor_NavigationPage : MasterDetailPage
    {
        public SubContractor_NavigationPage()
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
            var detail = new NavigationPage(new SubContractor_HomePage());
            App.DetailPage = new SubContractor_HomePage();
            detail.Title = "SCHomePage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridSettings_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new SubContactor_SettingsPage());
            App.DetailPage = new SubContactor_SettingsPage();
            detail.Title = "SCHomePage";
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