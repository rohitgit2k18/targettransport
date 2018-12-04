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
    public partial class WorkSheetDetailsPage : ContentPage
    {
        #region Variable Declaration
       
        private Driver_WorkSheetDetailsGetResponse _objDriver_WorkSheetDetailsGetResponse;
        private Driver_WorkSheetDetailsGetRequest _objDriver_WorkSheetDetailsGetRequest;
        private DeleteLoadRequest _objDeleteLoadRequest;
        private DeleteLoadResponse _objDeleteLoadResponse;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;       
        private string _baseUrlDeleteLoad;
        private RestApi _apiServices;  
        #endregion
        public WorkSheetDetailsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _objHeaderModel = new HeaderModel();
            _baseUrl = Settings.Url + Domain.WorkSheetDetailsGetApiConstant;
            _baseUrlDeleteLoad = Settings.Url + Domain.DeleteLoadApiConstant;
            _apiServices = new RestApi();
            _objDriver_WorkSheetDetailsGetResponse = new Driver_WorkSheetDetailsGetResponse();
            _objDeleteLoadResponse = new DeleteLoadResponse();
            LoadWorkSheetDetails();
        }
        private async void LoadWorkSheetDetails()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objDriver_WorkSheetDetailsGetRequest = new Driver_WorkSheetDetailsGetRequest
                {
                    Id = Settings.WorksheetID,
                    EmployeeId = Settings.UserId,
                    CompanyId = Settings.CompanyId
                };
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objDriver_WorkSheetDetailsGetResponse = await _apiServices.GetDriverWorkSheetDetailsAsync(new Get_API_Url().WorksheetDetailsGetApi(_baseUrl), true, _objHeaderModel, _objDriver_WorkSheetDetailsGetRequest);
                if (_objDriver_WorkSheetDetailsGetResponse.Response.StatusCode == 200)
                {
                    //await App.NavigationPage.Navigation.PushAsync(new Driver_SignatureScreenPage(DailyCheckListID));
                    BindingContext = _objDriver_WorkSheetDetailsGetResponse.Response.WorksheetDetails;
                    
                    LoadList.ItemsSource = _objDriver_WorkSheetDetailsGetResponse.Response.AllLoadList;
                    DependencyService.Get<IToast>().Show("Sucess!");
                    await Navigation.PopAllPopupAsync();
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

        private void btnLoadView_Clicked(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new Driver_AddLoadPage(_objDriver_WorkSheetDetailsGetResponse));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new TimingViewPage(_objDriver_WorkSheetDetailsGetResponse));
        }

        private void BackButton_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }

        private void OnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = ((TappedEventArgs)e).Parameter as AllLoadList;
              
                App.NavigationPage.Navigation.PushAsync(new Driver_EditLoadPage(obj.LoadId));

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async void OnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await DisplayAlert("Alert!", "Do you want to Delete?", "Ok", "Cancel"); // since we are using async, we should specify the DisplayAlert as awaiting.
                if (result == true) // if it's equal to Ok
                {
                    var obj = ((TappedEventArgs)e).Parameter as AllLoadList;

                    _objDeleteLoadRequest = new DeleteLoadRequest
                    {
                        EmployeeId = Settings.UserId.ToString(),
                        LoadId = obj.LoadId
                    };
                    _objDeleteLoadResponse = await _apiServices.DeleteLoadAsync(new Get_API_Url().CommonBaseApi(_baseUrlDeleteLoad), true, _objHeaderModel, _objDeleteLoadRequest);
                    if (_objDeleteLoadResponse.Response.StatusCode == 200)
                    {
                        await App.NavigationPage.Navigation.PushAsync(new WorkSheetDetailsPage());                      
                        DependencyService.Get<IToast>().Show(_objDeleteLoadResponse.Response.Message);
                        
                    }
                    else
                    {
                        DependencyService.Get<IToast>().Show(_objDeleteLoadResponse.Response.Message);
                      
                    }
                }
                else // if it's equal to Cancel
                {
                    return; // just return to the page and do nothing.
                }
            
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}