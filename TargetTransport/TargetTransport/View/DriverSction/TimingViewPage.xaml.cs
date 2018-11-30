using AsNum.XFControls.Services;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport_Api.Models.ResponseModels.DriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.DriverSction
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimingViewPage : ContentPage
	{
        private Driver_WorkSheetDetailsGetResponse _objDriver_WorkSheetDetailsGetResponse;

        public TimingViewPage (Driver_WorkSheetDetailsGetResponse ObjDriver_WorkSheetDetailsGetResponse)
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            _objDriver_WorkSheetDetailsGetResponse = ObjDriver_WorkSheetDetailsGetResponse;
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadPageData();
        }
        private void LoadPageData()
        {
            try
            {
                var TotalLoadList = _objDriver_WorkSheetDetailsGetResponse.Response.AllLoadList;
                if (TotalLoadList.Count > 0)
                {
                    listLoads.ItemsSource = TotalLoadList;
                    if (_objDriver_WorkSheetDetailsGetResponse.Response.WorksheetDetails.WorkSheetDate != null)
                    {
                        _objDriver_WorkSheetDetailsGetResponse.Response.WorksheetDetails.WorkSheetDateBD = _objDriver_WorkSheetDetailsGetResponse.Response.WorksheetDetails.WorkSheetDate.ToString();
                    }
                    BindingContext = _objDriver_WorkSheetDetailsGetResponse.Response.WorksheetDetails;
                }
                else
                {
                    DependencyService.Get<IToast>().Show("No Any Load to Display!");
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }
        private async void btnSubmitdailyList_Clicked(object sender, EventArgs e)
        {
            // App.NavigationPage.Navigation.PushAsync(new WorksheetSignOffPopUp());
          await  Navigation.PushPopupAsync(new WorksheetSignOffPopUp());
        }

        private void Btnback_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }

        private void ListItemTapped(object sender, EventArgs e)
        {
           
        }

        private void listLoads_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (e.SelectedItem == null)
                {
                    return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
                }
                else
                {
                    var obj = e.SelectedItem as AllLoadList;
                    var LoadId = obj.LoadId;
                    App.NavigationPage.Navigation.PushAsync(new Driver_LoadDetailsPage(LoadId));
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            // 
            
        }
    }
}