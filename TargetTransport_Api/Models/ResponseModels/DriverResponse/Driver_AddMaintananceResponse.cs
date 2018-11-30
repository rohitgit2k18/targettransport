﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
   public class Driver_AddMaintananceResponse
    {
        public AMaintananceResponse Response { get; set; }
    }
    public class AMaintananceResponse
    {       
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public object Description { get; set; }
}
}
