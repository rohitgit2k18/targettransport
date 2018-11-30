using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.MechanicRequest
{
   public class M_RequestDoneRequest
    {
        public M_RequestDoneRequest()
        {
            MultipleImage = new List<string>();
        }
        public Int32 MaintenenceRequestId { get; set; }
        public string Checklist { get; set; }
        public int EmployeeId { get; set; }
        public string Comments { get; set; }
        public List<string> MultipleImage { get; set; }
    }
}
