using AsNum.XFControls.Services;
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
using TargetTransport_Api.Models.RequestModels.DriverRequest;
using TargetTransport_Api.Models.ResponseModels.DriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.DriverSction
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Driver_WorksheetPage : ContentPage
	{
        #region variable Declaration
        private DriverWorkSheetListResponse _objDriverWorkSheetListResponse;
        private DriverWorkSheetListRequest _objDriverWorkSheetListRequest;
        private DriverActualStartAndEndTimeRequest _objDriverActualStartAndEndTimeRequest;
        private DriverActualStartAndEndTimeResponse _objDriverActualStartAndEndTimeResponse;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private string _baseUrlDriverActualStartAndEndTime;
        private string Orderby;
        private RestApi _apiServices;
        #endregion

        public Driver_WorksheetPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            _apiServices = new RestApi();
            _baseUrl = Settings.Url + Domain.DriverWorkSheetListApiConstant;
            _baseUrlDriverActualStartAndEndTime = Settings.Url + Domain.DriverActualStartAndEndTimeApiConstant;
            _objHeaderModel = new HeaderModel();
            _objDriverWorkSheetListResponse = new DriverWorkSheetListResponse();
            
            _objDriverActualStartAndEndTimeResponse = new DriverActualStartAndEndTimeResponse();
            Orderby = "DESC";
           // LoadPageData();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadPageData();
        }
        private async void imgHamburger_Click(object sender, EventArgs e)
        {
            var otherPage = new Driver_NavigationPage();
            otherPage.Detail= new NavigationPage(new Driver_WorksheetPage());
            var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            await App.NavigationPage.PopToRootAsync(false);
            (App.NavigationPage.CurrentPage as MasterDetailPage).IsPresented = true;
            //otherPage.Detail = new NavigationPage(new Driver_WorksheetPage());
           // (App.NavigationPage.CurrentPage as MasterDetailPage).Detail = homePage;
        }

        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    App.NavigationPage.Navigation.PushAsync(new Driver_DailyCheckListPage());
        //}

        private async void WorksheetList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            try
            {

                var IsSelected = await DisplayAlert("Alert!", "Do you want to Start Your Work Now?", "Yes", "No");
                if (IsSelected)
                {
                    var data = e.SelectedItem as WorksheetListByEmployee;
                    if (data.WorksheetStatus == 1)
                    {
                        var WorksheetId = data.Id;
                        var VehicleId = data.VehicleId;
                        Settings.VehicleID = VehicleId;
                        Settings.WorksheetID = WorksheetId;
                        //Settings.PreviousWorksheetID = WorksheetId;
                        Settings.CompanyId = data.ComapnyId;
                        Settings.RegoNo = data.Rego;
                        _objDriverActualStartAndEndTimeRequest = new DriverActualStartAndEndTimeRequest()
                        {
                            WorkDate = data.WorkSheetDate,
                            ProgramStartTime = data.ProgramStartTime,
                            ApprovedStartTime = data.StartTime,
                            ActualStartTime = DateTime.Now,
                            StartTime = data.StartTime,
                            WorksheetId = WorksheetId,
                            EmployeeId = Settings.UserId
                        };
                        _objDriverActualStartAndEndTimeResponse = await _apiServices.DriverActualStartAndEndTimeAsync(new Get_API_Url().CommonBaseApi(_baseUrlDriverActualStartAndEndTime), true, _objHeaderModel, _objDriverActualStartAndEndTimeRequest);
                        var Result = _objDriverActualStartAndEndTimeResponse.Response;
                        if (Result.StatusCode == 200)
                        {
                            DependencyService.Get<IToast>().Show("Your Actual Time Starts Now keep going!");
                            await App.NavigationPage.Navigation.PushAsync(new Driver_DailyCheckListPage(Settings.WorksheetID, Settings.VehicleID));
                        }
                        else if(Result.StatusCode == 203)
                        {
                            await App.NavigationPage.Navigation.PushAsync(new Driver_DailyCheckListPage(Settings.WorksheetID, Settings.VehicleID));
                        }
                        else
                        {
                            DependencyService.Get<IToast>().Show("Server Error!");
                        }

                    }
                    else
                    {
                        await DisplayAlert("Info", "This WorkSheet Is Already Signed off !", "Ok");
                    }

                }
                else
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void LoadPageData()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objDriverWorkSheetListRequest = new DriverWorkSheetListRequest();
                _objDriverWorkSheetListRequest.EmployeeId = Settings.UserId.ToString();
                _objDriverWorkSheetListRequest.Search = string.Empty;
                _objDriverWorkSheetListRequest.OrderBy = Orderby;
                //ASC
                //-----------------------------------------Api Request-------------------
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objDriverWorkSheetListResponse = await _apiServices.LoadDriverWorkSheetListAsync(new Get_API_Url().Driver_WorkSheetListApi(_baseUrl), true, _objHeaderModel, _objDriverWorkSheetListRequest);
                if (_objDriverWorkSheetListResponse.Response.StatusCode == 200)
                {
                    if(_objDriverWorkSheetListResponse.Response.WorksheetListByEmployee.Count>0)
                    {
                        foreach (var Items in _objDriverWorkSheetListResponse.Response.WorksheetListByEmployee)
                        {
                            if (Items.WorksheetStatus==1)
                            {
                                Items.ProgressImage = "progress.png";
                            }
                            else
                            {
                                Items.ProgressImage = "completed.png";
                            }
                            if(Items.WorkSheetDate!=null)
                            Items.WorkSheetDateBinding = Items.WorkSheetDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);

                        }
                        DependencyService.Get<IToast>().Show("Sucess");
                        WorksheetList.ItemsSource = _objDriverWorkSheetListResponse.Response.WorksheetListByEmployee;
                        await Navigation.PopAllPopupAsync();
                    }
                    else
                    {
                        DependencyService.Get<IToast>().Show("No Data to Display!");
                    }
                }
                else
                {
                    DependencyService.Get<IToast>().Show("Something Bad Happend please Try again Later!");
                    await Navigation.PopAllPopupAsync();
                }
            }
        catch(Exception ex)
            {
                var msg = ex.Message;
                DependencyService.Get<IToast>().Show(msg);
                await Navigation.PopAllPopupAsync();
            }
            }

        private void TapSortBy_Tapped(object sender, EventArgs e)
        {
            if (Orderby == "DESC")
            {
                Orderby = "ASC";
            }
            else
            {
                Orderby = "DESC";
            }
            LoadPageData();
        }

        private void ButtonRequest_Clicked(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new AddWorkSheetPage());
        }
    }

}