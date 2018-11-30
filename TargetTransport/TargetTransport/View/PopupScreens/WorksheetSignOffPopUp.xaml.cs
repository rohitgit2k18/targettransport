using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsNum.XFControls.Services;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TargetTransport_Api.Models.ResponseModels.DriverResponse;
using TargetTransport_Api.Models.RequestModels.DriverRequest;
using TargetTransport_Api.Models;
using TargetTransport_Api.ApiHandler;
using TargetTransport.Helpers;
using TargetTransport.Models;
using System.IO;
using TargetTransport.View.DriverSction;

namespace TargetTransport
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorksheetSignOffPopUp : PopupPage
    {
        #region Variable Declaration      
        private Driver_WorkSheetSignOffResponse _objDriver_WorkSheetSignOffResponse;
        private Driver_WorkSheetSignOffRequest _objDriver_WorkSheetSignOffRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private RestApi _apiServices;
        #endregion
        public WorksheetSignOffPopUp()
        {
            InitializeComponent();
          //  LoadID = Loadid;
            _apiServices = new RestApi();
            _baseUrl = Settings.Url + Domain.WorkSheetSignOffSigApiConstant;
            _objDriver_WorkSheetSignOffResponse = new Driver_WorkSheetSignOffResponse();
            _objHeaderModel = new HeaderModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            FrameContainer.HeightRequest = -1;

           
        }
        private void OnCloseButtonTapped(object sender, EventArgs e)
        {
            CloseAllPopup();
        }

        protected override bool OnBackgroundClicked()
        {
            CloseAllPopup();

            return false;
        }

        private async void CloseAllPopup()
        {
            await Navigation.PopAllPopupAsync();
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            try
            {
                String imageBase64;
                Stream image = await padView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg, Color.Black, Color.White, 1f);
                _objHeaderModel.TokenCode = Settings.TokenCode;
                if (image != null)
                {
                    imageBase64 = Base64Extensions.ConvertToBase64(image);
                    _objDriver_WorkSheetSignOffRequest = new Driver_WorkSheetSignOffRequest
                    {
                        Id = Settings.WorksheetID.ToString(),
                        CustomerName = custName.Text,
                        CustomerSign = imageBase64
                    };
                    await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objDriver_WorkSheetSignOffResponse = await _apiServices.WorkSheetSignOffSignAsync(new Get_API_Url().WorkSheetSignOffSignApi(_baseUrl), true, _objHeaderModel, _objDriver_WorkSheetSignOffRequest);
                    if (_objDriver_WorkSheetSignOffResponse.Response.StatusCode == 200)
                    {
                        DependencyService.Get<IToast>().Show(_objDriver_WorkSheetSignOffResponse.Response.Message);
                        await App.NavigationPage.Navigation.PushAsync(new Driver_WorksheetPage());
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

        private  void btnCancel_Clicked(object sender, EventArgs e)
        {
            CloseAllPopup();

            // await Navigation.PopAllPopupAsync();

        }
    }
}