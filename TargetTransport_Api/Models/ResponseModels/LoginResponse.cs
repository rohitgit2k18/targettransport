using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels
{
   public class LoginResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string userID { get; set; }
        public string imageUrl { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set;}
        public string userType { get; set; }
        public string Username { get; set; }
        public DateTime issued { get; set; }
        public string expires
        {
            get;
            set;
        }

    }
}
