using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
  public  class AddWorkSheetRequestModel
    {
        public int Id { get; set; }
        public DateTime WorkSheetDate { get; set; }
        public string WorkSheetDateFormate { get; set; }
        public DateTime ToDate { get; set; }
        public string StartTime { get; set; }
        public string ProgramStartTime { get; set; }
        public int ClientId { get; set; }
        public int SiteId { get; set; }
        public string JobKMs { get; set; }
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
        public List<LoadData> LoadData { get; set; }
        public bool Approval { get; set; }
        public int ShiftType { get; set; }
        public string ShiftName { get; set; }
        public int Limit { get; set; }
        public int OffSet { get; set; }
        public DateTime FromDate { get; set; }
        public string Rego { get; set; }
        public string DriverName { get; set; }
        public DateTime FDate { get; set; }
        public DateTime TDate { get; set; }
        public int StaffId { get; set; }
        public string ClientIds { get; set; }
        public List<int> WorksheetTollsRelations { get; set; }
        public string Vechicleids { get; set; }
        public int LoadId { get; set; }
        public List<TollList> TollList { get; set; }
        public string VechicleName { get; set; }
        public string ClientName { get; set; }
        public string SiteName { get; set; }
        public string AssignToName { get; set; }
        public string InvoiceStatusName { get; set; }
        public string EmployeeName { get; set; }
        public string LoadTypeName { get; set; }
        public string OrderBy { get; set; }
        public string Search { get; set; }
        public int CompanyId { get; set; }
        public string CustomerSign { get; set; }
        public string CustomerName { get; set; }
    }
    public class Toll
    {
       
    public int AccountId { get; set; }
    public int UniqueId { get; set; }
    public int CompanyId { get; set; }
    public int SrNo { get; set; }
    public string TollRoad { get; set; }
    public string Location { get; set; }
    public string TollPoint { get; set; }
    public int TollCost { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string SearchKey { get; set; }
    public int Limit { get; set; }
    public int OffSet { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public string RegoNo { get; set; }
    public string VechicleIds { get; set; }
    public int ComapnyId { get; set; }
    public int WorksheetTollId { get; set; }
   
}

public class LoadData
{
    
public int LoadId { get; set; }
public int WorkSheetId { get; set; }
public DateTime LoadingDate { get; set; }
public string LoadFrom { get; set; }
public string DeliverTo { get; set; }
public string BridgeDocket { get; set; }
public double NetWeight { get; set; }
public double KiloMeters { get; set; }
public string StartDeport { get; set; }
public string DepartDeport { get; set; }
public double WaitTimePerMinute { get; set; }
public string ArriveJob { get; set; }
public string DepartJob { get; set; }
public double WaitTimePerMinuteJob { get; set; }
public int TollId { get; set; }
public string JobType { get; set; }
public string Start { get; set; }
public string Finish { get; set; }
public double Total { get; set; }
public string CustomerSign { get; set; }
public List<int> TollIds { get; set; }
public List<Toll> Tolls { get; set; }
public double TotalTollAmount { get; set; }
public int CompanyId { get; set; }
public int TotalTolls { get; set; }
public int EmployeeId { get; set; }

}

public class TollList
{

}

public class RootObject
{
   
}
}
