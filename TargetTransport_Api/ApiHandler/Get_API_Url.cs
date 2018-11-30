using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.ApiHandler
{
    public class Get_API_Url
    {
        public string CommonBaseApi(string BaseUsrl)
        {
            return BaseUsrl;
        }
        /// <summary>
        /// for Login Users
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns>BaseUsrl</returns>
        public string LoginApi(string BaseUsrl)
        {
            return BaseUsrl;
        }
       
        /// <summary>
        /// for forgot Password
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string ForgotPasswordApi(string BaseUsrl)
        {
            return BaseUsrl;
        }
       
        /// <summary>
        /// for driver worksheet List
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string Driver_WorkSheetListApi(string BaseUsrl)
        {
            return BaseUsrl;        
        }

        /// <summary>
        /// for driver dailyCheckList Get Request
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string Driver_DailyCheckListApi(string BaseUsrl)
        {
            return BaseUsrl;
        }      
        /// <summary>
        /// Driver Signature
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string Driver_SignatureApi(string BaseUsrl)
        {
            return BaseUsrl;
        }

        /// <summary>
        /// for submiting the daily CheckList data
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string DriverDailyCheckListAddDataApi(string BaseUsrl)
        {
            return BaseUsrl;
        }
        /// <summary>
        /// for vehicle list
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string VehicleListApi(string BaseUsrl)
        {
            return BaseUsrl;
        }
        /// <summary>
        /// for worksheetdetails
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string WorksheetDetailsGetApi(string BaseUsrl)
        {
            return BaseUsrl;
        }
        /// <summary>
        /// for geeting the load types
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string GetLoadTypesApi(string BaseUsrl)
        {
            return BaseUsrl;
        }
        /// <summary>
        /// for getting the toll list
        /// </summary>
        /// <param name="BaseUsrl"></param>
        /// <returns></returns>
        public string GetTollsListApi(string BaseUsrl)
        {
            return BaseUsrl;
        }
        /// <summary>
        /// Load Add Api
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string AddNewLoadApi(string BaseUrl)
        {
            return BaseUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string EditLoadApi(string BaseUrl)
        {
            return BaseUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string UpdateLoadApi(string BaseUrl)
        {
            return BaseUrl;
        }
        //
        //public string UpdateUserApi(string BaseUrl,int UserId)
        //{
        //    return string.Format("{0}{1}", BaseUrl, UserId);
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string LoadOffC_SignatureApi(string BaseUrl)
        {
            return  BaseUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string WorkSheetSignOffSignApi(string BaseUrl)
        {
            return BaseUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string Driver_MaintananceListApi(string BaseUrl)
        {
            return BaseUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string Driver_AddMaintananceApi(string BaseUrl)
        {
            return BaseUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
       public string Driver_HomeApi(string BaseUrl)
       {
            return BaseUrl;
       }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string Driver_TimeSheetApi(string BaseUrl)
        {
            return BaseUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseUrl"></param>
        /// <returns></returns>
        public string Driver_ChangePasswordApi(string BaseUrl)
        {
            return BaseUrl;
        }
    }
}
