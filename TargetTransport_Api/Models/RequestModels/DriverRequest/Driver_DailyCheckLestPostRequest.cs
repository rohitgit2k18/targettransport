using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels.DriverRequest
{
   public class Driver_DailyCheckLestPostRequest
    {
        public string EmployeeId { get; set; }
        public string WorksheetId { get; set; }
        public string VechicleId { get; set; }
        public string SelectChecklist { get; set; }
        public string QuestionChecelist { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
    }
}
