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
using TargetTransport.View.DriverSction;
using TargetTransport.View.MechanicSction;
using TargetTransport.View.NonDriverSection;
using TargetTransport.View.SubContractorSction;
using TargetTransport_Api.ApiHandler;
using TargetTransport_Api.Models;
using TargetTransport_Api.Models.RequestModels;
using TargetTransport_Api.Models.ResponseModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        #region Variable Declaration
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        private bool IsValid { get; set; }
        private LoginRequest _objLoginRequest;
        private LoginResponse _objLoginResponse;
        private string _baseUrl;
        private RestApi _apiServices;
        #endregion
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _objLoginRequest = new LoginRequest();
            BindingContext = _objLoginRequest;
            _apiServices = new RestApi();
            _baseUrl = Settings.Url + Domain.LoginApiConstant;
            ResponseStatus.StatusCode = 0;
            if (Settings.RememberMe)
            {
                RememberMe.IsToggled = true;
            }
            if(!string.IsNullOrEmpty(Settings.UserName)||!string.IsNullOrEmpty(Settings.Password))
            {
                _objLoginRequest.userName = Settings.UserName;
                _objLoginRequest.password = Settings.Password;
            }
        }

        private async void BtnSignIn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IToast>().Show("No Internet Connection!");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(_objLoginRequest.userName) || string.IsNullOrWhiteSpace(_objLoginRequest.password))
                    {
                        DependencyService.Get<IToast>().Show("Please Enter Email And Passowrd!!..");
                    }
                    else
                    {
                        if (IsValid)
                        {
                            _objLoginRequest.password = _objLoginRequest.password;
                            await Navigation.PushPopupAsync(new LoadingPopPage());
                            _objLoginResponse = await _apiServices.LoginAsync(new Get_API_Url().LoginApi(_baseUrl), false, new HeaderModel(), _objLoginRequest);

                            if (ResponseStatus.StatusCode == 200)
                            {
                                Settings.IsLoggedIn = true;
                                Settings.Password = _objLoginRequest.password;
                                Settings.Name = _objLoginResponse.name;
                                Settings.UserName = _objLoginRequest.userName;
                                Settings.TokenCode = _objLoginResponse.access_token;
                                Settings.ProfilePicture = _objLoginResponse.imageUrl;
                                Settings.PhoneNo = _objLoginResponse.phoneNumber;
                                Settings.UserId = Convert.ToInt32(_objLoginResponse.userID);
                                //Settings.TokenExpiration = EipirationDate.Expires;
                                DependencyService.Get<IToast>().Show("Login Sucessfully..");
                                string USerType = _objLoginResponse.userType;

                                // ... Switch on the string.
                                switch (USerType)
                                {
                                    case "Driver":
                                        var otherPage = new Driver_NavigationPage();
                                        var homePage = App.NavigationPage.Navigation.NavigationStack.First();
                                        App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
                                        await App.NavigationPage.PopToRootAsync(false);
                                        await Navigation.PopAllPopupAsync();
                                        break;
                                    case "Non-Driver":
                                        var otherPage1 = new NonDriver_NavigationPage();
                                        var homePage1 = App.NavigationPage.Navigation.NavigationStack.First();
                                        App.NavigationPage.Navigation.InsertPageBefore(otherPage1, homePage1);
                                        await App.NavigationPage.PopToRootAsync(false);
                                        await Navigation.PopAllPopupAsync();
                                        break;
                                    case "Mechanic":
                                        var otherPage2 = new Mechanic_NavigationPage();
                                        var homePage2 = App.NavigationPage.Navigation.NavigationStack.First();
                                        App.NavigationPage.Navigation.InsertPageBefore(otherPage2, homePage2);
                                        await App.NavigationPage.PopToRootAsync(false);
                                        await Navigation.PopAllPopupAsync();
                                        break;
                                    case "Sub-Contractor":
                                        var otherPage3 = new SubContractor_NavigationPage();
                                        var homePage3 = App.NavigationPage.Navigation.NavigationStack.First();
                                        App.NavigationPage.Navigation.InsertPageBefore(otherPage3, homePage3);
                                        await App.NavigationPage.PopToRootAsync(false);
                                        await Navigation.PopAllPopupAsync();
                                        break;
                                }
                            }
                            else
                            {
                                DependencyService.Get<IToast>().Show("please enter valid email id and password!");
                                await Navigation.PopAllPopupAsync();
                            }
                        }
                        else
                        {
                            DependencyService.Get<IToast>().Show("Email is Not Valid!");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                DependencyService.Get<IToast>().Show("Something went wrong please check your internet connection or try again!");
                await Navigation.PopAllPopupAsync();
            }
            }

        private void StackForgotpassword_Click(object sender, EventArgs e)
        {
            try
            {
                App.NavigationPage.Navigation.PushAsync(new ForgotPasswordPage());
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void RememberMe_Toggled(object sender, ToggledEventArgs e)
        {
          if(e.Value)
            {
                Settings.RememberMe = true;
            }
            else
            {
                Settings.RememberMe = false;
            }
        }

        private void ImageEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
        }
    }
}