using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
  public  class Driver_EndOfShiftRequest
    {
        public string StaffDate { get; set; }
        public string Staff_Date { get; set; }
        public string StaffTime { get; set; }
        public string Odometer { get; set; }
        public string FuelAdded { get; set; }
        public string EngineHrs { get; set; }
        public string AdBlue { get; set; }
        public string PlantRegoId { get; set; }
        public string TyreChecked { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public string CompanyId { get; set; }
        public string Signature { get; set; }
        public string EmployeeId { get; set; }
    }
}
