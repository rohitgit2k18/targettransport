using AsNum.XFControls.Services;
using Plugin.Connectivity;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
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
	public partial class AddNewMRequestPage : ContentPage
	{
        #region Variable Declaration
        private Driver_AddMaintananceResponse _objDriver_AddMaintananceResponse;
        private Driver_AddMaintananceRequest _objDriver_AddMaintananceRequest;
        private MediaFile _mediaFile;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;       
        private RestApi _apiServices;
        #endregion

        public AddNewMRequestPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            _objDriver_AddMaintananceRequest = new Driver_AddMaintananceRequest();
            BindingContext = _objDriver_AddMaintananceRequest;
            _objDriver_AddMaintananceResponse = new Driver_AddMaintananceResponse();
            _objHeaderModel = new HeaderModel();
            _baseUrl = Settings.Url + Domain.Driver_AddMaintananceApiConstant;
            _apiServices = new RestApi();
        }

        private async void btnMaintananceSubmit_Clicked(object sender, EventArgs e)
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objDriver_AddMaintananceRequest.RequestDate = DateTime.Now;
                _objDriver_AddMaintananceRequest.CompanyId = Settings.CompanyId.ToString();
                _objDriver_AddMaintananceRequest.IsActive = true;
                _objDriver_AddMaintananceRequest.CreatedOn = DateTime.Now;
                _objDriver_AddMaintananceRequest.CreatedBy = Settings.UserId;
                _objDriver_AddMaintananceRequest.EmployeeId = Settings.UserId;
                //_objDriver_AddMaintananceRequest.MultilpleImage = null;
                if(string.IsNullOrEmpty(_objDriver_AddMaintananceRequest.VehicleName)||
                    string.IsNullOrEmpty(_objDriver_AddMaintananceRequest.Rego)||
                    string.IsNullOrEmpty(_objDriver_AddMaintananceRequest.Fault))
                {

                    DependencyService.Get<IToast>().Show("Please Enter All the field First!");
                }
                else
                {
                    if (!CrossConnectivity.Current.IsConnected)
                    {
                        DependencyService.Get<IToast>().Show("You are Offline Please Check Your Internet Connection!");
                    }
                    else
                    {
                        await Navigation.PushPopupAsync(new LoadingPopPage());
                        _objDriver_AddMaintananceResponse= await _apiServices.AddMaintananceAsync(new Get_API_Url().Driver_AddMaintananceApi(_baseUrl), true, _objHeaderModel, _objDriver_AddMaintananceRequest);
                        if (_objDriver_AddMaintananceResponse.Response.StatusCode == 200)
                        {
                            DependencyService.Get<IToast>().Show(_objDriver_AddMaintananceResponse.Response.Message);                           
                        }
                        else
                        {
                            DependencyService.Get<IToast>().Show(_objDriver_AddMaintananceResponse.Response.Message);
                        }
                        await Navigation.PopAllPopupAsync();
                    }
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                await Navigation.PopAllPopupAsync();
            }
        }

        private void BtnBack_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }

        private async void BtnUploadPic_Clicked(object sender, EventArgs e)
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
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 92

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
                _objDriver_AddMaintananceRequest.MultilpleImage.Add(imageString);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            
        }
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);

                //int read;
                //while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                //{
                //    ms.Write(buffer, 0, read);
                //}
                return ms.ToArray();
            }
        }
    }
}