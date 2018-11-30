using AsNum.XFControls.Services;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Helpers;
using TargetTransport.Models;
using TargetTransport_Api.ApiHandler;
using TargetTransport_Api.Models;
using TargetTransport_Api.Models.RequestModels.NonDriverRequest;
using TargetTransport_Api.Models.ResponseModels.NonDriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.NonDriverSection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NDriver_HomePage : ContentPage
    {
        #region Variable Declaration
        private NonDriver_HomeDataResponse _objNonDriver_HomeDataResponse;
        private NonDriver_HomeDataRequest _objNonDriver_HomeDataRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private RestApi _apiServices;
        #endregion
        public NDriver_HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _objNonDriver_HomeDataResponse = new NonDriver_HomeDataResponse();
            _objHeaderModel = new HeaderModel();
            _baseUrl = Settings.Url + Domain.NonDriver_HomeApiConstant;
            _apiServices = new RestApi();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetNonDriverData();
            imgProfile.Source = Settings.ProfilePicture;
            TxtUserName.Text = Settings.Name;
            UserEmail.Text = Settings.UserName;
            UserMobileNo.Text = Settings.PhoneNo;
        }
        private async void imgHamburger_Click(object sender, EventArgs e)
        {
            var otherPage = new NonDriver_NavigationPage();
            var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            await App.NavigationPage.PopToRootAsync(false);
            (App.NavigationPage.CurrentPage as MasterDetailPage).IsPresented = true;
            // otherPage.Detail = new NavigationPage(new  Driver_HomePage());
        }
        private async void GetNonDriverData()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objNonDriver_HomeDataRequest = new NonDriver_HomeDataRequest
                {
                    id = Settings.UserId.ToString()
                };
                    if(!CrossConnectivity.Current.IsConnected)
                    {
                    DependencyService.Get<IToast>().Show("No Internet Connection!");
                    }
                   else
                   {
                    await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objNonDriver_HomeDataResponse = await _apiServices.NonDriver_HomeDataAsync(new Get_API_Url().CommonBaseApi(_baseUrl), true, _objHeaderModel, _objNonDriver_HomeDataRequest);
                    if (_objNonDriver_HomeDataResponse.Response.StatusCode == 200)
                    {
                        Settings.CompanyId = _objNonDriver_HomeDataResponse.Response.EmployeeObject.CompanyId;
                        if (_objNonDriver_HomeDataResponse.Response.NonDriverHome.Count > 0)
                        {
                            foreach (var Items in _objNonDriver_HomeDataResponse.Response.NonDriverHome)
                            {
                                Items.ProgramStartTimeBinding = Items.ProgramStartTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                Items.ApprovedStartTimeBinding = Items.ApprovedStartTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                Items.StartTimeBinding = Items.StartTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                Items.EndTimeBinding = Items.EndTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                Items.WorkDateBinding = Items.WorkDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                                Items.EndDateBinding = Items.EndDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                                Items.TotalHrs.ToString();
                            }
                            NDJobList.ItemsSource = _objNonDriver_HomeDataResponse.Response.NonDriverHome;
                            DependencyService.Get<IToast>().Show("Sucess");
                        }
                        else
                        {
                            DependencyService.Get<IToast>().Show("No Data To Display!");
                        }                                            
                    }
                    else
                    {
                        DependencyService.Get<IToast>().Show("Error Occured");
                    }
                    await Navigation.PopAllPopupAsync();
                   }
            
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                await Navigation.PopAllPopupAsync();
            }
        }

        private void NDJobList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var data = e.SelectedItem as NonDriverHome;
            if(data.IsActive)
            {
                var WorksheetId = data.Id;
                var VehicleId = data;
                Settings.VehicleID = _objNonDriver_HomeDataResponse.Response.EmployeeObject.DefaultVehicleId;
                // Settings.WorksheetID = WorksheetId;
                Settings.CompanyId = _objNonDriver_HomeDataResponse.Response.EmployeeObject.CompanyId;
                App.NavigationPage.Navigation.PushAsync(new NDriverDailyCheckListPage());

            }
            else
            {
                DependencyService.Get<IToast>().Show("This Job is No more Active!");
            }
        }
    }
}