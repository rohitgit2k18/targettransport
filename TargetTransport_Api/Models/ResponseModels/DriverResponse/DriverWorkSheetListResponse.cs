using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
   public class DriverWorkSheetListResponse
    {
        public WorkSheetListEntity Response { get; set; }
    }
    public class WorksheetListByEmployee
    {
       
    public int Id { get; set; }
    public DateTime WorkSheetDate { get; set; }
    public string WorkSheetDateBinding { get; set; }
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
    public object ClientName { get; set; }
    public object SiteName { get; set; }
    public object AssignToName { get; set; }
    public object InvoiceStatusName { get; set; }
    public object EmployeeName { get; set; }
    public object LoadTypeName { get; set; }
    public object OrderBy { get; set; }
    public object Search { get; set; }
        public string ProgressImage { get; set; }
        public string CompletedImage { get; set; }
}

    public class WorkSheetListEntity
    {  
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public object WorksheetList { get; set; }
        public List<WorksheetListByEmployee> WorksheetListByEmployee { get; set; }
        public int Limit { get; set; }
        public int OffSet { get; set; }
        public int TotalCount { get; set; }
        public object WorksheetNo { get; set; }
    }
}
