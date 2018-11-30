using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
  public  class DriverSelectVehicleResonse
    {
        public VehicleResponse Response { get; set; }
    }
    public class VechicleListByEmployeeId
    {
        
    public int Id { get; set; }
    public int ComapnyId { get; set; }
    public string Image { get; set; }
    public object MultilpleImage { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int VehicleType { get; set; }
    public string Capacity { get; set; }
    public string Rego { get; set; }
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
    public object WorkSheetItems { get; set; }
    public object FromDate { get; set; }
    public object ToDate { get; set; }
    public int ClientVehicleMappingList { get; set; }
    public object VehicleClientRelationList { get; set; }
    public object VehicleCheckListRelationList { get; set; }
    public object VehicleCheckListRelationName { get; set; }
    public object VehicleCheckListRelationListDetail { get; set; }
    public object VehicleClientRelationListDetail { get; set; }
    public object VechicleList { get; set; }
    public object ClientIdFleetNo { get; set; }
    public object SchduleMaintenaceList { get; set; }
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
}
    public class VehicleResponse
    {
       
    public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public List<VechicleListByEmployeeId> VechicleListByEmployeeId { get; set; }
}
}
