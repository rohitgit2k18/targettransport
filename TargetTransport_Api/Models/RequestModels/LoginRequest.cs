using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.RequestModels
{
   public class LoginRequest : BaseRequestModel
    {
        public LoginRequest()
        {
            //string Username, Password, Grant_type;
            //Username = userName;
            //Password = password;
            //Grant_type = grant_type;
        }
        public string _username;   
        public string userName
        {

            get
            {
                return _username;
            }
            set
            {
                _username = value; OnPropertyChanged();
            }
        }
        public string _paswword;
public string password
        {
            get
            {
                return _paswword;
            }
            set
            {
                _paswword = value; OnPropertyChanged();
            }
        }
        public string grant_type = "password";
    }
}
