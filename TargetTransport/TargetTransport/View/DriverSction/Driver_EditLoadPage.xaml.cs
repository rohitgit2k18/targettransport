﻿using AsNum.XFControls.Services;
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
using TargetTransport_Api.Models.RequestModels.DriverRequest;
using TargetTransport_Api.Models.ResponseModels.DriverResponse;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TargetTransport.View.DriverSction
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Driver_EditLoadPage : ContentPage
    {
        #region Variable Declaration
        private Driver_EditLoadResponse _objDriver_EditLoadResponse;
        private Driver_EditLoadRequest _objDriver_EditLoadRequest;
        private Driver_LoadTypeResponse _objDriver_LoadTypeResponse;
        private Driver_LoadTypesRequest _objDriver_LoadTypesRequest;
        private Driver_TollsListResponse _objDriver_TollsListResponse;
        private Driver_TollsListRequest _objDriver_TollsListRequest;
        private HeaderModel _objHeaderModel;
        private string _baseUrlGetData;
        private string _baseUrlPostData;
        private string _baseUrlLoadTypes;
        private string _baseUrlTollsList;
        private RestApi _apiServices;
        private int LoadID;
        private bool IsClickedTall = false;
        private List<long> EditTolls;
        #endregion
        public Driver_EditLoadPage(int loadID)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _objDriver_EditLoadResponse = new Driver_EditLoadResponse();
            _objDriver_LoadTypeResponse = new Driver_LoadTypeResponse();
            _objDriver_TollsListResponse = new Driver_TollsListResponse();
            _objHeaderModel = new HeaderModel();
            EditTolls = new List<long>();
            LoadID = loadID;
            _apiServices = new RestApi();
            _baseUrlGetData = Settings.Url + Domain.EditLoadApiConstant;
            _baseUrlLoadTypes = Settings.Url + Domain.GetLoadTypesApiConstant;
            _baseUrlTollsList = Settings.Url + Domain.GetTollsListApiConstant;
            GetLoadTypes();
            LoadTolls();           
          
        }
        
        private async void GetLoad()
        {
            try
            {
                _objDriver_EditLoadRequest = new Driver_EditLoadRequest
                {
                    LoadId = LoadID,
                    WorksheetId = Settings.WorksheetID.ToString()
                };
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objDriver_EditLoadResponse = await _apiServices.EditLoadAsync(new Get_API_Url().EditLoadApi(_baseUrlGetData), true, _objHeaderModel, _objDriver_EditLoadRequest);
                if (_objDriver_EditLoadResponse.Response.StatusCode == 200)
                {
                    //  Convert.ToInt32(_objDriver_EditLoadResponse.Response.LoadDetails.JobType);
                    //bool containsLoadType = _objDriver_LoadTypeResponse.Response.LoadTypes.Any(item => item.Id == _objDriver_EditLoadResponse.Response.LoadDetails.JobType);
                    //bool containsToll= _objDriver_TollsListResponse.Response.AccountSettingTollList.Any(item => item.UniqueId == _objDriver_EditLoadResponse.Response.LoadDetails.TollId);

                    var existingLoadType = (from result in _objDriver_LoadTypeResponse.Response.LoadTypes
                                       where result.Id == _objDriver_EditLoadResponse.Response.LoadDetails.JobType
                                       select result).FirstOrDefault();
                    foreach (var Itemes in _objDriver_EditLoadResponse.Response.LoadDetails.TollIds)
                    {
                        //var existingToll = (from result in _objDriver_TollsListResponse.Response.AccountSettingTollList
                        //                    where result.AccountId == Itemes
                        //                    select result.AccountId).FirstOrDefault();
                        foreach (var itm in _objDriver_TollsListResponse.Response.AccountSettingTollList)
                        {
                            if(itm.AccountId== Itemes)
                            {
                                itm.IsTollSelected = true;
                            }
                            
                        }
                    }
                    if (existingLoadType != null)
                    {
                        int i = _objDriver_LoadTypeResponse.Response.LoadTypes.IndexOf(existingLoadType);
                        dropdownLoadType.SelectedIndex = i;
                    }
                    //if (existingToll != null)
                    //{
                    //    int j = _objDriver_TollsListResponse.Response.AccountSettingTollList.IndexOf(existingToll);
                    //    dropdownTolls.SelectedIndex = j;
                    //}
                    BindingContext = _objDriver_EditLoadResponse.Response.LoadDetails;
                    DependencyService.Get<IToast>().Show(_objDriver_EditLoadResponse.Response.Message);
                    await Navigation.PopAllPopupAsync();
                }
                else
                {
                    DependencyService.Get<IToast>().Show(_objDriver_EditLoadResponse.Response.Description);
                    await Navigation.PopAllPopupAsync();
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async void GetLoadTypes()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objDriver_LoadTypesRequest = new Driver_LoadTypesRequest
                {
                    CreatedBy = 0
                };
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objDriver_LoadTypeResponse = await _apiServices.GetLoadTypesAsync(new Get_API_Url().GetLoadTypesApi(_baseUrlLoadTypes), true, _objHeaderModel, _objDriver_LoadTypesRequest);
                if (_objDriver_LoadTypeResponse.Response.StatusCode == 200)
                {
                    //await App.NavigationPage.Navigation.PushAsync(new Driver_SignatureScreenPage(DailyCheckListID));
                    dropdownLoadType.ItemsSource = _objDriver_LoadTypeResponse.Response.LoadTypes;
                    DependencyService.Get<IToast>().Show(_objDriver_LoadTypeResponse.Response.Message);
                    await Navigation.PopAllPopupAsync();
                }
                else
                {
                    DependencyService.Get<IToast>().Show(_objDriver_LoadTypeResponse.Response.Description);
                    await Navigation.PopAllPopupAsync();
                }
            }
            catch (Exception ex)
            {
                await Navigation.PopAllPopupAsync();
                var msg = ex.Message;
            }
        }
        private async void LoadTolls()
        {
            try
            {
                _objHeaderModel.TokenCode = Settings.TokenCode;
                _objDriver_TollsListRequest = new Driver_TollsListRequest();
                _objDriver_TollsListRequest.ComapnyId = Settings.CompanyId;
                _objDriver_TollsListRequest.SearchKey = string.Empty;
                _objDriver_TollsListRequest.Limit = 50;
                _objDriver_TollsListRequest.OffSet = 0;
                await Navigation.PushPopupAsync(new LoadingPopPage());
                _objDriver_TollsListResponse = await _apiServices.GetTollListAsync(new Get_API_Url().GetTollsListApi(_baseUrlTollsList), true, _objHeaderModel, _objDriver_TollsListRequest);
                if (_objDriver_TollsListResponse.Response.StatusCode == 200)
                {
                    //await App.NavigationPage.Navigation.PushAsync(new Driver_SignatureScreenPage(DailyCheckListID));
                    ListViewTolls.ItemsSource = _objDriver_TollsListResponse.Response.AccountSettingTollList;
                    DependencyService.Get<IToast>().Show(_objDriver_TollsListResponse.Response.Message);
                    await Navigation.PopAllPopupAsync();
                    GetLoad();
                }
                else
                {
                    DependencyService.Get<IToast>().Show(_objDriver_TollsListResponse.Response.Description);
                    await Navigation.PopAllPopupAsync();
                    //need to change later
                    GetLoad();
                }
            }
            catch (Exception ex)
            {
                await Navigation.PopAllPopupAsync();
                var msg = ex.Message;
            }
        }

        private void dropdownLoadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                var data = picker.Items[picker.SelectedIndex];
                var LoadTypedata = picker.SelectedItem as LoadType;
                _objDriver_EditLoadResponse.Response.LoadDetails.JobType = LoadTypedata.Id;
               // _objDriver_AddLoadRequest.JobType = LoadTypedata.Id.ToString();
            }
            else
            {
                DependencyService.Get<IToast>().Show("please select LoadType!");
            }
        }

        private void dropdownTolls_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                var data = picker.Items[picker.SelectedIndex];
                var Tolls = picker.SelectedItem as AccountSettingTollList;
                _objDriver_EditLoadResponse.Response.LoadDetails.TollId = Tolls.AccountId;
               // _objDriver_AddLoadRequest.TollId = Tolls.UniqueId.ToString();
            }
            else
            {
                DependencyService.Get<IToast>().Show("please select Tolls!");
            }
        }

        private async void btnLoadViewDetailsSubmit_Clicked(object sender, EventArgs e)
        {
            try
            {
                //_objDriver_EditLoadResponse.Response.LoadDetails.TollIds = null;
                if(EditTolls.Count>0)
                {
                    _objDriver_EditLoadResponse.Response.LoadDetails.TollIds = EditTolls;
                }
                _objDriver_EditLoadResponse.Response.LoadDetails.LoadFrom = XfEntLoadFrom.Text;
                _objDriver_EditLoadResponse.Response.LoadDetails.DeliverTo = deliver_to.Text;
                _objDriver_EditLoadResponse.Response.LoadDetails.Start = Entrykilometer_start.Text;
                _objDriver_EditLoadResponse.Response.LoadDetails.NetWeight = Convert.ToDouble(xfEntNetweight.Text);
                _objDriver_EditLoadResponse.Response.LoadDetails.Finish = Entrykilometer_finish.Text;
                _objDriver_EditLoadResponse.Response.LoadDetails.KiloMeters = Convert.ToDouble(kmstxtbx.Text);
                _objDriver_EditLoadResponse.Response.LoadDetails.Comments = xfEntComments.Text;
                _objHeaderModel.TokenCode = Settings.TokenCode;
                if(_objDriver_EditLoadResponse.Response.LoadDetails.WaitTimePerMinute>=1)
                {
                    _objDriver_EditLoadResponse.Response.LoadDetails.WaitTimePerMinute = Convert.ToDouble(claim_minutes.Text);
                }
                if (_objDriver_EditLoadResponse.Response.LoadDetails.WaitTimePerMinuteJob >= 1)
                {
                    _objDriver_EditLoadResponse.Response.LoadDetails.WaitTimePerMinuteJob = Convert.ToDouble(claim_minutes1.Text);
                }
                _objDriver_EditLoadResponse.Response.LoadDetails.WorkSheetId = Settings.WorksheetID;
                _objDriver_EditLoadResponse.Response.LoadDetails.EmployeeId = Settings.UserId.ToString();
                if ((string.IsNullOrEmpty(_objDriver_EditLoadResponse.Response.LoadDetails.BridgeDocket)))
                    {
                    await Navigation.PushPopupAsync(new WBridgeDocketPopUp(_objDriver_EditLoadResponse));
                }
                else
                {
                    await App.NavigationPage.Navigation.PushAsync(new CustomerSignaturePage(null, 2, _objDriver_EditLoadResponse));
                }
               
                //await Navigation.PushPopupAsync(new LoadingPopPage());
                //_objDriver_LoadTypeResponse = await _apiServices.GetLoadTypesAsync(new Get_API_Url().GetLoadTypesApi(_baseUrlLoadTypes), true, _objHeaderModel, _objDriver_LoadTypesRequest);
                //if (_objDriver_LoadTypeResponse.Response.StatusCode == 200)
                //{
                //    //await App.NavigationPage.Navigation.PushAsync(new Driver_SignatureScreenPage(DailyCheckListID));
                //    dropdownLoadType.ItemsSource = _objDriver_LoadTypeResponse.Response.LoadTypes;
                //    DependencyService.Get<IToast>().Show(_objDriver_LoadTypeResponse.Response.Message);
                //    await Navigation.PopAllPopupAsync();
                //}
                //else
                //{
                //    DependencyService.Get<IToast>().Show(_objDriver_LoadTypeResponse.Response.Description);
                //    await Navigation.PopAllPopupAsync();
                //}

            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }

        }
        private void ImageEntry_Focused(object sender, FocusEventArgs e)
        {
            //_Picker = new TimePicker();
            Device.BeginInvokeOnMainThread(() =>
            {
                entryStartDepot.IsEnabled = false;
                StartDepot.Focus();
                //_Picker.Focus();  
            });
        }

        private void OnUnfocused(object sender, FocusEventArgs e)
        {
            entryStartDepot.IsEnabled = true;
            entryStartDepot.Unfocus();
            entryStartDepot.Text = StartDepot.Time.ToString();
        }

        private void EntryDepartDeport_Focused(object sender, FocusEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                EntryDepartDeport.IsEnabled = false;
                depart_depot.Focus();
                //_Picker.Focus();  
            });
        }

        private void depart_depot_Unfocused(object sender, FocusEventArgs e)
        {
            EntryDepartDeport.IsEnabled = true;
            EntryDepartDeport.Unfocus();
            EntryDepartDeport.Text = depart_depot.Time.ToString();
        }

        private void Entryarrive_job_Focused(object sender, FocusEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Entryarrive_job.IsEnabled = false;
                arrive_job.Focus();
                //_Picker.Focus();  
            });
        }

        private void arrive_job_Unfocused(object sender, FocusEventArgs e)
        {
            Entryarrive_job.IsEnabled = true;
            Entryarrive_job.Unfocus();
            Entryarrive_job.Text = arrive_job.Time.ToString();
        }

        private void depart_job_Unfocused(object sender, FocusEventArgs e)
        {
            Entrydepart_job.IsEnabled = true;
            Entrydepart_job.Unfocus();
            Entrydepart_job.Text = depart_job.Time.ToString();
        }

        private void Entrydepart_job_Focused(object sender, FocusEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Entrydepart_job.IsEnabled = false;
                depart_job.Focus();

            });
        }

        private void Entrykilometer_finish_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_objDriver_EditLoadResponse.Response.LoadDetails.Start) && !string.IsNullOrEmpty(_objDriver_EditLoadResponse.Response.LoadDetails.Finish))
                {
                    if (Convert.ToInt32(_objDriver_EditLoadResponse.Response.LoadDetails.Finish) > Convert.ToInt32(_objDriver_EditLoadResponse.Response.LoadDetails.Start))
                    {
                        kmstxtbx.Text = ((Convert.ToInt32(_objDriver_EditLoadResponse.Response.LoadDetails.Finish)) - (Convert.ToInt32(_objDriver_EditLoadResponse.Response.LoadDetails.Start))).ToString();
                        _objDriver_EditLoadResponse.Response.LoadDetails.NetWeight = Convert.ToDouble(kmstxtbx.Text);
                    }
                    else
                    {
                        DisplayAlert("Alert", "kilometer finish can not be less than kilometer start!", "ok");
                    }
                }
                else
                {
                    DisplayAlert("Alert", "Kilometer start or kilometer finish can not be null or Empty!", "ok");
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }



        private async void XFBtnTapCamera_Tapped(object sender, EventArgs e)
        {
            try
            {
                var result = await DisplayAlert("Alert", "Do you want to go without Uploading the document?", "Yes", "No");

                if (result)
                {
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("No Camera", ":( No camera available.", "OK");
                        return;
                    }

                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        Directory = "Test",
                        SaveToAlbum = true,
                        CompressionQuality = 75,
                        CustomPhotoSize = 50,
                        PhotoSize = PhotoSize.MaxWidthHeight,
                        MaxWidthHeight = 2000,
                        DefaultCamera = CameraDevice.Front
                    });

                    if (file == null)
                        return;

                    await DisplayAlert("File Location", file.Path, "OK");

                    var imageString = Base64Extensions.ConvertToBase64(file.GetStream());
                    xfGridShowDocket.IsVisible = true;
                    xfWbDocketImage.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });

                    _objDriver_EditLoadResponse.Response.LoadDetails.BridgeDocket = imageString;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void XFBtnTapTolls_Tapped(object sender, EventArgs e)
        {

            // await Navigation.PushPopupAsync(new AddTollsPage(_objDriver_TollsListResponse));
            if (!IsClickedTall)
            {
                XFFrameTollsView.IsVisible = true;
                IsClickedTall = true;
                if (_objDriver_TollsListResponse.Response.AccountSettingTollList.Count > 0)
                {
                    ListViewTolls.ItemsSource = _objDriver_TollsListResponse.Response.AccountSettingTollList;
                }
                else
                {
                    DisplayAlert("Alert!", "No Tolls data Exist!", "ok");
                }
            }
            else
            {
                XFFrameTollsView.IsVisible = false;
                IsClickedTall = false;
            }


        }

        private void XFSwitchTolls_Toggled(object sender, ToggledEventArgs e)
        {
            var picker = (Switch)sender;
            var xy = picker.BindingContext;
            var data = xy as AccountSettingTollList;


            var existingToll = (from result in EditTolls
                                where result == data.AccountId
                                select result).FirstOrDefault();
            if (existingToll > 0)
            {
                // int i = _objDriver_TollsListResponse.Response.AccountSettingTollList.IndexOf(existingToll);
                EditTolls.Remove(data.AccountId);
            }
            else
            {
                EditTolls.Add(data.AccountId);
            }

        }

        //private void kilometer_start_Unfocused(object sender, FocusEventArgs e)
        //{
        //    Entrykilometer_start.IsEnabled = true;
        //    Entrykilometer_start.Unfocus();
        //    Entrykilometer_start.Text = kilometer_start.Time.ToString();
        //}

        //private void Entrykilometer_start_Focused(object sender, FocusEventArgs e)
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        Entrykilometer_start.IsEnabled = false;
        //        kilometer_start.Focus();

        //    });
        //}

        //private void kilometer_finish_Unfocused(object sender, FocusEventArgs e)
        //{
        //    Entrykilometer_finish.IsEnabled = true;
        //    Entrykilometer_finish.Unfocus();
        //    Entrykilometer_finish.Text = kilometer_finish.Time.ToString();
        //}

        //private void Entrykilometer_finish_Focused(object sender, FocusEventArgs e)
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        Entrykilometer_finish.IsEnabled = false;
        //        kilometer_finish.Focus();

        //    });
        //}

        //private void LoaddatePicker_Unfocused(object sender, FocusEventArgs e)
        //{
        //    Entryselect_date.IsEnabled = true;
        //    Entryselect_date.Unfocus();
        //    Entryselect_date.Text = LoaddatePicker.Date.ToString();
        //}

        //private void Entryselect_date_Focused(object sender, FocusEventArgs e)
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        Entryselect_date.IsEnabled = false;
        //        LoaddatePicker.Focus();

        //    });
        //}

        private void BackButtonTapprd(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }
    }
}