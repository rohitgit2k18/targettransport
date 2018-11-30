using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
  public  class Driver_GetClientsResponse
    {
        public ClientResResponse Response { get; set; }
    }
    public class ClientList
    {
      
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string StreetAddress { get; set; }
    public string BillingAddress { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
    public string TrendingTerms { get; set; }
    public string Fleet_ { get; set; }
    public string ClientName { get; set; }
    public string ABN { get; set; }
    public string ACN { get; set; }
    public string ClientLogoURL { get; set; }
    public object SearchKey { get; set; }
    public int Limit { get; set; }
    public int OffSet { get; set; }
    public object ClientLogoBase64 { get; set; }
    public object FromDate { get; set; }
    public object ToDate { get; set; }
    public object ClientIdList { get; set; }
    public object RegoNo { get; set; }
    public object ClientIds { get; set; }
    public object CompanyName { get; set; }
}

public class ClientResResponse
{
   
public int StatusCode { get; set; }
public List<ClientList> ClientList { get; set; }
public int Limit { get; set; }
public int OffSet { get; set; }
public int TotalCount { get; set; }
public object ClientEntity { get; set; }
}

public class RootObject
{
   

}
}
