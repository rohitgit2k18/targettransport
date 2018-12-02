using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
   public class Driver_TollsListResponse
    {
        public TollsResponse Response { get; set; }
    }
    public class AccountSettingTollList
    {
       
    public int AccountId { get; set; }
    public int UniqueId { get; set; }
    public int CompanyId { get; set; }
    public int SrNo { get; set; }
    public string TollRoad { get; set; }
    public string Location { get; set; }
    public string TollPoint { get; set; }
    public int TollCost { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public object SearchKey { get; set; }
    public int Limit { get; set; }
    public int OffSet { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public object RegoNo { get; set; }
    public object VechicleIds { get; set; }
    public int ComapnyId { get; set; }
    public int WorksheetTollId { get; set; }




}

public class TollsResponse
    {
    
public int StatusCode { get; set; }
public List<AccountSettingTollList> AccountSettingTollList { get; set; }
public int Limit { get; set; }
public int OffSet { get; set; }
public int TotalCount { get; set; }
public string Message { get; set; }
public string Description { get; set; }
    }


    //    public class AccountSettingTollList
    //    {

    //    public int AccountId { get; set; }
    //    public int UniqueId { get; set; }
    //    public int CompanyId { get; set; }
    //    public int SrNo { get; set; }
    //    public string TollRoad { get; set; }
    //    public string Location { get; set; }
    //    public string TollPoint { get; set; }
    //    public int TollCost { get; set; }
    //    public int CreatedBy { get; set; }
    //    public DateTime CreatedOn { get; set; }
    //    public bool IsActive { get; set; }
    //    public bool IsDeleted { get; set; }
    //    public object SearchKey { get; set; }
    //    public int Limit { get; set; }
    //    public int OffSet { get; set; }
    //    public DateTime FromDate { get; set; }
    //    public DateTime ToDate { get; set; }
    //    public object RegoNo { get; set; }
    //    public object VechicleIds { get; set; }
    //    public int ComapnyId { get; set; }
    //    public int WorksheetTollId { get; set; }
    //}

    //public class TollsResponse
    //{

    //public int StatusCode { get; set; }
    //public string Message { get; set; }
    //public string Description { get; set; }
    //public List<AccountSettingTollList> AccountSettingTollList { get; set; }
    //public int Limit { get; set; }
    //public int OffSet { get; set; }
    //public int TotalCount { get; set; }
    //}

}
