﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
   public class Driver_SelectVehicleRequest
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public int ClientId { get; set; }
    }
}
