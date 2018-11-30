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
using TargetTransport_Api.ApiHandler;
using TargetTransport_Api.Models;
using TargetTransport_Api.Models.RequestModels;
using TargetTransport_Api.Models.ResponseModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgotPasswordPage : ContentPage
	{
        #region Variable Declaration
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        private bool IsValid { get; set; }
        private ForgotPasswordResponse _objForgotPasswordResponse;
        private ForgotPasswordRequest _objForgotPasswordRequest;
        private string _baseUrl;
        private RestApi _apiServices;
        #endregion
       
        public ForgotPasswordPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            _objForgotPasswordRequest = new ForgotPasswordRequest();
            BindingContext = _objForgotPasswordRequest;
            _objForgotPasswordResponse = new ForgotPasswordResponse();
            _apiServices = new RestApi();
            _baseUrl = Settings.Url + Domain.ForgotPasswordApiConstant;

        }

        private async void BtnForgotPassSub_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IToast>().Show("No Internet Connection!");
                }
                else
                {
                    if (string.IsNullOrEmpty(_objForgotPasswordRequest.EmailId))
                    {
                        DependencyService.Get<IToast>().Show("Please Enter Email !");
                    }
                    else
                    {
                        if (!IsValid)
                        {
                            DependencyService.Get<IToast>().Show("Email is not valid!");
                        }
                        else
                        {
                            await Navigation.PushPopupAsync(new LoadingPopPage());
                            _objForgotPasswordResponse = await _apiServices.ForgotPasswordAsync(new Get_API_Url().ForgotPasswordApi(_baseUrl), false, new HeaderModel(), _objForgotPasswordRequest);

                            if (_objForgotPasswordResponse.Response.StatusCode == 200)
                            {
                                await App.NavigationPage.Navigation.PushAsync(new LoginPage());
                                DependencyService.Get<IToast>().Show(_objForgotPasswordResponse.Response.Message + " " + _objForgotPasswordResponse.Response.Description);
                                await Navigation.PopAllPopupAsync();
                            }
                            else
                            {
                                DependencyService.Get<IToast>().Show(_objForgotPasswordResponse.Response.Message + " " + _objForgotPasswordResponse.Response.Description);
                                await Navigation.PopAllPopupAsync();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                DependencyService.Get<IToast>().Show(_objForgotPasswordResponse.Response.Message + " " + _objForgotPasswordResponse.Response.Description);
                await Navigation.PopAllPopupAsync();
            }
        }

        private void ImageEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
        }
    }

}