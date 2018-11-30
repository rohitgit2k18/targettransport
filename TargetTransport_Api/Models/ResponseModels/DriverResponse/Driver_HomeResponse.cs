using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
   public class Driver_HomeResponse
    {
        public Driver_HomeRes Response { get; set; }
    }
    public class EmployeeObject
    {
       
    public int Id { get; set; }
    public int PositionId { get; set; }
    public string MobileNo { get; set; }
    public int DefaultVehicleId { get; set; }
    public string DriverLicense { get; set; }
    public DateTime LicenseExpiry { get; set; }
    public DateTime DateStarted { get; set; }
    public string Email { get; set; }
    public int StatusId { get; set; }
    public bool IsPayedForbreak { get; set; }
    public int PayMethodId { get; set; }
    public string EmergencyContactName { get; set; }
    public string EmergencyMobileNo { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string EmployeeName { get; set; }
    public string WorkMobile { get; set; }
    public string WorkEmail { get; set; }
    public int EmployeeType { get; set; }
    public bool IsActive { get; set; }
    public string ClientLogoURL { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int CompanyId { get; set; }
    public object UserType { get; set; }
    public object FromDate { get; set; }
    public object ToDate { get; set; }
    public int OffSet { get; set; }
    public int Limit { get; set; }
    public object Rego { get; set; }
    public object Employeeids { get; set; }
    public object OldPassword { get; set; }
    public object NewPassword { get; set; }
    public object ConfirmPassword { get; set; }
    public object PositionName { get; set; }
    public object VechicleName { get; set; }
    public object PaymethodName { get; set; }
    public object statusName { get; set; }
    public int RollId { get; set; }
    public int WorksheetId { get; set; }
    public object Search { get; set; }
    public object OrderBy { get; set; }
}

public class Driver_HomeRes
{
   
public int StatusCode { get; set; }
public EmployeeObject EmployeeObject { get; set; }
public object NonDriverHome { get; set; }
public object MechineHome { get; set; }
public object SubContractorHome { get; set; }
public string Message { get; set; }
public string Description { get; set; }
    }

}
