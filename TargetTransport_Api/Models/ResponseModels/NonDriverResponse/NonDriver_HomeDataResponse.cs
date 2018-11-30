using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.NonDriverResponse
{
   public class NonDriver_HomeDataResponse
    {
        public ND_HomeResponse Response { get; set; }
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
    public object ClientLogoURL { get; set; }
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

public class NonDriverHome
{
        public int Id { get; set; }
        public DateTime WorkDate { get; set; }
        public string WorkDateBinding { get; set; }
        public DateTime ProgramStartTime { get; set; }
        public string ProgramStartTimeBinding { get; set; }
        public DateTime ApprovedStartTime { get; set; }
        public string ApprovedStartTimeBinding { get; set; }
        public string ActualStartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string EndTimeBinding { get; set; }
        public DateTime StartTime { get; set; }
        public string StartTimeBinding { get; set; }
        public string BreakTime { get; set; }
        public DateTime EndDate { get; set; }
        public string EndDateBinding { get; set; }
        public string Comments { get; set; }
        public string WorkHours { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int EmployeeId { get; set; }
        public object WorksheetNumber { get; set; }
        public int TotalHrs { get; set; }
}

public class ND_HomeResponse
{

public int StatusCode { get; set; }
public EmployeeObject EmployeeObject { get; set; }
public List<NonDriverHome> NonDriverHome { get; set; }
public object MechineHome { get; set; }
public object SubContractorHome { get; set; }
}

}
