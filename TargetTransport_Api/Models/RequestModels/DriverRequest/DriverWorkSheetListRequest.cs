using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
   public class DriverWorkSheetListRequest
    {
        public string EmployeeId { get; set; }
        public string OrderBy { get; set; }
        public string Search { get; set; }
    }
}
