using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
   public class Driver_MaintananceListResponse
    {
        public MListResponse Response { get; set; }
    }
    public class MaintenanceRequestList
    {
      
    public int? Id { get; set; }
    public int? CompanyId { get; set; }
    public DateTime? RequestDate { get; set; }
    public string VehicleName { get; set; }
    public string Rego { get; set; }
    public string Fault { get; set; }
    public string Location { get; set; }
    public List<string> MultilpleImage { get; set; }
    public int Assignedto { get; set; }
    public DateTime? FixedOn { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? EmployeeId { get; set; }
    public string AssignedToName { get; set; }
          
    }

public class MListResponse
    {
   
public int StatusCode { get; set; }
public List<MaintenanceRequestList> MaintenanceRequestList { get; set; }
public object MaintenanceList { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
