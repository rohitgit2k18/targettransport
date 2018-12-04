using AsNum.XFControls.Services;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TargetTransport.Helpers;
using TargetTransport.Models;
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
	public partial class AddWorkSheetPage : ContentPage
	{
        #region Variable Declaration
        private AddWorksheetResponseModel _objAddWorksheetResponseModel;
        private AddWorkSheetRequestModel _objAddWorksheetRequestModel;
        private Driver_LoadTypeResponse _objDriver_LoadTypeResponse;
        private Driver_LoadTypesRequest _objDriver_LoadTypesRequest;
        private Driver_SelectVehicleRequest _objDriver_SelectVehicleRequest;
        private DriverSelectVehicleResonse _objDriverSelectVehicleResonse;
        private LoadCompanySiteRequest _objLoadCompanySiteRequest;
        private LoadCompanySiteResponse _objLoadCompanySiteResponse;
        private Driver_GetClientsRequest _objDriver_GetClientsRequest;
        private Driver_GetClientsResponse _objDriver_GetClientsResponse;
        private AddWorkSheetNumberResponse _objAddWorkSheetNumberResponse;
        private AddWorkSheetNumberRequest _objAddWorkSheetNumberRequest;
        private ShiftDataViewModel _objShiftDataViewModel;
        private HeaderModel _objHeaderModel;
        private string _baseUrlLoadTypes;
        private string _baseUrlVehicle;
        private string _baseUrlCompanySite;
        private string _baseUrlGetClients;
        private string _baseUrlAddWorkSheet;
        private string _baseUrlGetWorksheetNo;
        private RestApi _apiServices;
        private Int32 ClientId;
        #endregion
        public AddWorkSheetPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            _objAddWorksheetRequestModel = new AddWorkSheetRequestModel();
            _objAddWorksheetResponseModel = new AddWorksheetResponseModel();
            _objDriver_LoadTypeResponse = new Driver_LoadTypeResponse();
            _objDriverSelectVehicleResonse = new DriverSelectVehicleResonse();
            _objLoadCompanySiteResponse = new LoadCompanySiteResponse();
            _objDriver_GetClientsResponse = new Driver_GetClientsResponse();
            _objAddWorkSheetNumberResponse = new AddWorkSheetNumberResponse();
            _objShiftDataViewModel = new ShiftDataViewModel();
            dropdownShift.ItemsSource = _objShiftDataViewModel.GetShiftType();
            _objHeaderModel = new HeaderModel();
            _apiServices = new RestApi();
            _baseUrlLoadTypes = Settings.Url + Domain.GetLoadTypesApiConstant;
            _baseUrlVehicle= Settings.Url + Domain.SelectVehicleApiConstant;
            _baseUrlCompanySite = Settings.Url + Domain.GetCompanySitesApiConstant;
            _baseUrlGetClients = Settings.Url + Domain.GetClientsApiConstant;
            _baseUrlAddWorkSheet = Settings.Url + Domain.AddWorkSheetApiConstant;
            _baseUrlGetWorksheetNo = Settings.Url + Domain.GetWorksheetNumberApiConstant;

            BindingContext = _objAddWorksheetRequestModel;
           // xyz("WKA009");

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            claim_minutes.Time = DateTime.Now.TimeOfDay;
            claim_minutes.Format = "hh:mm";
            LoadWorkSheetNumber();
            LoadClients();
           // LoadVehicleData();
            GetLoadTypes();
        }
       
        private async void LoadWorkSheetNumber()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objAddWorkSheetNumberRequest = new AddWorkSheetNumberRequest
                {
                    CompanyId = Settings.CompanyId
                    
                };
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objAddWorkSheetNumberResponse = await _apiServices.GetWorkSheetNumberAsync(new Get_API_Url().CommonBaseApi(_baseUrlGetWorksheetNo), true, _objHeaderModel, _objAddWorkSheetNumberRequest);
                if (_objAddWorkSheetNumberResponse.Response.StatusCode == 200)
                {
                    DependencyService.Get<IToast>().Show("Sucess!");
                    XFEntWorkshettNumber.Text = _objAddWorkSheetNumberResponse.Response.Data;
                    XFEntWorkshettNumber.IsEnabled = false;
                     await Navigation.PopAllPopupAsync();
                    //  LoadComapnySites();
                }
                else
                {
                    DependencyService.Get<IToast>().Show("Something Bad Happend please Try again Later!");
                    await Navigation.PopAllPopupAsync();
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async void LoadClients()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objDriver_GetClientsRequest = new Driver_GetClientsRequest
                {
                    CompanyId = Settings.CompanyId,                   
                    SearchKey = string.Empty,
                    Limit = 200,
                    OffSet = 0,
                     CreatedBy=1
                };
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objDriver_GetClientsResponse = await _apiServices.GetClientsAsync(new Get_API_Url().CommonBaseApi(_baseUrlGetClients), true, _objHeaderModel, _objDriver_GetClientsRequest);
                if (_objDriver_GetClientsResponse.Response.StatusCode == 200)
                {
                    DependencyService.Get<IToast>().Show("Sucess!!");
                    dropdownCustomerName.ItemsSource = _objDriver_GetClientsResponse.Response.ClientList;
                    await Navigation.PopAllPopupAsync();
                  //  LoadComapnySites();
                }
                else
                {
                    DependencyService.Get<IToast>().Show("Something Bad Happend please Try again Later!");
                    await Navigation.PopAllPopupAsync();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        
        private async void LoadComapnySites()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objLoadCompanySiteRequest = new LoadCompanySiteRequest
                {
                    CompanyId = Settings.CompanyId,
                     ClientId= ClientId,
                    SearchKey=string.Empty,
                     Limit= 200,
                     OffSet=0
                };
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objLoadCompanySiteResponse = await _apiServices.GetCompanySitesAsync(new Get_API_Url().CommonBaseApi(_baseUrlCompanySite), true, _objHeaderModel, _objLoadCompanySiteRequest);
                if (_objLoadCompanySiteResponse.Response.StatusCode == 200)
                {
                    DependencyService.Get<IToast>().Show("Sucess!!");
                    dropdownSiteName.ItemsSource = _objLoadCompanySiteResponse.Response.CompanySiteList;
                    await Navigation.PopAllPopupAsync();
                }
                else
                {
                    DependencyService.Get<IToast>().Show("Something Bad Happend please Try again Later!");
                    await Navigation.PopAllPopupAsync();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        private async void LoadVehicleData()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objDriver_SelectVehicleRequest = new Driver_SelectVehicleRequest
                {
                    Id = Settings.UserId,
                    CompanyId = Settings.CompanyId,
                    ClientId= _objAddWorksheetRequestModel.ClientId
                };
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objDriverSelectVehicleResonse = await _apiServices.GetDriverSelectVehicleListAsync(new Get_API_Url().VehicleListApi(_baseUrlVehicle), true, _objHeaderModel, _objDriver_SelectVehicleRequest);
                if (_objDriverSelectVehicleResonse.Response.StatusCode == 200)
                {
                    DependencyService.Get<IToast>().Show("Sucess!!");
                    dropdownVehicleName.ItemsSource = _objDriverSelectVehicleResonse.Response.VechicleListByEmployeeId;
                    await Navigation.PopAllPopupAsync();
                }
                else
                {
                    DependencyService.Get<IToast>().Show("Something Bad Happend please Try again Later!");
                    await Navigation.PopAllPopupAsync();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async void GetLoadTypes()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objDriver_LoadTypesRequest = new Driver_LoadTypesRequest
                {
                    CreatedBy = 0
                };
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objDriver_LoadTypeResponse = await _apiServices.GetLoadTypesAsync(new Get_API_Url().GetLoadTypesApi(_baseUrlLoadTypes), true, _objHeaderModel, _objDriver_LoadTypesRequest);
                if (_objDriver_LoadTypeResponse.Response.StatusCode == 200)
                {
                    //await App.NavigationPage.Navigation.PushAsync(new Driver_SignatureScreenPage(DailyCheckListID));
                    dropdownLoadType.ItemsSource = _objDriver_LoadTypeResponse.Response.LoadTypes;
                    DependencyService.Get<IToast>().Show(_objDriver_LoadTypeResponse.Response.Message);
                    await Navigation.PopAllPopupAsync();
                }
                else
                {
                    DependencyService.Get<IToast>().Show(_objDriver_LoadTypeResponse.Response.Description);
                    await Navigation.PopAllPopupAsync();
                }
            }
            catch (Exception ex)
            {
                await Navigation.PopAllPopupAsync();
                var msg = ex.Message;
            }
        }


        private void BtnBack_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }

        private async void btnAddWorkSheetSubmit_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IToast>().Show("No Internet Connection!");
                }
                else
                {
                    _objAddWorksheetRequestModel.EmployeeId = Settings.UserId;
                    _objAddWorksheetRequestModel.EmployeeName = Settings.Name;
                    _objAddWorksheetRequestModel.StartTime = DateTime.Now.ToString();
                    _objAddWorksheetRequestModel.ComapnyId = Settings.CompanyId;
                    _objAddWorksheetRequestModel.AssignTo = 4;
                    _objAddWorksheetRequestModel.CreatedOn = DateTime.Now;
                    _objAddWorksheetRequestModel.Createdby = 1;
                    _objAddWorksheetRequestModel.IsActive = true;
                    _objAddWorksheetRequestModel.WorksheetStatus = 1;
                    if (string.IsNullOrEmpty(_objAddWorksheetRequestModel.WorkSheetNumber) ||
                        string.IsNullOrEmpty(_objAddWorksheetRequestModel.JobDescription) ||
                        string.IsNullOrEmpty(_objAddWorksheetRequestModel.VechicleName) ||
                        string.IsNullOrEmpty(_objAddWorksheetRequestModel.SiteName) ||
                        string.IsNullOrEmpty(_objAddWorksheetRequestModel.ClientName) ||
                         string.IsNullOrEmpty(_objAddWorksheetRequestModel.LoadTypeName)
                        )
                    {
                        DependencyService.Get<IToast>().Show("please fill all the filed first!");
                    }
                    else
                    {
                        _objHeaderModel.TokenCode = Settings.TokenCode;
                        
                        await Navigation.PushPopupAsync(new LoadingPopPage());
                        _objAddWorksheetResponseModel = await _apiServices.AddWorkSheetAsync(new Get_API_Url().CommonBaseApi(_baseUrlAddWorkSheet), true, _objHeaderModel, _objAddWorksheetRequestModel);
                        if (_objDriver_LoadTypeResponse.Response.StatusCode == 200)
                        {
                           // await App.NavigationPage.Navigation.PushAsync(new Driver_SignatureScreenPage(DailyCheckListID));
                           // dropdownLoadType.ItemsSource = _objDriver_LoadTypeResponse.Response.LoadTypes;
                            DependencyService.Get<IToast>().Show(_objDriver_LoadTypeResponse.Response.Message);
                            await App.NavigationPage.Navigation.PushAsync(new Driver_WorksheetPage());
                            await Navigation.PopAllPopupAsync();
                        }
                        else
                        {
                            DependencyService.Get<IToast>().Show(_objDriver_LoadTypeResponse.Response.Description);
                            await Navigation.PopAllPopupAsync();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void Entryclaim_minutes_Focused(object sender, FocusEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Entryclaim_minutes.IsEnabled = false;
                claim_minutes.Focus();

            });
        }

        private void claim_minutes_Unfocused(object sender, FocusEventArgs e)
        {
            Entryclaim_minutes.IsEnabled = true;
            Entryclaim_minutes.Unfocus();
            Entryclaim_minutes.Text = claim_minutes.Time.ToString();
        }

        private void Entryselect_date_Focused(object sender, FocusEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Entryselect_date.IsEnabled = false;
                select_date.Focus();

            });
        }

        private void select_date_Unfocused(object sender, FocusEventArgs e)
        {
            Entryselect_date.IsEnabled = true;
            Entryselect_date.Unfocus();
            Entryselect_date.Text = select_date.Date.ToString();
        }

        private void dropdownLoadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                var data = picker.Items[picker.SelectedIndex];
                var LoadTypedata = picker.SelectedItem as LoadType;
                _objAddWorksheetRequestModel.LoadTypeId = LoadTypedata.Id;
                _objAddWorksheetRequestModel.LoadTypeName = LoadTypedata.Type;
            }
            else
            {
                DependencyService.Get<IToast>().Show("please select LoadType!");
            }
        }

        private void dropdownCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                var data = picker.Items[picker.SelectedIndex];
                var CustomernameData = picker.SelectedItem as ClientList;
                ClientId = CustomernameData.Id;
                _objAddWorksheetRequestModel.ClientId = ClientId;
                _objAddWorksheetRequestModel.ClientName = CustomernameData.ClientName;
                LoadComapnySites();
                LoadVehicleData();
            }
            else
            {
                DependencyService.Get<IToast>().Show("please select LoadType!");
            }
        }

        private void dropdownSiteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                var data = picker.Items[picker.SelectedIndex];
                var SitenameData = picker.SelectedItem as CompanySiteList;
               
                _objAddWorksheetRequestModel.SiteId = SitenameData.Id;
                _objAddWorksheetRequestModel.SiteName = SitenameData.Name;
                if(!string.IsNullOrEmpty(SitenameData.SiteInstructions))
                {
                    _objAddWorksheetRequestModel.JobDescription = SitenameData.SiteInstructions;
                }
                else
                {
                    _objAddWorksheetRequestModel.JobKMs = string.Empty;
                }
            }
            else
            {
                DependencyService.Get<IToast>().Show("please select LoadType!");
            }
        }

        private void dropdownVehicleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                var data = picker.Items[picker.SelectedIndex];
                var SelectedVehicleData = picker.SelectedItem as VechicleListByEmployeeId;               
                _objAddWorksheetRequestModel.VehicleId = SelectedVehicleData.Id;
                _objAddWorksheetRequestModel.VechicleName = SelectedVehicleData.VehicleTypeName;
                _objAddWorksheetRequestModel.Rego = SelectedVehicleData.Rego;
                if(!string.IsNullOrEmpty(SelectedVehicleData.PlantId))
                {
                    XFentPlantId.Text = SelectedVehicleData.PlantId;
                }
               
               
            }
            else
            {
                DependencyService.Get<IToast>().Show("please select LoadType!");
            }
        }

        private void dropdownShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                var data = picker.Items[picker.SelectedIndex];
                var SelectedShiftData = picker.SelectedItem as ShiftDataModel;
                _objAddWorksheetRequestModel.ShiftType = SelectedShiftData.ShiftId;
               
            }
            else
            {
                DependencyService.Get<IToast>().Show("please select LoadType!");
            }
        }
    }
}