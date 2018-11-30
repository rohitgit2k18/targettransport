using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
    public class Driver_TollsListRequest
    {
        public int ComapnyId { get; set; }
        public string SearchKey { get; set; }
        public int Limit { get; set; }
        public int OffSet { get; set; }
    }
}
