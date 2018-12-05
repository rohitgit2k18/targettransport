using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
    /// <summary>
    /// 
    /// </summary>
   public class Driver_WorkSheetDetailsGetResponse
    {
        public WorksheetDetailResponse Response { get; set; }
    }
    public class WorkSheetItem
    {
        
    public DateTime W_WorkSheetDate { get; set; }
    public string W_StartTime { get; set; }
    public string W_EndTime { get; set; }
}

public class SchduleMaintenaceList
{
   
public int Id { get; set; }
public string Hrs_Kms { get; set; }
public int Identity { get; set; }
public int Fk_VehicleId { get; set; }
}

public class ClientFleetNumberMapping
{
   
public int ClientId { get; set; }
public string ClientName { get; set; }
public int VechicleId { get; set; }
public string FleetNumber { get; set; }
}

public class VehicleEntity
{
 
public int Id { get; set; }
public int ComapnyId { get; set; }
public object Image { get; set; }
public List<object> MultilpleImage { get; set; }
public string Make { get; set; }
public string Model { get; set; }
public int VehicleType { get; set; }
public string Capacity { get; set; }
public string Rego { get; set; }
public object FleetNumber { get; set; }
public DateTime RegoExpires { get; set; }
public DateTime COIExpires { get; set; }
public int CheckListId { get; set; }
public string Insurancer { get; set; }
public string Policy { get; set; }
public int SchduleMaintenaceTypeId { get; set; }
public int CreatedBy { get; set; }
public DateTime CreatedOn { get; set; }
public bool IsActive { get; set; }
public bool IsDeleted { get; set; }
public List<WorkSheetItem> WorkSheetItems { get; set; }
public object InsuranceExpires { get; set; }
public object RWC { get; set; }
public object LastServicesCompleted { get; set; }
public object EngineHrs { get; set; }
public object RegoExpiresDateFormat { get; set; }
public object COIExpiresDateFormat { get; set; }
public string PlantId { get; set; }
public int ClientId { get; set; }
public object FromDate { get; set; }
public object ToDate { get; set; }
public int ClientVehicleMappingList { get; set; }
public List<object> VehicleClientRelationList { get; set; }
public List<int> VehicleCheckListRelationList { get; set; }
public List<string> VehicleCheckListRelationName { get; set; }
public object VehicleCheckListRelationListDetail { get; set; }
public object VehicleClientRelationListDetail { get; set; }
public object VechicleList { get; set; }
public List<object> ClientIdFleetNo { get; set; }
public List<SchduleMaintenaceList> SchduleMaintenaceList { get; set; }
public object VehicleServiceRoutineList { get; set; }
public int OffSet { get; set; }
public int Limit { get; set; }
public object ImageStrings { get; set; }
public string VehicleTypeName { get; set; }
public object SearchKey { get; set; }
public object CompanyName { get; set; }
public object VechicleName { get; set; }
public string ChecklistName { get; set; }
public object ScheduelName { get; set; }
public object EmployeeId { get; set; }
public List<ClientFleetNumberMapping> ClientFleetNumberMapping { get; set; }
}

public class TollList
{
   
public int AccountId { get; set; }
public int UniqueId { get; set; }
public int CompanyId { get; set; }
public int SrNo { get; set; }
public string TollRoad { get; set; }
public string Location { get; set; }
public string TollPoint { get; set; }
public double TollCost { get; set; }
public int CreatedBy { get; set; }
public DateTime CreatedOn { get; set; }
public bool IsActive { get; set; }
public bool IsDeleted { get; set; }
public object SearchKey { get; set; }
public int Limit { get; set; }
public int OffSet { get; set; }
public DateTime FromDate { get; set; }
public DateTime ToDate { get; set; }
public object RegoNo { get; set; }
public object VechicleIds { get; set; }
public int ComapnyId { get; set; }
public int WorksheetTollId { get; set; }
}

public class WorksheetDetails
{
   
public int Id { get; set; }
public DateTime WorkSheetDate { get; set; }
        public string WorkSheetDateBD { get; set; }
public string StartTime { get; set; }
public string ProgramStartTime { get; set; }
public object JobNumber { get; set; }
public int ClientId { get; set; }
public int SiteId { get; set; }
public int JobKMs { get; set; }
public int AssignTo { get; set; }
public int EmployeeId { get; set; }
public string VehicleRego { get; set; }
public string Attachment { get; set; }
public int LoadTypeName { get; set; }
public string JobDescription { get; set; }
public int Createdby { get; set; }
public DateTime CreatedOn { get; set; }
public int ComapnyId { get; set; }
public string WorksheetStatus { get; set; }
public object Fleet { get; set; }
public int LoadId { get; set; }
public VehicleEntity VehicleEntity { get; set; }
public string SiteName { get; set; }
public string ClientName { get; set; }
public string ProgrammedStartTime { get; set; }
public string OffSiteFinishTime { get; set; }
public double TotalHourlyHire { get; set; }
public double TotalWaitTimePlant { get; set; }
public double TotalWaitTimeOnSite { get; set; }
public string WorksheetNumber { get; set; }
public object LoadData { get; set; }
public List<TollList> TollList { get; set; }
public double TotalTollAmount { get; set; }
public string EmployeeName { get; set; }
public bool Approval { get; set; }
public object ShiftName { get; set; }
public object PlantId { get; set; }
public object CustomerSign { get; set; }
public string SiteOffSite { get; set; }
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
public double TollCost { get; set; }
public int CreatedBy { get; set; }
public DateTime CreatedOn { get; set; }
public bool IsActive { get; set; }
public bool IsDeleted { get; set; }
public object SearchKey { get; set; }
public int Limit { get; set; }
public int OffSet { get; set; }
public DateTime FromDate { get; set; }
public DateTime ToDate { get; set; }
public object RegoNo { get; set; }
public object VechicleIds { get; set; }
public int ComapnyId { get; set; }
public int WorksheetTollId { get; set; }
}

public class AllLoadList
{
  
public int LoadId { get; set; }
public int WorkSheetId { get; set; }
public DateTime LoadingDate { get; set; }
public object LoadFrom { get; set; }
public string DeliverTo { get; set; }
public string BridgeDocket { get; set; }
public double NetWeight { get; set; }
public double KiloMeters { get; set; }
public object KiloStart { get; set; }
public object KiloEnd { get; set; }
public string StartDeport { get; set; }
public string DepartDeport { get; set; }
public double WaitTimePerMinute { get; set; }
public string ArriveJob { get; set; }
public string DepartJob { get; set; }
public double WaitTimePerMinuteJob { get; set; }
public object TollId { get; set; }
public string JobType { get; set; }
public string Start { get; set; }
public string Finish { get; set; }
public double Total { get; set; }
public string CustomerSign { get; set; }
public object TollIds { get; set; }
public List<Toll> Tolls { get; set; }
public double TotalTollAmount { get; set; }
public int CompanyId { get; set; }
public int TotalTolls { get; set; }
public int EmployeeId { get; set; }
public string Comments { get; set; }
}

public class WorksheetDetailResponse
    {
    
public int StatusCode { get; set; }
public WorksheetDetails WorksheetDetails { get; set; }
public List<AllLoadList> AllLoadList { get; set; }
}


//    public class WorkSheetItem
//    {
    
//    public DateTime? W_WorkSheetDate { get; set; }
//    public string W_StartTime { get; set; }
//    public string W_EndTime { get; set; }
//}

//public class SchduleMaintenaceList
//{
    
//public int Id { get; set; }
//public string Hrs_Kms { get; set; }
//public int Identity { get; set; }
//public int Fk_VehicleId { get; set; }
//}

//public class VehicleEntity
//{
    
//public int Id { get; set; }
//public int ComapnyId { get; set; }
//public object Image { get; set; }
//public List<string> MultilpleImage { get; set; }
//public string Make { get; set; }
//public string Model { get; set; }
//public int VehicleType { get; set; }
//public string Capacity { get; set; }
//public string Rego { get; set; }
//public DateTime? RegoExpires { get; set; }
//public DateTime? COIExpires { get; set; }
//public int CheckListId { get; set; }
//public string Insurancer { get; set; }
//public string Policy { get; set; }
//public int SchduleMaintenaceTypeId { get; set; }
//public int CreatedBy { get; set; }
//public DateTime? CreatedOn { get; set; }
//public bool IsActive { get; set; }
//public bool IsDeleted { get; set; }
//public List<WorkSheetItem> WorkSheetItems { get; set; }
//public DateTime? InsuranceExpires { get; set; }
//public object RWC { get; set; }
//public DateTime? LastServicesCompleted { get; set; }
//public object EngineHrs { get; set; }
//public object FromDate { get; set; }
//public object ToDate { get; set; }
//public int ClientVehicleMappingList { get; set; }
//public List<int> VehicleClientRelationList { get; set; }
//public List<int> VehicleCheckListRelationList { get; set; }
//public List<string> VehicleCheckListRelationName { get; set; }
//public object VehicleCheckListRelationListDetail { get; set; }
//public object VehicleClientRelationListDetail { get; set; }
//public object VechicleList { get; set; }
//public List<List<string>> ClientIdFleetNo { get; set; }
//public List<SchduleMaintenaceList> SchduleMaintenaceList { get; set; }
//public object VehicleServiceRoutineList { get; set; }
//public int OffSet { get; set; }
//public int Limit { get; set; }
//public object ImageStrings { get; set; }
//public string VehicleTypeName { get; set; }
//public object SearchKey { get; set; }
//public object CompanyName { get; set; }
//public object VechicleName { get; set; }
//public string ChecklistName { get; set; }
//public object ScheduelName { get; set; }
//public object EmployeeId { get; set; }
//}

//public class TollList
//{
  
//public int AccountId { get; set; }
//public int UniqueId { get; set; }
//public int CompanyId { get; set; }
//public int SrNo { get; set; }
//public string TollRoad { get; set; }
//public string Location { get; set; }
//public string TollPoint { get; set; }
//public int TollCost { get; set; }
//public int CreatedBy { get; set; }
//public DateTime CreatedOn { get; set; }
//public bool IsActive { get; set; }
//public bool IsDeleted { get; set; }
//public object SearchKey { get; set; }
//public int Limit { get; set; }
//public int OffSet { get; set; }
//public DateTime? FromDate { get; set; }
//public DateTime? ToDate { get; set; }
//public object RegoNo { get; set; }
//public object VechicleIds { get; set; }
//public int ComapnyId { get; set; }
//public int WorksheetTollId { get; set; }
//}

//public class WorksheetDetails
//{
 
//public int Id { get; set; }
//public DateTime? WorkSheetDate { get; set; }
//public string WorkSheetDateBD { get; set; }
//public string StartTime { get; set; }
//public string ProgramStartTime { get; set; }
//public int ClientId { get; set; }
//public int SiteId { get; set; }
//public int JobKMs { get; set; }
//public int AssignTo { get; set; }
//public int EmployeeId { get; set; }
//public string VehicleRego { get; set; }
//public string Attachment { get; set; }
//public int LoadTypeName { get; set; }
//        public string JobNumber { get; set; }
//public string JobDescription { get; set; }
//public int Createdby { get; set; }
//public DateTime? CreatedOn { get; set; }
//public int? ComapnyId { get; set; }
//public string WorksheetStatus { get; set; }
//public object Fleet { get; set; }
//public int LoadId { get; set; }
//public VehicleEntity VehicleEntity { get; set; }
//public string SiteName { get; set; }
//public string ClientName { get; set; }
//public string ProgrammedStartTime { get; set; }
//public string OffSiteFinishTime { get; set; }
//public double? TotalHourlyHire { get; set; }
//public double? TotalWaitTimePlant { get; set; }
//public double? TotalWaitTimeOnSite { get; set; }
//public string WorksheetNumber { get; set; }
//public object LoadData { get; set; }
//public List<TollList> TollList { get; set; }
//public double? TotalTollAmount { get; set; }
//public string EmployeeName { get; set; }
//public bool Approval { get; set; }
//public object ShiftName { get; set; }
//}

//public class Toll
//{
  
//public int AccountId { get; set; }
//public int UniqueId { get; set; }
//public int CompanyId { get; set; }
//public int SrNo { get; set; }
//public string TollRoad { get; set; }
//public string Location { get; set; }
//public string TollPoint { get; set; }
//public int TollCost { get; set; }
//public int CreatedBy { get; set; }
//public DateTime? CreatedOn { get; set; }
//public bool IsActive { get; set; }
//public bool IsDeleted { get; set; }
//public object SearchKey { get; set; }
//public int Limit { get; set; }
//public int OffSet { get; set; }
//public DateTime? FromDate { get; set; }
//public DateTime? ToDate { get; set; }
//public object RegoNo { get; set; }
//public object VechicleIds { get; set; }
//public int ComapnyId { get; set; }
//public int WorksheetTollId { get; set; }
//}

//public class AllLoadList
//{
   
//public int LoadId { get; set; }
//public int WorkSheetId { get; set; }
//public DateTime? LoadingDate { get; set; }
//public string LoadFrom { get; set; }
// public bool LoadStatus { get; set; }
//public string DeliverTo { get; set; }
//public string BridgeDocket { get; set; }
//public double? NetWeight { get; set; }
//public double? KiloMeters { get; set; }
//public string StartDeport { get; set; }
//public string DepartDeport { get; set; }
//public double? WaitTimePerMinute { get; set; }
//public string ArriveJob { get; set; }
//public string DepartJob { get; set; }
//public double? WaitTimePerMinuteJob { get; set; }
//public int? TollId { get; set; }
//public string JobType { get; set; }
//public string Start { get; set; }
//public string Finish { get; set; }
//public double? Total { get; set; }
//public string CustomerSign { get; set; }
//public object TollIds { get; set; }
//public List<Toll> Tolls { get; set; }
//public double? TotalTollAmount { get; set; }
//public int CompanyId { get; set; }
//public int TotalTolls { get; set; }
//public int EmployeeId { get; set; }
//        public List<ClientFleetNumberMapping> ClientFleetNumberMapping { get; set; }
//    }

//public class WorksheetDetailResponse
//    {
  
//public int StatusCode { get; set; }
//public WorksheetDetails WorksheetDetails { get; set; }
//public List<AllLoadList> AllLoadList { get; set; }
//        public string Message { get; set; }
//        public string Description { get; set; }
//    }
//    public class ClientFleetNumberMapping
//    {
        
//    public int ClientId { get; set; }
//    public string ClientName { get; set; }
//    public int VechicleId { get; set; }
//    public string FleetNumber { get; set; }
//}

//    /// <summary>
//    /// 
//    /// </summary>
//    public class WorkSheetItem
//    {       
//    public DateTime W_WorkSheetDate { get; set; }
//    public string W_StartTime { get; set; }
//    public string W_EndTime { get; set; }
//}
///// <summary>
///// 
///// </summary>
//public class VehicleEntity
//{  
//public int Id { get; set; }
//public int ComapnyId { get; set; }
//public string Image { get; set; }
//public List<object> MultilpleImage { get; set; }
//public string Make { get; set; }
//public string Model { get; set; }
//public int VehicleType { get; set; }
//public string Capacity { get; set; }
//public string Rego { get; set; }
//public DateTime RegoExpires { get; set; }
//public DateTime COIExpires { get; set; }
//public int CheckListId { get; set; }
//public string Insurancer { get; set; }
//public string Policy { get; set; }
//public int SchduleMaintenaceTypeId { get; set; }
//public int CreatedBy { get; set; }
//public DateTime CreatedOn { get; set; }
//public bool IsActive { get; set; }
//public bool IsDeleted { get; set; }
//public List<WorkSheetItem> WorkSheetItems { get; set; }
//public object FromDate { get; set; }
//public object ToDate { get; set; }
//public int ClientVehicleMappingList { get; set; }
//public List<object> VehicleClientRelationList { get; set; }
//public List<object> VehicleCheckListRelationList { get; set; }
//public List<object> VehicleCheckListRelationName { get; set; }
//public object VehicleCheckListRelationListDetail { get; set; }
//public object VehicleClientRelationListDetail { get; set; }
//public object VechicleList { get; set; }
//public List<object> ClientIdFleetNo { get; set; }
//public List<object> SchduleMaintenaceList { get; set; }
//public object VehicleServiceRoutineList { get; set; }
//public int OffSet { get; set; }
//public int Limit { get; set; }
//public object ImageStrings { get; set; }
//public string VehicleTypeName { get; set; }
//public object SearchKey { get; set; }
//public object CompanyName { get; set; }
//public object VechicleName { get; set; }
//public string ChecklistName { get; set; }
//public object ScheduelName { get; set; }
//public object EmployeeId { get; set; }
//}
///// <summary>
///// 
///// </summary>
//public class TollList
//{   
//public int AccountId { get; set; }
//public int UniqueId { get; set; }
//public int CompanyId { get; set; }
//public int SrNo { get; set; }
//public string TollRoad { get; set; }
//public string Location { get; set; }
//public string TollPoint { get; set; }
//public int TollCost { get; set; }
//public int CreatedBy { get; set; }
//public DateTime CreatedOn { get; set; }
//public bool IsActive { get; set; }
//public bool IsDeleted { get; set; }
//public object SearchKey { get; set; }
//public int Limit { get; set; }
//public int OffSet { get; set; }
//public DateTime FromDate { get; set; }
//public DateTime ToDate { get; set; }
//public object RegoNo { get; set; }
//public object VechicleIds { get; set; }
//public int ComapnyId { get; set; }
//public int WorksheetTollId { get; set; }
//}
///// <summary>
///// 
///// </summary>
//public class WorksheetDetails
//{   
//public int Id { get; set; }
//public DateTime WorkSheetDate { get; set; }
//public string StartTime { get; set; }
//public string ProgramStartTime { get; set; }
//public int ClientId { get; set; }
//public int SiteId { get; set; }
//public int JobKMs { get; set; }
//public int AssignTo { get; set; }
//public int EmployeeId { get; set; }
//public string VehicleRego { get; set; }
//public string Attachment { get; set; }
//public int LoadTypeName { get; set; }
//public string JobDescription { get; set; }
//public int Createdby { get; set; }
//public DateTime CreatedOn { get; set; }
//public int ComapnyId { get; set; }
//public string WorksheetStatus { get; set; }
//public object Fleet { get; set; }
//public int LoadId { get; set; }
//public VehicleEntity VehicleEntity { get; set; }
//public object SiteName { get; set; }
//public object ClientName { get; set; }
//public string ProgrammedStartTime { get; set; }
//public string OffSiteFinishTime { get; set; }
//public int TotalHourlyHire { get; set; }
//public double TotalWaitTimePlant { get; set; }
//public double TotalWaitTimeOnSite { get; set; }
//public object WorksheetNumber { get; set; }
//public object LoadData { get; set; }
//public List<TollList> TollList { get; set; }
//public int TotalTollAmount { get; set; }
//public object EmployeeName { get; set; }
//}
///// <summary>
///// 
///// </summary>
//public class Toll
//{   
//public int AccountId { get; set; }
//public int UniqueId { get; set; }
//public int CompanyId { get; set; }
//public int SrNo { get; set; }
//public string TollRoad { get; set; }
//public string Location { get; set; }
//public string TollPoint { get; set; }
//public int TollCost { get; set; }
//public int CreatedBy { get; set; }
//public DateTime CreatedOn { get; set; }
//public bool IsActive { get; set; }
//public bool IsDeleted { get; set; }
//public object SearchKey { get; set; }
//public int Limit { get; set; }
//public int OffSet { get; set; }
//public DateTime FromDate { get; set; }
//public DateTime ToDate { get; set; }
//public object RegoNo { get; set; }
//public object VechicleIds { get; set; }
//public int ComapnyId { get; set; }
//public int WorksheetTollId { get; set; }
//}
///// <summary>
///// 
///// </summary>
//public class AllLoadList
//{   
//public int LoadId { get; set; }
//public int WorkSheetId { get; set; }
//public DateTime LoadingDate { get; set; }
//public string LoadFrom { get; set; }
//public string DeliverTo { get; set; }
//public string BridgeDocket { get; set; }
//public int NetWeight { get; set; }
//public double KiloMeters { get; set; }
//public string StartDeport { get; set; }
//public string DepartDeport { get; set; }
//public double WaitTimePerMinute { get; set; }
//public string ArriveJob { get; set; }
//public string DepartJob { get; set; }
//public double WaitTimePerMinuteJob { get; set; }
//public int TollId { get; set; }
//public string JobType { get; set; }
//public string Start { get; set; }
//public string Finish { get; set; }
//public int Total { get; set; }
//public string CustomerSign { get; set; }
//public object TollIds { get; set; }
//public List<Toll> Tolls { get; set; }
//public int TotalTollAmount { get; set; }
//public int CompanyId { get; set; }
//public int TotalTolls { get; set; }
//public int EmployeeId { get; set; }
//}
///// <summary>
///// 
///// </summary>
//public class WorksheetDetailResponse
//{ 
//public int StatusCode { get; set; }
//public string Message { get; set; }
// public string Description { get; set; }
// public WorksheetDetails WorksheetDetails { get; set; }
//public List<AllLoadList> AllLoadList { get; set; }
//}
}
