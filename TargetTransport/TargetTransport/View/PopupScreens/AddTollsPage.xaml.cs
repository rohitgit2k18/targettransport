using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport_Api.Models.ResponseModels.DriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTollsPage : PopupPage
    {
        private Driver_TollsListResponse _objDriver_TollsListResponse;
        public static List<long> TollsIds;
        public AddTollsPage(Driver_TollsListResponse driver_TollsListResponse)
        {
            InitializeComponent();
            _objDriver_TollsListResponse = driver_TollsListResponse;

            ListViewTolls.ItemsSource = _objDriver_TollsListResponse.Response.AccountSettingTollList;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            FrameContainer.HeightRequest = -1;

           
        }
        private void OnCloseButtonTapped(object sender, EventArgs e)
        {
            CloseAllPopup();
        }

        protected override bool OnBackgroundClicked()
        {
            CloseAllPopup();

            return false;
        }

        private async void CloseAllPopup()
        {
            await Navigation.PopAllPopupAsync();
        }

        private void XFSwitchTolls_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}