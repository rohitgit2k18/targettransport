using AsNum.XFControls.Services;
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
	public partial class Driver_ProfilePage : ContentPage
	{
        #region Variable Declaration       
        private ChnagePasswordRequest _objChnagePasswordRequest;
        private ChangePaswwordResponse _objChangePaswwordResponse;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;       
        private RestApi _apiServices;
        #endregion
        public Driver_ProfilePage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            _apiServices = new RestApi();
            _objHeaderModel = new HeaderModel();
            _baseUrl = Settings.Url + Domain.ChangePasswordApiConstant;
            _objChangePaswwordResponse = new ChangePaswwordResponse();
            _objChnagePasswordRequest = new ChnagePasswordRequest();
            BindingContext = _objChnagePasswordRequest;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            imgProfile.Source = Settings.ProfilePicture;
            TxtUserName.Text = Settings.Name;
            UserEmail.Text = Settings.UserName;
            UserMobileNo.Text = Settings.PhoneNo;
        }
        private async void imgHamburger_Click(object sender, EventArgs e)
        {
            var otherPage = new Driver_NavigationPage();
            otherPage.Detail = new NavigationPage(new Driver_ProfilePage());
            var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            await App.NavigationPage.PopToRootAsync(false);
            (App.NavigationPage.CurrentPage as MasterDetailPage).IsPresented = true;
            // otherPage.Detail = new NavigationPage(new  Driver_HomePage());
        }

        private async void BtnSubmitNewPassword_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await DisplayAlert("Alert!", "Do you want to change your password?", "Ok", "Cancel"); // since we are using async, we should specify the DisplayAlert as awaiting.
                if (result == true) // if it's equal to Ok
                {
                    _objChnagePasswordRequest.UserId = Settings.UserId;
                    _objHeaderModel.TokenCode = Settings.TokenCode;
                    if (_objChnagePasswordRequest.NewPassword != _objChnagePasswordRequest.ConfirmNewPassword)
                    {
                        DependencyService.Get<IToast>().Show("Confirm Password Did not Match!");
                    }
                    else
                    {
                        _objChangePaswwordResponse = await _apiServices.ChangeOfPasswordAsync(new Get_API_Url().CommonBaseApi(_baseUrl), true, _objHeaderModel, _objChnagePasswordRequest);
                        if (_objChangePaswwordResponse.Response.StatusCode == 200)
                        {
                            Settings.Password = _objChnagePasswordRequest.NewPassword;
                            DependencyService.Get<IToast>().Show(_objChangePaswwordResponse.Response.Message);
                        }
                        else
                        {
                            DependencyService.Get<IToast>().Show(_objChangePaswwordResponse.Response.Message);
                        }
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