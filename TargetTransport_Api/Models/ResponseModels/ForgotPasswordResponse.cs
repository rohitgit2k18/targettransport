using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels
{
   public class ForgotPasswordResponse
    {
        public ForgotPassRespEntity Response { get; set; }
    }
    public class ForgotPassRespEntity
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
