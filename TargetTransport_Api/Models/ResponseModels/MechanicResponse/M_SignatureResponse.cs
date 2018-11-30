using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.MechanicResponse
{
  public  class M_SignatureResponse
    {
        public M_Sign_Response Response { get; set; }
    }
    public class M_Sign_Response
    {
   
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public object Description { get; set; }
}

}
