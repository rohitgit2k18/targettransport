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
using TargetTransport_Api.Models.RequestModels.MechanicRequest;
using TargetTransport_Api.Models.ResponseModels.MechanicResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.MechanicSction
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mechanic_SignaturePage : ContentPage
	{
        #region Variable Declaration      
        private M_SignatureResponse _objM_SignatureResponse;
        private M_SignatureRequest _objM_SignatureRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private Int32 M_MR_DoneId;
        private RestApi _apiServices;
        #endregion
        public Mechanic_SignaturePage (Int32 MaintananceId)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            _apiServices = new RestApi();
            _baseUrl = Settings.Url + Domain.M_SignatureApiConstant;
            _objM_SignatureResponse = new M_SignatureResponse();
            _objHeaderModel = new HeaderModel();
            M_MR_DoneId = MaintananceId;
        }
        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            try
            {
                String imageBase64;
                Stream image = await padView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg);
                _objHeaderModel.TokenCode = Settings.TokenCode;
                if (image != null)
                {
                    imageBase64 = Base64Extensions.ConvertToBase64(image);
                    _objM_SignatureRequest = new M_SignatureRequest
                    {
                        MaintenenceRequestDoneId = M_MR_DoneId.ToString(),
                        CustomerName = custName.Text,
                        MechanicSign = imageBase64
                    };
                    await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objM_SignatureResponse = await _apiServices.M_SendSignatureAsync(new Get_API_Url().CommonBaseApi(_baseUrl), true, _objHeaderModel, _objM_SignatureRequest);
                    if (_objM_SignatureResponse.Response.StatusCode == 200)
                    {
                        DependencyService.Get<IToast>().Show(_objM_SignatureResponse.Response.Message);
                        await App.NavigationPage.Navigation.PushAsync(new Mechanic_RequestHistoryPage());
                        await Navigation.PopAllPopupAsync();
                    }
                    else
                    {
                        DependencyService.Get<IToast>().Show("Something Bad Happend please Try again Later!");
                        await Navigation.PopAllPopupAsync();
                    }
                }
                else
                {
                    DependencyService.Get<IToast>().Show("Please Sign over the signature pad to submit the Dailychecklist!");
                }
                //await App.NavigationPage.Navigation.PushAsync(new WorkSheetDetailsPage());
                //await Navigation.PopAllPopupAsync();

            }
            catch (Exception ex)
            {
                DependencyService.Get<IToast>().Show("Something Went Wrong please try Again or check your Internet Connection!!");
                await Navigation.PopAllPopupAsync();
                var msg = ex.Message;
            }
        }

    }
}