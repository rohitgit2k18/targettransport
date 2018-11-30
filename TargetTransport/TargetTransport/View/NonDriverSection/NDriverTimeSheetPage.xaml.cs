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
using TargetTransport_Api.Models.RequestModels.NonDriverRequest;
using TargetTransport_Api.Models.ResponseModels.NonDriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.NonDriverSection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NDriverTimeSheetPage : ContentPage
    {
        #region Variable Declaration
        private ND_TimeSheetResponse _objND_TimeSheetResponse;
        private ND_TimeSheetRequest _objND_TimeSheetRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private RestApi _apiServices;
        #endregion
        public NDriverTimeSheetPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _objND_TimeSheetResponse=new ND_TimeSheetResponse();
            _objHeaderModel = new HeaderModel();
            _apiServices = new RestApi();
            _baseUrl = Settings.Url + Domain.ND_TimeSheetApiConstant;
            _objND_TimeSheetRequest = new ND_TimeSheetRequest();
            LoadTimeSheetList();
        }
        private async void LoadTimeSheetList()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objND_TimeSheetRequest.EmployeeId = Settings.UserId;

                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IToast>().Show("You are Offline Please Check Your Internet Connection!");
                }
                else
                {
                    await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objND_TimeSheetResponse = await _apiServices.ND_TimeSheetDataAsync(new Get_API_Url().Driver_TimeSheetApi(_baseUrl), true, _objHeaderModel, _objND_TimeSheetRequest);
                    if (_objND_TimeSheetResponse.Response.StatusCode == 200)
                    {
                        if (_objND_TimeSheetResponse.Response.WorkTimeList.Count > 0)
                        {
                            foreach (var Items in _objND_TimeSheetResponse.Response.WorkTimeList)
                            {
                                Items.ProgramStartTimeBinding = Items.ProgramStartTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                Items.ApprovedStartTimeBinding = Items.ApprovedStartTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                Items.StartTimeBinding = Items.StartTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                Items.EndTimeBinding = Items.EndTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);
                                Items.WorkDateBinding = Items.WorkDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                                Items.EndDateBinding = Items.EndDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                                Items.TotalHrs.ToString();
                            }
                            TimeSheetList.ItemsSource = _objND_TimeSheetResponse.Response.WorkTimeList;
                           // DependencyService.Get<IToast>().Show(_objND_TimeSheetResponse.Response.Message);
                        }
                        else
                        {
                            DependencyService.Get<IToast>().Show("No Data To Display!");
                        }

                    }
                    else
                    {
                        DependencyService.Get<IToast>().Show("Error!");
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

        private void BtnLoadTimesheet_Clicked(object sender, EventArgs e)
        {
            _objND_TimeSheetRequest.WorkDate = StartDatePicker.Date;
            _objND_TimeSheetRequest.EndDate = EndDatePicker.Date;
            LoadTimeSheetList();

        }

        private async void imgHamburger_Click(object sender, EventArgs e)
        {
            var otherPage = new NonDriver_NavigationPage();
            otherPage.Detail = new NavigationPage(new NDriverTimeSheetPage());
            var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            await App.NavigationPage.PopToRootAsync(false);
            (App.NavigationPage.CurrentPage as MasterDetailPage).IsPresented = true;
            //otherPage.Detail = new NavigationPage(new Driver_WorksheetPage());
            // (App.NavigationPage.CurrentPage as MasterDetailPage).Detail = homePage;
        }
    }
}