using AsNum.XFControls.Services;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Helpers;
using TargetTransport.Models;
using TargetTransport.View.DriverSction;
using TargetTransport_Api.ApiHandler;
using TargetTransport_Api.Models;
using TargetTransport_Api.Models.RequestModels.DriverRequest;
using TargetTransport_Api.Models.ResponseModels.DriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadSignOffPopUp : PopupPage
    {
        #region Variable Declaration
        private int LoadID;
        private Driver_LoadSignOffResponse _objDriver_LoadSignOffResponse;
        private Driver_LoadSignOffResquest _objDriver_LoadSignOffResquest;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private RestApi _apiServices;
        #endregion

        public LoadSignOffPopUp(int Loadid)
        {
            InitializeComponent();
            LoadID = Loadid;
            _apiServices = new RestApi();
            _baseUrl = Settings.Url + Domain.LoadOffC_SignatureApiConstant;
            _objDriver_LoadSignOffResponse = new Driver_LoadSignOffResponse();
            _objHeaderModel = new HeaderModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            FrameContainer.HeightRequest = -1;

            //CloseImage.Rotation = 30;
            //   CloseImage.Scale = 0.3;
            //   CloseImage.Opacity = 0;

            //LoginButton.Scale = 0.3;
            //LoginButton.Opacity = 0;
            //LoginButton1.Scale = 0.3;
            //LoginButton1.Opacity = 0;
            //UsernameEntry.TranslationX = PasswordEntry.TranslationX = -10;
            //UsernameEntry.Opacity = PasswordEntry.Opacity = 0;
        }
        //protected async override Task OnAppearingAnimationEnd()
        //{
        //    var translateLength = 400u;

        //    //await Task.WhenAll(
        //    //    UsernameEntry.TranslateTo(0, 0, easing: Easing.SpringOut, length: translateLength),
        //    //    UsernameEntry.FadeTo(1),
        //    //    (new Func<Task>(async () =>
        //    //    {
        //    //        await Task.Delay(200);
        //    //        await Task.WhenAll(
        //    //            PasswordEntry.TranslateTo(0, 0, easing: Easing.SpringOut, length: translateLength),
        //    //            PasswordEntry.FadeTo(1));

        //    //    }))());

        //    //await Task.WhenAll(
        //    //    CloseImage.FadeTo(1),
        //    //    CloseImage.ScaleTo(1, easing: Easing.SpringOut),
        //    //    CloseImage.RotateTo(0),
        //    //    LoginButton.ScaleTo(1),
        //    //    LoginButton.FadeTo(1));
        //}

        //protected async override Task OnDisappearingAnimationBegin()
        //{
        //    //var taskSource = new TaskCompletionSource<bool>();

        //    //var currentHeight = FrameContainer.Height;

        //    ////await Task.WhenAll(
        //    ////    UsernameEntry.FadeTo(0),
        //    ////    PasswordEntry.FadeTo(0),
        //    ////    LoginButton.FadeTo(0));

        //    //FrameContainer.Animate("HideAnimation", d =>
        //    //{
        //    //    FrameContainer.HeightRequest = d;
        //    //},
        //    //start: currentHeight,
        //    //end: 170,
        //    //finished: async (d, b) =>
        //    //{
        //    //    await Task.Delay(300);
        //    //    taskSource.TrySetResult(true);
        //    //});

        //    //await taskSource.Task;
        //}

        //private async void OnLogin(object sender, EventArgs e)
        //{
        //    var loadingPage = new LoadingPopupPage();
        //    await Navigation.PushPopupAsync(loadingPage);
        //    await Task.Delay(2000);
        //    await Navigation.RemovePopupPageAsync(loadingPage);
        //    await Navigation.PushPopupAsync(new LoginSuccessPopupPage());
        //}

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
                Stream image = await padView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg);               
                _objHeaderModel.TokenCode = Settings.TokenCode;
                if(image != null)
                {
                    imageBase64 = Base64Extensions.ConvertToBase64(image);
                    _objDriver_LoadSignOffResquest = new Driver_LoadSignOffResquest
                    {
                        LoadId = LoadID.ToString(),
                        CustomerName = custName.Text,
                        CustomerSign = imageBase64
                    };
                    await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objDriver_LoadSignOffResponse = await _apiServices.LoadSignOffSignAsync(new Get_API_Url().LoadOffC_SignatureApi(_baseUrl), true, _objHeaderModel, _objDriver_LoadSignOffResquest);
                    if (_objDriver_LoadSignOffResponse.Response.StatusCode == 200)
                    {                                 
                        DependencyService.Get<IToast>().Show(_objDriver_LoadSignOffResponse.Response.Message);
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

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            CloseAllPopup();
           
           // await Navigation.PopAllPopupAsync();
           
        }
    }
}