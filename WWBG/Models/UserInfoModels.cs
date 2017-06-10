using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.core.Models;

namespace WWBG.Models
{
    public class UserInfoModels
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public bool IsActive { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}