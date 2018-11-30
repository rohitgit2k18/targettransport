using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
    public  class Driver_DailyCheckListGetResponse
    {
        public DailyChecklistResponseEntity Response { get; set; }
    }
    public class QuestionList
    {

        public int id { get; set; }
        public int? Fk_RoleId { get; set; }
        public int? CompanyId { get; set; }
        public string QuestionName { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string SearchKey { get; set; }
        public int Limit { get; set; }
        public int OffSet { get; set; }
        public string Question { get; set; }
        public string RoleList { get; set; }
        public long? CompanyId_RoleList { get; set; }
        public int? CompanyId_Question { get; set; }
        public List<string> LoadAnswerOptions { get; set; }
}

    public class CheckListList
    {
   
    public int id { get; set; }
    public int Fk_RoleId { get; set; }
    public long? CompanyId { get; set; }
    public string ChecklistName { get; set; }
    public long CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string SearchKey { get; set; }
    public int Limit { get; set; }
    public int OffSet { get; set; }
    }

    public class DailyChecklistResponseEntity
    {
   
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string Description { get; set; }
        public List<QuestionList> QuestionList { get; set; }
    public List<CheckListList> CheckListList { get; set; }
    public int WorksheetId { get; set; }
    public string RegoNo { get; set; }
    }
    }
