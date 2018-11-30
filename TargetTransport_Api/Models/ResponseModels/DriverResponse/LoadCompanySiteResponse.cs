using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
   public class LoadCompanySiteResponse
    {
        public GetSiteResponse Response { get; set; }
    }
    public class CompanySiteList
    {
       
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string SiteInstructions { get; set; }
    public int SiteTimeOffset { get; set; }
    public string PrimarySiteContactId { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
    public int ClientId { get; set; }
    public object SearchKey { get; set; }
    public int Limit { get; set; }
    public int OffSet { get; set; }
}

public class GetSiteResponse
{
   
public int StatusCode { get; set; }
public List<CompanySiteList> CompanySiteList { get; set; }
public int Limit { get; set; }
public int OffSet { get; set; }
public int TotalCount { get; set; }
}


}
