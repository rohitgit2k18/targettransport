using AsNum.XFControls.Services;
using Plugin.Connectivity;
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
using TargetTransport_Api.Models.RequestModels.MechanicRequest;
using TargetTransport_Api.Models.ResponseModels.MechanicResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.MechanicSction
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mechanic_ViewDetailsPage : ContentPage
    {
        #region Variable Declaration
        private M_GetViewDetailsResponse _objM_GetViewDetailsResponse;
        private M_GetViewDetailsRequest _objM_GetViewDetailsRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private RestApi _apiServices;
        #endregion
        public Mechanic_ViewDetailsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _objM_GetViewDetailsResponse = new M_GetViewDetailsResponse();
            _apiServices = new RestApi();
            _objHeaderModel = new HeaderModel();
            _baseUrl = Settings.Url + Domain.M_ViewDetailsApiConstant;
            GetpageDetailsDataAsync();
        }

        private async void GetpageDetailsDataAsync()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objM_GetViewDetailsRequest = new M_GetViewDetailsRequest
                {
                    id = Settings.RequestId.ToString()
                };
                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IToast>().Show("No Internet Connection!");
                }
                else
                {
                    
                    await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objM_GetViewDetailsResponse = await _apiServices.M_ViewDetailsDataAsync(new Get_API_Url().CommonBaseApi(_baseUrl), true, _objHeaderModel, _objM_GetViewDetailsRequest);
                    if (_objM_GetViewDetailsResponse.Response.StatusCode == 200)
                    {
                        this.BindingContext = _objM_GetViewDetailsResponse.Response.Data;


                            DependencyService.Get<IToast>().Show(_objM_GetViewDetailsResponse.Response.Message);
                       
                    }
                    else
                    {
                        DependencyService.Get<IToast>().Show("Error Occured");
                    }
                    await Navigation.PopAllPopupAsync();
                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                await Navigation.PopAllPopupAsync();
            }
        }
        private void BtnLater_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IToast>().Show("This Service is not Available Yet!");
        }

        private void BtnStartWork_Clicked(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new Mechanic_RequestDonePage(_objM_GetViewDetailsResponse.Response.Data.Id));
        }

        private void Back_Click(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }
    }
}