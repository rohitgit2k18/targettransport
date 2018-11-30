using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
   public class Driver_AddMaintananceRequest
    {
        public Driver_AddMaintananceRequest()
        {
            MultilpleImage = new List<string>();
        }
        public string CompanyId { get; set; }
        public DateTime RequestDate { get; set; }
        public string VehicleName { get; set; }
        public string Rego { get; set; }
        public string Fault { get; set; }
        public string Location { get; set; }
        public List<string> MultilpleImage { get; set; }
        public string Assignedto { get; set; }
        public DateTime? FixedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int EmployeeId { get; set; }
    }
}
