using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.MechanicResponse
{
   public class M_GetViewDetailsResponse
    {
        public M_DetailsResponse Response { get; set; }
    }
    public class Data
    {
    
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public DateTime RequestDate { get; set; }
    public string Rego { get; set; }
    public string Fault { get; set; }
    public string Location { get; set; }
    public DateTime FixedOn { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public int CreatedBy { get; set; }
    public List<object> MultipleImage { get; set; }
    public int EmployeeId { get; set; }
    public string VechicleName { get; set; }
    public int Status { get; set; }
    public object StatusName { get; set; }
    public object DriverName { get; set; }
    public string comments { get; set; }
    public object Priorty { get; set; }
    public object AssingToName { get; set; }
    public int AssignedTo { get; set; }
    public object ScheduleToDate { get; set; }
    public object FromDate { get; set; }
    public object ToDate { get; set; }
    public object CompanyName { get; set; }
}

public class M_DetailsResponse
{
 
public int StatusCode { get; set; }
public string Message { get; set; }
public object Description { get; set; }
public Data Data { get; set; }
}


}
