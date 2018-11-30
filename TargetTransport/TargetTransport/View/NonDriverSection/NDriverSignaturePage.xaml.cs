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
using TargetTransport_Api.Models.RequestModels.NonDriverRequest;
using TargetTransport_Api.Models.ResponseModels.NonDriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.NonDriverSection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NDriverSignaturePage : ContentPage
    {
        #region Variable Declaration       
        private ND_SignatureResponse _objND_SignatureResponse;
        private ND_SignatureRequest _objND_SignatureRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private RestApi _apiServices;
        private Int32 DailyCheckListId;
        #endregion
        public NDriverSignaturePage(Int32 DailyCheckListID)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _objND_SignatureResponse = new ND_SignatureResponse();
            _baseUrl = Settings.Url + Domain.ND_SignatureApiConstant;
            _apiServices = new RestApi();
            DailyCheckListId = DailyCheckListID;
        }
        private async void btnSubmitSignature_Clicked(object sender, EventArgs e)
        {
            try
            {
                String imageBase64;
                Stream image = await padView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg);
                _objHeaderModel = new HeaderModel
                {
                    TokenCode = Settings.TokenCode
                };
                if (image != null)
                {
                    imageBase64 = Base64Extensions.ConvertToBase64(image);
                    _objND_SignatureRequest = new ND_SignatureRequest
                    {
                        AddCheckListId = DailyCheckListId.ToString(),
                        DriverSign = imageBase64
                    };
                    await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objND_SignatureResponse = await _apiServices.ND_SignatureDataAsync(new Get_API_Url().CommonBaseApi(_baseUrl), true, _objHeaderModel, _objND_SignatureRequest);
                    if (_objND_SignatureResponse.Response.statusCode == 200)
                    {
                        DependencyService.Get<IToast>().Show(_objND_SignatureResponse.Response.Message);
                      await App.NavigationPage.Navigation.PushAsync(new NDriverTimeSheetPage());
                        await Navigation.PopAllPopupAsync();
                    }
                    else
                    {
                        DependencyService.Get<IToast>().Show("Something Bad Happend please Try again Later!");
                        await Navigation.PopAllPopupAsync();
                    }
                }
                else
                    DependencyService.Get<IToast>().Show("Please Sign over the signature pad to submit the Dailychecklist!");

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

    }
}