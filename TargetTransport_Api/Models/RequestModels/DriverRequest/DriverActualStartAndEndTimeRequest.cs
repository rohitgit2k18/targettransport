using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
   public class DriverActualStartAndEndTimeRequest
    {
        public int Id { get; set; }
        public DateTime? WorkDate { get; set; }
        public string ProgramStartTime { get; set; }
        public string ApprovedStartTime { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime? EndDate { get; set; }
        public string StartTime { get; set; }
        public string BreakTime { get; set; }
        public string Comments { get; set; }
        public string WorkHours { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int EmployeeId { get; set; }
        public string WorksheetNumber { get; set; }
        public int WorksheetId { get; set; }
        public int TotalHrs { get; set; }
    }
}
