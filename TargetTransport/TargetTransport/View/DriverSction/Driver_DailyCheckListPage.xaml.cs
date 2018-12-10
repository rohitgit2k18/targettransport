using AsNum.XFControls.Services;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.CustomeControls;
using TargetTransport.Helpers;
using TargetTransport.Models;
using TargetTransport.ViewModels;
using TargetTransport_Api.ApiHandler;
using TargetTransport_Api.Models;
using TargetTransport_Api.Models.RequestModels.DriverRequest;
using TargetTransport_Api.Models.ResponseModels.DriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace TargetTransport.View.DriverSction
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Driver_DailyCheckListPage : ContentPage
	{
        #region Variable Declaration
        private DailyEntryViewModel _objDailyEntryViewModel;
        private Driver_DailyCheckListGetResponse _objDriver_DailyCheckListGetResponse;
        private Driver_DailyCheckListGetRequest _objDriver_DailyCheckListGetRequest;
        private Driver_DailyCheckLestPostRequest _objDriver_DailyCheckLestPostRequest;
        private Driver_DailyCheckListPostResponse _objDriver_DailyCheckListPostResponse;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private string _baseUrlPostdata;
        private RestApi _apiServices;
        private int WorkSheetId;
        private int VehicleId;
        private int DailyCheckListID;
          List<string> RbtnList;
        private List<int> CheckBoxObj;
        List<int> RadiobBtnObj;
        #endregion

        public Driver_DailyCheckListPage (int sheetId,int vehicleId)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            _objDailyEntryViewModel = new DailyEntryViewModel();           
            _objHeaderModel = new HeaderModel();
            _apiServices = new RestApi();
            _baseUrl = Settings.Url + Domain.DriverDailyCheckListApiConstant;
            _baseUrlPostdata = Settings.Url + Domain.DriverDailyCheckListSubmitDataApiConstant;
            _objDriver_DailyCheckListGetResponse = new Driver_DailyCheckListGetResponse();
            _objDriver_DailyCheckListPostResponse = new Driver_DailyCheckListPostResponse();
            WorkSheetId = sheetId;
            VehicleId = vehicleId;            
            RbtnList = new List<string>();
            CheckBoxObj = new List<int>();
            RadiobBtnObj = new List<int>();
            LoadPageData();
        }
       
        protected override void OnAppearing()
        {
            // Set up activity indicator        

            if (!string.IsNullOrEmpty(Settings.RegoNo))
                LblRegoId.Text = Settings.RegoNo;
            imgProfile.Source = Settings.ProfilePicture;
            LblUserName.Text = "Welcome "+Settings.Name;
            // GC.Collect();
            // Remove activity indicator and set up real views
        }
        private async void btnSubmitdailyList_Clicked(object sender, EventArgs e)
        {
            try
            {
               
                string SelecetedCheckIds = string.Empty;
                string SelectedRadioIds = string.Empty;
                string Comments = txtComments.Text;
                foreach (var Checkbx in CheckBoxObj)
                {
                    SelecetedCheckIds += Checkbx.ToString() + ",";
                }
                foreach (var radiobx in RadiobBtnObj)
                {
                    SelectedRadioIds += radiobx.ToString() + ",";
                }
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objDriver_DailyCheckLestPostRequest = new Driver_DailyCheckLestPostRequest
                {
                    VechicleId = Settings.VehicleID.ToString(),
                    WorksheetId = WorkSheetId.ToString(),
                    EmployeeId = Settings.UserId.ToString(),
                    CreatedBy = Settings.UserId.ToString(),
                    Comments = Comments,
                    QuestionChecelist = SelectedRadioIds,
                    EngineHrs= txtEnginehours.Text,
                    Odometer= txtOdometer.Text,
                    SelectChecklist = SelecetedCheckIds
                };
                if(string.IsNullOrEmpty(SelecetedCheckIds) || string.IsNullOrEmpty(SelectedRadioIds))
                    {
                    DependencyService.Get<IToast>().Show("Please select the right Answers first and the checkbox!");
                        }
                else
                {
                    await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objDriver_DailyCheckListPostResponse = await _apiServices.DriverDailyCheckListPostAsync(new Get_API_Url().DriverDailyCheckListAddDataApi(_baseUrlPostdata), true, _objHeaderModel, _objDriver_DailyCheckLestPostRequest);
                    if (_objDriver_DailyCheckListPostResponse.Response.statusCode == 200)
                    {
                        DailyCheckListID = _objDriver_DailyCheckListPostResponse.Response.Id;
                        await App.NavigationPage.Navigation.PushAsync(new Driver_SignatureScreenPage(DailyCheckListID));
                        DependencyService.Get<IToast>().Show(_objDriver_DailyCheckListPostResponse.Response.Message);
                        await Navigation.PopAllPopupAsync();
                    }
                    else
                    {
                        DependencyService.Get<IToast>().Show("Something Bad Happend please Try again Later!");
                        await Navigation.PopAllPopupAsync();
                    }
                }
               
                
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void LblSelectVehicle_Click(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new Driver_SelectVehiclePage());
        }

        private void Ask4Maintanance_Click(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new Driver_MaintenanceRequestPage());
        }
        private async void LoadPageData()
        {
            RbtnList.Add("Yes");
            RbtnList.Add("No");
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objDriver_DailyCheckListGetRequest = new Driver_DailyCheckListGetRequest
                {
                    Id = Settings.UserId,
                    WorksheetId = WorkSheetId.ToString(),
                    //changes by ritesh/rohit
                    DefaultVehicleId = Settings.VehicleID
                };

                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objDriver_DailyCheckListGetResponse = await _apiServices.DriverDailyCheckListGetAsync(new Get_API_Url().Driver_DailyCheckListApi(_baseUrl), true, _objHeaderModel, _objDriver_DailyCheckListGetRequest);
                if (_objDriver_DailyCheckListGetResponse.Response.StatusCode == 200)
                {
                    foreach(var itm in _objDriver_DailyCheckListGetResponse.Response.CheckListList)
                    {
                        
                        itm.IsChecked = false;
                    }
                    Settings.RegoNo = _objDriver_DailyCheckListGetResponse.Response.RegoNo;
                    sepListView.FlowItemsSource = _objDriver_DailyCheckListGetResponse.Response.CheckListList;
                    foreach (var items in _objDriver_DailyCheckListGetResponse.Response.QuestionList)
                    {
                        items.LoadAnswerOptions = RbtnList;
                    }

                    QuestionWithOptionList.ItemsSource = _objDriver_DailyCheckListGetResponse.Response.QuestionList;
                    DependencyService.Get<IToast>().Show("Sucess");
                   // WorksheetList.ItemsSource = _objDriverWorkSheetListResponse.Response.WorksheetListByEmployee;
                    await Navigation.PopAllPopupAsync();
                }
                else
                {
                    DependencyService.Get<IToast>().Show("Something Bad Happend please Try again Later!");
                    await Navigation.PopAllPopupAsync();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                await Navigation.PopAllPopupAsync();
            }
        }
      
        //private async void SendPostData()
        //{
        //    try
        //    {

        //    }
        //    catch(Exception ex)
        //    {
        //        var msg = ex.Message;
        //    }
        //}
        private void CheckBox_CheckChanged(object sender, EventArgs e)
        {
            try
            {                           
                var selectedItem = ((Switch)sender);              
                var QuestionId = selectedItem.BindingContext;
                var chkbxobj = QuestionId.GetType();
                var SelectedId = chkbxobj.GetProperty("id").GetValue(QuestionId);
                if(selectedItem.IsToggled==true)
                {
                    if (Convert.ToInt32(SelectedId) > 0)
                        CheckBoxObj.Add(Convert.ToInt32(SelectedId));
                }
                else
                {
                    if (Convert.ToInt32(SelectedId) > 0)
                        CheckBoxObj.Remove(Convert.ToInt32(SelectedId));
                }
            }
             catch(Exception ex)
            {
                var msg = ex.Message;
            }        
        }

        private void RadioCheck_CheckedChanged(object sender, int e)
        {
            try
            {
                var selectedItem = ((CustomRadioButton)sender);                                               
                if (selectedItem.Text.Contains("Yes"))
                {
                    var QuestionId = selectedItem.BindingContext;
                    var radioObj = QuestionId.GetType();
                    var radioId = radioObj.GetProperty("id").GetValue(QuestionId);
                    if(RadiobBtnObj.Contains(Convert.ToInt32(radioId)))
                    {
                        //do nothing(because ethis event is fired twice )
                    }
                    else
                    {
                        //load id into list
                        RadiobBtnObj.Add(Convert.ToInt32(radioId));
                    }
                    
                }
                if (selectedItem.Text.Contains("No"))
                {
                    var QuestionId = selectedItem.BindingContext;
                    var radioObj = QuestionId.GetType();
                    var radioId = radioObj.GetProperty("id").GetValue(QuestionId);
                    RadiobBtnObj.Remove(Convert.ToInt32(radioId));
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void BackButtonTap_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }

        private void XFCbxSelectAll_CheckChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = ((AsNum.XFControls.CheckBox)sender);
              
                if (selectedItem.Checked == true)
                {
                    sepListView.FlowItemsSource = null;

                    foreach (var Items in _objDriver_DailyCheckListGetResponse.Response.CheckListList)
                    {
                        Items.IsChecked = true;
                        
                    }

                    Device.BeginInvokeOnMainThread(() => {
                        
                        sepListView.FlowItemsSource = _objDriver_DailyCheckListGetResponse.Response.CheckListList;

                                                
                    });
                      
                }
                else
                {
                    sepListView.FlowItemsSource = null;
                    foreach (var Items in _objDriver_DailyCheckListGetResponse.Response.CheckListList)
                    {
                        Items.IsChecked = false;
                       
                    }
                    Device.BeginInvokeOnMainThread(() => {

                        sepListView.FlowItemsSource = _objDriver_DailyCheckListGetResponse.Response.CheckListList;
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void XFBtnSkip_Clicked(object sender, EventArgs e)
        {
            if (Settings.PreviousWorksheetID == Settings.WorksheetID)
            {
                if (Settings.IsPreStartChecked)
                {
                    App.NavigationPage.Navigation.PushAsync(new WorkSheetDetailsPage());
                }
                else
                {
                    DisplayAlert("Alert!", "You have not completed the prestart for this WorkSheet!", "ok");
                }
                
            }
            else
            {
                DisplayAlert("Alert!", "You have not completed the prestart for this WorkSheet!", "ok");

            }
        }
    }
}