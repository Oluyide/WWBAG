using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using web.core.Models;

namespace WWBG.Models
{
    public class ProfileModels
    {
        public List<ProfileModels> ProfileList { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Academic { get; set; }
        public string Faculty { get; set; }
        public string Sex { get; set; }
        public string DateBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string UserId { get; set; }
      //  public Nullable<int> UserinfoId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public List<UserInfoModels> userInfoList { get; set; }

    }
}