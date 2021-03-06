﻿using AsNum.XFControls.Services;
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
using TargetTransport_Api.Models.RequestModels.DriverRequest;
using TargetTransport_Api.Models.ResponseModels.DriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.DriverSction
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Driver_TimeSheetPage : ContentPage
	{
        #region Variable Declaration
        private Driver_TimeSheetResponse _objDriver_TimeSheetResponse;
        private Driver_TimeSheetRequest _objDriver_TimeSheetRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private RestApi _apiServices;
        #endregion
        public Driver_TimeSheetPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            _apiServices = new RestApi();
            _objHeaderModel = new HeaderModel();
            _baseUrl = Settings.Url + Domain.Driver_TimeSheetApiConstant;
            _objDriver_TimeSheetResponse = new Driver_TimeSheetResponse();
            _objDriver_TimeSheetRequest = new Driver_TimeSheetRequest();
            LoadTimeSheetList();
        }
        private async void imgHamburger_Click(object sender, EventArgs e)
        {
            var otherPage = new Driver_NavigationPage();
            otherPage.Detail = new NavigationPage(new Driver_TimeSheetPage());
            var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            await App.NavigationPage.PopToRootAsync(false);
            (App.NavigationPage.CurrentPage as MasterDetailPage).IsPresented = true;
            //otherPage.Detail = new NavigationPage(new Driver_WorksheetPage());
            // (App.NavigationPage.CurrentPage as MasterDetailPage).Detail = homePage;
        }
        private async void LoadTimeSheetList()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;               
                _objDriver_TimeSheetRequest.EmployeeId = Settings.UserId;
               
                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IToast>().Show("You are Offline Please Check Your Internet Connection!");
                }
                else
                {
                    await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objDriver_TimeSheetResponse = await _apiServices.Driver_TimeSheetAsync(new Get_API_Url().Driver_TimeSheetApi(_baseUrl), true, _objHeaderModel, _objDriver_TimeSheetRequest);
                    if (_objDriver_TimeSheetResponse.Response.StatusCode == 200)
                    {
                        if (_objDriver_TimeSheetResponse.Response.WorkTimeList.Count > 0)
                        {
                            foreach(var Items in _objDriver_TimeSheetResponse.Response.WorkTimeList)
                            {
                                if(Items.ProgramStartTime!=null)
                                {
                                   // var tIME = TimeSpan.FromTicks(Items.ProgramStartTime.Value.TimeOfDay);
                                    var PST = Items.ProgramStartTime;
                                    Items.ProgramStartTimeBinding = PST.Value.ToString("hh:mm tt");
                                   // var BPST = DateTime.ParseExact(PST, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                                  //  Items.ProgramStartTimeBinding = BPST.ToString("hh:mm tt");

                                }
                                if(Items.ApprovedStartTime!=null)
                                {
                                    var AST = Items.ApprovedStartTime;
                                    //var BAST = DateTime.ParseExact(AST, "HH:mm tt", CultureInfo.InvariantCulture);
                                    Items.ApprovedStartTimeBinding = AST.Value.ToString("hh:mm tt");
                                    // Items.ApprovedStartTimeBinding = Items.ApprovedStartTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);

                                }
                                if (Items.StartTime != null)
                                {
                                    var ST = Items.StartTime;
                                   // var BST = DateTime.ParseExact(ST, "HH:mm tt", CultureInfo.InvariantCulture);
                                    Items.StartTimeBinding = ST.Value.ToString("hh:mm tt");
                                    //Items.StartTimeBinding = Items.StartTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);

                                }
                                    if(Items.EndTime != null)
                                {
                                    var ET = Items.EndTime;
                                    //var BET = DateTime.ParseExact(ET, "HH:mm tt", CultureInfo.InvariantCulture);
                                    Items.EndTimeBinding = ET.Value.ToString("hh:mm tt");
                                    // Items.EndTimeBinding = Items.EndTime.ToString("HH:mm tt", CultureInfo.InvariantCulture);

                                }
                                    if(Items.WorkDate!=null)
                                {
                                    var WD = Items.WorkDate;
                                   // var BWD = DateTime.ParseExact(WD, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                                    Items.WorkDateBinding = WD.Value.ToString("dd-MMM-yyyy");
                                    // Items.WorkDateBinding = Items.WorkDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);

                                }
                                if (Items.EndDate != null)
                                {
                                    var ED = Items.EndDate;
                                   // var BED = DateTime.ParseExact(ED, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                                    Items.EndDateBinding = ED.Value.ToString("dd-MMM-yyyy");
                                    // Items.EndDateBinding = Items.EndDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);

                                }
                                Items.TotalHrs.ToString();
                            }
                            TimeSheetList.ItemsSource = _objDriver_TimeSheetResponse.Response.WorkTimeList;
                            DependencyService.Get<IToast>().Show(_objDriver_TimeSheetResponse.Response.Message);
                        }
                        else
                        {
                            DependencyService.Get<IToast>().Show("No Data To Display!");
                        }
                        
                    }
                    else
                    {
                        DependencyService.Get<IToast>().Show(_objDriver_TimeSheetResponse.Response.Message);
                    }
                    await Navigation.PopAllPopupAsync();
                }
            
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                await Navigation.PopAllPopupAsync();
            }
        }

        private void BtnLoadTimesheet_Clicked(object sender, EventArgs e)
        {
            _objDriver_TimeSheetRequest.WorkDate = StartDatePicker.Date;
            _objDriver_TimeSheetRequest.EndDate = EndDatePicker.Date;
            LoadTimeSheetList();
            
        }

        private void BtnBack_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }
    }
}