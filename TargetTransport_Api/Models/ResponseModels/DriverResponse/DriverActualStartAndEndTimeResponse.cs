using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
   public class DriverActualStartAndEndTimeResponse
    {
        public Driver_StartAndEndResponse Response { get; set; }
    }

    public class Driver_StartAndEndResponse
    {
        
    public int StatusCode { get; set; }
    public object WorkTimeList { get; set; }
   
    public string TotalHrs { get; set; }
}

}
