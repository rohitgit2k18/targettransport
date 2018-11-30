using AsNum.XFControls.Services;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class CustomerSignaturePage : ContentPage
    {
        #region Variable Declaration       
        private Driver_AddLoadResponse _objDriver_AddLoadResponse;
        private Driver_AddLoadRequest _objDriver_AddLoadRequest;
        private Driver_EditLoadResponse _objDriver_EditLoadResponse;
        private Driver_UpdateLoadResponse _objDriver_UpdateLoadResponse;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private string _baseUrlPostLoad;
        private RestApi _apiServices;
        private int StatusId;
        private int DailyCheckListId;
        #endregion
        public CustomerSignaturePage(Driver_AddLoadRequest objDriver_AddLoadRequest,int status, Driver_EditLoadResponse objDriver_EditLoadResponse)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _objDriver_AddLoadResponse = new Driver_AddLoadResponse();
            _baseUrl = Settings.Url + Domain.AddNewLoadApiConstant;
            _apiServices = new RestApi();
            _baseUrlPostLoad = Settings.Url + Domain.UpdateLoadApiConstant;
            if (objDriver_AddLoadRequest!=null)
            _objDriver_AddLoadRequest = objDriver_AddLoadRequest;

            if (objDriver_EditLoadResponse != null)
                _objDriver_EditLoadResponse = objDriver_EditLoadResponse;

            StatusId = status;
            _objDriver_UpdateLoadResponse = new Driver_UpdateLoadResponse();
        }
        private async void btnSubmitSignature_Clicked(object sender, EventArgs e)
        {
            try
            {
                String imageBase64;
                Stream image = await padView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg, Color.Black, Color.White, 1f);
                _objHeaderModel = new HeaderModel
                {
                    TokenCode = Settings.TokenCode
                };
                if (image != null)
                {
                    imageBase64 = Base64Extensions.ConvertToBase64(image);
                    if (StatusId == 1)
                    {
                        _objDriver_AddLoadRequest.CustomerSign = imageBase64;
                        await Navigation.PushPopupAsync(new LoadingPopPage());
                        _objDriver_AddLoadResponse = await _apiServices.AddLoadAsync(new Get_API_Url().AddNewLoadApi(_baseUrl), true, _objHeaderModel, _objDriver_AddLoadRequest);
                        if (_objDriver_AddLoadResponse.Response.StatusCode == 200)
                        {
                            DependencyService.Get<IToast>().Show(_objDriver_AddLoadResponse.Response.Message);
                            await App.NavigationPage.Navigation.PushAsync(new WorkSheetDetailsPage());
                            await Navigation.PopAllPopupAsync();
                        }
                        else
                        {
                            DependencyService.Get<IToast>().Show(_objDriver_AddLoadResponse.Response.Message);
                            await Navigation.PopAllPopupAsync();
                        }
                    }
                    if (StatusId == 2)
                    {
                        _objDriver_EditLoadResponse.Response.LoadDetails.CustomerSign = imageBase64;
                        await Navigation.PushPopupAsync(new LoadingPopPage());
                        _objDriver_UpdateLoadResponse = await _apiServices.UpdateLoadAsync(new Get_API_Url().UpdateLoadApi(_baseUrlPostLoad), true, _objHeaderModel, _objDriver_EditLoadResponse.Response.LoadDetails);
                        if (_objDriver_UpdateLoadResponse.Response.StatusCode == 200)
                        {
                            DependencyService.Get<IToast>().Show(_objDriver_UpdateLoadResponse.Response.Message);
                            await Navigation.PushPopupAsync(new LoadSignOffPopUp(_objDriver_EditLoadResponse.Response.LoadDetails.LoadId));                         
                        }
                        else
                        {
                            DependencyService.Get<IToast>().Show(_objDriver_AddLoadResponse.Response.Message);
                            await Navigation.PopAllPopupAsync();
                        }
                    }
                }
                else
                    DependencyService.Get<IToast>().Show("Please Sign over the signature pad to submit the New Load!");

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                await Navigation.PopAllPopupAsync();
            }
        }
    }
}