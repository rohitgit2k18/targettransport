using AsNum.XFControls.Services;
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
using TargetTransport_Api.Models.RequestModels.NonDriverRequest;
using TargetTransport_Api.Models.ResponseModels.NonDriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace TargetTransport.View.NonDriverSection
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NDriverDailyCheckListPage : ContentPage
    {
        #region Variable Declaration
        //private DailyEntryViewModel _objDailyEntryViewModel;
        private NonDriver_DailyCheckListResponse _objNonDriver_DailyCheckListResponse;
        private NonDriver_DailyCheckListRequest _objNonDriver_DailyCheckListRequest;
        private ND_DailyCheckLIstPostRequest _objND_DailyCheckLIstPostRequest;
        private ND_DailyCheckLIstPostResponse _objND_DailyCheckLIstPostResponse;
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
        public NDriverDailyCheckListPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _objNonDriver_DailyCheckListResponse = new NonDriver_DailyCheckListResponse();
            _objND_DailyCheckLIstPostResponse = new ND_DailyCheckLIstPostResponse();
            _baseUrl = Settings.Url + Domain.NDDailyCheckListGet_ApiConstant;
            _baseUrlPostdata = Settings.Url + Domain.NDDailyCheckListPost_ApiConstant;
            _apiServices = new RestApi();
            _objHeaderModel = new HeaderModel();
            RbtnList = new List<string>();
            CheckBoxObj = new List<int>();
            RadiobBtnObj = new List<int>();
            LoadPageData();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lblUsername.Text = "Welcome " + Settings.Name;
            imgProfile.Source = Settings.ProfilePicture;
           
        }
        private async void LoadPageData()
        {
            RbtnList.Add("Yes");
            RbtnList.Add("No");
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objNonDriver_DailyCheckListRequest = new NonDriver_DailyCheckListRequest
                {
                    Id = Settings.UserId,
                    
                };

                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objNonDriver_DailyCheckListResponse = await _apiServices.ND_DailyCheckLIstGetDataAsync(new Get_API_Url().CommonBaseApi(_baseUrl), true, _objHeaderModel, _objNonDriver_DailyCheckListRequest);
                if (_objNonDriver_DailyCheckListResponse.Response.StatusCode == 200)
                {
                    //Settings.RegoNo = _objNonDriver_DailyCheckListResponse.Response.RegoNo;
                    sepListView.FlowItemsSource = _objNonDriver_DailyCheckListResponse.Response.CheckListList;
                    foreach (var items in _objNonDriver_DailyCheckListResponse.Response.QuestionList)
                    {
                        items.LoadAnswerOptions = RbtnList;
                    }

                    QuestionWithOptionList.ItemsSource = _objNonDriver_DailyCheckListResponse.Response.QuestionList;
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
        private void CheckBox_CheckChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = ((AsNum.XFControls.CheckBox)sender);
                var QuestionId = selectedItem.BindingContext;
                var chkbxobj = QuestionId.GetType();
                var SelectedId = chkbxobj.GetProperty("id").GetValue(QuestionId);
                if (selectedItem.Checked == true)
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
            catch (Exception ex)
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
                    if (RadiobBtnObj.Contains(Convert.ToInt32(radioId)))
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
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
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
                _objND_DailyCheckLIstPostRequest = new ND_DailyCheckLIstPostRequest
                {
                    VechicleId = Settings.VehicleID.ToString(),              
                    EmployeeId = Settings.UserId.ToString(),
                    CreatedBy = Settings.UserId.ToString(),
                    Comments = Comments,
                    QuestionChecelist = SelectedRadioIds,
                    SelectChecklist = SelecetedCheckIds
                };
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objND_DailyCheckLIstPostResponse = await _apiServices.ND_DailyCheckLIstPostDataAsync(new Get_API_Url().CommonBaseApi(_baseUrlPostdata), true, _objHeaderModel, _objND_DailyCheckLIstPostRequest);
                if (_objND_DailyCheckLIstPostResponse.Response.statusCode == 200)
                {
                    DailyCheckListID = _objND_DailyCheckLIstPostResponse.Response.Id;
                    await App.NavigationPage.Navigation.PushAsync(new NDriverSignaturePage(DailyCheckListID));
                    DependencyService.Get<IToast>().Show(_objND_DailyCheckLIstPostResponse.Response.Message);
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
            }
        }

    }
}