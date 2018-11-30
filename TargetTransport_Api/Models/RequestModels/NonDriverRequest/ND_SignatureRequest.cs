using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.NonDriverRequest
{
  public  class ND_SignatureRequest
    {
        public string AddCheckListId { get; set; }
        public string DriverSign { get; set; }
    }
}
