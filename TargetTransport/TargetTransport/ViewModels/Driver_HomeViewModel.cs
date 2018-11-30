using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Helpers;

namespace TargetTransport.ViewModels
{
   public class Driver_HomeViewModel
    {
        public Driver_HomeViewModel()
        {
            this.Name = Settings.Name;
            this.ProfileImage = Settings.ProfilePicture;
            this.Email = Settings.UserName;
            this.PhoneNo = Settings.PhoneNo;
        }
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
}
