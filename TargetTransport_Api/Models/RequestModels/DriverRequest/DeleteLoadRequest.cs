using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
    public class DeleteLoadRequest
    {
        public int LoadId { get; set; }
        public string EmployeeId { get; set; }
    }
}
