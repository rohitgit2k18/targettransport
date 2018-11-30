using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.NonDriverRequest
{
   public class ND_TimeSheetRequest
    {
        public DateTime WorkDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeId { get; set; }
    }
}
