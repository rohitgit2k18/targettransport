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
	public partial class Driver_SignatureScreenPage : ContentPage
	{
        #region Variable Declaration       
        private Driver_SignatureResponse _objDriver_SignatureResponse;
        private Driver_SignatureRequest _objDriver_SignatureRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private RestApi _apiServices;
        private int DailyCheckListId;
        #endregion
        public Driver_SignatureScreenPage (int DailyCheckListID)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            _objDriver_SignatureResponse = new Driver_SignatureResponse();
            _baseUrl = Settings.Url + Domain.DriverSignatureApiConstant;
            _apiServices = new RestApi();
            DailyCheckListId = DailyCheckListID;
        }

        private async void btnSubmitSignature_Clicked(object sender, EventArgs e)
        {
            try
            {
                String imageBase64;
                Stream image = await padView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg, Color.Black, Color.White, 1f);
               // imageSign.Source=image
                    //imageSign.Source = ImageSource.FromStream(() =>
                    //{
                    //    // var stream = _mediaFile.GetStream();
                    //    // _mediaFile.Dispose();
                    //    return image;
                    //});
                _objHeaderModel = new HeaderModel
                {
                    TokenCode = Settings.TokenCode
                };               
                if (image != null)
                {
                    imageBase64 = Base64Extensions.ConvertToBase64(image);
                    _objDriver_SignatureRequest = new Driver_SignatureRequest
                    {
                        AddCheckListId = DailyCheckListId.ToString(),
                        DriverSign = imageBase64
                    };
                    await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objDriver_SignatureResponse = await _apiServices.DriverSignatureAsync(new Get_API_Url().Driver_SignatureApi(_baseUrl), true, _objHeaderModel, _objDriver_SignatureRequest);
                    if (_objDriver_SignatureResponse.Response.statusCode == 200)
                    {
                        Settings.IsPreStartChecked = true;
                         DependencyService.Get<IToast>().Show(_objDriver_SignatureResponse.Response.Message);
                        await App.NavigationPage.Navigation.PushAsync(new WorkSheetDetailsPage());                       
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
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void BackButton_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }
    }
}