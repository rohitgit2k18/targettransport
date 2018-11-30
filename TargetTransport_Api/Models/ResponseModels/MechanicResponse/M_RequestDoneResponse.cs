using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.MechanicResponse
{
   public class M_RequestDoneResponse
    {
        public MResponseReqDone Response { get; set; }
    }
    public class MResponseReqDone
    {   
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public object Description { get; set; }
    public object Data { get; set; }
    }

}
