﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
   public class Driver_SignatureResponse
    {
        public SignatureResponse Response { get; set; }
    }
    public class SignatureResponse
    {      
    public int statusCode { get; set; }
    public int Id { get; set; }
    public string Message { get; set; }
    public string Description { get; set; }
    }
}
