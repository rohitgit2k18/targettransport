using AsNum.XFControls.Services;
using Plugin.Connectivity;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.MechanicSction
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mechanic_RequestDonePage : ContentPage
	{
        #region Variable Declaration
        //private DailyEntryViewModel _objDailyEntryViewModel;
        private M_CheckListResponse _objM_CheckListResponse;
        private M_CheckListRequest _objM_CheckListRequest;
        private M_RequestDoneResponse _objM_RequestDoneResponse;
         private M_RequestDoneRequest _objM_RequestDoneRequest;
        private HeaderModel _objHeaderModel;
        private MediaFile _mediaFile;
        private string _baseUrl;
        private string _baseUrlPostdata;
        private RestApi _apiServices;             
        private int DailyCheckListID;
        private Int32 _maintananceId;
        private List<int> CheckBoxObj;       
        #endregion
        public Mechanic_RequestDonePage (Int32 MaintananceID )
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            _objM_CheckListResponse = new M_CheckListResponse();
            _objM_CheckListRequest = new M_CheckListRequest();
            _objM_RequestDoneResponse = new M_RequestDoneResponse();
            _objM_RequestDoneRequest = new M_RequestDoneRequest();
            _objHeaderModel = new HeaderModel();
            _baseUrl = Settings.Url + Domain.M_CheckboxListApiConstant;
            _baseUrlPostdata = Settings.Url + Domain.M_SendRequestDoneApiConstant;
            _apiServices = new RestApi();
            CheckBoxObj = new List<int>();
            _maintananceId = MaintananceID;
            LoadPageData();
        }
        private async void LoadPageData()
        {
            //RbtnList.Add("Yes");
            //RbtnList.Add("No");
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objM_CheckListRequest = new M_CheckListRequest
                {
                    Id = Settings.UserId,
                };
                if (!CrossConnectivity.Current.IsConnected)
                {
                    DependencyService.Get<IToast>().Show("No Internet Connection!");
                }
                else
                {
                    await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objM_CheckListResponse = await _apiServices.M_ChecklIstDataAsync(new Get_API_Url().CommonBaseApi(_baseUrl), true, _objHeaderModel, _objM_CheckListRequest);
                    if (_objM_CheckListResponse.Response.StatusCode == 200)
                    {
                        sepListView.FlowItemsSource = _objM_CheckListResponse.Response.CheckListList;
                        DependencyService.Get<IToast>().Show("Sucess");
                        await Navigation.PopAllPopupAsync();
                    }
                    else
                    {
                        DependencyService.Get<IToast>().Show("Something Bad Happend please Try again Later!");
                        await Navigation.PopAllPopupAsync();
                    }
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

        private async void btnSubmitdailyList_Clicked(object sender, EventArgs e)
        {
            try
            {

                string SelecetedCheckIds = string.Empty; 
                string Comments = txtComments.Text;
                foreach (var Checkbx in CheckBoxObj)
                {
                    SelecetedCheckIds += Checkbx.ToString() + ",";
                }
               
                _objHeaderModel.TokenCode = Settings.TokenCode;
                //
                //{
                _objM_RequestDoneRequest.MaintenenceRequestId = _maintananceId;
                _objM_RequestDoneRequest.EmployeeId = Settings.UserId;
                _objM_RequestDoneRequest.Comments = Comments;
                _objM_RequestDoneRequest.Checklist = SelecetedCheckIds;

                // };
                if (_objM_RequestDoneRequest.Comments != null || _objM_RequestDoneRequest.Checklist != null)
                {
                    await Navigation.PushPopupAsync(new LoadingPopPage());
                    _objM_RequestDoneResponse = await _apiServices.M_SendRequestDoneDataAsync(new Get_API_Url().CommonBaseApi(_baseUrlPostdata), true, _objHeaderModel, _objM_RequestDoneRequest);
                    if (_objM_RequestDoneResponse.Response.StatusCode == 200)
                    {
                        await App.NavigationPage.Navigation.PushAsync(new Mechanic_SignaturePage(_maintananceId));
                        DependencyService.Get<IToast>().Show(_objM_RequestDoneResponse.Response.Message);
                        await Navigation.PopAllPopupAsync();
                    }
                    else
                    {
                        // await App.NavigationPage.Navigation.PushAsync(new Mechanic_SignaturePage(_maintananceId));
                        DependencyService.Get<IToast>().Show("Something Bad Happend please Try again Later!");
                        await Navigation.PopAllPopupAsync();
                    }
                }
                else
                {
                    DependencyService.Get<IToast>().Show("please enter the text field and checkbox !");
                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                await Navigation.PopAllPopupAsync();
            }
        }

        private async void btnSubmitImg_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                _mediaFile = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    //PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    //CompressionQuality = 92

                });


                if (_mediaFile == null)
                    return;

                Image1.Source = ImageSource.FromStream(() =>
                {
                    // var stream = _mediaFile.GetStream();
                    // _mediaFile.Dispose();
                    return _mediaFile.GetStream();
                });
                //   _objUploadProfileBase64Req = new UploadProfileBase64Req();
                // var ImageName = _mediaFile.Path.Split('\\').LastOrDefault().Split('/').LastOrDefault();
                //var Byt = ReadFully(_mediaFile.GetStream());
                //string base64 = Convert.ToBase64String(Byt);
                // _objUploadProfileBase64Req.ImageName = ImageName;
                // _objUploadProfileBase64Req.ProfilePicture = base64;

                // await Navigation.PushPopupAsync(new UploadConfirmation(_objUploadProfileBase64Req));
                //  await Navigation.PushPopupAsync(new UploadConfirmation(_mediaFile));
                var imageString = Base64Extensions.ConvertToBase64(_mediaFile.GetStream());
                _objM_RequestDoneRequest.MultipleImage.Add(imageString);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}