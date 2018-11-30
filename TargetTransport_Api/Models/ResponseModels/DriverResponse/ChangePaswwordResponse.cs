using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
   public class ChangePaswwordResponse
    {
        public CPResponse Response { get; set; }
    }
    public class CPResponse
    {

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
