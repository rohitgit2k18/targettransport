using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.NonDriverResponse
{
  public  class ND_SignatureResponse
    {
        public ND_SignResponse Response { get; set; }
    }
    public class ND_SignResponse
    {
        
    public int statusCode { get; set; }
    public int Id { get; set; }
    public string Message { get; set; }
}


}
