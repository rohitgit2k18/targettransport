using AsNum.XFControls.Services;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Helpers;
using TargetTransport.Models;
using TargetTransport_Api.ApiHandler;
using TargetTransport_Api.Models;
using TargetTransport_Api.Models.RequestModels.DriverRequest;
using TargetTransport_Api.Models.ResponseModels.DriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.DriverSction
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Driver_MaintenanceRequestPage : ContentPage
	{
        #region Variable Declaration       
        private Driver_MaintananceListResponse _objDriver_MaintananceListResponse;
        private Driver_MaintananceListRequest _objDriver_MaintananceListRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private RestApi _apiServices;
        private int DailyCheckListId;
        #endregion
        public Driver_MaintenanceRequestPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            _objHeaderModel = new HeaderModel();
            _baseUrl = Settings.Url + Domain.Driver_MaintananceListApiConstant;
            _apiServices = new RestApi();
            _objDriver_MaintananceListResponse = new Driver_MaintananceListResponse();
            GetMaintananceList();
        }
        private async void imgHamburger_Click(object sender, EventArgs e)
        {
            var otherPage = new Driver_NavigationPage();
            otherPage.Detail = new NavigationPage(new Driver_MaintenanceRequestPage());
            var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            await App.NavigationPage.PopToRootAsync(false);
            (App.NavigationPage.CurrentPage as MasterDetailPage).IsPresented = true;
            //otherPage.Detail = new NavigationPage(new Driver_WorksheetPage());
            // (App.NavigationPage.CurrentPage as MasterDetailPage).Detail = homePage;
        }
        private void ButtonRequest_Clicked(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new AddNewMRequestPage());
        }
        public async void GetMaintananceList()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objDriver_MaintananceListRequest = new Driver_MaintananceListRequest
                {
                    CompanyId = Settings.CompanyId.ToString(),
                    EmployeeId = Settings.UserId,
                    Limit = "50",
                    OffSet = "0",
                    SearchKey = string.Empty
                };
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objDriver_MaintananceListResponse = await _apiServices.MaintananceLoadAsync(new Get_API_Url().Driver_MaintananceListApi(_baseUrl), true, _objHeaderModel, _objDriver_MaintananceListRequest);
                if (_objDriver_MaintananceListResponse.Response.StatusCode == 200)
                {
                    if (_objDriver_MaintananceListResponse.Response.MaintenanceRequestList.Count > 0)
                    {
                        listMaintanance.ItemsSource = _objDriver_MaintananceListResponse.Response.MaintenanceRequestList;
                    }
                    else
                    {
                        DependencyService.Get<IToast>().Show("No Data To Display!");
                    }
                    await Navigation.PopAllPopupAsync();
                }
                else
                {
                    await Navigation.PopAllPopupAsync();
                    DependencyService.Get<IToast>().Show("Some Error Occured!");
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                await Navigation.PopAllPopupAsync();
            }
        }
    }
}