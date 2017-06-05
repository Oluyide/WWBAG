using System;
using System.Collections.Generic;

namespace web.core.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            this.UserProfiles = new List<UserProfile>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public bool IsActive { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
