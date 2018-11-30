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
using TargetTransport_Api.Models.RequestModels.DriverRequest;
using TargetTransport_Api.Models.ResponseModels.DriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.DriverSction
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Driver_SelectVehiclePage : ContentPage
	{
        #region Variable Declaration       
        private Driver_SelectVehicleRequest _objDriver_SelectVehicleRequest;
        private DriverSelectVehicleResonse _objDriverSelectVehicleResonse;
        private HeaderModel _objHeaderModel;
        private string _baseUrl;
        private RestApi _apiServices;      
        #endregion
        public Driver_SelectVehiclePage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this,false);
            _objDriverSelectVehicleResonse = new DriverSelectVehicleResonse();
            _baseUrl = Settings.Url + Domain.SelectVehicleApiConstant;
            _apiServices = new RestApi();
            _objHeaderModel = new HeaderModel();
            LoadPageData();
        }

        private void btnSubmitdailyList_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.NavigationPage.Navigation.PushAsync(new Driver_DailyCheckListPage(Settings.WorksheetID, Settings.VehicleID));
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
            }
        private async void LoadPageData()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objDriver_SelectVehicleRequest = new Driver_SelectVehicleRequest
                {
                    Id = Settings.UserId
                };
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objDriverSelectVehicleResonse = await _apiServices.GetDriverSelectVehicleListAsync(new Get_API_Url().VehicleListApi(_baseUrl), true, _objHeaderModel, _objDriver_SelectVehicleRequest);
                if (_objDriverSelectVehicleResonse.Response.StatusCode == 200)
                {
                    DependencyService.Get<IToast>().Show("Sucess!!");
                    SelectVehicleList.ItemsSource = _objDriverSelectVehicleResonse.Response.VechicleListByEmployeeId;
                    await Navigation.PopAllPopupAsync();
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
            }
        }

        //private void chkbxVehicle_CheckChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var selectedItem = ((AsNum.XFControls.CheckBox)sender);
        //        var VehicleId = selectedItem.BindingContext;
        //        var chkbxobj = VehicleId.GetType();
        //        var SelectedVehicleId = chkbxobj.GetProperty("Id").GetValue(VehicleId);
        //        if (selectedItem.Checked == true)
        //        {
        //            if (Convert.ToInt32(SelectedVehicleId) > 0)                     
        //                Settings.VehicleID = Convert.ToInt32(SelectedVehicleId);
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {
        //        var msg = ex.Message;
        //    }
        //}

        private void BtnBack_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }

        private void CheckBox_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            try
            {
                var selectedItem = ((XLabs.Forms.Controls.CheckBox)sender);
                var VehicleId = selectedItem.BindingContext;
                
                var chkbxobj = VehicleId.GetType();
                var SelectedVehicleId = chkbxobj.GetProperty("Id").GetValue(VehicleId);
                var regoNo = chkbxobj.GetProperty("Rego").GetValue(VehicleId);
                if (selectedItem.Checked == true)
                {
                    if (Convert.ToInt32(SelectedVehicleId) > 0)
                        Settings.VehicleID = Convert.ToInt32(SelectedVehicleId);
                    Settings.RegoNo = regoNo.ToString();
                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}