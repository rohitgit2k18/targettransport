using AsNum.XFControls.Services;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Helpers;
using TargetTransport.Models;
using TargetTransport_Api.ApiHandler;
using TargetTransport_Api.Models;
using TargetTransport_Api.Models.RequestModels.SubContractorRequest;
using TargetTransport_Api.Models.ResponseModels.SubContractorResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.SubContractorSction
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubContractor_HomePage : ContentPage
	{
        #region Variable Declaration
        private SC_HomePageResponse _objSC_HomePageResponse;
        private SC_HomePageRequest _objSC_HomePageRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private RestApi _apiServices;
        #endregion
        public SubContractor_HomePage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            _objSC_HomePageResponse = new SC_HomePageResponse();
            _objHeaderModel = new HeaderModel();
            _baseUrl = Settings.Url + Domain.SC_HomeApiConstant;
            _apiServices = new RestApi();

        }
        private async void imgHamburger_Click(object sender, EventArgs e)
        {
            var otherPage = new SubContractor_NavigationPage();
            otherPage.Detail = new NavigationPage(new SubContractor_HomePage());
            var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            await App.NavigationPage.PopToRootAsync(false);
            (App.NavigationPage.CurrentPage as MasterDetailPage).IsPresented = true;
            // otherPage.Detail = new NavigationPage(new  Driver_HomePage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetMechanicData();
        }
       
        private async void GetMechanicData()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objSC_HomePageRequest = new SC_HomePageRequest
                {
                    id = Settings.UserId.ToString()
                };
                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IToast>().Show("No Internet Connection!");
                }
                else
                {
                    await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objSC_HomePageResponse = await _apiServices.LoadDSCWorkSheetListAsync(new Get_API_Url().CommonBaseApi(_baseUrl), true, _objHeaderModel, _objSC_HomePageRequest);
                    if (_objSC_HomePageResponse.Response.StatusCode == 200)
                    {
                        // Settings.CompanyId = _objM_HomeDataResponse.Response.EmployeeObject.CompanyId;
                        if (_objSC_HomePageResponse.Response.SubContractorHome.Count > 0)
                        {
                            foreach (var Items in _objSC_HomePageResponse.Response.SubContractorHome)
                            {
                               // Items.FixedOnBinding = Items.FixedOn.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                               // Items.RequestDateBinding = Items.RequestDate.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                //Items.StartTimeBinding = Items.StartTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                //Items.EndTimeBinding = Items.EndTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                //Items.WorkDateBinding = Items.WorkDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                                //Items.EndDateBinding = Items.EndDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                                //Items.TotalHrs.ToString();
                            }
                            WorksheetList.ItemsSource = _objSC_HomePageResponse.Response.SubContractorHome;
                            DependencyService.Get<IToast>().Show("Sucess");
                        }
                        else
                        {
                            DependencyService.Get<IToast>().Show("No Data To Display!");
                        }
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
    }
}