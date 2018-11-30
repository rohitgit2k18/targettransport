using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
   public class Driver_MaintananceListRequest
    {
        public string CompanyId { get; set; }
        public string SearchKey { get; set; }
        public string Limit { get; set; }
        public string OffSet { get; set; }
        public int EmployeeId { get; set; }
    }
}
