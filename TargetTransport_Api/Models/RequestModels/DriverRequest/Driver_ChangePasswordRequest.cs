﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
   public class Driver_ChangePasswordRequest
    {
        public string NewPassword { get; set; }
        public string Token { get; set; }
    }
}
