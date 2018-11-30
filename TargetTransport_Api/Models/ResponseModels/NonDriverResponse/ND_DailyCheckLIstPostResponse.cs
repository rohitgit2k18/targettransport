using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.NonDriverResponse
{
   public class ND_DailyCheckLIstPostResponse
    {

        public ND_dailyChkPostResponse Response { get; set; }
    }
    

public class ND_dailyChkPostResponse
    {
    
    public int statusCode { get; set; }
    public int Id { get; set; }
    public string Message { get; set; }
    public string Description { get; set; }
    }


}
