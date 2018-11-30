using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
   public class Driver_LoadSignOffResquest
    {
        public string LoadId { get; set; }
        public string CustomerSign { get; set; }
        public string CustomerName { get; set; }
    }
}
