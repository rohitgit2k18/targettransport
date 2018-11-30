using AsNum.XFControls.Services;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Helpers;
using TargetTransport.Models;
using TargetTransport.View.MechanicSction;
using TargetTransport.View.NonDriverSection;
using TargetTransport.View.SubContractorSction;
using TargetTransport.ViewModels;
using TargetTransport_Api.ApiHandler;
using TargetTransport_Api.Models;
using TargetTransport_Api.Models.RequestModels.DriverRequest;
using TargetTransport_Api.Models.ResponseModels.DriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.DriverSction
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Driver_HomePage : ContentPage
	{
        #region Variable Declaration
        private Driver_HomeResponse _objDriver_HomeResponse;
        private Driver_HomeRequest _objDriver_HomeRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private RestApi _apiServices;
        #endregion
        private Driver_HomeViewModel _objDriver_HomeViewModel;

        public Driver_HomePage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            _objDriver_HomeViewModel = new Driver_HomeViewModel();
            BindingContext = _objDriver_HomeViewModel;
            _objDriver_HomeResponse = new Driver_HomeResponse();
            _objHeaderModel = new HeaderModel();
            _baseUrl = Settings.Url + Domain.Driver_HomeApiConstant;
            _apiServices = new RestApi();
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetDriverData();
        }
        public async void GetDriverData()
        {
            try
            {
                _objDriver_HomeRequest = new Driver_HomeRequest
                {
                    id = Settings.UserId.ToString()
                };
                _objHeaderModel.TokenCode = Settings.TokenCode;
                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IToast>().Show("You are Offline Please Check Your Internet Connection!");
                }
                else
                {
                   // await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objDriver_HomeResponse = await _apiServices.Driver_HomeAsync(new Get_API_Url().Driver_HomeApi(_baseUrl), true, _objHeaderModel, _objDriver_HomeRequest);
                    if (_objDriver_HomeResponse.Response.StatusCode == 200)
                    {
                        Settings.CompanyId = _objDriver_HomeResponse.Response.EmployeeObject.CompanyId;
                        //DependencyService.Get<IToast>().Show("Sucess");
                    }
                    else
                    {
                        DependencyService.Get<IToast>().Show("Error Occured");
                    }
                  //  await Navigation.PopAllPopupAsync();
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }
        private async void imgHamburger_Click(object sender, EventArgs e)
        {
            var otherPage = new Driver_NavigationPage();
            var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            await App.NavigationPage.PopToRootAsync(false);
            (App.NavigationPage.CurrentPage as MasterDetailPage).IsPresented = true;
           // otherPage.Detail = new NavigationPage(new  Driver_HomePage());
        }

        private void imgWorkSheet_Click(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new Driver_WorksheetPage(),true);
        }
        
        private void imgTimeSheet_Click(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new Driver_TimeSheetPage());
        }
        private void imgMaintanance_Click(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new Driver_MaintenanceRequestPage());
        }
        private void StackEditBtn_Tapped(object sender, EventArgs e)
        {
             App.NavigationPage.Navigation.PushAsync(new Driver_ProfilePage());
           // throw new NotImplementedException();
        }
    }
}