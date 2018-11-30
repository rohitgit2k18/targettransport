using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.SubContractorSction
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubContactor_SettingsPage : ContentPage
	{
		public SubContactor_SettingsPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
		}

        private async void imgHamburger_Click(object sender, EventArgs e)
        {
            var otherPage = new SubContractor_NavigationPage();
            otherPage.Detail = new NavigationPage(new SubContactor_SettingsPage());
            var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            await App.NavigationPage.PopToRootAsync(false);
            (App.NavigationPage.CurrentPage as MasterDetailPage).IsPresented = true;
            //otherPage.Detail = new NavigationPage(new Driver_WorksheetPage());
            // (App.NavigationPage.CurrentPage as MasterDetailPage).Detail = homePage;
        }
    }
}