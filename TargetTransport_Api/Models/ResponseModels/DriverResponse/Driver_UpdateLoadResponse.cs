﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
  public  class Driver_UpdateLoadResponse
    {
        public UpdateLoadResponse Response { get; set; }
    }
    public class UpdateLoadResponse
    {
       
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public object Description { get; set; }
}

}
