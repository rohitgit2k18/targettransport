using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
  public class Driver_AddLoadRequest
    {
        public Driver_AddLoadRequest()
        {
            TollIds = new List<long>();
        }
        public string WorkSheetId { get; set; }
        public DateTime LoadingDate { get; set; }
        public string LoadFrom { get; set; }
        public string DeliverTo { get; set; }
        public string BridgeDocket { get; set; }
        public string NetWeight { get; set; }
        public string KiloMeters { get; set; }
        public string StartDeport { get; set; }
        public string DepartDeport { get; set; }
        public string WaitTimePerMinute { get; set; }
        public string ArriveJob { get; set; }
        public string DepartJob { get; set; }
        public string WaitTimePerMinuteJob { get; set; }
        public string TollId { get; set; }
        public string JobType { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }
        public List<long> TollIds { get; set; }
        public string Total { get; set; }
        public string CustomerSign { get; set; }
        public string Comments { get; set; }
    }
}
