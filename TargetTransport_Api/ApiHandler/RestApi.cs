
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TargetTransport_Api.Models;
using TargetTransport_Api.Models.RequestModels;
using TargetTransport_Api.Models.RequestModels.DriverRequest;
using TargetTransport_Api.Models.RequestModels.MechanicRequest;
using TargetTransport_Api.Models.RequestModels.NonDriverRequest;
using TargetTransport_Api.Models.RequestModels.SubContractorRequest;
using TargetTransport_Api.Models.ResponseModels;
using TargetTransport_Api.Models.ResponseModels.DriverResponse;
using TargetTransport_Api.Models.ResponseModels.MechanicResponse;
using TargetTransport_Api.Models.ResponseModels.NonDriverResponse;
using TargetTransport_Api.Models.ResponseModels.SubContractorResponse;

namespace TargetTransport_Api.ApiHandler
{
    public class RestApi
    {
        public WebRequest webRequest = null;
        private HttpClient client;      
        private string _col = ":";

        public RestApi()

        {
            client = new HttpClient();
        }
        //*****************Get Generic Api's**************************
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="Tobject"></param>
        /// <returns></returns>
        public async Task<T> GetAsyncData_GetApi<T>(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, T Tobject) where T : new()
        {
            // var _storedToken=Settings;
            try
            {
                client.MaxResponseContentBufferSize = 256000;
                if (IsHeaderRequired)
                {

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                    //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                    //client.DefaultRequestHeaders.Add("Authorization", "application/json");
                    //client.DefaultRequestHeaders.Add("Content-Length", "84");
                    //client.DefaultRequestHeaders.Add("User-Agent", "Fiddler");
                    //client.DefaultRequestHeaders.Add("Host", "localhost:49165");
                    // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                // var request = new HttpRequestMessage(HttpMethod.Get, uri);

                // request.Content = new FormUrlEncodedContent(keyValues);

                //  HttpResponseMessage response = await client.SendAsync(request);

                HttpResponseMessage response = await client.GetAsync(uri);


                if (response.IsSuccessStatusCode)
                {

                    var responseContent = response.Content;
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    //  SucessResponse = SucessResponse.Insert(1, "\"Status\"" + _col + "\"Success\",");
                    Tobject = JsonConvert.DeserializeObject<T>(SucessResponse);
                    return Tobject;

                }
                else
                {

                    //long ResonseStatus = Convert.ToInt64(response.StatusCode);
                    //switch (ResonseStatus)
                    //{
                    //    case 302:
                    //        _response = "{\"Status\"" + _col + "\"Invalid User Name and password..\"}";
                    //        break;
                    //    case 400:
                    //        _response = "{\"Status\"" + _col + "\"Bad Request\"}";
                    //        break;
                    //    case 401:
                    //        _response = "{\"Status\"" + _col + "\"Invalid User Name and password..\"}";
                    //        break;
                    //    case 404:
                    //        _response = "{\"Status\"" + _col + "\"Not Found\"}";
                    //        break;

                    //    default:
                    //        _response = "{\"Status\"" + _col + "\"Internal Server errror\"}";
                    //        break;

                    var responseContent = response.Content;
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    ErrorResponse = ErrorResponse.Insert(1, "\"Status\"" + _col + "\"fail\",");
                    Tobject = JsonConvert.DeserializeObject<T>(ErrorResponse);
                    return Tobject;

                    // }
                }

                //Tobject = JsonConvert.DeserializeObject<T>(_response);
                //return Tobject;
            }
            catch (Exception ex)
            {

                throw;
               
            }
        }       
      /// <summary>
      /// 
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="uri"></param>
      /// <param name="IsHeaderRequired"></param>
      /// <param name="objHeaderModel"></param>
      /// <param name="Tobject"></param>
      /// <returns></returns>
       public async Task<ObservableCollection<T>> GetAsyncData_GetApiList<T>(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, ObservableCollection<T> Tobject) where T : new()
        {
            // var _storedToken=Settings;
            try
            {
                HttpResponseMessage response = null;
                //  client.MaxResponseContentBufferSize = 256000;
                if (IsHeaderRequired)
                {

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);

                }


                response = await client.GetAsync(uri);


                if (response.IsSuccessStatusCode)
                {

                    var responseContent = response.Content;
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    //  SucessResponse = SucessResponse.Insert(1, "\"Status\"" + _col + "\"Success\",");
                    Tobject = JsonConvert.DeserializeObject<ObservableCollection<T>>(SucessResponse);
                    return Tobject;

                }
                else
                {





                    var responseContent = response.Content;
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    //  ErrorResponse = ErrorResponse.Insert(1, "\"Status\"" + _col + "\"fail\",");
                    Tobject = JsonConvert.DeserializeObject<ObservableCollection<T>>(ErrorResponse);
                    return Tobject;


                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //*********************************POST APIS**************************

        /// <summary>
        /// Login Api
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objLoginRequest"></param>
        /// <returns></returns>
        public async Task<LoginResponse> LoginAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, LoginRequest _objLoginRequest)
        {

            client.MaxResponseContentBufferSize = 256000;
            LoginResponse _objLoginResponse = new LoginResponse();
           
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("userName",_objLoginRequest.userName),
                new KeyValuePair<string, string>("password",_objLoginRequest.password+",1"),
                new KeyValuePair<string, string>("grant_type",_objLoginRequest.grant_type)
            };
            if (IsHeaderRequired)
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Length", "69");
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Fiddler");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Host", "localhost:49165");
            }
            var request = new HttpRequestMessage(HttpMethod.Post, uri);

            request.Content = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.SendAsync(request);
            var statuscode = Convert.ToInt64(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
              ResponseStatus.StatusCode= Convert.ToInt32(response.StatusCode);
                var SucessResponse = await response.Content.ReadAsStringAsync();
                _objLoginResponse = JsonConvert.DeserializeObject<LoginResponse>(SucessResponse);               
                return _objLoginResponse;
            }
            else
            {
                ResponseStatus.StatusCode = Convert.ToInt32(response.StatusCode);
                var ErrorResponse = await response.Content.ReadAsStringAsync();
                _objLoginResponse = JsonConvert.DeserializeObject<LoginResponse>(ErrorResponse);
                return _objLoginResponse;
            }

        }
       
        /// <summary>
        /// Forgot Password Api
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objForgotPasswordRequest"></param>
        /// <returns></returns>
        public async Task<ForgotPasswordResponse> ForgotPasswordAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, ForgotPasswordRequest _objForgotPasswordRequest)
        {

            // client.MaxResponseContentBufferSize = 256000;
            ForgotPasswordResponse _objForgotPasswordResponse = new ForgotPasswordResponse();

            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Email",_objForgotPasswordRequest.EmailId)              
            };
            if (IsHeaderRequired)
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Length", "69");
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Fiddler");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Host", "localhost:49165");
            }
            var request = new HttpRequestMessage(HttpMethod.Post, uri);

            request.Content = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var SucessResponse = await response.Content.ReadAsStringAsync();
                _objForgotPasswordResponse = JsonConvert.DeserializeObject<ForgotPasswordResponse>(SucessResponse);
                return _objForgotPasswordResponse;
            }
            else
            {


                var ErrorResponse = await response.Content.ReadAsStringAsync();
                //  ErrorResponse = ErrorResponse.Insert(1, "\"Status\"" + _col + "\"Fail\",");
                _objForgotPasswordResponse = JsonConvert.DeserializeObject<ForgotPasswordResponse>(ErrorResponse);
                return _objForgotPasswordResponse;
            }

        }
       
        /// <summary>
        /// Worksheet List Api
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDriverWorkSheetListRequest"></param>
        /// <returns></returns>
        public async Task<DriverWorkSheetListResponse> LoadDriverWorkSheetListAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, DriverWorkSheetListRequest _objDriverWorkSheetListRequest)
        {

            DriverWorkSheetListResponse objDriverWorkSheetListResponse;
            string s = JsonConvert.SerializeObject(_objDriverWorkSheetListRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);

                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriverWorkSheetListResponse = JsonConvert.DeserializeObject<DriverWorkSheetListResponse>(SucessResponse);
                    return objDriverWorkSheetListResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriverWorkSheetListResponse = JsonConvert.DeserializeObject<DriverWorkSheetListResponse>(ErrorResponse);
                    return objDriverWorkSheetListResponse;
                }
            }
        }
       
        /// <summary>
        /// Driver Daily ChecklIst Api
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDriver_DailyCheckListGetRequest"></param>
        /// <returns></returns>
        public async Task<Driver_DailyCheckListGetResponse> DriverDailyCheckListGetAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_DailyCheckListGetRequest _objDriver_DailyCheckListGetRequest)
        {

            Driver_DailyCheckListGetResponse objDriver_DailyCheckListGetResponse;
            string s = JsonConvert.SerializeObject(_objDriver_DailyCheckListGetRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);

                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_DailyCheckListGetResponse = JsonConvert.DeserializeObject<Driver_DailyCheckListGetResponse>(SucessResponse);
                    return objDriver_DailyCheckListGetResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_DailyCheckListGetResponse = JsonConvert.DeserializeObject<Driver_DailyCheckListGetResponse>(ErrorResponse);
                    return objDriver_DailyCheckListGetResponse;
                }
            }
        }
      
        /// <summary>
        /// Driver Signature Api
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="objDriver_SignatureRequest"></param>
        /// <returns>Driver_SignatureResponse object</returns>
        public async Task<Driver_SignatureResponse> DriverSignatureAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_SignatureRequest objDriver_SignatureRequest)
        {

            Driver_SignatureResponse objDriver_SignatureResponse;
            string s = JsonConvert.SerializeObject(objDriver_SignatureRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_SignatureResponse = JsonConvert.DeserializeObject<Driver_SignatureResponse>(SucessResponse);
                    return objDriver_SignatureResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_SignatureResponse = JsonConvert.DeserializeObject<Driver_SignatureResponse>(ErrorResponse);
                    return objDriver_SignatureResponse;
                }
            }
        }
       
        /// <summary>
        /// for submiting the driver daily cheklist api's
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDriver_DailyCheckListPostRequest"></param>
        /// <returns></returns>
        public async Task<Driver_DailyCheckListPostResponse> DriverDailyCheckListPostAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_DailyCheckLestPostRequest _objDriver_DailyCheckListPostRequest)
        {

            Driver_DailyCheckListPostResponse objDriver_DailyCheckListPostResponse;
            string s = JsonConvert.SerializeObject(_objDriver_DailyCheckListPostRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_DailyCheckListPostResponse = JsonConvert.DeserializeObject<Driver_DailyCheckListPostResponse>(SucessResponse);
                    return objDriver_DailyCheckListPostResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_DailyCheckListPostResponse = JsonConvert.DeserializeObject<Driver_DailyCheckListPostResponse>(ErrorResponse);
                    return objDriver_DailyCheckListPostResponse;
                }
            }
        }

        /// <summary>
            /// for geting the vehicle list 
            /// </summary>
            /// <param name="uri"></param>
            /// <param name="IsHeaderRequired"></param>
            /// <param name="objHeaderModel"></param>
            /// <param name="_objDriver_SelectVehicleRequest"></param>
            /// <returns></returns>
        public async Task<DriverSelectVehicleResonse> GetDriverSelectVehicleListAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_SelectVehicleRequest _objDriver_SelectVehicleRequest)
        {

            DriverSelectVehicleResonse objDriverSelectVehicleResonse;
            string s = JsonConvert.SerializeObject(_objDriver_SelectVehicleRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriverSelectVehicleResonse = JsonConvert.DeserializeObject<DriverSelectVehicleResonse>(SucessResponse);
                    return objDriverSelectVehicleResonse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriverSelectVehicleResonse = JsonConvert.DeserializeObject<DriverSelectVehicleResonse>(ErrorResponse);
                    return objDriverSelectVehicleResonse;
                }
            }
        }
      
        /// <summary>
        /// for getting the complete worksheet details info
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDriver_WorkSheetDetailsGetRequest"></param>
        /// <returns></returns>
        public async Task<Driver_WorkSheetDetailsGetResponse> GetDriverWorkSheetDetailsAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_WorkSheetDetailsGetRequest _objDriver_WorkSheetDetailsGetRequest)
        {

            Driver_WorkSheetDetailsGetResponse objDriver_WorkSheetDetailsGetResponse;
            string s = JsonConvert.SerializeObject(_objDriver_WorkSheetDetailsGetRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_WorkSheetDetailsGetResponse = JsonConvert.DeserializeObject<Driver_WorkSheetDetailsGetResponse>(SucessResponse);
                    return objDriver_WorkSheetDetailsGetResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_WorkSheetDetailsGetResponse = JsonConvert.DeserializeObject<Driver_WorkSheetDetailsGetResponse>(ErrorResponse);
                    return objDriver_WorkSheetDetailsGetResponse;
                }
            }
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDriver_LoadTypesRequest"></param>
        /// <returns></returns>
        public async Task<Driver_LoadTypeResponse> GetLoadTypesAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_LoadTypesRequest _objDriver_LoadTypesRequest)
        {

            Driver_LoadTypeResponse objDriver_LoadTypeResponse;
            string s = JsonConvert.SerializeObject(_objDriver_LoadTypesRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_LoadTypeResponse = JsonConvert.DeserializeObject<Driver_LoadTypeResponse>(SucessResponse);
                    return objDriver_LoadTypeResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_LoadTypeResponse = JsonConvert.DeserializeObject<Driver_LoadTypeResponse>(ErrorResponse);
                    return objDriver_LoadTypeResponse;
                }
            }
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDriver_TollsListRequest"></param>
        /// <returns></returns>
        public async Task<Driver_TollsListResponse> GetTollListAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_TollsListRequest _objDriver_TollsListRequest)
        {

            Driver_TollsListResponse objDriver_TollsListResponse;
            string s = JsonConvert.SerializeObject(_objDriver_TollsListRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_TollsListResponse = JsonConvert.DeserializeObject<Driver_TollsListResponse>(SucessResponse);
                    return objDriver_TollsListResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_TollsListResponse = JsonConvert.DeserializeObject<Driver_TollsListResponse>(ErrorResponse);
                    return objDriver_TollsListResponse;
                }
            }
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDriver_AddLoadRequest"></param>
        /// <returns></returns>
        public async Task<Driver_AddLoadResponse> AddLoadAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_AddLoadRequest _objDriver_AddLoadRequest)
        {

            Driver_AddLoadResponse objDriver_AddLoadResponse;
            string s = JsonConvert.SerializeObject(_objDriver_AddLoadRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_AddLoadResponse = JsonConvert.DeserializeObject<Driver_AddLoadResponse>(SucessResponse);
                    return objDriver_AddLoadResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_AddLoadResponse = JsonConvert.DeserializeObject<Driver_AddLoadResponse>(ErrorResponse);
                    return objDriver_AddLoadResponse;
                }
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDriver_EditLoadRequest"></param>
        /// <returns></returns>
        public async Task<Driver_EditLoadResponse> EditLoadAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_EditLoadRequest _objDriver_EditLoadRequest)
        {

            Driver_EditLoadResponse objDriver_EditLoadResponse;
            string s = JsonConvert.SerializeObject(_objDriver_EditLoadRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_EditLoadResponse = JsonConvert.DeserializeObject<Driver_EditLoadResponse>(SucessResponse);
                    return objDriver_EditLoadResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_EditLoadResponse = JsonConvert.DeserializeObject<Driver_EditLoadResponse>(ErrorResponse);
                    return objDriver_EditLoadResponse;
                }
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objLoadDetails"></param>
        /// <returns></returns>
        public async Task<Driver_UpdateLoadResponse> UpdateLoadAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, LoadDetails _objLoadDetails)
        {

            Driver_UpdateLoadResponse objDriver_UpdateLoadResponse;
            string s = JsonConvert.SerializeObject(_objLoadDetails);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_UpdateLoadResponse = JsonConvert.DeserializeObject<Driver_UpdateLoadResponse>(SucessResponse);
                    return objDriver_UpdateLoadResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_UpdateLoadResponse = JsonConvert.DeserializeObject<Driver_UpdateLoadResponse>(ErrorResponse);
                    return objDriver_UpdateLoadResponse;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDeleteLoadRequest"></param>
        /// <returns></returns>
        public async Task<DeleteLoadResponse> DeleteLoadAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, DeleteLoadRequest _objDeleteLoadRequest)
        {

            DeleteLoadResponse objDeleteLoadResponse;
            string s = JsonConvert.SerializeObject(_objDeleteLoadRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDeleteLoadResponse = JsonConvert.DeserializeObject<DeleteLoadResponse>(SucessResponse);
                    return objDeleteLoadResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDeleteLoadResponse = JsonConvert.DeserializeObject<DeleteLoadResponse>(ErrorResponse);
                    return objDeleteLoadResponse;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDriver_LoadSignOffResquest"></param>
        /// <returns></returns>
        public async Task<Driver_LoadSignOffResponse> LoadSignOffSignAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_LoadSignOffResquest _objDriver_LoadSignOffResquest)
        {

            Driver_LoadSignOffResponse objDriver_LoadSignOffResponse;
            string s = JsonConvert.SerializeObject(_objDriver_LoadSignOffResquest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_LoadSignOffResponse = JsonConvert.DeserializeObject<Driver_LoadSignOffResponse>(SucessResponse);
                    return objDriver_LoadSignOffResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_LoadSignOffResponse = JsonConvert.DeserializeObject<Driver_LoadSignOffResponse>(ErrorResponse);
                    return objDriver_LoadSignOffResponse;
                }
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDriver_WorkSheetSignOffRequest"></param>
        /// <returns></returns>
        public async Task<Driver_WorkSheetSignOffResponse> WorkSheetSignOffSignAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_WorkSheetSignOffRequest _objDriver_WorkSheetSignOffRequest)
        {

            Driver_WorkSheetSignOffResponse objDriver_WorkSheetSignOffResponse;
            string s = JsonConvert.SerializeObject(_objDriver_WorkSheetSignOffRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_WorkSheetSignOffResponse = JsonConvert.DeserializeObject<Driver_WorkSheetSignOffResponse>(SucessResponse);
                    return objDriver_WorkSheetSignOffResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_WorkSheetSignOffResponse = JsonConvert.DeserializeObject<Driver_WorkSheetSignOffResponse>(ErrorResponse);
                    return objDriver_WorkSheetSignOffResponse;
                }
            }
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDriver_MaintananceListRequest"></param>
        /// <returns></returns>
        public async Task<Driver_MaintananceListResponse> MaintananceLoadAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_MaintananceListRequest _objDriver_MaintananceListRequest)
        {

            Driver_MaintananceListResponse objDriver_MaintananceListResponse;
            string s = JsonConvert.SerializeObject(_objDriver_MaintananceListRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_MaintananceListResponse = JsonConvert.DeserializeObject<Driver_MaintananceListResponse>(SucessResponse);
                    return objDriver_MaintananceListResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_MaintananceListResponse = JsonConvert.DeserializeObject<Driver_MaintananceListResponse>(ErrorResponse);
                    return objDriver_MaintananceListResponse;
                }
            }
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDriver_AddMaintananceRequest"></param>
        /// <returns></returns>
        public async Task<Driver_AddMaintananceResponse> AddMaintananceAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_AddMaintananceRequest _objDriver_AddMaintananceRequest)
        {

            Driver_AddMaintananceResponse objDriver_AddMaintananceResponse;
            string s = JsonConvert.SerializeObject(_objDriver_AddMaintananceRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_AddMaintananceResponse = JsonConvert.DeserializeObject<Driver_AddMaintananceResponse>(SucessResponse);
                    return objDriver_AddMaintananceResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_AddMaintananceResponse = JsonConvert.DeserializeObject<Driver_AddMaintananceResponse>(ErrorResponse);
                    return objDriver_AddMaintananceResponse;
                }
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDriver_HomeRequest"></param>
        /// <returns></returns>
        public async Task<Driver_HomeResponse> Driver_HomeAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_HomeRequest _objDriver_HomeRequest)
        {

            Driver_HomeResponse objDriver_HomeResponse;
            string s = JsonConvert.SerializeObject(_objDriver_HomeRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_HomeResponse = JsonConvert.DeserializeObject<Driver_HomeResponse>(SucessResponse);
                    return objDriver_HomeResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_HomeResponse = JsonConvert.DeserializeObject<Driver_HomeResponse>(ErrorResponse);
                    return objDriver_HomeResponse;
                }
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objDriver_TimeSheetRequest"></param>
        /// <returns></returns>
        public async Task<Driver_TimeSheetResponse> Driver_TimeSheetAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_TimeSheetRequest _objDriver_TimeSheetRequest)
        {

            Driver_TimeSheetResponse objDriver_TimeSheetResponse;
            string s = JsonConvert.SerializeObject(_objDriver_TimeSheetRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_TimeSheetResponse = JsonConvert.DeserializeObject<Driver_TimeSheetResponse>(SucessResponse);
                    return objDriver_TimeSheetResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_TimeSheetResponse = JsonConvert.DeserializeObject<Driver_TimeSheetResponse>(ErrorResponse);
                    return objDriver_TimeSheetResponse;
                }
            }
        }
        /// <summary>
/// 
/// </summary>
/// <param name="uri"></param>
/// <param name="IsHeaderRequired"></param>
/// <param name="objHeaderModel"></param>
/// <param name="_objDriver_EndOfShiftRequest"></param>
/// <returns></returns>
        public async Task<Driver_EndOfShiftResponse> Driver_EndOfShiftAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_EndOfShiftRequest _objDriver_EndOfShiftRequest)
        {

            Driver_EndOfShiftResponse objDriver_EndOfShiftResponse;
            string s = JsonConvert.SerializeObject(_objDriver_EndOfShiftRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_EndOfShiftResponse = JsonConvert.DeserializeObject<Driver_EndOfShiftResponse>(SucessResponse);
                    return objDriver_EndOfShiftResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_EndOfShiftResponse = JsonConvert.DeserializeObject<Driver_EndOfShiftResponse>(ErrorResponse);
                    return objDriver_EndOfShiftResponse;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objChnagePasswordRequest"></param>
        /// <returns></returns>
        public async Task<ChangePaswwordResponse> ChangeOfPasswordAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, ChnagePasswordRequest _objChnagePasswordRequest)
        {

            ChangePaswwordResponse objChangePaswwordResponse;
            string s = JsonConvert.SerializeObject(_objChnagePasswordRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objChangePaswwordResponse = JsonConvert.DeserializeObject<ChangePaswwordResponse>(SucessResponse);
                    return objChangePaswwordResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objChangePaswwordResponse = JsonConvert.DeserializeObject<ChangePaswwordResponse>(ErrorResponse);
                    return objChangePaswwordResponse;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objChnagePasswordRequest"></param>
        /// <returns></returns>
        public async Task<LoadCompanySiteResponse> GetCompanySitesAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, LoadCompanySiteRequest _objLoadCompanySiteRequest)
        {

            LoadCompanySiteResponse objLoadCompanySiteResponse;
            string s = JsonConvert.SerializeObject(_objLoadCompanySiteRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objLoadCompanySiteResponse = JsonConvert.DeserializeObject<LoadCompanySiteResponse>(SucessResponse);
                    return objLoadCompanySiteResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objLoadCompanySiteResponse = JsonConvert.DeserializeObject<LoadCompanySiteResponse>(ErrorResponse);
                    return objLoadCompanySiteResponse;
                }
            }
        }
        public async Task<Driver_GetClientsResponse> GetClientsAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, Driver_GetClientsRequest _objDriver_GetClientsRequest)
        {

            Driver_GetClientsResponse objDriver_GetClientsResponse;
            string s = JsonConvert.SerializeObject(_objDriver_GetClientsRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objDriver_GetClientsResponse = JsonConvert.DeserializeObject<Driver_GetClientsResponse>(SucessResponse);
                    return objDriver_GetClientsResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objDriver_GetClientsResponse = JsonConvert.DeserializeObject<Driver_GetClientsResponse>(ErrorResponse);
                    return objDriver_GetClientsResponse;
                }
            }
        }
        public async Task<AddWorksheetResponseModel> AddWorkSheetAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, AddWorkSheetRequestModel _objAddWorkSheetRequestModel)
        {

            AddWorksheetResponseModel objAddWorksheetResponseModel;
            string s = JsonConvert.SerializeObject(_objAddWorkSheetRequestModel);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objAddWorksheetResponseModel = JsonConvert.DeserializeObject<AddWorksheetResponseModel>(SucessResponse);
                    return objAddWorksheetResponseModel;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objAddWorksheetResponseModel = JsonConvert.DeserializeObject<AddWorksheetResponseModel>(ErrorResponse);
                    return objAddWorksheetResponseModel;
                }
            }
        }


        //----------------------------------------------Non Driver Section Api-------------------------------------------------

        /// <summary>
        /// Non Driver Home Data;
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objNonDriver_HomeDataRequest"></param>
        /// <returns></returns>
        public async Task<NonDriver_HomeDataResponse> NonDriver_HomeDataAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, NonDriver_HomeDataRequest _objNonDriver_HomeDataRequest)
        {

            NonDriver_HomeDataResponse objNonDriver_HomeDataResponse;
            string s = JsonConvert.SerializeObject(_objNonDriver_HomeDataRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objNonDriver_HomeDataResponse = JsonConvert.DeserializeObject<NonDriver_HomeDataResponse>(SucessResponse);
                    return objNonDriver_HomeDataResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objNonDriver_HomeDataResponse = JsonConvert.DeserializeObject<NonDriver_HomeDataResponse>(ErrorResponse);
                    return objNonDriver_HomeDataResponse;
                }
            }
        }
       
        /// <summary>
        /// Daily Checklist Data
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objNonDriver_DailyCheckListRequest"></param>
        /// <returns></returns>
        public async Task<NonDriver_DailyCheckListResponse> ND_DailyCheckLIstGetDataAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, NonDriver_DailyCheckListRequest _objNonDriver_DailyCheckListRequest)
        {

            NonDriver_DailyCheckListResponse objNonDriver_DailyCheckListResponse;
            string s = JsonConvert.SerializeObject(_objNonDriver_DailyCheckListRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objNonDriver_DailyCheckListResponse = JsonConvert.DeserializeObject<NonDriver_DailyCheckListResponse>(SucessResponse);
                    return objNonDriver_DailyCheckListResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objNonDriver_DailyCheckListResponse = JsonConvert.DeserializeObject<NonDriver_DailyCheckListResponse>(ErrorResponse);
                    return objNonDriver_DailyCheckListResponse;
                }
            }
        }
        /// <summary>
        /// Send Daily CheckList
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objNonDriver_DailyCheckListRequest"></param>
        /// <returns></returns>
        public async Task<ND_DailyCheckLIstPostResponse> ND_DailyCheckLIstPostDataAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, ND_DailyCheckLIstPostRequest _objND_DailyCheckLIstPostRequest)
        {

            ND_DailyCheckLIstPostResponse objND_DailyCheckLIstPostResponse;
            string s = JsonConvert.SerializeObject(_objND_DailyCheckLIstPostRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objND_DailyCheckLIstPostResponse = JsonConvert.DeserializeObject<ND_DailyCheckLIstPostResponse>(SucessResponse);
                    return objND_DailyCheckLIstPostResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objND_DailyCheckLIstPostResponse = JsonConvert.DeserializeObject<ND_DailyCheckLIstPostResponse>(ErrorResponse);
                    return objND_DailyCheckLIstPostResponse;
                }
            }
        }
       
        /// <summary>
        /// ND Signature
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objND_DailyCheckLIstPostRequest"></param>
        /// <returns></returns>
        public async Task<ND_SignatureResponse> ND_SignatureDataAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, ND_SignatureRequest _objND_SignatureRequest)
        {

            ND_SignatureResponse objND_SignatureResponse;
            string s = JsonConvert.SerializeObject(_objND_SignatureRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objND_SignatureResponse = JsonConvert.DeserializeObject<ND_SignatureResponse>(SucessResponse);
                    return objND_SignatureResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objND_SignatureResponse = JsonConvert.DeserializeObject<ND_SignatureResponse>(ErrorResponse);
                    return objND_SignatureResponse;
                }
            }
        }
       
        /// <summary>
        /// ND Timesheet data
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objND_SignatureRequest"></param>
        /// <returns></returns>
        public async Task<ND_TimeSheetResponse> ND_TimeSheetDataAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, ND_TimeSheetRequest _objND_TimeSheetRequest)
        {

            ND_TimeSheetResponse objND_TimeSheetResponse;
            string s = JsonConvert.SerializeObject(_objND_TimeSheetRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objND_TimeSheetResponse = JsonConvert.DeserializeObject<ND_TimeSheetResponse>(SucessResponse);
                    return objND_TimeSheetResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objND_TimeSheetResponse = JsonConvert.DeserializeObject<ND_TimeSheetResponse>(ErrorResponse);
                    return objND_TimeSheetResponse;
                }
            }
        }


        //--------------------------------------------Mechanic Section Api-------------------------------------------------------------------------------------------------------------------
      
            /// <summary>
        /// Mechanic Home data;
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objM_HomeDataRequest"></param>
        /// <returns></returns>
        public async Task<M_HomeDataResponse> M_HomeDataAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, M_HomeDataRequest _objM_HomeDataRequest)
        {

            M_HomeDataResponse objM_HomeDataResponse;
            string s = JsonConvert.SerializeObject(_objM_HomeDataRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objM_HomeDataResponse = JsonConvert.DeserializeObject<M_HomeDataResponse>(SucessResponse);
                    return objM_HomeDataResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objM_HomeDataResponse = JsonConvert.DeserializeObject<M_HomeDataResponse>(ErrorResponse);
                    return objM_HomeDataResponse;
                }
            }
        }
       
        /// <summary>
        /// View Request Details Mechanic.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objM_GetViewDetailsRequest"></param>
        /// <returns></returns>
        public async Task<M_GetViewDetailsResponse> M_ViewDetailsDataAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, M_GetViewDetailsRequest _objM_GetViewDetailsRequest)
        {

            M_GetViewDetailsResponse objM_GetViewDetailsResponse;
            string s = JsonConvert.SerializeObject(_objM_GetViewDetailsRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objM_GetViewDetailsResponse = JsonConvert.DeserializeObject<M_GetViewDetailsResponse>(SucessResponse);
                    return objM_GetViewDetailsResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objM_GetViewDetailsResponse = JsonConvert.DeserializeObject<M_GetViewDetailsResponse>(ErrorResponse);
                    return objM_GetViewDetailsResponse;
                }
            }
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objM_CheckListRequest"></param>
        /// <returns></returns>
        public async Task<M_CheckListResponse> M_ChecklIstDataAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, M_CheckListRequest _objM_CheckListRequest)
        {
            M_CheckListResponse objM_CheckListResponse;
            string s = JsonConvert.SerializeObject(_objM_CheckListRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objM_CheckListResponse = JsonConvert.DeserializeObject<M_CheckListResponse>(SucessResponse);
                    return objM_CheckListResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objM_CheckListResponse = JsonConvert.DeserializeObject<M_CheckListResponse>(ErrorResponse);
                    return objM_CheckListResponse;
                }
            }
        }
      
        /// <summary>
       /// 
       /// </summary>
       /// <param name="uri"></param>
       /// <param name="IsHeaderRequired"></param>
       /// <param name="objHeaderModel"></param>
       /// <param name="_objM_CheckListRequest"></param>
       /// <returns></returns>
        public async Task<M_RequestDoneResponse> M_SendRequestDoneDataAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, M_RequestDoneRequest _objM_RequestDoneRequest)
        {
            M_RequestDoneResponse objM_RequestDoneResponse;
            string s = JsonConvert.SerializeObject(_objM_RequestDoneRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objM_RequestDoneResponse = JsonConvert.DeserializeObject<M_RequestDoneResponse>(SucessResponse);
                    return objM_RequestDoneResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objM_RequestDoneResponse = JsonConvert.DeserializeObject<M_RequestDoneResponse>(ErrorResponse);
                    return objM_RequestDoneResponse;
                }
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objM_SignatureRequest"></param>
        /// <returns></returns>
        public async Task<M_SignatureResponse> M_SendSignatureAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, M_SignatureRequest _objM_SignatureRequest)
        {
            M_SignatureResponse objM_SignatureResponse;
            string s = JsonConvert.SerializeObject(_objM_SignatureRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);
                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objM_SignatureResponse = JsonConvert.DeserializeObject<M_SignatureResponse>(SucessResponse);
                    return objM_SignatureResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objM_SignatureResponse = JsonConvert.DeserializeObject<M_SignatureResponse>(ErrorResponse);
                    return objM_SignatureResponse;
                }
            }
        }
        //----------------------------------------------------Sub Contractor=-----------------------------------------------------------------------
       
            /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="IsHeaderRequired"></param>
        /// <param name="objHeaderModel"></param>
        /// <param name="_objSC_HomePageRequest"></param>
        /// <returns></returns>
        public async Task<SC_HomePageResponse> LoadDSCWorkSheetListAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, SC_HomePageRequest _objSC_HomePageRequest)
        {

            SC_HomePageResponse objSC_HomePageResponse;
            string s = JsonConvert.SerializeObject(_objSC_HomePageRequest);
            HttpResponseMessage response = null;
            using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
            {

                if (IsHeaderRequired)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.TokenCode);

                }
                response = await client.PostAsync(uri, stringContent);


                if (response.IsSuccessStatusCode)
                {
                    var SucessResponse = await response.Content.ReadAsStringAsync();
                    objSC_HomePageResponse = JsonConvert.DeserializeObject<SC_HomePageResponse>(SucessResponse);
                    return objSC_HomePageResponse;
                }
                else
                {
                    var ErrorResponse = await response.Content.ReadAsStringAsync();
                    objSC_HomePageResponse = JsonConvert.DeserializeObject<SC_HomePageResponse>(ErrorResponse);
                    return objSC_HomePageResponse;
                }
            }
        }


        //public async Task<UploadProfileResponse> UpdateUserProfileAsync1(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, UploadProfileBase64Req _objUploadProfileBase64Req)
        //{
        //    UploadProfileResponse objUploadProfileResponse;
        //    string s = JsonConvert.SerializeObject(_objUploadProfileBase64Req);
        //    HttpResponseMessage response = null;
        //    using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
        //    {
        //        //  MultipartFormDataContent form = new MultipartFormDataContent();
        //        //form.Add(new StreamContent(_mediafile.GetStream()),
        //        //   "\"file\"",
        //        //   $"\"{_mediafile.Path}\"");
        //        //  form.Add(new (content, 0, content.Count()), "profile_pic", Name);

        //        if (IsHeaderRequired)
        //    {

        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", objHeaderModel.OTPToken);


        //    }
        //    response = await client.PostAsync("http://10.0.1.246:5000/api/User/UploadUserProfile", stringContent);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var SucessResponse = await response.Content.ReadAsStringAsync();
        //        objUploadProfileResponse = JsonConvert.DeserializeObject<UploadProfileResponse>(SucessResponse);
        //        return objUploadProfileResponse;
        //    }
        //    else
        //    {
        //        var ErrorResponse = await response.Content.ReadAsStringAsync();
        //        objUploadProfileResponse = JsonConvert.DeserializeObject<UploadProfileResponse>(ErrorResponse);
        //        return objUploadProfileResponse;
        //    }
        //    }
        //}
        //public async Task<UploadProfileResponse> UpdateUserProfileAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, MediaFile _mediafile)
        //{
        //    UploadProfileResponse objUploadProfileResponse;
        //  //  string s = JsonConvert.SerializeObject(_objUploadProfileBase64Req);
        //    HttpResponseMessage response = null;
        //    //using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
        //    //{
        //        MultipartFormDataContent form = new MultipartFormDataContent();
        //        form.Add(new StreamContent(_mediafile.GetStream()),
        //           "\"file\"",
        //           $"\"{_mediafile.Path}\"");
        //        //  form.Add(new (content, 0, content.Count()), "profile_pic", Name);

        //        if (IsHeaderRequired)
        //        {

        //            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", objHeaderModel.OTPToken);
        //        }
        //        response = await client.PostAsync(uri, form);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var SucessResponse = await response.Content.ReadAsStringAsync();
        //            objUploadProfileResponse = JsonConvert.DeserializeObject<UploadProfileResponse>(SucessResponse);
        //            return objUploadProfileResponse;
        //        }
        //        else
        //        {
        //            var ErrorResponse = await response.Content.ReadAsStringAsync();
        //            objUploadProfileResponse = JsonConvert.DeserializeObject<UploadProfileResponse>(ErrorResponse);
        //            return objUploadProfileResponse;
        //        }
        //   // }
        //}


        //public async Task<GetProfilePicResponseModel> GetUserprofileAsync(string uri, Boolean IsHeaderRequired, HeaderModel objHeaderModel, GetProfilePicResponseModel _objGetProfilePicResponseModel)
        //{

        //    GetProfilePicResponseModel objGetProfilePicResponseModel;
        //    string s = JsonConvert.SerializeObject(_objGetProfilePicResponseModel);
        //    HttpResponseMessage response = null;
        //    using (var stringContent = new StringContent(s, System.Text.Encoding.UTF8, "application/json"))
        //    {

        //        if (IsHeaderRequired)
        //        {
        //            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objHeaderModel.OTPToken);
        //        }
        //        response = await client.PostAsync(uri, stringContent);


        //        if (response.IsSuccessStatusCode)
        //        {
        //            var SucessResponse = await response.Content.ReadAsStringAsync();
        //            objGetProfilePicResponseModel = JsonConvert.DeserializeObject<GetProfilePicResponseModel>(SucessResponse);
        //            return objGetProfilePicResponseModel;
        //        }
        //        else
        //        {
        //            var ErrorResponse = await response.Content.ReadAsStringAsync();
        //            objGetProfilePicResponseModel = JsonConvert.DeserializeObject<GetProfilePicResponseModel>(ErrorResponse);
        //            return objGetProfilePicResponseModel;
        //        }
        //    }
        //}

        //******************Generics**************************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<string> PostAsyncData(string uri)
        {
            try
            {

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                return await response.Content.ReadAsStringAsync(); ;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public void FetchData(string url)
        {

            // Create an HTTP web request using the URL:
            webRequest = WebRequest.Create(new Uri(url));
            webRequest.ContentType = "application/json";
            webRequest.Method = "GET";
            webRequest.BeginGetRequestStream(new AsyncCallback(RequestStreamCallback), webRequest);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="asynchronousResult"></param>
        private void RequestStreamCallback(IAsyncResult asynchronousResult)
        {
            webRequest = (HttpWebRequest)asynchronousResult.AsyncState;

            using (var postStream = webRequest.EndGetRequestStream(asynchronousResult))
            {
                //send yoour data here
            }
            webRequest.BeginGetResponse(new AsyncCallback(ResponseCallback), webRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asynchronousResult"></param>
        void ResponseCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest myrequest = (HttpWebRequest)asynchronousResult.AsyncState;
            using (HttpWebResponse response = (HttpWebResponse)myrequest.EndGetResponse(asynchronousResult))
            {
                using (System.IO.Stream responseStream = response.GetResponseStream())
                {
                    using (var reader = new System.IO.StreamReader(responseStream))
                    {
                        var data = reader.ReadToEnd();
                    }
                }
            }
        }
    }
}
