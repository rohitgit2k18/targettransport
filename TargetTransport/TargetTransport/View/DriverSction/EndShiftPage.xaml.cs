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
using TargetTransport.ViewModels;
using TargetTransport_Api.ApiHandler;
using TargetTransport_Api.Models;
using TargetTransport_Api.Models.RequestModels.DriverRequest;
using TargetTransport_Api.Models.ResponseModels.DriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.DriverSction
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EndShiftPage : ContentPage
	{
        #region Variable Declaration
        private Driver_EndOfShiftResponse _objDriver_EndOfShiftResponse;
        private Driver_EndOfShiftRequest _objDriver_EndOfShiftRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private DailyEntryViewModel _objDailyEntryViewModel;
        private RestApi _apiServices;
        #endregion
       
        public EndShiftPage ()
		{
			InitializeComponent ();
            

            NavigationPage.SetHasNavigationBar(this, false);
            _objDailyEntryViewModel = new DailyEntryViewModel();
            _objDriver_EndOfShiftRequest = new Driver_EndOfShiftRequest();
           // BindingContext = _objDriver_EndOfShiftRequest;
            RadioButtonBinding();
            _apiServices = new RestApi();
            _objDriver_EndOfShiftResponse = new Driver_EndOfShiftResponse();
            _objHeaderModel = new HeaderModel();
            _baseUrl = Settings.Url + Domain.Driver_EndOfShiftApiConstant;
           
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }
        public void RadioButtonBinding()
        {
            RadioTyreCheck.ItemsSource = _objDailyEntryViewModel.GetRadioType();           
        }
        private async void imgHamburger_Click(object sender, EventArgs e)
        {
            var otherPage = new Driver_NavigationPage();
            otherPage.Detail = new NavigationPage(new EndShiftPage());
            var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            await App.NavigationPage.PopToRootAsync(false);
            (App.NavigationPage.CurrentPage as MasterDetailPage).IsPresented = true;
            //otherPage.Detail = new NavigationPage(new Driver_WorksheetPage());
            // (App.NavigationPage.CurrentPage as MasterDetailPage).Detail = homePage;
        }
        private async void AddEndOfShift()
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IToast>().Show("You are Offline Please Check Your Internet Connection!");
                }
                else
                {                                      
                    if (string.IsNullOrEmpty(_objDriver_EndOfShiftRequest.StaffDate) ||
                        string.IsNullOrEmpty(_objDriver_EndOfShiftRequest.StaffTime) ||
                        string.IsNullOrEmpty(_objDriver_EndOfShiftRequest.Odometer)  ||
                        string.IsNullOrEmpty(_objDriver_EndOfShiftRequest.EngineHrs) ||
                        string.IsNullOrEmpty(_objDriver_EndOfShiftRequest.PlantRegoId))
                    {
                        DependencyService.Get<IToast>().Show("Please fill all the field first!");
                    }
                    else
                    {
                        _objHeaderModel.TokenCode = Settings.TokenCode;
                        await Navigation.PushPopupAsync(new LoadingPopPage());
                        _objDriver_EndOfShiftResponse = await _apiServices.Driver_EndOfShiftAsync(new Get_API_Url().Driver_AddMaintananceApi(_baseUrl), true, _objHeaderModel, _objDriver_EndOfShiftRequest);
                        if (_objDriver_EndOfShiftResponse.Response.StatusCode == 200)
                        {
                            DependencyService.Get<IToast>().Show(_objDriver_EndOfShiftResponse.Response.Message);
                            await Navigation.PopAllPopupAsync();
                        }
                        else
                        {
                            DependencyService.Get<IToast>().Show(_objDriver_EndOfShiftResponse.Response.Message);
                            await Navigation.PopAllPopupAsync();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                await Navigation.PopAllPopupAsync();
            }
        }

        private void Entryselect_date_Focused(object sender, FocusEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Entryselect_date.IsEnabled = false;
                LoaddatePicker.Focus();

            });
        }

        private void LoaddatePicker_Unfocused(object sender, FocusEventArgs e)
        {
            Entryselect_date.IsEnabled = true;
            Entryselect_date.Unfocus();
            Entryselect_date.Text = LoaddatePicker.Date.ToString();
        }

        private void ClaimminutesTPicker_Unfocused(object sender, FocusEventArgs e)
        {
            Entryclaim_minutes.IsEnabled = true;
            Entryclaim_minutes.Unfocus();
            Entryclaim_minutes.Text = ClaimminutesTPicker.Time.ToString();
        }

        private void Entryclaim_minutes_Focused(object sender, FocusEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Entryclaim_minutes.IsEnabled = false;
                ClaimminutesTPicker.Focus();

            });
        }

        private void btnSubmitShiftRec_Clicked(object sender, EventArgs e)
        {
            var startDate = Entryselect_date.Text;
            var starTime = Entryclaim_minutes.Text;
            var fuelAdded = Entryfuel_added.Text;
            var odometer = EntryOdometer.Text;
            var engineHrs = EntryEnginehrs.Text;
            var adBlue = EntryAdBlue.Text;
            var regoplantId = Entryplant.Text;
            var radioSelectedItem = RadioTyreCheck.SelectedItem as DailyEntryRadio;
            var tyreChecked = radioSelectedItem.Name;
            var comments = EntryComments.Text;
            _objDriver_EndOfShiftRequest.StaffDate = startDate;
            _objDriver_EndOfShiftRequest.StaffTime = starTime;
            _objDriver_EndOfShiftRequest.FuelAdded = fuelAdded;
            _objDriver_EndOfShiftRequest.Odometer = odometer;
            _objDriver_EndOfShiftRequest.EngineHrs = engineHrs;
            _objDriver_EndOfShiftRequest.AdBlue= adBlue;
            _objDriver_EndOfShiftRequest.PlantRegoId = regoplantId;
            _objDriver_EndOfShiftRequest.TyreChecked = tyreChecked;
            _objDriver_EndOfShiftRequest.Comments = comments;
            _objDriver_EndOfShiftRequest.EmployeeId = Settings.UserId.ToString();
            _objDriver_EndOfShiftRequest.CreatedBy = Settings.UserId.ToString();
            _objDriver_EndOfShiftRequest.CompanyId = Settings.CompanyId.ToString();
            //this.BindingContext = _objDriver_EndOfShiftRequest;
            AddEndOfShift();
        }
    }
}