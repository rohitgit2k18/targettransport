using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
   public class Driver_LoadTypeResponse
    {
        public LoadTypesResponse Response { get; set; }
    }

    public class LoadType
    {
       
    public int Id { get; set; }
    public string Type { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
}

public class LoadTypesResponse
{
   
public int StatusCode { get; set; }
public string Message { get; set; }
public string Description { get; set; }
public List<LoadType> LoadTypes { get; set; }
}

}
