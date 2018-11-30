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
using TargetTransport_Api.Models.RequestModels.MechanicRequest;
using TargetTransport_Api.Models.ResponseModels.MechanicResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.MechanicSction
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mechanic_HomePage : ContentPage
    {
        #region Variable Declaration
        private M_HomeDataResponse _objM_HomeDataResponse;
        private M_HomeDataRequest _objM_HomeDataRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private RestApi _apiServices;
        #endregion
        public Mechanic_HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _objM_HomeDataResponse = new M_HomeDataResponse();
            _objHeaderModel = new HeaderModel();
            _baseUrl = Settings.Url + Domain.M_HomeDataApiConstant;
            _apiServices = new RestApi();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            imgProfile.Source = Settings.ProfilePicture;
            TxtUserName.Text = Settings.Name;
            UserEmail.Text = Settings.UserName;
            UserMobileNo.Text = Settings.PhoneNo;
            GetMechanicData();
        }
        private async void imgHamburger_Click(object sender, EventArgs e)
        {
            var otherPage = new Mechanic_NavigationPage();
            var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            await App.NavigationPage.PopToRootAsync(false);
            (App.NavigationPage.CurrentPage as MasterDetailPage).IsPresented = true;
            // otherPage.Detail = new NavigationPage(new  Driver_HomePage());
        }

        private async void GetMechanicData()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objM_HomeDataRequest = new M_HomeDataRequest
                {
                    id = Settings.UserId.ToString()
                };
                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IToast>().Show("No Internet Connection!");
                }
                else
                {
                    await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objM_HomeDataResponse = await _apiServices.M_HomeDataAsync(new Get_API_Url().CommonBaseApi(_baseUrl), true, _objHeaderModel, _objM_HomeDataRequest);
                    if (_objM_HomeDataResponse.Response.StatusCode == 200)
                    {
                        Settings.CompanyId = _objM_HomeDataResponse.Response.EmployeeObject.CompanyId;
                        if (_objM_HomeDataResponse.Response.MechineHome.Count > 0)
                        {
                            foreach (var Items in _objM_HomeDataResponse.Response.MechineHome)
                            {
                                //Items.ProgramStartTimeBinding = Items.ProgramStartTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                //Items.ApprovedStartTimeBinding = Items.ApprovedStartTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                //Items.StartTimeBinding = Items.StartTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                //Items.EndTimeBinding = Items.EndTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                //Items.WorkDateBinding = Items.WorkDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                                //Items.EndDateBinding = Items.EndDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                                //Items.TotalHrs.ToString();
                            }
                            MechanicHomeList.ItemsSource = _objM_HomeDataResponse.Response.MechineHome;
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
            catch (Exception ex)
            {
                var msg = ex.Message;
                await Navigation.PopAllPopupAsync();
            }
        }

        private void MechanicHomeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var data = e.SelectedItem as MechineHome;
            if (data.IsActive)
            {
                var RequestID = data.Id;              
                Settings.VehicleID = _objM_HomeDataResponse.Response.EmployeeObject.DefaultVehicleId;
                 Settings.RequestId = RequestID;
                Settings.CompanyId = _objM_HomeDataResponse.Response.EmployeeObject.CompanyId;
                App.NavigationPage.Navigation.PushAsync(new Mechanic_ViewDetailsPage());

            }
            else
            {
                DependencyService.Get<IToast>().Show("This Job is No more Active!");
            }
        }
    }
}