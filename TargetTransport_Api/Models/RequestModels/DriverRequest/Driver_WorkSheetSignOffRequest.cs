using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
   public class Driver_WorkSheetSignOffRequest
    {
        //WorkSheetID
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSign { get; set; }           
        public TimeSpan OffSiteFinishTime { get; set; }
    }
}
