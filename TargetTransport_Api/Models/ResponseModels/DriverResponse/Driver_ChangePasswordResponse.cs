using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
  public  class Driver_ChangePasswordResponse
  {
        public ChangeResponse Response { get; set; }
  }
   

      public class ChangeResponse
      {
      
        public int statusCode { get; set; }
        public int Id { get; set; }
       public string Message { get; set; }
      }
}
