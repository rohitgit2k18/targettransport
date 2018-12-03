using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport.Models
{
  public static class Domain
    {
        public static string Url
        {
          
            get
            {
                 return "http://180.151.232.92:99/";
               
            }
        }

        public static string LoginApiConstant
        {
            get
            {
                return "token";
            }
        }
        public static string ForgotPasswordApiConstant
        {
            get
            {
                return "api/Staff/ForgotPassword";
            }
        }
        public static string Driver_HomeApiConstant
        {
            get
            {
                return "api/MobileUser/GetEmployeeById";
            }
        }
        public static string DriverWorkSheetListApiConstant
        {
            get
            {
                return "api/MobileUser/GetWorksheetByEmployeeId";
            }
        }
        public static string DriverDailyCheckListApiConstant
        {
            get
            {
                return "api/MobileUser/GetCheckListByEmployeeId";
            }
        }

        public static string DriverSignatureApiConstant
        {
            get
            {
                return "api/MobileUser/AddSignature";
            }
        }
        public static string DriverDailyCheckListSubmitDataApiConstant
        {
            get
            {
                return "api/MobileUser/AddChecklist";
            }
        }
        public static string SelectVehicleApiConstant
        {
            get
            {
                return "api/MobileUser/GetVechicleByEmployeeId";
            }
        }
        //  api/WorkSheet/GetWorksheetNumber
        public static string GetWorksheetNumberApiConstant
        {
            get
            {
                return "api/WorkSheet/GetWorksheetNumber";
            }
        }

        public static string AddWorkSheetApiConstant
        {
            get
            {
                return "api/MobileUser/AddWorksheet";
            }
        }

        public static string WorkSheetDetailsGetApiConstant
        {
            get
            {
                return "api/MobileUser/GetWorkSheetDetails";
            }
        }
        public static string GetLoadTypesApiConstant
        {
            get
            {
                return "api/MobileUser/GetAllLoadTypes";
            }
        }
        public static string GetTollsListApiConstant
        {
            get
            {
                return "api/MobileUser/GetAccountSettingToll";
            }
        }
        public static string AddNewLoadApiConstant
        {
            get
            {
                return "api/MobileUser/AddLoad";
            }
        }
        public static string EditLoadApiConstant
        {
            get
            {
                return "api/MobileUser/LoadDataById";
            }
        }
        public static string DeleteLoadApiConstant
        {
            get
            {
                return "api/MobileUser/LoadDelete";
            }
        }
        public static string UpdateLoadApiConstant
        {
            get
            {
                return "api/MobileUser/LoadUpdate";
            }
        }
        public static string LoadOffC_SignatureApiConstant
        {
            get
            {
                return "api/MobileUser/AddLoadCustomerSignature";
            }
        }
        public static string WorkSheetSignOffSigApiConstant
        {
            get
            {
                return "api/MobileUser/AddWorkSheetCustomerSignature";
            }
        }
        public static string Driver_MaintananceListApiConstant
        {
            get
            {
                return "api/MobileUser/GetMaintenanceRequest";
            }
        }
        public static string Driver_AddMaintananceApiConstant
        {
            get
            {
                return "api/MobileUser/AddMaintenanceRequest";
            }
        }
        public static string Driver_TimeSheetApiConstant
        {
            get
            {
                return "api/MobileUser/GetWorksTimeList";
            }
        }
        public static string Driver_ChangePasswordApiConstant
        {
            get
            {
                return "api/Staff/ResetPassword";
            }
        }
        public static string Driver_EndOfShiftApiConstant
        {
            get
            {
                return "api/MobileUser/AddEndOfDay";
            }
        }
        public static string ChangePasswordApiConstant
        {
            get
            {
                return "api/MobileUser/ChangePassword";
            }
        }
        public static string GetCompanySitesApiConstant
        {
            get
            {
                return "api/MobileUser/GetCompanySites";
            }
        }
        public static string GetClientsApiConstant
        {
            get
            {
                return "api/MobileUser/GetClients";
            }
        }



        //-----------------------------Non Driver-------------------------------
        public static string NonDriver_HomeApiConstant
        {
            get
            {
                return "api/MobileUser/GetEmployeeById";
            }
        }

        public static string NDDailyCheckListGet_ApiConstant
        {
            get
            {
                return "api/MobileUser/GetCheckListByEmployeeId";
            }
        }
       
        public static string NDDailyCheckListPost_ApiConstant
        {
            get
            {
                return "api/MobileUser/AddChecklist";
            }
        }
        public static string ND_SignatureApiConstant
        {
            get
            {
                return "api/MobileUser/AddSignature";
            }
        }
        public static string ND_TimeSheetApiConstant
        {
            get
            {
                return "api/MobileUser/GetWorksTimeList";
            }
        }

        //----------------------------Mechanic Section-------------------------------
        /// <summary>
        /// 
        /// </summary>
        public static string M_HomeDataApiConstant
        {
            get
            {
                return "api/MobileUser/GetEmployeeById";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string M_ViewDetailsApiConstant
        {
            get
            {
                return "api/MobileUser/GetMaintenanceRequetById";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string M_CheckboxListApiConstant
        {
            get
            {
                return "api/MobileUser/GetCheckListByEmployeeId";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string M_SendRequestDoneApiConstant
        {
            get
            {
                return "api/MobileUser/MaintenanceRequetDone";
            }
        }
        public static string M_SignatureApiConstant
        {
            get
            {
                return "api/MobileUser/AddMechanicSignature";
            }
        }
        public static string M_RequestHistoryApiConstant
        {
            get
            {
                return "api/MobileUser/GetEmployeeById";
            }
        }
        // --------------------------------------------Sub Contractor---------------------------------
        public static string SC_HomeApiConstant
        {
            get
            {
                return "api/MobileUser/GetEmployeeById";
            }
        }
    }
}
