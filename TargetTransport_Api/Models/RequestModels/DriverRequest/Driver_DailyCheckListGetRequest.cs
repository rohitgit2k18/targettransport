using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
    public class Driver_DailyCheckListGetRequest
    {
        public int Id { get; set; }
        public string WorksheetId { get; set; }
        public long DefaultVehicleId { get; set; }



    }
}
