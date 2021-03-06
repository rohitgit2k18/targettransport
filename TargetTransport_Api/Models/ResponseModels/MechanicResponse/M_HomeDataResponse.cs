﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.MechanicResponse
{
  public  class M_HomeDataResponse
    {
        public M_HomeResponse Response { get; set; }
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
    public string DateStartedBinding { get; set; }
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

public class MechineHome
{
 
public int Id { get; set; }
public int CompanyId { get; set; }
public DateTime RequestDate { get; set; }
public string RequestDateBinding { get; set; }
public string Rego { get; set; }
public string Fault { get; set; }
public string Location { get; set; }
public DateTime FixedOn { get; set; }
public string FixedOnBinding { get; set; }
public bool IsActive { get; set; }
public bool IsDeleted { get; set; }
public int CreatedBy { get; set; }
public List<object> MultipleImage { get; set; }
public int EmployeeId { get; set; }
public object VechicleName { get; set; }
public int Status { get; set; }
public string StatusName { get; set; }
public object DriverName { get; set; }
public string comments { get; set; }
public object Priorty { get; set; }
public object AssingToName { get; set; }
public int AssignedTo { get; set; }
public object ScheduleToDate { get; set; }
public object FromDate { get; set; }
public object ToDate { get; set; }
public object CompanyName { get; set; }
}

public class M_HomeResponse
{

public int StatusCode { get; set; }
public EmployeeObject EmployeeObject { get; set; }
public object NonDriverHome { get; set; }
public List<MechineHome> MechineHome { get; set; }
public object SubContractorHome { get; set; }
}


}
