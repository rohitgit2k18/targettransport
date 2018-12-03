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
	public partial class Driver_LoadDetailsPage : ContentPage
	{
        #region Variable Declaration
        private Driver_EditLoadResponse _objDriver_EditLoadResponse;
        private Driver_EditLoadRequest _objDriver_EditLoadRequest;
        private Driver_LoadTypeResponse _objDriver_LoadTypeResponse;
        private Driver_LoadTypesRequest _objDriver_LoadTypesRequest;
        private Driver_TollsListResponse _objDriver_TollsListResponse;
        private Driver_TollsListRequest _objDriver_TollsListRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrlGetData;
        private string _baseUrlPostData;
        private string _baseUrlLoadTypes;
        private string _baseUrlTollsList;
        private RestApi _apiServices;
        private int Loadid;
        #endregion

        public Driver_LoadDetailsPage (int LoadID)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            Loadid = LoadID;
            _objDriver_EditLoadResponse = new Driver_EditLoadResponse();
            _objDriver_LoadTypeResponse = new Driver_LoadTypeResponse();
            _objDriver_TollsListResponse = new Driver_TollsListResponse();
            _objHeaderModel = new HeaderModel();
           
            _apiServices = new RestApi();
            _baseUrlGetData = Settings.Url + Domain.EditLoadApiConstant;
            _baseUrlLoadTypes = Settings.Url + Domain.GetLoadTypesApiConstant;
            _baseUrlTollsList = Settings.Url + Domain.GetTollsListApiConstant;
            GetLoadTypes();
            LoadTolls();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
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
                  //  dropdownLoadType.ItemsSource = _objDriver_LoadTypeResponse.Response.LoadTypes;
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
        private async void LoadTolls()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objDriver_TollsListRequest = new Driver_TollsListRequest();
                _objDriver_TollsListRequest.ComapnyId = Settings.CompanyId;
                _objDriver_TollsListRequest.SearchKey = string.Empty;
                _objDriver_TollsListRequest.Limit = 50;
                _objDriver_TollsListRequest.OffSet = 0;
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objDriver_TollsListResponse = await _apiServices.GetTollListAsync(new Get_API_Url().GetTollsListApi(_baseUrlTollsList), true, _objHeaderModel, _objDriver_TollsListRequest);
                if (_objDriver_TollsListResponse.Response.StatusCode == 200)
                {
                    //await App.NavigationPage.Navigation.PushAsync(new Driver_SignatureScreenPage(DailyCheckListID));
                  //  dropdownTolls.ItemsSource = _objDriver_TollsListResponse.Response.AccountSettingTollList;
                    DependencyService.Get<IToast>().Show(_objDriver_TollsListResponse.Response.Message);
                    await Navigation.PopAllPopupAsync();
                    GetLoad();
                }
                else
                {
                    DependencyService.Get<IToast>().Show(_objDriver_TollsListResponse.Response.Description);
                    await Navigation.PopAllPopupAsync();
                    GetLoad();
                }
            }
            catch (Exception ex)
            {
                await Navigation.PopAllPopupAsync();
                var msg = ex.Message;
            }
        }
        private async void GetLoad()
        {
            try
            {
                _objDriver_EditLoadRequest = new Driver_EditLoadRequest
                {
                    LoadId = Loadid,
                    WorksheetId = Settings.WorksheetID.ToString()
                };
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objDriver_EditLoadResponse = await _apiServices.EditLoadAsync(new Get_API_Url().EditLoadApi(_baseUrlGetData), true, _objHeaderModel, _objDriver_EditLoadRequest);
                if (_objDriver_EditLoadResponse.Response.StatusCode == 200)
                {
                    //  Convert.ToInt32(_objDriver_EditLoadResponse.Response.LoadDetails.JobType);
                    //bool containsLoadType = _objDriver_LoadTypeResponse.Response.LoadTypes.Any(item => item.Id == _objDriver_EditLoadResponse.Response.LoadDetails.JobType);
                    //bool containsToll= _objDriver_TollsListResponse.Response.AccountSettingTollList.Any(item => item.UniqueId == _objDriver_EditLoadResponse.Response.LoadDetails.TollId);

                    var existingLoadType = (from result in _objDriver_LoadTypeResponse.Response.LoadTypes
                                            where result.Id == _objDriver_EditLoadResponse.Response.LoadDetails.JobType
                                            select result).FirstOrDefault();

                    var existingToll = (from result in _objDriver_TollsListResponse.Response.AccountSettingTollList
                                        where result.AccountId == _objDriver_EditLoadResponse.Response.LoadDetails.TollId
                                        select result).FirstOrDefault();
                    if (existingLoadType != null)
                    {
                          int i = _objDriver_LoadTypeResponse.Response.LoadTypes.IndexOf(existingLoadType);
                        _objDriver_EditLoadResponse.Response.LoadDetails.JobTypeName = _objDriver_LoadTypeResponse.Response.LoadTypes[i].Type;
                       // dropdownLoadType.SelectedIndex = i;
                    }
                    if (existingToll != null)
                    {
                        int j = _objDriver_TollsListResponse.Response.AccountSettingTollList.IndexOf(existingToll);
                        _objDriver_EditLoadResponse.Response.LoadDetails.TollName = _objDriver_TollsListResponse.Response.AccountSettingTollList[j].TollPoint;
                        // dropdownTolls.SelectedIndex = j;
                    }
                    BindingContext = _objDriver_EditLoadResponse.Response.LoadDetails;
                    DependencyService.Get<IToast>().Show(_objDriver_EditLoadResponse.Response.Message);
                    await Navigation.PopAllPopupAsync();
                }
                else
                {
                    DependencyService.Get<IToast>().Show(_objDriver_EditLoadResponse.Response.Description);
                    await Navigation.PopAllPopupAsync();
                }
            }
            catch (Exception ex) 
            {
                var msg = ex.Message;
            }
        }
        private void btnLoadViewDetailsSubmit_Clicked(object sender, EventArgs e)
        {
            //  Navigation.PushPopupAsync(new  LoadSignOffPopUp());
            App.NavigationPage.Navigation.PushAsync(new WorkSheetDetailsPage());

            // Navigation.PopAllPopupAsync();
        }

        private void OnBackButtonTapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }
    }
}