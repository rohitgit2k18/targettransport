using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.NonDriverResponse
{
  public  class NonDriver_DailyCheckListResponse
    {
        public NDCheckResponse Response { get; set; }
    }
    public class QuestionList
    {
    
    public int id { get; set; }
    public int Fk_RoleId { get; set; }
    public int CompanyId { get; set; }
    public string QuestionName { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public object SearchKey { get; set; }
    public int Limit { get; set; }
    public int OffSet { get; set; }
    public object Question { get; set; }
    public object RoleList { get; set; }
    public object CompanyId_RoleList { get; set; }
    public object CompanyId_Question { get; set; }
    public object ANS { get; set; }
        public List<string> LoadAnswerOptions { get; set; }
}

public class CheckListList
{

public int id { get; set; }
public int Fk_RoleId { get; set; }
public int CompanyId { get; set; }
public string ChecklistName { get; set; }
public int CreatedBy { get; set; }
public DateTime CreatedOn { get; set; }
public bool IsActive { get; set; }
public bool IsDeleted { get; set; }
public object SearchKey { get; set; }
public int Limit { get; set; }
public int OffSet { get; set; }
}

public class NDCheckResponse
{

public int StatusCode { get; set; }
public List<QuestionList> QuestionList { get; set; }
public List<CheckListList> CheckListList { get; set; }
public int WorksheetId { get; set; }
public object RegoNo { get; set; }
}


}
