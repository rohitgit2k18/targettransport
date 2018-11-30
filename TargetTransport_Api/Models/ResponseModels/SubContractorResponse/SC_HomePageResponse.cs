using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.SubContractorResponse
{
   public class SC_HomePageResponse
    {
        public SC_DEtailsResponse Response { get; set; }
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
    public object EmergencyMobileNo { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string EmployeeName { get; set; }
    public string WorkMobile { get; set; }
    public string WorkEmail { get; set; }
    public int EmployeeType { get; set; }
    public bool IsActive { get; set; }
    public object ClientLogoURL { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int CompanyId { get; set; }
    public object UserType { get; set; }
    public object FromDate { get; set; }
    public object ToDate { get; set; }
    public int OffSet { get; set; }
    public int Limit { get; set; }
    public string Rego { get; set; }
    public object Employeeids { get; set; }
    public object OldPassword { get; set; }
    public object NewPassword { get; set; }
    public object ConfirmPassword { get; set; }
    public object PositionName { get; set; }
    public string VechicleName { get; set; }
    public object PaymethodName { get; set; }
    public object statusName { get; set; }
    public int RollId { get; set; }
    public int WorksheetId { get; set; }
    public object Search { get; set; }
    public object OrderBy { get; set; }
}

public class SubContractorHome
{

public int Id { get; set; }
public DateTime WorkSheetDate { get; set; }
public object ToDate { get; set; }
public string StartTime { get; set; }
public string ProgramStartTime { get; set; }
public int ClientId { get; set; }
public int SiteId { get; set; }
public int JobKMs { get; set; }
public int AssignTo { get; set; }
public int EmployeeId { get; set; }
public int VehicleId { get; set; }
public string Attachment { get; set; }
public int LoadTypeId { get; set; }
public string JobDescription { get; set; }
public int Createdby { get; set; }
public DateTime CreatedOn { get; set; }
public int ComapnyId { get; set; }
public bool IsActive { get; set; }
public int WorksheetStatus { get; set; }
public string WorkSheetNumber { get; set; }
public string InvoiceNumber { get; set; }
public int InvoiceStatus { get; set; }
public string EndTime { get; set; }
public object LoadData { get; set; }
public bool Approval { get; set; }
public int ShiftType { get; set; }
public object ShiftName { get; set; }
public int Limit { get; set; }
public int OffSet { get; set; }
public DateTime FromDate { get; set; }
public object Rego { get; set; }
public object DriverName { get; set; }
public DateTime FDate { get; set; }
public DateTime TDate { get; set; }
public int StaffId { get; set; }
public object ClientIds { get; set; }
public object WorksheetTollsRelations { get; set; }
public object Vechicleids { get; set; }
public int LoadId { get; set; }
public object TollList { get; set; }
public string VechicleName { get; set; }
public string ClientName { get; set; }
public string SiteName { get; set; }
public string AssignToName { get; set; }
public string InvoiceStatusName { get; set; }
public string EmployeeName { get; set; }
public string LoadTypeName { get; set; }
public object OrderBy { get; set; }
public object Search { get; set; }
public int CompanyId { get; set; }
public object CustomerSign { get; set; }
public object CustomerName { get; set; }
}

public class SC_DEtailsResponse
{

public int StatusCode { get; set; }
public EmployeeObject EmployeeObject { get; set; }
public object NonDriverHome { get; set; }
public object MechineHome { get; set; }
public List<SubContractorHome> SubContractorHome { get; set; }
}


}
