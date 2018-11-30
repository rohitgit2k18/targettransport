using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.MechanicRequest
{
   public class M_SignatureRequest
    {
        public string MaintenenceRequestDoneId { get; set; }
        public string MechanicSign { get; set; }
        public string CustomerName { get; set; }
    }
}
